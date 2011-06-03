using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIAERClassLibrary;

namespace SIAERAplicacao
{
    public partial class FormDeAutenticacao : Form
    {
        public Logar Autenticado;
        public SIAERClassLibrary.CAtendente User = new SIAERClassLibrary.CAtendente();
        public enum Logar
        {
            Sim,
            Não
        }
        public FormDeAutenticacao()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(UmaTeclaFoiPressionada);
            this.TextBoxNomedoUsuario.Click += new System.EventHandler(this.TextBoxFoiClicada);
            this.TextBoxSenha.Click += new System.EventHandler(this.TextBoxFoiClicada);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            BotaoOK();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            BotaoCancelar();
        }

        private void BotaoOK()
        {
            Autenticado = Logar.Sim;
            LabelFalha.Text = "";
            User.UserName = TextBoxNomedoUsuario.Text.ToString();
            User.Senha = TextBoxSenha.Text.ToString();
            int Resultado = User.VerificaLogin(User);
            if (Resultado == 0)
            {
                this.Close();
            }
            else
            {
                LabelFalha.Text = "Falha na Autenticação!";
                LabelFalha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void BotaoCancelar()
        {
            Autenticado = Logar.Não;
            this.Close();
        }

        void UmaTeclaFoiPressionada(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//13 significa que a tecla Enter do teclado foi presisonada
            {
                BotaoOK();
            }
        }
        private void TextBoxFoiClicada(object sender, EventArgs e)
        {
            if (sender == TextBoxNomedoUsuario)
            {
                TextBoxNomedoUsuario.Clear();
            }
            if (sender == TextBoxSenha)
            {
                TextBoxSenha.Clear();
            }
        }
    }
}
