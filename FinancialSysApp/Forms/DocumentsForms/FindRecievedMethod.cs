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
    public partial class FindRecievedMethod : DevExpress.XtraEditors.XtraForm
    {
        public FindRecievedMethod()
        {
            InitializeComponent();
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
            com.CommandText = "Insert Into Tbl_orderReceivedMethod (RecievedMethodID,OrderID,ReceivedDate,ReceivedActual_Date)Values(@RecievedMethodID,@OrderID,@ReceivedDate,@ReceivedActual_Date)";

            com.Parameters.Add("@RecievedMethodID", SqlDbType.Int).Value = Convert.ToInt32(txtOrderId.Text);
            com.Parameters.Add("@OrderID", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            com.Parameters.Add("@ReceivedDate", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            com.Parameters.Add("@ReceivedActual_Date", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحفظ بنجاح");
        }
        private void FindRecievedMethod_Load(object sender, EventArgs e)
        {
            this.tbl_RecievedMethodTableAdapter.Fill(this.dataSet1.Tbl_RecievedMethod);

        }

        private void txtsearchitem_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
                //this.tbl_RecievedMethodTableAdapter.FillByName(this.dataSet1.Tbl_RecievedMethod,txtsearchitem.Text);
            ////    if(textBox3.Text == string.Empty )
            ////{
            ////    txtOrderSupName.Text = "";
            ////    textBox3.Text = "";
            ////}
            //}
            //catch { }
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit5.Checked==true )
            {
                checkEdit3.Checked = false;
                dateTimePicker2.Enabled = true;
            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit3.Checked == true)
            {
                checkEdit5.Checked = false ;
                dateTimePicker2.Enabled = false ;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtsearchitem.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if(txtsearchitem.Text.Contains("أمر") || txtsearchitem.Text.Contains("امر"))
            {
                txtOrderSupName.Enabled = false;
                txtOrderSupName.Text = dateTimePicker1.Value.ToShortDateString();
                textBox3.Text = dateTimePicker1.Value.ToShortDateString();
                textBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show("أدخل تاريخ التسليم");
                txtOrderSupName.Enabled = true ;
                textBox3.Enabled = false;
                txtOrderSupName.Text = "";
                textBox3.Text = "";
                txtOrderSupName.Focus();
                txtOrderSupName.BackColor = Color.Red;
            }

        }

        private void txtOrderSupName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                txtOrderSupName.BackColor = Color.White ;
                if (checkEdit1.Checked == true)
                {
                    textBox3.Text =Convert.ToDateTime(txtOrderSupName.Text).AddDays(Convert.ToDouble(textBox8.Text)).ToShortDateString();
                }
                if (checkEdit2.Checked == true)
                {
                    textBox3.Text = Convert.ToDateTime(txtOrderSupName.Text).AddMonths(Convert.ToInt32(textBox8.Text)).ToShortDateString();
                }
               

               
            }
        }

        private void txtsearchitem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                dataGridView1.Focus();
            }
        }
    }
}