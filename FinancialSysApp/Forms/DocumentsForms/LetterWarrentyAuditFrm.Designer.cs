namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class LetterWarrentyAuditFrm
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
            this.dtb_OrderAuditTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Dtb_OrderAuditTableAdapter();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.dtbOrderAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtbLetterWAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.letterWarranty = new FinancialSysApp.LetterWarranty();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.txtLetterKindID = new System.Windows.Forms.TextBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtLetterKind = new System.Windows.Forms.TextBox();
            this.txtLetterFullNo = new System.Windows.Forms.TextBox();
            this.LetterId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtbLetterWAuditTableAdapter = new FinancialSysApp.LetterWarrantyTableAdapters.DtbLetterWAuditTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letterWarrentyIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.letterWBasicDataDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.letterWExpandDateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.letterWRefundLetterDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.letterChangeValueLetterDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrderAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbLetterWAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterWarranty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtb_OrderAuditTableAdapter
            // 
            this.dtb_OrderAuditTableAdapter.ClearBeforeFill = true;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtbOrderAuditBindingSource
            // 
            this.dtbOrderAuditBindingSource.DataMember = "Dtb_OrderAudit";
            this.dtbOrderAuditBindingSource.DataSource = this.financialSysDataSet;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.letterWarrentyIDDataGridViewTextBoxColumn,
            this.empNameDataGridViewTextBoxColumn,
            this.referenceDateDataGridViewTextBoxColumn,
            this.letterWBasicDataDataGridViewCheckBoxColumn,
            this.letterWExpandDateDataGridViewCheckBoxColumn,
            this.letterWRefundLetterDataGridViewCheckBoxColumn,
            this.letterChangeValueLetterDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.dtbLetterWAuditBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Size = new System.Drawing.Size(977, 464);
            this.dataGridView1.TabIndex = 19;
            // 
            // dtbLetterWAuditBindingSource
            // 
            this.dtbLetterWAuditBindingSource.DataMember = "DtbLetterWAudit";
            this.dtbLetterWAuditBindingSource.DataSource = this.letterWarranty;
            // 
            // letterWarranty
            // 
            this.letterWarranty.DataSetName = "LetterWarranty";
            this.letterWarranty.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(12, 12);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "وارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "صادر")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(160, 25);
            this.radioGroup1.TabIndex = 254;
            this.radioGroup1.Visible = false;
            // 
            // txtLetterKindID
            // 
            this.txtLetterKindID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKindID.Location = new System.Drawing.Point(84, 43);
            this.txtLetterKindID.Name = "txtLetterKindID";
            this.txtLetterKindID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKindID.Size = new System.Drawing.Size(66, 22);
            this.txtLetterKindID.TabIndex = 253;
            this.txtLetterKindID.Visible = false;
            // 
            // txtBank
            // 
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(467, 40);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(306, 25);
            this.txtBank.TabIndex = 250;
            // 
            // txtLetterKind
            // 
            this.txtLetterKind.Enabled = false;
            this.txtLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKind.Location = new System.Drawing.Point(781, 40);
            this.txtLetterKind.Name = "txtLetterKind";
            this.txtLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKind.Size = new System.Drawing.Size(205, 25);
            this.txtLetterKind.TabIndex = 249;
            // 
            // txtLetterFullNo
            // 
            this.txtLetterFullNo.Enabled = false;
            this.txtLetterFullNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterFullNo.Location = new System.Drawing.Point(203, 40);
            this.txtLetterFullNo.Name = "txtLetterFullNo";
            this.txtLetterFullNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterFullNo.Size = new System.Drawing.Size(254, 25);
            this.txtLetterFullNo.TabIndex = 248;
            // 
            // LetterId
            // 
            this.LetterId.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterId.Location = new System.Drawing.Point(12, 43);
            this.LetterId.Name = "LetterId";
            this.LetterId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LetterId.Size = new System.Drawing.Size(66, 22);
            this.LetterId.TabIndex = 247;
            this.LetterId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(920, 20);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 245;
            this.label3.Text = "نوع الخطاب";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(744, 20);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 244;
            this.label5.Text = "البنك";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(391, 20);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 243;
            this.label13.Text = "رقم الخطاب ";
            // 
            // dtbLetterWAuditTableAdapter
            // 
            this.dtbLetterWAuditTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // letterWarrentyIDDataGridViewTextBoxColumn
            // 
            this.letterWarrentyIDDataGridViewTextBoxColumn.DataPropertyName = "LetterWarrentyID";
            this.letterWarrentyIDDataGridViewTextBoxColumn.HeaderText = "LetterWarrentyID";
            this.letterWarrentyIDDataGridViewTextBoxColumn.Name = "letterWarrentyIDDataGridViewTextBoxColumn";
            this.letterWarrentyIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.letterWarrentyIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // empNameDataGridViewTextBoxColumn
            // 
            this.empNameDataGridViewTextBoxColumn.DataPropertyName = "EmpName";
            this.empNameDataGridViewTextBoxColumn.HeaderText = "اسم المراجع";
            this.empNameDataGridViewTextBoxColumn.Name = "empNameDataGridViewTextBoxColumn";
            this.empNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.empNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // referenceDateDataGridViewTextBoxColumn
            // 
            this.referenceDateDataGridViewTextBoxColumn.DataPropertyName = "ReferenceDate";
            this.referenceDateDataGridViewTextBoxColumn.HeaderText = "تاريخ المراجعه";
            this.referenceDateDataGridViewTextBoxColumn.Name = "referenceDateDataGridViewTextBoxColumn";
            this.referenceDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // letterWBasicDataDataGridViewCheckBoxColumn
            // 
            this.letterWBasicDataDataGridViewCheckBoxColumn.DataPropertyName = "LetterWBasicData";
            this.letterWBasicDataDataGridViewCheckBoxColumn.HeaderText = "البيانات الاساسيه للخطاب";
            this.letterWBasicDataDataGridViewCheckBoxColumn.Name = "letterWBasicDataDataGridViewCheckBoxColumn";
            this.letterWBasicDataDataGridViewCheckBoxColumn.ReadOnly = true;
            this.letterWBasicDataDataGridViewCheckBoxColumn.Width = 150;
            // 
            // letterWExpandDateDataGridViewCheckBoxColumn
            // 
            this.letterWExpandDateDataGridViewCheckBoxColumn.DataPropertyName = "LetterWExpandDate";
            this.letterWExpandDateDataGridViewCheckBoxColumn.HeaderText = "بيانات مد الخطاب";
            this.letterWExpandDateDataGridViewCheckBoxColumn.Name = "letterWExpandDateDataGridViewCheckBoxColumn";
            this.letterWExpandDateDataGridViewCheckBoxColumn.ReadOnly = true;
            this.letterWExpandDateDataGridViewCheckBoxColumn.Width = 150;
            // 
            // letterWRefundLetterDataGridViewCheckBoxColumn
            // 
            this.letterWRefundLetterDataGridViewCheckBoxColumn.DataPropertyName = "LetterWRefundLetter";
            this.letterWRefundLetterDataGridViewCheckBoxColumn.HeaderText = "بيانات رد الخطاب";
            this.letterWRefundLetterDataGridViewCheckBoxColumn.Name = "letterWRefundLetterDataGridViewCheckBoxColumn";
            this.letterWRefundLetterDataGridViewCheckBoxColumn.ReadOnly = true;
            this.letterWRefundLetterDataGridViewCheckBoxColumn.Width = 150;
            // 
            // letterChangeValueLetterDataGridViewCheckBoxColumn
            // 
            this.letterChangeValueLetterDataGridViewCheckBoxColumn.DataPropertyName = "LetterChangeValueLetter";
            this.letterChangeValueLetterDataGridViewCheckBoxColumn.HeaderText = "بيانات تخفيض / زيادة الخطاب";
            this.letterChangeValueLetterDataGridViewCheckBoxColumn.Name = "letterChangeValueLetterDataGridViewCheckBoxColumn";
            this.letterChangeValueLetterDataGridViewCheckBoxColumn.ReadOnly = true;
            this.letterChangeValueLetterDataGridViewCheckBoxColumn.Width = 150;
            // 
            // LetterWarrentyAuditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 570);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.txtLetterKindID);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.txtLetterKind);
            this.Controls.Add(this.txtLetterFullNo);
            this.Controls.Add(this.LetterId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LetterWarrentyAuditFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LetterWarrentyAuditFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrderAuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbLetterWAuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterWarranty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FinancialSysDataSetTableAdapters.Dtb_OrderAuditTableAdapter dtb_OrderAuditTableAdapter;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource dtbOrderAuditBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        public DevExpress.XtraEditors.RadioGroup radioGroup1;
        public System.Windows.Forms.TextBox txtLetterKindID;
        public System.Windows.Forms.TextBox txtBank;
        public System.Windows.Forms.TextBox txtLetterKind;
        public System.Windows.Forms.TextBox txtLetterFullNo;
        public System.Windows.Forms.TextBox LetterId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingSource dtbLetterWAuditBindingSource;
        private LetterWarranty letterWarranty;
        private LetterWarrantyTableAdapters.DtbLetterWAuditTableAdapter dtbLetterWAuditTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn letterWarrentyIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn letterWBasicDataDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn letterWExpandDateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn letterWRefundLetterDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn letterChangeValueLetterDataGridViewCheckBoxColumn;
    }
}