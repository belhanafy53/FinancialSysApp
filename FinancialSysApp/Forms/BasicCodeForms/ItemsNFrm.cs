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
    public partial class ItemsNFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();

        int Vint_Parent_ID = 0;
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        public ItemsNFrm()
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
            string Sql = "Select * From Tbl_Items";
            return Sql;
        }                                                  
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch,string StoreCode)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'|| "+ StoreCode + " ='" +TxtSearch+ "'");

            return Sql;
        }

        private void ItemsNFrm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID","StoreCode" );
            }

            cmbSelected.SelectedIndex = 0;
            cmbItemStatus.DataSource = FsDb.Tbl_ItemNewUsedNonUsed.ToList();
            cmbItemStatus.DisplayMember = "Name";
            cmbItemStatus.ValueMember = "ID";
            Nametxt.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
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
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_IdItem);

            if (listItem != null)
            {
                Vstr_Name = listItem.Name;
                txtSelected.Text = Vstr_Name;

                grbNodeSelected.Text = ViewTree.SelectFullHirachyItem(treeView1, Vint_IdItem, Vint_Parent_ID);
                txtStoreCode.Text = listItem.StoreCode;
                if (listItem.CableTube == 1 )
                {
                    checkBox1.Checked = true;
                }
                else if (listItem.CableTube == 2)
                {
                    checkBox2.Checked = true;
                }

                if (listItem.CableExption == true)
                {
                    checkBox3.Checked = true;
                }
            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                int Vint_CableTube = 0;
                bool vbl_cablexception = false;
                if (txtSelected.Text == null)
                {
                    MessageBox.Show("برجاء ادخال البند المراد اضافته");
                }
                else
                {
                    string Vst_Name = "";
                    if (grbNodeSelected.Text == "")
                    {
                        Vst_Name = txtSelected.Text;
                    }
                    else
                    {
                        Vst_Name = grbNodeSelected.Text + " - " + txtSelected.Text;
                    }
                    if (Vint_IdItem == 0)
                    {
                       
                        int Vint_itemcategoryid = 0;
                        if (cmbSelected.SelectedIndex != -1)
                        {
                            Vint_itemcategoryid = int.Parse(cmbSelected.SelectedIndex.ToString());
                        }
                       if (checkBox1.Checked == true)
                        {
                            Vint_CableTube = 1;
                        }
                       else if (checkBox2.Checked == true)
                        {
                            Vint_CableTube = 2;
                        }
                       if (checkBox3.Checked == true)
                        {
                            vbl_cablexception = true;
                        }
                       else if (checkBox3.Checked == false)
                        {
                            vbl_cablexception = false;
                        }

                        Tbl_Items Itm = new Tbl_Items
                        {
                            Name = txtSelected.Text,
                            Parent_ID = null,
                            ItemCategoryID = Vint_itemcategoryid,
                            SystemUnitesID = Program.GlbV_SysUnite_ID,
                            StoreCode = txtStoreCode.Text,
                            ItemNewUsedNonUsed = int.Parse(cmbItemStatus.SelectedValue.ToString()),
                            Note = Vst_Name,
                            CableTube = Vint_CableTube,
                            CableExption = vbl_cablexception
                        };
                        FsDb.Tbl_Items.Add(Itm);
                        FsDb.SaveChanges();


                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند",
                            TableName = "Tbl_Items",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنود"


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
                        txtStoreCode.Text = "";
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                        //***************************

                    }
                    else
                    {
                        if (checkBox1.Checked == true)
                        {
                            Vint_CableTube = 1;
                        }
                        else if (checkBox2.Checked == true)
                        {
                            Vint_CableTube = 2;
                        }
                        if (checkBox3.Checked == true)
                        {
                            vbl_cablexception = true;
                        }

                        Tbl_Items Itm = new Tbl_Items
                        {
                            Name = txtSelected.Text,
                            Parent_ID = Vint_IdItem,
                            ItemCategoryID = int.Parse(cmbSelected.SelectedIndex.ToString()),
                            SystemUnitesID = Program.GlbV_SysUnite_ID,
                            StoreCode = txtStoreCode.Text,
                            ItemNewUsedNonUsed = int.Parse(cmbItemStatus.SelectedValue.ToString()),
                            Note = Vst_Name,
                            CableTube = Vint_CableTube,
                            CableExption = vbl_cablexception
                        };
                        FsDb.Tbl_Items.Add(Itm);
                        FsDb.SaveChanges();
                        //grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند",
                            TableName = "Tbl_Items",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنود"
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
                        txtStoreCode.Text = "";
                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                    }
                    treeView1.Refresh();

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا البند  ؟", "حدف بند " + " " + treeView1.SelectedNode.Text, MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());


                    var ListCheckDelete = FsDb.Tbl_Items.FirstOrDefault(x => x.Parent_ID == Vint_IdItem);
                    if (ListCheckDelete == null)
                    {

                        var listDelete = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_IdItem);
                        if (listDelete != null)
                        {
                            FsDb.Tbl_Items.Remove(listDelete);
                            FsDb.SaveChanges();
                            grbNodeSelected.Text = "";
                            txtSelected.Text = "";
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف بند",
                                TableName = "Tbl_Items",
                                TableRecordId = listDelete.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة البنود"


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
                        MessageBox.Show("لايمكن حذف هدا البند لاحتوائه على بنود تابعه له قم بحدف تلك البنود اولا");
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

        private void txtSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSelected.Focus();
            }

        }

        private void cmbSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStoreCode.Focus();
            }
        }

        private void txtStoreCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            txtSelected.Focus();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSelected.Focus();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (Vint_IdItem != 0 && txtSelected.Text != "")
                {
                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
                   
                    int Vint_itemcategoryid = 0;
                    if (cmbSelected.SelectedIndex != -1)
                    {
                        Vint_itemcategoryid = int.Parse(cmbSelected.SelectedIndex.ToString());
                    }
                    var listupdate = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_IdItem);
                    string Vst_Name = "";
                    if (grbNodeSelected.Text == "" && listupdate.Parent_ID == null)
                    {
                        Vst_Name = txtSelected.Text;
                    }
                    else if (grbNodeSelected.Text != "" && listupdate.Parent_ID != null)
                    {
                        Vst_Name = grbNodeSelected.Text + " - " + txtSelected.Text;
                    }
                    if (checkBox1.Checked == true)
                    {
                        listupdate.CableTube = 1;
                    }
                    else if (checkBox2.Checked == true)
                    {
                        listupdate.CableTube = 2;
                    }
                    if (checkBox3.Checked == true)
                    {
                        listupdate.CableExption = true;
                    }
                    else if (checkBox3.Checked == false)
                    {
                        listupdate.CableExption = false;
                    }
                    listupdate.Name = txtSelected.Text;
                    listupdate.ItemCategoryID = Vint_itemcategoryid;
                    listupdate.SystemUnitesID = Program.GlbV_SysUnite_ID;
                    listupdate.StoreCode = txtStoreCode.Text;
                    listupdate.ItemNewUsedNonUsed = int.Parse(cmbItemStatus.SelectedValue.ToString());
                    listupdate.Note = Vst_Name;
                    FsDb.SaveChanges();


                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل بند",
                        TableName = "Tbl_Items",
                        TableRecordId = Vint_IdItem.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة البنود"


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
                    txtStoreCode.Text = "";
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    txtSelected.Select();
                    this.ActiveControl = txtSelected;
                    txtSelected.Focus();
                    //***************************

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل  بند .. برجاء مراجعة مدير المنظومه");
                }
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

        private void txtStoreCode_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_Items.Where(x => x.StoreCode.Contains(txtStoreCode.Text)).ToList();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "البند";
            dataGridView1.Columns["StoreCode"].HeaderText = "كود المخزن";
            dataGridView1.Columns["ItemNewUsedNonUsed"].Visible = false;
            dataGridView1.Columns["Note"].Visible = false;
            dataGridView1.Columns["SystemUnitesID"].Visible = false;
            dataGridView1.Columns["ItemCategoryID"].Visible = false;
            dataGridView1.Columns["Parent_ID"].Visible = false;
            dataGridView1.Columns["Tbl_Match_AccGuid_DocCategory"].Visible = false;

            dataGridView1.Columns["Tbl_Items1"].Visible = false;
            dataGridView1.Columns["Tbl_Items2"].Visible = false;

            dataGridView1.Columns["Name"].Width = 150;

        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}