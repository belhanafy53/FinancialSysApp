namespace FinancialSysApp.Forms.CashDeposit
{
    partial class CheqeedepositQueryFrm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dTPDeposit = new System.Windows.Forms.DateTimePicker();
            this.dTPDeposit2 = new System.Windows.Forms.DateTimePicker();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtbtotalTrCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.label25 = new System.Windows.Forms.Label();
            this.txtAllCount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAllValue = new System.Windows.Forms.TextBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtb_totalTrCollectionTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_totalTrCollectionTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.Ser2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankDepositeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankAccounNoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالايداعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالحافظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالحافظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representiveIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeReceivedKindIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.البنكالمودعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.القيمهالاجماليهللحافظهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDepositNoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.الفرعDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheqCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbtotalTrCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(936, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 380;
            this.label3.Text = "من تاريخ ايداع";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(76, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 383;
            this.label5.Text = "الى تاريخ ايداع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(956, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 379;
            this.label2.Text = "محددات البحث";
            // 
            // dTPDeposit
            // 
            this.dTPDeposit.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPDeposit.Location = new System.Drawing.Point(879, 100);
            this.dTPDeposit.Name = "dTPDeposit";
            this.dTPDeposit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPDeposit.RightToLeftLayout = true;
            this.dTPDeposit.Size = new System.Drawing.Size(126, 26);
            this.dTPDeposit.TabIndex = 381;
            // 
            // dTPDeposit2
            // 
            this.dTPDeposit2.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPDeposit2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPDeposit2.Location = new System.Drawing.Point(19, 42);
            this.dTPDeposit2.Name = "dTPDeposit2";
            this.dTPDeposit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPDeposit2.RightToLeftLayout = true;
            this.dTPDeposit2.Size = new System.Drawing.Size(126, 26);
            this.dTPDeposit2.TabIndex = 382;
            this.dTPDeposit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPDeposit2_KeyDown);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.label5);
            this.radGroupBox3.Controls.Add(this.dTPDeposit2);
            this.radGroupBox3.HeaderText = " ";
            this.radGroupBox3.Location = new System.Drawing.Point(689, 57);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(349, 85);
            this.radGroupBox3.TabIndex = 384;
            this.radGroupBox3.Text = " ";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.HeaderText = "";
            this.radGroupBox4.Location = new System.Drawing.Point(702, 455);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(317, 88);
            this.radGroupBox4.TabIndex = 379;
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
            this.Ser2,
            this.iDDataGridViewTextBoxColumn,
            this.TotalAmount,
            this.bankDepositeIDDataGridViewTextBoxColumn,
            this.bankAccounNoIDDataGridViewTextBoxColumn,
            this.تاريخالايداعDataGridViewTextBoxColumn,
            this.رقمالحافظهDataGridViewTextBoxColumn,
            this.تاريخالحافظهDataGridViewTextBoxColumn,
            this.branchIDDataGridViewTextBoxColumn,
            this.representiveIDDataGridViewTextBoxColumn,
            this.chequeReceivedKindIDDataGridViewTextBoxColumn,
            this.البنكالمودعDataGridViewTextBoxColumn,
            this.القيمهالاجماليهللحافظهDataGridViewTextBoxColumn,
            this.isDepositNoDataGridViewCheckBoxColumn,
            this.الفرعDataGridViewTextBoxColumn,
            this.CheqCount});
            this.dataGridView1.DataSource = this.dtbtotalTrCollectionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1015, 419);
            this.dataGridView1.TabIndex = 82;
            // 
            // dtbtotalTrCollectionBindingSource
            // 
            this.dtbtotalTrCollectionBindingSource.DataMember = "Dtb_totalTrCollection";
            this.dtbtotalTrCollectionBindingSource.DataSource = this.bankCheques;
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(968, 473);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 19);
            this.label25.TabIndex = 313;
            this.label25.Text = "العدد";
            // 
            // txtAllCount
            // 
            this.txtAllCount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAllCount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAllCount.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllCount.Location = new System.Drawing.Point(897, 495);
            this.txtAllCount.Name = "txtAllCount";
            this.txtAllCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllCount.Size = new System.Drawing.Size(108, 25);
            this.txtAllCount.TabIndex = 312;
            this.txtAllCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(838, 473);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 19);
            this.label16.TabIndex = 310;
            this.label16.Text = "الاجمالي";
            // 
            // txtAllValue
            // 
            this.txtAllValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAllValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAllValue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllValue.Location = new System.Drawing.Point(722, 495);
            this.txtAllValue.Name = "txtAllValue";
            this.txtAllValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllValue.Size = new System.Drawing.Size(169, 25);
            this.txtAllValue.TabIndex = 311;
            this.txtAllValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.txtAllValue);
            this.radGroupBox2.Controls.Add(this.label16);
            this.radGroupBox2.Controls.Add(this.txtAllCount);
            this.radGroupBox2.Controls.Add(this.label25);
            this.radGroupBox2.Controls.Add(this.dataGridView1);
            this.radGroupBox2.Controls.Add(this.radGroupBox4);
            this.radGroupBox2.HeaderText = " ";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 148);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(1034, 554);
            this.radGroupBox2.TabIndex = 385;
            this.radGroupBox2.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(426, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 24);
            this.label1.TabIndex = 386;
            this.label1.Text = "استعلامات الشيكات المودعه";
            // 
            // dtb_totalTrCollectionTableAdapter
            // 
            this.dtb_totalTrCollectionTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(484, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 387;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ser2
            // 
            this.Ser2.HeaderText = "م";
            this.Ser2.Name = "Ser2";
            this.Ser2.ReadOnly = true;
            this.Ser2.Width = 30;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "القيمه الاجماليه للحافظه";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 150;
            // 
            // bankDepositeIDDataGridViewTextBoxColumn
            // 
            this.bankDepositeIDDataGridViewTextBoxColumn.DataPropertyName = "BankDepositeID";
            this.bankDepositeIDDataGridViewTextBoxColumn.HeaderText = "BankDepositeID";
            this.bankDepositeIDDataGridViewTextBoxColumn.Name = "bankDepositeIDDataGridViewTextBoxColumn";
            this.bankDepositeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankDepositeIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // bankAccounNoIDDataGridViewTextBoxColumn
            // 
            this.bankAccounNoIDDataGridViewTextBoxColumn.DataPropertyName = "BankAccounNoID";
            this.bankAccounNoIDDataGridViewTextBoxColumn.HeaderText = "BankAccounNoID";
            this.bankAccounNoIDDataGridViewTextBoxColumn.Name = "bankAccounNoIDDataGridViewTextBoxColumn";
            this.bankAccounNoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankAccounNoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // تاريخالايداعDataGridViewTextBoxColumn
            // 
            this.تاريخالايداعDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الايداع";
            this.تاريخالايداعDataGridViewTextBoxColumn.HeaderText = "تاريخ الايداع";
            this.تاريخالايداعDataGridViewTextBoxColumn.Name = "تاريخالايداعDataGridViewTextBoxColumn";
            this.تاريخالايداعDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // رقمالحافظهDataGridViewTextBoxColumn
            // 
            this.رقمالحافظهDataGridViewTextBoxColumn.DataPropertyName = "رقم الحافظه";
            this.رقمالحافظهDataGridViewTextBoxColumn.HeaderText = "رقم الحافظه";
            this.رقمالحافظهDataGridViewTextBoxColumn.Name = "رقمالحافظهDataGridViewTextBoxColumn";
            this.رقمالحافظهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // تاريخالحافظهDataGridViewTextBoxColumn
            // 
            this.تاريخالحافظهDataGridViewTextBoxColumn.DataPropertyName = "تاريخ الحافظه";
            this.تاريخالحافظهDataGridViewTextBoxColumn.HeaderText = "تاريخ الحافظه";
            this.تاريخالحافظهDataGridViewTextBoxColumn.Name = "تاريخالحافظهDataGridViewTextBoxColumn";
            this.تاريخالحافظهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // branchIDDataGridViewTextBoxColumn
            // 
            this.branchIDDataGridViewTextBoxColumn.DataPropertyName = "BranchID";
            this.branchIDDataGridViewTextBoxColumn.HeaderText = "BranchID";
            this.branchIDDataGridViewTextBoxColumn.Name = "branchIDDataGridViewTextBoxColumn";
            this.branchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.branchIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // representiveIDDataGridViewTextBoxColumn
            // 
            this.representiveIDDataGridViewTextBoxColumn.DataPropertyName = "RepresentiveID";
            this.representiveIDDataGridViewTextBoxColumn.HeaderText = "RepresentiveID";
            this.representiveIDDataGridViewTextBoxColumn.Name = "representiveIDDataGridViewTextBoxColumn";
            this.representiveIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.representiveIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // chequeReceivedKindIDDataGridViewTextBoxColumn
            // 
            this.chequeReceivedKindIDDataGridViewTextBoxColumn.DataPropertyName = "ChequeReceivedKindID";
            this.chequeReceivedKindIDDataGridViewTextBoxColumn.HeaderText = "ChequeReceivedKindID";
            this.chequeReceivedKindIDDataGridViewTextBoxColumn.Name = "chequeReceivedKindIDDataGridViewTextBoxColumn";
            this.chequeReceivedKindIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.chequeReceivedKindIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // البنكالمودعDataGridViewTextBoxColumn
            // 
            this.البنكالمودعDataGridViewTextBoxColumn.DataPropertyName = "البنك المودع";
            this.البنكالمودعDataGridViewTextBoxColumn.HeaderText = "البنك المودع";
            this.البنكالمودعDataGridViewTextBoxColumn.Name = "البنكالمودعDataGridViewTextBoxColumn";
            this.البنكالمودعDataGridViewTextBoxColumn.ReadOnly = true;
            this.البنكالمودعDataGridViewTextBoxColumn.Width = 200;
            // 
            // القيمهالاجماليهللحافظهDataGridViewTextBoxColumn
            // 
            this.القيمهالاجماليهللحافظهDataGridViewTextBoxColumn.DataPropertyName = "القيمه الاجماليه للحافظه";
            this.القيمهالاجماليهللحافظهDataGridViewTextBoxColumn.HeaderText = "القيمه الاجماليه للحافظه";
            this.القيمهالاجماليهللحافظهDataGridViewTextBoxColumn.Name = "القيمهالاجماليهللحافظهDataGridViewTextBoxColumn";
            this.القيمهالاجماليهللحافظهDataGridViewTextBoxColumn.ReadOnly = true;
            this.القيمهالاجماليهللحافظهDataGridViewTextBoxColumn.Width = 150;
            // 
            // isDepositNoDataGridViewCheckBoxColumn
            // 
            this.isDepositNoDataGridViewCheckBoxColumn.DataPropertyName = "IsDepositNo";
            this.isDepositNoDataGridViewCheckBoxColumn.HeaderText = "IsDepositNo";
            this.isDepositNoDataGridViewCheckBoxColumn.Name = "isDepositNoDataGridViewCheckBoxColumn";
            this.isDepositNoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isDepositNoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // الفرعDataGridViewTextBoxColumn
            // 
            this.الفرعDataGridViewTextBoxColumn.DataPropertyName = "الفرع";
            this.الفرعDataGridViewTextBoxColumn.HeaderText = "الفرع";
            this.الفرعDataGridViewTextBoxColumn.Name = "الفرعDataGridViewTextBoxColumn";
            this.الفرعDataGridViewTextBoxColumn.ReadOnly = true;
            this.الفرعDataGridViewTextBoxColumn.Width = 200;
            // 
            // CheqCount
            // 
            this.CheqCount.HeaderText = "عدد الشيكات";
            this.CheqCount.Name = "CheqCount";
            this.CheqCount.ReadOnly = true;
            // 
            // CheqeedepositQueryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 721);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dTPDeposit);
            this.Controls.Add(this.radGroupBox3);
            this.Name = "CheqeedepositQueryFrm";
            this.Text = "CheqeedepositQueryFrm";
            this.Load += new System.EventHandler(this.CheqeedepositQueryFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbtotalTrCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dTPDeposit;
        private System.Windows.Forms.DateTimePicker dTPDeposit2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtAllCount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAllValue;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dtbtotalTrCollectionBindingSource;
        private BankCheques bankCheques;
        private BankChequesTableAdapters.Dtb_totalTrCollectionTableAdapter dtb_totalTrCollectionTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankDepositeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccounNoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالايداعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالحافظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالحافظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn representiveIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeReceivedKindIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn البنكالمودعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn القيمهالاجماليهللحافظهDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDepositNoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الفرعDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheqCount;
    }
}