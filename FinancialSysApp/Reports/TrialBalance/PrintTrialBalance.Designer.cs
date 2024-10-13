namespace FinancialSysApp.Reports.TrialBalance
{
    partial class PrintTrialBalance
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
            this.tblAccountingGuidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trialBalancePrint = new FinancialSysApp.TrialBalancePrint();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbl_Accounting_GuidTableAdapter = new FinancialSysApp.TrialBalancePrintTableAdapters.Tbl_Accounting_GuidTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingGuidBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trialBalancePrint)).BeginInit();
            this.SuspendLayout();
            // 
            // tblAccountingGuidBindingSource
            // 
            this.tblAccountingGuidBindingSource.DataMember = "Tbl_Accounting_Guid";
            this.tblAccountingGuidBindingSource.DataSource = this.trialBalancePrint;
            // 
            // trialBalancePrint
            // 
            this.trialBalancePrint.DataSetName = "TrialBalancePrint";
            this.trialBalancePrint.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblAccountingGuidBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.TrialBalance.TrialBalance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 137);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(891, 446);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // tbl_Accounting_GuidTableAdapter
            // 
            this.tbl_Accounting_GuidTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(236, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // PrintTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 583);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintTrialBalance";
            this.Text = "PrintTrialBalance";
            this.Load += new System.EventHandler(this.PrintTrialBalance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingGuidBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trialBalancePrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblAccountingGuidBindingSource;
        private TrialBalancePrint trialBalancePrint;
        private TrialBalancePrintTableAdapters.Tbl_Accounting_GuidTableAdapter tbl_Accounting_GuidTableAdapter;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
    }
}