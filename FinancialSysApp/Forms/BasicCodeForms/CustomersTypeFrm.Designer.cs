namespace FinancialSysApp.Forms.BasicCodeForms
{
    partial class CustomersTypeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersTypeFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.grbNodeSelected = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridViewX7 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountsKindIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personalAccountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advacAccountingNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensesAccountDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.highamountsAccountDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.brokerAccountDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.extrasFinancialYearDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tblAccountingGuidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.dtbAccBankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtb_AccBankTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_AccBankTableAdapter();
            this.tbl_Accounting_GuidTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_Accounting_GuidTableAdapter();
            this.txtGuidID = new System.Windows.Forms.TextBox();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grbNodeSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingGuidBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbAccBankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 22);
            this.label1.TabIndex = 100;
            this.label1.Text = "تصنيفات العملاء";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ImageIndex = 5;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(519, 104);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.SelectedImageIndex = 4;
            this.treeView1.Size = new System.Drawing.Size(493, 438);
            this.treeView1.TabIndex = 99;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "engineer.png");
            this.imageList1.Images.SetKeyName(1, "development.png");
            this.imageList1.Images.SetKeyName(2, "icons8-project-100.png");
            this.imageList1.Images.SetKeyName(3, "icons8-project-100 (1).png");
            this.imageList1.Images.SetKeyName(4, "open-folder.png");
            this.imageList1.Images.SetKeyName(5, "folder.png");
            // 
            // txtSelected
            // 
            this.txtSelected.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelected.Location = new System.Drawing.Point(177, 72);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSelected.Size = new System.Drawing.Size(273, 26);
            this.txtSelected.TabIndex = 101;
            this.txtSelected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSelected_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(397, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "التصنيف";
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(628, 70);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Nametxt.Size = new System.Drawing.Size(384, 25);
            this.Nametxt.TabIndex = 104;
            this.Nametxt.TextChanged += new System.EventHandler(this.Nametxt_TextChanged);
            this.Nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nametxt_KeyDown);
            // 
            // grbNodeSelected
            // 
            this.grbNodeSelected.Controls.Add(this.checkBox1);
            this.grbNodeSelected.Controls.Add(this.label2);
            this.grbNodeSelected.Controls.Add(this.txtSelected);
            this.grbNodeSelected.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNodeSelected.Location = new System.Drawing.Point(23, 67);
            this.grbNodeSelected.Name = "grbNodeSelected";
            this.grbNodeSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbNodeSelected.Size = new System.Drawing.Size(478, 126);
            this.grbNodeSelected.TabIndex = 106;
            this.grbNodeSelected.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(45, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 21);
            this.checkBox1.TabIndex = 360;
            this.checkBox1.Text = "دفع اليكتروني";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(289, 504);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(105, 43);
            this.simpleButton4.TabIndex = 107;
            this.simpleButton4.Text = "تعديل";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(519, 67);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(99, 25);
            this.simpleButton3.TabIndex = 105;
            this.simpleButton3.Text = "بحث ";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            this.simpleButton3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleButton3_KeyDown);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(118, 504);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(105, 43);
            this.simpleButton2.TabIndex = 103;
            this.simpleButton2.Text = "حدف";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(184, 433);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(152, 43);
            this.simpleButton1.TabIndex = 102;
            this.simpleButton1.Text = "اضافه";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(212, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 19);
            this.label9.TabIndex = 356;
            this.label9.Text = "اسم الحساب";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(7, 229);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(276, 26);
            this.textBox2.TabIndex = 355;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dataGridViewX7);
            this.groupControl1.Location = new System.Drawing.Point(7, 272);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(494, 138);
            this.groupControl1.TabIndex = 354;
            this.groupControl1.Text = "الدليل المحاسبى";
            // 
            // dataGridViewX7
            // 
            this.dataGridViewX7.AllowUserToAddRows = false;
            this.dataGridViewX7.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewX7.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX7.AutoGenerateColumns = false;
            this.dataGridViewX7.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX7.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewX7.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX7.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX7.ColumnHeadersHeight = 28;
            this.dataGridViewX7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.accountNODataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.parentIDDataGridViewTextBoxColumn,
            this.fromDateDataGridViewTextBoxColumn,
            this.toDateDataGridViewTextBoxColumn,
            this.accountsKindIDDataGridViewTextBoxColumn,
            this.personalAccountDataGridViewTextBoxColumn,
            this.advacAccountingNODataGridViewTextBoxColumn,
            this.expensesAccountDataGridViewCheckBoxColumn,
            this.highamountsAccountDataGridViewCheckBoxColumn,
            this.brokerAccountDataGridViewCheckBoxColumn,
            this.extrasFinancialYearDataGridViewCheckBoxColumn});
            this.dataGridViewX7.DataSource = this.tblAccountingGuidBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX7.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX7.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewX7.EnableHeadersVisualStyles = false;
            this.dataGridViewX7.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX7.Location = new System.Drawing.Point(2, 21);
            this.dataGridViewX7.MultiSelect = false;
            this.dataGridViewX7.Name = "dataGridViewX7";
            this.dataGridViewX7.ReadOnly = true;
            this.dataGridViewX7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX7.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX7.Size = new System.Drawing.Size(490, 115);
            this.dataGridViewX7.TabIndex = 340;
            this.dataGridViewX7.UseCustomBackgroundColor = true;
            this.dataGridViewX7.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX7_CellDoubleClick);
            this.dataGridViewX7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX7_KeyDown);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // accountNODataGridViewTextBoxColumn
            // 
            this.accountNODataGridViewTextBoxColumn.DataPropertyName = "Account_NO";
            this.accountNODataGridViewTextBoxColumn.HeaderText = "رقم الحساب";
            this.accountNODataGridViewTextBoxColumn.Name = "accountNODataGridViewTextBoxColumn";
            this.accountNODataGridViewTextBoxColumn.ReadOnly = true;
            this.accountNODataGridViewTextBoxColumn.Width = 150;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "اسم الحساب";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // parentIDDataGridViewTextBoxColumn
            // 
            this.parentIDDataGridViewTextBoxColumn.DataPropertyName = "Parent_ID";
            this.parentIDDataGridViewTextBoxColumn.HeaderText = "Parent_ID";
            this.parentIDDataGridViewTextBoxColumn.Name = "parentIDDataGridViewTextBoxColumn";
            this.parentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.parentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fromDateDataGridViewTextBoxColumn
            // 
            this.fromDateDataGridViewTextBoxColumn.DataPropertyName = "From_Date";
            this.fromDateDataGridViewTextBoxColumn.HeaderText = "From_Date";
            this.fromDateDataGridViewTextBoxColumn.Name = "fromDateDataGridViewTextBoxColumn";
            this.fromDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.fromDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // toDateDataGridViewTextBoxColumn
            // 
            this.toDateDataGridViewTextBoxColumn.DataPropertyName = "To_Date";
            this.toDateDataGridViewTextBoxColumn.HeaderText = "To_Date";
            this.toDateDataGridViewTextBoxColumn.Name = "toDateDataGridViewTextBoxColumn";
            this.toDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.toDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // accountsKindIDDataGridViewTextBoxColumn
            // 
            this.accountsKindIDDataGridViewTextBoxColumn.DataPropertyName = "AccountsKind_ID";
            this.accountsKindIDDataGridViewTextBoxColumn.HeaderText = "AccountsKind_ID";
            this.accountsKindIDDataGridViewTextBoxColumn.Name = "accountsKindIDDataGridViewTextBoxColumn";
            this.accountsKindIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.accountsKindIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // personalAccountDataGridViewTextBoxColumn
            // 
            this.personalAccountDataGridViewTextBoxColumn.DataPropertyName = "PersonalAccount";
            this.personalAccountDataGridViewTextBoxColumn.HeaderText = "PersonalAccount";
            this.personalAccountDataGridViewTextBoxColumn.Name = "personalAccountDataGridViewTextBoxColumn";
            this.personalAccountDataGridViewTextBoxColumn.ReadOnly = true;
            this.personalAccountDataGridViewTextBoxColumn.Visible = false;
            // 
            // advacAccountingNODataGridViewTextBoxColumn
            // 
            this.advacAccountingNODataGridViewTextBoxColumn.DataPropertyName = "Advac_AccountingNO";
            this.advacAccountingNODataGridViewTextBoxColumn.HeaderText = "Advac_AccountingNO";
            this.advacAccountingNODataGridViewTextBoxColumn.Name = "advacAccountingNODataGridViewTextBoxColumn";
            this.advacAccountingNODataGridViewTextBoxColumn.ReadOnly = true;
            this.advacAccountingNODataGridViewTextBoxColumn.Visible = false;
            // 
            // expensesAccountDataGridViewCheckBoxColumn
            // 
            this.expensesAccountDataGridViewCheckBoxColumn.DataPropertyName = "ExpensesAccount";
            this.expensesAccountDataGridViewCheckBoxColumn.HeaderText = "ExpensesAccount";
            this.expensesAccountDataGridViewCheckBoxColumn.Name = "expensesAccountDataGridViewCheckBoxColumn";
            this.expensesAccountDataGridViewCheckBoxColumn.ReadOnly = true;
            this.expensesAccountDataGridViewCheckBoxColumn.Visible = false;
            // 
            // highamountsAccountDataGridViewCheckBoxColumn
            // 
            this.highamountsAccountDataGridViewCheckBoxColumn.DataPropertyName = "HighamountsAccount";
            this.highamountsAccountDataGridViewCheckBoxColumn.HeaderText = "HighamountsAccount";
            this.highamountsAccountDataGridViewCheckBoxColumn.Name = "highamountsAccountDataGridViewCheckBoxColumn";
            this.highamountsAccountDataGridViewCheckBoxColumn.ReadOnly = true;
            this.highamountsAccountDataGridViewCheckBoxColumn.Visible = false;
            // 
            // brokerAccountDataGridViewCheckBoxColumn
            // 
            this.brokerAccountDataGridViewCheckBoxColumn.DataPropertyName = "BrokerAccount";
            this.brokerAccountDataGridViewCheckBoxColumn.HeaderText = "BrokerAccount";
            this.brokerAccountDataGridViewCheckBoxColumn.Name = "brokerAccountDataGridViewCheckBoxColumn";
            this.brokerAccountDataGridViewCheckBoxColumn.ReadOnly = true;
            this.brokerAccountDataGridViewCheckBoxColumn.Visible = false;
            // 
            // extrasFinancialYearDataGridViewCheckBoxColumn
            // 
            this.extrasFinancialYearDataGridViewCheckBoxColumn.DataPropertyName = "ExtrasFinancialYear";
            this.extrasFinancialYearDataGridViewCheckBoxColumn.HeaderText = "ExtrasFinancialYear";
            this.extrasFinancialYearDataGridViewCheckBoxColumn.Name = "extrasFinancialYearDataGridViewCheckBoxColumn";
            this.extrasFinancialYearDataGridViewCheckBoxColumn.ReadOnly = true;
            this.extrasFinancialYearDataGridViewCheckBoxColumn.Visible = false;
            // 
            // tblAccountingGuidBindingSource
            // 
            this.tblAccountingGuidBindingSource.DataMember = "Tbl_Accounting_Guid";
            this.tblAccountingGuidBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.EnforceConstraints = false;
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(294, 229);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(207, 26);
            this.textBox1.TabIndex = 353;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(430, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 19);
            this.label8.TabIndex = 352;
            this.label8.Text = "رقم الحساب";
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtbAccBankBindingSource
            // 
            this.dtbAccBankBindingSource.DataMember = "Dtb_AccBank";
            this.dtbAccBankBindingSource.DataSource = this.bankCheques;
            // 
            // dtb_AccBankTableAdapter
            // 
            this.dtb_AccBankTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_Accounting_GuidTableAdapter
            // 
            this.tbl_Accounting_GuidTableAdapter.ClearBeforeFill = true;
            // 
            // txtGuidID
            // 
            this.txtGuidID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuidID.Location = new System.Drawing.Point(23, 197);
            this.txtGuidID.Name = "txtGuidID";
            this.txtGuidID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGuidID.Size = new System.Drawing.Size(65, 26);
            this.txtGuidID.TabIndex = 357;
            this.txtGuidID.Visible = false;
            // 
            // simpleButton5
            // 
            this.simpleButton5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton5.ImageOptions.SvgImage")));
            this.simpleButton5.Location = new System.Drawing.Point(616, 563);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(170, 40);
            this.simpleButton5.TabIndex = 358;
            this.simpleButton5.Text = "تصدير ملف اكسيل";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(541, 305);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(301, 223);
            this.gridControl1.TabIndex = 359;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "التصنيف";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // CustomersTypeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 615);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.txtGuidID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.Nametxt);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.grbNodeSelected);
            this.Name = "CustomersTypeFrm";
            this.Text = "CustomersTypeFrm";
            this.Load += new System.EventHandler(this.CustomersTypeFrm_Load);
            this.grbNodeSelected.ResumeLayout(false);
            this.grbNodeSelected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingGuidBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbAccBankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.TextBox Nametxt;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.GroupBox grbNodeSelected;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource dtbAccBankBindingSource;
        private BankChequesTableAdapters.Dtb_AccBankTableAdapter dtb_AccBankTableAdapter;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblAccountingGuidBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_Accounting_GuidTableAdapter tbl_Accounting_GuidTableAdapter;
        private System.Windows.Forms.TextBox txtGuidID;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountsKindIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personalAccountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn advacAccountingNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn expensesAccountDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn highamountsAccountDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn brokerAccountDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn extrasFinancialYearDataGridViewCheckBoxColumn;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}