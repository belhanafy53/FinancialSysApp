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
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindEXC : DevExpress.XtraEditors.XtraForm
    {
        public FindEXC()
        {
            InitializeComponent();
        }

        private void FindEXC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ExchangeCenter' table. You can move, or remove it, as needed.
            //this.tbl_ExchangeCenterTableAdapter.Fill(this.financialSysDataSet.Tbl_ExchangeCenter);
            dataGridView1.DataSource = ExCenter();
            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ExCenterWithName();
            }
            catch { dataGridView1.DataSource = ExCenter(); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }
        public DataTable ExCenter()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select  ID ,Name as [مركز الصرف ] from Tbl_ExchangeCenter ");
            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable ExCenterWithName()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select  ID ,Name as [مركز الصرف ] from Tbl_ExchangeCenter where Name Like @p");
            com.Parameters.Add("@p", SqlDbType.NVarChar).Value ="%" + textBox1.Text + "%";
            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //    textEdit1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //}
            //catch { }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== 13)
            {
                //dataGridView1.DataSource = ExCenterWithName();
                textEdit1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                this.Close();
            }
        }
    }
}