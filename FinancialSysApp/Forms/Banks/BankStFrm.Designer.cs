namespace FinancialSysApp.Forms.Banks
{
    partial class BankStFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankStFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dtbBanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.label2 = new System.Windows.Forms.Label();
            this.dtb_BanksTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_BanksTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheqBankF = new System.Windows.Forms.TextBox();
            this.txtCheqBankT = new System.Windows.Forms.TextBox();
            this.txtCashT = new System.Windows.Forms.TextBox();
            this.txtCashF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransferT = new System.Windows.Forms.TextBox();
            this.txtTransferF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblBankStringCHeqCashBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankTransmentDS = new FinancialSysApp.BankTransmentDS();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.tbl_BankStringCHeqCashTableAdapter = new FinancialSysApp.BankTransmentDSTableAdapters.Tbl_BankStringCHeqCashTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRowId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCheqExpBankT = new System.Windows.Forms.TextBox();
            this.txtCheqExpBankF = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTransferExpT = new System.Windows.Forms.TextBox();
            this.txtTransferExpF = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankStringCHeqCashBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(363, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "اعداد كلمات افتتاحيه لكشوف حساب البنوك";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dtbBanksBindingSource, "ID", true));
            this.comboBox1.DataSource = this.dtbBanksBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(688, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(304, 27);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // dtbBanksBindingSource
            // 
            this.dtbBanksBindingSource.DataMember = "Dtb_Banks";
            this.dtbBanksBindingSource.DataSource = this.bankCheques;
            // 
            // bankCheques
            // 
            this.bankCheques.DataSetName = "BankCheques";
            this.bankCheques.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(958, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "البنك";
            // 
            // dtb_BanksTableAdapter
            // 
            this.dtb_BanksTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(902, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "الشيكات الوارده";
            // 
            // txtCheqBankF
            // 
            this.txtCheqBankF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqBankF.Location = new System.Drawing.Point(876, 135);
            this.txtCheqBankF.Name = "txtCheqBankF";
            this.txtCheqBankF.Size = new System.Drawing.Size(116, 26);
            this.txtCheqBankF.TabIndex = 4;
            this.txtCheqBankF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheqBankF_KeyDown);
            // 
            // txtCheqBankT
            // 
            this.txtCheqBankT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqBankT.Location = new System.Drawing.Point(688, 135);
            this.txtCheqBankT.Name = "txtCheqBankT";
            this.txtCheqBankT.Size = new System.Drawing.Size(100, 26);
            this.txtCheqBankT.TabIndex = 6;
            this.txtCheqBankT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheqBankT_KeyDown);
            // 
            // txtCashT
            // 
            this.txtCashT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashT.Location = new System.Drawing.Point(407, 135);
            this.txtCashT.Name = "txtCashT";
            this.txtCashT.Size = new System.Drawing.Size(127, 26);
            this.txtCashT.TabIndex = 9;
            this.txtCashT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashT_KeyDown);
            // 
            // txtCashF
            // 
            this.txtCashF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashF.Location = new System.Drawing.Point(544, 135);
            this.txtCashF.Name = "txtCashF";
            this.txtCashF.Size = new System.Drawing.Size(127, 26);
            this.txtCashF.TabIndex = 8;
            this.txtCashF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashF_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(629, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "النقديه";
            // 
            // txtTransferT
            // 
            this.txtTransferT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferT.Location = new System.Drawing.Point(17, 135);
            this.txtTransferT.Name = "txtTransferT";
            this.txtTransferT.Size = new System.Drawing.Size(127, 26);
            this.txtTransferT.TabIndex = 12;
            this.txtTransferT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransferT_KeyDown);
            // 
            // txtTransferF
            // 
            this.txtTransferF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferF.Location = new System.Drawing.Point(266, 135);
            this.txtTransferF.Name = "txtTransferF";
            this.txtTransferF.Size = new System.Drawing.Size(127, 26);
            this.txtTransferF.TabIndex = 11;
            this.txtTransferF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransferF_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(294, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "التحويلات الوارده";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 297);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(980, 343);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // tblBankStringCHeqCashBindingSource
            // 
            this.tblBankStringCHeqCashBindingSource.DataMember = "Tbl_BankStringCHeqCash";
            this.tblBankStringCHeqCashBindingSource.DataSource = this.bankTransmentDS;
            // 
            // bankTransmentDS
            // 
            this.bankTransmentDS.DataSetName = "BankTransmentDS";
            this.bankTransmentDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(12, 256);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(227, 35);
            this.simpleButton7.TabIndex = 277;
            this.simpleButton7.Text = "حفظ";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // tbl_BankStringCHeqCashTableAdapter
            // 
            this.tbl_BankStringCHeqCashTableAdapter.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(794, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 19);
            this.label6.TabIndex = 278;
            this.label6.Text = "#رقم الشيك #";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(150, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 19);
            this.label7.TabIndex = 279;
            this.label7.Text = "#رقم مرجع البنك #";
            // 
            // txtRowId
            // 
            this.txtRowId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowId.Location = new System.Drawing.Point(32, 42);
            this.txtRowId.Name = "txtRowId";
            this.txtRowId.Size = new System.Drawing.Size(70, 26);
            this.txtRowId.TabIndex = 280;
            this.txtRowId.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(793, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 19);
            this.label8.TabIndex = 284;
            this.label8.Text = "#رقم الشيك #";
            // 
            // txtCheqExpBankT
            // 
            this.txtCheqExpBankT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqExpBankT.Location = new System.Drawing.Point(687, 197);
            this.txtCheqExpBankT.Name = "txtCheqExpBankT";
            this.txtCheqExpBankT.Size = new System.Drawing.Size(100, 26);
            this.txtCheqExpBankT.TabIndex = 283;
            this.txtCheqExpBankT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheqExpBankT_KeyDown);
            // 
            // txtCheqExpBankF
            // 
            this.txtCheqExpBankF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqExpBankF.Location = new System.Drawing.Point(875, 197);
            this.txtCheqExpBankF.Name = "txtCheqExpBankF";
            this.txtCheqExpBankF.Size = new System.Drawing.Size(116, 26);
            this.txtCheqExpBankF.TabIndex = 282;
            this.txtCheqExpBankF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheqExpBankF_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(901, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 281;
            this.label9.Text = "الشيكات الصادره";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(150, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 19);
            this.label10.TabIndex = 288;
            this.label10.Text = "#رقم مرجع البنك #";
            // 
            // txtTransferExpT
            // 
            this.txtTransferExpT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferExpT.Location = new System.Drawing.Point(17, 197);
            this.txtTransferExpT.Name = "txtTransferExpT";
            this.txtTransferExpT.Size = new System.Drawing.Size(127, 26);
            this.txtTransferExpT.TabIndex = 287;
            this.txtTransferExpT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransferExpT_KeyDown);
            // 
            // txtTransferExpF
            // 
            this.txtTransferExpF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferExpF.Location = new System.Drawing.Point(266, 197);
            this.txtTransferExpF.Name = "txtTransferExpF";
            this.txtTransferExpF.Size = new System.Drawing.Size(127, 26);
            this.txtTransferExpF.TabIndex = 286;
            this.txtTransferExpF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransferExpF_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(294, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 19);
            this.label11.TabIndex = 285;
            this.label11.Text = "التحويلات الصادره";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // BankStFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 652);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTransferExpT);
            this.Controls.Add(this.txtTransferExpF);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCheqExpBankT);
            this.Controls.Add(this.txtCheqExpBankF);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRowId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtTransferT);
            this.Controls.Add(this.txtTransferF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCashT);
            this.Controls.Add(this.txtCashF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCheqBankT);
            this.Controls.Add(this.txtCheqBankF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "BankStFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankStatmentsSettingFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankStringCHeqCashBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private BankCheques bankCheques;
        private System.Windows.Forms.BindingSource dtbBanksBindingSource;
        private BankChequesTableAdapters.Dtb_BanksTableAdapter dtb_BanksTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheqBankF;
        private System.Windows.Forms.TextBox txtCheqBankT;
        private System.Windows.Forms.TextBox txtCashT;
        private System.Windows.Forms.TextBox txtCashF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransferT;
        private System.Windows.Forms.TextBox txtTransferF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private BankTransmentDS bankTransmentDS;
        private System.Windows.Forms.BindingSource tblBankStringCHeqCashBindingSource;
        private BankTransmentDSTableAdapters.Tbl_BankStringCHeqCashTableAdapter tbl_BankStringCHeqCashTableAdapter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRowId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCheqExpBankT;
        private System.Windows.Forms.TextBox txtCheqExpBankF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTransferExpT;
        private System.Windows.Forms.TextBox txtTransferExpF;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}