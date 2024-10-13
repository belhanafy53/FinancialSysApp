namespace FinancialSysApp.ReportingServicesEventies
{
    partial class SecurityUserActivityRep
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
            this.securityUserActivityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysEventsDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysEventsDataSet1 = new FinancialSysApp.FinancialSysEventsDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.securityEventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.securityEventTableAdapter = new FinancialSysApp.FinancialSysEventsDataSet1TableAdapters.SecurityEventTableAdapter();
            this.tableAdapterManager = new FinancialSysApp.FinancialSysEventsDataSet1TableAdapters.TableAdapterManager();
            this.securityUserActivityBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.securityUserActivityTableAdapter = new FinancialSysApp.FinancialSysEventsDataSet1TableAdapters.SecurityUserActivityTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.securityUserActivityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysEventsDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysEventsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityEventBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityUserActivityBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // securityUserActivityBindingSource
            // 
            this.securityUserActivityBindingSource.DataMember = "SecurityUserActivity";
            this.securityUserActivityBindingSource.DataSource = this.financialSysEventsDataSet1BindingSource;
            // 
            // financialSysEventsDataSet1BindingSource
            // 
            this.financialSysEventsDataSet1BindingSource.DataSource = this.financialSysEventsDataSet1;
            this.financialSysEventsDataSet1BindingSource.Position = 0;
            // 
            // financialSysEventsDataSet1
            // 
            this.financialSysEventsDataSet1.DataSetName = "FinancialSysEventsDataSet1";
            this.financialSysEventsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.securityUserActivityBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.ReportingServicesEventies.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportViewer1.Size = new System.Drawing.Size(874, 589);
            this.reportViewer1.TabIndex = 0;
            // 
            // securityEventBindingSource
            // 
            this.securityEventBindingSource.DataMember = "SecurityEvent";
            this.securityEventBindingSource.DataSource = this.financialSysEventsDataSet1;
            // 
            // securityEventTableAdapter
            // 
            this.securityEventTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.SecurityEventTableAdapter = this.securityEventTableAdapter;
            this.tableAdapterManager.UpdateOrder = FinancialSysApp.FinancialSysEventsDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // securityUserActivityBindingSource1
            // 
            this.securityUserActivityBindingSource1.DataMember = "SecurityUserActivity";
            this.securityUserActivityBindingSource1.DataSource = this.financialSysEventsDataSet1;
            // 
            // securityUserActivityTableAdapter
            // 
            this.securityUserActivityTableAdapter.ClearBeforeFill = true;
            // 
            // SecurityUserActivityRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 621);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SecurityUserActivityRep";
            this.Text = "SecurityUserActivityRep";
            this.Load += new System.EventHandler(this.SecurityUserActivityRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.securityUserActivityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysEventsDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysEventsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityEventBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityUserActivityBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FinancialSysEventsDataSet1 financialSysEventsDataSet1;
        private System.Windows.Forms.BindingSource financialSysEventsDataSet1BindingSource;
        private System.Windows.Forms.BindingSource securityUserActivityBindingSource;
        private System.Windows.Forms.BindingSource securityEventBindingSource;
        private FinancialSysEventsDataSet1TableAdapters.SecurityEventTableAdapter securityEventTableAdapter;
        private FinancialSysEventsDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource securityUserActivityBindingSource1;
        private FinancialSysEventsDataSet1TableAdapters.SecurityUserActivityTableAdapter securityUserActivityTableAdapter;
    }
}