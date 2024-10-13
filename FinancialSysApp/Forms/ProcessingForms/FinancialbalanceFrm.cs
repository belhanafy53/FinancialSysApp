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
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FinancialbalanceFrm : DevExpress.XtraEditors.XtraForm
    {
        public FinancialbalanceFrm()
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
                               ISNULL(SUM(CASE WHEN VB.Credit_Value IS NOT NULL THEN VB.Credit_Value ELSE 0 END), 0) AS TotalCredit,AccountsKind_ID
                        FROM dbo.Tbl_Accounting_Guid AS A
                        LEFT JOIN dbo.Vie_Balance AS VB ON VB.Account_NO LIKE A.Account_NO + '%'
                                                       AND VB.FYear = @Fyear
                                                       
                                                       AND VB.Restriction_Date Between @StartDate And  @EndDate

                                                       AND VB.AccountingRestrictionKind_ID = @RestrictionKind
                        GROUP BY A.Account_NO, A.Name,AccountsKind_ID
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
       
        private void FinancialbalanceFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'trialBalancePrint.Tbl_Accounting_Guid' table. You can move, or remove it, as needed.
            //this.tbl_Accounting_GuidTableAdapter.Fill(this.trialBalancePrint.Tbl_Accounting_Guid);
            this.tbl_AccountingRestrictions_KindTableAdapter.FillByKind(this.dataSet1.Tbl_AccountingRestrictions_Kind);

            this.tbl_FiscalyearTableAdapter.FillByYear(this.dataSet1.Tbl_Fiscalyear);
            this.reportViewer1.RefreshReport();
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
            dataTable.Columns.Add("Kind", typeof(int));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDates(startDate, endDate, Fyear, checkedID, dataTable);
            }

            // Group data in the DataTable
            var groupedData = dataTable.AsEnumerable()
                .GroupBy(row => new {
                    AccountNumber = row.Field<string>("رقم الحساب"),
                    AccountName = row.Field<string>("اسم الحساب"),
                    Kind= row.Field<int>("Kind")
                })
                .Select(group => new {
                    AccountNumber = group.Key.AccountNumber,
                    AccountName = group.Key.AccountName,
                    TotalDebit = group.Sum(row => row.Field<decimal>("مدين")),
                    TotalCredit = group.Sum(row => row.Field<decimal>("دائن")),
                    Balance = group.Sum(row => row.Field<decimal>("مدين")) - group.Sum(row => row.Field<decimal>("دائن")),
                    Kind = group.Key.Kind 
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
        private DataTable GetDataBetweenDatesAndGroupFilter(List<int> checkedIDs, DateTime startDate, DateTime endDate, int Fyear)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("رقم الحساب", typeof(string));
            dataTable.Columns.Add("اسم الحساب", typeof(string));
            dataTable.Columns.Add("مدين", typeof(decimal));
            dataTable.Columns.Add("دائن", typeof(decimal));
            dataTable.Columns.Add("الرصيد", typeof(decimal));
            dataTable.Columns.Add("Kind", typeof(int));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDates(startDate, endDate, Fyear, checkedID, dataTable);
            }

            // Filter data before grouping
            var filteredRows = dataTable.AsEnumerable()
          .Where(row => {
              string accountNumber = row.Field<string>("رقم الحساب");
        // Check if the account number matches the pattern
        return accountNumber.StartsWith(textBox3.Text) || accountNumber.StartsWith(textBox4.Text);
          });

            // Create a new DataTable to store the filtered data
            DataTable filteredDataTable = dataTable.Clone(); // Clone the structure of the original table
            foreach (var row in filteredRows)
            {
                filteredDataTable.ImportRow(row);
            }

            // Create a new DataTable to store the filtered data


            // Group data in the DataTable
            var groupedData = filteredDataTable.AsEnumerable()
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
        private DataTable GetDataBetweenDatesAndGroupFilterReport(List<int> checkedIDs, DateTime startDate, DateTime endDate, int Fyear)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Account_NO", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            dataTable.Columns.Add("TotalCredit", typeof(decimal));
            dataTable.Columns.Add("Kind", typeof(int));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDates(startDate, endDate, Fyear, checkedID, dataTable);
            }

            // Filter data before grouping
            var filteredRows = dataTable.AsEnumerable()
          .Where(row => {
              string accountNumber = row.Field<string>("Account_NO");
              int? AccKind = row.Field<int?>("Kind");
              // Check if the account number matches the pattern Child Account
              return accountNumber.StartsWith(textBox3.Text) && AccKind == 1 || accountNumber.StartsWith(textBox4.Text) && AccKind == 1 || accountNumber.StartsWith(textBox3.Text) && AccKind == null || accountNumber.StartsWith(textBox4.Text) && AccKind == null;
          });

            // Create a new DataTable to store the filtered data
            DataTable filteredDataTable = dataTable.Clone(); // Clone the structure of the original table
            foreach (var row in filteredRows)
            {
                filteredDataTable.ImportRow(row);
            }

            // Create a new DataTable to store the filtered data


            // Group data in the DataTable
            var groupedData = filteredDataTable.AsEnumerable()
                .GroupBy(row => new {
                    AccountNumber = row.Field<string>("Account_NO"),
                    AccountName = row.Field<string>("Name"),
                    Kind = row.Field<int?>("Kind")
                })
                .Select(group => new {
                    AccountNumber = group.Key.AccountNumber,
                    AccountName = group.Key.AccountName,
                    TotalDebit = group.Sum(row => row.Field<decimal>("TotalDebitCash")),
                    TotalCredit = group.Sum(row => row.Field<decimal>("TotalCredit")),
                    Balance = group.Sum(row => row.Field<decimal>("TotalDebitCash")) - group.Sum(row => row.Field<decimal>("TotalCredit")),
                    Kind = group.Key.Kind
                });

            // Populate grouped data into a new DataTable
            DataTable groupedDataTable = new DataTable();
            groupedDataTable.Columns.Add("Account_NO", typeof(string));
            groupedDataTable.Columns.Add("Name", typeof(string));
            groupedDataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            groupedDataTable.Columns.Add("TotalCredit", typeof(decimal));

            foreach (var group in groupedData)
            {
                if (group.TotalCredit != 0 && group.Kind == 1 || group.TotalDebit != 0 && group.Kind == 1 || group.TotalCredit != 0 && group.Kind==null || group.TotalDebit != 0 && group.Kind == null) // To View Only Have Value > 0 
                {
                    groupedDataTable.Rows.Add(group.AccountNumber, group.AccountName, group.TotalDebit, group.TotalCredit);
                }
            }

            

            return groupedDataTable;
        }
        private DataTable GetDataBetweenDatesAndGroupFilterReportChildAccount(List<int> checkedIDs, DateTime startDate, DateTime endDate, int Fyear)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Account_NO", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            dataTable.Columns.Add("TotalCredit", typeof(decimal));
            dataTable.Columns.Add("Kind", typeof(int));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDates(startDate, endDate, Fyear, checkedID, dataTable);
            }

            // Filter data before grouping
            var filteredRows = dataTable.AsEnumerable()
          .Where(row => {
              string accountNumber = row.Field<string>("Account_NO");
              int? AccKind = row.Field<int?>("Kind");
              // Check if the account number matches the pattern Child Account
              return accountNumber.StartsWith(textBox3.Text) && AccKind==2 || accountNumber.StartsWith(textBox4.Text) && AccKind == 2;
          });

            // Create a new DataTable to store the filtered data
            DataTable filteredDataTable = dataTable.Clone(); // Clone the structure of the original table
            foreach (var row in filteredRows)
            {
                filteredDataTable.ImportRow(row);
            }

            // Create a new DataTable to store the filtered data


            // Group data in the DataTable
            var groupedData = filteredDataTable.AsEnumerable()
                .GroupBy(row => new {
                    AccountNumber = row.Field<string>("Account_NO"),
                    AccountName = row.Field<string>("Name"),
                    Kind = row.Field<int?>("Kind")
        })
                .Select(group => new {
                    AccountNumber = group.Key.AccountNumber,
                    AccountName = group.Key.AccountName,
                    TotalDebit = group.Sum(row => row.Field<decimal>("TotalDebitCash")),
                    TotalCredit = group.Sum(row => row.Field<decimal>("TotalCredit")),
                    Balance = group.Sum(row => row.Field<decimal>("TotalDebitCash")) - group.Sum(row => row.Field<decimal>("TotalCredit")),
                    Kind = group.Key.Kind 
                });

            // Populate grouped data into a new DataTable
            DataTable groupedDataTable = new DataTable();
            groupedDataTable.Columns.Add("Account_NO", typeof(string));
            groupedDataTable.Columns.Add("Name", typeof(string));
            groupedDataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            groupedDataTable.Columns.Add("TotalCredit", typeof(decimal));

            foreach (var group in groupedData)
            {
                if (group.TotalCredit != 0 && group.Kind == 2 || group.TotalDebit != 0 && group.Kind ==2 ) // To View Only Have Value > 0 
                {
                    groupedDataTable.Rows.Add(group.AccountNumber, group.AccountName, group.TotalDebit, group.TotalCredit);
                }
            }

            return groupedDataTable;
        }
        private DataTable GetDataBetweenDatesAndGroupReport(List<int> checkedIDs, DateTime startDate, DateTime endDate, int Fyear)
        {
            DataTable dataTable = new DataTable();
            
            dataTable.Columns.Add("Account_NO", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            dataTable.Columns.Add("TotalCredit", typeof(decimal));
            dataTable.Columns.Add("Kind", typeof(int));
            foreach (int checkedID in checkedIDs)
            {
                RetrieveDataBetweenDates(startDate, endDate, Fyear, checkedID, dataTable);
            }

            // Group data in the DataTable
            var groupedData = dataTable.AsEnumerable()
                .GroupBy(row => new {
                    AccountNumber = row.Field<string>("Account_NO"),
                    AccountName = row.Field<string>("Name")
                })
                .Select(group => new {
                    AccountNumber = group.Key.AccountNumber,
                    AccountName = group.Key.AccountName,
                    TotalDebit = group.Sum(row => row.Field<decimal>("TotalDebitCash")),
                    TotalCredit = group.Sum(row => row.Field<decimal>("TotalCredit")),
                    Balance = group.Sum(row => row.Field<decimal>("TotalDebitCash")) - group.Sum(row => row.Field<decimal>("TotalCredit"))
                });

            // Populate grouped data into a new DataTable
            DataTable groupedDataTable = new DataTable();
            groupedDataTable.Columns.Add("Account_NO", typeof(string));
            groupedDataTable.Columns.Add("Name", typeof(string));
            groupedDataTable.Columns.Add("TotalDebitCash", typeof(decimal));
            groupedDataTable.Columns.Add("TotalCredit", typeof(decimal));

            foreach (var group in groupedData)
            {
                if (group.TotalCredit != 0 || group.TotalDebit != 0) // To View Only Have Value > 0 
                {
                    groupedDataTable.Rows.Add(group.AccountNumber, group.AccountName, group.TotalDebit, group.TotalCredit);
                }
            }

            return groupedDataTable;
        }
        private void button1_Click(object sender, EventArgs e)
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

            //DataTable groupedDataTable = GetDataBetweenDatesAndGroup(checkedIDs, startDate, endDate, Fyear);
            DataTable groupedDataTableReport = GetDataBetweenDatesAndGroupReport(checkedIDs, startDate, endDate, Fyear);
            //dataGridView1.DataSource = groupedDataTable;
            
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", groupedDataTableReport)); // Set your data set name


            // Refresh the report viewer
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("d", startDate.ToString());
            parameters[1] = new ReportParameter("d1", endDate.ToString());
           
            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();





            dataGridView1.Columns["رقم الحساب"].Width = 140;
            dataGridView1.Columns["اسم الحساب"].Width = 350;
            dataGridView1.Columns["مجموع المدين"].Width = 140;
            dataGridView1.Columns["مجموع الدائن"].Width = 140;
            dataGridView1.Columns["الرصيد"].Width = 140;
            for (int x=0;x<dataGridView1.Rows.Count;x++)
            {
                if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "1" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "4")
                {
                    dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[2].Value) - Convert.ToDecimal(dataGridView1.Rows[x].Cells[3].Value);
                }

                if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "2" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "3" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "5")
                {
                    dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[3].Value) - Convert.ToDecimal(dataGridView1.Rows[x].Cells[2].Value);
                }
                //if (Convert.ToDecimal(dataGridView1.Rows[x].Cells[4].Value)<0) // To Keep All Value >0
                //{
                //   dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[4].Value) * -1;
                //}

            }
            t1.Text = (from DataGridViewRow row in dataGridView1.Rows
                            where row.Cells[0].Value.ToString().Equals("1")
                            select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            t2.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[0].Value.ToString().Equals("2")
                       select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            t3.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[0].Value.ToString().Equals("3")
                       select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();
            t4.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[0].Value.ToString().Equals("4")
                       select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();
            t5.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[0].Value.ToString().Equals("5")
                       select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            decimal D  = (Convert.ToDecimal(t1.Text) + Convert.ToDecimal(t4.Text)) - Convert.ToDecimal(t3.Text) - Convert.ToDecimal(t2.Text) - Convert.ToDecimal(t5.Text);
            textBox2.Text = Convert.ToString(D);
            if(Convert.ToDecimal(textBox2.Text)>0 || Convert.ToDecimal(textBox2.Text) < 0)
            {
                textBox2.BackColor = Color.Red;
                textBox2.ForeColor  = Color.White;
                labelControl2.Visible = true;
            }

            if (Convert.ToDecimal(textBox2.Text) == 0)
            {
                textBox2.BackColor = Color.White ;
                textBox2.ForeColor = Color.Black ;
                labelControl2.Visible = false ;
            }
            //DataTable chartData = GetDataBetweenDatesAndGroup(checkedIDs, startDate, endDate, Fyear);
            //DisplayDataInChart(chartData);
           

        }

        private void button2_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> selectedNodes = new List<int>();
            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr;
                    if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                    {
                        selectedNodes.Add(Vint_MenuPr);
                    }
                }
            }
            Reports.TrialBalance.PrintTrialBalance f = new Reports.TrialBalance.PrintTrialBalance(selectedNodes);
            f.textBox1.Text = dateTimePicker1.Value.ToShortDateString();
            f.textBox2.Text = dateTimePicker2.Value.ToShortDateString();
            f.x = Convert.ToInt32(comboBox9.SelectedValue);
           
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
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

                DataTable groupedDataTable = GetDataBetweenDatesAndGroupFilter(checkedIDs, startDate, endDate, Fyear);
                DataTable groupedDataTableReport = GetDataBetweenDatesAndGroupFilterReport(checkedIDs, startDate, endDate, Fyear);
                dataGridView1.DataSource = groupedDataTable;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", groupedDataTableReport)); // Set your data set name


                // Refresh the report viewer
                ReportParameter[] parameters = new ReportParameter[6];
                parameters[0] = new ReportParameter("d", startDate.ToString());
                parameters[1] = new ReportParameter("d1", endDate.ToString());
                parameters[2] = new ReportParameter("ReportParameter1", textBox3.Text);
                parameters[3] = new ReportParameter("ReportParameter2", textBox4.Text);
                parameters[4] = new ReportParameter("Managament", Program.GlbV_Management);
                parameters[5] = new ReportParameter("Usr", Program.GlbV_EmpName);
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.RefreshReport();





                dataGridView1.Columns["رقم الحساب"].Width = 140;
                dataGridView1.Columns["اسم الحساب"].Width = 350;
                dataGridView1.Columns["مجموع المدين"].Width = 140;
                dataGridView1.Columns["مجموع الدائن"].Width = 140;
                dataGridView1.Columns["الرصيد"].Width = 140;
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "1" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "4")
                    {
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[2].Value) - Convert.ToDecimal(dataGridView1.Rows[x].Cells[3].Value);
                    }

                    if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "2" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "3" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "5")
                    {
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[3].Value) - Convert.ToDecimal(dataGridView1.Rows[x].Cells[2].Value);
                    }
                    //if (Convert.ToDecimal(dataGridView1.Rows[x].Cells[4].Value)<0) // To Keep All Value >0
                    //{
                    //   dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[4].Value) * -1;
                    //}

                }
                t1.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("1")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                t2.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("2")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                t3.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("3")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();
                t4.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("4")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();
                t5.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("5")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                decimal D = (Convert.ToDecimal(t1.Text) + Convert.ToDecimal(t4.Text)) - Convert.ToDecimal(t3.Text) - Convert.ToDecimal(t2.Text) - Convert.ToDecimal(t5.Text);
                textBox2.Text = Convert.ToString(D);
                if (Convert.ToDecimal(textBox2.Text) > 0 || Convert.ToDecimal(textBox2.Text) < 0)
                {
                    textBox2.BackColor = Color.Red;
                    textBox2.ForeColor = Color.White;
                    labelControl2.Visible = true;
                }

                if (Convert.ToDecimal(textBox2.Text) == 0)
                {
                    textBox2.BackColor = Color.White;
                    textBox2.ForeColor = Color.Black;
                    labelControl2.Visible = false;
                }
            }
            if (checkBox2.Checked == true)
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

                DataTable groupedDataTable = GetDataBetweenDatesAndGroupFilter(checkedIDs, startDate, endDate, Fyear);
                DataTable groupedDataTableReport = GetDataBetweenDatesAndGroupFilterReportChildAccount(checkedIDs, startDate, endDate, Fyear);
                dataGridView1.DataSource = groupedDataTable;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", groupedDataTableReport)); // Set your data set name


                // Refresh the report viewer
                ReportParameter[] parameters = new ReportParameter[6];
                parameters[0] = new ReportParameter("d", startDate.ToString());
                parameters[1] = new ReportParameter("d1", endDate.ToString());
                parameters[2] = new ReportParameter("ReportParameter1", textBox3.Text );
                parameters[3] = new ReportParameter("ReportParameter2", textBox4.Text);
                parameters[4] = new ReportParameter("Managament", Program.GlbV_Management);
                parameters[5] = new ReportParameter("Usr", Program.GlbV_EmpName);
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.RefreshReport();





                dataGridView1.Columns["رقم الحساب"].Width = 140;
                dataGridView1.Columns["اسم الحساب"].Width = 350;
                dataGridView1.Columns["مجموع المدين"].Width = 140;
                dataGridView1.Columns["مجموع الدائن"].Width = 140;
                dataGridView1.Columns["الرصيد"].Width = 140;
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "1" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "4")
                    {
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[2].Value) - Convert.ToDecimal(dataGridView1.Rows[x].Cells[3].Value);
                    }

                    if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "2" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "3" || dataGridView1.Rows[x].Cells[0].Value.ToString() == "5")
                    {
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[3].Value) - Convert.ToDecimal(dataGridView1.Rows[x].Cells[2].Value);
                    }
                    //if (Convert.ToDecimal(dataGridView1.Rows[x].Cells[4].Value)<0) // To Keep All Value >0
                    //{
                    //   dataGridView1.Rows[x].Cells[4].Value = Convert.ToDecimal(dataGridView1.Rows[x].Cells[4].Value) * -1;
                    //}

                }
                t1.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("1")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                t2.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("2")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                t3.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("3")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();
                t4.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("4")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();
                t5.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[0].Value.ToString().Equals("5")
                           select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                decimal D = (Convert.ToDecimal(t1.Text) + Convert.ToDecimal(t4.Text)) - Convert.ToDecimal(t3.Text) - Convert.ToDecimal(t2.Text) - Convert.ToDecimal(t5.Text);
                textBox2.Text = Convert.ToString(D);
                if (Convert.ToDecimal(textBox2.Text) > 0 || Convert.ToDecimal(textBox2.Text) < 0)
                {
                    textBox2.BackColor = Color.Red;
                    textBox2.ForeColor = Color.White;
                    labelControl2.Visible = true;
                }

                if (Convert.ToDecimal(textBox2.Text) == 0)
                {
                    textBox2.BackColor = Color.White;
                    textBox2.ForeColor = Color.Black;
                    labelControl2.Visible = false;
                }
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void t4_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            Forms.ProcessingForms.FinanReport.AccountStatement f = new FinanReport.AccountStatement();
            f.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true )
            {
                checkBox2.Checked = false;
            }
        }
    }
    
   
}
