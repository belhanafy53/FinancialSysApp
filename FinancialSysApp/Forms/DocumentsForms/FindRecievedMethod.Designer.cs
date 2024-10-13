namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class FindRecievedMethod
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtsearchitem = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.tbl_RecievedMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new FinancialSysApp.DataSet1();
            this.tbl_RecievedMethodTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_RecievedMethodTableAdapter();
            this.tableAdapterManager = new FinancialSysApp.DataSet1TableAdapters.TableAdapterManager();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.checkEdit5 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.grpOrderData = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtOrderSupName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtManagementId = new System.Windows.Forms.TextBox();
            this.txtItemOrderId = new System.Windows.Forms.TextBox();
            this.txtOrderManagementID = new System.Windows.Forms.TextBox();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodExtraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.monthDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RecievedMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            this.grpOrderData.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtsearchitem
            // 
            this.txtsearchitem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchitem.Location = new System.Drawing.Point(20, 142);
            this.txtsearchitem.Name = "txtsearchitem";
            this.txtsearchitem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsearchitem.Size = new System.Drawing.Size(614, 25);
            this.txtsearchitem.TabIndex = 183;
            this.txtsearchitem.TextChanged += new System.EventHandler(this.txtsearchitem_TextChanged);
            this.txtsearchitem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearchitem_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.periodExtraDataGridViewTextBoxColumn,
            this.dayDataGridViewCheckBoxColumn,
            this.monthDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.tbl_RecievedMethodBindingSource;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 173);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.Size = new System.Drawing.Size(643, 274);
            this.dataGridView1.TabIndex = 190;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // checkEdit2
            // 
            this.checkEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tbl_RecievedMethodBindingSource, "Month", true));
            this.checkEdit2.Enabled = false;
            this.checkEdit2.Location = new System.Drawing.Point(174, 297);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.Caption = "بالشهر";
            this.checkEdit2.Size = new System.Drawing.Size(75, 19);
            this.checkEdit2.TabIndex = 192;
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tbl_RecievedMethodBindingSource, "Day", true));
            this.checkEdit1.Enabled = false;
            this.checkEdit1.Location = new System.Drawing.Point(83, 297);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "باليوم";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 191;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(511, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 193;
            this.label2.Text = "البحث عن طرق التسليم";
            // 
            // tbl_RecievedMethodBindingSource
            // 
            this.tbl_RecievedMethodBindingSource.DataMember = "Tbl_RecievedMethod";
            this.tbl_RecievedMethodBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_RecievedMethodTableAdapter
            // 
            this.tbl_RecievedMethodTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.Tbl_FinancialMenuAccountsDuePaymentBlusTableAdapter = null;
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
            this.tableAdapterManager.Tbl_RecievedMethodTableAdapter = this.tbl_RecievedMethodTableAdapter;
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
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "{0:yyyy MM dd}";
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(222, 292);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(115, 24);
            this.dateTimePicker2.TabIndex = 206;
            this.dateTimePicker2.Visible = false;
            // 
            // checkEdit5
            // 
            this.checkEdit5.Location = new System.Drawing.Point(343, 292);
            this.checkEdit5.Name = "checkEdit5";
            this.checkEdit5.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.checkEdit5.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.checkEdit5.Properties.Appearance.Options.UseFont = true;
            this.checkEdit5.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit5.Properties.Caption = "من تاريخ آخر";
            this.checkEdit5.Size = new System.Drawing.Size(123, 21);
            this.checkEdit5.TabIndex = 204;
            this.checkEdit5.Visible = false;
            this.checkEdit5.CheckedChanged += new System.EventHandler(this.checkEdit5_CheckedChanged);
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(472, 293);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.checkEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.checkEdit3.Properties.Appearance.Options.UseFont = true;
            this.checkEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit3.Properties.Caption = "من تاريخ الامر";
            this.checkEdit3.Size = new System.Drawing.Size(137, 21);
            this.checkEdit3.TabIndex = 205;
            this.checkEdit3.Visible = false;
            this.checkEdit3.CheckedChanged += new System.EventHandler(this.checkEdit3_CheckedChanged);
            // 
            // textBox8
            // 
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_RecievedMethodBindingSource, "PeriodExtra", true));
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(137, 290);
            this.textBox8.Name = "textBox8";
            this.textBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox8.Size = new System.Drawing.Size(69, 25);
            this.textBox8.TabIndex = 203;
            // 
            // grpOrderData
            // 
            this.grpOrderData.BackColor = System.Drawing.Color.Transparent;
            this.grpOrderData.Controls.Add(this.textBox3);
            this.grpOrderData.Controls.Add(this.label1);
            this.grpOrderData.Controls.Add(this.dateTimePicker1);
            this.grpOrderData.Controls.Add(this.txtOrderSupName);
            this.grpOrderData.Controls.Add(this.label7);
            this.grpOrderData.Controls.Add(this.label8);
            this.grpOrderData.Controls.Add(this.label9);
            this.grpOrderData.Controls.Add(this.txtOrderNo);
            this.grpOrderData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderData.ForeColor = System.Drawing.Color.Black;
            this.grpOrderData.Location = new System.Drawing.Point(-116, 54);
            this.grpOrderData.Name = "grpOrderData";
            this.grpOrderData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpOrderData.Size = new System.Drawing.Size(766, 56);
            this.grpOrderData.TabIndex = 207;
            this.grpOrderData.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "{0:yyyy MM dd}";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(534, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 26);
            this.dateTimePicker1.TabIndex = 167;
            // 
            // txtOrderSupName
            // 
            this.txtOrderSupName.Location = new System.Drawing.Point(351, 24);
            this.txtOrderSupName.Name = "txtOrderSupName";
            this.txtOrderSupName.Size = new System.Drawing.Size(139, 26);
            this.txtOrderSupName.TabIndex = 166;
            this.txtOrderSupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrderSupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderSupName_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(421, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 165;
            this.label7.Text = "تاريخ التسليم";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(581, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 163;
            this.label8.Text = "تاريخ الامر";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(698, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 162;
            this.label9.Text = "رقم الامر";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Enabled = false;
            this.txtOrderNo.Location = new System.Drawing.Point(651, 25);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(99, 26);
            this.txtOrderNo.TabIndex = 162;
            this.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(38, 20);
            this.textBox1.TabIndex = 213;
            this.textBox1.Visible = false;
            // 
            // txtManagementId
            // 
            this.txtManagementId.Location = new System.Drawing.Point(12, 12);
            this.txtManagementId.Name = "txtManagementId";
            this.txtManagementId.Size = new System.Drawing.Size(32, 20);
            this.txtManagementId.TabIndex = 210;
            this.txtManagementId.Visible = false;
            // 
            // txtItemOrderId
            // 
            this.txtItemOrderId.Location = new System.Drawing.Point(12, 8);
            this.txtItemOrderId.Name = "txtItemOrderId";
            this.txtItemOrderId.Size = new System.Drawing.Size(38, 20);
            this.txtItemOrderId.TabIndex = 211;
            this.txtItemOrderId.Visible = false;
            // 
            // txtOrderManagementID
            // 
            this.txtOrderManagementID.Location = new System.Drawing.Point(12, 12);
            this.txtOrderManagementID.Name = "txtOrderManagementID";
            this.txtOrderManagementID.Size = new System.Drawing.Size(38, 20);
            this.txtOrderManagementID.TabIndex = 212;
            this.txtOrderManagementID.Visible = false;
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(12, 12);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(32, 20);
            this.txtOrderId.TabIndex = 208;
            this.txtOrderId.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(12, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(32, 23);
            this.textBox2.TabIndex = 209;
            this.textBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 214;
            this.label3.Text = "طريقة التسليم";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "طريقة التسليم";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 120;
            // 
            // periodExtraDataGridViewTextBoxColumn
            // 
            this.periodExtraDataGridViewTextBoxColumn.DataPropertyName = "PeriodExtra";
            this.periodExtraDataGridViewTextBoxColumn.HeaderText = "المدة الإضافية";
            this.periodExtraDataGridViewTextBoxColumn.Name = "periodExtraDataGridViewTextBoxColumn";
            this.periodExtraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dayDataGridViewCheckBoxColumn
            // 
            this.dayDataGridViewCheckBoxColumn.DataPropertyName = "Day";
            this.dayDataGridViewCheckBoxColumn.HeaderText = "باليوم";
            this.dayDataGridViewCheckBoxColumn.Name = "dayDataGridViewCheckBoxColumn";
            this.dayDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // monthDataGridViewCheckBoxColumn
            // 
            this.monthDataGridViewCheckBoxColumn.DataPropertyName = "Month";
            this.monthDataGridViewCheckBoxColumn.HeaderText = "بالشهر";
            this.monthDataGridViewCheckBoxColumn.Name = "monthDataGridViewCheckBoxColumn";
            this.monthDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(136, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 26);
            this.textBox3.TabIndex = 169;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(146, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 168;
            this.label1.Text = "تاريخ التسليم الفعلى";
            // 
            // FindRecievedMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 447);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtManagementId);
            this.Controls.Add(this.txtItemOrderId);
            this.Controls.Add(this.txtOrderManagementID);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.grpOrderData);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.checkEdit5);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsearchitem);
            this.MaximizeBox = false;
            this.Name = "FindRecievedMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اختر طريقة التسليم";
            this.Load += new System.EventHandler(this.FindRecievedMethod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RecievedMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            this.grpOrderData.ResumeLayout(false);
            this.grpOrderData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tbl_RecievedMethodBindingSource;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.Tbl_RecievedMethodTableAdapter tbl_RecievedMethodTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox txtsearchitem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        private DevExpress.XtraEditors.CheckEdit checkEdit5;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.GroupBox grpOrderData;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.TextBox txtOrderSupName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtOrderNo;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtManagementId;
        public System.Windows.Forms.TextBox txtItemOrderId;
        public System.Windows.Forms.TextBox txtOrderManagementID;
        public System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodExtraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dayDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn monthDataGridViewCheckBoxColumn;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
    }
}