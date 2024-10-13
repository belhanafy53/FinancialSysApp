namespace FinancialSysApp.Forms.Banks
{
    partial class ViewRestrictionsOutChequFRM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRestrictionsOutChequFRM));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.restrictionCheque = new FinancialSysApp.RestrictionCheque();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BrokerAccount = new System.Windows.Forms.TextBox();
            this.Code = new System.Windows.Forms.TextBox();
            this.BankAccount = new System.Windows.Forms.TextBox();
            this.notOutChequeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.UsFulID = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.notOutChequeTableAdapter = new FinancialSysApp.RestrictionChequeTableAdapters.NotOutChequeTableAdapter();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tblFiscalyearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tbl_FiscalyearTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.restrictionNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restrictionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usfulDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outChequeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usfulIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restrictionItemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restrictionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeOut = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.restrictionCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notOutChequeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // restrictionCheque
            // 
            this.restrictionCheque.DataSetName = "RestrictionCheque";
            this.restrictionCheque.EnforceConstraints = false;
            this.restrictionCheque.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Location = new System.Drawing.Point(675, 86);
            this.textBox9.Name = "textBox9";
            this.textBox9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox9.Size = new System.Drawing.Size(70, 20);
            this.textBox9.TabIndex = 339;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(132, 115);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 17);
            this.checkBox1.TabIndex = 340;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // BrokerAccount
            // 
            this.BrokerAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrokerAccount.BackColor = System.Drawing.Color.Cornsilk;
            this.BrokerAccount.Location = new System.Drawing.Point(629, 150);
            this.BrokerAccount.Name = "BrokerAccount";
            this.BrokerAccount.Size = new System.Drawing.Size(161, 20);
            this.BrokerAccount.TabIndex = 344;
            this.BrokerAccount.Text = "0";
            this.BrokerAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Code
            // 
            this.Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Code.Location = new System.Drawing.Point(785, 112);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(26, 20);
            this.Code.TabIndex = 332;
            // 
            // BankAccount
            // 
            this.BankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BankAccount.BackColor = System.Drawing.Color.Cornsilk;
            this.BankAccount.Location = new System.Drawing.Point(629, 125);
            this.BankAccount.Name = "BankAccount";
            this.BankAccount.Size = new System.Drawing.Size(161, 20);
            this.BankAccount.TabIndex = 345;
            this.BankAccount.Text = "0";
            this.BankAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // notOutChequeBindingSource
            // 
            this.notOutChequeBindingSource.DataMember = "NotOutCheque";
            this.notOutChequeBindingSource.DataSource = this.restrictionCheque;
            // 
            // simpleButton7
            // 
            this.simpleButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton7.Location = new System.Drawing.Point(735, 151);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(76, 45);
            this.simpleButton7.TabIndex = 323;
            this.simpleButton7.TabStop = false;
            this.simpleButton7.Text = "تعديل ";
            this.simpleButton7.ToolTip = "حفظ التعديل";
            this.simpleButton7.Visible = false;
            // 
            // UsFulID
            // 
            this.UsFulID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UsFulID.Location = new System.Drawing.Point(686, 125);
            this.UsFulID.Name = "UsFulID";
            this.UsFulID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UsFulID.Size = new System.Drawing.Size(89, 20);
            this.UsFulID.TabIndex = 333;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(645, 151);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox2.Size = new System.Drawing.Size(41, 21);
            this.comboBox2.TabIndex = 331;
            this.comboBox2.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(657, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 330;
            this.label13.Text = "التابع";
            this.label13.Visible = false;
            // 
            // notOutChequeTableAdapter
            // 
            this.notOutChequeTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox3.DataSource = this.tblFiscalyearBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.DropDownWidth = 100;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(252, 112);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox3.Size = new System.Drawing.Size(139, 25);
            this.comboBox3.TabIndex = 361;
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
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(686, 150);
            this.textBox10.Name = "textBox10";
            this.textBox10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox10.Size = new System.Drawing.Size(89, 20);
            this.textBox10.TabIndex = 333;
            // 
            // tbl_FiscalyearTableAdapter
            // 
            this.tbl_FiscalyearTableAdapter.ClearBeforeFill = true;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.dataGridViewX1);
            this.radGroupBox3.Controls.Add(this.comboBox3);
            this.radGroupBox3.Controls.Add(this.textBox9);
            this.radGroupBox3.Controls.Add(this.checkBox1);
            this.radGroupBox3.Controls.Add(this.BrokerAccount);
            this.radGroupBox3.Controls.Add(this.Code);
            this.radGroupBox3.Controls.Add(this.BankAccount);
            this.radGroupBox3.Controls.Add(this.simpleButton7);
            this.radGroupBox3.Controls.Add(this.textBox10);
            this.radGroupBox3.Controls.Add(this.UsFulID);
            this.radGroupBox3.Controls.Add(this.comboBox2);
            this.radGroupBox3.Controls.Add(this.label13);
            this.radGroupBox3.HeaderText = "المستندات التى  تم اصدار شيك لها";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 96);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGroupBox3.Size = new System.Drawing.Size(904, 510);
            this.radGroupBox3.TabIndex = 360;
            this.radGroupBox3.Text = "المستندات التى  تم اصدار شيك لها";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AutoGenerateColumns = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewX1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeight = 28;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.restrictionNODataGridViewTextBoxColumn,
            this.restrictionDateDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.creditValueDataGridViewTextBoxColumn,
            this.usfulDataGridViewTextBoxColumn,
            this.accountNODataGridViewTextBoxColumn,
            this.outChequeDataGridViewCheckBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.dayDataGridViewTextBoxColumn,
            this.usfulIDDataGridViewTextBoxColumn,
            this.fYearDataGridViewTextBoxColumn,
            this.restrictionItemIDDataGridViewTextBoxColumn,
            this.restrictionIDDataGridViewTextBoxColumn,
            this.ChequeOut});
            this.dataGridViewX1.DataSource = this.notOutChequeBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(2, 18);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.Size = new System.Drawing.Size(900, 490);
            this.dataGridViewX1.TabIndex = 341;
            this.dataGridViewX1.UseCustomBackgroundColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(508, 54);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(204, 26);
            this.dateTimePicker2.TabIndex = 359;
            this.dateTimePicker2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker2_KeyDown);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(718, 54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(199, 26);
            this.dateTimePicker1.TabIndex = 358;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(855, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 356;
            this.label5.Text = "الفتره من ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(649, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 19);
            this.label6.TabIndex = 357;
            this.label6.Text = "الفتره الى ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 362;
            this.label1.Text = "شيكات تم إصدارها";
            // 
            // restrictionNODataGridViewTextBoxColumn
            // 
            this.restrictionNODataGridViewTextBoxColumn.DataPropertyName = "Restriction_NO";
            this.restrictionNODataGridViewTextBoxColumn.HeaderText = "رقم المستند";
            this.restrictionNODataGridViewTextBoxColumn.Name = "restrictionNODataGridViewTextBoxColumn";
            this.restrictionNODataGridViewTextBoxColumn.ReadOnly = true;
            this.restrictionNODataGridViewTextBoxColumn.Width = 120;
            // 
            // restrictionDateDataGridViewTextBoxColumn
            // 
            this.restrictionDateDataGridViewTextBoxColumn.DataPropertyName = "Restriction_Date";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.restrictionDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.restrictionDateDataGridViewTextBoxColumn.HeaderText = "تاريخ المستند";
            this.restrictionDateDataGridViewTextBoxColumn.Name = "restrictionDateDataGridViewTextBoxColumn";
            this.restrictionDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.restrictionDateDataGridViewTextBoxColumn.Width = 120;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Expr2";
            this.nameDataGridViewTextBoxColumn.HeaderText = "البنك";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 300;
            // 
            // creditValueDataGridViewTextBoxColumn
            // 
            this.creditValueDataGridViewTextBoxColumn.DataPropertyName = "check_value";
            this.creditValueDataGridViewTextBoxColumn.HeaderText = "القيمة";
            this.creditValueDataGridViewTextBoxColumn.Name = "creditValueDataGridViewTextBoxColumn";
            this.creditValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.creditValueDataGridViewTextBoxColumn.Width = 140;
            // 
            // usfulDataGridViewTextBoxColumn
            // 
            this.usfulDataGridViewTextBoxColumn.DataPropertyName = "Usful";
            this.usfulDataGridViewTextBoxColumn.HeaderText = "المستفيد";
            this.usfulDataGridViewTextBoxColumn.Name = "usfulDataGridViewTextBoxColumn";
            this.usfulDataGridViewTextBoxColumn.ReadOnly = true;
            this.usfulDataGridViewTextBoxColumn.Width = 300;
            // 
            // accountNODataGridViewTextBoxColumn
            // 
            this.accountNODataGridViewTextBoxColumn.DataPropertyName = "Account_NO";
            this.accountNODataGridViewTextBoxColumn.HeaderText = "Account_NO";
            this.accountNODataGridViewTextBoxColumn.Name = "accountNODataGridViewTextBoxColumn";
            this.accountNODataGridViewTextBoxColumn.ReadOnly = true;
            this.accountNODataGridViewTextBoxColumn.Visible = false;
            // 
            // outChequeDataGridViewCheckBoxColumn
            // 
            this.outChequeDataGridViewCheckBoxColumn.DataPropertyName = "OutCheque";
            this.outChequeDataGridViewCheckBoxColumn.HeaderText = "OutCheque";
            this.outChequeDataGridViewCheckBoxColumn.Name = "outChequeDataGridViewCheckBoxColumn";
            this.outChequeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.outChequeDataGridViewCheckBoxColumn.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // dayDataGridViewTextBoxColumn
            // 
            this.dayDataGridViewTextBoxColumn.DataPropertyName = "Day";
            this.dayDataGridViewTextBoxColumn.HeaderText = "اليومية";
            this.dayDataGridViewTextBoxColumn.Name = "dayDataGridViewTextBoxColumn";
            this.dayDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayDataGridViewTextBoxColumn.Visible = false;
            this.dayDataGridViewTextBoxColumn.Width = 120;
            // 
            // usfulIDDataGridViewTextBoxColumn
            // 
            this.usfulIDDataGridViewTextBoxColumn.DataPropertyName = "UsfulID";
            this.usfulIDDataGridViewTextBoxColumn.HeaderText = "كود المستفيد";
            this.usfulIDDataGridViewTextBoxColumn.Name = "usfulIDDataGridViewTextBoxColumn";
            this.usfulIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.usfulIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fYearDataGridViewTextBoxColumn
            // 
            this.fYearDataGridViewTextBoxColumn.DataPropertyName = "FYear";
            this.fYearDataGridViewTextBoxColumn.HeaderText = "FYear";
            this.fYearDataGridViewTextBoxColumn.Name = "fYearDataGridViewTextBoxColumn";
            this.fYearDataGridViewTextBoxColumn.ReadOnly = true;
            this.fYearDataGridViewTextBoxColumn.Visible = false;
            // 
            // restrictionItemIDDataGridViewTextBoxColumn
            // 
            this.restrictionItemIDDataGridViewTextBoxColumn.DataPropertyName = "RestrictionItemID";
            this.restrictionItemIDDataGridViewTextBoxColumn.HeaderText = "كود البند";
            this.restrictionItemIDDataGridViewTextBoxColumn.Name = "restrictionItemIDDataGridViewTextBoxColumn";
            this.restrictionItemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.restrictionItemIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // restrictionIDDataGridViewTextBoxColumn
            // 
            this.restrictionIDDataGridViewTextBoxColumn.DataPropertyName = "RestrictionID";
            this.restrictionIDDataGridViewTextBoxColumn.HeaderText = "كود المستند";
            this.restrictionIDDataGridViewTextBoxColumn.Name = "restrictionIDDataGridViewTextBoxColumn";
            this.restrictionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.restrictionIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // ChequeOut
            // 
            this.ChequeOut.DataPropertyName = "ChequeOut";
            this.ChequeOut.HeaderText = "ChequeOut";
            this.ChequeOut.Name = "ChequeOut";
            this.ChequeOut.ReadOnly = true;
            // 
            // ViewRestrictionsOutChequFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 635);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.Name = "ViewRestrictionsOutChequFRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المستندات التى  تم اصدار شيك لها";
            this.Load += new System.EventHandler(this.ViewRestrictionsOutChequFRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.restrictionCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notOutChequeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private RestrictionCheque restrictionCheque;
        public System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.TextBox BrokerAccount;
        public System.Windows.Forms.TextBox Code;
        public System.Windows.Forms.TextBox BankAccount;
        private System.Windows.Forms.BindingSource notOutChequeBindingSource;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        public System.Windows.Forms.TextBox UsFulID;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label13;
        private RestrictionChequeTableAdapters.NotOutChequeTableAdapter notOutChequeTableAdapter;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.BindingSource tblFiscalyearBindingSource;
        private FinancialSysDataSet financialSysDataSet;
        public System.Windows.Forms.TextBox textBox10;
        private FinancialSysDataSetTableAdapters.Tbl_FiscalyearTableAdapter tbl_FiscalyearTableAdapter;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usfulDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn outChequeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usfulIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionItemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChequeOut;
    }
}