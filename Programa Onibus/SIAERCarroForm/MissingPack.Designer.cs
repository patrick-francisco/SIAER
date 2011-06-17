namespace SIAERCarroForm
{
    partial class MissingPack
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
            this.components = new System.ComponentModel.Container();
            this.ListBoxSubirAtencao = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListBoxDescerAtencao = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListBoxSubirAtencao
            // 
            this.ListBoxSubirAtencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxSubirAtencao.FormattingEnabled = true;
            this.ListBoxSubirAtencao.ItemHeight = 24;
            this.ListBoxSubirAtencao.Location = new System.Drawing.Point(12, 120);
            this.ListBoxSubirAtencao.Name = "ListBoxSubirAtencao";
            this.ListBoxSubirAtencao.Size = new System.Drawing.Size(242, 124);
            this.ListBoxSubirAtencao.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subir Encomendas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descer Encomendas";
            // 
            // ListBoxDescerAtencao
            // 
            this.ListBoxDescerAtencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxDescerAtencao.FormattingEnabled = true;
            this.ListBoxDescerAtencao.ItemHeight = 24;
            this.ListBoxDescerAtencao.Location = new System.Drawing.Point(285, 120);
            this.ListBoxDescerAtencao.Name = "ListBoxDescerAtencao";
            this.ListBoxDescerAtencao.Size = new System.Drawing.Size(242, 124);
            this.ListBoxDescerAtencao.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(511, 73);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ações Faltantes!";
            // 
            // MissingPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 268);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ListBoxDescerAtencao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListBoxSubirAtencao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MissingPack";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxSubirAtencao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListBoxDescerAtencao;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
    }
}