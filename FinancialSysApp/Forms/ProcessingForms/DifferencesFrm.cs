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
    public partial class DifferencesFrm : DevExpress.XtraEditors.XtraForm
    {
        int x = 1;
        int y = 2;
        public DifferencesFrm()
        {
            InitializeComponent();
        }
        public DataTable getDay()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where ParentID is null Order by ID ASC");
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
        public void GetParentIDKind()
        {

            //exCenter.Text = "";
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select ParentID from Tbl_AccountingRestrictions_Kind where ParentID=@P  ");

            com.Parameters.Add("@P", SqlDbType.Int).Value = comboBox1.SelectedValue;

            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                //comboBox2.Items.Add(red.GetValue(0)).ToString();
                textBox16.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();
        }
        private void GETDATA()
        {
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = @"SELECT        TOP (100) PERCENT dbo.Tbl_AccountingRestriction.Restriction_NO, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID, 
                         SUM(dbo.Tbl_AccountingRestrictionItems.Debit_Value) AS Expr1, SUM(dbo.Tbl_AccountingRestrictionItems.Credit_Value) AS Expr2, dbo.Tbl_AccountingRestrictions_Kind.Name, 
                         SUM(dbo.Tbl_AccountingRestrictionItems.Debit_Value) - SUM(dbo.Tbl_AccountingRestrictionItems.Credit_Value) AS Expr3
FROM            dbo.Tbl_AccountingRestrictionItems INNER JOIN
                         dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID INNER JOIN
                         dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID
GROUP BY dbo.Tbl_AccountingRestriction.Restriction_NO, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID, dbo.Tbl_AccountingRestrictions_Kind.Name
HAVING        (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @Date AND @Date2) AND (dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID = @P) AND (SUM(dbo.Tbl_AccountingRestrictionItems.Debit_Value) 
                         - SUM(dbo.Tbl_AccountingRestrictionItems.Credit_Value) <> 0) OR
                         (dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @Date AND @Date2) AND (dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID = @P1) AND (SUM(dbo.Tbl_AccountingRestrictionItems.Debit_Value) 
                         - SUM(dbo.Tbl_AccountingRestrictionItems.Credit_Value) <> 0)
ORDER BY dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID, dbo.Tbl_AccountingRestriction.Restriction_NO";
            com.Parameters.Add("@Date", SqlDbType.Date).Value = dateTimePicker1.Value;
            com.Parameters.Add("@Date2", SqlDbType.Date).Value = dateTimePicker2.Value;
            com.Parameters.Add("@P", SqlDbType.Int ).Value = x;
            com.Parameters.Add("@P1", SqlDbType.Int ).Value = y;
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6));
            }
            red.Close();
            con.Close();
        }
        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                GETDATA();
                if(dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد فروق");
                }
            }
        }

        private void DifferencesFrm_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = getDay();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
                comboBox1.SelectedIndex = 0;
                GetParentIDKind();
                if (Convert.ToInt32(textBox16.Text) == 12)
                {
                    x = 1;
                    y = 2;
                }

                if (Convert.ToInt32(textBox16.Text) == 13)
                {
                    x = 3;
                    y = 3;
                }
                if (Convert.ToInt32(textBox16.Text) == 14)
                {
                    x = 4;
                    y = 4;
                }
                if (Convert.ToInt32(textBox16.Text) == 15)
                {
                    x = 5;
                    y = 5;
                }
                if (Convert.ToInt32(textBox16.Text) == 16)
                {
                    x = 6;
                    y = 6;
                }
                if (Convert.ToInt32(textBox16.Text) == 17)
                {
                    x = 7;
                    y = 7;
                }
                if (Convert.ToInt32(textBox16.Text) == 18)
                {
                    x = 8;
                    y = 8;
                }
                if (Convert.ToInt32(textBox16.Text) == 19)
                {
                    x = 9;
                    y = 9;
                }
            }
            catch { }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetParentIDKind();
            if (Convert.ToInt32(textBox16.Text) == 12)
            {
                x = 1;
                y = 2;
            }

            if (Convert.ToInt32(textBox16.Text) == 13)
            {
                x = 3;
                y = 3;
            }
            if (Convert.ToInt32(textBox16.Text) == 14)
            {
                x = 4;
                y = 4;
            }
            if (Convert.ToInt32(textBox16.Text) == 15)
            {
                x = 5;
                y = 5;
            }
            if (Convert.ToInt32(textBox16.Text) == 16)
            {
                x = 6;
                y = 6;
            }
            if (Convert.ToInt32(textBox16.Text) == 17)
            {
                x = 7;
                y = 7;
            }
            if (Convert.ToInt32(textBox16.Text) == 18)
            {
                x = 8;
                y = 8;
            }
            if (Convert.ToInt32(textBox16.Text) == 19)
            {
                x = 9;
                y = 9;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }
    }
}