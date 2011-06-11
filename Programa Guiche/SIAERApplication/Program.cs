using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIAERAplicacao
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SIAERLocalizaencomenda("7891234000644"));
            //Application.Run(new SIAERGeraCodigoDeBarras("7891234000309"));
            FormDeAutenticacao FormAutenticador = new FormDeAutenticacao();
            FormAutenticador.ShowDialog();
            if (FormAutenticador.Autenticado == FormDeAutenticacao.Logar.Sim)
            {
                Application.Run(new FormSIAER(FormAutenticador.User));
            }
            FormAutenticador.Close();
        }
    }
}
