namespace SIAERAplicacao
{
    partial class SIAERAguardaCodigoDeBarras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LabelAguardandoLeitura = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.LabelESC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.progressBar1.Location = new System.Drawing.Point(13, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 27);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // LabelAguardandoLeitura
            // 
            this.LabelAguardandoLeitura.AutoSize = true;
            this.LabelAguardandoLeitura.Location = new System.Drawing.Point(9, 9);
            this.LabelAguardandoLeitura.Name = "LabelAguardandoLeitura";
            this.LabelAguardandoLeitura.Size = new System.Drawing.Size(208, 13);
            this.LabelAguardandoLeitura.TabIndex = 1;
            this.LabelAguardandoLeitura.Text = "Aguardando Leitura do Código de Barras...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LabelESC
            // 
            this.LabelESC.AutoSize = true;
            this.LabelESC.Location = new System.Drawing.Point(96, 58);
            this.LabelESC.Name = "LabelESC";
            this.LabelESC.Size = new System.Drawing.Size(154, 13);
            this.LabelESC.TabIndex = 2;
            this.LabelESC.Text = "Pressione ESC para cancelar...";
            // 
            // SIAERAguardaCodigoDeBarras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 74);
            this.ControlBox = false;
            this.Controls.Add(this.LabelESC);
            this.Controls.Add(this.LabelAguardandoLeitura);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SIAERAguardaCodigoDeBarras";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LabelAguardandoLeitura;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LabelESC;
    }
}