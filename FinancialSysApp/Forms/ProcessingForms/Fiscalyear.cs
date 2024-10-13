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
    public partial class Fiscalyear : DevExpress.XtraEditors.XtraForm
    {
        public Fiscalyear()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Fiscalyear_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter.Fill(this.financialSysDataSet.Tbl_Fiscalyear);
            this.tbl_FiscalyearTableAdapter.Fill(this.financialSysDataSet.Tbl_Fiscalyear);
            simpleButton1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            this.tblFiscalyearBindingSource.AddNew();
            simpleButton1.Enabled = true;
            textBox1.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblFiscalyearBindingSource.EndEdit();
            this.tbl_FiscalyearTableAdapter.Update(this.financialSysDataSet.Tbl_Fiscalyear);
            simpleButton1.Enabled = false;
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblFiscalyearBindingSource.EndEdit();
            this.tbl_FiscalyearTableAdapter.Update(this.financialSysDataSet.Tbl_Fiscalyear);
            //simpleButton1.Enabled = false;
            MessageBox.Show("تم التعديل بنجاح");
        }
        public void GetData()
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

                com.CommandText = (" select * from TBL_Periods_of_fiscal_year where FinanctialYear_ID=@FinanctialYear_ID");

            com.Parameters.Add("@FinanctialYear_ID", SqlDbType.NVarChar).Value = dataGridView1.CurrentRow.Cells[0].Value.ToString(); ;

            SqlDataReader red;




                con.Open();

            red = com.ExecuteReader();
            while(red.Read())
            {
                dataGridView2.Rows.Add(red.GetValue(1).ToString(),Convert.ToDateTime( red.GetValue(2).ToString()).ToShortDateString(), Convert.ToDateTime(red.GetValue(3).ToString()).ToShortDateString());
            }
            red.Close();
                con.Close();

            
        }
        public void saveToDB()
        {
            dataGridView2.AllowUserToAddRows = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;

            try
            {
                con.Open();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    // Check if the first cell value is null or empty
                    if (row.Cells[0].Value == null || string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("الرجاء إدخال قيمة لاسم الفترة");
                        return;
                    }

                    com.Parameters.Clear();
                    com.CommandText = "INSERT INTO TBL_Periods_of_fiscal_year(PeriodsName, FromDate, ToDate, FinanctialYear_ID) VALUES (@PeriodsName, @FromDate, @ToDate, @FinanctialYear_ID)";
                    com.Parameters.AddWithValue("@PeriodsName", SqlDbType.NVarChar).Value = row.Cells[0].Value.ToString();
                    com.Parameters.AddWithValue("@FromDate", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[1].Value);
                    com.Parameters.AddWithValue("@ToDate", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[2].Value);
                    com.Parameters.AddWithValue("@FinanctialYear_ID", SqlDbType.NVarChar).Value = row.Cells[3].Value.ToString();

                    com.ExecuteNonQuery();
                }
                MessageBox.Show("تم اضافة الفترات المالية بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ في قاعدة البيانات: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            DateTime fiscalYearStart = dateTimePicker1.Value; // Assuming fiscal year starts on April 1st
            DateTime fiscalYearEnd = dateTimePicker2.Value; // Assuming fiscal year ends on March 31st

            // Define the start and end dates between which you want to calculate quarters
            DateTime startDate = dateTimePicker1.Value; // Start date of the period
            DateTime endDate = dateTimePicker2.Value;// End date of the period

            // Calculate the total number of days in the fiscal year
            int totalDaysInFiscalYear = (int)(fiscalYearEnd - fiscalYearStart).TotalDays;

            // Calculate the number of days between the start date and the fiscal year start
            int daysFromStart = (int)(startDate - fiscalYearStart).TotalDays;

            // Calculate the quarter number
            int quarterNumber = (daysFromStart / (totalDaysInFiscalYear / 4)) + 1;
            for (int i = 0; i < 4; i++)
            {
                DateTime quarterStartDate = fiscalYearStart.AddMonths(i * 3);
                DateTime quarterEndDate = quarterStartDate.AddMonths(3).AddDays(-1);

                // If the quarter end date goes beyond the fiscal year end, adjust it
                if (quarterEndDate > fiscalYearEnd)
                    quarterEndDate = fiscalYearEnd;

                // Construct the Arabic quarter label
                string quarterLabel = "الربع " + (i + 1);

                // Add the row to the DataGridView
                dataGridView2.Rows.Add(quarterLabel, quarterStartDate.ToShortDateString(), quarterEndDate.ToShortDateString(), dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            for (int i = 0; i < 12; i++)
            {
                DateTime quarterStartDate = fiscalYearStart.AddMonths(i * 1);
                DateTime quarterEndDate = quarterStartDate.AddMonths(1).AddDays(-1);

                // If the quarter end date goes beyond the fiscal year end, adjust it
                if (quarterEndDate > fiscalYearEnd)
                    quarterEndDate = fiscalYearEnd;
                string quarterLabel = "شهر " + (i + 1);
                dataGridView2.Rows.Add(quarterLabel, quarterStartDate.ToShortDateString(), quarterEndDate.ToShortDateString(),dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            //Console.WriteLine("Quarter Number: " + quarterNumber);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            saveToDB();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            GetData();
        }

        private void dataGridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            dataGridView2.Rows.Clear();
            GetData();
        }
    }
}