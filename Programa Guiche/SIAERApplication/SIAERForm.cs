using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIAERComunicacaoSerial;
using SIAERClassLibrary;
using System.Threading;
using System.IO.Ports;
using System.Collections;


namespace SIAERAplicacao
{
    public partial class FormSIAER : Form
    {
        #region Atributos
        CComunicacaoSerial ComunicacaoComLeitorDeCodigoDeBarras = new CComunicacaoSerial();
        CComunicacaoSerial ComunicacaoComOnibus = new CComunicacaoSerial();
        CAtendente Atendente = new CAtendente();
        int count = 0;//
        public delegate void DelegateToggleTimer2();
        /// <summary>
        /// Cada ônibus que chegar receberá uma nova entrada na variável Msp
        /// </summary>
        List<CMspOnibus> Msp = new List<CMspOnibus>();
        int PosicaoListaTransmissaoCarro = 0;
        byte MSB, LSB;
        private SerialPort PortaDeComunicacao = new SerialPort();
        int OffsetListBoxWidth=11;
        int OffsetAlturaListBox = 9;
        int AlturaListBoxs;
        int OffsetOnde = 10;
        string toolstriplabelconexaotext = "Desconectado ao dispostivo para comunicação com ônibus...";
        List<CCarro> CarrosNaPlataforma = new List<CCarro>();
        #endregion

        #region Construtores
        public FormSIAER(CAtendente AtendenteAtual)
        {
            Atendente = AtendenteAtual;
            InitializeComponent();
            //Timer para atualizar as ListBox com os dados mais recentes do banco
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.timer2.Enabled = false;
            this.timer2.Interval = 500;
            this.TimerAtualizaListaEncomendasCarros.Enabled = false;
            this.TimerAtualizaListaEncomendasCarros.Interval = 10000;
            this.LabelCidade.Text = this.Atendente.Cidade;
            //Ajuste de Label de indicação da cidade
            this.LabelVc.Location = new Point(this.Width - this.LabelVc.Width - OffsetOnde, this.LabelVc.Location.Y);
            this.LabelCidade.Location = new Point(this.Width - this.LabelCidade.Width - OffsetOnde, this.LabelCidade.Location.Y);

                this.PanelLeft.Location = new Point(0, this.MenuStripSIAERAplicacao.Height);
            this.PanelLeft.Height = this.StatusStripSiaerForm.Location.Y - this.MenuStripSIAERAplicacao.Height;
            this.SizeChanged +=new EventHandler(FormSIAER_MaximumSizeChanged);
            AlturaListBoxs = (5 * this.PanelLeft.Height / 6) + OffsetAlturaListBox;
            this.Button1.Height = 30;
            this.Button1.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.Button2.Height = 30;
            this.Button2.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.Button3.Height = 30;
            this.Button3.Width = (this.Width - this.PanelLeft.Width) / 3;
            //Localização e Redimensionamento listbox1
            this.Button1.Location = new Point(this.PanelLeft.Width, AlturaListBoxs);
            this.ListBox1.Location = new Point(this.PanelLeft.Width, AlturaListBoxs + this.Button1.Height);
            this.ListBox1.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.ListBox1.Height = this.StatusStripSiaerForm.Location.Y - (this.Button1.Location.Y + this.Button1.Height) + OffsetListBoxWidth;
            //Localização e Redimensionamento listbox2
            this.Button2.Location = new Point(this.PanelLeft.Width + this.Button1.Width, AlturaListBoxs);
            this.ListBox2.Location = new Point(this.PanelLeft.Width + this.Button1.Width, AlturaListBoxs + this.Button2.Height);
            this.ListBox2.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.ListBox2.Height = this.StatusStripSiaerForm.Location.Y - (this.Button2.Location.Y + this.Button2.Height) + OffsetListBoxWidth;
            //Localização e Redimensionamento listbox3
            this.Button3.Location = new Point(this.PanelLeft.Width + this.Button1.Width + this.Button2.Width, AlturaListBoxs);
            this.ListBox3.Location = new Point(this.PanelLeft.Width + this.Button1.Width + this.Button2.Width, AlturaListBoxs + this.Button3.Height);
            this.ListBox3.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.ListBox3.Height = this.StatusStripSiaerForm.Location.Y - (this.Button3.Location.Y + this.Button3.Height) + OffsetListBoxWidth;
           //Preenche as ListBox com os códigos das encomendas
            this.Button1.Text += " " + this.Atendente.Cidade;
            PreencherListBoxs();
            this.PictureBoxCarro1.Visible = false;
            this.PictureBoxCarro2.Visible = false;
            this.PictureBoxCarro3.Visible = false;
            this.PictureBoxCarro4.Visible = false;
            this.Label1Carro1.Visible = false;
            this.Label1Carro2.Visible = false;
            this.Label1Carro3.Visible = false;
            this.Label1Carro4.Visible = false;
            this.Label2Carro1.Visible = false;
            this.Label2Carro2.Visible = false;
            this.Label2Carro3.Visible = false;
            this.Label2Carro4.Visible = false;
//            this.PictureBoxCarro1.Image = new Bitmap (Properties.Resources.SIAEROnibusFigura);
            this.PictureBoxCarro1.Image = new Bitmap(Properties.Resources.ONIBUS2); 
            this.PictureBoxCarro2.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
            this.PictureBoxCarro3.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
            this.PictureBoxCarro4.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
        
        
        }

