namespace FinancialSysApp.Forms.Letter_WarrantyForm
{
    partial class LetterWntryRefundReport
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
            this.dtbRefundLtrWarrantyRepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.letterWarranty = new FinancialSysApp.LetterWarranty();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSupliers = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtBankID = new System.Windows.Forms.TextBox();
            this.txtSuplierID = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dtb_RefundLtrWarrantyRepTableAdapter = new FinancialSysApp.LetterWarrantyTableAdapters.Dtb_RefundLtrWarrantyRepTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLetterKind = new System.Windows.Forms.ComboBox();
            this.tblLetterWarrantyKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tbl_LetterWarrantyKindTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyKindTableAdapter();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dtbRefundLtrWarrantyRepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterWarranty)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWarrantyKindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtbRefundLtrWarrantyRepBindingSource
            // 
            this.dtbRefundLtrWarrantyRepBindingSource.DataMember = "Dtb_RefundLtrWarrantyRep";
            this.dtbRefundLtrWarrantyRepBindingSource.DataSource = this.letterWarranty;
            // 
            // letterWarranty
            // 
            this.letterWarranty.DataSetName = "LetterWarranty";
            this.letterWarranty.EnforceConstraints = false;
            this.letterWarranty.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.textBoxX1.Location = new System.Drawing.Point(511, 12);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(198, 26);
            this.textBoxX1.TabIndex = 339;
            this.textBoxX1.TabStop = false;
            this.textBoxX1.Text = "تقرير بخطابات الضمان  التي تم ردها";
            this.textBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dtbRefundLtrWarrantyRepBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TreasurCollBankCheqAudit.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 135);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1205, 493);
            this.reportViewer1.TabIndex = 340;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.DTPFrom);
            this.groupBox2.Controls.Add(this.DTPTo);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(633, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(379, 75);
            this.groupBox2.TabIndex = 341;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الفترة";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSupliers);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(387, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(240, 72);
            this.groupBox1.TabIndex = 342;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المورد";
            // 
            // txtSupliers
            // 
            this.txtSupliers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSupliers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSupliers.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupliers.Location = new System.Drawing.Point(6, 30);
            this.txtSupliers.Name = "txtSupliers";
            this.txtSupliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSupliers.Size = new System.Drawing.Size(228, 25);
            this.txtSupliers.TabIndex = 344;
            this.txtSupliers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupliers_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBank);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(127, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(254, 72);
            this.groupBox3.TabIndex = 343;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "البنك";
            // 
            // txtBank
            // 
            this.txtBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBank.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(6, 28);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(242, 25);
            this.txtBank.TabIndex = 345;
            this.txtBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // txtBankID
            // 
            this.txtBankID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBankID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBankID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankID.Location = new System.Drawing.Point(83, 13);
            this.txtBankID.Name = "txtBankID";
            this.txtBankID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBankID.Size = new System.Drawing.Size(85, 25);
            this.txtBankID.TabIndex = 346;
            this.txtBankID.Visible = false;
            // 
            // txtSuplierID
            // 
            this.txtSuplierID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSuplierID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSuplierID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuplierID.Location = new System.Drawing.Point(649, 13);
            this.txtSuplierID.Name = "txtSuplierID";
            this.txtSuplierID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSuplierID.Size = new System.Drawing.Size(60, 25);
            this.txtSuplierID.TabIndex = 345;
            this.txtSuplierID.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(12, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(98, 23);
            this.checkBox1.TabIndex = 347;
            this.checkBox1.Text = "المورد والبنك";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBox1_MouseClick);
            // 
            // dtb_RefundLtrWarrantyRepTableAdapter
            // 
            this.dtb_RefundLtrWarrantyRepTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1097, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 349;
            this.label3.Text = "نوع خطاب الضمان";
            // 
            // cmbLetterKind
            // 
            this.cmbLetterKind.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblLetterWarrantyKindBindingSource, "ID", true));
            this.cmbLetterKind.DataSource = this.tblLetterWarrantyKindBindingSource;
            this.cmbLetterKind.DisplayMember = "Name";
            this.cmbLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLetterKind.FormattingEnabled = true;
            this.cmbLetterKind.Location = new System.Drawing.Point(1027, 78);
            this.cmbLetterKind.Name = "cmbLetterKind";
            this.cmbLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbLetterKind.Size = new System.Drawing.Size(177, 25);
            this.cmbLetterKind.TabIndex = 348;
            this.cmbLetterKind.ValueMember = "ID";
            this.cmbLetterKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLetterKind_KeyDown);
            // 
            // tblLetterWarrantyKindBindingSource
            // 
            this.tblLetterWarrantyKindBindingSource.DataMember = "Tbl_LetterWarrantyKind";
            this.tblLetterWarrantyKindBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_LetterWarrantyKindTableAdapter
            // 
            this.tbl_LetterWarrantyKindTableAdapter.ClearBeforeFill = true;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(799, 10);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "وارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "صادر")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(160, 25);
            this.radioGroup1.TabIndex = 350;
            this.radioGroup1.Visible = false;
            // 
            // LetterWntryRefundReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 635);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLetterKind);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtSuplierID);
            this.Controls.Add(this.txtBankID);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "LetterWntryRefundReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LetterWntryRefundReport";
            this.Load += new System.EventHandler(this.LetterWntryRefundReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtbRefundLtrWarrantyRepBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterWarranty)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWarrantyKindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSupliers;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.TextBox txtBankID;
        private System.Windows.Forms.TextBox txtSuplierID;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource dtbRefundLtrWarrantyRepBindingSource;
        private LetterWarranty letterWarranty;
        private LetterWarrantyTableAdapters.Dtb_RefundLtrWarrantyRepTableAdapter dtb_RefundLtrWarrantyRepTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLetterKind;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblLetterWarrantyKindBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyKindTableAdapter tbl_LetterWarrantyKindTableAdapter;
        public DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}