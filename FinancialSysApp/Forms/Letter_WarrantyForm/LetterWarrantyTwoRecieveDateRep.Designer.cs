namespace FinancialSysApp.Forms.Letter_WarrantyForm
{
    partial class LetterWarrantyTwoRecieveDateRep
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
            this.dtbLttrWrrntyRepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.letterWarranty = new FinancialSysApp.LetterWarranty();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtb_LttrWrrntyRepTableAdapter = new FinancialSysApp.LetterWarrantyTableAdapters.Dtb_LttrWrrntyRepTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLetterKind = new System.Windows.Forms.ComboBox();
            this.tbl_LetterWarrantyTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyTableAdapter();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tblLetterWarrantyKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_LetterWarrantyKindTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyKindTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtbLttrWrrntyRepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterWarranty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWarrantyKindBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtbLttrWrrntyRepBindingSource
            // 
            this.dtbLttrWrrntyRepBindingSource.DataMember = "Dtb_LttrWrrntyRep";
            this.dtbLttrWrrntyRepBindingSource.DataSource = this.letterWarranty;
            // 
            // letterWarranty
            // 
            this.letterWarranty.DataSetName = "LetterWarranty";
            this.letterWarranty.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(65, 23);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "وارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "صادر")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(160, 25);
            this.radioGroup1.TabIndex = 339;
            this.radioGroup1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(554, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(394, 75);
            this.groupBox2.TabIndex = 340;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الفتره ";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(24, 30);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(128, 26);
            this.dateTimePicker2.TabIndex = 344;
            this.dateTimePicker2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 324;
            this.label2.Text = "الى";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(210, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 26);
            this.dateTimePicker1.TabIndex = 343;
            this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 323;
            this.label1.Text = "من";
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
            this.textBoxX1.Location = new System.Drawing.Point(396, 12);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(301, 26);
            this.textBoxX1.TabIndex = 341;
            this.textBoxX1.Text = "تقرير بخطابات الضمان  طبقا لتاريخ استلام الخطاب";
            this.textBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // reportViewer1
            // 
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.dtbLttrWrrntyRepBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TreasurCollBankCheqAudit.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 137);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1129, 517);
            this.reportViewer1.TabIndex = 342;
            // 
            // dtb_LttrWrrntyRepTableAdapter
            // 
            this.dtb_LttrWrrntyRepTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1034, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 351;
            this.label3.Text = "نوع خطاب الضمان";
            // 
            // cmbLetterKind
            // 
            this.cmbLetterKind.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblLetterWarrantyKindBindingSource, "ID", true));
            this.cmbLetterKind.DataSource = this.tblLetterWarrantyKindBindingSource;
            this.cmbLetterKind.DisplayMember = "Name";
            this.cmbLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLetterKind.FormattingEnabled = true;
            this.cmbLetterKind.Location = new System.Drawing.Point(964, 91);
            this.cmbLetterKind.Name = "cmbLetterKind";
            this.cmbLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbLetterKind.Size = new System.Drawing.Size(177, 25);
            this.cmbLetterKind.TabIndex = 350;
            this.cmbLetterKind.ValueMember = "ID";
            this.cmbLetterKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLetterKind_KeyDown);
            // 
            // tbl_LetterWarrantyTableAdapter
            // 
            this.tbl_LetterWarrantyTableAdapter.ClearBeforeFill = true;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblLetterWarrantyKindBindingSource
            // 
            this.tblLetterWarrantyKindBindingSource.DataMember = "Tbl_LetterWarrantyKind";
            this.tblLetterWarrantyKindBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_LetterWarrantyKindTableAdapter
            // 
            this.tbl_LetterWarrantyKindTableAdapter.ClearBeforeFill = true;
            // 
            // LetterWarrantyTwoRecieveDateRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 666);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLetterKind);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.radioGroup1);
            this.Name = "LetterWarrantyTwoRecieveDateRep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LetterWarrantyTwoRecieveDateRep";
            this.Load += new System.EventHandler(this.LetterWarrantyTwoRecieveDateRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtbLttrWrrntyRepBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterWarranty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWarrantyKindBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.BindingSource dtbLttrWrrntyRepBindingSource;
        private LetterWarranty letterWarranty;
        private LetterWarrantyTableAdapters.Dtb_LttrWrrntyRepTableAdapter dtb_LttrWrrntyRepTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLetterKind;
        private FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyTableAdapter tbl_LetterWarrantyTableAdapter;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblLetterWarrantyKindBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyKindTableAdapter tbl_LetterWarrantyKindTableAdapter;
    }
}