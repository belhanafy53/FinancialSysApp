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

namespace FinancialSysApp.Forms
{
    public partial class FindStores : DevExpress.XtraEditors.XtraForm
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
        decimal Vdec_qnty = 0;
        long Vlong_OrderManagementitemID = 0;
        string Vstr_NameManagement = "";
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
            string Sql = "Select * From Tbl_Stores";
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }
        public FindStores()
        {
            InitializeComponent();
        }

        private void FindStores_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "StoreCode");
            }
            treeView1.ExpandAll();
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
            try
            {
                this.orderStoresTableAdapter.FillByOrder(this.dataSet1.OrderStores, int.Parse(txtOrderId.Text));
            }
            catch { }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string searchText = this.Nametxt.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                //txtsearchitem.Focus();
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
                    txtOrderManagement.Text = "مخزن" + " " + Vstr_NameManagement;
                    txtManagementId.Text = treeView1.SelectedNode.Tag.ToString();
                    this.treeView1.Select();

                }
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {

                Vint_IdManagement = 0;

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
          int  Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsDb.Tbl_Stores.FirstOrDefault(x => x.ID == Vint_IdItem);

           string  Vstr_Name = listItem.Name;
            txtOrderManagement.Text = Vstr_Name;
            //this.dtb_OrderItemsTableAdapter.FillByOrderIdManagementId(this.financialSysDataSet.Dtb_OrderItems, long.Parse(txtOrderId.Text), Vint_IdManagement);
            //*****************
            //FillDatagridview2OrderMangement(Vint_OrderID, Vint_IdManagement);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void SaveOrderStores()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;


            com.Parameters.Clear();
            //row.Cells[5].Value = MAXID.Text;
            com.CommandText = "Insert Into Tbl_OrderStores (StoreID,OrderID)Values(@StoreID,@OrderID)";
            com.Parameters.Add("@StoreID", SqlDbType.Int).Value = Convert.ToInt32(txtManagementId.Text);
            com.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(txtOrderId.Text);
           
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            try
            {
                Vint_IdManagement = int.Parse(treeView1.SelectedNode.Tag.ToString());
                if (treeView1.SelectedNode.Name != "")
                {
                    Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
                }
                txtManagementId.Text = Vint_IdManagement.ToString();
                Vstr_NameManagement = treeView1.SelectedNode.Text;
                txtOrderManagement.Text = Vstr_NameManagement;
                Vint_OrderID = int.Parse(txtOrderId.Text);
                Vint_IdManagement = int.Parse(txtManagementId.Text);
                SaveOrderStores();
                this.orderStoresTableAdapter.FillByOrder(this.dataSet1.OrderStores, int.Parse(txtOrderId.Text));
            }
            catch { }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }
    }
}