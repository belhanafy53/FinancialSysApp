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
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Diagnostics;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class TRIALBALANCE : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataSet DBDataSet = new DataSet();
        public TRIALBALANCE()
        {
            InitializeComponent();
        }
        private void DeleteResult()
        {
            string sqlConnStr = ConfigurationManager.ConnectionStrings["ACC.Properties.Settings.DBConnectionString"].ConnectionString.ToString();
            SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            sqlConn.Open();
            string sqlQuery = "Delete  From TBL_RESULT";
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
          
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteResult();
                splashScreenManager2.ShowWaitForm();
                splashScreenManager2.SetWaitFormCaption("تجميع بيانات ميزان المراجعة ");
                splashScreenManager2.SetWaitFormDescription("الرجاء الإنتظار لحظات حين الانتهاء من ترصيد الحسابات ");
                SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ACC.Properties.Settings.DBConnectionString"].ConnectionString.ToString());

                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Connection = sqlconnection;

                CMD.CommandText = "SP_BalancTrial1";
            CMD.CommandTimeout = 80;
                CMD.Parameters.Add("@Date1", SqlDbType.DateTime).Value = dateTimePicker1.Text;
                CMD.Parameters.Add("@Date2", SqlDbType.DateTime).Value = dateTimePicker2.Text;
                //CMD.Parameters.Add("@D1", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                //CMD.Parameters.Add("@D2", SqlDbType.DateTime).Value = dateTimePicker2.Value.ToShortDateString();
                sqlconnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(CMD);
                DBDataSet.Tables.Add(dt);
                da.Fill(DBDataSet, "SP_BalancTrial1");
                DataTable dataTable1 = new DataTable();
                dataTable1.TableName = "TBL_RESULT";
                dataGridView1.DataSource = DBDataSet.Tables[1];
                gridControl1.DataSource = DBDataSet.Tables[1];
                gridView1.OptionsView.ColumnAutoWidth = true;

                gridView1.BestFitColumns();
                gridView1.BestFitMaxRowCount = -1;


            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i <= dataGridView1.Rows.Count; i++)
                {
                    SqlCommand comIN = new SqlCommand();
                    comIN.Connection = sqlconnection;
                    comIN.CommandType = CommandType.Text;
                    comIN.CommandText = "Insert into TBL_RESULT (ACC_NO,ACC_NM_Ar,TOT) Values (@ACC_NO,@ACC_NM_Ar,@TOT)";
                    comIN.Parameters.Add("@ACC_NO", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    comIN.Parameters.Add("@ACC_NM_Ar", SqlDbType.NVarChar, 2147483647).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    comIN.Parameters.Add("@TOT", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value).ToString();

                    comIN.ExecuteNonQuery();
                }
            }
                sqlconnection.Close();

        }
            catch { }
            finally
            { splashScreenManager2.CloseWaitForm(); }
}

        private void TRIALBALANCE_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string loc = "output.xlsx";


                (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = true ;
                XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
                advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
                advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
                advOptions.SheetName = "Trial Balance";

                gridControl1.ExportToXlsx(loc, advOptions);

                Process.Start(loc);
            }
            catch
            { MessageBox.Show("من فضلك اغلق ملف الاكسيل الخاص بهذا الميزان أولا ،،"); }
        }
    }
}