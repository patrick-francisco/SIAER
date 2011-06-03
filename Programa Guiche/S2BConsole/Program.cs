using System;
using System.Collections.Generic;
using System.Text;
using SIAERClassLibrary;

namespace S2BConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Usuario usu1 = new Usuario();
            usu1.Nome = "João";
            usu1.Sobrenome = "Pereira";
            usu1.Login = "jpereira";
            usu1.Senha = "555";
            usu1.Sexo = Sexo.Masculino;
            usu1.Ativo = true;
            usu1.Save();*/

            

            /*
            Endereco end1 = new Endereco();
            end1.Rua = "Sete de Setembro";
            end1.Cep = "82520400";
            end1.Save();
            

            usu1.Endereco = end1;
            usu1.Save();

            //Busca todos os valores
            Usuario usu2 = new Usuario(1);
            usu2.CompleteObject();
            usu2.Endereco.CompleteObject();
            Console.WriteLine(usu2.Nome + " " + usu2.Endereco.Rua + " " + usu2.Endereco.Cep);

            Usuario.Delete(3);

            System.Data.SqlClient.SqlDataReader dr = Usuario.LoadDataReader(null, null, null, null, null, null, true);
            while (dr.Read())
            {
                Console.WriteLine(dr["nome"] + " " + dr["endereco"]);
            }
            dr.Close();*/

            Console.Read();
        }
    }
}
