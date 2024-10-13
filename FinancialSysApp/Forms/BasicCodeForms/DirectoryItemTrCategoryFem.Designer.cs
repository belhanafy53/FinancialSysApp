namespace FinancialSysApp.Forms.BasicCodeForms
{
    partial class DirectoryItemTrCategoryFem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryItemTrCategoryFem));
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.grbNodeSelected = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblTreasuryItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.depositCashDS = new FinancialSysApp.DepositCashDS();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.tbl_TreasuryItemsTableAdapter = new FinancialSysApp.DepositCashDSTableAdapters.Tbl_TreasuryItemsTableAdapter();
            this.txtRowId = new System.Windows.Forms.TextBox();
            this.dtbTreasurItemMnagementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtb_TreasurItemMnagementTableAdapter = new FinancialSysApp.DepositCashDSTableAdapters.Dtb_TreasurItemMnagementTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.بندالخزينهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الجههDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managementIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsTreasureIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbNodeSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTreasuryItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositCashDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbTreasurItemMnagementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 22);
            this.label1.TabIndex = 120;
            this.label1.Text = "بنود الخزينه للإدارات";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-management-100.png");
            this.imageList1.Images.SetKeyName(1, "open-file.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 116;
            this.label2.Text = "بنود الخزينه";
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(55, 95);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Nametxt.Size = new System.Drawing.Size(361, 25);
            this.Nametxt.TabIndex = 123;
            this.Nametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nametxt_KeyDown);
            // 
            // grbNodeSelected
            // 
            this.grbNodeSelected.Controls.Add(this.dataGridView1);
            this.grbNodeSelected.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNodeSelected.Location = new System.Drawing.Point(3, 206);
            this.grbNodeSelected.Name = "grbNodeSelected";
            this.grbNodeSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbNodeSelected.Size = new System.Drawing.Size(446, 363);
            this.grbNodeSelected.TabIndex = 125;
            this.grbNodeSelected.TabStop = false;
            this.grbNodeSelected.Text = "بنود الخزينه";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.بندالخزينهDataGridViewTextBoxColumn,
            this.الجههDataGridViewTextBoxColumn,
            this.managementIDDataGridViewTextBoxColumn,
            this.itemsTreasureIDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dtbTreasurItemMnagementBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(434, 333);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 118;
            this.label4.Text = "الجهه";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(265, 637);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(105, 43);
            this.simpleButton4.TabIndex = 126;
            this.simpleButton4.Text = "تعديل";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(94, 637);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(105, 43);
            this.simpleButton2.TabIndex = 122;
            this.simpleButton2.Text = "حدف";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(158, 575);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(152, 43);
            this.simpleButton1.TabIndex = 121;
            this.simpleButton1.Text = "اضافه";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblTreasuryItemsBindingSource, "ID", true));
            this.comboBox1.DataSource = this.tblTreasuryItemsBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 162);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(359, 27);
            this.comboBox1.TabIndex = 127;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // tblTreasuryItemsBindingSource
            // 
            this.tblTreasuryItemsBindingSource.DataMember = "Tbl_TreasuryItems";
            this.tblTreasuryItemsBindingSource.DataSource = this.depositCashDS;
            // 
            // depositCashDS
            // 
            this.depositCashDS.DataSetName = "DepositCashDS";
            this.depositCashDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtBranchID
            // 
            this.txtBranchID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchID.Location = new System.Drawing.Point(12, 64);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranchID.Size = new System.Drawing.Size(102, 25);
            this.txtBranchID.TabIndex = 128;
            this.txtBranchID.Visible = false;
            // 
            // tbl_TreasuryItemsTableAdapter
            // 
            this.tbl_TreasuryItemsTableAdapter.ClearBeforeFill = true;
            // 
            // txtRowId
            // 
            this.txtRowId.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowId.Location = new System.Drawing.Point(242, 64);
            this.txtRowId.Name = "txtRowId";
            this.txtRowId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRowId.Size = new System.Drawing.Size(102, 25);
            this.txtRowId.TabIndex = 129;
            this.txtRowId.Visible = false;
            // 
            // dtbTreasurItemMnagementBindingSource
            // 
            this.dtbTreasurItemMnagementBindingSource.DataMember = "Dtb_TreasurItemMnagement";
            this.dtbTreasurItemMnagementBindingSource.DataSource = this.depositCashDS;
            // 
            // dtb_TreasurItemMnagementTableAdapter
            // 
            this.dtb_TreasurItemMnagementTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // بندالخزينهDataGridViewTextBoxColumn
            // 
            this.بندالخزينهDataGridViewTextBoxColumn.DataPropertyName = "بند الخزينه";
            this.بندالخزينهDataGridViewTextBoxColumn.HeaderText = "بند الخزينه";
            this.بندالخزينهDataGridViewTextBoxColumn.Name = "بندالخزينهDataGridViewTextBoxColumn";
            this.بندالخزينهDataGridViewTextBoxColumn.ReadOnly = true;
            this.بندالخزينهDataGridViewTextBoxColumn.Width = 150;
            // 
            // الجههDataGridViewTextBoxColumn
            // 
            this.الجههDataGridViewTextBoxColumn.DataPropertyName = "الجهه";
            this.الجههDataGridViewTextBoxColumn.HeaderText = "الجهه";
            this.الجههDataGridViewTextBoxColumn.Name = "الجههDataGridViewTextBoxColumn";
            this.الجههDataGridViewTextBoxColumn.ReadOnly = true;
            this.الجههDataGridViewTextBoxColumn.Width = 180;
            // 
            // managementIDDataGridViewTextBoxColumn
            // 
            this.managementIDDataGridViewTextBoxColumn.DataPropertyName = "ManagementID";
            this.managementIDDataGridViewTextBoxColumn.HeaderText = "ManagementID";
            this.managementIDDataGridViewTextBoxColumn.Name = "managementIDDataGridViewTextBoxColumn";
            this.managementIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.managementIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsTreasureIDDataGridViewTextBoxColumn
            // 
            this.itemsTreasureIDDataGridViewTextBoxColumn.DataPropertyName = "ItemsTreasureID";
            this.itemsTreasureIDDataGridViewTextBoxColumn.HeaderText = "ItemsTreasureID";
            this.itemsTreasureIDDataGridViewTextBoxColumn.Name = "itemsTreasureIDDataGridViewTextBoxColumn";
            this.itemsTreasureIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsTreasureIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // DirectoryItemTrCategoryFem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 709);
            this.Controls.Add(this.txtRowId);
            this.Controls.Add(this.txtBranchID);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nametxt);
            this.Controls.Add(this.grbNodeSelected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "DirectoryItemTrCategoryFem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirectoryItemTrCategoryFem";
            this.Load += new System.EventHandler(this.DirectoryItemTrCategoryFem_Load);
            this.grbNodeSelected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTreasuryItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depositCashDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbTreasurItemMnagementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Nametxt;
        private System.Windows.Forms.GroupBox grbNodeSelected;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtBranchID;
        private DepositCashDS depositCashDS;
        private System.Windows.Forms.BindingSource tblTreasuryItemsBindingSource;
        private DepositCashDSTableAdapters.Tbl_TreasuryItemsTableAdapter tbl_TreasuryItemsTableAdapter;
        private System.Windows.Forms.TextBox txtRowId;
        private System.Windows.Forms.BindingSource dtbTreasurItemMnagementBindingSource;
        private DepositCashDSTableAdapters.Dtb_TreasurItemMnagementTableAdapter dtb_TreasurItemMnagementTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn بندالخزينهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الجههDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managementIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsTreasureIDDataGridViewTextBoxColumn;
    }
}