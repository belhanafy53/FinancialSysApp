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

using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Data;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class OrderItemsFrm : DevExpress.XtraEditors.XtraForm
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
        public OrderItemsFrm()
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
        private void dg2()
        {
            var resultitems = (from item in FsDb.Tbl_Items
                               join itemChild in FsDb.Tbl_Items on item.Parent_ID equals itemChild.ID

                               select new
                               {
                                   ID = item.ID,
                                   Name = item.Name,
                                   Parent_ID = item.Parent_ID,
                                   Note = item.Note
                               }).Take(30).OrderBy(x => x.Parent_ID).ThenBy(x => x.ID).ToList();
            dataGridView2.DataSource = resultitems;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Visible = false;

            dataGridView2.Columns["Note"].Visible = true;
            dataGridView2.Columns["Note"].Width = 400;
            dataGridView2.Columns["Note"].HeaderText = "";

        }
        private void OrderItemsFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Tenders' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Unites' table. You can move, or remove it, as needed.
            this.tbl_UnitesTableAdapter.Fill(this.financialSysDataSet.Tbl_Unites);
            // TODO: This line of code loads data into the 'financialSysDataSet.Dtb_OrderItems' table. You can move, or remove it, as needed.
            this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ValueAddedTax' table. You can move, or remove it, as needed.
            this.tbl_ValueAddedTaxTableAdapter.Fill(this.financialSysDataSet.Tbl_ValueAddedTax);
            //using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            //{
            //    ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "StoreCode");
            //}
            dg2(); 
            cmbUnite.SelectedIndex = -1;
            //cmbUnite.SelectedText = " اختر الوحده";

            cmbVat.SelectedIndex = -1;

            //cmbVat.SelectedText = " اختر الضريبه";

            radioGroup1.SelectedIndex = 0;
            radioGroup2.SelectedIndex = 0;
            txtattach.Text = "0";
            //LoadSerial();
            //*************
            Vint_DgCount = dataGridView1.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValueBefore.Text = (from DataGridViewRow row in dataGridView1.Rows
                                          select Convert.ToDouble(row.Cells[14].Value)).Sum().ToString();
                txtAllValueAfter.Text = (from DataGridViewRow row in dataGridView1.Rows
                                         select Convert.ToDouble(row.Cells[15].Value)).Sum().ToString();
            }
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
            //*****************
             
            long Vl_orderID = long.Parse(txtOrderId.Text);
            var resultForcheckind = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vl_orderID);
            if (resultForcheckind.OrderKind_ID == 2)
            {
                cmbUnite.Enabled = false;
                
                cmbVat.Enabled = false;
                 

                
                cmbVat.Enabled = false;
                txtattach.Enabled = false;
                txtValueBefore.Enabled = false;
                txtValueAfter.Enabled = false;
                txtqnty.Text = "0";
                txtPrice.Enabled = false;
                 
                txtItemID.Text = "";
                txtSortRow.Text = "";
                simpleButton7.Enabled = false;
                simpleButton8.Enabled = false;
            }
            //**************
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentCell.RowIndex;
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
                cmbUnite.SelectedIndex = -1;
                cmbUnite.SelectedText = "";
                cmbUnite.SelectedText = " اختر الوحده";

                cmbVat.SelectedIndex = -1;
                //cmbVat.SelectedText = "";
                //cmbVat.SelectedText = " اختر الضريبه";

                radioGroup1.SelectedIndex = 0;
                radioGroup2.SelectedIndex = 0;
                txtattach.Text = "0";
                txtValueBefore.Text = "0";
                txtValueAfter.Text = "0";
                txtqnty.Text = "0";
                txtPrice.Text = "0";


                simpleButton7.Enabled = false;
                simpleButton8.Enabled = false;
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
                    //CurrentNodeMatches.Clear();
                    //LastSearchText = searchText;
                    //LastNodeIndex = 0;
                    //SearchNodes(searchText, treeView1.Nodes[0]);
                    
                    dataGridView2.DataSource = FsDb.Tbl_Items.Where(x => x.Note.Contains(searchText)).ToList();
                    dataGridView2.Focus();
                }
                //if (LastNodeIndex >= 0 && CurrentNodeMatches.Count > 0 && LastNodeIndex < CurrentNodeMatches.Count)
                //{
                //    TreeNode SelectedNode = CurrentNodeMatches[LastNodeIndex];
                //    LastNodeIndex++;
                //    this.treeView1.SelectedNode = SelectedNode;
                //    this.treeView1.SelectedNode.Expand();
                //    this.treeView1.Select();

                //}
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
            long Vl_orderID = long.Parse(txtOrderId.Text);
            var resultForQuantity = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vl_orderID);
            if (e.KeyCode == Keys.Enter)
            {
               
                if (resultForQuantity.OrderKind_ID == 2)
                {
                    Tbl_OrderItems OrdIt = new Tbl_OrderItems()
                    {
                        OrderID = long.Parse(txtOrderId.Text),
                        ItemID = int.Parse(txtItemID.Text),
                        Quantity = decimal.Parse(txtqnty.Text),
                        UnitID = 6,
                        VatTax = false,
                        PriceIncludedNon = true,
                        ValueAddedTaxId = 0,
                        Price = 0,
                        ValueAfter = 0,
                        ValueBefore = 0,
                        InstallationPrice = 0,
                        Sort_Row = short.Parse(txtSortRow.Text)
                    };
                    FsDb.Tbl_OrderItems.Add(OrdIt);
                    FsDb.SaveChanges();
                    MessageBox.Show("تم الحفظ");
                    this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));
                    Vint_DgCount = dataGridView1.RowCount;
                    if (Vint_DgCount != 0)
                    {
                        txtAllValueBefore.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                  select Convert.ToDouble(row.Cells[13].Value)).Sum().ToString();
                        txtAllValueAfter.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                 select Convert.ToDouble(row.Cells[14].Value)).Sum().ToString();
                    }
                    cmbUnite.SelectedIndex = -1;
                    cmbUnite.SelectedText = "";
                    cmbUnite.SelectedText = " اختر الوحده";

                    cmbVat.SelectedIndex = -1;
                    cmbVat.SelectedText = "";
                    cmbVat.SelectedText = " اختر الضريبه";

                    radioGroup1.SelectedIndex = 0;
                    radioGroup2.SelectedIndex = 0;
                    cmbVat.Enabled = true;
                    txtattach.Text = "0";
                    txtValueBefore.Text = "0";
                    txtValueAfter.Text = "0";
                    txtqnty.Text = "0";
                    txtPrice.Text = "0";
                    txtItem.Text = "";
                    txtItemID.Text = "";
                    txtSortRow.Text = "";
                    simpleButton7.Enabled = false;
                    simpleButton8.Enabled = false;

                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                }
                else
                {
                    cmbUnite.Focus();
                }
            }
        }

        private void cmbUnite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radioGroup1.Focus();
            }
        }

        private void radioGroup1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioGroup1.SelectedIndex == 0)
                {
                    cmbVat.Enabled = true;
                    cmbVat.Focus();
                }
                else
                {
                    cmbVat.Enabled = false;
                    txtattach.Focus();
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtattach.Focus();
            }

        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {

            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 62 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (radioGroup1.SelectedIndex == 0 && cmbVat.SelectedIndex == -1)
                    {
                        MessageBox.Show("من فضلك اختر الضريبه");
                        cmbVat.Focus();
                    }
                    else if (txtqnty.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل الكمية ");
                        txtqnty.Focus();
                    }
                    else if (cmbUnite.SelectedIndex == -1)
                    {
                        MessageBox.Show("من فضلك ادخل الوحده ");
                        cmbUnite.Focus();
                    }
                    else
                    {
                        int? Vint_VatValue = 0;
                        bool Vbool_VatorNo = true;

                        if (radioGroup1.SelectedIndex == 0)
                        {
                            Vbool_VatorNo = true;
                            Vint_VatValue = int.Parse(cmbVat.SelectedValue.ToString());
                        }
                        else
                        {
                            Vbool_VatorNo = false;

                            Vint_VatValue = null;
                        }
                        if (radioGroup2.SelectedIndex == 0)
                        {
                            Vbool_PriceIncludNO = true;

                        }
                        else
                        {
                            Vbool_PriceIncludNO = false;


                        }


                        Tbl_OrderItems OrdIt = new Tbl_OrderItems()
                        {
                            OrderID = long.Parse(txtOrderId.Text),
                            ItemID = int.Parse(txtItemID.Text),
                            Quantity = decimal.Parse(txtqnty.Text),
                            UnitID = int.Parse(cmbUnite.SelectedValue.ToString()),
                            VatTax = Vbool_VatorNo,
                            PriceIncludedNon = Vbool_PriceIncludNO,
                            ValueAddedTaxId = Vint_VatValue,
                            Price = decimal.Parse(txtPrice.Text),
                            ValueAfter = decimal.Parse(txtValueAfter.Text),
                            ValueBefore = decimal.Parse(txtValueBefore.Text),
                            InstallationPrice = decimal.Parse(txtattach.Text),
                            Sort_Row = short.Parse(txtSortRow.Text)
                        };
                        FsDb.Tbl_OrderItems.Add(OrdIt);
                        FsDb.SaveChanges();
                        MessageBox.Show("تم الحفظ");
                        this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));
                        Vint_DgCount = dataGridView1.RowCount;
                        if (Vint_DgCount != 0)
                        {
                            txtAllValueBefore.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                      select Convert.ToDouble(row.Cells[13].Value)).Sum().ToString();
                            txtAllValueAfter.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                     select Convert.ToDouble(row.Cells[14].Value)).Sum().ToString();
                        }
                        cmbUnite.SelectedIndex = -1;
                        cmbUnite.SelectedText = "";
                        cmbUnite.SelectedText = " اختر الوحده";

                        cmbVat.SelectedIndex = -1;
                        cmbVat.SelectedText = "";
                        cmbVat.SelectedText = " اختر الضريبه";

                        radioGroup1.SelectedIndex = 0;
                        radioGroup2.SelectedIndex = 0;
                        cmbVat.Enabled = true;
                        txtattach.Text = "0";
                        txtValueBefore.Text = "0";
                        txtValueAfter.Text = "0";
                        txtqnty.Text = "0";
                        txtPrice.Text = "0";
                        txtItem.Text = "";
                        txtItemID.Text = "";
                        txtSortRow.Text = "";
                        simpleButton7.Enabled = false;
                        simpleButton8.Enabled = false;

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

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Focus();
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
            txtqnty.Select();
            this.ActiveControl = txtqnty;
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

        private void txtattach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radioGroup2.Focus();
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                Vbool_PriceIncludNO = true;

            }
            else
            {
                Vbool_PriceIncludNO = false;


            }
            if (cmbVat.SelectedValue != null && radioGroup1.SelectedIndex == 0)
            {
                Vint_VatId = int.Parse(cmbVat.SelectedValue.ToString());
                var ListVat = FsDb.Tbl_ValueAddedTax.FirstOrDefault(x => x.ID == Vint_VatId);
                Vdec_Vat = decimal.Parse(ListVat.Value.ToString());

                txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();

            }
            else
            {
                txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
            }
            if (txtPrice.Text == "")
            {
                txtPrice.Text = "0";
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text != "" && txtqnty.Text != "")
            {
                if (radioGroup2.SelectedIndex == 0)
                {
                    Vbool_PriceIncludNO = true;

                }
                else
                {
                    Vbool_PriceIncludNO = false;


                }

                if (radioGroup1.SelectedIndex == 0)
                {
                    if (cmbVat.SelectedValue != null)
                    {
                        radioGroup2.Enabled = true;
                        Vint_VatId = int.Parse(cmbVat.SelectedValue.ToString());
                        var ListVat = FsDb.Tbl_ValueAddedTax.FirstOrDefault(x => x.ID == Vint_VatId);

                        if (radioGroup1.SelectedIndex == 0)
                        {
                            Vdec_Vat = decimal.Parse(ListVat.Value.ToString());
                            txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                            txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                        }
                        else
                        {
                            radioGroup2.Enabled = false;
                            cmbVat.SelectedIndex = -1;
                            cmbVat.SelectedText = "";
                            cmbVat.SelectedText = " اختر الضريبه";
                            txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                            txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                        }
                    }

                }
                else
                {
                    Vdec_Vat = 0;

                    cmbVat.SelectedIndex = -1;
                    cmbVat.SelectedText = "";
                    cmbVat.SelectedText = " اختر الضريبه";

                    txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                    txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                }
            }
            else
            {
                //cmbVat.Enabled = false;
                cmbVat.SelectedIndex = -1;
                cmbVat.SelectedText = "";
                cmbVat.SelectedText = " اختر الضريبه";
            }
        }

        private void cmbVat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text != "" && txtqnty.Text != "")
            {
                if (radioGroup2.SelectedIndex == 0)
                {
                    Vbool_PriceIncludNO = true;

                }
                else
                {
                    Vbool_PriceIncludNO = false;


                }

                if (cmbVat.SelectedValue != null)
                {
                    radioGroup2.Enabled = true;
                    Vint_VatId = int.Parse(cmbVat.SelectedValue.ToString());
                    var ListVat = FsDb.Tbl_ValueAddedTax.FirstOrDefault(x => x.ID == Vint_VatId);

                    if (radioGroup1.SelectedIndex == 0)
                    {
                        Vdec_Vat = decimal.Parse(ListVat.Value.ToString());
                        txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                        txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                    }
                    else
                    {
                        cmbVat.SelectedIndex = -1;
                        cmbVat.SelectedText = "";
                        cmbVat.SelectedText = " اختر الضريبه";
                        txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                        txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                    }
                }
            }

        }

        private void txtattach_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text != "" && txtqnty.Text != "")
            {
                if (radioGroup2.SelectedIndex == 0)
                {
                    Vbool_PriceIncludNO = true;

                }
                else
                {
                    Vbool_PriceIncludNO = false;


                }
                if (cmbVat.SelectedValue != null && radioGroup1.SelectedIndex == 0)
                {
                    Vint_VatId = int.Parse(cmbVat.SelectedValue.ToString());
                    var ListVat = FsDb.Tbl_ValueAddedTax.FirstOrDefault(x => x.ID == Vint_VatId);

                    Vdec_Vat = decimal.Parse(ListVat.Value.ToString());
                    txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                    txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();

                }
                else
                {
                    txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                    txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                }
            }
            else
            {
                if (txtattach.Text == "")
                {
                    txtattach.Text = "0";
                }
            }
        }

        private void txtqnty_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text != "")
            {
                if (radioGroup2.SelectedIndex == 0)
                {
                    Vbool_PriceIncludNO = true;

                }
                else
                {
                    Vbool_PriceIncludNO = false;


                }

                if (cmbVat.SelectedValue != null)
                {
                    Vint_VatId = int.Parse(cmbVat.SelectedValue.ToString());
                    var ListVat = FsDb.Tbl_ValueAddedTax.FirstOrDefault(x => x.ID == Vint_VatId);

                    if (radioGroup1.SelectedIndex == 0)
                    {
                        Vdec_Vat = decimal.Parse(ListVat.Value.ToString());
                        txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                        txtValueBefore.Text = string.Format("{0:NO}", double.Parse(txtValueBefore.Text));
                        txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                        txtValueAfter.Text = string.Format("{0:#,##0.00}", double.Parse(txtValueAfter.Text));
                        //label11.Text = string.Format("{0:N2}", CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat).ToString());
                    }
                    else
                    {
                        cmbVat.SelectedIndex = -1;
                        cmbVat.SelectedText = " اختر الضريبه";
                        cmbVat.SelectedText = "";
                        txtValueBefore.Text = string.Format("{0:#,##0.00}", CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString());
                        txtValueBefore.Text = string.Format("{0:#,##0.00}", double.Parse(txtValueBefore.Text));
                        txtValueAfter.Text = string.Format("{0:#,##0.00}", CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString());
                        txtValueAfter.Text = string.Format("{0:#,##0.00}", double.Parse(txtValueAfter.Text));
                    }
                }
            }
            else
            {
                if (txtqnty.Text == "")
                {
                    txtqnty.Text = "0";
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            long Vlong_itemorderID = long.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ListOrderItem = FsDb.Tbl_OrderItems.FirstOrDefault(x => x.ID == Vlong_itemorderID);
            int Vint_vattax = 0;
            int Vint_PriceInc = 0;
            if (ListOrderItem.VatTax == false)
            {
                Vint_vattax = 1;
            }
            if (ListOrderItem.PriceIncludedNon == false)
            {
                Vint_PriceInc = 1;
            }
            txtItemID.Text = ListOrderItem.ItemID.ToString();
            txtItemOrderId.Text = ListOrderItem.ID.ToString();
            txtItem.Text = ListOrderItem.Tbl_Items.Note;
            txtqnty.Text = ListOrderItem.Quantity.ToString();
            txtattach.Text = ListOrderItem.InstallationPrice.ToString();

            txtPrice.Text = ListOrderItem.Price.ToString();

            txtValueBefore.Text = Math.Round((ListOrderItem.ValueBefore), 2).ToString();
            txtValueAfter.Text = Math.Round((ListOrderItem.ValueAfter), 2).ToString();



            cmbUnite.SelectedValue = int.Parse(ListOrderItem.UnitID.ToString());
            if (ListOrderItem.ValueAddedTaxId != null)
            {
                cmbVat.Enabled = true;
                cmbVat.SelectedValue = int.Parse(ListOrderItem.ValueAddedTaxId.ToString());
            }
            txtSortRow.Text = ListOrderItem.Sort_Row.ToString();
            radioGroup1.SelectedIndex = Vint_vattax;
            radioGroup2.SelectedIndex = Vint_PriceInc;
            simpleButton7.Enabled = true;
            simpleButton8.Enabled = true;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 62 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                Vlong_OrderitemID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var ListOrderItem = FsDb.Tbl_OrderItems.FirstOrDefault(x => x.ID == Vlong_OrderitemID);
                if (ListOrderItem != null)
                {

                    ListOrderItem.ItemID = int.Parse(txtItemID.Text);
                    ListOrderItem.Quantity = decimal.Parse(txtqnty.Text);
                    ListOrderItem.InstallationPrice = decimal.Parse(txtattach.Text);
                    ListOrderItem.Price = decimal.Parse(txtPrice.Text);
                    ListOrderItem.ValueBefore = decimal.Parse(txtValueBefore.Text);
                    ListOrderItem.ValueAfter = decimal.Parse(txtValueAfter.Text);
                    ListOrderItem.UnitID = int.Parse(cmbUnite.SelectedValue.ToString());
                    if (cmbVat.SelectedValue != null)
                    {
                        ListOrderItem.ValueAddedTaxId = int.Parse(cmbVat.SelectedValue.ToString()); ;
                    }
                    else
                    {
                        ListOrderItem.ValueAddedTaxId = null;
                    }
                    ListOrderItem.Sort_Row = short.Parse(txtSortRow.Text);
                    if (radioGroup1.SelectedIndex == 0)
                    {
                        ListOrderItem.VatTax = true;
                    }
                    else
                    {
                        ListOrderItem.VatTax = false;
                    }
                    if (radioGroup2.SelectedIndex == 0)
                    {
                        ListOrderItem.PriceIncludedNon = true;
                    }
                    else
                    {
                        ListOrderItem.PriceIncludedNon = false;
                    }
                    FsDb.SaveChanges();
                    MessageBox.Show("تم التعديل");
                    this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));
                    cmbUnite.SelectedIndex = -1;
                    cmbUnite.SelectedText = "";
                    cmbUnite.SelectedText = " اختر الوحده";

                    cmbVat.SelectedIndex = -1;
                    cmbVat.SelectedText = "";
                    cmbVat.SelectedText = " اختر الضريبه";

                    radioGroup1.SelectedIndex = 0;
                    radioGroup2.SelectedIndex = 0;
                    cmbVat.Enabled = true;
                    txtattach.Text = "0";
                    txtValueBefore.Text = "0";
                    txtValueAfter.Text = "0";
                    txtqnty.Text = "0";
                    txtPrice.Text = "0";
                    txtItem.Text = "";
                    txtItemID.Text = "";
                    txtSortRow.Text = "";
                    simpleButton7.Enabled = false;
                    simpleButton8.Enabled = false;
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل  بند .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 62 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                Vlong_OrderitemID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var resultMessageYesNo = MessageBox.Show("هل تريد حدف هدا البند  ؟", "حدف بند من بنود الامر ", MessageBoxButtons.YesNo);

                if (resultMessageYesNo == DialogResult.Yes)
                {
                    var ListOrderItemDel = FsDb.Tbl_OrderItems.FirstOrDefault(x => x.ID == Vlong_OrderitemID);
                    FsDb.Tbl_OrderItems.Remove(ListOrderItemDel);
                    FsDb.SaveChanges();
                    MessageBox.Show("تم الحذف");
                    this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));
                    cmbUnite.SelectedIndex = -1;
                    cmbUnite.SelectedText = "";
                    cmbUnite.SelectedText = " اختر الوحده";

                    cmbVat.SelectedIndex = -1;
                    cmbVat.SelectedText = "";
                    cmbVat.SelectedText = " اختر الضريبه";

                    radioGroup1.SelectedIndex = 0;
                    radioGroup2.SelectedIndex = 0;
                    cmbVat.Enabled = true;
                    txtattach.Text = "0";
                    txtValueBefore.Text = "0";
                    txtValueAfter.Text = "0";
                    txtqnty.Text = "0";
                    txtPrice.Text = "0";
                    txtItem.Text = "";
                    txtItemID.Text = "";
                    txtSortRow.Text = "";
                    simpleButton7.Enabled = false;
                    simpleButton8.Enabled = false;
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();

                }
                else
                {
                    cmbUnite.SelectedIndex = -1;
                    cmbUnite.SelectedText = "";
                    cmbUnite.SelectedText = " اختر الوحده";

                    cmbVat.SelectedIndex = -1;
                    cmbVat.SelectedText = "";
                    cmbVat.SelectedText = " اختر الضريبه";

                    radioGroup1.SelectedIndex = 0;
                    radioGroup2.SelectedIndex = 0;
                    cmbVat.Enabled = true;
                    txtattach.Text = "0";
                    txtValueBefore.Text = "0";
                    txtValueAfter.Text = "0";
                    txtqnty.Text = "0";
                    txtPrice.Text = "0";
                    txtItem.Text = "";
                    txtItemID.Text = "";

                    simpleButton7.Enabled = false;
                    simpleButton8.Enabled = false;
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

        private void radioGroup2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrice.Focus();
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                if (txtattach.Text == "" || txtattach.Text == "0") { txtattach.Text = "0"; }
                if (txtqnty.Text == "") { txtqnty.Text = "0"; }
                if (txtPrice.Text == "") { txtPrice.Text = "0"; }

                Vbool_PriceIncludNO = true;
                if (cmbVat.SelectedValue != null)
                {
                    Vint_VatId = int.Parse(cmbVat.SelectedValue.ToString());
                    var ListVat = FsDb.Tbl_ValueAddedTax.FirstOrDefault(x => x.ID == Vint_VatId);
                    Vdec_Vat = decimal.Parse(ListVat.Value.ToString());
                }
                else
                {
                    Vdec_Vat = 0;
                }
                txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
            }
            else
            {
                if (txtattach.Text == "" || txtattach.Text == "0") { txtattach.Text = "0"; }
                Vbool_PriceIncludNO = false;
                if (txtqnty.Text == "") { txtqnty.Text = "0"; }
                if (txtPrice.Text == "") { txtPrice.Text = "0"; }

                if (cmbVat.SelectedValue != null)
                {
                    Vint_VatId = int.Parse(cmbVat.SelectedValue.ToString());
                    var ListVat = FsDb.Tbl_ValueAddedTax.FirstOrDefault(x => x.ID == Vint_VatId);
                    Vdec_Vat = decimal.Parse(ListVat.Value.ToString());
                }
                else
                {
                    Vdec_Vat = 0;
                }

                txtValueBefore.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueBefore(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();
                txtValueAfter.Text = CalcOrderItemsValue.Cs_CalcOrderItemsValueAfter(txtqnty.Text, txtPrice.Text, txtattach.Text, Vdec_Vat, Vbool_PriceIncludNO).ToString();

            }
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            Vint_DgCount = dataGridView1.RowCount;
            txtSortRow.Text = (Vint_DgCount + 1).ToString();
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

        private void chckBxItemData_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtOrderId.Text != "")
            {
                long Vlng_OrderID = long.Parse(txtOrderId.Text);
                bool Vbl_itemso = false;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 66 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {


                    Vbl_itemso = true;
                    var ListOrderAuditOrdUser = FsDb.Tbl_OrderAudit.FirstOrDefault(x => x.OrderId == Vlng_OrderID && x.UserID == Program.GlbV_UserId);
                    if (ListOrderAuditOrdUser == null)

                    {

                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));


                        Tbl_OrderAudit OrdAud = new Tbl_OrderAudit
                        {

                            UserID = Program.GlbV_UserId,
                            OrderId = Vlng_OrderID,

                            OrderIItemDataID = Vbl_itemso,

                            ReferenceDate = Vdt_Today
                        };
                        FsDb.Tbl_OrderAudit.Add(OrdAud);
                        FsDb.SaveChanges();

                        int Vint_LastRow = OrdAud.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مراجعة بنود امر",
                            TableName = "Tbl_OrderAudit",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراجعة بنود الاوامر"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        //****************Refrences***************
                        OrderAuditSelect(Vlng_OrderID);
                        //***************************************


                    }
                    else
                    {
                        if (chckBxItemData.Checked == true)
                        {
                            Vbl_itemso = true;
                        }
                        else
                        {
                            Vbl_itemso = false;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListOrderAuditOrdUsero = FsDb.Tbl_OrderAudit.FirstOrDefault(x => x.OrderId == Vlng_OrderID && x.UserID == Program.GlbV_UserId);

                        ListOrderAuditOrdUsero.OrderIItemDataID = Vbl_itemso;

                        ListOrderAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //****************Refrences***************
                        OrderAuditSelect(Vlng_OrderID);
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  مراجعه امر .. برجاء مراجعة مدير المنظومه");
                }
            }
            else
            {
                MessageBox.Show("اختر الامر المراد مراجعته");
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإثبات مراجعة الأمر", TB, 0, 0, VisibleTime);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.OrderAuditAddFrm t = new Forms.DocumentsForms.OrderAuditAddFrm();
                t.txtOrderId.Text = this.txtOrderId.Text;
                t.txtOrderNo.Text = this.txtOrderNo.Text;

                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                if (txtOrderId.Text != "")
                {
                    t.ShowDialog();
                }
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            string Result = "";

            Vint_IdItem = int.Parse(dataGridView2.CurrentRow.Cells["ID"].Value.ToString());
            txtItem.Text = dataGridView2.CurrentRow.Cells["Note"].Value.ToString();
                          
            dataGridView1.AllowUserToAddRows = false;
            Vint_DgCount = dataGridView1.RowCount;
            txtSortRow.Text = (Vint_DgCount + 1).ToString();
            txtItemID.Text = Vint_IdItem.ToString();
            if (txtItemOrderId.Text == "")
            {
                cmbUnite.SelectedIndex = -1;
                cmbUnite.SelectedText = "";
                cmbUnite.SelectedText = " اختر الوحده";

                cmbVat.SelectedIndex = -1;
                //cmbVat.SelectedText = "";
                //cmbVat.SelectedText = " اختر الضريبه";

                radioGroup1.SelectedIndex = 0;
                radioGroup2.SelectedIndex = 0;
                txtattach.Text = "0";
                txtValueBefore.Text = "0";
                txtValueAfter.Text = "0";
                txtqnty.Text = "0";
                txtPrice.Text = "0";


                simpleButton7.Enabled = false;
                simpleButton8.Enabled = false;
            }
            txtqnty.Select();
            this.ActiveControl = txtqnty;
            txtqnty.Focus();
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            string searchText = this.Nametxt.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                dg2();
               
            }
            else
            {
                var resultitems = (from item in FsDb.Tbl_Items
                                   join itemChild in FsDb.Tbl_Items on item.Parent_ID equals itemChild.ID
                                   where(item.Note.StartsWith(searchText))
                                   select new
                                   {
                                       ID = item.ID,
                                       Name = item.Name,
                                       Parent_ID = item.Parent_ID,
                                       Note = item.Note
                                   }).Take(30).OrderBy(x => x.Parent_ID).ThenBy(x => x.ID).ToList();
                dataGridView2.DataSource = resultitems;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].Visible = false;

                dataGridView2.Columns["Note"].Visible = true;
                dataGridView2.Columns["Note"].Width = 400;
                dataGridView2.Columns["Note"].HeaderText = "";

               
                
                
            }
        }
    }

}