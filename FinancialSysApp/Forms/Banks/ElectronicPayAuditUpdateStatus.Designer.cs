namespace FinancialSysApp.Forms.Banks
{
    partial class ElectronicPayAuditUpdateStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElectronicPayAuditUpdateStatus));
            this.Ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.bankTransmentDS = new FinancialSysApp.BankTransmentDS();
            this.dTBElectronicPayAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTBElectronicPayAuditTableAdapter = new FinancialSysApp.BankTransmentDSTableAdapters.DTBElectronicPayAuditTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالحركهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالحقDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.وصفالحركهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.كودالحركهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالمراجعهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الملاحظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالتعديلDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.قيمةالحركهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.البنكDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUpdateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBElectronicPayAuditBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Ser
            // 
            this.Ser.HeaderText = "م";
            this.Ser.Name = "Ser";
            this.Ser.ReadOnly = true;
            this.Ser.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 24);
            this.label1.TabIndex = 278;
            this.label1.Text = "موقف الدفع النقدي بعد المراجعه";
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ser,
            this.iDDataGridViewTextBoxColumn,
            this.تاريخالحركهDataGridViewTextBoxColumn,
            this.تاريخالحقDataGridViewTextBoxColumn,
            this.وصفالحركهDataGridViewTextBoxColumn,
            this.كودالحركهDataGridViewTextBoxColumn,
            this.تاريخالمراجعهDataGridViewTextBoxColumn,
            this.الملاحظهDataGridViewTextBoxColumn,
            this.تاريخالتعديلDataGridViewTextBoxColumn,
            this.قيمةالحركهDataGridViewTextBoxColumn,
            this.البنكDataGridViewTextBoxColumn,
            this.isUpdateDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.dTBElectronicPayAuditBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(19, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1123, 542);
            this.dataGridView1.TabIndex = 279;
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(449, 623);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(227, 35);
            this.simpleButton7.TabIndex = 280;
            this.simpleButton7.Text = "حفظ";
            this.simpleButton7.Visible = false;
            // 
            // bankTransmentDS
            // 
            this.bankTransmentDS.DataSetName = "BankTransmentDS";
            this.bankTransmentDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dTBElectronicPayAuditBindingSource
            // 
            this.dTBElectronicPayAuditBindingSource.DataMember = "DTBElectronicPayAudit";
            this.dTBElectronicPayAuditBindingSource.DataSource = this.bankTransmentDS;
            // 
            // dTBElectronicPayAuditTableAdapter
            // 
            this.dTBElectronicPayAuditTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالحركهDataGridViewTextBoxColumn
            // 
            this.تاريخالحركهDataGridViewTextBoxColumn.DataPropertyName = "تاريخ_الحركه";
            this.تاريخالحركهDataGridViewTextBoxColumn.HeaderText = "تاريخ_الحركه";
            this.تاريخالحركهDataGridViewTextBoxColumn.Name = "تاريخالحركهDataGridViewTextBoxColumn";
            this.تاريخالحركهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالحقDataGridViewTextBoxColumn
            // 
            this.تاريخالحقDataGridViewTextBoxColumn.DataPropertyName = "تاريخ_الحق";
            this.تاريخالحقDataGridViewTextBoxColumn.HeaderText = "تاريخ_الحق";
            this.تاريخالحقDataGridViewTextBoxColumn.Name = "تاريخالحقDataGridViewTextBoxColumn";
            this.تاريخالحقDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // وصفالحركهDataGridViewTextBoxColumn
            // 
            this.وصفالحركهDataGridViewTextBoxColumn.DataPropertyName = "وصف_الحركه";
            this.وصفالحركهDataGridViewTextBoxColumn.HeaderText = "وصف_الحركه";
            this.وصفالحركهDataGridViewTextBoxColumn.Name = "وصفالحركهDataGridViewTextBoxColumn";
            this.وصفالحركهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // كودالحركهDataGridViewTextBoxColumn
            // 
            this.كودالحركهDataGridViewTextBoxColumn.DataPropertyName = "كود_الحركه";
            this.كودالحركهDataGridViewTextBoxColumn.HeaderText = "كود_الحركه";
            this.كودالحركهDataGridViewTextBoxColumn.Name = "كودالحركهDataGridViewTextBoxColumn";
            this.كودالحركهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالمراجعهDataGridViewTextBoxColumn
            // 
            this.تاريخالمراجعهDataGridViewTextBoxColumn.DataPropertyName = "تاريخ_المراجعه";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.HeaderText = "تاريخ_المراجعه";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.Name = "تاريخالمراجعهDataGridViewTextBoxColumn";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الملاحظهDataGridViewTextBoxColumn
            // 
            this.الملاحظهDataGridViewTextBoxColumn.DataPropertyName = "الملاحظه";
            this.الملاحظهDataGridViewTextBoxColumn.HeaderText = "الملاحظه";
            this.الملاحظهDataGridViewTextBoxColumn.Name = "الملاحظهDataGridViewTextBoxColumn";
            this.الملاحظهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالتعديلDataGridViewTextBoxColumn
            // 
            this.تاريخالتعديلDataGridViewTextBoxColumn.DataPropertyName = "تاريخ_التعديل";
            this.تاريخالتعديلDataGridViewTextBoxColumn.HeaderText = "تاريخ_التعديل";
            this.تاريخالتعديلDataGridViewTextBoxColumn.Name = "تاريخالتعديلDataGridViewTextBoxColumn";
            this.تاريخالتعديلDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // قيمةالحركهDataGridViewTextBoxColumn
            // 
            this.قيمةالحركهDataGridViewTextBoxColumn.DataPropertyName = "قيمة_الحركه";
            this.قيمةالحركهDataGridViewTextBoxColumn.HeaderText = "قيمة_الحركه";
            this.قيمةالحركهDataGridViewTextBoxColumn.Name = "قيمةالحركهDataGridViewTextBoxColumn";
            this.قيمةالحركهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // البنكDataGridViewTextBoxColumn
            // 
            this.البنكDataGridViewTextBoxColumn.DataPropertyName = "البنك";
            this.البنكDataGridViewTextBoxColumn.HeaderText = "البنك";
            this.البنكDataGridViewTextBoxColumn.Name = "البنكDataGridViewTextBoxColumn";
            this.البنكDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isUpdateDataGridViewCheckBoxColumn
            // 
            this.isUpdateDataGridViewCheckBoxColumn.DataPropertyName = "IsUpdate";
            this.isUpdateDataGridViewCheckBoxColumn.HeaderText = "IsUpdate";
            this.isUpdateDataGridViewCheckBoxColumn.Name = "isUpdateDataGridViewCheckBoxColumn";
            this.isUpdateDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // ElectronicPayAuditUpdateStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 623);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ElectronicPayAuditUpdateStatus";
            this.Text = "ElectronicPayAuditUpdateStatus";
            this.Load += new System.EventHandler(this.ElectronicPayAuditUpdateStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTBElectronicPayAuditBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BankTransmentDS bankTransmentDS;
        private System.Windows.Forms.BindingSource dTBElectronicPayAuditBindingSource;
        private BankTransmentDSTableAdapters.DTBElectronicPayAuditTableAdapter dTBElectronicPayAuditTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالحركهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالحقDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn وصفالحركهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn كودالحركهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالمراجعهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الملاحظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالتعديلDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn قيمةالحركهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn البنكDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUpdateDataGridViewCheckBoxColumn;
    }
}