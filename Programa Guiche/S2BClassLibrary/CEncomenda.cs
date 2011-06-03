using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Collections;

namespace SIAERClassLibrary
{
    public class CEncomenda
    {
        #region Atributos
        private string _codigo;
        private string _cpfremetente;
        private string _cpfdestinatario;
        private string _cidadeorigem;
        private string _cidadedestino;
        private string _peso;
        private string _preco;
        private string _comentarios;
        private bool persisted;
        private bool _EstaNoCarro;
        private bool _DesceuDoCarro;

        #endregion

        #region Stored Procedures
        private const string SPINSERT = "InserirEncomenda";
        private const string SPUPDATE = "AltUsuario";
        private const string SPDELETE = "DelUsuario";
        private const string SPSELECT = "SelLogin";
        private const string SPSELECTULTIMOCODIGO = "SelCodigoUltimaEncomenda";
        #endregion

        #region Métodos de Leitura e Escrita
        public bool DesceuDoCarro
        {
            get { return this._DesceuDoCarro; }
            set { this._DesceuDoCarro = value; }
        }
        public string Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }
        public bool EstaNoCarro
        {
            get { return this._EstaNoCarro; }
            set { this._EstaNoCarro = value; }
        }
        public string CPFDoRemetente
        {
            get { return this._cpfremetente; }
            set { this._cpfremetente = value; }
        }
        public string CPFDoDestinatário
        {
            get { return this._cpfdestinatario; }
            set { this._cpfdestinatario = value; }
        }
        public string CidadeDeOrigem
        {
            get { return this._cidadeorigem; }
            set { this._cidadeorigem = value; }
        }
        public string CidadeDeDestino
        {
            get { return this._cidadedestino; }
            set { this._cidadedestino = value; }
        }
        public string Peso
        {
            get { return this._peso; }
            set { this._peso = value; }
        }
        public string Preço
        {
            get { return this._preco; }
            set { this._preco = value; }
        }
        public string Comentários
        {
            get { return this._comentarios; }
            set { this._comentarios = value; }
        }
        /*
        public string HoraDeCadastro
        {
            get { return this._horadecadastro; }
            set { this._horadecadastro = value; }
        }
        public string DataDeCadastro
        {
            get { return this._datadecadastro; }
            set { this._datadecadastro = value; }
        }*/
        public bool Persisted
        {
            get { return this.persisted; }
            set { this.persisted = value; }
        }
        #endregion

        #region Construtores
        public CEncomenda()
        {
            this.persisted = false;
        }

        public CEncomenda(string codigo, string cpfremetente, string cpfdestinatario, string cidadeorigem, string cidadedestino, string peso, string preco, string comentarios)
        {
            this._codigo = codigo;
            this._cpfremetente = cpfremetente;
            this._cpfdestinatario = cpfdestinatario;
            this._cidadeorigem = cidadeorigem;
            this._cidadedestino = cidadedestino;
            this._peso = peso;
            this._preco = preco;
            this._comentarios = comentarios;
            this.persisted = true;
        }
        public CEncomenda(string codigo, string cidadeorigem, string cidadedestino, bool EstaNoCarro)
        {
            this._codigo = codigo;
            this._cidadeorigem = cidadeorigem;
            this._cidadedestino = cidadedestino;
            this._EstaNoCarro = EstaNoCarro;
            this._DesceuDoCarro = false;
            this.persisted = true;
        }
        public CEncomenda(string codigo, string cidadeorigem, string cidadedestino, bool EstaNoCarro,bool DesceuDoCarro)
        {
            this._codigo = codigo;
            this._cidadeorigem = cidadeorigem;
            this._cidadedestino = cidadedestino;
            this._EstaNoCarro = EstaNoCarro;
            this._DesceuDoCarro = DesceuDoCarro;
            this.persisted = true;
        }

        #endregion

