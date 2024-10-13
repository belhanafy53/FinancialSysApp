namespace FinancialSysApp.Forms.CashDeposit
{
    partial class CashDepositFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashDepositFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dTPDeposit = new System.Windows.Forms.DateTimePicker();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dtbBanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.txtDepositCashNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRepresentiveID = new System.Windows.Forms.TextBox();
            this.dTpBankDueDate = new System.Windows.Forms.DateTimePicker();
            this.txtAccountBnkID = new System.Windows.Forms.TextBox();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.txtBnkDepositID = new System.Windows.Forms.TextBox();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbBnkDeposit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmountCash = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRepresentive = new System.Windows.Forms.TextBox();
            this.txtAccountBnk = new System.Windows.Forms.TextBox();
            this.txtRowID = new System.Windows.Forms.TextBox();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton9 = new DevExpress.XtraEditors.SimpleButton();
            this.label35 = new System.Windows.Forms.Label();
            this.simpleButton11 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbNote = new System.Windows.Forms.ComboBox();
            this.simpleButton12 = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chckBxBasicData = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PicturePath = new System.Windows.Forms.PictureBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Ser2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.cmbAccountBank = new System.Windows.Forms.ComboBox();
            this.tblAccountsBankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtb_BanksTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_BanksTableAdapter();
            this.tbl_AccountsBankTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Tbl_AccountsBankTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblFiscalyearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tbl_FiscalyearTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter();
            this.textBox8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountsBankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 271;
            this.label1.Text = "ايداع النقديه";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(991, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 19);
            this.label19.TabIndex = 274;
            this.label19.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1036, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 272;
            this.label3.Text = "تاريخ الايداع";
            // 
            // dTPDeposit
            // 
            this.dTPDeposit.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPDeposit.Location = new System.Drawing.Point(937, 39);
            this.dTPDeposit.Name = "dTPDeposit";
            this.dTPDeposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPDeposit.RightToLeftLayout = true;
            this.dTPDeposit.Size = new System.Drawing.Size(174, 26);
            this.dTPDeposit.TabIndex = 273;
            this.dTPDeposit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPDeposit_KeyDown);
            this.dTPDeposit.Leave += new System.EventHandler(this.dTPDeposit_Leave);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.comboBox3);
            this.groupControl1.Controls.Add(this.comboBox2);
            this.groupControl1.Controls.Add(this.txtDepositCashNo);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtRepresentiveID);
            this.groupControl1.Controls.Add(this.dTpBankDueDate);
            this.groupControl1.Controls.Add(this.txtAccountBnkID);
            this.groupControl1.Controls.Add(this.txtBranchID);
            this.groupControl1.Controls.Add(this.txtBnkDepositID);
            this.groupControl1.Controls.Add(this.pdfViewer1);
            this.groupControl1.Controls.Add(this.label20);
            this.groupControl1.Controls.Add(this.label18);
            this.groupControl1.Controls.Add(this.label17);
            this.groupControl1.Controls.Add(this.cmbBnkDeposit);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txtBranch);
            this.groupControl1.Controls.Add(this.label11);
            this.groupControl1.Controls.Add(this.txtAmountCash);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtRepresentive);
            this.groupControl1.Location = new System.Drawing.Point(808, 71);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl1.Size = new System.Drawing.Size(303, 451);
            this.groupControl1.TabIndex = 275;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(175, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 323;
            this.label6.Text = "الغرض من  الحساب";
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(13, 261);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(285, 27);
            this.comboBox3.TabIndex = 322;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dtbBanksBindingSource, "ID", true));
            this.comboBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 205);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(290, 27);
            this.comboBox2.TabIndex = 321;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox2_KeyDown);
            this.comboBox2.Leave += new System.EventHandler(this.comboBox2_Leave);
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
            // txtDepositCashNo
            // 
            this.txtDepositCashNo.Enabled = false;
            this.txtDepositCashNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositCashNo.Location = new System.Drawing.Point(8, 100);
            this.txtDepositCashNo.Name = "txtDepositCashNo";
            this.txtDepositCashNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDepositCashNo.Size = new System.Drawing.Size(290, 26);
            this.txtDepositCashNo.TabIndex = 320;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 319;
            this.label2.Text = "رقم الايداع ";
            // 
            // txtRepresentiveID
            // 
            this.txtRepresentiveID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepresentiveID.Location = new System.Drawing.Point(58, 268);
            this.txtRepresentiveID.Name = "txtRepresentiveID";
            this.txtRepresentiveID.Size = new System.Drawing.Size(80, 26);
            this.txtRepresentiveID.TabIndex = 318;
            this.txtRepresentiveID.Visible = false;
            // 
            // dTpBankDueDate
            // 
            this.dTpBankDueDate.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTpBankDueDate.Enabled = false;
            this.dTpBankDueDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTpBankDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTpBankDueDate.Location = new System.Drawing.Point(125, 420);
            this.dTpBankDueDate.Name = "dTpBankDueDate";
            this.dTpBankDueDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTpBankDueDate.RightToLeftLayout = true;
            this.dTpBankDueDate.Size = new System.Drawing.Size(173, 26);
            this.dTpBankDueDate.TabIndex = 278;
            // 
            // txtAccountBnkID
            // 
            this.txtAccountBnkID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountBnkID.Location = new System.Drawing.Point(37, 180);
            this.txtAccountBnkID.Name = "txtAccountBnkID";
            this.txtAccountBnkID.Size = new System.Drawing.Size(80, 26);
            this.txtAccountBnkID.TabIndex = 279;
            this.txtAccountBnkID.Visible = false;
            // 
            // txtBranchID
            // 
            this.txtBranchID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(55, 19);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(80, 26);
            this.txtBranchID.TabIndex = 278;
            this.txtBranchID.Visible = false;
            // 
            // txtBnkDepositID
            // 
            this.txtBnkDepositID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBnkDepositID.Location = new System.Drawing.Point(37, 123);
            this.txtBnkDepositID.Name = "txtBnkDepositID";
            this.txtBnkDepositID.Size = new System.Drawing.Size(80, 26);
            this.txtBnkDepositID.TabIndex = 278;
            this.txtBnkDepositID.Visible = false;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Location = new System.Drawing.Point(415, 21);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(20, 10);
            this.pdfViewer1.TabIndex = 317;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(142, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 19);
            this.label20.TabIndex = 267;
            this.label20.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(142, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 19);
            this.label18.TabIndex = 265;
            this.label18.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(223, 398);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 19);
            this.label17.TabIndex = 264;
            this.label17.Text = "تاريخ الحق";
            // 
            // cmbBnkDeposit
            // 
            this.cmbBnkDeposit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dtbBanksBindingSource, "ID", true));
            this.cmbBnkDeposit.DataSource = this.dtbBanksBindingSource;
            this.cmbBnkDeposit.DisplayMember = "Name";
            this.cmbBnkDeposit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBnkDeposit.FormattingEnabled = true;
            this.cmbBnkDeposit.Location = new System.Drawing.Point(8, 152);
            this.cmbBnkDeposit.Name = "cmbBnkDeposit";
            this.cmbBnkDeposit.Size = new System.Drawing.Size(290, 27);
            this.cmbBnkDeposit.TabIndex = 262;
            this.cmbBnkDeposit.ValueMember = "ID";
            this.cmbBnkDeposit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBnkDeposit_KeyDown);
            this.cmbBnkDeposit.Leave += new System.EventHandler(this.cmbBnkDeposit_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(219, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 77;
            this.label5.Text = "رقم الحساب";
            // 
            // txtBranch
            // 
            this.txtBranch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(8, 44);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranch.Size = new System.Drawing.Size(290, 26);
            this.txtBranch.TabIndex = 66;
            this.txtBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranch_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(248, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 19);
            this.label11.TabIndex = 65;
            this.label11.Text = "الفرع ";
            // 
            // txtAmountCash
            // 
            this.txtAmountCash.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountCash.Location = new System.Drawing.Point(125, 314);
            this.txtAmountCash.Name = "txtAmountCash";
            this.txtAmountCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmountCash.Size = new System.Drawing.Size(173, 26);
            this.txtAmountCash.TabIndex = 3;
            this.txtAmountCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmountCash_KeyDown);
            this.txtAmountCash.Leave += new System.EventHandler(this.txtAmountCash_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "المبلغ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(216, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "البنك المودع";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(181, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 19);
            this.label10.TabIndex = 64;
            this.label10.Text = "مندوب خزينة الفرع";
            // 
            // txtRepresentive
            // 
            this.txtRepresentive.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepresentive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRepresentive.Location = new System.Drawing.Point(11, 370);
            this.txtRepresentive.Name = "txtRepresentive";
            this.txtRepresentive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRepresentive.Size = new System.Drawing.Size(290, 26);
            this.txtRepresentive.TabIndex = 63;
            this.txtRepresentive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepresentive_KeyDown);
            // 
            // txtAccountBnk
            // 
            this.txtAccountBnk.Enabled = false;
            this.txtAccountBnk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountBnk.Location = new System.Drawing.Point(698, 13);
            this.txtAccountBnk.Name = "txtAccountBnk";
            this.txtAccountBnk.Size = new System.Drawing.Size(69, 26);
            this.txtAccountBnk.TabIndex = 261;
            this.txtAccountBnk.Visible = false;
            // 
            // txtRowID
            // 
            this.txtRowID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowID.Location = new System.Drawing.Point(808, 29);
            this.txtRowID.Name = "txtRowID";
            this.txtRowID.Size = new System.Drawing.Size(67, 26);
            this.txtRowID.TabIndex = 75;
            this.txtRowID.Visible = false;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.simpleButton9);
            this.groupControl4.Controls.Add(this.label35);
            this.groupControl4.Controls.Add(this.simpleButton11);
            this.groupControl4.Controls.Add(this.cmbNote);
            this.groupControl4.Controls.Add(this.simpleButton12);
            this.groupControl4.Controls.Add(this.textBox1);
            this.groupControl4.Controls.Add(this.label13);
            this.groupControl4.Controls.Add(this.chckBxBasicData);
            this.groupControl4.Controls.Add(this.textBox2);
            this.groupControl4.Controls.Add(this.PicturePath);
            this.groupControl4.Controls.Add(this.textBox7);
            this.groupControl4.Controls.Add(this.label30);
            this.groupControl4.Controls.Add(this.textBox6);
            this.groupControl4.Controls.Add(this.dataGridView2);
            this.groupControl4.Location = new System.Drawing.Point(12, 60);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl4.Size = new System.Drawing.Size(790, 591);
            this.groupControl4.TabIndex = 276;
            this.groupControl4.Text = "النقديه المودعه بتاريخ";
            // 
            // simpleButton9
            // 
            this.simpleButton9.Appearance.BackColor = System.Drawing.Color.Black;
            this.simpleButton9.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton9.Appearance.Options.UseBackColor = true;
            this.simpleButton9.Appearance.Options.UseFont = true;
            this.simpleButton9.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton9.ImageOptions.Image")));
            this.simpleButton9.Location = new System.Drawing.Point(78, 531);
            this.simpleButton9.Name = "simpleButton9";
            this.simpleButton9.Size = new System.Drawing.Size(278, 42);
            this.simpleButton9.TabIndex = 311;
            this.simpleButton9.Text = "عرض صورة التحويل";
            this.simpleButton9.Click += new System.EventHandler(this.simpleButton9_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(325, 455);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(163, 19);
            this.label35.TabIndex = 319;
            this.label35.Text = "الملاحظات على الايداع النقدي";
            // 
            // simpleButton11
            // 
            this.simpleButton11.Appearance.BackColor = System.Drawing.Color.Black;
            this.simpleButton11.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton11.Appearance.Options.UseBackColor = true;
            this.simpleButton11.Appearance.Options.UseFont = true;
            this.simpleButton11.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton11.ImageOptions.Image")));
            this.simpleButton11.Location = new System.Drawing.Point(386, 531);
            this.simpleButton11.Name = "simpleButton11";
            this.simpleButton11.Size = new System.Drawing.Size(141, 42);
            this.simpleButton11.TabIndex = 312;
            this.simpleButton11.Text = "JPG";
            this.simpleButton11.Click += new System.EventHandler(this.simpleButton11_Click);
            // 
            // cmbNote
            // 
            this.cmbNote.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNote.FormattingEnabled = true;
            this.cmbNote.Items.AddRange(new object[] {
            "",
            "مبلغ الايداع خطأ",
            "البنك المودع خطأ",
            "الفرع خطأ",
            "تاريخ الحق خطأ"});
            this.cmbNote.Location = new System.Drawing.Point(300, 482);
            this.cmbNote.Name = "cmbNote";
            this.cmbNote.Size = new System.Drawing.Size(194, 27);
            this.cmbNote.TabIndex = 318;
            // 
            // simpleButton12
            // 
            this.simpleButton12.Appearance.BackColor = System.Drawing.Color.Black;
            this.simpleButton12.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton12.Appearance.Options.UseBackColor = true;
            this.simpleButton12.Appearance.Options.UseFont = true;
            this.simpleButton12.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton12.ImageOptions.Image")));
            this.simpleButton12.Location = new System.Drawing.Point(550, 531);
            this.simpleButton12.Name = "simpleButton12";
            this.simpleButton12.Size = new System.Drawing.Size(164, 42);
            this.simpleButton12.TabIndex = 313;
            this.simpleButton12.Text = "PDF";
            this.simpleButton12.Click += new System.EventHandler(this.simpleButton12_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(523, 482);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(234, 26);
            this.textBox1.TabIndex = 315;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(679, 455);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 19);
            this.label13.TabIndex = 314;
            this.label13.Text = "مدخل البيانات";
            // 
            // chckBxBasicData
            // 
            this.chckBxBasicData.AutoSize = true;
            this.chckBxBasicData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBxBasicData.ForeColor = System.Drawing.Color.Red;
            this.chckBxBasicData.Location = new System.Drawing.Point(73, 455);
            this.chckBxBasicData.Name = "chckBxBasicData";
            this.chckBxBasicData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckBxBasicData.Size = new System.Drawing.Size(161, 23);
            this.chckBxBasicData.TabIndex = 317;
            this.chckBxBasicData.Text = "تمت مراجعة بيانات الشيك";
            this.chckBxBasicData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckBxBasicData.UseVisualStyleBackColor = true;
            this.chckBxBasicData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chckBxBasicData_MouseClick);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(56, 482);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(203, 26);
            this.textBox2.TabIndex = 316;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // PicturePath
            // 
            this.PicturePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicturePath.Image = global::FinancialSysApp.Properties.Resources.download__2_;
            this.PicturePath.Location = new System.Drawing.Point(550, 147);
            this.PicturePath.Name = "PicturePath";
            this.PicturePath.Size = new System.Drawing.Size(21, 32);
            this.PicturePath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicturePath.TabIndex = 313;
            this.PicturePath.TabStop = false;
            this.PicturePath.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(191, 36);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(80, 26);
            this.textBox7.TabIndex = 308;
            this.textBox7.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(131, 14);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(80, 19);
            this.label30.TabIndex = 312;
            this.label30.Text = "الفرع / الجهه";
            this.label30.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Green;
            this.textBox6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox6.Location = new System.Drawing.Point(13, 36);
            this.textBox6.Name = "textBox6";
            this.textBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox6.Size = new System.Drawing.Size(200, 26);
            this.textBox6.TabIndex = 311;
            this.textBox6.Visible = false;
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ser2});
            this.dataGridView2.Location = new System.Drawing.Point(5, 32);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Size = new System.Drawing.Size(770, 392);
            this.dataGridView2.TabIndex = 81;
            this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseClick);
            // 
            // Ser2
            // 
            this.Ser2.HeaderText = "م";
            this.Ser2.Name = "Ser2";
            this.Ser2.ReadOnly = true;
            this.Ser2.Width = 30;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(983, 557);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(107, 37);
            this.simpleButton1.TabIndex = 61;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(843, 557);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(107, 37);
            this.simpleButton2.TabIndex = 277;
            this.simpleButton2.Text = "حذف";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // cmbAccountBank
            // 
            this.cmbAccountBank.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblAccountsBankBindingSource, "ID", true));
            this.cmbAccountBank.DataSource = this.tblAccountsBankBindingSource;
            this.cmbAccountBank.DisplayMember = "AccountBankNo";
            this.cmbAccountBank.Enabled = false;
            this.cmbAccountBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccountBank.FormattingEnabled = true;
            this.cmbAccountBank.Location = new System.Drawing.Point(54, 12);
            this.cmbAccountBank.Name = "cmbAccountBank";
            this.cmbAccountBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAccountBank.Size = new System.Drawing.Size(102, 27);
            this.cmbAccountBank.TabIndex = 278;
            this.cmbAccountBank.ValueMember = "ID";
            this.cmbAccountBank.Visible = false;
            // 
            // tblAccountsBankBindingSource
            // 
            this.tblAccountsBankBindingSource.DataMember = "Tbl_AccountsBank";
            this.tblAccountsBankBindingSource.DataSource = this.bankCheques;
            // 
            // dtb_BanksTableAdapter
            // 
            this.dtb_BanksTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_AccountsBankTableAdapter
            // 
            this.tbl_AccountsBankTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblFiscalyearBindingSource, "ID", true));
            this.comboBox1.DataSource = this.tblFiscalyearBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(203, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 279;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.Visible = false;
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
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(549, 277);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(34, 26);
            this.textBox8.TabIndex = 312;
            this.textBox8.Text = "\\";
            this.textBox8.Visible = false;
            // 
            // CashDepositFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 661);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmbAccountBank);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dTPDeposit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtRowID);
            this.Controls.Add(this.txtAccountBnk);
            this.Name = "CashDepositFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CashDepositFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountsBankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dTPDeposit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbBnkDeposit;
        private System.Windows.Forms.TextBox txtAccountBnk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRowID;
        private System.Windows.Forms.TextBox txtAmountCash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRepresentive;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.TextBox txtAccountBnkID;
        private System.Windows.Forms.TextBox txtBnkDepositID;
        private System.Windows.Forms.DateTimePicker dTpBankDueDate;
        private System.Windows.Forms.TextBox txtRepresentiveID;
        private System.Windows.Forms.ComboBox cmbAccountBank;
        private System.Windows.Forms.TextBox textBox7;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource dtbBanksBindingSource;
        private BankChequesTableAdapters.Dtb_BanksTableAdapter dtb_BanksTableAdapter;
        private System.Windows.Forms.BindingSource tblAccountsBankBindingSource;
        private BankChequesTableAdapters.Tbl_AccountsBankTableAdapter tbl_AccountsBankTableAdapter;
        private System.Windows.Forms.TextBox txtDepositCashNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblFiscalyearBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter tbl_FiscalyearTableAdapter;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private DevExpress.XtraEditors.SimpleButton simpleButton11;
        private DevExpress.XtraEditors.SimpleButton simpleButton12;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.PictureBox PicturePath;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chckBxBasicData;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbNote;
    }
}