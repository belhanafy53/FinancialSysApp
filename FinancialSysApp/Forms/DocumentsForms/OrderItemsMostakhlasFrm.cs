using DevExpress.XtraEditors;
using FinancialSysApp.Classes;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class OrderItemsMostakhlasFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_Parent_ID = 0;
        int Vint_IdItem = 0;
        //string Vstr_Name = "";
        decimal Vdec_Vat = 0;
        int Vint_VatId = 0;
        int Vint_DgCount = 0;
        //int Vint_KindOrder = 0;
        //long Vint_orderID = 0;
        int Vlong_OrderitemID = 0;

        bool Vbool_PriceIncludNO = true;
        public OrderItemsMostakhlasFrm()
        {
            InitializeComponent();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
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
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch, string StoreCode)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'|| " + StoreCode + " ='" + TxtSearch + "'");

            return Sql;
        }
        private void OrderItemsMostakhlasFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Tenders' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Unites' table. You can move, or remove it, as needed.
            this.tbl_UnitesTableAdapter.Fill(this.financialSysDataSet.Tbl_Unites);
            // TODO: This line of code loads data into the 'financialSysDataSet.Dtb_OrderItems' table. You can move, or remove it, as needed.
            this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ValueAddedTax' table. You can move, or remove it, as needed.
            this.tbl_ValueAddedTaxTableAdapter.Fill(this.financialSysDataSet.Tbl_ValueAddedTax);
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "StoreCode");
            }
            //string formatstring = string.Format("{0:yyyy MM dd}", txtOrderDate.Text);
            //txtOrderDate.Text = formatstring;
            if (txtqnty.Text == "")
            {
                txtqnty.Text = "0";
            }
           
            //LoadSerial();
            //*************
            Vint_DgCount = dataGridView1.RowCount;
             
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 62 && w.ProcdureId == 1003);
            if (validationSaveUser != null)
            {
                long Vint_orderID = long.Parse(txtOrderId.Text);
                //****************Refrences***************
                OrderAuditSelect(Vint_orderID);
                //***************************************
                chckBxItemData.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                chckBxItemData.Enabled = false;
                textBox3.Enabled = false;
            }

            //**************
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }
        private void OrderAuditSelect(long? Vint_OrderIDC)
        {
            var ListOrderAuditOrdUser = FsDb.Tbl_OrderAudit.FirstOrDefault(x => x.OrderId == Vint_OrderIDC && x.UserID == Program.GlbV_UserId);
            if (ListOrderAuditOrdUser != null)
            {
                if (ListOrderAuditOrdUser.OrderIItemDataID == true)
                { chckBxItemData.Checked = true; }
                else
                {
                    chckBxItemData.Checked = false;
                }
            }
            var ListOrderAudit = (from ordAud in FsDb.Tbl_OrderAudit
                                  join usr in FsDb.Tbl_User on ordAud.UserID equals usr.ID
                                  join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                  where (ordAud.OrderId == Vint_OrderIDC)
                                  select new
                                  {
                                      EmpName = emp.Name
                                  }).Distinct().ToList();
            if (ListOrderAudit != null)
            {
                string Vstr_RefrencesOrder = "";
                int WCount = int.Parse(ListOrderAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_RefrencesOrder = ListOrderAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
                }
                textBox3.Text = Vstr_RefrencesOrder;
            }
            else
            {
                textBox3.Text = "";
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string Result = "";

            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            txtItem.Text = ViewTree.SelectFullHirachyItem(treeView1, Vint_IdItem, Vint_Parent_ID);
            Result = txtItem.Text;

            var listResultF = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_IdItem);
            listResultF.Note = Result;
            FsDb.SaveChanges();
            dataGridView1.AllowUserToAddRows = false;

            txtItemID.Text = Vint_IdItem.ToString();
            if (txtItemOrderId.Text == "")
            {
                //cmbUnite.SelectedIndex = -1;
                //cmbUnite.SelectedText = "";
                //cmbUnite.SelectedText = " اختر الوحده";

                //cmbVat.SelectedIndex = -1;
                //cmbVat.SelectedText = "";
                //cmbVat.SelectedText = " اختر الضريبه";

                //radioGroup1.SelectedIndex = 0;
                //radioGroup2.SelectedIndex = 0;
                //txtattach.Text = "0";
                //txtValueBefore.Text = "0";
                //txtValueAfter.Text = "0";
                txtqnty.Text = "0";
                //txtPrice.Text = "0";


                //simpleButton7.Enabled = false;
                //simpleButton8.Enabled = false;
            }
            txtqnty.Select();
            this.ActiveControl = txtqnty;
            txtqnty.Focus();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string searchText = this.Nametxt.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                //txtSelected.Focus();
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

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtqnty.Focus();
            }
        }

       

        private void txtqnty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 62 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                       
                         if (txtqnty.Text == "")
                        {
                            MessageBox.Show("من فضلك ادخل الكمية ");
                            txtqnty.Focus();
                        }
                        
                        else
                        {
                             Tbl_OrderItems OrdIt = new Tbl_OrderItems()
                            {
                                OrderID = long.Parse(txtOrderId.Text),
                                ItemID = int.Parse(txtItemID.Text),
                                Quantity = decimal.Parse(txtqnty.Text),
                                 Sort_Row = short.Parse(txtSortRow.Text)
                            };
                            FsDb.Tbl_OrderItems.Add(OrdIt);
                            FsDb.SaveChanges();
                            MessageBox.Show("تم الحفظ");
                            this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));
                            Vint_DgCount = dataGridView1.RowCount;
                            
                            
                            txtqnty.Text = "0";
                            
                            txtItem.Text = "";
                            txtItemID.Text = "";
                            txtSortRow.Text = "";
                          

                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة بند .. برجاء مراجعة مدير المنظومه");
                }
            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton4.Focus();
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtItemOrderId.Text == "")
            {
                Vint_DgCount = dataGridView1.RowCount;
                txtSortRow.Text = (Vint_DgCount + 1).ToString();
            }
            txtqnty.Select();
            this.ActiveControl = txtqnty;
            txtqnty.Focus();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            if (txtItemOrderId.Text == "")
            {
                Vint_DgCount = dataGridView1.RowCount;
                txtSortRow.Text = (Vint_DgCount + 1).ToString();
            }
            txtqnty.Focus();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemOrderId.Text == "")
                {
                    Vint_DgCount = dataGridView1.RowCount;
                    txtSortRow.Text = (Vint_DgCount + 1).ToString();
                }
                txtqnty.Focus();
            }
        }
    }
}
