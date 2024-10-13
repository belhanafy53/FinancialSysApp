namespace FinancialSysApp.Forms.Banks.Reports
{
    partial class BankCollectedOrNotFrm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tblBankMovementBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bankTransmentDS = new FinancialSysApp.BankTransmentDS();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tblAccountsBankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tblBankMovementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_BankMovementTableAdapter = new FinancialSysApp.BankTransmentDSTableAdapters.Tbl_BankMovementTableAdapter();
            this.tbl_AccountsBankTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Tbl_AccountsBankTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.tblMovementBankTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_MovementBankTypeTableAdapter = new FinancialSysApp.BankTransmentDSTableAdapters.Tbl_MovementBankTypeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankMovementBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountsBankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankMovementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMovementBankTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tblBankMovementBindingSource1
            // 
            this.tblBankMovementBindingSource1.DataMember = "Tbl_BankMovement";
            this.tblBankMovementBindingSource1.DataSource = this.bankTransmentDS;
            // 
            // bankTransmentDS
            // 
            this.bankTransmentDS.DataSetName = "BankTransmentDS";
            this.bankTransmentDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.textBoxX1.Location = new System.Drawing.Point(371, 12);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(255, 26);
            this.textBoxX1.TabIndex = 334;
            this.textBoxX1.Text = "بيان بما تم  / وما لم تتم ربطه خلال الفتره ";
            this.textBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox4);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.DTPFrom);
            this.groupBox2.Controls.Add(this.DTPTo);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(805, 126);
            this.groupBox2.TabIndex = 333;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تاريخ الحركه ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(469, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 340;
            this.label4.Text = "رقم الحساب";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.tblAccountsBankBindingSource;
            this.comboBox2.DisplayMember = "AccountBankNo";
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(266, 95);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(273, 26);
            this.comboBox2.TabIndex = 339;
            this.comboBox2.ValueMember = "ID";
            this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox2_KeyDown);
            // 
            // tblAccountsBankBindingSource
            // 
            this.tblAccountsBankBindingSource.DataMember = "Tbl_AccountsBank";
            this.tblAccountsBankBindingSource.DataSource = this.bankCheques;
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(507, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 19);
            this.label3.TabIndex = 338;
            this.label3.Text = "البنك";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(266, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 26);
            this.comboBox1.TabIndex = 337;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(636, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 324;
            this.label2.Text = "الى";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(761, 26);
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
            this.DTPFrom.Location = new System.Drawing.Point(675, 53);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTPFrom.RightToLeftLayout = true;
            this.DTPFrom.Size = new System.Drawing.Size(118, 23);
            this.DTPFrom.TabIndex = 9;
            this.DTPFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPFrom_KeyDown);
            // 
            // DTPTo
            // 
            this.DTPTo.CustomFormat = "dd-MM-yyyy";
            this.DTPTo.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTPTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPTo.Location = new System.Drawing.Point(545, 53);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTPTo.RightToLeftLayout = true;
            this.DTPTo.Size = new System.Drawing.Size(113, 23);
            this.DTPTo.TabIndex = 10;
            this.DTPTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPTo_KeyDown);
            // 
            // reportViewer1
            // 
            reportDataSource9.Name = "DataSet1";
            reportDataSource9.Value = this.tblBankMovementBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TreasurCollBankCheqAudit.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 174);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(976, 487);
            this.reportViewer1.TabIndex = 336;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(823, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(165, 92);
            this.groupBox1.TabIndex = 335;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "موقف الربط";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(29, 53);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(101, 23);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "ما لم يتم ربطه";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBox2_MouseClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(47, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 23);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "ما تم ربطه";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBox1_MouseClick);
            // 
            // tblBankMovementBindingSource
            // 
            this.tblBankMovementBindingSource.DataMember = "Tbl_BankMovement";
            this.tblBankMovementBindingSource.DataSource = this.bankTransmentDS;
            // 
            // tbl_BankMovementTableAdapter
            // 
            this.tbl_BankMovementTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_AccountsBankTableAdapter
            // 
            this.tbl_AccountsBankTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 341;
            this.label5.Text = "التصنيف الرئيسي";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 19);
            this.label6.TabIndex = 342;
            this.label6.Text = "التصنيف الفرعي";
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblMovementBankTypeBindingSource, "ID", true));
            this.comboBox3.DataSource = this.tblMovementBankTypeBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(6, 43);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(221, 26);
            this.comboBox3.TabIndex = 343;
            this.comboBox3.ValueMember = "ID";
            this.comboBox3.SelectionChangeCommitted += new System.EventHandler(this.comboBox3_SelectionChangeCommitted);
            this.comboBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox3_KeyDown);
            // 
            // comboBox4
            // 
            this.comboBox4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(6, 99);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(221, 26);
            this.comboBox4.TabIndex = 344;
            this.comboBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox4_KeyDown);
            // 
            // tblMovementBankTypeBindingSource
            // 
            this.tblMovementBankTypeBindingSource.DataMember = "Tbl_MovementBankType";
            this.tblMovementBankTypeBindingSource.DataSource = this.bankTransmentDS;
            // 
            // tbl_MovementBankTypeTableAdapter
            // 
            this.tbl_MovementBankTypeTableAdapter.ClearBeforeFill = true;
            // 
            // BankCollectedOrNotFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 689);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "BankCollectedOrNotFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BankCollectedOrNotFrm";
            this.Load += new System.EventHandler(this.BankCollectedOrNotFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblBankMovementBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountsBankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankMovementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMovementBankTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private BankTransmentDS bankTransmentDS;
        private System.Windows.Forms.BindingSource tblBankMovementBindingSource;
        private BankTransmentDSTableAdapters.Tbl_BankMovementTableAdapter tbl_BankMovementTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource tblAccountsBankBindingSource;
        private BankChequesTableAdapters.Tbl_AccountsBankTableAdapter tbl_AccountsBankTableAdapter;
        private System.Windows.Forms.BindingSource tblBankMovementBindingSource1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.BindingSource tblMovementBankTypeBindingSource;
        private BankTransmentDSTableAdapters.Tbl_MovementBankTypeTableAdapter tbl_MovementBankTypeTableAdapter;
    }
}