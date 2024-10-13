namespace FinancialSysApp.Forms.Banks
{
    partial class ChequeBankStatusFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChequeBankStatusFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dTPAddBank = new System.Windows.Forms.DateTimePicker();
            this.cmbDepositBank = new System.Windows.Forms.ComboBox();
            this.dtbBanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkboxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAllValueBefore = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCheqAllCount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtSpValueBefore = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheqSpCount = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CountChq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmountChq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dtb_BanksTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_BanksTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(871, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 19);
            this.label19.TabIndex = 272;
            this.label19.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(908, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 270;
            this.label3.Text = "تاريخ الاضافه";
            // 
            // dTPAddBank
            // 
            this.dTPAddBank.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPAddBank.CustomFormat = "";
            this.dTPAddBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPAddBank.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPAddBank.Location = new System.Drawing.Point(817, 65);
            this.dTPAddBank.Name = "dTPAddBank";
            this.dTPAddBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPAddBank.RightToLeftLayout = true;
            this.dTPAddBank.Size = new System.Drawing.Size(174, 26);
            this.dTPAddBank.TabIndex = 271;
            this.dTPAddBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPAddBank_KeyDown);
            // 
            // cmbDepositBank
            // 
            this.cmbDepositBank.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dtbBanksBindingSource, "ID", true));
            this.cmbDepositBank.DataSource = this.dtbBanksBindingSource;
            this.cmbDepositBank.DisplayMember = "Name";
            this.cmbDepositBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepositBank.FormattingEnabled = true;
            this.cmbDepositBank.Location = new System.Drawing.Point(535, 64);
            this.cmbDepositBank.Name = "cmbDepositBank";
            this.cmbDepositBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDepositBank.Size = new System.Drawing.Size(257, 27);
            this.cmbDepositBank.TabIndex = 322;
            this.cmbDepositBank.ValueMember = "ID";
            this.cmbDepositBank.SelectionChangeCommitted += new System.EventHandler(this.cmbDepositBank_SelectionChangeCommitted);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(674, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 19);
            this.label1.TabIndex = 324;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(711, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 323;
            this.label2.Text = "البنك المودع";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(408, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 325;
            this.label4.Text = "موقف الشيكات ";
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.dataGridView1);
            this.groupControl3.Controls.Add(this.label8);
            this.groupControl3.Controls.Add(this.txtAllValueBefore);
            this.groupControl3.Controls.Add(this.label16);
            this.groupControl3.Controls.Add(this.txtCheqAllCount);
            this.groupControl3.Controls.Add(this.label25);
            this.groupControl3.Controls.Add(this.txtSpValueBefore);
            this.groupControl3.Controls.Add(this.label9);
            this.groupControl3.Controls.Add(this.txtCheqSpCount);
            this.groupControl3.Location = new System.Drawing.Point(12, 103);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl3.Size = new System.Drawing.Size(989, 452);
            this.groupControl3.TabIndex = 327;
            this.groupControl3.Text = "بيانات الشيكات والتي تم/ لم يتم  اضافتها بتاريخ ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ser,
            this.checkboxColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(19, 24);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridView1.Size = new System.Drawing.Size(958, 346);
            this.dataGridView1.TabIndex = 329;
            // 
            // Ser
            // 
            this.Ser.HeaderText = "م";
            this.Ser.Name = "Ser";
            this.Ser.Width = 40;
            // 
            // checkboxColumn1
            // 
            this.checkboxColumn1.FalseValue = "false";
            this.checkboxColumn1.HeaderText = "(تم / لم يتم) الايداع";
            this.checkboxColumn1.Name = "checkboxColumn1";
            this.checkboxColumn1.TrueValue = "true";
            this.checkboxColumn1.Width = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(155, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 19);
            this.label8.TabIndex = 311;
            this.label8.Text = "اجمالى قيمة الشيكات المحدده";
            // 
            // txtAllValueBefore
            // 
            this.txtAllValueBefore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAllValueBefore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAllValueBefore.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllValueBefore.Location = new System.Drawing.Point(636, 406);
            this.txtAllValueBefore.Name = "txtAllValueBefore";
            this.txtAllValueBefore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAllValueBefore.Size = new System.Drawing.Size(169, 25);
            this.txtAllValueBefore.TabIndex = 307;
            this.txtAllValueBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(752, 384);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 19);
            this.label16.TabIndex = 306;
            this.label16.Text = "الاجمالي";
            // 
            // txtCheqAllCount
            // 
            this.txtCheqAllCount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCheqAllCount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCheqAllCount.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqAllCount.Location = new System.Drawing.Point(811, 406);
            this.txtCheqAllCount.Name = "txtCheqAllCount";
            this.txtCheqAllCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheqAllCount.Size = new System.Drawing.Size(108, 25);
            this.txtCheqAllCount.TabIndex = 308;
            this.txtCheqAllCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(841, 384);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 19);
            this.label25.TabIndex = 309;
            this.label25.Text = "عدد الشيكات";
            // 
            // txtSpValueBefore
            // 
            this.txtSpValueBefore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSpValueBefore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSpValueBefore.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpValueBefore.Location = new System.Drawing.Point(155, 406);
            this.txtSpValueBefore.Name = "txtSpValueBefore";
            this.txtSpValueBefore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSpValueBefore.Size = new System.Drawing.Size(170, 25);
            this.txtSpValueBefore.TabIndex = 312;
            this.txtSpValueBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(345, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 19);
            this.label9.TabIndex = 313;
            this.label9.Text = "عدد الشيكات المحدده";
            // 
            // txtCheqSpCount
            // 
            this.txtCheqSpCount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCheqSpCount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCheqSpCount.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqSpCount.Location = new System.Drawing.Point(331, 406);
            this.txtCheqSpCount.Name = "txtCheqSpCount";
            this.txtCheqSpCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheqSpCount.Size = new System.Drawing.Size(138, 25);
            this.txtCheqSpCount.TabIndex = 314;
            this.txtCheqSpCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serial,
            this.Column1,
            this.CountChq,
            this.TotalAmountChq});
            this.dataGridView2.Location = new System.Drawing.Point(329, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridView2.Size = new System.Drawing.Size(65, 37);
            this.dataGridView2.TabIndex = 330;
            this.dataGridView2.Visible = false;
            // 
            // Serial
            // 
            this.Serial.HeaderText = "م";
            this.Serial.Name = "Serial";
            this.Serial.Width = 40;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "False";
            this.Column1.HeaderText = "(تم / لم يتم) الايداع";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "True";
            // 
            // CountChq
            // 
            this.CountChq.HeaderText = "عدد الشيكات ";
            this.CountChq.Name = "CountChq";
            // 
            // TotalAmountChq
            // 
            this.TotalAmountChq.HeaderText = "قيمة الشيكات";
            this.TotalAmountChq.Name = "TotalAmountChq";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(362, 575);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(227, 35);
            this.simpleButton7.TabIndex = 328;
            this.simpleButton7.Text = "حفظ";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(300, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(147, 25);
            this.textBox2.TabIndex = 331;
            this.textBox2.Visible = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToOrderColumns = true;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(54, 12);
            this.dataGridView3.Name = "dataGridView3";
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView3.RowsDefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridView3.Size = new System.Drawing.Size(269, 68);
            this.dataGridView3.TabIndex = 332;
            this.dataGridView3.Visible = false;
            // 
            // dtb_BanksTableAdapter
            // 
            this.dtb_BanksTableAdapter.ClearBeforeFill = true;
            // 
            // ChequeBankStatusFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 636);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDepositBank);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dTPAddBank);
            this.Name = "ChequeBankStatusFrm";
            this.Text = "ChequeBankStatusFrm";
            this.Load += new System.EventHandler(this.ChequeBankStatusFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dTPAddBank;
        private System.Windows.Forms.ComboBox cmbDepositBank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAllValueBefore;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCheqAllCount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtSpValueBefore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCheqSpCount;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkboxColumn1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountChq;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmountChq;
        private BankCheques bankCheques;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingSource dtbBanksBindingSource;
        private BankChequesTableAdapters.Dtb_BanksTableAdapter dtb_BanksTableAdapter;
    }
}