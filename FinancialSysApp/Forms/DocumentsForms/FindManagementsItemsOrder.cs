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
using DevComponents.DotNetBar.Controls;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class FindManagementsItemsOrder : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_IdManagement = 0;
        int? Vint_itemOrderId = 0;
        int? Vint_Parent_ID = 0;
        int? Vint_ItemID = 0;
        int? Vint_OrderID = 0;
        //decimal Vdec_qntyManagement = 0;
        decimal Vdec_qntyOrderItem = 0;
        //decimal Vdec_qnty = 0;
        long Vlong_OrderManagementitemID = 0;
        string Vstr_NameManagement = "";
        string Vstr_UniteName = "";
        //******* Tree View
        private List<TreeNode> CurrentNodeMatches = new List<TreeNode>();
        private int LastNodeIndex = 0;
        private string LastSearchText;
        //***************
        private void SearchNodes(string SearchText, TreeNode StartNode)
        {
            TreeNode node = null;
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
        public FindManagementsItemsOrder()
        {
            InitializeComponent();
        }
        private void FillDatagridview2Orderid(int? Vint_OrderID)
        {
            var listmanagementItem = (from Mngit in FsDb.Tbl_OrderManagementItems
                                      join Mng in FsDb.Tbl_Management on Mngit.ManagementID equals Mng.Management_ID
                                      join ordit in FsDb.Tbl_OrderItems on Mngit.OrderItemsID equals ordit.ID
                                      join it in FsDb.Tbl_Items on ordit.ItemID equals it.ID
                                      join un in FsDb.Tbl_Unites on ordit.UnitID equals un.ID
                                      where (Mngit.OrderId == Vint_OrderID)

                                      select new
                                      {
                                          ID = ordit.ID,
                                          OrderID = ordit.OrderID,
                                          ItemID = ordit.ItemID,
                                          Name = it.Name,
                                          UnitID = ordit.UnitID,
                                          VatTax = ordit.VatTax,
                                          Price = ordit.Price,
                                          Sort_Row = ordit.Sort_Row,
                                          FullItemName = it.Note,
                                          ValueAfter = ordit.ValueAfter,
                                          ValueBefore = ordit.ValueBefore,
                                          InstallationPrice = ordit.InstallationPrice,

                                          PriceIncludedNon = ordit.PriceIncludedNon,
                                          Quantity = Mngit.Quantity,
                                          uniteName = un.Name,
                                          OrderItemsID = Mngit.OrderItemsID,
                                          ManagementID = Mngit.ManagementID,
                                          QntyManagement = ordit.Quantity,
                                          MngName = Mng.Name,
                                          OrdMngItemID = Mngit.ID
                                      }).OrderBy(sr => sr.Sort_Row).ToList();
            dataGridView2.DataSource = listmanagementItem;
            dataGridView2.Columns["FullItemName"].HeaderText = "البند";

            dataGridView2.Columns["Quantity"].HeaderText = "الكمية";
            dataGridView2.Columns["Sort_Row"].HeaderText = "رقم البند بالأمر";
            dataGridView2.Columns["MngName"].HeaderText = "الاداره";
            dataGridView2.Columns["uniteName"].HeaderText = "الوحده";
            dataGridView2.Columns["FullItemName"].Width = 220;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["OrderID"].Visible = false;
            dataGridView2.Columns["ItemID"].Visible = false;
            dataGridView2.Columns["Name"].Visible = false;
            dataGridView2.Columns["PriceIncludedNon"].Visible = false;

            dataGridView2.Columns["UnitID"].Visible = false;
            dataGridView2.Columns["VatTax"].Visible = false;
            dataGridView2.Columns["Price"].Visible = false;
            dataGridView2.Columns["ValueAfter"].Visible = false;
            dataGridView2.Columns["ValueBefore"].Visible = false;

            dataGridView2.Columns["InstallationPrice"].Visible = false;
            dataGridView2.Columns["OrderItemsID"].Visible = false;
            dataGridView2.Columns["ManagementID"].Visible = false;
            dataGridView2.Columns["QntyManagement"].Visible = false;
            dataGridView2.Columns["OrdMngItemID"].Visible = false;

            groupBox1.Text = "بنود الامر رقم " + " " + txtOrderNo.Text + "بتاريخ " + dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + "والتي تم توزيعها على الادارات المختلفه";
            //Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }
        private void FillDatagridview2OrderMangement(int? Vint_OrderID, int? Vint_IdManagement)
        {
            var listmanagementItem = (from Mngit in FsDb.Tbl_OrderManagementItems
                                      join Mng in FsDb.Tbl_Management on Mngit.ManagementID equals Mng.Management_ID
                                      join ordit in FsDb.Tbl_OrderItems on Mngit.OrderItemsID equals ordit.ID
                                      join it in FsDb.Tbl_Items on ordit.ItemID equals it.ID
                                      join un in FsDb.Tbl_Unites on ordit.UnitID equals un.ID
                                      where (Mngit.OrderId == Vint_OrderID && Mng.Management_ID == Vint_IdManagement)

                                      select new
                                      {
                                          ID = ordit.ID,
                                          OrderID = ordit.OrderID,
                                          ItemID = ordit.ItemID,
                                          Name = it.Name,
                                          UnitID = ordit.UnitID,
                                          VatTax = ordit.VatTax,
                                          Price = ordit.Price,
                                          Sort_Row = ordit.Sort_Row,
                                          FullItemName = it.Note,
                                          ValueAfter = ordit.ValueAfter,
                                          ValueBefore = ordit.ValueBefore,
                                          InstallationPrice = ordit.InstallationPrice,

                                          PriceIncludedNon = ordit.PriceIncludedNon,
                                          Quantity = Mngit.Quantity,
                                          uniteName = un.Name,
                                          OrderItemsID = Mngit.OrderItemsID,
                                          ManagementID = Mngit.ManagementID,
                                          QntyManagement = ordit.Quantity,
                                          MngName = Mng.Name,
                                          OrdMngItemID = Mngit.ID
                                      }).OrderBy(sr => sr.Sort_Row).ToList();
            dataGridView2.DataSource = listmanagementItem;
            dataGridView2.Columns["FullItemName"].HeaderText = "البند";

            dataGridView2.Columns["Quantity"].HeaderText = "الكمية";
            dataGridView2.Columns["Sort_Row"].HeaderText = "رقم البند بالأمر";
            dataGridView2.Columns["MngName"].HeaderText = "الاداره";
            dataGridView2.Columns["uniteName"].HeaderText = "الوحده";
            dataGridView2.Columns["FullItemName"].Width = 220;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["OrderID"].Visible = false;
            dataGridView2.Columns["ItemID"].Visible = false;
            dataGridView2.Columns["Name"].Visible = false;
            dataGridView2.Columns["PriceIncludedNon"].Visible = false;

            dataGridView2.Columns["UnitID"].Visible = false;
            dataGridView2.Columns["VatTax"].Visible = false;
            dataGridView2.Columns["Price"].Visible = false;
            dataGridView2.Columns["ValueAfter"].Visible = false;
            dataGridView2.Columns["ValueBefore"].Visible = false;

            dataGridView2.Columns["InstallationPrice"].Visible = false;
            dataGridView2.Columns["OrderItemsID"].Visible = false;
            dataGridView2.Columns["ManagementID"].Visible = false;
            dataGridView2.Columns["QntyManagement"].Visible = false;
            dataGridView2.Columns["OrdMngItemID"].Visible = false;
            //groupBox1.Text = "بنود الامر رقم " + " " + txtOrderNo.Text + "بتاريخ " + dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + "والتي تم توزيعها على الادارات المختلفه";
            //Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void FillDatagridview2OrderManagementItem(int? Vint_OrderID, int? Vint_IdManagement, int? Vint_itemOrderId)
        {
            var listmanagementItem = (from Mngit in FsDb.Tbl_OrderManagementItems
                                      join Mng in FsDb.Tbl_Management on Mngit.ManagementID equals Mng.Management_ID
                                      join ordit in FsDb.Tbl_OrderItems on Mngit.OrderItemsID equals ordit.ID
                                      join it in FsDb.Tbl_Items on ordit.ItemID equals it.ID
                                      join un in FsDb.Tbl_Unites on ordit.UnitID equals un.ID
                                      where (Mngit.OrderId == Vint_OrderID && Mng.Management_ID == Vint_IdManagement && ordit.ID == Vint_itemOrderId)

                                      select new
                                      {
                                          ID = ordit.ID,
                                          OrderID = ordit.OrderID,
                                          ItemID = ordit.ItemID,
                                          Name = it.Name,
                                          UnitID = ordit.UnitID,
                                          VatTax = ordit.VatTax,
                                          Price = ordit.Price,
                                          Sort_Row = ordit.Sort_Row,
                                          FullItemName = it.Note,
                                          ValueAfter = ordit.ValueAfter,
                                          ValueBefore = ordit.ValueBefore,
                                          InstallationPrice = ordit.InstallationPrice,

                                          PriceIncludedNon = ordit.PriceIncludedNon,
                                          Quantity = Mngit.Quantity,
                                          uniteName = un.Name,
                                          OrderItemsID = Mngit.OrderItemsID,
                                          ManagementID = Mngit.ManagementID,
                                          QntyManagement = ordit.Quantity,
                                          MngName = Mng.Name,
                                          OrdMngItemID = Mngit.ID

                                      }).OrderBy(sr => sr.Sort_Row).ToList();
            dataGridView2.DataSource = listmanagementItem;
            dataGridView2.Columns["FullItemName"].HeaderText = "البند";

            dataGridView2.Columns["Quantity"].HeaderText = "الكمية";
            dataGridView2.Columns["Sort_Row"].HeaderText = "رقم البند بالأمر";
            dataGridView2.Columns["MngName"].HeaderText = "الاداره";
            dataGridView2.Columns["uniteName"].HeaderText = "الوحده";
            dataGridView2.Columns["FullItemName"].Width = 220;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["OrderID"].Visible = false;
            dataGridView2.Columns["ItemID"].Visible = false;
            dataGridView2.Columns["Name"].Visible = false;
            dataGridView2.Columns["PriceIncludedNon"].Visible = false;

            dataGridView2.Columns["UnitID"].Visible = false;
            dataGridView2.Columns["VatTax"].Visible = false;
            dataGridView2.Columns["Price"].Visible = false;
            dataGridView2.Columns["ValueAfter"].Visible = false;
            dataGridView2.Columns["ValueBefore"].Visible = false;

            dataGridView2.Columns["InstallationPrice"].Visible = false;
            dataGridView2.Columns["OrderItemsID"].Visible = false;
            dataGridView2.Columns["ManagementID"].Visible = false;
            dataGridView2.Columns["QntyManagement"].Visible = false;
            dataGridView2.Columns["OrdMngItemID"].Visible = false;
        }

        private void FillDatagridview2Orderiditem(int? Vint_OrderID , int? Vint_ItemId)
        {
            var listmanagementItem = (from Mngit in FsDb.Tbl_OrderManagementItems
                                      join Mng in FsDb.Tbl_Management on Mngit.ManagementID equals Mng.Management_ID
                                      join ordit in FsDb.Tbl_OrderItems on Mngit.OrderItemsID equals ordit.ID
                                      join it in FsDb.Tbl_Items on ordit.ItemID equals it.ID
                                      join un in FsDb.Tbl_Unites on ordit.UnitID equals un.ID
                                      where (Mngit.OrderId == Vint_OrderID && Mngit.ItemID == Vint_ItemID)

                                      select new
                                      {
                                          ID = ordit.ID,
                                          OrderID = ordit.OrderID,
                                          ItemID = ordit.ItemID,
                                          Name = it.Name,
                                          UnitID = ordit.UnitID,
                                          VatTax = ordit.VatTax,
                                          Price = ordit.Price,
                                          Sort_Row = ordit.Sort_Row,
                                          FullItemName = it.Note,
                                          ValueAfter = ordit.ValueAfter,
                                          ValueBefore = ordit.ValueBefore,
                                          InstallationPrice = ordit.InstallationPrice,

                                          PriceIncludedNon = ordit.PriceIncludedNon,
                                          Quantity = Mngit.Quantity,
                                          uniteName = un.Name,
                                          OrderItemsID = Mngit.OrderItemsID,
                                          ManagementID = Mngit.ManagementID,
                                          QntyManagement = ordit.Quantity,
                                          MngName = Mng.Name,
                                          OrdMngItemID = Mngit.ID
                                      }).OrderBy(sr => sr.Sort_Row).ToList();
            dataGridView2.DataSource = listmanagementItem;
            dataGridView2.Columns["FullItemName"].HeaderText = "البند";

            dataGridView2.Columns["Quantity"].HeaderText = "الكمية";
            dataGridView2.Columns["Sort_Row"].HeaderText = "رقم البند بالأمر";
            dataGridView2.Columns["MngName"].HeaderText = "الاداره";
            dataGridView2.Columns["uniteName"].HeaderText = "الوحده";
            dataGridView2.Columns["FullItemName"].Width = 220;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["OrderID"].Visible = false;
            dataGridView2.Columns["ItemID"].Visible = false;
            dataGridView2.Columns["Name"].Visible = false;
            dataGridView2.Columns["PriceIncludedNon"].Visible = false;

            dataGridView2.Columns["UnitID"].Visible = false;
            dataGridView2.Columns["VatTax"].Visible = false;
            dataGridView2.Columns["Price"].Visible = false;
            dataGridView2.Columns["ValueAfter"].Visible = false;
            dataGridView2.Columns["ValueBefore"].Visible = false;

            dataGridView2.Columns["InstallationPrice"].Visible = false;
            dataGridView2.Columns["OrderItemsID"].Visible = false;
            dataGridView2.Columns["ManagementID"].Visible = false;
            dataGridView2.Columns["QntyManagement"].Visible = false;
            dataGridView2.Columns["OrdMngItemID"].Visible = false;

            groupBox1.Text = "بنود الامر رقم " + " " + txtOrderNo.Text + "بتاريخ " + dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + "والتي تم توزيعها على الادارات المختلفه";
            //Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }
        private void FindManagementsItemsOrder_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "Management_ID", "Name", "Parent_ID", "");
            }
            Vint_OrderID = int.Parse(txtOrderId.Text);
            this.dtb_OrderItemsTableAdapter.FillOrderItemsByOrderId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text));
            //long Vlng_OrderId = long.Parse(txtOrderId.Text);
            simpleButton4.Enabled = false;
            simpleButton2.Enabled = false;
            //*****************
            FillDatagridview2Orderid(Vint_OrderID);
            //********************
        }

        private decimal DtotalOfQntyOrderItem(int? Vint_itemOrderId, int? Vint_OrderID)
        {
            decimal query = 0;
            //***********اجمالى الكمية المنصرفه للادارات من هذا البند لهذا الامر
            var totalOfQntyOrderItem = FsDb.Tbl_OrderItems.FirstOrDefault(t => t.ID == Vint_itemOrderId && t.OrderID == Vint_OrderID);

            if (totalOfQntyOrderItem != null)
            {
                query = totalOfQntyOrderItem.Quantity;
            }
            return query;
            //*****************************
        }
        private decimal DtotalOfQntyOrderMngItem(int? Vint_itemOrderId, int? Vint_OrderID)
        {
            decimal query = 0;
            //***********اجمالى الكمية المنصرفه للادارات من هذا البند لهذا الامر
            var totalOfQntyOrderItem = FsDb.Tbl_OrderManagementItems.Where(x => x.OrderItemsID == Vint_itemOrderId).Select(x => x.Quantity).Sum();

            if (totalOfQntyOrderItem != null)
            {
                query = totalOfQntyOrderItem.Value;
            }
            return query;
            //*****************************
        }
        private decimal DtotalOfQntyOrderMngNotItem(long? Vlong_OrderManagementitemID, int? Vint_OrderID, int? Vint_ItemID)
        {
            decimal query = 0;
            //***********اجمالى الكمية المنصرفه للادارات من هذا البند لهذا الامر من دون البند المختار 

            var totalOfQntyOrderItem = FsDb.Tbl_OrderManagementItems.Where(x => x.ID != Vlong_OrderManagementitemID && x.OrderId == Vint_OrderID && x.ItemID == Vint_ItemID).Select(x => x.Quantity).Sum();

            if (totalOfQntyOrderItem != null)
            {
                query = totalOfQntyOrderItem.Value;
            }
            return query;
            //*****************************
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Vint_IdManagement = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            txtManagementId.Text = Vint_IdManagement.ToString();
            Vstr_NameManagement = treeView1.SelectedNode.Text;
            txtOrderManagement.Text = Vstr_NameManagement;
            if (txtManagementId.Text != "")
            {
                groupBox1.Text = "بنود الامر رقم " + " " + txtOrderNo.Text + "بتاريخ " + dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + "والمخصص منها لــ" + " " + Vstr_NameManagement;
            }
            else
            {
                groupBox1.Text = "بنود الامر رقم " + " " + txtOrderNo.Text + "بتاريخ " + dateTimePicker1.Value.ToString() + " " + "والتي تم توزيعها على الادارات المختلفه";
            }
            Vint_OrderID = int.Parse(txtOrderId.Text);

            //this.dtb_OrderItemsTableAdapter.FillByOrderIdManagementId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text), Vint_IdManagement);
            //*****************
            FillDatagridview2OrderMangement(Vint_OrderID, Vint_IdManagement);
            //********************
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {

                Vint_IdManagement = 0;

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string searchText = this.Nametxt.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                txtsearchitem.Focus();
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
                    Vstr_NameManagement = treeView1.SelectedNode.Text;
                    txtOrderManagement.Text = "بنود" + " " + Vstr_NameManagement;
                    txtManagementId.Text = treeView1.SelectedNode.Tag.ToString();
                    this.treeView1.Select();

                }
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtsearchitem.Focus();
            }
        }

        private void txtsearchitem_TextChanged(object sender, EventArgs e)
        {
            this.dtb_OrderItemsTableAdapter.FillByFullNameItem(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text), txtsearchitem.Text);
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtItemID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Vint_ItemID = int.Parse(txtItemID.Text);
            Vint_itemOrderId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtItemOrderId.Text = Vint_itemOrderId.ToString();
            txtsearchitemManagement.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Vstr_UniteName = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            //*****************************
            Vint_OrderID = int.Parse(txtOrderId.Text);
            if (txtManagementId.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار الاداره ");
            }
            else
            {
                Vint_IdManagement = int.Parse(txtManagementId.Text);

                FillDatagridview2OrderManagementItem(Vint_OrderID, Vint_IdManagement, Vint_itemOrderId);

                //***********اجمالى الكمية المنصرفه للادارات من هذا البند لهذا الامر
                decimal totalOfQntyOrderItem = DtotalOfQntyOrderItem(Vint_itemOrderId, Vint_OrderID);
                decimal totalOfQntyOrderMngItem = DtotalOfQntyOrderMngItem(Vint_itemOrderId, Vint_OrderID);

                if (txtquantity.Text == "")

                {
                    txtquantity.Text = "0";
                }

                //***************************** مقارنة كمية الصنف بالامر مع الكميه التي تم توزيعها من الصنف على الادارات 
                if (totalOfQntyOrderItem == totalOfQntyOrderMngItem)
                {
                    MessageBox.Show($"هذا البند {txtsearchitemManagement.Text}  تم توزيع الكميه الخاصه به {totalOfQntyOrderItem} {" "} {Vstr_UniteName} بالأمر بالكامل ");
                    FillDatagridview2Orderiditem(Vint_OrderID, Vint_ItemID);
                    txtsearchitemManagement.Text = "";
                    txtquantity.Text = "";

                }
                else if (totalOfQntyOrderItem != totalOfQntyOrderMngItem)
                {

                    txtquantity.Text = (totalOfQntyOrderItem - totalOfQntyOrderMngItem).ToString();
                    txtquantity.Select();
                    this.ActiveControl = txtquantity;
                    txtquantity.Focus();

                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            Vint_itemOrderId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtItemOrderId.Text = Vint_itemOrderId.ToString();
            txtsearchitemManagement.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtItemID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Vint_ItemID = int.Parse(txtItemID.Text);
            //*****************************
            Vint_OrderID = int.Parse(txtOrderId.Text);
            if (txtManagementId.Text == "")
            {
                MessageBox.Show("من فضلك قم بإختيار الاداره ");
            }
            else
            {
                Vint_IdManagement = int.Parse(txtManagementId.Text);

                FillDatagridview2OrderManagementItem(Vint_OrderID, Vint_IdManagement, Vint_itemOrderId);

                //***********اجمالى الكمية المنصرفه للادارات من هذا البند لهذا الامر
                decimal totalOfQntyOrderItem = DtotalOfQntyOrderItem(Vint_itemOrderId, Vint_OrderID);
                decimal totalOfQntyOrderMngItem = DtotalOfQntyOrderMngItem(Vint_itemOrderId, Vint_OrderID);

                if (txtquantity.Text == "")

                {
                    txtquantity.Text = "0";
                }

                //***************************** مقارنة كمية الصنف بالامر مع الكميه التي تم توزيعها من الصنف على الادارات 
                if (totalOfQntyOrderItem == totalOfQntyOrderMngItem)
                {
                    MessageBox.Show($"هذا البند {txtsearchitemManagement.Text}   تم توزيع الكميه الخاصه به بالأمر بالكامل وهي  {totalOfQntyOrderItem} {" "} {Vstr_UniteName}  ");
                    FillDatagridview2Orderiditem(Vint_OrderID, Vint_ItemID);
                    txtsearchitemManagement.Text = "";
                    txtquantity.Text = "";

                }
                else if (totalOfQntyOrderItem != totalOfQntyOrderMngItem)
                {

                    txtquantity.Text = (totalOfQntyOrderItem - totalOfQntyOrderMngItem).ToString();
                    txtquantity.Select();
                    this.ActiveControl = txtquantity;
                    txtquantity.Focus();

                }
            }
        }

        private void txtsearchitem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void txtquantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtManagementId.Text != "" && txtItemOrderId.Text != "")
                {

                    Vint_IdManagement = int.Parse(txtManagementId.Text);
                    Vint_itemOrderId = int.Parse(txtItemOrderId.Text);
                    Vint_OrderID = int.Parse(txtOrderId.Text);
                    var ListqntitemmangOrder = FsDb.Tbl_OrderManagementItems.FirstOrDefault(x => x.OrderId == Vint_OrderID && x.OrderItemsID == Vint_itemOrderId && x.ManagementID == Vint_IdManagement);
                    if (ListqntitemmangOrder == null)
                    {
                        ////// التحقق من الكمية المراد اضافتها 
                        //***********اجمالى الكمية المنصرفه للادارات من هذا البند لهذا الامر
                        decimal totalOfQntyOrderItem = DtotalOfQntyOrderItem(Vint_itemOrderId, Vint_OrderID);
                        decimal totalOfQntyOrderMngItem = DtotalOfQntyOrderMngItem(Vint_itemOrderId, Vint_OrderID);
                        decimal QntyAddUpdate = Convert.ToDecimal(txtquantity.Text);
                        //***************************** مقارنة كمية الصنف بالامر مع الكميه التي تم توزيعها من الصنف على الادارات 
                        if (totalOfQntyOrderItem == (totalOfQntyOrderMngItem))
                        {
                            MessageBox.Show($"هذا البند {txtsearchitemManagement.Text}   تم توزيع الكميه الخاصه به بالأمر بالكامل وهي  {totalOfQntyOrderItem} {" "} {Vstr_UniteName}  ");
                            FillDatagridview2Orderiditem(Vint_OrderID, Vint_ItemID);
                            txtsearchitemManagement.Text = "";
                            txtquantity.Text = "";
                        }
                        else if (totalOfQntyOrderItem >= (totalOfQntyOrderMngItem + QntyAddUpdate))
                        {

                            txtquantity.Text = QntyAddUpdate.ToString();

                            //**************************** insert
                            Tbl_OrderManagementItems OrdMng = new Tbl_OrderManagementItems
                            {
                                OrderItemsID = Vint_itemOrderId,
                                ManagementID = Vint_IdManagement,
                                Quantity = QntyAddUpdate,
                                OrderId = Vint_OrderID,
                                ItemID = Vint_ItemID
                            };
                            FsDb.Tbl_OrderManagementItems.Add(OrdMng);
                            FsDb.SaveChanges();
                            MessageBox.Show("تم الحفظ");
                            Vint_IdManagement = int.Parse(txtManagementId.Text);

                            FillDatagridview2OrderMangement(Vint_OrderID, Vint_IdManagement);
                            //******************
                            txtsearchitemManagement.Text = "";
                            txtquantity.Text = "";
                            txtItemOrderId.Text = "";
                            txtsearchitemManagement.Text = "";
                            txtItemID.Text = "";
                            Nametxt.Focus();
                        }
                        else
                        {
                            MessageBox.Show($"الكميه المراد اضافتها تتعدى الكميه الخاصه بالبند بالأمر وهي {totalOfQntyOrderItem} {" "} {Vstr_UniteName}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"هذا البند  {txtsearchitemManagement.Text} تم اضافته لهذه الاداره {Vstr_NameManagement} من قبل ");

                    }
                }

            }

        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 62 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                Vlong_OrderManagementitemID = int.Parse(dataGridView2.CurrentRow.Cells["OrdMngItemID"].Value.ToString());
                Vint_ItemID = int.Parse(dataGridView2.CurrentRow.Cells["ItemID"].Value.ToString());
                Vint_itemOrderId = int.Parse(dataGridView2.CurrentRow.Cells["ID"].Value.ToString());
                Vstr_UniteName = dataGridView2.CurrentRow.Cells["uniteName"].Value.ToString();
                Vint_IdManagement = int.Parse(dataGridView2.CurrentRow.Cells["ManagementID"].Value.ToString());
                var ListOrderManagementItem = FsDb.Tbl_OrderManagementItems.FirstOrDefault(x => x.ID == Vlong_OrderManagementitemID);
                if (ListOrderManagementItem != null)
                {
                    txtOrderManagementID.Text = ListOrderManagementItem.ManagementID.ToString();
                    ////// التحقق من الكمية المراد اضافتها 
                    //***********اجمالى الكمية المنصرفه للادارات من هذا البند لهذا الامر
                    decimal totalOfQntyOrderItem = DtotalOfQntyOrderItem(Vint_itemOrderId, Vint_OrderID);
                    decimal totalOfQntyOrderMngItem = DtotalOfQntyOrderMngItem(Vint_itemOrderId, Vint_OrderID);
                    decimal totalOfQntyOrderMngNotItem = DtotalOfQntyOrderMngNotItem(Vlong_OrderManagementitemID, Vint_OrderID, Vint_ItemID);
                    decimal QntyAddUpdate = Convert.ToDecimal(txtquantity.Text);

                    //***************************** مقارنة كمية الصنف بالامر مع الكميه التي تم توزيعها من الصنف على الادارات 
                    if (totalOfQntyOrderItem < (totalOfQntyOrderMngNotItem + QntyAddUpdate))
                    {
                        MessageBox.Show($"هذا البند {txtsearchitemManagement.Text}   تم توزيع الكميه الخاصه به بالأمر بالكامل وهي  {totalOfQntyOrderItem} {" "} {Vstr_UniteName}  ");
                        txtsearchitemManagement.Text = "";
                        txtquantity.Text = "";
                    }
                    else if (totalOfQntyOrderItem >= (totalOfQntyOrderMngNotItem + QntyAddUpdate))
                    {
                        ListOrderManagementItem.Quantity = decimal.Parse(txtquantity.Text);
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //******************
                        FillDatagridview2OrderMangement(Vint_OrderID, Vint_IdManagement);
                        //****************
                        txtManagementId.Text = "";
                        txtquantity.Text = "";
                        txtsearchitemManagement.Text = "";
                        txtquantity.Select();
                        this.ActiveControl = txtquantity;
                        txtquantity.Focus();

                    }
                    else
                    {
                        MessageBox.Show($"الكمية المطلوب تعديلها {QntyAddUpdate} {" "} {Vstr_UniteName}  بالاضافه للكميات التي تم توزيعها تتجاوز الكميه الخاصه بالامر {totalOfQntyOrderItem} {" "} {Vstr_UniteName} ");
                        txtquantity.Select();
                        this.ActiveControl = txtquantity;
                        txtquantity.Focus();
                    }
                    //*****************



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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 43 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {

                var resultMessageYesNo = MessageBox.Show($"هل تريد حدف هدا البند  {txtsearchitemManagement.Text}؟", "حدف  بند ", MessageBoxButtons.YesNo);

                if (resultMessageYesNo == DialogResult.Yes)
                {
                    Vlong_OrderManagementitemID = int.Parse(dataGridView2.CurrentRow.Cells["OrdMngItemID"].Value.ToString());
                    Vint_IdManagement = int.Parse(dataGridView2.CurrentRow.Cells["ManagementID"].Value.ToString());

                    var ListOrderManagementItem = FsDb.Tbl_OrderManagementItems.FirstOrDefault(x => x.ID == Vlong_OrderManagementitemID);
                    FsDb.Tbl_OrderManagementItems.Remove(ListOrderManagementItem);
                    FsDb.SaveChanges();
                    MessageBox.Show("تم الحذف");
                    //******************
                    FillDatagridview2OrderMangement(Vint_OrderID, Vint_IdManagement);
                    //****************
                    txtManagementId.Text = "";
                    txtquantity.Text = "";
                    txtsearchitemManagement.Text = "";
                    txtquantity.Select();
                    this.ActiveControl = txtquantity;
                    txtquantity.Focus();
                }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            Vlong_OrderManagementitemID = long.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            txtOrderManagementID.Text = Vlong_OrderManagementitemID.ToString();
            txtsearchitemManagement.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            txtquantity.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            simpleButton2.Enabled = true;
            simpleButton4.Enabled = true;

            txtquantity.Select();
            this.ActiveControl = txtquantity;
            txtquantity.Focus();
        }

        private void CheckAddAllItems_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckAddAllItems.Checked == true)
            {
                if (txtManagementId.Text == "")
                {
                    MessageBox.Show("من فضلك قم بإختيار الاداره ");
                    CheckAddAllItems.Checked = false;
                }
                else
                {
                    Vint_IdManagement = int.Parse(txtManagementId.Text);
                    //if (DtotalOfQntyOrderMngItem(Vint_itemOrderId, Vint_OrderID) != DtotalOfQntyOrderItem(Vint_itemOrderId, Vint_OrderID))
                    //{
                        int WCount = int.Parse(dataGridView1.RowCount.ToString());
                        for (int i = 0; i <= WCount - 1; i++)
                        {
                            Vint_itemOrderId = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            Vint_OrderID = int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                            Vdec_qntyOrderItem = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value.ToString());
                            Vint_ItemID = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());

                            var listCheckInsert = FsDb.Tbl_OrderManagementItems.Where(x => x.OrderId == Vint_OrderID && x.ItemID == Vint_ItemID && x.OrderItemsID == Vint_itemOrderId).ToList();
                            if (listCheckInsert.Count == 0)
                            {
                                //**************************** insert
                                Tbl_OrderManagementItems OrdMng = new Tbl_OrderManagementItems
                                {
                                    OrderItemsID = Vint_itemOrderId,
                                    ManagementID = Vint_IdManagement,
                                    Quantity = Vdec_qntyOrderItem,
                                    OrderId = Vint_OrderID,
                                    ItemID = Vint_ItemID
                                };
                                FsDb.Tbl_OrderManagementItems.Add(OrdMng);
                                FsDb.SaveChanges();
                            }
                        }
                        MessageBox.Show("تم الحفظ");
                        Vint_IdManagement = int.Parse(txtManagementId.Text);

                        FillDatagridview2OrderMangement(Vint_OrderID, Vint_IdManagement);
                        //******************
                        txtsearchitemManagement.Text = "";
                        txtquantity.Text = "";
                        txtItemOrderId.Text = "";
                        txtsearchitemManagement.Text = "";
                        txtItemID.Text = "";
                        Nametxt.Focus();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("الكميات الخاصه بالأمر تم توزيعها بالكامل");
                    //}
                }
            }
        }

        private void FindManagementsItemsOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            

           
            var ListOrderManagement = (from ordMng in FsDb.Tbl_OrderManagementItems
                                       join mng in FsDb.Tbl_Management on ordMng.ManagementID equals mng.Management_ID
                                       where (ordMng.OrderId == Vint_OrderID)
                                       select new
                                       {

                                           mng.Name
                                       }
                                       ).Distinct().ToList();
            if (ListOrderManagement != null)
            {
                string Vstr_ManagementsOrder = "";
                int WCount = int.Parse(ListOrderManagement.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {

                    Vstr_ManagementsOrder = ListOrderManagement[i].Name + " / " + Vstr_ManagementsOrder;


                }
                txtManagementOrder.Text = "";
                txtManagementOrder.Text = Vstr_ManagementsOrder;
            }
        }

        private void FindManagementsItemsOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}