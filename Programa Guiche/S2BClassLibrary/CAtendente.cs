using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SIAERClassLibrary
{
    public partial class CAtendente
    {
        #region Atributos
        private string _username;
        private string _cidade;
        private string _senha;
        private bool _ativo;

        private bool persisted;

        #endregion

        #region Stored Procedures
        private const string SPINSERT = "InsUsuario";
        private const string SPUPDATE = "AltUsuario";
        private const string SPDELETE = "DelUsuario";
        private const string SPSELECT = "SelLogin";
        #endregion

        #region Métodos de Leitura e Escrita
        public string UserName
        {
            get { return this._username; }
            set { this._username = value; }
        }
        public string Cidade
        {
            get { return this._cidade; }
            set { this._cidade = value; }
        }
        public string Senha
        {
            get { return this._senha; }
            set { this._senha = value; }
        }
        public bool Ativo
        {
            get { return this._ativo; }
            set { this._ativo = value; }
        }
        public bool Persisted
        {
            get { return this.persisted; }
            set { this.persisted = value; }
        }
        #endregion

        #region Construtores
        public CAtendente()
        {
            this.persisted = false;
        }
        public CAtendente (string username)
        {
            this._username = username;
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
                        this._username = Convert.ToString(cmd.Parameters["@username"].Value);
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
            SqlParameter[] parms = { new SqlParameter("@id", DbType.Int32) };
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
        public SqlDataReader CarregarDataReader(string username)
        {
            SqlParameter[] parms = CriarParametrosParaRecebimentoDosDados(); 
       
                parms[0].Value = username;
                parms[1].Value = DBNull.Value;
                parms[2].Value = DBNull.Value;           

            return DataBase.ExecuteReader(CommandType.StoredProcedure, SPSELECT, parms);
        }
        public CAtendente CarregarUmObjeto(string username)
        {
            SqlDataReader dr = CarregarDataReader(username);
            CAtendente objUsuario = new CAtendente();
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
            SqlDataReader dr = CarregarDataReader(this._username);
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
                /*00*/ new SqlParameter("@username", SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*01*/ new SqlParameter("@city_name",SqlDbType.VarChar,50),//Tem que ter o mesmo nome da coluna
                /*02*/ new SqlParameter("@userpassword",SqlDbType.VarChar, 50)//Tem que ter o mesmo nome da coluna
            };

            return parms;
        }
        private void SetParameters(SqlParameter[] parms)
        {
            parms[0].Value = this._username;
            parms[1].Value = this._cidade;
            parms[2].Value = this._senha;
        }
        public int VerificaLogin(CAtendente User)
        {
            //return 0 -> sucesso na verificação de login
            //return 1 -> problema de username
            //return 2 -> problema de senha
            CAtendente objUsuario = new CAtendente();
            objUsuario = User.CarregarUmObjeto(User.UserName.ToString());
            User._cidade = objUsuario._cidade;
            if (objUsuario.persisted == true)
            {
                if (User.UserName.ToString() == objUsuario.UserName.ToString() && objUsuario.Senha.ToString() == User.Senha.ToString())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else 
            {
                return 1;
            }
            
            
        }
        private static bool SetInstance(SqlDataReader dr, CAtendente objUsuario)
        {
            try
            {
                if (dr.Read())
                {
                    objUsuario._username = Convert.ToString(dr["username"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._cidade = Convert.ToString(dr["city_name"]);//Tem que ter o mesmo nome da coluna
                    objUsuario._senha = Convert.ToString(dr["userpassword"]);//Tem que ter o mesmo nome da coluna
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
                objUsuario = new CAtendente();
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
        #endregion
    }
}