        private void FormSIAER_MaximumSizeChanged(object sender, EventArgs e)
        {
            this.PanelLeft.Location = new Point(0, this.MenuStripSIAERAplicacao.Height);
            this.PanelLeft.Height = this.StatusStripSiaerForm.Location.Y - this.MenuStripSIAERAplicacao.Height;

            this.LabelVc.Location = new Point(this.Width - this.LabelVc.Width - OffsetOnde, this.LabelVc.Location.Y);
            this.LabelCidade.Location = new Point(this.Width - this.LabelCidade.Width - OffsetOnde, this.LabelCidade.Location.Y);

            this.Button1.Height = 30;
            this.Button1.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.Button2.Height = 30;
            this.Button2.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.Button3.Height = 30;
            this.Button3.Width = (this.Width - this.PanelLeft.Width) / 3;
            AlturaListBoxs = 5 * (this.PanelLeft.Height / 6) + OffsetAlturaListBox;
            //Localização e Redimensionamento listbox1
            this.Button1.Location = new Point(this.PanelLeft.Width, AlturaListBoxs);
            this.ListBox1.Location = new Point(this.PanelLeft.Width, AlturaListBoxs + this.Button1.Height);
            this.ListBox1.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.ListBox1.Height = this.StatusStripSiaerForm.Location.Y - (this.Button1.Location.Y + this.Button1.Height) + OffsetListBoxWidth;
            //Localização e Redimensionamento listbox2
            this.Button2.Location = new Point(this.PanelLeft.Width + this.Button1.Width, AlturaListBoxs);
            this.ListBox2.Location = new Point(this.PanelLeft.Width + this.Button1.Width, AlturaListBoxs + this.Button2.Height);
            this.ListBox2.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.ListBox2.Height = this.StatusStripSiaerForm.Location.Y - (this.Button2.Location.Y + this.Button2.Height) + OffsetListBoxWidth;
            //Localização e Redimensionamento listbox3
            this.Button3.Location = new Point(this.PanelLeft.Width + this.Button1.Width + this.Button2.Width, AlturaListBoxs);
            this.ListBox3.Location = new Point(this.PanelLeft.Width + this.Button1.Width + this.Button2.Width, AlturaListBoxs + this.Button3.Height);
            this.ListBox3.Width = (this.Width - this.PanelLeft.Width) / 3;
            this.ListBox3.Height = this.StatusStripSiaerForm.Location.Y - (this.Button3.Location.Y + this.Button3.Height) + OffsetListBoxWidth;
            //Redimensionamento PanelCarros
            this.PanelCarros.Height = (this.Button3.Location.Y - (this.LabelCidade.Location.Y + this.LabelCidade.Height));
            this.PanelCarros.Width = 250;
            this.PanelCarros.Location = new Point((this.LabelCidade.Location.X + this.LabelCidade.Width) - this.PanelCarros.Width, this.LabelCidade.Location.Y + this.LabelCidade.Height);
            this.ButtonCarros.Location = this.PanelCarros.Location;
            this.ButtonCarros.Width = this.PanelCarros.Width;
        }

        private void SIAERForm_Load(object sender, EventArgs e)
        {
            ToolStripLabelConexao.Text = toolstriplabelconexaotext;
            SelecionarParametosPadraoComunicacaoCodigoDeBarras();
            SelecionarParametosPadraoComunicacaoOnibus();
            PortaDeComunicacao.DataReceived += new SerialDataReceivedEventHandler(DadosRecebidosNaPortaSerial);
            CarregarComboBoxDePortas(ComboBoxPortas);
        }
        #endregion

        #region ToolStripMenuItem para comunicação com o Leitor de Código de Barras
        private void ToolStripMenuItemLeitorDeCodigoDeBarras_Click(object sender, EventArgs e)
        {
            SIAERComunicacaoSerial.FormMain FormSerial = new SIAERComunicacaoSerial.FormMain(ComunicacaoComLeitorDeCodigoDeBarras.PortName, ComunicacaoComLeitorDeCodigoDeBarras.BaudRate, ComunicacaoComLeitorDeCodigoDeBarras.Parity, ComunicacaoComLeitorDeCodigoDeBarras.StopBits, ComunicacaoComLeitorDeCodigoDeBarras.DataBits);
            FormSerial.Text = "Leitor de Código de Barras";
            FormSerial.Show();
        }

