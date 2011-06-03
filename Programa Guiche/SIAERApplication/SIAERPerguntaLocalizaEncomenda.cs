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

namespace SIAERAplicacao
{
    public partial class SIAERPerguntaLocalizaEncomenda : Form
    {
        public SIAERPerguntaLocalizaEncomenda()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(UmaTeclaFoiPressionada);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void UmaTeclaFoiPressionada(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//13 significa que a tecla Enter do teclado foi presisonada
            {
                ButtonLocalizar_Click();
            }
        }
        private void ButtonLocalizar_Click()
        {
            if (this.TextBoxCodigo.Text != "")
            {
                int Resultado;
                using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                {
                             //Comando 
                             SqlCommand command = null;
                             using (command = new SqlCommand("VerificaCodigoTrajetoEncomenda", connection))
                             {
                                 command.CommandType = CommandType.StoredProcedure;
                                 //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                                 command.Parameters.Add("@codigoencomenda", SqlDbType.VarChar, 20);
                                 command.Parameters["@codigoencomenda"].Value = this.TextBoxCodigo.Text;
                                 command.Parameters.Add("@Resultado", SqlDbType.Int);
                                 command.Parameters["@Resultado"].Direction = ParameterDirection.Output;

                                 //Configura os parâmetros.
                                 //daGetRecords.SelectCommand = command;
                                 connection.Open();
                                 //@Resultado:
                                 // 0-> Código existe no banco
                                 // 1-> Código inexistente
                                 command.ExecuteNonQuery();
                                 Resultado = (int)command.Parameters["@Resultado"].Value;
                                 connection.Close();
                             }
                         }
                if (Resultado == 0)
                {
                    SIAERLocalizaencomenda FormLocalizaEncomenda = new SIAERLocalizaencomenda(this.TextBoxCodigo.Text);
                    FormLocalizaEncomenda.Show();
                }
                else 
                {
                    MessageBox.Show("O código digitado não foi encontrado. Por favor verifique se foi digitado corretamente", "Código não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else 
            {
                MessageBox.Show("O código digitado não foi encontrado. Por favor verifique se foi digitado corretamente", "Código não encontrado", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void ButtonLocalizarx_Click(object sender, EventArgs e)
        {
            ButtonLocalizar_Click();
        }
    }
}
