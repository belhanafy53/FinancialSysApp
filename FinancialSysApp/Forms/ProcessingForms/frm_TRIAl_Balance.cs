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
    public partial class frm_TRIAl_Balance : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataSet DBDataSet = new DataSet();
        public frm_TRIAl_Balance()
        {
            InitializeComponent();
        }

        private void frm_TRIAl_Balance_Load(object sender, EventArgs e)
        {
            YMonth.DataSource = GetMonth();
            YMonth.DisplayMember = "YMonth";
            YYear.DataSource = GetYear();
            YYear.DisplayMember = "YYear";

            //YMonth.Text = "";
            //YYear.Text = "";
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
        private void CheckRange()
        {
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());

            SqlCommand CMD = new SqlCommand();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Connection = sqlconnection;

            CMD.CommandText = "GetResUltForBalance";
            CMD.CommandTimeout = 80;
            sqlconnection.Open();
            CMD.Parameters.Add("@MonthF", SqlDbType.NVarChar).Value = YMonth.Text.Trim();
            CMD.Parameters.Add("@MonthT", SqlDbType.NVarChar).Value = YMonth1.Text.Trim();
            CMD.Parameters.Add("@YearF", SqlDbType.NVarChar).Value = YYear.Text.Trim();
            CMD.Parameters.Add("@YearT", SqlDbType.NVarChar).Value = YYear1.Text.Trim();
            //CMD.Parameters.Add("@D1", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
            //CMD.Parameters.Add("@D2", SqlDbType.DateTime).Value = dateTimePicker2.Value.ToShortDateString();

            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DBDataSet.Tables.Clear();
            DBDataSet.Tables.Add(dt);
            da.Fill(DBDataSet, "GetResUltForBalance");
            DataTable dataTable1 = new DataTable();
            dataTable1.TableName = "View_GetResult_Balance1";
            dataGridView1.DataSource = DBDataSet.Tables[1];
            gridControl1.DataSource = DBDataSet.Tables[1];
            gridView1.OptionsView.ColumnAutoWidth = true;

            gridView1.BestFitColumns();
            gridView1.BestFitMaxRowCount = -1;

            sqlconnection.Close();
            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            {


                if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value) < 0)
                {
                    //decimal x = -1;
                    //decimal y;
                    dataGridView1.Rows[i].Cells[8].Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value) * -1;
                    //y = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    //dataGridView1.Rows[i].Cells[8].Value = y * x;
                }
            }
        }
        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormCaption(" المنظومة المالية ** تجميع بيانات ميزان المراجعة  ");
                    splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات لحين الانتهاء من ترصيد الحسابات ");
                    //CheckRange();
                    if (dataGridView1.Rows.Count == 0)
                    {
                        //DeleteResult();
                        updateDate();
                       
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
                        DBDataSet.Tables.Clear();
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

                        }
                        sqlconnection.Close();
                    }
                }
                catch { }
                finally
                {


                    splashScreenManager1.CloseWaitForm();


                }
            }
        }
        private void updateDate()
        {
            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "Insert Into Tbl_DateRange (Datef,DateT) Values (@DateF,@DateT)";
            com.Parameters.Add("@DateF", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            com.Parameters.Add("@DateT", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
            sqlconnection.Open();
            com.ExecuteNonQuery();
            sqlconnection.Close();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[0].Value.ToString() == "1%"
                       select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void YYear_TextChanged(object sender, EventArgs e)
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
        private void GetTotal1()
        {
            t1.Text = "";
            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "select TOT FROM  dbo.TBL_RESULT  where ACC_NO=1 And (YMonth =@MonthF AND  YMonth1 = @MonthT  AND   YYear = @YearF AND   YYear1 = @YearT) ";
            com.Parameters.Add("@MonthF", SqlDbType.NVarChar).Value = YMonth.Text.Trim();
            com.Parameters.Add("@MonthT", SqlDbType.NVarChar).Value = YMonth1.Text.Trim();
            com.Parameters.Add("@YearF", SqlDbType.NVarChar).Value = YYear.Text.Trim();
            com.Parameters.Add("@YearT", SqlDbType.NVarChar).Value = YYear1.Text.Trim();
            SqlDataReader red;
            sqlconnection.Open();
            red = com.ExecuteReader();
            while(red.Read())
            {
                t1.Text = red.GetValue(0).ToString();
            }

            red.Close();
            sqlconnection.Close();
        }
        private void GetTotal2()
        {
            t2.Text = "";
            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "select TOT FROM  dbo.TBL_RESULT  where ACC_NO=2 And (YMonth =@MonthF AND  YMonth1 = @MonthT  AND   YYear = @YearF AND   YYear1 = @YearT) ";
            com.Parameters.Add("@MonthF", SqlDbType.NVarChar).Value = YMonth.Text.Trim();
            com.Parameters.Add("@MonthT", SqlDbType.NVarChar).Value = YMonth1.Text.Trim();
            com.Parameters.Add("@YearF", SqlDbType.NVarChar).Value = YYear.Text.Trim();
            com.Parameters.Add("@YearT", SqlDbType.NVarChar).Value = YYear1.Text.Trim();
            SqlDataReader red;
            sqlconnection.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                t2.Text = red.GetValue(0).ToString();
            }

            red.Close();
            sqlconnection.Close();
        }
        private void GetTotal3()
        {
            t3.Text = "";
            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "select TOT FROM  dbo.TBL_RESULT  where ACC_NO=3 And (YMonth =@MonthF AND  YMonth1 = @MonthT  AND   YYear = @YearF AND   YYear1 = @YearT) ";
            com.Parameters.Add("@MonthF", SqlDbType.NVarChar).Value = YMonth.Text.Trim();
            com.Parameters.Add("@MonthT", SqlDbType.NVarChar).Value = YMonth1.Text.Trim();
            com.Parameters.Add("@YearF", SqlDbType.NVarChar).Value = YYear.Text.Trim();
            com.Parameters.Add("@YearT", SqlDbType.NVarChar).Value = YYear1.Text.Trim();
            SqlDataReader red;
            sqlconnection.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                t3.Text = red.GetValue(0).ToString();
            }

            red.Close();
            sqlconnection.Close();
        }
        private void GetTotal4()
        {
            t4.Text = "";
            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "select TOT FROM  dbo.TBL_RESULT  where ACC_NO=4 And (YMonth =@MonthF AND  YMonth1 = @MonthT  AND   YYear = @YearF AND   YYear1 = @YearT) ";
            com.Parameters.Add("@MonthF", SqlDbType.NVarChar).Value = YMonth.Text.Trim();
            com.Parameters.Add("@MonthT", SqlDbType.NVarChar).Value = YMonth1.Text.Trim();
            com.Parameters.Add("@YearF", SqlDbType.NVarChar).Value = YYear.Text.Trim();
            com.Parameters.Add("@YearT", SqlDbType.NVarChar).Value = YYear1.Text.Trim();
            SqlDataReader red;
            sqlconnection.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                t4.Text = red.GetValue(0).ToString();
            }

            red.Close();
            sqlconnection.Close();
        }
        private void GetTotal5()
        {
            t5.Text = "";
            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "select TOT FROM  dbo.TBL_RESULT  where ACC_NO=5 And (YMonth =@MonthF AND  YMonth1 = @MonthT  AND   YYear = @YearF AND   YYear1 = @YearT) ";
            com.Parameters.Add("@MonthF", SqlDbType.NVarChar).Value = YMonth.Text.Trim();
            com.Parameters.Add("@MonthT", SqlDbType.NVarChar).Value = YMonth1.Text.Trim();
            com.Parameters.Add("@YearF", SqlDbType.NVarChar).Value = YYear.Text.Trim();
            com.Parameters.Add("@YearT", SqlDbType.NVarChar).Value = YYear1.Text.Trim();
            SqlDataReader red;
            sqlconnection.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                t5.Text = red.GetValue(0).ToString();
            }

            red.Close();
            sqlconnection.Close();
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption(" المنظومة المالية ** تجميع بيانات ميزان المراجعة  ");
                splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات لحين الانتهاء من ترصيد الحسابات ");
                CheckRange();


            }
            catch { }
            finally
            {


                splashScreenManager1.CloseWaitForm();
                GetTotal1();
                GetTotal2();
                GetTotal3();
                GetTotal4();
                GetTotal5();

            }
        }
    }
}