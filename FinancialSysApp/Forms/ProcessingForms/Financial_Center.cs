using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Financial_Center : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataSet DBDataSet = new DataSet();
        DateTime DateTO = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        public Financial_Center()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Reports.CachedFinancial_Center r = new Reports.CachedFinancial_Center();
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.RefreshReport();
            crystalReportViewer1.Refresh();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Reports.CachedFinancial_Center2 r = new Reports.CachedFinancial_Center2();
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.RefreshReport();
            crystalReportViewer1.Refresh();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Reports.CachedFinancial_Center3 r = new Reports.CachedFinancial_Center3();
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.RefreshReport();
            crystalReportViewer1.Refresh();
        }
        private void DeleteResult()
        {
            string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            sqlConn.Open();
            string sqlQuery = "Delete  From TBL_RESULT";
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();

        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //DeleteResult();
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("تجميع قائمة المركز المالى  ");
                splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات حين الانتهاء من ترصيد الحسابات ");
        //        SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

        //        SqlCommand CMD = new SqlCommand();
        //        CMD.CommandType = CommandType.StoredProcedure;
        //        CMD.Connection = sqlconnection;

        //        CMD.CommandText = "SP_BalancTrial1";
        //        CMD.CommandTimeout = 80;
        //        CMD.Parameters.Add("@Date1", SqlDbType.DateTime).Value = dateTimePicker1.Text;
        //        CMD.Parameters.Add("@Date2", SqlDbType.DateTime).Value = dateTimePicker2.Text;
        //        //CMD.Parameters.Add("@D1", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
        //        //CMD.Parameters.Add("@D2", SqlDbType.DateTime).Value = dateTimePicker2.Value.ToShortDateString();
        //        sqlconnection.Open();
        //        SqlDataAdapter da = new SqlDataAdapter(CMD);
        //        DBDataSet.Tables.Add(dt);
        //        da.Fill(DBDataSet, "SP_BalancTrial1");
        //        DataTable dataTable1 = new DataTable();
        //        dataTable1.TableName = "TBL_RESULT";
        //        dataGridView1.DataSource = DBDataSet.Tables[1];
               

               


        //        if (dataGridView1.Rows.Count > 0)
        //        {
        //            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
        //            {
        //                SqlCommand comIN = new SqlCommand();
        //                comIN.Connection = sqlconnection;
        //                comIN.CommandType = CommandType.Text;
        //                comIN.CommandText = "Insert into TBL_RESULT (ACC_NO,ACC_NM_Ar,TOT) Values (@ACC_NO,@ACC_NM_Ar,@TOT)";
        //                comIN.Parameters.Add("@ACC_NO", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
        //                comIN.Parameters.Add("@ACC_NM_Ar", SqlDbType.NVarChar, 2147483647).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
        //                comIN.Parameters.Add("@TOT", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value).ToString();

        //                comIN.ExecuteNonQuery();
        //            }
        //        }
        //        sqlconnection.Close();

        //}
        //    catch { }
        //    finally
        //    {
 splashScreenManager1.CloseWaitForm();
                //simpleButton1.Enabled = true;
                //simpleButton2.Enabled = true;
                //simpleButton3.Enabled = true;
            //}
}
        
        private void Financial_Center_Load(object sender, EventArgs e)
        {
            this.tbl_FiscalyearTableAdapter.FillByYear(this.dataSet1.Tbl_Fiscalyear);
            this.tBL_Periods_of__fiscal_yearTableAdapter.Fill(this._Periods_of_fiscalyear.TBL_Periods_of__fiscal_year, Convert.ToInt32(comboBox9.SelectedValue));
            comboBox1.SelectedValue = -1;
            dateTimePicker4.Value = Convert.ToDateTime(textBox1.Text);
            dateTimePicker3.Value = Convert.ToDateTime(textBox2.Text);

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
           
        }
        private void CheckRange()
        {
            //string reportPath = @"Reports\Financial_Center.rpt"; // Replace with the actual relative path to your report
            //ReportDocument report = new ReportDocument();
            //report.Load(reportPath);
           

           
            
           

          
            //TableLogOnInfo tableLogOnInfo = report.Database.Tables[0].LogOnInfo;

           
            //ConnectionInfo connectionInfo = tableLogOnInfo.ConnectionInfo;
            //connectionInfo.ServerName = "DESKTOP-CIB865P1"; 

          
            //foreach (Table table in report.Database.Tables)
            //{
            //    table.ApplyLogOnInfo(tableLogOnInfo);
            //}

            Reports.Financial_Center r = new Reports.Financial_Center();
            using (SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString()))
            {
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Connection = sqlconnection;

                CMD.CommandText = "Pro_FinancialMenue";
                CMD.CommandTimeout = 80;

              
                CMD.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

               
                sqlconnection.Open();

              
                DataSet DBDataSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(CMD);
                DataTable dt = new DataTable();
                DBDataSet.Tables.Clear();
                DBDataSet.Tables.Add(dt);
                da.Fill(DBDataSet, "TBL_RESULT");

               
                r.SetDataSource(DBDataSet);

             
                sqlconnection.Close();
            }

            
            ParameterFieldDefinitions crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
            ParameterFieldDefinition crParameterFieldDefinition = crParameterFieldDefinitions["d"];  
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString(); 
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
       
       
        
       
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTO = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            CheckRange();
           
        }
        private void CheckRange2()
        {
            Reports.Financial_Center2 r = new Reports.Financial_Center2(); SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

            SqlCommand CMD = new SqlCommand();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Connection = sqlconnection;

            CMD.CommandText = "Pro_FinancialMenue";
            CMD.CommandTimeout = 80;
            sqlconnection.Open();
            CMD.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
           
            DataSet DBDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            DBDataSet.Tables.Clear();
            DBDataSet.Tables.Add(dt);
            da.Fill(DBDataSet, "TBL_RESULT");
            r.SetDataSource(DBDataSet);


            sqlconnection.Close();


            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTO = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            CheckRange2();
           
        }
        private void CheckRange3()
        {
            Reports.Financial_Center3 r = new Reports.Financial_Center3();

            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

            SqlCommand CMD = new SqlCommand();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Connection = sqlconnection;

            CMD.CommandText = "Pro_FinancialMenue";
            CMD.CommandTimeout = 80;
            sqlconnection.Open();
            CMD.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
           
            DataSet DBDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            DBDataSet.Tables.Clear();
            DBDataSet.Tables.Add(dt);
            da.Fill(DBDataSet, "TBL_RESULT");
            r.SetDataSource(DBDataSet);


            sqlconnection.Close();


            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTO = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            CheckRange3();
            
        }
        private void RetrieveDataBetweenDates(DateTime startDate, DateTime endDate, int Fyear, DataTable dataTable)
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

                                                      
                        GROUP BY A.Account_NO, A.Name
                        ORDER BY A.Account_NO ASC";

                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                    com.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                    com.Parameters.Add("@Fyear", SqlDbType.Int).Value = Fyear;
                   
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
        private DataTable GetDataBetweenDatesAndGroup( DateTime startDate, DateTime endDate, int Fyear)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("رقم الحساب", typeof(string));
            dataTable.Columns.Add("اسم الحساب", typeof(string));
            dataTable.Columns.Add("مدين", typeof(decimal));
            dataTable.Columns.Add("دائن", typeof(decimal));
            dataTable.Columns.Add("الرصيد", typeof(decimal));

            
                RetrieveDataBetweenDates(startDate, endDate, Fyear, dataTable);
            

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
               
                    groupedDataTable.Rows.Add(group.AccountNumber, group.AccountName, group.TotalDebit, group.TotalCredit, group.Balance);
                
            }

            return groupedDataTable;
        }
        public void DeleteResultByUser()
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

                com.CommandText = ("Delete From TBL_RESULT where UserName= @UserName");
               
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;


                con.Open();

                com.ExecuteNonQuery();
                con.Close();

           
        }
        public void saveToDB()
        {
            DeleteResultByUser();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
           

           
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {


                com.Parameters.Clear();

                com.CommandText = ("Insert Into TBL_RESULT(ACC_NO,ACC_NM_Ar,TOT,UserName) values(@ACC_NO,@ACC_NM_Ar,@TOT,@UserName)");
                com.Parameters.Add("@ACC_NO", SqlDbType.NVarChar ).Value = row.Cells[0].Value;
                com.Parameters.Add("@ACC_NM_Ar", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                com.Parameters.Add("@TOT", SqlDbType.Float ).Value = Convert.ToDecimal(row.Cells[4].Value);
                com.Parameters.Add("@UserName", SqlDbType.NVarChar ).Value = Program.GlbV_UserName;
                
                



                con.Open();

                com.ExecuteNonQuery();
                con.Close();

            }
        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
           
            
            DateTime startDate = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            int Fyear = Convert.ToInt32(comboBox9.SelectedValue);

            DataTable groupedDataTable = GetDataBetweenDatesAndGroup( startDate, endDate, Fyear);

            dataGridView2.DataSource = groupedDataTable;
            saveToDB();
            //GetParam_Date();
            DateTO =Convert.ToDateTime( dateTimePicker3.Value.ToShortDateString());
            CheckRange();
        }

        private void YYear_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //dateTimePicker4.Value = DateTime.MinValue;
                //dateTimePicker3.Value = DateTime.MinValue;
                dateTimePicker4.Value = Convert.ToDateTime(textBox1.Text);
                dateTimePicker3.Value = Convert.ToDateTime(textBox2.Text);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //DataBase f = new DataBase();
            //f.Show();
            string reportPath = @"Reports\Financial_Center.rpt";
            ReportDocument report = new ReportDocument();
            report.Load(reportPath);

            //Reports.Financial_Center report = new Reports.Financial_Center(); // Assuming Financial_Center is your report class
            //ReportDocument reportDocument = new ReportDocument();
            //report.Load(reportPath);

            // Get the database logon information for the report
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();

            // Set the new server name
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = "DESKTOP-CIB865P"; // Replace with the new server name
            connectionInfo.DatabaseName = "FinancialSys"; // Replace with the database name if needed
            connectionInfo.UserID = "sa"; // Replace with the username if needed
            connectionInfo.Password = "123"; // Replace with the password if needed

            // Update the database connection information for each table in the report
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }

            // Retrieve data from the database
            using (SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Connection = sqlconnection;
                CMD.CommandText = "Pro_FinancialMenue";
                CMD.CommandTimeout = 80;
                CMD.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

                sqlconnection.Open();

                DataSet DBDataSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(CMD);
                DataTable dt = new DataTable();
                DBDataSet.Tables.Clear();
                DBDataSet.Tables.Add(dt);
                da.Fill(DBDataSet, "TBL_RESULT");

                // Set the retrieved data as the report's data source
                report.SetDataSource(DBDataSet);

                sqlconnection.Close();
            }

            ParameterFieldDefinitions crParameterFieldDefinitions = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

          
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();

        }
    }
}