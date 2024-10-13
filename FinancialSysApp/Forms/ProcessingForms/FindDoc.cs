using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
using DevComponents.DotNetBar;
using AnalogClock.My.Resources;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Diagnostics;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindDoc : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindDoc()
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
            com.CommandText = ("SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS التاريخ, dbo.Tbl_AccountingRestrictions_Kind.Name AS [ اليومية], dbo.Tbl_AccountingRestriction.ID FROM dbo.Tbl_AccountingRestriction INNER JOIN dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID  group by Restriction_NO,Restriction_Date,dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID,dbo.Tbl_AccountingRestriction.ID  order by dbo.Tbl_AccountingRestriction.Restriction_Date ASC");
            //com.Parameters.Add("@p", SqlDbType.Int).Value = int.Parse(textBox1.Text);
            //com.Parameters.Add("@p1", SqlDbType.Int).Value = int.Parse(textBox3.Text);
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

        public DataTable FindDocN()
        {

            
                //DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = ("SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS التاريخ, dbo.Tbl_AccountingRestrictions_Kind.Name AS [ اليومية], dbo.Tbl_AccountingRestriction.ID FROM dbo.Tbl_AccountingRestriction INNER JOIN dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID  where  dbo.Tbl_AccountingRestriction.Restriction_NO =@T  group by Restriction_NO,Restriction_Date,dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID,dbo.Tbl_AccountingRestriction.ID  order by dbo.Tbl_AccountingRestriction.Restriction_Date ASC");
                //com.Parameters.Add("@p", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                //com.Parameters.Add("@p1", SqlDbType.Int).Value = int.Parse(textBox3.Text);
                com.Parameters.Add("@T", SqlDbType.Int).Value = int.Parse(textBox4.Text);
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
        private void FindDoc_Load(object sender, EventArgs e)
        {
            SelectedRow = null;
            dataGridView1.DataSource = getDay();
            textBox4.Select();
            this.ActiveControl = textBox4;
            textBox4.Focus();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    Res_Frm f = new Res_Frm();
            //    //r.Restriction_NO.Text = "0";
            //    f.Lyear.Text   = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            //    //r.CleareControls();
            //    //r.GetREstrictionID();
            //    //r.FindFileNumber1();
            //    //r.GetDocumentData();
            //    this.Close();
                
            //}
            //else
            //{
            //    MessageBox.Show("لا توجد مستندات تم تحديدها");
            //    //r.Restriction_NO.Text = "0";
            //    this.Close();
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty)
            {
                try
                {
                    dataGridView1.DataSource = FindDocN();
                }
                catch { }
            }
            else
            { textBox4.Text = "0"; }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                dataGridView1_CellDoubleClick(dataGridView1, args);



            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }

        private void FindDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow = null;
                this.Close();
            }
        }
    }
}