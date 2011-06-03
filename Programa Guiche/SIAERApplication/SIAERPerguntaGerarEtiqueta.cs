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
    public partial class SIAERPerguntaGerarEtiqueta : Form
    {
        public SIAERPerguntaGerarEtiqueta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonGerar_Click(object sender, EventArgs e)
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
                    SIAERGeraCodigoDeBarras ger = new SIAERGeraCodigoDeBarras(this.TextBoxCodigo.Text);
                    ger.Show();
                }
                else
                {
                    MessageBox.Show("O código digitado não foi encontrado. Por favor verifique se foi digitado corretamente", "Código não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("O código digitado não foi encontrado. Por favor verifique se foi digitado corretamente", "Código não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}