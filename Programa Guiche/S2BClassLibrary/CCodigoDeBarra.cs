using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SIAERClassLibrary
{
    public class CCodigoDeBarra
    {
        #region Atributos
        private string _codigo;
        

        private bool persisted;
        #endregion

        #region Métodos de Leitura e Escrita

        public string Code
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        #endregion

        #region Stored Procedures
        private const string SPINSERT = "InserirCodigoDeBarras";
        private const string SPUPDATE = "AltBarCode";
        private const string SPDELETE = "DelBarCode";
        private const string SPSELECT = "InsBarcode";
        #endregion

        #region Construtores
        public CCodigoDeBarra()
        {
            this.persisted = false;
        }
        public CCodigoDeBarra(string code)
        {
            this._codigo = code;
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
                        this._codigo = Convert.ToString(cmd.Parameters["Codigo"].Value);//Nome da Coluna
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
        public static void Delete(string CodigoQueDesejaDeletar)
        {
            SqlParameter[] parms = { new SqlParameter("@codigo", DbType.String) };//Nome do Parametro a ser enviado
            parms[0].Value = CodigoQueDesejaDeletar;

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
        private static SqlDataReader CarregarDataReader(string code)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@codigo", SqlDbType.VarChar, 50) };//nome do parametro a ser enviado
            parms[0].Value = code;

            return DataBase.ExecuteReader(CommandType.StoredProcedure, SPSELECT, parms);
        }
        public static CCodigoDeBarra CarregarUmObjeto(string code)
        {
            SqlDataReader dr = CarregarDataReader(code);
            CCodigoDeBarra objBarCode = new CCodigoDeBarra();
            try
            {
                SetInstance(dr, objBarCode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return objBarCode;
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
        private static SqlParameter[] CriarParametrosParaRecebimentoDosDados()
        {
            SqlParameter[] parms = new SqlParameter[]{
                /*00*/ new SqlParameter("Codigo", SqlDbType.VarChar, 50)//Nome da coluna
            };

            return parms;
        }
        private void SetParameters(SqlParameter[] parms)
        {
            parms[0].Value = this._codigo;
            //if (this._codigo <= 0)
               // parms[0].Direction = ParameterDirection.Output;
        }
        private static bool SetInstance(SqlDataReader dr, CCodigoDeBarra objBarCode)
        {
            try
            {
                if (dr.Read())
                {
                    objBarCode._codigo = Convert.ToString(dr["Codigo"]);//Nome da coluna
                    objBarCode.persisted = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objBarCode = new CCodigoDeBarra();
                throw (ex);
            }
            finally
            {
                if (!dr.IsClosed)
                    dr.Close();
            }
        }
        #endregion

        #region Validacao do Código de Barras
        /// <summary>
        /// Método que valida um código de barra de protocolo EAN-13, calculando o
        /// Check Digit do código lido por um leitor de código de barras .
        /// O Método ValidarCodigoDeBarras() não exige parâmetros de entrada
        /// mas retorna dois possíveis valores, 0 e 1.
        /// Significado:
        /// 0 -> O código enviado pelo leitor foi validado com sucesso
        /// 1 -> O código enviado pelo leitor não está correto
        /// </summary>
        /// <returns></returns>
        public int ValidarCodigoDeBarras()
        {
            int Resultado = 0;//Recebe 0 se o código de barras for verídico
                              // Recebe 1 se o código de barras apresentar falhas
            String StringCodigoDeBarras = Convert.ToString(_codigo);
            try
            {
                StringCodigoDeBarras = StringCodigoDeBarras.Remove(StringCodigoDeBarras.Length - 2, 2);//remove o /r e o /n do vetor

            }
            catch
            {
                return 1;
            }
            if (StringCodigoDeBarras[0] == 'D')//Protocolo EAN-13
            {
                StringCodigoDeBarras = StringCodigoDeBarras.Remove(0, 1);//Remove a primeira letra que indica o tipo de protocolo
                _codigo = StringCodigoDeBarras;
                int CheckDigitEnviadoPeloLeitor = 0;
                int CheckDigitCalculado = 0;
                int ProcuraMultiplicador = 0;
                int Soma1 = 0;
                int ResultadoSoma1MultiplicadoPor3 = 0;
                int Soma2 = 0;
                int SomaTotal = 0;
                CheckDigitEnviadoPeloLeitor = Convert.ToInt32(Convert.ToDecimal(Convert.ToString(StringCodigoDeBarras[StringCodigoDeBarras.Length-1])));
                StringCodigoDeBarras = StringCodigoDeBarras.Remove(StringCodigoDeBarras.Length-1, 1);//Elimina o Digito Verificador para os cálculos
                for (int i = 1; i <= StringCodigoDeBarras.Length - 1; i = i + 2)
                {
                    Soma1 = Soma1+ Convert.ToInt32(Convert.ToDecimal(Convert.ToString(StringCodigoDeBarras[i])));
                }
                ResultadoSoma1MultiplicadoPor3 = Soma1 * 3;
                for (int i = 0; i <= StringCodigoDeBarras.Length - 1; i = i + 2)
                {
                    Soma2 = Soma2 + Convert.ToInt32(Convert.ToDecimal(Convert.ToString(StringCodigoDeBarras[i])));
                }
                SomaTotal = ResultadoSoma1MultiplicadoPor3 + Soma2;
                if (SomaTotal % 10 == 0)
                {
                    CheckDigitCalculado = 0;
                }
                else
                {
                    ProcuraMultiplicador = SomaTotal;
                    while (ProcuraMultiplicador % 10 != 0)
                    {
                        ProcuraMultiplicador++;
                    }
                    CheckDigitCalculado = ProcuraMultiplicador - SomaTotal;
                }

                if (CheckDigitCalculado == CheckDigitEnviadoPeloLeitor)
                {
                    Resultado = 0; ;
                }
                else 
                {
                    Resultado = 1;
                }
            }
            return Resultado;
        }

        public void InserirChecksumNoValor()
        {
            String StringCodigoDeBarras = Convert.ToString(_codigo);
                _codigo = StringCodigoDeBarras;
                int CheckDigitEnviadoPeloLeitor = 0;
                int CheckDigitCalculado = 0;
                int ProcuraMultiplicador = 0;
                int Soma1 = 0;
                int ResultadoSoma1MultiplicadoPor3 = 0;
                int Soma2 = 0;
                int SomaTotal = 0;
                CheckDigitEnviadoPeloLeitor = Convert.ToInt32(Convert.ToDecimal(Convert.ToString(StringCodigoDeBarras[StringCodigoDeBarras.Length - 1])));
                for (int i = 1; i <= StringCodigoDeBarras.Length - 1; i = i + 2)
                {
                    Soma1 = Soma1 + Convert.ToInt32(Convert.ToDecimal(Convert.ToString(StringCodigoDeBarras[i])));
                }
                ResultadoSoma1MultiplicadoPor3 = Soma1 * 3;
                for (int i = 0; i <= StringCodigoDeBarras.Length - 1; i = i + 2)
                {
                    Soma2 = Soma2 + Convert.ToInt32(Convert.ToDecimal(Convert.ToString(StringCodigoDeBarras[i])));
                }
                SomaTotal = ResultadoSoma1MultiplicadoPor3 + Soma2;
                if (SomaTotal % 10 == 0)
                {
                    CheckDigitCalculado = 0;
                }
                else
                {
                    ProcuraMultiplicador = SomaTotal;
                    while (ProcuraMultiplicador % 10 != 0)
                    {
                        ProcuraMultiplicador++;
                    }
                    CheckDigitCalculado = ProcuraMultiplicador - SomaTotal;
                }
               StringCodigoDeBarras += Convert.ToString(CheckDigitCalculado);
               _codigo = StringCodigoDeBarras;
        }
        #endregion

        #region Métodos para Geração de Código de Barras
        
        #endregion
    }
}