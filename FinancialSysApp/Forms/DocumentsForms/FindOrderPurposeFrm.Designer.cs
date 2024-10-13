namespace FinancialSysApp.Forms.DocumentsForms
{
    partial class FindOrderPurposeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindOrderPurposeFrm));
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.Nametxt = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.txtOrderPuprposeId = new System.Windows.Forms.TextBox();
            this.txtOrderKindId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblSelected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton5
            // 
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.ImageOptions.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(10, 66);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(53, 25);
            this.simpleButton5.TabIndex = 162;
            this.simpleButton5.Text = "بحث ";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // Nametxt
            // 
            this.Nametxt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nametxt.Location = new System.Drawing.Point(68, 67);
            this.Nametxt.Name = "Nametxt";
            this.Nametxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Nametxt.Size = new System.Drawing.Size(470, 25);
            this.Nametxt.TabIndex = 161;
            this.Nametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Nametxt.TextChanged += new System.EventHandler(this.Nametxt_TextChanged);
            this.Nametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nametxt_KeyDown);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(10, 98);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.SelectedImageIndex = 9;
            this.treeView1.Size = new System.Drawing.Size(528, 450);
            this.treeView1.TabIndex = 159;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-folder-30.png");
            this.imageList1.Images.SetKeyName(1, "icons8-opened-folder-30.png");
            this.imageList1.Images.SetKeyName(2, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(3, "icons8-general-ledger-40.png");
            this.imageList1.Images.SetKeyName(4, "icons8-opened-folder-48.png");
            this.imageList1.Images.SetKeyName(5, "icons8-opened-folder-100.png");
            this.imageList1.Images.SetKeyName(6, "icons8-folder-48.png");
            this.imageList1.Images.SetKeyName(7, "open-file.png");
            this.imageList1.Images.SetKeyName(8, "folder.png");
            this.imageList1.Images.SetKeyName(9, "open-folder.png");
            this.imageList1.Images.SetKeyName(10, "folders.png");
            this.imageList1.Images.SetKeyName(11, "folder (1).png");
            this.imageList1.Images.SetKeyName(12, "open-folder (1).png");
            this.imageList1.Images.SetKeyName(13, "folder (2).png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 163;
            this.label1.Text = "اغراض الاوامر";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSelected
            // 
            this.txtSelected.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtSelected.Enabled = false;
            this.txtSelected.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelected.ForeColor = System.Drawing.Color.Yellow;
            this.txtSelected.Location = new System.Drawing.Point(12, 563);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSelected.Size = new System.Drawing.Size(35, 26);
            this.txtSelected.TabIndex = 164;
            this.txtSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSelected.Visible = false;
            // 
            // txtOrderPuprposeId
            // 
            this.txtOrderPuprposeId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderPuprposeId.Location = new System.Drawing.Point(13, 12);
            this.txtOrderPuprposeId.Name = "txtOrderPuprposeId";
            this.txtOrderPuprposeId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrderPuprposeId.Size = new System.Drawing.Size(50, 26);
            this.txtOrderPuprposeId.TabIndex = 165;
            this.txtOrderPuprposeId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrderPuprposeId.Visible = false;
            // 
            // txtOrderKindId
            // 
            this.txtOrderKindId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderKindId.Location = new System.Drawing.Point(462, 20);
            this.txtOrderKindId.Name = "txtOrderKindId";
            this.txtOrderKindId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrderKindId.Size = new System.Drawing.Size(50, 26);
            this.txtOrderKindId.TabIndex = 166;
            this.txtOrderKindId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOrderKindId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 167;
            // 
            // LblSelected
            // 
            this.LblSelected.AutoSize = true;
            this.LblSelected.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblSelected.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSelected.ForeColor = System.Drawing.Color.Yellow;
            this.LblSelected.Location = new System.Drawing.Point(12, 562);
            this.LblSelected.Name = "LblSelected";
            this.LblSelected.Size = new System.Drawing.Size(17, 24);
            this.LblSelected.TabIndex = 168;
            this.LblSelected.Text = "-";
            // 
            // FindOrderPurposeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 601);
            this.Controls.Add(this.LblSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrderKindId);
            this.Controls.Add(this.txtOrderPuprposeId);
            this.Controls.Add(this.txtSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.Nametxt);
            this.Controls.Add(this.treeView1);
            this.Name = "FindOrderPurposeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FindOrderPurposeFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private System.Windows.Forms.TextBox Nametxt;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtSelected;
        public System.Windows.Forms.TextBox txtOrderPuprposeId;
        public System.Windows.Forms.TextBox txtOrderKindId;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblSelected;
    }
}