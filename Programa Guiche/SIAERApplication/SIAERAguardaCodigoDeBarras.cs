using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SIAERComunicacaoSerial;
using System.IO.Ports;
using SIAERClassLibrary;
using System.Data.SqlClient;

namespace SIAERAplicacao
{
    public partial class SIAERAguardaCodigoDeBarras : Form
    {
        //public CComunicacaoSerialLeitor ComunicacaoSerialEstabelecida = new CComunicacaoSerialLeitor();
        private SerialPort PortaDeComunicacao = new SerialPort();
        CAtendente _atendente;
        string _codigodebarraslido;
        string transType = string.Empty;
        string BaudRateParaConstrutorComParametros;
        string ParityParaConstrutorComParametros;
        string DatabitParaConstrutorComParametros;
        string StopBitParaConstrutorComParametros;
        string PortNameParaConstrutorComParametros;
        public delegate void DelegateThisClose();

           public SIAERAguardaCodigoDeBarras(string PortName,string BaudRate, string Parity, string StopBit, string DataBit,CAtendente atendente)
           {
                InitializeComponent();
               
               //---------------------Pega o ESC------------------------
                this.KeyPreview = true;
                this.KeyPress += new KeyPressEventHandler(UmaTeclaFoiPressionada);
               //---------Comunicação Serial-------------------
                PortNameParaConstrutorComParametros = PortName;
                BaudRateParaConstrutorComParametros = BaudRate;
                ParityParaConstrutorComParametros = Parity;
                StopBitParaConstrutorComParametros = StopBit;
                DatabitParaConstrutorComParametros = DataBit;
                //-----------ProgressBar--------------
                this.timer1.Enabled = true;
                this.timer1.Interval = 300;
                this.progressBar1.Maximum = 100;
                this.progressBar1.Step = 20;
                this.progressBar1.TabIndex = 0;
                _atendente = atendente;
                PortaDeComunicacao.DataReceived += new SerialDataReceivedEventHandler(DadosRecebidosNaPortaSerial);
                this.OpenPort();
               //-----------------------------------
        }
             protected void timer1_Tick (object sender, System.EventArgs e)
             {
                if (progressBar1.Value >= this.progressBar1.Maximum )
                {
                    progressBar1.Value = 0;
                    return;
                }
                    progressBar1.Value += 20;
             }

             void UmaTeclaFoiPressionada(object sender, KeyPressEventArgs e)
             {
                 if (e.KeyChar == 27)//13 significa que a tecla ESC do teclado foi presisonada
                 {
                     this.FecharPortaDeComunicacaoSerial();
                     this.Close();
                 }
             }
             #region Iniciar conexão
             public bool OpenPort()
             {
                 try
                 {
                     //Testando se a porta serial está livre para comunicação
                     if (PortaDeComunicacao.IsOpen == true) PortaDeComunicacao.Close();

                     //Inicializa o Objeto de comunicação Serial
                     PortaDeComunicacao.BaudRate = int.Parse(BaudRateParaConstrutorComParametros);    //BaudRate
                     PortaDeComunicacao.DataBits = int.Parse(DatabitParaConstrutorComParametros);    //DataBits
                     PortaDeComunicacao.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBitParaConstrutorComParametros);    //StopBits
                     PortaDeComunicacao.Parity = (Parity)Enum.Parse(typeof(Parity), ParityParaConstrutorComParametros);    //Parity
                     PortaDeComunicacao.PortName = PortNameParaConstrutorComParametros;   //PortName
                     //now open the port
                     PortaDeComunicacao.Open();
                     PortaDeComunicacao.DiscardInBuffer();//Limpa o buffer de entrada da serial antes de usá-la
                     return true;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Erro ao conectar-se com o leitor de código de barras.\nDescrição do erro:\n  "+ex.Message.ToString(), "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     this.Dispose();
                     return false;
                 }
             }
             #endregion

