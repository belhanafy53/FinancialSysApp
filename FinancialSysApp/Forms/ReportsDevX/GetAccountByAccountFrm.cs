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

namespace FinancialSysApp.Forms.ReportsDevX
{

    public partial class GetAccountByAccountFrm : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }

        public GetAccountByAccountFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{ 
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
           
                com.CommandType = CommandType.Text;
                //and  (dbo.Tbl_AccountingRestriction.Restriction_NO = dbo.Tbl_AccountingRestriction.Restriction_NO)
                com.CommandText = "SELECT  dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestriction.Restriction_NO, Sum (Distinct dbo.Tbl_AccountingRestrictionItems.Debit_Value), Sum (Distinct dbo.Tbl_AccountingRestrictionItems.Credit_Value), dbo.Tbl_AccountingRestrictionItems.ID,dbo.Tbl_Accounting_Guid.ID, dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID FROM dbo.Tbl_AccountingRestrictionItems INNER JOIN dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID = dbo.Tbl_Accounting_Guid.ID where (dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID=@ID) and (dbo.Tbl_AccountingRestriction.Restriction_Date between @D and @D1) and  (dbo.Tbl_AccountingRestriction.Restriction_NO = dbo.Tbl_AccountingRestriction.Restriction_NO) and dbo.Tbl_Accounting_Guid.Account_NO=@R or   (dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID=@ID) and (dbo.Tbl_AccountingRestriction.Restriction_Date between @D and @D1) and  (dbo.Tbl_AccountingRestriction.Restriction_NO = dbo.Tbl_AccountingRestriction.Restriction_NO) and dbo.Tbl_Accounting_Guid.Account_NO=@R1  group by dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestriction.Restriction_NO, dbo.Tbl_AccountingRestrictionItems.Debit_Value, dbo.Tbl_AccountingRestrictionItems.Credit_Value, dbo.Tbl_AccountingRestrictionItems.ID,dbo.Tbl_Accounting_Guid.ID, dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID  ";
                com.Parameters.Add("@ID", SqlDbType.Int).Value = comboBox2.SelectedValue;
                com.Parameters.Add("@D", SqlDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
                com.Parameters.Add("@D1", SqlDbType.Date).Value = dateTimePicker2.Value.ToShortDateString();
            com.Parameters.Add("@R", SqlDbType.NVarChar).Value = textBox1.Text;
            com.Parameters.Add("@R1", SqlDbType.NVarChar).Value = textBox2.Text;
            SqlDataReader red;
                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {
                    dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6),  red.GetValue(7));
                dataGridView2.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6),  red.GetValue(7));

            }
                red.Close();
                con.Close();
            //dataGridView1.SelectAll();
            //for (int i = 0; i < dataGridView1.SelectedRows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dataGridView1.SelectedRows[i].Cells.Count; j++)
            //    {
            //        if (dataGridView1.SelectedRows[i].Cells[j].Value.Equals(dataGridView1.SelectedRows[i + 1].Cells[j].Value))
            //        {
            //            dataGridView1.SelectedRows[i].Cells[j].Style.BackColor = Color.Red;
            //            dataGridView1.SelectedRows[i + 1].Cells[j].Style.BackColor = Color.Red;
            //        }
            //    }
            //}
            //for (int i = 0; i < dataGridView1.Rows.Count; i++) //compare data
            //{
            //    var Row = dataGridView1.Rows[i];
            //    string abc = Row.Cells[2].Value.ToString();

            //    for (int j = 0 ; j < dataGridView1.Rows.Count ; j++)
            //    {
            //        var Row2 = dataGridView1.Rows[j];
            //        string def = Row2.Cells[2].Value.ToString();
            //        if (abc == def)
            //        {
            //            dataGridView1.Rows.Remove(Row2);

            //            //j--;
            //        }
            //    }
            //}
           
            for (int v = 0; v < dataGridView1.Rows.Count; v++)
            {
                dataGridView2.Rows.Add(dataGridView1.Rows[v].Cells[0].Value.ToString(), dataGridView1.Rows[v].Cells[1].Value.ToString(), dataGridView1.Rows[v].Cells[2].Value.ToString(), dataGridView1.Rows[v].Cells[3].Value.ToString(), dataGridView1.Rows[v].Cells[4].Value.ToString(), dataGridView1.Rows[v].Cells[5].Value.ToString(), dataGridView1.Rows[v].Cells[6].Value.ToString(), dataGridView1.Rows[v].Cells[7].Value.ToString());

                dataGridView3.Rows.Add(dataGridView1.Rows[v].Cells[0].Value.ToString(), dataGridView1.Rows[v].Cells[1].Value.ToString(), dataGridView1.Rows[v].Cells[2].Value.ToString(), dataGridView1.Rows[v].Cells[3].Value.ToString(), dataGridView1.Rows[v].Cells[4].Value.ToString(), dataGridView1.Rows[v].Cells[5].Value.ToString(), dataGridView1.Rows[v].Cells[6].Value.ToString(), dataGridView1.Rows[v].Cells[7].Value.ToString());
            }
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    foreach (DataGridViewRow row1 in dataGridView3.Rows)
            //    {
            //        if (row.Cells[2].Value.ToString() == row1.Cells[2].Value.ToString())
            //        {
            //            dataGridView2.Rows.Remove(row1);
            //            dataGridView3.Rows.Remove(row);
            //        }
            //    }
            //}
            button2_Click(sender, e);
            //}
            //    catch { MessageBox.Show("تأكد من إدخال الشروط بشكل صحيح"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //***********************
            //for (int i = 0; i < dataGridView1.Rows.Count; i++) //compare data
            //{
            //    var Row = dataGridView1.Rows[i];
            //    string abc = Row.Cells[2].Value.ToString();
            //    string acc = Row.Cells[1].Value.ToString();

            //    for (int j = 0; j < dataGridView1.Rows.Count; j++)
            //    {
            //        var Row2 = dataGridView1.Rows[j];
            //        string def = Row2.Cells[2].Value.ToString();
            //        string acc1 = Row2.Cells[1].Value.ToString();
            //        //string ID = Row2.Cells[5].Value.ToString();
            //        if (abc == def && textBox1.Text == acc1 && abc == def && textBox2.Text == acc)
            //        {
            //            //for (int h = 0; h < dataGridView4.Rows.Count; h++)
            //            //{
            //            //    var Row3 = dataGridView4.Rows[h];
            //            //    string ID1 = Row3.Cells[5].Value.ToString();


            //            dataGridView4.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value, dataGridView1.Rows[i].Cells[4].Value, dataGridView1.Rows[i].Cells[5].Value, dataGridView1.Rows[i].Cells[6].Value, true, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), dataGridView1.Rows[i].Cells[7].Value);
            //            //if (ID == ID1)
            //            //{
            //            dataGridView4.Rows.Add(dataGridView1.Rows[j].Cells[0].Value, dataGridView1.Rows[j].Cells[1].Value, dataGridView1.Rows[j].Cells[2].Value, dataGridView1.Rows[j].Cells[3].Value, dataGridView1.Rows[j].Cells[4].Value, dataGridView1.Rows[j].Cells[5].Value, dataGridView1.Rows[j].Cells[6].Value, true, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), dataGridView1.Rows[j].Cells[7].Value);
            //            //}
            //            //}
            //        }
            //    }
            //}

            //**********************
            for (int i = 0; i < dataGridView2.Rows.Count; i++) //compare data
            {
                var Row = dataGridView2.Rows[i];
                string abc = Row.Cells[2].Value.ToString();
                string acc = Row.Cells[1].Value.ToString();

                for (int j = 0; j < dataGridView3.Rows.Count; j++)
                {
                    var Row2 = dataGridView3.Rows[j];
                    string def = Row2.Cells[2].Value.ToString();
                    string acc1 = Row2.Cells[1].Value.ToString();
                    string ID = Row2.Cells[5].Value.ToString();
                    if (abc == def && textBox1.Text == acc1  && textBox2.Text == acc)
                    {
                        //for (int h = 0; h < dataGridView4.Rows.Count; h++)
                        //{
                        //    var Row3 = dataGridView4.Rows[h];
                        //    string ID1 = Row3.Cells[5].Value.ToString();


                        dataGridView4.Rows.Add(dataGridView2.Rows[i].Cells[0].Value, dataGridView2.Rows[i].Cells[1].Value, dataGridView2.Rows[i].Cells[2].Value, dataGridView2.Rows[i].Cells[3].Value, dataGridView2.Rows[i].Cells[4].Value, dataGridView2.Rows[i].Cells[5].Value, dataGridView2.Rows[i].Cells[6].Value, true, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), dataGridView2.Rows[i].Cells[7].Value);
                        //if (ID == ID1)
                        //{
                        dataGridView4.Rows.Add(dataGridView3.Rows[j].Cells[0].Value, dataGridView3.Rows[j].Cells[1].Value, dataGridView3.Rows[j].Cells[2].Value, dataGridView3.Rows[j].Cells[3].Value, dataGridView3.Rows[j].Cells[4].Value, dataGridView3.Rows[j].Cells[5].Value, dataGridView3.Rows[j].Cells[6].Value, true, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(), dataGridView3.Rows[j].Cells[7].Value);
                        //}
                        //}
                    }
                }
                textBox3.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                textBox4.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[4].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                button3_Click(sender, e);
                dataGridView4.Rows.Clear();
                getData();
                //Check();
            }
        }
        private void Check()
        {
            for (int i = 0; i < dataGridView4.RowCount; i++) //compare data
            {
                var Row = dataGridView4.Rows[i];
                string abc = Row.Cells[3].Value.ToString();
                string abc1 = Row.Cells[4].Value.ToString();
                string acc = Row.Cells[1].Value.ToString();
                string Res = Row.Cells[2].Value.ToString();
                for (int j = 0; j < dataGridView4.RowCount; j++)
                {
                    var Row2 = dataGridView4.Rows[j];
                    string def = Row2.Cells[3].Value.ToString();
                    string def1 = Row2.Cells[4].Value.ToString();
                    string acc1 = Row2.Cells[1].Value.ToString();
                    string Res1 = Row2.Cells[2].Value.ToString();
                    if (abc == def && abc1 == def1 && acc == acc1  && Res == Res1)
                    {
                        dataGridView4.Rows.Remove(Row2);

                        j--;
                    }
                }
            }
        }
        public DataTable getDay()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where ParentID is Not null Order by ID ASC");
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
        private void GetAccountByAccountFrm_Load(object sender, EventArgs e)
        {
            
            //comboBox2.SelectedIndex = 0;
            getData();
        }
        private void DeleteData()
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show(" هل أنت متأكد من حذف البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;

                com.Parameters.Clear();
                com.CommandText = ("delete   from Tbl_AccountByAccountSetting where RestrictionItems_ID=@ID");
                SqlDataReader red;
                con.Open();
                com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView4.CurrentRow.Cells[5].Value.ToString());
                red = com.ExecuteReader();

                red.Close();
                con.Close();
                if (dataGridView4.Rows.Count > 0)
                {
                    textBox3.Text = (from DataGridViewRow row in dataGridView4.Rows
                                     where row.Cells[3].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                    textBox4.Text = (from DataGridViewRow row in dataGridView4.Rows
                                     where row.Cells[4].FormattedValue.ToString() != string.Empty
                                     select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                }
            }
        }
        private void getData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            
                    com.Parameters.Clear();
                    com.CommandText = ("select  AccountNumber,AccountName,Account_Guid_ID,DateFrom,DateTo,RestrictionItems_ID,Restriction_no,RestrictionKind_ID,SUM(DISTINCT Debit),SUM(DISTINCT Credit) from Tbl_AccountByAccountSetting GROUP BY AccountNumber,AccountName,Account_Guid_ID,DateFrom,DateTo,RestrictionItems_ID,Restriction_no,RestrictionKind_ID           order by Restriction_no asc");
            SqlDataReader red;
                    con.Open();
                   red =  com.ExecuteReader ();
            while (red.Read())
            {
                dataGridView4.Rows.Add(red.GetValue(1), red.GetValue(0), red.GetValue(6), red.GetValue(8), red.GetValue(9), red.GetValue(5), red.GetValue(2), false, red.GetValue(3), red.GetValue(4), red.GetValue(7));
            }
            red.Close();
            con.Close();
            if(dataGridView4.Rows.Count >0)
            {
                textBox3.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                textBox4.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[4].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            }
        }

        private void getDatawithLike()
        {
            dataGridView4.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;

            com.Parameters.Clear();
            com.CommandText = ("select  AccountNumber,AccountName,Account_Guid_ID,DateFrom,DateTo,RestrictionItems_ID,Restriction_no,RestrictionKind_ID,SUM(DISTINCT Debit),SUM(DISTINCT Credit) from Tbl_AccountByAccountSetting where AccountNumber Like @A GROUP BY AccountNumber,AccountName,Account_Guid_ID,DateFrom,DateTo,RestrictionItems_ID,Restriction_no,RestrictionKind_ID           order by Restriction_no asc");
            com.Parameters.Add("@A", SqlDbType.NVarChar).Value = "%" + textBox5.Text + "%";
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                dataGridView4.Rows.Add(red.GetValue(1), red.GetValue(0), red.GetValue(6), red.GetValue(8), red.GetValue(9), red.GetValue(5), red.GetValue(2), false, red.GetValue(3), red.GetValue(4), red.GetValue(7));
            }
            red.Close();
            con.Close();
            if (dataGridView4.Rows.Count > 0)
            {
                textBox3.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                textBox4.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[4].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                foreach (DataGridViewRow Row in dataGridView4.Rows)
                {

                    bool isSelected = Convert.ToBoolean(Row.Cells["Column9"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        com.CommandText = ("Insert Into Tbl_AccountByAccountSetting (AccountNumber,AccountName,Account_Guid_ID,DateFrom,DateTo,RestrictionItems_ID,Restriction_no,RestrictionKind_ID,Debit,Credit) Values (@AccountNumber,@AccountName,@Account_Guid_ID,@DateFrom,@DateTo,@RestrictionItems_ID,@Restriction_no,@RestrictionKind_ID,@Debit,@Credit)");
                        com.Parameters.Add("@AccountNumber", SqlDbType.NVarChar).Value = Row.Cells[1].Value;
                        com.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = Row.Cells[0].Value;
                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(Row.Cells[6].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(Row.Cells[8].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(Row.Cells[9].Value);
                        com.Parameters.Add("@RestrictionItems_ID", SqlDbType.Int).Value = Convert.ToInt32(Row.Cells[5].Value);
                        com.Parameters.Add("@Restriction_no", SqlDbType.NVarChar).Value = Row.Cells[2].Value;
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(Row.Cells[10].Value);
                        com.Parameters.Add("@Debit", SqlDbType.Decimal).Value = Convert.ToDecimal(Row.Cells[3].Value);
                        com.Parameters.Add("@Credit", SqlDbType.Decimal).Value = Convert.ToDecimal(Row.Cells[4].Value);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    dataGridView4.Rows[i].Cells[7].Value = false;
                }
            }
            catch { MessageBox.Show("تأكد من إدخال الشروط بشكل صحيح"); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            button1_Click(sender,  e);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                textBox2.Focus();
            }
            if (e.KeyCode == Keys.Down )
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    f.ShowDialog();
                    textBox1.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();

                }
                catch { }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    f.ShowDialog();
                    textBox2.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();

                }
                catch { }
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void simpleButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void dataGridView4_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                textBox3.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                textBox4.Text = (from DataGridViewRow row in dataGridView4.Rows
                                 where row.Cells[4].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            }
            catch { }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DeleteData();
            dataGridView4.Rows.Clear();
            getData();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            getDatawithLike();
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dataGridView4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView4.CurrentCell.ColumnIndex, dataGridView4.CurrentCell.RowIndex);

                dataGridView4_CellDoubleClick(dataGridView4, args);

                
                

            }
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView4.Rows[e.RowIndex];
           
            this.Close();
            
        }

        private void GetAccountByAccountFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SelectedRow == null)
            {
                try
                {
                    //this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.FillAccountNumber(this.dataSet1.Tbl_RestrictionItemsCategory_With_AccountNumber, textBox1.Text);
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView4.CurrentCell.ColumnIndex, dataGridView4.CurrentCell.RowIndex);

                    dataGridView4_CellDoubleClick(dataGridView1, args);
                }
                catch { }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox5.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }
    }
}