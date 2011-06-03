using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace SIAERClassLibrary
{
    public class CCidade
    {
        public ArrayList CidadesDoCaminho()
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("SELECT city_name FROM city", Conectar);
            SqlDataReader reader;
            ArrayList Cidades = new ArrayList();
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    Cidades.Add(reader["city_name"]);
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return Cidades;
        }

        public int CodigoDaCidade(string cidade)
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("SELECT city_code FROM city where city_name = @cidade", Conectar);
            
            Command.CommandType = CommandType.Text;
            //Cria Parametros para inserir na query do SqlCommand
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = "@cidade";
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 20;
            param.Value = cidade;
            param.Direction = ParameterDirection.Input;
            Command.Parameters.Add(param);
            
            SqlDataReader reader;
            int CodCidade = 0;
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    CodCidade = (int)reader["city_code"];
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return CodCidade;
        }
    }
}
