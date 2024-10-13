namespace FinancialSysApp.Forms.ProcessingForms
{
    partial class FindAssays
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.assaysSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new FinancialSysApp.DataSet1();
            this.orderAssaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assaysSearchTableAdapter = new FinancialSysApp.DataSet1TableAdapters.AssaysSearchTableAdapter();
            this.orderAssaysTableAdapter = new FinancialSysApp.DataSet1TableAdapters.OrderAssaysTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمالمقايسةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.تاريخالمقايسةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.نوعالمقايسةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.المقاولDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الإدارةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrderManagement = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.assaysSearchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderAssaysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // assaysSearchBindingSource
            // 
            this.assaysSearchBindingSource.DataMember = "AssaysSearch";
            this.assaysSearchBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderAssaysBindingSource
            // 
            this.orderAssaysBindingSource.DataMember = "OrderAssays";
            this.orderAssaysBindingSource.DataSource = this.dataSet1;
            // 
            // assaysSearchTableAdapter
            // 
            this.assaysSearchTableAdapter.ClearBeforeFill = true;
            // 
            // orderAssaysTableAdapter
            // 
            this.orderAssaysTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 19);
            this.label1.TabIndex = 186;
            this.label1.Text = "البحث عن المقايسات (أدخل رقم المقايسة)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.رقمالمقايسةDataGridViewTextBoxColumn,
            this.تاريخالمقايسةDataGridViewTextBoxColumn,
            this.نوعالمقايسةDataGridViewTextBoxColumn,
            this.المقاولDataGridViewTextBoxColumn,
            this.الإدارةDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.assaysSearchBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(41)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(12, 79);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Size = new System.Drawing.Size(629, 156);
            this.dataGridView1.TabIndex = 185;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // رقمالمقايسةDataGridViewTextBoxColumn
            // 
            this.رقمالمقايسةDataGridViewTextBoxColumn.DataPropertyName = "رقم المقايسة";
            this.رقمالمقايسةDataGridViewTextBoxColumn.HeaderText = "رقم المقايسة";
            this.رقمالمقايسةDataGridViewTextBoxColumn.Name = "رقمالمقايسةDataGridViewTextBoxColumn";
            this.رقمالمقايسةDataGridViewTextBoxColumn.Width = 120;
            // 
            // تاريخالمقايسةDataGridViewTextBoxColumn
            // 
            this.تاريخالمقايسةDataGridViewTextBoxColumn.DataPropertyName = "تاريخ المقايسة";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.تاريخالمقايسةDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.تاريخالمقايسةDataGridViewTextBoxColumn.HeaderText = "تاريخ المقايسة";
            this.تاريخالمقايسةDataGridViewTextBoxColumn.Name = "تاريخالمقايسةDataGridViewTextBoxColumn";
            this.تاريخالمقايسةDataGridViewTextBoxColumn.Width = 120;
            // 
            // نوعالمقايسةDataGridViewTextBoxColumn
            // 
            this.نوعالمقايسةDataGridViewTextBoxColumn.DataPropertyName = "نوع المقايسة";
            this.نوعالمقايسةDataGridViewTextBoxColumn.HeaderText = "نوع المقايسة";
            this.نوعالمقايسةDataGridViewTextBoxColumn.Name = "نوعالمقايسةDataGridViewTextBoxColumn";
            this.نوعالمقايسةDataGridViewTextBoxColumn.Width = 120;
            // 
            // المقاولDataGridViewTextBoxColumn
            // 
            this.المقاولDataGridViewTextBoxColumn.DataPropertyName = "المقاول";
            this.المقاولDataGridViewTextBoxColumn.HeaderText = "المقاول";
            this.المقاولDataGridViewTextBoxColumn.Name = "المقاولDataGridViewTextBoxColumn";
            this.المقاولDataGridViewTextBoxColumn.Width = 300;
            // 
            // الإدارةDataGridViewTextBoxColumn
            // 
            this.الإدارةDataGridViewTextBoxColumn.DataPropertyName = "الإدارة";
            this.الإدارةDataGridViewTextBoxColumn.HeaderText = "الإدارة";
            this.الإدارةDataGridViewTextBoxColumn.Name = "الإدارةDataGridViewTextBoxColumn";
            this.الإدارةDataGridViewTextBoxColumn.Width = 300;
            // 
            // txtOrderManagement
            // 
            this.txtOrderManagement.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderManagement.Location = new System.Drawing.Point(416, 47);
            this.txtOrderManagement.Name = "txtOrderManagement";
            this.txtOrderManagement.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrderManagement.Size = new System.Drawing.Size(225, 26);
            this.txtOrderManagement.TabIndex = 184;
            this.txtOrderManagement.TextChanged += new System.EventHandler(this.txtOrderManagement_TextChanged);
            this.txtOrderManagement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderManagement_KeyDown);
            // 
            // FindAssays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 242);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtOrderManagement);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FindAssays";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "البحث عن المقايسات";
            this.Load += new System.EventHandler(this.FindAssays_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindAssays_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.assaysSearchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderAssaysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource assaysSearchBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource orderAssaysBindingSource;
        private DataSet1TableAdapters.AssaysSearchTableAdapter assaysSearchTableAdapter;
        private DataSet1TableAdapters.OrderAssaysTableAdapter orderAssaysTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رقمالمقايسةDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn تاريخالمقايسةDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn نوعالمقايسةDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn المقاولDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الإدارةDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtOrderManagement;
    }
}