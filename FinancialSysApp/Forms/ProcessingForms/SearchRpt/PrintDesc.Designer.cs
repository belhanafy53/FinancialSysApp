namespace FinancialSysApp.Forms.ProcessingForms.SearchRpt
{
    partial class PrintDesc
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.reportSearchTableAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new FinancialSysApp.DataSet1();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.radDateTimePicker1 = new System.Windows.Forms.TextBox();
            this.radDateTimePicker2 = new System.Windows.Forms.TextBox();
            this.d1 = new System.Windows.Forms.TextBox();
            this.d2 = new System.Windows.Forms.TextBox();
            this.desc = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.reportSearchTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.ReportSearchTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportSearchBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportSearchTableAdapter1 = new FinancialSysApp.DataSet1TableAdapters.ReportSearchTableAdapterTableAdapter();
            this.tbl_SystemUnitesTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_SystemUnitesTableAdapter();
            this.tbl_FinanctialSearchTableAdapter = new FinancialSysApp.FinaSearchTableAdapters.Tbl_FinanctialSearchTableAdapter();
            this.tblFiscalyearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_FiscalyearTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_FiscalyearTableAdapter();
            this.tblAccountingRestrictionItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblAccountingRestrictionsKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_AccountingRestrictions_KindTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_AccountingRestrictions_KindTableAdapter();
            this.tbl_AccountingRestrictionItemsTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_AccountingRestrictionItemsTableAdapter();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportSearchTableAdapterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSearchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSearchBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionsKindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // reportSearchTableAdapterBindingSource
            // 
            this.reportSearchTableAdapterBindingSource.DataMember = "ReportSearchTableAdapter";
            this.reportSearchTableAdapterBindingSource.DataSource = this.reportSearchBindingSource;
            // 
            // reportSearchBindingSource
            // 
            this.reportSearchBindingSource.DataSource = this.dataSet1;
            this.reportSearchBindingSource.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.EnforceConstraints = false;
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radDateTimePicker1
            // 
            this.radDateTimePicker1.Location = new System.Drawing.Point(577, 358);
            this.radDateTimePicker1.Name = "radDateTimePicker1";
            this.radDateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.radDateTimePicker1.TabIndex = 0;
            // 
            // radDateTimePicker2
            // 
            this.radDateTimePicker2.Location = new System.Drawing.Point(471, 358);
            this.radDateTimePicker2.Name = "radDateTimePicker2";
            this.radDateTimePicker2.Size = new System.Drawing.Size(100, 20);
            this.radDateTimePicker2.TabIndex = 1;
            // 
            // d1
            // 
            this.d1.Location = new System.Drawing.Point(577, 384);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(100, 20);
            this.d1.TabIndex = 2;
            // 
            // d2
            // 
            this.d2.Location = new System.Drawing.Point(471, 384);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(100, 20);
            this.d2.TabIndex = 3;
            // 
            // desc
            // 
            this.desc.Location = new System.Drawing.Point(471, 410);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(100, 20);
            this.desc.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(10, "اختر الكل"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(1, "عمليات"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(2, "مدفوعات"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(3, "تسويات - عمليات"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(4, "مقبوضات - نقدي"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(5, "قيد افتتاحي  - ميزانية"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(6, "عمليات 30 -6 - استحقاق "),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(7, "ملحق 1 - استحقاق "),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(8, "ملحق 2 - استحقاق "),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(9, "ملحق 3 - استحقاق ")});
            this.checkedListBox1.Location = new System.Drawing.Point(161, 398);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.checkedListBox1.Size = new System.Drawing.Size(347, 113);
            this.checkedListBox1.TabIndex = 321;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Location = new System.Drawing.Point(487, 381);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(120, 95);
            this.checkedListBoxControl1.TabIndex = 322;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(278, 381);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(120, 34);
            this.checkedListBox2.TabIndex = 323;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(598, 349);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 324;
            // 
            // reportSearchTableAdapter
            // 
            this.reportSearchTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(337, 296);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 325;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.reportSearchTableAdapterBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ProcessingForms.SearchRpt.Descrption.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 101);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(970, 588);
            this.reportViewer1.TabIndex = 326;
            // 
            // reportSearchBindingSource1
            // 
            this.reportSearchBindingSource1.DataMember = "ReportSearch";
            this.reportSearchBindingSource1.DataSource = this.dataSet1;
            // 
            // reportSearchTableAdapter1
            // 
            this.reportSearchTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_SystemUnitesTableAdapter
            // 
            this.tbl_SystemUnitesTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_FinanctialSearchTableAdapter
            // 
            this.tbl_FinanctialSearchTableAdapter.ClearBeforeFill = true;
            // 
            // tblFiscalyearBindingSource
            // 
            this.tblFiscalyearBindingSource.DataMember = "Tbl_Fiscalyear";
            this.tblFiscalyearBindingSource.DataSource = this.dataSet1;
            // 
            // tbl_FiscalyearTableAdapter
            // 
            this.tbl_FiscalyearTableAdapter.ClearBeforeFill = true;
            // 
            // tblAccountingRestrictionItemsBindingSource
            // 
            this.tblAccountingRestrictionItemsBindingSource.DataMember = "Tbl_AccountingRestrictionItems";
            this.tblAccountingRestrictionItemsBindingSource.DataSource = this.dataSet1;
            // 
            // tblAccountingRestrictionsKindBindingSource
            // 
            this.tblAccountingRestrictionsKindBindingSource.DataMember = "Tbl_AccountingRestrictions_Kind";
            this.tblAccountingRestrictionsKindBindingSource.DataSource = this.dataSet1;
            // 
            // tbl_AccountingRestrictions_KindTableAdapter
            // 
            this.tbl_AccountingRestrictions_KindTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_AccountingRestrictionItemsTableAdapter
            // 
            this.tbl_AccountingRestrictionItemsTableAdapter.ClearBeforeFill = true;
            // 
            // ultraButton1
            // 
            this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D;
            this.ultraButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ultraButton1.Location = new System.Drawing.Point(24, 10);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(119, 26);
            this.ultraButton1.TabIndex = 403;
            this.ultraButton1.Text = "استدعاء بيانات الفترة";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(754, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker1.TabIndex = 402;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(544, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker2.TabIndex = 401;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Gold;
            this.radLabel1.Location = new System.Drawing.Point(888, 14);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 19);
            this.radLabel1.TabIndex = 399;
            this.radLabel1.Text = "الفترة من";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.Gold;
            this.radLabel2.Location = new System.Drawing.Point(678, 14);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(70, 19);
            this.radLabel2.TabIndex = 400;
            this.radLabel2.Text = "الفترة إلى";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // ultraLabel7
            // 
            appearance6.BackColor = System.Drawing.Color.CornflowerBlue;
            appearance6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance6;
            this.ultraLabel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraLabel7.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(970, 49);
            this.ultraLabel7.TabIndex = 404;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(406, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 17);
            this.checkBox1.TabIndex = 405;
            this.checkBox1.Text = "موقف التوريد تحليلى";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(268, 14);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(135, 17);
            this.checkBox2.TabIndex = 405;
            this.checkBox2.Text = "موقف التوريد اجمالى";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox3.ForeColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(182, 14);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 405;
            this.checkBox3.Text = "المسدد";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // PrintDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 689);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ultraButton1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.d2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.radDateTimePicker2);
            this.Controls.Add(this.radDateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Name = "PrintDesc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "موقف التوريد";
            this.Load += new System.EventHandler(this.PrintDesc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportSearchTableAdapterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSearchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ////((System.ComponentModel.ISupportInitialize)(this.reportSearchBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionsKindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox radDateTimePicker1;
        public System.Windows.Forms.TextBox radDateTimePicker2;
        public System.Windows.Forms.TextBox d1;
        public System.Windows.Forms.TextBox d2;
        public System.Windows.Forms.TextBox desc;
        private System.Windows.Forms.BindingSource reportSearchBindingSource;
        private FinancialSysDataSet financialSysDataSet;
        private FinancialSysDataSetTableAdapters.ReportSearchTableAdapter reportSearchTableAdapter;
        public DevExpress.XtraEditors.CheckedListBoxControl checkedListBox1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.TextBox textBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource reportSearchBindingSource1;
        private DataSet1TableAdapters.ReportSearchTableAdapterTableAdapter  reportSearchTableAdapter1;
        private System.Windows.Forms.BindingSource reportSearchTableAdapterBindingSource;
        private DataSet1TableAdapters.Tbl_SystemUnitesTableAdapter tbl_SystemUnitesTableAdapter;
        private FinaSearchTableAdapters.Tbl_FinanctialSearchTableAdapter tbl_FinanctialSearchTableAdapter;
        private System.Windows.Forms.BindingSource tblFiscalyearBindingSource;
        private DataSet1TableAdapters.Tbl_FiscalyearTableAdapter tbl_FiscalyearTableAdapter;
        private System.Windows.Forms.BindingSource tblAccountingRestrictionItemsBindingSource;
        private System.Windows.Forms.BindingSource tblAccountingRestrictionsKindBindingSource;
        private DataSet1TableAdapters.Tbl_AccountingRestrictions_KindTableAdapter tbl_AccountingRestrictions_KindTableAdapter;
        private DataSet1TableAdapters.Tbl_AccountingRestrictionItemsTableAdapter tbl_AccountingRestrictionItemsTableAdapter;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}