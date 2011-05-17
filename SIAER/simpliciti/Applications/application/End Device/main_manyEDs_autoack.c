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

//  CRIAR METODO PARA RECEBER MENSAGEM DO AP
// 
#include "bsp.h"
#include "mrfi.h"
#include "nwk_types.h"
#include "nwk_api.h"
#include "bsp_leds.h"
#include "bsp_buttons.h"
#include "simpliciti.h"
#include "app_remap_led.h"
#include "includes.h"

#ifndef APP_AUTO_ACK
#error ERROR: Must define the macro APP_AUTO_ACK for this application.
#endif

void toggleLED(uint8_t);

extern void Encode_siaer_data_onibus();

extern void ReportEventUart (char simpliciti_msg[], unsigned char tamanho, char tipo);

static void linkTo(void);

static uint8_t  sTid = 0;
static linkID_t sLinkID1 = 0;

volatile uint8_t ed_send_request = 0;


#define SPIN_ABOUT_A_SECOND   NWK_DELAY(1000)
#define SPIN_ABOUT_A_QUARTER_SECOND   NWK_DELAY(250)

/* How many times to try a Tx and miss an acknowledge before doing a scan */
#define MISSES_IN_A_ROW  2

void main_end_device (void)
{
  BSP_Init();
  
  uint8_t i;
  /* If an on-the-fly device address is generated it must be done before the
   * call to SMPL_Init(). If the address is set here the ROM value will not
   * be used. If SMPL_Init() runs before this IOCTL is used the IOCTL call
   * will not take effect. One shot only. The IOCTL call below is conformal.
   */
  addr_t lAddr;
    
  // Change network address to value set in calling function
  for (i=0; i<4; i++)
  {
    lAddr.addr[i] = simpliciti_ed_address[i];
  }

  // Muda o endereco do end device
  SMPL_Ioctl(IOCTL_OBJ_ADDR, IOCTL_ACT_SET, &lAddr);

  /* Keep trying to join (a side effect of successful initialization) until
   * successful. Toggle LEDS to indicate that joining has not occurred.
   */
  while (SMPL_SUCCESS != SMPL_Init(0))
  {
    toggleLED(1);
    toggleLED(2);
    SPIN_ABOUT_A_SECOND;
  }

  /* LEDs on solid to indicate successful join. */
  if (!BSP_LED2_IS_ON())
  {
    toggleLED(2);
  }
  if (!BSP_LED1_IS_ON())
  {
    toggleLED(1);
  }

  /* Unconditional link to AP which is listening due to successful join. */
  linkTo();

  while (1);
}

static void linkTo()
{
  uint8_t     misses, done;
  uint8_t   len;	
  uint8_t      noAck;
  smplStatus_t rc;

  // Keep trying to link...
  while (SMPL_SUCCESS != SMPL_Link(&sLinkID1))
  {
    toggleLED(1);
    toggleLED(2);
    SPIN_ABOUT_A_SECOND;
  }

  /* Turn off LEDs. */
  if (BSP_LED2_IS_ON())
  {
    toggleLED(2);
  }
  if (BSP_LED1_IS_ON())
  {
    toggleLED(1);
  }
  
  // sleep until button press... 
  SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_SLEEP, 0);

  // Implementar metodo de escuta. Esperar pelo Access Point
  while (1)
  {
  	if(ed_send_request)
  	{
      // get radio ready...awakens in idle state 
      SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_AWAKE, 0);
      done = 0;
      while (!done)
      {
        noAck = 0;

        // Try sending message MISSES_IN_A_ROW times looking for ack 
        for (misses=0; misses < MISSES_IN_A_ROW; ++misses)
        {
        	     	
          // Montar a mensagem e enviar para o GUICHE
          // criar metodo com o bus id como polling
          
  		 Encode_siaer_data_onibus();
        	
          if (SMPL_SUCCESS == (rc=SMPL_SendOpt(sLinkID1, simpliciti_msg, sizeof(simpliciti_msg), SMPL_TXOPTION_ACKREQ)))
          {
            // Message acked. We're done. Toggle LED 1 to indicate ack received. 
            toggleLED(1);
            break;
          }
          if (SMPL_NO_ACK == rc)
          {
            // Count ack failures. Could also fail becuase of CCA and
            //  we don't want to scan in this case.
            // 
            noAck++;
          }
        }
        if (MISSES_IN_A_ROW == noAck)
        {
          // Message not acked. Toggle LED 2.              
          toggleLED(2);
#ifdef FREQUENCY_AGILITY
          if (SMPL_SUCCESS != SMPL_Ping(sLinkID1))
          {
            done = 1;
          }
#else
          done = 1;
#endif  // FREQUENCY_AGILITY 
        }
        else
        {
	        // Wait shortly for host reply
			SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_RXON, 0);
			//NWK_DELAY(10);
	  	
			// Check if a command packet was received
			if (SMPL_Receive(sLinkID1, simpliciti_msg, &len) == SMPL_SUCCESS)
			{
				//TrataMsgSimpliciti(simpliciti_msg, len, RECEBEU_BARCODE);
				ReportEventUart(simpliciti_msg, len, RECEBEU_BARCODE);
				
				ed_send_request=0;
				done = 1;
	  		}
        }
      }

      // radio back to sleep 
      SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_SLEEP, 0);
  	}
  }

  // Reiniciar em caso de perda de conexao.
}


void toggleLED(uint8_t which)
{
  if (1 == which)
  {
    BSP_TOGGLE_LED1();
  }
  else if (2 == which)
  {
    BSP_TOGGLE_LED2();
  }
  return;
}
