namespace FinancialSysApp.Forms.BasicCodeForms
{
    partial class OrderPurposeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPurposeFrm));
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.grbNodeSelected = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label7 = new System.Windows.Forms.Label();
            this.CmbOrderKind = new System.Windows.Forms.ComboBox();
            this.tblOrderKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.tbl_OrderKindTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_OrderKindTableAdapter();
            this.grpBOrderKind = new System.Windows.Forms.GroupBox();
            this.grbNodeSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderKindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(257, 409);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(105, 43);
            this.simpleButton4.TabIndex = 105;
            this.simpleButton4.Text = "تعديل";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(411, 90);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(99, 25);
            this.simpleButton3.TabIndex = 104;
            this.simpleButton3.Text = "بحث ";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            this.simpleButton3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleButton3_KeyDown);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(15, 409);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(105, 43);
            this.simpleButton2.TabIndex = 102;
            this.simpleButton2.Text = "حدف";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(93, 329);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(186, 43);
            this.simpleButton1.TabIndex = 101;
            this.simpleButton1.Text = "اضافه";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(515, 90);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Nametxt.Size = new System.Drawing.Size(317, 25);
            this.Nametxt.TabIndex = 98;
            this.Nametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Nametxt.TextChanged += new System.EventHandler(this.Nametxt_TextChanged);
            this.Nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nametxt_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(297, 41);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "*";
            // 
            // txtSelected
            // 
            this.txtSelected.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelected.Location = new System.Drawing.Point(30, 39);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSelected.Size = new System.Drawing.Size(261, 26);
            this.txtSelected.TabIndex = 1;
            this.txtSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSelected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSelected_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 46);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "الغرض";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(783, 68);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(0, 19);
            this.label10.TabIndex = 97;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-folder-30.png");
            this.imageList1.Images.SetKeyName(1, "icons8-opened-folder-30.png");
            this.imageList1.Images.SetKeyName(2, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(3, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(4, "icons8-opened-folder-48.png");
            this.imageList1.Images.SetKeyName(5, "icons8-opened-folder-100.png");
            this.imageList1.Images.SetKeyName(6, "icons8-folder-48.png");
            this.imageList1.Images.SetKeyName(7, "open-file.png");
            this.imageList1.Images.SetKeyName(8, "folder.png");
            this.imageList1.Images.SetKeyName(9, "open-folder.png");
            this.imageList1.Images.SetKeyName(10, "folders.png");
            this.imageList1.Images.SetKeyName(11, "folder (1).png");
            this.imageList1.Images.SetKeyName(12, "open-folder (1).png");
            this.imageList1.Images.SetKeyName(13, "folder (2).png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(382, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 103;
            this.label4.Text = "اغراض الأوامر";
            // 
            // grbNodeSelected
            // 
            this.grbNodeSelected.BackColor = System.Drawing.Color.White;
            this.grbNodeSelected.Controls.Add(this.label2);
            this.grbNodeSelected.Controls.Add(this.txtSelected);
            this.grbNodeSelected.Controls.Add(this.label3);
            this.grbNodeSelected.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNodeSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grbNodeSelected.Location = new System.Drawing.Point(5, 137);
            this.grbNodeSelected.Name = "grbNodeSelected";
            this.grbNodeSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbNodeSelected.Size = new System.Drawing.Size(399, 169);
            this.grbNodeSelected.TabIndex = 100;
            this.grbNodeSelected.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(410, 122);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.SelectedImageIndex = 9;
            this.treeView1.Size = new System.Drawing.Size(422, 416);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 99;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(739, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 108;
            this.label7.Text = "*";
            // 
            // CmbOrderKind
            // 
            this.CmbOrderKind.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblOrderKindBindingSource, "ID", true));
            this.CmbOrderKind.DataSource = this.tblOrderKindBindingSource;
            this.CmbOrderKind.DisplayMember = "Name";
            this.CmbOrderKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbOrderKind.FormattingEnabled = true;
            this.CmbOrderKind.Location = new System.Drawing.Point(515, 56);
            this.CmbOrderKind.Name = "CmbOrderKind";
            this.CmbOrderKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CmbOrderKind.Size = new System.Drawing.Size(317, 25);
            this.CmbOrderKind.TabIndex = 107;
            this.CmbOrderKind.ValueMember = "ID";
            this.CmbOrderKind.SelectionChangeCommitted += new System.EventHandler(this.CmbOrderKind_SelectionChangeCommitted);
            this.CmbOrderKind.SelectedValueChanged += new System.EventHandler(this.CmbOrderKind_SelectedValueChanged);
            this.CmbOrderKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbOrderKind_KeyDown);
            // 
            // tblOrderKindBindingSource
            // 
            this.tblOrderKindBindingSource.DataMember = "Tbl_OrderKind";
            this.tblOrderKindBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(771, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 106;
            this.label1.Text = "نوع  الامر";
            // 
            // tbl_OrderKindTableAdapter
            // 
            this.tbl_OrderKindTableAdapter.ClearBeforeFill = true;
            // 
            // grpBOrderKind
            // 
            this.grpBOrderKind.BackColor = System.Drawing.Color.White;
            this.grpBOrderKind.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBOrderKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpBOrderKind.Location = new System.Drawing.Point(5, 90);
            this.grpBOrderKind.Name = "grpBOrderKind";
            this.grpBOrderKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpBOrderKind.Size = new System.Drawing.Size(399, 222);
            this.grpBOrderKind.TabIndex = 109;
            this.grpBOrderKind.TabStop = false;
            this.grpBOrderKind.Text = "نوع الامر";
            // 
            // OrderPurposeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 550);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbOrderKind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.Nametxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grbNodeSelected);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.grpBOrderKind);
            this.Name = "OrderPurposeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OrderPurposeFrm_Load);
            this.grbNodeSelected.ResumeLayout(false);
            this.grbNodeSelected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderKindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox Nametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbNodeSelected;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbOrderKind;
        private System.Windows.Forms.Label label1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblOrderKindBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_OrderKindTableAdapter tbl_OrderKindTableAdapter;
        private System.Windows.Forms.GroupBox grpBOrderKind;
    }
}