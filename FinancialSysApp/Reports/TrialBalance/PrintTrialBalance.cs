using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Reports.TrialBalance
{
    public partial class PrintTrialBalance : Form
    {
       public  int x;
        private List<int> checkedIDs1;
        public PrintTrialBalance(List<int> selectedNodes)
        {
            InitializeComponent();
            checkedIDs1 = new List<int>();
            foreach (int nodeId in selectedNodes)
            {
                checkedIDs1.Add(nodeId);
            }
        }
        private void RetrieveDataBetweenDates(DateTime startDate, DateTime endDate, int Fyear, int RestrictionKind, DataTable dataTable)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                string query = @"SELECT A.Account_NO, 
                               A.Name,
                               ISNULL(SUM(CASE WHEN VB.Debit_Value IS NOT NULL THEN VB.Debit_Value ELSE 0 END), 0) AS TotalDebitCash,
                               ISNULL(SUM(CASE WHEN VB.Credit_Value IS NOT NULL THEN VB.Credit_Value ELSE 0 END), 0) AS TotalCredit
                        FROM dbo.Tbl_Accounting_Guid AS A
                        LEFT JOIN dbo.Vie_Balance AS VB ON VB.Account_NO LIKE A.Account_NO + '%'
                                                       AND VB.FYear = @Fyear
                                                       
                                                       AND VB.Restriction_Date Between @StartDate And  @EndDate

                                                       AND VB.AccountingRestrictionKind_ID = @RestrictionKind
                        GROUP BY A.Account_NO, A.Name
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
                        dataTable.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
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

        private DataTable GetDataBetweenDatesAndGroup(List<int> checkedIDs, DateTime startDate, DateTime endDate, int Fyear)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("رقم الحساب", typeof(string));
            dataTable.Columns.Add("اسم الحساب", typeof(string));
            dataTable.Columns.Add("مدين", typeof(decimal));
            dataTable.Columns.Add("دائن", typeof(decimal));
            dataTable.Columns.Add("الرصيد", typeof(decimal));

            foreach (int checkedID in checkedIDs1)
            {
                RetrieveDataBetweenDates(startDate, endDate, Fyear, checkedID, dataTable);
            }

            // Group data in the DataTable
            var groupedData = dataTable.AsEnumerable()
                .GroupBy(row => new {
                    AccountNumber = row.Field<string>("رقم الحساب"),
                    AccountName = row.Field<string>("اسم الحساب")
                })
                .Select(group => new {
                    AccountNumber = group.Key.AccountNumber,
                    AccountName = group.Key.AccountName,
                    TotalDebit = group.Sum(row => row.Field<decimal>("مدين")),
                    TotalCredit = group.Sum(row => row.Field<decimal>("دائن")),
                    Balance = group.Sum(row => row.Field<decimal>("مدين")) - group.Sum(row => row.Field<decimal>("دائن"))
                });

            // Populate grouped data into a new DataTable
            DataTable groupedDataTable = new DataTable();
            groupedDataTable.Columns.Add("رقم الحساب", typeof(string));
            groupedDataTable.Columns.Add("اسم الحساب", typeof(string));
            groupedDataTable.Columns.Add("مجموع المدين", typeof(decimal));
            groupedDataTable.Columns.Add("مجموع الدائن", typeof(decimal));
            groupedDataTable.Columns.Add("الرصيد", typeof(decimal));

            foreach (var group in groupedData)
            {
                if (group.TotalCredit != 0 || group.TotalDebit != 0) // To View Only Have Value > 0 
                {
                    groupedDataTable.Rows.Add(group.AccountNumber, group.AccountName, group.TotalDebit, group.TotalCredit, group.Balance);
                }
            }

            return groupedDataTable;
        }
        //public List<int> checkedIDs = new List<int>()
        //{


        //};
        private void PrintTrialBalance_Load(object sender, EventArgs e)
        {
            List<int> checkedIDs = new List<int>();
            checkedIDs.AddRange(checkedIDs1);
            DateTime startDate = Convert.ToDateTime(textBox1.Text);
            DateTime endDate = Convert.ToDateTime(textBox1.Text);
            int Fyear = x;

            DataTable groupedDataTable = GetDataBetweenDatesAndGroup(checkedIDs, startDate, endDate, Fyear);
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", groupedDataTable);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("d", textBox1.Text);
            parameters[1] = new ReportParameter("d1", textBox2.Text);
            //parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
            //parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
            //parameters[4] = new ReportParameter("man", Program.GlbV_Management);
            //parameters[5] = new ReportParameter("Title", "تقرير موقف التوريد");
            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();
            //*****************
            //*****************
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
