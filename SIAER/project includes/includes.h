#ifndef INCLUDES_H_
#define INCLUDES_H_

#include <stdlib.h>
#include "cc430x613x.h"
#include "uart.h"
#include "msg.h"
#include "simpliciti.h"


// REMOVER TUDO ISSO ANTES DO FIM DO PROJETO
#define INIT_BUS	    0x01
#define	INIT_GUI	    0x02
#define TX_BARCODE          0x10
#define TX_BARCODE_ACK      0x11
#define TX_BARCODE_2        0x12
#define TX_BARCODE_2_ACK    0x13

#define	POLLING		 0x03
#define POLLING2     0x05

#define POLL_ACK     0x04
#define POLL2_ACK    0x06
#define TIPO_ONIBUS  0x01
#define TIPO_GUICHE  0x02

//Timer Events
#define EXP_TIM_10      0xF0
#define EXP_TIM_5       0xF1
#define EXP_TIM_2       0xF2

//Report UART
#define BUS_CHEGOU      0x0C
#define BUS_PARTIU      0x0D
#define RECEBEU_BARCODE     0x0A

#endif
