namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class FindItemNFrm
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
            this.label10 = new System.Windows.Forms.Label();
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.financialSysDataSet = new FinancialSysApp.FinancialSysDataSet();
            this.tblItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_ItemsTableAdapter = new FinancialSysApp.FinancialSysDataSetTableAdapters.Tbl_ItemsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(517, 43);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 84;
            this.label10.Text = "بحث ";
            // 
            // radTreeView1
            // 
            this.radTreeView1.AllowAdd = true;
            this.radTreeView1.AllowDragDrop = true;
            this.radTreeView1.AllowEdit = true;
            this.radTreeView1.BackColor = System.Drawing.SystemColors.Control;
            this.radTreeView1.CausesValidation = false;
            this.radTreeView1.CheckedMember = "ID";
            this.radTreeView1.ChildMember = "ID";
            this.radTreeView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radTreeView1.DataSource = this.tblItemsBindingSource;
            this.radTreeView1.DisplayMember = "Name";
            this.radTreeView1.ExpandAnimation = Telerik.WinControls.UI.ExpandAnimation.None;
            this.radTreeView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radTreeView1.ForeColor = System.Drawing.Color.Black;
            this.radTreeView1.FullRowSelect = false;
            this.radTreeView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.radTreeView1.ItemHeight = 25;
            this.radTreeView1.KeyboardSearchEnabled = true;
            this.radTreeView1.LineColor = System.Drawing.Color.PowderBlue;
            this.radTreeView1.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid;
            this.radTreeView1.Location = new System.Drawing.Point(12, 78);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.ParentMember = "Parent_ID";
            this.radTreeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.radTreeView1.RootElement.ApplyShapeToControl = false;
            this.radTreeView1.RootElement.BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.radTreeView1.ShowLines = true;
            this.radTreeView1.Size = new System.Drawing.Size(560, 369);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 86;
            this.radTreeView1.ThemeName = "ControlDefault";
            this.radTreeView1.ToggleMode = Telerik.WinControls.UI.ToggleMode.None;
            this.radTreeView1.ValueMember = "ID";
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(136, 39);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Nametxt.Size = new System.Drawing.Size(375, 22);
            this.Nametxt.TabIndex = 85;
            this.Nametxt.TextChanged += new System.EventHandler(this.Nametxt_TextChanged);
            // 
            // financialSysDataSet
            // 
            this.financialSysDataSet.DataSetName = "FinancialSysDataSet";
            this.financialSysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblItemsBindingSource
            // 
            this.tblItemsBindingSource.DataMember = "Tbl_Items";
            this.tblItemsBindingSource.DataSource = this.financialSysDataSet;
            // 
            // tbl_ItemsTableAdapter
            // 
            this.tbl_ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // FindItemNFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 475);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.radTreeView1);
            this.Controls.Add(this.Nametxt);
            this.Name = "FindItemNFrm";
            this.Text = "FindItemNFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindItemNFrm_FormClosed);
            this.Load += new System.EventHandler(this.FindItemNFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financialSysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private Telerik.WinControls.UI.RadTreeView radTreeView1;
        private System.Windows.Forms.TextBox Nametxt;
        private FinancialSysDataSet financialSysDataSet;
        private System.Windows.Forms.BindingSource tblItemsBindingSource;
        private FinancialSysDataSetTableAdapters.Tbl_ItemsTableAdapter tbl_ItemsTableAdapter;
    }
}