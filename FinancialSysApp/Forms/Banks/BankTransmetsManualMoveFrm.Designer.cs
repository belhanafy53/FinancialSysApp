namespace FinancialSysApp.Forms.Banks
{
    partial class BankTransmetsManualMoveFrm
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
                //components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankTransmetsManualMoveFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDebitCredit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DTPDue = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransferValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAccBank = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.dtbBanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPMov = new System.Windows.Forms.DateTimePicker();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtb_BanksTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_BanksTableAdapter();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tblFiscalyearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tbl_FiscalyearTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter();
            this.txtRowId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(223, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 19);
            this.label8.TabIndex = 378;
            this.label8.Text = "الغرض";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(55, 93);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(215, 27);
            this.comboBox2.TabIndex = 377;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(30, 231);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(111, 60);
            this.simpleButton2.TabIndex = 376;
            this.simpleButton2.Text = "حذف";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(159, 103);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(89, 60);
            this.simpleButton1.TabIndex = 375;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ser});
            this.dataGridView1.Location = new System.Drawing.Point(13, 332);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(1070, 317);
            this.dataGridView1.TabIndex = 374;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // ser
            // 
            this.ser.HeaderText = "م";
            this.ser.Name = "ser";
            this.ser.ReadOnly = true;
            this.ser.Width = 50;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(291, 231);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(748, 61);
            this.txtDescription.TabIndex = 373;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(957, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 372;
            this.label7.Text = "وصف الحركه";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(459, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 371;
            this.label6.Text = "نوع الحركه";
            // 
            // cmbDebitCredit
            // 
            this.cmbDebitCredit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDebitCredit.FormattingEnabled = true;
            this.cmbDebitCredit.Items.AddRange(new object[] {
            "مدين",
            "دائن"});
            this.cmbDebitCredit.Location = new System.Drawing.Point(291, 172);
            this.cmbDebitCredit.Name = "cmbDebitCredit";
            this.cmbDebitCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDebitCredit.Size = new System.Drawing.Size(237, 27);
            this.cmbDebitCredit.TabIndex = 370;
            this.cmbDebitCredit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDebitCredit_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(712, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 369;
            this.label5.Text = "مبلغ الحركه";
            // 
            // DTPDue
            // 
            this.DTPDue.CustomFormat = "dd-MM-yyyy";
            this.DTPDue.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTPDue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPDue.Location = new System.Drawing.Point(825, 171);
            this.DTPDue.Name = "DTPDue";
            this.DTPDue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTPDue.RightToLeftLayout = true;
            this.DTPDue.Size = new System.Drawing.Size(214, 26);
            this.DTPDue.TabIndex = 368;
            this.DTPDue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPDue_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(970, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 367;
            this.label4.Text = "تاريخ الحق";
            // 
            // txtTransferValue
            // 
            this.txtTransferValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferValue.Location = new System.Drawing.Point(565, 171);
            this.txtTransferValue.Name = "txtTransferValue";
            this.txtTransferValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTransferValue.Size = new System.Drawing.Size(219, 26);
            this.txtTransferValue.TabIndex = 366;
            this.txtTransferValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransferValue_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(439, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 365;
            this.label3.Text = "رقم حساب البنك";
            // 
            // cmbAccBank
            // 
            this.cmbAccBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccBank.FormattingEnabled = true;
            this.cmbAccBank.Location = new System.Drawing.Point(291, 93);
            this.cmbAccBank.Name = "cmbAccBank";
            this.cmbAccBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAccBank.Size = new System.Drawing.Size(237, 27);
            this.cmbAccBank.TabIndex = 364;
            this.cmbAccBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAccBank_KeyDown);
            this.cmbAccBank.Leave += new System.EventHandler(this.cmbAccBank_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(750, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 19);
            this.label2.TabIndex = 363;
            this.label2.Text = "البنك";
            // 
            // cmbBank
            // 
            this.cmbBank.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dtbBanksBindingSource, "ID", true));
            this.cmbBank.DataSource = this.dtbBanksBindingSource;
            this.cmbBank.DisplayMember = "Name";
            this.cmbBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(565, 93);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBank.Size = new System.Drawing.Size(219, 27);
            this.cmbBank.TabIndex = 362;
            this.cmbBank.ValueMember = "ID";
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            this.cmbBank.Leave += new System.EventHandler(this.cmbBank_Leave);
            // 
            // dtbBanksBindingSource
            // 
            this.dtbBanksBindingSource.DataMember = "Dtb_Banks";
            this.dtbBanksBindingSource.DataSource = this.bankCheques;
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(962, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 361;
            this.label1.Text = "تاريخ الحركه";
            // 
            // DTPMov
            // 
            this.DTPMov.CustomFormat = "dd-MM-yyyy";
            this.DTPMov.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DTPMov.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPMov.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPMov.Location = new System.Drawing.Point(825, 90);
            this.DTPMov.Name = "DTPMov";
            this.DTPMov.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DTPMov.RightToLeftLayout = true;
            this.DTPMov.Size = new System.Drawing.Size(214, 26);
            this.DTPMov.TabIndex = 360;
            this.DTPMov.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPMov_KeyDown);
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(488, 21);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(127, 29);
            this.textBoxX1.TabIndex = 359;
            this.textBoxX1.Text = "حركة حساب البنك ";
            this.textBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtb_BanksTableAdapter
            // 
            this.dtb_BanksTableAdapter.ClearBeforeFill = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(225, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 19);
            this.label9.TabIndex = 380;
            this.label9.Text = "الرصيد";
            // 
            // txtbalance
            // 
            this.txtbalance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbalance.Location = new System.Drawing.Point(55, 171);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbalance.Size = new System.Drawing.Size(215, 26);
            this.txtbalance.TabIndex = 379;
            this.txtbalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbalance_KeyDown);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radGroupBox1.Controls.Add(this.label10);
            this.radGroupBox1.Controls.Add(this.simpleButton1);
            this.radGroupBox1.HeaderText = " ";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 128);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.ControlBounds = new System.Drawing.Rectangle(13, 128, 200, 100);
            this.radGroupBox1.Size = new System.Drawing.Size(1070, 183);
            this.radGroupBox1.TabIndex = 397;
            this.radGroupBox1.Text = " ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(173, -3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 19);
            this.label10.TabIndex = 314;
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblFiscalyearBindingSource, "ID", true));
            this.comboBox3.DataSource = this.tblFiscalyearBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.DropDownWidth = 100;
            this.comboBox3.Enabled = false;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(89, 374);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox3.Size = new System.Drawing.Size(118, 25);
            this.comboBox3.TabIndex = 398;
            this.comboBox3.ValueMember = "ID";
            // 
            // tblFiscalyearBindingSource
            // 
            this.tblFiscalyearBindingSource.DataMember = "Tbl_Fiscalyear";
            this.tblFiscalyearBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_FiscalyearTableAdapter
            // 
            this.tbl_FiscalyearTableAdapter.ClearBeforeFill = true;
            // 
            // txtRowId
            // 
            this.txtRowId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowId.Location = new System.Drawing.Point(30, 24);
            this.txtRowId.Name = "txtRowId";
            this.txtRowId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRowId.Size = new System.Drawing.Size(108, 26);
            this.txtRowId.TabIndex = 399;
            this.txtRowId.Visible = false;
            // 
            // BankTransmetsManualMoveFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 669);
            this.Controls.Add(this.txtRowId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtbalance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDebitCredit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DTPDue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTransferValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAccBank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPMov);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "BankTransmetsManualMoveFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BankTransmetsManualMoveFrm";
            this.Load += new System.EventHandler(this.BankTransmetsManualMoveFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDebitCredit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DTPDue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransferValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAccBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPMov;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource dtbBanksBindingSource;
        private BankChequesTableAdapters.Dtb_BanksTableAdapter dtb_BanksTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtbalance;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox3;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblFiscalyearBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter tbl_FiscalyearTableAdapter;
        private System.Windows.Forms.TextBox txtRowId;
    }
}