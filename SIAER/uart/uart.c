//******************************************************************************
//   CC430F613x Demo - USCI_A0, Ultra-Low Pwr UART 9600 Echo ISR, 32kHz ACLK
//
//   Description: Echo a received character, RX ISR used. Normal mode is LPM3,
//   USCI_A0 RX interrupt triggers TX Echo.
//   ACLK = REFO = 32768Hz, MCLK = SMCLK = DCO ~12MHz
//   Baud rate divider with 32768Hz XTAL @9600 = 32768Hz/9600 = 3.41
//   See User Guide for baud rate divider table
//
//                CC430F6137
//             -----------------
//         /|\|                 |
//          | |                 |
//          --|RST              |
//            |                 |
//            |     P1.6/UCA0TXD|------------>
//            |                 | 9600 - 8N1
//            |     P1.5/UCA0RXD|<------------
//
// 
//   Texas Instruments Inc.
//   April 2009
//   Built with CCE Version: 3.2.2 and IAR Embedded Workbench Version: 4.11B
//******************************************************************************

#include "cc430x613x.h"

void init_uart(void)
{
  WDTCTL = WDTPW + WDTHOLD;                 // Parar watchdog
  
  PMAPPWD = 0x02D52;                        // Acesso para escrita aos registradores de port mapping 
  P1MAP6 = PM_UCA0TXD;                      // Configura funcao especial do pino - TX
  P1MAP5 = PM_UCA0RXD;                      // Configura funcao especial do pino - RX
  PMAPPWD = 0;                              // Trava acesso aos registradores de configuracao do pino

  P1DIR |= BIT6;                            // Setar P1.7 como TX - output
  P1SEL |= BIT5 + BIT6;                     // P1.5 & P1.6 com funcao de UART
  
  UCA0CTL1 |= UCSWRST;                      // **Put state machine in reset**
  UCA0CTL1 |= UCSSEL_1;                     // CLK = ACLK
  UCA0BR0 = 0x03;                           // 32kHz/9600=3.41 (see User's Guide)
  UCA0BR1 = 0x00;                           //
  UCA0MCTL = UCBRS_3+UCBRF_0;               // Modulation UCBRSx=3, UCBRFx=0
  UCA0CTL1 &= ~UCSWRST;                     // **Initialize USCI state machine**
  UCA0IE |= UCRXIE;                         // Enable USCI_A0 RX interrupt
}

// Echo back RXed character, confirm TX buffer is ready first
#pragma vector=USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
  switch(__even_in_range(UCA0IV,4))
  {
  case 0:break;                             // Vector 0 - no interrupt
  case 2:                                   // Vector 2 - RXIFG
    while (!(UCA0IFG&UCTXIFG));             // USCI_A0 TX buffer ready?
    UCA0TXBUF = UCA0RXBUF;                  // TX -> RXed character
    break;
  case 4:break;                             // Vector 4 - TXIFG
  default: break;  
  }
}
