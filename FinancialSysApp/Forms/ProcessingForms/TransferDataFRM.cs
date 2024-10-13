using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.OleDb;
using FinancialSysApp.DataBase;
using FinancialSysApp.DataBase.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class TransferDataFRM : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        public TransferDataFRM()
        {
            InitializeComponent();
            bw.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }
        private BackgroundWorker bw = new BackgroundWorker();
        private void TransferDataFRM_Load(object sender, EventArgs e)
        {
            this.tbl_FiscalyearTableAdapter.FillByYear(this.dataSet1.Tbl_Fiscalyear);

            // TODO: This line of code loads data into the 'financialSysDataSet.TBL_Temp_MatchAccounts' table. You can move, or remove it, as needed.
            this.tBL_Temp_MatchAccountsTableAdapter.Fill(this.financialSysDataSet.TBL_Temp_MatchAccounts);
        }
        private void MigrationCH()
        {
            button1.Invoke((Action)delegate
            {
                button1.Enabled = false;
            });

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            lblStatus.Invoke((Action)delegate
            {
                lblStatus.Text = "جارى تنفيذ العملية";
            });
            label1.Invoke((Action)delegate
            {
                label1.Text = "جارى حـساب وقت العملية ..";
            });
            progressBar1.Invoke((Action)delegate
            {
                progressBar1.Visible = true;
            });
            string accessConnStr = ConfigurationManager.ConnectionStrings["ACC.Properties.Settings.GLdataConnectionString"].ConnectionString.ToString();
            string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            OleDbConnection accessConn = new OleDbConnection(accessConnStr);
            SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            //string accessQuery = "SELECT gljrnld.JRN_CD, gljrnld.TR_NO, gljrnld.LN_NO, glmf.ACC_NO, gljrnld.TR_DS, gljrnld.DB_VL, gljrnld.CR_VL, gljrnlh.TR_DT, glmf.ACC_NM_Ar, glmf.ACC_TY, glmf.MANACC FROM(gljrnld INNER JOIN gljrnlh ON(gljrnld.JRN_CD = gljrnlh.JRN_CD) AND(gljrnld.TR_NO = gljrnlh.TR_NO)) INNER JOIN glmf ON gljrnld.ACC_NO = glmf.ACC_NO GROUP BY gljrnld.JRN_CD, gljrnld.TR_NO, gljrnld.LN_NO, glmf.ACC_NO, gljrnld.TR_DS, gljrnld.DB_VL, gljrnld.CR_VL, gljrnlh.TR_DT, glmf.ACC_NM_Ar, glmf.ACC_TY, glmf.MANACC Where  (((gljrnlh.TR_DT)>=@D And (gljrnlh.TR_DT)<=@D1))";

            string accessQuery= "SELECT gljrnld.JRN_CD, gljrnld.TR_NO, gljrnld.LN_NO, glmf.ACC_NO, gljrnld.TR_DS, gljrnld.DB_VL, gljrnld.CR_VL, gljrnlh.TR_DT, glmf.ACC_NM_Ar, glmf.ACC_TY, glmf.MANACC FROM(gljrnld INNER JOIN gljrnlh ON(gljrnld.JRN_CD = gljrnlh.JRN_CD) AND(gljrnld.TR_NO = gljrnlh.TR_NO)) INNER JOIN glmf ON gljrnld.ACC_NO = glmf.ACC_NO WHERE (gljrnlh.TR_DT >=  @D) AND (gljrnlh.TR_DT <= @D1)";
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
            dataGridView1.Invoke((Action)delegate
            {
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].HeaderText = "رقم اليومية";
                dataGridView1.Columns[1].HeaderText = "رقم المستند";
                dataGridView1.Columns[2].HeaderText = "رقم السطر";
                dataGridView1.Columns[3].HeaderText = "رقم الحساب";
                dataGridView1.Columns[4].HeaderText = "البيان";
                dataGridView1.Columns[5].HeaderText = "مدين";
                dataGridView1.Columns[6].HeaderText = "دائن";
                dataGridView1.Columns[7].HeaderText = "التاريخ";
                label3.Text = dataGridView1.Rows.Count.ToString();
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
            lblStatus.Invoke((Action)delegate
            {
                lblStatus.Text = "تمت العملية بنجاح";
            });
            progressBar1.Invoke((Action)delegate
            {
                progressBar1.Visible = false;
            });
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            label1.Invoke((Action)delegate
            {
                label1.ForeColor = Color.Red;

                label1.Text = ts.Hours.ToString() + ": " + ts.Minutes.ToString() + ": " + ts.Seconds.ToString() + ": " + ts.Milliseconds.ToString();
            });
            button1.Invoke((Action)delegate
            {
                button1.Enabled = true;
            });
        }
        public void INsertItems()
        {
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
           
            SqlCommand CMD = new SqlCommand();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Connection = sqlconnection;
            CMD.CommandText = "InsertTOAcc_Items";
            sqlconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            DataSet DBDataSet = new DataSet();
            DBDataSet.Tables.Add(dt);
            da.Fill(DBDataSet, "Tbl_AccountingRestrictionItems");
            sqlconnection.Close();
        }
        public void NextTransfareITEMS()
        {

            //string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            //SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            //string DetailQuiry = "select TR_NO AS [Restriction_NO],TR_DT AS [Restriction_Date],JRN_CD AS [AccountingRestrictionKind_ID] from Detail  group by TR_NO,TR_DT,JRN_CD  ";

            //SqlCommand com = new SqlCommand();
            //com.CommandType = CommandType.Text;
            //com.CommandText = DetailQuiry;
            //com.Connection = sqlConn;
            ////com.Parameters.Add("@D", SqlDbType.Date).Value = dateTimePicker1.Value;
            ////com.Parameters.Add("@D1", SqlDbType.Date).Value = dateTimePicker2.Value;
            //DataTable dataTable1 = new DataTable();
            //SqlDataAdapter adapter1 = new SqlDataAdapter();
            //sqlConn.Open();
            //com.ExecuteNonQuery();
            //adapter1.SelectCommand = new SqlCommand(DetailQuiry, sqlConn);
            ////adapter1.SelectCommand.Parameters.Add("@D", SqlDbType.Date).Value = dateTimePicker1.Value;
            ////adapter1.SelectCommand.Parameters.Add("@D1", SqlDbType.Date).Value = dateTimePicker2.Value;

            //dataTable1.TableName = "Tbl_AccountingRestriction";
            //DataSet DBDataSet = new DataSet();
            //DBDataSet.Tables.Add(dataTable1);
            //adapter1.Fill(dataTable1 );
            //using (var copy = new SqlBulkCopy(sqlConn))
            //{

            //    copy.ColumnMappings.Add("Restriction_NO", "Restriction_NO");
            //    copy.ColumnMappings.Add("Restriction_Date", "Restriction_Date");
            //    copy.ColumnMappings.Add("AccountingRestrictionKind_ID", "AccountingRestrictionKind_ID");
            //    copy.DestinationTableName = dataTable1.TableName;
            //    copy.WriteToServer(dataTable1);
            //    sqlConn.Close();
            //    copy.Close();
            //}
            
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

            SqlCommand CMD = new SqlCommand();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Connection = sqlconnection;
            CMD.CommandText = "InsertTOAcc_MainRes";
            sqlconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            DataSet DBDataSet = new DataSet();
            DBDataSet.Tables.Add(dt);
            da.Fill(DBDataSet, "Tbl_AccountingRestriction");
            sqlconnection.Close();
            UpdateFYear();
            INsertItems();
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
                MigrationCH();
            //}
            //catch { }
        }
        private void UpdateFYear()
        {
            string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

            // Invoke UI thread to access comboBox9.SelectedValue
            string comboBox9SelectedValue = string.Empty;
            comboBox9.Invoke((MethodInvoker)delegate {
                comboBox9SelectedValue = comboBox9.SelectedValue.ToString();
            });

            using (SqlConnection sqlConn = new SqlConnection(sqlConnStr))
            {
                sqlConn.Open();
                string sqlQuery = "UPDATE [FinancialSys].[dbo].[Tbl_AccountingRestriction] SET FYear = @F WHERE Restriction_Date BETWEEN @D AND @D1 AND FYear IS NULL";
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);

                // Now you can use comboBox9SelectedValue in your command parameters
                sqlCmd.Parameters.Add("@F", SqlDbType.NVarChar).Value = comboBox9SelectedValue;
                sqlCmd.Parameters.Add("@D", SqlDbType.Date).Value = dateTimePicker1.Value;
                sqlCmd.Parameters.Add("@D1", SqlDbType.Date).Value = dateTimePicker2.Value;

                sqlCmd.ExecuteNonQuery();
            }
        }
        private void DeleteBeforINSERT()
        {
            //try
            //{
                //DeleteBeforINSERTITEMS();
                string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlConnection sqlConn = new SqlConnection(sqlConnStr);
                sqlConn.Open();
                string sqlQuery = "Delete  From Tbl_AccountingRestriction DBCC CHECKIDENT (Tbl_AccountingRestrictionItems, RESEED, 0)";
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            //}
            //catch { }
        }
        private void DeleteBeforINSERTITEMS()
        {
            //try
            //{
            //DeleteBeforINSERT();
                //string sqlConnStr = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                //SqlConnection sqlConn = new SqlConnection(sqlConnStr);
                //sqlConn.Open();
                //string sqlQuery = "Delete  From Tbl_AccountingRestrictionItems";
                //SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConn);
                //sqlCmd.ExecuteNonQuery();
                //sqlConn.Close();
            //}
            //catch { }
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DeleteBeforINSERTITEMS();
            // check();
            NextTransfareITEMS();
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // NextTransfareITEMS();
            if (e.Cancelled == true)
            {
                lblStatus.Text = "Operation was cancelled";
            }
            else if (e.Error != null)
            {
                lblStatus.Text = "Error: " + e.Error.Message;
            }
            else
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
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
            this.tBL_Temp_MatchAccountsTableAdapter.Fill(this.financialSysDataSet.TBL_Temp_MatchAccounts);
            if (gridControl1.DefaultView.RowCount == 0)
            {
               
                bw.RunWorkerAsync();
            }

            if (gridControl1.DefaultView.RowCount > 0)
            {
               MessageBox.Show("من فضلك قم بتسجيل الحسابات المعروضة أولا ثم قم بسحب البيانات مرة أخرى");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
           // NextTransfare();
            NextTransfareITEMS();
        }
        private void button2_Click(object sender, EventArgs e)
        {  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string loc = "output.xlsx";


                (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = true;
                XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
                advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
                advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
                advOptions.SheetName = "Not Find Accounts";

                gridControl1.ExportToXlsx(loc, advOptions);

                Process.Start(loc);
            }
            catch
            { MessageBox.Show("من فضلك اغلق ملف الاكسيل الخاص بهذا التقرير أولا ،،"); }
        }
    }
}
