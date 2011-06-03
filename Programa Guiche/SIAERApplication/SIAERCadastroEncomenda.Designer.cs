namespace SIAERAplicacao
{
    partial class SIAERCadastroEncomenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ButtonLimparTudo = new System.Windows.Forms.Button();
            this.ButtonCancelar = new System.Windows.Forms.Button();
            this.GroupBoxDadosPessoais = new System.Windows.Forms.GroupBox();
            this.DataGridViewTrajeto = new System.Windows.Forms.DataGridView();
            this.ColumnServico = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnCidadeFinal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnData = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TextBoxComentarios = new System.Windows.Forms.TextBox();
            this.LabelComentarios = new System.Windows.Forms.Label();
            this.TextBoxCPFDestinatario = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxPreco = new System.Windows.Forms.MaskedTextBox();
            this.LabelCPFDestinatario = new System.Windows.Forms.Label();
            this.TextBoxCPFRemetente = new System.Windows.Forms.MaskedTextBox();
            this.LabelPreco = new System.Windows.Forms.Label();
            this.LabelTrajeto = new System.Windows.Forms.Label();
            this.TextBoxPeso = new System.Windows.Forms.MaskedTextBox();
            this.LabelCPFRemente = new System.Windows.Forms.Label();
            this.LabelPeso = new System.Windows.Forms.Label();
            this.ButtonSalvar = new System.Windows.Forms.Button();
            this.GroupBoxDadosPessoais.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonLimparTudo
            // 
            this.ButtonLimparTudo.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonLimparTudo.Location = new System.Drawing.Point(237, 351);
            this.ButtonLimparTudo.Name = "ButtonLimparTudo";
            this.ButtonLimparTudo.Size = new System.Drawing.Size(75, 25);
            this.ButtonLimparTudo.TabIndex = 9;
            this.ButtonLimparTudo.Text = "LimparTudo";
            this.ButtonLimparTudo.UseVisualStyleBackColor = false;
            this.ButtonLimparTudo.Click += new System.EventHandler(this.ButtonLimparTudo_Click);
            // 
            // ButtonCancelar
            // 
            this.ButtonCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonCancelar.Location = new System.Drawing.Point(328, 351);
            this.ButtonCancelar.Name = "ButtonCancelar";
            this.ButtonCancelar.Size = new System.Drawing.Size(75, 25);
            this.ButtonCancelar.TabIndex = 10;
            this.ButtonCancelar.Text = "Cancelar";
            this.ButtonCancelar.UseVisualStyleBackColor = false;
            this.ButtonCancelar.Click += new System.EventHandler(this.ButtonCancelar_Click);
            // 
            // GroupBoxDadosPessoais
            // 
            this.GroupBoxDadosPessoais.Controls.Add(this.DataGridViewTrajeto);
            this.GroupBoxDadosPessoais.Controls.Add(this.TextBoxComentarios);
            this.GroupBoxDadosPessoais.Controls.Add(this.LabelComentarios);
            this.GroupBoxDadosPessoais.Controls.Add(this.TextBoxCPFDestinatario);
            this.GroupBoxDadosPessoais.Controls.Add(this.TextBoxPreco);
            this.GroupBoxDadosPessoais.Controls.Add(this.LabelCPFDestinatario);
            this.GroupBoxDadosPessoais.Controls.Add(this.TextBoxCPFRemetente);
            this.GroupBoxDadosPessoais.Controls.Add(this.LabelPreco);
            this.GroupBoxDadosPessoais.Controls.Add(this.LabelTrajeto);
            this.GroupBoxDadosPessoais.Controls.Add(this.TextBoxPeso);
            this.GroupBoxDadosPessoais.Controls.Add(this.LabelCPFRemente);
            this.GroupBoxDadosPessoais.Controls.Add(this.LabelPeso);
            this.GroupBoxDadosPessoais.Location = new System.Drawing.Point(3, 0);
            this.GroupBoxDadosPessoais.Name = "GroupBoxDadosPessoais";
            this.GroupBoxDadosPessoais.Size = new System.Drawing.Size(524, 345);
            this.GroupBoxDadosPessoais.TabIndex = 24;
            this.GroupBoxDadosPessoais.TabStop = false;
            // 
            // DataGridViewTrajeto
            // 
            this.DataGridViewTrajeto.AllowUserToOrderColumns = true;
            this.DataGridViewTrajeto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewTrajeto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewTrajeto.CausesValidation = false;
            this.DataGridViewTrajeto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewTrajeto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewTrajeto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewTrajeto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServico,
            this.ColumnCidadeFinal,
            this.ColumnData});
            this.DataGridViewTrajeto.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.DataGridViewTrajeto.Location = new System.Drawing.Point(21, 200);
            this.DataGridViewTrajeto.Name = "DataGridViewTrajeto";
            this.DataGridViewTrajeto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewTrajeto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewTrajeto.RowHeadersWidth = 20;
            this.DataGridViewTrajeto.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewTrajeto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewTrajeto.Size = new System.Drawing.Size(480, 139);
            this.DataGridViewTrajeto.StandardTab = true;
            this.DataGridViewTrajeto.TabIndex = 37;
            // 
            // ColumnServico
            // 
            this.ColumnServico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnServico.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnServico.FillWeight = 182.7411F;
            this.ColumnServico.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ColumnServico.HeaderText = "Serviço";
            this.ColumnServico.Name = "ColumnServico";
            // 
            // ColumnCidadeFinal
            // 
            this.ColumnCidadeFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCidadeFinal.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnCidadeFinal.FillWeight = 117.2589F;
            this.ColumnCidadeFinal.HeaderText = "Cidade Final";
            this.ColumnCidadeFinal.Name = "ColumnCidadeFinal";
            this.ColumnCidadeFinal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCidadeFinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnData
            // 
            this.ColumnData.HeaderText = "Data";
            this.ColumnData.Name = "ColumnData";
            this.ColumnData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TextBoxComentarios
            // 
            this.TextBoxComentarios.Location = new System.Drawing.Point(20, 91);
            this.TextBoxComentarios.Multiline = true;
            this.TextBoxComentarios.Name = "TextBoxComentarios";
            this.TextBoxComentarios.Size = new System.Drawing.Size(481, 84);
            this.TextBoxComentarios.TabIndex = 6;
            // 
            // LabelComentarios
            // 
            this.LabelComentarios.AutoSize = true;
            this.LabelComentarios.Location = new System.Drawing.Point(18, 75);
            this.LabelComentarios.Name = "LabelComentarios";
            this.LabelComentarios.Size = new System.Drawing.Size(163, 13);
            this.LabelComentarios.TabIndex = 33;
            this.LabelComentarios.Text = "Comentários sobre a Encomenda";
            // 
            // TextBoxCPFDestinatario
            // 
            this.TextBoxCPFDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCPFDestinatario.Location = new System.Drawing.Point(168, 33);
            this.TextBoxCPFDestinatario.Mask = "000,000,000-00";
            this.TextBoxCPFDestinatario.Name = "TextBoxCPFDestinatario";
            this.TextBoxCPFDestinatario.Size = new System.Drawing.Size(127, 26);
            this.TextBoxCPFDestinatario.TabIndex = 2;
            this.TextBoxCPFDestinatario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBoxPreco
            // 
            this.TextBoxPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPreco.Location = new System.Drawing.Point(417, 34);
            this.TextBoxPreco.Mask = "0000.00";
            this.TextBoxPreco.Name = "TextBoxPreco";
            this.TextBoxPreco.PromptChar = ' ';
            this.TextBoxPreco.Size = new System.Drawing.Size(86, 26);
            this.TextBoxPreco.TabIndex = 4;
            this.TextBoxPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelCPFDestinatario
            // 
            this.LabelCPFDestinatario.AutoSize = true;
            this.LabelCPFDestinatario.Location = new System.Drawing.Point(165, 20);
            this.LabelCPFDestinatario.Name = "LabelCPFDestinatario";
            this.LabelCPFDestinatario.Size = new System.Drawing.Size(101, 13);
            this.LabelCPFDestinatario.TabIndex = 24;
            this.LabelCPFDestinatario.Text = "CPF do Destinatário";
            // 
            // TextBoxCPFRemetente
            // 
            this.TextBoxCPFRemetente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCPFRemetente.Location = new System.Drawing.Point(17, 33);
            this.TextBoxCPFRemetente.Mask = "000,000,000-00";
            this.TextBoxCPFRemetente.Name = "TextBoxCPFRemetente";
            this.TextBoxCPFRemetente.Size = new System.Drawing.Size(126, 26);
            this.TextBoxCPFRemetente.TabIndex = 1;
            this.TextBoxCPFRemetente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelPreco
            // 
            this.LabelPreco.AutoSize = true;
            this.LabelPreco.Location = new System.Drawing.Point(412, 21);
            this.LabelPreco.Name = "LabelPreco";
            this.LabelPreco.Size = new System.Drawing.Size(58, 13);
            this.LabelPreco.TabIndex = 31;
            this.LabelPreco.Text = "Preço (R$)";
            // 
            // LabelTrajeto
            // 
            this.LabelTrajeto.AutoSize = true;
            this.LabelTrajeto.Location = new System.Drawing.Point(18, 184);
            this.LabelTrajeto.Name = "LabelTrajeto";
            this.LabelTrajeto.Size = new System.Drawing.Size(115, 13);
            this.LabelTrajeto.TabIndex = 36;
            this.LabelTrajeto.Text = "Trajeto da Encomenda";
            // 
            // TextBoxPeso
            // 
            this.TextBoxPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPeso.Location = new System.Drawing.Point(313, 34);
            this.TextBoxPeso.Mask = "0000.00";
            this.TextBoxPeso.Name = "TextBoxPeso";
            this.TextBoxPeso.Size = new System.Drawing.Size(86, 26);
            this.TextBoxPeso.TabIndex = 3;
            this.TextBoxPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LabelCPFRemente
            // 
            this.LabelCPFRemente.AutoSize = true;
            this.LabelCPFRemente.Location = new System.Drawing.Point(14, 20);
            this.LabelCPFRemente.Name = "LabelCPFRemente";
            this.LabelCPFRemente.Size = new System.Drawing.Size(97, 13);
            this.LabelCPFRemente.TabIndex = 6;
            this.LabelCPFRemente.Text = "CPF do Remetente";
            // 
            // LabelPeso
            // 
            this.LabelPeso.AutoSize = true;
            this.LabelPeso.Location = new System.Drawing.Point(310, 21);
            this.LabelPeso.Name = "LabelPeso";
            this.LabelPeso.Size = new System.Drawing.Size(31, 13);
            this.LabelPeso.TabIndex = 29;
            this.LabelPeso.Text = "Peso";
            // 
            // ButtonSalvar
            // 
            this.ButtonSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonSalvar.Location = new System.Drawing.Point(147, 351);
            this.ButtonSalvar.Name = "ButtonSalvar";
            this.ButtonSalvar.Size = new System.Drawing.Size(75, 25);
            this.ButtonSalvar.TabIndex = 25;
            this.ButtonSalvar.Text = "Salvar";
            this.ButtonSalvar.UseVisualStyleBackColor = false;
            this.ButtonSalvar.Click += new System.EventHandler(this.ButtonSalvarTeste_Click);
            // 
            // SIAERCadastroEncomenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 379);
            this.Controls.Add(this.ButtonSalvar);
            this.Controls.Add(this.ButtonLimparTudo);
            this.Controls.Add(this.ButtonCancelar);
            this.Controls.Add(this.GroupBoxDadosPessoais);
            this.Name = "SIAERCadastroEncomenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Encomenda";
            this.Load += new System.EventHandler(this.SIAERCadastroEncomenda_Load);
            this.GroupBoxDadosPessoais.ResumeLayout(false);
            this.GroupBoxDadosPessoais.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonLimparTudo;
        private System.Windows.Forms.Button ButtonCancelar;
        private System.Windows.Forms.GroupBox GroupBoxDadosPessoais;
        private System.Windows.Forms.Label LabelComentarios;
        private System.Windows.Forms.MaskedTextBox TextBoxPreco;
        private System.Windows.Forms.Label LabelPreco;
        private System.Windows.Forms.MaskedTextBox TextBoxPeso;
        private System.Windows.Forms.Label LabelPeso;
        private System.Windows.Forms.MaskedTextBox TextBoxCPFDestinatario;
        private System.Windows.Forms.Label LabelCPFDestinatario;
        private System.Windows.Forms.MaskedTextBox TextBoxCPFRemetente;
        private System.Windows.Forms.Label LabelCPFRemente;
        private System.Windows.Forms.TextBox TextBoxComentarios;
        private System.Windows.Forms.Label LabelTrajeto;
        private System.Windows.Forms.DataGridView DataGridViewTrajeto;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnServico;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCidadeFinal;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnData;
        private System.Windows.Forms.Button ButtonSalvar;
    }
}