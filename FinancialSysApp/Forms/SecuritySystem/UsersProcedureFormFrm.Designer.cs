namespace FinancialSysApp.Forms.SecuritySystem
{
    partial class UsersProcedureFormFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersProcedureFormFrm));
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.UsrTxtBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuUsersDataSet13BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuUsersDataSet13 = new FinancialSysApp.MenuUsersDataSet13();
            this.financialSysDataSet102 = new FinancialSysApp.FinancialSysDataSet10();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParent_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tblMenuProgramUnitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tbl_SystemUnitesTableAdapter = new FinancialSysApp.FinancialSysDataSet11TableAdapters.Tbl_SystemUnitesTableAdapter();
            this.tbl_MenuProgramUnitesTableAdapter = new FinancialSysApp.FinancialSysDataSet12TableAdapters.Tbl_MenuProgramUnitesTableAdapter();
            this.tbl_MenuProgramUnitesTableAdapter1 = new FinancialSysApp.FinancialSysDataSet10TableAdapters.Tbl_MenuProgramUnitesTableAdapter();
            this.financialSysDataSet9 = new FinancialSysApp.FinancialSysDataSet9();
            this.financialSysDataSet101 = new FinancialSysApp.FinancialSysDataSet10();
            this.financialSysDataSet12 = new FinancialSysApp.FinancialSysDataSet12();
            this.financialSysDataSet103 = new FinancialSysApp.FinancialSysDataSet10();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.tblSystemUnitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet11 = new FinancialSysApp.FinancialSysDataSet11();
            this.tbl_MenuProgramUnitesTableAdapter2 = new FinancialSysApp.MenuUsersDataSet13TableAdapters.Tbl_MenuProgramUnitesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuUsersDataSet13BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuUsersDataSet13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet102)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMenuProgramUnitesBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSystemUnitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(452, 123);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView2.Size = new System.Drawing.Size(411, 182);
            this.dataGridView2.TabIndex = 21;
            this.dataGridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView2_KeyDown);
            this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseClick);
            // 
            // UsrTxtBox
            // 
            this.UsrTxtBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrTxtBox.Location = new System.Drawing.Point(482, 94);
            this.UsrTxtBox.Name = "UsrTxtBox";
            this.UsrTxtBox.Size = new System.Drawing.Size(297, 26);
            this.UsrTxtBox.TabIndex = 20;
            this.UsrTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UsrTxtBox.TextChanged += new System.EventHandler(this.NameEmptxt_TextChanged);
            this.UsrTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsrTxtBox_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(785, 98);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(15, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(815, 98);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "المستخدم";
            // 
            // menuUsersDataSet13BindingSource
            // 
            this.menuUsersDataSet13BindingSource.DataSource = this.menuUsersDataSet13;
            this.menuUsersDataSet13BindingSource.Position = 0;
            // 
            // menuUsersDataSet13
            // 
            this.menuUsersDataSet13.DataSetName = "MenuUsersDataSet13";
            this.menuUsersDataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialSysDataSet102
            // 
            this.financialSysDataSet102.DataSetName = "FinancialSysDataSet10";
            this.financialSysDataSet102.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(371, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 22);
            this.label1.TabIndex = 47;
            this.label1.Text = "صلاحيات المستخدمين";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeList1);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 480);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // treeList1
            // 
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colName,
            this.colParent_ID});
            this.treeList1.DataSource = this.tblMenuProgramUnitesBindingSource;
            this.treeList1.Location = new System.Drawing.Point(6, 19);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList1.ParentFieldName = "Parent_ID";
            this.treeList1.PreviewFieldName = "Name";
            this.treeList1.Size = new System.Drawing.Size(400, 443);
            this.treeList1.TabIndex = 0;
            this.treeList1.TreeViewFieldName = "Name";
            this.treeList1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeList1_KeyDown_1);
            this.treeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDoubleClick);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colParent_ID
            // 
            this.colParent_ID.FieldName = "Parent_ID";
            this.colParent_ID.Name = "colParent_ID";
            this.colParent_ID.Visible = true;
            this.colParent_ID.VisibleIndex = 1;
            // 
            // tblMenuProgramUnitesBindingSource
            // 
            this.tblMenuProgramUnitesBindingSource.DataMember = "Tbl_MenuProgramUnites";
            this.tblMenuProgramUnitesBindingSource.DataSource = this.menuUsersDataSet13BindingSource;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(443, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 235);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(443, 318);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(440, 238);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView1.Location = new System.Drawing.Point(22, 37);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 80;
            this.dataGridView1.Size = new System.Drawing.Size(398, 183);
            this.dataGridView1.TabIndex = 51;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Column1";
            this.Column1.FalseValue = "false";
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.TrueValue = "true";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Enabled = false;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(392, 578);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 35);
            this.simpleButton1.TabIndex = 51;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tbl_SystemUnitesTableAdapter
            // 
            this.tbl_SystemUnitesTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_MenuProgramUnitesTableAdapter
            // 
            this.tbl_MenuProgramUnitesTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_MenuProgramUnitesTableAdapter1
            // 
            this.tbl_MenuProgramUnitesTableAdapter1.ClearBeforeFill = true;
            // 
            // financialSysDataSet9
            // 
            this.financialSysDataSet9.DataSetName = "FinancialSysDataSet9";
            this.financialSysDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialSysDataSet101
            // 
            this.financialSysDataSet101.DataSetName = "FinancialSysDataSet10";
            this.financialSysDataSet101.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialSysDataSet12
            // 
            this.financialSysDataSet12.DataSetName = "FinancialSysDataSet12";
            this.financialSysDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // financialSysDataSet103
            // 
            this.financialSysDataSet103.DataSetName = "FinancialSysDataSet10";
            this.financialSysDataSet103.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // tbl_MenuProgramUnitesTableAdapter2
            // 
            this.tbl_MenuProgramUnitesTableAdapter2.ClearBeforeFill = true;
            // 
            // UsersProcedureFormFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 625);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.UsrTxtBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "UsersProcedureFormFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.UsersProcedureFormFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuUsersDataSet13BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuUsersDataSet13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet102)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMenuProgramUnitesBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSystemUnitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox UsrTxtBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private FinancialSysDataSet10 financialSysDataSet102;
        private FinancialSysDataSet11TableAdapters.Tbl_SystemUnitesTableAdapter tbl_SystemUnitesTableAdapter;
        private FinancialSysDataSet12TableAdapters.Tbl_MenuProgramUnitesTableAdapter tbl_MenuProgramUnitesTableAdapter;
        private FinancialSysDataSet10TableAdapters.Tbl_MenuProgramUnitesTableAdapter tbl_MenuProgramUnitesTableAdapter1;
        private FinancialSysDataSet9 financialSysDataSet9;
        private FinancialSysDataSet10 financialSysDataSet101;
        private FinancialSysDataSet12 financialSysDataSet12;
        private FinancialSysDataSet10 financialSysDataSet103;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.BindingSource tblSystemUnitesBindingSource;
        private FinancialSysDataSet11 financialSysDataSet11;
        private System.Windows.Forms.BindingSource menuUsersDataSet13BindingSource;
        private MenuUsersDataSet13 menuUsersDataSet13;
        private System.Windows.Forms.BindingSource tblMenuProgramUnitesBindingSource;
        private MenuUsersDataSet13TableAdapters.Tbl_MenuProgramUnitesTableAdapter tbl_MenuProgramUnitesTableAdapter2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParent_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
    }
}