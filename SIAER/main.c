// *************************************************************************************************
// Include section
#include <string.h>
#include "includes.h"

// *************************************************************************************************
// Prototypes section

// *************************************************************************************************
// Defines section

// *************************************************************************************************
// Global Variable section

// *************************************************************************************************
// Extern section
unsigned char simpliciti_ed_address[];
char simpliciti_msg[];
struct rf_buffer buffer_a_transmitir[];
// *************************************************************************************************
// @fn		main
// @brief 	laco principal
// @param 	none
// @return 	none
// *************************************************************************************************
extern void Timer1_Init(void);

void main (void)
{
   // iniciar clock - MCLK E SMCLK 12MHz, atraves de DCO e oscilador interno REFO
   //                 ACLK 32KHz     
   // timer
   // iniciar simpliciti
   // iniciar porta de com
   // ------------
   // SIMPLICITI
   // 	GUICHE 
   // 		Ao receber um dado, tratar o dado recebido e transformar informacao para formato compativel com codigo do marcus
   //  		triggar o envio pela serial.
   //  	ONIBUS
   //		Ao
   // criar modo de testes independente: uart - mensagens
   //  
   
   // Inicializacao de variaveis globais
    ESTADO_RX_UART = RX_LIVRE;
   // Gerar endereco aleatorio para os end devices
   simpliciti_ed_address[0] = rand();
   simpliciti_ed_address[1] = rand();
   simpliciti_ed_address[2] = rand();
   simpliciti_ed_address[3] = rand();

   Timer1_Init();
  // Timer0_Stop();
   init_uart();
   //while (!BSP_BUTTON1());

   #ifdef END_DEVICE
   //main_end_device();
   
   #elif ACCESS_POINT
  // main_access_point();
   
   #endif   
   while(1);
}


