namespace FinancialSysApp.Forms
{
    partial class Workers
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tbl_HummanResourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSectores = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSectore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagementName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkerJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblHead = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_HummanResourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.AllowDrop = true;
            this.gridControl1.DataSource = this.tbl_HummanResourceBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1286, 388);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tbl_HummanResourceBindingSource
            // 
            this.tbl_HummanResourceBindingSource.DataSource = typeof(FinancialSysApp.DataBase.Model.Tbl_HummanResource);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colNationalID,
            this.colSectores,
            this.colSectore,
            this.colManagementName,
            this.colManagementDate,
            this.colWorkerJob,
            this.colJobDate,
            this.colStatus,
            this.colStatusDetail,
            this.colStatusDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "الاسم";
            this.colName.FieldName = "Name";
            this.colName.MaxWidth = 250;
            this.colName.MinWidth = 10;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 247;
            // 
            // colNationalID
            // 
            this.colNationalID.Caption = "الرقم القومي";
            this.colNationalID.FieldName = "NationalID";
            this.colNationalID.MinWidth = 10;
            this.colNationalID.Name = "colNationalID";
            this.colNationalID.Visible = true;
            this.colNationalID.VisibleIndex = 1;
            this.colNationalID.Width = 100;
            // 
            // colSectores
            // 
            this.colSectores.Caption = "قطاعات";
            this.colSectores.FieldName = "Sectores";
            this.colSectores.MinWidth = 10;
            this.colSectores.Name = "colSectores";
            this.colSectores.Visible = true;
            this.colSectores.VisibleIndex = 2;
            this.colSectores.Width = 104;
            // 
            // colSectore
            // 
            this.colSectore.Caption = "قطاع";
            this.colSectore.FieldName = "Sectore";
            this.colSectore.MinWidth = 10;
            this.colSectore.Name = "colSectore";
            this.colSectore.Visible = true;
            this.colSectore.VisibleIndex = 3;
            this.colSectore.Width = 52;
            // 
            // colManagementName
            // 
            this.colManagementName.Caption = "الادارة";
            this.colManagementName.FieldName = "ManagementName";
            this.colManagementName.MinWidth = 10;
            this.colManagementName.Name = "colManagementName";
            this.colManagementName.Visible = true;
            this.colManagementName.VisibleIndex = 4;
            this.colManagementName.Width = 98;
            // 
            // colManagementDate
            // 
            this.colManagementDate.Caption = "تاريخ الادارة";
            this.colManagementDate.FieldName = "ManagementDate";
            this.colManagementDate.MinWidth = 10;
            this.colManagementDate.Name = "colManagementDate";
            this.colManagementDate.Visible = true;
            this.colManagementDate.VisibleIndex = 5;
            this.colManagementDate.Width = 104;
            // 
            // colWorkerJob
            // 
            this.colWorkerJob.Caption = "الوظيفة";
            this.colWorkerJob.FieldName = "WorkerJob";
            this.colWorkerJob.MinWidth = 10;
            this.colWorkerJob.Name = "colWorkerJob";
            this.colWorkerJob.Visible = true;
            this.colWorkerJob.VisibleIndex = 6;
            this.colWorkerJob.Width = 67;
            // 
            // colJobDate
            // 
            this.colJobDate.Caption = "تاريخ الوظيفه";
            this.colJobDate.FieldName = "JobDate";
            this.colJobDate.MinWidth = 10;
            this.colJobDate.Name = "colJobDate";
            this.colJobDate.Visible = true;
            this.colJobDate.VisibleIndex = 7;
            this.colJobDate.Width = 129;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "الحالة";
            this.colStatus.FieldName = "Status";
            this.colStatus.MinWidth = 10;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;
            this.colStatus.Width = 129;
            // 
            // colStatusDetail
            // 
            this.colStatusDetail.Caption = "تفصيل الحاله";
            this.colStatusDetail.FieldName = "StatusDetail";
            this.colStatusDetail.MinWidth = 10;
            this.colStatusDetail.Name = "colStatusDetail";
            this.colStatusDetail.Visible = true;
            this.colStatusDetail.VisibleIndex = 10;
            this.colStatusDetail.Width = 136;
            // 
            // colStatusDate
            // 
            this.colStatusDate.Caption = "تاريخ الحاله";
            this.colStatusDate.FieldName = "StatusDate";
            this.colStatusDate.MinWidth = 10;
            this.colStatusDate.Name = "colStatusDate";
            this.colStatusDate.Visible = true;
            this.colStatusDate.VisibleIndex = 9;
            this.colStatusDate.Width = 95;
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.Location = new System.Drawing.Point(718, 9);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(85, 26);
            this.lblHead.TabIndex = 1;
            this.lblHead.Text = "الموظفين";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1212, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "اسم الموظفين";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(950, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(687, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(170, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(863, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "الوظيفة";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(381, 53);
            this.textBox3.Name = "textBox3";
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox3.Size = new System.Drawing.Size(254, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "الادارة";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "الحالة";
            // 
            // Workers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 505);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.gridControl1);
            this.Name = "Workers";
            this.Text = "Workers";
            this.Load += new System.EventHandler(this.Workers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_HummanResourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource tbl_HummanResourceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colManagementName;
        private DevExpress.XtraGrid.Columns.GridColumn colManagementDate;
        private DevExpress.XtraGrid.Columns.GridColumn colJobDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colSectores;
        private DevExpress.XtraGrid.Columns.GridColumn colSectore;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkerJob;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}