namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class ScanChequesFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCollectionNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dTPCollection = new System.Windows.Forms.DateTimePicker();
            this.LblBank = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRowID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpTrCollectionCheq = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMultiScan = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.lstListOfScanner = new System.Windows.Forms.ListBox();
            this.lblListOfScanner = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtCheqID = new System.Windows.Forms.TextBox();
            this.txtProcessID = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpTrCollectionCheq.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBranch
            // 
            this.txtBranch.Enabled = false;
            this.txtBranch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranch.Location = new System.Drawing.Point(888, 48);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranch.Size = new System.Drawing.Size(250, 26);
            this.txtBranch.TabIndex = 269;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1054, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 19);
            this.label11.TabIndex = 268;
            this.label11.Text = "الفرع / الجهه";
            // 
            // txtCollectionNo
            // 
            this.txtCollectionNo.Enabled = false;
            this.txtCollectionNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollectionNo.Location = new System.Drawing.Point(706, 103);
            this.txtCollectionNo.Name = "txtCollectionNo";
            this.txtCollectionNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCollectionNo.Size = new System.Drawing.Size(173, 26);
            this.txtCollectionNo.TabIndex = 265;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(812, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 263;
            this.label2.Text = "رقم الحافظه";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(799, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 264;
            this.label3.Text = "تاريخ الحافظه";
            // 
            // dTPCollection
            // 
            this.dTPCollection.CalendarFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPCollection.Enabled = false;
            this.dTPCollection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPCollection.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPCollection.Location = new System.Drawing.Point(706, 48);
            this.dTPCollection.Name = "dTPCollection";
            this.dTPCollection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPCollection.RightToLeftLayout = true;
            this.dTPCollection.Size = new System.Drawing.Size(174, 26);
            this.dTPCollection.TabIndex = 266;
            // 
            // LblBank
            // 
            this.LblBank.AutoSize = true;
            this.LblBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBank.Location = new System.Drawing.Point(1065, 79);
            this.LblBank.Name = "LblBank";
            this.LblBank.Size = new System.Drawing.Size(74, 19);
            this.LblBank.TabIndex = 267;
            this.LblBank.Text = "البنك المودع";
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.dataGridView1);
            this.groupControl3.Location = new System.Drawing.Point(671, 135);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl3.Size = new System.Drawing.Size(472, 364);
            this.groupControl3.TabIndex = 271;
            this.groupControl3.Text = "بيانات الشيكات الوارده من الفرع  / الجهه";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ser});
            this.dataGridView1.Location = new System.Drawing.Point(11, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(456, 331);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Ser
            // 
            this.Ser.HeaderText = "م";
            this.Ser.Name = "Ser";
            this.Ser.ReadOnly = true;
            this.Ser.Width = 50;
            // 
            // txtRowID
            // 
            this.txtRowID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowID.Location = new System.Drawing.Point(671, 12);
            this.txtRowID.Name = "txtRowID";
            this.txtRowID.Size = new System.Drawing.Size(80, 26);
            this.txtRowID.TabIndex = 73;
            this.txtRowID.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 647);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 301;
            this.pictureBox1.TabStop = false;
            // 
            // grpTrCollectionCheq
            // 
            this.grpTrCollectionCheq.BackColor = System.Drawing.Color.White;
            this.grpTrCollectionCheq.Controls.Add(this.pictureBox1);
            this.grpTrCollectionCheq.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTrCollectionCheq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpTrCollectionCheq.Location = new System.Drawing.Point(12, 12);
            this.grpTrCollectionCheq.Name = "grpTrCollectionCheq";
            this.grpTrCollectionCheq.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpTrCollectionCheq.Size = new System.Drawing.Size(653, 692);
            this.grpTrCollectionCheq.TabIndex = 302;
            this.grpTrCollectionCheq.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(927, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 20);
            this.textBox2.TabIndex = 305;
            this.textBox2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMultiScan);
            this.panel1.Controls.Add(this.btnScan);
            this.panel1.Controls.Add(this.lstListOfScanner);
            this.panel1.Controls.Add(this.lblListOfScanner);
            this.panel1.Location = new System.Drawing.Point(677, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 168);
            this.panel1.TabIndex = 303;
            // 
            // btnMultiScan
            // 
            this.btnMultiScan.Enabled = false;
            this.btnMultiScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnMultiScan.Location = new System.Drawing.Point(11, 109);
            this.btnMultiScan.Name = "btnMultiScan";
            this.btnMultiScan.Size = new System.Drawing.Size(192, 31);
            this.btnMultiScan.TabIndex = 2;
            this.btnMultiScan.Text = "Scan Multi Papers";
            this.btnMultiScan.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(237, 109);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(224, 31);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan One Paper";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lstListOfScanner
            // 
            this.lstListOfScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListOfScanner.FormattingEnabled = true;
            this.lstListOfScanner.ItemHeight = 16;
            this.lstListOfScanner.Location = new System.Drawing.Point(12, 35);
            this.lstListOfScanner.Name = "lstListOfScanner";
            this.lstListOfScanner.Size = new System.Drawing.Size(454, 68);
            this.lstListOfScanner.TabIndex = 1;
            // 
            // lblListOfScanner
            // 
            this.lblListOfScanner.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListOfScanner.Location = new System.Drawing.Point(274, 9);
            this.lblListOfScanner.Name = "lblListOfScanner";
            this.lblListOfScanner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblListOfScanner.Size = new System.Drawing.Size(190, 23);
            this.lblListOfScanner.TabIndex = 0;
            this.lblListOfScanner.Text = "قائمة الماسح الضوئي";
            // 
            // txtBank
            // 
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(888, 103);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(249, 26);
            this.txtBank.TabIndex = 306;
            // 
            // txtCheqID
            // 
            this.txtCheqID.Location = new System.Drawing.Point(951, 80);
            this.txtCheqID.Name = "txtCheqID";
            this.txtCheqID.Size = new System.Drawing.Size(66, 20);
            this.txtCheqID.TabIndex = 307;
            this.txtCheqID.Visible = false;
            // 
            // txtProcessID
            // 
            this.txtProcessID.Location = new System.Drawing.Point(671, 80);
            this.txtProcessID.Name = "txtProcessID";
            this.txtProcessID.Size = new System.Drawing.Size(66, 20);
            this.txtProcessID.TabIndex = 308;
            this.txtProcessID.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(560, 340);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(34, 26);
            this.textBox3.TabIndex = 309;
            this.textBox3.Text = "\\";
            this.textBox3.Visible = false;
            // 
            // ScanChequesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 707);
            this.Controls.Add(this.txtProcessID);
            this.Controls.Add(this.txtCheqID);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRowID);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCollectionNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dTPCollection);
            this.Controls.Add(this.LblBank);
            this.Controls.Add(this.grpTrCollectionCheq);
            this.Controls.Add(this.textBox3);
            this.Name = "ScanChequesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanChequesFrm";
            this.Load += new System.EventHandler(this.ScanChequesFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpTrCollectionCheq.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpTrCollectionCheq;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMultiScan;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox lstListOfScanner;
        private System.Windows.Forms.Label lblListOfScanner;
        public System.Windows.Forms.TextBox txtBranch;
        public System.Windows.Forms.TextBox txtRowID;
        public System.Windows.Forms.TextBox txtBank;
        public System.Windows.Forms.TextBox txtCollectionNo;
        public System.Windows.Forms.DateTimePicker dTPCollection;
        public System.Windows.Forms.Label LblBank;
        private System.Windows.Forms.TextBox txtCheqID;
        public System.Windows.Forms.TextBox txtProcessID;
        private System.Windows.Forms.TextBox textBox3;
    }
}