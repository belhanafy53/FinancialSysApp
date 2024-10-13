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
    public partial class FindAssays : DevExpress.XtraEditors.XtraForm
    {
        public FindAssays()
        {
            InitializeComponent();
        }

        private void FindAssays_Load(object sender, EventArgs e)
        {
            try
            {
                this.orderAssaysTableAdapter.Fill(this.dataSet1.OrderAssays, int.Parse(txtOrderId.Text));
            }
            catch { }
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
            com.CommandText = "Insert Into Tbl_OrderAssays (OrderID,AssaysID)Values(@OrderID,@AssaysID)";

            com.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(txtOrderId.Text);
            com.Parameters.Add("@AssaysID", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحفظ بنجاح");
        }
        private void txtOrderManagement_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.assaysSearchTableAdapter.Fill(this.dataSet1.AssaysSearch, txtOrderManagement.Text);
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch { }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SaveOrderStores();
            this.orderAssaysTableAdapter.Fill(this.dataSet1.OrderAssays, int.Parse(txtOrderId.Text));

        }
    }
}
