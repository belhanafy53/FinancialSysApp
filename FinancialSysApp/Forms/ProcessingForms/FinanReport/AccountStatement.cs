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
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.ProcessingForms.FinanReport
{
    public partial class AccountStatement : DevExpress.XtraEditors.XtraForm
    {
        public AccountStatement()
        {
            InitializeComponent();
        }
        private void RetrieveDataBetweenDates(DateTime startDate, DateTime endDate, int Fyear, int RestrictionKind, DataTable dataTable)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                string query = @"SELECT A.Account_NO AS [Account_NO] , 
                               A.Name AS [Name],
                               ISNULL(SUM(CASE WHEN VB.Debit_Value IS NOT NULL THEN VB.Debit_Value ELSE 0 END), 0) AS TotalDebitCash,
                               ISNULL(SUM(CASE WHEN VB.Credit_Value IS NOT NULL THEN VB.Credit_Value ELSE 0 END), 0) AS TotalCredit,VB.Restriction_Date
                        FROM dbo.Tbl_Accounting_Guid AS A
                        Inner JOIN dbo.Vie_Balance AS VB ON VB.Account_NO = A.Account_NO 
                                                       AND VB.FYear = @Fyear
                                                       
                                                       AND VB.Restriction_Date Between @StartDate And  @EndDate

                                                       AND VB.AccountingRestrictionKind_ID = @RestrictionKind
                        GROUP BY A.Account_NO, A.Name,VB.Restriction_Date,A.AccountsKind_ID
HAVING        (A.AccountsKind_ID = 2) And (VB.Restriction_Date IS NOT NULL) 
                        ORDER BY A.Account_NO ASC";

                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                    com.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                    com.Parameters.Add("@Fyear", SqlDbType.Int).Value = Fyear;
                    com.Parameters.Add("@RestrictionKind", SqlDbType.Int).Value = RestrictionKind;
                   
                    con.Open();

                    SqlDataReader reader = com.ExecuteReader();

                    // Add retrieved data to the DataTable
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                    }

                    reader.Close();
                    con.Close();
                }
            }
        }

        
        class MyDataModel
        {
            public string Account_NO { get; set; }
            public string Name { get; set; }
            public string TotalDebitCash { get; set; }
            public string TotalCredit { get; set; }
            public string Total { get; set; }
        }
        private void AccountStatement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Accounting_Guid' table. You can move, or remove it, as needed.
            this.tbl_Accounting_GuidTableAdapter1.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);
            this.tbl_AccountingRestrictions_KindTableAdapter.FillByKind(this.dataSet1.Tbl_AccountingRestrictions_Kind);

            this.tbl_FiscalyearTableAdapter.FillByYear(this.dataSet1.Tbl_Fiscalyear);
            this.reportViewer1.RefreshReport();
        }
        private DataTable GetDataBetweenDatesAndGroupFilterReport(List<int> checkedIDs, DateTime startDate, DateTime endDate, int Fyear)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Account_NO", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            dataTable.Columns.Add("TotalCredit", typeof(decimal));
            dataTable.Columns.Add("Restriction_Date", typeof(DateTime));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDates(startDate, endDate, Fyear, checkedID, dataTable);
            }

            // Filter data before grouping
            var filteredRows = dataTable.AsEnumerable()
                .Where(row => {
                    string accountNumber = row.Field<string>("Account_NO");
            // Check if the account number matches the pattern
            return accountNumber.StartsWith(textBox3.Text) ;
                });

            // Create a new DataTable to store the filtered data
            DataTable filteredDataTable = dataTable.Clone(); // Clone the structure of the original table
            foreach (var row in filteredRows)
            {
                filteredDataTable.ImportRow(row);
            }

            // Group data in the DataTable
            var groupedData = filteredDataTable.AsEnumerable()
    .GroupBy(row => new {
        AccountNumber = row.Field<string>("Account_NO"),
        AccountName = row.Field<string>("Name")
    })
    .Select(group => new {
        AccountNumber = group.Key.AccountNumber,
        AccountName = group.Key.AccountName,
        TotalDebit = group.Sum(row => row.Field<decimal>("TotalDebitCash")),
        TotalCredit = group.Sum(row => row.Field<decimal>("TotalCredit")),
        Balance = group.Sum(row => row.Field<decimal>("TotalDebitCash")) - group.Sum(row => row.Field<decimal>("TotalCredit")),
        RestrictionDate = group.First().Field<DateTime?>("Restriction_Date") // Using nullable DateTime
    });

            // Populate grouped data into a new DataTable
            DataTable groupedDataTable = new DataTable();
            groupedDataTable.Columns.Add("Account_NO", typeof(string));
            groupedDataTable.Columns.Add("Name", typeof(string));
            groupedDataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            groupedDataTable.Columns.Add("TotalCredit", typeof(decimal));
           
            groupedDataTable.Columns.Add("Restriction_Date", typeof(DateTime));
            foreach (var group in groupedData)
            {
                if (group.TotalCredit != 0 || group.TotalDebit != 0) // To View Only Have Value > 0 
                {
                    groupedDataTable.Rows.Add(group.AccountNumber, group.AccountName, group.TotalDebit, group.TotalCredit,  group.RestrictionDate);
                }
            }

            return groupedDataTable;
        }
        private void ultraButton1_Click(object sender, EventArgs e)
        {

            List<int> checkedIDs = new List<int>();
            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr;
                    if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                    {
                        checkedIDs.Add(Vint_MenuPr);
                    }
                }
            }

            DateTime startDate = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            int Fyear = Convert.ToInt32(comboBox9.SelectedValue);
            string  Acc = textBox3.Text ;
            DataTable groupedDataTableReport = GetDataBetweenDatesAndGroupFilterReport(checkedIDs, startDate, endDate, Fyear);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", groupedDataTableReport)); // Set your data set name


            // Refresh the report viewer
            //ReportParameter[] parameters = new ReportParameter[6];
            //parameters[0] = new ReportParameter("d", startDate.ToString());
            //parameters[1] = new ReportParameter("d1", endDate.ToString());
            //parameters[2] = new ReportParameter("ReportParameter1", textBox3.Text.ToString());
            //parameters[3] = new ReportParameter("ReportParameter2", labelControl1.Text.ToString());
            //parameters[4] = new ReportParameter("Managament", Program.GlbV_Management);
            //parameters[5] = new ReportParameter("Usr", Program.GlbV_EmpName);
            //this.reportViewer1.LocalReport.SetParameters(parameters);

            //this.reportViewer1.RefreshReport();

            List<string> selectedItems = new List<string>();

            // Iterate through selected nodes and extract their text values
            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    string name = node.GetValue("Name") as string;
                    if (!string.IsNullOrEmpty(name))
                    {
                        selectedItems.Add(name);
                    }
                }
            }

            // Construct an array of ReportParameter objects
            ReportParameter[] parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("d", startDate.ToString());
            parameters[1] = new ReportParameter("d1", endDate.ToString());
            parameters[2] = new ReportParameter("ReportParameter1", textBox3.Text);
            parameters[3] = new ReportParameter("ReportParameter2", labelControl1.Text);
            parameters[4] = new ReportParameter("Managament", Program.GlbV_Management);
            parameters[5] = new ReportParameter("Usr", Program.GlbV_EmpName);
            // Convert the list of selected items to a single string separated by commas
            string selectedItemsString = string.Join("/ ", selectedItems);
            parameters[6] = new ReportParameter("SelectedItems", selectedItemsString);

            // Set report parameters
            this.reportViewer1.LocalReport.SetParameters(parameters);

            // Refresh the report viewer
            this.reportViewer1.RefreshReport();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            labelControl1.Text = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                string query = @"SELECT Name From Tbl_Accounting_Guid where Account_NO = @Account_NO";
                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@Account_NO", SqlDbType.NVarChar ).Value = textBox3.Text ;
                    

                    con.Open();

                    SqlDataReader reader = com.ExecuteReader();

                    // Add retrieved data to the DataTable
                    while (reader.Read())
                    {
                        
                            
                            labelControl1.Text = reader.GetValue(0).ToString();
                        
                        
                    }

                    reader.Close();
                    con.Close();
                }
            }

        
        }
    }
}
