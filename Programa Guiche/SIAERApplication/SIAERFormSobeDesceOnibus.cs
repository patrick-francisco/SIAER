using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIAERClassLibrary;
using System.Collections;

namespace SIAERAplicacao
{
    public partial class SIAERFormSobeDesceOnibus : Form
    {
        CCarro CarroAtual = new CCarro();
        ArrayList EncomendasASubir = new ArrayList();
        ArrayList EncomendasADescer = new ArrayList();
        string _Carro;
        string _Cidade;
        public SIAERFormSobeDesceOnibus(string Carro,string Cidade)
        {
            InitializeComponent();
            DataGridViewEncomendas.AutoGenerateColumns = true;
            DataGridViewEncomendas.AllowUserToAddRows = true;
            _Carro = Carro;
            _Cidade = Cidade;
            this.LabelCarro.Text = Carro;
            //DataGridView
            CarroAtual.CodigodoCarro = Carro;
            //Subir
            EncomendasASubir = CarroAtual.RetornaEncomendasQueSubiraoNoCarro(Cidade);
            EncomendasADescer = CarroAtual.RetornaEncomendasQueDesceraoDoCarro(Cidade);

            //Deleta Encomendas Repetidas a subir
            ArrayList EncomendasASubirAux = new ArrayList();
            EncomendasASubirAux = EncomendasASubir;
            int Achou = EncomendasASubirAux.Count;
            for (int Item0 = 0; Item0 < Achou; Item0++)
            {
                if (EncomendasASubirAux[Item0].ToString() == EncomendasASubirAux[EncomendasASubirAux.Count - 1].ToString())
                {
                    Achou = Item0 + 1;
                }
            }
            int n = EncomendasASubirAux.Count - Achou;
            for (int Item0 = 0; Item0 < n; Item0++)
            {
                EncomendasASubir.RemoveAt(Achou);
            }

            int NumeroDeRows = 0;
            if (EncomendasASubir.Count > EncomendasADescer.Count)
            {
                NumeroDeRows = EncomendasASubir.Count;
            }
            else 
            {
                NumeroDeRows = EncomendasADescer.Count;
            }
            for (int i = 0; i < NumeroDeRows-1; i++)
            {
                DataGridViewEncomendas.Rows.Add();
            }
            for (int i = 0; i < EncomendasASubir.Count; i++)
            {
                DataGridViewEncomendas.Rows[i].Cells["ColumnSubir"].Value = EncomendasASubir[i];
            }
            for (int i = 0; i < EncomendasADescer.Count; i++)
            {
                DataGridViewEncomendas.Rows[i].Cells["ColumnDescer"].Value = EncomendasADescer[i];
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
