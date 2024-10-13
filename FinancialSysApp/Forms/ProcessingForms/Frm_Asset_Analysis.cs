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
using System.Data.OleDb;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Frm_Asset_Analysis : DevExpress.XtraEditors.XtraForm
    {
      
        public Frm_Asset_Analysis()
        {
            InitializeComponent();
        }
        private void MigrationCH()
        {
            
            string accessConnStr = ConfigurationManager.ConnectionStrings["ACC.Properties.Settings.GLdataConnectionString"].ConnectionString.ToString();
            string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            OleDbConnection accessConn = new OleDbConnection(accessConnStr);
            SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            //string accessQuery = "SELECT gljrnld.JRN_CD, gljrnld.TR_NO, gljrnld.LN_NO, glmf.ACC_NO, gljrnld.TR_DS, gljrnld.DB_VL, gljrnld.CR_VL, gljrnlh.TR_DT, glmf.ACC_NM_Ar, glmf.ACC_TY, glmf.MANACC FROM(gljrnld INNER JOIN gljrnlh ON(gljrnld.JRN_CD = gljrnlh.JRN_CD) AND(gljrnld.TR_NO = gljrnlh.TR_NO)) INNER JOIN glmf ON gljrnld.ACC_NO = glmf.ACC_NO GROUP BY gljrnld.JRN_CD, gljrnld.TR_NO, gljrnld.LN_NO, glmf.ACC_NO, gljrnld.TR_DS, gljrnld.DB_VL, gljrnld.CR_VL, gljrnlh.TR_DT, glmf.ACC_NM_Ar, glmf.ACC_TY, glmf.MANACC Where  (((gljrnlh.TR_DT)>=@D And (gljrnlh.TR_DT)<=@D1))";

            string accessQuery = "SELECT gljrnld.JRN_CD, gljrnld.TR_NO, gljrnld.LN_NO, glmf.ACC_NO, gljrnld.TR_DS, gljrnld.DB_VL, gljrnld.CR_VL, gljrnlh.TR_DT, glmf.ACC_NM_Ar, glmf.ACC_TY, glmf.MANACC FROM(gljrnld INNER JOIN gljrnlh ON(gljrnld.JRN_CD = gljrnlh.JRN_CD) AND(gljrnld.TR_NO = gljrnlh.TR_NO)) INNER JOIN glmf ON gljrnld.ACC_NO = glmf.ACC_NO WHERE (gljrnlh.TR_DT >=  @D) AND (gljrnlh.TR_DT <= @D1)";
            OleDbCommand accessCmd = new OleDbCommand(accessQuery, accessConn);
            //accessCmd.CommandType = CommandType.Text;
            accessConn.Open();
            accessCmd.Parameters.Add("@D", OleDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
            accessCmd.Parameters.Add("@D1", OleDbType.Date).Value = dateTimePicker2.Value.ToShortDateString();
            DataTable dataTable = new DataTable();
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            adapter.SelectCommand = new OleDbCommand(accessQuery, accessConn);
            adapter.SelectCommand.Parameters.Add("@D", OleDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
            adapter.SelectCommand.Parameters.Add("@D1", OleDbType.Date).Value = dateTimePicker2.Value.ToShortDateString();
            sqlConn.Open();
            dataTable.TableName = "Detail";
            adapter.Fill(dataTable);
           
            using (var bulkInsert = new SqlBulkCopy(sqlConnStr))
            {
                bulkInsert.DestinationTableName = dataTable.TableName;

                bulkInsert.WriteToServer(dataTable);

                sqlConn.Close();
                bulkInsert.Close();
            }
            accessConn.Close();
            sqlConn.Close();
          
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
        private void GetAdvac()
        {
            check();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

            SqlCommand CMD = new SqlCommand();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Connection = sqlconnection;
            CMD.CommandText = "ST_Catch_AccountNm";
            sqlconnection.Open();
            CMD.ExecuteNonQuery();
            sqlconnection.Close();
           
        }
        public void Get_Balance()
        {

            //تجميع ميزان المراجعة حسب التاريخ






            //try
            //{
            //Reports.CachedRevenue_and_expense r = new Reports.CachedRevenue_and_expense();
            Reports.RptAssets BRPT = new Reports.RptAssets();
                 //BRPT = new Balance_RevRPT.RptAssets();
                //DataAccessLayers.DataAccessL DAL = new DataAccessLayers.DataAccessL();
                SqlConnection sqlconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

                sqlconnection.Open();
                SqlCommand CMD = new SqlCommand();
                CMD.CommandType = CommandType.StoredProcedure;
                CMD.Connection = sqlconnection;
                CMD.CommandText = "SP_Assest_Analysis";
                CMD.Parameters.Add("@D1", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                CMD.Parameters.Add("@D2", SqlDbType.DateTime).Value = dateTimePicker2.Value.ToShortDateString();
                SqlDataAdapter da = new SqlDataAdapter(CMD);
                DataTable dt = new DataTable();
                DataSet DBDataSet = new DataSet();
                DBDataSet.Tables.Add(dt);
                DBDataSet.Clear();
                da.Fill(DBDataSet, "View_ Asset_Analysis");
                //da.Fill(DBDataSet, "SP_Assest_Analysis");
                BRPT.SetDataSource(DBDataSet);
            
            
            crystalReportViewer1.ReportSource = BRPT;
                BRPT.SetParameterValue("D1", dateTimePicker1.Text);
                BRPT.SetParameterValue("D2", dateTimePicker2.Text);
                //Forms.Balance_Rev FRMBalance = new Forms.Balance_Rev();
                
                crystalReportViewer1.ReportSource = BRPT;
                crystalReportViewer1.Refresh();
                //DAL.closse();
                sqlconnection.Close();
                DBDataSet.Dispose();
            //}
            //catch { }


        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("تجميع بيانات تحليلات الأصول الثابتة ");
            splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات ");
            check();
            MigrationCH();
            Get_Balance();
           
            splashScreenManager1.CloseWaitForm();
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("تجميع بيانات تحليلات الأصول الثابتة ");
                splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات ");
                check();
                MigrationCH();
                Get_Balance();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }
    }
}