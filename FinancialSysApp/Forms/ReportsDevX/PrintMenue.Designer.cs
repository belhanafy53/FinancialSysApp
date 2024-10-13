namespace FinancialSysApp.Forms.ReportsDevX
{
    partial class PrintMenue
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tBLShowMenueReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet11 = new FinancialSysApp.DataSet1();
            this.financialMenueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Tbl_FinancialMenuSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restrictionKindIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialMenuSettingIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financialMenuNameIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDueBlusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDueMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCashBlusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCashMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortingItemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortRestrictionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new FinancialSysApp.DataSet1();
            this.MenueWithCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblFinancialMenuAccountsDuePaymentBlusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter();
            this.dataTable1TableAdapter = new FinancialSysApp.DataSet1TableAdapters.DataTable1TableAdapter();
            this.menueWithCategoryTableAdapter = new FinancialSysApp.DataSet1TableAdapters.MenueWithCategoryTableAdapter();
            this.tableAdapterManager = new FinancialSysApp.DataSet1TableAdapters.TableAdapterManager();
            this.tBL_ShowMenue_ReportTableAdapter = new FinancialSysApp.DataSet1TableAdapters.TBL_ShowMenue_ReportTableAdapter();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.TCount = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tBLShowMenueReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialMenueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_FinancialMenuSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenueWithCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFinancialMenuAccountsDuePaymentBlusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tBLShowMenueReportBindingSource
            // 
            this.tBLShowMenueReportBindingSource.DataMember = "TBL_ShowMenue_Report";
            this.tBLShowMenueReportBindingSource.DataSource = this.dataSet11;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialMenueBindingSource
            // 
            this.financialMenueBindingSource.DataMember = "FinancialMenue";
            this.financialMenueBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.EnforceConstraints = false;
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tBLShowMenueReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(886, 626);
            this.reportViewer1.TabIndex = 0;
            // 
            // Tbl_FinancialMenuSettingBindingSource
            // 
            this.Tbl_FinancialMenuSettingBindingSource.DataMember = "Tbl_FinancialMenuSetting";
            this.Tbl_FinancialMenuSettingBindingSource.DataSource = this.financialSysDataSet;
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView7.AutoGenerateColumns = false;
            this.dataGridView7.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.restrictionKindIDDataGridViewTextBoxColumn,
            this.financialMenuSettingIDDataGridViewTextBoxColumn,
            this.financialMenuNameIDDataGridViewTextBoxColumn,
            this.menuNameDataGridViewTextBoxColumn,
            this.totalDueBlusDataGridViewTextBoxColumn,
            this.totalDueMinDataGridViewTextBoxColumn,
            this.totalCashBlusDataGridViewTextBoxColumn,
            this.totalCashMinDataGridViewTextBoxColumn,
            this.sortingItemsDataGridViewTextBoxColumn,
            this.parentIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.sortRestrictionDataGridViewTextBoxColumn,
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn});
            this.dataGridView7.DataSource = this.tBLShowMenueReportBindingSource;
            this.dataGridView7.EnableHeadersVisualStyles = false;
            this.dataGridView7.GridColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView7.Location = new System.Drawing.Point(587, 45);
            this.dataGridView7.Name = "dataGridView7";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView7.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView7.Size = new System.Drawing.Size(141, 176);
            this.dataGridView7.TabIndex = 152;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // restrictionKindIDDataGridViewTextBoxColumn
            // 
            this.restrictionKindIDDataGridViewTextBoxColumn.DataPropertyName = "RestrictionKind_ID";
            this.restrictionKindIDDataGridViewTextBoxColumn.HeaderText = "RestrictionKind_ID";
            this.restrictionKindIDDataGridViewTextBoxColumn.Name = "restrictionKindIDDataGridViewTextBoxColumn";
            // 
            // financialMenuSettingIDDataGridViewTextBoxColumn
            // 
            this.financialMenuSettingIDDataGridViewTextBoxColumn.DataPropertyName = "FinancialMenuSetting_ID";
            this.financialMenuSettingIDDataGridViewTextBoxColumn.HeaderText = "FinancialMenuSetting_ID";
            this.financialMenuSettingIDDataGridViewTextBoxColumn.Name = "financialMenuSettingIDDataGridViewTextBoxColumn";
            // 
            // financialMenuNameIDDataGridViewTextBoxColumn
            // 
            this.financialMenuNameIDDataGridViewTextBoxColumn.DataPropertyName = "FinancialMenuNameID";
            this.financialMenuNameIDDataGridViewTextBoxColumn.HeaderText = "FinancialMenuNameID";
            this.financialMenuNameIDDataGridViewTextBoxColumn.Name = "financialMenuNameIDDataGridViewTextBoxColumn";
            // 
            // menuNameDataGridViewTextBoxColumn
            // 
            this.menuNameDataGridViewTextBoxColumn.DataPropertyName = "MenuName";
            this.menuNameDataGridViewTextBoxColumn.HeaderText = "MenuName";
            this.menuNameDataGridViewTextBoxColumn.Name = "menuNameDataGridViewTextBoxColumn";
            // 
            // totalDueBlusDataGridViewTextBoxColumn
            // 
            this.totalDueBlusDataGridViewTextBoxColumn.DataPropertyName = "TotalDue_Blus";
            this.totalDueBlusDataGridViewTextBoxColumn.HeaderText = "TotalDue_Blus";
            this.totalDueBlusDataGridViewTextBoxColumn.Name = "totalDueBlusDataGridViewTextBoxColumn";
            // 
            // totalDueMinDataGridViewTextBoxColumn
            // 
            this.totalDueMinDataGridViewTextBoxColumn.DataPropertyName = "TotalDue_Min";
            this.totalDueMinDataGridViewTextBoxColumn.HeaderText = "TotalDue_Min";
            this.totalDueMinDataGridViewTextBoxColumn.Name = "totalDueMinDataGridViewTextBoxColumn";
            // 
            // totalCashBlusDataGridViewTextBoxColumn
            // 
            this.totalCashBlusDataGridViewTextBoxColumn.DataPropertyName = "TotalCash_Blus";
            this.totalCashBlusDataGridViewTextBoxColumn.HeaderText = "TotalCash_Blus";
            this.totalCashBlusDataGridViewTextBoxColumn.Name = "totalCashBlusDataGridViewTextBoxColumn";
            // 
            // totalCashMinDataGridViewTextBoxColumn
            // 
            this.totalCashMinDataGridViewTextBoxColumn.DataPropertyName = "TotalCash_Min";
            this.totalCashMinDataGridViewTextBoxColumn.HeaderText = "TotalCash_Min";
            this.totalCashMinDataGridViewTextBoxColumn.Name = "totalCashMinDataGridViewTextBoxColumn";
            // 
            // sortingItemsDataGridViewTextBoxColumn
            // 
            this.sortingItemsDataGridViewTextBoxColumn.DataPropertyName = "SortingItems";
            this.sortingItemsDataGridViewTextBoxColumn.HeaderText = "SortingItems";
            this.sortingItemsDataGridViewTextBoxColumn.Name = "sortingItemsDataGridViewTextBoxColumn";
            // 
            // parentIDDataGridViewTextBoxColumn
            // 
            this.parentIDDataGridViewTextBoxColumn.DataPropertyName = "Parent_ID";
            this.parentIDDataGridViewTextBoxColumn.HeaderText = "Parent_ID";
            this.parentIDDataGridViewTextBoxColumn.Name = "parentIDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // sortRestrictionDataGridViewTextBoxColumn
            // 
            this.sortRestrictionDataGridViewTextBoxColumn.DataPropertyName = "sortRestriction";
            this.sortRestrictionDataGridViewTextBoxColumn.HeaderText = "sortRestriction";
            this.sortRestrictionDataGridViewTextBoxColumn.Name = "sortRestrictionDataGridViewTextBoxColumn";
            // 
            // restrictionItemsCategoryIDDataGridViewTextBoxColumn
            // 
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn.DataPropertyName = "RestrictionItemsCategory_ID";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn.HeaderText = "RestrictionItemsCategory_ID";
            this.restrictionItemsCategoryIDDataGridViewTextBoxColumn.Name = "restrictionItemsCategoryIDDataGridViewTextBoxColumn";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(409, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 20);
            this.textBox1.TabIndex = 153;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.EnforceConstraints = false;
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MenueWithCategoryBindingSource
            // 
            this.MenueWithCategoryBindingSource.DataMember = "MenueWithCategory";
            this.MenueWithCategoryBindingSource.DataSource = this.dataSet1;
            // 
            // tblFinancialMenuAccountsDuePaymentBlusBindingSource
            // 
            this.tblFinancialMenuAccountsDuePaymentBlusBindingSource.DataMember = "Tbl_FinancialMenuAccountsDuePaymentBlus";
            this.tblFinancialMenuAccountsDuePaymentBlusBindingSource.DataSource = this.dataSet1;
            // 
            // tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter
            // 
            this.tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter.ClearBeforeFill = true;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // menueWithCategoryTableAdapter
            // 
            this.menueWithCategoryTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DetailTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountByAccountSettingTableAdapter = null;
            this.tableAdapterManager.Tbl_Accounting_GuidTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountingRestrictionItemsTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountingRestrictions_KindTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountingRestrictionTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountsKindTableAdapter = null;
            this.tableAdapterManager.Tbl_ActivitiesTableAdapter = null;
            this.tableAdapterManager.Tbl_Advac_DeferenceTableAdapter = null;
            this.tableAdapterManager.Tbl_Auth_Users_FormsTableAdapter = null;
            this.tableAdapterManager.Tbl_BanksTableAdapter = null;
            this.tableAdapterManager.Tbl_BeneficiaryKindTableAdapter = null;
            this.tableAdapterManager.Tbl_BeneficiaryTableAdapter = null;
            this.tableAdapterManager.Tbl_CenteralDeviceNotesTableAdapter = null;
            this.tableAdapterManager.Tbl_CentralDeviceRepliesTableAdapter = null;
            this.tableAdapterManager.Tbl_ChequeKindTableAdapter = null;
            this.tableAdapterManager.Tbl_ChequesTableAdapter = null;
            this.tableAdapterManager.Tbl_CostCentersTableAdapter = null;
            this.tableAdapterManager.Tbl_CustomerTableAdapter = null;
            this.tableAdapterManager.Tbl_DateRangeTableAdapter = null;
            this.tableAdapterManager.Tbl_Description_SupplyeAccount_RptTableAdapter = null;
            this.tableAdapterManager.Tbl_Document_OrdersTableAdapter = null;
            this.tableAdapterManager.Tbl_DocumentBenefcairyTableAdapter = null;
            this.tableAdapterManager.Tbl_DocumentCategoryTableAdapter = null;
            this.tableAdapterManager.TBL_DocumentTableAdapter = null;
            this.tableAdapterManager.Tbl_EmployeeTableAdapter = null;
            this.tableAdapterManager.Tbl_ExchangeCenterTableAdapter = null;
            this.tableAdapterManager.Tbl_FinancialMenuAccountByAccountDuePaymentBlusTableAdapter = null;
            this.tableAdapterManager.Tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter = this.tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter;
            this.tableAdapterManager.Tbl_FinancialMenuCategoryDuePaymentBlusTableAdapter = null;
            this.tableAdapterManager.Tbl_FinancialMenuNameTableAdapter = null;
            this.tableAdapterManager.TBL_FinancialMenuProcessingTableAdapter = null;
            this.tableAdapterManager.Tbl_FinancialMenuSettingTableAdapter = null;
            this.tableAdapterManager.Tbl_FinancialMenuValueTableAdapter = null;
            this.tableAdapterManager.Tbl_FiscalyearTableAdapter = null;
            this.tableAdapterManager.Tbl_FormsTableAdapter = null;
            this.tableAdapterManager.Tbl_FormsUserTypeUserTableAdapter = null;
            this.tableAdapterManager.Tbl_HandlerTableAdapter = null;
            this.tableAdapterManager.Tbl_HummanResourceTableAdapter = null;
            this.tableAdapterManager.Tbl_IndebtednessBeneficiaryTableAdapter = null;
            this.tableAdapterManager.Tbl_IndebtednessKindTableAdapter = null;
            this.tableAdapterManager.Tbl_IndebtednessTableAdapter = null;
            this.tableAdapterManager.Tbl_ItemsTableAdapter = null;
            this.tableAdapterManager.Tbl_ManagementCategoryTableAdapter = null;
            this.tableAdapterManager.Tbl_ManagementTableAdapter = null;
            this.tableAdapterManager.Tbl_Match_AccGuid_DocCategoryTableAdapter = null;
            this.tableAdapterManager.Tbl_MenuProgramUnitesTableAdapter = null;
            this.tableAdapterManager.Tbl_MenuProgUnit_SysUnitesTableAdapter = null;
            this.tableAdapterManager.Tbl_NormativeCostsTableAdapter = null;
            this.tableAdapterManager.Tbl_OrderAssaysTableAdapter = null;
            this.tableAdapterManager.Tbl_OrderHandlersTableAdapter = null;
            this.tableAdapterManager.Tbl_OrderItemsTableAdapter = null;
            this.tableAdapterManager.Tbl_OrderKindTableAdapter = null;
            this.tableAdapterManager.Tbl_OrderTableAdapter = null;
            this.tableAdapterManager.Tbl_PaymentMethodTableAdapter = null;
            this.tableAdapterManager.Tbl_ProceduresFormsTableAdapter = null;
            this.tableAdapterManager.Tbl_ProceduresTableAdapter = null;
            this.tableAdapterManager.Tbl_Processing_KindTableAdapter = null;
            this.tableAdapterManager.Tbl_ProcessingPurposeTableAdapter = null;
            this.tableAdapterManager.Tbl_ProjectsTableAdapter = null;
            this.tableAdapterManager.Tbl_RecievedMethodTableAdapter = null;
            this.tableAdapterManager.Tbl_RelativeRlationTableAdapter = null;
            this.tableAdapterManager.Tbl_ResponspilityCentersTableAdapter = null;
            this.tableAdapterManager.Tbl_RestrictionItemsCategoryTableAdapter = null;
            this.tableAdapterManager.TBL_RESULTTableAdapter = null;
            this.tableAdapterManager.TBL_ShowMenue_ReportTableAdapter = null;
            this.tableAdapterManager.Tbl_SupplierKindTableAdapter = null;
            this.tableAdapterManager.Tbl_SupplierTableAdapter = null;
            this.tableAdapterManager.Tbl_SystemUnitesTableAdapter = null;
            this.tableAdapterManager.Tbl_TaxAuthorityTableAdapter = null;
            this.tableAdapterManager.TBL_Temp_MatchAccountsTableAdapter = null;
            this.tableAdapterManager.Tbl_TempMatchingRestrictionsTableAdapter = null;
            this.tableAdapterManager.Tbl_UnitesTableAdapter = null;
            this.tableAdapterManager.Tbl_User_SysUnitesTableAdapter = null;
            this.tableAdapterManager.Tbl_UserAuthFormsTableAdapter = null;
            this.tableAdapterManager.Tbl_UsersProcedureFormTableAdapter = null;
            this.tableAdapterManager.Tbl_UserStatusTableAdapter = null;
            this.tableAdapterManager.Tbl_UserTableAdapter = null;
            this.tableAdapterManager.Tbl_UserTypeTableAdapter = null;
            this.tableAdapterManager.Tbl_ValueAddedTaxTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = FinancialSysApp.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tBL_ShowMenue_ReportTableAdapter
            // 
            this.tBL_ShowMenue_ReportTableAdapter.ClearBeforeFill = true;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(141, 12);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(587, 20);
            this.textBox17.TabIndex = 158;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(141, 227);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(587, 20);
            this.textBox2.TabIndex = 159;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(141, 253);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(587, 20);
            this.textBox3.TabIndex = 160;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(141, 279);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(587, 20);
            this.textBox4.TabIndex = 161;
            // 
            // TCount
            // 
            this.TCount.Location = new System.Drawing.Point(141, 305);
            this.TCount.Name = "TCount";
            this.TCount.Size = new System.Drawing.Size(587, 20);
            this.TCount.TabIndex = 162;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(141, 331);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(587, 20);
            this.textBox5.TabIndex = 163;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(141, 357);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(587, 20);
            this.textBox6.TabIndex = 164;
            // 
            // PrintMenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 626);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.dataGridView7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.TCount);
            this.Name = "PrintMenue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintMenue";
            this.Load += new System.EventHandler(this.PrintMenue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tBLShowMenueReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialMenueBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbl_FinancialMenuSettingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenueWithCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFinancialMenuAccountsDuePaymentBlusBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource financialMenueBindingSource;
        //private FinancialSysDataSetTableAdapters.FinancialMenueTableAdapter financialMenueTableAdapter;
        private System.Windows.Forms.BindingSource Tbl_FinancialMenuSettingBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblFinancialMenuAccountsDuePaymentBlusBindingSource;
        private DataSet1TableAdapters.Tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private DataSet1TableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private System.Windows.Forms.BindingSource MenueWithCategoryBindingSource;
        private DataSet1TableAdapters.MenueWithCategoryTableAdapter menueWithCategoryTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dataGridView7;
        private DataSet1 dataSet11;
        private System.Windows.Forms.BindingSource tBLShowMenueReportBindingSource;
        private DataSet1TableAdapters.TBL_ShowMenue_ReportTableAdapter tBL_ShowMenue_ReportTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionKindIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialMenuSettingIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn financialMenuNameIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDueBlusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDueMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCashBlusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCashMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortingItemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortRestrictionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restrictionItemsCategoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox17;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox TCount;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox6;
    }
}