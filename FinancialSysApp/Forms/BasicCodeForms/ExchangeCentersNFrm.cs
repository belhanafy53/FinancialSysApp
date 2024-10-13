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
    public partial class ExchangeCentersNFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_IdManagement = 0;
        string Vstr_NameExchangeCenter = "";
        int Vint_Parent_ID = 0;
        int Vint_ExchangeID = 0;
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
        string SelectTreeTable()
        {
            string Sql = "Select * From Tbl_Management";
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }
        public ExchangeCentersNFrm()
        {
            InitializeComponent();
        }

        private void ExchangeCentersNFrm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "Management_ID", "Name", "Parent_ID","");
            }
            var listExchangeCenters = FsDb.Tbl_ExchangeCenter.ToList();
            dataGridView1.DataSource = listExchangeCenters;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "مركز الصرف";
            dataGridView1.Columns["Mnagement_ID"].Visible = false;
            dataGridView1.Columns["Tbl_Management"].Visible = false;
            dataGridView1.Columns["Name"].Width = 250;

            //treeView1.ExpandAll();
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
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
            Vint_IdManagement = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listManagement = FsDb.Tbl_ExchangeCenter.Where(x => x.Mnagement_ID == Vint_IdManagement).ToList();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "مركز الصرف";
            dataGridView1.Columns["Mnagement_ID"].Visible = false;
            dataGridView1.Columns["Tbl_Management"].Visible = false;
            dataGridView1.Columns["Name"].Width = 250;
            Vstr_NameExchangeCenter = treeView1.SelectedNode.Text;
            grbNodeSelected.Text = "مراكز صرف" + " " + Vstr_NameExchangeCenter;
            dataGridView1.DataSource = listManagement;
            txtSelected.Focus();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 7 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (txtSelected.Text == "")
            {
                MessageBox.Show("برجاء ادخال مركز الصرف المراد اضافته");
            }
            else
            {

                if (Vint_IdManagement == 0)
                {
                        MessageBox.Show("برجاء اختيار الاداره ");


                    }
                else
                {
                 var ListExchangeManagment = FsDb.Tbl_ExchangeCenter.Where(x => x.Name == txtSelected.Text && x.Mnagement_ID == Vint_IdManagement).ToList();
                        if (ListExchangeManagment.Count == 0)
                        {
                            Tbl_ExchangeCenter Itm = new Tbl_ExchangeCenter
                            {
                                Name = txtSelected.Text,
                                Mnagement_ID = Vint_IdManagement

                            };
                            FsDb.Tbl_ExchangeCenter.Add(Itm);
                            FsDb.SaveChanges();
                            //grbNodeSelected.Text = "";

                            //---------------خفظ ااحداث 
                            int Vint_LastRow = Itm.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة مركز الصرف",
                                TableName = "Tbl_ExchangeCenter",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة مراكز الصرف"
                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************



                            MessageBox.Show("تم الاضافه");
                            Nametxt.Text = "";
                            txtSelected.Text = "";

                            txtSelected.Select();
                            this.ActiveControl = txtSelected;
                            txtSelected.Focus();
                        }
                        else
                        {
                            MessageBox.Show("هذا المركز تم اضافته لهذه الاداره من قبل");
                        }    
                }
                treeView1.Refresh();

            }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  مركز صرف .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 7 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا المركز صرف  ؟", "حدف مركز صرف " + " " + treeView1.SelectedNode.Text, MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {

                Vint_IdManagement = int.Parse(treeView1.SelectedNode.Tag.ToString());


                var ListCheckDelete = FsDb.TBL_Document.FirstOrDefault(x => x.ExchangeCenter_ID == Vint_ExchangeID);
                if (ListCheckDelete == null)
                {

                    var listDelete = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.ID == Vint_ExchangeID);
                    if (listDelete != null)
                    {
                        FsDb.Tbl_ExchangeCenter.Remove(listDelete);
                        FsDb.SaveChanges();
                        grbNodeSelected.Text = "";
                        txtSelected.Text = "";
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف مركز صرف",
                            TableName = "Tbl_ExchangeCenter",
                            TableRecordId = listDelete.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراكز الصرف"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        //treeView1.ExpandAll();
                        //************************************

                        MessageBox.Show("  تم الحذف");
                            Nametxt.Text = "";
                            txtSelected.Text = "";

                            txtSelected.Select();
                            this.ActiveControl = txtSelected;
                            txtSelected.Focus();
                        }
                }

                else
                {
                    MessageBox.Show("لايمكن حذف هدا المركز صرف لاحتوائه على بنود تابعه له قم بحدف تلك مراكز الصرف اولا");
                }

            }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  مركز صرف .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 7 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (Vint_IdManagement != 0 && txtSelected.Text != "")
            {
   
                var listupdate = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.ID == Vint_ExchangeID);
                listupdate.Name = txtSelected.Text;


                FsDb.SaveChanges();


                //---------------خفظ ااحداث 

                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "تعديل مركز صرف",
                    TableName = "Tbl_ExchangeCenter",
                    TableRecordId = Vint_IdManagement.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة مراكز الصرف"


                };
                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //TreeNode node = new TreeNode();
                //node.Text = txtSelected.Text;
                //node.Name = Vint_Parent_ID.ToString();
                //node.Tag = Vint_IdManagement.ToString();
                //node.Expand();

                //treeView1.SelectedNode.Text = txtSelected.Text;
                MessageBox.Show("تم التعديل");
                    Nametxt.Text = "";
                    txtSelected.Text = "";

                txtSelected.Select();
                this.ActiveControl = txtSelected;
                txtSelected.Focus();
                //***************************

            }
            else
            {
                MessageBox.Show("برجاء اختيار الاداره ومركز الصرف");
            }

            }
            else
            {
                //MessageBox.Show("ليس لديك صلاحية تعديل  مركز صرف .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                grbNodeSelected.Text = "";
                txtSelected.Text = "";
                Vint_IdManagement = 0;

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

        private void txtSelected_TextChanged(object sender, EventArgs e)
        {
            var ListExchangeCenters = FsDb.Tbl_ExchangeCenter.Where(x => x.Name.Contains(txtSelected.Text)).ToList();
            dataGridView1.DataSource = ListExchangeCenters;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "مركز الصرف";
            dataGridView1.Columns["Mnagement_ID"].Visible = false;
            dataGridView1.Columns["Tbl_Management"].Visible = false;
            dataGridView1.Columns["Name"].Width = 250;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Vint_ExchangeID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ListExchangeCenters = FsDb.Tbl_ExchangeCenter.FirstOrDefault(x => x.ID == Vint_ExchangeID);
            txtSelected.Text = ListExchangeCenters.Name;
            var listManagement = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == ListExchangeCenters.Mnagement_ID);
            if (listManagement != null)
            {
                Vint_IdManagement = int.Parse(listManagement.Management_ID.ToString());
                Vint_Parent_ID = int.Parse(listManagement.Parent_ID.ToString());
            }
            TreeNode node = new TreeNode();
            node.Text = listManagement.Name.ToString();
            node.Name = Vint_Parent_ID.ToString();
            node.Tag = Vint_IdManagement.ToString();
            node.Expand();
            Nametxt.Text = listManagement.Name.ToString();
            simpleButton3.Focus();

        }
    }
}
