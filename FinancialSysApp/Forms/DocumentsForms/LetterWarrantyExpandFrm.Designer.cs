namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class LetterWarrantyExpandFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LetterWarrantyExpandFrm));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LetterId = new System.Windows.Forms.TextBox();
            this.txtLetterFullNo = new System.Windows.Forms.TextBox();
            this.txtLetterKind = new System.Windows.Forms.TextBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcurrency = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letterWarrantyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letterWExpandDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblLetterWExpandDatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.txtLetterKindID = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.MskStartDate = new System.Windows.Forms.DateTimePicker();
            this.MskFirstExpandDate = new System.Windows.Forms.DateTimePicker();
            this.tbl_LetterWExpandDatesTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_LetterWExpandDatesTableAdapter();
            this.MskExpandLastDate = new System.Windows.Forms.TextBox();
            this.chckBxBasicData = new System.Windows.Forms.CheckBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWExpandDatesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(228, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 22);
            this.label4.TabIndex = 42;
            this.label4.Text = "مد خطاب الضمان ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 131);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "رقم الخطاب ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(557, 101);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "البنك";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(520, 66);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 45;
            this.label3.Text = "نوع الخطاب";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(518, 165);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "مبلغ الخطاب";
            // 
            // LetterId
            // 
            this.LetterId.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterId.Location = new System.Drawing.Point(21, 12);
            this.LetterId.Name = "LetterId";
            this.LetterId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LetterId.Size = new System.Drawing.Size(66, 22);
            this.LetterId.TabIndex = 47;
            this.LetterId.Visible = false;
            // 
            // txtLetterFullNo
            // 
            this.txtLetterFullNo.Enabled = false;
            this.txtLetterFullNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterFullNo.Location = new System.Drawing.Point(99, 130);
            this.txtLetterFullNo.Name = "txtLetterFullNo";
            this.txtLetterFullNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterFullNo.Size = new System.Drawing.Size(374, 25);
            this.txtLetterFullNo.TabIndex = 48;
            // 
            // txtLetterKind
            // 
            this.txtLetterKind.Enabled = false;
            this.txtLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKind.Location = new System.Drawing.Point(21, 66);
            this.txtLetterKind.Name = "txtLetterKind";
            this.txtLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKind.Size = new System.Drawing.Size(452, 25);
            this.txtLetterKind.TabIndex = 49;
            // 
            // txtBank
            // 
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(21, 98);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(452, 25);
            this.txtBank.TabIndex = 50;
            // 
            // txtvalue
            // 
            this.txtvalue.Enabled = false;
            this.txtvalue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalue.Location = new System.Drawing.Point(252, 164);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtvalue.Size = new System.Drawing.Size(220, 25);
            this.txtvalue.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(478, 197);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "تاريخ اصدار الخطاب";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(164, 200);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 54;
            this.label7.Text = "تاريخ صلاحية الخطاب";
            // 
            // txtcurrency
            // 
            this.txtcurrency.Enabled = false;
            this.txtcurrency.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcurrency.Location = new System.Drawing.Point(100, 165);
            this.txtcurrency.Name = "txtcurrency";
            this.txtcurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcurrency.Size = new System.Drawing.Size(146, 25);
            this.txtcurrency.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(476, 235);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 57;
            this.label8.Text = "  اخر تاريخ مد الخطاب";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(494, 273);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(95, 17);
            this.label9.TabIndex = 59;
            this.label9.Text = "تاريخ  مد الخطاب";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.letterWarrantyIDDataGridViewTextBoxColumn,
            this.letterWExpandDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblLetterWExpandDatesBindingSource;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(12, 345);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(592, 215);
            this.dataGridView1.TabIndex = 61;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // letterWarrantyIDDataGridViewTextBoxColumn
            // 
            this.letterWarrantyIDDataGridViewTextBoxColumn.DataPropertyName = "LetterWarrantyID";
            this.letterWarrantyIDDataGridViewTextBoxColumn.HeaderText = "LetterWarrantyID";
            this.letterWarrantyIDDataGridViewTextBoxColumn.Name = "letterWarrantyIDDataGridViewTextBoxColumn";
            this.letterWarrantyIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.letterWarrantyIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // letterWExpandDateDataGridViewTextBoxColumn
            // 
            this.letterWExpandDateDataGridViewTextBoxColumn.DataPropertyName = "LetterWExpandDate";
            this.letterWExpandDateDataGridViewTextBoxColumn.HeaderText = "تواريخ المد ";
            this.letterWExpandDateDataGridViewTextBoxColumn.Name = "letterWExpandDateDataGridViewTextBoxColumn";
            this.letterWExpandDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.letterWExpandDateDataGridViewTextBoxColumn.Width = 300;
            // 
            // tblLetterWExpandDatesBindingSource
            // 
            this.tblLetterWExpandDatesBindingSource.DataMember = "Tbl_LetterWExpandDates";
            this.tblLetterWExpandDatesBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtLetterKindID
            // 
            this.txtLetterKindID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKindID.Location = new System.Drawing.Point(21, 38);
            this.txtLetterKindID.Name = "txtLetterKindID";
            this.txtLetterKindID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKindID.Size = new System.Drawing.Size(66, 22);
            this.txtLetterKindID.TabIndex = 62;
            this.txtLetterKindID.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(272, 270);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 63;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(143, 264);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 33);
            this.simpleButton1.TabIndex = 156;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(444, 10);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "وارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "صادر")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(160, 25);
            this.radioGroup1.TabIndex = 157;
            this.radioGroup1.Visible = false;
            // 
            // MskStartDate
            // 
            this.MskStartDate.Enabled = false;
            this.MskStartDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MskStartDate.Location = new System.Drawing.Point(312, 196);
            this.MskStartDate.Name = "MskStartDate";
            this.MskStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskStartDate.RightToLeftLayout = true;
            this.MskStartDate.Size = new System.Drawing.Size(160, 26);
            this.MskStartDate.TabIndex = 158;
            // 
            // MskFirstExpandDate
            // 
            this.MskFirstExpandDate.Enabled = false;
            this.MskFirstExpandDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskFirstExpandDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MskFirstExpandDate.Location = new System.Drawing.Point(21, 196);
            this.MskFirstExpandDate.Name = "MskFirstExpandDate";
            this.MskFirstExpandDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskFirstExpandDate.RightToLeftLayout = true;
            this.MskFirstExpandDate.Size = new System.Drawing.Size(137, 26);
            this.MskFirstExpandDate.TabIndex = 159;
            // 
            // tbl_LetterWExpandDatesTableAdapter
            // 
            this.tbl_LetterWExpandDatesTableAdapter.ClearBeforeFill = true;
            // 
            // MskExpandLastDate
            // 
            this.MskExpandLastDate.Enabled = false;
            this.MskExpandLastDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskExpandLastDate.Location = new System.Drawing.Point(310, 232);
            this.MskExpandLastDate.Name = "MskExpandLastDate";
            this.MskExpandLastDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskExpandLastDate.Size = new System.Drawing.Size(160, 25);
            this.MskExpandLastDate.TabIndex = 161;
            // 
            // chckBxBasicData
            // 
            this.chckBxBasicData.AutoSize = true;
            this.chckBxBasicData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBxBasicData.ForeColor = System.Drawing.Color.Red;
            this.chckBxBasicData.Location = new System.Drawing.Point(272, 567);
            this.chckBxBasicData.Name = "chckBxBasicData";
            this.chckBxBasicData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckBxBasicData.Size = new System.Drawing.Size(139, 23);
            this.chckBxBasicData.TabIndex = 255;
            this.chckBxBasicData.Text = "تم مراجعة مد الخطاب";
            this.chckBxBasicData.UseVisualStyleBackColor = true;
            this.chckBxBasicData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chckBxBasicData_MouseClick);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(476, 596);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(125, 17);
            this.label50.TabIndex = 254;
            this.label50.Text = "تفاصيل مراجعة الخطاب";
            // 
            // textBox6
            // 
            this.textBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(18, 596);
            this.textBox6.Name = "textBox6";
            this.textBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox6.Size = new System.Drawing.Size(452, 25);
            this.textBox6.TabIndex = 253;
            this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyDown);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(21, 264);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(103, 33);
            this.simpleButton2.TabIndex = 256;
            this.simpleButton2.Text = "حذف";
            this.simpleButton2.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(256, 325);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(347, 17);
            this.label10.TabIndex = 257;
            this.label10.Text = "لحذف مد اضغط Double Click Mouse على التاريخ المراد حذف";
            // 
            // LetterWarrantyExpandFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 626);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.chckBxBasicData);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.MskExpandLastDate);
            this.Controls.Add(this.MskFirstExpandDate);
            this.Controls.Add(this.MskStartDate);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtLetterKindID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcurrency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.txtLetterKind);
            this.Controls.Add(this.txtLetterFullNo);
            this.Controls.Add(this.LetterId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "LetterWarrantyExpandFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LetterWarrantyExpandFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLetterWExpandDatesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtLetterFullNo;
        public System.Windows.Forms.TextBox txtLetterKind;
        public System.Windows.Forms.TextBox txtBank;
        public System.Windows.Forms.TextBox txtvalue;
        public System.Windows.Forms.TextBox txtcurrency;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox LetterId;
        public System.Windows.Forms.TextBox txtLetterKindID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.RadioGroup radioGroup1;
        public System.Windows.Forms.DateTimePicker MskStartDate;
        public System.Windows.Forms.DateTimePicker MskFirstExpandDate;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblLetterWExpandDatesBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_LetterWExpandDatesTableAdapter tbl_LetterWExpandDatesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn letterWarrantyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn letterWExpandDateDataGridViewTextBoxColumn;
        public System.Windows.Forms.TextBox MskExpandLastDate;
        private System.Windows.Forms.CheckBox chckBxBasicData;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox textBox6;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Label label10;
    }
}