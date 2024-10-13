namespace FinancialSysApp. Reports. TreasuryCollectionsRpt
    {
    partial class Print_treasury
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System. ComponentModel. IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if(disposing && (components != null))
                {
                components. Dispose();
                }
            base. Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label3 = new System.Windows.Forms.Label();
            this.dTPAddBank = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treasury_ٌReport = new FinancialSysApp.Treasury_ٌReport();
            this.bigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bigTableAdapter = new FinancialSysApp.Treasury_ٌReportTableAdapters.BigTableAdapter();
            this.dataTable1TableAdapter = new FinancialSysApp.Treasury_ٌReportTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treasury_ٌReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(795, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 328;
            this.label3.Text = "تاريخ الايداع";
            // 
            // dTPAddBank
            // 
            this.dTPAddBank.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPAddBank.CustomFormat = "";
            this.dTPAddBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPAddBank.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPAddBank.Location = new System.Drawing.Point(615, 12);
            this.dTPAddBank.Name = "dTPAddBank";
            this.dTPAddBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPAddBank.RightToLeftLayout = true;
            this.dTPAddBank.Size = new System.Drawing.Size(174, 26);
            this.dTPAddBank.TabIndex = 329;
            this.dTPAddBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPAddBank_KeyDown);
            this.dTPAddBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dTPAddBank_KeyPress);
            // 
            // reportViewer1
            // 
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = this.dataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.TreasuryCollectionsRpt.TresuryBrunch.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 87);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(557, 508);
            this.reportViewer1.TabIndex = 331;
            // 
            // reportViewer2
            // 
            reportDataSource8.Name = "DataSet1";
            reportDataSource8.Value = this.bigBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.TreasuryCollectionsRpt.Tresury.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(615, 87);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(557, 508);
            this.reportViewer2.TabIndex = 332;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(982, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 333;
            this.label1.Text = "جزء مقدم (كبار مشتركين)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 24);
            this.label2.TabIndex = 334;
            this.label2.Text = "بيان باقى الايراد اليومى بالخزينة العامة";
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.treasury_ٌReport;
            // 
            // treasury_ٌReport
            // 
            this.treasury_ٌReport.DataSetName = "Treasury_ٌReport";
            this.treasury_ٌReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bigBindingSource
            // 
            this.bigBindingSource.DataMember = "Big";
            this.bigBindingSource.DataSource = this.treasury_ٌReport;
            // 
            // bigTableAdapter
            // 
            this.bigTableAdapter.ClearBeforeFill = true;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // Print_treasury
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 676);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dTPAddBank);
            this.Name = "Print_treasury";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print_treasury";
            this.Load += new System.EventHandler(this.Print_treasury_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treasury_ٌReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bigBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System. Windows. Forms. Label label3;
        private System. Windows. Forms. DateTimePicker dTPAddBank;
        private Microsoft. Reporting. WinForms. ReportViewer reportViewer1;
        private Microsoft. Reporting. WinForms. ReportViewer reportViewer2;
        private System. Windows. Forms. Label label1;
        private System. Windows. Forms. Label label2;
        private System. Windows. Forms. BindingSource bigBindingSource;
        private Treasury_ٌReport treasury_ٌReport;
        private Treasury_ٌReportTableAdapters. BigTableAdapter bigTableAdapter;
        private System. Windows. Forms. BindingSource dataTable1BindingSource;
        private Treasury_ٌReportTableAdapters. DataTable1TableAdapter dataTable1TableAdapter;
        }
    }