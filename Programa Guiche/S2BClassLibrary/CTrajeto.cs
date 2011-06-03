using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SIAERClassLibrary
{
    public class CTrajeto
    {
        #region Atributos
        private string _codigodaencomenda;
        private string _codigodoservico;
        private string _datadoservico;
        private string _codigodacidade;
        private string _codigodocarro;
        private string _quempassouocodigodebarrasnoguiche;
        private string _quempassouocodigodebarrasnocarro;
        private string _horaemqueocodigodebarrasfoipassadonoguiche;
        private string _horaemqueocodigodebarrasfoipassadonocarro;
        private bool _aencomendaestanoguiche;
        private bool _aencomendaestanocarro;

        #endregion

        #region Stored Procedures
        private const string SPINSERT = "InserirTrajeto";
        private const string SPUPDATE = "AltUsuario";
        private const string SPDELETE = "DelUsuario";
        private const string SPSELECT = "SelLogin";
        #endregion

        #region Métodos de Leitura e Escrita
        public string CodigoDaEncomenda
        {
            get { return this._codigodaencomenda; }
            set { this._codigodaencomenda = value; }
        }
        public string CodigoDoServico
        {
            get { return this._codigodoservico; }
            set { this._codigodoservico = value; }
        }
        public string DataDoServico
        {
            get { return this._datadoservico; }
            set { this._datadoservico = value; }
        }
        public string CodigoDaCidade
        {
            get { return this._codigodacidade; }
            set { this._codigodacidade = value; }
        }
        public string CodigoDoCarro
        {
            get { return this._codigodocarro; }
            set { this._codigodocarro = value; }
        }
        public string QuemPassouOCodigoDeBarrasNoGuiche
        {
            get { return this._quempassouocodigodebarrasnoguiche; }
            set { this._quempassouocodigodebarrasnoguiche = value; }
        }
        public string QuemPassouOCodigoDeBarrasNoCarro
        {
            get { return this._quempassouocodigodebarrasnocarro; }
            set { this._quempassouocodigodebarrasnocarro = value; }
        }
        public string HoraEmQueOCodigoDeBarrasFoiPassadoNoGuiche
        {
            get { return this._horaemqueocodigodebarrasfoipassadonoguiche; }
            set { this._horaemqueocodigodebarrasfoipassadonoguiche = value; }
        }
        public string HoraEmQueOCodigoDeBarrasFoiPassadoNoCarro
        {
            get { return this._horaemqueocodigodebarrasfoipassadonocarro; }
            set { this._horaemqueocodigodebarrasfoipassadonocarro = value; }
        }
          public bool AEncomendaEstaNoGuiche
        {
            get { return this._aencomendaestanoguiche; }
            set { this._aencomendaestanoguiche = value; }
        }
        public bool AEncomendaEstaNoCarro
        {
            get { return this._aencomendaestanocarro; }
            set { this._aencomendaestanocarro = value; }
        }
        #endregion

        #region Construtores
        public CTrajeto()
        {}

        public CTrajeto(string codigodaencomenda, string codigodacidade, string codigodocarro, string quempassouocodigodebarrasnoguiche, string quempassouocodigodebarrasnocarro, string horaemqueocodigodebarrasfoipassadonoguiche, string horaemqueocodigodebarrasfoipassadonocarro,bool aencomendaestanoguiche,bool aencomendaestanocarro)
        {
            this._codigodaencomenda = codigodaencomenda;
            this._codigodacidade = codigodacidade;
            this._codigodocarro = codigodocarro;
            this._quempassouocodigodebarrasnoguiche = quempassouocodigodebarrasnoguiche;
            this._quempassouocodigodebarrasnocarro = quempassouocodigodebarrasnocarro;
            this._horaemqueocodigodebarrasfoipassadonoguiche = horaemqueocodigodebarrasfoipassadonoguiche;
            this._horaemqueocodigodebarrasfoipassadonocarro = horaemqueocodigodebarrasfoipassadonocarro;
            this._aencomendaestanoguiche = aencomendaestanoguiche;
            this._aencomendaestanocarro = aencomendaestanocarro;
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

                        this._codigodaencomenda = Convert.ToString(cmd.Parameters["@codigodaencomenda"].Value);//variáveis que serão criadas na Stored Procedure
                        this._codigodacidade = Convert.ToString(cmd.Parameters["@cidade"].Value);
                        this._codigodocarro = Convert.ToString(cmd.Parameters["@codigodocarro"].Value);
                        this._quempassouocodigodebarrasnoguiche = Convert.ToString(cmd.Parameters["@quempassouocodigodebarrasnoguiche"].Value);
                        this._quempassouocodigodebarrasnocarro = Convert.ToString(cmd.Parameters["@quempassouocodigodebarrasnocarro"].Value);
                        this._aencomendaestanoguiche = Convert.ToBoolean(cmd.Parameters["@aencomendaestanoguiche"].Value); ;
                        this._aencomendaestanocarro = Convert.ToBoolean(cmd.Parameters["@aencomendaestanocarro"].Value);
                        cmd.Parameters.Clear();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        //throw (ex);
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
                this.Inserir();
        }
        public SqlDataReader CarregarDataReader(string cpf)
        {
            SqlParameter[] parms = CriarParametrosParaRecebimentoDosDados();

            parms[0].Value = cpf;
            parms[1].Value = DBNull.Value;
            parms[2].Value = DBNull.Value;

            return DataBase.ExecuteReader(CommandType.StoredProcedure, SPSELECT, parms);
        }
        public CTrajeto CarregarUmObjeto(string cpf)
        {
            SqlDataReader dr = CarregarDataReader(cpf);
            CTrajeto objUsuario = new CTrajeto();
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
            SqlDataReader dr = CarregarDataReader(this.CodigoDaEncomenda);
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
                /*00*/ new SqlParameter("@codigodaencomenda", SqlDbType.VarChar,50),
                /*01*/ new SqlParameter("@cidade",SqlDbType.VarChar,50),
                /*02*/ new SqlParameter("@codigodocarro",SqlDbType.VarChar, 50),
                /*03*/ new SqlParameter("@quempassouocodigodebarrasnoguiche", SqlDbType.VarChar,50),
                /*04*/ new SqlParameter("@quempassouocodigodebarrasnocarro", SqlDbType.VarChar,50),
                /*05*/ new SqlParameter("@aencomendaestanoguiche", SqlDbType.Bit),
                /*06*/ new SqlParameter("@aencomendaestanocarro", SqlDbType.Bit)
            };

            return parms;
        }
        private void SetParameters(SqlParameter[] parms)
        {
            parms[0].Value = this._codigodaencomenda;
            parms[1].Value = this._codigodacidade;
            parms[2].Value = this._codigodocarro;
            parms[3].Value = this._quempassouocodigodebarrasnoguiche;
            parms[4].Value = this._quempassouocodigodebarrasnocarro;
            parms[5].Value = this._aencomendaestanoguiche;
            parms[6].Value = this._aencomendaestanocarro;
        }
        private static bool SetInstance(SqlDataReader dr, CTrajeto objUsuario)
        {
            try
            {
                if (dr.Read())
                {
                    objUsuario._codigodaencomenda = Convert.ToString(dr["codigodaencomenda"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._codigodacidade = Convert.ToString(dr["codigodacidade"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._codigodocarro = Convert.ToString(dr["codigodocarro"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._quempassouocodigodebarrasnoguiche = Convert.ToString(dr["quempassouocodigodebarrasnoguiche"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._quempassouocodigodebarrasnocarro = Convert.ToString(dr["quempassouocodigodebarrasnocarro"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._horaemqueocodigodebarrasfoipassadonoguiche = Convert.ToString(dr["horaemqueocodigodebarrasfoipassadonoguiche"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._horaemqueocodigodebarrasfoipassadonocarro = Convert.ToString(dr["horaemqueocodigodebarrasfoipassadonocarro"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._aencomendaestanoguiche = Convert.ToBoolean(dr["aencomendaestanoguiche"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._aencomendaestanocarro = Convert.ToBoolean(dr["aencomendaestanocarro"]);//Tem que ter o mesmo nome da coluna
                    return true;
                }
                else//Caso não encontre um nome de usuário válido entre aqui
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objUsuario = new CTrajeto();
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
        public void SalvarTrajeto()
        {
            try
            {
                //Conexão
                using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                {
                    //Comando 
                    SqlCommand command = null;
                    using (command = new SqlCommand("InserirTrajetoEncomenda", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                        //@codigoencomenda
                        command.Parameters.Add("@codigodaencomenda", SqlDbType.VarChar, 20);
                        command.Parameters["@codigodaencomenda"].Value = _codigodaencomenda;
                        //@codigodoservico
                        command.Parameters.Add("@codigodoservico", SqlDbType.VarChar, 20);
                        command.Parameters["@codigodoservico"].Value = _codigodoservico;
                        //@datadoservico
                        command.Parameters.Add("@datadoservico", SqlDbType.VarChar, 20);
                        command.Parameters["@datadoservico"].Value = _datadoservico;
                        //@cidade
                        command.Parameters.Add("@cidade", SqlDbType.VarChar, 20);
                        command.Parameters["@cidade"].Value = _codigodacidade;
                        //@quempassouocodigodebarrasnoguiche
                        command.Parameters.Add("@quempassouocodigodebarrasnoguiche", SqlDbType.VarChar, 20);
                        if (_quempassouocodigodebarrasnoguiche == String.Empty)
                            command.Parameters["@quempassouocodigodebarrasnoguiche"].Value = DBNull.Value;
                        else
                            command.Parameters["@quempassouocodigodebarrasnoguiche"].Value = _quempassouocodigodebarrasnoguiche;
                        //@quempassouocodigodebarrasnocarro
                        command.Parameters.Add("@quempassouocodigodebarrasnocarro", SqlDbType.VarChar, 20);
                        if (_quempassouocodigodebarrasnocarro == String.Empty)
                            command.Parameters["@quempassouocodigodebarrasnocarro"].Value = DBNull.Value;
                        else               
                            command.Parameters["@quempassouocodigodebarrasnocarro"].Value = _quempassouocodigodebarrasnocarro;
                        //@aencomendaestanoguiche
                        command.Parameters.Add("@aencomendaestanoguiche", SqlDbType.Bit);
                        command.Parameters["@aencomendaestanoguiche"].Value = _aencomendaestanoguiche;
                        //@aencomendaestanocarro
                        command.Parameters.Add("@aencomendaestanocarro", SqlDbType.Bit);
                        command.Parameters["@aencomendaestanocarro"].Value = _aencomendaestanocarro;

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
