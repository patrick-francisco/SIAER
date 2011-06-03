using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAERClassLibrary
{
    class CComboBox
    {
        private string cAtributoDisplayName;
        private string cAtributoValue;

        public CComboBox(string AtributoDisplayName, string AtributoValue)
        {
            this.cAtributoDisplayName = AtributoDisplayName;
            this.cAtributoValue = AtributoValue;
        }
        public string AtributoDisplayName
        {
            get { return cAtributoDisplayName; }
        }
        public string AtributoValue
        {
            get { return cAtributoValue; }
        }

    }
}