        #region Métodos para conexão com o Banco de Dados
        private void Inserir()
        {
            SqlParameter[] parms = CriarParametrosParaRecebimentoDosDados();
            this.SetParameters(parms);

            using (SqlConnection conn = new SqlConnection(DataBase.CONN_STRING))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = DataBase.ExecuteNonQueryCmd(trans, CommandType.StoredProcedure, SPINSERT, parms);

                        this._codigo = Convert.ToString(cmd.Parameters["@codigo"].Value);//variáveis que serão criadas na Stored Procedure
                        this._cpfremetente = Convert.ToString(cmd.Parameters["@cpfremetente"].Value);
                        this._cpfdestinatario = Convert.ToString(cmd.Parameters["@cpfdestinatario"].Value);
                        this._cidadeorigem = Convert.ToString(cmd.Parameters["@cidadeorigem"].Value);
                        this._cidadedestino = Convert.ToString(cmd.Parameters["@cidadedestino"].Value);
                        //this._horadecadastro = Convert.ToString(cmd.Parameters["@horadecadastro"].Value);
                        //this._datadecadastro = Convert.ToString(cmd.Parameters["@datadecadastro"].Value);
                        this._peso = Convert.ToString(cmd.Parameters["@peso"].Value);
                        this._preco = Convert.ToString(cmd.Parameters["@preco"].Value);
                        this._comentarios = Convert.ToString(cmd.Parameters["@comentarios"].Value);                        
                        this.persisted = true;
                        cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }
        private void Update()
        {
            SqlParameter[] parms = CriarParametrosParaRecebimentoDosDados();
            this.SetParameters(parms);

            using (SqlConnection conn = new SqlConnection(DataBase.CONN_STRING))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = DataBase.ExecuteNonQueryCmd(trans, CommandType.StoredProcedure, SPUPDATE, parms);
                        this.persisted = true;
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }
        public static void Delete(int id)
        {
            SqlParameter[] parms = { new SqlParameter("@codigo", DbType.Int32) };
            parms[0].Value = id;

            using (SqlConnection conn = new SqlConnection(DataBase.CONN_STRING))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = DataBase.ExecuteNonQueryCmd(trans, CommandType.StoredProcedure, SPDELETE, parms);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw (ex);
                    }
                }
            }
        }
        public void SalvarDadosNoBancoDeDados()
        {
            if (persisted)
            {
                this.Update();
            }
            else
            {
                this.Inserir();
            }
        }
        public SqlDataReader CarregarDataReader(string cpf)
        {
            SqlParameter[] parms = CriarParametrosParaRecebimentoDosDados(); 
       
                parms[0].Value = cpf;
                parms[1].Value = DBNull.Value;
                parms[2].Value = DBNull.Value;           

            return DataBase.ExecuteReader(CommandType.StoredProcedure, SPSELECT, parms);
        }
        public CEncomenda CarregarUmObjeto(string cpf)
        {
            SqlDataReader dr = CarregarDataReader(cpf);
            CEncomenda objUsuario = new CEncomenda();
            try
            {
                SetInstance(dr, objUsuario);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return objUsuario;
        }
        public void CompleteObject()
        {
            SqlDataReader dr = CarregarDataReader(this._codigo);
            try
            {
                SetInstance(dr, this);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private SqlParameter[] CriarParametrosParaRecebimentoDosDados()
        {
            SqlParameter[] parms = new SqlParameter[]{
                /*00*/ new SqlParameter("@codigo", SqlDbType.VarChar,50),
                /*01*/ new SqlParameter("@cpfremetente",SqlDbType.VarChar,50),
                /*02*/ new SqlParameter("@cpfdestinatario",SqlDbType.VarChar, 50),
                /*03*/ new SqlParameter("@cidadeorigem", SqlDbType.VarChar,50),
                /*04*/ new SqlParameter("@cidadedestino", SqlDbType.VarChar,50),
                /*05*/ //new SqlParameter("@horadecadastro", SqlDbType.VarChar,50),
                /*06*/ //new SqlParameter("@datadecadastro", SqlDbType.VarChar,50),
                /*07*/ new SqlParameter("@peso", SqlDbType.VarChar,50),
                /*08*/ new SqlParameter("@preco", SqlDbType.VarChar,50),
                /*09*/ new SqlParameter("@comentarios", SqlDbType.VarChar,100)
            };

            return parms;
        }
        private void SetParameters(SqlParameter[] parms)
        {
            parms[0].Value = this._codigo;
            parms[1].Value = this._cpfremetente;
            parms[2].Value = this._cpfdestinatario;
            parms[3].Value = this._cidadeorigem;
            parms[4].Value = this._cidadedestino;
            //parms[5].Value = this._horadecadastro;
            //parms[6].Value = this._datadecadastro;
            parms[5].Value = this._peso;
            parms[6].Value = this._preco;
            parms[7].Value = this._comentarios;
        }
        private static bool SetInstance(SqlDataReader dr, CEncomenda objUsuario)
        {
            try
            {
                if (dr.Read())
                {
                    objUsuario._codigo = Convert.ToString(dr["codigodaencomenda"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._cpfremetente = Convert.ToString(dr["cpfdoremetente"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._cpfdestinatario = Convert.ToString(dr["cpfdodestinatario"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._cidadeorigem = Convert.ToString(dr["CodigoDaCidadeDeOrigem"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._cidadedestino = Convert.ToString(dr["CodigoDaCidadeDeDestino"]);//Tem que ter o mesmo nome da coluna
                    //objUsuario._cidadedestino = Convert.ToString(dr["HoraDeCadastroDaEncomenda"]);//Tem que ter o mesmo nome da coluna
                    //objUsuario._cidadedestino = Convert.ToString(dr["DataDeCadastroDaEncomenda"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._peso = Convert.ToString(dr["peso"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._preco = Convert.ToString(dr["preco"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._comentarios = Convert.ToString(dr["descricaodaencomenda"]);//Tem que ter o mesmo nome da coluna

                    objUsuario.persisted = true;
                    return true;
                }
                else//Caso não encontre um nome de usuário válido entre aqui
                {
                    objUsuario.persisted = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                objUsuario = new CEncomenda();
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
        public CEncomenda PesquisarUltimaEncomenda()
        {
            //SqlParameter[] parms = CriarParametrosParaRecebimentoDosDados();
            SqlDataReader dr = DataBase.ExecuteReader(CommandType.StoredProcedure, SPSELECTULTIMOCODIGO);
            CEncomenda objUsuario = new CEncomenda();
            try
            {
                try
                {
                    if (dr.Read())
                    {
                        objUsuario._codigo = Convert.ToString(dr["codigodaencomenda"]);//Tem que ter o mesmo nome da coluna
                        objUsuario._cpfremetente = Convert.ToString(dr["cpfdoremetente"]);//Tem que ter o mesmo nome da coluna
                        objUsuario._cpfdestinatario = Convert.ToString(dr["cpfdodestinatario"]);//Tem que ter o mesmo nome da coluna
                        objUsuario._cidadeorigem = Convert.ToString(dr["CodigoDaCidadeDeOrigem"]);//Tem que ter o mesmo nome da coluna
                        objUsuario._cidadedestino = Convert.ToString(dr["CodigoDaCidadeDeDestino"]);//Tem que ter o mesmo nome da coluna
                        objUsuario._peso = Convert.ToString(dr["peso"]);//Tem que ter o mesmo nome da coluna
                        objUsuario._preco = Convert.ToString(dr["preco"]);//Tem que ter o mesmo nome da coluna
                        objUsuario._comentarios = Convert.ToString(dr["descricaodaencomenda"]);//Tem que ter o mesmo nome da coluna
                    }
                }
                catch (Exception ex)
                {
                    objUsuario = new CEncomenda();
                    throw (ex);
                }
                finally
                {
                    if (!dr.IsClosed)
                        dr.Close();
                };
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return objUsuario;
        }
        public ArrayList RetornaTodasEncomendasEmGuiche(string nomedacidade)
        {
            ArrayList ArrayEncomendas = new ArrayList();
            using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
            {
                SqlCommand command = null;
                using (command = new SqlCommand("RetornaTodasEncomendasEmGuiche", connection))
                {
                    //Tipo de Command, dizendo que é um query
                    command.CommandType = CommandType.StoredProcedure;
                    //Cria Parametros para inserir na query do SqlCommand
                    command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                    command.Parameters["@nomedacidade"].Value = nomedacidade;

                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        ArrayEncomendas.Add(dr["CodigoDaEncomenda"]);
                    }
                    connection.Close();
                }
            }
            return ArrayEncomendas;
        }
        public ArrayList RetornaEncomendasEmGuicheDeDestino(string nomedacidade)
        {
            ArrayList ArrayEncomendas = new ArrayList();
            using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
            {
                SqlCommand command = null;
                using (command = new SqlCommand("RetornaEncomendasEmGuicheDeDestino", connection))
                {
                    //Tipo de Command, dizendo que é um query
                    command.CommandType = CommandType.StoredProcedure;
                    //Cria Parametros para inserir na query do SqlCommand
                    command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                    command.Parameters["@nomedacidade"].Value = nomedacidade;

                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        ArrayEncomendas.Add(dr["CodigoDaEncomenda"]);
                    }
                    connection.Close();
                }
            }
            return ArrayEncomendas;
        }
        public ArrayList RetornaEncomendasAChegarEmGuiche(string nomedacidade)
        {
            ArrayList ArrayEncomendas = new ArrayList();
            using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
            {
                SqlCommand command = null;
                using (command = new SqlCommand("RetornaEncomendasAChegarEmGuiche", connection))
                {
                    //Tipo de Command, dizendo que é um query
                    command.CommandType = CommandType.StoredProcedure;
                    //Cria Parametros para inserir na query do SqlCommand
                    command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                    command.Parameters["@nomedacidade"].Value = nomedacidade;

                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        ArrayEncomendas.Add(dr["CodigoDaEncomenda"]);
                    }
                    connection.Close();
                }
            }
            return ArrayEncomendas;
        }
        
        #endregion
    }
}
