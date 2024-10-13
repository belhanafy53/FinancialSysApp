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
    public partial class DirectoryItemTrCategoryFem : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_branchID = 0;
        string Vstr_NameExchangeCenter = "";
        //int Vint_Parent_ID = 0;
        int vint_itemTrMangID = 0;
        //******* Tree View
        private List<TreeNode> CurrentNodeMatches = new List<TreeNode>();
        private int LastNodeIndex = 0;
        //private string LastSearchText;
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
            string Sql = ("Select * From Tbl_Management where KindBranchDirect = 2 ");
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }
        string SelectTreeTableByKindBranchDirect(string TABLE, string KindBranchDirect)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + KindBranchDirect + " ='" + 2 + "'");

            return Sql;
        }
        public DirectoryItemTrCategoryFem()
        {
            InitializeComponent();
        }

        private void DirectoryItemTrCategoryFem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'depositCashDS.Dtb_TreasurItemMnagement' table. You can move, or remove it, as needed.
            this.dtb_TreasurItemMnagementTableAdapter.FillAll(this.depositCashDS.Dtb_TreasurItemMnagement);
            // TODO: This line of code loads data into the 'depositCashDS.Tbl_TreasuryItems' table. You can move, or remove it, as needed.
            this.tbl_TreasuryItemsTableAdapter.Fill(this.depositCashDS.Tbl_TreasuryItems);
            //***********
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر بند الخزينه";
            //treeView1.ExpandAll();
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 112 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {

                if (txtBranchID.Text == "")
                {
                    MessageBox.Show("برجاء اختيار الجهه ");


                }
                else if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("برجاء اختيار بند الخزينه ");
                }
                else
                {
                    Vint_branchID = int.Parse(txtBranchID.Text);
                    int Vint_IdItemTr = int.Parse(comboBox1.SelectedValue.ToString());

                    var ListExchangeManagment = FsDb.Tbl_ItemsTreasureManagement.Where(x => x.ManagementID == Vint_branchID && x.ItemsTreasureID == Vint_IdItemTr).ToList();
                    if (ListExchangeManagment.Count == 0)
                    {

                        Tbl_ItemsTreasureManagement Itm = new Tbl_ItemsTreasureManagement
                        {
                            ItemsTreasureID = Vint_IdItemTr,
                            ManagementID = Vint_branchID

                        };
                        FsDb.Tbl_ItemsTreasureManagement.Add(Itm);
                        FsDb.SaveChanges();
                        //grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = Itm.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند خزينه لاداره",
                            TableName = "Tbl_ItemsTreasureManagement",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة بنود خزينه الادارات"
                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************



                        MessageBox.Show("تم الاضافه");
                        //Nametxt.Text = "";
                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "اختر بند الخزينه";
                        //Nametxt.Text = "";
                        this.dtb_TreasurItemMnagementTableAdapter.FillByMngID(this.depositCashDS.Dtb_TreasurItemMnagement, Vint_branchID);

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("هذا البند تم اضافته لهذه الاداره من قبل");
                    }

                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  بنود خزينة الادارات .. برجاء مراجعة مدير المنظومه");
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {


        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 112 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا البند  ؟", "حذف بند خزينه " + " " + "", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {


                    var listDelete = FsDb.Tbl_ItemsTreasureManagement.FirstOrDefault(x => x.ID == vint_itemTrMangID);
                    if (listDelete != null)
                    {
                        Vint_branchID = int.Parse(listDelete.ManagementID.ToString());
                        FsDb.Tbl_ItemsTreasureManagement.Remove(listDelete);
                        FsDb.SaveChanges();
                        grbNodeSelected.Text = "";

                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف بند خزينه لاداره",
                            TableName = "Tbl_ItemsTreasureManagement",
                            TableRecordId = listDelete.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة بنود خزينة ادارات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();

                        //treeView1.ExpandAll();
                        //************************************

                        MessageBox.Show("  تم الحذف");
                        //Nametxt.Text = "";
                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "اختر بند الخزينه";
                        //Nametxt.Text = "";

                        this.dtb_TreasurItemMnagementTableAdapter.FillByMngID(this.depositCashDS.Dtb_TreasurItemMnagement, Vint_branchID);
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }


                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  بند خزينه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 112 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (txtRowId.Text != "")
                {
                    Vint_branchID = int.Parse(txtBranchID.Text);
                    int Vint_IdItemTr = int.Parse(comboBox1.SelectedValue.ToString());

                    var ListExchangeManagment = FsDb.Tbl_ItemsTreasureManagement.Where(x => x.ManagementID == Vint_branchID && x.ItemsTreasureID == Vint_IdItemTr).ToList();
                    if (ListExchangeManagment.Count == 0)
                    {
                        vint_itemTrMangID = int.Parse(txtRowId.Text);
                        var listupdate = FsDb.Tbl_ItemsTreasureManagement.FirstOrDefault(x => x.ID == vint_itemTrMangID);
                        listupdate.ManagementID = int.Parse(txtBranchID.Text);
                        listupdate.ItemsTreasureID = int.Parse(comboBox1.SelectedValue.ToString());
                        Vint_branchID = int.Parse(listupdate.ManagementID.ToString());
                        FsDb.SaveChanges();


                        //---------------خفظ ااحداث 

                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بند خزينة اداره",
                            TableName = "Tbl_ItemsTreasureManagement",
                            TableRecordId = vint_itemTrMangID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة بنود خزينة ادارات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();

                        MessageBox.Show("  تم التعديل");
                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "اختر بند الخزينه";
                        //Nametxt.Text = "";
                        this.dtb_TreasurItemMnagementTableAdapter.FillByMngID(this.depositCashDS.Dtb_TreasurItemMnagement, Vint_branchID);
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("هذا البند تم اضافته لهذه الاداره من قبل");
                    }
                }
                else
                {
                    MessageBox.Show("برجاء اختيار الاداره وبند الخزينه");
                }

            }
            else
            {
                //MessageBox.Show("ليس لديك صلاحية تعديل  مركز صرف .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            int Vint_BranchID = 0;
            if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindDirectionFrm t = new Forms.BasicCodeForms.FindDirectionFrm();

                t.ShowDialog();
                if (Forms.BasicCodeForms.FindDirectionFrm.SelectedRow != null)
                {
                    Nametxt.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[1].Value.ToString();
                    txtBranchID.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[0].Value.ToString();
                    Vint_BranchID = int.Parse(txtBranchID.Text);
                    this.dtb_TreasurItemMnagementTableAdapter.FillByMngID(this.depositCashDS.Dtb_TreasurItemMnagement, Vint_BranchID);
                    //var list = FsDb.Tbl_ItemsTreasureManagement.Where(x => x.ManagementID == Vint_BranchID).ToList();
                    //dataGridView1.DataSource = list;
                    comboBox1.Focus();

                }
            }
        }



        private void simpleButton3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //treeView1.Focus();
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //txtSelected.Focus();
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
            var ListExchangeCenters = FsDb.Tbl_ItemsTreasure.Where(x => x.Name.Contains("")).ToList();
            dataGridView1.DataSource = ListExchangeCenters;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "بنود خزينه";
            dataGridView1.Columns["Mnagement_ID"].Visible = false;
            dataGridView1.Columns["Tbl_Management"].Visible = false;
            dataGridView1.Columns["Name"].Width = 250;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            vint_itemTrMangID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ListExchangeCenters = (from ItTr in FsDb.Tbl_TreasuryItems
                                       join ItTrCt in FsDb.Tbl_ItemsTreasureManagement on ItTr.ID equals ItTrCt.ItemsTreasureID
                                       join mng in FsDb.Tbl_Management on ItTrCt.ManagementID equals mng.ID
                                       where (ItTrCt.ID == vint_itemTrMangID)
                                       select new
                                       {
                                           ID = ItTr.ID,
                                           Name = ItTr.Name,
                                           itemCatId = ItTrCt.ID,
                                           Mnagement_ID = mng.ID,
                                           mngName = mng.BrancheName

                                       }).OrderByDescending(x => x.ID).ToList();
            if (ListExchangeCenters.Count != 0)
            {
                txtRowId.Text = vint_itemTrMangID.ToString();
                txtBranchID.Text = ListExchangeCenters[0].Mnagement_ID.ToString();
                Nametxt.Text = ListExchangeCenters[0].mngName.ToString();
                comboBox1.SelectedValue = int.Parse(ListExchangeCenters[0].itemCatId.ToString());
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_BranchID = int.Parse(txtBranchID.Text);
            int Vint_TritemID = int.Parse(comboBox1.SelectedValue.ToString());
            this.dtb_TreasurItemMnagementTableAdapter.FillByMNgIDItTRID(this.depositCashDS.Dtb_TreasurItemMnagement, Vint_BranchID, Vint_TritemID);
            //var list = FsDb.Tbl_ItemsTreasureManagement.Where(x => x.ManagementID == Vint_BranchID && x.ItemsTreasureID == Vint_TritemID).ToList();
            //dataGridView1.DataSource = list;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }
    }
}
