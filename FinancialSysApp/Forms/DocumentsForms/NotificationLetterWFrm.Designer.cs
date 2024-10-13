namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class NotificationLetterWFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationLetterWFrm));
            this.dTPNotificationDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFYear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPurchMethode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MskExpandLastDate = new System.Windows.Forms.TextBox();
            this.MskFirstExpandDate = new System.Windows.Forms.DateTimePicker();
            this.MskStartDate = new System.Windows.Forms.DateTimePicker();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.txtLetterKindID = new System.Windows.Forms.TextBox();
            this.txtLetterFullNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcurrency = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtLetterKind = new System.Windows.Forms.TextBox();
            this.LetterId = new System.Windows.Forms.TextBox();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbRecieveMethode = new System.Windows.Forms.ComboBox();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tblRefundLettersReasonsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_RefundLettersReasonsTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_RefundLettersReasonsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRefundLettersReasonsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dTPNotificationDate
            // 
            this.dTPNotificationDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPNotificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPNotificationDate.Location = new System.Drawing.Point(351, 333);
            this.dTPNotificationDate.Name = "dTPNotificationDate";
            this.dTPNotificationDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dTPNotificationDate.RightToLeftLayout = true;
            this.dTPNotificationDate.Size = new System.Drawing.Size(272, 26);
            this.dTPNotificationDate.TabIndex = 205;
            this.dTPNotificationDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dTPNotificationDate_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(542, 313);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 203;
            this.label9.Text = "تاريخ الاخطار";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(298, 383);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 33);
            this.simpleButton1.TabIndex = 206;
            this.simpleButton1.Text = "حفظ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(235, 313);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(88, 17);
            this.label13.TabIndex = 217;
            this.label13.Text = "سبب رد الخطاب";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(79, 127);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(37, 17);
            this.label15.TabIndex = 268;
            this.label15.Text = "العمله";
            // 
            // txtFYear
            // 
            this.txtFYear.Enabled = false;
            this.txtFYear.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFYear.Location = new System.Drawing.Point(15, 211);
            this.txtFYear.Name = "txtFYear";
            this.txtFYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFYear.Size = new System.Drawing.Size(98, 25);
            this.txtFYear.TabIndex = 267;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(91, 189);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(25, 17);
            this.label12.TabIndex = 266;
            this.label12.Text = "عام";
            // 
            // txtTenderNo
            // 
            this.txtTenderNo.Enabled = false;
            this.txtTenderNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenderNo.Location = new System.Drawing.Point(131, 273);
            this.txtTenderNo.Name = "txtTenderNo";
            this.txtTenderNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTenderNo.Size = new System.Drawing.Size(189, 25);
            this.txtTenderNo.TabIndex = 265;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 189);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 264;
            this.label1.Text = "طريقة الشراء";
            // 
            // txtPurchMethode
            // 
            this.txtPurchMethode.Enabled = false;
            this.txtPurchMethode.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchMethode.Location = new System.Drawing.Point(131, 211);
            this.txtPurchMethode.Name = "txtPurchMethode";
            this.txtPurchMethode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPurchMethode.Size = new System.Drawing.Size(196, 25);
            this.txtPurchMethode.TabIndex = 263;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 250);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 262;
            this.label2.Text = "رقم";
            // 
            // MskExpandLastDate
            // 
            this.MskExpandLastDate.Enabled = false;
            this.MskExpandLastDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskExpandLastDate.Location = new System.Drawing.Point(208, 38);
            this.MskExpandLastDate.Name = "MskExpandLastDate";
            this.MskExpandLastDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskExpandLastDate.Size = new System.Drawing.Size(48, 25);
            this.MskExpandLastDate.TabIndex = 261;
            this.MskExpandLastDate.Visible = false;
            // 
            // MskFirstExpandDate
            // 
            this.MskFirstExpandDate.Enabled = false;
            this.MskFirstExpandDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskFirstExpandDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MskFirstExpandDate.Location = new System.Drawing.Point(351, 273);
            this.MskFirstExpandDate.Name = "MskFirstExpandDate";
            this.MskFirstExpandDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskFirstExpandDate.RightToLeftLayout = true;
            this.MskFirstExpandDate.Size = new System.Drawing.Size(272, 26);
            this.MskFirstExpandDate.TabIndex = 260;
            // 
            // MskStartDate
            // 
            this.MskStartDate.Enabled = false;
            this.MskStartDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MskStartDate.Location = new System.Drawing.Point(351, 215);
            this.MskStartDate.Name = "MskStartDate";
            this.MskStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MskStartDate.RightToLeftLayout = true;
            this.MskStartDate.Size = new System.Drawing.Size(274, 26);
            this.MskStartDate.TabIndex = 259;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(430, 19);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "وارد"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "صادر")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(160, 25);
            this.radioGroup1.TabIndex = 258;
            this.radioGroup1.Visible = false;
            // 
            // txtLetterKindID
            // 
            this.txtLetterKindID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKindID.Location = new System.Drawing.Point(119, 49);
            this.txtLetterKindID.Name = "txtLetterKindID";
            this.txtLetterKindID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKindID.Size = new System.Drawing.Size(66, 22);
            this.txtLetterKindID.TabIndex = 257;
            this.txtLetterKindID.Visible = false;
            // 
            // txtLetterFullNo
            // 
            this.txtLetterFullNo.Enabled = false;
            this.txtLetterFullNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterFullNo.Location = new System.Drawing.Point(351, 147);
            this.txtLetterFullNo.Name = "txtLetterFullNo";
            this.txtLetterFullNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterFullNo.Size = new System.Drawing.Size(273, 25);
            this.txtLetterFullNo.TabIndex = 249;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(197, 18);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 256;
            this.label8.Text = "  اخر تاريخ مد الخطاب";
            this.label8.Visible = false;
            // 
            // txtcurrency
            // 
            this.txtcurrency.Enabled = false;
            this.txtcurrency.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcurrency.Location = new System.Drawing.Point(15, 147);
            this.txtcurrency.Name = "txtcurrency";
            this.txtcurrency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtcurrency.Size = new System.Drawing.Size(98, 25);
            this.txtcurrency.TabIndex = 255;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(510, 250);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 254;
            this.label7.Text = "تاريخ صلاحية الخطاب";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(517, 189);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 253;
            this.label6.Text = "تاريخ اصدار الخطاب";
            // 
            // txtBank
            // 
            this.txtBank.Enabled = false;
            this.txtBank.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(21, 87);
            this.txtBank.Name = "txtBank";
            this.txtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBank.Size = new System.Drawing.Size(306, 25);
            this.txtBank.TabIndex = 251;
            // 
            // txtLetterKind
            // 
            this.txtLetterKind.Enabled = false;
            this.txtLetterKind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterKind.Location = new System.Drawing.Point(351, 87);
            this.txtLetterKind.Name = "txtLetterKind";
            this.txtLetterKind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterKind.Size = new System.Drawing.Size(273, 25);
            this.txtLetterKind.TabIndex = 250;
            // 
            // LetterId
            // 
            this.LetterId.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterId.Location = new System.Drawing.Point(119, 23);
            this.LetterId.Name = "LetterId";
            this.LetterId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LetterId.Size = new System.Drawing.Size(66, 22);
            this.LetterId.TabIndex = 248;
            this.LetterId.Visible = false;
            // 
            // txtvalue
            // 
            this.txtvalue.Enabled = false;
            this.txtvalue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalue.Location = new System.Drawing.Point(125, 147);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtvalue.Size = new System.Drawing.Size(202, 25);
            this.txtvalue.TabIndex = 252;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(262, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 22);
            this.label4.TabIndex = 243;
            this.label4.Text = "اخطار رد خطاب الضمان ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(558, 67);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 246;
            this.label3.Text = "نوع الخطاب";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(298, 67);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 245;
            this.label5.Text = "البنك";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(558, 127);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 244;
            this.label10.Text = "رقم الخطاب ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(259, 127);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 247;
            this.label14.Text = "مبلغ الخطاب";
            // 
            // cmbRecieveMethode
            // 
            this.cmbRecieveMethode.DataSource = this.tblRefundLettersReasonsBindingSource;
            this.cmbRecieveMethode.DisplayMember = "Name";
            this.cmbRecieveMethode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecieveMethode.FormattingEnabled = true;
            this.cmbRecieveMethode.Location = new System.Drawing.Point(21, 333);
            this.cmbRecieveMethode.Name = "cmbRecieveMethode";
            this.cmbRecieveMethode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbRecieveMethode.Size = new System.Drawing.Size(299, 27);
            this.cmbRecieveMethode.TabIndex = 269;
            this.cmbRecieveMethode.ValueMember = "ID";
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblRefundLettersReasonsBindingSource
            // 
            this.tblRefundLettersReasonsBindingSource.DataMember = "Tbl_RefundLettersReasons";
            this.tblRefundLettersReasonsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_RefundLettersReasonsTableAdapter
            // 
            this.tbl_RefundLettersReasonsTableAdapter.ClearBeforeFill = true;
            // 
            // NotificationLetterWFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 430);
            this.Controls.Add(this.cmbRecieveMethode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtFYear);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTenderNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPurchMethode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MskExpandLastDate);
            this.Controls.Add(this.MskFirstExpandDate);
            this.Controls.Add(this.MskStartDate);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.txtLetterKindID);
            this.Controls.Add(this.txtLetterFullNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcurrency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.txtLetterKind);
            this.Controls.Add(this.LetterId);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.dTPNotificationDate);
            this.Controls.Add(this.label9);
            this.Name = "NotificationLetterWFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NotificationLetterWFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRefundLettersReasonsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtFYear;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtTenderNo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPurchMethode;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox MskExpandLastDate;
        public System.Windows.Forms.DateTimePicker MskFirstExpandDate;
        public System.Windows.Forms.DateTimePicker MskStartDate;
        public DevExpress.XtraEditors.RadioGroup radioGroup1;
        public System.Windows.Forms.TextBox txtLetterKindID;
        public System.Windows.Forms.TextBox txtLetterFullNo;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtcurrency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtBank;
        public System.Windows.Forms.TextBox txtLetterKind;
        public System.Windows.Forms.TextBox LetterId;
        public System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.DateTimePicker dTPNotificationDate;
        public System.Windows.Forms.ComboBox cmbRecieveMethode;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblRefundLettersReasonsBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_RefundLettersReasonsTableAdapter tbl_RefundLettersReasonsTableAdapter;
    }
}