namespace FinancialSysApp.Forms.BasicCodeForms
{
    partial class XtraForm1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uniteNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatTaxDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.priceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullItemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueAfterDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueBeforeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.installationPriceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortRowDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceIncludedNonDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.qntyManagementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderItemsIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managementIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtbOrderManagementItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatTaxDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valueAddedTaxIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueAfterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueBeforeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.installationPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortRowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblOrderItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_OrderItemsTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_OrderItemsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrderManagementItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.orderIDDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.unitIDDataGridViewTextBoxColumn,
            this.vatTaxDataGridViewCheckBoxColumn,
            this.valueAddedTaxIdDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.valueAfterDataGridViewTextBoxColumn,
            this.valueBeforeDataGridViewTextBoxColumn,
            this.installationPriceDataGridViewTextBoxColumn,
            this.sortRowDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblOrderItemsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(108, 31);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.orderIDDataGridViewTextBoxColumn1,
            this.itemIDDataGridViewTextBoxColumn1,
            this.itemNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn1,
            this.uniteNameDataGridViewTextBoxColumn,
            this.unitIDDataGridViewTextBoxColumn1,
            this.vatTaxDataGridViewCheckBoxColumn1,
            this.priceDataGridViewTextBoxColumn1,
            this.fullItemNameDataGridViewTextBoxColumn,
            this.valueAfterDataGridViewTextBoxColumn1,
            this.valueBeforeDataGridViewTextBoxColumn1,
            this.installationPriceDataGridViewTextBoxColumn1,
            this.sortRowDataGridViewTextBoxColumn1,
            this.priceIncludedNonDataGridViewCheckBoxColumn,
            this.qntyManagementDataGridViewTextBoxColumn,
            this.orderItemsIDDataGridViewTextBoxColumn,
            this.managementIDDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.dtbOrderManagementItemsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Location = new System.Drawing.Point(108, 235);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(436, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // orderIDDataGridViewTextBoxColumn1
            // 
            this.orderIDDataGridViewTextBoxColumn1.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn1.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn1.Name = "orderIDDataGridViewTextBoxColumn1";
            // 
            // itemIDDataGridViewTextBoxColumn1
            // 
            this.itemIDDataGridViewTextBoxColumn1.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn1.HeaderText = "ItemID";
            this.itemIDDataGridViewTextBoxColumn1.Name = "itemIDDataGridViewTextBoxColumn1";
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            // 
            // uniteNameDataGridViewTextBoxColumn
            // 
            this.uniteNameDataGridViewTextBoxColumn.DataPropertyName = "UniteName";
            this.uniteNameDataGridViewTextBoxColumn.HeaderText = "UniteName";
            this.uniteNameDataGridViewTextBoxColumn.Name = "uniteNameDataGridViewTextBoxColumn";
            // 
            // unitIDDataGridViewTextBoxColumn1
            // 
            this.unitIDDataGridViewTextBoxColumn1.DataPropertyName = "UnitID";
            this.unitIDDataGridViewTextBoxColumn1.HeaderText = "UnitID";
            this.unitIDDataGridViewTextBoxColumn1.Name = "unitIDDataGridViewTextBoxColumn1";
            // 
            // vatTaxDataGridViewCheckBoxColumn1
            // 
            this.vatTaxDataGridViewCheckBoxColumn1.DataPropertyName = "VatTax";
            this.vatTaxDataGridViewCheckBoxColumn1.HeaderText = "VatTax";
            this.vatTaxDataGridViewCheckBoxColumn1.Name = "vatTaxDataGridViewCheckBoxColumn1";
            // 
            // priceDataGridViewTextBoxColumn1
            // 
            this.priceDataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn1.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn1.Name = "priceDataGridViewTextBoxColumn1";
            // 
            // fullItemNameDataGridViewTextBoxColumn
            // 
            this.fullItemNameDataGridViewTextBoxColumn.DataPropertyName = "FullItemName";
            this.fullItemNameDataGridViewTextBoxColumn.HeaderText = "FullItemName";
            this.fullItemNameDataGridViewTextBoxColumn.Name = "fullItemNameDataGridViewTextBoxColumn";
            // 
            // valueAfterDataGridViewTextBoxColumn1
            // 
            this.valueAfterDataGridViewTextBoxColumn1.DataPropertyName = "ValueAfter";
            this.valueAfterDataGridViewTextBoxColumn1.HeaderText = "ValueAfter";
            this.valueAfterDataGridViewTextBoxColumn1.Name = "valueAfterDataGridViewTextBoxColumn1";
            // 
            // valueBeforeDataGridViewTextBoxColumn1
            // 
            this.valueBeforeDataGridViewTextBoxColumn1.DataPropertyName = "ValueBefore";
            this.valueBeforeDataGridViewTextBoxColumn1.HeaderText = "ValueBefore";
            this.valueBeforeDataGridViewTextBoxColumn1.Name = "valueBeforeDataGridViewTextBoxColumn1";
            // 
            // installationPriceDataGridViewTextBoxColumn1
            // 
            this.installationPriceDataGridViewTextBoxColumn1.DataPropertyName = "InstallationPrice";
            this.installationPriceDataGridViewTextBoxColumn1.HeaderText = "InstallationPrice";
            this.installationPriceDataGridViewTextBoxColumn1.Name = "installationPriceDataGridViewTextBoxColumn1";
            // 
            // sortRowDataGridViewTextBoxColumn1
            // 
            this.sortRowDataGridViewTextBoxColumn1.DataPropertyName = "Sort_Row";
            this.sortRowDataGridViewTextBoxColumn1.HeaderText = "Sort_Row";
            this.sortRowDataGridViewTextBoxColumn1.Name = "sortRowDataGridViewTextBoxColumn1";
            // 
            // priceIncludedNonDataGridViewCheckBoxColumn
            // 
            this.priceIncludedNonDataGridViewCheckBoxColumn.DataPropertyName = "PriceIncludedNon";
            this.priceIncludedNonDataGridViewCheckBoxColumn.HeaderText = "PriceIncludedNon";
            this.priceIncludedNonDataGridViewCheckBoxColumn.Name = "priceIncludedNonDataGridViewCheckBoxColumn";
            // 
            // qntyManagementDataGridViewTextBoxColumn
            // 
            this.qntyManagementDataGridViewTextBoxColumn.DataPropertyName = "QntyManagement";
            this.qntyManagementDataGridViewTextBoxColumn.HeaderText = "QntyManagement";
            this.qntyManagementDataGridViewTextBoxColumn.Name = "qntyManagementDataGridViewTextBoxColumn";
            // 
            // orderItemsIDDataGridViewTextBoxColumn
            // 
            this.orderItemsIDDataGridViewTextBoxColumn.DataPropertyName = "OrderItemsID";
            this.orderItemsIDDataGridViewTextBoxColumn.HeaderText = "OrderItemsID";
            this.orderItemsIDDataGridViewTextBoxColumn.Name = "orderItemsIDDataGridViewTextBoxColumn";
            // 
            // managementIDDataGridViewTextBoxColumn
            // 
            this.managementIDDataGridViewTextBoxColumn.DataPropertyName = "ManagementID";
            this.managementIDDataGridViewTextBoxColumn.HeaderText = "ManagementID";
            this.managementIDDataGridViewTextBoxColumn.Name = "managementIDDataGridViewTextBoxColumn";
            // 
            // dtbOrderManagementItemsBindingSource
            // 
            this.dtbOrderManagementItemsBindingSource.DataMember = "Dtb_OrderManagementItems";
            this.dtbOrderManagementItemsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // unitIDDataGridViewTextBoxColumn
            // 
            this.unitIDDataGridViewTextBoxColumn.DataPropertyName = "UnitID";
            this.unitIDDataGridViewTextBoxColumn.HeaderText = "UnitID";
            this.unitIDDataGridViewTextBoxColumn.Name = "unitIDDataGridViewTextBoxColumn";
            // 
            // vatTaxDataGridViewCheckBoxColumn
            // 
            this.vatTaxDataGridViewCheckBoxColumn.DataPropertyName = "VatTax";
            this.vatTaxDataGridViewCheckBoxColumn.HeaderText = "VatTax";
            this.vatTaxDataGridViewCheckBoxColumn.Name = "vatTaxDataGridViewCheckBoxColumn";
            // 
            // valueAddedTaxIdDataGridViewTextBoxColumn
            // 
            this.valueAddedTaxIdDataGridViewTextBoxColumn.DataPropertyName = "ValueAddedTaxId";
            this.valueAddedTaxIdDataGridViewTextBoxColumn.HeaderText = "ValueAddedTaxId";
            this.valueAddedTaxIdDataGridViewTextBoxColumn.Name = "valueAddedTaxIdDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // valueAfterDataGridViewTextBoxColumn
            // 
            this.valueAfterDataGridViewTextBoxColumn.DataPropertyName = "ValueAfter";
            this.valueAfterDataGridViewTextBoxColumn.HeaderText = "ValueAfter";
            this.valueAfterDataGridViewTextBoxColumn.Name = "valueAfterDataGridViewTextBoxColumn";
            // 
            // valueBeforeDataGridViewTextBoxColumn
            // 
            this.valueBeforeDataGridViewTextBoxColumn.DataPropertyName = "ValueBefore";
            this.valueBeforeDataGridViewTextBoxColumn.HeaderText = "ValueBefore";
            this.valueBeforeDataGridViewTextBoxColumn.Name = "valueBeforeDataGridViewTextBoxColumn";
            // 
            // installationPriceDataGridViewTextBoxColumn
            // 
            this.installationPriceDataGridViewTextBoxColumn.DataPropertyName = "InstallationPrice";
            this.installationPriceDataGridViewTextBoxColumn.HeaderText = "InstallationPrice";
            this.installationPriceDataGridViewTextBoxColumn.Name = "installationPriceDataGridViewTextBoxColumn";
            // 
            // sortRowDataGridViewTextBoxColumn
            // 
            this.sortRowDataGridViewTextBoxColumn.DataPropertyName = "Sort_Row";
            this.sortRowDataGridViewTextBoxColumn.HeaderText = "Sort_Row";
            this.sortRowDataGridViewTextBoxColumn.Name = "sortRowDataGridViewTextBoxColumn";
            // 
            // tblOrderItemsBindingSource
            // 
            this.tblOrderItemsBindingSource.DataMember = "Tbl_OrderItems";
            this.tblOrderItemsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_OrderItemsTableAdapter
            // 
            this.tbl_OrderItemsTableAdapter.ClearBeforeFill = true;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 457);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrderManagementItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblOrderItemsBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_OrderItemsTableAdapter tbl_OrderItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vatTaxDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueAddedTaxIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueAfterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueBeforeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn installationPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortRowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uniteNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vatTaxDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullItemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueAfterDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueBeforeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn installationPriceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortRowDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn priceIncludedNonDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qntyManagementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderItemsIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managementIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dtbOrderManagementItemsBindingSource;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}