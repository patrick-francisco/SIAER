using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteXMLV1
{
    public class CBufferDeEntrada
    {
        string _Codigo;
        string _Origem;
        string _Destino;
        bool _EstaNoCarro;

        public string Codigo
        {
            get { return this._Codigo; }
            set { this._Codigo = value; }
        }
        public string Origem
        {
            get { return this._Origem; }
            set { this._Origem = value; }
        }
        public string Destino
        {
            get { return this._Destino; }
            set { this._Destino = value; }
        }
        public bool EstaNoCarro
        {
            get { return this._EstaNoCarro; }
            set { this._EstaNoCarro = value; }
        }

        public CBufferDeEntrada(string codigo, string origem, string destino,bool EstaNoCarro)
        {
            _Codigo = codigo;
            _Origem = origem;
            _Destino = destino;
            _EstaNoCarro = EstaNoCarro;
        }
    }
}
