namespace SIAERCarroForm
{
    partial class Form1
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
            this.GroupBoxSubir = new System.Windows.Forms.GroupBox();
            this.ListBoxSubir = new System.Windows.Forms.ListBox();
            this.PictureBoxSubir = new System.Windows.Forms.PictureBox();
            this.GroupBoxDescer = new System.Windows.Forms.GroupBox();
            this.ListBoxDescer = new System.Windows.Forms.ListBox();
            this.PictureBoxDescer = new System.Windows.Forms.PictureBox();
            this.GroupBoxEncomendasNoCarro = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ListBoxEncomendasNoCarro = new System.Windows.Forms.ListBox();
            this.ButtonFechar = new System.Windows.Forms.Button();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.TextBoxIDCarro = new System.Windows.Forms.TextBox();
            this.ButtonIniciar = new System.Windows.Forms.Button();
            this.LabelCodOnibus = new System.Windows.Forms.Label();
            this.Mapa = new System.Windows.Forms.PictureBox();
            this.GroupBoxSubir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSubir)).BeginInit();
            this.GroupBoxDescer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDescer)).BeginInit();
            this.GroupBoxEncomendasNoCarro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mapa)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxSubir
            // 
            this.GroupBoxSubir.AutoSize = true;
            this.GroupBoxSubir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBoxSubir.Controls.Add(this.ListBoxSubir);
            this.GroupBoxSubir.Controls.Add(this.PictureBoxSubir);
            this.GroupBoxSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxSubir.Location = new System.Drawing.Point(19, 138);
            this.GroupBoxSubir.Margin = new System.Windows.Forms.Padding(10);
            this.GroupBoxSubir.Name = "GroupBoxSubir";
            this.GroupBoxSubir.Size = new System.Drawing.Size(971, 210);
            this.GroupBoxSubir.TabIndex = 0;
            this.GroupBoxSubir.TabStop = false;
            this.GroupBoxSubir.Text = "Encomendas a subir";
            this.GroupBoxSubir.Visible = false;
            // 
            // ListBoxSubir
            // 
            this.ListBoxSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxSubir.FormattingEnabled = true;
            this.ListBoxSubir.ItemHeight = 25;
            this.ListBoxSubir.Location = new System.Drawing.Point(207, 31);
            this.ListBoxSubir.Name = "ListBoxSubir";
            this.ListBoxSubir.Size = new System.Drawing.Size(752, 154);
            this.ListBoxSubir.TabIndex = 1;
            this.ListBoxSubir.Visible = false;
            // 
            // PictureBoxSubir
            // 
            this.PictureBoxSubir.Image = global::SIAERCarroForm.Properties.Resources.SetaSubida1;
            this.PictureBoxSubir.Location = new System.Drawing.Point(17, 35);
            this.PictureBoxSubir.Name = "PictureBoxSubir";
            this.PictureBoxSubir.Size = new System.Drawing.Size(161, 150);
            this.PictureBoxSubir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxSubir.TabIndex = 0;
            this.PictureBoxSubir.TabStop = false;
            this.PictureBoxSubir.Visible = false;
            // 
            // GroupBoxDescer
            // 
            this.GroupBoxDescer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxDescer.AutoSize = true;
            this.GroupBoxDescer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBoxDescer.Controls.Add(this.ListBoxDescer);
            this.GroupBoxDescer.Controls.Add(this.PictureBoxDescer);
            this.GroupBoxDescer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxDescer.Location = new System.Drawing.Point(12, 375);
            this.GroupBoxDescer.Name = "GroupBoxDescer";
            this.GroupBoxDescer.Size = new System.Drawing.Size(978, 206);
            this.GroupBoxDescer.TabIndex = 1;
            this.GroupBoxDescer.TabStop = false;
            this.GroupBoxDescer.Text = "Encomendas a descer";
            this.GroupBoxDescer.Visible = false;
            // 
            // ListBoxDescer
            // 
            this.ListBoxDescer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxDescer.FormattingEnabled = true;
            this.ListBoxDescer.ItemHeight = 25;
            this.ListBoxDescer.Location = new System.Drawing.Point(207, 29);
            this.ListBoxDescer.Name = "ListBoxDescer";
            this.ListBoxDescer.Size = new System.Drawing.Size(752, 154);
            this.ListBoxDescer.TabIndex = 4;
            this.ListBoxDescer.Visible = false;
            // 
            // PictureBoxDescer
            // 
            this.PictureBoxDescer.Image = global::SIAERCarroForm.Properties.Resources.SetaDescida;
            this.PictureBoxDescer.Location = new System.Drawing.Point(10, 23);
            this.PictureBoxDescer.Name = "PictureBoxDescer";
            this.PictureBoxDescer.Size = new System.Drawing.Size(168, 160);
            this.PictureBoxDescer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxDescer.TabIndex = 3;
            this.PictureBoxDescer.TabStop = false;
            this.PictureBoxDescer.Visible = false;
            // 
            // GroupBoxEncomendasNoCarro
            // 
            this.GroupBoxEncomendasNoCarro.AutoSize = true;
            this.GroupBoxEncomendasNoCarro.Controls.Add(this.pictureBox1);
            this.GroupBoxEncomendasNoCarro.Controls.Add(this.ListBoxEncomendasNoCarro);
            this.GroupBoxEncomendasNoCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxEncomendasNoCarro.Location = new System.Drawing.Point(12, 591);
            this.GroupBoxEncomendasNoCarro.Name = "GroupBoxEncomendasNoCarro";
            this.GroupBoxEncomendasNoCarro.Size = new System.Drawing.Size(984, 157);
            this.GroupBoxEncomendasNoCarro.TabIndex = 2;
            this.GroupBoxEncomendasNoCarro.TabStop = false;
            this.GroupBoxEncomendasNoCarro.Text = "Encomendas no bagageiro do ônibus";
            this.GroupBoxEncomendasNoCarro.Visible = false;
            this.GroupBoxEncomendasNoCarro.Enter += new System.EventHandler(this.GroupBoxEncomendasNoCarro_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SIAERCarroForm.Properties.Resources.BAGAGEIRO;
            this.pictureBox1.Location = new System.Drawing.Point(22, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // ListBoxEncomendasNoCarro
            // 
            this.ListBoxEncomendasNoCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxEncomendasNoCarro.FormattingEnabled = true;
            this.ListBoxEncomendasNoCarro.ItemHeight = 25;
            this.ListBoxEncomendasNoCarro.Location = new System.Drawing.Point(214, 32);
            this.ListBoxEncomendasNoCarro.Name = "ListBoxEncomendasNoCarro";
            this.ListBoxEncomendasNoCarro.Size = new System.Drawing.Size(752, 104);
            this.ListBoxEncomendasNoCarro.TabIndex = 0;
            this.ListBoxEncomendasNoCarro.Visible = false;
            // 
            // ButtonFechar
            // 
            this.ButtonFechar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonFechar.Location = new System.Drawing.Point(980, 12);
            this.ButtonFechar.Name = "ButtonFechar";
            this.ButtonFechar.Size = new System.Drawing.Size(24, 21);
            this.ButtonFechar.TabIndex = 3;
            this.ButtonFechar.Text = "X";
            this.ButtonFechar.UseVisualStyleBackColor = false;
            this.ButtonFechar.Click += new System.EventHandler(this.button1_Click);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.Location = new System.Drawing.Point(350, 25);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(423, 91);
            this.LabelStatus.TabIndex = 10;
            this.LabelStatus.Text = "Viajando...";
            this.LabelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabelStatus.Visible = false;
            // 
            // TextBoxIDCarro
            // 
            this.TextBoxIDCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxIDCarro.Location = new System.Drawing.Point(19, 90);
            this.TextBoxIDCarro.Name = "TextBoxIDCarro";
            this.TextBoxIDCarro.Size = new System.Drawing.Size(40, 22);
            this.TextBoxIDCarro.TabIndex = 11;
            this.TextBoxIDCarro.Text = "8005";
            // 
            // ButtonIniciar
            // 
            this.ButtonIniciar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonIniciar.Location = new System.Drawing.Point(65, 92);
            this.ButtonIniciar.Name = "ButtonIniciar";
            this.ButtonIniciar.Size = new System.Drawing.Size(43, 20);
            this.ButtonIniciar.TabIndex = 12;
            this.ButtonIniciar.Text = "Iniciar";
            this.ButtonIniciar.UseVisualStyleBackColor = false;
            this.ButtonIniciar.Click += new System.EventHandler(this.ButtonIniciar_Click);
            // 
            // LabelCodOnibus
            // 
            this.LabelCodOnibus.AutoSize = true;
            this.LabelCodOnibus.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LabelCodOnibus.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCodOnibus.ForeColor = System.Drawing.SystemColors.Info;
            this.LabelCodOnibus.Location = new System.Drawing.Point(16, 36);
            this.LabelCodOnibus.Name = "LabelCodOnibus";
            this.LabelCodOnibus.Size = new System.Drawing.Size(180, 73);
            this.LabelCodOnibus.TabIndex = 13;
            this.LabelCodOnibus.Text = "0000";
            this.LabelCodOnibus.Visible = false;
            // 
            // Mapa
            // 
            this.Mapa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Mapa.Image = global::SIAERCarroForm.Properties.Resources.mapa;
            this.Mapa.Location = new System.Drawing.Point(160, 200);
            this.Mapa.Name = "Mapa";
            this.Mapa.Size = new System.Drawing.Size(797, 506);
            this.Mapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mapa.TabIndex = 15;
            this.Mapa.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1016, 760);
            this.ControlBox = false;
            this.Controls.Add(this.Mapa);
            this.Controls.Add(this.LabelCodOnibus);
            this.Controls.Add(this.ButtonIniciar);
            this.Controls.Add(this.TextBoxIDCarro);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.ButtonFechar);
            this.Controls.Add(this.GroupBoxEncomendasNoCarro);
            this.Controls.Add(this.GroupBoxDescer);
            this.Controls.Add(this.GroupBoxSubir);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBoxSubir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSubir)).EndInit();
            this.GroupBoxDescer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDescer)).EndInit();
            this.GroupBoxEncomendasNoCarro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxSubir;
        private System.Windows.Forms.PictureBox PictureBoxSubir;
        private System.Windows.Forms.GroupBox GroupBoxDescer;
        private System.Windows.Forms.PictureBox PictureBoxDescer;
        private System.Windows.Forms.GroupBox GroupBoxEncomendasNoCarro;
        private System.Windows.Forms.Button ButtonFechar;
        private System.Windows.Forms.ListBox ListBoxSubir;
        private System.Windows.Forms.ListBox ListBoxDescer;
        private System.Windows.Forms.ListBox ListBoxEncomendasNoCarro;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.TextBox TextBoxIDCarro;
        private System.Windows.Forms.Button ButtonIniciar;
        private System.Windows.Forms.Label LabelCodOnibus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Mapa;
    }
}

