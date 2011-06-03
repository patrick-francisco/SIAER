using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SIAERClassLibrary;
using System.Data.SqlClient;

namespace SIAERAplicacao
{
    public partial class SIAERCadastroEncomenda : Form
    {
        CAtendente Atendente = new CAtendente();
        public delegate void DelegateMouse();
        public SIAERCadastroEncomenda(CAtendente atendente)
        {
            InitializeComponent();
            this.Atendente = atendente;
        }

        private void SIAERCadastroEncomenda_Load(object sender, EventArgs e)
        {
            //Popula a ComboBox de Servicos
            ArrayList ListaDeServicos = new ArrayList();
            Citinerario Servicos = new Citinerario();
            ListaDeServicos = Servicos.Servicos();
            ColumnServico.DataSource = ListaDeServicos;
            DataGridViewTrajeto.CellBeginEdit += new DataGridViewCellCancelEventHandler(DataGridViewTrajeto_CellBeginEdit);
            DataGridViewTrajeto.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonLimparTudo_Click(object sender, EventArgs e)
        {
            LimpaTudo();
        }

        private void LimpaTudo()
        {
            TextBoxCPFDestinatario.Clear();
            TextBoxCPFRemetente.Clear();
            TextBoxPeso.Clear();
            TextBoxPreco.Clear();
        }
        private void ButtonSalvarTeste_Click(object sender, EventArgs e)
        {
            CValidaoDeValores val = new CValidaoDeValores();
            if (val.ValidaCPF(this.TextBoxCPFRemetente.Text))
            {
                if (val.ValidaCPF(this.TextBoxCPFDestinatario.Text))
                {
                    int ResultadoCPFRemetente;
                    int ResultadoCPFDestinatario;
                    CCliente cli = new CCliente();
                    ResultadoCPFRemetente = cli.ValidaCPFCliente(this.TextBoxCPFRemetente.Text);
                    ResultadoCPFDestinatario = cli.ValidaCPFCliente(this.TextBoxCPFDestinatario.Text);
                    if (ResultadoCPFRemetente == 0)
                    {
                        if (ResultadoCPFDestinatario == 0)
                        {
                            for (int j = 1; j <= DataGridViewTrajeto.RowCount - 1; j++)
                            {
                                try
                                {
                                    if (DataGridViewTrajeto.Rows[j - 1].Cells["ColumnServico"].Value.ToString() == null)
                                    { }
                                }
                                catch
                                {
                                    MessageBox.Show("Números de serviços incompleto", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                try
                                {
                                    if (DataGridViewTrajeto.Rows[j - 1].Cells["ColumnCidadeFinal"].Value.ToString() == null)
                                    { }
                                }
                                catch
                                {
                                    MessageBox.Show("Campo de Cidades incompleto", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                try
                                {
                                    if (DataGridViewTrajeto.Rows[j - 1].Cells["ColumnData"].Value.ToString() == null)
                                    { }
                                }
                                catch
                                {
                                    MessageBox.Show("Campo de datas incompleto", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                            if (DataGridViewTrajeto.RowCount > 2)
                            {
                                CEncomenda enc = new CEncomenda();
                                CCodigoDeBarra bar = new CCodigoDeBarra();
                                enc = enc.PesquisarUltimaEncomenda();//Pesquisa qual o código da última encomenda cadastrada
                                String StringCodigoDeBarras = Convert.ToString(enc.Codigo);
                                StringCodigoDeBarras = StringCodigoDeBarras.Remove(StringCodigoDeBarras.Length - 1, 1);//Elimina o Digito Verificador para os cálculos
                                enc.Codigo = Convert.ToString(Convert.ToInt64(StringCodigoDeBarras) + 1);//Calcula o código para a encomenda atual sendo cadastrada
                                bar.Code = enc.Codigo;
                                bar.InserirChecksumNoValor();
                                enc.Codigo = bar.Code;
                                enc.CPFDoRemetente = TextBoxCPFRemetente.Text;
                                enc.CPFDoDestinatário = TextBoxCPFDestinatario.Text;
                                enc.CidadeDeOrigem = Atendente.Cidade;//A cidade de origem sempre é a cidade do atendente
                                enc.CidadeDeDestino = DataGridViewTrajeto.Rows[DataGridViewTrajeto.Rows.Count - 2].Cells["ColumnCidadeFinal"].Value.ToString();
                                enc.Peso = TextBoxPeso.Text;
                                enc.Preço = TextBoxPreco.Text;
                                enc.Comentários = TextBoxComentarios.Text;
                                enc.SalvarDadosNoBancoDeDados();//Salva a encomenda no banco de dados
                                LimpaTudo();
                                //*************Salvar Trajetório no Banco de Dados***************************
                                CTrajeto Trajeto = new CTrajeto();
                                for (int i = 1; i <= DataGridViewTrajeto.RowCount - 1; i++)
                                {
                                    if (i < DataGridViewTrajeto.RowCount - 1)
                                    {
                                        Trajeto.CodigoDaEncomenda = enc.Codigo;
                                        if (i == 1)
                                        {
                                            //Salvando a cidade de Origem
                                            Trajeto.CodigoDaCidade = Atendente.Cidade;
                                            Trajeto.CodigoDoServico = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnServico"].Value.ToString();
                                            Trajeto.DataDoServico = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnData"].Value.ToString();
                                            Trajeto.QuemPassouOCodigoDeBarrasNoGuiche = this.Atendente.UserName;
                                            Trajeto.QuemPassouOCodigoDeBarrasNoCarro = DBNull.Value.ToString();
                                            if (i == 1)
                                                Trajeto.AEncomendaEstaNoGuiche = true;
                                            else
                                                Trajeto.AEncomendaEstaNoGuiche = false;
                                            Trajeto.AEncomendaEstaNoCarro = false;
                                            Trajeto.SalvarTrajeto();
                                            //Salvando a próxima cidade após a cidade de origem
                                            Trajeto.CodigoDaCidade = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnCidadeFinal"].Value.ToString();
                                            Trajeto.QuemPassouOCodigoDeBarrasNoGuiche = DBNull.Value.ToString();
                                            Trajeto.QuemPassouOCodigoDeBarrasNoCarro = DBNull.Value.ToString();
                                            Trajeto.AEncomendaEstaNoGuiche = false;
                                            Trajeto.AEncomendaEstaNoCarro = false;
                                            Trajeto.SalvarTrajeto();
                                        }
                                        else
                                        {
                                            Trajeto.CodigoDoServico = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnServico"].Value.ToString();
                                            Trajeto.DataDoServico = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnData"].Value.ToString();
                                            Trajeto.CodigoDaCidade = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnCidadeFinal"].Value.ToString();
                                            Trajeto.QuemPassouOCodigoDeBarrasNoGuiche = DBNull.Value.ToString();
                                            Trajeto.QuemPassouOCodigoDeBarrasNoCarro = DBNull.Value.ToString();
                                            Trajeto.AEncomendaEstaNoGuiche = false;
                                            Trajeto.AEncomendaEstaNoCarro = false;
                                            Trajeto.SalvarTrajeto();
                                        }
                                    }
                                    else //Momento de salvar a última cidade
                                    {
                                        Trajeto.CodigoDaCidade = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnCidadeFinal"].Value.ToString();
                                        Trajeto.CodigoDoServico = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnServico"].Value.ToString();
                                        Trajeto.DataDoServico = DataGridViewTrajeto.Rows[i - 1].Cells["ColumnData"].Value.ToString();
                                        Trajeto.QuemPassouOCodigoDeBarrasNoGuiche = "";
                                        Trajeto.AEncomendaEstaNoGuiche = false;
                                        try
                                        {
                                            Trajeto.SalvarTrajeto();
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Existem cidades cidades repetidas no cadastro", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                }
                                MessageBox.Show("Encomenda cadastrada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SIAERGeraCodigoDeBarras FormGeradorCodigoDeBarras = new SIAERGeraCodigoDeBarras(enc.Codigo);
                                FormGeradorCodigoDeBarras.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                if (DataGridViewTrajeto.RowCount == 2)//Não existem cidades intermediárias no caminho
                                {
                                    CEncomenda enc = new CEncomenda();
                                    CCodigoDeBarra bar = new CCodigoDeBarra();
                                    enc = enc.PesquisarUltimaEncomenda();//Pesquisa qual o código da última encomenda cadastrada
                                    String StringCodigoDeBarras = Convert.ToString(enc.Codigo);
                                    StringCodigoDeBarras = StringCodigoDeBarras.Remove(StringCodigoDeBarras.Length - 1, 1);//Elimina o Digito Verificador para os cálculos
                                    enc.Codigo = Convert.ToString(Convert.ToInt64(StringCodigoDeBarras) + 1);//Calcula o código para a encomenda atual sendo cadastrada
                                    bar.Code = enc.Codigo;
                                    bar.InserirChecksumNoValor();
                                    enc.Codigo = bar.Code;
                                    enc.CPFDoRemetente = TextBoxCPFRemetente.Text;
                                    enc.CPFDoDestinatário = TextBoxCPFDestinatario.Text;
                                    enc.CidadeDeOrigem = Atendente.Cidade;//A cidade de origem sempre é a cidade do atendente
                                    enc.CidadeDeDestino = DataGridViewTrajeto.Rows[DataGridViewTrajeto.Rows.Count - 2].Cells["ColumnCidadeFinal"].Value.ToString();
                                    enc.Peso = TextBoxPeso.Text;
                                    enc.Preço = TextBoxPreco.Text;
                                    enc.Comentários = TextBoxComentarios.Text;
                                    enc.SalvarDadosNoBancoDeDados();//Salva a encomenda no banco de dados
                                    LimpaTudo();
                                    //*************Salvar Trajetório no Banco de Dados***************************
                                    CTrajeto Trajeto = new CTrajeto();
                                    Trajeto.CodigoDaEncomenda = enc.Codigo;
                                    //Salvando a cidade de Origem
                                    Trajeto.CodigoDaCidade = Atendente.Cidade;
                                    Trajeto.CodigoDoServico = DataGridViewTrajeto.Rows[0].Cells["ColumnServico"].Value.ToString();
                                    Trajeto.DataDoServico = DataGridViewTrajeto.Rows[0].Cells["ColumnData"].Value.ToString();
                                    Trajeto.QuemPassouOCodigoDeBarrasNoGuiche = this.Atendente.UserName;
                                    Trajeto.QuemPassouOCodigoDeBarrasNoCarro = DBNull.Value.ToString();
                                    Trajeto.AEncomendaEstaNoGuiche = true;
                                    Trajeto.AEncomendaEstaNoCarro = false;
                                    Trajeto.SalvarTrajeto();
                                    //Salvando a próxima cidade após a cidade de origem
                                    Trajeto.CodigoDaCidade = DataGridViewTrajeto.Rows[0].Cells["ColumnCidadeFinal"].Value.ToString();
                                    Trajeto.QuemPassouOCodigoDeBarrasNoGuiche = DBNull.Value.ToString();
                                    Trajeto.QuemPassouOCodigoDeBarrasNoCarro = DBNull.Value.ToString();
                                    Trajeto.AEncomendaEstaNoGuiche = false;
                                    Trajeto.AEncomendaEstaNoCarro = false;
                                    Trajeto.SalvarTrajeto();
                                    MessageBox.Show("Encomenda cadastrada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SIAERGeraCodigoDeBarras FormGeradorCodigoDeBarras = new SIAERGeraCodigoDeBarras(enc.Codigo);
                                    FormGeradorCodigoDeBarras.ShowDialog();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("O trajeto de uma encomenda requer no mínimo uma cidade de saída e uma cidade de destino.", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Número de CPF Destinatário não cadastrado", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        if (ResultadoCPFDestinatario == 1)
                        {
                            MessageBox.Show("Número de CPF Remetente e Destinatário não cadastrados", "Código não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Número de CPF Remetente não cadastrado", "Código não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Número de CPF Destinatário inválido", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (!val.ValidaCPF(this.TextBoxCPFDestinatario.Text))
                {
                    MessageBox.Show("Número de CPF Remetente e Destinatário inválidos", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Número de CPF Remetente inválido", "Falta de Dado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        private void DataGridViewTrajeto_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataGridViewTrajeto.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                if (e.ColumnIndex == 1)
                {
                    ArrayList ListaDeServicos = new ArrayList();
                    Citinerario Servicos = new Citinerario();
                    //Popula a ComboBox de Cidades
                    ArrayList ListaDeCidadesDeSaida = new ArrayList();
                    DataTable Teste = new DataTable();
                    DataGridViewComboBoxCell ComboBoxAux = new DataGridViewComboBoxCell();
                    ListaDeCidadesDeSaida = (Servicos.CidadesDoServico(DataGridViewTrajeto.Rows[e.RowIndex].Cells["ColumnServico"].Value.ToString()));
                    ComboBoxAux.DataSource = ListaDeCidadesDeSaida;
                    ComboBoxAux.DisplayMember = "AtributoDisplayName";
                    ComboBoxAux.ValueMember = "AtributoValue";
                    DataGridViewTrajeto.Rows[e.RowIndex].Cells[e.ColumnIndex] = ComboBoxAux;
                }
                if (e.ColumnIndex == 2)
                {
                    if (DataGridViewTrajeto.Rows[e.RowIndex].Cells["ColumnServico"].Value.ToString() != null)
                    {
                        ArrayList ListaDeServicos = new ArrayList();
                        Citinerario Servicos = new Citinerario();
                        //Popula a ComboBox de Cidades
                        ArrayList ListaDeDatas = new ArrayList();
                        DataTable Teste = new DataTable();
                        DataGridViewComboBoxCell ComboBoxAux = new DataGridViewComboBoxCell();
                        ListaDeDatas = (Servicos.DatasDoServico(DataGridViewTrajeto.Rows[e.RowIndex].Cells["ColumnServico"].Value.ToString()));
                        ComboBoxAux.DataSource = ListaDeDatas;
                        ComboBoxAux.DisplayMember = "AtributoDisplayName";
                        ComboBoxAux.ValueMember = "AtributoValue";
                        DataGridViewTrajeto.Rows[e.RowIndex].Cells[e.ColumnIndex] = ComboBoxAux;
                    }
                }
            }
            catch { }
        }
    }
}
