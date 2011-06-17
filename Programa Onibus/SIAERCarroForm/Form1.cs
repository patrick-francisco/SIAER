using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TesteXMLV1;
using System.Collections;
using System.Threading;
using System.IO.Ports;

namespace SIAERCarroForm
{
    public partial class Form1 : Form
    {
        CXml XmlAtual = new CXml();
        List<CBufferDeEntrada> BufferDeChegada = new List<CBufferDeEntrada>();//Deve ser atualizada pelo MSP
        public delegate void DelegateThisClose();
        string CidadeAtual = "";
        //*****************************************************************
        //Variáveis para Comunicação com o MSP
        //*****************************************************************
        private SerialPort PortaDeComunicacao = new SerialPort();
        string transType = string.Empty;
        string BaudRateSerial;
        string ParitySerial;
        string DatabitSerial;
        string StopBitSerial;
        string PortNameSerial;

        public Form1()
        {
            InitializeComponent();
            this.PictureBoxSubir.Image = Properties.Resources.SetaDesabilitadoUP;
            this.PictureBoxDescer.Image = Properties.Resources.SetaDesabilitadoDOWN;
            this.ListBoxSubir.Visible = false;
            this.ListBoxDescer.Visible = false;
            RedimensionaComponentes();
            //Preenche a variável BufferDeChegada que contendo os dados vindos do MSP
            PreencherVariavelBuffer();
            //Preenche a ListBoxEncomendasNoCarro com as encomendas cadastradas no .xml da viagem
            PreencherListBoxEncoemendasNoCarro();
            //Preenche a ListBoxDescer com as encomendas que deverão descer na cidade escrita na texbox1
            PreencherListBoxDescer();
            //Preenche a ListBoxSubir com as encomendas que deverão subir no carro analisando a variável BufferDeChegada
            PreencherListBoxSubir();
            //this.textBox1.TextChanged +=new EventHandler(textBox1_TextChanged);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SelecionarParametosSerial();
            PortaDeComunicacao.DataReceived += new SerialDataReceivedEventHandler(DadosRecebidosNaPortaSerial);

            
        }
        private void RedimensionaComponentes()
        { 
//            this.SizeChanged += new EventHandler(FormSIAERCarro_MaximumSizeChanged);
            Inicializa_form();
        }
        private void Inicializa_form()
        {
            this.LabelCodOnibus.Visible = false;
        }
        private void FormSIAERCarro_MaximumSizeChanged(object sender, EventArgs e)
        {
            int PosicaoXGroupBoxSubir = 20;
            int PosicaoYGroupBox = 150;
            int OffsetGroupBoxX=60;
            int OffsetGroupBoxDescerWidth = 50;
            int OffsetGroupBoxEncomendasNoCarro = 10;
            //GroupBoxSubir
            this.GroupBoxSubir.Location = new Point(PosicaoXGroupBoxSubir, PosicaoYGroupBox);
            this.GroupBoxSubir.Width = (this.Width / 2) - OffsetGroupBoxX;
            this.GroupBoxSubir.Height = 2*(this.Height / 5);
            //GroupBoxDescer
            this.GroupBoxDescer.Location = new Point(PosicaoXGroupBoxSubir, PosicaoYGroupBox*2);
            this.GroupBoxDescer.Width = (this.Width / 2) - OffsetGroupBoxDescerWidth;
            this.GroupBoxDescer.Height = 2*(this.Height / 5);
            //PictureBoxSubir
            this.PictureBoxSubir.Width = this.GroupBoxSubir.Width - 50;
            this.PictureBoxSubir.Height = this.GroupBoxSubir.Height-40;
            this.PictureBoxSubir.Location = new Point((this.GroupBoxSubir.Width - this.PictureBoxSubir.Width) / 2, (this.GroupBoxSubir.Height - this.PictureBoxSubir.Height) / 2);
            //PictureBoxDescer
            this.PictureBoxDescer.Width = this.GroupBoxDescer.Width - 50;
            this.PictureBoxDescer.Height = this.GroupBoxDescer.Height - 40;
            this.PictureBoxDescer.Location = new Point((this.GroupBoxDescer.Width - this.PictureBoxDescer.Width) / 2, (this.GroupBoxDescer.Height - this.PictureBoxDescer.Height) / 2);
            //ListBoxSubir
            this.ListBoxSubir.Width = this.PictureBoxSubir.Width/2;
            this.ListBoxSubir.Height = this.PictureBoxSubir.Height - 60;
            this.ListBoxSubir.Location = new Point(((this.PictureBoxSubir.Width - this.ListBoxSubir.Width) / 2)+22, (this.PictureBoxSubir.Height - this.ListBoxSubir.Height) / 2 + PictureBoxSubir.Location.Y+30);
            //ListBoxDescer
            this.ListBoxDescer.Width = this.PictureBoxDescer.Width/2;
            this.ListBoxDescer.Height = this.PictureBoxDescer.Height-60;
            this.ListBoxDescer.Location = new Point((this.PictureBoxDescer.Width - this.ListBoxDescer.Width) / 2+27, (this.PictureBoxDescer.Height - this.ListBoxDescer.Height) / 2 + PictureBoxDescer.Location.Y-10);
            //GroupBoxEncomendasNoCarro
            this.GroupBoxEncomendasNoCarro.Location = new Point(this.GroupBoxSubir.Location.X,this.GroupBoxSubir.Location.Y + this.GroupBoxSubir.Height + OffsetGroupBoxEncomendasNoCarro);
            this.GroupBoxEncomendasNoCarro.Width = this.GroupBoxDescer.Location.X + this.GroupBoxDescer.Width - PosicaoXGroupBoxSubir;
            this.GroupBoxEncomendasNoCarro.Height = this.Height - this.GroupBoxEncomendasNoCarro.Location.Y - 30;
            this.ButtonFechar.Location = new Point(this.Width / 2, this.Height / 2+20);
            //ListBoxEncomendasNoCarro
            this.ListBoxEncomendasNoCarro.Location = new Point(20, 30);
            this.ListBoxEncomendasNoCarro.Width = this.GroupBoxEncomendasNoCarro.Width - 40;
            this.ListBoxEncomendasNoCarro.Height = this.GroupBoxEncomendasNoCarro.Height - 40;
            //LabelSubir
            this.LabelSubir.Location = new Point(this.GroupBoxSubir.Location.X + (this.GroupBoxSubir.Width - this.LabelSubir.Width) / 2, this.GroupBoxSubir.Location.Y - 20);
            //LabelDescer
            this.LabelDescer.Location = new Point(this.GroupBoxDescer.Location.X + (this.GroupBoxDescer.Width - this.LabelDescer.Width) / 2, this.GroupBoxDescer.Location.Y - 20);
            //LabelStatus
            //this.LabelStatus.Text = this.textBox1.Text;
            this.LabelStatus.Location = new Point((this.Width - this.LabelStatus.Width)/2, 20);
            //ButtonFechar
            this.ButtonFechar.Location = new Point(this.Width - this.ButtonFechar.Width-5, 0);
            //TextBox ID Carro
            this.TextBoxIDCarro.Location = new Point(this.GroupBoxSubir.Location.X, this.GroupBoxSubir.Location.Y - 20);
            //ButtonInciar
            this.ButtonIniciar.Location = new Point(this.TextBoxIDCarro.Location.X + this.TextBoxIDCarro.Width + 5, this.TextBoxIDCarro.Location.Y);
            //Label Cod Onibus
            this.LabelCodOnibus.Text = "";
            this.LabelCodOnibus.Visible = false;
            this.LabelCodOnibus.Location = new Point(this.TextBoxIDCarro.Location.X, this.LabelStatus.Location.Y);
        }
        private void PreencherListBoxEncoemendasNoCarro()
        {
            //XmlAtual.CaminhoXml = "C:\\" + XmlAtual.RetornaNomeUltimoArquivo() + ".xml";
            XmlAtual.CaminhoXml = "C:\\CarroDataBase.xml";
            ArrayList ArrayEncomendas = XmlAtual.EncomendasDoCarro();
            for (int Item = 0; Item < ArrayEncomendas.Count; Item++)
            {
                this.ListBoxEncomendasNoCarro.Items.Add(ArrayEncomendas[Item]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PreencherListBoxDescer()
        {
            this.ListBoxDescer.Items.Clear();
            ArrayList ArrayEncomendas = XmlAtual.DesceEncomendas(CidadeAtual);
            for (int Item = 0; Item < ArrayEncomendas.Count; Item++)
            {
                this.ListBoxDescer.Items.Add(ArrayEncomendas[Item]);
            }
        }
        private void PreencherListBoxSubir()
        {
            this.ListBoxSubir.Items.Clear();
            ArrayList ArrayEncomendas = XmlAtual.SobeEncomendas(BufferDeChegada);
            for (int Item = 0; Item < ArrayEncomendas.Count; Item++)
            {
                this.ListBoxSubir.Items.Add(ArrayEncomendas[Item]);
            }
        }
        private void PreencherVariavelBuffer()
        {
            /*CCodigoDeBarras cod = new CCodigoDeBarras();
            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor("00001"), "Curitiba", "Maringá", false));
            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor("00002"), "Curitiba", "Maringá", false));
            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor("00003"), "Curitiba", "Maringá", false));
            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor("00004"), "Curitiba", "Maringá", false));
            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor("00005"), "Curitiba", "Maringá", true));
            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor("00006"), "Curitiba", "Maringá", false));
            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor("00007"), "Curitiba", "Maringá", false));*/
        }
        private void Alteracidade()
        {
            if(this.CidadeAtual == "" )
            {
                if (ListBoxSubir.Items.Count > 0 || ListBoxDescer.Items.Count > 0)
                {
                    ArrayList list1 = new ArrayList();
                    ArrayList list2 = new ArrayList();
                    for(int i = 0; i< ListBoxSubir.Items.Count;i++)
                    {
                        list1.Add(ListBoxSubir.Items[i]);
                    }
                    for (int i = 0; i < ListBoxDescer.Items.Count; i++)
                    {
                        list2.Add(ListBoxDescer.Items[i]);
                    }
                    MissingPack Form = new MissingPack(list1, list2);
                    Form.Show();
                }
                    this.LabelStatus.Text = "Viajando...";
                    //this.PictureBoxSubir.Image = Properties.Resources.SetaDesabilitadoUP;
                    //this.PictureBoxDescer.Image = Properties.Resources.SetaDesabilitadoDOWN;
                    this.PictureBoxSubir.Visible = false;
                    this.PictureBoxDescer.Visible = false;
                    this.Mapa.Visible = true;
                    this.GroupBoxDescer.Visible = false;
                    this.GroupBoxSubir.Visible = false;
                    this.GroupBoxEncomendasNoCarro.Visible = false;
                    this.ListBoxDescer.Visible = false;
                    this.ListBoxSubir.Items.Clear();
                    this.BufferDeChegada.Clear();
            }
            else
            {
                this.Mapa.Visible = false;
                this.GroupBoxDescer.Visible = true;
                this.GroupBoxSubir.Visible = true;
                this.GroupBoxEncomendasNoCarro.Visible = true;
                this.pictureBox1.Visible = true;
                this.PictureBoxDescer.Visible = true;
                this.PictureBoxSubir.Visible = true;
                this.ListBoxEncomendasNoCarro.Visible = true;

                this.LabelStatus.Text = this.CidadeAtual;
                this.PictureBoxSubir.Image = Properties.Resources.SetaSubida;
                this.PictureBoxDescer.Image = Properties.Resources.SetaDescida;
                this.ListBoxSubir.Visible = true;
                this.ListBoxDescer.Visible = true;
                //Preencher ListBox de Descida
                this.ListBoxDescer.Items.Clear();
                ArrayList ArrayEncomendasDescer = XmlAtual.DesceEncomendas(CidadeAtual);
                for (int Item = 0; Item < ArrayEncomendasDescer.Count; Item++)
                {
                    this.ListBoxDescer.Items.Add(ArrayEncomendasDescer[Item]);
                }
                //Preenche ListBox de Subida
                this.ListBoxSubir.Items.Clear();
                ArrayList ArrayEncomendasSubir = XmlAtual.SobeEncomendas(BufferDeChegada);
                for (int Item = 0; Item < ArrayEncomendasSubir.Count; Item++)
                {
                    this.ListBoxSubir.Items.Add(ArrayEncomendasSubir[Item]);
                }
            }
        }
        #region Selecionar as opções padrões previstas para o Leitor de Código de Barras
        private void SelecionarParametosSerial()
        {
            ParitySerial = "None";
            StopBitSerial = "1";
            DatabitSerial = "8";
            BaudRateSerial = "9600";
            PortNameSerial = "COM6";
        }
        #endregion
        public bool OpenPort()
        {
            try
            {
                //Testando se a porta serial está livre para comunicação
                if (PortaDeComunicacao.IsOpen == true) PortaDeComunicacao.Close();

                //Inicializa o Objeto de comunicação Serial
                PortaDeComunicacao.BaudRate = int.Parse(BaudRateSerial);    //BaudRate
                PortaDeComunicacao.DataBits = int.Parse(DatabitSerial);    //DataBits
                PortaDeComunicacao.StopBits = (StopBits)Enum.Parse(typeof(StopBits), StopBitSerial);    //StopBits
                PortaDeComunicacao.Parity = (Parity)Enum.Parse(typeof(Parity), ParitySerial);    //Parity
                PortaDeComunicacao.PortName = PortNameSerial;   //PortName
                //now open the port
                PortaDeComunicacao.Open();
                PortaDeComunicacao.DiscardInBuffer();//Limpa o buffer de entrada da serial antes de usá-la
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar-se com o leitor de código de barras.\nDescrição do erro:\n  " + ex.Message.ToString(), "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
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
        public void AtualizaScreen()
        {
            //Atualizando ListBox´s Subida e Descida
            //XmlAtual.AtualizaXML(BufferDeChegada, this.CidadeAtual);

            //Preencher ListBox de Descida
            this.ListBoxDescer.Items.Clear();
            ArrayList ArrayEncomendasDescer = XmlAtual.DesceEncomendas(CidadeAtual);
            for (int Item = 0; Item < ArrayEncomendasDescer.Count; Item++)
            {
                this.ListBoxDescer.Items.Add(ArrayEncomendasDescer[Item]);
            }
            //Preenche ListBox de Subida
            this.ListBoxSubir.Items.Clear();
            ArrayList ArrayEncomendasSubir = XmlAtual.SobeEncomendas(BufferDeChegada);
            for (int Item = 0; Item < ArrayEncomendasSubir.Count; Item++)
            {
                this.ListBoxSubir.Items.Add(ArrayEncomendasSubir[Item]);
            }
            this.ListBoxEncomendasNoCarro.Items.Clear();
            PreencherListBoxEncoemendasNoCarro();
        }
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
            }while(Cifrao<2);
            PortaDeComunicacao.DiscardInBuffer();//Limpa o buffer de entrada da serial antes de usá-la
            if(msg[1] == 0x0C)//0x0C byte indicando chegada em cidade
            {
                int codcid = Convert.ToInt32((char)msg[2])*256 + Convert.ToInt32((char)msg[3]);
                string NomeCidade = XmlAtual.RetornaNomeDeCidade(codcid.ToString());
                CidadeAtual = NomeCidade;
                BeginInvoke(new DelegateThisClose(this.Alteracidade));
            }
            if (msg[1] == 0x0A)//0x0C byte indicando chegada de encomenda
            {
                CCodigoDeBarras cod = new CCodigoDeBarras();
                string CodigoEncomenda = msg.Substring(5, 5);

                int CodigoCidadeOrigem = Convert.ToInt32((char)msg[10]) * 256 + Convert.ToInt32((char)msg[11]);
                string NomeCidadeOrigem = XmlAtual.RetornaNomeDeCidade(CodigoCidadeOrigem.ToString());

                int CodigoCidadeDestino = Convert.ToInt32((char)msg[12]) * 256 + Convert.ToInt32((char)msg[13]);
                string NomeCidadeDestino = XmlAtual.RetornaNomeDeCidade(CodigoCidadeDestino.ToString());
                bool EstaNoCarro = false;

                if (msg[4] == 0x30)//Remover encomenda do XML
                {
                    ArrayList x = new ArrayList();
                    ArrayList y = new ArrayList();
                    y = XmlAtual.EncomendasDoCarro();
                    foreach (string s in y)
                    {
                        if (s == cod.InserirChecksumNoValor(CodigoEncomenda))
                        {
                            x.Add(s);
                            XmlAtual.RemoverDoXML(x);
                            break;
                        }
                    }
                }
                else if ((msg[4] & 0xF0) == 0x10)//
                {
                    int EstaNoXml = 0;
                    int EstaNoBufferDeChegada = 0;
                    ArrayList EncomendasNoXml = new ArrayList();
                    EncomendasNoXml = XmlAtual.EncomendasDoCarro();
                    for (int Item = 0; Item < EncomendasNoXml.Count; Item++)
                    {
                        string x = cod.InserirChecksumNoValor(CodigoEncomenda);
                        if (EncomendasNoXml[Item].ToString() == x)
                        {
                            EstaNoXml = 1;
                        }
                    }
                    if (EstaNoXml == 0)
                    {
                        int Item = 0;
                        for (Item = 0; Item < BufferDeChegada.Count; Item++)
                        {
                            string x = cod.InserirChecksumNoValor(CodigoEncomenda);
                            if (BufferDeChegada[Item].Codigo.ToString() == x)
                            {
                                BufferDeChegada[Item].Origem = NomeCidadeOrigem;
                                BufferDeChegada[Item].Destino = NomeCidadeDestino;
                                EstaNoBufferDeChegada = 1;
                                break;
                            }
                        }
                        if (EstaNoBufferDeChegada == 0)
                        {
                            EstaNoCarro = Convert.ToBoolean(msg[4] & 0x01);
                            BufferDeChegada.Add(new CBufferDeEntrada(cod.InserirChecksumNoValor(CodigoEncomenda), NomeCidadeOrigem, NomeCidadeDestino, EstaNoCarro));
                        }
                        else if (msg[4]==0x11)
                        {
                            BufferDeChegada[Item].EstaNoCarro = true;
                        }
                        if (msg[4] == 0x11)
                        {
                            XmlAtual.AtualizaXML(BufferDeChegada, this.CidadeAtual);
                        }
                    }
                }
                BeginInvoke(new DelegateThisClose(this.AtualizaScreen));
            }
            if (msg[1] == 0x0D)//0x0C byte indicando chegada em cidade
            {
                this.CidadeAtual = "";
                BeginInvoke(new DelegateThisClose(this.Alteracidade));
            }
        }

        private void ButtonIniciar_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt16(this.TextBoxIDCarro.Text);
            byte MSB, LSB;
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
            //byte[] newMsg = { 0x24, 0x10, 0x00, 0x00, 0x00, 0x00, 0x01, 0x20, 0x21, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x24 };
            byte[] newMsg = { 0x24, 0x10, 0x00, 0x00, 0x00, 0x00, 0x01, MSB, LSB, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x24 };
            //send the message to the port
            if(this.OpenPort())
            PortaDeComunicacao.Write(newMsg, 0, newMsg.Length);

            this.LabelStatus.Visible = true;
            this.TextBoxIDCarro.Visible = false;
            this.ButtonIniciar.Visible = false;
            //lABEL
            this.LabelCodOnibus.Visible = true;
            this.LabelCodOnibus.Text = this.TextBoxIDCarro.Text;
        }

        private void GroupBoxEncomendasNoCarro_Enter(object sender, EventArgs e)
        {

        }

        private void LabelSubir_Click(object sender, EventArgs e)
        {

        }
    }
}
