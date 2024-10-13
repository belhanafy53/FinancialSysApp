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

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class ResponspilityCentersFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_Parent_ID = 0;
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        public ResponspilityCentersFrm()
        {
            InitializeComponent();
        }
        private List<TreeNode> CurrentNodeMatches = new List<TreeNode>();
        private int LastNodeIndex = 0;
        private string LastSearchText;
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
        string SelectTreeTable()
        {
            string Sql = "Select * From Tbl_ResponspilityCenters";
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch, string StoreCode)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'|| " + StoreCode + " ='" + TxtSearch + "'");

            return Sql;
        }

        private void ResponspilityCentersFrm_Load(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "StoreCode");
            }

            searchText.Text = "";
            searchText.Select();
            this.ActiveControl = searchText;
            searchText.Focus();
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (searchText.Text == "")
            {
                grbNodeSelected.Text = "";
                txtSelected.Text = "";
                Vint_IdItem = 0;

            }
        }
   
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 40 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    var result1 = MessageBox.Show("هل تريد حدف هدا المركز  ؟", "حدف مركز  " + " " + treeView1.SelectedNode.Text, MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {

                        Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());


                        var ListCheckDelete = FsDb.Tbl_ResponspilityCenters.FirstOrDefault(x => x.Parent_ID == Vint_IdItem);
                        if (ListCheckDelete == null)
                        {

                            var listDelete = FsDb.Tbl_ResponspilityCenters.FirstOrDefault(x => x.ID == Vint_IdItem);
                            if (listDelete != null)
                            {
                                FsDb.Tbl_ResponspilityCenters.Remove(listDelete);
                                FsDb.SaveChanges();
                                grbNodeSelected.Text = "";
                                txtSelected.Text = "";
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف مركز",
                                    TableName = "Tbl_ResponspilityCenters",
                                    TableRecordId = listDelete.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة مراكز المسؤلية"


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
                            MessageBox.Show("لايمكن حذف هدا المركز لاحتوائه على مراكز تابعه له قم بحدف تلك البنود اولا");
                        }
                        // Clears all nodes.  
                        //treeView1.Nodes.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  بند .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المركز لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
      

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsDb.Tbl_ResponspilityCenters.FirstOrDefault(x => x.ID == Vint_IdItem);

            Vstr_Name = listItem.Name;
            txtSelected.Text = Vstr_Name;

            grbNodeSelected.Text = ViewTree.SelectFullHirachyResponspilityCenters(treeView1, Vint_IdItem, Vint_Parent_ID);
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 40 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (Vint_IdItem != null && txtSelected.Text != "")
                {
                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());

                    //int Vint_itemcategoryid = 0;
                   
                    var listupdate = FsDb.Tbl_ResponspilityCenters.FirstOrDefault(x => x.ID == Vint_IdItem);
                    listupdate.Name = txtSelected.Text;
                    
                    
                    FsDb.SaveChanges();


                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل مركز",
                        TableName = "Tbl_ResponspilityCenters",
                        TableRecordId = Vint_IdItem.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة مراكز المسؤلية"


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

                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل  مركز مسؤلية .. برجاء مراجعة مدير المنظومه");
                }
            }
        }

        

        private void txtSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 40 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (txtSelected.Text == null)
                {
                    MessageBox.Show("برجاء ادخال المركز المراد اضافته");
                }
                else
                {

                    if (Vint_IdItem == 0)
                    {

                        int Vint_itemcategoryid = 0;


                        Tbl_ResponspilityCenters Itm = new Tbl_ResponspilityCenters
                        {
                            Name = txtSelected.Text,
                            Parent_ID = null


                        };
                        FsDb.Tbl_ResponspilityCenters.Add(Itm);
                        FsDb.SaveChanges();


                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مركز",
                            TableName = "Tbl_ResponspilityCenters",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراكز المسؤلية"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        TreeNode node = new TreeNode();
                        node.Text = txtSelected.Text;
                        node.Name = Vint_IdItem.ToString();
                        node.Tag = Vint_LastRow.ToString();
                        node.Expand();
                        treeView1.Nodes.Add(node);
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


                        Tbl_ResponspilityCenters Itm = new Tbl_ResponspilityCenters
                        {
                            Name = txtSelected.Text,
                            Parent_ID = Vint_IdItem

                        };
                        FsDb.Tbl_ResponspilityCenters.Add(Itm);
                        FsDb.SaveChanges();
                        //grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مركز",
                            TableName = "Tbl_ResponspilityCenters",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراكز المسؤلية"
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
                MessageBox.Show("ليس لديك صلاحية اضافة  مركز .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }

       

       

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string searchText = this.searchText.Text;

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

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }
    }
}
