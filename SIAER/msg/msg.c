// *************************************************************************************************
// Include section
#include "includes.h"

// *************************************************************************************************
// Prototypes section
void TrataMsg(char* msg);
void MontaBusMsg (char funcid);
void TrataMsgSimpliciti(char simpliciti_msg[], unsigned char tamanho,char tipo);
void ReportEventUart (char simpliciti_msg[], unsigned char tamanho, char tipo);
void Encode_siaer_data_guiche(char mensagem_recebida[]);
void Encode_siaer_data_onibus();


// *************************************************************************************************
// Defines section
                                            
// *************************************************************************************************
// Global Variable section
struct BUS Onibus;
struct GUICHE Guiche;
struct siaer_frame msg;
char SRC[2]={0x00,0x00};
char DST[2]={0x00,0x00};

unsigned char simpliciti_ed_address[];
struct rf_buffer buffer_a_transmitir[];

// *************************************************************************************************
// Extern section
void InitBusGuiche() //todo mundo nulo 
{
    int i=0;
    for (i=0;i<2;i++)
    {
        Onibus.id_bus[i]=0x00;
        Guiche.cidade[i]=0x00;
        Onibus.ativo=0x00;
        Guiche.cidade[i]=0x00;
    }
    for (i=0;i<7;i++)
      Onibus.placa[i]=0x00;
    Onibus.EST_CONEXAO=OFF;
}


// *************************************************************************************************
// @fn		set_bus_guiche
// @brief 	inicializa tanto o onibus quanto o guiche com dados iniciais da uart
// @param 	char * msg
// @return 	none
// **************************************************************************************************
void set_bus_guiche(char *msg)
{
   int i=0;
    switch (msg[5])
    {
      case INIT_BUS:
        Onibus.ativo=TRUE;
        for (i=0;i<2;i++)
          Onibus.id_bus[i]=msg[i+6];
        for (i=0;i<8;i++)
          Onibus.placa[i]=msg[i+8];
       
        main_end_device();
        break;
        
      case INIT_GUI:
        Guiche.ativo=TRUE;
        Guiche.cidade[0]=msg[6];
        Guiche.cidade[1]=msg[7];
        SRC[0]=Guiche.cidade[0];
        SRC[1]=Guiche.cidade[1];
       
        main_access_point();
        break;
    }
}

// *************************************************************************************************
// @fn		TrataMsg
// @brief 	Apos receber os bytes da uart atraves da interrupcao, esta funcao 
//			eh chamada para efetuar o tratamento dos dados
// @param 	char * msg
// @return 	none
// *************************************************************************************************
void TrataMsg(char* msg)
{
    char func_id;
  
    func_id=msg[FUNCID];
  
    switch (func_id)
    {
        // Caso receba ordem de inicializacao modo onibus, lancar rotina de link do simpliciti e ficar em busca de um Access Point
        // Caso receba comando de inicializacao do modo guiche, lancar rotina de listen do simpliciti      
      case INIT_BUS:
      case INIT_GUI:
              set_bus_guiche(msg);
        break;
      default:
        if (func_id&TX_BARCODE)
        {
          if (Guiche.ativo == TRUE)
            AddBarcodeBuffer(msg);
        }
        break;
    }
}

