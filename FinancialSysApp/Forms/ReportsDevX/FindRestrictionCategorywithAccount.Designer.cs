namespace FinancialSysApp.Forms.ReportsDevX
{
    partial class FindRestrictionCategorywithAccount
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblRestrictionItemsCategoryWithAccountNumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new FinancialSysApp.DataSet1();
            this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.accountNoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RestrictionItemsCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNoIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.اسمالحسابDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالحسابDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.التصنيفDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRestrictionItemsCategoryWithAccountNumberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountNoIDDataGridViewTextBoxColumn1,
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn1,
            this.اسمالحسابDataGridViewTextBoxColumn,
            this.رقمالحسابDataGridViewTextBoxColumn,
            this.التصنيفDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblRestrictionItemsCategoryWithAccountNumberBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(774, 348);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // tblRestrictionItemsCategoryWithAccountNumberBindingSource
            // 
            this.tblRestrictionItemsCategoryWithAccountNumberBindingSource.DataMember = "Tbl_RestrictionItemsCategory_With_AccountNumber";
            this.tblRestrictionItemsCategoryWithAccountNumberBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.EnforceConstraints = false;
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter
            // 
            this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(436, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // accountNoIDDataGridViewTextBoxColumn
            // 
            this.accountNoIDDataGridViewTextBoxColumn.DataPropertyName = "AccountNo_ID";
            this.accountNoIDDataGridViewTextBoxColumn.HeaderText = "AccountNo_ID";
            this.accountNoIDDataGridViewTextBoxColumn.Name = "accountNoIDDataGridViewTextBoxColumn";
            this.accountNoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // restrictionItemsCategoryIDDataGridViewTextBoxColumn
            // 
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn.DataPropertyName = "RestrictionItemsCategoryID";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn.HeaderText = "RestrictionItemsCategoryID";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn.Name = "restrictionItemsCategoryIDDataGridViewTextBoxColumn";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // AccountNo_ID
            // 
            this.AccountNo_ID.DataPropertyName = "AccountNo_ID";
            this.AccountNo_ID.HeaderText = "AccountNo_ID";
            this.AccountNo_ID.Name = "AccountNo_ID";
            // 
            // RestrictionItemsCategoryID
            // 
            this.RestrictionItemsCategoryID.DataPropertyName = "RestrictionItemsCategoryID";
            this.RestrictionItemsCategoryID.HeaderText = "RestrictionItemsCategoryID";
            this.RestrictionItemsCategoryID.Name = "RestrictionItemsCategoryID";
            // 
            // accountNoIDDataGridViewTextBoxColumn1
            // 
            this.accountNoIDDataGridViewTextBoxColumn1.DataPropertyName = "AccountNo_ID";
            this.accountNoIDDataGridViewTextBoxColumn1.HeaderText = "AccountNo_ID";
            this.accountNoIDDataGridViewTextBoxColumn1.Name = "accountNoIDDataGridViewTextBoxColumn1";
            this.accountNoIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // restrictionItemsCategoryIDDataGridViewTextBoxColumn1
            // 
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn1.DataPropertyName = "RestrictionItemsCategoryID";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn1.HeaderText = "RestrictionItemsCategoryID";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn1.Name = "restrictionItemsCategoryIDDataGridViewTextBoxColumn1";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // اسمالحسابDataGridViewTextBoxColumn
            // 
            this.اسمالحسابDataGridViewTextBoxColumn.DataPropertyName = "اسم الحساب";
            this.اسمالحسابDataGridViewTextBoxColumn.HeaderText = "اسم الحساب";
            this.اسمالحسابDataGridViewTextBoxColumn.Name = "اسمالحسابDataGridViewTextBoxColumn";
            this.اسمالحسابDataGridViewTextBoxColumn.Width = 250;
            // 
            // رقمالحسابDataGridViewTextBoxColumn
            // 
            this.رقمالحسابDataGridViewTextBoxColumn.DataPropertyName = "رقم الحساب";
            this.رقمالحسابDataGridViewTextBoxColumn.HeaderText = "رقم الحساب";
            this.رقمالحسابDataGridViewTextBoxColumn.Name = "رقمالحسابDataGridViewTextBoxColumn";
            this.رقمالحسابDataGridViewTextBoxColumn.Width = 120;
            // 
            // التصنيفDataGridViewTextBoxColumn
            // 
            this.التصنيفDataGridViewTextBoxColumn.DataPropertyName = "التصنيف";
            this.التصنيفDataGridViewTextBoxColumn.HeaderText = "التصنيف";
            this.التصنيفDataGridViewTextBoxColumn.Name = "التصنيفDataGridViewTextBoxColumn";
            this.التصنيفDataGridViewTextBoxColumn.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "أدخل رقم الحساب";
            // 
            // FindRestrictionCategorywithAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FindRestrictionCategorywithAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحديد الحسابات داخل تصنيف بنود القيد";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindRestrictionCategorywithAccount_FormClosed);
            this.Load += new System.EventHandler(this.FindRestrictionCategorywithAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRestrictionItemsCategoryWithAccountNumberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblRestrictionItemsCategoryWithAccountNumberBindingSource;
        private DataSet1TableAdapters.Tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionItemsCategoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestrictionItemsCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNoIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionItemsCategoryIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn اسمالحسابDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالحسابDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn التصنيفDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
    }
}