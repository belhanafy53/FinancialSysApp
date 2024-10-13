namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class OrderItemsMostakhlasFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderItemsMostakhlasFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpOrderData = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtPurchaseMethode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrderSupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chckBxItemData = new System.Windows.Forms.CheckBox();
            this.txtSortRow = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtqnty = new System.Windows.Forms.TextBox();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label10 = new System.Windows.Forms.Label();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tblValueAddedTaxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_UnitesTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_UnitesTableAdapter();
            this.tblUnitesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtbOrderItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_ValueAddedTaxTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_ValueAddedTaxTableAdapter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtb_OrderItemsTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Dtb_OrderItemsTableAdapter();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.txtItemOrderId = new System.Windows.Forms.TextBox();
            this.grpOrderData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblValueAddedTaxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUnitesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrderItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpOrderData
            // 
            this.grpOrderData.BackColor = System.Drawing.Color.Gainsboro;
            this.grpOrderData.Controls.Add(this.dateTimePicker1);
            this.grpOrderData.Controls.Add(this.txtPurchaseMethode);
            this.grpOrderData.Controls.Add(this.label6);
            this.grpOrderData.Controls.Add(this.txtOrderSupName);
            this.grpOrderData.Controls.Add(this.label5);
            this.grpOrderData.Controls.Add(this.label4);
            this.grpOrderData.Controls.Add(this.label3);
            this.grpOrderData.Controls.Add(this.txtOrderId);
            this.grpOrderData.Controls.Add(this.txtOrderNo);
            this.grpOrderData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderData.ForeColor = System.Drawing.Color.Black;
            this.grpOrderData.Location = new System.Drawing.Point(69, 49);
            this.grpOrderData.Name = "grpOrderData";
            this.grpOrderData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpOrderData.Size = new System.Drawing.Size(833, 86);
            this.grpOrderData.TabIndex = 162;
            this.grpOrderData.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "{0:yyyy MM dd}";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(601, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 26);
            this.dateTimePicker1.TabIndex = 167;
            // 
            // txtPurchaseMethode
            // 
            this.txtPurchaseMethode.Location = new System.Drawing.Point(6, 42);
            this.txtPurchaseMethode.Multiline = true;
            this.txtPurchaseMethode.Name = "txtPurchaseMethode";
            this.txtPurchaseMethode.Size = new System.Drawing.Size(191, 26);
            this.txtPurchaseMethode.TabIndex = 168;
            this.txtPurchaseMethode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(127, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 167;
            this.label6.Text = "طريقة الشراء";
            // 
            // txtOrderSupName
            // 
            this.txtOrderSupName.Location = new System.Drawing.Point(203, 42);
            this.txtOrderSupName.Name = "txtOrderSupName";
            this.txtOrderSupName.Size = new System.Drawing.Size(392, 26);
            this.txtOrderSupName.TabIndex = 166;
            this.txtOrderSupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(549, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 165;
            this.label5.Text = "المورد";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(642, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 163;
            this.label4.Text = "تاريخ الامر";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(766, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 162;
            this.label3.Text = "رقم الامر";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(345, 15);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(83, 26);
            this.txtOrderId.TabIndex = 161;
            this.txtOrderId.Visible = false;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(718, 42);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(99, 26);
            this.txtOrderNo.TabIndex = 162;
            this.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 161;
            this.label1.Text = "بنود الامر";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(947, 565);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(110, 17);
            this.label26.TabIndex = 187;
            this.label26.Text = "تفاصيل مراجعة الأمر";
            // 
            // textBox3
            // 
            this.textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(671, 585);
            this.textBox3.Name = "textBox3";
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox3.Size = new System.Drawing.Size(386, 25);
            this.textBox3.TabIndex = 186;
            // 
            // chckBxItemData
            // 
            this.chckBxItemData.AutoSize = true;
            this.chckBxItemData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBxItemData.ForeColor = System.Drawing.Color.Red;
            this.chckBxItemData.Location = new System.Drawing.Point(494, 585);
            this.chckBxItemData.Name = "chckBxItemData";
            this.chckBxItemData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chckBxItemData.Size = new System.Drawing.Size(146, 23);
            this.chckBxItemData.TabIndex = 185;
            this.chckBxItemData.Text = "تمت مراجعة بنود الامر";
            this.chckBxItemData.UseVisualStyleBackColor = true;
            // 
            // txtSortRow
            // 
            this.txtSortRow.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSortRow.Location = new System.Drawing.Point(633, 182);
            this.txtSortRow.Name = "txtSortRow";
            this.txtSortRow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSortRow.Size = new System.Drawing.Size(35, 26);
            this.txtSortRow.TabIndex = 184;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(649, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 19);
            this.label8.TabIndex = 183;
            this.label8.Text = "م";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(127, 160);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 19);
            this.label19.TabIndex = 181;
            this.label19.Text = "الكمية";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(597, 160);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 19);
            this.label18.TabIndex = 180;
            this.label18.Text = "البند";
            // 
            // txtqnty
            // 
            this.txtqnty.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqnty.Location = new System.Drawing.Point(72, 182);
            this.txtqnty.Name = "txtqnty";
            this.txtqnty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtqnty.Size = new System.Drawing.Size(99, 25);
            this.txtqnty.TabIndex = 179;
            this.txtqnty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtqnty_KeyDown);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(703, 182);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(53, 22);
            this.simpleButton4.TabIndex = 178;
            this.simpleButton4.Text = "بحث";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(671, 217);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.Size = new System.Drawing.Size(386, 335);
            this.treeView1.TabIndex = 177;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1019, 162);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(35, 19);
            this.label10.TabIndex = 175;
            this.label10.Text = "بحث ";
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(762, 182);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Nametxt.Size = new System.Drawing.Size(292, 26);
            this.Nametxt.TabIndex = 176;
            this.Nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nametxt_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(18, 226);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.Size = new System.Drawing.Size(650, 326);
            this.dataGridView1.TabIndex = 174;
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(177, 182);
            this.txtItem.Multiline = true;
            this.txtItem.Name = "txtItem";
            this.txtItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItem.Size = new System.Drawing.Size(453, 26);
            this.txtItem.TabIndex = 182;
            this.txtItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblValueAddedTaxBindingSource
            // 
            this.tblValueAddedTaxBindingSource.DataMember = "Tbl_ValueAddedTax";
            this.tblValueAddedTaxBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_UnitesTableAdapter
            // 
            this.tbl_UnitesTableAdapter.ClearBeforeFill = true;
            // 
            // tblUnitesBindingSource
            // 
            this.tblUnitesBindingSource.DataMember = "Tbl_Unites";
            this.tblUnitesBindingSource.DataSource = this.financialSysDataSet;
            // 
            // dtbOrderItemsBindingSource
            // 
            this.dtbOrderItemsBindingSource.DataMember = "Dtb_OrderItems";
            this.dtbOrderItemsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_ValueAddedTaxTableAdapter
            // 
            this.tbl_ValueAddedTaxTableAdapter.ClearBeforeFill = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-folder-30.png");
            this.imageList1.Images.SetKeyName(1, "open-file.png");
            this.imageList1.Images.SetKeyName(2, "icons8-opened-folder-30.png");
            this.imageList1.Images.SetKeyName(3, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(4, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(5, "icons8-opened-folder-48.png");
            this.imageList1.Images.SetKeyName(6, "icons8-opened-folder-100.png");
            this.imageList1.Images.SetKeyName(7, "icons8-folder-48.png");
            this.imageList1.Images.SetKeyName(8, "folder.png");
            this.imageList1.Images.SetKeyName(9, "open-folder.png");
            this.imageList1.Images.SetKeyName(10, "folders.png");
            this.imageList1.Images.SetKeyName(11, "folder (1).png");
            this.imageList1.Images.SetKeyName(12, "open-folder (1).png");
            this.imageList1.Images.SetKeyName(13, "folder (2).png");
            // 
            // dtb_OrderItemsTableAdapter
            // 
            this.dtb_OrderItemsTableAdapter.ClearBeforeFill = true;
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(933, 49);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(87, 20);
            this.txtItemID.TabIndex = 188;
            this.txtItemID.Visible = false;
            // 
            // txtItemOrderId
            // 
            this.txtItemOrderId.Location = new System.Drawing.Point(493, 315);
            this.txtItemOrderId.Name = "txtItemOrderId";
            this.txtItemOrderId.Size = new System.Drawing.Size(87, 20);
            this.txtItemOrderId.TabIndex = 189;
            this.txtItemOrderId.Visible = false;
            // 
            // OrderItemsMostakhlasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 651);
            this.Controls.Add(this.txtItemOrderId);
            this.Controls.Add(this.txtItemID);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.chckBxItemData);
            this.Controls.Add(this.txtSortRow);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtqnty);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Nametxt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.grpOrderData);
            this.Controls.Add(this.label1);
            this.Name = "OrderItemsMostakhlasFrm";
            this.Text = "OrderItemsMostakhlasFrm";
            this.Load += new System.EventHandler(this.OrderItemsMostakhlasFrm_Load);
            this.grpOrderData.ResumeLayout(false);
            this.grpOrderData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblValueAddedTaxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblUnitesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrderItemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox grpOrderData;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.TextBox txtPurchaseMethode;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtOrderSupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtOrderId;
        public System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox chckBxItemData;
        private System.Windows.Forms.TextBox txtSortRow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtqnty;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Nametxt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtItem;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblValueAddedTaxBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_UnitesTableAdapter tbl_UnitesTableAdapter;
        private System.Windows.Forms.BindingSource tblUnitesBindingSource;
        private System.Windows.Forms.BindingSource dtbOrderItemsBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_ValueAddedTaxTableAdapter tbl_ValueAddedTaxTableAdapter;
        private System.Windows.Forms.ImageList imageList1;
        private FinancialSysDataSetTableAdapters.Dtb_OrderItemsTableAdapter dtb_OrderItemsTableAdapter;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.TextBox txtItemOrderId;
    }
}