namespace SIAERComunicacaoSerial
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboData = new System.Windows.Forms.ComboBox();
            this.LabelBitDeParada = new System.Windows.Forms.Label();
            this.LabelBitDeDados = new System.Windows.Forms.Label();
            this.TextBoxDesconectar = new System.Windows.Forms.Button();
            this.ComboBoxBitDeParada = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.rtbDisplay = new System.Windows.Forms.RichTextBox();
            this.LabelParidade = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelTaxaDeTransmissão = new System.Windows.Forms.Label();
            this.ComboBoxParidade = new System.Windows.Forms.ComboBox();
            this.LabelPorta = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.ComboBoxPorta = new System.Windows.Forms.ComboBox();
            this.TextBoxConectar = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboData
            // 
            this.cboData.FormattingEnabled = true;
            this.cboData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboData.Location = new System.Drawing.Point(9, 195);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(76, 21);
            this.cboData.TabIndex = 14;
            // 
            // LabelBitDeParada
            // 
            this.LabelBitDeParada.AutoSize = true;
            this.LabelBitDeParada.Location = new System.Drawing.Point(7, 139);
            this.LabelBitDeParada.Name = "LabelBitDeParada";
            this.LabelBitDeParada.Size = new System.Drawing.Size(71, 13);
            this.LabelBitDeParada.TabIndex = 18;
            this.LabelBitDeParada.Text = "Bit de Parada";
            // 
            // LabelBitDeDados
            // 
            this.LabelBitDeDados.AutoSize = true;
            this.LabelBitDeDados.Location = new System.Drawing.Point(6, 179);
            this.LabelBitDeDados.Name = "LabelBitDeDados";
            this.LabelBitDeDados.Size = new System.Drawing.Size(71, 13);
            this.LabelBitDeDados.TabIndex = 19;
            this.LabelBitDeDados.Text = "Bits de dados";
            // 
            // TextBoxDesconectar
            // 
            this.TextBoxDesconectar.Location = new System.Drawing.Point(12, 284);
            this.TextBoxDesconectar.Name = "TextBoxDesconectar";
            this.TextBoxDesconectar.Size = new System.Drawing.Size(100, 23);
            this.TextBoxDesconectar.TabIndex = 5;
            this.TextBoxDesconectar.Text = "Desconectar";
            this.TextBoxDesconectar.UseVisualStyleBackColor = true;
            this.TextBoxDesconectar.Click += new System.EventHandler(this.TextBoxDesconectar_Click);
            // 
            // ComboBoxBitDeParada
            // 
            this.ComboBoxBitDeParada.FormattingEnabled = true;
            this.ComboBoxBitDeParada.Location = new System.Drawing.Point(9, 155);
            this.ComboBoxBitDeParada.Name = "ComboBoxBitDeParada";
            this.ComboBoxBitDeParada.Size = new System.Drawing.Size(76, 21);
            this.ComboBoxBitDeParada.TabIndex = 13;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cmdSend);
            this.GroupBox1.Controls.Add(this.txtSend);
            this.GroupBox1.Controls.Add(this.rtbDisplay);
            this.GroupBox1.Location = new System.Drawing.Point(141, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(236, 299);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Visualização";
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(145, 270);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 23);
            this.cmdSend.TabIndex = 5;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(6, 273);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(78, 20);
            this.txtSend.TabIndex = 4;
            // 
            // rtbDisplay
            // 
            this.rtbDisplay.Location = new System.Drawing.Point(7, 19);
            this.rtbDisplay.Name = "rtbDisplay";
            this.rtbDisplay.Size = new System.Drawing.Size(213, 248);
            this.rtbDisplay.TabIndex = 3;
            this.rtbDisplay.Text = "";
            // 
            // LabelParidade
            // 
            this.LabelParidade.AutoSize = true;
            this.LabelParidade.Location = new System.Drawing.Point(6, 98);
            this.LabelParidade.Name = "LabelParidade";
            this.LabelParidade.Size = new System.Drawing.Size(49, 13);
            this.LabelParidade.TabIndex = 17;
            this.LabelParidade.Text = "Paridade";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LabelBitDeDados);
            this.groupBox2.Controls.Add(this.cboData);
            this.groupBox2.Controls.Add(this.LabelBitDeParada);
            this.groupBox2.Controls.Add(this.ComboBoxBitDeParada);
            this.groupBox2.Controls.Add(this.LabelParidade);
            this.groupBox2.Controls.Add(this.LabelTaxaDeTransmissão);
            this.groupBox2.Controls.Add(this.ComboBoxParidade);
            this.groupBox2.Controls.Add(this.LabelPorta);
            this.groupBox2.Controls.Add(this.cboBaud);
            this.groupBox2.Controls.Add(this.ComboBoxPorta);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 221);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parâmetros";
            // 
            // LabelTaxaDeTransmissão
            // 
            this.LabelTaxaDeTransmissão.AutoSize = true;
            this.LabelTaxaDeTransmissão.Location = new System.Drawing.Point(6, 58);
            this.LabelTaxaDeTransmissão.Name = "LabelTaxaDeTransmissão";
            this.LabelTaxaDeTransmissão.Size = new System.Drawing.Size(31, 13);
            this.LabelTaxaDeTransmissão.TabIndex = 16;
            this.LabelTaxaDeTransmissão.Text = "Taxa";
            // 
            // ComboBoxParidade
            // 
            this.ComboBoxParidade.FormattingEnabled = true;
            this.ComboBoxParidade.Location = new System.Drawing.Point(9, 114);
            this.ComboBoxParidade.Name = "ComboBoxParidade";
            this.ComboBoxParidade.Size = new System.Drawing.Size(76, 21);
            this.ComboBoxParidade.TabIndex = 12;
            // 
            // LabelPorta
            // 
            this.LabelPorta.AutoSize = true;
            this.LabelPorta.Location = new System.Drawing.Point(6, 18);
            this.LabelPorta.Name = "LabelPorta";
            this.LabelPorta.Size = new System.Drawing.Size(32, 13);
            this.LabelPorta.TabIndex = 15;
            this.LabelPorta.Text = "Porta";
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "36000",
            "115000"});
            this.cboBaud.Location = new System.Drawing.Point(9, 74);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(76, 21);
            this.cboBaud.TabIndex = 11;
            // 
            // ComboBoxPorta
            // 
            this.ComboBoxPorta.FormattingEnabled = true;
            this.ComboBoxPorta.Location = new System.Drawing.Point(9, 34);
            this.ComboBoxPorta.Name = "ComboBoxPorta";
            this.ComboBoxPorta.Size = new System.Drawing.Size(76, 21);
            this.ComboBoxPorta.TabIndex = 10;
            // 
            // TextBoxConectar
            // 
            this.TextBoxConectar.Location = new System.Drawing.Point(12, 255);
            this.TextBoxConectar.Name = "TextBoxConectar";
            this.TextBoxConectar.Size = new System.Drawing.Size(100, 23);
            this.TextBoxConectar.TabIndex = 8;
            this.TextBoxConectar.Text = "Conectar";
            this.TextBoxConectar.UseVisualStyleBackColor = true;
            this.TextBoxConectar.Click += new System.EventHandler(this.TextBoxConectar_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(392, 316);
            this.Controls.Add(this.TextBoxDesconectar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TextBoxConectar);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunicação Serial";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.Label LabelBitDeParada;
        private System.Windows.Forms.Label LabelBitDeDados;
        private System.Windows.Forms.Button TextBoxDesconectar;
        private System.Windows.Forms.ComboBox ComboBoxBitDeParada;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.RichTextBox rtbDisplay;
        private System.Windows.Forms.Label LabelParidade;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LabelTaxaDeTransmissão;
        private System.Windows.Forms.ComboBox ComboBoxParidade;
        private System.Windows.Forms.Label LabelPorta;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.ComboBox ComboBoxPorta;
        private System.Windows.Forms.Button TextBoxConectar;
    }
}