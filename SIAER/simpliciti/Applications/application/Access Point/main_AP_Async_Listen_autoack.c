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


void toggleLED(uint8_t);
extern void TXString (char* string, int length);

/* reserve space for the maximum possible peer Link IDs */
static linkID_t sLID[NUM_CONNECTIONS] = {0};
static uint8_t  sNumCurrentPeers = 0;

/* callback handler */
static uint8_t sCB(linkID_t);
/* work loop semaphores */
static volatile uint8_t sPeerFrameSem = 0;
static volatile uint8_t sJoinSem = 0;
/* received message handler */
static void processMessage(linkID_t, uint8_t *, uint8_t);

/* blink LEDs when channel changes... */
static volatile uint8_t sBlinky = 0;
unsigned char ed_data[RF_MSG_SIZE];
#define SPIN_ABOUT_A_QUARTER_SECOND   NWK_DELAY(250)

void main_access_point (void)
{
  uint8_t   len, i;	
  bspIState_t intState;

  BSP_Init();

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
		     processMessage(sLID[i], ed_data, len);     
	                   
             BSP_ENTER_CRITICAL_SECTION(intState);
	         sPeerFrameSem--;
	         BSP_EXIT_CRITICAL_SECTION(intState);
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
  // Decode end device packet
  
  bspIState_t intState;
  //BSP_ENTER_CRITICAL_SECTION(intState);
  	   
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
        
        //  BSP_EXIT_CRITICAL_SECTION(intState);
        
       	// Send reply packet to end device
        SMPL_Send(lid, simpliciti_msg, len);
        break;
	}
  return;
}

