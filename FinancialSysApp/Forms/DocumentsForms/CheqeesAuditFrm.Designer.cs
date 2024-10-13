namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class CheqeesAuditFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtbTreasuryCollectionAuditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheqNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCheqId = new System.Windows.Forms.TextBox();
            this.dtbTreasuryCollection_AuditTableAdapter = new FinancialSysApp.BankChequesTableAdapters.DtbTreasuryCollection_AuditTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treasuryCollectionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankCheqeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTrcollectionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCheqBankDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.referenceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbTreasuryCollectionAuditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            this.SuspendLayout();
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
            this.treasuryCollectionIDDataGridViewTextBoxColumn,
            this.bankCheqeIDDataGridViewTextBoxColumn,
            this.isTrcollectionDataGridViewCheckBoxColumn,
            this.isCheqBankDataGridViewCheckBoxColumn,
            this.referenceDateDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dtbTreasuryCollectionAuditBindingSource;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(811, 448);
            this.dataGridView1.TabIndex = 14;
            // 
            // dtbTreasuryCollectionAuditBindingSource
            // 
            this.dtbTreasuryCollectionAuditBindingSource.DataMember = "DtbTreasuryCollection_Audit";
            this.dtbTreasuryCollectionAuditBindingSource.DataSource = this.bankCheques;
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(177, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(306, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "تاريخ استحقاق الشيك";
            // 
            // txtCheqNo
            // 
            this.txtCheqNo.Enabled = false;
            this.txtCheqNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqNo.Location = new System.Drawing.Point(394, 51);
            this.txtCheqNo.Name = "txtCheqNo";
            this.txtCheqNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheqNo.Size = new System.Drawing.Size(208, 26);
            this.txtCheqNo.TabIndex = 17;
            this.txtCheqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(531, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "رقم الشيك";
            // 
            // txtCheqId
            // 
            this.txtCheqId.Enabled = false;
            this.txtCheqId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqId.Location = new System.Drawing.Point(25, 15);
            this.txtCheqId.Name = "txtCheqId";
            this.txtCheqId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheqId.Size = new System.Drawing.Size(103, 26);
            this.txtCheqId.TabIndex = 20;
            this.txtCheqId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCheqId.Visible = false;
            // 
            // dtbTreasuryCollection_AuditTableAdapter
            // 
            this.dtbTreasuryCollection_AuditTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // treasuryCollectionIDDataGridViewTextBoxColumn
            // 
            this.treasuryCollectionIDDataGridViewTextBoxColumn.DataPropertyName = "TreasuryCollectionID";
            this.treasuryCollectionIDDataGridViewTextBoxColumn.HeaderText = "TreasuryCollectionID";
            this.treasuryCollectionIDDataGridViewTextBoxColumn.Name = "treasuryCollectionIDDataGridViewTextBoxColumn";
            this.treasuryCollectionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.treasuryCollectionIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // bankCheqeIDDataGridViewTextBoxColumn
            // 
            this.bankCheqeIDDataGridViewTextBoxColumn.DataPropertyName = "BankCheqeID";
            this.bankCheqeIDDataGridViewTextBoxColumn.HeaderText = "BankCheqeID";
            this.bankCheqeIDDataGridViewTextBoxColumn.Name = "bankCheqeIDDataGridViewTextBoxColumn";
            this.bankCheqeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankCheqeIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // isTrcollectionDataGridViewCheckBoxColumn
            // 
            this.isTrcollectionDataGridViewCheckBoxColumn.DataPropertyName = "IsTrcollection";
            this.isTrcollectionDataGridViewCheckBoxColumn.HeaderText = "(تم / ام لم تتم)المراجعه";
            this.isTrcollectionDataGridViewCheckBoxColumn.Name = "isTrcollectionDataGridViewCheckBoxColumn";
            this.isTrcollectionDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isTrcollectionDataGridViewCheckBoxColumn.Visible = false;
            this.isTrcollectionDataGridViewCheckBoxColumn.Width = 150;
            // 
            // isCheqBankDataGridViewCheckBoxColumn
            // 
            this.isCheqBankDataGridViewCheckBoxColumn.DataPropertyName = "IsCheqBank";
            this.isCheqBankDataGridViewCheckBoxColumn.HeaderText = "(تم / ام لم تتم)المراجعه";
            this.isCheqBankDataGridViewCheckBoxColumn.Name = "isCheqBankDataGridViewCheckBoxColumn";
            this.isCheqBankDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isCheqBankDataGridViewCheckBoxColumn.Width = 150;
            // 
            // referenceDateDataGridViewTextBoxColumn
            // 
            this.referenceDateDataGridViewTextBoxColumn.DataPropertyName = "ReferenceDate";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.referenceDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.referenceDateDataGridViewTextBoxColumn.HeaderText = "تاريح المراجعه";
            this.referenceDateDataGridViewTextBoxColumn.Name = "referenceDateDataGridViewTextBoxColumn";
            this.referenceDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.referenceDateDataGridViewTextBoxColumn.Width = 130;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "الملاحظات";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteDataGridViewTextBoxColumn.Width = 210;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "المراجع";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // CheqeesAuditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 550);
            this.Controls.Add(this.txtCheqId);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCheqNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CheqeesAuditFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CheqeesAuditFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbTreasuryCollectionAuditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCheqNo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCheqId;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource dtbTreasuryCollectionAuditBindingSource;
        private BankChequesTableAdapters.DtbTreasuryCollection_AuditTableAdapter dtbTreasuryCollection_AuditTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treasuryCollectionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankCheqeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTrcollectionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheqBankDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}