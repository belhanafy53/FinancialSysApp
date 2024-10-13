using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevExpress.Xpo.DB.Helpers;

namespace FinancialSysApp.Forms.DocumentsArchiving
{
    public partial class DocumentsArchHirarchyFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        string Vstr_fullName = "";
        int Vint_Parent_ID = 0;
        int Vint_orderKind = 0;
        //******* Tree View
        private List<TreeNode> CurrentNodeMatches = new List<TreeNode>();
        private int LastNodeIndex = 0;
        private string LastSearchText;
        //***************
        private void SearchNodes(string SearchText, TreeNode StartNode)
        {
            //TreeNode node = null;
            while (StartNode != null)
            {
                if (StartNode.Text.Trim().Contains(SearchText.Trim()))
                {
                    CurrentNodeMatches.Add(StartNode);
                }
                if (StartNode.Nodes.Count != 0)
                {
                    SearchNodes(SearchText, StartNode.Nodes[0]);
                }
                StartNode = StartNode.NextNode;
            }
        }
         
        string SelectTreeTable(int OKID)
        {

            int DocumentProcessID = OKID;
           
            //string Sql = "Select * From  Tbl_DocumentHirarchy Where Name = @tt";
            string Sql = "select * from Tbl_DocumentHirarchy where Tbl_DocumentHirarchy.DocumentProcessID = " + @DocumentProcessID;
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }

