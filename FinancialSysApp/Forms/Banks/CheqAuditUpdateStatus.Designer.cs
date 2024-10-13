namespace FinancialSysApp.Forms.Banks
{
    partial class CheqAuditUpdateStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheqAuditUpdateStatus));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.dtbCheqWithErrorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtb_CheqWithErrorTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_CheqWithErrorTableAdapter();
            this.Ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمحافظةالتجاريDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالحافظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالخافظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالايداعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالشيكDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالشيكDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.مبلغالشيكDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالمراجعهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ملحوظةالمراجعهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.اسمالمراجعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.البنكالمسحوبعليهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUpdateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.updateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbCheqWithErrorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 24);
            this.label1.TabIndex = 274;
            this.label1.Text = "موقف الشيكات بعد المراجعه";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(442, 604);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(227, 35);
            this.simpleButton7.TabIndex = 277;
            this.simpleButton7.Text = "حفظ";
            this.simpleButton7.Visible = false;
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
            this.رقمحافظةالتجاريDataGridViewTextBoxColumn,
            this.رقمالحافظهDataGridViewTextBoxColumn,
            this.تاريخالخافظهDataGridViewTextBoxColumn,
            this.تاريخالايداعDataGridViewTextBoxColumn,
            this.رقمالشيكDataGridViewTextBoxColumn,
            this.تاريخالشيكDataGridViewTextBoxColumn,
            this.مبلغالشيكDataGridViewTextBoxColumn,
            this.تاريخالمراجعهDataGridViewTextBoxColumn,
            this.ملحوظةالمراجعهDataGridViewTextBoxColumn,
            this.اسمالمراجعDataGridViewTextBoxColumn,
            this.البنكالمسحوبعليهDataGridViewTextBoxColumn,
            this.isUpdateDataGridViewCheckBoxColumn,
            this.updateDateDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dtbCheqWithErrorBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Size = new System.Drawing.Size(1123, 542);
            this.dataGridView1.TabIndex = 275;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.EnforceConstraints = false;
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtbCheqWithErrorBindingSource
            // 
            this.dtbCheqWithErrorBindingSource.DataMember = "Dtb_CheqWithError";
            this.dtbCheqWithErrorBindingSource.DataSource = this.bankCheques;
            // 
            // dtb_CheqWithErrorTableAdapter
            // 
            this.dtb_CheqWithErrorTableAdapter.ClearBeforeFill = true;
            // 
            // Ser
            // 
            this.Ser.HeaderText = "م";
            this.Ser.Name = "Ser";
            this.Ser.ReadOnly = true;
            this.Ser.Width = 40;
            // 
            // رقمحافظةالتجاريDataGridViewTextBoxColumn
            // 
            this.رقمحافظةالتجاريDataGridViewTextBoxColumn.DataPropertyName = "رقم حافظة التجاري";
            this.رقمحافظةالتجاريDataGridViewTextBoxColumn.HeaderText = "رقم حافظة التجاري";
            this.رقمحافظةالتجاريDataGridViewTextBoxColumn.Name = "رقمحافظةالتجاريDataGridViewTextBoxColumn";
            this.رقمحافظةالتجاريDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // رقمالحافظهDataGridViewTextBoxColumn
            // 
            this.رقمالحافظهDataGridViewTextBoxColumn.DataPropertyName = "رقم الحافظه";
            this.رقمالحافظهDataGridViewTextBoxColumn.HeaderText = "رقم الحافظه";
            this.رقمالحافظهDataGridViewTextBoxColumn.Name = "رقمالحافظهDataGridViewTextBoxColumn";
            this.رقمالحافظهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالخافظهDataGridViewTextBoxColumn
            // 
            this.تاريخالخافظهDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الخافظه";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.تاريخالخافظهDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.تاريخالخافظهDataGridViewTextBoxColumn.HeaderText = "تاريخ الخافظه";
            this.تاريخالخافظهDataGridViewTextBoxColumn.Name = "تاريخالخافظهDataGridViewTextBoxColumn";
            this.تاريخالخافظهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالايداعDataGridViewTextBoxColumn
            // 
            this.تاريخالايداعDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الايداع";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            this.تاريخالايداعDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.تاريخالايداعDataGridViewTextBoxColumn.HeaderText = "تاريخ الايداع";
            this.تاريخالايداعDataGridViewTextBoxColumn.Name = "تاريخالايداعDataGridViewTextBoxColumn";
            this.تاريخالايداعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // رقمالشيكDataGridViewTextBoxColumn
            // 
            this.رقمالشيكDataGridViewTextBoxColumn.DataPropertyName = "رقم الشيك";
            this.رقمالشيكDataGridViewTextBoxColumn.HeaderText = "رقم الشيك";
            this.رقمالشيكDataGridViewTextBoxColumn.Name = "رقمالشيكDataGridViewTextBoxColumn";
            this.رقمالشيكDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالشيكDataGridViewTextBoxColumn
            // 
            this.تاريخالشيكDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الشيك";
            this.تاريخالشيكDataGridViewTextBoxColumn.HeaderText = "تاريخ الشيك";
            this.تاريخالشيكDataGridViewTextBoxColumn.Name = "تاريخالشيكDataGridViewTextBoxColumn";
            this.تاريخالشيكDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // مبلغالشيكDataGridViewTextBoxColumn
            // 
            this.مبلغالشيكDataGridViewTextBoxColumn.DataPropertyName = "مبلغ الشيك";
            this.مبلغالشيكDataGridViewTextBoxColumn.HeaderText = "مبلغ الشيك";
            this.مبلغالشيكDataGridViewTextBoxColumn.Name = "مبلغالشيكDataGridViewTextBoxColumn";
            this.مبلغالشيكDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالمراجعهDataGridViewTextBoxColumn
            // 
            this.تاريخالمراجعهDataGridViewTextBoxColumn.DataPropertyName = "تاريخ المراجعه";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.تاريخالمراجعهDataGridViewTextBoxColumn.HeaderText = "تاريخ المراجعه";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.Name = "تاريخالمراجعهDataGridViewTextBoxColumn";
            this.تاريخالمراجعهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ملحوظةالمراجعهDataGridViewTextBoxColumn
            // 
            this.ملحوظةالمراجعهDataGridViewTextBoxColumn.DataPropertyName = "ملحوظة المراجعه";
            this.ملحوظةالمراجعهDataGridViewTextBoxColumn.HeaderText = "ملحوظة المراجعه";
            this.ملحوظةالمراجعهDataGridViewTextBoxColumn.Name = "ملحوظةالمراجعهDataGridViewTextBoxColumn";
            this.ملحوظةالمراجعهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // اسمالمراجعDataGridViewTextBoxColumn
            // 
            this.اسمالمراجعDataGridViewTextBoxColumn.DataPropertyName = "اسم المراجع";
            this.اسمالمراجعDataGridViewTextBoxColumn.HeaderText = "اسم المراجع";
            this.اسمالمراجعDataGridViewTextBoxColumn.Name = "اسمالمراجعDataGridViewTextBoxColumn";
            this.اسمالمراجعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // البنكالمسحوبعليهDataGridViewTextBoxColumn
            // 
            this.البنكالمسحوبعليهDataGridViewTextBoxColumn.DataPropertyName = "البنك المسحوب عليه";
            this.البنكالمسحوبعليهDataGridViewTextBoxColumn.HeaderText = "البنك المسحوب عليه";
            this.البنكالمسحوبعليهDataGridViewTextBoxColumn.Name = "البنكالمسحوبعليهDataGridViewTextBoxColumn";
            this.البنكالمسحوبعليهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isUpdateDataGridViewCheckBoxColumn
            // 
            this.isUpdateDataGridViewCheckBoxColumn.DataPropertyName = "IsUpdate";
            this.isUpdateDataGridViewCheckBoxColumn.HeaderText = "IsUpdate";
            this.isUpdateDataGridViewCheckBoxColumn.Name = "isUpdateDataGridViewCheckBoxColumn";
            this.isUpdateDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // updateDateDataGridViewTextBoxColumn
            // 
            this.updateDateDataGridViewTextBoxColumn.DataPropertyName = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.HeaderText = "UpdateDate";
            this.updateDateDataGridViewTextBoxColumn.Name = "updateDateDataGridViewTextBoxColumn";
            this.updateDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CheqAuditUpdateStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 601);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "CheqAuditUpdateStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CheqAuditUpdateStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbCheqWithErrorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource dtbCheqWithErrorBindingSource;
        private BankChequesTableAdapters.Dtb_CheqWithErrorTableAdapter dtb_CheqWithErrorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمحافظةالتجاريDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالحافظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالخافظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالايداعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالشيكDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالشيكDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn مبلغالشيكDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالمراجعهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ملحوظةالمراجعهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn اسمالمراجعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn البنكالمسحوبعليهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUpdateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}