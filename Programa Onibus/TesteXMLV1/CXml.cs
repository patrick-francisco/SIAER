using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.Xml.XPath;

namespace TesteXMLV1
{
    public class CXml
    {
        string _caminhoXml;
        public string CaminhoXml
        {
            get { return this._caminhoXml; }
            set { this._caminhoXml = value; }
        }
        static void ClassExemplo1(string[] args)
        {
            // Create an isntance of XmlTextReader and call Read method to read the file
            XmlTextReader textReader = new XmlTextReader("C:\\SIAER0001.xml");
            textReader.Read();
            // If the node has value
            while (textReader.Read())
            {
                // Move to fist element
                textReader.MoveToElement();
                Console.WriteLine("XmlTextReader Properties Test");
                Console.WriteLine("===================");
                // Read this element's properties and display them on console
                Console.WriteLine("Name::::" + textReader.Name);
                Console.WriteLine("Base URI::::" + textReader.BaseURI);
                Console.WriteLine("Local Name::::" + textReader.LocalName);
                Console.WriteLine("Attribute Count::::" + textReader.AttributeCount.ToString());
                Console.WriteLine("Depth::::" + textReader.Depth.ToString());
                Console.WriteLine("Line Number::::" + textReader.LineNumber.ToString());
                Console.WriteLine("Node Type::::" + textReader.NodeType.ToString());
                Console.WriteLine("Attribute Count::::" + textReader.Value.ToString());
                Console.WriteLine("");

            }
        }
        public void CriarArquivoComNomeDeArquivos()
        {
            XmlTextWriter textWriter = new XmlTextWriter("C:\\GerenciadorDeArquivos.xml", null);
            // Opens the document 
            textWriter.WriteStartDocument();
            // Write comments
            textWriter.WriteComment("XML para gerenciamento de arquivos neste onibus");
            // Write first element
            textWriter.WriteStartElement("Arquivos");
            textWriter.WriteStartElement("Nome");
            textWriter.WriteString("SIAER0001");
            textWriter.WriteEndElement();
            // Ends the document.
            textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
        }
        public string RetornaNomedoArquivo()
        {
            String ArquivoACriar = "";
            int Incrementa;
            XmlTextReader XMLReader = new XmlTextReader("C:\\GerenciadorDeArquivos.xml");
            ArrayList ArrayDeNomesDeArquivos = new ArrayList();
            // Read until end of file
            while (XMLReader.Read())
            {
                XmlNodeType nType = XMLReader.NodeType;
                if (nType == XmlNodeType.Text)
                {
                    ArrayDeNomesDeArquivos.Add(XMLReader.Value.ToString());
                }
            }
            ArrayDeNomesDeArquivos.Sort();
            ArquivoACriar = ArrayDeNomesDeArquivos[ArrayDeNomesDeArquivos.Count - 1].ToString();
            ArquivoACriar = ArquivoACriar.Remove(0, 5);
            Incrementa = Convert.ToInt32(ArquivoACriar);
            Incrementa++;
            ArquivoACriar = "SIAER" + Incrementa.ToString();
            XMLReader.Close();
            InsereNovoNomeDeArquivo(ArquivoACriar);
            return ArquivoACriar;
        }
        public void InsereNovoNomeDeArquivo(string nome)
        {
            string NomedoArquivo = "C:\\GerenciadorDeArquivos.xml";
            XmlTextReader XMLReader = new XmlTextReader(NomedoArquivo);
            XmlDocument XMLDocumento = new XmlDocument();
            XMLDocumento.Load(XMLReader);
            XMLReader.Close();
            

            XmlDocumentFragment XMLFragmento = XMLDocumento.CreateDocumentFragment();//cria um fragmento de xml
            XMLFragmento.InnerXml = "<Nome>" + nome + "</Nome>";//Insere na última posição

            XmlNode NoAtual = XMLDocumento.DocumentElement;
            NoAtual.InsertAfter(XMLFragmento, NoAtual.LastChild);//insere apos o no atual o fragmento

            XMLDocumento.Save(NomedoArquivo);
        }
        public ArrayList EncomendasDoCarro()
        {
            ArrayList ArrayDeEncomendas = new ArrayList();
            XPathDocument Documento = new XPathDocument(_caminhoXml);
            XPathNavigator Navegador = Documento.CreateNavigator();

            XPathExpression ExpressaoXml = Navegador.Compile("/Onibus/Encomenda/Id");
            XPathNodeIterator Iterador = Navegador.Select(ExpressaoXml);

            try
            {
                while (Iterador.MoveNext())
                {
                    XPathNavigator Navegador2 = Iterador.Current.Clone();
                    ArrayDeEncomendas.Add(Navegador2.Value);
                }
            }
            catch { }
            return ArrayDeEncomendas;
        }
        public string RetornaNomeUltimoArquivo()
        {
            XmlTextReader XMLReader = new XmlTextReader("C:\\GerenciadorDeArquivos.xml");
            ArrayList ArrayDeNomesDeArquivos = new ArrayList();
            string UltimoArquivo;
            // Read until end of file
            while (XMLReader.Read())
            {
                XmlNodeType nType = XMLReader.NodeType;
                if (nType == XmlNodeType.Text)
                {
                    ArrayDeNomesDeArquivos.Add(XMLReader.Value.ToString());
                }
            }
            ArrayDeNomesDeArquivos.Sort();
            UltimoArquivo = ArrayDeNomesDeArquivos[ArrayDeNomesDeArquivos.Count - 1].ToString();

            return UltimoArquivo;
        }
        public ArrayList DesceEncomendas(string Cidade)
        {
            ArrayList ArrayDeDestinos = new ArrayList();
            XPathDocument Documento = new XPathDocument(_caminhoXml);
            XPathNavigator Navegador = Documento.CreateNavigator();
            XPathExpression ExpressaoXml = Navegador.Compile("/Onibus/Encomenda/Destino");
            XPathNodeIterator Iterador = Navegador.Select(ExpressaoXml);
            ArrayList Indice = new ArrayList();
            ArrayList Codigos = new ArrayList();
            try
            {
                while (Iterador.MoveNext())
                {
                    XPathNavigator Navegador2 = Iterador.Current.Clone();
                    ArrayDeDestinos.Add(Navegador2.Value);
                }
            }
            catch { }
            
            for (int Item = 0; Item < ArrayDeDestinos.Count; Item++)
            {
                if (ArrayDeDestinos[Item].ToString() == Cidade)
                {
                    Indice.Add(Item);
                }
            }
            Codigos = EncomendasDoCarro();
            for (int Item = 0; Item < Indice.Count; Item++)
            {
                Indice[Item] = Codigos[(int)Indice[Item]];
            }
            return Indice;
        }
        public ArrayList SobeEncomendas(List<CBufferDeEntrada> Encomenda)
        {
            ArrayList ArrayDeEncomendas = new ArrayList();
            XPathDocument Documento = new XPathDocument(_caminhoXml);
            XPathNavigator Navegador = Documento.CreateNavigator();
            XPathExpression ExpressaoXml = Navegador.Compile("/Onibus/Encomenda/Id");
            XPathNodeIterator Iterador = Navegador.Select(ExpressaoXml);
            ArrayList Indice = new ArrayList();
            ArrayList Codigos = new ArrayList();
            ArrayList CodigosASubir = new ArrayList();
            Codigos = EncomendasDoCarro();
            try
            {
                while (Iterador.MoveNext())
                {
                    XPathNavigator Navegador2 = Iterador.Current.Clone();
                    ArrayDeEncomendas.Add(Navegador2.Value);//Recebe todas as enmendas cadastradas no onibus
                }
            }
            catch { }
            int AEncomendaEstaAqui=0;
            for (int Item = 0; Item < Encomenda.Count; Item++)
            {
                AEncomendaEstaAqui = 0;
                for (int Item2 = 0; Item2 < Codigos.Count; Item2++)
                {
                    if (Encomenda[Item].Codigo == Codigos[Item2].ToString())
                    {
                        AEncomendaEstaAqui = 1;
                    }
                }
                if (AEncomendaEstaAqui == 0)//A Encomenda não está cadastrada no ônibus ainda
                {
                    CodigosASubir.Add(Encomenda[Item].Codigo);
                }
            }
            return CodigosASubir;
        }
        public void AtualizaXML(List<CBufferDeEntrada> Encomenda,string Cidade)
        {
            ArrayList ArrayDeEncomendas = new ArrayList();
            XPathDocument Documento = new XPathDocument(_caminhoXml);
            //Filtra pelas encomendas que estão na cidade de destino
            ArrayList ArrayDeDestinos = new ArrayList();
            //XPathDocument Documento = new XPathDocument(_caminhoXml);
            XPathNavigator Navegador = Documento.CreateNavigator();
            XPathExpression ExpressaoXml = Navegador.Compile("/Onibus/Encomenda/Destino");
            XPathNodeIterator Iterador = Navegador.Select(ExpressaoXml);
            ArrayList EncomendasNaCidadeDeDestino = new ArrayList();
            ArrayList Codigos = new ArrayList();
            ArrayList CodigosAApagar = new ArrayList();
            while (Iterador.MoveNext())
            {
                XPathNavigator Navegador2 = Iterador.Current.Clone();
                ArrayDeDestinos.Add(Navegador2.Value);
            }
            for (int Item = 0; Item < ArrayDeDestinos.Count; Item++)
            {
                if (ArrayDeDestinos[Item].ToString() == Cidade)
                {
                    EncomendasNaCidadeDeDestino.Add(Item);
                }
            }
            Codigos = EncomendasDoCarro();
            for (int Item = 0; Item < EncomendasNaCidadeDeDestino.Count; Item++)
            {
                EncomendasNaCidadeDeDestino[Item] = Codigos[(int)EncomendasNaCidadeDeDestino[Item]];//Preenche a ArrayList Indice com as encomendas que estão na cidade de destino
            }


            //Procura por encomendas que estão no .xml, que estão na cidade de destino, e que não estão no BufferDeEntrada
            ArrayList EncomendasADeletar = new ArrayList();
            int AEncomendaEstaNoBuffer;
            for (int Item0 = 0; Item0 < EncomendasNaCidadeDeDestino.Count; Item0++)
            {
                AEncomendaEstaNoBuffer = 0;
                for (int Item1 = 0; Item1 < Encomenda.Count; Item1++)
                {
                    if (EncomendasNaCidadeDeDestino[Item0].ToString() == Encomenda[Item1].Codigo)
                    {
                        AEncomendaEstaNoBuffer = 1;
                    }
                }
                if (AEncomendaEstaNoBuffer == 0)//A Encomenda está cadastrada, mas não está sendo mais enviada
                {
                    CodigosAApagar.Add(EncomendasNaCidadeDeDestino[Item0]);
                }
            }
            RemoverDoXML(CodigosAApagar);
            AdicionarAoXML(Encomenda);
        }
        public void RemoverDoXML(ArrayList EncomendasAApagar)
        {
            XmlTextReader Leitor = new XmlTextReader(_caminhoXml);
            XmlDocument Documento = new XmlDocument();
            Documento.Load(Leitor);
            Leitor.Close();
            XmlNodeList No_atual = Documento.SelectNodes("/Onibus/Encomenda/Id");
            XmlElement raiz = Documento.DocumentElement;
             //pesquisa para selecionar o no com os dados do codigo de barras
            //XmlNodeList prices = Documento.GetElementsByTagName("Id");
            //*****************************************************************
            /*XmlNodeList newXMLNodes = Documento.SelectNodes("/ConceptCenters/center/value");
            foreach (XmlNode newXMLNode in newXMLNodes)
            {
                if (newXMLNode.InnerText == nodeVal)
                {
                    newXMLNode.ParentNode.RemoveAll();
                }
            }*/

            //*****************************************************************
            for (int Item = 0; Item < EncomendasAApagar.Count; Item++)
            {
                //No_atual = Documento.SelectNodes("/Onibus/Encomenda");
                foreach (XmlNode Node in No_atual)
                {
                    if (Node.InnerText.ToString() == EncomendasAApagar[Item].ToString())
                    {
                        Node.ParentNode.RemoveAll();
                    }
                }

                //raiz.RemoveChild(No_atual);
                //raiz.RemoveChild(No_atual);//remove o nó
            }
            // xpathExpr = "/root/person[name='Martin Fowler']"; 
            Documento.Save(_caminhoXml);
        }
        public void AdicionarAoXML(List<CBufferDeEntrada> Encomenda)
        {
            //************************************************************
            //           Busca todas as encomendas que estão no Carro
            //************************************************************
            ArrayList ArrayDeEncomendas = new ArrayList();
            XPathDocument Documento = new XPathDocument(_caminhoXml);
            XPathNavigator Navegador = Documento.CreateNavigator();
            XPathExpression ExpressaoXml = Navegador.Compile("/Onibus/Encomenda/Id");
            XPathNodeIterator Iterador = Navegador.Select(ExpressaoXml);
            ArrayList Indice = new ArrayList();
            ArrayList Codigos = new ArrayList();
            ArrayList CodigosASubir = new ArrayList();
            Codigos = EncomendasDoCarro();
            while (Iterador.MoveNext())
            {
                XPathNavigator Navegador2 = Iterador.Current.Clone();
                ArrayDeEncomendas.Add(Navegador2.Value);
            }
            //**********************************************************************
            //Verifica as encomendas que estão chegando e possuem a flag EstaNoCarro = 1
            //e que ainda não estão no Carro. Caso não esteja salva no .xml do carro
            //e a flag EstaNoCarro é igual a 1, então a encomenda é salva no .xml.
            //**********************************************************************
            foreach(CBufferDeEntrada buf in Encomenda)
            {
                int AEncomendaEstaAqui=0;
                foreach (string enc in ArrayDeEncomendas)
                { 
                    if(buf.Codigo == enc.ToString())
                    {
                        AEncomendaEstaAqui = 1;
                    }
                }
                if (AEncomendaEstaAqui == 0 && buf.EstaNoCarro == true)//A Encomenda não está cadastrada no ônibus e possui a flag EstaNoCarro = 1
                {
                    string NomedoArquivo = _caminhoXml;
                    XmlTextReader XMLReader = new XmlTextReader(NomedoArquivo);
                    XmlDocument XMLDocumento = new XmlDocument();
                    XMLDocumento.Load(XMLReader);
                    XMLReader.Close();
                    XmlDocumentFragment XMLFragmento = XMLDocumento.CreateDocumentFragment();//cria um fragmento de xml

                    XMLFragmento.InnerXml = "<Encomenda>" + buf +
                                               "<Id>" + buf.Codigo + "</Id>" +
                                               "<Origem>" + buf.Origem + "</Origem>" +
                                               "<Destino>" + buf.Destino + "</Destino>" +
                                            "</Encomenda>";//Insere na última posição

                    XmlNode NoAtual = XMLDocumento.DocumentElement;
                    NoAtual.InsertAfter(XMLFragmento, NoAtual.LastChild);//insere apos o no atual o fragmento

                    XMLDocumento.Save(NomedoArquivo);
                }
            }
        }
        /// <summary>
        /// A partir do ID da cidade retorna o nome da cidade
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public string RetornaNomeDeCidade(string codigo)
        {
                XmlTextReader Reader = new XmlTextReader("C:\\Cidades.xml");
                XmlDocument Documento = new XmlDocument();
                Documento.Load(Reader); //carrega dados do xml no doc
                Reader.Close();

                XmlNode NoDeCaminho;
                XmlElement root = Documento.DocumentElement;
                NoDeCaminho = root.SelectSingleNode("/Cidades/Cidade[@Codigo=" + codigo + "]"); // seleciona o conjunto 'mestre' de nós que será trocado -- muito importante o '@'... só com ele funciona pesquisa de atributos
                codigo = NoDeCaminho.InnerText.ToString();
                return codigo;
            
        }
    }
}