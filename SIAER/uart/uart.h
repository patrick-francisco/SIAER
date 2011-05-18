#ifndef UART_H_
#define UART_H_

#define RX_LIVRE              (char)0x40
#define RX_RECEBENDO          (char)0x80

extern char ESTADO_RX_UART;

extern void init_uart(void);
extern void TrataIntUartRx(char rx);

extern void TXString(char* string, int length);
#endif /*UART_H_*/