// *************************************************************************************************
// @fn		MontaBusMsg
// @brief 	Monta mensagem a ser transmitida do onibus para o terminal
// @param 	char funcid 	identificador do tipo de mensagem a ser transmitida
// @return 	none
// *************************************************************************************************
void MontaBusMsg (char funcid)
{
    msg.funcid=funcid;
    msg.src[0]=Onibus.id_bus[0];
    msg.src[1]=Onibus.id_bus[1];
    msg.dst[0] =Onibus.DST[0];
    msg.dst[1] =Onibus.DST[1];
      
    switch (funcid)
    {
        case POLL_ACK:
        case POLL2_ACK:
            msg.size = POLL_MSG_SIZE;
            msg.data[0]=Onibus.id_bus[0];
            msg.data[1]=Onibus.id_bus[1];
            break;
        case TX_BARCODE_ACK:
          msg.size = BAR_ACK_MSG_SIZE;
          msg.data[0] = funcid;
    }
}
// *************************************************************************************************
// @fn		MontaTslMsg
// @brief 	Monta mensagem a ser transmitida do onibus para o terminal
// @param 	char funcid tipo de mensagem
//			char mensagem_recebida[] o pacote em si
// @return 	none
// *************************************************************************************************
void MontaTslMsg (char funcid, char mensagem_recebida[])
{
    int j,i=0;
    struct siaer_frame msg;
    msg.funcid=funcid;
    msg.src[0]=buffer_a_transmitir[i].SRC[0];
    msg.src[1]=buffer_a_transmitir[i].SRC[1];
    
    msg.size = POLL_MSG_SIZE;
    msg.data[0]=msg.src[0];
    msg.data[1]=msg.src[1];
    if (funcid==POLLING)
    {
       msg.dst[0]=0x00;
       msg.dst[1]=0x00;
    }
    if (funcid==POLLING2)
    {
       msg.dst[0]=buffer_a_transmitir[i].DST[0];
       msg.dst[1]=buffer_a_transmitir[i].DST[1];
    }
    if (funcid&TX_BARCODE)
    {
       msg.funcid=(buffer_a_transmitir[i].buffer[BUF_STATUS_POS][0])&0x7F;
       msg.dst[0]=buffer_a_transmitir[i].DST[0];
       msg.dst[1]=buffer_a_transmitir[i].DST[1];
       
		//msg.size = BARCODE_MSG_SIZE;
       
       for (j=1;j<TX_BARCODE_BUF_SIZE+1;j++)
         msg.data[j-1]=buffer_a_transmitir[i].buffer[j][0];
    }
}

// *************************************************************************************************
// @fn		ReportEventUart
// @brief 	Manda pra uart tanto to guiche quanto do onibus informacoes referentes ao funcionamento do programa
// @param 	char simpliciti_msg[] conjunto de dados
//			unsigned char tamanho quantidade em bytes
//			char tipo de mensagem a ser enviada a uart
// @return 	none
// *************************************************************************************************

void ReportEventUart (char simpliciti_msg[], unsigned char tamanho, char tipo)
{
    int i;
    char msg[]="$123$";
    char msg2[]="$SS12345678$";

    if (Onibus.ativo==TRUE)
    {
        switch(tipo)
        {
            case BUS_CHEGOU:
            case BUS_PARTIU:
              msg[0]=0x24;
              msg[1]=tipo;
              msg[2]=Onibus.DST[0];
              msg[3]=Onibus.DST[1];
              msg[4]=0x24;
              TXString(msg,5);
              break;
              
            case RECEBEU_BARCODE:
              msg2[1]=tipo;
              msg2[2]=Onibus.DST[0];
              msg2[3]=Onibus.DST[1];
              for (i=0;i<TX_BARCODE_BUF_SIZE+4;i++)
                msg2[i+4]=simpliciti_msg[5+i];
              msg2[14]=0x24;
              TXString(msg2,15); 
              break;
        }
        
    }
}

// *************************************************************************************************
// @fn		AddBarcodeBuffer
// @brief 	Coloca o barcode vindo do guiche no buffer a ser enviado
// @param 	os bytes
// @return 	none
// *************************************************************************************************
void AddBarcodeBuffer(char* msg)
{
	// TRANSMITIR
    char i,j=10;
    char dest[2];
        
    dest[0]=msg[DST_HI];
    dest[1]=msg[DST_LO];

    for (i=0;i<CONEXOES_POSSIVEIS;i++)
    {
        if (dest[0]==buffer_a_transmitir[i].DST[0] && dest[1]==buffer_a_transmitir[i].DST[1])
          {
	        for (i=0;i<BUFFER_SIZE;i++)
	        {
	            if (!(buffer_a_transmitir[i].buffer[BUF_STATUS_POS][i]&NOT_TXED))
	            {
	                buffer_a_transmitir[i].buffer[BUF_STATUS_POS][i]=msg[FUNCID];
	                for (j=1;j<TX_BARCODE_BUF_SIZE+1;j++)
	                {
	                  buffer_a_transmitir[i].buffer[j][i]=msg[j-1+HDR_SIZE];
	                }
	                buffer_a_transmitir[i].buffer[BUF_STATUS_POS][i]|=NOT_TXED;
	              //  EnableTslProcess(tsl,BARCODE_PROC);
	                break;
	            }
	         }        
    		}
    }
}

