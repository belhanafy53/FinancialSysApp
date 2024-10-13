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

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class FindOrderPurposeFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_Parent_ID = 0;
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        //string vstr_orderNo = "";
        int Vint_orderKind = 0;
        long? Vint_orderID = 0;
        //long? Vlong_orderEsdarAdd = 0;
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
        string SelectTreeTable(int OKID)
        {

            int OrderKindID = OKID;

            //string Sql = "Select * From  Tbl_OrderPurpose Where Name = @tt";
            string Sql = "select * from Tbl_OrderPurpose where Tbl_OrderPurpose.OrderKindID = " + @OrderKindID;
            return Sql;
        }
        
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }
        public FindOrderPurposeFrm()
        {
            InitializeComponent();
        }

        private void FindOrderPurposeFrm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            {
                Vint_orderKind = int.Parse(txtOrderKindId.Text);
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(Vint_orderKind), "ID", "Name", "Parent_ID", "Name");
            }
            //treeView1.ExpandAll();
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
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

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {

                txtSelected.Text = "";
                Vint_IdItem = 0;

            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton5.Focus();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            txtOrderPuprposeId.Text = Vint_IdItem.ToString();
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsDb.Tbl_OrderPurpose.FirstOrDefault(x => x.ID == Vint_IdItem);

            Vstr_Name = treeView1.SelectedNode.Text;
            //txtSelected.Text = Vstr_Name;

            txtSelected.Text = ViewTree.SelectFullHirachyOrderPurpose(treeView1, Vint_IdItem, Vint_Parent_ID);
            LblSelected.Text = ViewTree.SelectFullHirachyOrderPurpose(treeView1, Vint_IdItem, Vint_Parent_ID);


        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
