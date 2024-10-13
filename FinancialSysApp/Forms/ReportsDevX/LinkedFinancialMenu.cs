using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System.Data.SqlClient;
using System.Configuration;


namespace FinancialSysApp.Forms.ReportsDevX
{
    public partial class LinkedFinancialMenu : DevExpress.XtraEditors.XtraForm
    {
        public int     SelectMenue_ID { get; set; }
        public int   SelectParent_ID { get; set; }
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_ItemId;
        int Vint_ItemChildId;

        public LinkedFinancialMenu()
        {
            InitializeComponent();
        }

        private void LinkedFinancialMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Tbl_FinancialMenuName' table. You can move, or remove it, as needed
            // 
            this.configureLinkeMenuTableAdapter.Fill(this.dataSet1.ConfigureLinkeMenu);

            this.tbl_FinancialMenuNameTableAdapter1.Fill(this.dataSet1.Tbl_FinancialMenuName);
            this.tbl_FinancialMenuNameTableAdapter.Fill(this.financialSysDataSet.Tbl_FinancialMenuName);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_FinancialMenuSetting' table. You can move, or remove it, as needed.
            //this.tbl_FinancialMenuSettingTableAdapter.Fill(this.financialSysDataSet.Tbl_FinancialMenuSetting);
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedText = "اختر القائمة";
            comboBox11.SelectedIndex = -1;
            comboBox11.SelectedText = "اختر القائمة";
            //************************
            tBLRESULTBindingSource.DataSource = FsDb.TBL_RESULT.ToList();
            AutoCompleteStringCollection Doct = new AutoCompleteStringCollection();
            foreach (TBL_RESULT d in tBLRESULTBindingSource.DataSource as List<TBL_RESULT>)
                Doct.Add(d.ACC_NM_Ar);
            AuditBalancetxtBox.AutoCompleteCustomSource = Doct;
           
            //*******************

            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int? Vint_FinMenuID = int.Parse(comboBox1.SelectedValue.ToString());
            var list = FsDb.Tbl_FinancialMenuSetting.Where(x => x.FinancialMenuNameID == Vint_FinMenuID).ToList();
            radTreeView1.DataSource = list;
           
        }

