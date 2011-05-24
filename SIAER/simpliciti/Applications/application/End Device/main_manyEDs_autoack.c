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
volatile char ed_send_request = 0;

static void linkTo(void);
/* Callback handler */
static uint8_t sCB(linkID_t);

static linkID_t sLinkID1 = 0;

static volatile uint8_t  sPeerFrameSem = 0;

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
  while (SMPL_SUCCESS != SMPL_Init(sCB))
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
}

static void linkTo()
{
  uint8_t    done;

  /* Keep trying to link... */
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

  /* sleep until button press... */
  SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_SLEEP, 0);

  Conexao=ON;

  // Implementar metodo de escuta. Esperar pelo Access Point
  while (Conexao==ON)
  {
  	if(ed_send_request)
  	{
      // get radio ready...awakens in idle state 
      SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_AWAKE, 0);
      done = 0;
      while (!done)
      {
          // Montar a mensagem e enviar para o GUICHE
          // criar metodo com o bus id como polling
          Encode_siaer_data_onibus();
          if (SMPL_SUCCESS == SMPL_Send(sLinkID1, simpliciti_msg, sizeof(simpliciti_msg)))
          {
             SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_RXON, 0);
             NWK_REPLY_DELAY();
             bspIState_t intState;
             
              if (!sPeerFrameSem)
              {
                /* Try again if we havn't received anything. */
                continue;
              }
              else
              {
                uint8_t len;

                BSP_ENTER_CRITICAL_SECTION(intState);
                sPeerFrameSem--;
                BSP_EXIT_CRITICAL_SECTION(intState);

                /* We got something. Go get it. */
                SMPL_Receive(sLinkID1, simpliciti_msg, &len);
                             
	            TrataMsgSimpliciti(RECEBEU_BARCODE);
				ed_send_request=0;
				done = 1;
              }
            } 
        }
      
      // radio back to sleep 
      SMPL_Ioctl( IOCTL_OBJ_RADIO, IOCTL_ACT_RADIO_SLEEP, 0);
  	}
  }
  ReportEventUart(BUS_PARTIU,NULL);
  main_end_device();
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

static uint8_t sCB(linkID_t lid)
{
  if (lid == sLinkID1)
  {
    sPeerFrameSem++;
    return 0;
  }

  return 1;
}
