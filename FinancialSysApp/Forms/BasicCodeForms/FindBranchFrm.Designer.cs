namespace FinancialSysApp.Forms.BasicCodeForms
{
    partial class FindBranchFrm
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
            this.txtBranche = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brancheNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindBranchDirectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblManagement1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tbl_Management1TableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_Management1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblManagement1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBranche
            // 
            this.txtBranche.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranche.Location = new System.Drawing.Point(14, 49);
            this.txtBranche.Name = "txtBranche";
            this.txtBranche.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranche.Size = new System.Drawing.Size(473, 26);
            this.txtBranche.TabIndex = 74;
            this.txtBranche.TextChanged += new System.EventHandler(this.txtBranche_TextChanged);
            this.txtBranche.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranche_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(447, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 22);
            this.label4.TabIndex = 121;
            this.label4.Text = "الفرع";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.brancheNameDataGridViewTextBoxColumn,
            this.kindBranchDirectDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblManagement1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(473, 405);
            this.dataGridView1.TabIndex = 122;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
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
            // brancheNameDataGridViewTextBoxColumn
            // 
            this.brancheNameDataGridViewTextBoxColumn.DataPropertyName = "BrancheName";
            this.brancheNameDataGridViewTextBoxColumn.HeaderText = "الفرع";
            this.brancheNameDataGridViewTextBoxColumn.Name = "brancheNameDataGridViewTextBoxColumn";
            this.brancheNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.brancheNameDataGridViewTextBoxColumn.Width = 400;
            // 
            // kindBranchDirectDataGridViewTextBoxColumn
            // 
            this.kindBranchDirectDataGridViewTextBoxColumn.DataPropertyName = "KindBranchDirect";
            this.kindBranchDirectDataGridViewTextBoxColumn.HeaderText = "KindBranchDirect";
            this.kindBranchDirectDataGridViewTextBoxColumn.Name = "kindBranchDirectDataGridViewTextBoxColumn";
            this.kindBranchDirectDataGridViewTextBoxColumn.ReadOnly = true;
            this.kindBranchDirectDataGridViewTextBoxColumn.Visible = false;
            // 
            // tblManagement1BindingSource
            // 
            this.tblManagement1BindingSource.DataMember = "Tbl_Management1";
            this.tblManagement1BindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_Management1TableAdapter
            // 
            this.tbl_Management1TableAdapter.ClearBeforeFill = true;
            // 
            // FindBranchFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 512);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBranche);
            this.Name = "FindBranchFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindBranchFrm_FormClosed);
            this.Load += new System.EventHandler(this.FindBranchFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblManagement1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtBranche;
        public System.Windows.Forms.DataGridView dataGridView1;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblManagement1BindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_Management1TableAdapter tbl_Management1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brancheNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kindBranchDirectDataGridViewTextBoxColumn;
    }
}