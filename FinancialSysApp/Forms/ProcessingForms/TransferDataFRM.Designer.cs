namespace FinancialSysApp.Forms.ProcessingForms
{
    partial class TransferDataFRM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferDataFRM));
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tBLTempMatchAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBL_Temp_MatchAccountsTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.TBL_Temp_MatchAccountsTableAdapter();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colACC_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACC_NM_Ar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tbl_FinanctialSearchTableAdapter = new FinancialSysApp.FinaSearchTableAdapters.Tbl_FinanctialSearchTableAdapter();
            this.ultraGridFilterUIProvider1 = new Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(this.components);
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.benifaryTableAdapter = new FinancialSysApp.FinaSearchTableAdapters.BenifaryTableAdapter();
            this.totalAccRestrByUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new FinancialSysApp.DataSet1();
            this.tblBeneficiaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.benifaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.finaSearch = new FinancialSysApp.FinaSearch();
            this.tblFinanctialSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblOrderKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblSystemUnitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblAccountingRestrictionItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBLPeriodsoffiscalyearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Periods_of_fiscalyear = new FinancialSysApp._Periods_of_fiscalyear();
            this.tBL_Periods_of__fiscal_yearTableAdapter = new FinancialSysApp._Periods_of_fiscalyearTableAdapters.TBL_Periods_of__fiscal_yearTableAdapter();
            this.tblFiscalyearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem7 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem8 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem9 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem10 = new DevExpress.XtraBars.BarStaticItem();
            this.tblAccountingRestrictionsKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_OrderKindTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_OrderKindTableAdapter();
            this.tableAdapterManager = new FinancialSysApp.DataSet1TableAdapters.TableAdapterManager();
            this.tbl_AccountingRestrictionItemsTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_AccountingRestrictionItemsTableAdapter();
            this.tbl_SystemUnitesTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_SystemUnitesTableAdapter();
            this.totalAccRestrByUserTableAdapter = new FinancialSysApp.DataSet1TableAdapters.TotalAccRestrByUserTableAdapter();
            this.tbl_FiscalyearTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_FiscalyearTableAdapter();
            this.tbl_BeneficiaryTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_BeneficiaryTableAdapter();
            this.tbl_AccountingRestrictions_KindTableAdapter = new FinancialSysApp.DataSet1TableAdapters.Tbl_AccountingRestrictions_KindTableAdapter();
            this.searchingTableAdapter = new FinancialSysApp.FinaSearchTableAdapters.SearchingTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLTempMatchAccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalAccRestrByUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBeneficiaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.benifaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finaSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFinanctialSearchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderKindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSystemUnitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLPeriodsoffiscalyearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Periods_of_fiscalyear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionsKindBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(563, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "  ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(12, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 13);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "  ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 54);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(438, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "جلب البيانات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 342);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 24;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 394);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(9, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(801, 206);
            this.dataGridView1.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(727, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "عدد السجلات ";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(15, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBLTempMatchAccountsBindingSource
            // 
            this.tBLTempMatchAccountsBindingSource.DataMember = "TBL_Temp_MatchAccounts";
            this.tBLTempMatchAccountsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tBL_Temp_MatchAccountsTableAdapter
            // 
            this.tBL_Temp_MatchAccountsTableAdapter.ClearBeforeFill = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tBLTempMatchAccountsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(9, 308);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(801, 195);
            this.gridControl1.TabIndex = 26;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colACC_NO,
            this.colACC_NM_Ar,
            this.colID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colACC_NO
            // 
            this.colACC_NO.Caption = "رقم الحساب";
            this.colACC_NO.FieldName = "ACC_NO";
            this.colACC_NO.Name = "colACC_NO";
            this.colACC_NO.Visible = true;
            this.colACC_NO.VisibleIndex = 0;
            // 
            // colACC_NM_Ar
            // 
            this.colACC_NM_Ar.Caption = "اسم الحساب";
            this.colACC_NM_Ar.FieldName = "ACC_NM_Ar";
            this.colACC_NM_Ar.Name = "colACC_NM_Ar";
            this.colACC_NM_Ar.Visible = true;
            this.colACC_NM_Ar.VisibleIndex = 1;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(632, 509);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 30);
            this.button5.TabIndex = 27;
            this.button5.Text = "تصدير الحسابات إكسيل";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(360, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(182, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker2.TabIndex = 29;
            // 
            // tbl_FinanctialSearchTableAdapter
            // 
            this.tbl_FinanctialSearchTableAdapter.ClearBeforeFill = true;
            // 
            // ultraGridFilterUIProvider1
            // 
            this.ultraGridFilterUIProvider1.OperandListFilterBehavior = Infragistics.Win.UltraWinGrid.OperandListFilterBehavior.ShowAllItems;
            this.ultraGridFilterUIProvider1.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGridFilterUIProvider1.ViewStyle = Infragistics.Win.SupportDialogs.FilterUIProvider.FilterUIProviderViewStyle.Vista;
            // 
            // benifaryTableAdapter
            // 
            this.benifaryTableAdapter.ClearBeforeFill = true;
            // 
            // totalAccRestrByUserBindingSource
            // 
            this.totalAccRestrByUserBindingSource.DataMember = "TotalAccRestrByUser";
            this.totalAccRestrByUserBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.EnforceConstraints = false;
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblBeneficiaryBindingSource
            // 
            this.tblBeneficiaryBindingSource.DataMember = "Tbl_Beneficiary";
            this.tblBeneficiaryBindingSource.DataSource = this.dataSet1;
            // 
            // benifaryBindingSource
            // 
            this.benifaryBindingSource.DataMember = "Benifary";
            this.benifaryBindingSource.DataSource = this.finaSearch;
            // 
            // finaSearch
            // 
            this.finaSearch.DataSetName = "FinaSearch";
            this.finaSearch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblFinanctialSearchBindingSource
            // 
            this.tblFinanctialSearchBindingSource.DataMember = "Tbl_FinanctialSearch";
            this.tblFinanctialSearchBindingSource.DataSource = this.finaSearch;
            // 
            // searchingBindingSource
            // 
            this.searchingBindingSource.DataMember = "Searching";
            this.searchingBindingSource.DataSource = this.finaSearch;
            // 
            // tblOrderKindBindingSource
            // 
            this.tblOrderKindBindingSource.DataMember = "Tbl_OrderKind";
            this.tblOrderKindBindingSource.DataSource = this.dataSet1;
            // 
            // tblSystemUnitesBindingSource
            // 
            this.tblSystemUnitesBindingSource.DataMember = "Tbl_SystemUnites";
            this.tblSystemUnitesBindingSource.DataSource = this.dataSet1;
            // 
            // tblAccountingRestrictionItemsBindingSource
            // 
            this.tblAccountingRestrictionItemsBindingSource.DataMember = "Tbl_AccountingRestrictionItems";
            this.tblAccountingRestrictionItemsBindingSource.DataSource = this.dataSet1;
            // 
            // tBLPeriodsoffiscalyearBindingSource
            // 
            this.tBLPeriodsoffiscalyearBindingSource.DataMember = "TBL_Periods_of _fiscal_year";
            this.tBLPeriodsoffiscalyearBindingSource.DataSource = this._Periods_of_fiscalyear;
            // 
            // _Periods_of_fiscalyear
            // 
            this._Periods_of_fiscalyear.DataSetName = "Periods-of_fiscalyear";
            this._Periods_of_fiscalyear.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBL_Periods_of__fiscal_yearTableAdapter
            // 
            this.tBL_Periods_of__fiscal_yearTableAdapter.ClearBeforeFill = true;
            // 
            // tblFiscalyearBindingSource
            // 
            this.tblFiscalyearBindingSource.DataMember = "Tbl_Fiscalyear";
            this.tblFiscalyearBindingSource.DataSource = this.dataSet1;
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem6,
            this.barStaticItem7,
            this.barStaticItem8,
            this.barButtonItem12,
            this.barStaticItem9,
            this.barStaticItem10});
            this.barManager2.MaxItemId = 10;
            this.barManager2.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            this.barManager2.StatusBar = this.bar1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Status bar";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Status bar";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Size = new System.Drawing.Size(812, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 549);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Size = new System.Drawing.Size(812, 22);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Size = new System.Drawing.Size(0, 549);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(812, 0);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Size = new System.Drawing.Size(0, 549);
            // 
            // barStaticItem6
            // 
            this.barStaticItem6.Caption = "قائمة المركز المالى";
            this.barStaticItem6.Id = 0;
            this.barStaticItem6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barStaticItem6.ImageOptions.SvgImage")));
            this.barStaticItem6.Name = "barStaticItem6";
            this.barStaticItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem7
            // 
            this.barStaticItem7.Caption = "barStaticItem2";
            this.barStaticItem7.Id = 1;
            this.barStaticItem7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem7.ImageOptions.Image")));
            this.barStaticItem7.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItem7.ImageOptions.LargeImage")));
            this.barStaticItem7.Name = "barStaticItem7";
            this.barStaticItem7.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem8
            // 
            this.barStaticItem8.Caption = "barStaticItem3";
            this.barStaticItem8.Id = 2;
            this.barStaticItem8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem8.ImageOptions.Image")));
            this.barStaticItem8.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItem8.ImageOptions.LargeImage")));
            this.barStaticItem8.Name = "barStaticItem8";
            this.barStaticItem8.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "h";
            this.barButtonItem12.Id = 3;
            this.barButtonItem12.Name = "barButtonItem12";
            // 
            // barStaticItem9
            // 
            this.barStaticItem9.Caption = "barStaticItem4";
            this.barStaticItem9.Id = 4;
            this.barStaticItem9.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem9.ImageOptions.Image")));
            this.barStaticItem9.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItem9.ImageOptions.LargeImage")));
            this.barStaticItem9.Name = "barStaticItem9";
            this.barStaticItem9.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem10
            // 
            this.barStaticItem10.Caption = "barStaticItem5";
            this.barStaticItem10.Id = 5;
            this.barStaticItem10.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem10.ImageOptions.Image")));
            this.barStaticItem10.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItem10.ImageOptions.LargeImage")));
            this.barStaticItem10.Name = "barStaticItem10";
            this.barStaticItem10.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // tblAccountingRestrictionsKindBindingSource
            // 
            this.tblAccountingRestrictionsKindBindingSource.DataMember = "Tbl_AccountingRestrictions_Kind";
            this.tblAccountingRestrictionsKindBindingSource.DataSource = this.dataSet1;
            // 
            // tbl_OrderKindTableAdapter
            // 
            this.tbl_OrderKindTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DetailTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountByAccountSettingTableAdapter = null;
            this.tableAdapterManager.Tbl_Accounting_GuidTableAdapter = null;
            this.tableAdapterManager.Tbl_AccountingRestrictionItemsTableAdapter = this.tbl_AccountingRestrictionItemsTableAdapter;
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
            this.tableAdapterManager.Tbl_OrderKindTableAdapter = this.tbl_OrderKindTableAdapter;
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
            this.tableAdapterManager.Tbl_SystemUnitesTableAdapter = this.tbl_SystemUnitesTableAdapter;
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
            // tbl_AccountingRestrictionItemsTableAdapter
            // 
            this.tbl_AccountingRestrictionItemsTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_SystemUnitesTableAdapter
            // 
            this.tbl_SystemUnitesTableAdapter.ClearBeforeFill = true;
            // 
            // totalAccRestrByUserTableAdapter
            // 
            this.totalAccRestrByUserTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_FiscalyearTableAdapter
            // 
            this.tbl_FiscalyearTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_BeneficiaryTableAdapter
            // 
            this.tbl_BeneficiaryTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_AccountingRestrictions_KindTableAdapter
            // 
            this.tbl_AccountingRestrictions_KindTableAdapter.ClearBeforeFill = true;
            // 
            // searchingTableAdapter
            // 
            this.searchingTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "الفترة من";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "الفترة الى";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(748, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 17);
            this.labelControl2.TabIndex = 372;
            this.labelControl2.Text = "العام المالى";
            // 
            // comboBox9
            // 
            this.comboBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox9.BackColor = System.Drawing.Color.LightGray;
            this.comboBox9.DataSource = this.tblFiscalyearBindingSource;
            this.comboBox9.DisplayMember = "Name";
            this.comboBox9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(582, 7);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox9.Size = new System.Drawing.Size(160, 21);
            this.comboBox9.TabIndex = 371;
            this.comboBox9.TabStop = false;
            this.comboBox9.ValueMember = "ID";
            // 
            // TransferDataFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 571);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.comboBox9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "TransferDataFRM";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جلب البيانات";
            this.Load += new System.EventHandler(this.TransferDataFRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLTempMatchAccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalAccRestrByUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBeneficiaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.benifaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finaSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFinanctialSearchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderKindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSystemUnitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLPeriodsoffiscalyearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Periods_of_fiscalyear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblFiscalyearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountingRestrictionsKindBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tBLTempMatchAccountsBindingSource;
        private FinancialSysDataSetTableAdapters.TBL_Temp_MatchAccountsTableAdapter tBL_Temp_MatchAccountsTableAdapter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colACC_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colACC_NM_Ar;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private FinaSearchTableAdapters.Tbl_FinanctialSearchTableAdapter tbl_FinanctialSearchTableAdapter;
        private Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider ultraGridFilterUIProvider1;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        private FinaSearchTableAdapters.BenifaryTableAdapter benifaryTableAdapter;
        private System.Windows.Forms.BindingSource totalAccRestrByUserBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tblBeneficiaryBindingSource;
        private System.Windows.Forms.BindingSource benifaryBindingSource;
        private FinaSearch finaSearch;
        private System.Windows.Forms.BindingSource tblFinanctialSearchBindingSource;
        private System.Windows.Forms.BindingSource searchingBindingSource;
        private System.Windows.Forms.BindingSource tblOrderKindBindingSource;
        private System.Windows.Forms.BindingSource tblSystemUnitesBindingSource;
        private System.Windows.Forms.BindingSource tblAccountingRestrictionItemsBindingSource;
        private System.Windows.Forms.BindingSource tBLPeriodsoffiscalyearBindingSource;
        private _Periods_of_fiscalyear _Periods_of_fiscalyear;
        private _Periods_of_fiscalyearTableAdapters.TBL_Periods_of__fiscal_yearTableAdapter tBL_Periods_of__fiscal_yearTableAdapter;
        private System.Windows.Forms.BindingSource tblFiscalyearBindingSource;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem6;
        private DevExpress.XtraBars.BarStaticItem barStaticItem7;
        private DevExpress.XtraBars.BarStaticItem barStaticItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarStaticItem barStaticItem9;
        private DevExpress.XtraBars.BarStaticItem barStaticItem10;
        private System.Windows.Forms.BindingSource tblAccountingRestrictionsKindBindingSource;
        private DataSet1TableAdapters.Tbl_OrderKindTableAdapter tbl_OrderKindTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DataSet1TableAdapters.Tbl_AccountingRestrictionItemsTableAdapter tbl_AccountingRestrictionItemsTableAdapter;
        private DataSet1TableAdapters.Tbl_SystemUnitesTableAdapter tbl_SystemUnitesTableAdapter;
        private DataSet1TableAdapters.TotalAccRestrByUserTableAdapter totalAccRestrByUserTableAdapter;
        private DataSet1TableAdapters.Tbl_FiscalyearTableAdapter tbl_FiscalyearTableAdapter;
        private DataSet1TableAdapters.Tbl_BeneficiaryTableAdapter tbl_BeneficiaryTableAdapter;
        private DataSet1TableAdapters.Tbl_AccountingRestrictions_KindTableAdapter tbl_AccountingRestrictions_KindTableAdapter;
        private FinaSearchTableAdapters.SearchingTableAdapter searchingTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox comboBox9;
    }
}