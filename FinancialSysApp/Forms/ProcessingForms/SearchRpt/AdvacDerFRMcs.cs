using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraTreeList.Nodes;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using FinancialSysApp.DataBase.ModelEvents;
using FinancialSysApp.DataBase.Model;

using System.Data.OleDb;

namespace FinancialSysApp.Forms.ProcessingForms.SearchRpt
{
    public partial class AdvacDerFRMcs : DevExpress.XtraEditors.XtraForm
    {
        public AdvacDerFRMcs()
        {
            InitializeComponent();
        }
        public  void  GetAdvacData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            SqlDataReader red;
            int Vint_TreelistCount = treeList1.Nodes.Count();
            List<TreeListNode> nodes = treeList1.GetNodeList();
            com.CommandTimeout = 60;
            foreach (TreeListNode item in nodes)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    
                    int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
                    string VStr_MenuPr = item.GetValue("Name").ToString();
                    com.Parameters.Clear();
                    com.CommandText = ("SELECT         dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Detail.TR_NO AS RNumber, dbo.Detail.TR_DT AS [Re Number], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم Acc], SUM(CONVERT(decimal,  dbo.Detail.DB_VL)) AS Debit, SUM(CONVERT(decimal, dbo.Detail.CR_VL)) AS Cridt FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN dbo.Detail ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Detail.JRN_CD FULL OUTER JOIN dbo.Tbl_Accounting_Guid ON dbo.Detail.ACC_NO COLLATE Arabic_100_CI_AS_KS = dbo.Tbl_Accounting_Guid.Advac_AccountingNO WHERE(dbo.Detail.JRN_CD = @i) GROUP BY dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Detail.TR_NO, dbo.Detail.TR_DT, dbo.Tbl_Accounting_Guid.Account_NO HAVING(dbo.Detail.TR_DT BETWEEN @P AND @P1) ORDER BY RNumber ");
                    com.Parameters.Add("@P", SqlDbType.Date).Value = Convert.ToDateTime(radDateTimePicker1.Value).ToShortDateString();
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = Convert.ToDateTime(radDateTimePicker2.Value).ToShortDateString();
                    com.Parameters.Add("@i", SqlDbType.NVarChar).Value = Vint_MenuPr;
                    //com.Parameters.Add("@F", SqlDbType.NVarChar).Value = comboBox3.SelectedValue; ;
                    //SqlDataAdapter da = new SqlDataAdapter(com);
                    
                   
                    con.Open();
                    red = com.ExecuteReader();
                    if (red.HasRows)
                    {
                        while (red.Read())
                        {
                            dataGridView3.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5));
                        }

                    }



                    red.Close();
                   con.Close();
                }
            }
          
        }
        private void GetFsData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            SqlDataReader red;
            int Vint_TreelistCount = treeList1.Nodes.Count();
            List<TreeListNode> nodes = treeList1.GetNodeList();
            com.CommandTimeout = 60;
            foreach (TreeListNode item in nodes)
            {
                if (item.CheckState == CheckState.Checked)
                {

                    int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
                    string VStr_MenuPr = item.GetValue("Name").ToString();
                    com.Parameters.Clear();
                    com.CommandText = ("SELECT        dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند],  dbo.Tbl_Accounting_Guid.Account_NO AS[رقم الحساب], SUM(CONVERT(decimal, dbo.Tbl_AccountingRestrictionItems.Debit_Value)) AS مدين, SUM(CONVERT(decimal, dbo.Tbl_AccountingRestrictionItems.Credit_Value)) AS دائن FROM   dbo.Tbl_Accounting_Guid INNER JOIN dbo.Tbl_AccountingRestrictionItems INNER JOIN  dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID INNER JOIN dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID WHERE(dbo.Tbl_AccountingRestrictions_Kind.ID = @i) AND(dbo.Tbl_AccountingRestriction.FYear = @F) GROUP BY dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Tbl_AccountingRestriction.Restriction_NO, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_Accounting_Guid.Account_NO HAVING(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) ORDER BY[رقم المستند]");
                    com.Parameters.Add("@P", SqlDbType.Date).Value = Convert.ToDateTime(radDateTimePicker1.Value).ToShortDateString();
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = Convert.ToDateTime(radDateTimePicker2.Value).ToShortDateString();
                    com.Parameters.Add("@i", SqlDbType.NVarChar).Value = Vint_MenuPr;
                    com.Parameters.Add("@F", SqlDbType.NVarChar).Value = comboBox3.SelectedValue; ;
                    con.Open();
                    red = com.ExecuteReader();
                    if (red.HasRows)
                    {
                        while (red.Read())
                        {
                            dataGridView4.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5));
                        }

                    }
                    red.Close();
                    con.Close();
                }
            }
           
        }
        public void GetSearchDate()
        {

            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            SqlCommand com1 = new SqlCommand();
            com1.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandText = "delete from Tbl_Advac_Deference";
            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            //ultraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            int Vint_TreelistCount = treeList1.Nodes.Count();
            List<TreeListNode> nodes = treeList1.GetNodeList();
            com.CommandTimeout = 60;

            foreach (TreeListNode item in nodes)
            {
                if (item.CheckState == CheckState.Checked)
                {

                    int Vint_MenuPr = int.Parse(item.GetValue("ID").ToString());
                    string VStr_MenuPr = item.GetValue("Name").ToString();
                    com.Parameters.Clear();
                    com.CommandText = ("Insert Into dbo.Tbl_Advac_Deference (NameofDay,Restriction_NO,Restriction_Date,ACC_NO,DB_VL,CR_VL,Debit_Value,Credit_Value,DDebit_Value,DCredit_Value,ADef )SELECT        dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, dbo.Tbl_AccountingRestriction.Restriction_NO, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_Accounting_Guid.Account_NO,  SUM(DISTINCT dbo.Detail.DB_VL) AS[مدين أدفاك], SUM(DISTINCT dbo.Detail.CR_VL) AS[دائن أدفاك], SUM(DISTINCT dbo.Tbl_AccountingRestrictionItems.Debit_Value) AS Expr1,  SUM(DISTINCT dbo.Tbl_AccountingRestrictionItems.Credit_Value) AS Expr2, SUM(dbo.Detail.DB_VL) - SUM(dbo.Tbl_AccountingRestrictionItems.Debit_Value) AS DF, SUM(dbo.Detail.CR_VL)  - SUM(dbo.Tbl_AccountingRestrictionItems.Credit_Value) AS CF, SUM(ISNULL(CAST(dbo.Detail.ACC_NO AS float), 0)) - SUM(ISNULL(CAST(dbo.Tbl_Accounting_Guid.Account_NO AS float), 0)) AS dd FROM            dbo.Tbl_Accounting_Guid INNER JOIN dbo.Tbl_AccountingRestrictionItems INNER JOIN dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID INNER JOIN dbo.Tbl_AccountingRestrictions_Kind ON dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Tbl_AccountingRestrictions_Kind.ID ON dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID FULL OUTER JOIN dbo.Detail ON dbo.Tbl_Accounting_Guid.Advac_AccountingNO = dbo.Detail.ACC_NO COLLATE Arabic_100_CI_AS_KS AND dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID = dbo.Detail.JRN_CD AND   dbo.Tbl_AccountingRestriction.Restriction_NO = dbo.Detail.TR_NO AND dbo.Tbl_AccountingRestriction.Restriction_Date = dbo.Detail.TR_DT GROUP BY dbo.Detail.JRN_CD, dbo.Detail.TR_DT, dbo.Detail.TR_NO, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestriction.Restriction_NO, dbo.Tbl_AccountingRestriction.Restriction_Date, dbo.Tbl_Accounting_Guid.Account_NO,  dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_AccountingRestrictions_Kind.ID,dbo.Tbl_AccountingRestriction.FYear  HAVING(dbo.Tbl_AccountingRestriction.Restriction_Date BETWEEN @P AND @P1) AND(dbo.Tbl_AccountingRestrictions_Kind.ID = @i) AND (dbo.Tbl_AccountingRestriction.FYear=@F)ORDER BY dbo.Tbl_AccountingRestriction.Restriction_NO,dbo.Tbl_AccountingRestrictions_Kind.Name");
                    com.Parameters.Add("@P", SqlDbType.Date).Value = Convert.ToDateTime(radDateTimePicker1.Value).ToShortDateString();
                    com.Parameters.Add("@P1", SqlDbType.Date).Value = Convert.ToDateTime(radDateTimePicker2.Value).ToShortDateString();
                    com.Parameters.Add("@i", SqlDbType.NVarChar).Value = Vint_MenuPr;
                    com.Parameters.Add("@F", SqlDbType.NVarChar).Value = comboBox3.SelectedValue; ;

                    con.Open();

                    com.ExecuteNonQuery();
                    //da.SelectCommand = com;
                    //com.ExecuteScalar();


                    //da.Fill(dt);
                    //com.ExecuteScalar();
                    con.Close();
                }
            }
            }
        private void AdvacDerFRMcs_Load(object sender, EventArgs e)
        {
            this.tbl_FiscalyearTableAdapter1.FillByYear(this.dataSet1.Tbl_Fiscalyear);
            // TODO: This line of code loads data into the 'dataSet1.Tbl_Advac_Deference' table. You can move, or remove it, as needed.
            //this.tbl_Advac_DeferenceTableAdapter.Fill(this.dataSet1.Tbl_Advac_Deference);
            //this.tbl_AccountingRestrictions_KindTableAdapter.Fill(this.dataSet1.Tbl_AccountingRestrictions_Kind);
            this.tbl_AccountingRestrictions_KindTableAdapter.FillByKind(this.dataSet1.Tbl_AccountingRestrictions_Kind);

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            GetSearchDate();
            this.tbl_Advac_DeferenceTableAdapter.Fill(this.dataSet1.Tbl_Advac_Deference);
        }
        private void check()
        {
            //try
            //{
            string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            sqlConn.Open();
            string sqlQuery = "Delete  From Detail";
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
           
            //}
            //catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            check();
            string accessConnStr = ConfigurationManager.ConnectionStrings["ACC.Properties.Settings.GLdataConnectionString"].ConnectionString.ToString();
            string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            OleDbConnection accessConn = new OleDbConnection(accessConnStr);
            SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            string accessQuery = "SELECT gljrnld.JRN_CD, gljrnld.TR_NO, gljrnld.LN_NO,glmf.ACC_NO, gljrnld.TR_DS, gljrnld.DB_VL, gljrnld.CR_VL, gljrnlh.TR_DT, glmf.ACC_NM_Ar, glmf.ACC_TY, glmf.MANACC FROM ((gljrnld INNER JOIN gljrnlh ON gljrnld.TR_NO = gljrnlh.TR_NO AND gljrnld.JRN_CD = gljrnlh.JRN_CD)  INNER JOIN glmf ON gljrnld.ACC_NO =glmf.ACC_NO) ";

            OleDbCommand accessCmd = new OleDbCommand(accessQuery, accessConn);
            accessConn.Open();
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand(accessQuery, accessConn);
            sqlConn.Open();
            dataTable.TableName = "Detail";
            adapter.Fill(dataTable);
            dataGridView2.Invoke((Action)delegate
            {
                dataGridView2.DataSource = dataTable;
                dataGridView2.Columns[0].HeaderText = "رقم اليومية";
                dataGridView2.Columns[1].HeaderText = "رقم المستند";
                dataGridView2.Columns[2].HeaderText = "رقم السطر";
                dataGridView2.Columns[3].HeaderText = "رقم الحساب";
                dataGridView2.Columns[4].HeaderText = "البيان";
                dataGridView2.Columns[5].HeaderText = "مدين";
                dataGridView2.Columns[6].HeaderText = "دائن";
                dataGridView2.Columns[7].HeaderText = "التاريخ";
                
            });
            using (var bulkInsert = new SqlBulkCopy(sqlConnStr))
            {
                bulkInsert.DestinationTableName = dataTable.TableName;

                bulkInsert.WriteToServer(dataTable);

                sqlConn.Close();
                bulkInsert.Close();
            }


            accessConn.Close();
            sqlConn.Close();
           
            GetAdvacData();
            GetFsData();
           

           

        }
        private DataTable GetDifferentRecords(DataTable dt1, DataTable dt2)
        {
            DataTable dt3 = new DataTable();

            // Copy structure of dt1 to dt3
            foreach (DataColumn column in dt1.Columns)
            {
                dt3.Columns.Add(column.ColumnName, column.DataType);
            }

            // Find different rows and add them to dt3
            foreach (DataRow row1 in dt1.Rows)
            {
                bool found = false;
                foreach (DataRow row2 in dt2.Rows)
                {
                    if (DataRowEquals(row1, row2))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    dt3.ImportRow(row1);
                }
            }

            return dt3;
        }

        private bool DataRowEquals(DataRow row1, DataRow row2)
        {
            for (int i = 0; i < row1.ItemArray.Length; i++)
            {
                if (!row1.ItemArray[i].Equals(row2.ItemArray[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static bool DataRowMatches(DataRow row1, DataRow row2)
        {
            for (int i = 0; i < row1.ItemArray.Length; i++)
            {
                if (!row1[i].Equals(row2[i]))
                {
                    return false;
                }
            }
            return true;
        }
    

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            button2_Click_1(sender, e);

        }

        private void radDateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                radDateTimePicker2.Focus();
            }
        }

        private void radDateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void radDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void SumAndGroupData()
        {
           
         
        }
        
        private bool FindMatchInGrid(DataGridView grid, string id1, string id, string name, string account, decimal debit, decimal credit)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                string id1Compare = row.Cells[0].Value?.ToString();
                string idCompare = row.Cells[1].Value?.ToString();
                string nameCompare = row.Cells[2].Value?.ToString();
                string accountCompare = row.Cells[3].Value?.ToString();
                decimal debitCompare = Convert.ToDecimal(row.Cells[4].Value?.ToString());
                decimal creditCompare = Convert.ToDecimal(row.Cells[5].Value?.ToString());

                if (id1 == id1Compare && id == idCompare && name == nameCompare && account == accountCompare && debit == debitCompare && credit == creditCompare)
                {
                    return true; // Match found
                }
            }
            return false; // No match found
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            
            for (int currentRow = 0; currentRow < dataGridView3.Rows.Count; currentRow++)
            {
                string id1 = dataGridView3.Rows[currentRow].Cells[0].Value?.ToString();
                string id = dataGridView3.Rows[currentRow].Cells[1].Value?.ToString();
                string name = dataGridView3.Rows[currentRow].Cells[2].Value?.ToString();
               
                string account = dataGridView3.Rows[currentRow].Cells[3].Value?.ToString();
                decimal debit = Convert.ToDecimal(dataGridView3.Rows[currentRow].Cells[4].Value?.ToString());
                decimal credit = Convert.ToDecimal(dataGridView3.Rows[currentRow].Cells[5].Value?.ToString());
                bool foundMatch = false;

                for (int row = 0; row < dataGridView4.Rows.Count; row++)
                {
                    

                    string idCompare1 = dataGridView4.Rows[row].Cells[0].Value?.ToString();
                    string idCompare = dataGridView4.Rows[row].Cells[1].Value?.ToString();
                    string nameCompare = dataGridView4.Rows[row].Cells[2].Value?.ToString();

                    string accountCompare = dataGridView4.Rows[row].Cells[3].Value?.ToString();
                    decimal debitCompare = Convert.ToDecimal(dataGridView4.Rows[row].Cells[4].Value?.ToString());
                    decimal creditCompare = Convert.ToDecimal(dataGridView4.Rows[row].Cells[5].Value?.ToString());

                    if (id1 == idCompare1 && id == idCompare && name == nameCompare && account== accountCompare && debit== debitCompare && credit== creditCompare)
                    {
                        foundMatch = true;
                        break;
                    }
                }

                if (!foundMatch)
                {
                    // Add the row to dataGridView1 since it doesn't have a matching row in dataGridView4
                    dataGridView1.Rows.Add(dataGridView3.Rows[currentRow].Cells[0].Value?.ToString(),
                                           dataGridView3.Rows[currentRow].Cells[1].Value?.ToString(),
                                           dataGridView3.Rows[currentRow].Cells[2].Value?.ToString(),
                                           dataGridView3.Rows[currentRow].Cells[3].Value?.ToString(),
                                           dataGridView3.Rows[currentRow].Cells[4].Value?.ToString(),
                                           dataGridView3.Rows[currentRow].Cells[5].Value?.ToString());
                }
            }

            for (int currentRow = 0; currentRow < dataGridView4.Rows.Count; currentRow++)
            {
                string id1 = dataGridView4.Rows[currentRow].Cells[0].Value?.ToString();
                string id = dataGridView4.Rows[currentRow].Cells[1].Value?.ToString();
                string name = dataGridView4.Rows[currentRow].Cells[2].Value?.ToString();

                string account = dataGridView4.Rows[currentRow].Cells[3].Value?.ToString();
                decimal debit = Convert.ToDecimal(dataGridView4.Rows[currentRow].Cells[4].Value?.ToString());
                decimal credit = Convert.ToDecimal(dataGridView4.Rows[currentRow].Cells[5].Value?.ToString());

                bool foundMatch = false;

                for (int row = 0; row < dataGridView3.Rows.Count; row++)
                {
                    string idCompare1 = dataGridView3.Rows[row].Cells[0].Value?.ToString();
                    string idCompare = dataGridView3.Rows[row].Cells[1].Value?.ToString();
                    string nameCompare = dataGridView3.Rows[row].Cells[2].Value?.ToString();

                    string accountCompare = dataGridView3.Rows[row].Cells[3].Value?.ToString();
                    decimal debitCompare = Convert.ToDecimal(dataGridView3.Rows[row].Cells[4].Value?.ToString());
                    decimal creditCompare = Convert.ToDecimal(dataGridView3.Rows[row].Cells[5].Value?.ToString());

                    if (id1 == idCompare1 && id == idCompare && name == nameCompare && account == accountCompare && debit == debitCompare && credit == creditCompare)
                    {
                        foundMatch = true;
                        break;
                    }
                }

                if (!foundMatch)
                {
                    // Add the row to dataGridView1 since it doesn't have a matching row in dataGridView4
                    dataGridView1.Rows.Add(dataGridView4.Rows[currentRow].Cells[0].Value?.ToString(),
                                           dataGridView4.Rows[currentRow].Cells[1].Value?.ToString(),
                                           dataGridView4.Rows[currentRow].Cells[2].Value?.ToString(),
                                           dataGridView4.Rows[currentRow].Cells[3].Value?.ToString(),
                                           dataGridView4.Rows[currentRow].Cells[4].Value?.ToString(),
                                           dataGridView4.Rows[currentRow].Cells[5].Value?.ToString());
                }
            }
            try
            {
                textBox11.Text = (from DataGridViewRow row in this.dataGridView1.Rows
                                  where row.Cells[0].Value.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[1].Value)).Distinct().Count().ToString();
            }
            catch { }
        }
        private void PopulateDistinctRowsFromDataGridView(DataGridView sourceGrid, DataGridView compareGrid)
        {
            // Store unique values from compareGrid for faster lookup
            HashSet<string> compareIds = new HashSet<string>();
            HashSet<string> compareNames = new HashSet<string>();
            HashSet<string> compareAccounts = new HashSet<string>();
            HashSet<decimal> compareDebit= new HashSet<decimal>();
            HashSet<decimal> compareCridet = new HashSet<decimal>();
            foreach (DataGridViewRow row in compareGrid.Rows)
            {
                string id = row.Cells[1].Value?.ToString();
                string name = row.Cells[2].Value?.ToString();
                string account = row.Cells[3].Value?.ToString();
                decimal Debit =Convert.ToDecimal( row.Cells[4].Value?.ToString());
                decimal Cridet = Convert.ToDecimal(row.Cells[5].Value?.ToString());
                // Add to HashSet for faster lookup
                compareIds.Add(id);
                compareNames.Add(name);
                compareAccounts.Add(account);
                compareDebit.Add(Debit);
                compareCridet.Add(Cridet);
            }

            for (int currentRow = 0; currentRow < sourceGrid.Rows.Count; currentRow++)
            {
                string id = sourceGrid.Rows[currentRow].Cells[1].Value?.ToString();
                string name = sourceGrid.Rows[currentRow].Cells[2].Value?.ToString();
                string account = sourceGrid.Rows[currentRow].Cells[3].Value?.ToString();
                decimal Debit = Convert.ToDecimal(sourceGrid.Rows[currentRow].Cells[4].Value?.ToString());
                decimal Cridet = Convert.ToDecimal(sourceGrid.Rows[currentRow].Cells[5].Value?.ToString());

                // Check if the row is found in compareGrid
                if (!compareIds.Contains(id) || !compareNames.Contains(name) || !compareAccounts.Contains(account) || !compareDebit.Contains(Debit) || !compareCridet.Contains(Cridet))
                {
                    dataGridView1.Rows.Add(
                        sourceGrid.Rows[currentRow].Cells[0].Value?.ToString(),
                        id,
                        name,
                        account,
                        Debit,
                        Cridet);
                }
            }
        }
        private void GroupDataInDataGridView()
        {
            // Filter out rows with null values in any of the grouped columns
            var groupedData = from DataGridViewRow row in dataGridView1.Rows
                              let column1 = row.Cells[0].Value?.ToString()
                              let column2 = row.Cells[1].Value?.ToString()
                              let column3 = row.Cells[2].Value?.ToString()
                              let column4 = row.Cells[3].Value?.ToString()
                              let column5 = row.Cells[4].Value?.ToString()
                              let column6 = row.Cells[5].Value?.ToString()
                              where !string.IsNullOrEmpty(column1) && !string.IsNullOrEmpty(column2) && !string.IsNullOrEmpty(column3) && !string.IsNullOrEmpty(column4) && !string.IsNullOrEmpty(column5) && !string.IsNullOrEmpty(column6)
                              group row by new { Column1 = column1, Column2 = column2, Column3 = column3, Column4 = column4, Column5 = column5, Column6 = column6 } into grp
                              select new { Category = grp.Key, Items = grp.ToList() };

            // Temporarily suspend the DataGridView's layout to improve performance during bulk updates
            dataGridView1.SuspendLayout();

            // Clear existing rows in dataGridView1
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;

            // Populate dataGridView1 with grouped data
            foreach (var group in groupedData)
            {
                // Add a row to represent the group
                dataGridView1.Rows.Add(group.Category.Column1, group.Category.Column2, group.Category.Column3, group.Category.Column4, group.Category.Column5, group.Category.Column6); // Adjust columns as needed

                // Add rows for items within the group
                foreach (var item in group.Items)
                {
                    // Add row for each item
                    dataGridView1.Rows.Add(item.Cells[0].Value, item.Cells[1].Value, item.Cells[2].Value, item.Cells[3].Value, item.Cells[4].Value, item.Cells[5].Value); // Adjust columns
                }
            }

            // Resume the layout and force the DataGridView to repaint itself
            dataGridView1.ResumeLayout();
            dataGridView1.Refresh();

            dataGridView1.AllowUserToAddRows = false;
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}