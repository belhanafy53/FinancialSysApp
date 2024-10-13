using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialSysApp.Classes;
using DevExpress.CodeParser;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class DocumentCategoryNFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        //int Vint_ItemId;
        //int Vint_ItemChildId;
        int Vint_Parent_ID = 0;
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        public DocumentCategoryNFrm()
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
            string Sql = "Select * From Tbl_DocumentCategory";
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch, string StoreCode)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'|| " + StoreCode + " ='" + TxtSearch + "'");

            return Sql;
        }

        private void DocumentCategoryNFrm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "StoreCode");
            }
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_DocumentCategory' table. You can move, or remove it, as needed.
            this.tbl_DocumentCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentCategory);
            Nametxt.Focus();

        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            //var list = FsDb.Tbl_DocumentCategory.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
            //radTreeView1.DataSource = list;

            //if (list.Count() == 0)
            //{
            //    textBox1.Text = Nametxt.Text;
            //}
            //if (Nametxt.Text == "")
            //{
            //    //textBox1.Text = "";
            //}
            //radTreeView1.ExpandAll();
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 14 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("برجاء ادخال البند المراد اضافته");
                }
                else
                {

                    if (Vint_IdItem == 0)
                    {

                        //int Vint_itemcategoryid = 0;
                        

                        Tbl_DocumentCategory Itm = new Tbl_DocumentCategory
                        {
                            Name = textBox1.Text,
                            Parent_ID = null,
                           
                        };
                        FsDb.Tbl_DocumentCategory.Add(Itm);
                        FsDb.SaveChanges();


                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند",
                            TableName = "Tbl_DocumentCategory",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البيان"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        TreeNode node = new TreeNode();
                        node.Text = textBox1.Text;
                        node.Name = Vint_IdItem.ToString();
                        node.Tag = Vint_LastRow.ToString();
                        node.Expand();
                        treeView1.Nodes.Add(node);
                        MessageBox.Show("تم الاضافه");
                        
                        textBox1.Text = "";

                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                        //***************************

                    }
                    else
                    {


                        Tbl_DocumentCategory Itm = new Tbl_DocumentCategory
                        {
                            Name = textBox1.Text,
                            Parent_ID = Vint_IdItem 
                            
                        };
                        FsDb.Tbl_DocumentCategory.Add(Itm);
                        FsDb.SaveChanges();
                        //grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند",
                            TableName = "Tbl_DocumentCategory",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البيان"
                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************

                        TreeNode node1 = new TreeNode();

                        node1.Text =textBox1.Text;
                        node1.Name = Vint_IdItem.ToString();
                        node1.Tag = Vint_LastRow.ToString();
                        node1.Expand();
                        treeView1.SelectedNode.Nodes.Add(node1);

                        MessageBox.Show("تم الاضافه");
                        textBox1.Text = "";
                       
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    treeView1.Refresh();

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  بيان .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 14 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا بيان  ؟", "حدف بيان " + " " + treeView1.SelectedNode.Text, MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                   
                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());

                  var listCheqDel =  FsDb.Tbl_RestrictionItemsCategory_With_AccountNumber.Where(x => x.Descrption == Vint_IdItem).ToList();
                    if (listCheqDel.Count != 0)
                    {
                        MessageBox.Show("لايمكن حذف هذا البيان لربطه مع تصنيف بنود القيد"); 
                    }
                    else
                    {
                        var ListCheckDelete = FsDb.Tbl_DocumentCategory.FirstOrDefault(x => x.Parent_ID == Vint_IdItem);
                        if (ListCheckDelete == null)
                        {

                            var listDelete = FsDb.Tbl_DocumentCategory.FirstOrDefault(x => x.ID == Vint_IdItem);
                            if (listDelete != null)
                            {
                                FsDb.Tbl_DocumentCategory.Remove(listDelete);
                                FsDb.SaveChanges();

                                textBox1.Text = "";
                                //---------------خفظ ااحداث 
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف بيان",
                                    TableName = "Tbl_DocumentCategory",
                                    TableRecordId = listDelete.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة البيان"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                treeView1.Nodes.Remove(treeView1.SelectedNode);
                                //treeView1.ExpandAll();
                                //************************************

                                MessageBox.Show("  تم الحذف");
                                textBox1.Select();
                                this.ActiveControl = textBox1;
                                textBox1.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("لايمكن حذف هدا البند لاحتوائه على بنود تابعه له قم بحدف تلك البنود اولا");
                        }
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string searchText = this.Nametxt.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                textBox1.Focus();
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
            var listItem = FsDb.Tbl_DocumentCategory.FirstOrDefault(x => x.ID == Vint_IdItem);

            Vstr_Name = listItem.Name;
            textBox1.Text = Vstr_Name;

            groupBox2.Text = ViewTree.SelectFullHirachyDocumCategory(treeView1, Vint_IdItem, Vint_Parent_ID);

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 14 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (Vint_IdItem != null && textBox1.Text != "")
                {
                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());

                    
                   
                    var listupdate = FsDb.Tbl_DocumentCategory.FirstOrDefault(x => x.ID == Vint_IdItem);
                    listupdate.Name = textBox1.Text;
                    
                    FsDb.SaveChanges();


                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل بيان",
                        TableName = "Tbl_DocumentCategory",
                        TableRecordId = Vint_IdItem.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة البيان"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    TreeNode node = new TreeNode();
                    node.Text = textBox1.Text;
                    node.Name = Vint_Parent_ID.ToString();
                    node.Tag = Vint_IdItem.ToString();
                    node.Expand();

                    treeView1.SelectedNode.Text = textBox1.Text;
                    MessageBox.Show("تم التعديل");
                    //grbNodeSelected.Text = "";
                    textBox1.Text = "";

                    textBox1.Select();
                    this.ActiveControl = textBox1;
                    textBox1.Focus();
                    //***************************

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل  بيان .. برجاء مراجعة مدير المنظومه");
                }
            }
        }
    }
}