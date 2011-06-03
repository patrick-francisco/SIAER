using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SIAERClassLibrary;
using System.Collections;

namespace SIAERAplicacao
{
    public partial class SIAERLocalizaencomenda : Form
    {
        //Variável com o ID digitado pelo usuário
        string CodigoDeBarrasALocalizar;

        int AlturaPadrao = 60;
        int PosicaoXInicio = 15;
        int LarguraDesenhoGuiche;
        int LarguraDesenhoCliente;
        int AlturaDesenhoGuiche;
        int LarguraDesenhoOnibus;
        int AlturaDesenhoOnibus;
        int OffsetOnibus;
        int LarguraDesenhoLinha;
        int AlturaDesenhoLinha;
        int OffsetLinha;

        //Adquire a lista de guiches
        ArrayList ArrayDeGuiches = new ArrayList();
        //Adquire a lista de Onibus
        ArrayList ArrayDeCarros = new ArrayList();
        //Adquire a lista de Status Guiche
        ArrayList ArrayDeStatusGuiches = new ArrayList();
        //Adquire a lista de Status Onibus
        ArrayList ArrayDeStatusCarros = new ArrayList();
        //Adquire a lista de Status Cliente
        ArrayList ArrayDeStatusCliente = new ArrayList();
        //Adquire a lista de Atendentes
        ArrayList ArrayDeStatusAtendentesGuiche = new ArrayList();
        ArrayList ArrayDeStatusAtendentesOnibus = new ArrayList();

