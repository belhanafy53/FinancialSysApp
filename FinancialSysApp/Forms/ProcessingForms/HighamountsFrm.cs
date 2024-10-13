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
    public partial class HighamountsFrm : DevExpress.XtraEditors.XtraForm
    {
        public HighamountsFrm()
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
            com.CommandText = ("select * from Tbl_IndebtednessKind  Order by ID ASC");
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
        private void HighamountsFrm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = getDay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            //comboBox1.SelectedIndex = 0;
            if (LB.Text == "1")
            {
                comboBox1.SelectedValue = 8;
            }
            if (LB.Text == "2")
            {
                comboBox1.SelectedValue = 7;
            }
            GETDATA();
            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[1].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[2].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
            textEdit1.Text = dataGridView1.Rows.Count.ToString();
            double xx, yy, zz;
            xx = Convert.ToDouble(tD.Text);
            yy = Convert.ToDouble(tC.Text);
            zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            //df.Text = Convert.ToString(zz);

            decimal DebitV, CriditV, MainDebit, MainCridit;
            CriditV = Convert.ToDecimal(tD.Text);
            DebitV = Convert.ToDecimal(tC.Text);
            MainDebit = Convert.ToDecimal(Debit.Text);
            MainCridit = Convert.ToDecimal(Cridit.Text);
            UsFul.Select();
            this.ActiveControl = UsFul;
            UsFul.Focus();
        }

        private void UsFul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down  && UsFul.Focus() == true)
            {
                try
                {
                    FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                    f.label1.Text = "R";
                    UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                    UsFulID.Text = FindUsefl.SelectedRow.Cells[0].Value.ToString();
                }
                catch { }

            }
            if (e.KeyCode == Keys.Delete  && UsFul.Focus() == true)
            {
                try
                {
                    //FindDepart f = new FindDepart();
                    //f.ShowDialog();
                    UsFul.Text = DBNull.Value.ToString();
                    UsFulID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)

            {
                textBox3.Focus();
            }
            }
        private void SaveIndebtedness()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = ("Insert Into Tbl_Indebtedness(IndebtednessKind_ID,AccountingRestrictionItems_ID,DebitIndebtedness,CreditIndebtedness) values(@IndebtednessKind_ID,@AccountingRestrictionItems_ID,@DebitIndebtedness,@CreditIndebtedness)");
            com.Parameters.Add("@IndebtednessKind_ID", SqlDbType.Int).Value = comboBox1.SelectedValue;
            com.Parameters.Add("@AccountingRestrictionItems_ID", SqlDbType.Int).Value = Convert.ToInt32(Code.Text);
            com.Parameters.Add("@DebitIndebtedness", SqlDbType.Decimal).Value = Convert.ToDecimal(Debit.Text);
            com.Parameters.Add("@CreditIndebtedness", SqlDbType.Decimal).Value = Convert.ToDecimal(Cridit.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        private void GETMAXID()
        {
            MAXID.Text = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = ("Select ID from Tbl_Indebtedness where AccountingRestrictionItems_ID=@AccountingRestrictionItems_ID ");
            com.Parameters.Add("@AccountingRestrictionItems_ID", SqlDbType.Int).Value = Convert.ToInt32(Code.Text ); 
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while(red.Read())
            {
                MAXID.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();
        }
        private void GETDATA()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = "SELECT dbo.Tbl_Beneficiary.Name, dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue, dbo.Tbl_IndebtednessBeneficiary.IndebtednessReason,dbo.Tbl_IndebtednessBeneficiary.Beneficiary_ID, dbo.Tbl_IndebtednessBeneficiary.Indebtedness_ID,dbo.Tbl_IndebtednessBeneficiary.ID FROM  dbo.Tbl_IndebtednessBeneficiary INNER JOIN dbo.Tbl_Indebtedness ON dbo.Tbl_IndebtednessBeneficiary.Indebtedness_ID = dbo.Tbl_Indebtedness.ID INNER JOIN dbo.Tbl_IndebtednessKind ON dbo.Tbl_Indebtedness.IndebtednessKind_ID = dbo.Tbl_IndebtednessKind.ID INNER JOIN dbo.Tbl_Beneficiary ON dbo.Tbl_IndebtednessBeneficiary.Beneficiary_ID = dbo.Tbl_Beneficiary.ID INNER JOIN dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_Indebtedness.AccountingRestrictionItems_ID = dbo.Tbl_AccountingRestrictionItems.ID INNER JOIN dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID = dbo.Tbl_Accounting_Guid.ID INNER JOIN dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID AND dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID WHERE(dbo.Tbl_AccountingRestrictionItems.ID = @P)";
            com.Parameters.Add("@P", SqlDbType.Int).Value = Convert.ToInt32(Code.Text);
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4),red.GetValue(5), 0, red.GetValue(6));
            }
            red.Close();
            con.Close();
        }
        private void SaveIndebtednessBenefi()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Column4"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_IndebtednessBeneficiary(Indebtedness_ID,Beneficiary_ID,DebitValue,CreditValue,IndebtednessReason) values(@Indebtedness_ID,@Beneficiary_ID,@DebitValue,@CreditValue,@IndebtednessReason)");
                    com.Parameters.Add("@Indebtedness_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);
                    com.Parameters.Add("@Beneficiary_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    if (row.Cells[1].Value == DBNull.Value)
                    {
                        com.Parameters.Add("@DebitValue", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    if (row.Cells[1].Value != DBNull.Value)
                    {
                        com.Parameters.Add("@DebitValue", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[1].Value);
                    }
                    if (row.Cells[2].Value == DBNull.Value)
                    {
                        com.Parameters.Add("@CreditValue", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    if (row.Cells[2].Value != DBNull.Value)
                    {
                        com.Parameters.Add("@CreditValue", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[2].Value);
                    }
                    com.Parameters.Add("@IndebtednessReason", SqlDbType.NVarChar).Value = row.Cells[3].Value.ToString();
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void UpdateIndebtednessBenefi()
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
                    
                    com.CommandText = ("UPdate Tbl_IndebtednessBeneficiary set Beneficiary_ID=@BID,DebitValue=@DV,CreditValue=@CV,IndebtednessReason=@R where ID=@ID");
                    
                    com.Parameters.Add("@BID", SqlDbType.Int).Value = Convert.ToInt32(UsFulID.Text );
                    if (textBox3.Text  == string.Empty )
                    {
                        com.Parameters.Add("@DV", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    if (textBox3.Text != string.Empty)
                    {
                        com.Parameters.Add("@DV", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox3.Text );
                    }
                    if (textBox4.Text == string.Empty)
                    {
                        com.Parameters.Add("@CV", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    if (textBox4.Text != string.Empty)
                    {
                        com.Parameters.Add("@CV", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox4.Text);
                    }
                    com.Parameters.Add("@R", SqlDbType.NVarChar).Value = textBox1.Text ;

            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
            con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
               
        }
        private void DeleteIndebtednessBenefi()
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

            com.CommandText = ("Delete From Tbl_IndebtednessBeneficiary  where ID=@ID");

            

            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        private void AddToGrid()
        {
            dataGridView1.Rows.Add(UsFul.Text, textBox3.Text, textBox4.Text, textBox1.Text, UsFulID.Text, MAXID.Text,true );
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            UsFul.Focus();
            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

            dataGridViewX2_CellEnter(dataGridView1, args);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (CriditV > MainCridit)
            //{
            //    MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
            //    textBox4.Focus();
            //}

            //if (DebitV > MainDebit)
            //{
            //    MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
            //    textBox4.Focus();
            //}
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "0";
            }
            if (textBox4.Text == string.Empty)
            {
                textBox4.Text = "0";
            }
            SaveIndebtedness();
            GETMAXID();
            SaveIndebtednessBenefi();
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                decimal DebitV, CriditV, MainDebit, MainCridit;
                CriditV = Convert.ToDecimal(textBox4.Text);
                DebitV = Convert.ToDecimal(textBox3.Text);
                MainDebit = Convert.ToDecimal(Debit.Text);
                MainCridit = Convert.ToDecimal(Cridit.Text);
                if (DebitV <= MainDebit && CriditV <= MainCridit && DebitV!=0 || CriditV!=0)
                {
                    
                        AddToGrid();
                    simpleButton1.Enabled = false;
                    simpleButton7.Enabled = false;
                    simpleButton8.Enabled = false;
                   
                    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[1].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
                    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[2].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
                    textEdit1.Text = dataGridView1.Rows.Count.ToString();
                    double xx, yy, zz;
                    xx = Convert.ToDouble(tD.Text);
                    yy = Convert.ToDouble(tC.Text);
                    zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);



                    //if (CriditV <= MainCridit)
                    //{

                    //    simpleButton1.Enabled = true;
                    //    simpleButton7.Enabled = true;
                    //    simpleButton8.Enabled = true;
                    //}

                    //if (DebitV <= MainDebit)
                    //{

                    //    simpleButton1.Enabled = true;
                    //    simpleButton7.Enabled = true;
                    //    simpleButton8.Enabled = true;
                    //}
                    textBox3.Text = "0";
                    textBox4.Text = "0";
                }
                else
                {
                   
                    MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
                    //dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                    
                    simpleButton1.Enabled = false ;
                    simpleButton7.Enabled = false;
                    simpleButton8.Enabled = false ;
                    dataGridView1.AllowUserToAddRows = false;
                    textBox3.Text = "0";
                    textBox4.Text = "0";
                   
                }
            }
        }

        private void dataGridViewX2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentCell.RowIndex;
            // Check if the current row is a new row.
            if (dataGridView1.Rows[currentIndex].IsNewRow)
            {
                // The current row is a new row.
                dataGridView1.CurrentRow.Cells[6].Value = true;
                simpleButton1.Enabled = true;
            }
        }

        private void dataGridViewX2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void dataGridViewX2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
            }
            catch { }
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                UsFulID.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                UsFul.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
                
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            UpdateIndebtednessBenefi();
            dataGridView1.Rows.Clear();
            GETDATA();
            MessageBox.Show("تم التعديل بنجاح");
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            DeleteIndebtednessBenefi();
            dataGridView1.Rows.Clear();
            GETDATA();
            MessageBox.Show("تم الحذف بنجاح");
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                textBox1.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //if(textBox4.Text !=string.Empty )
            //{
            //    textBox3.Text = "0";
            //}
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //if (textBox3.Text != string.Empty)
            //{
            //    textBox4.Text = "0";
            //}
        }
        private void CheckValue()
        {
            decimal  DebitV, CriditV, MainDebit, MainCridit;
            CriditV = Convert.ToDecimal(tC.Text);
            DebitV = Convert.ToDecimal(tD.Text);
            MainDebit = Convert.ToDecimal(Debit.Text);
            MainCridit = Convert.ToDecimal(Cridit.Text);
            //if (CriditV > MainCridit)
            //{
            //    MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
            //    simpleButton1.Enabled = false;
            //    simpleButton7.Enabled = false;
            //    //simpleButton8.Enabled = false;
            //    textBox3.Focus();
            //}

            if (DebitV > MainDebit || CriditV > MainCridit)
            {
                MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
                simpleButton1.Enabled = false;
                simpleButton7.Enabled = false;
                //simpleButton8.Enabled = false;
                //textBox4.Focus();
            }
            if (DebitV <= MainDebit && CriditV <= MainCridit)
            {
               // MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
                simpleButton1.Enabled = true;
                simpleButton7.Enabled = true;
                simpleButton8.Enabled = true;
                //textBox4.Focus();
            }

            //if (CriditV <= MainCridit)
            //{
            //    // MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
            //    simpleButton1.Enabled = true;
            //    simpleButton7.Enabled = true;
            //    simpleButton8.Enabled = true;
            //    //textBox4.Focus();
            //}
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            decimal DebitV, CriditV, MainDebit, MainCridit;
            CriditV = Convert.ToDecimal(tC.Text);
            DebitV = Convert.ToDecimal(tD.Text);
            MainDebit = Convert.ToDecimal(Debit.Text);
            MainCridit = Convert.ToDecimal(Cridit.Text);
            if (DebitV > MainDebit || CriditV > MainCridit)
            {
                MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
                simpleButton1.Enabled = false;
                simpleButton7.Enabled = false;
                //simpleButton8.Enabled = false;
                //textBox4.Focus();
            }
            if (DebitV <= MainDebit && CriditV <= MainCridit)
            {
                // MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
                simpleButton1.Enabled = true;
                simpleButton7.Enabled = true;
                simpleButton8.Enabled = true;
                //textBox4.Focus();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            decimal DebitV, CriditV, MainDebit, MainCridit;
            CriditV = Convert.ToDecimal(tC.Text);
            DebitV = Convert.ToDecimal(tD.Text);
            MainDebit = Convert.ToDecimal(Debit.Text);
            MainCridit = Convert.ToDecimal(Cridit.Text);
            if (DebitV > MainDebit || CriditV > MainCridit)
            {
                MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
                simpleButton1.Enabled = false;
                simpleButton7.Enabled = false;
                //simpleButton8.Enabled = false;
                //textBox4.Focus();
            }
            if (DebitV <= MainDebit && CriditV <= MainCridit)
            {
                // MessageBox.Show("الرجاء تحقق من القيمة المدحلة لا تكون أكبر من القيمة فى المستند");
                simpleButton1.Enabled = true;
                simpleButton7.Enabled = true;
                simpleButton8.Enabled = true;
                //textBox4.Focus();
            }
        }

        private void UsFul_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tC_TextChanged(object sender, EventArgs e)
        {
            CheckValue();
        }

        private void tD_TextChanged(object sender, EventArgs e)
        {
            CheckValue();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[1].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
                tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[2].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
                textEdit1.Text = dataGridView1.Rows.Count.ToString();
                double xx, yy, zz;
                xx = Convert.ToDouble(tD.Text);
                yy = Convert.ToDouble(tC.Text);
                zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                //df.Text = Convert.ToString(zz);

                decimal DebitV, CriditV, MainDebit, MainCridit;
                CriditV = Convert.ToDecimal(tD.Text);
                DebitV = Convert.ToDecimal(tC.Text);
                MainDebit = Convert.ToDecimal(Debit.Text);
                MainCridit = Convert.ToDecimal(Cridit.Text);
            }
            catch { }
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
           
        //}

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "0";
            }
            if (textBox4.Text == string.Empty)
            {
                textBox4.Text = "0";
            }
            SaveIndebtedness();
            GETMAXID();
            SaveIndebtednessBenefi();
            MessageBox.Show("تم الحفظ بنجاح");
        }
    }
}