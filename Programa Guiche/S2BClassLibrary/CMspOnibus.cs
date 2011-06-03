using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using SIAERClassLibrary;
using System.Data.SqlClient;

namespace SIAERClassLibrary
{
    public class CMspOnibus
    {
        string _Guiche;
        string _Onibus;
        byte[] _OnibusHex = {0x00, 0x00};
        List<CEncomenda> _EncomendasQueVaoParaOCarro = new List<CEncomenda>();
        int _PosicaoListaTransmissaoEncomenda = 0;

        public CMspOnibus(string Guiche,string Onibus)
        {
            _Guiche = Guiche;
            _Onibus = Onibus;
        }
        public CMspOnibus()
        { }

        #region Métodos de Leitura e Escrita
        public string Guiche
        {
            get { return this._Guiche; }
            set { this._Guiche = value; }

        }
        public int PosicaoListaTransmissaoEncomenda
        {
            get { return this._PosicaoListaTransmissaoEncomenda; }
            set { this._PosicaoListaTransmissaoEncomenda = value; }

        }
        public string Onibus
        {
            get { return this._Onibus; }
            set { this._Onibus = value; }

        }
        public byte[] OnibusHex
        {
            get { return this._OnibusHex; }
            set { this._OnibusHex = value; }

        }
        public List<CEncomenda> EncomendasQueVaoParaOCarro
        {
            get { return this._EncomendasQueVaoParaOCarro; }
            set { this._EncomendasQueVaoParaOCarro = value; }

        }
        #endregion

