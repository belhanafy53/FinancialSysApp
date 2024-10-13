namespace FinancialSysApp.Forms.Banks.Reports
{
    partial class AllCheqWithErrorRP
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.dtbCheqWithErrorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtb_CheqWithErrorTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_CheqWithErrorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbCheqWithErrorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(285, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 24);
            this.label1.TabIndex = 339;
            this.label1.Text = "تقرير بالشيكات التي بها أخطاء طبقا للمراجعه";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dtbCheqWithErrorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.Location = new System.Drawing.Point(0, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.Size = new System.Drawing.Size(904, 594);
            this.reportViewer1.TabIndex = 340;
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtbCheqWithErrorBindingSource
            // 
            this.dtbCheqWithErrorBindingSource.DataMember = "Dtb_CheqWithError";
            this.dtbCheqWithErrorBindingSource.DataSource = this.bankCheques;
            // 
            // dtb_CheqWithErrorTableAdapter
            // 
            this.dtb_CheqWithErrorTableAdapter.ClearBeforeFill = true;
            // 
            // AllCheqWithErrorRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 645);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Name = "AllCheqWithErrorRP";
            this.Text = "AllCheqWithErrorRP";
            this.Load += new System.EventHandler(this.AllCheqWithErrorRP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbCheqWithErrorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource dtbCheqWithErrorBindingSource;
        private BankChequesTableAdapters.Dtb_CheqWithErrorTableAdapter dtb_CheqWithErrorTableAdapter;
    }
}