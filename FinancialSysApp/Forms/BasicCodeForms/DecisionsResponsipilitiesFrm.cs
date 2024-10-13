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
    public partial class DecisionsResponsipilitiesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_IdManagement = 0;
        //string Vstr_NameExchangeCenter = "";
        int Vint_Parent_ID = 0;
        int Vint_DecisionID = 0;
        string Vint_DecisionNo = "";
        int Vint_ResponspilityID = 0;
        DateTime VDate_DecisionDate = Convert.ToDateTime(DateTime.Now.ToString());
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        public DecisionsResponsipilitiesFrm()
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

        private void DecisionsResponsipilitiesFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_DecisionsResponspilities.OrderBy(x=>x.DecisionDate).ToList();

            
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "StoreCode");
            }
             

            
            searchText.Text = "";
            searchText.Select();
            this.ActiveControl = searchText;
            searchText.Focus();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsDb.Tbl_ResponspilityCenters.FirstOrDefault(x => x.ID == Vint_IdItem);
            var ListDecisionResponspility = FsDb.Tbl_DecisionsResponspilities.Where(x => x.ResponspilityCentersID == listItem.ID).OrderBy(x => x.DecisionDate).ToList();
            dataGridView1.DataSource = ListDecisionResponspility;
            Vstr_Name = listItem.Name;
            txtResponsepilityId.Text = listItem.ID.ToString();

            grbNodeSelected.Text = "القرار / الجلسات لجنة" + "  " + ViewTree.SelectFullHirachyResponspilityCenters(treeView1, Vint_IdItem, Vint_Parent_ID);
            txtSelected.Text = "";
            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            txtForYear.Text = "";
            //txtSelected.Select();
            //this.ActiveControl = txtSelected;
            //txtSelected.Focus();
            ;
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

        private void txtSelected_TextChanged(object sender, EventArgs e)
        {
            if (txtSelected.Text != "")
            {
                Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
                string Vint_DecisionNo = txtSelected.Text;
                var ListDecisionsResponspilities = FsDb.Tbl_DecisionsResponspilities.Where(x => x.DecisionNO.Contains(Vint_DecisionNo) && x.ResponspilityCentersID == Vint_IdItem).OrderBy(x => x.DecisionDate).ToList();
                if (ListDecisionsResponspilities.Count != 0)
                {
                    dataGridView1.DataSource = ListDecisionsResponspilities;
   
                }
                else
                {

                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Vint_DecisionID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ListDecisionsResponspilities = FsDb.Tbl_DecisionsResponspilities.FirstOrDefault(x => x.ID == Vint_DecisionID);
            Vint_ResponspilityID = int.Parse(ListDecisionsResponspilities.ResponspilityCentersID.ToString());
            txtResponsepilityId.Text = ListDecisionsResponspilities.ResponspilityCentersID.ToString();
            txtSelected.Text = ListDecisionsResponspilities.DecisionNO.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(ListDecisionsResponspilities.DecisionDate.ToString());
            var listResponspilityCenters = FsDb.Tbl_ResponspilityCenters.FirstOrDefault(x => x.ID == Vint_ResponspilityID);
            if (ListDecisionsResponspilities.ForYear != null)
            {
                txtForYear.Text = ListDecisionsResponspilities.ForYear.ToString();
            }
            searchText.Text = listResponspilityCenters.Name.ToString();
            TreeNode node = new TreeNode();
            node.Text = listResponspilityCenters.Name.ToString();
            node.Name = listResponspilityCenters.Parent_ID.ToString();
            node.Tag = listResponspilityCenters.ID.ToString();
            node.Expand();

            simpleButton3.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 61 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {



                if (txtResponsepilityId.Text == "")
                {
                    MessageBox.Show("برجاء اختيار اللجنه ");
                    treeView1.Focus();
                }
                else if (txtSelected.Text == "")
                {
                    MessageBox.Show("برجاء ادخال رقم الالقرار / الجلسه ");
                    txtSelected.Focus();

                }
                else if (dateTimePicker1.Value == null)
                {
                    MessageBox.Show("برجاء ادخال تاريخ الالقرار / الجلسه ");

                    dateTimePicker1.Focus();
                }
                else
                {

                    Vint_ResponspilityID = int.Parse(txtResponsepilityId.Text);
                    Vint_DecisionNo = txtSelected.Text;
                    VDate_DecisionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                    var ListDecisionResp = FsDb.Tbl_DecisionsResponspilities.Where(x => x.DecisionNO == Vint_DecisionNo && x.DecisionDate == VDate_DecisionDate).ToList();
                    if (ListDecisionResp.Count == 0)
                    {
                        Tbl_DecisionsResponspilities Itm = new Tbl_DecisionsResponspilities
                        {
                            DecisionNO = Vint_DecisionNo,
                            DecisionDate = VDate_DecisionDate,
                            ResponspilityCentersID = Vint_ResponspilityID,
                            ForYear = txtForYear.Text
                            

                        };
                        FsDb.Tbl_DecisionsResponspilities.Add(Itm);
                        FsDb.SaveChanges();
                        //grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة القرار / الجلسه لجنه",
                            TableName = "Tbl_DecisionsResponspilities",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة القرار / الجلسهات اللجان"
                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************



                        MessageBox.Show("تم الاضافه ");
                        var ListDecisionsResponspilities = FsDb.Tbl_DecisionsResponspilities.ToList();

                        dataGridView1.DataSource = ListDecisionsResponspilities;
                        //dataGridView1.Columns["ID"].Visible = false;
                        //dataGridView1.Columns["DecisionNO"].HeaderText = "الالقرار / الجلسه";
                        //dataGridView1.Columns["DecisionNO"].Width = 70;
                        //dataGridView1.Columns["DecisionNDate"].Width = 70;
                        txtSelected.Text = "";

                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                    }
                    else
                    {
                        MessageBox.Show("هذا الالقرار / الجلسه تم اضافته لهذه اللجنه من قبل");
                    }
                }
                treeView1.Refresh();



            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة القرار / الجلسه لجنه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 61 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا الالقرار / الجلسه  ؟", "حدف القرار / الجلسه للجنه " + " " , MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                   


                    //var ListCheckDelete = FsDb.TBL_Document.FirstOrDefault(x => x.ExchangeCenter_ID == Vint_DecisionID);
                    //if (ListCheckDelete == null)
                    //{

                    var listDelete = FsDb.Tbl_DecisionsResponspilities.FirstOrDefault(x => x.ID == Vint_DecisionID);
                    if (listDelete != null)
                    {
                        FsDb.Tbl_DecisionsResponspilities.Remove(listDelete);
                        FsDb.SaveChanges();
                        grbNodeSelected.Text = "";
                        txtSelected.Text = "";
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف القرار / الجلسه لجنه",
                            TableName = "Tbl_DecisionsResponspilities",
                            TableRecordId = listDelete.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة القرار / الجلسهات اللجان"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                         
                        //treeView1.ExpandAll();
                        //************************************

                        MessageBox.Show("  تم الحذف");
                        dataGridView1.DataSource = FsDb.Tbl_DecisionsResponspilities.ToList();
                        txtSelected.Text = "";
                        dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        txtForYear.Text = "";
                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                    }
                    //}

                    //else
                    //{
                    //    //MessageBox.Show("لايمكن حذف هدا االالقرار / الجلسه لاحتوائه على بنود تابعه له قم بحدف تلك مراكز الصرف اولا");
                    //}

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  القرار / الجلسه لجنه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 61 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {

                if (Vint_DecisionID != 0 )
                {
                    

                    var listupdate = FsDb.Tbl_DecisionsResponspilities.FirstOrDefault(x => x.ID == Vint_DecisionID);
                   
                    listupdate.DecisionNO = txtSelected.Text;
                    listupdate.DecisionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                    listupdate.ResponspilityCentersID = int.Parse(txtResponsepilityId.Text);
                    listupdate.ForYear = txtForYear.Text;
                    FsDb.SaveChanges();


                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل القرار / الجلسه لجنه",
                        TableName = "Tbl_DecisionsResponspilities",
                        TableRecordId = Vint_IdManagement.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة القرارات / الجلسات اللجان"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();


                    //treeView1.SelectedNode.Text = txtSelected.Text;
                    MessageBox.Show("تم التعديل");
                    dataGridView1.DataSource = FsDb.Tbl_DecisionsResponspilities.ToList();
                    txtSelected.Text = "";
                    txtForYear.Text = "";
                    dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                    txtSelected.Select();
                    this.ActiveControl = txtSelected;
                    txtSelected.Focus();
                    //***************************

                }
                else
                {
                    MessageBox.Show("برجاء اختيار اللجنه والالقرار / الجلسه");
                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل  القرار / الجلسه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void txtSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { dateTimePicker1.Focus(); }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 Vint_DecisionNo = txtSelected.Text;
                DateTime Vdt_DecisionDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
                var ListDecisionsResponspilities = FsDb.Tbl_DecisionsResponspilities.Where(x => x.DecisionNO == Vint_DecisionNo && x.DecisionDate == Vdt_DecisionDate).ToList();
                if (ListDecisionsResponspilities.Count != 0)
                {
                    dataGridView1.DataSource = ListDecisionsResponspilities;
                    //dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["DecisionNO"].HeaderText = "الالقرار / الجلسه";
                    //dataGridView1.Columns["DecisionNDate"].HeaderText = "الالقرار / الجلسه";
                    dataGridView1.Columns["DecisionNO"].Width = 100;
                    dataGridView1.Columns["Name"].Visible = false;
                    //dataGridView1.Columns["DecisionNDate"].Width = 70;
                    txtForYear.Focus();
                }
                else
                {
                    txtForYear.Focus();
                }
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSelected.Select();
                this.ActiveControl = txtSelected;
                txtSelected.Focus();
            }
        }

        private void txtForYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { simpleButton1.Focus(); }
        }

       
    }
}