// *************************************************************************************************
// @fn		AddBarcodeBuffer
// @brief 	Somente para testes. Joga na uart o q receber via RF
// *******************************************
void TrataMsgSimpliciti(char simpliciti_msg[], unsigned char tamanho, char tipo)
{
    switch(simpliciti_msg[5]) //  funcid
    {
      case POLLING:
          // aqui o onibus chegou na estacao e recebeu um mensagem poll do guiche
          // implementar no codigo para primeira conexao
            Onibus.DST[0]=simpliciti_msg[1];  // src[0]
            Onibus.DST[1]=simpliciti_msg[2];  //msg_ptr->src[1];
            ReportEventUart(simpliciti_msg, 0, BUS_CHEGOU);
            // Mandar ACK
        
        break;
      case POLLING2:
          // Mandar um ACK2 
          // feito apos a conexao estar feita, para manter contato com o bus
        
        break;
      default:
            if (simpliciti_msg[5] & TX_BARCODE)
            {
              // mandar via uart
              ReportEventUart(simpliciti_msg, tamanho, RECEBEU_BARCODE);
              
              // mandar ack
              //  bar_ack=MontaBusMsg(TX_BARCODE_ACK);
              // bar_ack.data[0]=msg_ptr->funcid&0x3F;
              // WITX_frame(bar_ack);
            }
        }
}

// *************************************************************************************************
// @fn		Encode_siaer_data
// @brief 	Empacota os dados para serem enviados via RF pelo guiche
// @param   tipo de mensagem recebida
// ****************************************************
void Encode_siaer_data_guiche(char mensagem_recebida[])
{
	 char i,cont;
	 for (i=0;i<CONEXOES_POSSIVEIS;i++)
	 {
        if (mensagem_recebida[2] == buffer_a_transmitir[i].DST[0] && mensagem_recebida[1]==buffer_a_transmitir[i].DST[1])
          {
          	// O que sera transmitido
     		simpliciti_msg[1] = buffer_a_transmitir[i].SRC[0];
     		simpliciti_msg[2] = buffer_a_transmitir[i].SRC[1];
     		simpliciti_msg[3] = buffer_a_transmitir[i].DST[0];
     		simpliciti_msg[4] = buffer_a_transmitir[i].DST[1];
     		simpliciti_msg[5] = (buffer_a_transmitir[i].buffer[BUF_STATUS_POS][0])&0x7F; // funcid
     		for (cont=1;i<TX_BARCODE_BUF_SIZE+1;i++)
			{
				// coloca o top da lista buffer na mensagem a ser enviada
     			simpliciti_msg[cont+5] = buffer_a_transmitir[i].buffer[cont][0];
			}
	        break;
          }
	 }
	 simpliciti_msg[1] = 1;
     simpliciti_msg[2] = 3;
     simpliciti_msg[3] = 2;
     simpliciti_msg[4] = 0;
}

// *************************************************************************************************
// @fn		Encode_siaer_data
// @brief 	Empacota os dados para serem enviados via RF pelo guiche
// @param   tipo de mensagem recebida
// ****************************************************
void Encode_siaer_data_onibus()
{
	//switch(Onibus.EST_CONEXAO)
	//{
	 //case OFF:
	 //	Onibus.EST_CONEXAO=CONECTADO;
	   	simpliciti_msg[0] = ED_READY_2_RECEIVE;
  		simpliciti_msg[1] = Onibus.id_bus[0];
  		simpliciti_msg[2] = Onibus.id_bus[1];
	 /*	break;
	 case CONECTADO:
		Onibus.EST_CONEXAO=ON;
	   	simpliciti_msg[0] = ED_READY_2_RECEIVE;
  		simpliciti_msg[1] = Onibus.id_bus[0];
  		simpliciti_msg[2] = Onibus.id_bus[1];
		break;
	 case ON:
	   	simpliciti_msg[0] = ED_READY_2_RECEIVE;
	  	simpliciti_msg[1] = Onibus.id_bus[0];
	  	simpliciti_msg[2] = Onibus.id_bus[1];
	  	break;
	}*/
}
