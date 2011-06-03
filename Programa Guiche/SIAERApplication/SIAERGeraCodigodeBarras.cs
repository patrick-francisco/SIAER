using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.IO;
using SIAERClassLibrary;

namespace SIAERAplicacao
{
    /// <summary>
    /// This form is a test form to show what all you can do with the Barcode Library.
    /// Only one call is actually needed to do the encoding and return the image of the 
    /// barcode but the rest is just flare and user interface ... stuff.
    /// </summary>
    public partial class SIAERGeraCodigoDeBarras : Form
    {
        string _codigoagerar;
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        public SIAERGeraCodigoDeBarras(string CodigoAGerar)
        {
            InitializeComponent();
            _codigoagerar = CodigoAGerar;
            GerarImagemCodigoDeBarras();
            SalvarAImagemDoCodigoNoBanco();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(1, 1);
            temp.SetPixel(0, 0, this.BackColor);
            barcode.Image = (Image)temp;
        }

        private void SIAERGeraCodigodeBarras_Changed(object sender, EventArgs e)
        {
            barcode.Location = new Point((this.Width / 2) - barcode.Width / 2, 10);
        }
        private void GerarImagemCodigoDeBarras()
        {
            int W = Convert.ToInt32("300");
            int H = Convert.ToInt32("100");
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.EAN13;

            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    b.IncludeLabel = false;//Sempre Imprime os números junto com o código de barras
                    //===== Encoding performed here =====
                    barcode.Image = b.Encode(type, _codigoagerar, this.b.ForeColor, this.b.BackColor, W, H);
                    barcode.Width = barcode.Image.Width;
                    barcode.Height = barcode.Image.Height;
                }//if

                barcode.Width = barcode.Image.Width;
                barcode.Height = barcode.Image.Height;

                //reposition the barcode image to the middle
                barcode.Location = new Point((this.Width / 2) - barcode.Width / 2, 10);
            }//try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//catch
        }

        private void SalvarAImagemDoCodigoNoBanco()
        {
            try
            {
                //Conexão
                using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                {
                    //Comando 
                    SqlCommand command = null;
                    using (command = new SqlCommand("InserirImagemCodigoDeBarras @codigo,@Pic", connection))
                    {
                        MemoryStream stream = new MemoryStream();
                        this.barcode.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //Below is the most important part, actually you are
                        //transferring the bytes of the array
                        //to the pic which is also of kind byte[]
                        byte[] pic = stream.ToArray();
                        command.Parameters.AddWithValue("@codigo", _codigoagerar);
                        command.Parameters.AddWithValue("@Pic", pic);

                        //Configura os parâmetros.
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void SIAERGeraCodigoDeBarras_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SIAERTESTEDataSet.EtiquetaTemporaria' table. You can move, or remove it, as needed.
            this.EtiquetaTemporariaTableAdapter.Fill(this.SIAERTESTEDataSet.EtiquetaTemporaria);
            this.reportViewer1.RefreshReport();
        }
        private void DeletaCodigoDeBarrasTemporario(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                {
                    SqlCommand command = null;
                    using (command = new SqlCommand("delete from etiquetatemporaria", connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }//class
}//namespace