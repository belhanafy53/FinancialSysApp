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
    public partial class ItemsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_ItemId;
        int Vint_ItemChildId;
        public ItemsFrm()
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
                };
                if (StartNode.Nodes.Count != 0)
                {
                    SearchNodes(SearchText, StartNode.Nodes[0]);
                };
                StartNode = StartNode.NextNode;
            }
        }
        string SelectTreeTable()
        {
            string Sql = "Select * From Tbl_Items";
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }
        private void ItemsFrm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                //ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID");
            }
            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();

        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            //var list = FsDb.Tbl_Items.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
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
                string searchText = this.Nametxt.Text;
                if (string.IsNullOrEmpty(searchText))
                {
                    return;
                };
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
            //int xrows = radTreeView1.Nodes.Count;
            //if (xrows == 0)
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        simpleButton1.Select();
            //        this.ActiveControl = simpleButton1;
            //        comboBox1.Focus();
            //    }
            //}
            //else
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        radTreeView1.Select();
            //        this.ActiveControl = radTreeView1;
            //        radTreeView1.Focus();
            //    }
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البند ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {
                int xrows = radTreeView1.SelectedNodes.Count;
                if (IDParenttxtBox.Text == "" && Nametxt.Text != "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        int Vint_itemcategoryid = 0;
                        if (comboBox1.SelectedIndex != -1)
                        {
                            Vint_itemcategoryid = int.Parse(comboBox1.SelectedIndex.ToString());
                        }
                        Tbl_Items CatF = new Tbl_Items
                        {
                            Name = Nametxt.Text,
                            ItemCategoryID = Vint_itemcategoryid
                            //SystemUnitesID =Program.GlbV_SysUnite_ID
                        };
                        FsDb.Tbl_Items.Add(CatF);
                        FsDb.SaveChanges();

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
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
                        MessageBox.Show("تم الحفظ");
                        radTreeView1.DataSource = FsDb.Tbl_Items.ToList();
                        Nametxt.Text = "";
                        IDParenttxtBox.Text = "";
                        textBox1.Text = "";
                        ParentIDtxt.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;
                        radTreeView1.ExpandAll();
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDParenttxtBox.Text == "" && textBox1.Text == "" && textBox2.Text != "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        int Vint_itemcategoryid = 0;
                        if (comboBox1.SelectedIndex != -1)
                        {
                            Vint_itemcategoryid = int.Parse(comboBox1.SelectedIndex.ToString());
                        }
                        Tbl_Items CatF = new Tbl_Items
                        {
                            Name = textBox2.Text,
                            Parent_ID = null,
                            ItemCategoryID = Vint_itemcategoryid,
                            SystemUnitesID = Program.GlbV_SysUnite_ID
                        };
                        FsDb.Tbl_Items.Add(CatF);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
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
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة بنود تابعه للبند " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_Items.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            Nametxt.Text = "";
                            //ParentIDtxt.Text = "";
                            //textBox1.Text = "";
                            textBox2.Text = "";
                            comboBox1.SelectedIndex = 0;
                            comboBox2.SelectedIndex = 0;
                            radTreeView1.ExpandAll();
                            textBox2.Select();
                            this.ActiveControl = textBox2;
                            textBox2.Focus();
                        }
                        else
                        {
                            Nametxt.Text = "";
                            IDParenttxtBox.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";
                            ParentIDtxt.Text = "";
                            comboBox1.SelectedIndex = 0;
                            comboBox2.SelectedIndex = 0;
                            radTreeView1.ExpandAll();
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && IDChildtxtBox.Text == "")
                {
                    var validationSaveUser1 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 1);
                    if (validationSaveUser1 != null)
                    {
                        int Vint_itemcategoryid = 0;
                        if (comboBox1.SelectedIndex != -1)
                        {
                            Vint_itemcategoryid = int.Parse(comboBox1.SelectedIndex.ToString());
                        }
                        Tbl_Items CatF = new Tbl_Items
                        {
                            Name = textBox2.Text,
                            Parent_ID = int.Parse(IDParenttxtBox.Text),
                            ItemCategoryID = Vint_itemcategoryid,
                            SystemUnitesID = Program.GlbV_SysUnite_ID

                        };
                        FsDb.Tbl_Items.Add(CatF);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
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
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة فروع تابعه لبند " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_Items.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            Nametxt.Text = "";
                            //IDtxtBox.Text = "";
                            //ParentIDtxt.Text = "";
                            textBox2.Text = "";
                            comboBox1.SelectedIndex = 0;
                            comboBox2.SelectedIndex = 0;
                            radTreeView1.ExpandAll();
                            textBox2.Select();
                            this.ActiveControl = textBox2;
                            textBox2.Focus();
                        }
                        else
                        {
                            Nametxt.Text = "";
                            IDParenttxtBox.Text = "";
                            ParentIDtxt.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";

                            radTreeView1.ExpandAll();
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text == "" || Nametxt.Text == "")
                {
                    var validationSaveUser3 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 3);
                    if (validationSaveUser3 != null)

                    {
                        int Vint_itemcategoryid = 0;
                        if (comboBox1.SelectedIndex != -1)
                        {
                            Vint_itemcategoryid = int.Parse(comboBox1.SelectedIndex.ToString());
                        }
                        Vint_ItemId = int.Parse(IDParenttxtBox.Text);
                        var result = FsDb.Tbl_Items.SingleOrDefault(x => x.ID == Vint_ItemId);
                        result.Name = textBox1.Text;
                        result.ItemCategoryID = Vint_itemcategoryid;
                        result.SystemUnitesID = Program.GlbV_SysUnite_ID;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بند",
                            TableName = "Tbl_Items",
                            TableRecordId = result.ID.ToString(),
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
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_Items.ToList();
                        radTreeView1.ExpandAll();
                        Nametxt.Text = "";
                        IDParenttxtBox.Text = "";
                        textBox1.Text = "";
                        ParentIDtxt.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  بند .. برجاء مراجعة مدير المنظومه");
                    }

                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text == "")
                {
                    var validationSaveUser2 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 3);
                    if (validationSaveUser2 != null)

                    {

                        Vint_ItemId = int.Parse(IDParenttxtBox.Text);
                        var result = FsDb.Tbl_Items.SingleOrDefault(x => x.ID == Vint_ItemId);
                        result.Name = textBox1.Text;
                        result.SystemUnitesID = Program.GlbV_SysUnite_ID;

                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بند",
                            TableName = "Tbl_Items",
                            TableRecordId = result.ID.ToString(),
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
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_Items.ToList();
                        radTreeView1.ExpandAll();
                        Nametxt.Text = "";
                        IDParenttxtBox.Text = "";
                        textBox1.Text = "";
                        ParentIDtxt.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && IDChildtxtBox.Text != "")
                {
                    var validationSaveUser3 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 3);
                    if (validationSaveUser3 != null)

                    {

                        Vint_ItemChildId = int.Parse(IDChildtxtBox.Text);
                        var result = FsDb.Tbl_Items.SingleOrDefault(x => x.ID == Vint_ItemChildId);
                        result.Name = textBox2.Text;
                        result.SystemUnitesID = Program.GlbV_SysUnite_ID;

                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بند",
                            TableName = "Tbl_Items",
                            TableRecordId = result.ID.ToString(),
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
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_Items.ToList();
                        radTreeView1.ExpandAll();
                        Nametxt.Text = "";
                        IDParenttxtBox.Text = "";
                        textBox1.Text = "";
                        ParentIDtxt.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  بند .. برجاء مراجعة مدير المنظومه");
                    }

                }
            }

        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    if (textBox1.Text != "")
                    {
                        int Vint_catID = int.Parse(IDParenttxtBox.Text);
                        var result1 = MessageBox.Show("هل تريد حدف هدا البند  ؟", "حدف بيان ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_Items.Find(Vint_catID);
                            FsDb.Tbl_Items.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 

                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف بند",
                                TableName = "Tbl_Items",
                                TableRecordId = result.ID.ToString(),
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
                            MessageBox.Show("  تم الحدف");
                        }
                        radTreeView1.DataSource = FsDb.Tbl_Items.ToList();
                        radTreeView1.ExpandAll();
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        ParentIDtxt.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = 0;
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد البند المراد حدفه");

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  بند .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا البند لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radTreeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radTreeView1.SelectedNodes.Count() > 0)
                {
                    Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    var list = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_ItemId);
                    string Vstr_item = list.Name.ToString();



                    if (list.Parent_ID == null && IDParenttxtBox.Text == "")
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Text = Vstr_item;
                        Nametxt.Text = textBox1.Text;
                        IDParenttxtBox.Text = Vint_ItemId.ToString();
                        //ParentIDtxt.Text = list.Parent_ID.ToString();

                    }
                    else if (list.Parent_ID == null && IDParenttxtBox.Text != "")
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Text = Vstr_item;
                        Nametxt.Text = textBox1.Text;
                        IDParenttxtBox.Text = Vint_ItemId.ToString();

                    }
                    else if (list.Parent_ID != null && IDParenttxtBox.Text != "")
                    {
                        textBox2.Text = "";
                        var listParent = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == list.Parent_ID);
                        textBox1.Text = listParent.Name;
                        IDParenttxtBox.Text = listParent.ID.ToString();
                        ParentIDtxt.Text = listParent.Parent_ID.ToString();
                        Nametxt.Text = textBox1.Text;
                        IDChildtxtBox.Text = Vint_ItemId.ToString();
                        textBox2.Text = Vstr_item;
                    }
                    else if (list.Parent_ID != null && IDParenttxtBox.Text == "")
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Text = Vstr_item;
                        Nametxt.Text = textBox1.Text;
                        IDParenttxtBox.Text = Vint_ItemId.ToString();
                    }







                    textBox2.Select();
                    this.ActiveControl = textBox2;
                    textBox2.Focus();
                }
                else
                {
                    textBox1.Text = Nametxt.Text;
                    radTreeView1.Select();
                    this.ActiveControl = radTreeView1;
                    radTreeView1.Focus();
                }

            }
        }

        private void radTreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radTreeView1.SelectedNodes.Count() > 0)
            {
                Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                var list = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_ItemId);
                string Vstr_item = list.Name.ToString();



                if (list.Parent_ID == null && IDParenttxtBox.Text == "")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = Vstr_item;
                    Nametxt.Text = textBox1.Text;
                    IDParenttxtBox.Text = Vint_ItemId.ToString();
                    //ParentIDtxt.Text = list.Parent_ID.ToString();

                }
                else if (list.Parent_ID == null && IDParenttxtBox.Text != "")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = Vstr_item;
                    Nametxt.Text = textBox1.Text;
                    IDParenttxtBox.Text = Vint_ItemId.ToString();

                }
                else if (list.Parent_ID != null && IDParenttxtBox.Text != "")
                {
                    textBox2.Text = "";
                    var listParent = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == list.Parent_ID);
                    textBox1.Text = listParent.Name;
                    IDParenttxtBox.Text = listParent.ID.ToString();
                    ParentIDtxt.Text = listParent.Parent_ID.ToString();
                    Nametxt.Text = textBox1.Text;
                    IDChildtxtBox.Text = Vint_ItemId.ToString();
                    textBox2.Text = Vstr_item;
                }
                else if (list.Parent_ID != null && IDParenttxtBox.Text == "")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = Vstr_item;
                    Nametxt.Text = textBox1.Text;
                    IDParenttxtBox.Text = Vint_ItemId.ToString();
                }







                textBox2.Select();
                this.ActiveControl = textBox2;
                textBox2.Focus();
            }
            else
            {
                textBox1.Text = Nametxt.Text;
                radTreeView1.Select();
                this.ActiveControl = radTreeView1;
                radTreeView1.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                IDParenttxtBox.Text = "";
                ParentIDtxt.Text = "";
                IDChildtxtBox.Text = "";
                textBox2.Text = "";

            }
            else
            {
                var list = FsDb.Tbl_Items.Where(x => x.Name.Contains(textBox1.Text)).ToList();
                radTreeView1.DataSource = list;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                IDChildtxtBox.Text = "";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

      

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string Vstr_item = treeView1.SelectedNode.Text;
               //int Vint_ItemId = int.Parse(treeView1.SelectedNode.Nodes["ID"].ToString());
                var list = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_ItemId);
                //string Vstr_item = list.Name.ToString();



                if (list.Parent_ID == null && IDParenttxtBox.Text == "")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = Vstr_item;
                    Nametxt.Text = textBox1.Text;
                    IDParenttxtBox.Text = Vint_ItemId.ToString();
                    //ParentIDtxt.Text = list.Parent_ID.ToString();

                }
                else if (list.Parent_ID == null && IDParenttxtBox.Text != "")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = Vstr_item;
                    Nametxt.Text = textBox1.Text;
                    IDParenttxtBox.Text = Vint_ItemId.ToString();

                }
                else if (list.Parent_ID != null && IDParenttxtBox.Text != "")
                {
                    textBox2.Text = "";
                    var listParent = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == list.Parent_ID);
                    textBox1.Text = listParent.Name;
                    IDParenttxtBox.Text = listParent.ID.ToString();
                    ParentIDtxt.Text = listParent.Parent_ID.ToString();
                    Nametxt.Text = textBox1.Text;
                    IDChildtxtBox.Text = Vint_ItemId.ToString();
                    textBox2.Text = Vstr_item;
                }
                else if (list.Parent_ID != null && IDParenttxtBox.Text == "")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = Vstr_item;
                    Nametxt.Text = textBox1.Text;
                    IDParenttxtBox.Text = Vint_ItemId.ToString();
                }







                textBox2.Select();
                this.ActiveControl = textBox2;
                textBox2.Focus();
           
        }
    }
}