        #region Selecionar as opções padrões previstas para o Leitor de Código de Barras
        private void SelecionarParametosPadraoComunicacaoCodigoDeBarras()
        {
            ComunicacaoComLeitorDeCodigoDeBarras.Parity = "None";
            ComunicacaoComLeitorDeCodigoDeBarras.StopBits = "1";
            ComunicacaoComLeitorDeCodigoDeBarras.DataBits = "8";
            ComunicacaoComLeitorDeCodigoDeBarras.BaudRate = "1200";
            ComunicacaoComLeitorDeCodigoDeBarras.PortName = "COM4";
            ComunicacaoComLeitorDeCodigoDeBarras.DisplayWindow = null;
        }
        #endregion
        #endregion

        #region ToolStripMenuItem para comunicação com o Ônibus
        /// <summary>
        /// Selecionar as opções padrões previstas para a comunicação com o Ônibus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemOnibus_Click(object sender, EventArgs e)
        {
            SIAERComunicacaoSerial.FormMain FormSerial = new SIAERComunicacaoSerial.FormMain(ComunicacaoComLeitorDeCodigoDeBarras.PortName, ComunicacaoComLeitorDeCodigoDeBarras.BaudRate, ComunicacaoComLeitorDeCodigoDeBarras.Parity, ComunicacaoComLeitorDeCodigoDeBarras.StopBits, ComunicacaoComLeitorDeCodigoDeBarras.DataBits);
            FormSerial.Text = "Ônibus";
            FormSerial.Show();
        }

        /// <summary>
        /// Selecionar as opções padrões previstas para a comunicação com o Ônibus
        /// </summary>
        private void SelecionarParametosPadraoComunicacaoOnibus()
        {
            ComunicacaoComOnibus.Parity = "None";
            ComunicacaoComOnibus.StopBits = "1";
            ComunicacaoComOnibus.DataBits = "8";
            ComunicacaoComOnibus.BaudRate = "9600";
            ComunicacaoComOnibus.PortName = "COM3";
        }



        #endregion

        #region ToolStripMenuItem para Cadastro de Clientes
        private void ToolStripMenuItemCadastroClientes_Click(object sender, EventArgs e)
        {
            SIAERCadastroCliente FormDeCadastro = new SIAERCadastroCliente();
            FormDeCadastro.Show();
        }
        #endregion

        private void ToolStripMenuItemFechar_Click_1(object sender, EventArgs e)
        {
            FecharPortaDeComunicacaoSerial();
            Application.Exit();
        }


        #region ToolStripMenuItem para Cadastro de Clientes
        private void ToolStripMenuItemCadastroEncomendas_Click(object sender, EventArgs e)
        {
            SIAERCadastroEncomenda FormDeCadastro = new SIAERCadastroEncomenda(Atendente);
            FormDeCadastro.Show();
        }
        #endregion

        private void ButtonValidarChegadaEncomenda_Click(object sender, EventArgs e)
        {
            try
            {
                SIAERAguardaCodigoDeBarras FormAguardaCodigo = new SIAERAguardaCodigoDeBarras(ComunicacaoComLeitorDeCodigoDeBarras.PortName, ComunicacaoComLeitorDeCodigoDeBarras.BaudRate, ComunicacaoComLeitorDeCodigoDeBarras.Parity, ComunicacaoComLeitorDeCodigoDeBarras.StopBits, ComunicacaoComLeitorDeCodigoDeBarras.DataBits, Atendente);
                FormAguardaCodigo.Show();
            }
            catch 
            { 
                
            }
        }