        private void radTreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radTreeView1.SelectedNodes.Count() > 0)
            {
                Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                var list = FsDb.Tbl_FinancialMenuSetting.FirstOrDefault(x => x.ID == Vint_ItemId);

                ParentIDtxt.Text = list.Parent_ID.ToString();
                if (IDParenttxtBox.Text == "" && list.Parent_ID == null)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = radTreeView1.SelectedNode.Text.ToString();
                    //Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    IDParenttxtBox.Text = Vint_ItemId.ToString();

                }
                else if (IDParenttxtBox.Text != "" && list.Parent_ID != null)
                {
                    textBox2.Text = "";
                    Vint_ItemChildId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    IDChildtxtBox.Text = Vint_ItemChildId.ToString();
                    textBox2.Text = radTreeView1.SelectedNode.Text.ToString();
                }
                else if (IDParenttxtBox.Text != "" && list.Parent_ID == null)
                {
                    textBox2.Text = "";
                    Vint_ItemChildId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    IDChildtxtBox.Text = Vint_ItemChildId.ToString();
                    textBox2.Text = radTreeView1.SelectedNode.Text.ToString();
                }
                else if (IDParenttxtBox.Text == "" && list.Parent_ID != null)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = radTreeView1.SelectedNode.Text.ToString();

                    IDParenttxtBox.Text = Vint_ItemId.ToString();
                }





                textBox2.Select();
                this.ActiveControl = textBox2;
                textBox2.Focus();
            }
            else
            {
                //textBox1.Text = Nametxt.Text;
                radTreeView1.Select();
                this.ActiveControl = radTreeView1;
                radTreeView1.Focus();
            }
            SelectParent_ID = Convert.ToInt32(IDParenttxtBox.Text);
            SelectMenue_ID = Convert.ToInt32(comboBox1.SelectedValue);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                IDParenttxtBox.Text = "";
                IDParenttxtBox.Text = "";
                int? Vint_FinMenuID = int.Parse(comboBox1.SelectedValue.ToString());
                var list1 = FsDb.Tbl_FinancialMenuSetting.Where(x => x.FinancialMenuNameID == Vint_FinMenuID).ToList();
                radTreeView1.DataSource = list1;

            }
            if (textBox1.Text != "")
            {
                var list = FsDb.Tbl_FinancialMenuSetting.Where(x => x.Name.Contains(textBox1.Text)).ToList();
                radTreeView1.DataSource = list;
            }
        }
        private void insertIFMenuSettingISNULL()
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
            com.CommandText = "Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus (RestrictionKind_ID,Account_Guid_ID,FinancialMenuSetting_ID,DuePaymentDebitValue,FinancialMenuNameID)Values(@RestrictionKind_ID,@Account_Guid_ID,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@FinancialMenuNameID)";
            com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value =1;
            com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = 1;
            com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(IDParenttxtBox.Text);
            com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value =1;
            com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedValue );
           // com.Parameters.Add("@SortingItems", SqlDbType.Int).Value = 1;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            insertIFMenuSettingISNULL();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;

            int? Vint_FinMenuID = int.Parse(comboBox11.SelectedValue.ToString());
            int? Vint_FinMenuID1 = int.Parse(comboBox1.SelectedValue.ToString());
            com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = "Insert Into Tbl_FinanctialMenueLinkedFunction (Transfare_FinancialMenuNameID,Transfare_FinancialMenuSetting_ID,To_FinancialMenuSetting_ID,To_FinancialMenuNameID)Values(@Transfare_FinancialMenuNameID,@Transfare_FinancialMenuSetting_ID,@To_FinancialMenuSetting_ID,@To_FinancialMenuNameID)";
            com.Parameters.Add("@Transfare_FinancialMenuNameID", SqlDbType.Int).Value = Vint_FinMenuID;
            com.Parameters.Add("@Transfare_FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(IDParenttxtBox1.Text);
            com.Parameters.Add("@To_FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(IDParenttxtBox.Text);
            com.Parameters.Add("@To_FinancialMenuNameID", SqlDbType.Int).Value = Vint_FinMenuID1;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الربط بنجاح");
           
            this.configureLinkeMenuTableAdapter.Fill(this.dataSet1.ConfigureLinkeMenu);

        }

        private void comboBox11_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int? Vint_FinMenuID = int.Parse(comboBox11.SelectedValue.ToString());
            var list = FsDb.Tbl_FinancialMenuSetting.Where(x => x.FinancialMenuNameID == Vint_FinMenuID).ToList();
            radTreeView2.DataSource = list;

        }

        private void radTreeView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radTreeView2.SelectedNodes.Count() > 0)
            {
                Vint_ItemId = int.Parse(radTreeView2.SelectedNode.Value.ToString());
                var list = FsDb.Tbl_FinancialMenuSetting.FirstOrDefault(x => x.ID == Vint_ItemId);

                ParentIDtxt1.Text = list.Parent_ID.ToString();
                if (IDParenttxtBox1.Text == "" && list.Parent_ID == null)
                {
                    textBox11.Text = "";
                    textBox21.Text = "";
                    textBox11.Text = radTreeView2.SelectedNode.Text.ToString();
                    //Vint_ItemId = int.Parse(radTreeView2.SelectedNode.Value.ToString());
                    IDParenttxtBox1.Text = Vint_ItemId.ToString();

                }
                else if (IDParenttxtBox1.Text != "" && list.Parent_ID != null)
                {
                    textBox21.Text = "";
                    Vint_ItemChildId = int.Parse(radTreeView2.SelectedNode.Value.ToString());
                    IDChildtxtBox1.Text = Vint_ItemChildId.ToString();
                    textBox21.Text = radTreeView2.SelectedNode.Text.ToString();
                }
                else if (IDParenttxtBox1.Text != "" && list.Parent_ID == null)
                {
                    textBox21.Text = "";
                    Vint_ItemChildId = int.Parse(radTreeView2.SelectedNode.Value.ToString());
                    IDChildtxtBox1.Text = Vint_ItemChildId.ToString();
                    textBox21.Text = radTreeView2.SelectedNode.Text.ToString();
                }
                else if (IDParenttxtBox1.Text == "" && list.Parent_ID != null)
                {
                    textBox11.Text = "";
                    textBox21.Text = "";
                    textBox11.Text = radTreeView2.SelectedNode.Text.ToString();

                    IDParenttxtBox1.Text = Vint_ItemId.ToString();
                }





                textBox21.Select();
                this.ActiveControl = textBox21;
                textBox21.Focus();
            }
            else
            {
                //textBox1.Text = Nametxt.Text;
                radTreeView2.Select();
                this.ActiveControl = radTreeView2;
                radTreeView2.Focus();
            }
            SelectParent_ID = Convert.ToInt32(IDParenttxtBox1.Text);

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                IDParenttxtBox1.Text = "";
                IDParenttxtBox1.Text = "";
                int? Vint_FinMenuID = int.Parse(comboBox11.SelectedValue.ToString());
                var list1 = FsDb.Tbl_FinancialMenuSetting.Where(x => x.FinancialMenuNameID == Vint_FinMenuID).ToList();
                radTreeView2.DataSource = list1;

            }
            if (textBox11.Text != "")
            {
                var list = FsDb.Tbl_FinancialMenuSetting.Where(x => x.Name.Contains(textBox11.Text)).ToList();
                radTreeView2.DataSource = list;

            }
            //if (list.Count() == 0)
            //{
            //    textBox1.Text = textBox1.Text;
            //}
            //if (Nametxt.Text == "")
            //{
            //    textBox1.Text = "";
            //}
            //radTreeView2.ExpandAll();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
