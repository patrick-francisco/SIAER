/**********************************************************************************************
  Copyright 2007-2009 Texas Instruments Incorporated. All rights reserved.

  IMPORTANT: Your use of this Software is limited to those specific rights granted under
  the terms of a software license agreement between the user who downloaded the software,
  his/her employer (which must be your employer) and Texas Instruments Incorporated (the
  "License"). You may not use this Software unless you agree to abide by the terms of the
  License. The License limits your use, and you acknowledge, that the Software may not be
  modified, copied or distributed unless embedded on a Texas Instruments microcontroller
  or used solely and exclusively in conjunction with a Texas Instruments radio frequency
  transceiver, which is integrated into your product. Other than for the foregoing purpose,
  you may not use, reproduce, copy, prepare derivative works of, modify, distribute,
  perform, display or sell this Software and/or its documentation for any purpose.

  YOU FURTHER ACKNOWLEDGE AND AGREE THAT THE SOFTWARE AND DOCUMENTATION ARE PROVIDED “AS IS”
  WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION, ANY
  WARRANTY OF MERCHANTABILITY, TITLE, NON-INFRINGEMENT AND FITNESS FOR A PARTICULAR PURPOSE.
  IN NO EVENT SHALL TEXAS INSTRUMENTS OR ITS LICENSORS BE LIABLE OR OBLIGATED UNDER CONTRACT,
  NEGLIGENCE, STRICT LIABILITY, CONTRIBUTION, BREACH OF WARRANTY, OR OTHER LEGAL EQUITABLE
  THEORY ANY DIRECT OR INDIRECT DAMAGES OR EXPENSES INCLUDING BUT NOT LIMITED TO ANY
  INCIDENTAL, SPECIAL, INDIRECT, PUNITIVE OR CONSEQUENTIAL DAMAGES, LOST PROFITS OR LOST
  DATA, COST OF PROCUREMENT OF SUBSTITUTE GOODS, TECHNOLOGY, SERVICES, OR ANY CLAIMS BY
  THIRD PARTIES (INCLUDING BUT NOT LIMITED TO ANY DEFENSE THEREOF), OR OTHER SIMILAR COSTS.

  Should you have any questions regarding your right to use this Software,
  contact Texas Instruments Incorporated at www.TI.com.
**************************************************************************************************/
#include <string.h>
#include "bsp.h"
#include "mrfi.h"
#include "bsp_leds.h"
#include "bsp_buttons.h"
#include "nwk_types.h"
#include "nwk_api.h"
#include "nwk_frame.h"
#include "nwk.h"
#include "simpliciti.h"
#include "app_remap_led.h"

#ifndef APP_AUTO_ACK
#error ERROR: Must define the macro APP_AUTO_ACK for this application.
#endif

void toggleLED(uint8_t);

// CRIAR METODO PARA ENVIAR MENSAGEM PARA O ED
// FILTRAR MENSAGEM E EENVIAR VIA UART
// 
extern void TXString (char* string, int length);

/* reserve space for the maximum possible peer Link IDs */
static linkID_t sLID[NUM_CONNECTIONS] = {0};
static uint8_t  sNumCurrentPeers = 0;

/* callback handler */
static uint8_t sCB(linkID_t);

/* received message handler */
static void processMessage(linkID_t, uint8_t *, uint8_t);

/* Frequency Agility helper functions */
static void    checkChangeChannel(void);
static void    changeChannel(void);

/* work loop semaphores */
static volatile uint8_t sPeerFrameSem = 0;
static volatile uint8_t sJoinSem = 0;

#ifdef FREQUENCY_AGILITY
/*     ************** BEGIN interference detection support */

#define INTERFERNCE_THRESHOLD_DBM (-70)
#define SSIZE    25
#define IN_A_ROW  3
static int8_t  sSample[SSIZE];
static uint8_t sChannel = 0;
#endif  /* FREQUENCY_AGILITY */

/* blink LEDs when channel changes... */
static volatile uint8_t sBlinky = 0;
unsigned char ed_data[RF_MSG_SIZE];
/*     ************** END interference detection support                       */

#define SPIN_ABOUT_A_QUARTER_SECOND   NWK_DELAY(250)