             #region Fechamento de Conexão
             public bool FecharPortaDeComunicacaoSerial()
             {
                 try
                 {
                     PortaDeComunicacao.Close();
                     return true;
                 }
                 catch (Exception ex)
                 {
                     return false;
                 }
             }
             #endregion

             #region Dados Recebidos na Serial
             public void DadosRecebidosNaPortaSerial(object sender, SerialDataReceivedEventArgs e)
             {
                 String msg = null;
                 do
                 {
                     msg += PortaDeComunicacao.ReadExisting();
                 } while (msg[msg.Length - 1] != 10);//10 significa que estamos aguardando um /n, ou seja, uma quebra de linha para parar a verificação na porta
                 this.FecharPortaDeComunicacaoSerial();
                 CCodigoDeBarra bars = new CCodigoDeBarra();
                 bars.Code = msg;
                 if (bars.ValidarCodigoDeBarras() == 0)//Código chegou com sucesso
                 {
                     int Resultado;
                     string Guiche;
                     string Onibus;
                     try
                     {
                         //Conexão
                         using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                         {
                             //Comando 
                             SqlCommand command = null;
                             using (command = new SqlCommand("PreveAtualizaTrajetoEncomenda", connection))
                             {
                                 command.CommandType = CommandType.StoredProcedure;
                                 //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                                 command.Parameters.Add("@codigoencomenda", SqlDbType.VarChar, 20);
                                 command.Parameters["@codigoencomenda"].Value = bars.Code;
                                 command.Parameters.Add("@Resultado", SqlDbType.Int);
                                 command.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                                 command.Parameters.Add("@Guiche", SqlDbType.VarChar, 20);
                                 command.Parameters["@Guiche"].Direction = ParameterDirection.Output;
                                 command.Parameters.Add("@Onibus", SqlDbType.VarChar, 20);
                                 command.Parameters["@Onibus"].Direction = ParameterDirection.Output;
                                 //Configura os parâmetros.
                                 //daGetRecords.SelectCommand = command;
                                 connection.Open();
                                 //@Resultado:
                                 // 0-> AEncomenda subirá em um ônibus
                                 // 1-> A Encomenda descerá em um Guichê
                                 // 2-> Já está no guiche de destino
                                 // 3-> A encomenda já foi entregue ao cliente
                                 command.ExecuteNonQuery();
                                 Resultado = (int)command.Parameters["@Resultado"].Value;
                                 Guiche = (string)command.Parameters["@Guiche"].Value;
                                 Onibus = (string)command.Parameters["@Onibus"].Value;
                                 connection.Close();
                             }
                         }
                     }
                     catch (Exception)
                     {
                         throw;
                     }
                     string ConfirmaAcao = "";
                         switch (Resultado)
                         {
                             case 0:
                                 ConfirmaAcao = "Deseja transferir a encomenda " + bars.Code + " para o ônibus " + Onibus + "?";
                                 break;
                             case 1:
                                 //if(Resultado == 1 && Guiche == _atendente.Cidade)
                                 //{
                                    ConfirmaAcao = "Deseja receber a encomenda " + bars.Code + " do ônibus " + Onibus + "?";
                                 //}
                                 //else
                                 //{
                                  //  MessageBox.Show("A encomenda " + bars.Code.ToString() + " não pode ser registrada em " + _atendente.Cidade + ". A próxima cidade desta encomenda seria " + Guiche, "Situação da Encomenda " + bars.Code.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  //  Resultado = 100;//valor aleatório
                                // }
                                     break;
                             case 2:
                                 ConfirmaAcao = "A Encomenda " + bars.Code.ToString() + " já está em " + Guiche + " sua cidade de destino.\nGostaria de entregá-la ao cliente?";
                                 break;
                             case 3:
                                 String Data, Hora;
                                 Data = Onibus.Substring(8, 2);
                                 Data += "/" + Onibus.Substring(5, 2);
                                 Data += "/" + Onibus.Substring(0, 4);
                                 Hora = Onibus.Substring(11, 8);
                                 MessageBox.Show("A Encomenda " + bars.Code.ToString() + " já foi entregue ao cliente em " + Data + " às " + Hora, "Situação da Encomenda " + bars.Code.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 break;
                         }
                         if (Resultado <= 2)
                         {
                             if (MessageBox.Show(ConfirmaAcao, "Notificação", MessageBoxButtons.OKCancel) == DialogResult.OK)
                             {
                                 try
                                 {
                                     //Conexão
                                     using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                                     {
                                         //Comando 
                                         SqlCommand command = null;
                                         using (command = new SqlCommand("AtualizaTrajetoEncomenda", connection))
                                         {
                                             command.CommandType = CommandType.StoredProcedure;
                                             //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                                             command.Parameters.Add("@codigoencomenda", SqlDbType.VarChar, 20);
                                             command.Parameters["@codigoencomenda"].Value = bars.Code;
                                             command.Parameters.Add("@quempassouocodigo", SqlDbType.VarChar, 20);
                                             command.Parameters["@quempassouocodigo"].Value = _atendente.UserName.ToString();
                                             command.Parameters.Add("@Resultado", SqlDbType.Int);
                                             command.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                                             command.Parameters.Add("@Guiche", SqlDbType.VarChar, 20);
                                             command.Parameters["@Guiche"].Direction = ParameterDirection.Output;
                                             command.Parameters.Add("@Onibus", SqlDbType.VarChar, 20);
                                             command.Parameters["@Onibus"].Direction = ParameterDirection.Output;
                                             //Configura os parâmetros.
                                             //daGetRecords.SelectCommand = command;
                                             connection.Open();
                                             //@Resultado:
                                             // 0-> Atualizou com sucesso e desceu em um guichê
                                             // 1-> Atualizou com sucesso e subiu em um ônibus
                                             // 2-> Atualizou com sucesso e acabou de chegar na cidade de destino
                                             // 3-> Já está no guiche de destino
                                             // 4-> A encomenda ja está com o cliente
                                             command.ExecuteNonQuery();
                                             Resultado = (int)command.Parameters["@Resultado"].Value;
                                             Guiche = (string)command.Parameters["@Guiche"].Value;
                                             Onibus = (string)command.Parameters["@Onibus"].Value;
                                             connection.Close();
                                         }
                                     }
                                 }
                                 catch (Exception)
                                 {
                                     throw;
                                 }
                                 switch (Resultado)
                                 {
                                     case 0:
                                         MessageBox.Show("A encomenda " + bars.Code.ToString() + " foi registrada em " + Guiche + " com sucesso\nHorário: " + DateTime.Now.ToString(), "Situação da Encomenda " + bars.Code.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         break;
                                     case 1:
                                         MessageBox.Show("A encomenda " + bars.Code.ToString() + " saiu de " + Guiche + " e foi cadastrada no ônibus: " + Onibus + "\nHorário: " + DateTime.Now.ToString(), "Situação da Encomenda " + bars.Code.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         break;
                                     case 2:
                                         MessageBox.Show("A encomenda " + bars.Code.ToString() + " chegou em " + Guiche + ", sua cidade de destino\nHorário: " + DateTime.Now.ToString(), "Situação da Encomenda " + bars.Code.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         break;
                                     case 3:
                                         MessageBox.Show("A Encomenda " + bars.Code.ToString() + " foi entregue ao cliente em " + Guiche, "Situação da Encomenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         break;
                                     case 4:
                                         MessageBox.Show("A Encomenda " + bars.Code.ToString() + " já foi entregue ao cliente ao cliente em " + Onibus, "Situação da Encomenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         break;
                                 }
                             }
                         }
                     }
                     else
                     {
                         //AVISAR AO USUÁRIO QUE A LEITURA FALHOU!!!
                     }
                     BeginInvoke(new DelegateThisClose(this.Close));//Invoke para chamar o this.close() da thread do Form principal
             }
             #endregion
    }
}
