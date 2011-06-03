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
            this.ListBoxEncomendasNoCarro = new System.Windows.Forms.ListBox();
            this.ButtonFechar = new System.Windows.Forms.Button();
            this.LabelSubir = new System.Windows.Forms.Label();
            this.LabelDescer = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.TextBoxIDCarro = new System.Windows.Forms.TextBox();
            this.ButtonIniciar = new System.Windows.Forms.Button();
            this.LabelCodOnibus = new System.Windows.Forms.Label();
            this.GroupBoxSubir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSubir)).BeginInit();
            this.GroupBoxDescer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDescer)).BeginInit();
            this.GroupBoxEncomendasNoCarro.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxSubir
            // 
            this.GroupBoxSubir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBoxSubir.Controls.Add(this.ListBoxSubir);
            this.GroupBoxSubir.Controls.Add(this.PictureBoxSubir);
            this.GroupBoxSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxSubir.Location = new System.Drawing.Point(26, 23);
            this.GroupBoxSubir.Margin = new System.Windows.Forms.Padding(10);
            this.GroupBoxSubir.Name = "GroupBoxSubir";
            this.GroupBoxSubir.Size = new System.Drawing.Size(450, 450);
            this.GroupBoxSubir.TabIndex = 0;
            this.GroupBoxSubir.TabStop = false;
            // 
            // ListBoxSubir
            // 
            this.ListBoxSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxSubir.FormattingEnabled = true;
            this.ListBoxSubir.ItemHeight = 25;
            this.ListBoxSubir.Location = new System.Drawing.Point(109, 122);
            this.ListBoxSubir.Name = "ListBoxSubir";
            this.ListBoxSubir.Size = new System.Drawing.Size(180, 229);
            this.ListBoxSubir.TabIndex = 1;
            // 
            // PictureBoxSubir
            // 
            this.PictureBoxSubir.Image = global::SIAERCarroForm.Properties.Resources.SetaSubida1;
            this.PictureBoxSubir.Location = new System.Drawing.Point(18, 19);
            this.PictureBoxSubir.Name = "PictureBoxSubir";
            this.PictureBoxSubir.Size = new System.Drawing.Size(367, 368);
            this.PictureBoxSubir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxSubir.TabIndex = 0;
            this.PictureBoxSubir.TabStop = false;
            // 
            // GroupBoxDescer
            // 
            this.GroupBoxDescer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxDescer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBoxDescer.Controls.Add(this.ListBoxDescer);
            this.GroupBoxDescer.Controls.Add(this.PictureBoxDescer);
            this.GroupBoxDescer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxDescer.Location = new System.Drawing.Point(524, 23);
            this.GroupBoxDescer.Name = "GroupBoxDescer";
            this.GroupBoxDescer.Size = new System.Drawing.Size(450, 450);
            this.GroupBoxDescer.TabIndex = 1;
            this.GroupBoxDescer.TabStop = false;
            // 
            // ListBoxDescer
            // 
            this.ListBoxDescer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxDescer.FormattingEnabled = true;
            this.ListBoxDescer.ItemHeight = 25;
            this.ListBoxDescer.Location = new System.Drawing.Point(119, 75);
            this.ListBoxDescer.Name = "ListBoxDescer";
            this.ListBoxDescer.Size = new System.Drawing.Size(180, 229);
            this.ListBoxDescer.TabIndex = 4;
            // 
            // PictureBoxDescer
            // 
            this.PictureBoxDescer.Image = global::SIAERCarroForm.Properties.Resources.SetaDescida;
            this.PictureBoxDescer.Location = new System.Drawing.Point(20, 19);
            this.PictureBoxDescer.Name = "PictureBoxDescer";
            this.PictureBoxDescer.Size = new System.Drawing.Size(367, 368);
            this.PictureBoxDescer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxDescer.TabIndex = 3;
            this.PictureBoxDescer.TabStop = false;
            // 
            // GroupBoxEncomendasNoCarro
            // 
            this.GroupBoxEncomendasNoCarro.Controls.Add(this.ListBoxEncomendasNoCarro);
            this.GroupBoxEncomendasNoCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxEncomendasNoCarro.Location = new System.Drawing.Point(107, 506);
            this.GroupBoxEncomendasNoCarro.Name = "GroupBoxEncomendasNoCarro";
            this.GroupBoxEncomendasNoCarro.Size = new System.Drawing.Size(737, 132);
            this.GroupBoxEncomendasNoCarro.TabIndex = 2;
            this.GroupBoxEncomendasNoCarro.TabStop = false;
            this.GroupBoxEncomendasNoCarro.Text = "Encomendas no bagageiro do ônibus";
            this.GroupBoxEncomendasNoCarro.Enter += new System.EventHandler(this.GroupBoxEncomendasNoCarro_Enter);
            // 
            // ListBoxEncomendasNoCarro
            // 
            this.ListBoxEncomendasNoCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxEncomendasNoCarro.FormattingEnabled = true;
            this.ListBoxEncomendasNoCarro.ItemHeight = 25;
            this.ListBoxEncomendasNoCarro.Location = new System.Drawing.Point(44, 32);
            this.ListBoxEncomendasNoCarro.Name = "ListBoxEncomendasNoCarro";
            this.ListBoxEncomendasNoCarro.Size = new System.Drawing.Size(657, 79);
            this.ListBoxEncomendasNoCarro.TabIndex = 0;
            // 
            // ButtonFechar
            // 
            this.ButtonFechar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonFechar.Location = new System.Drawing.Point(955, 617);
            this.ButtonFechar.Name = "ButtonFechar";
            this.ButtonFechar.Size = new System.Drawing.Size(24, 21);
            this.ButtonFechar.TabIndex = 3;
            this.ButtonFechar.Text = "X";
            this.ButtonFechar.UseVisualStyleBackColor = false;
            this.ButtonFechar.Click += new System.EventHandler(this.button1_Click);
            // 
            // LabelSubir
            // 
            this.LabelSubir.AutoSize = true;
            this.LabelSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSubir.Location = new System.Drawing.Point(103, -4);
            this.LabelSubir.Name = "LabelSubir";
            this.LabelSubir.Size = new System.Drawing.Size(307, 24);
            this.LabelSubir.TabIndex = 2;
            this.LabelSubir.Text = "Encomendas a subir no ônibus:";
            // 
            // LabelDescer
            // 
            this.LabelDescer.AutoSize = true;
            this.LabelDescer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDescer.Location = new System.Drawing.Point(635, -4);
            this.LabelDescer.Name = "LabelDescer";
            this.LabelDescer.Size = new System.Drawing.Size(333, 24);
            this.LabelDescer.TabIndex = 5;
            this.LabelDescer.Text = "Encomendas a descer neste local:";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.Location = new System.Drawing.Point(381, 6);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(423, 91);
            this.LabelStatus.TabIndex = 10;
            this.LabelStatus.Text = "Viajando...";
            // 
            // TextBoxIDCarro
            // 
            this.TextBoxIDCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxIDCarro.Location = new System.Drawing.Point(7, 4);
            this.TextBoxIDCarro.Name = "TextBoxIDCarro";
            this.TextBoxIDCarro.Size = new System.Drawing.Size(40, 22);
            this.TextBoxIDCarro.TabIndex = 11;
            this.TextBoxIDCarro.Text = "8005";
            // 
            // ButtonIniciar
            // 
            this.ButtonIniciar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonIniciar.Location = new System.Drawing.Point(54, 6);
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
            this.LabelCodOnibus.Location = new System.Drawing.Point(465, 382);
            this.LabelCodOnibus.Name = "LabelCodOnibus";
            this.LabelCodOnibus.Size = new System.Drawing.Size(180, 73);
            this.LabelCodOnibus.TabIndex = 13;
            this.LabelCodOnibus.Text = "0000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(991, 650);
            this.ControlBox = false;
            this.Controls.Add(this.LabelCodOnibus);
            this.Controls.Add(this.ButtonIniciar);
            this.Controls.Add(this.TextBoxIDCarro);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.LabelDescer);
            this.Controls.Add(this.LabelSubir);
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
        private System.Windows.Forms.Label LabelSubir;
        private System.Windows.Forms.Label LabelDescer;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.TextBox TextBoxIDCarro;
        private System.Windows.Forms.Button ButtonIniciar;
        private System.Windows.Forms.Label LabelCodOnibus;
    }
}

