namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class CheqAuditAccRestFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtbAccRefAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accRestAuditDS = new FinancialSysApp.AccRestAuditDS();
            this.dataTable1TableAdapter = new FinancialSysApp.AccRestAuditDSTableAdapters.DataTable1TableAdapter();
            this.رقمالمستندDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريحالمستندDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالمراجعهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.المراجعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.مدخلالبياناتDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUserUpdateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ملاحظاتالمراجعهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالتعديلDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbAccRefAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accRestAuditDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 24);
            this.label1.TabIndex = 275;
            this.label1.Text = "موقف المستندات بعد المراجعه";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.رقمالمستندDataGridViewTextBoxColumn,
            this.تاريحالمستندDataGridViewTextBoxColumn,
            this.تاريخالمراجعهDataGridViewTextBoxColumn,
            this.المراجعDataGridViewTextBoxColumn,
            this.مدخلالبياناتDataGridViewTextBoxColumn,
            this.isUserUpdateDataGridViewCheckBoxColumn,
            this.ملاحظاتالمراجعهDataGridViewTextBoxColumn,
            this.تاريخالتعديلDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dtbAccRefAuditBindingSource;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(1046, 464);
            this.dataGridView1.TabIndex = 276;
            // 
            // dtbAccRefAuditBindingSource
            // 
            this.dtbAccRefAuditBindingSource.DataMember = "Dtb_AccRefAudit";
            this.dtbAccRefAuditBindingSource.DataSource = this.accRestAuditDS;
            // 
            // accRestAuditDS
            // 
            this.accRestAuditDS.DataSetName = "AccRestAuditDS";
            this.accRestAuditDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // رقمالمستندDataGridViewTextBoxColumn
            // 
            this.رقمالمستندDataGridViewTextBoxColumn.DataPropertyName = "رقم المستند";
            this.رقمالمستندDataGridViewTextBoxColumn.HeaderText = "رقم المستند";
            this.رقمالمستندDataGridViewTextBoxColumn.Name = "رقمالمستندDataGridViewTextBoxColumn";
            this.رقمالمستندDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريحالمستندDataGridViewTextBoxColumn
            // 
            this.تاريحالمستندDataGridViewTextBoxColumn.DataPropertyName = "تاريح المستند";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.تاريحالمستندDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.تاريحالمستندDataGridViewTextBoxColumn.HeaderText = "تاريح المستند";
            this.تاريحالمستندDataGridViewTextBoxColumn.Name = "تاريحالمستندDataGridViewTextBoxColumn";
            this.تاريحالمستندDataGridViewTextBoxColumn.ReadOnly = true;
            this.تاريحالمستندDataGridViewTextBoxColumn.Width = 120;
            // 
            // تاريخالمراجعهDataGridViewTextBoxColumn
            // 
            this.تاريخالمراجعهDataGridViewTextBoxColumn.DataPropertyName = "تاريخ المراجعه";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.تاريخالمراجعهDataGridViewTextBoxColumn.HeaderText = "تاريخ المراجعه";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.Name = "تاريخالمراجعهDataGridViewTextBoxColumn";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.ReadOnly = true;
            this.تاريخالمراجعهDataGridViewTextBoxColumn.Width = 120;
            // 
            // المراجعDataGridViewTextBoxColumn
            // 
            this.المراجعDataGridViewTextBoxColumn.DataPropertyName = "المراجع";
            this.المراجعDataGridViewTextBoxColumn.HeaderText = "المراجع";
            this.المراجعDataGridViewTextBoxColumn.Name = "المراجعDataGridViewTextBoxColumn";
            this.المراجعDataGridViewTextBoxColumn.ReadOnly = true;
            this.المراجعDataGridViewTextBoxColumn.Width = 150;
            // 
            // مدخلالبياناتDataGridViewTextBoxColumn
            // 
            this.مدخلالبياناتDataGridViewTextBoxColumn.DataPropertyName = "مدخل البيانات";
            this.مدخلالبياناتDataGridViewTextBoxColumn.HeaderText = "مدخل البيانات";
            this.مدخلالبياناتDataGridViewTextBoxColumn.Name = "مدخلالبياناتDataGridViewTextBoxColumn";
            this.مدخلالبياناتDataGridViewTextBoxColumn.ReadOnly = true;
            this.مدخلالبياناتDataGridViewTextBoxColumn.Visible = false;
            this.مدخلالبياناتDataGridViewTextBoxColumn.Width = 150;
            // 
            // isUserUpdateDataGridViewCheckBoxColumn
            // 
            this.isUserUpdateDataGridViewCheckBoxColumn.DataPropertyName = "IsUserUpdate";
            this.isUserUpdateDataGridViewCheckBoxColumn.HeaderText = "IsUserUpdate";
            this.isUserUpdateDataGridViewCheckBoxColumn.Name = "isUserUpdateDataGridViewCheckBoxColumn";
            this.isUserUpdateDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isUserUpdateDataGridViewCheckBoxColumn.Visible = false;
            // 
            // ملاحظاتالمراجعهDataGridViewTextBoxColumn
            // 
            this.ملاحظاتالمراجعهDataGridViewTextBoxColumn.DataPropertyName = "ملاحظات المراجعه";
            this.ملاحظاتالمراجعهDataGridViewTextBoxColumn.HeaderText = "ملاحظات المراجعه";
            this.ملاحظاتالمراجعهDataGridViewTextBoxColumn.Name = "ملاحظاتالمراجعهDataGridViewTextBoxColumn";
            this.ملاحظاتالمراجعهDataGridViewTextBoxColumn.ReadOnly = true;
            this.ملاحظاتالمراجعهDataGridViewTextBoxColumn.Width = 300;
            // 
            // تاريخالتعديلDataGridViewTextBoxColumn
            // 
            this.تاريخالتعديلDataGridViewTextBoxColumn.DataPropertyName = "تاريخ التعديل";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd";
            this.تاريخالتعديلDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.تاريخالتعديلDataGridViewTextBoxColumn.HeaderText = "تاريخ التعديل";
            this.تاريخالتعديلDataGridViewTextBoxColumn.Name = "تاريخالتعديلDataGridViewTextBoxColumn";
            this.تاريخالتعديلDataGridViewTextBoxColumn.ReadOnly = true;
            this.تاريخالتعديلDataGridViewTextBoxColumn.Width = 120;
            // 
            // CheqAuditAccRestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 537);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "CheqAuditAccRestFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.CheqAuditAccRestFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbAccRefAuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accRestAuditDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dtbAccRefAuditBindingSource;
        private AccRestAuditDS accRestAuditDS;
        private AccRestAuditDSTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالمستندDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريحالمستندDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالمراجعهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn المراجعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn مدخلالبياناتDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUserUpdateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ملاحظاتالمراجعهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالتعديلDataGridViewTextBoxColumn;
    }
}