        public DocumentsArchHirarchyFrm()
        {
            InitializeComponent();
        }
     
     
        private void DocumentsArchHirarchyFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysEventsDataSet3.Tbl_DocumentProcess' table. You can move, or remove it, as needed.
            this.tbl_DocumentProcessTableAdapter.Fill(this.financialSysEventsDataSet3.Tbl_DocumentProcess);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_OrderKind' table. You can move, or remove it, as needed.
            this.tbl_OrderKindTableAdapter.Fill(this.financialSysDataSet.Tbl_OrderKind);
            
           
            CmbOrderKind.SelectedIndex = -1;
            CmbOrderKind.Text = "";
            CmbOrderKind.SelectedText = "اختر العمليه";
            Nametxt.Text = "";
            CmbOrderKind.Select();
            this.ActiveControl = CmbOrderKind;
            CmbOrderKind.Focus();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string searchText = this.Nametxt.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                txtSelected.Focus();
            }
            else
            {
                if (LastSearchText != searchText)
                {
                    // It's a New Search
                    CurrentNodeMatches.Clear();
                    LastSearchText = searchText;
                    LastNodeIndex = 0;
                    SearchNodes(searchText, treeView1.Nodes[0]);
                }
                if (LastNodeIndex >= 0 && CurrentNodeMatches.Count > 0 && LastNodeIndex < CurrentNodeMatches.Count)
                {
                    TreeNode SelectedNode = CurrentNodeMatches[LastNodeIndex];
                    LastNodeIndex++;
                    this.treeView1.SelectedNode = SelectedNode;
                    this.treeView1.SelectedNode.Expand();
                    this.treeView1.Select();

                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);

            Vstr_Name = treeView1.SelectedNode.Text;
            txtSelected.Text = Vstr_Name;

            grbNodeSelected.Text = ViewTree.SelectFullHirachyDocumentArch(treeView1, Vint_IdItem, Vint_Parent_ID);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 73 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (txtSelected.Text == null)
                {
                    MessageBox.Show("برجاء ادخال التصنيف المراد اضافته");
                }
                else
                {

                    if (Vint_IdItem == 0)
                    {

                         
                        if (grbNodeSelected.Text == "")
                        { Vstr_fullName =  txtSelected.Text; }
                        else
                        { Vstr_fullName = grbNodeSelected.Text + "" +"-" + "" + txtSelected.Text; }

                        Tbl_DocumentHirarchy Itm = new Tbl_DocumentHirarchy
                        {
                            Name = txtSelected.Text,
                            Note = Vstr_fullName,
                            DocumentProcessID = Vint_orderKind
                        };
                        FsEvDb.Tbl_DocumentHirarchy.Add(Itm);
                        FsEvDb.SaveChanges();


                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة تصنيف مستند",
                            TableName = "Tbl_DocumentHirarchy",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة تصنيف مستندات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        TreeNode node = new TreeNode();
                        node.Text = txtSelected.Text;
                        node.Name = Vint_IdItem.ToString();
                        node.Tag = Vint_LastRow.ToString();

                        treeView1.Nodes.Add(node);
                        node.Expand();
                        MessageBox.Show("تم الاضافه");
                        grbNodeSelected.Text = "";
                        txtSelected.Text = "";

                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                        //***************************

                    }
                    else
                    {

                        if (grbNodeSelected.Text == "")
                        { Vstr_fullName = txtSelected.Text; }
                        else
                        { Vstr_fullName = grbNodeSelected.Text + "" + "-" + "" + txtSelected.Text; ; }

                        Tbl_DocumentHirarchy Itm = new Tbl_DocumentHirarchy
                        {
                            Name = txtSelected.Text,
                            Parent_ID = Vint_IdItem,
                            DocumentProcessID = Vint_orderKind,
                            Note = Vstr_fullName


                        };
                        FsEvDb.Tbl_DocumentHirarchy.Add(Itm);
                        FsEvDb.SaveChanges();
                        //grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة تصنيف مستند",
                            TableName = "Tbl_DocumentHirarchy",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة تصنيف مستندات"
                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************

                        TreeNode node1 = new TreeNode();

                        node1.Text = txtSelected.Text;
                        node1.Name = Vint_IdItem.ToString();
                        node1.Tag = Vint_LastRow.ToString();
                        node1.Expand();
                        treeView1.SelectedNode.Nodes.Add(node1);

                        MessageBox.Show("تم الاضافه");
                        txtSelected.Text = "";

                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                    }
                    treeView1.Refresh();

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  تصنيف مستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 73 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (Vint_IdItem != 0 && txtSelected.Text != "")
                {
                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());

                    

                    var listupdate = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);
                    listupdate.Name = txtSelected.Text;
                    listupdate.DocumentProcessID = Vint_orderKind;

                    FsEvDb.SaveChanges();
                    if (listupdate.Parent_ID != null)

                    {
                        Vint_Parent_ID = int.Parse(listupdate.Parent_ID.ToString());
                        listupdate.Note = ViewTree.SelectFullHirachyOrderPurpose(treeView1, Vint_IdItem, Vint_Parent_ID);
                    }
                    else
                    {
                        listupdate.Note = txtSelected.Text;
                    }
                    FsEvDb.SaveChanges();
                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل تصنيف مستند",
                        TableName = "Tbl_DocumentHirarchy",
                        TableRecordId = Vint_IdItem.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة تصنيف مستندات"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    TreeNode node = new TreeNode();
                    node.Text = txtSelected.Text;
                    node.Name = Vint_Parent_ID.ToString();
                    node.Tag = Vint_IdItem.ToString();
                    node.Expand();

                    treeView1.SelectedNode.Text = txtSelected.Text;
                    MessageBox.Show("تم التعديل");
                    //grbNodeSelected.Text = "";
                    txtSelected.Text = "";

                    txtSelected.Select();
                    this.ActiveControl = txtSelected;
                    txtSelected.Focus();
                    //***************************

                }

            }
            else
            {
               MessageBox.Show("ليس لديك صلاحية تعديل  تصنيف مستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 73 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا التصنيف   ؟", "حدف تصنيف مستند " + " " + treeView1.SelectedNode.Text, MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());


                    var ListCheckDelete = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.Parent_ID == Vint_IdItem);
                    if (ListCheckDelete == null)
                    {

                        var listDelete = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);
                        if (listDelete != null)
                        {
                            FsEvDb.Tbl_DocumentHirarchy.Remove(listDelete);
                            FsEvDb.SaveChanges();
                            grbNodeSelected.Text = "";
                            txtSelected.Text = "";
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف تصنيف مستند",
                                TableName = "Tbl_DocumentHirarchy",
                                TableRecordId = listDelete.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة تصنيف مستندات"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            treeView1.Nodes.Remove(treeView1.SelectedNode);
                            //treeView1.ExpandAll();
                            //************************************

                            MessageBox.Show("  تم الحذف");
                            txtSelected.Select();
                            this.ActiveControl = txtSelected;
                            txtSelected.Focus();
                        }
                    }

                    else
                    {
                        MessageBox.Show("لايمكن حذف هدا التصنيف لاحتوائه على بنود تابعه له قم بحدف تلك البنود اولا");
                    }

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  تصنيف مستند .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                grbNodeSelected.Text = "";
                txtSelected.Text = "";
                Vint_IdItem = 0;

            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }

        private void simpleButton3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                treeView1.Focus();
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSelected.Focus();
            }
        }

        private void txtSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void CmbOrderKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(Program.GlbV_EVConnection))
            {
                Vint_orderKind = int.Parse(CmbOrderKind.SelectedValue.ToString());
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(Vint_orderKind), "ID", "Name", "Parent_ID", "Name");
            }
            treeView1.ExpandAll();
            grbNodeSelected.Text = "";

        }

        private void CmbOrderKind_SelectedValueChanged(object sender, EventArgs e)
        {
            grpBOrderKind.Text = "";
            grbNodeSelected.Text = "";
            grpBOrderKind.Text = "العملية :  " + " " + CmbOrderKind.Text.ToString();
          
        }

        private void CmbOrderKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nametxt.Focus();
            }
        }
    }
}