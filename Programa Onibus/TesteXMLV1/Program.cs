using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TesteXMLV1
{
    class Program
    {
        static void Main(string[] args)
        {
            //*********************************************************************************************************
            //Gera um novo arquivo .xml seguindo a seqüência de nomes contida no arquivo C:\\GerenciadorDeArquivos.xml
            CXml GerarArquivoNomes = new CXml();
            //string NomeDoArquivo = "SIAER6";//GerarArquivoNomes.RetornaNomedoArquivo();
            //XmlTextWriter textWriter = new XmlTextWriter("C:\\" + NomeDoArquivo + ".xml", null);// Cria o novo arquivo
            //XmlTextWriter textWriter = new XmlTextWriter("C:\\Cidades.xml", null);// Cria o novo arquivo
            //GerarArquivoNomes.CriarArquivoComNomeDeArquivos();
            //GerarArquivoNomes.InsereNovoNomeDeArquivo("SIAER0004");
            //*********************************************************************************************************
            /* 
            // Opens the document 
            textWriter.WriteStartDocument();
            // Write comments
            textWriter.WriteComment("Encomendas presentes neste Onibus");
            // Write first element
            textWriter.WriteStartElement("Onibus");
            textWriter.WriteStartElement("Encomenda");
            // Write next element
            textWriter.WriteStartElement("Id");
            textWriter.WriteString("7891234000122");
            textWriter.WriteEndElement();
            // Write one more element
            textWriter.WriteStartElement("Origem"); 
            textWriter.WriteString("Curitiba");
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Destino");
            textWriter.WriteString("Maringá");
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            // Ends the document.
            textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
            */
            //XmlElement NewCodigo = doc.CreateElement("codigo"); //cria elemento principal
            //NewCodigo.SetAttribute("barras", this.codigo.Text); //Dá o atributo ao nó 

            //NewCodigo.InnerXml = "<origem>" + origem.Text + "</origem>" + // Insere dados no novo nó XML
                                 //"<destino>" + destino.Text + "</destino>";

            //root.ReplaceChild(NewCodigo, OldCodigo); // substitui o old pelo new
            //doc.Save(FILE_NAME); //salva arquivo
            string x = GerarArquivoNomes.RetornaNomeDeCidade("1");
            x = GerarArquivoNomes.RetornaNomeDeCidade("2");
            x = GerarArquivoNomes.RetornaNomeDeCidade("3");
            x = GerarArquivoNomes.RetornaNomeDeCidade("4");
            return;
        }

        
    }
}