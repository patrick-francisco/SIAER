// *************************************************************************************************
// Include section
#include "msg.h"
#include "bsp.h"
#include "includes.h"
// *************************************************************************************************
// Prototypes section
void TrataMsg(char* msg);
void TrataMsgSimpliciti(char tipo);
void ReportEventUart (char tipo, char id_onibus);
void Encode_siaer_data_guiche();

// *************************************************************************************************
// Defines section
                                            
// *************************************************************************************************
// Global Variable section

struct BUS Onibus;
struct GUICHE Guiche;

struct siaer_frame msg;
unsigned char simpliciti_msg[RF_MSG_SIZE];

char SRC[2]={0x00,0x00};
char DST[2]={0x00,0x00};

struct rf_buffer buffer_a_transmitir[CONEXOES_POSSIVEIS];
unsigned char simpliciti_ed_address[];
char num_onibus_conectados=0;
char Conexao;

// *************************************************************************************************
// Extern section

// *************************************************************************************************
// @fn		InitBusGuiche
// @brief 	inicializa tanto o onibus quanto o guiche zerados
// @param 	none
// @return 	none
// **************************************************************************************************
void InitBusGuiche() //todo mundo nulo 
{
    int i,j;

	DST[0]=1;
	DST[0]=0;
    for (i=0;i<2;i++)
    {
        Onibus.id_bus[i]=0;
        Guiche.cidade[i]=0;
        Onibus.ativo=0;
        Guiche.ativo=0;
        Guiche.cidade[i]=0;
    }
    for (i=0;i<7;i++)
    {
      Onibus.placa[i]=0;
    }
    Onibus.EST_CONEXAO=OFF;

    for(i=0; i<CONEXOES_POSSIVEIS; i++)
    {
	    for (j=0; j<BUFFER_SIZE; j++)
	    {
	    	buffer_a_transmitir[i].buffer[j][BUF_STATUS_POS] = 0x00;
	    }
    	buffer_a_transmitir[i].EST_CONEXAO=OFF;
    }
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
        Onibus.TIMEOUT=0;
        for (i=0;i<2;i++)
        {
          Onibus.id_bus[i]=msg[i+6];
        }
        for (i=0;i<8;i++)
        {
          Onibus.placa[i]=msg[i+8];
        }
       
	   #ifdef END_DEVICE
	   	main_end_device();
	   #endif

        break;
        
      case INIT_GUI:
        Guiche.ativo=TRUE;
        Guiche.cidade[0]=msg[6];
        Guiche.cidade[1]=msg[7];
        SRC[0]=Guiche.cidade[0];
        SRC[1]=Guiche.cidade[1];
   
	   #ifdef ACCESS_POINT
	   	main_access_point();
	   #endif

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

// ************************************************************************************************************
// @fn		ReportEventUart
// @brief 	Manda pra uart tanto to guiche quanto do onibus informacoes referentes ao funcionamento do programa
// @param 	char simpliciti_msg[] conjunto de dados
//			unsigned char tamanho quantidade em bytes
//			char tipo de mensagem a ser enviada a uart
// @return 	none
// *************************************************************************************************************
void ReportEventUart (char tipo, char id_onibus)
{
    int i;
    char msg[]="$123$";
    char msg2[]="$SS12345678415$";
	
	if (Guiche.ativo==TRUE)
	{
	    switch (tipo)
	    {
	        case BUS_CHEGOU:
	        case BUS_PARTIU:
	          msg[0]=0x24;
	          msg[1]=tipo;
	          msg[2]=buffer_a_transmitir[id_onibus].DST[0];
	          msg[3]=buffer_a_transmitir[id_onibus].DST[1];
	          msg[4]=0x24;
	          TXString(msg,5);
	          TXString(msg,5);
	          TXString(msg,5);
	          TXString(msg,5);
	          break;
	        case RECEBEU_BARCODE:
	          msg2[0]=0x24;
	          msg2[1]=tipo;
	          msg2[2]=buffer_a_transmitir[id_onibus].DST[0];
	          msg2[3]=buffer_a_transmitir[id_onibus].DST[1];
	          for (i=0; i<TX_BARCODE_BUF_SIZE+1; i++)
	            msg2[i+4]=buffer_a_transmitir[id_onibus].buffer[0][i];
	          msg2[4]&=0x3f;
	          msg2[15]=0x24;
	          TXString(msg2,15);
	          TXString(msg2,15);
	          break;
	    }
	}

    if (Onibus.ativo==TRUE)
    {
        switch(tipo)
        {
            case BUS_CHEGOU:
   			msg[0]=0x24;
            msg[1]=tipo;
            msg[2]=Onibus.DST[0];
            msg[3]=Onibus.DST[1];
            msg[4]=0x24;
            TXString(msg,5);
            TXString(msg,5);
            Onibus.EST_CONEXAO = CONECTADO;
 			break;          
 			 
            case BUS_PARTIU:
              msg[0]=0x24;
              msg[1]=tipo;
              msg[2]=Onibus.DST[0];
              msg[3]=Onibus.DST[1];
              msg[4]=0x24;
              TXString(msg,5);
              Onibus.EST_CONEXAO = OFF;
              break;
              
            case RECEBEU_BARCODE:
              msg2[1]=tipo;
              msg2[2]=Onibus.DST[0];
              msg2[3]=Onibus.DST[1];
              msg2[4]&=0x3f;
              for (i=0;i<TX_BARCODE_BUF_SIZE+4;i++)
              {
                msg2[i+4]=simpliciti_msg[5+i];             
              }
			  msg2[14]=0x24;
              TXString(msg2,15); 
              Onibus.EST_CONEXAO = ACK_BARCODE;
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
    char i,j,id_buf=10;
    char dest[2];
        
    dest[0]=msg[DST_HI];
    dest[1]=msg[DST_LO];

    buffer_a_transmitir[0].DST[0] = dest[0];
    buffer_a_transmitir[0].DST[1] = dest[1];
    
    for (i=0;i<CONEXOES_POSSIVEIS;i++)
    {
        if (dest[0]==buffer_a_transmitir[i].DST[0] && dest[1]==buffer_a_transmitir[i].DST[1])
          {
	        for (id_buf=0;id_buf<BUFFER_SIZE;id_buf++)
	        {
	            if (!(buffer_a_transmitir[i].buffer[id_buf][BUF_STATUS_POS]&NOT_TXED))
	            {
	                buffer_a_transmitir[i].buffer[id_buf][BUF_STATUS_POS] = msg[FUNCID];
	                for (j=1; j<TX_BARCODE_BUF_SIZE+1; j++)
	                {
	                  buffer_a_transmitir[i].buffer[id_buf][j] = msg[j-1+HDR_SIZE];
	                }
	                buffer_a_transmitir[i].buffer[BUF_STATUS_POS][id_buf] |= NOT_TXED;
	               
	              	// flag avisando q tem mensagem pra transmitir.
	                buffer_a_transmitir[i].ENVIAR_BUFFER = TRUE;
	                break;
	            }
	         }        
    		}
    }
}

// *************************************************************************************************
// @fn		Encode_siaer_data_guiche
// @brief 	Usado pelo Guiche. Empacota os dados para serem enviados via RF e triga eventos UART
// @param 	none, mas usa variaveis globais.
// @return 	none
// *************************************************************************************************
void Encode_siaer_data_guiche()
{
	char j, k, i;
	char etwas_tx=FALSE;
	
	 	switch(ed_data[5]) // funcid
	 	{
	 		// Achou um novo onibus. Atribuir um novo buffer a ele.
	 		 case POLL_ACK:
		 		// O que sera transmitido
		 		simpliciti_msg[1] = Guiche.cidade[0]; // SRC
		 		simpliciti_msg[2] = Guiche.cidade[1];
		 		simpliciti_msg[5] = POLLING; // funcid

		 		buffer_a_transmitir[num_onibus_conectados].DST[0] = ed_data[1]; // DST = ID DO BUS
		 		buffer_a_transmitir[num_onibus_conectados].DST[1] = ed_data[2]; // DST = ID DO BUS
		 		buffer_a_transmitir[num_onibus_conectados].EST_CONEXAO = ON; 	// Buffer esta em uso. Sera livre qnd ocorrer desconexao.
		 		buffer_a_transmitir[num_onibus_conectados].SRC[0]=Guiche.cidade[0]; // redundancia.
		 		buffer_a_transmitir[num_onibus_conectados].SRC[1]=Guiche.cidade[1]; // 
				ReportEventUart(BUS_CHEGOU,num_onibus_conectados);
				num_onibus_conectados++;
		        break;
		    
				// Soh mantem a conexao
				// for para cada onibus.
		    case POLL2_ACK:
				 for (i=0; i < num_onibus_conectados; i++)
		          {
		          	if((buffer_a_transmitir[i].DST[0] == ed_data[1]) && (buffer_a_transmitir[i].DST[1] == ed_data[2]))
		          	{
		          		// Se ha algo no buffer, enviar.				    	
						if( buffer_a_transmitir[i].ENVIAR_BUFFER == TRUE)
						{
							simpliciti_msg[0] = 16;
      						simpliciti_msg[1] = Guiche.cidade[0]; // source
      						simpliciti_msg[2] = Guiche.cidade[1]; // source
      						
      						simpliciti_msg[3] = buffer_a_transmitir[i].DST[0]; // source
      						simpliciti_msg[4] = buffer_a_transmitir[i].DST[1]; // source
      						simpliciti_msg[5] = (buffer_a_transmitir[i].buffer[0][BUF_STATUS_POS])&0x7F; // FUNCID

       						for (j=1; j<TX_BARCODE_BUF_SIZE+1; j++)
       						{
       							simpliciti_msg[j+5] = buffer_a_transmitir[i].buffer[0][j];
       						}
							// carregar dados a serem enviados
							buffer_a_transmitir[i].buffer[0][BUF_STATUS_POS]&=0x7F;
    						buffer_a_transmitir[i].buffer[0][BUF_STATUS_POS]|=TXED;
						}
						else
						{
							//ReportEventUart(BUS_CHEGOU,i);
						}
					}
		          }
		        break;
		        
		    // Onibus recebeu o barcode. Verificar qual dentre eles no buffer e mandar mais caso necessario.            
	        case TX_BARCODE_ACK:
			 for (i=0; i < num_onibus_conectados; i++)
	          {
	          	if((buffer_a_transmitir[i].DST[0] == ed_data[1]) && (buffer_a_transmitir[i].DST[1] == ed_data[2])) // verifica o destinatario correto 
	          	{
					if (buffer_a_transmitir[i].buffer[0][BUF_STATUS_POS]&TXED) // caso transmitiu com sucesso
	                {
	               		// manda resposta positiva pro programa do guiche
	                    ReportEventUart(RECEBEU_BARCODE,i); 
	                    
	                	for (j=0;j<TX_BARCODE_BUF_SIZE+1;j++) // zera o buffer
	                	{
	                 		buffer_a_transmitir[i].buffer[0][j]=0x00;
	                	}
	                    for (k=1; k<BUFFER_SIZE; k++) // copia o buffer 2 para o 1, o 3 para o 2...
	                    {
	                        for (j=0; j<TX_BARCODE_BUF_SIZE+1; j++)
	                     	{
	                            buffer_a_transmitir[i].buffer[k-1][j] = buffer_a_transmitir[i].buffer[k][j];
	                     	}
	                        if (buffer_a_transmitir[i].buffer[k][BUF_STATUS_POS]&NOT_TXED)
	                        {
	                        	// Ainda tem algo no buffer
	                          	etwas_tx=TRUE;
	                        }
	                    }
	                    if (etwas_tx==FALSE)
	                    {
	                       buffer_a_transmitir[i].ENVIAR_BUFFER = FALSE;
	                       simpliciti_msg[5] = POLLING2; // FUNCID
	                    }
	            	}
	          	}
	          }
	         break;      
	 }
}

// *************************************************************************************************
// @fn		Encode_siaer_data_onibus
// @brief 	Usado pelo Onibus. Empacota os dados para serem enviados via RF
// @param 	none
// @return 	none
// *************************************************************************************************
void Encode_siaer_data_onibus()
{
	switch(Onibus.EST_CONEXAO)
	{
		case OFF:
		   	simpliciti_msg[0] = ED_READY_2_RECEIVE;
	  		simpliciti_msg[1] = Onibus.id_bus[0]; // src 0
	  		simpliciti_msg[2] = Onibus.id_bus[1]; // src 1
		 	simpliciti_msg[3] = 0; // dst 0 
	  		simpliciti_msg[4] = 0; // dst 1
		 	simpliciti_msg[5] = POLL_ACK;
			break;
	
		case CONECTADO:
			// fazer poll 2
		 	simpliciti_msg[0] = ED_READY_2_RECEIVE;
	  		simpliciti_msg[1] = Onibus.id_bus[0]; // src 0
	  		simpliciti_msg[2] = Onibus.id_bus[1]; // src 1
		 	simpliciti_msg[3] = 0; // dst 0 
	  		simpliciti_msg[4] = 0; // dst 1
		 	simpliciti_msg[5] = POLL2_ACK;
		break;
		
		case ACK_BARCODE:
			// montar mensagem de ack
			simpliciti_msg[0] = ED_READY_2_RECEIVE;
	  		simpliciti_msg[1] = Onibus.id_bus[0]; // src 0
	  		simpliciti_msg[2] = Onibus.id_bus[1]; // src 1
		 	simpliciti_msg[3] = 0; // dst 0 
	  		simpliciti_msg[4] = 0; // dst 1
		 	simpliciti_msg[5] = TX_BARCODE_ACK;
		break;
	}
}

// *************************************************************************************************
// @fn		TrataMsgSimpliciti
// @brief 	Usado no Onibus. Recebe os dados via RF e trabalha a resposta e triga os eventos UART
// @param 	tipo de mensagem recebida
// @return 	none
// *************************************************************************************************
void TrataMsgSimpliciti(char tipo)
{
	Onibus.TIMEOUT=0;
    switch(simpliciti_msg[5]) //  funcid
    {
      case POLLING:
          // aqui o onibus chegou na estacao e recebeu um mensagem poll do guiche
          // implementar no codigo para primeira conexao
            Onibus.DST[0]=simpliciti_msg[1];  // src[0]
            Onibus.DST[1]=simpliciti_msg[2];  // msg_ptr->src[1];
            ReportEventUart(BUS_CHEGOU,NULL);
            Onibus.EST_CONEXAO = CONECTADO;
            // Mandar ACK
        
        break;
      case POLLING2:
	      Onibus.EST_CONEXAO = CONECTADO;
          // Mandar um ACK2 
          // feito apos a conexao estar feita, para manter contato com o bus
        
        break;
      default:
            if (simpliciti_msg[5] & TX_BARCODE)
            {
              // mandar via uart
              ReportEventUart(RECEBEU_BARCODE,NULL);
              Onibus.EST_CONEXAO = ACK_BARCODE;
              Onibus.TIMEOUT=0;
              // mandar ack
              //  bar_ack=MontaBusMsg(TX_BARCODE_ACK);
              // bar_ack.data[0]=msg_ptr->funcid&0x3F;
              // WITX_frame(bar_ack);
            }
        }
}

// *************************************************************************************************
// @fn		Incrementa_timeout
// @brief 	Usado pelo timer. Aumenta o timeout a cada segundo.
// @param 	none
// @return 	none
// *************************************************************************************************
void Incrementa_timeout(void)
{
  #ifdef END_DEVICE
	Onibus.TIMEOUT++; 
	if(Onibus.TIMEOUT > MAX_MISSES)
	{
		Conexao = OFF;
	}
  #elif ACCESS_POINT
   #endif
}