        #region Serial
        public bool OpenPort()
        {
            try
            {
                    //Inicializa o Objeto de comunicação Serial
                    PortaDeComunicacao.BaudRate = int.Parse(ComunicacaoComOnibus.BaudRate);    //BaudRate
                    PortaDeComunicacao.DataBits = int.Parse(ComunicacaoComOnibus.DataBits);    //DataBits
                    PortaDeComunicacao.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ComunicacaoComOnibus.StopBits);    //StopBits
                    PortaDeComunicacao.Parity = (Parity)Enum.Parse(typeof(Parity), ComunicacaoComOnibus.Parity);    //Parity
                    PortaDeComunicacao.PortName = ComboBoxPortas.Text;   //PortName
                    //now open the port
                    PortaDeComunicacao.Open();
                    PortaDeComunicacao.DiscardInBuffer();//Limpa o buffer de entrada da serial antes de usá-la
                    this.ButtonConectar.Text = "Desconectar";
                    toolstriplabelconexaotext = "Conectado ao dispostivo para comunicação com ônibus...";
                    ComboBoxPortas.Enabled = false;
                    ToolStripLabelConexao.Text = toolstriplabelconexaotext;
                    return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Não existe dispositivo na porta "+this.PortaDeComunicacao.PortName.ToString() +" para comunicação com ônibus", "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolstriplabelconexaotext = "Desconectado ao dispostivo para comunicação com ônibus...";
                ComboBoxPortas.Enabled = true;
                ToolStripLabelConexao.Text = toolstriplabelconexaotext;
                return false;
            }
        }
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
        //Função que vai tratar todas as conversas com o MSP430
        public void DadosRecebidosNaPortaSerial(object sender, SerialDataReceivedEventArgs e)
        {
            String msg = null;
            int Cifrao = 0;
            do
            {
                msg += Convert.ToChar(PortaDeComunicacao.ReadChar());
                if (msg[msg.Length - 1] == 0x24)
                {
                    Cifrao++;
                }
            }while(Cifrao<2); //while (msg[0] == 0x24 && msg[msg.Length - 1] != 36);//36 e 0x24 significa $
            PortaDeComunicacao.DiscardInBuffer();//Limpa o buffer de entrada da serial antes de usá-la
            if (msg[1] == 0x0C)//0x0C byte indicando chegada em cidade
            {
                int codbus = Convert.ToInt32((char)msg[2]) * 256 + Convert.ToInt32((char)msg[3]);
                bool flag = false;
                foreach (CMspOnibus c in Msp)
                { 
                    if(codbus.ToString() == c.Onibus)
                    {
                        flag = true;
                    }
                }
                if(!flag)
                {
                    CMspOnibus Mspx = new CMspOnibus(Atendente.Cidade, Convert.ToString(codbus));
                    Mspx.OnibusHex[0] = (byte)msg[2];
                    Mspx.OnibusHex[1] = (byte)msg[3];
                    Mspx.RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro();
                    Msp.Add(Mspx);
                    BeginInvoke(new DelegateToggleTimer2(this.Habilitatimer2));
                    CarrosNaPlataforma.Add(new CCarro(Convert.ToString(codbus)));
                    BeginInvoke(new DelegateToggleTimer2(this.AtualizarOnibusNaPlataforma));
                }
            }
            if (msg[1] == 0x0A)//0x0A byte indicando ACK de encomenda
            {
                BeginInvoke(new DelegateToggleTimer2(this.Desabilitatimer2));
                int codbus = Convert.ToInt32((char)msg[2]) * 256 + Convert.ToInt32((char)msg[3]);
                int Posicao = 0;
                string enc;
                foreach (CMspOnibus c in Msp)
                {
                    if (c.OnibusHex[0] == msg[2] && c.OnibusHex[1] == msg[3])
                    {
                        break;
                    }
                    Posicao += 1;
                }
                enc = msg.Substring(5, 5);
                foreach (CEncomenda cl in Msp[Posicao].EncomendasQueVaoParaOCarro)
                {
                    if (enc == cl.Codigo)
                    {

                        if (Msp[Posicao].EncomendasQueVaoParaOCarro.Count > Msp[Posicao].PosicaoListaTransmissaoEncomenda + 1)
                        {
                            BeginInvoke(new DelegateToggleTimer2(this.Habilitatimer2));//Tempo de envio entre duas enconmendas
                            Msp[Posicao].PosicaoListaTransmissaoEncomenda++;
                        }
                        break;
                    }
                }
            }
            if (msg[1] == 0x0D)//0x0D Perdeu Conexão com um Onibus
            {
                int codbus = Convert.ToInt32((char)msg[2]) * 256 + Convert.ToInt32((char)msg[3]);
                CMspOnibus x = new CMspOnibus();
                foreach (CMspOnibus m in Msp)
                {
                    if (m.Onibus == codbus.ToString())
                    {
                        x = m;
                    }
                }
                Msp.Remove(x);
                BeginInvoke(new DelegateToggleTimer2(this.AtualizarOnibusNaPlataforma));
            }
            if (Msp.Count != 0)
            {
                BeginInvoke(new DelegateToggleTimer2(this.HabilitaTimerAtualizaListaEncomendasCarros));
            }
            else
            {
                BeginInvoke(new DelegateToggleTimer2(this.DesabilitaTimerAtualizaListaEncomendasCarros));
            }
        }
        #endregion

