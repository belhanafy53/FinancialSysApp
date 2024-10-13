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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class CustomersTypeFrm : Form
    {
        public CustomersTypeFrm()
        {
            InitializeComponent();
        }
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        int Vint_Parent_ID = 0;
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
            string Sql = "Select * From Tbl_CustmersType";
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }
        private void CustomersTypeFrm_Load(object sender, EventArgs e)
        {
            this.tbl_Accounting_GuidTableAdapter.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);
            gridControl1.DataSource = FsDb.Tbl_CustmersType.ToList();
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "Name");
            }
            treeView1.ExpandAll();
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
            textBox1.Text = "";
            textBox2.Text = "";
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsDb.Tbl_CustmersType.FirstOrDefault(x => x.ID == Vint_IdItem);

            Vstr_Name = treeView1.SelectedNode.Text;
            txtSelected.Text = Vstr_Name;
            if (listItem.Accounting_GuidID != null)
            {
                int Vint_AccGuidID = int.Parse(listItem.Accounting_GuidID.ToString());
                var ListAccountGuid = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.ID == Vint_AccGuidID);
                if (ListAccountGuid.Account_NO.ToString() != "")
                {
                    textBox1.Text = ListAccountGuid.Account_NO.ToString();
                    txtGuidID.Text = Vint_AccGuidID.ToString();

                }
                if (ListAccountGuid.Name.ToString() != "")
                {
                    textBox2.Text = ListAccountGuid.Name.ToString();
                }
                
            }
            if (listItem.IsElectronicPaymentNo == true)
            {
                checkBox1.Checked = true;
            }
            else
            { checkBox1.Checked = false; }
            //grbNodeSelected.Text = ViewTree.SelectFullHirachyProjects(treeView1, Vint_IdItem, Vint_Parent_ID);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 55 && w.ProcdureId == 1);
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

                        int? Vint_AccGuidid = null;
                        bool? Vbl_ElectrPay = false;
                        Vint_AccGuidid = int.Parse(txtGuidID.Text);
                        if (checkBox1.Checked == true)
                        {
                            Vbl_ElectrPay = true;
                        }
                        Tbl_CustmersType Itm = new Tbl_CustmersType
                        {
                            Name = txtSelected.Text,
                            Accounting_GuidID = Vint_AccGuidid,
                            IsElectronicPaymentNo = Vbl_ElectrPay 
                        };
                        FsDb.Tbl_CustmersType.Add(Itm);
                        FsDb.SaveChanges();


                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة تصنيف عملاء",
                            TableName = "Tbl_CustmersType",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة تصنيفات العملاء"


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
                        textBox1.Text = "";
                        textBox2.Text = "";
                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                        //***************************

                    }
                    else
                    {
                        int Vint_AccGuidid = 0;
                        Vint_AccGuidid = int.Parse(txtGuidID.Text);

                        Tbl_CustmersType Itm = new Tbl_CustmersType
                        {
                            Name = txtSelected.Text,
                            Accounting_GuidID = Vint_AccGuidid,
                            Parent_ID = Vint_IdItem


                        };
                        FsDb.Tbl_CustmersType.Add(Itm);
                        FsDb.SaveChanges();
                        //grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة تصنيف",
                            TableName = "Tbl_CustmersType",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة تصنيفات العملاء"
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
                        textBox1.Text = "";
                        textBox2.Text = "";
                        txtSelected.Select();
                        this.ActiveControl = txtSelected;
                        txtSelected.Focus();
                    }
                    treeView1.Refresh();

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  التصنيف .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 55 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا البند  ؟", "حدف بند " + " " + treeView1.SelectedNode.Text, MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());


                    var ListCheckDelete = FsDb.Tbl_CustmersType.FirstOrDefault(x => x.Parent_ID == Vint_IdItem);
                    if (ListCheckDelete == null)
                    {

                        var listDelete = FsDb.Tbl_CustmersType.FirstOrDefault(x => x.ID == Vint_IdItem);
                        if (listDelete != null)
                        {
                            FsDb.Tbl_CustmersType.Remove(listDelete);
                            FsDb.SaveChanges();
                            grbNodeSelected.Text = "";
                            txtSelected.Text = "";
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف تصنيف",
                                TableName = "Tbl_CustmersType",
                                TableRecordId = listDelete.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة تصنيف العملاء"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            treeView1.Nodes.Remove(treeView1.SelectedNode);
                            //treeView1.ExpandAll();
                            //************************************

                            MessageBox.Show("  تم الحذف");
                            textBox1.Text = "";
                            textBox2.Text = "";
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
                MessageBox.Show("ليس لديك صلاحية حذف  تصنيف .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 55 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                int? Vint_AccGuidid = null;
                if (Vint_IdItem != null && txtSelected.Text != "")
                {
                    Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
                    if (txtGuidID.Text != "")
                    {
                          Vint_AccGuidid = int.Parse(txtGuidID.Text);
                         
                    }
                    bool? Vbl_ElectrPay = false;
                    
                    if (checkBox1.Checked == true)
                    {
                        Vbl_ElectrPay = true;
                    }

                    var listupdate = FsDb.Tbl_CustmersType.FirstOrDefault(x => x.ID == Vint_IdItem);
                    listupdate.Name = txtSelected.Text;
                    listupdate.Accounting_GuidID = Vint_AccGuidid;
                    listupdate.IsElectronicPaymentNo = Vbl_ElectrPay;

                    FsDb.SaveChanges();


                    //---------------خفظ ااحداث 

                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل تصنيف",
                        TableName = "Tbl_CustmersType",
                        TableRecordId = Vint_IdItem.ToString(),
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة تصنيف العملاء"


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
                    textBox1.Text = "";
                    textBox2.Text = "";
                    txtSelected.Select();
                    this.ActiveControl = txtSelected;
                    txtSelected.Focus();
                    //***************************

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل  تصنيف .. برجاء مراجعة مدير المنظومه");
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
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text != string.Empty)
            {
                if (dataGridViewX7.Rows.Count == 1)
                {
                    textBox1.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();


                }
                if (dataGridViewX7.Rows.Count > 1)
                {
                    dataGridViewX7.Focus();
                }


                //simpleButton1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Vst_AccountNoSearch = textBox1.Text.Trim();
            this.tbl_Accounting_GuidTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_Accounting_Guid, Vst_AccountNoSearch);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void dataGridViewX7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridViewX7.CurrentRow.Cells[2].Value.ToString();
            txtGuidID.Text = dataGridViewX7.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridViewX7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridViewX7.CurrentRow.Cells[2].Value.ToString();
                txtGuidID.Text = dataGridViewX7.CurrentRow.Cells[0].Value.ToString();
                simpleButton1.Focus();

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                string Vsd_Today = DateTime.Today.ToString("yyyy-MM-dd");
                string loc = Vsd_Today + ".xlsx";


                (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = true;
                XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
                advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
                advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
                advOptions.SheetName = "Not Find Accounts";

                gridControl1.ExportToXlsx(loc, advOptions);

                Process.Start(loc);
            }
            catch
            {
                MessageBox.Show("من فضلك اغلق ملف الاكسيل الخاص بهذا التقرير أولا ،،");
            }
        }
    }
}
