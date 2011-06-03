using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SIAERComunicacaoSerial;
using SIAERClassLibrary;

namespace SIAERComunicacaoSerial
{
    public partial class FormMain : Form
    {
        CComunicacaoSerial ComunicacaoSerialEstabelecida = new CComunicacaoSerial();
        string transType = string.Empty;
        string BaudRateParaConstrutorComParametros;
        string ParityParaConstrutorComParametros;
        string DatabitParaConstrutorComParametros;
        string StopBitParaConstrutorComParametros;
        string PortNameParaConstrutorComParametros;
        #region Enumeradores de Conexão Serial
        /// <summary>
        /// Enumerador para especificar quem irá enviar
        /// </summary>
        public enum QuemEnviara { Onibus, Leitor };
        private QuemEnviara _quemtrans;
        public QuemEnviara QuemEstaEnviando
        {
            get { return _quemtrans; }
            set { _quemtrans = value; }
        }

        #endregion

        public FormMain()
        {
            InitializeComponent();
        }
        public FormMain(string PortName,string BaudRate, string Parity, string StopBit, string DataBit)
        {
            InitializeComponent();
            PortNameParaConstrutorComParametros = PortName;
            BaudRateParaConstrutorComParametros = BaudRate;
            ParityParaConstrutorComParametros = Parity;
            StopBitParaConstrutorComParametros = StopBit;
            DatabitParaConstrutorComParametros = DataBit;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           CarregarParametrosDeComunicacao();
           CarregarParametrosDeComunicacaoPadrao();
           ControleDeVisibilidadeInicialDosComponentesDoForm();
           ComunicacaoSerialEstabelecida.CurrentTransmissionType = SIAERComunicacaoSerial.CComunicacaoSerial.TransmissionType.Text;
        }

        
        /// <summary>
        /// Função para inicializar os parâmetros padrões para a comunicação serial
        /// </summary>
        private void CarregarParametrosDeComunicacaoPadrao()
        {
            ComboBoxPorta.SelectedText = PortNameParaConstrutorComParametros;
            cboBaud.SelectedText = BaudRateParaConstrutorComParametros;
            ComboBoxParidade.SelectedText = ParityParaConstrutorComParametros;
            ComboBoxBitDeParada.SelectedText = StopBitParaConstrutorComParametros;
            cboData.SelectedText = DatabitParaConstrutorComParametros;
        }

        /// <summary>
        /// methos to load our serial
        /// port option values
        /// </summary>
        private void CarregarParametrosDeComunicacao()
        {
            ComunicacaoSerialEstabelecida.CarregarComboBoxDePortas(ComboBoxPorta);
            ComunicacaoSerialEstabelecida.CarregarComboBoxDeParidade(ComboBoxParidade);
            ComunicacaoSerialEstabelecida.CarregarComboBoxDeStopBit(ComboBoxBitDeParada);
        }

        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
        /// </summary>
        private void ControleDeVisibilidadeInicialDosComponentesDoForm()
        {
            cmdSend.Enabled = false;
            TextBoxDesconectar.Enabled = false;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            ComunicacaoSerialEstabelecida.WriteData(txtSend.Text);
        }

        private void TextBoxDesconectar_Click(object sender, EventArgs e)
        {
        	TextBoxConectar.Enabled = true;
        	TextBoxDesconectar.Enabled = false;
        	cmdSend.Enabled = false;
            ComunicacaoSerialEstabelecida.FecharPortaDeComunicacaoSerial();
        }

        private void TextBoxConectar_Click(object sender, EventArgs e)
        {
            ComunicacaoSerialEstabelecida.Parity = ComboBoxParidade.Text;
            ComunicacaoSerialEstabelecida.StopBits = ComboBoxBitDeParada.Text;
            ComunicacaoSerialEstabelecida.DataBits = cboData.Text;
            ComunicacaoSerialEstabelecida.BaudRate = cboBaud.Text;
            ComunicacaoSerialEstabelecida.PortName = ComboBoxPorta.Text;
            ComunicacaoSerialEstabelecida.DisplayWindow = rtbDisplay;
            ComunicacaoSerialEstabelecida.OpenPort();

            TextBoxConectar.Enabled = false;
            TextBoxDesconectar.Enabled = true;
            cmdSend.Enabled = true;
        }
    }
}