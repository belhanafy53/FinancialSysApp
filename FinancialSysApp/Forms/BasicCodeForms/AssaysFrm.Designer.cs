namespace FinancialSysApp.Forms.BasicCodeForms
{
    partial class AssaysFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssaysFrm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assaysNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assaysDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assKindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assCustDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assaysDataTapleByNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet1 = new FinancialSysApp.FinancialSysDataSet();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAssaysDate = new System.Windows.Forms.DateTimePicker();
            this.txtAssaysNo = new System.Windows.Forms.TextBox();
            this.cmbAssaysKind = new System.Windows.Forms.ComboBox();
            this.tblAssaysKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tbl_AssaysKindTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_AssaysKindTableAdapter();
            this.label8 = new System.Windows.Forms.Label();
            this.txtManagement = new System.Windows.Forms.TextBox();
            this.txtManagementId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomers = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtAssaysId = new System.Windows.Forms.TextBox();
            this.assaysDataTapleByNoTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.AssaysDataTapleByNoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assaysDataTapleByNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAssaysKindBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.assaysNoDataGridViewTextBoxColumn,
            this.assaysDateDataGridViewTextBoxColumn,
            this.assKindDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.assCustDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.assaysDataTapleByNoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(23, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(677, 450);
            this.dataGridView1.TabIndex = 93;
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
            // assaysNoDataGridViewTextBoxColumn
            // 
            this.assaysNoDataGridViewTextBoxColumn.DataPropertyName = "AssaysNo";
            this.assaysNoDataGridViewTextBoxColumn.HeaderText = "رقم المقايسه";
            this.assaysNoDataGridViewTextBoxColumn.Name = "assaysNoDataGridViewTextBoxColumn";
            this.assaysNoDataGridViewTextBoxColumn.Width = 80;
            // 
            // assaysDateDataGridViewTextBoxColumn
            // 
            this.assaysDateDataGridViewTextBoxColumn.DataPropertyName = "AssaysDate";
            dataGridViewCellStyle2.Format = "yyyy/MM/dd";
            this.assaysDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.assaysDateDataGridViewTextBoxColumn.HeaderText = "تاريخ المقايسه";
            this.assaysDateDataGridViewTextBoxColumn.Name = "assaysDateDataGridViewTextBoxColumn";
            // 
            // assKindDataGridViewTextBoxColumn
            // 
            this.assKindDataGridViewTextBoxColumn.DataPropertyName = "AssKind";
            this.assKindDataGridViewTextBoxColumn.HeaderText = "نوع المقايسه";
            this.assKindDataGridViewTextBoxColumn.Name = "assKindDataGridViewTextBoxColumn";
            this.assKindDataGridViewTextBoxColumn.Width = 70;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "الاداره";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // assCustDataGridViewTextBoxColumn
            // 
            this.assCustDataGridViewTextBoxColumn.DataPropertyName = "AssCust";
            this.assCustDataGridViewTextBoxColumn.HeaderText = "العميل";
            this.assCustDataGridViewTextBoxColumn.Name = "assCustDataGridViewTextBoxColumn";
            this.assCustDataGridViewTextBoxColumn.Width = 150;
            // 
            // assaysDataTapleByNoBindingSource
            // 
            this.assaysDataTapleByNoBindingSource.DataMember = "AssaysDataTapleByNo";
            this.assaysDataTapleByNoBindingSource.DataSource = this.financialSysDataSet1;
            // 
            // financialSysDataSet1
            // 
            this.financialSysDataSet1.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(942, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(945, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(942, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 90;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1013, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 89;
            this.label4.Text = "تاريخ المقايسه";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1023, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 88;
            this.label3.Text = "رقم المقايسه";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1021, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 87;
            this.label2.Text = "نوع المقايسه";
            // 
            // dtpAssaysDate
            // 
            this.dtpAssaysDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAssaysDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssaysDate.Location = new System.Drawing.Point(722, 204);
            this.dtpAssaysDate.Name = "dtpAssaysDate";
            this.dtpAssaysDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpAssaysDate.RightToLeftLayout = true;
            this.dtpAssaysDate.Size = new System.Drawing.Size(377, 25);
            this.dtpAssaysDate.TabIndex = 86;
            this.dtpAssaysDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpAssaysDate_KeyDown);
            // 
            // txtAssaysNo
            // 
            this.txtAssaysNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAssaysNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAssaysNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssaysNo.Location = new System.Drawing.Point(898, 141);
            this.txtAssaysNo.Name = "txtAssaysNo";
            this.txtAssaysNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAssaysNo.Size = new System.Drawing.Size(201, 25);
            this.txtAssaysNo.TabIndex = 85;
            this.txtAssaysNo.TextChanged += new System.EventHandler(this.txtAssaysNo_TextChanged);
            this.txtAssaysNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAssaysNo_KeyDown);
            // 
            // cmbAssaysKind
            // 
            this.cmbAssaysKind.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.financialSysDataSet, "Tbl_AssaysKind.ID", true));
            this.cmbAssaysKind.DataSource = this.tblAssaysKindBindingSource;
            this.cmbAssaysKind.DisplayMember = "Name";
            this.cmbAssaysKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAssaysKind.FormattingEnabled = true;
            this.cmbAssaysKind.Location = new System.Drawing.Point(722, 88);
            this.cmbAssaysKind.Name = "cmbAssaysKind";
            this.cmbAssaysKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAssaysKind.Size = new System.Drawing.Size(377, 25);
            this.cmbAssaysKind.TabIndex = 84;
            this.cmbAssaysKind.ValueMember = "ID";
            this.cmbAssaysKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAssaysKind_KeyDown);
            // 
            // tblAssaysKindBindingSource
            // 
            this.tblAssaysKindBindingSource.DataMember = "Tbl_AssaysKind";
            this.tblAssaysKindBindingSource.DataSource = this.financialSysDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(586, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 22);
            this.label1.TabIndex = 96;
            this.label1.Text = "المقايسات";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(771, 383);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(103, 37);
            this.simpleButton2.TabIndex = 95;
            this.simpleButton2.Text = "حدف";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(916, 383);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 37);
            this.simpleButton1.TabIndex = 94;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tbl_AssaysKindTableAdapter
            // 
            this.tbl_AssaysKindTableAdapter.ClearBeforeFill = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1057, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 19);
            this.label8.TabIndex = 97;
            this.label8.Text = "الادارة";
            // 
            // txtManagement
            // 
            this.txtManagement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtManagement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtManagement.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManagement.Location = new System.Drawing.Point(722, 261);
            this.txtManagement.Name = "txtManagement";
            this.txtManagement.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtManagement.Size = new System.Drawing.Size(377, 25);
            this.txtManagement.TabIndex = 98;
            this.txtManagement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManagement_KeyDown);
            // 
            // txtManagementId
            // 
            this.txtManagementId.Location = new System.Drawing.Point(734, 235);
            this.txtManagementId.Name = "txtManagementId";
            this.txtManagementId.Size = new System.Drawing.Size(78, 20);
            this.txtManagementId.TabIndex = 99;
            this.txtManagementId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(704, 306);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المقايسات";
            // 
            // txtCustomers
            // 
            this.txtCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCustomers.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomers.Location = new System.Drawing.Point(722, 321);
            this.txtCustomers.Name = "txtCustomers";
            this.txtCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomers.Size = new System.Drawing.Size(377, 25);
            this.txtCustomers.TabIndex = 105;
            this.txtCustomers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1058, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 19);
            this.label9.TabIndex = 104;
            this.label9.Text = "العميل";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(734, 292);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(78, 20);
            this.txtCustomerId.TabIndex = 106;
            this.txtCustomerId.Visible = false;
            // 
            // txtAssaysId
            // 
            this.txtAssaysId.Location = new System.Drawing.Point(722, 141);
            this.txtAssaysId.Name = "txtAssaysId";
            this.txtAssaysId.Size = new System.Drawing.Size(78, 20);
            this.txtAssaysId.TabIndex = 107;
            this.txtAssaysId.Visible = false;
            // 
            // assaysDataTapleByNoTableAdapter
            // 
            this.assaysDataTapleByNoTableAdapter.ClearBeforeFill = true;
            // 
            // AssaysFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 539);
            this.Controls.Add(this.txtAssaysId);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.txtCustomers);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtManagementId);
            this.Controls.Add(this.txtManagement);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpAssaysDate);
            this.Controls.Add(this.txtAssaysNo);
            this.Controls.Add(this.cmbAssaysKind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupBox1);
            this.Name = "AssaysFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AssaysFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assaysDataTapleByNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAssaysKindBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAssaysDate;
        private System.Windows.Forms.TextBox txtAssaysNo;
        private System.Windows.Forms.ComboBox cmbAssaysKind;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblAssaysKindBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_AssaysKindTableAdapter tbl_AssaysKindTableAdapter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtManagement;
        private System.Windows.Forms.TextBox txtManagementId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtAssaysId;
        private FinancialSysDataSet financialSysDataSet1;
        private System.Windows.Forms.BindingSource assaysDataTapleByNoBindingSource;
        private FinancialSysDataSetTableAdapters.AssaysDataTapleByNoTableAdapter assaysDataTapleByNoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assaysNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assaysDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assKindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assCustDataGridViewTextBoxColumn;
    }
}