        /// <summary>
        /// Carrega a variável EncomendasQueVaoParaOCarro desta classe com as encomendas que deverão subir no Ônibus
        /// </summary>
        public void RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro()
        {
            ArrayList EncomendaOrigemDestino = new ArrayList();
            ArrayList EncomendasAux = new ArrayList();
            ArrayList EncomendasAux2 = new ArrayList();
            _EncomendasQueVaoParaOCarro.Clear();
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
                        command.Parameters["@nomedacidade"].Value = _Guiche;
                        command.Parameters.Add("@codigodocarro", SqlDbType.VarChar, 20);
                        command.Parameters["@codigodocarro"].Value = _Onibus;
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
            foreach (string str in EncomendasAux)
            {
                string CidadeDestino;
                try
                {
                    //Conexão
                    using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                    {
                        //Comando
                        SqlCommand command = null;
                        using (command = new SqlCommand("RetornaCidadeAnteriorDaEncomenda", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                            command.Parameters.Add("@CodigoDaEncomenda", SqlDbType.VarChar, 20);
                            command.Parameters["@CodigoDaEncomenda"].Value = str.ToString();
                            command.Parameters.Add("@NomeCidadeOrigem", SqlDbType.VarChar, 20);
                            command.Parameters["@NomeCidadeOrigem"].Value = _Guiche;
                            command.Parameters.Add("@CodCidadeAnterior", SqlDbType.VarChar, 20);
                            command.Parameters["@CodCidadeAnterior"].Direction = ParameterDirection.Output;
                            //Configura os parâmetros.
                            //daGetRecords.SelectCommand = command;
                            connection.Open();
                            //@Resultado:
                            // 0-> AEncomenda subirá em um ônibus
                            // 1-> A Encomenda descerá em um Guichê
                            // 2-> Já está no guiche de destino
                            // 3-> A encomenda já foi entregue ao cliente
                            command.ExecuteNonQuery();
                            CidadeDestino = (string)command.Parameters["@CodCidadeAnterior"].Value;
                            connection.Close();
                        }
                    }
                    if (_Guiche != CidadeDestino)
                    {
                        _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), CidadeDestino, _Guiche, false));
                    }
                    else
                    {
                        using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                        {
                            //Comando
                            SqlCommand command = null;
                            using (command = new SqlCommand("RetornaProximaCidadeDestinoDaEncomenda", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                                command.Parameters.Add("@CodigoDaEncomenda", SqlDbType.VarChar, 20);
                                command.Parameters["@CodigoDaEncomenda"].Value = str.ToString();
                                command.Parameters.Add("@NomeCidadeOrigem", SqlDbType.VarChar, 20);
                                command.Parameters["@NomeCidadeOrigem"].Value = _Guiche;
                                command.Parameters.Add("@CodCidadeDestino ", SqlDbType.VarChar, 20);
                                command.Parameters["@CodCidadeDestino "].Direction = ParameterDirection.Output;
                                //Configura os parâmetros.
                                //daGetRecords.SelectCommand = command;
                                connection.Open();
                                //@Resultado:
                                // 0-> AEncomenda subirá em um ônibus
                                // 1-> A Encomenda descerá em um Guichê
                                // 2-> Já está no guiche de destino
                                // 3-> A encomenda já foi entregue ao cliente
                                command.ExecuteNonQuery();
                                CidadeDestino = (string)command.Parameters["@CodCidadeDestino "].Value;
                                connection.Close();
                            }
                        }
                        _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), _Guiche, CidadeDestino, false));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            ////////////////////
            /*try
            {
                //Conexão
                using (SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING))
                {
                    //Comando 
                    SqlCommand command = null;
                    using (command = new SqlCommand("RetornaEncomendasQueEstaoNoCarro", Conectar))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                        command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                        command.Parameters["@nomedacidade"].Value = _Guiche;
                        command.Parameters.Add("@codigodocarro", SqlDbType.VarChar, 20);
                        command.Parameters["@codigodocarro"].Value = _Onibus;
                        //Configura os parâmetros.
                        //daGetRecords.SelectCommand = command;
                        Conectar.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            EncomendasAux2.Add(dr["CodigoDaEncomenda"]);
                        }
                        Conectar.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }*/
            /*foreach (string str in EncomendasAux2)
            {
                string CidadeDestino;
                try
                {
                    //Conexão
                    using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                    {
                        //Comando
                        SqlCommand command = null;
                        using (command = new SqlCommand("RetornaCidadeAnteriorDaEncomenda", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                            command.Parameters.Add("@CodigoDaEncomenda", SqlDbType.VarChar, 20);
                            command.Parameters["@CodigoDaEncomenda"].Value = str.ToString();
                            command.Parameters.Add("@NomeCidadeOrigem", SqlDbType.VarChar, 20);
                            command.Parameters["@NomeCidadeOrigem"].Value = _Guiche;
                            command.Parameters.Add("@CodCidadeAnterior", SqlDbType.VarChar, 20);
                            command.Parameters["@CodCidadeAnterior"].Direction = ParameterDirection.Output;
                            //Configura os parâmetros.
                            //daGetRecords.SelectCommand = command;
                            connection.Open();
                            //@Resultado:
                            // 0-> AEncomenda subirá em um ônibus
                            // 1-> A Encomenda descerá em um Guichê
                            // 2-> Já está no guiche de destino
                            // 3-> A encomenda já foi entregue ao cliente
                            command.ExecuteNonQuery();
                            CidadeDestino = (string)command.Parameters["@CodCidadeAnterior"].Value;
                            connection.Close();
                        }
                    }
                    if (_Guiche != CidadeDestino)
                    {
                        _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), CidadeDestino, _Guiche, true));
                    }
                    else
                    {
                        using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                        {
                            //Comando
                            SqlCommand command = null;
                            using (command = new SqlCommand("RetornaProximaCidadeDestinoDaEncomenda", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                                command.Parameters.Add("@CodigoDaEncomenda", SqlDbType.VarChar, 20);
                                command.Parameters["@CodigoDaEncomenda"].Value = str.ToString();
                                command.Parameters.Add("@NomeCidadeOrigem", SqlDbType.VarChar, 20);
                                command.Parameters["@NomeCidadeOrigem"].Value = _Guiche;
                                command.Parameters.Add("@CodCidadeDestino ", SqlDbType.VarChar, 20);
                                command.Parameters["@CodCidadeDestino "].Direction = ParameterDirection.Output;
                                //Configura os parâmetros.
                                //daGetRecords.SelectCommand = command;
                                connection.Open();
                                //@Resultado:
                                // 0-> AEncomenda subirá em um ônibus
                                // 1-> A Encomenda descerá em um Guichê
                                // 2-> Já está no guiche de destino
                                // 3-> A encomenda já foi entregue ao cliente
                                command.ExecuteNonQuery();
                                CidadeDestino = (string)command.Parameters["@CodCidadeDestino "].Value;
                                connection.Close();
                            }
                        }
                        _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), _Guiche, CidadeDestino, true));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }*/
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
            param.Value = this.Onibus;
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
            param.Value = this.Onibus;
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

