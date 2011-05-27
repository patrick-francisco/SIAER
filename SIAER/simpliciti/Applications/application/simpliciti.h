#ifndef SIMPLICITI_H_
#define SIMPLICITI_H_

#include "msg.h"


#define RF_MSG_SIZE 15

// Definicoes para tipo de mensagem
#define ED_READY_2_RECEIVE 0xAA

extern void main_end_device(void);

extern void main_access_point(void);

// 4 byte device address overrides device address set during compile time
extern unsigned char simpliciti_ed_address[4];
extern unsigned char simpliciti_msg[RF_MSG_SIZE];
extern unsigned char ed_data[RF_MSG_SIZE];

#endif /*SIMPLICITI_H_*/
