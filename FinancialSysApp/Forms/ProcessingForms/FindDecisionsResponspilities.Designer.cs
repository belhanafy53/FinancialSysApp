namespace FinancialSysApp.Forms.ProcessingForms
{
    partial class FindDecisionsResponspilities
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dtptxtDecisionDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDecisionNo = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decisionNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decisionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responspilityCentersIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblDecisionsResponspilitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblResponspilityCenters1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblResponspilityCentersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_ResponspilityCenters1TableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_ResponspilityCenters1TableAdapter();
            this.tbl_DecisionsResponspilitiesTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_DecisionsResponspilitiesTableAdapter();
            this.tbl_ResponspilityCentersTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_ResponspilityCentersTableAdapter();
            this.txtRespName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDecisionsResponspilitiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblResponspilityCenters1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblResponspilityCentersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRespName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(7, 15);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.textEdit1.Size = new System.Drawing.Size(103, 20);
            this.textEdit1.TabIndex = 316;
            this.textEdit1.TabStop = false;
            this.textEdit1.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(374, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 314;
            this.label2.Text = "اللجنه";
            // 
            // dtptxtDecisionDate
            // 
            this.dtptxtDecisionDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptxtDecisionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtptxtDecisionDate.Location = new System.Drawing.Point(54, 58);
            this.dtptxtDecisionDate.Name = "dtptxtDecisionDate";
            this.dtptxtDecisionDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtptxtDecisionDate.RightToLeftLayout = true;
            this.dtptxtDecisionDate.Size = new System.Drawing.Size(134, 25);
            this.dtptxtDecisionDate.TabIndex = 313;
            this.dtptxtDecisionDate.ValueChanged += new System.EventHandler(this.dtptxtDecisionDate_ValueChanged);
            this.dtptxtDecisionDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptxtDecisionDate_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 312;
            this.label1.Text = "تاريخ    ";
            // 
            // txtDecisionNo
            // 
            this.txtDecisionNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecisionNo.EditValue = "";
            this.txtDecisionNo.Location = new System.Drawing.Point(274, 58);
            this.txtDecisionNo.Name = "txtDecisionNo";
            this.txtDecisionNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDecisionNo.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtDecisionNo.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecisionNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtDecisionNo.Properties.Appearance.Options.UseBorderColor = true;
            this.txtDecisionNo.Properties.Appearance.Options.UseFont = true;
            this.txtDecisionNo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDecisionNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDecisionNo.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtDecisionNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDecisionNo.Size = new System.Drawing.Size(138, 22);
            this.txtDecisionNo.TabIndex = 309;
            this.txtDecisionNo.TabStop = false;
            this.txtDecisionNo.EditValueChanged += new System.EventHandler(this.txtDecisionNo_EditValueChanged);
            this.txtDecisionNo.TextChanged += new System.EventHandler(this.txtDecisionNo_TextChanged);
            this.txtDecisionNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDecisionNo_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(418, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 17);
            this.label13.TabIndex = 310;
            this.label13.Text = "رقم";
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 28;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.decisionNODataGridViewTextBoxColumn,
            this.decisionDateDataGridViewTextBoxColumn,
            this.forYearDataGridViewTextBoxColumn,
            this.responspilityCentersIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblDecisionsResponspilitiesBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView1.Location = new System.Drawing.Point(7, 102);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Size = new System.Drawing.Size(533, 349);
            this.dataGridView1.TabIndex = 311;
            this.dataGridView1.UseCustomBackgroundColor = true;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // decisionNODataGridViewTextBoxColumn
            // 
            this.decisionNODataGridViewTextBoxColumn.DataPropertyName = "DecisionNO";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.decisionNODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.decisionNODataGridViewTextBoxColumn.HeaderText = "الرقم";
            this.decisionNODataGridViewTextBoxColumn.Name = "decisionNODataGridViewTextBoxColumn";
            this.decisionNODataGridViewTextBoxColumn.Width = 150;
            // 
            // decisionDateDataGridViewTextBoxColumn
            // 
            this.decisionDateDataGridViewTextBoxColumn.DataPropertyName = "DecisionDate";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.decisionDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.decisionDateDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.decisionDateDataGridViewTextBoxColumn.Name = "decisionDateDataGridViewTextBoxColumn";
            // 
            // forYearDataGridViewTextBoxColumn
            // 
            this.forYearDataGridViewTextBoxColumn.DataPropertyName = "ForYear";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.forYearDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.forYearDataGridViewTextBoxColumn.HeaderText = "العام";
            this.forYearDataGridViewTextBoxColumn.Name = "forYearDataGridViewTextBoxColumn";
            this.forYearDataGridViewTextBoxColumn.Width = 120;
            // 
            // responspilityCentersIDDataGridViewTextBoxColumn
            // 
            this.responspilityCentersIDDataGridViewTextBoxColumn.DataPropertyName = "ResponspilityCentersID";
            this.responspilityCentersIDDataGridViewTextBoxColumn.HeaderText = "ResponspilityCentersID";
            this.responspilityCentersIDDataGridViewTextBoxColumn.Name = "responspilityCentersIDDataGridViewTextBoxColumn";
            this.responspilityCentersIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.nameDataGridViewTextBoxColumn.HeaderText = "اللجنه";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Visible = false;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // tblDecisionsResponspilitiesBindingSource
            // 
            this.tblDecisionsResponspilitiesBindingSource.DataMember = "Tbl_DecisionsResponspilities";
            this.tblDecisionsResponspilitiesBindingSource.DataSource = this.financialSysDataSet;
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(49, 25);
            this.comboBox1.TabIndex = 315;
            this.comboBox1.Visible = false;
            // 
            // tblResponspilityCenters1BindingSource
            // 
            this.tblResponspilityCenters1BindingSource.DataMember = "Tbl_ResponspilityCenters1";
            this.tblResponspilityCenters1BindingSource.DataSource = this.financialSysDataSet;
            // 
            // tblResponspilityCentersBindingSource
            // 
            this.tblResponspilityCentersBindingSource.DataMember = "Tbl_ResponspilityCenters";
            this.tblResponspilityCentersBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_ResponspilityCenters1TableAdapter
            // 
            this.tbl_ResponspilityCenters1TableAdapter.ClearBeforeFill = true;
            // 
            // tbl_DecisionsResponspilitiesTableAdapter
            // 
            this.tbl_DecisionsResponspilitiesTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_ResponspilityCentersTableAdapter
            // 
            this.tbl_ResponspilityCentersTableAdapter.ClearBeforeFill = true;
            // 
            // txtRespName
            // 
            this.txtRespName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRespName.EditValue = "";
            this.txtRespName.Location = new System.Drawing.Point(141, 15);
            this.txtRespName.Name = "txtRespName";
            this.txtRespName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRespName.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtRespName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespName.Properties.Appearance.Options.UseBackColor = true;
            this.txtRespName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtRespName.Properties.Appearance.Options.UseFont = true;
            this.txtRespName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRespName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRespName.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtRespName.Size = new System.Drawing.Size(227, 24);
            this.txtRespName.TabIndex = 317;
            this.txtRespName.TabStop = false;
            // 
            // FindDecisionsResponspilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 463);
            this.Controls.Add(this.txtRespName);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtptxtDecisionDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDecisionNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Name = "FindDecisionsResponspilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FindDecisionsResponspilities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecisionNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDecisionsResponspilitiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblResponspilityCenters1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblResponspilityCentersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRespName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit textEdit1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtptxtDecisionDate;
        internal System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.TextEdit txtDecisionNo;
        internal System.Windows.Forms.Label label13;
        public DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        private FinancialSysDataSet financialSysDataSet;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource tblResponspilityCenters1BindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_ResponspilityCenters1TableAdapter tbl_ResponspilityCenters1TableAdapter;
        private System.Windows.Forms.BindingSource tblDecisionsResponspilitiesBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_DecisionsResponspilitiesTableAdapter tbl_DecisionsResponspilitiesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn decisionNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn decisionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn forYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responspilityCentersIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tblResponspilityCentersBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_ResponspilityCentersTableAdapter tbl_ResponspilityCentersTableAdapter;
        public DevExpress.XtraEditors.TextEdit txtRespName;
    }
}