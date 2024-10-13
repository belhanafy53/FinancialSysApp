namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class ScanDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanDocuments));
            this.lblListOfScanner = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMultiScan = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.lstListOfScanner = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtEmpRecieveID = new System.Windows.Forms.TextBox();
            this.MskExpandLastDate = new System.Windows.Forms.TextBox();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.txtLetterKindID = new System.Windows.Forms.TextBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtLetterKind = new System.Windows.Forms.TextBox();
            this.txtLetterFullNo = new System.Windows.Forms.TextBox();
            this.LetterId = new System.Windows.Forms.TextBox();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.LblLetterKind = new System.Windows.Forms.Label();
            this.LblBank = new System.Windows.Forms.Label();
            this.LblLetterFullNo = new System.Windows.Forms.Label();
            this.Lblvalue = new System.Windows.Forms.Label();
            this.txtcurrency = new System.Windows.Forms.TextBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblDocumentProcessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysEventsDataSet3 = new FinancialSysApp.FinancialSysEventsDataSet3();
            this.tblLetterWarrantyKind1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tbl_LetterWarrantyKind1TableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyKind1TableAdapter();
            this.tbl_DocumentProcessTableAdapter = new FinancialSysApp.FinancialSysEventsDataSet3TableAdapters.Tbl_DocumentProcessTableAdapter();
            this.txtProcessID = new System.Windows.Forms.TextBox();
            this.grpBOrderKind = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LblLetterDate = new System.Windows.Forms.Label();
            this.txtLetterDate = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtDocumentArchPr = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDocumentProcessBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysEventsDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWarrantyKind1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            this.grpBOrderKind.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblListOfScanner
            // 
            this.lblListOfScanner.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListOfScanner.Location = new System.Drawing.Point(274, 9);
            this.lblListOfScanner.Name = "lblListOfScanner";
            this.lblListOfScanner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblListOfScanner.Size = new System.Drawing.Size(190, 23);
            this.lblListOfScanner.TabIndex = 0;
            this.lblListOfScanner.Text = "قائمة الماسح الضوئي";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMultiScan);
            this.panel1.Controls.Add(this.btnScan);
            this.panel1.Controls.Add(this.lstListOfScanner);
            this.panel1.Controls.Add(this.lblListOfScanner);
            this.panel1.Location = new System.Drawing.Point(668, 538);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 148);
            this.panel1.TabIndex = 3;
            // 
            // btnMultiScan
            // 
            this.btnMultiScan.Enabled = false;
            this.btnMultiScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnMultiScan.Location = new System.Drawing.Point(11, 109);
            this.btnMultiScan.Name = "btnMultiScan";
            this.btnMultiScan.Size = new System.Drawing.Size(192, 31);
            this.btnMultiScan.TabIndex = 2;
            this.btnMultiScan.Text = "Scan Multi Papers";
            this.btnMultiScan.UseVisualStyleBackColor = true;
            this.btnMultiScan.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(237, 109);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(224, 31);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan One Paper";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lstListOfScanner
            // 
            this.lstListOfScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListOfScanner.FormattingEnabled = true;
            this.lstListOfScanner.ItemHeight = 16;
            this.lstListOfScanner.Location = new System.Drawing.Point(12, 35);
            this.lstListOfScanner.Name = "lstListOfScanner";
            this.lstListOfScanner.Size = new System.Drawing.Size(454, 68);
            this.lstListOfScanner.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 609);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtEmpRecieveID
            // 
            this.txtEmpRecieveID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpRecieveID.Location = new System.Drawing.Point(12, 580);
            this.txtEmpRecieveID.Name = "txtEmpRecieveID";
            this.txtEmpRecieveID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEmpRecieveID.Size = new System.Drawing.Size(66, 22);
            this.txtEmpRecieveID.TabIndex = 292;
            this.txtEmpRecieveID.Visible = false;
            // 
            // MskExpandLastDate
            // 
            this.MskExpandLastDate.Enabled = false;
            this.MskExpandLastDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskExpandLastDate.Location = new System.Drawing.Point(12, 610);
            this.MskExpandLastDate.Name = "MskExpandLastDate";
            this.MskExpandLastDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskExpandLastDate.Size = new System.Drawing.Size(48, 25);
            this.MskExpandLastDate.TabIndex = 291;
            this.MskExpandLastDate.Visible = false;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(662, 1);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "وارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "صادر")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(160, 25);
            this.radioGroup1.TabIndex = 290;
            this.radioGroup1.Visible = false;
            // 
            // txtLetterKindID
            // 
            this.txtLetterKindID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKindID.Location = new System.Drawing.Point(139, 580);
            this.txtLetterKindID.Name = "txtLetterKindID";
            this.txtLetterKindID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKindID.Size = new System.Drawing.Size(66, 22);
            this.txtLetterKindID.TabIndex = 289;
            this.txtLetterKindID.Visible = false;
            // 
            // txtBank
            // 
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(662, 40);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(244, 25);
            this.txtBank.TabIndex = 287;
            // 
            // txtLetterKind
            // 
            this.txtLetterKind.Enabled = false;
            this.txtLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKind.Location = new System.Drawing.Point(921, 40);
            this.txtLetterKind.Name = "txtLetterKind";
            this.txtLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKind.Size = new System.Drawing.Size(204, 25);
            this.txtLetterKind.TabIndex = 286;
            // 
            // txtLetterFullNo
            // 
            this.txtLetterFullNo.Enabled = false;
            this.txtLetterFullNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterFullNo.Location = new System.Drawing.Point(921, 95);
            this.txtLetterFullNo.Name = "txtLetterFullNo";
            this.txtLetterFullNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterFullNo.Size = new System.Drawing.Size(204, 25);
            this.txtLetterFullNo.TabIndex = 285;
            // 
            // LetterId
            // 
            this.LetterId.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterId.Location = new System.Drawing.Point(45, 566);
            this.LetterId.Name = "LetterId";
            this.LetterId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LetterId.Size = new System.Drawing.Size(66, 22);
            this.LetterId.TabIndex = 284;
            this.LetterId.Visible = false;
            // 
            // txtvalue
            // 
            this.txtvalue.Enabled = false;
            this.txtvalue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalue.Location = new System.Drawing.Point(955, 143);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtvalue.Size = new System.Drawing.Size(170, 25);
            this.txtvalue.TabIndex = 288;
            // 
            // LblLetterKind
            // 
            this.LblLetterKind.AutoSize = true;
            this.LblLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLetterKind.Location = new System.Drawing.Point(1057, 20);
            this.LblLetterKind.Name = "LblLetterKind";
            this.LblLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblLetterKind.Size = new System.Drawing.Size(69, 17);
            this.LblLetterKind.TabIndex = 282;
            this.LblLetterKind.Text = "نوع الخطاب";
            // 
            // LblBank
            // 
            this.LblBank.AutoSize = true;
            this.LblBank.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBank.Location = new System.Drawing.Point(842, 20);
            this.LblBank.Name = "LblBank";
            this.LblBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblBank.Size = new System.Drawing.Size(32, 17);
            this.LblBank.TabIndex = 281;
            this.LblBank.Text = "البنك";
            // 
            // LblLetterFullNo
            // 
            this.LblLetterFullNo.AutoSize = true;
            this.LblLetterFullNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLetterFullNo.Location = new System.Drawing.Point(1033, 71);
            this.LblLetterFullNo.Name = "LblLetterFullNo";
            this.LblLetterFullNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblLetterFullNo.Size = new System.Drawing.Size(70, 17);
            this.LblLetterFullNo.TabIndex = 280;
            this.LblLetterFullNo.Text = "رقم الخطاب ";
            // 
            // Lblvalue
            // 
            this.Lblvalue.AutoSize = true;
            this.Lblvalue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblvalue.Location = new System.Drawing.Point(1054, 123);
            this.Lblvalue.Name = "Lblvalue";
            this.Lblvalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lblvalue.Size = new System.Drawing.Size(71, 17);
            this.Lblvalue.TabIndex = 283;
            this.Lblvalue.Text = "مبلغ الخطاب";
            // 
            // txtcurrency
            // 
            this.txtcurrency.Enabled = false;
            this.txtcurrency.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcurrency.Location = new System.Drawing.Point(875, 145);
            this.txtcurrency.Name = "txtcurrency";
            this.txtcurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcurrency.Size = new System.Drawing.Size(71, 21);
            this.txtcurrency.TabIndex = 293;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(661, 189);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(99, 25);
            this.simpleButton3.TabIndex = 296;
            this.simpleButton3.Text = "بحث ";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(767, 192);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Nametxt.Size = new System.Drawing.Size(358, 25);
            this.Nametxt.TabIndex = 294;
            this.Nametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nametxt_KeyDown);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(662, 220);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.SelectedImageIndex = 9;
            this.treeView1.Size = new System.Drawing.Size(467, 312);
            this.treeView1.TabIndex = 295;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-folder-30.png");
            this.imageList1.Images.SetKeyName(1, "icons8-opened-folder-30.png");
            this.imageList1.Images.SetKeyName(2, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(3, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(4, "icons8-opened-folder-48.png");
            this.imageList1.Images.SetKeyName(5, "icons8-opened-folder-100.png");
            this.imageList1.Images.SetKeyName(6, "icons8-folder-48.png");
            this.imageList1.Images.SetKeyName(7, "open-file.png");
            this.imageList1.Images.SetKeyName(8, "folder.png");
            this.imageList1.Images.SetKeyName(9, "open-folder.png");
            this.imageList1.Images.SetKeyName(10, "folders.png");
            this.imageList1.Images.SetKeyName(11, "folder (1).png");
            this.imageList1.Images.SetKeyName(12, "open-folder (1).png");
            this.imageList1.Images.SetKeyName(13, "folder (2).png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1022, 172);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 297;
            this.label1.Text = "بحث في التصنيفات";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblDocumentProcessBindingSource, "ID", true));
            this.comboBox1.DataSource = this.tblDocumentProcessBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(680, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 298;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.Visible = false;
            // 
            // tblDocumentProcessBindingSource
            // 
            this.tblDocumentProcessBindingSource.DataMember = "Tbl_DocumentProcess";
            this.tblDocumentProcessBindingSource.DataSource = this.financialSysEventsDataSet3;
            // 
            // financialSysEventsDataSet3
            // 
            this.financialSysEventsDataSet3.DataSetName = "FinancialSysEventsDataSet3";
            this.financialSysEventsDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblLetterWarrantyKind1BindingSource
            // 
            this.tblLetterWarrantyKind1BindingSource.DataMember = "Tbl_LetterWarrantyKind1";
            this.tblLetterWarrantyKind1BindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_LetterWarrantyKind1TableAdapter
            // 
            this.tbl_LetterWarrantyKind1TableAdapter.ClearBeforeFill = true;
            // 
            // tbl_DocumentProcessTableAdapter
            // 
            this.tbl_DocumentProcessTableAdapter.ClearBeforeFill = true;
            // 
            // txtProcessID
            // 
            this.txtProcessID.Enabled = false;
            this.txtProcessID.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessID.Location = new System.Drawing.Point(935, 12);
            this.txtProcessID.Name = "txtProcessID";
            this.txtProcessID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProcessID.Size = new System.Drawing.Size(71, 21);
            this.txtProcessID.TabIndex = 299;
            this.txtProcessID.Visible = false;
            // 
            // grpBOrderKind
            // 
            this.grpBOrderKind.BackColor = System.Drawing.Color.White;
            this.grpBOrderKind.Controls.Add(this.textBox2);
            this.grpBOrderKind.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBOrderKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpBOrderKind.Location = new System.Drawing.Point(3, 1);
            this.grpBOrderKind.Name = "grpBOrderKind";
            this.grpBOrderKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpBOrderKind.Size = new System.Drawing.Size(653, 640);
            this.grpBOrderKind.TabIndex = 300;
            this.grpBOrderKind.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(154, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 26);
            this.textBox2.TabIndex = 305;
            // 
            // LblLetterDate
            // 
            this.LblLetterDate.AutoSize = true;
            this.LblLetterDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLetterDate.Location = new System.Drawing.Point(821, 71);
            this.LblLetterDate.Name = "LblLetterDate";
            this.LblLetterDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblLetterDate.Size = new System.Drawing.Size(80, 17);
            this.LblLetterDate.TabIndex = 301;
            this.LblLetterDate.Text = "تاريخ الخطاب ";
            // 
            // txtLetterDate
            // 
            this.txtLetterDate.Enabled = false;
            this.txtLetterDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterDate.Location = new System.Drawing.Point(703, 95);
            this.txtLetterDate.Name = "txtLetterDate";
            this.txtLetterDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterDate.Size = new System.Drawing.Size(204, 25);
            this.txtLetterDate.TabIndex = 302;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(668, 126);
            this.txtID.Name = "txtID";
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID.Size = new System.Drawing.Size(53, 21);
            this.txtID.TabIndex = 303;
            this.txtID.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(204, 329);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(34, 26);
            this.textBox3.TabIndex = 305;
            this.textBox3.Text = "\\";
            this.textBox3.Visible = false;
            // 
            // txtDocumentArchPr
            // 
            this.txtDocumentArchPr.Enabled = false;
            this.txtDocumentArchPr.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentArchPr.Location = new System.Drawing.Point(679, 153);
            this.txtDocumentArchPr.Name = "txtDocumentArchPr";
            this.txtDocumentArchPr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDocumentArchPr.Size = new System.Drawing.Size(42, 21);
            this.txtDocumentArchPr.TabIndex = 306;
            this.txtDocumentArchPr.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(373, 647);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(153, 47);
            this.simpleButton1.TabIndex = 362;
            this.simpleButton1.Text = "حذف الصورة";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ScanDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 698);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtDocumentArchPr);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtLetterDate);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.LblLetterDate);
            this.Controls.Add(this.txtProcessID);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.Nametxt);
            this.Controls.Add(this.txtcurrency);
            this.Controls.Add(this.txtEmpRecieveID);
            this.Controls.Add(this.MskExpandLastDate);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.txtLetterKindID);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.txtLetterKind);
            this.Controls.Add(this.txtLetterFullNo);
            this.Controls.Add(this.LetterId);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.LblLetterKind);
            this.Controls.Add(this.LblBank);
            this.Controls.Add(this.LblLetterFullNo);
            this.Controls.Add(this.Lblvalue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpBOrderKind);
            this.Name = "ScanDocuments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ScanDocuments_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDocumentProcessBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysEventsDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWarrantyKind1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            this.grpBOrderKind.ResumeLayout(false);
            this.grpBOrderKind.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListOfScanner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox lstListOfScanner;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtEmpRecieveID;
        public System.Windows.Forms.TextBox MskExpandLastDate;
        public DevExpress.XtraEditors.RadioGroup radioGroup1;
        public System.Windows.Forms.TextBox txtLetterKindID;
        public System.Windows.Forms.TextBox txtBank;
        public System.Windows.Forms.TextBox txtLetterKind;
        public System.Windows.Forms.TextBox txtLetterFullNo;
        public System.Windows.Forms.TextBox LetterId;
        public System.Windows.Forms.TextBox txtvalue;
        public System.Windows.Forms.TextBox txtcurrency;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.TextBox Nametxt;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblLetterWarrantyKind1BindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_LetterWarrantyKind1TableAdapter tbl_LetterWarrantyKind1TableAdapter;
        private System.Windows.Forms.ImageList imageList1;
        private FinancialSysEventsDataSet3 financialSysEventsDataSet3;
        private System.Windows.Forms.BindingSource tblDocumentProcessBindingSource;
        private FinancialSysEventsDataSet3TableAdapters.Tbl_DocumentProcessTableAdapter tbl_DocumentProcessTableAdapter;
        public System.Windows.Forms.TextBox txtProcessID;
        public System.Windows.Forms.Label LblLetterKind;
        public System.Windows.Forms.Label LblBank;
        public System.Windows.Forms.Label LblLetterFullNo;
        public System.Windows.Forms.Label Lblvalue;
        private System.Windows.Forms.GroupBox grpBOrderKind;
        public System.Windows.Forms.Label LblLetterDate;
        public System.Windows.Forms.TextBox txtLetterDate;
        public System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox txtDocumentArchPr;
        private System.Windows.Forms.Button btnMultiScan;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}