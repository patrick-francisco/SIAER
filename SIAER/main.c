/*----------------------------------------------------------------------------
 *  Demo Application for SimpliciTI
 *
 *  L. Friedman
 *  Texas Instruments, Inc.
 *----------------------------------------------------------------------------
 */

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
// *************************************************************************************************
// @fn		main
// @brief 	laco principal
// @param 	none
// @return 	none
// *************************************************************************************************
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
   //			
   // criar modo de testes independente: uart - mensagens
   //  
   
   // Inicializacao de variaveis globais
   ESTADO_RX_UART = RX_LIVRE;
   
   // Gerar endereco aleatorio para os end devices
   simpliciti_ed_address[0] = rand();
   simpliciti_ed_address[1] = rand();   
   simpliciti_ed_address[2] = rand();   
   simpliciti_ed_address[3] = rand();
     
   init_uart();
   
   #ifdef END_DEVICE
   main_end_device();
   
   #elif ACCESS_POINT
   main_access_point();
   
   #endif
   
}