        public SIAERLocalizaencomenda(string cod)
        {
            InitializeComponent();
            L1.Text = "";
            L2.Text = "";
            L3.Text = "";
            L4.Text = "";
            L5.Text = "";
            L6.Text = "";
            L7.Text = "";
            LabelAt1.Text = "";
            LabelAt2.Text = "";
            LabelAt3.Text = "";
            LabelAt4.Text = "";
            LabelAt5.Text = "";
            LabelAt6.Text = "";
            LabelAt7.Text = "";
            LabelCliente.Text = "Cliente";
            LabelCliente.Font = new Font(L6.Font.Name,15.0F,FontStyle.Bold,L6.Font.Unit);
            this.CodigoDeBarrasALocalizar = cod;
            AdquirirInformaçõesDeTrajeto();
            InicializarFigurasELabels();
            this.PanelDensenho.Paint += new PaintEventHandler(DesenharElipse);
            this.button1.Location = new Point((this.GroupBoxDesenho.Width-this.button1.Width)/2+10,this.GroupBoxDesenho.Location.Y + this.GroupBoxDesenho.Height+3);
            //this.Text = "Visualização da Encomenda " + CodigoDeBarrasALocalizar;
            this.LabelText.Text +=" "+CodigoDeBarrasALocalizar;
            this.LabelText.Location = new Point((this.GroupBoxDesenho.Width - this.LabelText.Width) / 2 + 10, this.GroupBoxDesenho.Location.Y - 9);
            this.Height = this.LabelText.Height + this.GroupBoxDesenho.Height + this.button1.Height + 10;
        }
        private void DesenharElipse(object sender, PaintEventArgs e)
        {
            if (ArrayDeGuiches.Count == 2)
            {
                //Guiche 1
                if (Convert.ToInt32(ArrayDeStatusGuiches[0]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L1.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L1.Location.X - 2, L1.Location.Y - 2, L1.Width + 5, L1.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox1.Location.X - 4, L1.Location.Y - 2, this.pictureBox1.Width + 8, L1.Height + AlturaDesenhoGuiche + 13));
                }
                //Guiche 2
                if (Convert.ToInt32(ArrayDeStatusGuiches[1]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L3.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L3.Location.X - 2, L3.Location.Y - 2, L3.Width + 5, L3.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox5.Location.X - 4, L3.Location.Y - 2, this.pictureBox5.Width + 8, L3.Height + AlturaDesenhoGuiche + 13));
                }
            }
            if (ArrayDeGuiches.Count == 3)
            {
                //Guiche 1
                if (Convert.ToInt32(ArrayDeStatusGuiches[0]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L1.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L1.Location.X - 2, L1.Location.Y - 2, L1.Width + 5, L1.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox1.Location.X - 4, L1.Location.Y - 2, this.pictureBox1.Width + 8, L1.Height + AlturaDesenhoGuiche + 13));
                }
                //Guiche 2
                if (Convert.ToInt32(ArrayDeStatusGuiches[1]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L3.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L3.Location.X - 2, L3.Location.Y - 2, L3.Width + 5, L3.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox5.Location.X - 4, L3.Location.Y - 2, this.pictureBox5.Width + 8, L3.Height + AlturaDesenhoGuiche + 13));
                }
                //Guiche 3
                if (Convert.ToInt32(ArrayDeStatusGuiches[2]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L5.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L5.Location.X - 2, L5.Location.Y - 2, L5.Width + 5, L5.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox9.Location.X - 4, L5.Location.Y - 2, this.pictureBox9.Width + 8, L5.Height + AlturaDesenhoGuiche + 13));
                }
            }

            if (ArrayDeGuiches.Count == 4)
            {
                //Guiche 1
                if (Convert.ToInt32(ArrayDeStatusGuiches[0]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L1.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L1.Location.X - 2, L1.Location.Y - 2, L1.Width + 5, L1.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox1.Location.X - 4, L1.Location.Y - 2, this.pictureBox1.Width + 8, L1.Height + AlturaDesenhoGuiche + 13));
                }
                //Guiche 2
                if (Convert.ToInt32(ArrayDeStatusGuiches[1]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L3.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L3.Location.X - 2, L3.Location.Y - 2, L3.Width + 5, L3.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox5.Location.X - 4, L3.Location.Y - 2, this.pictureBox5.Width + 8, L3.Height + AlturaDesenhoGuiche + 13));
                }
                //Guiche 3
                if (Convert.ToInt32(ArrayDeStatusGuiches[2]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L5.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L5.Location.X - 2, L5.Location.Y - 2, L5.Width + 5, L5.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox9.Location.X - 4, L5.Location.Y - 2, this.pictureBox9.Width + 8, L5.Height + AlturaDesenhoGuiche + 13));
                }
                //Guiche 4
                if (Convert.ToInt32(ArrayDeStatusGuiches[3]) == 1)
                {
                    int LarguraQuadradoGuiche = LarguraDesenhoGuiche + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L7.Width > LarguraDesenhoGuiche)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L7.Location.X - 2, L7.Location.Y - 2, L7.Width + 5, L7.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox13.Location.X - 4, L7.Location.Y - 2, this.pictureBox13.Width + 8, L7.Height + AlturaDesenhoGuiche + 13));
                }
            }
            if (ArrayDeCarros.Count == 2)
            {
                //Onibus 1
                if (Convert.ToInt32(ArrayDeStatusCarros[0]) == 1)
                {
                    int LarguraQuadradoOnibus = LarguraDesenhoOnibus + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L2.Width > LarguraDesenhoOnibus)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L2.Location.X - 2, this.pictureBox3.Location.Y - 4, L2.Width + 5, L2.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox3.Location.X - 4, this.pictureBox3.Location.Y - 4, this.pictureBox3.Width + 8, L2.Height + AlturaDesenhoOnibus + 5));
                }
            }
            if (ArrayDeCarros.Count == 3)
            {
                //Onibus 1
                if (Convert.ToInt32(ArrayDeStatusCarros[0]) == 1)
                {
                    int LarguraQuadradoOnibus = LarguraDesenhoOnibus + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L2.Width > LarguraDesenhoOnibus)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L2.Location.X - 2, this.pictureBox3.Location.Y - 4, L2.Width + 5, L2.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox3.Location.X - 4, this.pictureBox3.Location.Y - 4, this.pictureBox3.Width + 8, L2.Height + AlturaDesenhoOnibus + 5));
                }
                //Onibus 2
                if (Convert.ToInt32(ArrayDeStatusCarros[1]) == 1)
                {
                    int LarguraQuadradoOnibus = LarguraDesenhoOnibus + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L4.Width > LarguraDesenhoOnibus)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L4.Location.X - 2, this.pictureBox7.Location.Y - 4, L4.Width + 5, L4.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox7.Location.X - 4, this.pictureBox7.Location.Y - 4, this.pictureBox7.Width + 8, L4.Height + AlturaDesenhoOnibus + 5));
                }
            }
            if (ArrayDeCarros.Count == 4)
            { 
                //Onibus 1
                if (Convert.ToInt32(ArrayDeStatusCarros[0]) == 1)
                {
                    int LarguraQuadradoOnibus = LarguraDesenhoOnibus + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L2.Width > LarguraDesenhoOnibus)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L2.Location.X - 2, this.pictureBox3.Location.Y-4, L2.Width + 5, L2.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox3.Location.X - 4, this.pictureBox3.Location.Y-4, this.pictureBox3.Width + 8, L2.Height + AlturaDesenhoOnibus + 5));
                }
                //Onibus 2
                if (Convert.ToInt32(ArrayDeStatusCarros[1]) == 1)
                {
                    int LarguraQuadradoOnibus = LarguraDesenhoOnibus + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L4.Width > LarguraDesenhoOnibus)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L4.Location.X - 2, this.pictureBox7.Location.Y - 4, L4.Width + 5, L4.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox7.Location.X - 4, this.pictureBox7.Location.Y - 4, this.pictureBox7.Width + 8, L4.Height + AlturaDesenhoOnibus + 5));
                }
                //Onibus 3
                if (Convert.ToInt32(ArrayDeStatusCarros[2]) == 1)
                {
                    int LarguraQuadradoOnibus = LarguraDesenhoOnibus + 5;
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = this.PanelDensenho.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                    if (L6.Width > LarguraDesenhoOnibus)
                        graphicsObj.DrawRectangle(myPen, new Rectangle(L6.Location.X - 2, this.pictureBox11.Location.Y - 4, L6.Width + 5, L6.Height + AlturaDesenhoGuiche + 13));
                    else
                        graphicsObj.DrawRectangle(myPen, new Rectangle(this.pictureBox11.Location.X - 4, this.pictureBox11.Location.Y - 4, this.pictureBox11.Width + 8, L6.Height + AlturaDesenhoOnibus + 5));
                }
            }
            if (Convert.ToInt32(ArrayDeStatusCliente[ArrayDeStatusCliente.Count-1]) == 1)
            {
                 int LarguraQuadradoCliente = LabelCliente.Width + 5;
                 System.Drawing.Graphics graphicsObj;
                 graphicsObj = this.PanelDensenho.CreateGraphics();
                 Pen myPen = new Pen(System.Drawing.Color.Red, 3);
                 graphicsObj.DrawRectangle(myPen, new Rectangle(LabelCliente.Location.X-2, LabelCliente.Location.Y-2, LabelCliente.Width+3, LabelCliente.Height+3));
            }
        }
        public void InicializarFigurasELabels()
        {
            int BordaForm=60;
            int BordaPanel=60;
            int BordaGroupBox=90;
            this.GroupBoxDesenho.Location = new Point(10, this.GroupBoxDesenho.Location.Y);
            this.PanelDensenho.Location = new Point(15, this.PanelDensenho.Location.Y);
            Bitmap temp = new Bitmap(1, 1);
            this.pictureBox1.Image = (Image)temp;
            this.pictureBox1.Location = new Point((this.Width / 2) - this.pictureBox1.Width / 2, 10);
            this.pictureBox1.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
            LarguraDesenhoGuiche = this.pictureBox1.Image.Width;
            AlturaDesenhoGuiche = this.pictureBox1.Image.Height;
            this.pictureBox1.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
            LarguraDesenhoOnibus = this.pictureBox1.Image.Width;
            AlturaDesenhoOnibus = this.pictureBox1.Image.Height;
            this.pictureBox1.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
            LarguraDesenhoLinha = this.pictureBox1.Image.Width;
            LarguraDesenhoCliente = this.LabelCliente.Width;
            AlturaDesenhoLinha = this.pictureBox1.Image.Height;
            OffsetLinha = AlturaDesenhoGuiche / 2;
            OffsetOnibus = Math.Abs((AlturaDesenhoGuiche - AlturaDesenhoOnibus) / 2);
            int PosicaoYLinha = AlturaPadrao + OffsetLinha;
            int PosicaoYOnibus;
            if(AlturaDesenhoGuiche<AlturaDesenhoOnibus)
                PosicaoYOnibus = AlturaPadrao - OffsetOnibus;
            else
                PosicaoYOnibus = AlturaPadrao + OffsetOnibus;
            int PosicaoYCliente = PosicaoYLinha - (this.LabelCliente.Height/2);
            int SomaDoBloco = LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus;
            switch (ArrayDeGuiches.Count)
            {
                case 2:
                    {
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox1.Image = (Image)temp;
                        this.pictureBox1.Location = new Point((this.Width / 2) - this.pictureBox1.Width / 2, 10);
                        this.pictureBox1.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox1.Width = this.pictureBox1.Image.Width;
                        this.pictureBox1.Height = this.pictureBox1.Image.Height;
                        this.pictureBox1.Location = new Point(PosicaoXInicio, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox2.Image = (Image)temp;
                        this.pictureBox2.Location = new Point((this.Width / 2) - this.pictureBox2.Width / 2, 10);
                        this.pictureBox2.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox2.Width = this.pictureBox2.Image.Width;
                        this.pictureBox2.Height = this.pictureBox2.Image.Height;
                        this.pictureBox2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche, PosicaoYLinha);
                        //Onibus
                        this.pictureBox3.Image = (Image)temp;
                        this.pictureBox3.Location = new Point((this.Width / 2) - this.pictureBox3.Width / 2, 10);
                        this.pictureBox3.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox3.Width = this.pictureBox3.Image.Width;
                        this.pictureBox3.Height = this.pictureBox3.Image.Height;
                        this.pictureBox3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox4.Image = (Image)temp;
                        this.pictureBox4.Location = new Point((this.Width / 2) - this.pictureBox4.Width / 2, 10);
                        this.pictureBox4.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox4.Width = this.pictureBox4.Image.Width;
                        this.pictureBox4.Height = this.pictureBox4.Image.Height;
                        this.pictureBox4.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox5.Image = (Image)temp;
                        this.pictureBox5.Location = new Point((this.Width / 2) - this.pictureBox5.Width / 2, 10);
                        this.pictureBox5.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox5.Width = this.pictureBox5.Image.Width;
                        this.pictureBox5.Height = this.pictureBox5.Image.Height;
                        this.pictureBox5.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus + LarguraDesenhoLinha, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox6.Image = (Image)temp;
                        this.pictureBox6.Location = new Point((this.Width / 2) - this.pictureBox6.Width / 2, 10);
                        this.pictureBox6.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox6.Width = this.pictureBox6.Image.Width;
                        this.pictureBox6.Height = this.pictureBox6.Image.Height;
                        this.pictureBox6.Location = new Point(PosicaoXInicio + 2*LarguraDesenhoGuiche + 2*LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Cliente
                        this.LabelCliente.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYCliente);
                        //Largura form principal
                        BordaForm = 117;
                        this.Width = 2*LarguraDesenhoGuiche+2*LarguraDesenhoLinha+LarguraDesenhoOnibus+LabelCliente.Width+BordaForm;
                        this.PanelDensenho.Width = 2 * LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus+LabelCliente.Width + BordaPanel;
                        this.GroupBoxDesenho.Width = 2 * LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus+LabelCliente.Width + BordaGroupBox;
                        //this.pictureBox6.Visible = false;
                        this.pictureBox7.Visible = false;
                        this.pictureBox8.Visible = false;
                        this.pictureBox9.Visible = false;
                        this.pictureBox10.Visible = false;
                        this.pictureBox11.Visible = false;
                        this.pictureBox12.Visible = false;
                        this.pictureBox13.Visible = false;
                        this.pictureBox14.Visible = false;
                        this.pictureBox15.Visible = false;
                        this.pictureBox16.Visible = false;
                        this.pictureBox17.Visible = false;
                        this.pictureBox18.Visible = false;
                        break;
                    }
                case 3:
                    {
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox1.Image = (Image)temp;
                        this.pictureBox1.Location = new Point((this.Width / 2) - this.pictureBox1.Width / 2, 10);
                        this.pictureBox1.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox1.Width = this.pictureBox1.Image.Width;
                        this.pictureBox1.Height = this.pictureBox1.Image.Height;
                        this.pictureBox1.Location = new Point(PosicaoXInicio, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox2.Image = (Image)temp;
                        this.pictureBox2.Location = new Point((this.Width / 2) - this.pictureBox2.Width / 2, 10);
                        this.pictureBox2.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox2.Width = this.pictureBox2.Image.Width;
                        this.pictureBox2.Height = this.pictureBox2.Image.Height;
                        this.pictureBox2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche, PosicaoYLinha);
                        //Onibus
                        this.pictureBox3.Image = (Image)temp;
                        this.pictureBox3.Location = new Point((this.Width / 2) - this.pictureBox3.Width / 2, 10);
                        this.pictureBox3.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox3.Width = this.pictureBox3.Image.Width;
                        this.pictureBox3.Height = this.pictureBox3.Image.Height;
                        this.pictureBox3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox4.Image = (Image)temp;
                        this.pictureBox4.Location = new Point((this.Width / 2) - this.pictureBox4.Width / 2, 10);
                        this.pictureBox4.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox4.Width = this.pictureBox4.Image.Width;
                        this.pictureBox4.Height = this.pictureBox4.Image.Height;
                        this.pictureBox4.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox5.Image = (Image)temp;
                        this.pictureBox5.Location = new Point((this.Width / 2) - this.pictureBox5.Width / 2, 10);
                        this.pictureBox5.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox5.Width = this.pictureBox5.Image.Width;
                        this.pictureBox5.Height = this.pictureBox5.Image.Height;
                        this.pictureBox5.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus + LarguraDesenhoLinha, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox6.Image = (Image)temp;
                        this.pictureBox6.Location = new Point((this.Width / 2) - this.pictureBox6.Width / 2, 10);
                        this.pictureBox6.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox6.Width = this.pictureBox6.Image.Width;
                        this.pictureBox6.Height = this.pictureBox6.Image.Height;
                        this.pictureBox6.Location = new Point(PosicaoXInicio + 2*LarguraDesenhoGuiche + 2*LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Onibus
                        this.pictureBox7.Image = (Image)temp;
                        this.pictureBox7.Location = new Point((this.Width / 2) - this.pictureBox7.Width / 2, 10);
                        this.pictureBox7.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox7.Width = this.pictureBox7.Image.Width;
                        this.pictureBox7.Height = this.pictureBox7.Image.Height;
                        this.pictureBox7.Location = new Point(PosicaoXInicio + 2*LarguraDesenhoGuiche + 3*LarguraDesenhoLinha+LarguraDesenhoOnibus, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox8.Image = (Image)temp;
                        this.pictureBox8.Location = new Point((this.Width / 2) - this.pictureBox8.Width / 2, 10);
                        this.pictureBox8.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox8.Width = this.pictureBox8.Image.Width;
                        this.pictureBox8.Height = this.pictureBox8.Image.Height;
                        this.pictureBox8.Location = new Point(PosicaoXInicio + 2*LarguraDesenhoGuiche + 3*LarguraDesenhoLinha + 2*LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox9.Image = (Image)temp;
                        this.pictureBox9.Location = new Point((this.Width / 2) - this.pictureBox9.Width / 2, 10);
                        this.pictureBox9.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox9.Width = this.pictureBox9.Image.Width;
                        this.pictureBox9.Height = this.pictureBox9.Image.Height;
                        this.pictureBox9.Location = new Point(PosicaoXInicio + 2*LarguraDesenhoGuiche + 4*LarguraDesenhoLinha + 2*LarguraDesenhoOnibus, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox10.Image = (Image)temp;
                        this.pictureBox10.Location = new Point((this.Width / 2) - this.pictureBox10.Width / 2, 10);
                        this.pictureBox10.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox10.Width = this.pictureBox10.Image.Width;
                        this.pictureBox10.Height = this.pictureBox10.Image.Height;
                        this.pictureBox10.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, PosicaoYLinha);
                        //Cliente
                        this.LabelCliente.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, PosicaoYCliente);
                        //Largura form principal
                        this.Width = PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + LabelCliente.Width + BordaForm;
                        this.PanelDensenho.Width = 3 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + LabelCliente.Width + BordaPanel;
                        this.GroupBoxDesenho.Width = 3 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + LabelCliente.Width + BordaGroupBox;
                        //this.pictureBox10.Visible = false;
                        this.pictureBox11.Visible = false;
                        this.pictureBox12.Visible = false;
                        this.pictureBox13.Visible = false;
                        this.pictureBox14.Visible = false;
                        this.pictureBox15.Visible = false;
                        this.pictureBox16.Visible = false;
                        this.pictureBox17.Visible = false;
                        this.pictureBox18.Visible = false;
                        break;
                    }
                case 4:
                    {
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox1.Image = (Image)temp;
                        this.pictureBox1.Location = new Point((this.Width / 2) - this.pictureBox1.Width / 2, 10);
                        this.pictureBox1.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox1.Width = this.pictureBox1.Image.Width;
                        this.pictureBox1.Height = this.pictureBox1.Image.Height;
                        this.pictureBox1.Location = new Point(PosicaoXInicio, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox2.Image = (Image)temp;
                        this.pictureBox2.Location = new Point((this.Width / 2) - this.pictureBox2.Width / 2, 10);
                        this.pictureBox2.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox2.Width = this.pictureBox2.Image.Width;
                        this.pictureBox2.Height = this.pictureBox2.Image.Height;
                        this.pictureBox2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche, PosicaoYLinha);
                        //Onibus
                        this.pictureBox3.Image = (Image)temp;
                        this.pictureBox3.Location = new Point((this.Width / 2) - this.pictureBox3.Width / 2, 10);
                        this.pictureBox3.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox3.Width = this.pictureBox3.Image.Width;
                        this.pictureBox3.Height = this.pictureBox3.Image.Height;
                        this.pictureBox3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox4.Image = (Image)temp;
                        this.pictureBox4.Location = new Point((this.Width / 2) - this.pictureBox4.Width / 2, 10);
                        this.pictureBox4.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox4.Width = this.pictureBox4.Image.Width;
                        this.pictureBox4.Height = this.pictureBox4.Image.Height;
                        this.pictureBox4.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox5.Image = (Image)temp;
                        this.pictureBox5.Location = new Point((this.Width / 2) - this.pictureBox5.Width / 2, 10);
                        this.pictureBox5.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox5.Width = this.pictureBox5.Image.Width;
                        this.pictureBox5.Height = this.pictureBox5.Image.Height;
                        this.pictureBox5.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus + LarguraDesenhoLinha, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox6.Image = (Image)temp;
                        this.pictureBox6.Location = new Point((this.Width / 2) - this.pictureBox6.Width / 2, 10);
                        this.pictureBox6.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox6.Width = this.pictureBox6.Image.Width;
                        this.pictureBox6.Height = this.pictureBox6.Image.Height;
                        this.pictureBox6.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Onibus
                        this.pictureBox7.Image = (Image)temp;
                        this.pictureBox7.Location = new Point((this.Width / 2) - this.pictureBox7.Width / 2, 10);
                        this.pictureBox7.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox7.Width = this.pictureBox7.Image.Width;
                        this.pictureBox7.Height = this.pictureBox7.Image.Height;
                        this.pictureBox7.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox8.Image = (Image)temp;
                        this.pictureBox8.Location = new Point((this.Width / 2) - this.pictureBox8.Width / 2, 10);
                        this.pictureBox8.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox8.Width = this.pictureBox8.Image.Width;
                        this.pictureBox8.Height = this.pictureBox8.Image.Height;
                        this.pictureBox8.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox9.Image = (Image)temp;
                        this.pictureBox9.Location = new Point((this.Width / 2) - this.pictureBox9.Width / 2, 10);
                        this.pictureBox9.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox9.Width = this.pictureBox9.Image.Width;
                        this.pictureBox9.Height = this.pictureBox9.Image.Height;
                        this.pictureBox9.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox10.Image = (Image)temp;
                        this.pictureBox10.Location = new Point((this.Width / 2) - this.pictureBox10.Width / 2, 10);
                        this.pictureBox10.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox10.Width = this.pictureBox10.Image.Width;
                        this.pictureBox10.Height = this.pictureBox10.Image.Height;
                        this.pictureBox10.Location = new Point(PosicaoXInicio + 3* LarguraDesenhoGuiche + 4* LarguraDesenhoLinha + 2*LarguraDesenhoOnibus, PosicaoYLinha);
                        
                        //Onibus
                        this.pictureBox11.Image = (Image)temp;
                        this.pictureBox11.Location = new Point((this.Width / 2) - this.pictureBox11.Width / 2, 10);
                        this.pictureBox11.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox11.Width = this.pictureBox11.Image.Width;
                        this.pictureBox11.Height = this.pictureBox11.Image.Height;
                        this.pictureBox11.Location = new Point(PosicaoXInicio + 3* LarguraDesenhoGuiche + 5* LarguraDesenhoLinha + 2*LarguraDesenhoOnibus, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox12.Image = (Image)temp;
                        this.pictureBox12.Location = new Point((this.Width / 2) - this.pictureBox12.Width / 2, 10);
                        this.pictureBox12.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox12.Width = this.pictureBox12.Image.Width;
                        this.pictureBox12.Height = this.pictureBox12.Image.Height;
                        this.pictureBox12.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 3* LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox13.Image = (Image)temp;
                        this.pictureBox13.Location = new Point((this.Width / 2) - this.pictureBox13.Width / 2, 10);
                        this.pictureBox13.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox13.Width = this.pictureBox13.Image.Width;
                        this.pictureBox13.Height = this.pictureBox13.Image.Height;
                        this.pictureBox13.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox14.Image = (Image)temp;
                        this.pictureBox14.Location = new Point((this.Width / 2) - this.pictureBox14.Width / 2, 10);
                        this.pictureBox14.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox14.Width = this.pictureBox14.Image.Width;
                        this.pictureBox14.Height = this.pictureBox14.Image.Height;
                        this.pictureBox14.Location = new Point(PosicaoXInicio + 4 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus, PosicaoYLinha);
                        //Cliente
                        this.LabelCliente.Location = new Point(PosicaoXInicio + 4 * LarguraDesenhoGuiche + 7 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus, PosicaoYCliente);
                        //largura do form
                        this.Width = PosicaoXInicio + 4 * LarguraDesenhoGuiche + 7 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus + LabelCliente.Width + BordaForm;
                        this.PanelDensenho.Width = 4 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus + LabelCliente.Width + BordaPanel;
                        this.GroupBoxDesenho.Width = 4 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus + LabelCliente.Width + BordaGroupBox;
                        //this.pictureBox13.Visible = false;
                        //this.pictureBox14.Visible = false;
                        this.pictureBox15.Visible = false;
                        this.pictureBox16.Visible = false;
                        this.pictureBox17.Visible = false;
                        this.pictureBox18.Visible = false;

                        break;
                    }
                case 5:
                    {
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox1.Image = (Image)temp;
                        this.pictureBox1.Location = new Point((this.Width / 2) - this.pictureBox1.Width / 2, 10);
                        this.pictureBox1.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox1.Width = this.pictureBox1.Image.Width;
                        this.pictureBox1.Height = this.pictureBox1.Image.Height;
                        this.pictureBox1.Location = new Point(PosicaoXInicio, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox2.Image = (Image)temp;
                        this.pictureBox2.Location = new Point((this.Width / 2) - this.pictureBox2.Width / 2, 10);
                        this.pictureBox2.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox2.Width = this.pictureBox2.Image.Width;
                        this.pictureBox2.Height = this.pictureBox2.Image.Height;
                        this.pictureBox2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche, PosicaoYLinha);
                        //Onibus
                        this.pictureBox3.Image = (Image)temp;
                        this.pictureBox3.Location = new Point((this.Width / 2) - this.pictureBox3.Width / 2, 10);
                        this.pictureBox3.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox3.Width = this.pictureBox3.Image.Width;
                        this.pictureBox3.Height = this.pictureBox3.Image.Height;
                        this.pictureBox3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox4.Image = (Image)temp;
                        this.pictureBox4.Location = new Point((this.Width / 2) - this.pictureBox4.Width / 2, 10);
                        this.pictureBox4.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox4.Width = this.pictureBox4.Image.Width;
                        this.pictureBox4.Height = this.pictureBox4.Image.Height;
                        this.pictureBox4.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox5.Image = (Image)temp;
                        this.pictureBox5.Location = new Point((this.Width / 2) - this.pictureBox5.Width / 2, 10);
                        this.pictureBox5.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox5.Width = this.pictureBox5.Image.Width;
                        this.pictureBox5.Height = this.pictureBox5.Image.Height;
                        this.pictureBox5.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + LarguraDesenhoOnibus + LarguraDesenhoLinha, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox6.Image = (Image)temp;
                        this.pictureBox6.Location = new Point((this.Width / 2) - this.pictureBox6.Width / 2, 10);
                        this.pictureBox6.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox6.Width = this.pictureBox6.Image.Width;
                        this.pictureBox6.Height = this.pictureBox6.Image.Height;
                        this.pictureBox6.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYLinha);
                        //Onibus
                        this.pictureBox7.Image = (Image)temp;
                        this.pictureBox7.Location = new Point((this.Width / 2) - this.pictureBox7.Width / 2, 10);
                        this.pictureBox7.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox7.Width = this.pictureBox7.Image.Width;
                        this.pictureBox7.Height = this.pictureBox7.Image.Height;
                        this.pictureBox7.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox8.Image = (Image)temp;
                        this.pictureBox8.Location = new Point((this.Width / 2) - this.pictureBox8.Width / 2, 10);
                        this.pictureBox8.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox8.Width = this.pictureBox8.Image.Width;
                        this.pictureBox8.Height = this.pictureBox8.Image.Height;
                        this.pictureBox8.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox9.Image = (Image)temp;
                        this.pictureBox9.Location = new Point((this.Width / 2) - this.pictureBox9.Width / 2, 10);
                        this.pictureBox9.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox9.Width = this.pictureBox9.Image.Width;
                        this.pictureBox9.Height = this.pictureBox9.Image.Height;
                        this.pictureBox9.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox10.Image = (Image)temp;
                        this.pictureBox10.Location = new Point((this.Width / 2) - this.pictureBox10.Width / 2, 10);
                        this.pictureBox10.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox10.Width = this.pictureBox10.Image.Width;
                        this.pictureBox10.Height = this.pictureBox10.Image.Height;
                        this.pictureBox10.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, PosicaoYLinha);

                        //Onibus
                        this.pictureBox11.Image = (Image)temp;
                        this.pictureBox11.Location = new Point((this.Width / 2) - this.pictureBox11.Width / 2, 10);
                        this.pictureBox11.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox11.Width = this.pictureBox11.Image.Width;
                        this.pictureBox11.Height = this.pictureBox11.Image.Height;
                        this.pictureBox11.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox12.Image = (Image)temp;
                        this.pictureBox12.Location = new Point((this.Width / 2) - this.pictureBox12.Width / 2, 10);
                        this.pictureBox12.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox12.Width = this.pictureBox12.Image.Width;
                        this.pictureBox12.Height = this.pictureBox12.Image.Height;
                        this.pictureBox12.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox13.Image = (Image)temp;
                        this.pictureBox13.Location = new Point((this.Width / 2) - this.pictureBox13.Width / 2, 10);
                        this.pictureBox13.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox13.Width = this.pictureBox13.Image.Width;
                        this.pictureBox13.Height = this.pictureBox13.Image.Height;
                        this.pictureBox13.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox14.Image = (Image)temp;
                        this.pictureBox14.Location = new Point((this.Width / 2) - this.pictureBox14.Width / 2, 10);
                        this.pictureBox14.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox14.Width = this.pictureBox14.Image.Width;
                        this.pictureBox14.Height = this.pictureBox14.Image.Height;
                        this.pictureBox14.Location = new Point(PosicaoXInicio + 4 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus, PosicaoYLinha);

                        //Onibus
                        this.pictureBox15.Image = (Image)temp;
                        this.pictureBox15.Location = new Point((this.Width / 2) - this.pictureBox15.Width / 2, 10);
                        this.pictureBox15.Image = new Bitmap(Properties.Resources.SIAEROnibusFigura);
                        this.pictureBox15.Width = this.pictureBox15.Image.Width;
                        this.pictureBox15.Height = this.pictureBox15.Image.Height;
                        this.pictureBox15.Location = new Point(PosicaoXInicio + 4 * LarguraDesenhoGuiche + 7 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus, PosicaoYOnibus);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox16.Image = (Image)temp;
                        this.pictureBox16.Location = new Point((this.Width / 2) - this.pictureBox16.Width / 2, 10);
                        this.pictureBox16.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox16.Width = this.pictureBox16.Image.Width;
                        this.pictureBox16.Height = this.pictureBox16.Image.Height;
                        this.pictureBox16.Location = new Point(PosicaoXInicio + 4 * LarguraDesenhoGuiche + 7 * LarguraDesenhoLinha + 4 * LarguraDesenhoOnibus, PosicaoYLinha);
                        //Guiche
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox17.Image = (Image)temp;
                        this.pictureBox17.Location = new Point((this.Width / 2) - this.pictureBox17.Width / 2, 10);
                        this.pictureBox17.Image = new Bitmap(Properties.Resources.SIAERGuicheFigura);
                        this.pictureBox17.Width = this.pictureBox17.Image.Width;
                        this.pictureBox17.Height = this.pictureBox17.Image.Height;
                        this.pictureBox17.Location = new Point(PosicaoXInicio + 4 * LarguraDesenhoGuiche + 8 * LarguraDesenhoLinha + 4 * LarguraDesenhoOnibus, AlturaPadrao);
                        //Linha
                        temp.SetPixel(0, 0, this.BackColor);
                        this.pictureBox18.Image = (Image)temp;
                        this.pictureBox18.Location = new Point((this.Width / 2) - this.pictureBox18.Width / 2, 10);
                        this.pictureBox18.Image = new Bitmap(Properties.Resources.SIAERLinhaFigura);
                        this.pictureBox18.Width = this.pictureBox18.Image.Width;
                        this.pictureBox18.Height = this.pictureBox18.Image.Height;
                        this.pictureBox18.Location = new Point(PosicaoXInicio + 5 * LarguraDesenhoGuiche + 8 * LarguraDesenhoLinha + 4 * LarguraDesenhoOnibus, PosicaoYLinha);
                        //Cliente
                        this.LabelCliente.Location = new Point(PosicaoXInicio + 5 * LarguraDesenhoGuiche + 9 * LarguraDesenhoLinha + 4 * LarguraDesenhoOnibus, PosicaoYCliente);


                        this.Width = PosicaoXInicio + 5 * LarguraDesenhoGuiche + 9 * LarguraDesenhoLinha + 4 * LarguraDesenhoOnibus + LabelCliente.Width + BordaForm;
                        this.PanelDensenho.Width = PosicaoXInicio + 5 * LarguraDesenhoGuiche + 8 * LarguraDesenhoLinha + 4 * LarguraDesenhoOnibus + LabelCliente.Width + BordaPanel;
                        this.GroupBoxDesenho.Width = PosicaoXInicio + 5 * LarguraDesenhoGuiche + 8 * LarguraDesenhoLinha + 4 * LarguraDesenhoOnibus + LabelCliente.Width + BordaGroupBox;
                        break;
                    }
                }
            //A partir daqui é o código dos Labels
            int PosicaoYLabelOnibus = pictureBox3.Location.Y +AlturaDesenhoOnibus;
            int PosicaoYLabelGuiche = pictureBox1.Location.Y - 20;

            int PosicaoYLabelGuicheAtendente = pictureBox1.Location.Y + pictureBox1.Height + 10;
            int PosicaoYLabelGuicheOnibus = pictureBox3.Location.Y - 20;
            int PosicaoYLabelClienteAtendente = LabelCliente.Location.Y - 20;
            switch (ArrayDeGuiches.Count)
            {
                case 2:
                    {
                        L1.Text = Convert.ToString(ArrayDeGuiches[0]);
                        L1.Font = new Font(L1.Font, FontStyle.Bold);
                        L2.Text = Convert.ToString(ArrayDeCarros[1]);
                        L2.Font = new Font(L2.Font, FontStyle.Bold);
                        L3.Text = Convert.ToString(ArrayDeGuiches[1]);
                        L3.Font = new Font(L3.Font, FontStyle.Bold);
                        LabelAt1.Text = Convert.ToString(ArrayDeStatusAtendentesGuiche[0]);
                        LabelAt1.Font = new Font(LabelAt1.Font,FontStyle.Bold);
                        LabelAt1.ForeColor = Color.Red;
                        LabelAt2.Text = Convert.ToString(ArrayDeStatusAtendentesOnibus[0]);
                        LabelAt2.Font = new Font(LabelAt2.Font, FontStyle.Bold);
                        LabelAt2.ForeColor = Color.Red;
                        LabelAt3.Text = Convert.ToString(ArrayDeStatusAtendentesGuiche[1]);
                        LabelAt3.Font = new Font(LabelAt3.Font, FontStyle.Bold);
                        LabelAt3.ForeColor = Color.Red;
                        LabelAt4.Text = Convert.ToString(ArrayDeStatusAtendentesOnibus[1]);
                        LabelAt4.Font = new Font(LabelAt4.Font, FontStyle.Bold);
                        LabelAt4.ForeColor = Color.Red;
                        L4.Visible = false;
                        L5.Visible = false;
                        L6.Visible = false;
                        L7.Visible = false;
                        LabelAt5.Visible = false;
                        LabelAt6.Visible = false;
                        LabelAt7.Visible = false;

                        int OffsetL1 = Math.Abs((LarguraDesenhoGuiche - L1.Width) / 2);
                        int OffsetL2 = Math.Abs((LarguraDesenhoOnibus - L2.Width) / 2);
                        int OffsetL3 = Math.Abs((LarguraDesenhoGuiche - L3.Width) / 2);

                        int OffsetLabelAt1 = Math.Abs((LarguraDesenhoGuiche - LabelAt1.Width) / 2);
                        int OffsetLabelAt2 = Math.Abs((LarguraDesenhoOnibus - LabelAt2.Width) / 2);
                        int OffsetLabelAt3 = Math.Abs((LarguraDesenhoGuiche - LabelAt3.Width) / 2);
                        int OffsetLabelAt4 = Math.Abs((LarguraDesenhoCliente - LabelAt4.Width) / 2);
                        //Guiche
                        if (LarguraDesenhoGuiche < L1.Width)
                            L1.Location = new Point(PosicaoXInicio - OffsetL1, PosicaoYLabelGuiche);
                        else
                            L1.Location = new Point(PosicaoXInicio + OffsetL1, PosicaoYLabelGuiche);
                        //Atendente Guiche 1
                        if (LarguraDesenhoGuiche < LabelAt1.Width)
                            LabelAt1.Location = new Point(PosicaoXInicio - OffsetLabelAt1, PosicaoYLabelGuicheAtendente);
                        else
                            LabelAt1.Location = new Point(PosicaoXInicio + OffsetLabelAt1, PosicaoYLabelGuicheAtendente);

                        //Onibus
                        if (LarguraDesenhoOnibus < L2.Width)
                            L2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha - OffsetL2, PosicaoYLabelOnibus);
                        else
                            L2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + OffsetL2, PosicaoYLabelOnibus);
                        //Atendente Onibus 1
                        if (LarguraDesenhoOnibus < LabelAt2.Width)
                            LabelAt2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha - OffsetLabelAt2, PosicaoYLabelGuicheOnibus);
                        else
                            LabelAt2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + OffsetLabelAt2, PosicaoYLabelGuicheOnibus);

                        //Guiche
                        if (LarguraDesenhoGuiche < L3.Width)
                            L3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetL3, PosicaoYLabelGuiche);
                        else
                            L3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetL3, PosicaoYLabelGuiche);

                        //Atendente Guiche 2
                        if (LarguraDesenhoGuiche < LabelAt3.Width)
                            LabelAt3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetLabelAt3, PosicaoYLabelGuicheAtendente);
                        else
                            LabelAt3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetLabelAt3, PosicaoYLabelGuicheAtendente);

                        //Atendente Cliente
                        if (LarguraDesenhoCliente < LabelAt4.Width)
                            LabelAt4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetLabelAt4, PosicaoYLabelClienteAtendente);
                        else
                            LabelAt4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetLabelAt4, PosicaoYLabelClienteAtendente);
                        break;
                        
                    }
                case 3:
                    {
                        L1.Text = Convert.ToString(ArrayDeGuiches[0]);
                        L1.Font = new Font(L1.Font, FontStyle.Bold);
                        L2.Text = Convert.ToString(ArrayDeCarros[1]);
                        L2.Font = new Font(L2.Font, FontStyle.Bold);
                        L3.Text = Convert.ToString(ArrayDeGuiches[1]);
                        L3.Font = new Font(L3.Font, FontStyle.Bold);
                        L4.Text = Convert.ToString(ArrayDeCarros[2]);
                        L4.Font = new Font(L4.Font, FontStyle.Bold);
                        L5.Text = Convert.ToString(ArrayDeGuiches[2]);
                        L5.Font = new Font(L5.Font, FontStyle.Bold);
                        LabelAt1.Text = Convert.ToString(ArrayDeStatusAtendentesGuiche[0]);
                        LabelAt1.Font = new Font(LabelAt1.Font, FontStyle.Bold);
                        LabelAt1.ForeColor = Color.Red;
                        LabelAt2.Text = Convert.ToString(ArrayDeStatusAtendentesOnibus[0]);
                        LabelAt2.Font = new Font(LabelAt2.Font, FontStyle.Bold);
                        LabelAt2.ForeColor = Color.Red;
                        LabelAt3.Text = Convert.ToString(ArrayDeStatusAtendentesGuiche[1]);
                        LabelAt3.Font = new Font(LabelAt3.Font, FontStyle.Bold);
                        LabelAt3.ForeColor = Color.Red;
                        LabelAt4.Text = Convert.ToString(ArrayDeStatusAtendentesOnibus[1]);
                        LabelAt4.Font = new Font(LabelAt4.Font, FontStyle.Bold);
                        LabelAt4.ForeColor = Color.Red;
                        LabelAt5.Text = Convert.ToString(ArrayDeStatusAtendentesGuiche[2]);
                        LabelAt5.Font = new Font(LabelAt1.Font, FontStyle.Bold);
                        LabelAt5.ForeColor = Color.Red;
                        LabelAt6.Text = Convert.ToString(ArrayDeStatusAtendentesOnibus[2]);
                        LabelAt6.Font = new Font(LabelAt1.Font, FontStyle.Bold);
                        LabelAt6.ForeColor = Color.Red;
                        L6.Visible = false;
                        L7.Visible = false;

                        int OffsetL1 = Math.Abs((LarguraDesenhoGuiche - L1.Width) / 2);
                        int OffsetL2 = Math.Abs((LarguraDesenhoOnibus - L2.Width) / 2);
                        int OffsetL3 = Math.Abs((LarguraDesenhoGuiche - L3.Width) / 2);
                        int OffsetL4 = Math.Abs((LarguraDesenhoOnibus - L4.Width) / 2);
                        int OffsetL5 = Math.Abs((LarguraDesenhoGuiche - L5.Width) / 2);
                        int OffsetLabelAt1 = Math.Abs((LarguraDesenhoGuiche - LabelAt1.Width) / 2);
                        int OffsetLabelAt2 = Math.Abs((LarguraDesenhoOnibus - LabelAt2.Width) / 2);
                        int OffsetLabelAt3 = Math.Abs((LarguraDesenhoGuiche - LabelAt3.Width) / 2);
                        int OffsetLabelAt4 = Math.Abs((LarguraDesenhoOnibus - LabelAt4.Width) / 2);
                        int OffsetLabelAt5 = Math.Abs((LarguraDesenhoGuiche - LabelAt5.Width) / 2);
                        int OffsetLabelAt6 = Math.Abs((LarguraDesenhoCliente - LabelAt6.Width) / 2);

                        //Guiche
                        if (LarguraDesenhoGuiche < L1.Width)
                            L1.Location = new Point(PosicaoXInicio - OffsetL1, PosicaoYLabelGuiche);
                        else
                            L1.Location = new Point(PosicaoXInicio + OffsetL1, PosicaoYLabelGuiche);
                        //Atendente Guiche 1
                        if (LarguraDesenhoGuiche < LabelAt1.Width)
                            LabelAt1.Location = new Point(PosicaoXInicio - OffsetLabelAt1, PosicaoYLabelGuicheAtendente);
                        else
                            LabelAt1.Location = new Point(PosicaoXInicio + OffsetLabelAt1, PosicaoYLabelGuicheAtendente);
                        //Onibus
                        if (LarguraDesenhoOnibus < L2.Width)
                            L2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha - OffsetL2, PosicaoYLabelOnibus);
                        else
                            L2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + OffsetL2, PosicaoYLabelOnibus);
                        //Atendente Onibus 1
                        if (LarguraDesenhoOnibus < LabelAt2.Width)
                            LabelAt2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha - OffsetLabelAt2, PosicaoYLabelGuicheOnibus);
                        else
                            LabelAt2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + OffsetLabelAt2, PosicaoYLabelGuicheOnibus);
                        //Guiche
                        if (LarguraDesenhoGuiche < L3.Width)
                            L3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetL3, PosicaoYLabelGuiche);
                        else
                            L3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetL3, PosicaoYLabelGuiche);
                        //Atendente Guiche 2
                        if (LarguraDesenhoGuiche < LabelAt3.Width)
                            LabelAt3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetLabelAt3, PosicaoYLabelGuicheAtendente);
                        else
                            LabelAt3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetLabelAt3, PosicaoYLabelGuicheAtendente);

                        //Onibus
                        if (LarguraDesenhoOnibus < L4.Width)
                            L4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetL4, PosicaoYLabelOnibus);
                        else
                            L4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetL4, PosicaoYLabelOnibus);
                        
                        //Atendente Onibus 2
                        if (LarguraDesenhoOnibus < LabelAt4.Width)
                            LabelAt4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha +  LarguraDesenhoOnibus - OffsetLabelAt4, PosicaoYLabelGuicheOnibus);
                        else
                            LabelAt4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha +  LarguraDesenhoOnibus + OffsetLabelAt4, PosicaoYLabelGuicheOnibus);

                        //Guiche
                        if (LarguraDesenhoGuiche < L5.Width)
                            L5.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus - OffsetL5, PosicaoYLabelGuiche);
                        else
                            L5.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + OffsetL5, PosicaoYLabelGuiche);

                        //Atendente Guiche 3
                        if (LarguraDesenhoGuiche < LabelAt5.Width)
                            LabelAt5.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus - OffsetLabelAt5, PosicaoYLabelGuicheAtendente);
                        else
                            LabelAt5.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + OffsetLabelAt5, PosicaoYLabelGuicheAtendente);

                        //Atendente Cliente
                        if (LarguraDesenhoCliente < LabelAt6.Width)
                            LabelAt6.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus - OffsetLabelAt6, PosicaoYLabelClienteAtendente);
                        else
                            LabelAt6.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + OffsetLabelAt6, PosicaoYLabelClienteAtendente);
                        break;
                    }
                case 4:
                    {
                        
                        L1.Text = Convert.ToString(ArrayDeGuiches[0]);
                        L1.Font = new Font(L1.Font, FontStyle.Bold);
                        L2.Text = Convert.ToString(ArrayDeCarros[1]);
                        L2.Font = new Font(L2.Font, FontStyle.Bold);
                        L3.Text = Convert.ToString(ArrayDeGuiches[1]);
                        L3.Font = new Font(L3.Font, FontStyle.Bold);
                        L4.Text = Convert.ToString(ArrayDeCarros[2]);
                        L4.Font = new Font(L4.Font, FontStyle.Bold);
                        L5.Text = Convert.ToString(ArrayDeGuiches[2]);
                        L5.Font = new Font(L5.Font, FontStyle.Bold);
                        L6.Text = Convert.ToString(ArrayDeCarros[3]);
                        L6.Font = new Font(L6.Font, FontStyle.Bold);
                        L7.Text = Convert.ToString(ArrayDeGuiches[3]);
                        L7.Font = new Font(L7.Font, FontStyle.Bold);


                        int OffsetL1 = Math.Abs((LarguraDesenhoGuiche - L1.Width) / 2);
                        int OffsetL2 = Math.Abs((LarguraDesenhoOnibus - L2.Width) / 2);
                        int OffsetL3 = Math.Abs((LarguraDesenhoGuiche - L3.Width) / 2);
                        int OffsetL4 = Math.Abs((LarguraDesenhoOnibus - L4.Width) / 2);
                        int OffsetL5 = Math.Abs((LarguraDesenhoGuiche - L5.Width) / 2);
                        int OffsetL6 = Math.Abs((LarguraDesenhoOnibus - L6.Width) / 2);
                        int OffsetL7 = Math.Abs((LarguraDesenhoGuiche - L7.Width) / 2);

                        //Guiche
                        if (LarguraDesenhoGuiche < L1.Width)
                            L1.Location = new Point(PosicaoXInicio - OffsetL1, PosicaoYLabelGuiche);
                        else
                            L1.Location = new Point(PosicaoXInicio + OffsetL1, PosicaoYLabelGuiche);
                        //Onibus
                        if (LarguraDesenhoOnibus < L2.Width)
                            L2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha - OffsetL2, PosicaoYLabelOnibus);
                        else
                            L2.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + LarguraDesenhoLinha + OffsetL2, PosicaoYLabelOnibus);
                        //Guiche
                        if (LarguraDesenhoGuiche < L3.Width)
                            L3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetL3, PosicaoYLabelGuiche);
                        else
                            L3.Location = new Point(PosicaoXInicio + LarguraDesenhoGuiche + 2 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetL3, PosicaoYLabelGuiche);
                        //Onibus
                        if (LarguraDesenhoOnibus < L4.Width)
                            L4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus - OffsetL4, PosicaoYLabelOnibus);
                        else
                            L4.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 3 * LarguraDesenhoLinha + LarguraDesenhoOnibus + OffsetL4, PosicaoYLabelOnibus);
                        //Guiche
                        if (LarguraDesenhoGuiche < L5.Width)
                            L5.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus - OffsetL5, PosicaoYLabelGuiche);
                        else
                            L5.Location = new Point(PosicaoXInicio + 2 * LarguraDesenhoGuiche + 4 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + OffsetL5, PosicaoYLabelGuiche);
                        //Onibus
                        if (LarguraDesenhoOnibus < L6.Width)
                            L6.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus - OffsetL6, PosicaoYLabelOnibus);
                        else
                            L6.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 5 * LarguraDesenhoLinha + 2 * LarguraDesenhoOnibus + OffsetL6, PosicaoYLabelOnibus);
                        //Guiche
                        if (LarguraDesenhoGuiche < L7.Width)
                            L7.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus - OffsetL7, PosicaoYLabelGuiche);
                        else
                            L7.Location = new Point(PosicaoXInicio + 3 * LarguraDesenhoGuiche + 6 * LarguraDesenhoLinha + 3 * LarguraDesenhoOnibus + OffsetL7, PosicaoYLabelGuiche);
                        break;
                    }
            }
        }
        private void AdquirirInformaçõesDeTrajeto()
        {
            using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
            {
                SqlCommand command = null;
                using (command = new SqlCommand("select codigodocarro,city_name,AEncomendaEstaNoGuiche,AEncomendaEstaNoCarro,AEncomendaFoiEntregueAoCliente,QuemPassouOCodigoDeBarrasNoGuiche,QuemPassouOCodigoDeBarrasNoCarro from trajetoencomenda inner join City on city_code = CodigoDaCidade where codigodaencomenda = @codigoencomenda order by identificador asc", connection))
                {
                    //Tipo de Command, dizendo que é um query
                    command.CommandType = CommandType.Text;
                    //Cria Parametros para inserir na query do SqlCommand
                    SqlParameter param = command.CreateParameter();
                    param.ParameterName = "@codigoencomenda";
                    param.SqlDbType = SqlDbType.VarChar;
                    param.Size = 20;
                    param.Value = CodigoDeBarrasALocalizar;
                    param.Direction = ParameterDirection.Input;
                    command.Parameters.Add(param);

                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        ArrayDeGuiches.Add(dr["city_name"]);
                        ArrayDeCarros.Add(dr["codigodocarro"]);
                        ArrayDeStatusGuiches.Add(Convert.ToInt32(dr["AEncomendaEstaNoGuiche"]));
                        ArrayDeStatusCarros.Add(Convert.ToInt32(dr["AEncomendaEstaNoCarro"]));
                        ArrayDeStatusCliente.Add(Convert.ToInt32(dr["AEncomendaFoiEntregueAoCliente"]));
                        ArrayDeStatusAtendentesGuiche.Add(Convert.ToString(dr["QuemPassouOCodigoDeBarrasNoGuiche"]));
                        ArrayDeStatusAtendentesOnibus.Add(Convert.ToString(dr["QuemPassouOCodigoDeBarrasNoCarro"]));
                    }
                        connection.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
