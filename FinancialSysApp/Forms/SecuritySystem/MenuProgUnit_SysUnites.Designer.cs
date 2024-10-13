namespace FinancialSysApp.Forms.SecuritySystem
{
    partial class MenuProgUnit_SysUnites
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
                //ecomponents.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuProgUnit_SysUnites));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblSystemUnitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet11 = new FinancialSysApp.FinancialSysDataSet11();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParent_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.financialSysDataSet102 = new FinancialSysApp.FinancialSysDataSet10();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tblMenuProgramUnitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet12 = new FinancialSysApp.FinancialSysDataSet12();
            this.financialSysDataSet101 = new FinancialSysApp.FinancialSysDataSet10();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.tbl_MenuProgramUnitesTableAdapter1 = new FinancialSysApp.FinancialSysDataSet10TableAdapters.Tbl_MenuProgramUnitesTableAdapter();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.financialSysDataSet9 = new FinancialSysApp.FinancialSysDataSet9();
            this.tbl_SystemUnitesTableAdapter = new FinancialSysApp.FinancialSysDataSet11TableAdapters.Tbl_SystemUnitesTableAdapter();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.tbl_MenuProgramUnitesTableAdapter = new FinancialSysApp.FinancialSysDataSet12TableAdapters.Tbl_MenuProgramUnitesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblSystemUnitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet11)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMenuProgramUnitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "صفحات وحدات المنظومه";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "وحدات المنظومة ";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblSystemUnitesBindingSource, "ID", true));
            this.comboBox1.DataSource = this.tblSystemUnitesBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(331, 25);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // tblSystemUnitesBindingSource
            // 
            this.tblSystemUnitesBindingSource.DataMember = "Tbl_SystemUnites";
            this.tblSystemUnitesBindingSource.DataSource = this.financialSysDataSet11;
            // 
            // financialSysDataSet11
            // 
            this.financialSysDataSet11.DataSetName = "FinancialSysDataSet11";
            this.financialSysDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(132, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 63);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeList1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(571, 442);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " ";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.BandPanel.Options.UseImage = true;
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.ChildListFieldName = "Parent_ID";
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colName,
            this.colParent_ID});
            this.treeList1.CustomizationFormBounds = new System.Drawing.Rectangle(386, 455, 252, 266);
            this.treeList1.DataMember = "Tbl_MenuProgramUnites";
            this.treeList1.DataSource = this.financialSysDataSet102;
            this.treeList1.HierarchyFieldName = "Name";
            this.treeList1.Location = new System.Drawing.Point(0, 24);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowBoundCheckBoxesInVirtualMode = true;
            this.treeList1.OptionsBehavior.AllowExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsCustomization.AllowChangeBandParent = true;
            this.treeList1.OptionsCustomization.AllowChangeColumnParent = true;
            this.treeList1.OptionsFilter.ExpandNodesOnFiltering = true;
            this.treeList1.OptionsPrint.PrintAllNodes = true;
            this.treeList1.OptionsPrint.PrintFilledTreeIndent = true;
            this.treeList1.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.treeList1.OptionsView.RootCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.Check;
            this.treeList1.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList1.ParentFieldName = "Parent_ID";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.treeList1.Size = new System.Drawing.Size(554, 386);
            this.treeList1.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseImage = true;
            this.colName.Caption = "وحدات البرنامج";
            this.colName.FieldName = "Name";
            this.colName.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colName.ImageOptions.Image")));
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colParent_ID
            // 
            this.colParent_ID.FieldName = "Parent_ID";
            this.colParent_ID.Name = "colParent_ID";
            // 
            // financialSysDataSet102
            // 
            this.financialSysDataSet102.DataSetName = "FinancialSysDataSet10";
            this.financialSysDataSet102.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // tblMenuProgramUnitesBindingSource
            // 
            this.tblMenuProgramUnitesBindingSource.DataMember = "Tbl_MenuProgramUnites";
            this.tblMenuProgramUnitesBindingSource.DataSource = this.financialSysDataSet12;
            // 
            // financialSysDataSet12
            // 
            this.financialSysDataSet12.DataSetName = "FinancialSysDataSet12";
            this.financialSysDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialSysDataSet101
            // 
            this.financialSysDataSet101.DataSetName = "FinancialSysDataSet10";
            this.financialSysDataSet101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "ID";
            this.gridColumn1.HeaderText = "ID";
            this.gridColumn1.Name = "ID";
            this.gridColumn1.ReadOnly = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.DataPropertyName = "Name";
            this.gridColumn2.HeaderText = "Name";
            this.gridColumn2.Name = "Name";
            // 
            // gridColumn3
            // 
            this.gridColumn3.DataPropertyName = "Parent_ID";
            this.gridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.gridColumn3.EnableGroupHeaderMarkup = true;
            this.gridColumn3.EnableHeaderMarkup = true;
            this.gridColumn3.HeaderText = "Parent_ID";
            this.gridColumn3.Name = "Parent_ID";
            this.gridColumn3.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.DefaultNewRowCellValue = "";
            this.gridColumn5.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.gridColumn5.EnableGroupHeaderMarkup = true;
            this.gridColumn5.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.Copy;
            this.gridColumn5.Name = "Parent_ID";
            this.gridColumn5.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.gridColumn5.Tag = "Parent_ID";
            // 
            // tbl_MenuProgramUnitesTableAdapter1
            // 
            this.tbl_MenuProgramUnitesTableAdapter1.ClearBeforeFill = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(237, 575);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 35);
            this.simpleButton1.TabIndex = 45;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // financialSysDataSet9
            // 
            this.financialSysDataSet9.DataSetName = "FinancialSysDataSet9";
            this.financialSysDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_SystemUnitesTableAdapter
            // 
            this.tbl_SystemUnitesTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_MenuProgramUnitesTableAdapter
            // 
            this.tbl_MenuProgramUnitesTableAdapter.ClearBeforeFill = true;
            // 
            // MenuProgUnit_SysUnites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 622);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MenuProgUnit_SysUnites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuProgUnit_SysUnites";
            this.Load += new System.EventHandler(this.MenuProgUnit_SysUnites_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblSystemUnitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet11)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMenuProgramUnitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FinancialSysDataSet10 financialSysDataSet101;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private FinancialSysDataSet10 financialSysDataSet102;
        private FinancialSysDataSet10TableAdapters.Tbl_MenuProgramUnitesTableAdapter tbl_MenuProgramUnitesTableAdapter1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private FinancialSysDataSet9 financialSysDataSet9;
        private FinancialSysDataSet11 financialSysDataSet11;
        private System.Windows.Forms.BindingSource tblSystemUnitesBindingSource;
        private FinancialSysDataSet11TableAdapters.Tbl_SystemUnitesTableAdapter tbl_SystemUnitesTableAdapter;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParent_ID;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private FinancialSysDataSet12 financialSysDataSet12;
        private System.Windows.Forms.BindingSource tblMenuProgramUnitesBindingSource;
        private FinancialSysDataSet12TableAdapters.Tbl_MenuProgramUnitesTableAdapter tbl_MenuProgramUnitesTableAdapter;
    }
}