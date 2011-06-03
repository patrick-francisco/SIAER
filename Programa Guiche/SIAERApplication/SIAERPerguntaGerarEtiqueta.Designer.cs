namespace SIAERAplicacao
{
    partial class SIAERPerguntaGerarEtiqueta
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
            this.TextBoxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonGerar = new System.Windows.Forms.Button();
            this.ButtonCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // TextBoxCodigo
            // 
            this.TextBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCodigo.Location = new System.Drawing.Point(82, 56);
            this.TextBoxCodigo.Name = "TextBoxCodigo";
            this.TextBoxCodigo.Size = new System.Drawing.Size(236, 23);
            this.TextBoxCodigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Digite o código da Encomenda que deseja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "gerar uma etiqueta.";
            // 
            // ButtonGerar
            // 
            this.ButtonGerar.Location = new System.Drawing.Point(174, 103);
            this.ButtonGerar.Name = "ButtonGerar";
            this.ButtonGerar.Size = new System.Drawing.Size(86, 23);
            this.ButtonGerar.TabIndex = 3;
            this.ButtonGerar.Text = "Gerar";
            this.ButtonGerar.UseVisualStyleBackColor = true;
            this.ButtonGerar.Click += new System.EventHandler(this.ButtonGerar_Click);
            // 
            // ButtonCancelar
            // 
            this.ButtonCancelar.Location = new System.Drawing.Point(266, 103);
            this.ButtonCancelar.Name = "ButtonCancelar";
            this.ButtonCancelar.Size = new System.Drawing.Size(86, 23);
            this.ButtonCancelar.TabIndex = 4;
            this.ButtonCancelar.Text = "Cancelar";
            this.ButtonCancelar.UseVisualStyleBackColor = true;
            this.ButtonCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Código:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SIAERAplicacao.Properties.Resources.SIAERCodigoDeBarrasFigura;
            this.pictureBox1.Location = new System.Drawing.Point(16, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // SIAERPerguntaGerarEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 138);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonCancelar);
            this.Controls.Add(this.ButtonGerar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxCodigo);
            this.Name = "SIAERPerguntaGerarEtiqueta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Etiqueta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonGerar;
        private System.Windows.Forms.Button ButtonCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}