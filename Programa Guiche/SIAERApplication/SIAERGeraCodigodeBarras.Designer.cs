namespace SIAERAplicacao
{
    partial class SIAERGeraCodigoDeBarras
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.EtiquetaTemporariaBindingSource = new System.Windows.Forms.BindingSource();
            this.SIAERTESTEDataSet = new SIAERAplicacao.SIAERTESTEDataSet();
            this.barcode = new System.Windows.Forms.PictureBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EtiquetaTemporariaTableAdapter = new SIAERAplicacao.SIAERTESTEDataSetTableAdapters.EtiquetaTemporariaTableAdapter();
            this.SuspendLayout();
            // 
            // EtiquetaTemporariaBindingSource
            // 
            this.EtiquetaTemporariaBindingSource.DataMember = "EtiquetaTemporaria";
            this.EtiquetaTemporariaBindingSource.DataSource = this.SIAERTESTEDataSet;
            // 
            // SIAERTESTEDataSet
            // 
            this.SIAERTESTEDataSet.DataSetName = "SIAERTESTEDataSet";
            this.SIAERTESTEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // barcode
            // 
            this.barcode.BackColor = System.Drawing.Color.Transparent;
            this.barcode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.barcode.Location = new System.Drawing.Point(195, 124);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(90, 52);
            this.barcode.TabIndex = 13;
            this.barcode.TabStop = false;
            this.barcode.Visible = false;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "SIAERDataSetEtiqueta";
            reportDataSource1.Value = this.EtiquetaTemporariaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SIAERAplicacao.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(697, 487);
            this.reportViewer1.TabIndex = 14;
            // 
            // EtiquetaTemporariaTableAdapter
            // 
            this.EtiquetaTemporariaTableAdapter.ClearBeforeFill = true;
            // 
            // SIAERGeraCodigoDeBarras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 511);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.barcode);
            this.Name = "SIAERGeraCodigoDeBarras";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIAERGeraCodigodeBarras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeletaCodigoDeBarrasTemporario);
            this.Load += new System.EventHandler(this.SIAERGeraCodigoDeBarras_Load);
            this.SizeChanged += new System.EventHandler(this.SIAERGeraCodigodeBarras_Changed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox barcode;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EtiquetaTemporariaBindingSource;
        private SIAERTESTEDataSet SIAERTESTEDataSet;
        private SIAERTESTEDataSetTableAdapters.EtiquetaTemporariaTableAdapter EtiquetaTemporariaTableAdapter;
    }
}