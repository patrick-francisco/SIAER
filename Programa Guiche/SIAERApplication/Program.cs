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
