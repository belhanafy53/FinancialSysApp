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
    public partial class FindProject : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_IdManagement = 0;
        int? Vint_itemOrderId = 0;
        int? Vint_Parent_ID = 0;
        //int? Vint_ItemID = 0;
        int? Vint_OrderID = 0;
        decimal Vdec_qntyManagement = 0;
        decimal Vdec_qntyOrderItem = 0;
        decimal Vdec_qnty = 0;
        //long Vlong_OrderManagementitemID = 0;
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
            string Sql = "Select * From Tbl_Projects";
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }
        public FindProject()
        {
            InitializeComponent();
        }

        private void FindProject_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID","");
            }
            treeView1.ExpandAll();
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
            try
            {
                this.projectStorsTableAdapter.FillByOrder(this.dataSet1.ProjectStors, int.Parse(txtOrderId.Text));
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
                    txtOrderManagement.Text = "المشروع" + " " + Vstr_NameManagement;
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
            com.CommandText = "Insert Into Tbl_OrderProjects (OrderID,ProjectID)Values(@OrderID,@ProjectID)";
            
            com.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(txtOrderId.Text);
            com.Parameters.Add("@ProjectID", SqlDbType.Int).Value = Convert.ToInt32(txtManagementId.Text);

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
                this.projectStorsTableAdapter.FillByOrder(this.dataSet1.ProjectStors, int.Parse(txtOrderId.Text));
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtOrderManagement_TextChanged(object sender, EventArgs e)
        {

        }
    }
}