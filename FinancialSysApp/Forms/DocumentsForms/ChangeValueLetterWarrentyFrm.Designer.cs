namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class ChangeValueLetterWarrentyFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeValueLetterWarrentyFrm));
            this.label16 = new System.Windows.Forms.Label();
            this.txtEmpRecieveID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet1 = new FinancialSysApp.FinancialSysDataSet();
            this.tbl_LetterWExpandDatesTableAdapter1 = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_LetterWExpandDatesTableAdapter();
            this.dTPDateChange = new System.Windows.Forms.DateTimePicker();
            this.txtFYear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPurchMethode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MskExpandLastDate = new System.Windows.Forms.TextBox();
            this.MskFirstExpandDate = new System.Windows.Forms.DateTimePicker();
            this.MskStartDate = new System.Windows.Forms.DateTimePicker();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tblLetterWExpandDatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_LetterWExpandDatesTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_LetterWExpandDatesTableAdapter();
            this.txtLetterKindID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcurrency = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtLetterKind = new System.Windows.Forms.TextBox();
            this.txtLetterFullNo = new System.Windows.Forms.TextBox();
            this.LetterId = new System.Windows.Forms.TextBox();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbChangeMethode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtChangeValueLetter = new System.Windows.Forms.TextBox();
            this.chckBxBasicData = new System.Windows.Forms.CheckBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWExpandDatesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(249, 378);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(69, 17);
            this.label16.TabIndex = 280;
            this.label16.Text = "تاريخ التغيير";
            // 
            // txtEmpRecieveID
            // 
            this.txtEmpRecieveID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpRecieveID.Location = new System.Drawing.Point(199, 66);
            this.txtEmpRecieveID.Name = "txtEmpRecieveID";
            this.txtEmpRecieveID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEmpRecieveID.Size = new System.Drawing.Size(66, 22);
            this.txtEmpRecieveID.TabIndex = 279;
            this.txtEmpRecieveID.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(81, 144);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(37, 17);
            this.label15.TabIndex = 278;
            this.label15.Text = "العمله";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Tbl_LetterWExpandDates";
            this.bindingSource1.DataSource = this.financialSysDataSet1;
            // 
            // financialSysDataSet1
            // 
            this.financialSysDataSet1.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_LetterWExpandDatesTableAdapter1
            // 
            this.tbl_LetterWExpandDatesTableAdapter1.ClearBeforeFill = true;
            // 
            // dTPDateChange
            // 
            this.dTPDateChange.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDateChange.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPDateChange.Location = new System.Drawing.Point(133, 398);
            this.dTPDateChange.Name = "dTPDateChange";
            this.dTPDateChange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPDateChange.RightToLeftLayout = true;
            this.dTPDateChange.Size = new System.Drawing.Size(189, 26);
            this.dTPDateChange.TabIndex = 281;
            this.dTPDateChange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPDateChange_KeyDown);
            // 
            // txtFYear
            // 
            this.txtFYear.Enabled = false;
            this.txtFYear.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFYear.Location = new System.Drawing.Point(353, 289);
            this.txtFYear.Name = "txtFYear";
            this.txtFYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFYear.Size = new System.Drawing.Size(98, 25);
            this.txtFYear.TabIndex = 277;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(433, 267);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(25, 17);
            this.label12.TabIndex = 276;
            this.label12.Text = "عام";
            // 
            // txtTenderNo
            // 
            this.txtTenderNo.Enabled = false;
            this.txtTenderNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenderNo.Location = new System.Drawing.Point(133, 290);
            this.txtTenderNo.Name = "txtTenderNo";
            this.txtTenderNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTenderNo.Size = new System.Drawing.Size(189, 25);
            this.txtTenderNo.TabIndex = 275;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(555, 267);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 274;
            this.label1.Text = "طريقة الشراء";
            // 
            // txtPurchMethode
            // 
            this.txtPurchMethode.Enabled = false;
            this.txtPurchMethode.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchMethode.Location = new System.Drawing.Point(462, 289);
            this.txtPurchMethode.Name = "txtPurchMethode";
            this.txtPurchMethode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPurchMethode.Size = new System.Drawing.Size(165, 25);
            this.txtPurchMethode.TabIndex = 273;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 267);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 272;
            this.label2.Text = "رقم";
            // 
            // MskExpandLastDate
            // 
            this.MskExpandLastDate.Enabled = false;
            this.MskExpandLastDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskExpandLastDate.Location = new System.Drawing.Point(560, 32);
            this.MskExpandLastDate.Name = "MskExpandLastDate";
            this.MskExpandLastDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskExpandLastDate.Size = new System.Drawing.Size(48, 25);
            this.MskExpandLastDate.TabIndex = 271;
            this.MskExpandLastDate.Visible = false;
            // 
            // MskFirstExpandDate
            // 
            this.MskFirstExpandDate.Enabled = false;
            this.MskFirstExpandDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskFirstExpandDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MskFirstExpandDate.Location = new System.Drawing.Point(48, 229);
            this.MskFirstExpandDate.Name = "MskFirstExpandDate";
            this.MskFirstExpandDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskFirstExpandDate.RightToLeftLayout = true;
            this.MskFirstExpandDate.Size = new System.Drawing.Size(272, 26);
            this.MskFirstExpandDate.TabIndex = 270;
            // 
            // MskStartDate
            // 
            this.MskStartDate.Enabled = false;
            this.MskStartDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MskStartDate.Location = new System.Drawing.Point(353, 232);
            this.MskStartDate.Name = "MskStartDate";
            this.MskStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskStartDate.RightToLeftLayout = true;
            this.MskStartDate.Size = new System.Drawing.Size(274, 26);
            this.MskStartDate.TabIndex = 269;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(61, 23);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "وارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "صادر")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(160, 25);
            this.radioGroup1.TabIndex = 268;
            this.radioGroup1.Visible = false;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblLetterWExpandDatesBindingSource
            // 
            this.tblLetterWExpandDatesBindingSource.DataMember = "Tbl_LetterWExpandDates";
            this.tblLetterWExpandDatesBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_LetterWExpandDatesTableAdapter
            // 
            this.tbl_LetterWExpandDatesTableAdapter.ClearBeforeFill = true;
            // 
            // txtLetterKindID
            // 
            this.txtLetterKindID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKindID.Location = new System.Drawing.Point(121, 66);
            this.txtLetterKindID.Name = "txtLetterKindID";
            this.txtLetterKindID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKindID.Size = new System.Drawing.Size(66, 22);
            this.txtLetterKindID.TabIndex = 267;
            this.txtLetterKindID.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(433, 31);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 266;
            this.label8.Text = "  اخر تاريخ مد الخطاب";
            this.label8.Visible = false;
            // 
            // txtcurrency
            // 
            this.txtcurrency.Enabled = false;
            this.txtcurrency.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcurrency.Location = new System.Drawing.Point(17, 164);
            this.txtcurrency.Name = "txtcurrency";
            this.txtcurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcurrency.Size = new System.Drawing.Size(98, 25);
            this.txtcurrency.TabIndex = 265;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(207, 206);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 264;
            this.label7.Text = "تاريخ صلاحية الخطاب";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(519, 206);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 263;
            this.label6.Text = "تاريخ اصدار الخطاب";
            // 
            // txtBank
            // 
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(23, 104);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(306, 25);
            this.txtBank.TabIndex = 261;
            // 
            // txtLetterKind
            // 
            this.txtLetterKind.Enabled = false;
            this.txtLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKind.Location = new System.Drawing.Point(353, 104);
            this.txtLetterKind.Name = "txtLetterKind";
            this.txtLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKind.Size = new System.Drawing.Size(273, 25);
            this.txtLetterKind.TabIndex = 260;
            // 
            // txtLetterFullNo
            // 
            this.txtLetterFullNo.Enabled = false;
            this.txtLetterFullNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterFullNo.Location = new System.Drawing.Point(353, 164);
            this.txtLetterFullNo.Name = "txtLetterFullNo";
            this.txtLetterFullNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterFullNo.Size = new System.Drawing.Size(273, 25);
            this.txtLetterFullNo.TabIndex = 259;
            // 
            // LetterId
            // 
            this.LetterId.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterId.Location = new System.Drawing.Point(49, 66);
            this.LetterId.Name = "LetterId";
            this.LetterId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LetterId.Size = new System.Drawing.Size(66, 22);
            this.LetterId.TabIndex = 258;
            this.LetterId.Visible = false;
            // 
            // txtvalue
            // 
            this.txtvalue.Enabled = false;
            this.txtvalue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalue.Location = new System.Drawing.Point(127, 164);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtvalue.Size = new System.Drawing.Size(202, 25);
            this.txtvalue.TabIndex = 262;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(227, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 22);
            this.label4.TabIndex = 253;
            this.label4.Text = " تخفيض/ زيادة  خطاب الضمان ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(560, 84);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 256;
            this.label3.Text = "نوع الخطاب";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(300, 84);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 255;
            this.label5.Text = "البنك";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(560, 144);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 254;
            this.label13.Text = "رقم الخطاب ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(261, 144);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 257;
            this.label14.Text = "مبلغ الخطاب";
            // 
            // cmbChangeMethode
            // 
            this.cmbChangeMethode.BackColor = System.Drawing.Color.White;
            this.cmbChangeMethode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cmbChangeMethode.FormattingEnabled = true;
            this.cmbChangeMethode.Items.AddRange(new object[] {
            "تخقيض",
            "زياده"});
            this.cmbChangeMethode.Location = new System.Drawing.Point(353, 342);
            this.cmbChangeMethode.Name = "cmbChangeMethode";
            this.cmbChangeMethode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbChangeMethode.Size = new System.Drawing.Size(272, 27);
            this.cmbChangeMethode.TabIndex = 250;
            this.cmbChangeMethode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbChangeMethode_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(560, 319);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 249;
            this.label10.Text = "نوع التغيير ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(249, 319);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 246;
            this.label9.Text = "القيمه الجديده";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 395);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 33);
            this.simpleButton1.TabIndex = 248;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtChangeValueLetter
            // 
            this.txtChangeValueLetter.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangeValueLetter.Location = new System.Drawing.Point(133, 344);
            this.txtChangeValueLetter.Name = "txtChangeValueLetter";
            this.txtChangeValueLetter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtChangeValueLetter.Size = new System.Drawing.Size(189, 25);
            this.txtChangeValueLetter.TabIndex = 282;
            this.txtChangeValueLetter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChangeValueLetter_KeyDown);
            // 
            // chckBxBasicData
            // 
            this.chckBxBasicData.AutoSize = true;
            this.chckBxBasicData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBxBasicData.ForeColor = System.Drawing.Color.Red;
            this.chckBxBasicData.Location = new System.Drawing.Point(224, 454);
            this.chckBxBasicData.Name = "chckBxBasicData";
            this.chckBxBasicData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckBxBasicData.Size = new System.Drawing.Size(206, 23);
            this.chckBxBasicData.TabIndex = 286;
            this.chckBxBasicData.Text = "تم مراجعة تخفيض / زيادة  الخطاب";
            this.chckBxBasicData.UseVisualStyleBackColor = true;
            this.chckBxBasicData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chckBxBasicData_MouseClick);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(482, 483);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(125, 17);
            this.label50.TabIndex = 285;
            this.label50.Text = "تفاصيل مراجعة الخطاب";
            // 
            // textBox6
            // 
            this.textBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(24, 483);
            this.textBox6.Name = "textBox6";
            this.textBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox6.Size = new System.Drawing.Size(452, 25);
            this.textBox6.TabIndex = 284;
            this.textBox6.Enter += new System.EventHandler(this.textBox6_Enter);
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // ChangeValueLetterWarrentyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 520);
            this.Controls.Add(this.chckBxBasicData);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.txtChangeValueLetter);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtEmpRecieveID);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dTPDateChange);
            this.Controls.Add(this.txtFYear);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTenderNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPurchMethode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MskExpandLastDate);
            this.Controls.Add(this.MskFirstExpandDate);
            this.Controls.Add(this.MskStartDate);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.txtLetterKindID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcurrency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.txtLetterKind);
            this.Controls.Add(this.txtLetterFullNo);
            this.Controls.Add(this.LetterId);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbChangeMethode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label9);
            this.Name = "ChangeValueLetterWarrentyFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChangeValueLetterWarrentyFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWExpandDatesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtEmpRecieveID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.BindingSource bindingSource1;
        private FinancialSysDataSet financialSysDataSet1;
        private FinancialSysDataSetTableAdapters.Tbl_LetterWExpandDatesTableAdapter tbl_LetterWExpandDatesTableAdapter1;
        public System.Windows.Forms.DateTimePicker dTPDateChange;
        public System.Windows.Forms.TextBox txtFYear;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtTenderNo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPurchMethode;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox MskExpandLastDate;
        public System.Windows.Forms.DateTimePicker MskFirstExpandDate;
        public System.Windows.Forms.DateTimePicker MskStartDate;
        public DevExpress.XtraEditors.RadioGroup radioGroup1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblLetterWExpandDatesBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_LetterWExpandDatesTableAdapter tbl_LetterWExpandDatesTableAdapter;
        public System.Windows.Forms.TextBox txtLetterKindID;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtcurrency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtBank;
        public System.Windows.Forms.TextBox txtLetterKind;
        public System.Windows.Forms.TextBox txtLetterFullNo;
        public System.Windows.Forms.TextBox LetterId;
        public System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox cmbChangeMethode;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtChangeValueLetter;
        private System.Windows.Forms.CheckBox chckBxBasicData;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox textBox6;
    }
}