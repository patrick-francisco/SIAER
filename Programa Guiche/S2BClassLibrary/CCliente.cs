using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SIAERClassLibrary
{
    public class CCliente
    {
        
        #region Atributos
        private string _nome;
        private string _datadenascimento;
        private string _rg;
        private string _cpf;
        private string _endereco;
        private string _bairro;
        private string _cep;
        private string _cidade;
        private string _estado;
        private string _telefone;
        private string _celular;


        private bool persisted;

        #endregion

        #region Stored Procedures
        private const string SPINSERT = "InserirCliente";
        private const string SPUPDATE = "AltUsuario";
        private const string SPDELETE = "DelUsuario";
        private const string SPSELECT = "SelLogin";
        #endregion

        #region Métodos de Leitura e Escrita
        public string Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }
        public string DataDeNascimento
        {
            get { return this._datadenascimento; }
            set { this._datadenascimento = value; }
        }
        public string RG
        {
            get { return this._rg; }
            set { this._rg = value; }
        }
        public string CPF
        {
            get { return this._cpf; }
            set { this._cpf = value; }
        }
        public string Endereco
        {
            get { return this._endereco; }
            set { this._endereco = value; }
        }
        public string Bairro
        {
            get { return this._bairro; }
            set { this._bairro = value; }
        }
        public string CEP
        {
            get { return this._cep; }
            set { this._cep = value; }
        }
        public string Cidade
        {
            get { return this._cidade; }
            set { this._cidade = value; }
        }
        public string Estado
        {
            get { return this._estado; }
            set { this._estado = value; }
        }
        public string Telefone
        {
            get { return this._telefone; }
            set { this._telefone = value; }
        }
        public string Celular
        {
            get { return this._celular; }
            set { this._celular = value; }
        }
        public bool Persisted
        {
            get { return this.persisted; }
            set { this.persisted = value; }
        }
        #endregion

        #region Construtores
        public CCliente()
        {
            this.persisted = false;
        }
        
        public CCliente (string nome,string datadenascimento,string rg,string cpf,string endereco,string bairro,string cidade,string estado,string telefone,string celular,string cep)
        {
            this._nome = nome;
            this._datadenascimento = datadenascimento;
            this._rg = rg;
            this._cpf = cpf;
            this._endereco = endereco;
            this._bairro = bairro;
            this._cidade = cidade;
            this._estado = estado;
            this._telefone = telefone;
            this._celular = celular;
            this._cep = cep;
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
                        this._cpf = Convert.ToString(cmd.Parameters["@cpf"].Value);
                        this._nome = Convert.ToString(cmd.Parameters["@nome"].Value);
                        this._datadenascimento = Convert.ToString(cmd.Parameters["@datadenascimento"].Value);
                        this._rg = Convert.ToString(cmd.Parameters["@rg"].Value);
                        this._endereco = Convert.ToString(cmd.Parameters["@endereco"].Value);
                        this._bairro = Convert.ToString(cmd.Parameters["@bairro"].Value);
                        this._cep = Convert.ToString(cmd.Parameters["@cep"].Value);
                        this._cidade = Convert.ToString(cmd.Parameters["@cidade"].Value);
                        this._estado = Convert.ToString(cmd.Parameters["@estado"].Value);
                        this._telefone = Convert.ToString(cmd.Parameters["@telefone"].Value);
                        this._celular = Convert.ToString(cmd.Parameters["@celular"].Value);
                        
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
            SqlParameter[] parms = { new SqlParameter("@cpf", DbType.Int32) };
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
        public CCliente CarregarUmObjeto(string cpf)
        {
            SqlDataReader dr = CarregarDataReader(cpf);
            CCliente objUsuario = new CCliente();
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
            SqlDataReader dr = CarregarDataReader(this._cpf);
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
                /*00*/ new SqlParameter("@cpf", SqlDbType.VarChar,20),//Tem que ter o mesmo nome da coluna
                /*01*/ new SqlParameter("@nome",SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*02*/ new SqlParameter("@datadenascimento",SqlDbType.VarChar, 50),//Tem que ter o mesmo nome da coluna
                /*03*/ new SqlParameter("@rg", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*04*/ new SqlParameter("@endereco", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*05*/ new SqlParameter("@bairro", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*06*/ new SqlParameter("@cep", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*07*/ new SqlParameter("@cidade", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*08*/ new SqlParameter("@estado", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*09*/ new SqlParameter("@telefone", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*10*/ new SqlParameter("@celular", SqlDbType.VarChar,50)//Tem que ter o mesmo nome da coluna
            };

            return parms;
        }
        private void SetParameters(SqlParameter[] parms)
        {
            parms[0].Value = this._cpf;
            parms[1].Value = this._nome;
            parms[2].Value = this._datadenascimento;
            parms[3].Value = this._rg;
            parms[4].Value = this._endereco;
            parms[5].Value = this._bairro;
            parms[6].Value = this._cep;
            parms[7].Value = this._cidade;
            parms[8].Value = this._estado;
            parms[9].Value = this._telefone;
            parms[10].Value = this._celular;
        }
        private static bool SetInstance(SqlDataReader dr, CCliente objUsuario)
        {
            try
            {
                if (dr.Read())
                {
                    objUsuario._cpf = Convert.ToString(dr["cpf"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._nome = Convert.ToString(dr["nome"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._datadenascimento = Convert.ToString(dr["datadenascimento"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._rg = Convert.ToString(dr["rg"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._endereco = Convert.ToString(dr["endereco"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._bairro = Convert.ToString(dr["bairro"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._cep = Convert.ToString(dr["cep"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._cidade = Convert.ToString(dr["cidade"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._estado = Convert.ToString(dr["estado"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._telefone = Convert.ToString(dr["telefone"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._celular = Convert.ToString(dr["celular"]);//Tem que ter o mesmo nome da coluna

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
                objUsuario = new CCliente();
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
        public int ValidaCPFCliente(string cpf)
        { 
            int Resultado;
            using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
            {
                //Comando 
                SqlCommand command = null;
                using (command = new SqlCommand("VerificaValidadeCPF", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                    command.Parameters.Add("@cpf", SqlDbType.VarChar, 20);
                    command.Parameters["@cpf"].Value = cpf;
                    command.Parameters.Add("@Resultado", SqlDbType.Int);
                    command.Parameters["@Resultado"].Direction = ParameterDirection.Output;
                    //Configura os parâmetros.
                    //daGetRecords.SelectCommand = command;
                    connection.Open();
                    //@Resultado:
                    // 0-> CPF Válido
                    // 1-> CPF Inválido
                    command.ExecuteNonQuery();
                    Resultado = (int)command.Parameters["@Resultado"].Value;
                    connection.Close();
                }
            }
            return Resultado;
        }
        #endregion
    }
}
