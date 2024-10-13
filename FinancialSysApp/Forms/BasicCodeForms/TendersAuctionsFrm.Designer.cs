namespace FinancialSysApp.Forms.BasicCodeForms
{
    partial class TendersAuctionsFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TendersAuctionsFrm));
            this.dtpTendersDate = new System.Windows.Forms.DateTimePicker();
            this.txtTendersNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialYearIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseMethodeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finYearNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTBTendersBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.dTBTendersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dTBTendersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTendertId = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPurchMethod = new System.Windows.Forms.ComboBox();
            this.tblPurchaseMethodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.tbl_PurchaseMethodsTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_PurchaseMethodsTableAdapter();
            this.label7 = new System.Windows.Forms.Label();
            this.dTB_TendersTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.DTB_TendersTableAdapter();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblFiscalyearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblTendersAuctionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_TendersAuctionsTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_TendersAuctionsTableAdapter();
            this.tbl_FiscalyearTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBTendersBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBTendersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBTendersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPurchaseMethodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTendersAuctionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTendersDate
            // 
            this.dtpTendersDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTendersDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTendersDate.Location = new System.Drawing.Point(6, 62);
            this.dtpTendersDate.Name = "dtpTendersDate";
            this.dtpTendersDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpTendersDate.RightToLeftLayout = true;
            this.dtpTendersDate.Size = new System.Drawing.Size(213, 26);
            this.dtpTendersDate.TabIndex = 61;
            this.dtpTendersDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpTendersDate_KeyDown);
            this.dtpTendersDate.Leave += new System.EventHandler(this.dtpTendersDate_Leave);
            // 
            // txtTendersNo
            // 
            this.txtTendersNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTendersNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTendersNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTendersNo.Location = new System.Drawing.Point(226, 62);
            this.txtTendersNo.Name = "txtTendersNo";
            this.txtTendersNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTendersNo.Size = new System.Drawing.Size(162, 26);
            this.txtTendersNo.TabIndex = 60;
            this.txtTendersNo.TextChanged += new System.EventHandler(this.txtTendersNo_TextChanged);
            this.txtTendersNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTendersNo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(267, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(174, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 19);
            this.label4.TabIndex = 66;
            this.label4.Text = "تاريخ  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 65;
            this.label3.Text = "رقم  ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
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
            this.iDDataGridViewTextBoxColumn,
            this.tenderNoDataGridViewTextBoxColumn,
            this.tenderDateDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.financialYearIdDataGridViewTextBoxColumn,
            this.purchaseMethodeIDDataGridViewTextBoxColumn,
            this.finYearNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dTBTendersBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(7, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(654, 399);
            this.dataGridView1.TabIndex = 70;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // tenderNoDataGridViewTextBoxColumn
            // 
            this.tenderNoDataGridViewTextBoxColumn.DataPropertyName = "TenderNo";
            this.tenderNoDataGridViewTextBoxColumn.HeaderText = "رقم المناقصه - المزايده";
            this.tenderNoDataGridViewTextBoxColumn.Name = "tenderNoDataGridViewTextBoxColumn";
            this.tenderNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tenderDateDataGridViewTextBoxColumn
            // 
            this.tenderDateDataGridViewTextBoxColumn.DataPropertyName = "TenderDate";
            this.tenderDateDataGridViewTextBoxColumn.HeaderText = "تاريخ المناقصه - المزايده";
            this.tenderDateDataGridViewTextBoxColumn.Name = "tenderDateDataGridViewTextBoxColumn";
            this.tenderDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "طريقة الشراء";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 120;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "الغرض";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteDataGridViewTextBoxColumn.Width = 150;
            // 
            // financialYearIdDataGridViewTextBoxColumn
            // 
            this.financialYearIdDataGridViewTextBoxColumn.DataPropertyName = "FinancialYearId";
            this.financialYearIdDataGridViewTextBoxColumn.HeaderText = "FinancialYearId";
            this.financialYearIdDataGridViewTextBoxColumn.Name = "financialYearIdDataGridViewTextBoxColumn";
            this.financialYearIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.financialYearIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // purchaseMethodeIDDataGridViewTextBoxColumn
            // 
            this.purchaseMethodeIDDataGridViewTextBoxColumn.DataPropertyName = "PurchaseMethodeID";
            this.purchaseMethodeIDDataGridViewTextBoxColumn.HeaderText = "PurchaseMethodeID";
            this.purchaseMethodeIDDataGridViewTextBoxColumn.Name = "purchaseMethodeIDDataGridViewTextBoxColumn";
            this.purchaseMethodeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseMethodeIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // finYearNameDataGridViewTextBoxColumn
            // 
            this.finYearNameDataGridViewTextBoxColumn.DataPropertyName = "FinYearName";
            this.finYearNameDataGridViewTextBoxColumn.HeaderText = "العام المالي";
            this.finYearNameDataGridViewTextBoxColumn.Name = "finYearNameDataGridViewTextBoxColumn";
            this.finYearNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dTBTendersBindingSource2
            // 
            this.dTBTendersBindingSource2.DataMember = "DTB_Tenders";
            this.dTBTendersBindingSource2.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dTBTendersBindingSource1
            // 
            this.dTBTendersBindingSource1.DataMember = "DTB_Tenders";
            this.dTBTendersBindingSource1.DataSource = this.financialSysDataSet;
            // 
            // dTBTendersBindingSource
            // 
            this.dTBTendersBindingSource.DataMember = "DTB_Tenders";
            this.dTBTendersBindingSource.DataSource = this.financialSysDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 83;
            this.label1.Text = "المناقصات - المزايدات  ";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(235, 615);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(103, 37);
            this.simpleButton2.TabIndex = 82;
            this.simpleButton2.Text = "حدف";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(394, 615);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 37);
            this.simpleButton1.TabIndex = 81;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(98, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "*";
            // 
            // txtTendertId
            // 
            this.txtTendertId.Location = new System.Drawing.Point(49, 14);
            this.txtTendertId.Name = "txtTendertId";
            this.txtTendertId.Size = new System.Drawing.Size(100, 20);
            this.txtTendertId.TabIndex = 85;
            this.txtTendertId.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(226, 113);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(435, 79);
            this.textBox1.TabIndex = 86;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(606, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 87;
            this.label6.Text = "الغرض  ";
            // 
            // cmbPurchMethod
            // 
            this.cmbPurchMethod.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblPurchaseMethodsBindingSource, "ID", true));
            this.cmbPurchMethod.DataSource = this.tblPurchaseMethodsBindingSource;
            this.cmbPurchMethod.DisplayMember = "Name";
            this.cmbPurchMethod.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPurchMethod.FormattingEnabled = true;
            this.cmbPurchMethod.Location = new System.Drawing.Point(394, 62);
            this.cmbPurchMethod.Name = "cmbPurchMethod";
            this.cmbPurchMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPurchMethod.Size = new System.Drawing.Size(267, 27);
            this.cmbPurchMethod.TabIndex = 88;
            this.cmbPurchMethod.ValueMember = "ID";
            this.cmbPurchMethod.SelectionChangeCommitted += new System.EventHandler(this.cmbPurchMethod_SelectionChangeCommitted);
            this.cmbPurchMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPurchMethod_KeyDown);
            // 
            // tblPurchaseMethodsBindingSource
            // 
            this.tblPurchaseMethodsBindingSource.DataMember = "Tbl_PurchaseMethods";
            this.tblPurchaseMethodsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(580, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 19);
            this.label9.TabIndex = 89;
            this.label9.Text = "طريقة الشراء";
            // 
            // tbl_PurchaseMethodsTableAdapter
            // 
            this.tbl_PurchaseMethodsTableAdapter.ClearBeforeFill = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(540, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "*";
            // 
            // dTB_TendersTableAdapter
            // 
            this.dTB_TendersTableAdapter.ClearBeforeFill = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(150, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 91;
            this.label8.Text = "العام المالي";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblFiscalyearBindingSource, "ID", true));
            this.comboBox1.DataSource = this.tblFiscalyearBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 27);
            this.comboBox1.TabIndex = 92;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // tblFiscalyearBindingSource
            // 
            this.tblFiscalyearBindingSource.DataMember = "Tbl_Fiscalyear";
            this.tblFiscalyearBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tblTendersAuctionsBindingSource
            // 
            this.tblTendersAuctionsBindingSource.DataMember = "Tbl_TendersAuctions";
            this.tblTendersAuctionsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_TendersAuctionsTableAdapter
            // 
            this.tbl_TendersAuctionsTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_FiscalyearTableAdapter
            // 
            this.tbl_FiscalyearTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblFiscalyearBindingSource, "ID", true));
            this.comboBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "جهد منخفض",
            "جهد متوسط"});
            this.comboBox2.Location = new System.Drawing.Point(78, 165);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(142, 27);
            this.comboBox2.TabIndex = 94;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(174, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 19);
            this.label10.TabIndex = 93;
            this.label10.Text = "الجهد";
            // 
            // TendersAuctionsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 661);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbPurchMethod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtTendertId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTendersDate);
            this.Controls.Add(this.txtTendersNo);
            this.Name = "TendersAuctionsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TendersAuctionsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBTendersBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBTendersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBTendersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPurchaseMethodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTendersAuctionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTendersDate;
        private System.Windows.Forms.TextBox txtTendersNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.TextBox txtTendertId;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPurchMethod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource tblPurchaseMethodsBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_PurchaseMethodsTableAdapter tbl_PurchaseMethodsTableAdapter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource dTBTendersBindingSource;
        private FinancialSysDataSetTableAdapters.DTB_TendersTableAdapter dTB_TendersTableAdapter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource tblTendersAuctionsBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_TendersAuctionsTableAdapter tbl_TendersAuctionsTableAdapter;
        private System.Windows.Forms.BindingSource tblFiscalyearBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter tbl_FiscalyearTableAdapter;
        private System.Windows.Forms.BindingSource dTBTendersBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialYearIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseMethodeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finYearNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dTBTendersBindingSource2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label10;
    }
}