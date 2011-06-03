using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SIAERClassLibrary
{
    public class Citinerario
    {
        #region Atributos
        private string _data;
        private string _servico;
        private string _horariosaida;
        private string _cidadesaida;
        private string _carro;
        public ArrayList _CidadesDosServicos;
        private bool persisted;

        #endregion

        #region Métodos de Leitura e Escrita
        public string Data
        {
            get { return this._data; }
            set { this._data = value; }
        }
        public string Servico
        {
            get { return this._servico; }
            set { this._servico = value; }
        }
        public string HorarioDeSaida
        {
            get { return this._horariosaida; }
            set { this._horariosaida = value; }
        }
        public string CidadeDeSaida
        {
            get { return this._cidadesaida; }
            set { this._cidadesaida = value; }
        }
        public string Carro
        {
            get { return this._carro; }
            set { this._carro = value; }
        }
        public bool Persisted
        {
            get { return this.persisted; }
            set { this.persisted = value; }
        }
        #endregion

        #region Construtores
        public Citinerario()
        {
            this.persisted = false;
        }
        public Citinerario(ArrayList x)
        {
            _CidadesDosServicos = x;
        }

        #endregion

        public ArrayList CidadesDosServicos
        {
            get
            {
                return _CidadesDosServicos;
            }
        }


        #region Métodos para conexão com o Banco de Dados
        /// <summary>
        /// Retorna todos os códigos de servicos que a empresa possui
        /// </summary>
        /// <returns></returns>
        public ArrayList Servicos()
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("SELECT distinct CodigoDoServico FROM Itinerario", Conectar);
            SqlDataReader reader;
            ArrayList Servicos = new ArrayList();
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    Servicos.Add(reader["CodigoDoServico"]);
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return Servicos;
        }

        public ArrayList CidadesDoServico(string Servico)
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("select city_name from Itinerario inner join City on CodigoCidadeDeSaida = city_code where CodigoDoServico = @servico order by Identificador asc", Conectar);
            //Tipo de Command, dizendo que é um query
            Command.CommandType = CommandType.Text;
            //Cria Parametros para inserir na query do SqlCommand
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = "@servico";
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 20;
            param.Value = Servico;
            param.Direction = ParameterDirection.Input;
            Command.Parameters.Add(param);
            
            SqlDataReader reader;
            ArrayList Cidades = new ArrayList();
            ArrayList CidadesAux = new ArrayList();
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    //Cidades.Add(reader["city_name"]);
                    Cidades.Add(new CComboBox((string)reader["city_name"],(string)reader["city_name"]));
                    CidadesAux.Add((string)reader["city_name"]);
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            int Achou = CidadesAux.Count;
            for (int Item0 = 0; Item0 < Achou; Item0++)
            {
                if (CidadesAux[Item0].ToString() == CidadesAux[CidadesAux.Count - 1].ToString())
                {
                    Achou = Item0 + 1;
                }
            }
            for (int Item0 = Achou; Item0 < (CidadesAux.Count); Item0++)
            {
                Cidades.RemoveAt(Achou);   
            }
                    return Cidades;
        }
        public ArrayList DatasDoServico()
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("SELECT distinct Data FROM Itinerario", Conectar);
            SqlDataReader reader;
            ArrayList Datas = new ArrayList();
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    Datas.Add(reader["Data"]);
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return Datas;
        }
        public ArrayList CidadesDeSaida()
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("SELECT distinct city_name FROM Itinerario inner join City on city_code = CodigoCidadeDeSaida", Conectar);
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
        public ArrayList DatasDoServico(string Servico)
        {
            SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING);
            SqlCommand Command = new SqlCommand("select distinct Data from Itinerario where CodigoDoServico = @servico order by Data asc", Conectar);
            //Tipo de Command, dizendo que é um query
            Command.CommandType = CommandType.Text;
            //Cria Parametros para inserir na query do SqlCommand
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = "@servico";
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = 20;
            param.Value = Servico;
            param.Direction = ParameterDirection.Input;
            Command.Parameters.Add(param);

            SqlDataReader reader;
            ArrayList Datas = new ArrayList();
            try
            {
                Conectar.Open();
                reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    //Cidades.Add(reader["city_name"]);
                    Datas.Add(new CComboBox((string)reader["Data"], (string)reader["Data"]));
                }
            }
            catch (Exception ex)
            {
                Conectar.Close();
                Conectar.Dispose();
                throw (ex);
            }
            return Datas;
        }
        #endregion
    }
}
