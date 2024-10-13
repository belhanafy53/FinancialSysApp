namespace FinancialSysApp.Forms.ProcessingForms
{
    partial class FindBeneficiaryFrm
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
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beneficiaryKindIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDEmpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDCustDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDSuppDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDMngDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDBankDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kIndNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtbBeneficiaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.dtb_BeneficiaryTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Dtb_BeneficiaryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBeneficiaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 28;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.beneficiaryKindIDDataGridViewTextBoxColumn,
            this.iDEmpDataGridViewTextBoxColumn,
            this.iDCustDataGridViewTextBoxColumn,
            this.iDSuppDataGridViewTextBoxColumn,
            this.iDMngDataGridViewTextBoxColumn,
            this.iDBankDataGridViewTextBoxColumn,
            this.parentIDDataGridViewTextBoxColumn,
            this.relativeIDDataGridViewTextBoxColumn,
            this.kIndNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dtbBeneficiaryBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView1.Location = new System.Drawing.Point(10, 52);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(535, 350);
            this.dataGridView1.TabIndex = 303;
            this.dataGridView1.UseCustomBackgroundColor = true;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
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
            this.nameDataGridViewTextBoxColumn.HeaderText = "اسم المستفيد";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 300;
            // 
            // beneficiaryKindIDDataGridViewTextBoxColumn
            // 
            this.beneficiaryKindIDDataGridViewTextBoxColumn.DataPropertyName = "BeneficiaryKind_ID";
            this.beneficiaryKindIDDataGridViewTextBoxColumn.HeaderText = "BeneficiaryKind_ID";
            this.beneficiaryKindIDDataGridViewTextBoxColumn.Name = "beneficiaryKindIDDataGridViewTextBoxColumn";
            this.beneficiaryKindIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDEmpDataGridViewTextBoxColumn
            // 
            this.iDEmpDataGridViewTextBoxColumn.DataPropertyName = "ID_Emp";
            this.iDEmpDataGridViewTextBoxColumn.HeaderText = "ID_Emp";
            this.iDEmpDataGridViewTextBoxColumn.Name = "iDEmpDataGridViewTextBoxColumn";
            this.iDEmpDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDCustDataGridViewTextBoxColumn
            // 
            this.iDCustDataGridViewTextBoxColumn.DataPropertyName = "ID_Cust";
            this.iDCustDataGridViewTextBoxColumn.HeaderText = "ID_Cust";
            this.iDCustDataGridViewTextBoxColumn.Name = "iDCustDataGridViewTextBoxColumn";
            this.iDCustDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDSuppDataGridViewTextBoxColumn
            // 
            this.iDSuppDataGridViewTextBoxColumn.DataPropertyName = "ID_Supp";
            this.iDSuppDataGridViewTextBoxColumn.HeaderText = "ID_Supp";
            this.iDSuppDataGridViewTextBoxColumn.Name = "iDSuppDataGridViewTextBoxColumn";
            this.iDSuppDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDMngDataGridViewTextBoxColumn
            // 
            this.iDMngDataGridViewTextBoxColumn.DataPropertyName = "ID_Mng";
            this.iDMngDataGridViewTextBoxColumn.HeaderText = "ID_Mng";
            this.iDMngDataGridViewTextBoxColumn.Name = "iDMngDataGridViewTextBoxColumn";
            this.iDMngDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDBankDataGridViewTextBoxColumn
            // 
            this.iDBankDataGridViewTextBoxColumn.DataPropertyName = "ID_Bank";
            this.iDBankDataGridViewTextBoxColumn.HeaderText = "ID_Bank";
            this.iDBankDataGridViewTextBoxColumn.Name = "iDBankDataGridViewTextBoxColumn";
            this.iDBankDataGridViewTextBoxColumn.Visible = false;
            // 
            // parentIDDataGridViewTextBoxColumn
            // 
            this.parentIDDataGridViewTextBoxColumn.DataPropertyName = "Parent_ID";
            this.parentIDDataGridViewTextBoxColumn.HeaderText = "Parent_ID";
            this.parentIDDataGridViewTextBoxColumn.Name = "parentIDDataGridViewTextBoxColumn";
            this.parentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // relativeIDDataGridViewTextBoxColumn
            // 
            this.relativeIDDataGridViewTextBoxColumn.DataPropertyName = "Relative_ID";
            this.relativeIDDataGridViewTextBoxColumn.HeaderText = "Relative_ID";
            this.relativeIDDataGridViewTextBoxColumn.Name = "relativeIDDataGridViewTextBoxColumn";
            this.relativeIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // kIndNameDataGridViewTextBoxColumn
            // 
            this.kIndNameDataGridViewTextBoxColumn.DataPropertyName = "KIndName";
            this.kIndNameDataGridViewTextBoxColumn.HeaderText = "نوع المستفيد";
            this.kIndNameDataGridViewTextBoxColumn.Name = "kIndNameDataGridViewTextBoxColumn";
            this.kIndNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // dtbBeneficiaryBindingSource
            // 
            this.dtbBeneficiaryBindingSource.DataMember = "Dtb_Beneficiary";
            this.dtbBeneficiaryBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.EditValue = "";
            this.textBox1.Location = new System.Drawing.Point(10, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textBox1.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Properties.Appearance.Options.UseBackColor = true;
            this.textBox1.Properties.Appearance.Options.UseBorderColor = true;
            this.textBox1.Properties.Appearance.Options.UseFont = true;
            this.textBox1.Properties.Appearance.Options.UseTextOptions = true;
            this.textBox1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textBox1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.textBox1.Size = new System.Drawing.Size(428, 26);
            this.textBox1.TabIndex = 301;
            this.textBox1.TabStop = false;
            this.textBox1.EditValueChanged += new System.EventHandler(this.textBox1_EditValueChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(444, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 14);
            this.label13.TabIndex = 302;
            this.label13.Text = "اسم المستفيد";
            // 
            // dtb_BeneficiaryTableAdapter
            // 
            this.dtb_BeneficiaryTableAdapter.ClearBeforeFill = true;
            // 
            // FindBeneficiaryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 422);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FindBeneficiaryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FindBeneficiaryFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBeneficiaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        public DevExpress.XtraEditors.TextEdit textBox1;
        internal System.Windows.Forms.Label label13;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource dtbBeneficiaryBindingSource;
        private FinancialSysDataSetTableAdapters.Dtb_BeneficiaryTableAdapter dtb_BeneficiaryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beneficiaryKindIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDEmpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCustDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSuppDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDMngDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDBankDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kIndNameDataGridViewTextBoxColumn;
    }
}