        private void localizarEncomendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIAERPerguntaLocalizaEncomenda FormLocalizaEncomenda = new SIAERPerguntaLocalizaEncomenda();
            FormLocalizaEncomenda.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SIAERPerguntaLocalizaEncomenda FormLocalizaEncomenda = new SIAERPerguntaLocalizaEncomenda();
            FormLocalizaEncomenda.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                SIAERAguardaCodigoDeBarras FormAguardaCodigo = new SIAERAguardaCodigoDeBarras(ComunicacaoComLeitorDeCodigoDeBarras.PortName, ComunicacaoComLeitorDeCodigoDeBarras.BaudRate, ComunicacaoComLeitorDeCodigoDeBarras.Parity, ComunicacaoComLeitorDeCodigoDeBarras.StopBits, ComunicacaoComLeitorDeCodigoDeBarras.DataBits, Atendente);
                FormAguardaCodigo.Show();
            }
            catch
            {

            }
        }
        private void PreencherListBoxs()
        {
            //Preenchendo ListBox1 com as encomendas existentes no guiche atual
            CEncomenda Encomenda = new CEncomenda();
            ArrayList ArrayEncomendas;
            ArrayEncomendas = Encomenda.RetornaTodasEncomendasEmGuiche(this.Atendente.Cidade);
            ListBox1.Items.Clear();
            for (int Item = 0; Item < ArrayEncomendas.Count; Item++)
            {
                ListBox1.Items.Add(ArrayEncomendas[Item]);
            }
            ArrayEncomendas.Clear();
            //Preenchendo ListBox2 com as encomendas que chegarão na cidade atual
            ArrayEncomendas = Encomenda.RetornaEncomendasAChegarEmGuiche(this.Atendente.Cidade);
            ListBox2.Items.Clear();
            for (int Item = 0; Item < ArrayEncomendas.Count; Item++)
            {
                ListBox2.Items.Add(ArrayEncomendas[Item]);
            }
            ArrayEncomendas.Clear();
            //Preenchendo ListBox3 com as encomendas nas quais o destino é a cidade atual
            ArrayEncomendas = Encomenda.RetornaEncomendasEmGuicheDeDestino(this.Atendente.Cidade);
            ListBox3.Items.Clear();
            for (int Item = 0; Item < ArrayEncomendas.Count; Item++)
            {
                ListBox3.Items.Add(ArrayEncomendas[Item]);
            }
            ArrayEncomendas.Clear();

        }

        protected void timer1_Tick(object sender, System.EventArgs e)
        {
            PreencherListBoxs();
        }
        protected void timer2_Tick(object sender, System.EventArgs e)
        {
            if (Msp.Count > 0)
            {
                for(int i = 0; i<Msp.Count; i++)
                {
                    if (Msp[i].EncomendasQueVaoParaOCarro.Count > 0)
                    TransmiteEncomenda(i);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SIAERPerguntaGerarEtiqueta PerguntaEtiqueta = new SIAERPerguntaGerarEtiqueta();
            PerguntaEtiqueta.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SIAERCadastroEncomenda FormDeCadastro = new SIAERCadastroEncomenda(Atendente);
            FormDeCadastro.Show();
        }
        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CMspOnibus Mspx = new CMspOnibus(Atendente.Cidade, "0001");
            Mspx.RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro();
            Msp.Add(Mspx);
            //Exemplo de uso
            string aux = Msp[0].EncomendasQueVaoParaOCarro[0].Codigo;
        }

        private void TransmiteEncomenda(int Indice)
        {
            count++;
            this.Desabilitatimer2();
            byte FunctionID;
            byte EncomendaByteID0 = Convert.ToByte(Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].Codigo[0]);
            byte EncomendaByteID1 = Convert.ToByte(Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].Codigo[1]);
            byte EncomendaByteID2 = Convert.ToByte(Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].Codigo[2]);
            byte EncomendaByteID3 = Convert.ToByte(Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].Codigo[3]);
            byte EncomendaByteID4 = Convert.ToByte(Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].Codigo[4]);
            if (Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].DesceuDoCarro == true)
            {
                FunctionID = 0x30;
            }
            else if (Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].EstaNoCarro == true)
            {
                FunctionID = 0x11;
            }
            else
            {
                FunctionID = 0x10;
            }
            CCidade cid = new CCidade();
            byte OrigemMSB, OrigemLSB;
            int cod = cid.CodigoDaCidade(Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].CidadeDeOrigem);
            if (cod < 256)
            {
                OrigemMSB = 0x00;
                OrigemLSB = Convert.ToByte(cod);
            }
            else
            {
                OrigemMSB = Convert.ToByte(cod / 256);
                OrigemLSB = Convert.ToByte(cod % 256);
            }
            byte DestinoMSB, DestinoLSB;
            cod = cid.CodigoDaCidade(Msp[Indice].EncomendasQueVaoParaOCarro[Msp[Indice].PosicaoListaTransmissaoEncomenda].CidadeDeDestino);
            if (cod < 256)
            {
                DestinoMSB = 0x00;
                DestinoLSB = Convert.ToByte(cod);
            }
            else
            {
                DestinoMSB = Convert.ToByte(cod / 256);
                DestinoLSB = Convert.ToByte(cod % 256);
            }
            byte[] BufferDeTransmissao = { 0x24, 0x0F, MSB, LSB, Msp[Indice].OnibusHex[0], Msp[Indice].OnibusHex[1], FunctionID, EncomendaByteID0, EncomendaByteID1, EncomendaByteID2, EncomendaByteID3, EncomendaByteID4, OrigemMSB, OrigemLSB, DestinoMSB, DestinoLSB, 0x24 };
            PortaDeComunicacao.Write(BufferDeTransmissao, 0, BufferDeTransmissao.Length);
        }

        private void Desabilitatimer2()
        {
                this.timer2.Enabled = false;
        }
        private void Habilitatimer2()
        {
            this.timer2.Enabled = true;
        }

        protected void TimerAtualizaListaEncomendasCarros_Tick(object sender, System.EventArgs e)
        {
            int mspi_ini = 0;
            int mspi_fim = 0;
            
            
            CMspOnibus maux = new CMspOnibus();
            CMspOnibus mauxfinal = new CMspOnibus();
            

            for (int i = 0; i < Msp.Count; i++)
            {
               
                mspi_ini = Msp[i].EncomendasQueVaoParaOCarro.Count;
                Msp[i].RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro2();
                Msp[i].RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro3();
                mspi_fim = Msp[i].EncomendasQueVaoParaOCarro.Count;
                if (mspi_ini < mspi_fim)
                {
                    TransmiteEncomenda(i);
                }
            }
        }
        private CMspOnibus MetodoMentira(CMspOnibus Mspx, CMspOnibus maux)
        {
            ArrayList Int = new ArrayList();
            ArrayList IndRemoval = new ArrayList();
            
                Int.Clear();
                IndRemoval.Clear();
                maux.RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro();
                for (int j = 0; j < Mspx.EncomendasQueVaoParaOCarro.Count; j++)
                {
                    for (int k = 0; k < maux.EncomendasQueVaoParaOCarro.Count; k++)
                    {
                        if (Mspx.EncomendasQueVaoParaOCarro[j].Codigo == maux.EncomendasQueVaoParaOCarro[k].Codigo)
                        {
                            Int.Add(Mspx.EncomendasQueVaoParaOCarro[j].Codigo);
                        }
                    }
                }
                foreach (string integer in Int)
                {
                    for (int m = 0; m < Mspx.EncomendasQueVaoParaOCarro.Count; m++)
                    {
                        int aux = 0;
                        if (maux.EncomendasQueVaoParaOCarro[m].Codigo == integer)
                        {
                            foreach (CEncomenda cenc in maux.EncomendasQueVaoParaOCarro)
                            {
                                if (cenc.Codigo == integer)
                                {
                                    IndRemoval.Add(aux);
                                }
                                aux++;
                            }
                            break;
                        }
                    }
                }
                foreach (int nummer in IndRemoval)
                {
                    maux.EncomendasQueVaoParaOCarro.RemoveAt(nummer);
                }

                if (maux.EncomendasQueVaoParaOCarro.Count > 0)
                {
                    foreach (CEncomenda c in maux.EncomendasQueVaoParaOCarro)
                    {
                        Mspx.EncomendasQueVaoParaOCarro.Add(c);
                    }
                    TransmiteEncomenda(0);
                }
            return maux;
        }

        private void HabilitaTimerAtualizaListaEncomendasCarros()
        {
            this.TimerAtualizaListaEncomendasCarros.Enabled = true;
        }
        private void DesabilitaTimerAtualizaListaEncomendasCarros()
        {
            this.TimerAtualizaListaEncomendasCarros.Enabled = false;
        }

        private void AtualizarOnibusNaPlataforma()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.PanelCarros.CreateGraphics();
            int AlturaAtehAqui = 0;
            int DistanciaEntreFiguras = 30;
            int AlturaInicial = 40;

            PictureBoxCarro1.Visible = false;
            Label1Carro1.Visible = false;
            Label2Carro1.Visible = false;

            PictureBoxCarro2.Visible = false;
            Label1Carro2.Visible = false;
            Label2Carro2.Visible = false;

            PictureBoxCarro3.Visible = false;
            Label1Carro3.Visible = false;
            Label2Carro3.Visible = false;

            PictureBoxCarro4.Visible = false;
            Label1Carro4.Visible = false;
            Label2Carro4.Visible = false;

            int i = 0;
            foreach (CMspOnibus c in Msp)
            {
                switch (i)
                {
                    case 0:
                        //Carro 1
//                        this.PictureBoxCarro1.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.PictureBoxCarro1.Image = new Bitmap(Properties.Resources.ONIBUS2); 
                        this.PictureBoxCarro1.SizeMode = PictureBoxSizeMode.AutoSize;
                        this.Label1Carro1.Text = c.Onibus;
                        this.Label2Carro1.Text = c.CidadeDeOrigemDoCarro() + " -> " + c.CidadeDeDestinoDoCarro();
                        if ((this.PictureBoxCarro1.Width - this.Label2Carro1.Width) < 0)
                        {
                            this.PictureBoxCarro1.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.PictureBoxCarro1.Width) / 2, this.PanelCarros.Location.Y + this.ButtonCarros.Height + AlturaInicial);
                            this.Label2Carro1.Location = new Point(this.PictureBoxCarro1.Location.X - (Math.Abs(this.PictureBoxCarro1.Width - this.Label2Carro1.Width) / 2), this.PanelCarros.Location.Y + this.PictureBoxCarro1.Height + this.Label1Carro1.Height + this.ButtonCarros.Height + AlturaInicial);
                        }
                        else
                        {
                            this.Label2Carro1.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.Label2Carro1.Width) / 2, this.PanelCarros.Location.Y + this.PictureBoxCarro1.Height + this.Label1Carro1.Height + this.ButtonCarros.Height + AlturaInicial);
                            this.PictureBoxCarro1.Location = new Point(this.Label2Carro1.Location.X + (Math.Abs(this.PictureBoxCarro1.Width - this.Label2Carro1.Width) / 2), this.PanelCarros.Location.Y + this.ButtonCarros.Height + AlturaInicial);
                        }
                        Label1Carro1.Location = new Point(this.PictureBoxCarro1.Location.X + (this.PictureBoxCarro1.Width - this.Label1Carro1.Width) / 2, this.PanelCarros.Location.Y + this.PictureBoxCarro1.Height + this.ButtonCarros.Height + AlturaInicial);
                        this.PictureBoxCarro1.Visible = true;
                        this.Label1Carro1.Visible = true;
                        this.Label2Carro1.Visible = true;

                        AlturaAtehAqui = this.ButtonCarros.Location.Y + this.ButtonCarros.Height + this.PictureBoxCarro1.Height + this.Label1Carro1.Height + this.Label2Carro1.Height + DistanciaEntreFiguras + AlturaInicial;
                        i++;
                        break;
                    case 1:
                        //Carro 2
                        this.PictureBoxCarro2.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.PictureBoxCarro2.SizeMode = PictureBoxSizeMode.AutoSize;
                        this.Label1Carro2.Text = c.Onibus;
                        this.Label2Carro2.Text = c.CidadeDeOrigemDoCarro() + " -> " + c.CidadeDeDestinoDoCarro();
                        if ((this.PictureBoxCarro2.Width - this.Label2Carro2.Width) < 0)
                        {
                            this.PictureBoxCarro2.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.PictureBoxCarro2.Width) / 2, AlturaAtehAqui);
                            this.Label2Carro2.Location = new Point(this.PictureBoxCarro2.Location.X + (Math.Abs(this.PictureBoxCarro2.Width - this.Label2Carro2.Width) / 2), AlturaAtehAqui + this.PictureBoxCarro2.Height + this.Label1Carro2.Height);
                        }
                        else
                        {
                            this.Label2Carro2.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.Label2Carro2.Width) / 2, AlturaAtehAqui + this.PictureBoxCarro2.Height + this.Label1Carro2.Height);
                            this.PictureBoxCarro2.Location = new Point(this.Label2Carro2.Location.X - (Math.Abs(this.PictureBoxCarro2.Width - this.Label2Carro2.Width) / 2), AlturaAtehAqui);
                        }
                        Label1Carro2.Location = new Point(this.PictureBoxCarro2.Location.X + (this.PictureBoxCarro2.Width - this.Label1Carro2.Width) / 2, AlturaAtehAqui + this.PictureBoxCarro2.Height);
                        this.PictureBoxCarro2.Visible = true;
                        this.Label1Carro2.Visible = true;
                        this.Label2Carro2.Visible = true;

                        AlturaAtehAqui = this.Label2Carro2.Location.Y + this.Label2Carro2.Height + DistanciaEntreFiguras;
                        i++;
                        break;
                    case 2:
                        //Carro 3
                        this.PictureBoxCarro3.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.PictureBoxCarro3.SizeMode = PictureBoxSizeMode.AutoSize;
                        this.Label1Carro3.Text = c.Onibus;
                        this.Label2Carro3.Text = c.CidadeDeOrigemDoCarro() + " -> " + c.CidadeDeDestinoDoCarro();
                        if ((this.PictureBoxCarro3.Width - this.Label2Carro3.Width) < 0)
                        {
                            this.PictureBoxCarro3.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.PictureBoxCarro3.Width) / 2, AlturaAtehAqui);
                            this.Label2Carro3.Location = new Point(this.PictureBoxCarro3.Location.X + (Math.Abs(this.PictureBoxCarro3.Width - this.Label2Carro3.Width) / 2), AlturaAtehAqui + this.PictureBoxCarro3.Height + this.Label1Carro3.Height);
                        }
                        else
                        {
                            this.Label2Carro3.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.Label2Carro3.Width) / 2, AlturaAtehAqui + this.PictureBoxCarro3.Height + this.Label1Carro3.Height);
                            this.PictureBoxCarro3.Location = new Point(this.Label2Carro3.Location.X - (Math.Abs(this.PictureBoxCarro3.Width - this.Label2Carro3.Width) / 2), AlturaAtehAqui);
                        }
                        Label1Carro3.Location = new Point(this.PictureBoxCarro3.Location.X + (this.PictureBoxCarro3.Width - this.Label1Carro3.Width) / 2, AlturaAtehAqui + this.PictureBoxCarro3.Height);
                        this.PictureBoxCarro3.Visible = true;
                        this.Label1Carro3.Visible = true;
                        this.Label2Carro3.Visible = true;

                        AlturaAtehAqui = this.Label2Carro3.Location.Y + this.Label2Carro3.Height + DistanciaEntreFiguras;
                        i++;
                        break;
                    case 3:
                        //Carro 4

                        this.PictureBoxCarro4.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.PictureBoxCarro4.SizeMode = PictureBoxSizeMode.AutoSize;
                        this.Label1Carro4.Text = c.Onibus;
                        this.Label2Carro4.Text = c.CidadeDeOrigemDoCarro() + " -> " + c.CidadeDeDestinoDoCarro();
                        if ((this.PictureBoxCarro4.Width - this.Label2Carro4.Width) < 0)
                        {
                            this.PictureBoxCarro4.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.PictureBoxCarro4.Width) / 2, AlturaAtehAqui);
                            this.Label2Carro4.Location = new Point(this.PictureBoxCarro4.Location.X + (Math.Abs(this.PictureBoxCarro4.Width - this.Label2Carro4.Width) / 2), AlturaAtehAqui + this.PictureBoxCarro4.Height + this.Label1Carro4.Height);
                        }
                        else
                        {
                            this.Label2Carro4.Location = new Point(this.PanelCarros.Location.X + (this.PanelCarros.Width - this.Label2Carro4.Width) / 2, AlturaAtehAqui + this.PictureBoxCarro4.Height + this.Label1Carro4.Height);
                            this.PictureBoxCarro4.Location = new Point(this.Label2Carro4.Location.X - (Math.Abs(this.PictureBoxCarro4.Width - this.Label2Carro4.Width) / 2), AlturaAtehAqui);
                        }
                        Label1Carro4.Location = new Point(this.PictureBoxCarro4.Location.X + (this.PictureBoxCarro4.Width - this.Label1Carro4.Width) / 2, AlturaAtehAqui + this.PictureBoxCarro4.Height);
                        this.PictureBoxCarro4.Visible = true;
                        this.Label1Carro4.Visible = true;
                        this.Label2Carro4.Visible = true;
                        i++;
                        break;
                }
            }
            bool Label1bool = false;
            bool Label2bool = false;
            bool Label3bool = false;
            bool Label4bool = false;
            foreach (CMspOnibus m in Msp)
            {
                if (m.Onibus == Label1Carro1.Text)
                { Label1bool = true; }
                if (m.Onibus == Label1Carro2.Text)
                { Label2bool = true; }
                if (m.Onibus == Label1Carro3.Text)
                { Label3bool = true; }
                if (m.Onibus == Label1Carro4.Text)
                { Label4bool = true; }
            }
            if (Label1bool == false)
            {
                PictureBoxCarro1.Visible = false;
                Label1Carro1.Visible = false;
                Label2Carro1.Visible = false;
            }
            if (Label2bool == false)
            {
                PictureBoxCarro2.Visible = false;
                Label1Carro2.Visible = false;
                Label2Carro2.Visible = false;
            }
            if (Label3bool == false)
            {
                PictureBoxCarro3.Visible = false;
                Label1Carro3.Visible = false;
                Label2Carro3.Visible = false;
            }
            if (Label4bool == false)
            {
                PictureBoxCarro4.Visible = false;
                Label1Carro4.Visible = false;
                Label2Carro4.Visible = false;
            }
        }

        private void PictureBoxCarro1_Click(object sender, EventArgs e)
        {
            SIAERFormSobeDesceOnibus FormCarro1 = new SIAERFormSobeDesceOnibus(this.Label1Carro1.Text,Atendente.Cidade);
            FormCarro1.Show();
        }
        private void PictureBoxCarro2_Click(object sender, EventArgs e)
        {
            SIAERFormSobeDesceOnibus FormCarro2 = new SIAERFormSobeDesceOnibus(this.Label1Carro2.Text, Atendente.Cidade);
            FormCarro2.Show();
        }
        private void PictureBoxCarro3_Click(object sender, EventArgs e)
        {
            SIAERFormSobeDesceOnibus FormCarro3 = new SIAERFormSobeDesceOnibus(this.Label1Carro3.Text, Atendente.Cidade);
            FormCarro3.Show();
        }
        private void PictureBoxCarro4_Click(object sender, EventArgs e)
        {
            SIAERFormSobeDesceOnibus FormCarro4 = new SIAERFormSobeDesceOnibus(this.Label1Carro4.Text, Atendente.Cidade);
            FormCarro4.Show();
        }

        private void ButtonConectar_Click(object sender, EventArgs e)
        {
            //Testando se a porta serial está livre para comunicação
                if (PortaDeComunicacao.IsOpen == false)
                {
                    if (OpenPort())
                    {
                        CCidade cid = new CCidade();
                        int cod = cid.CodigoDaCidade(this.Atendente.Cidade.ToString());
                        if (cod < 256)
                        {
                            MSB = 0x00;
                            LSB = Convert.ToByte(cod);
                        }
                        else
                        {
                            MSB = Convert.ToByte(cod / 256);
                            LSB = Convert.ToByte(cod % 256);
                        }
                        byte[] newMsg = { 0x24, 0x08, 0x00, 0x00, 0x00, 0x00, 0x02, MSB, LSB, 0x24 };
                        //send the message to the port
                        PortaDeComunicacao.Write(newMsg, 0, newMsg.Length);
                    }
                }
                else
                {
                    PortaDeComunicacao.Close();
                    this.ButtonConectar.Text = "Conectar";
                    toolstriplabelconexaotext = "Desconectado ao dispostivo para comunicação com ônibus...";
                    ComboBoxPortas.Enabled = true;
                    ToolStripLabelConexao.Text = toolstriplabelconexaotext;
                    
                }
        }

        #region Carregar ComboBox com os valores padrões de Porta do PC
        public void CarregarComboBoxDePortas(object obj)
        {
            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        private void ButtonCarros_Click(object sender, EventArgs e)
        {

        }
    }
}