        public void RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro2()
        {
            ArrayList EncomendaOrigemDestino = new ArrayList();
            ArrayList EncomendasAux = new ArrayList();
            ArrayList EncomendasAux2 = new ArrayList();
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
                        command.Parameters["@nomedacidade"].Value = _Guiche;
                        command.Parameters.Add("@codigodocarro", SqlDbType.VarChar, 20);
                        command.Parameters["@codigodocarro"].Value = _Onibus;
                        //Configura os parâmetros.
                        //daGetRecords.SelectCommand = command;
                        Conectar.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            EncomendasAux.Add(dr["CodigoDaEncomenda"]);
                        }
                        Conectar.Close();
                        ArrayList EncomendasASubirAux = new ArrayList();
                        EncomendasASubirAux = EncomendasAux;
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
                            EncomendasAux.RemoveAt(Achou);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            foreach (string str in EncomendasAux)
            {
                string CidadeDestino;
                try
                {
                    //Conexão
                    using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                    {
                        //Comando
                        SqlCommand command = null;
                        using (command = new SqlCommand("RetornaProximaCidadeDestinoDaEncomenda", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                            command.Parameters.Add("@CodigoDaEncomenda", SqlDbType.VarChar, 20);
                            command.Parameters["@CodigoDaEncomenda"].Value = str.ToString();
                            command.Parameters.Add("@NomeCidadeOrigem", SqlDbType.VarChar, 20);
                            command.Parameters["@NomeCidadeOrigem"].Value = _Guiche;
                            command.Parameters.Add("@CodCidadeDestino", SqlDbType.VarChar, 20);
                            command.Parameters["@CodCidadeDestino"].Direction = ParameterDirection.Output;
                            //Configura os parâmetros.
                            //daGetRecords.SelectCommand = command;
                            connection.Open();
                            //@Resultado:
                            // 0-> AEncomenda subirá em um ônibus
                            // 1-> A Encomenda descerá em um Guichê
                            // 2-> Já está no guiche de destino
                            // 3-> A encomenda já foi entregue ao cliente
                            command.ExecuteNonQuery();
                            CidadeDestino = (string)command.Parameters["@CodCidadeDestino"].Value;
                            connection.Close();
                        }
                    }
                    int Flag = 0;
                    foreach (CEncomenda c in _EncomendasQueVaoParaOCarro)
                    {
                        
                        if (c.Codigo == str.Substring(7, 5))
                        {
                            Flag = 1;
                        }
                    }
                    if (Flag == 0)
                    {
                        _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), _Guiche, CidadeDestino, false));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            try
            {
                //Conexão
                using (SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING))
                {
                    //Comando 
                    SqlCommand command = null;
                    using (command = new SqlCommand("RetornaEncomendasQueEstaoNoCarro2", Conectar))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                        command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                        command.Parameters["@nomedacidade"].Value = _Guiche;
                        command.Parameters.Add("@codigodocarro", SqlDbType.VarChar, 20);
                        command.Parameters["@codigodocarro"].Value = _Onibus;
                        //Configura os parâmetros.
                        //daGetRecords.SelectCommand = command;
                        Conectar.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            EncomendasAux2.Add(dr["CodigoDaEncomenda"]);
                        }
                        Conectar.Close();
                        ArrayList EncomendasASubirAux = new ArrayList();
                        EncomendasASubirAux = EncomendasAux2;
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
                            EncomendasAux2.RemoveAt(Achou);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            foreach (string str in EncomendasAux2)
            {
                string CidadeDestino;
                try
                {
                    //Conexão
                    using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                    {
                        //Comando
                        SqlCommand command = null;
                        using (command = new SqlCommand("RetornaProximaCidadeDestinoDaEncomenda", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                            command.Parameters.Add("@CodigoDaEncomenda", SqlDbType.VarChar, 20);
                            command.Parameters["@CodigoDaEncomenda"].Value = str.ToString();
                            command.Parameters.Add("@NomeCidadeOrigem", SqlDbType.VarChar, 20);
                            command.Parameters["@NomeCidadeOrigem"].Value = _Guiche;
                            command.Parameters.Add("@CodCidadeDestino", SqlDbType.VarChar, 20);
                            command.Parameters["@CodCidadeDestino"].Direction = ParameterDirection.Output;
                            //Configura os parâmetros.
                            //daGetRecords.SelectCommand = command;
                            connection.Open();
                            //@Resultado:
                            // 0-> AEncomenda subirá em um ônibus
                            // 1-> A Encomenda descerá em um Guichê
                            // 2-> Já está no guiche de destino
                            // 3-> A encomenda já foi entregue ao cliente
                            command.ExecuteNonQuery();
                            CidadeDestino = (string)command.Parameters["@CodCidadeDestino"].Value;
                            connection.Close();
                        }
                    }
                    int Flag = 0;
                    foreach (CEncomenda c in _EncomendasQueVaoParaOCarro)
                    {

                        if (c.Codigo == str.Substring(7, 5))
                        {
                            if (c.EstaNoCarro == false)
                            {
                                Flag = 2;
                            }
                            else
                            {
                                Flag = 1;
                            }
                        }
                    }
                    if (Flag == 0 || Flag == 2)
                    {
                        _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), _Guiche, CidadeDestino, true));
                    }
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void RetornaEncomendasQueEstaoNoCarroEQueSubiraoNoCarro3()
        {
            ArrayList EncomendaOrigemDestino = new ArrayList();
            ArrayList EncomendasAux = new ArrayList();
            ArrayList EncomendasAux2 = new ArrayList();
            List<CEncomenda> Aux = new List<CEncomenda>();
            Aux.Clear();
            try
            {
                //Conexão
                using (SqlConnection Conectar = new SqlConnection(DataBase.CONN_STRING))
                {
                    //Comando 
                    SqlCommand command = null;
                    using (command = new SqlCommand("RetornaEncomendasQueDesceramDoCarro", Conectar))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                        command.Parameters.Add("@nomedacidade", SqlDbType.VarChar, 20);
                        command.Parameters["@nomedacidade"].Value = _Guiche;
                        command.Parameters.Add("@codigodocarro", SqlDbType.VarChar, 20);
                        command.Parameters["@codigodocarro"].Value = _Onibus;
                        //Configura os parâmetros.
                        //daGetRecords.SelectCommand = command;
                        Conectar.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            EncomendasAux.Add(dr["CodigoDaEncomenda"]);
                        }
                        Conectar.Close();
                        ArrayList EncomendasASubirAux = new ArrayList();
                        EncomendasASubirAux = EncomendasAux;
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
                            EncomendasAux.RemoveAt(Achou);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            foreach (string str in EncomendasAux)
            {
                string CidadeDestino;
                try
                {
                    //Conexão
                    using (SqlConnection connection = new SqlConnection(DataBase.CONN_STRING))
                    {
                        //Comando
                        SqlCommand command = null;
                        using (command = new SqlCommand("RetornaCidadeAnteriorDaEncomenda", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            //SqlDataAdapter daGetRecords = new SqlDataAdapter(); 
                            command.Parameters.Add("@CodigoDaEncomenda", SqlDbType.VarChar, 20);
                            command.Parameters["@CodigoDaEncomenda"].Value = str.ToString();
                            command.Parameters.Add("@NomeCidadeOrigem", SqlDbType.VarChar, 20);
                            command.Parameters["@NomeCidadeOrigem"].Value = _Guiche;
                            command.Parameters.Add("@CodCidadeAnterior", SqlDbType.VarChar, 20);
                            command.Parameters["@CodCidadeAnterior"].Direction = ParameterDirection.Output;
                            //Configura os parâmetros.
                            //daGetRecords.SelectCommand = command;
                            connection.Open();
                            //@Resultado:
                            // 0-> AEncomenda subirá em um ônibus
                            // 1-> A Encomenda descerá em um Guichê
                            // 2-> Já está no guiche de destino
                            // 3-> A encomenda já foi entregue ao cliente
                            command.ExecuteNonQuery();
                            CidadeDestino = (string)command.Parameters["@CodCidadeAnterior"].Value;
                            connection.Close();
                        }
                    }
                    int Flag = 0;
                    if (_EncomendasQueVaoParaOCarro.Count == 0 && EncomendasAux.Count > 0)
                    {
                        _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), CidadeDestino, _Guiche, false, true));
                    }
                    else if (EncomendasAux.Count > 0)
                    {
                        foreach (CEncomenda c in _EncomendasQueVaoParaOCarro)
                        {
                            if (c.Codigo == str.Substring(7, 5) && c.DesceuDoCarro == true)
                            {
                                Flag = 1;
                            }
                        }
                        if (Flag == 0)
                        {
                            _EncomendasQueVaoParaOCarro.Add(new CEncomenda(str.Substring(7, 5), CidadeDestino, _Guiche, false, true));
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }  
    }
}
