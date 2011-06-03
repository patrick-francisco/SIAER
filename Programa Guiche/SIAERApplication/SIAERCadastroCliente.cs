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
    public partial class SIAERCadastroCliente : Form
    {
        public SIAERCadastroCliente()
        {
            InitializeComponent();
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            CValidaoDeValores val = new CValidaoDeValores();
            if (val.ValidaCPF(TextBoxCPF.Text))
            {
                CCliente cli = new CCliente();
                cli.CPF = TextBoxCPF.Text;
                cli.Nome = TextBoxNome.Text;
                cli.DataDeNascimento = TextBoxNascimento.Text;
                cli.RG = TextBoxRG.Text;
                cli.Endereco = TextBoxEndereco.Text;
                cli.Bairro = TextboxBairro.Text;
                cli.CEP = TextBoxCEP.Text;
                cli.Cidade = TextBoxCidade.Text;
                cli.Estado = TextBoxEstado.Text;
                cli.Telefone = TextBoxTelefone.Text;
                cli.Celular = TextBoxCelular.Text;

                if (TextBoxNome.Text != "")
                {
                    cli.SalvarDadosNoBancoDeDados();
                    LimpaTudo();
                    MessageBox.Show("Cliente cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("O campo Nome está vazio", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            else 
            {
                MessageBox.Show("Valor de CPF inválido", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ButtonLimparTudo_Click(object sender, EventArgs e)
        {
            LimpaTudo();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxCPF_TextChanged(object sender, EventArgs e)
        {
            TextBoxCPF.SelectionStart = TextBoxCPF.Text.Length + 1;

        }

        private void LimpaTudo()
        {
            TextBoxCPF.Clear();
            TextBoxNome.Clear();
            TextBoxNascimento.Clear();
            TextBoxRG.Clear();
            TextBoxEndereco.Clear();
            TextboxBairro.Clear();
            TextBoxCEP.Clear();
            TextBoxCidade.Clear();
            TextBoxEstado.Clear();
            TextBoxTelefone.Clear();
            TextBoxCelular.Clear();
        }
    }
}
