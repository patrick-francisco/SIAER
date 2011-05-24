#ifndef MSG_H_
#define MSG_H_

// *************************************************************************************************
// Include section
#include "includes.h"

// *************************************************************************************************
// Prototypes section
extern void TrataMsg(char* msg);

extern void AddBarcodeBuffer(char* msg);
extern void ReportEventUart (char tipo, char id_onibus);
extern void TrataMsgSimpliciti(char tipo);
extern void Encode_siaer_data_guiche(void);
extern void Encode_siaer_data_onibus(void);
extern void Incrementa_timeout(void);
// *************************************************************************************************
// Defines section
#define TRUE        0xFF
#define FALSE       0x00

#define ON  0xFF
#define OFF 0x00
#define CONECTADO 0x01
#define DESCONEXAO 0xAA

#define ACK_BARCODE 0xBB

#define CONEXOES_POSSIVEIS    8
#define POLL_MSG_SIZE         8
#define BAR_ACK_MSG_SIZE      7    

#define SIAER_DATA_SIZE 20
#define BUFFER_SIZE 9

#define TRUE        0xFF
#define FALSE       0x00

#define INIT_BUS    0x01
#define INIT_GUI    0x02

#define BUF_STATUS_POS 		  0
#define NOT_TXED              0x80
#define TXED                  0x40
#define TX_BARCODE_BUF_SIZE   10 

#define MAX_MISSES 300 

//estrutura básica de frame uart/wi
#define PKT_OFF         1 //offset pelo byte[0]=28
#define SIZE            0
#define SRC_HI          1
#define SRC_LO          2
#define DST_HI          3
#define DST_LO          4
#define FUNCID          5
#define DATA            6
#define HDR_SIZE        6
                                           
// *************************************************************************************************
// Global Variable section
struct BUS
{
	
    char id_bus[2];
    char placa[8];
    char ativo;
	char TIMEOUT;
    char EST_CONEXAO;
    //struct siaer_frame pollack;
    char DST[2];
   // struct processo list_processos[N_TOTAL_PROC];
    char buffer[TX_BARCODE_BUF_SIZE+1][BUFFER_SIZE];
};
extern struct BUS Onibus;

extern char Conexao;


struct GUICHE
{
	char cidade[2];
	char ativo;
};
extern struct GUICHE Guiche;

struct siaer_frame
{
    char size;
    char src[2];
    char dst[2];
    char funcid;
    char data[SIAER_DATA_SIZE];
};
extern struct siaer_frame msg;

struct processo
{
    char estado;
    char status;
    char handled;
};

struct rf_buffer
{
       char EST_CONEXAO;
       char ENVIAR_BUFFER;
       char TIMEOUT; // conta a cada segunda e zera a cada mensagem recebida. Ao chegar a um valor maximo, reconhece que o onibus partiu.
       char SRC[2];
       char DST[2];
       char funcid;
       char buffer[TX_BARCODE_BUF_SIZE+1][BUFFER_SIZE];
       //BUFFER DA UART!
};


extern char num_onibus_conectados;
// *************************************************************************************************
// Extern section
#endif
