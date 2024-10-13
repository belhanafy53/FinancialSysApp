namespace FinancialSysApp.Forms.ProcessingForms
{
    partial class XtraUserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label account_NOLabel;
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAccount_NO = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.financialSysDataSet1 = new FinancialSysApp.FinancialSysDataSet();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tblAccountingGuidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_Accounting_GuidTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_Accounting_GuidTableAdapter();
            this.tbl_Accounting_GuidTableAdapter1 = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_Accounting_GuidTableAdapter();
            this.tableAdapterManager = new FinancialSysApp.FinancialSysDataSetTableAdapters.TableAdapterManager();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            account_NOLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingGuidBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(64, 246);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // account_NOLabel
            // 
            account_NOLabel.AutoSize = true;
            account_NOLabel.Location = new System.Drawing.Point(34, 282);
            account_NOLabel.Name = "account_NOLabel";
            account_NOLabel.Size = new System.Drawing.Size(68, 13);
            account_NOLabel.TabIndex = 3;
            account_NOLabel.Text = "Account NO:";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colAccount_NO,
            this.colName});
            this.treeList1.DataMember = "Tbl_Accounting_Guid";
            this.treeList1.DataSource = this.financialSysDataSet1;
            this.treeList1.KeyFieldName = "Account_NO";
            this.treeList1.Location = new System.Drawing.Point(27, 25);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.ParentFieldName = "Parent_ID";
            this.treeList1.Size = new System.Drawing.Size(501, 200);
            this.treeList1.TabIndex = 0;
            this.treeList1.GetPreviewText += new DevExpress.XtraTreeList.GetPreviewTextEventHandler(this.treeList1_GetPreviewText);
            this.treeList1.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.treeList1_CustomNodeCellEdit);
            this.treeList1.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterFocusNode);
            this.treeList1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterCheckNode);
            this.treeList1.Click += new System.EventHandler(this.treeList1_Click);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colAccount_NO
            // 
            this.colAccount_NO.FieldName = "Account_NO";
            this.colAccount_NO.Name = "colAccount_NO";
            this.colAccount_NO.Visible = true;
            this.colAccount_NO.VisibleIndex = 0;
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
            // tblAccountingGuidBindingSource
            // 
            this.tblAccountingGuidBindingSource.DataMember = "Tbl_Accounting_Guid";
            this.tblAccountingGuidBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_Accounting_GuidTableAdapter
            // 
            this.tbl_Accounting_GuidTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_Accounting_GuidTableAdapter1
            // 
            this.tbl_Accounting_GuidTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DetailTableAdapter = null;
            //this.tableAdapterManager.gljrnlhTableAdapter = null;
            this.tableAdapterManager.Tbl_Accounting_GuidTableAdapter = this.tbl_Accounting_GuidTableAdapter;
            this.tableAdapterManager.Tbl_AccountingRestrictionItemsTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountingRestrictions_KindTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountingRestrictionTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountsKindTableAdapter = null;
            this.tableAdapterManager.Tbl_BeneficiaryKindTableAdapter = null;
            this.tableAdapterManager.Tbl_BeneficiaryTableAdapter = null;
            this.tableAdapterManager.Tbl_CustomerTableAdapter = null;
            this.tableAdapterManager.Tbl_DateRangeTableAdapter = null;
            this.tableAdapterManager.Tbl_DocumentCategoryTableAdapter = null;
            this.tableAdapterManager.TBL_DocumentTableAdapter = null;
            this.tableAdapterManager.Tbl_EmployeeTableAdapter = null;
            this.tableAdapterManager.Tbl_ExchangeCenterTableAdapter = null;
            this.tableAdapterManager.Tbl_IndebtednessKindTableAdapter = null;
            this.tableAdapterManager.Tbl_IndebtednessTableAdapter = null;
            this.tableAdapterManager.Tbl_ManagementCategoryTableAdapter = null;
            this.tableAdapterManager.Tbl_ManagementTableAdapter = null;
            //this.tableAdapterManager.Tbl_OrderHandlerTableAdapter = null;
            this.tableAdapterManager.Tbl_OrderKindTableAdapter = null;
            this.tableAdapterManager.Tbl_OrderTableAdapter = null;
            //this.tableAdapterManager.Tbl_ReportTableAdapter = null;
            this.tableAdapterManager.Tbl_RestrictionItemsCategoryTableAdapter = null;
            this.tableAdapterManager.TBL_RESULTTableAdapter = null;
            this.tableAdapterManager.Tbl_SupplierTableAdapter = null;
            this.tableAdapterManager.Tbl_UserTableAdapter = null;
            //this.tableAdapterManager.TreeTableAdapter = null;
            //this.tableAdapterManager.tTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = FinancialSysApp.FinancialSysDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblAccountingGuidBindingSource, "Name", true));
            this.textBox1.Location = new System.Drawing.Point(124, 246);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tblAccountingGuidBindingSource, "Account_NO", true));
            this.textBox2.Location = new System.Drawing.Point(138, 279);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // XtraUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(account_NOLabel);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.treeList1);
            this.Name = "XtraUserControl1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(589, 457);
            this.Load += new System.EventHandler(this.XtraUserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingGuidBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private FinancialSysDataSet financialSysDataSet1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblAccountingGuidBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_Accounting_GuidTableAdapter tbl_Accounting_GuidTableAdapter;
        private FinancialSysDataSetTableAdapters.Tbl_Accounting_GuidTableAdapter tbl_Accounting_GuidTableAdapter1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAccount_NO;
        private FinancialSysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox2;
    }
}
