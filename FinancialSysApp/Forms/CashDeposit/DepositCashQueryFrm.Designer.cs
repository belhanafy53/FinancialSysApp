namespace FinancialSysApp.Forms.CashDeposit
{
    partial class DepositCashQueryFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dTPDeposit = new System.Windows.Forms.DateTimePicker();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBnkDeposit = new System.Windows.Forms.ComboBox();
            this.dtbBanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques1 = new FinancialSysApp.BankCheques();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAccountBnkID = new System.Windows.Forms.TextBox();
            this.txtAmountCash = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRepresentiveID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRepresentive = new System.Windows.Forms.TextBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dTPDeposit2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNonDepBranches = new System.Windows.Forms.TextBox();
            this.txtAllValue = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAllCount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Ser2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الفرعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالايداعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالحقDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositBankIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accBankIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representiveIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.القيمهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالايداعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.العامالماليDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.مندوبالخزينهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.البنكDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالحسابDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDepositCashBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.depositCashDS = new FinancialSysApp.DepositCashDS();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtpDepositCashTableAdapter = new FinancialSysApp.DepositCashDSTableAdapters.DtpDepositCashTableAdapter();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtb_BanksTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_BanksTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDepositCashBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositCashDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 24);
            this.label1.TabIndex = 360;
            this.label1.Text = "استعلامات النقديه المودعه";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(944, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 361;
            this.label3.Text = "من تاريخ ايداع";
            // 
            // dTPDeposit
            // 
            this.dTPDeposit.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPDeposit.Location = new System.Drawing.Point(887, 82);
            this.dTPDeposit.Name = "dTPDeposit";
            this.dTPDeposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPDeposit.RightToLeftLayout = true;
            this.dTPDeposit.Size = new System.Drawing.Size(126, 26);
            this.dTPDeposit.TabIndex = 362;
            this.dTPDeposit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPDeposit_KeyDown);
            // 
            // txtBranchID
            // 
            this.txtBranchID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(721, 22);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(34, 26);
            this.txtBranchID.TabIndex = 367;
            this.txtBranchID.Visible = false;
            // 
            // txtBranch
            // 
            this.txtBranch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(721, 58);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranch.Size = new System.Drawing.Size(122, 26);
            this.txtBranch.TabIndex = 365;
            this.txtBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranch_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(801, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 19);
            this.label11.TabIndex = 364;
            this.label11.Text = "الفرع ";
            // 
            // cmbBnkDeposit
            // 
            this.cmbBnkDeposit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dtbBanksBindingSource, "ID", true));
            this.cmbBnkDeposit.DataSource = this.dtbBanksBindingSource;
            this.cmbBnkDeposit.DisplayMember = "Name";
            this.cmbBnkDeposit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBnkDeposit.FormattingEnabled = true;
            this.cmbBnkDeposit.Location = new System.Drawing.Point(512, 58);
            this.cmbBnkDeposit.Name = "cmbBnkDeposit";
            this.cmbBnkDeposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBnkDeposit.Size = new System.Drawing.Size(203, 27);
            this.cmbBnkDeposit.TabIndex = 369;
            this.cmbBnkDeposit.ValueMember = "ID";
            this.cmbBnkDeposit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBnkDeposit_KeyDown);
            // 
            // dtbBanksBindingSource
            // 
            this.dtbBanksBindingSource.DataMember = "Dtb_Banks";
            this.dtbBanksBindingSource.DataSource = this.bankCheques1;
            // 
            // bankCheques1
            // 
            this.bankCheques1.DataSetName = "BankCheques";
            this.bankCheques1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(641, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 19);
            this.label7.TabIndex = 368;
            this.label7.Text = "البنك المودع";
            // 
            // txtAccountBnkID
            // 
            this.txtAccountBnkID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountBnkID.Location = new System.Drawing.Point(512, 24);
            this.txtAccountBnkID.Name = "txtAccountBnkID";
            this.txtAccountBnkID.Size = new System.Drawing.Size(27, 26);
            this.txtAccountBnkID.TabIndex = 370;
            this.txtAccountBnkID.Visible = false;
            // 
            // txtAmountCash
            // 
            this.txtAmountCash.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountCash.Location = new System.Drawing.Point(397, 58);
            this.txtAmountCash.Name = "txtAmountCash";
            this.txtAmountCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmountCash.Size = new System.Drawing.Size(110, 26);
            this.txtAmountCash.TabIndex = 372;
            this.txtAmountCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmountCash_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(459, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 371;
            this.label4.Text = "المبلغ";
            // 
            // txtRepresentiveID
            // 
            this.txtRepresentiveID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepresentiveID.Location = new System.Drawing.Point(223, 25);
            this.txtRepresentiveID.Name = "txtRepresentiveID";
            this.txtRepresentiveID.Size = new System.Drawing.Size(33, 26);
            this.txtRepresentiveID.TabIndex = 375;
            this.txtRepresentiveID.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(280, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 19);
            this.label10.TabIndex = 374;
            this.label10.Text = "مندوب خزينة الفرع";
            // 
            // txtRepresentive
            // 
            this.txtRepresentive.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepresentive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRepresentive.Location = new System.Drawing.Point(223, 58);
            this.txtRepresentive.Name = "txtRepresentive";
            this.txtRepresentive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRepresentive.Size = new System.Drawing.Size(168, 26);
            this.txtRepresentive.TabIndex = 373;
            this.txtRepresentive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepresentive_KeyDown);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cmbUser);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.label11);
            this.radGroupBox1.Controls.Add(this.txtRepresentiveID);
            this.radGroupBox1.Controls.Add(this.txtBranch);
            this.radGroupBox1.Controls.Add(this.label10);
            this.radGroupBox1.Controls.Add(this.txtBranchID);
            this.radGroupBox1.Controls.Add(this.txtRepresentive);
            this.radGroupBox1.Controls.Add(this.label7);
            this.radGroupBox1.Controls.Add(this.txtAmountCash);
            this.radGroupBox1.Controls.Add(this.cmbBnkDeposit);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.txtAccountBnkID);
            this.radGroupBox1.HeaderText = " ";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 38);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(848, 129);
            this.radGroupBox1.TabIndex = 376;
            this.radGroupBox1.Text = " ";
            // 
            // cmbUser
            // 
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(5, 58);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbUser.Size = new System.Drawing.Size(212, 27);
            this.cmbUser.TabIndex = 379;
            this.cmbUser.ValueMember = "ID";
            this.cmbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUser_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(146, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 19);
            this.label6.TabIndex = 378;
            this.label6.Text = "المستخدمين";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(944, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 377;
            this.label5.Text = "الى تاريخ ايداع";
            // 
            // dTPDeposit2
            // 
            this.dTPDeposit2.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPDeposit2.Location = new System.Drawing.Point(887, 134);
            this.dTPDeposit2.Name = "dTPDeposit2";
            this.dTPDeposit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPDeposit2.RightToLeftLayout = true;
            this.dTPDeposit2.Size = new System.Drawing.Size(126, 26);
            this.dTPDeposit2.TabIndex = 376;
            this.dTPDeposit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPDeposit2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(964, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "محددات البحث";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.label8);
            this.radGroupBox2.Controls.Add(this.txtNonDepBranches);
            this.radGroupBox2.Controls.Add(this.txtAllValue);
            this.radGroupBox2.Controls.Add(this.label16);
            this.radGroupBox2.Controls.Add(this.txtAllCount);
            this.radGroupBox2.Controls.Add(this.label25);
            this.radGroupBox2.Controls.Add(this.dataGridView2);
            this.radGroupBox2.Controls.Add(this.radGroupBox4);
            this.radGroupBox2.Controls.Add(this.radGroupBox5);
            this.radGroupBox2.HeaderText = " ";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 173);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1034, 554);
            this.radGroupBox2.TabIndex = 377;
            this.radGroupBox2.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(380, 449);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(294, 19);
            this.label8.TabIndex = 315;
            this.label8.Text = "الفروع التي لم يتم ايداع نقديه لها   طبقا لمحددات البحث";
            // 
            // txtNonDepBranches
            // 
            this.txtNonDepBranches.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNonDepBranches.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNonDepBranches.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNonDepBranches.Location = new System.Drawing.Point(26, 481);
            this.txtNonDepBranches.Multiline = true;
            this.txtNonDepBranches.Name = "txtNonDepBranches";
            this.txtNonDepBranches.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNonDepBranches.Size = new System.Drawing.Size(657, 60);
            this.txtNonDepBranches.TabIndex = 314;
            this.txtNonDepBranches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAllValue
            // 
            this.txtAllValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAllValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAllValue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllValue.Location = new System.Drawing.Point(722, 503);
            this.txtAllValue.Name = "txtAllValue";
            this.txtAllValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllValue.Size = new System.Drawing.Size(169, 25);
            this.txtAllValue.TabIndex = 311;
            this.txtAllValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(838, 481);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 19);
            this.label16.TabIndex = 310;
            this.label16.Text = "الاجمالي";
            // 
            // txtAllCount
            // 
            this.txtAllCount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAllCount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAllCount.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllCount.Location = new System.Drawing.Point(897, 503);
            this.txtAllCount.Name = "txtAllCount";
            this.txtAllCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllCount.Size = new System.Drawing.Size(108, 25);
            this.txtAllCount.TabIndex = 312;
            this.txtAllCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(968, 481);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 19);
            this.label25.TabIndex = 313;
            this.label25.Text = "العدد";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ser2,
            this.iDDataGridViewTextBoxColumn,
            this.الفرعDataGridViewTextBoxColumn,
            this.branchIDDataGridViewTextBoxColumn,
            this.تاريخالايداعDataGridViewTextBoxColumn,
            this.تاريخالحقDataGridViewTextBoxColumn,
            this.depositBankIDDataGridViewTextBoxColumn,
            this.accBankIDDataGridViewTextBoxColumn,
            this.representiveIDDataGridViewTextBoxColumn,
            this.القيمهDataGridViewTextBoxColumn,
            this.fYearDataGridViewTextBoxColumn,
            this.رقمالايداعDataGridViewTextBoxColumn,
            this.العامالماليDataGridViewTextBoxColumn,
            this.مندوبالخزينهDataGridViewTextBoxColumn,
            this.البنكDataGridViewTextBoxColumn,
            this.رقمالحسابDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.dtpDepositCashBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(11, 21);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.Size = new System.Drawing.Size(1015, 419);
            this.dataGridView2.TabIndex = 82;
            // 
            // Ser2
            // 
            this.Ser2.HeaderText = "م";
            this.Ser2.Name = "Ser2";
            this.Ser2.ReadOnly = true;
            this.Ser2.Width = 30;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // الفرعDataGridViewTextBoxColumn
            // 
            this.الفرعDataGridViewTextBoxColumn.DataPropertyName = "الفرع";
            this.الفرعDataGridViewTextBoxColumn.HeaderText = "الفرع";
            this.الفرعDataGridViewTextBoxColumn.Name = "الفرعDataGridViewTextBoxColumn";
            this.الفرعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // branchIDDataGridViewTextBoxColumn
            // 
            this.branchIDDataGridViewTextBoxColumn.DataPropertyName = "BranchID";
            this.branchIDDataGridViewTextBoxColumn.HeaderText = "BranchID";
            this.branchIDDataGridViewTextBoxColumn.Name = "branchIDDataGridViewTextBoxColumn";
            this.branchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // تاريخالايداعDataGridViewTextBoxColumn
            // 
            this.تاريخالايداعDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الايداع";
            dataGridViewCellStyle2.Format = "yyyy/MM/dd";
            this.تاريخالايداعDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.تاريخالايداعDataGridViewTextBoxColumn.HeaderText = "تاريخ الايداع";
            this.تاريخالايداعDataGridViewTextBoxColumn.Name = "تاريخالايداعDataGridViewTextBoxColumn";
            this.تاريخالايداعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالحقDataGridViewTextBoxColumn
            // 
            this.تاريخالحقDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الحق";
            dataGridViewCellStyle3.Format = "yyyy/MM/dd";
            this.تاريخالحقDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.تاريخالحقDataGridViewTextBoxColumn.HeaderText = "تاريخ الحق";
            this.تاريخالحقDataGridViewTextBoxColumn.Name = "تاريخالحقDataGridViewTextBoxColumn";
            this.تاريخالحقDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // depositBankIDDataGridViewTextBoxColumn
            // 
            this.depositBankIDDataGridViewTextBoxColumn.DataPropertyName = "DepositBankID";
            this.depositBankIDDataGridViewTextBoxColumn.HeaderText = "DepositBankID";
            this.depositBankIDDataGridViewTextBoxColumn.Name = "depositBankIDDataGridViewTextBoxColumn";
            this.depositBankIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.depositBankIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // accBankIDDataGridViewTextBoxColumn
            // 
            this.accBankIDDataGridViewTextBoxColumn.DataPropertyName = "AccBankID";
            this.accBankIDDataGridViewTextBoxColumn.HeaderText = "AccBankID";
            this.accBankIDDataGridViewTextBoxColumn.Name = "accBankIDDataGridViewTextBoxColumn";
            this.accBankIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.accBankIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // representiveIDDataGridViewTextBoxColumn
            // 
            this.representiveIDDataGridViewTextBoxColumn.DataPropertyName = "RepresentiveID";
            this.representiveIDDataGridViewTextBoxColumn.HeaderText = "RepresentiveID";
            this.representiveIDDataGridViewTextBoxColumn.Name = "representiveIDDataGridViewTextBoxColumn";
            this.representiveIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.representiveIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // القيمهDataGridViewTextBoxColumn
            // 
            this.القيمهDataGridViewTextBoxColumn.DataPropertyName = "القيمه";
            this.القيمهDataGridViewTextBoxColumn.HeaderText = "القيمه";
            this.القيمهDataGridViewTextBoxColumn.Name = "القيمهDataGridViewTextBoxColumn";
            this.القيمهDataGridViewTextBoxColumn.ReadOnly = true;
            this.القيمهDataGridViewTextBoxColumn.Width = 120;
            // 
            // fYearDataGridViewTextBoxColumn
            // 
            this.fYearDataGridViewTextBoxColumn.DataPropertyName = "FYear";
            this.fYearDataGridViewTextBoxColumn.HeaderText = "FYear";
            this.fYearDataGridViewTextBoxColumn.Name = "fYearDataGridViewTextBoxColumn";
            this.fYearDataGridViewTextBoxColumn.ReadOnly = true;
            this.fYearDataGridViewTextBoxColumn.Visible = false;
            // 
            // رقمالايداعDataGridViewTextBoxColumn
            // 
            this.رقمالايداعDataGridViewTextBoxColumn.DataPropertyName = "رقم الايداع";
            this.رقمالايداعDataGridViewTextBoxColumn.HeaderText = "رقم الايداع";
            this.رقمالايداعDataGridViewTextBoxColumn.Name = "رقمالايداعDataGridViewTextBoxColumn";
            this.رقمالايداعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // العامالماليDataGridViewTextBoxColumn
            // 
            this.العامالماليDataGridViewTextBoxColumn.DataPropertyName = "العام المالي";
            this.العامالماليDataGridViewTextBoxColumn.HeaderText = "العام المالي";
            this.العامالماليDataGridViewTextBoxColumn.Name = "العامالماليDataGridViewTextBoxColumn";
            this.العامالماليDataGridViewTextBoxColumn.ReadOnly = true;
            this.العامالماليDataGridViewTextBoxColumn.Visible = false;
            // 
            // مندوبالخزينهDataGridViewTextBoxColumn
            // 
            this.مندوبالخزينهDataGridViewTextBoxColumn.DataPropertyName = "مندوب الخزينه";
            this.مندوبالخزينهDataGridViewTextBoxColumn.HeaderText = "مندوب الخزينه";
            this.مندوبالخزينهDataGridViewTextBoxColumn.Name = "مندوبالخزينهDataGridViewTextBoxColumn";
            this.مندوبالخزينهDataGridViewTextBoxColumn.ReadOnly = true;
            this.مندوبالخزينهDataGridViewTextBoxColumn.Width = 200;
            // 
            // البنكDataGridViewTextBoxColumn
            // 
            this.البنكDataGridViewTextBoxColumn.DataPropertyName = "البنك";
            this.البنكDataGridViewTextBoxColumn.HeaderText = "البنك";
            this.البنكDataGridViewTextBoxColumn.Name = "البنكDataGridViewTextBoxColumn";
            this.البنكDataGridViewTextBoxColumn.ReadOnly = true;
            this.البنكDataGridViewTextBoxColumn.Width = 150;
            // 
            // رقمالحسابDataGridViewTextBoxColumn
            // 
            this.رقمالحسابDataGridViewTextBoxColumn.DataPropertyName = "رقم الحساب";
            this.رقمالحسابDataGridViewTextBoxColumn.HeaderText = "رقم الحساب";
            this.رقمالحسابDataGridViewTextBoxColumn.Name = "رقمالحسابDataGridViewTextBoxColumn";
            this.رقمالحسابDataGridViewTextBoxColumn.ReadOnly = true;
            this.رقمالحسابDataGridViewTextBoxColumn.Width = 150;
            // 
            // dtpDepositCashBindingSource
            // 
            this.dtpDepositCashBindingSource.DataMember = "DtpDepositCash";
            this.dtpDepositCashBindingSource.DataSource = this.depositCashDS;
            // 
            // depositCashDS
            // 
            this.depositCashDS.DataSetName = "DepositCashDS";
            this.depositCashDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.HeaderText = "";
            this.radGroupBox4.Location = new System.Drawing.Point(702, 461);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(317, 88);
            this.radGroupBox4.TabIndex = 379;
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.HeaderText = "";
            this.radGroupBox5.Location = new System.Drawing.Point(11, 461);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.Size = new System.Drawing.Size(685, 88);
            this.radGroupBox5.TabIndex = 380;
            // 
            // dtpDepositCashTableAdapter
            // 
            this.dtpDepositCashTableAdapter.ClearBeforeFill = true;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.HeaderText = " ";
            this.radGroupBox3.Location = new System.Drawing.Point(866, 39);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(180, 128);
            this.radGroupBox3.TabIndex = 378;
            this.radGroupBox3.Text = " ";
            // 
            // dtb_BanksTableAdapter
            // 
            this.dtb_BanksTableAdapter.ClearBeforeFill = true;
            // 
            // DepositCashQueryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 739);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dTPDeposit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dTPDeposit2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox3);
            this.Name = "DepositCashQueryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.DepositCashQueryFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDepositCashBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositCashDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dTPDeposit;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBnkDeposit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAccountBnkID;
        private System.Windows.Forms.TextBox txtAmountCash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRepresentiveID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRepresentive;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dTPDeposit2;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource dtpDepositCashBindingSource;
        private DepositCashDS depositCashDS;
        private DepositCashDSTableAdapters.DtpDepositCashTableAdapter dtpDepositCashTableAdapter;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private System.Windows.Forms.BindingSource dtbBanksBindingSource;
        private BankCheques bankCheques1;
        private BankChequesTableAdapters.Dtb_BanksTableAdapter dtb_BanksTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الفرعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالايداعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالحقDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depositBankIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accBankIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn representiveIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn القيمهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالايداعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn العامالماليDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn مندوبالخزينهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn البنكDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالحسابDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtAllValue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAllCount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNonDepBranches;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
    }
}