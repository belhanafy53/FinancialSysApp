namespace FinancialSysApp.Forms.CashDeposit
{
    partial class CheqDCAuditUpdateStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheqDCAuditUpdateStatus));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الفرعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.isUpdateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.الملاحظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالمراجعهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالتعديلDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الملاخظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtbDepositCashWithErrorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.depositCashDS = new FinancialSysApp.DepositCashDS();
            this.dtb_DepositCashWithErrorTableAdapter = new FinancialSysApp.DepositCashDSTableAdapters.Dtb_DepositCashWithErrorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDepositCashWithErrorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositCashDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 24);
            this.label1.TabIndex = 274;
            this.label1.Text = "موقف الايداعات النقديه بعد المراجعه";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(442, 604);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(227, 35);
            this.simpleButton7.TabIndex = 277;
            this.simpleButton7.Text = "حفظ";
            this.simpleButton7.Visible = false;
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
            this.Ser,
            this.الفرعDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
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
            this.رقمالحسابDataGridViewTextBoxColumn,
            this.isUpdateDataGridViewCheckBoxColumn,
            this.الملاحظهDataGridViewTextBoxColumn,
            this.تاريخالمراجعهDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.تاريخالتعديلDataGridViewTextBoxColumn,
            this.الملاخظهDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dtbDepositCashWithErrorBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1123, 542);
            this.dataGridView1.TabIndex = 275;
            // 
            // Ser
            // 
            this.Ser.HeaderText = "م";
            this.Ser.Name = "Ser";
            this.Ser.ReadOnly = true;
            this.Ser.Width = 40;
            // 
            // الفرعDataGridViewTextBoxColumn
            // 
            this.الفرعDataGridViewTextBoxColumn.DataPropertyName = "الفرع";
            this.الفرعDataGridViewTextBoxColumn.HeaderText = "الفرع";
            this.الفرعDataGridViewTextBoxColumn.Name = "الفرعDataGridViewTextBoxColumn";
            this.الفرعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
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
            this.تاريخالايداعDataGridViewTextBoxColumn.HeaderText = "تاريخ الايداع";
            this.تاريخالايداعDataGridViewTextBoxColumn.Name = "تاريخالايداعDataGridViewTextBoxColumn";
            this.تاريخالايداعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالحقDataGridViewTextBoxColumn
            // 
            this.تاريخالحقDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الحق";
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
            // 
            // مندوبالخزينهDataGridViewTextBoxColumn
            // 
            this.مندوبالخزينهDataGridViewTextBoxColumn.DataPropertyName = "مندوب الخزينه";
            this.مندوبالخزينهDataGridViewTextBoxColumn.HeaderText = "مندوب الخزينه";
            this.مندوبالخزينهDataGridViewTextBoxColumn.Name = "مندوبالخزينهDataGridViewTextBoxColumn";
            this.مندوبالخزينهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // البنكDataGridViewTextBoxColumn
            // 
            this.البنكDataGridViewTextBoxColumn.DataPropertyName = "البنك";
            this.البنكDataGridViewTextBoxColumn.HeaderText = "البنك";
            this.البنكDataGridViewTextBoxColumn.Name = "البنكDataGridViewTextBoxColumn";
            this.البنكDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // رقمالحسابDataGridViewTextBoxColumn
            // 
            this.رقمالحسابDataGridViewTextBoxColumn.DataPropertyName = "رقم الحساب";
            this.رقمالحسابDataGridViewTextBoxColumn.HeaderText = "رقم الحساب";
            this.رقمالحسابDataGridViewTextBoxColumn.Name = "رقمالحسابDataGridViewTextBoxColumn";
            this.رقمالحسابDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isUpdateDataGridViewCheckBoxColumn
            // 
            this.isUpdateDataGridViewCheckBoxColumn.DataPropertyName = "IsUpdate";
            this.isUpdateDataGridViewCheckBoxColumn.HeaderText = "IsUpdate";
            this.isUpdateDataGridViewCheckBoxColumn.Name = "isUpdateDataGridViewCheckBoxColumn";
            this.isUpdateDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isUpdateDataGridViewCheckBoxColumn.Visible = false;
            // 
            // الملاحظهDataGridViewTextBoxColumn
            // 
            this.الملاحظهDataGridViewTextBoxColumn.DataPropertyName = "الملاحظه";
            this.الملاحظهDataGridViewTextBoxColumn.HeaderText = "الملاحظه";
            this.الملاحظهDataGridViewTextBoxColumn.Name = "الملاحظهDataGridViewTextBoxColumn";
            this.الملاحظهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالمراجعهDataGridViewTextBoxColumn
            // 
            this.تاريخالمراجعهDataGridViewTextBoxColumn.DataPropertyName = "تاريخ المراجعه";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.HeaderText = "تاريخ المراجعه";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.Name = "تاريخالمراجعهDataGridViewTextBoxColumn";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // تاريخالتعديلDataGridViewTextBoxColumn
            // 
            this.تاريخالتعديلDataGridViewTextBoxColumn.DataPropertyName = "تاريخ التعديل";
            this.تاريخالتعديلDataGridViewTextBoxColumn.HeaderText = "تاريخ التعديل";
            this.تاريخالتعديلDataGridViewTextBoxColumn.Name = "تاريخالتعديلDataGridViewTextBoxColumn";
            this.تاريخالتعديلDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الملاخظهDataGridViewTextBoxColumn
            // 
            this.الملاخظهDataGridViewTextBoxColumn.DataPropertyName = "الملاخظه";
            this.الملاخظهDataGridViewTextBoxColumn.HeaderText = "الملاخظه";
            this.الملاخظهDataGridViewTextBoxColumn.Name = "الملاخظهDataGridViewTextBoxColumn";
            this.الملاخظهDataGridViewTextBoxColumn.ReadOnly = true;
            this.الملاخظهDataGridViewTextBoxColumn.Visible = false;
            // 
            // dtbDepositCashWithErrorBindingSource
            // 
            this.dtbDepositCashWithErrorBindingSource.DataMember = "Dtb_DepositCashWithError";
            this.dtbDepositCashWithErrorBindingSource.DataSource = this.depositCashDS;
            // 
            // depositCashDS
            // 
            this.depositCashDS.DataSetName = "DepositCashDS";
            this.depositCashDS.EnforceConstraints = false;
            this.depositCashDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtb_DepositCashWithErrorTableAdapter
            // 
            this.dtb_DepositCashWithErrorTableAdapter.ClearBeforeFill = true;
            // 
            // CheqDCAuditUpdateStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 601);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "CheqDCAuditUpdateStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CheqDCAuditUpdateStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDepositCashWithErrorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositCashDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn المراجعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn مدخلالبياناتDataGridViewTextBoxColumn;
        private DepositCashDS depositCashDS;
        private System.Windows.Forms.BindingSource dtbDepositCashWithErrorBindingSource;
        private DepositCashDSTableAdapters.Dtb_DepositCashWithErrorTableAdapter dtb_DepositCashWithErrorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser;
        private System.Windows.Forms.DataGridViewTextBoxColumn الفرعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUpdateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الملاحظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالمراجعهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expr1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالتعديلDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الملاخظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}