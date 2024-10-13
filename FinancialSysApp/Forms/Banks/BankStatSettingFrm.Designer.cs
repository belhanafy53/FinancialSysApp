namespace FinancialSysApp.Forms.Banks
{
    partial class BankStatSettingFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankStatSettingFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tblMovementBankTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankTransmentDS = new FinancialSysApp.BankTransmentDS();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtbBanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankCheques = new FinancialSysApp.BankCheques();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCheqBankT = new System.Windows.Forms.TextBox();
            this.txtCheqBankF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moveTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moveType1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.البنكDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.التصنيفالرئيسيDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.التصنيفالفرعيDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الكلمهالاولىDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الكلمهالثانيهDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblBankStringCHeqCashBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtb_BanksTableAdapter = new FinancialSysApp.BankChequesTableAdapters.Dtb_BanksTableAdapter();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.txtRowId = new System.Windows.Forms.TextBox();
            this.tbl_BankStringCHeqCashTableAdapter = new FinancialSysApp.BankTransmentDSTableAdapters.Tbl_BankStringCHeqCashTableAdapter();
            this.tbl_MovementBankTypeTableAdapter = new FinancialSysApp.BankTransmentDSTableAdapters.Tbl_MovementBankTypeTableAdapter();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMovementBankTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankStringCHeqCashBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "اعداد كلمات افتتاحيه لكشوف حساب البنوك";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.radGroupBox1.Controls.Add(this.comboBox3);
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.comboBox4);
            this.radGroupBox1.Controls.Add(this.label8);
            this.radGroupBox1.Controls.Add(this.label9);
            this.radGroupBox1.HeaderText = " ";
            this.radGroupBox1.Location = new System.Drawing.Point(730, 139);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.ControlBounds = new System.Drawing.Rectangle(730, 139, 200, 100);
            this.radGroupBox1.Size = new System.Drawing.Size(233, 122);
            this.radGroupBox1.TabIndex = 397;
            this.radGroupBox1.Text = " ";
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tblMovementBankTypeBindingSource, "ID", true));
            this.comboBox3.DataSource = this.tblMovementBankTypeBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(14, 38);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox3.Size = new System.Drawing.Size(204, 27);
            this.comboBox3.TabIndex = 388;
            this.comboBox3.ValueMember = "ID";
            this.comboBox3.SelectionChangeCommitted += new System.EventHandler(this.comboBox3_SelectionChangeCommitted);
            this.comboBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox3_KeyDown);
            // 
            // tblMovementBankTypeBindingSource
            // 
            this.tblMovementBankTypeBindingSource.DataMember = "Tbl_MovementBankType";
            this.tblMovementBankTypeBindingSource.DataSource = this.bankTransmentDS;
            // 
            // bankTransmentDS
            // 
            this.bankTransmentDS.DataSetName = "BankTransmentDS";
            this.bankTransmentDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(173, -3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 19);
            this.label6.TabIndex = 314;
            this.label6.Text = "التصنيف";
            // 
            // comboBox4
            // 
            this.comboBox4.DisplayMember = "ID";
            this.comboBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(14, 90);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox4.Size = new System.Drawing.Size(204, 27);
            this.comboBox4.TabIndex = 387;
            this.comboBox4.ValueMember = "ID";
            this.comboBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox4_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(138, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 19);
            this.label8.TabIndex = 386;
            this.label8.Text = "تصنيف فرعي";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(139, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 19);
            this.label9.TabIndex = 385;
            this.label9.Text = "تصنيف رئيسي";
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
            this.label2.Location = new System.Drawing.Point(811, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 400;
            this.label2.Text = "# رقم  #";
            // 
            // txtCheqBankT
            // 
            this.txtCheqBankT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqBankT.Location = new System.Drawing.Point(686, 316);
            this.txtCheqBankT.Name = "txtCheqBankT";
            this.txtCheqBankT.Size = new System.Drawing.Size(119, 26);
            this.txtCheqBankT.TabIndex = 399;
            this.txtCheqBankT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheqBankT_KeyDown);
            // 
            // txtCheqBankF
            // 
            this.txtCheqBankF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheqBankF.Location = new System.Drawing.Point(874, 316);
            this.txtCheqBankF.Name = "txtCheqBankF";
            this.txtCheqBankF.Size = new System.Drawing.Size(116, 26);
            this.txtCheqBankF.TabIndex = 398;
            this.txtCheqBankF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCheqBankF_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(956, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 19);
            this.label3.TabIndex = 402;
            this.label3.Text = "البنك";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dtbBanksBindingSource, "ID", true));
            this.comboBox1.DataSource = this.dtbBanksBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(686, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(304, 27);
            this.comboBox1.TabIndex = 401;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
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
            this.Column1,
            this.iDDataGridViewTextBoxColumn,
            this.bankIDDataGridViewTextBoxColumn,
            this.moveTypeDataGridViewTextBoxColumn,
            this.moveType1DataGridViewTextBoxColumn,
            this.البنكDataGridViewTextBoxColumn,
            this.التصنيفالرئيسيDataGridViewTextBoxColumn,
            this.التصنيفالفرعيDataGridViewTextBoxColumn,
            this.الكلمهالاولىDataGridViewTextBoxColumn,
            this.الكلمهالثانيهDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblBankStringCHeqCashBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(659, 452);
            this.dataGridView1.TabIndex = 403;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "م";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // bankIDDataGridViewTextBoxColumn
            // 
            this.bankIDDataGridViewTextBoxColumn.DataPropertyName = "BankID";
            this.bankIDDataGridViewTextBoxColumn.HeaderText = "BankID";
            this.bankIDDataGridViewTextBoxColumn.Name = "bankIDDataGridViewTextBoxColumn";
            this.bankIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // moveTypeDataGridViewTextBoxColumn
            // 
            this.moveTypeDataGridViewTextBoxColumn.DataPropertyName = "MoveType";
            this.moveTypeDataGridViewTextBoxColumn.HeaderText = "MoveType";
            this.moveTypeDataGridViewTextBoxColumn.Name = "moveTypeDataGridViewTextBoxColumn";
            this.moveTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.moveTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // moveType1DataGridViewTextBoxColumn
            // 
            this.moveType1DataGridViewTextBoxColumn.DataPropertyName = "MoveType1";
            this.moveType1DataGridViewTextBoxColumn.HeaderText = "MoveType1";
            this.moveType1DataGridViewTextBoxColumn.Name = "moveType1DataGridViewTextBoxColumn";
            this.moveType1DataGridViewTextBoxColumn.ReadOnly = true;
            this.moveType1DataGridViewTextBoxColumn.Visible = false;
            // 
            // البنكDataGridViewTextBoxColumn
            // 
            this.البنكDataGridViewTextBoxColumn.DataPropertyName = "البنك";
            this.البنكDataGridViewTextBoxColumn.HeaderText = "البنك";
            this.البنكDataGridViewTextBoxColumn.Name = "البنكDataGridViewTextBoxColumn";
            this.البنكDataGridViewTextBoxColumn.ReadOnly = true;
            this.البنكDataGridViewTextBoxColumn.Width = 200;
            // 
            // التصنيفالرئيسيDataGridViewTextBoxColumn
            // 
            this.التصنيفالرئيسيDataGridViewTextBoxColumn.DataPropertyName = "التصنيف الرئيسي";
            this.التصنيفالرئيسيDataGridViewTextBoxColumn.HeaderText = "التصنيف الرئيسي";
            this.التصنيفالرئيسيDataGridViewTextBoxColumn.Name = "التصنيفالرئيسيDataGridViewTextBoxColumn";
            this.التصنيفالرئيسيDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // التصنيفالفرعيDataGridViewTextBoxColumn
            // 
            this.التصنيفالفرعيDataGridViewTextBoxColumn.DataPropertyName = "التصنيف الفرعي";
            this.التصنيفالفرعيDataGridViewTextBoxColumn.HeaderText = "التصنيف الفرعي";
            this.التصنيفالفرعيDataGridViewTextBoxColumn.Name = "التصنيفالفرعيDataGridViewTextBoxColumn";
            this.التصنيفالفرعيDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الكلمهالاولىDataGridViewTextBoxColumn
            // 
            this.الكلمهالاولىDataGridViewTextBoxColumn.DataPropertyName = "الكلمه الاولى";
            this.الكلمهالاولىDataGridViewTextBoxColumn.HeaderText = "الكلمه الاولى";
            this.الكلمهالاولىDataGridViewTextBoxColumn.Name = "الكلمهالاولىDataGridViewTextBoxColumn";
            this.الكلمهالاولىDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الكلمهالثانيهDataGridViewTextBoxColumn
            // 
            this.الكلمهالثانيهDataGridViewTextBoxColumn.DataPropertyName = "الكلمه الثانيه";
            this.الكلمهالثانيهDataGridViewTextBoxColumn.HeaderText = "الكلمه الثانيه";
            this.الكلمهالثانيهDataGridViewTextBoxColumn.Name = "الكلمهالثانيهDataGridViewTextBoxColumn";
            this.الكلمهالثانيهDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tblBankStringCHeqCashBindingSource
            // 
            this.tblBankStringCHeqCashBindingSource.DataMember = "Tbl_BankStringCHeqCash";
            this.tblBankStringCHeqCashBindingSource.DataSource = this.bankTransmentDS;
            // 
            // dtb_BanksTableAdapter
            // 
            this.dtb_BanksTableAdapter.ClearBeforeFill = true;
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(725, 367);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(227, 35);
            this.simpleButton7.TabIndex = 404;
            this.simpleButton7.Text = "حفظ";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // txtRowId
            // 
            this.txtRowId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowId.Location = new System.Drawing.Point(466, 228);
            this.txtRowId.Name = "txtRowId";
            this.txtRowId.Size = new System.Drawing.Size(70, 26);
            this.txtRowId.TabIndex = 405;
            this.txtRowId.Visible = false;
            // 
            // tbl_BankStringCHeqCashTableAdapter
            // 
            this.tbl_BankStringCHeqCashTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_MovementBankTypeTableAdapter
            // 
            this.tbl_MovementBankTypeTableAdapter.ClearBeforeFill = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(720, 435);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(227, 35);
            this.simpleButton1.TabIndex = 406;
            this.simpleButton1.Text = "حذف";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // BankStatSettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 561);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtRowId);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCheqBankT);
            this.Controls.Add(this.txtCheqBankF);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.label1);
            this.Name = "BankStatSettingFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BankStatmentSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMovementBankTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankTransmentDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblBankStringCHeqCashBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCheqBankT;
        private System.Windows.Forms.TextBox txtCheqBankF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BankChequesTableAdapters.Dtb_BanksTableAdapter dtb_BanksTableAdapter;
        private System.Windows.Forms.BindingSource dtbBanksBindingSource;
        private BankCheques bankCheques;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private System.Windows.Forms.TextBox txtRowId;
        private BankTransmentDS bankTransmentDS;
        private System.Windows.Forms.BindingSource tblBankStringCHeqCashBindingSource;
        private BankTransmentDSTableAdapters.Tbl_BankStringCHeqCashTableAdapter tbl_BankStringCHeqCashTableAdapter;
        private System.Windows.Forms.BindingSource tblMovementBankTypeBindingSource;
        private BankTransmentDSTableAdapters.Tbl_MovementBankTypeTableAdapter tbl_MovementBankTypeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moveTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moveType1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn البنكDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn التصنيفالرئيسيDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn التصنيفالفرعيDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الكلمهالاولىDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الكلمهالثانيهDataGridViewTextBoxColumn;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}