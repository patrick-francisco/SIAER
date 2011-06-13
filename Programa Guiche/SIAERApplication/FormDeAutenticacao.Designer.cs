namespace SIAERAplicacao
{
    partial class FormDeAutenticacao
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
            this.TextBoxNomedoUsuario = new System.Windows.Forms.TextBox();
            this.TextBoxSenha = new System.Windows.Forms.TextBox();
            this.LabelLogin = new System.Windows.Forms.Label();
            this.LabelSenha = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancelar = new System.Windows.Forms.Button();
            this.LabelFalha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxNomedoUsuario
            // 
            this.TextBoxNomedoUsuario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNomedoUsuario.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TextBoxNomedoUsuario.Location = new System.Drawing.Point(123, 72);
            this.TextBoxNomedoUsuario.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.TextBoxNomedoUsuario.Name = "TextBoxNomedoUsuario";
            this.TextBoxNomedoUsuario.Size = new System.Drawing.Size(210, 20);
            this.TextBoxNomedoUsuario.TabIndex = 0;
            this.TextBoxNomedoUsuario.Text = "Digite seu nome de usuário";
            // 
            // TextBoxSenha
            // 
            this.TextBoxSenha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxSenha.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TextBoxSenha.Location = new System.Drawing.Point(123, 109);
            this.TextBoxSenha.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.TextBoxSenha.Name = "TextBoxSenha";
            this.TextBoxSenha.PasswordChar = '*';
            this.TextBoxSenha.Size = new System.Drawing.Size(210, 20);
            this.TextBoxSenha.TabIndex = 1;
            this.TextBoxSenha.Text = "*********";
            // 
            // LabelLogin
            // 
            this.LabelLogin.AutoSize = true;
            this.LabelLogin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLogin.Location = new System.Drawing.Point(15, 74);
            this.LabelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelLogin.Name = "LabelLogin";
            this.LabelLogin.Size = new System.Drawing.Size(104, 14);
            this.LabelLogin.TabIndex = 2;
            this.LabelLogin.Text = "Nome do Usuário:";
            // 
            // LabelSenha
            // 
            this.LabelSenha.AutoSize = true;
            this.LabelSenha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSenha.Location = new System.Drawing.Point(75, 112);
            this.LabelSenha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSenha.Name = "LabelSenha";
            this.LabelSenha.Size = new System.Drawing.Size(44, 14);
            this.LabelSenha.TabIndex = 3;
            this.LabelSenha.Text = "Senha:";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOK.Location = new System.Drawing.Point(140, 152);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(90, 25);
            this.ButtonOK.TabIndex = 4;
            this.ButtonOK.Text = "Ok";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancelar
            // 
            this.ButtonCancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancelar.Location = new System.Drawing.Point(239, 152);
            this.ButtonCancelar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ButtonCancelar.Name = "ButtonCancelar";
            this.ButtonCancelar.Size = new System.Drawing.Size(94, 25);
            this.ButtonCancelar.TabIndex = 5;
            this.ButtonCancelar.Text = "Cancelar";
            this.ButtonCancelar.UseVisualStyleBackColor = true;
            this.ButtonCancelar.Click += new System.EventHandler(this.ButtonCancelar_Click);
            // 
            // LabelFalha
            // 
            this.LabelFalha.AutoSize = true;
            this.LabelFalha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFalha.ForeColor = System.Drawing.Color.Red;
            this.LabelFalha.Location = new System.Drawing.Point(161, 133);
            this.LabelFalha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelFalha.Name = "LabelFalha";
            this.LabelFalha.Size = new System.Drawing.Size(0, 14);
            this.LabelFalha.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Autenticação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(30, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "SIAER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rastreamento Inteligente";
            // 
            // FormDeAutenticacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(346, 188);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelFalha);
            this.Controls.Add(this.ButtonCancelar);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.LabelSenha);
            this.Controls.Add(this.LabelLogin);
            this.Controls.Add(this.TextBoxSenha);
            this.Controls.Add(this.TextBoxNomedoUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeAutenticacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxNomedoUsuario;
        private System.Windows.Forms.TextBox TextBoxSenha;
        private System.Windows.Forms.Label LabelLogin;
        private System.Windows.Forms.Label LabelSenha;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancelar;
        private System.Windows.Forms.Label LabelFalha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}