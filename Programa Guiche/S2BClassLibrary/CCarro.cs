using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;


namespace SIAERClassLibrary
{
    public class CCarro
    {
        string _CodigoDoCarro;

        public CCarro()
        { }

        #region Métodos de Leitura e Escrita
        public string CodigodoCarro
        {
            get { return this._CodigoDoCarro; }
            set { this._CodigoDoCarro = value; }
        }
        #endregion

        public CCarro(string carro)
        {
            _CodigoDoCarro = carro;
        }

        public ArrayList CarrosDoCaminho()
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("SELECT codigodocarro FROM carro", Conectar);
            SqlDataReader reader;
            ArrayList Carros = new ArrayList();
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    Carros.Add(reader["CodigoDoCarro"]);
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return Carros;
        }

        public string CidadeDeOrigemDoCarro()
        {
            string CidadeDeOrigem = "";
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("select top 1 Identificador,city_name from Itinerario inner join city on CodigoCidadeDesaida = city_code where Data = (SELECT (CONVERT (varchar(20),CONVERT (Date ,SYSDATETIME())))) and CodigoDoCarro = @codigodocarro order by Identificador asc", Conectar);

            Command.CommandType = CommandType.Text;
            //Cria Parametros para inserir na query do SqlCommand
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = "@codigodocarro";
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 20;
            param.Value = this._CodigoDoCarro;
            param.Direction = ParameterDirection.Input;
            Command.Parameters.Add(param);

            SqlDataReader reader;
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    CidadeDeOrigem = (string)reader["city_name"];
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return CidadeDeOrigem;
        }
        public string CidadeDeDestinoDoCarro()
        {
            string CidadeDeDestino = "";
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("select top 1 Identificador,city_name from Itinerario inner join city on CodigoCidadeDesaida = city_code where Data = (SELECT (CONVERT (varchar(20),CONVERT (Date ,SYSDATETIME())))) and CodigoDoCarro = @codigodocarro order by Identificador desc", Conectar);

            Command.CommandType = CommandType.Text;
            //Cria Parametros para inserir na query do SqlCommand
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = "@codigodocarro";
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 20;
            param.Value = this._CodigoDoCarro;
            param.Direction = ParameterDirection.Input;
            Command.Parameters.Add(param);

            SqlDataReader reader;
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    CidadeDeDestino = (string)reader["city_name"];
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return CidadeDeDestino;
        }

        public ArrayList RetornaEncomendasQueDesceraoDoCarro(string nomedacidade)
        {
            ArrayList ArrayEncomendas = new ArrayList();
            using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
            {
                SqlCommand command = null;
                using (command = new SqlCommand("RetornaEncomendasQueDesceraoDoCarro", connection))
                {
                    //Tipo de Command, dizendo que é um query
                    command.CommandType = CommandType.StoredProcedure;
                    //Cria Parametros para inserir na query do SqlCommand
                    command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                    command.Parameters["@nomedacidade"].Value = nomedacidade;
                    command.Parameters.Add("@codigodocarro", SqlDbType.VarChar, 20);
                    command.Parameters["@codigodocarro"].Value = _CodigoDoCarro;

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

         public ArrayList RetornaEncomendasQueSubiraoNoCarro(string nomedacidade)
         {
             ArrayList EncomendasAux = new ArrayList();
             try
             {
                 //Conexão
                 using (SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING))
                 {
                     //Comando 
                     SqlCommand command = null;
                     using (command = new SqlCommand("RetornaEncomendasQueSubiraoNoCarro", Conectar))
                     {
                         command.CommandType = CommandType.StoredProcedure;
                         //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                         command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                         command.Parameters["@nomedacidade"].Value = nomedacidade;
                         command.Parameters.Add("@codigodocarro", SqlDbType.VarChar, 20);
                         command.Parameters["@codigodocarro"].Value = _CodigoDoCarro;
                         //Configura os parâmetros.
                         //daGetRecords.SelectCommand = command;
                         Conectar.Open();
                         SqlDataReader dr = command.ExecuteReader();
                         while (dr.Read())
                         {
                             EncomendasAux.Add(dr["CodigoDaEncomenda"]);
                         }
                         Conectar.Close();
                     }
                 }
             }
             catch (Exception)
             {
                 throw;
             }
             return EncomendasAux;
         }
    }
}
