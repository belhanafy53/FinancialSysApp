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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Ongoing_Operation : DevExpress.XtraEditors.XtraForm
    {
        DateTime DateFR = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        DateTime DateTO = Convert.ToDateTime(DateTime.Now.ToShortDateString());

        public Ongoing_Operation()
        {
            InitializeComponent();
        }
        public void GetParam_Date()
        {

            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "Select DateT,DateF From Tbl_DateRange ";
            sqlconnection.Open();
            SqlDataReader re = com.ExecuteReader();
            while (re.Read())
            {
                DateTO = Convert.ToDateTime(re.GetValue(0));
                DateFR = Convert.ToDateTime(re.GetValue(1));
            }
            re.Close();

            sqlconnection.Close();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTO = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            DateFR = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
            CheckRange();

        }
        private void CheckRange2()
        {
            Reports.Ongoing_Operations2 r = new Reports.Ongoing_Operations2();
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


            ParameterFieldDefinitions crParameterFieldDefinitions1;
            ParameterFieldDefinition crParameterFieldDefinition1;
            ParameterValues crParameterValues1 = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
            crParameterDiscreteValue1.Value = DateFR.ToString();
            crParameterFieldDefinitions1 = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition1 = crParameterFieldDefinitions1["d2"];

            crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
            crParameterValues1.Clear();
            crParameterValues1.Add(crParameterDiscreteValue1);
            crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTO = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            DateFR = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
            CheckRange2();
        }

        private void Ongoing_Operation_Load(object sender, EventArgs e)
        {
            this.tbl_FiscalyearTableAdapter.FillByYear(this.dataSet1.Tbl_Fiscalyear);
            this.tBL_Periods_of__fiscal_yearTableAdapter.Fill(this._Periods_of_fiscalyear.TBL_Periods_of__fiscal_year, Convert.ToInt32(comboBox9.SelectedValue));
            comboBox1.SelectedValue = -1;
            dateTimePicker4.Value = Convert.ToDateTime(textBox1.Text);
            dateTimePicker3.Value = Convert.ToDateTime(textBox2.Text);

        }
        public DataTable GetMonth1()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select distinct YMonth1 from dbo.TBL_RESULT where YYear=@Y and YMonth=@M ");
            com.Parameters.Add("Y", SqlDbType.NVarChar).Value = YYear.Text;
            com.Parameters.Add("M", SqlDbType.NVarChar).Value = YMonth.Text;
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
        public DataTable GetYear()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select distinct YYear from dbo.TBL_RESULT group by YYear order  by YYear ASC");
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
        public DataTable GetMonth()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select distinct YMonth from dbo.TBL_RESULT group by YMonth order  by YMonth ASC");
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
        public DataTable GetYear1()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select distinct YYear1 from dbo.TBL_RESULT where YYear=@Y and YMonth=@M ");
            com.Parameters.Add("Y", SqlDbType.NVarChar).Value = YYear.Text;
            com.Parameters.Add("M", SqlDbType.NVarChar).Value = YMonth.Text;
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
        private void CheckRange()
        {
            Reports.Ongoing_Operations r = new Reports.Ongoing_Operations();
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


            ParameterFieldDefinitions crParameterFieldDefinitions1;
            ParameterFieldDefinition crParameterFieldDefinition1;
            ParameterValues crParameterValues1 = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
            crParameterDiscreteValue1.Value = DateFR.ToString();
            crParameterFieldDefinitions1 = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition1 = crParameterFieldDefinitions1["d1"];

            crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
            crParameterValues1.Clear();
            crParameterValues1.Add(crParameterDiscreteValue1);
            crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
        private void YYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                YMonth1.Text = "";
                YYear1.Text = "";
                YMonth1.DataSource = GetMonth1();
                YMonth1.DisplayMember = "YMonth1";
                YYear1.DataSource = GetYear1();
                YYear1.DisplayMember = "YYear1";
            }
            catch { }
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
        private DataTable GetDataBetweenDatesAndGroup(DateTime startDate, DateTime endDate, int Fyear)
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
                com.Parameters.Add("@ACC_NO", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                com.Parameters.Add("@ACC_NM_Ar", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                com.Parameters.Add("@TOT", SqlDbType.Float).Value = Convert.ToDecimal(row.Cells[4].Value);
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;





                con.Open();

                com.ExecuteNonQuery();
                con.Close();

            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            int Fyear = Convert.ToInt32(comboBox9.SelectedValue);

            DataTable groupedDataTable = GetDataBetweenDatesAndGroup(startDate, endDate, Fyear);

            dataGridView2.DataSource = groupedDataTable;
            saveToDB();
            //GetParam_Date();
            DateTO = Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString());
            DateFR = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
            CheckRange();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dateTimePicker4.Value = Convert.ToDateTime( textBox1.Text);
            //dateTimePicker3.Value = Convert.ToDateTime(textBox2.Text);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}