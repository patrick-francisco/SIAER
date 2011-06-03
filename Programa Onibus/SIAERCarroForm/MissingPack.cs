using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SIAERCarroForm
{
    public partial class MissingPack : Form
    {
        public MissingPack()
        {
            InitializeComponent();
        }

        public MissingPack(ArrayList Subir, ArrayList Descer)
        {
            InitializeComponent();
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.ListBoxSubirAtencao.DataSource = Subir;
            this.ListBoxDescerAtencao.DataSource = Descer;
        }
        protected void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
