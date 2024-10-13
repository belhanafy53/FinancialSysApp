namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class RecievedMethodSettingFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecievedMethodSettingFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtsearchitem = new System.Windows.Forms.TextBox();
            this.tbl_RecievedMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new FinancialSysApp.DataSet1();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbl_RecievedMethodTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_RecievedMethodTableAdapter();
            this.tableAdapterManager = new FinancialSysApp.DataSet1TableAdapters.TableAdapterManager();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodExtraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.monthDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RecievedMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(331, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 183;
            this.label1.Text = "طريقة التسليم";
            // 
            // txtsearchitem
            // 
            this.txtsearchitem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_RecievedMethodBindingSource, "Name", true));
            this.txtsearchitem.Enabled = false;
            this.txtsearchitem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchitem.Location = new System.Drawing.Point(63, 55);
            this.txtsearchitem.Name = "txtsearchitem";
            this.txtsearchitem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtsearchitem.Size = new System.Drawing.Size(262, 25);
            this.txtsearchitem.TabIndex = 182;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(331, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 185;
            this.label2.Text = "المدة الإضافية";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbl_RecievedMethodBindingSource, "PeriodExtra", true));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(63, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(84, 25);
            this.textBox1.TabIndex = 184;
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tbl_RecievedMethodBindingSource, "Day", true));
            this.checkEdit1.Enabled = false;
            this.checkEdit1.Location = new System.Drawing.Point(250, 89);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "باليوم";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 186;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // checkEdit2
            // 
            this.checkEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tbl_RecievedMethodBindingSource, "Month", true));
            this.checkEdit2.Enabled = false;
            this.checkEdit2.Location = new System.Drawing.Point(153, 89);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.Caption = "بالشهر";
            this.checkEdit2.Size = new System.Drawing.Size(75, 19);
            this.checkEdit2.TabIndex = 187;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.periodExtraDataGridViewTextBoxColumn,
            this.dayDataGridViewCheckBoxColumn,
            this.monthDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.tbl_RecievedMethodBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 184);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.Size = new System.Drawing.Size(442, 252);
            this.dataGridView1.TabIndex = 189;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
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
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Enabled = false;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(165, 128);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(96, 37);
            this.simpleButton2.TabIndex = 191;
            this.simpleButton2.Text = "حفظ";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(334, 128);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 37);
            this.simpleButton1.TabIndex = 192;
            this.simpleButton1.Text = "إضافة";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(181, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 193;
            this.label3.Text = "طرق التسليم";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Enabled = false;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(63, 128);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(96, 37);
            this.simpleButton3.TabIndex = 194;
            this.simpleButton3.Text = "تعديل";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
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
            // RecievedMethodSettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 436);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsearchitem);
            this.MaximizeBox = false;
            this.Name = "RecievedMethodSettingFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طرق التسليم";
            this.Load += new System.EventHandler(this.RecievedMethodSettingFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_RecievedMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsearchitem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tbl_RecievedMethodBindingSource;
        private DataSet1TableAdapters.Tbl_RecievedMethodTableAdapter tbl_RecievedMethodTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodExtraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dayDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn monthDataGridViewCheckBoxColumn;
    }
}