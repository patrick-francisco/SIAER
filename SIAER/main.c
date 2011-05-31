// *************************************************************************************************
// Include section
#include <string.h>
#include "includes.h"
#include "msg.h"
#include "uart.h"
#include "timer.h"

// *************************************************************************************************
// Prototypes section

// *************************************************************************************************
// Defines section

// *************************************************************************************************
// Global Variable section


// *************************************************************************************************
// Extern section

// *************************************************************************************************
// @fn		main
// @brief 	laco principal
// @param 	none
// @return 	none
// *************************************************************************************************
extern void Timer1_Init(void);
extern void InitBusGuiche(void);

void main (void)
{
  // char teste[]={0x10,0x00,0x00,0x00,0x00,0x02,0x58,0x67,0x39,0x63,0x32,0x39,0x32,0x36,0x30,0x35};
   // iniciar clock - MCLK E SMCLK 12MHz, atraves de DCO e oscilador interno REFO
   //                 ACLK 32KHz     
   
   // Inicializacao de variaveis globais
    ESTADO_RX_UART = RX_LIVRE;

//  Gerar endereco aleatorio para os end devices
//  simpliciti_ed_address[0] = rand();

   InitBusGuiche();
   Timer1_Init();
   init_uart();

   Timer0_A4_Delay(20);

   //char msg[] = { 0x24, 0x0F, 0x01, 0x02, 0x03,0x03, 0x10,0x33, 0x45, 0x65,0x87, 0x45,0x01, 0x00, 0x00, 0x04, 0x24 };  
   //AddBarcodeBuffer(msg);
  // TrataMsg(teste);
  // Vamos testar ver se ele recebe qualquer coisa depois da primeira mensagem de inicializacao.

	//Guiche.ativo = TRUE;	          
   //ReportEventUart(BUS_CHEGOU,0);

   #ifdef END_DEVICE
   //main_end_device();
   
   #elif ACCESS_POINT
   //main_access_point();
   
   #endif
   while(1);
}


