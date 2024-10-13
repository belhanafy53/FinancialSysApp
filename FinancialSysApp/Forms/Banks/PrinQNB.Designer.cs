namespace FinancialSysApp.Forms.Banks
{
    partial class PrinQNB
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
            this.Tbl_TreasuryCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankDateAddedReport = new FinancialSysApp.BankDateAddedReport();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblTreasuryCollectionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cheqDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cheqDetailsTableAdapter = new FinancialSysApp.BankDateAddedReportTableAdapters.CheqDetailsTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tblTreasuryCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_TreasuryCollectionTableAdapter = new FinancialSysApp.BankDateAddedReportTableAdapters.Tbl_TreasuryCollectionTableAdapter();
            this.tbl_TreasuryCollectionTableAdapter1 = new FinancialSysApp.BankDateAddedReportTableAdapters.Tbl_TreasuryCollectionTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.تاريخحافظةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمحافظةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالحافظةالتجارىDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_TreasuryCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDateAddedReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTreasuryCollectionBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheqDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTreasuryCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Tbl_TreasuryCollectionBindingSource
            // 
            this.Tbl_TreasuryCollectionBindingSource.DataMember = "Tbl_TreasuryCollection";
            this.Tbl_TreasuryCollectionBindingSource.DataSource = this.bankDateAddedReport;
            // 
            // bankDateAddedReport
            // 
            this.bankDateAddedReport.DataSetName = "BankDateAddedReport";
            this.bankDateAddedReport.EnforceConstraints = false;
            this.bankDateAddedReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Tbl_TreasuryCollectionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.TreasuryCollectionsRpt.TreasuryQNB.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 56);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(601, 611);
            this.reportViewer1.TabIndex = 337;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(832, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 19);
            this.label5.TabIndex = 336;
            this.label5.Text = "تاريخ الحافظة من";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(630, 56);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(196, 26);
            this.dateTimePicker2.TabIndex = 335;
            this.dateTimePicker2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker2_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 338;
            this.label1.Text = "QNB Bank";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.تاريخحافظةDataGridViewTextBoxColumn,
            this.رقمحافظةDataGridViewTextBoxColumn,
            this.رقمالحافظةالتجارىDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.Tbl_TreasuryCollectionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(630, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(407, 270);
            this.dataGridView1.TabIndex = 339;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // tblTreasuryCollectionBindingSource1
            // 
            this.tblTreasuryCollectionBindingSource1.DataMember = "Tbl_TreasuryCollection";
            this.tblTreasuryCollectionBindingSource1.DataSource = this.bankDateAddedReport;
            // 
            // cheqDetailsBindingSource
            // 
            this.cheqDetailsBindingSource.DataMember = "CheqDetails";
            this.cheqDetailsBindingSource.DataSource = this.bankDateAddedReport;
            // 
            // cheqDetailsTableAdapter
            // 
            this.cheqDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(832, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 341;
            this.label2.Text = "الى";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(630, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(196, 26);
            this.dateTimePicker1.TabIndex = 340;
            this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(630, 494);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 342;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(736, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 343;
            this.label3.Text = "عدد الحفظات";
            // 
            // tblTreasuryCollectionBindingSource
            // 
            this.tblTreasuryCollectionBindingSource.DataMember = "Tbl_TreasuryCollection";
            this.tblTreasuryCollectionBindingSource.DataSource = this.bankDateAddedReport;
            // 
            // tbl_TreasuryCollectionTableAdapter
            // 
            this.tbl_TreasuryCollectionTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_TreasuryCollectionTableAdapter1
            // 
            this.tbl_TreasuryCollectionTableAdapter1.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(832, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 19);
            this.label4.TabIndex = 347;
            this.label4.Text = "الى";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(630, 172);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(196, 26);
            this.dateTimePicker3.TabIndex = 346;
            this.dateTimePicker3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker3_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(832, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 19);
            this.label6.TabIndex = 345;
            this.label6.Text = "تاريخ الايداع من";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker4.Location = new System.Drawing.Point(630, 140);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(196, 26);
            this.dateTimePicker4.TabIndex = 344;
            this.dateTimePicker4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker4_KeyDown);
            // 
            // تاريخحافظةDataGridViewTextBoxColumn
            // 
            this.تاريخحافظةDataGridViewTextBoxColumn.DataPropertyName = "تاريخ_حافظة";
            this.تاريخحافظةDataGridViewTextBoxColumn.HeaderText = "تاريخ_حافظة";
            this.تاريخحافظةDataGridViewTextBoxColumn.Name = "تاريخحافظةDataGridViewTextBoxColumn";
            this.تاريخحافظةDataGridViewTextBoxColumn.Visible = false;
            // 
            // رقمحافظةDataGridViewTextBoxColumn
            // 
            this.رقمحافظةDataGridViewTextBoxColumn.DataPropertyName = "رقم_حافظة";
            this.رقمحافظةDataGridViewTextBoxColumn.HeaderText = "رقم_حافظة";
            this.رقمحافظةDataGridViewTextBoxColumn.Name = "رقمحافظةDataGridViewTextBoxColumn";
            // 
            // رقمالحافظةالتجارىDataGridViewTextBoxColumn
            // 
            this.رقمالحافظةالتجارىDataGridViewTextBoxColumn.DataPropertyName = "رقم_الحافظة_التجارى";
            this.رقمالحافظةالتجارىDataGridViewTextBoxColumn.HeaderText = "رقم_الحافظة_التجارى";
            this.رقمالحافظةالتجارىDataGridViewTextBoxColumn.Name = "رقمالحافظةالتجارىDataGridViewTextBoxColumn";
            this.رقمالحافظةالتجارىDataGridViewTextBoxColumn.Width = 140;
            // 
            // PrinQNB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 683);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker2);
            this.Name = "PrinQNB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrinQNB";
            this.Load += new System.EventHandler(this.PrinQNB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_TreasuryCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDateAddedReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTreasuryCollectionBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheqDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTreasuryCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.BindingSource cheqDetailsBindingSource;
        private BankDateAddedReport bankDateAddedReport;
        private BankDateAddedReportTableAdapters.CheqDetailsTableAdapter cheqDetailsTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource tblTreasuryCollectionBindingSource1;
        private System.Windows.Forms.BindingSource tblTreasuryCollectionBindingSource;
        private BankDateAddedReportTableAdapters.Tbl_TreasuryCollectionTableAdapter tbl_TreasuryCollectionTableAdapter;
        private BankDateAddedReportTableAdapters.Tbl_TreasuryCollectionTableAdapter tbl_TreasuryCollectionTableAdapter1;
        private System.Windows.Forms.BindingSource Tbl_TreasuryCollectionBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخحافظةDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمحافظةDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالحافظةالتجارىDataGridViewTextBoxColumn;
    }
}