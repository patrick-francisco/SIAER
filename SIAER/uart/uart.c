// *************************************************************************************************
// Include section
#include "includes.h"

// *************************************************************************************************
// Prototypes section

// *************************************************************************************************
// Defines section

// *************************************************************************************************
// Global Variable section

char ESTADO_RX_UART;
char *buffer_uart_rx;
int pos_buffer=0;
int tamanho_buffer=0;
char uart_msg[]={"\rUART: "};

// *************************************************************************************************
// Extern section

// *************************************************************************************************
// @fn 		init_uart
// @brief 	inicializa a uart
// @param 	none
// @return 	none
// *************************************************************************************************
void init_uart(void)
{
  WDTCTL = WDTPW + WDTHOLD;                 // Parar watchdog
  
  PMAPPWD = 0x02D52;                        // Acesso para escrita aos registradores de port mapping 
  P1MAP6 = PM_UCA0TXD;                      // Configura funcao especial do pino - TX
  P1MAP5 = PM_UCA0RXD;                      // Configura funcao especial do pino - RX
  PMAPPWD = 0;                              // Trava acesso aos registradores de configuracao do pino

  P1DIR |= BIT6;                            // Setar P1.6 como TX - output
  P1DIR &= BIT5;                            // Setar P1.5 como rX - input
  P1SEL |= BIT5 + BIT6;                     // P1.5 & P1.6 com funcao de UART
  
  UCA0CTL1 |= UCSWRST;                      // **Put state machine in reset**
  UCA0CTL1 |= UCSSEL_1;                     // CLK = ACLK
  UCA0BR0 = 0x03;                           // 32kHz/9600=3.41 (see User's Guide)
  UCA0BR1 = 0x00;                           //
  UCA0MCTL = UCBRS_3+UCBRF_0;               // Modulation UCBRSx=3, UCBRFx=0
  UCA0CTL1 &= ~UCSWRST;                     // **Initialize USCI state machine**
  UCA0IE |= UCRXIE;                         // Enable USCI_A0 RX interrup
}

// *************************************************************************************************
// @fn 		TrataIntUartRx
// @brief 	Recebe todos os bytes entre '$', organiza a mensagem e envia para a funcao 
//			que decodificara a mensagem recebida
// @param 	char rx
// @return 	none
// *************************************************************************************************
void TrataIntUartRx(char rx)
{ 
    switch (ESTADO_RX_UART)
    {
      case RX_LIVRE:
        if (rx=='$')                       // Codigo para inicio de recebimento
        {
            ESTADO_RX_UART=RX_RECEBENDO;   // muda flag
            pos_buffer=0;       	       // zera posicao do buffer
        }
        break;
      case RX_RECEBENDO:                   // Caso esteja recebendo uma mensagem
        if (pos_buffer==0) 		           // Se pos_buffer for zero
        {
            tamanho_buffer=(int)rx; 						// primeira mensagem provavelmente contem o tamanho da mensagem a ser transmitida 
            buffer_uart_rx=(char*)calloc(tamanho_buffer,1); // aloca memoria para receber os dados
            buffer_uart_rx[pos_buffer]=tamanho_buffer;      // primeira parte ainda contem o tamanho do buffer
            pos_buffer++;									// incrementa buffer para proxima iteracao
            break; 
        }
        if (rx=='$') // terminou de receber
        {
            ESTADO_RX_UART=RX_LIVRE;
            //TXString(uart_msg,7);
            //TXString(buffer_uart_rx,tamanho_buffer); 	// transmite um ack
            TrataMsg(buffer_uart_rx); 					//Apos receber todos os dados, chama funcao que ira decodificar a mensagem
            free(buffer_uart_rx); 						// libera espaco alocado
            buffer_uart_rx = 0;     					//boa pratica de programacao
            break;
        }
        else; // se for maior q o buffer
        {
            buffer_uart_rx[pos_buffer]=rx; // recebe dados a partir do segundo pacote
            pos_buffer++;
            break;
        }
    }
}

// *************************************************************************************************
// @fn 		TXString
// @brief 	Transmite dados atraves da serial
// @param 	char* string	dados
//			int length		tamanho da mensagem a ser transmitida
// @return 	none
// *************************************************************************************************
void TXString(char* string, int length)     // transmitir por uart
{
  int pointer;
  for( pointer = 0; pointer < length; pointer++)
  {
    volatile int i;
    UCA0TXBUF = string[pointer];
    while (!(UCA0IFG&UCTXIFG));             // USCI_A0 TX buffer ready?  
  }
}

// *************************************************************************************************
// @fn 		__interrupt void USCI_A0_ISR
// @brief 	Echo back RXed character, confirm TX buffer is ready first
// @param 	none
// @return 	none
// *************************************************************************************************
#pragma vector=USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
  switch(__even_in_range(UCA0IV,4))
  {
  case 0:break;                             // Vector 0 - no interrupt
  case 2:                                   // Vector 2 - RXIFG
  
  // SIAER 
  //  char rx;
  //  rx = UCA0RXBUF;
  //  IntUartRx(rx);
  
    while (!(UCA0IFG&UCTXIFG));             // USCI_A0 TX buffer ready?
    //UCA0TXBUF = UCA0RXBUF;                  // TX -> RXed character
    TrataIntUartRx(UCA0RXBUF);
    break;
  case 4:break;                             // Vector 4 - TXIFG
  default: break;  
  }
}
