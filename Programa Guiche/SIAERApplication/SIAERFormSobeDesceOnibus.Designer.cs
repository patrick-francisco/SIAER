namespace SIAERAplicacao
{
    partial class SIAERFormSobeDesceOnibus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelCarro = new System.Windows.Forms.Label();
            this.DataGridViewEncomendas = new System.Windows.Forms.DataGridView();
            this.ColumnSubir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SIAERAplicacao.Properties.Resources.SIAEROnibusFigura;
            this.pictureBox1.Location = new System.Drawing.Point(250, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LabelCarro
            // 
            this.LabelCarro.AutoSize = true;
            this.LabelCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCarro.Location = new System.Drawing.Point(35, 3);
            this.LabelCarro.Name = "LabelCarro";
            this.LabelCarro.Size = new System.Drawing.Size(180, 73);
            this.LabelCarro.TabIndex = 1;
            this.LabelCarro.Text = "0000";
            // 
            // DataGridViewEncomendas
            // 
            this.DataGridViewEncomendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEncomendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSubir,
            this.ColumnDescer});
            this.DataGridViewEncomendas.Location = new System.Drawing.Point(22, 79);
            this.DataGridViewEncomendas.Name = "DataGridViewEncomendas";
            this.DataGridViewEncomendas.RowHeadersVisible = false;
            this.DataGridViewEncomendas.Size = new System.Drawing.Size(403, 170);
            this.DataGridViewEncomendas.TabIndex = 2;
            // 
            // ColumnSubir
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnSubir.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSubir.HeaderText = "SubirEncomendas";
            this.ColumnSubir.Name = "ColumnSubir";
            this.ColumnSubir.Width = 200;
            // 
            // ColumnDescer
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnDescer.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnDescer.HeaderText = "Descer Encomendas";
            this.ColumnDescer.Name = "ColumnDescer";
            this.ColumnDescer.Width = 200;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(179, 258);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // SIAERFormSobeDesceOnibus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 287);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.DataGridViewEncomendas);
            this.Controls.Add(this.LabelCarro);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SIAERFormSobeDesceOnibus";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelCarro;
        private System.Windows.Forms.DataGridView DataGridViewEncomendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescer;
        private System.Windows.Forms.Button ButtonOK;
    }
}