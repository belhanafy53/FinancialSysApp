namespace FinancialSysApp.Forms.Banks.Reports
{
    partial class RefundBankCheqRpt
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtbRefundCheqBankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankDateAddedReport = new FinancialSysApp.BankDateAddedReport();
            this.dtb_RefundCheqBankTableAdapter = new FinancialSysApp.BankDateAddedReportTableAdapters.Dtb_RefundCheqBankTableAdapter();
            this.Dtb_RefundCheqBankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbRefundCheqBankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDateAddedReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtb_RefundCheqBankBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.Dtb_RefundCheqBankBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.RefundBankCheq.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 158);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(976, 521);
            this.reportViewer1.TabIndex = 336;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(297, 26);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(119, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(320, 75);
            this.groupBox1.TabIndex = 335;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "البنك";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 324;
            this.label2.Text = "الى";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 323;
            this.label1.Text = "من";
            // 
            // DTPFrom
            // 
            this.DTPFrom.CustomFormat = "dd-MM-yyyy";
            this.DTPFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTPFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFrom.Location = new System.Drawing.Point(197, 33);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTPFrom.RightToLeftLayout = true;
            this.DTPFrom.Size = new System.Drawing.Size(141, 23);
            this.DTPFrom.TabIndex = 9;
            this.DTPFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPFrom_KeyDown);
            // 
            // DTPTo
            // 
            this.DTPTo.CustomFormat = "dd-MM-yyyy";
            this.DTPTo.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTPTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPTo.Location = new System.Drawing.Point(16, 33);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTPTo.RightToLeftLayout = true;
            this.DTPTo.Size = new System.Drawing.Size(141, 23);
            this.DTPTo.TabIndex = 10;
            this.DTPTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPTo_KeyDown);
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX1.Location = new System.Drawing.Point(393, 13);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(198, 26);
            this.textBoxX1.TabIndex = 334;
            this.textBoxX1.Text = "تقرير  بالشيكات المرتده خلال الفتره";
            this.textBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.DTPFrom);
            this.groupBox2.Controls.Add(this.DTPTo);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(485, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(379, 75);
            this.groupBox2.TabIndex = 333;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الفترة";
            // 
            // dtbRefundCheqBankBindingSource
            // 
            this.dtbRefundCheqBankBindingSource.DataMember = "Dtb_RefundCheqBank";
            this.dtbRefundCheqBankBindingSource.DataSource = this.bankDateAddedReport;
            // 
            // bankDateAddedReport
            // 
            this.bankDateAddedReport.DataSetName = "BankDateAddedReport";
            this.bankDateAddedReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtb_RefundCheqBankTableAdapter
            // 
            this.dtb_RefundCheqBankTableAdapter.ClearBeforeFill = true;
            // 
            // Dtb_RefundCheqBankBindingSource
            // 
            this.Dtb_RefundCheqBankBindingSource.DataMember = "Dtb_RefundCheqBank";
            this.Dtb_RefundCheqBankBindingSource.DataSource = this.bankDateAddedReport;
            // 
            // RefundBankCheqRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 702);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.groupBox2);
            this.Name = "RefundBankCheqRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RefundBankCheqRpt";
            this.Load += new System.EventHandler(this.RefundBankCheqRpt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbRefundCheqBankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDateAddedReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dtb_RefundCheqBankBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.GroupBox groupBox2;
        private BankDateAddedReport bankDateAddedReport;
        private System.Windows.Forms.BindingSource dtbRefundCheqBankBindingSource;
        private BankDateAddedReportTableAdapters.Dtb_RefundCheqBankTableAdapter dtb_RefundCheqBankTableAdapter;
        private System.Windows.Forms.BindingSource Dtb_RefundCheqBankBindingSource;
    }
}