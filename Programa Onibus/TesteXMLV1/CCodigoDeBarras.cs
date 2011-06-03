using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteXMLV1
{
    public class CCodigoDeBarras
    {
        string CountryCode = "789";
        string ManufacturerCode = "1234";
        #region Validacao do Código de Barras
        /// <summary>
        /// Dado um ID a função retorno o código de barras completo
        /// </summary>
        /// <returns></returns>
        public string InserirChecksumNoValor(string id)
        {
            string _codigo = CountryCode + ManufacturerCode + id;
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
            return _codigo;
        }
        #endregion
    }
}
