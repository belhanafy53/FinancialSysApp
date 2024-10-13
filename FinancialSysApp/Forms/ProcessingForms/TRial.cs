using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class TRial : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable dt = new DataTable();
        DataSet DBDataSet = new DataSet();
        public TRial()
        {
            InitializeComponent();
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

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                try
                {
                    DeleteResult();
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormCaption("تجميع بيانات ميزان المراجعة ");
                    splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات حين الانتهاء من ترصيد الحسابات ");
                    SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

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
                            //sqlconnection.Open();
                            //comIN.CommandText = "Insert into TBL_RESULT (ACC_NO,ACC_NM_Ar,OPDB,OPCR,PRDB,PRCR,MDB,MCR,TOT) Values (@ACC_NO,@ACC_NM_Ar,@OPDB,@OPCR,@PRDB,@PRCR,@MDB,@MCR,@TOT)";


                            comIN.CommandText = "Insert into TBL_RESULT (ACC_NO,ACC_NM_Ar,OPDB,OPCR,PRDB,PRCR,MDB,MCR,TOT,DateF,DateT,YMonth,YYear,YMonth1,YYear1) Values (@ACC_NO,@ACC_NM_Ar,@OPDB,@OPCR,@PRDB,@PRCR,@MDB,@MCR,@TOT,@DateF,@DateT,@YMonth,@YYear,@YMonth1,@YYear1)";
                            comIN.Parameters.Add("@ACC_NO", SqlDbType.NVarChar).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            comIN.Parameters.Add("@ACC_NM_Ar", SqlDbType.NVarChar, 2147483647).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            
                            //****
                            comIN.Parameters.Add("@OPDB", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value).ToString();

                            comIN.Parameters.Add("@OPCR", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value).ToString();

                            comIN.Parameters.Add("@PRDB", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value).ToString();

                            comIN.Parameters.Add("@PRCR", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value).ToString();

                            comIN.Parameters.Add("@MDB", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value).ToString();

                            comIN.Parameters.Add("@MCR", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value).ToString();
                            comIN.Parameters.Add("@TOT", SqlDbType.Float).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value).ToString();

                            comIN.Parameters.Add("@DateF", SqlDbType.DateTime).Value = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());

                            comIN.Parameters.Add("@DateT", SqlDbType.DateTime).Value = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());

                            comIN.Parameters.Add("@YMonth", SqlDbType.VarChar).Value = dateTimePicker1.Value.Month.ToString();

                            comIN.Parameters.Add("@YYear", SqlDbType.VarChar).Value = dateTimePicker1.Value.Year.ToString();


                            comIN.Parameters.Add("@YMonth1", SqlDbType.VarChar).Value = dateTimePicker2.Value.Month.ToString();

                            comIN.Parameters.Add("@YYear1", SqlDbType.VarChar).Value = dateTimePicker2.Value.Year.ToString();
                            comIN.ExecuteNonQuery();

                            if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value) < 0)
                            {
                                //decimal x = -1;
                                //decimal y;
                               dataGridView1.Rows[i].Cells[8].Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value) * -1;
                                //y = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                                //dataGridView1.Rows[i].Cells[8].Value = y * x;
                            }
                        }
                        sqlconnection.Close();
                    }

                   
                }
                catch { }
                finally
                {
                    splashScreenManager1.CloseWaitForm();

                    SqlCommand com = new SqlCommand();
                    SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
                    com.CommandType = CommandType.Text;
                    com.Connection = sqlconnection;
                    com.CommandText = "Update Tbl_DateRange set Datef=@DateF,DateT=@DateT";
                    com.Parameters.Add("@DateF", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
                    com.Parameters.Add("@DateT", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
                    sqlconnection.Open();
                    com.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string loc = "output.xlsx";


                (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = true;
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