void main_access_point (void)
{
  uint8_t   len, i;	
  bspIState_t intState;
  
#ifdef FREQUENCY_AGILITY
  memset(sSample, 0x0, sizeof(sSample));
  #endif  /* FREQUENCY_AGILITY */
  BSP_Init();

  /* If an on-the-fly device address is generated it must be done before the
   * call to SMPL_Init(). If the address is set here the ROM value will not
   * be used. If SMPL_Init() runs before this IOCTL is used the IOCTL call
   * will not take effect. One shot only. The IOCTL call below is conformal.
   */
#ifdef I_WANT_TO_CHANGE_DEFAULT_ROM_DEVICE_ADDRESS_PSEUDO_CODE
  {
    addr_t lAddr;

    createRandomAddress(&lAddr);
    SMPL_Ioctl(IOCTL_OBJ_ADDR, IOCTL_ACT_SET, &lAddr);
  }
#endif /* I_WANT_TO_CHANGE_DEFAULT_ROM_DEVICE_ADDRESS_PSEUDO_CODE */

  SMPL_Init(sCB);

  /* green and red LEDs on solid to indicate waiting for a Join. */
  if (!BSP_LED2_IS_ON())
  {
    toggleLED(2);
  }
  if (!BSP_LED1_IS_ON())
  {
    toggleLED(1);
  }

  // main work loop
   
  while (1)
  {
    /* Wait for the Join semaphore to be set by the receipt of a Join frame from a
     * device that supports an End Device.
     *
     * An external method could be used as well. A button press could be connected
     * to an ISR and the ISR could set a semaphore that is checked by a function
     * call here, or a command shell running in support of a serial connection
     * could set a semaphore that is checked by a function call.
     */     
     
    if (sJoinSem && (sNumCurrentPeers < NUM_CONNECTIONS))
    {
      // listen for a new connection
      while (1)
      {
        if (SMPL_SUCCESS == SMPL_LinkListen(&sLID[sNumCurrentPeers]))
        {
          break;
        }
        // Implement fail-to-link policy here. otherwise, listen again.
      }

      sNumCurrentPeers++;

      BSP_ENTER_CRITICAL_SECTION(intState);
      sJoinSem--;
      BSP_EXIT_CRITICAL_SECTION(intState);
    }
     
    // Have we received a frame on one of the ED connections?
    // No critical section -- it doesn't really matter much if we miss a poll
    
    if (sPeerFrameSem)
    {
      for (i=0; i<sNumCurrentPeers; ++i)
      {
    	// Continuously try to receive end device packets
        if (SMPL_SUCCESS == SMPL_Receive(sLID[i], ed_data, &len))
        {
	          // Indicate received packet
	          toggleLED(1);
	          toggleLED(2);
	          // Decode end device packet
	          switch (ed_data[0])
	          {
	              case ED_READY_2_RECEIVE:
	                    len = RF_MSG_SIZE;
	                    
	                    // Pegar os dados do buffer
	                    // o bus envia a cada segundo seus dados e o R2R.
	                    // criar metodo para receber os dados atraves do ed_data
	                    // verificar os bytes referentes ao id do bus
	                    // usar um for pra achar o id no buffer
	                    // transmitir o q der.
	                    
	                    Encode_siaer_data_guiche();
	                    
	                   	// Send reply packet to end device
	                    SMPL_Send(sLID[i], simpliciti_msg, len);
	                   
	                     BSP_ENTER_CRITICAL_SECTION(intState);
				         sPeerFrameSem--;
				         BSP_EXIT_CRITICAL_SECTION(intState);
	                   
	                    /* if (SMPL_SUCCESS == (rc=SMPL_SendOpt(sLID[i], simpliciti_msg, sizeof(simpliciti_msg), SMPL_TXOPTION_ACKREQ)))
				          {
				            // Message acked. We're done. Toggle LED 1 to indicate ack received. 
				            toggleLED(1);
				            break;
				          }*/
				          
		                break;
	            }
	       }
      	}
   	 }
    }
  }

/* Runs in ISR context. Reading the frame should be done in the */
/* application thread not in the ISR thread. */
static uint8_t sCB(linkID_t lid)
{
  if (lid)
  {
    sPeerFrameSem++;
  }
  else
  {
    sJoinSem++;
  }

  /* leave frame to be read by application. */
  return 0;
}

static void processMessage(linkID_t lid, uint8_t *msg, uint8_t len)
{
  // chamar aqui a funcao de tratamento de dados do ack e do ID do busao
  if (len)
  {
  //	TrataMsg(*msg);
      toggleLED(1);
  }
  return;
}

static void changeChannel(void)
{
#ifdef FREQUENCY_AGILITY
  freqEntry_t freq;

  if (++sChannel >= NWK_FREQ_TBL_SIZE)
  {
    sChannel = 0;
  }
  freq.logicalChan = sChannel;
  SMPL_Ioctl(IOCTL_OBJ_FREQ, IOCTL_ACT_SET, &freq);
  BSP_TURN_OFF_LED1();
  BSP_TURN_OFF_LED2();
  sBlinky = 1;
#endif
  return;
}

/* implement auto-channel-change policy here... */
static void  checkChangeChannel(void)
{
#ifdef FREQUENCY_AGILITY
  int8_t dbm, inARow = 0;

  uint8_t i;

  memset(sSample, 0x0, SSIZE);
  for (i=0; i<SSIZE; ++i)
  {
    /* quit if we need to service an app frame */
    if (sPeerFrameSem || sJoinSem)
    {
      return;
    }
    NWK_DELAY(1);
    SMPL_Ioctl(IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_RSSI, (void *)&dbm);
    sSample[i] = dbm;

    if (dbm > INTERFERNCE_THRESHOLD_DBM)
    {
      if (++inARow == IN_A_ROW)
      {
        changeChannel();
        break;
      }
    }
    else
    {
      inARow = 0;
    }
  }
#endif
  return;
}
