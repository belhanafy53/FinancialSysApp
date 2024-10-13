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
using Excel = Microsoft.Office.Interop.Excel;
namespace FinancialSysApp.Forms.ProcessingForms.Beneficiary_Rpt
{
    public partial class BeneficiaryRpt_Frm : DevExpress.XtraEditors.XtraForm
    {
        public BeneficiaryRpt_Frm()
        {
            InitializeComponent();
        }

        private void BeneficiaryRpt_Frm_Load(object sender, EventArgs e)
        {
            

        }
        private void GetData()
        {
            if (comboBox1.Text != "")
            {
                dataGridViewX1.Rows.Clear();
                dataGridViewX2.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("SELECT        dbo.Tbl_Beneficiary.Name, MONTH(dbo.Tbl_AccountingRestriction.Restriction_Date) AS Expr1, dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue,   dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name AS[اسم الحساب], SUM(dbo.Tbl_IndebtednessBeneficiary.DebitValue) - SUM(dbo.Tbl_IndebtednessBeneficiary.CreditValue) AS Total FROM            dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_IndebtednessBeneficiary ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_IndebtednessBeneficiary.Beneficiary_ID INNER JOIN dbo.Tbl_Indebtedness ON dbo.Tbl_IndebtednessBeneficiary.Indebtedness_ID = dbo.Tbl_Indebtedness.ID INNER JOIN dbo.Tbl_Accounting_Guid INNER JOIN dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID ON  dbo.Tbl_Indebtedness.AccountingRestrictionItems_ID = dbo.Tbl_AccountingRestrictionItems.ID INNER JOIN  dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID GROUP BY dbo.Tbl_Beneficiary.Name, dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name,  dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_AccountingRestriction.Restriction_NO  HAVING(dbo.Tbl_Beneficiary.Name = @Param1) AND(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @D AND @D1) And (dbo.Tbl_Accounting_Guid.Account_NO =@Ac) ");



                com.Parameters.Add("@Param1", SqlDbType.VarChar).Value = comboBox1.Text ;

                com.Parameters.Add("@D", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value);
                com.Parameters.Add("@D1", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value);
                com.Parameters.Add("@Ac", SqlDbType.NVarChar).Value = UsFul.Text;

                con.Open();
                red = com.ExecuteReader();
                if (red.HasRows)
                {
                    while (red.Read())
                    {
                        dataGridViewX1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6));

                        //dataGridViewX2.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6));
                    }
                    red.Close();
                    con.Close();

                }
                GetData1();
            }
            if (comboBox1.Text == "")
            {
                GetDataLike();
            }
        }
        private void GetDataLike()
        {
            if (comboBox1.Text == "")
            {
                dataGridViewX1.Rows.Clear();
                dataGridViewX2.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("SELECT        dbo.Tbl_Beneficiary.Name, MONTH(dbo.Tbl_AccountingRestriction.Restriction_Date) AS Expr1, dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue,   dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name AS[اسم الحساب], SUM(dbo.Tbl_IndebtednessBeneficiary.DebitValue) - SUM(dbo.Tbl_IndebtednessBeneficiary.CreditValue)  AS Total FROM            dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_IndebtednessBeneficiary ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_IndebtednessBeneficiary.Beneficiary_ID INNER JOIN dbo.Tbl_Indebtedness ON dbo.Tbl_IndebtednessBeneficiary.Indebtedness_ID = dbo.Tbl_Indebtedness.ID INNER JOIN dbo.Tbl_Accounting_Guid INNER JOIN dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID ON  dbo.Tbl_Indebtedness.AccountingRestrictionItems_ID = dbo.Tbl_AccountingRestrictionItems.ID INNER JOIN  dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID GROUP BY dbo.Tbl_Beneficiary.Name, dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name,  dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_AccountingRestriction.Restriction_NO  HAVING(dbo.Tbl_Beneficiary.Name LIKE @Param1) AND(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @D AND @D1) And (dbo.Tbl_Accounting_Guid.Account_NO =@Ac) ");



                com.Parameters.Add("@Param1", SqlDbType.VarChar).Value = "%";

                com.Parameters.Add("@D", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value);
                com.Parameters.Add("@D1", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value);
                com.Parameters.Add("@Ac", SqlDbType.NVarChar).Value = UsFul.Text;

                con.Open();
                red = com.ExecuteReader();
                if (red.HasRows)
                {
                    while (red.Read())
                    {
                        dataGridViewX1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6));

                        //dataGridViewX2.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6));
                    }
                    red.Close();
                    con.Close();

                }
                GetData1LIKE();
            }
           
        }
        private void GetData1LIKE()
        {
            //dataGridViewX1.Rows.Clear();
            dataGridViewX2.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("SELECT        dbo.Tbl_Beneficiary.Name,  dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue,    SUM(dbo.Tbl_IndebtednessBeneficiary.DebitValue) - SUM(dbo.Tbl_IndebtednessBeneficiary.CreditValue)  AS Total FROM            dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_IndebtednessBeneficiary ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_IndebtednessBeneficiary.Beneficiary_ID INNER JOIN dbo.Tbl_Indebtedness ON dbo.Tbl_IndebtednessBeneficiary.Indebtedness_ID = dbo.Tbl_Indebtedness.ID INNER JOIN dbo.Tbl_Accounting_Guid INNER JOIN dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID ON  dbo.Tbl_Indebtedness.AccountingRestrictionItems_ID = dbo.Tbl_AccountingRestrictionItems.ID INNER JOIN  dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID GROUP BY dbo.Tbl_Beneficiary.Name, dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name,  dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_AccountingRestriction.Restriction_NO  HAVING(dbo.Tbl_Beneficiary.Name Like @Param1) AND(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @D AND @D1) And (dbo.Tbl_Accounting_Guid.Account_NO =@Ac) ");




            com.Parameters.Add("@Param1", SqlDbType.VarChar).Value = "%";
            com.Parameters.Add("@D", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value);
            com.Parameters.Add("@D1", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value);
            com.Parameters.Add("@Ac", SqlDbType.NVarChar).Value = UsFul.Text;

            con.Open();
            red = com.ExecuteReader();
            if (red.HasRows)
            {
                while (red.Read())
                {
                    //dataGridViewX1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6));

                    dataGridViewX2.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3));
                }
                red.Close();
                con.Close();
            }
        }
        private void GetData1()
        {
            //dataGridViewX1.Rows.Clear();
            dataGridViewX2.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("SELECT        dbo.Tbl_Beneficiary.Name,  dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue,    SUM(dbo.Tbl_IndebtednessBeneficiary.DebitValue) - SUM(dbo.Tbl_IndebtednessBeneficiary.CreditValue)  AS Total FROM            dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_IndebtednessBeneficiary ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_IndebtednessBeneficiary.Beneficiary_ID INNER JOIN dbo.Tbl_Indebtedness ON dbo.Tbl_IndebtednessBeneficiary.Indebtedness_ID = dbo.Tbl_Indebtedness.ID INNER JOIN dbo.Tbl_Accounting_Guid INNER JOIN dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID ON  dbo.Tbl_Indebtedness.AccountingRestrictionItems_ID = dbo.Tbl_AccountingRestrictionItems.ID INNER JOIN  dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID GROUP BY dbo.Tbl_Beneficiary.Name, dbo.Tbl_IndebtednessBeneficiary.DebitValue, dbo.Tbl_IndebtednessBeneficiary.CreditValue, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_Accounting_Guid.Name,  dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_AccountingRestriction.Restriction_NO  HAVING(dbo.Tbl_Beneficiary.Name = @Param1) AND(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @D AND @D1) And (dbo.Tbl_Accounting_Guid.Account_NO =@Ac) ");




            com.Parameters.Add("@Param1", SqlDbType.VarChar).Value = comboBox1.Text ;
            com.Parameters.Add("@D", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value);
            com.Parameters.Add("@D1", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value);
            com.Parameters.Add("@Ac", SqlDbType.NVarChar).Value = UsFul.Text;

            con.Open();
            red = com.ExecuteReader();
            if (red.HasRows)
            {
                while (red.Read())
                {
                    //dataGridViewX1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6));

                    dataGridViewX2.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3));
                }
                red.Close();
                con.Close();
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            //if (UsFul.Text != "")
            //{
            //    dataGridViewX1.Rows.Clear();
            //    dataGridViewX2.Rows.Clear();
            GetData();
            //}
            //if (UsFul.Text == "")
            //{
            //    dataGridViewX1.Rows.Clear();
            //    dataGridViewX2.Rows.Clear();
            //    GetData1();
            //}
        }
        
        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel  
                for (int i = 1; i < dataGridViewX1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridViewX1.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridViewX1.Rows.Count ; i++)
                {
                    for (int j = 0; j < dataGridViewX1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewX1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
            }
            catch { }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel  
                for (int i = 1; i < dataGridViewX2.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridViewX2.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewX2.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewX2.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                workbook.SaveAs("c:\\output1.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
            }
            catch { }
        }

        private void UsFul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && UsFul.Focus() == true)
            {
                try
                {
                    FindAccount  f = new FindAccount();

                    
                    f.ShowDialog();
                    UsFul.Text = FindAccount.SelectedRow.Cells[0].Value.ToString();
                    accName.Text = FindAccount.SelectedRow.Cells[1].Value.ToString();
                }
                catch { }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && UsFul.Focus() == true)
            {
                try
                {
                    FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                   
                    comboBox1.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                    

                    
                }
                catch { }

            }
        }
    }
}