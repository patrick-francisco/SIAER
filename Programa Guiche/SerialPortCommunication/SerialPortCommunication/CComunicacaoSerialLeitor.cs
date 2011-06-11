using System;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using SIAERClassLibrary;

namespace SIAERComunicacaoSerial
{
    public class CComunicacaoSerialLeitor
    {
        #region Enumeradores de Conexão Serial
        /// <summary>
        /// Enumerador para especificar o tipo de transmissão
        /// </summary>
        public enum TransmissionType { Text, Hex }

        /// <summary>
        /// Enumerador para especificar o tipo de mensagem
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };

        /// <summary>
        /// Enumerador para especificar que dispositivo enviará na porta serial
        /// </summary>
        public enum QuemEnviara { Onibus, Leitor, Ninguem };
        #endregion

        #region Variáveis para Conexão Serial
        //Variáveis de parâmetros
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;       
        private TransmissionType _transType;
        private SerialPort PortaDeComunicacao = new SerialPort();
        #endregion

        #region Métodos de Leitura e Escrita dos atributos
        
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

         public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

         public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CComunicacaoSerialLeitor()
        {
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = "COM3";
            //Evento criado para reconhecer dados na porta Serial
            //PortaDeComunicacao.DataReceived += new SerialDataReceivedEventHandler(DadosRecebidosNaPortaSerial);
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        private string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

        #region Iniciar conexão
        public bool OpenPort()
        {
            try
            {
                //Testando se a porta serial está livre para comunicação
                if (PortaDeComunicacao.IsOpen == true) PortaDeComunicacao.Close();

                //Inicializa o Objeto de comunicação Serial
                PortaDeComunicacao.BaudRate = int.Parse(_baudRate);    //BaudRate
                PortaDeComunicacao.DataBits = int.Parse(_dataBits);    //DataBits
                PortaDeComunicacao.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                PortaDeComunicacao.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                PortaDeComunicacao.PortName = _portName;   //PortName
                //now open the port
                PortaDeComunicacao.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //DisplayData(MessageType.Error, ex.Message);
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
        	catch(Exception ex)
        	{
        		return false;
        	}
        }
        #endregion

        #region Receber de Dados
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DadosRecebidosNaPortaSerial(object sender, SerialDataReceivedEventArgs e)
        {
            String msg = null;
            do
            {
                msg += PortaDeComunicacao.ReadExisting();
            }while(msg[msg.Length-1]!= 10);//10 significa que estamos aguardando um /n, ou seja, uma quebra de linha para parar a verificação na porta
            CCodigoDeBarra bars = new CCodigoDeBarra();
            bars.Code = msg;
            if (bars.ValidarCodigoDeBarras() == 0)
            {
                bars.SalvarDadosNoBancoDeDados();
            }
            else 
            { 
                //AVISAR AO USUÁRIO QUE A LEITURA FALHOU!!!
            }
        }
        #endregion
    }
}
