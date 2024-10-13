using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using FinancialSysApp.DataBase.ModelEvents;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.Windows;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using DevComponents.DotNetBar.Controls;
using AnalogClock.My.Resources;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Diagnostics;
using FinancialSysApp.DataBase.Model;
//using Infragistics.Win;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using Infragistics.Win.UltraWinToolbars;
using System.Net.NetworkInformation;
using Telerik.WinControls.Primitives;
using System.Threading;
using System;
using System.Timers;
using System.Threading.Tasks;

namespace FinancialSysApp.Forms.ProcessingForms
{

    public partial class Res_Frm : RadForm
    {

        //private Image greenImage = Properties. Resources. green;
        //private Image redImage = Properties. Resources. red;

        DataTable DT = new DataTable();
        DataTable DT1 = new DataTable();
        DataTable DT2 = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter();
        DataSet ds;
        DataTable dt = new DataTable();
        int x = 1;
        int y = 2;
        ModelEvent FsEvDb = new ModelEvent();
        Model1 FsDb = new Model1();
        public Res_Frm()
        {

            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            textBox24.KeyPress +=  textBox24_KeyPress;
            textBox25.KeyPress += textBox25_KeyPress;
            // الاشتراك في الحدث Resize
            //this.Resize += Res_Frm_Resize;

            // ملء البيانات في الفورم
            this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet1.Tbl_Fiscalyear);
            //labelControl3.Visible = false;
            //labelControl2.Visible = false;
            //timer4.Interval = 1000; // إعداد التايمر ليفعل كل ثانية
            //timer4.Tick += timer4_Tick; // ربط الحدث Tick بالمعالج

        }


        //private void ResizeControls()
        //{
        //    // ضبط حجم وموقع العناصر داخل الفورم بناءً على حجم الفورم الحالي
        //    foreach (Control ctrl in this.Controls)
        //    {
        //        ctrl.Width = this.ClientSize.Width / 2;  // على سبيل المثال، ضبط العرض
        //        ctrl.Height = this.ClientSize.Height / 2; // على سبيل المثال، ضبط الارتفاع
        //    }
        //}

        public DataTable getDay()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("SELECT * FROM Tbl_AccountingRestrictions_Kind WHERE ParentID IS NULL ORDER BY ID ASC", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);

                }
            }
            return dt;
        }

        public DataTable getOpen()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (5)");
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
        public DataTable ReportPrint()
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.Accounting_Guid_ID ,Tbl_Activities.Name as[النشاط] ,Tbl_Activities.ID,Tbl_RestrictionItemsCategory.Name as [التصنيف],Tbl_RestrictionItemsCategory.ID, Tbl_CostCenters.Name ,Tbl_AccountingRestrictionItems.CostCenters_ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID Left Join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID left join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID left join Tbl_CostCenters on Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2  OR Tbl_AccountingRestriction.Restriction_NO = @D and Tbl_AccountingRestrictions_Kind.id = @D3  Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

            //if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
            //{
            //    x = 1;
            //    y = 2;
            //}

            //if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
            //{
            //    x = 1;
            //    y = 2;
            //}
            //if (Convert.ToInt32(comboBox1.SelectedValue) != 2 && Convert.ToInt32(comboBox1.SelectedValue) != 1)
            //{
            //    x = Convert.ToInt32(comboBox1.SelectedValue);
            //    y = Convert.ToInt32(comboBox1.SelectedValue);
            //}
            //if (Convert.ToInt32(comboBox1.SelectedValue) != 1 && Convert.ToInt32(comboBox1.SelectedValue) != 2)
            //{
            //    x = Convert.ToInt32(comboBox1.SelectedValue);
            //    y = Convert.ToInt32(comboBox1.SelectedValue);
            //}


            com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;
            //if (comboBox1.Text != "عمليات" || comboBox1.Text != "مدفوعات"  ) 
            //{
            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
            //}

            //if (comboBox1.Text == "عمليات" || comboBox1.Text == "مدفوعات")
            //{
            //    com.Parameters.Add("@D2", SqlDbType.Int).Value = 1;
            //    com.Parameters.Add("@D3", SqlDbType.Int).Value = 2;
            //}
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
        public void getBanifecary()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandType = CommandType.Text;
                    com.Connection = con;
                    com.CommandText = "SELECT dbo.Tbl_DocumentBenefcairy.Beneficiary_ID, dbo.Tbl_Beneficiary.Name  FROM dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_DocumentBenefcairy  ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_DocumentBenefcairy.Beneficiary_ID  WHERE dbo.Tbl_DocumentBenefcairy.Document_ID = @ID";

                    // Clear parameters to avoid adding multiple parameters on multiple calls
                    com.Parameters.Clear();

                    // Add parameter
                    if (!string.IsNullOrEmpty(textBox10.Text))
                    {
                        com.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox10.Text));
                    }
                    else
                    {
                        com.Parameters.AddWithValue("@ID", DBNull.Value);
                    }

                    con.Open();
                    using (SqlDataReader red = com.ExecuteReader())
                    {
                        if (red.Read())
                        {
                            UsFulID.Text = red.IsDBNull(0) ? string.Empty : red.GetInt32(0).ToString();
                            UsFul.Text = red.IsDBNull(1) ? string.Empty : red.GetString(1);
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        public void getBanifecary1()
        {

            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("SELECT dbo.Tbl_DocumentBenefcairy.Beneficiary_ID, dbo.Tbl_Beneficiary.Name, dbo.Tbl_DocumentBenefcairy.Document_ID FROM dbo.Tbl_Beneficiary INNER JOIN dbo.Tbl_DocumentBenefcairy ON dbo.Tbl_Beneficiary.ID = dbo.Tbl_DocumentBenefcairy.Beneficiary_ID WHERE(dbo.Tbl_DocumentBenefcairy.Document_ID = @ID)");
            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox10.Text);
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while (red.Read())
            {
                UsFul.Items.Add(red.GetValue(1)).ToString();
            }
            red.Close();
            con.Close();

            UsFul.SelectedIndex = 0;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //da.SelectCommand = com;
            //com.ExecuteScalar();
            //da.Fill(dt);
            //con.Close();
            //return dt;
        }
        public DataTable getsettlements()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (3)");
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
        public DataTable getPayment()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (4)");
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
        public DataTable getMOL1()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (7)");
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
        public DataTable getMOL2()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (8)");
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
        public DataTable getMOL3()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (9)");
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
        //int x = 0;
        //int y = 0;
        public void FindFileNumber()
        {

            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.Accounting_Guid_ID,Tbl_RestrictionItemsCategory.Name as [التصنيف] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_Activities.Name as [النشاط] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");


            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_RestrictionItemsCategory.Name as [التصنيف] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D Order by Row_No ,Tbl_AccountingRestrictions_Kind.ID  ASc ");

            com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;

            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;

            con.Open();
            red = com.ExecuteReader();
            if (red.HasRows)
            {
                while (red.Read())
                {
                    dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8));
                }

            }
            if (!red.HasRows)
            {
                FindFileNumber1();
                GetDocumentData();
            }
            red.Close();

            //da.SelectCommand = com;

            //da.SelectCommand = com;
            //com.ExecuteScalar();

            //da.Fill(dt);





            com1.Connection = con;
            com1.CommandText = ("select Restriction_Date  from Tbl_AccountingRestriction  where Tbl_AccountingRestriction.Restriction_NO =  @D ");

            //com1.CommandText = ("select Restriction_Date ,Document_ID,  Tbl_Descrption.Name from Tbl_AccountingRestriction inner join TBL_Document on  Tbl_AccountingRestriction.Document_ID = TBL_Document.ID inner join Tbl_Descrption on TBL_Document.DescrptionID = Tbl_Descrption.ID  where Tbl_AccountingRestriction.Restriction_NO =  @D ");

            com1.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;

            //con.Open();
            SqlDataReader red1;
            red1 = com1.ExecuteReader();
            while (red1.Read())
            {

                dateTimePicker1.Text = red1.GetValue(0).ToString();
                //DocNO.Text = red.GetValue(1).ToString();
                //Descp.Text = red.GetValue(2).ToString();

            }
            red1.Close();
            con.Close();
            //return dt;
            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            textBox1.Text = dataGridView1.Rows.Count.ToString();
            double xx, yy, zz;
            xx = Convert.ToDouble(tD.Text);
            yy = Convert.ToDouble(tC.Text);
            zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            df.Text = Convert.ToString(zz);

        }
        public void FindFileNumber1()
        {
            //try
            //{
            //    this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet1.Tbl_Fiscalyear);
            //}
            //catch
            { }
            if (checkBox8.Checked == false)
            {
                if (Convert.ToInt32(textBox16.Text) == 12)
                {
                    x = 1;
                    y = 2;
                }

                if (Convert.ToInt32(textBox16.Text) == 13)
                {
                    x = 3;
                    y = 3;
                }
                if (Convert.ToInt32(textBox16.Text) == 14)
                {
                    x = 4;
                    y = 4;
                }
                if (Convert.ToInt32(textBox16.Text) == 15)
                {
                    x = 5;
                    y = 5;
                }
                if (Convert.ToInt32(textBox16.Text) == 16)
                {
                    x = 6;
                    y = 6;
                }
                if (Convert.ToInt32(textBox16.Text) == 17)
                {
                    x = 7;
                    y = 7;
                }
                if (Convert.ToInt32(textBox16.Text) == 18)
                {
                    x = 8;
                    y = 8;
                }
                if (Convert.ToInt32(textBox16.Text) == 19)
                {
                    x = 9;
                    y = 9;
                }
                dataGridView1.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID as[اليومية],Tbl_AccountingRestrictionItems.Accounting_Guid_ID ,Tbl_Activities.Name as[النشاط] ,Tbl_Activities.ID,Tbl_RestrictionItemsCategory.Name as [التصنيف],Tbl_RestrictionItemsCategory.ID, Tbl_CostCenters.Name ,Tbl_AccountingRestrictionItems.CostCenters_ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.AccountingRestriction_ID,Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID,Tbl_Accounting_Guid.BrokerAccount,HighamountsAccount,PersonalAccount from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID Left Join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID left join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID left join Tbl_CostCenters on Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 and FYear=@FY  OR Tbl_AccountingRestriction.Restriction_NO = @D and Tbl_AccountingRestrictions_Kind.id = @D3 and FYear=@FY Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

                //if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
                //{
                //    x = 1;
                //    y = 2;
                //}

                //if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
                //{
                //    x = 1;
                //    y = 2;
                //}
                //if (Convert.ToInt32(comboBox1.SelectedValue) != 2 && Convert.ToInt32(comboBox1.SelectedValue) != 1)
                //{
                //    x = Convert.ToInt32(comboBox1.SelectedValue);
                //    y = Convert.ToInt32(comboBox1.SelectedValue);
                //}
                //if (Convert.ToInt32(comboBox1.SelectedValue) != 1 && Convert.ToInt32(comboBox1.SelectedValue) != 2)
                //{
                //    x = Convert.ToInt32(comboBox1.SelectedValue);
                //    y = Convert.ToInt32(comboBox1.SelectedValue);
                //}


                com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;
                //if (comboBox1.Text != "عمليات" || comboBox1.Text != "مدفوعات"  ) 
                //{
                com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                com.Parameters.Add("@FY", SqlDbType.NVarChar).Value = comboBox3.SelectedValue;
                //}

                //if (comboBox1.Text == "عمليات" || comboBox1.Text == "مدفوعات")
                //{
                //    com.Parameters.Add("@D2", SqlDbType.Int).Value = 1;
                //    com.Parameters.Add("@D3", SqlDbType.Int).Value = 2;
                //}
                con.Open();
                red = com.ExecuteReader();
                if (red.HasRows)
                {
                    while (red.Read())
                    {
                        dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8), red.GetValue(9), red.GetValue(10), red.GetValue(11), red.GetValue(12), red.GetValue(13), red.GetValue(14), 0, 0, 0, 0, 0, 0, red.GetValue(5), red.GetValue(16), red.GetValue(17), red.GetValue(18));
                    }
                    red.Close();


                    //da.SelectCommand = com;

                    //da.SelectCommand = com;
                    //com.ExecuteScalar();

                    //da.Fill(dt);





                    com1.Connection = con;
                    com1.CommandText = ("select Restriction_Date,AcountingRestrictionCorrRelation_ID  from Tbl_AccountingRestriction  where Tbl_AccountingRestriction.Restriction_NO =  @D and AccountingRestrictionKind_ID=@D1 OR Tbl_AccountingRestriction.Restriction_NO =  @D and AccountingRestrictionKind_ID=@D2 ");

                    //com1.CommandText = ("select Restriction_Date ,Document_ID,  Tbl_Descrption.Name from Tbl_AccountingRestriction inner join TBL_Document on  Tbl_AccountingRestriction.Document_ID = TBL_Document.ID inner join Tbl_Descrption on TBL_Document.DescrptionID = Tbl_Descrption.ID  where Tbl_AccountingRestriction.Restriction_NO =  @D ");

                    com1.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;
                    com1.Parameters.Add("@D1", SqlDbType.VarChar).Value = x;
                    com1.Parameters.Add("@D2", SqlDbType.VarChar).Value = y;
                    //con.Open();
                    SqlDataReader red1;
                    red1 = com1.ExecuteReader();
                    while (red1.Read())
                    {

                        dateTimePicker1.Text = red1.GetValue(0).ToString();
                        Lyear.Text = red1.GetValue(1).ToString();
                        //DocNO.Text = red.GetValue(1).ToString();
                        //Descp.Text = red.GetValue(2).ToString();

                    }
                    red1.Close();
                    con.Close();
                    if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
                    {
                        //dataGridView1.Rows.Clear();
                        //MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
                    }
                    //****************Refrences******User Enter Data *********
                    try
                    {
                        long Vlng_AccRstID = long.Parse(textBox5.Text);
                        AccRstAuditSelect(Vlng_AccRstID);
                        var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TrecordId == Vlng_AccRstID).Distinct().ToList();

                        string Vstr_UserAddR = "";
                        int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                        for (int i = 0; i <= WCount - 1; i++)
                        {
                            Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                        }
                        textBox30.Text = Vstr_UserAddR;
                    }
                    catch { }
                    //}
                    //else
                    //{
                    //    textBox30.Text = "";
                    //}
                    //***************************************
                    //return dt;
                    //////tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                    //////           where row.Cells[3].FormattedValue.ToString() != string.Empty
                    //////           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                    //////tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                    //////           where row.Cells[4].FormattedValue.ToString() != string.Empty
                    //////           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                    //////textBox1.Text = dataGridView1.Rows.Count.ToString();
                    //////double xx, yy, zz;
                    //////xx = Convert.ToDouble(tD.Text);
                    //////yy = Convert.ToDouble(tC.Text);
                    //////zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                    //////df.Text = Convert.ToString(zz);
                    if (dataGridView1.Rows.Count > 1)
                    {
                        tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                                   where row.Cells[3].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                        tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                                   where row.Cells[4].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                        textBox1.Text = dataGridView1.Rows.Count.ToString();
                        double xx1, yy1, zz1;
                        xx1 = Convert.ToDouble(tD.Text);
                        yy1 = Convert.ToDouble(tC.Text);
                        zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                        df.Text = Convert.ToString(zz1);


                        string s = (from DataGridViewRow row in dataGridViewX2.Rows
                                    where row.Cells[2].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
                        string f = (from DataGridViewRow row in dataGridViewX2.Rows
                                    where row.Cells[3].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

                        double xx, yy, zz;
                        xx = Convert.ToDouble(s);
                        yy = Convert.ToDouble(f);
                        zz = Convert.ToDouble(s) - Convert.ToDouble(f);
                        TTT.Text = Convert.ToString(zz);
                        // dataGridView1.AllowUserToAddRows = true;

                        //PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                        //                where row.Cells[21].Value.ToString() == "1"
                        //                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                        //Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                        //                 where row.Cells[21].Value.ToString() == "1"
                        //                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                        //double PrD, PRC, PRT;
                        //PrD = Convert.ToDouble(PrDebit.Text);
                        //PRC = Convert.ToDouble(Prcridit.Text);
                        //PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                        //PrTot.Text = Convert.ToString(PRT);
                        ////dataGridView1.AllowUserToAddRows = true;


                        //CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                        //                where row.Cells[21].Value.ToString() == "2"
                        //                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                        //CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                        //                 where row.Cells[21].Value.ToString() == "2"
                        //                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                        //double CaD, CaC, CaT;
                        //CaD = Convert.ToDouble(CaDebit.Text);
                        //CaC = Convert.ToDouble(CaCridit.Text);
                        //CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                        //CaTolt.Text = Convert.ToString(CaT);
                    }
                    //textBox22.Select();
                    //dataGridView1.AllowUserToAddRows = true;
                }
                Open_PersonalityAccountsButton();
                if (dataGridView1.Rows.Count > 0)
                {

                    this.CategortID.TextChanged += CategortID_TextChanged;
                }
            }
            if (checkBox8.Checked == true)
            {
                MessageBox.Show("العام المالى مغلق");
            }

            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        public void Updated()
        {

            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.Accounting_Guid_ID ,Tbl_Activities.Name as[النشاط] ,Tbl_Activities.ID,Tbl_RestrictionItemsCategory.Name as [التصنيف],Tbl_RestrictionItemsCategory.ID, Tbl_AccountingRestrictionItems.CostCenters_ID,Tbl_CostCenters.Name ,Tbl_AccountingRestrictionItems.ID from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID Left Join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID left join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID left join Tbl_CostCenters on Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");





            com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;

            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;

            con.Open();
            adap.SelectCommand = com;
            adap.Fill(ds, "t");
            dataGridViewX1.AutoGenerateColumns = true;
            dataGridViewX1.DataSource = ds.Tables[1];


            con.Close();
            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            textBox1.Text = dataGridView1.Rows.Count.ToString();
            double xx, yy, zz;
            xx = Convert.ToDouble(tD.Text);
            yy = Convert.ToDouble(tC.Text);
            zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            df.Text = Convert.ToString(zz);
        }
        public AutoCompleteStringCollection ClientListDropDown()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlDataReader dr;
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                con.Open();
                string query;
                query = "select Account_NO From Tbl_Accounting_Guid where AccountsKind_ID <> 1 ";
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
                if ((dr != null) && (dr.HasRows))
                {
                    while (dr.Read())
                    {
                        asc.Add(dr.GetValue(0).ToString());
                    }
                    dr.Close();
                    com.Dispose();
                    con.Close();
                }
            }

            catch { }
            return asc;
        }

        public AutoCompleteStringCollection Activity()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlDataReader dr;
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                con.Open();
                string query;
                query = "select Name From Tbl_Activities ";
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
                if ((dr != null) && (dr.HasRows))
                {
                    while (dr.Read())
                    {
                        asc.Add(dr.GetValue(0).ToString());
                    }
                    dr.Close();
                    com.Dispose();
                    con.Close();
                }
            }

            catch { }
            return asc;
        }
        public AutoCompleteStringCollection CostCenter()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlDataReader dr;
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                con.Open();
                string query;
                query = "select Name From Tbl_CostCenters ";
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
                if ((dr != null) && (dr.HasRows))
                {
                    while (dr.Read())
                    {
                        asc.Add(dr.GetValue(0).ToString());
                    }
                    dr.Close();
                    com.Dispose();
                    con.Close();
                }
            }

            catch { }
            return asc;
        }

        public AutoCompleteStringCollection RestrictionKind()
        {
            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlDataReader dr;
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.Connection = con;
                con.Open();
                string query;
                query = "select Name From Tbl_RestrictionItemsCategory ";
                com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
                if ((dr != null) && (dr.HasRows))
                {
                    while (dr.Read())
                    {
                        asc.Add(dr.GetValue(0).ToString());
                    }
                    dr.Close();
                    com.Dispose();
                    con.Close();
                }
            }

            catch { }
            return asc;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void GenerateID()
        {
            //int x = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Select  ID from Tbl_AccountingRestriction where Restriction_NO=@P and AccountingRestrictionKind_ID=@P1 and FYear=@FYear and Document_ID is not null";
            com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Restriction_NO.Text;
            com.Parameters.Add("@P1", SqlDbType.Int).Value = x;
            com.Parameters.Add("@FYear", SqlDbType.NVarChar).Value = comboBox3.SelectedValue;
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox5.Text = red.GetValue(0).ToString();
            }

            red.Close();
            con.Close();

            //x = x + 1;
            //return x;
        }
        public void GetREstrictionID()
        {
            try
            {
                //int x = 0;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = "Select  ID from Tbl_AccountingRestriction where Restriction_NO=@P and AccountingRestrictionKind_ID=@P1";
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Restriction_NO.Text;
                com.Parameters.Add("@P1", SqlDbType.Int).Value = comboBox1.SelectedValue;
                con.Open();
                SqlDataReader red;
                red = com.ExecuteReader();
                while (red.Read())
                {
                    textEdit2.Text = red.GetValue(0).ToString();
                }

                red.Close();
                con.Close();
            }
            catch
            {
                MessageBox.Show("أدخل رقم المستند");
                //Restriction_NO.Text = "0";
                Restriction_NO.Focus();
            }

        }

        public void GetREstrictionIDForLYear()
        {
            //try
            //{
            //int x = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Select  Restriction_NO from Tbl_AccountingRestriction where ID=@P ";
            com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Lyear.Text;

            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox19.Text = red.GetValue(0).ToString();
            }

            red.Close();
            con.Close();
            //}
            //catch
            //{

            //}

        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }

        public DataTable fillDGVComboBox()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("SELECT * FROM Tbl_AccountingRestrictions_Kind WHERE ParentID = @ID ORDER BY ID ASC", con))
                {
                    com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox16.Text);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        private void ComboInDataGrid()
        {
            DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns[21];
            comboBoxColumn.DisplayMember = "Name";
            comboBoxColumn.ValueMember = "ID";

            DataTable comboBoxData = fillDGVComboBox(); // Retrieve combo box data only once
            comboBoxColumn.DataSource = comboBoxData;
        }
        //private void ComboInDataGrid()
        //{
        //    var combobox = (DataGridViewComboBoxColumn)dataGridView1.Columns[21];
        //    combobox.DisplayMember = "Name";
        //    combobox.ValueMember = "ID";

        //    combobox.DataSource = fillDGVComboBox();
        //}

        private void CheckDataGridView()
        {
            int i = 0;
            int j = 0;

            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.RowCount - 1; j++)
                {
                    if (i > j)
                    {
                        if (dataGridView1[1, i].Value == dataGridView1[1, j].Value)
                            dataGridView1[1, i].Value += String.Format(" {0}", dataGridView1[1, j].Value.ToString());
                    }
                    if (i < j)
                    {
                        if (dataGridView1[1, i].Value == dataGridView1[1, j].Value)
                            dataGridView1[1, i].Value += String.Format(" {0}", dataGridView1[1, j].Value.ToString());
                    }
                    if (i == j)
                    {
                        if (!dataGridView1.Rows[i].IsNewRow)
                            dataGridView1[1, i].Value += String.Format(" {0}", dataGridView1[1, i].Value.ToString());
                    }
                }
            }
        }



        private void checkDay()
        {
            int textBoxValue;
            if (int.TryParse(textBox16.Text, out textBoxValue))
            {
                switch (textBoxValue)
                {
                    case 12:
                        x = 1;
                        y = 2;
                        break;
                    case 13:
                        x = 3;
                        y = 3;
                        break;
                    case 14:
                        x = 4;
                        y = 4;
                        break;
                    case 15:
                        x = 5;
                        y = 5;
                        break;
                    case 16:
                        x = 6;
                        y = 6;
                        break;
                    case 17:
                        x = 7;
                        y = 7;
                        break;
                    case 18:
                        x = 8;
                        y = 8;
                        break;
                    case 19:
                        x = 9;
                        y = 9;
                        break;
                    default:
                        // Handle case when textBoxValue is not in the specified cases
                        // You may throw an exception, set default values, or handle it in another way
                        break;
                }
            }
            else
            {
                // Handle case when textBox16.Text cannot be parsed as an integer
                // You may throw an exception, set default values, or handle it in another way
            }
        }
        private async void LoadFrm()
        {
            // تشغيل العمليات الثقيلة في خيط منفصل
            await Task.Run(() => {
                checkDay();
                var days = getDay();
                var comboBoxData = fillDGVComboBox();

                // يجب عدم استدعاء GetParentIDKind هنا لأنها تتفاعل مع عناصر واجهة المستخدم مباشرة
            });

            // تحديث عناصر واجهة المستخدم في الخيط الرئيسي
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(LoadFrm));
            }
            else
            {
                switchButton1.Value = true;
                comboBox1.DataSource = getDay();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
                comboBox1.SelectedIndex = 0;
                comboBox5.DataSource = getDay();
                comboBox5.DisplayMember = "Name";
                comboBox5.ValueMember = "ID";
                comboBox5.SelectedIndex = 0;

                // استدعاء GetParentIDKind بعد إعداد العناصر
                GetParentIDKind();

                ComboInDataGrid();
                comboBox4.DataSource = fillDGVComboBox();
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
                this.ActiveControl = Restriction_NO;
                Restriction_NO.Focus();
                Restriction_NO.SelectAll();
            }
        }
        private SqlConnection con;
        public void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
        private async void Res_Frm_Load(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 77 && w.ProcdureId == 1003);
            //if (validationSaveUser != null)
            //{
            //   textBox36.Enabled = true;
            //}
            //else
            //{
            //    textBox36.Enabled = false;
            //}


                //splashScreenManager2.ShowWaitForm();
                // TODO: This line of code loads data into the 'dataSet1.Tbl_SystemUnites' table. You can move, or remove it, as needed.
                try
            {
                // تعبئة البيانات في DataSet
                await Task.Run(() => this.tbl_SystemUnitesTableAdapter.FillBySpecifiedUnite(this.dataSet1.Tbl_SystemUnites));
                if (textBox21.Text != "X")
                {
                    // تشغيل مؤشر تحميل في خيط منفصل
                    await Task.Run(() => LoadFrm());

                    // ضبط عناصر التحكم
                    label24.Text = string.Empty;
                    dateTimePicker5.Focus();
                    dateTimePicker5.Select();
                }
                if (textBox21.Text == "X")
                {
                    comboBox1.Text = label49.Text;
                    checkBox15.Checked = true;
                    comboBox1.Text = label49.Text;
                    if (comboBox1.Text == "عمليات")
                    {
                        this.KeyPreview = true;
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 12;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                   else if (comboBox1.Text == "مدفوعات")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 12;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    else if (comboBox1.Text == "تسويات")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 13;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    else if (comboBox1.Text == "مقبوضات")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 14;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    else if (comboBox1.Text == "قيد افتتاحي")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 15;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    else if (comboBox1.Text == "عمليات 30-6")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 16;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    else if (comboBox1.Text == "ملحق1")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 17;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    else if (comboBox1.Text == "ملحق 2")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 18;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    else if (comboBox1.Text == "ملحق 3")
                    {
                        comboBox1.DataSource = getDay();
                        comboBox1.DisplayMember = "Name";
                        comboBox1.ValueMember = "ID";
                        comboBox1.SelectedValue = 19;
                        comboBox5.DataSource = getDay();
                        comboBox5.DisplayMember = "Name";
                        comboBox5.ValueMember = "ID";
                        comboBox5.SelectedIndex = 0;

                        // استدعاء GetParentIDKind بعد إعداد العناصر
                        GetParentIDKind();

                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        this.ActiveControl = Restriction_NO;
                        Restriction_NO.Focus();
                        Restriction_NO.SelectAll();
                    }
                    panel22.Visible = false;
                    Restriction_NO.Focus();
                    Restriction_NO.SelectAll();
                 
                    //splashScreenManager2.ShowWaitForm();
                   
                    labelControl8.Text = "العام المالى " + comboBox3.Text;
                    chckBxBasicData.Checked = false;
                    textBox36.BackColor = Color.White;
                    textBox36.ForeColor = Color.Black;
                    textBox29.Text = string.Empty;
                    textBox30.Text = string.Empty;
                    labelControl1.Visible = false;
                    panel2.Visible = false;
                    textBox29.Text = string.Empty;
                    textBox30.Text = string.Empty;
                    textBox36.Text = string.Empty;
                    textBox19.Text = string.Empty;
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    textBox37.Text = string.Empty;
                    textBox34.Text = string.Empty;
                    dataGridViewX8.Rows.Clear();
                    button2_Click_1(sender, e);
                    dateTimePicker1.Focus();

                    if (comboBox4.Items.Count > 1)
                    {
                        comboBox4.SelectedValue = 1;
                    }

                    if (dataGridView1.Rows.Count == 1 && !checkBox15.Checked)
                    {
                        dateTimePicker1.Value = dateTimePicker5.Value;
                    }

                    if (!string.IsNullOrEmpty(textBox5.Text))
                    {
                        long Vlng_AccRstID = long.Parse(textBox5.Text);
                        await Task.Run(() => AccRstAuditSelect(Vlng_AccRstID));

                        if (!string.IsNullOrEmpty(textBox7.Text))
                        {
                            await Task.Run(() => SelcectOrderUser(textBox7.Text));
                        }

                        await Task.Run(() => AccRstNoteToUnitSelect(Vlng_AccRstID));

                    }
                    //splashScreenManager2.CloseWaitForm();
                }

              
            }
            catch 
            {
              //  splashScreenManager2.CloseWaitForm();
                MessageBox.Show($"حدث خطأ: تأكد من أن هذا المستند داخل العام المالى المفتوح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dataGridView1.CurrentCell.ColumnIndex == 1)//Account Number 
            {

            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {

            }

            if (dataGridView1.CurrentCell.ColumnIndex == 9)//Restriction Kind 
            {

            }

        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();


                if (e.ColumnIndex == 1)//رقم الحساب استعلام وجلب حسب رقم الحساب
                {

                    string NewValue;
                    NewValue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select Name,ID,BrokerAccount,HighamountsAccount,PersonalAccount from Tbl_Accounting_Guid where Account_NO='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = dt.Rows[0][1].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[22].Value = dt.Rows[0][2].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[23].Value = dt.Rows[0][3].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[24].Value = dt.Rows[0][4].ToString();
                    con.Close();
                    LoadSerial();
                    foreach (DataGridViewRow row1 in dataGridView2.Rows)
                    {
                        //foreach (DataGridViewRow row in dataGridView1.Rows)
                        //{
                        //dataGridView1.AllowUserToAddRows = false;

                        if (CategortID.Text == row1.Cells[3].Value.ToString())
                        {
                            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == row1.Cells[1].Value.ToString())
                            {
                                dataGridView1.CurrentRow.Cells[10].Value = row1.Cells[2].Value;
                                //SqlConnection con = new SqlConnection();
                                //con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                                con.Open();
                                SqlDataAdapter da1 = new SqlDataAdapter("select Name from Tbl_RestrictionItemsCategory where ID='" + dataGridView1.CurrentRow.Cells[10].Value + "'", con);
                                DataTable dt1 = new DataTable();
                                da1.Fill(dt1);
                                //   MessageBox.Show(dt.Rows.Count.ToString());
                                if (dt1.Rows.Count > 0)
                                {
                                    dataGridView1.CurrentRow.Cells[9].Value = dt1.Rows[0][0].ToString();
                                }
                                con.Close();


                                //}
                            }
                        }
                    }
                }

                if (e.ColumnIndex == 21)//رقم الحساب استعلام وجلب حسب رقم الحساب
                {

                    textBox17.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = dataGridView1.CurrentRow.Cells[21].Value;

                }
                if (e.ColumnIndex == 11)//مركز التكلفة
                {
                    //if (dataGridView1.CurrentRow.Cells[13].Value != null)
                    //{
                    //LoadSerial();
                    string NewValue;
                    NewValue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select ID from Tbl_CostCenters where Name='" + NewValue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[12].Value = dt.Rows[0][0].ToString();

                    con.Close();

                }

                if (e.ColumnIndex == 9)//التصنيف
                {
                    //string NewValue;
                    //NewValue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    //con.Open();
                    //SqlDataAdapter da = new SqlDataAdapter("select ID from Tbl_RestrictionItemsCategory where Name='" + NewValue + "'", con);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //dataGridView1.Rows[e.RowIndex].Cells[10].Value = dt.Rows[0][0].ToString();

                    //con.Close();


                }



                if (e.ColumnIndex == 7)//الانشطة
                {
                    string NewValue;
                    NewValue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value).ToString();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select ID from Tbl_Activities where Name='" + NewValue + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[e.RowIndex].Cells[8].Value = dt.Rows[0][0].ToString();

                    con.Close();

                }

                if (e.ColumnIndex == 3)//التحقق من المدين 
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null && dataGridView1.Rows[e.RowIndex].Cells[4].Value != null)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "0";
                        //BrokerAccount();
                        SendKeys.Send("{TAB}");
                    }

                }

                if (e.ColumnIndex == 3)//التحقق من المدين  
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[3].Value != null && dataGridView1.Rows[e.RowIndex].Cells[4].Value == null)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "0";
                        //BrokerAccount();
                        SendKeys.Send("{TAB}");


                    }

                }
                if (e.ColumnIndex == 4)//التحقق من الدائن 
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null && dataGridView1.Rows[e.RowIndex].Cells[3].Value != null)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = "0";
                        //BrokerAccount();
                        SendKeys.Send("{TAB}");
                    }

                }
                if (e.ColumnIndex == 4)//التحقق من الدائن
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null && dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = "0";
                        //BrokerAccount();
                        SendKeys.Send("{TAB}");
                    }

                }



                //dataGridView1.AllowUserToAddRows = false;
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[3].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[4].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                textBox1.Text = dataGridView1.Rows.Count.ToString();
                double xx, yy, zz;
                xx = Convert.ToDouble(tD.Text);
                yy = Convert.ToDouble(tC.Text);
                zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                df.Text = Convert.ToString(zz);


                PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[21].Value.ToString() == "1"
                                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[21].Value.ToString() == "1"
                                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                double PrD, PRC, PRT;
                PrD = Convert.ToDouble(PrDebit.Text);
                PRC = Convert.ToDouble(Prcridit.Text);
                PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                PrTot.Text = Convert.ToString(PRT);

                CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[21].Value.ToString() == "2"
                                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[21].Value.ToString() == "2"
                                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                double CaD, CaC, CaT;
                CaD = Convert.ToDouble(CaDebit.Text);
                CaC = Convert.ToDouble(CaCridit.Text);
                CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                CaTolt.Text = Convert.ToString(CaT);
                LoadSerial();

            }
            catch
            {
            }

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {

        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
                }

            }
            catch { }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {//next
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("select top(1) Restriction_NO, LAG(Restriction_NO) OVER ( ORDER BY Restriction_NO) from Tbl_AccountingRestriction where Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D2 OR Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D3     ");
                com.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Restriction_NO.Text;
                com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                con.Open();
                red = com.ExecuteReader();

                while (red.Read())
                {
                    Restriction_NO.Text = red.GetValue(0).ToString();
                }
                if (!red.HasRows)
                {
                    Restriction_NO.Text = "0";
                }
                red.Close();
                con.Close();
                CleareControls();
                GetREstrictionID();
                FindFileNumber1();
                GetDocumentData();
                Getex();
                GetMan();
                GetUsf();
                Getcate();
                GetHand();
                GetRespon();
                GetOrdersIDDocument();
                BrokerAccount();
            }
            catch { }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            { //prev
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("select top(1) Restriction_NO, LAG  (Restriction_NO) OVER ( ORDER BY Restriction_NO desc) from Tbl_AccountingRestriction where Restriction_NO < @Restriction_NO and AccountingRestrictionKind_ID = @D2 OR  Restriction_NO < @Restriction_NO and AccountingRestrictionKind_ID = @D3     ");
                com.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Restriction_NO.Text;
                com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                con.Open();
                red = com.ExecuteReader();

                while (red.Read())
                {

                    Restriction_NO.Text = red.GetValue(0).ToString();
                }
                if (!red.HasRows)
                {
                    Restriction_NO.Text = "0";
                }
                red.Close();
                con.Close();
                CleareControls();
                GetREstrictionID();
                FindFileNumber1();
                GetDocumentData();
                Getex();
                GetMan();
                GetUsf();
                Getcate();
                GetHand();
                GetRespon();
                GetOrdersIDDocument();
                BrokerAccount();
            }
            catch { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            DialogResult result = new DialogResult();
            result = MessageBox.Show(" هل أنت متأكد من حفظ التعديل؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;

                com.CommandText = ("Update Tbl_AccountingRestrictionItems set Accounting_Guid_ID=@Accounting_Guid_ID,Debit_Value=@Debit_Value,Credit_Value=@Credit_Value,RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID,Activities_ID=@Activities_ID ,CostCenters_ID=@CostCenters_ID where ID=@ID   ");
                com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);

                com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
                com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
                if (dataGridView1.CurrentRow.Cells[10].Value != DBNull.Value)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt64(dataGridView1.CurrentRow.Cells[10].Value);
                }
                if (dataGridView1.CurrentRow.Cells[10].Value == DBNull.Value)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (dataGridView1.CurrentRow.Cells[8].Value != DBNull.Value)
                {
                    com.Parameters.Add("@Activities_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value);
                }
                if (dataGridView1.CurrentRow.Cells[8].Value == DBNull.Value)
                {
                    com.Parameters.Add("@Activities_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (dataGridView1.CurrentRow.Cells[12].Value != DBNull.Value)
                {
                    com.Parameters.Add("@CostCenters_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[12].Value);
                }
                if (dataGridView1.CurrentRow.Cells[12].Value == DBNull.Value)
                {
                    com.Parameters.Add("@CostCenters_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                com.Parameters.Add("@ID", SqlDbType.Int).Value = dataGridView1.CurrentRow.Cells[13].Value;
                con.Open();

                com.ExecuteNonQuery();
                con.Close();
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[3].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[4].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                textBox1.Text = dataGridView1.Rows.Count.ToString();
                double xx, yy, zz;
                xx = Convert.ToDouble(tD.Text);
                yy = Convert.ToDouble(tC.Text);
                zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                df.Text = Convert.ToString(zz);
                LoadSerial();
                MessageBox.Show("تم التعديل");

                FindFileNumber1();
                GetDocumentData();

            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show(" هل أنت متأكد من حذف البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;

                com.CommandText = ("delete from Tbl_AccountingRestrictionItems  where ID=@ID   ");

                com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
                con.Open();

                com.ExecuteNonQuery();
                con.Close();

                FindFileNumber1();
                GetDocumentData();
                //}
                MessageBox.Show("تم حذف  بند القيد بنجاح");

                if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count)
                {

                    dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Selected = true;







                }


            }

        }
        private void Open_PersonalityAccountsButton()//التحقق من وجود بيانات للمستند قبل اتاحة زرار المديونيات والتعليات
        {
            simpleButton17.Enabled = false;
            simpleButton18.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells[13].Value != null)
                {
                    simpleButton17.Enabled = true;
                    simpleButton18.Enabled = true;
                }
                else if (dataGridView1.Rows[x].Cells[13].Value == null)
                {
                    simpleButton17.Enabled = false;
                    simpleButton18.Enabled = false;
                }
            }
            //dataGridView1.AllowUserToAddRows = true;
        }

        public void Restriction_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(Restriction_NO.Text) < Convert.ToInt32(textBox32.Text) && checkBox15.Checked == false && comboBox1.Text != comboBox5.Text || Convert.ToInt32(Restriction_NO.Text) > Convert.ToInt32(textBox33.Text) && checkBox15.Checked == false && comboBox1.Text != comboBox5.Text)
                {
                    MessageBox.Show("رقم المستند خارج النطاق المحدد");
                }
                else
                {
                    chckBxBasicData.Checked = false;
                    textBox36.BackColor = Color.White;
                    textBox36.ForeColor = Color.Black;
                    textBox29.Text = string.Empty;
                    textBox30.Text = string.Empty;
                    labelControl1.Visible = false;
                    panel2.Visible = false;
                    chckBxBasicData.Checked = false;
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox36.Text = "";
                    textBox19.Text = "";
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    textBox37.Text = "";
                    textBox34.Text = "";
                    dataGridViewX8.Rows.Clear();
                    chckBxBasicData.Checked = false;
                    button2_Click_1(sender, e);
                    dateTimePicker1.Focus();
                    if (comboBox4.Items.Count > 1)
                    {
                        comboBox4.SelectedValue = 1;
                    }
                    if (dataGridView1.Rows.Count == 1 && checkBox15.Checked == false)
                    {
                        dateTimePicker1.Value = dateTimePicker5.Value;
                    }
                    if (textBox5.Text != string.Empty)
                    {
                        long Vlng_AccRstID = long.Parse(textBox5.Text);
                        AccRstAuditSelect(Vlng_AccRstID);
                        if (textBox7.Text != "")
                        {
                            SelcectOrderUser(textBox7.Text);
                        }
                        AccRstNoteToUnitSelect(Vlng_AccRstID);

                    }
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                dateTimePicker1.Focus();
            }
        }
        public void SearchinHeader()
        {
            // Assuming @D, @D1, and @D2 are parameters passed to the method or declared elsewhere
            GenerateID();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Restriction_Date, AcountingRestrictionCorrRelation_ID " +
                              "FROM Tbl_AccountingRestriction " +
                              "WHERE (Tbl_AccountingRestriction.Restriction_NO = @D AND AccountingRestrictionKind_ID = @D1 And FYear=@FYear) " +
                              "OR (Tbl_AccountingRestriction.Restriction_NO = @D AND AccountingRestrictionKind_ID = @D2 And FYear=@FYear)";

            cmd.Parameters.AddWithValue("@D", Restriction_NO.Text);
            cmd.Parameters.AddWithValue("@D1", x);
            cmd.Parameters.AddWithValue("@D2", y);
            cmd.Parameters.AddWithValue("@FYear", comboBox3.SelectedValue.ToString());
            //***************


            //try
            //{
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                dateTimePicker1.Value = Convert.ToDateTime(rdr.GetValue(0).ToString());
                Lyear.Text = rdr.GetValue(1).ToString();
            }

            rdr.Close();
            con.Close();


            con.Close();
            GetAssayes();
            GetProjects();
            Getex();
            GetMan();
            GetUsf();
            Getcate();
            GetHand();
            GetRespon();
            if (dataGridView1.Rows.Count > 0)
            {

                this.CategortID.TextChanged += CategortID_TextChanged;
            }

            //}
        }
        private void Searching()
        {
            CleareControls();
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            dataGridView1.Rows.Clear();

            // SQL query
            string query = @"SELECT Row_No as [م], 
                                    Tbl_Accounting_Guid.Account_NO as [رقم الحساب],
                                    Tbl_Accounting_Guid.Name as [اسم الحساب],
                                    Debit_Value AS [مدين],
                                    Credit_Value AS [دائن],
                                    Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID as [اليومية],
                                    Tbl_AccountingRestrictionItems.Accounting_Guid_ID,
                                    Tbl_Activities.Name as [النشاط],
                                    Tbl_Activities.ID,
                                    Tbl_RestrictionItemsCategory.Name as [التصنيف],
                                    Tbl_RestrictionItemsCategory.ID,
                                    Tbl_CostCenters.Name,
                                    Tbl_AccountingRestrictionItems.CostCenters_ID,
                                    Tbl_AccountingRestrictionItems.ID,
                                    Tbl_AccountingRestrictionItems.AccountingRestriction_ID,
                                    Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID,
                                    Tbl_Accounting_Guid.BrokerAccount,
                                    HighamountsAccount,
                                    PersonalAccount,OutCheque
                            FROM Tbl_AccountingRestrictionItems
                            INNER JOIN Tbl_AccountingRestriction ON Tbl_AccountingRestrictionItems.AccountingRestriction_ID = Tbl_AccountingRestriction.ID
                            INNER JOIN Tbl_Accounting_Guid ON Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID
                            INNER JOIN Tbl_AccountingRestrictions_Kind ON Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID
                            LEFT JOIN Tbl_Activities ON Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID
                            LEFT JOIN Tbl_RestrictionItemsCategory ON Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID
                            LEFT JOIN Tbl_CostCenters ON Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID
                            WHERE Tbl_AccountingRestriction.Restriction_NO = @D 
                            AND Tbl_AccountingRestrictions_Kind.id IN (@D2, @D3) 
                            AND FYear = @FY
                            ORDER BY Tbl_AccountingRestrictions_Kind.ID,Row_No ASC";

            // Parameters
            string restrictionNo = Restriction_NO.Text;
            int d2 = x; // Assuming you have an int value for D2
            int d3 = y; // Assuming you have an int value for D3
            int fYear = Convert.ToInt32(comboBox3.SelectedValue); // Assuming you have an int value for FY

            // Establish connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@D", restrictionNo);
                    command.Parameters.AddWithValue("@D2", d2);
                    command.Parameters.AddWithValue("@D3", d3);
                    command.Parameters.AddWithValue("@FY", fYear);

                    // Open connection
                    connection.Open();

                    // Execute query
                    using (SqlDataReader red = command.ExecuteReader())
                    {
                        // Check if there are any rows returned
                        if (red.HasRows)
                        {
                            // Loop through each row
                            while (red.Read())
                            {

                                dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8), red.GetValue(9), red.GetValue(10), red.GetValue(11), red.GetValue(12), red.GetValue(13), red.GetValue(14), 0, 0, 0, 0, 0, 0, red.GetValue(5), red.GetValue(16), red.GetValue(17), red.GetValue(18), red.GetValue(19));

                                // Access other columns similarly
                            }
                        }

                        else
                        {

                        }
                        red.Close();
                    }

                    connection.Close();
                }
            }
            if (dataGridView1.Rows.Count > 1)
            {
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[3].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[4].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                textBox1.Text = dataGridView1.Rows.Count.ToString();
                double xx1, yy1, zz1;
                xx1 = Convert.ToDouble(tD.Text);
                yy1 = Convert.ToDouble(tC.Text);
                zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                df.Text = Convert.ToString(zz1);


                string s = (from DataGridViewRow row in dataGridViewX2.Rows
                            where row.Cells[2].FormattedValue.ToString() != string.Empty
                            select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
                string f = (from DataGridViewRow row in dataGridViewX2.Rows
                            where row.Cells[3].FormattedValue.ToString() != string.Empty
                            select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

                double xx, yy, zz;
                xx = Convert.ToDouble(s);
                yy = Convert.ToDouble(f);
                zz = Convert.ToDouble(s) - Convert.ToDouble(f);
                TTT.Text = Convert.ToString(zz);
            }



            GetDocumentData();
            GetOrdersIDDocument();
            BrokerAccount();


            GetManagamentBYExCenter();
            //getBanifecary();
            SearchinHeader();



        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveToDB();
        }

        private void popupContainerEdit7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Lyear_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            GetREstrictionIDForLYear();
            //}
            //catch { }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int yearNow;
                int yearNowOld;
                yearNow = int.Parse(DateTime.Today.Year.ToString());
                yearNowOld = int.Parse(DateTime.Today.Year.ToString()) - 1;
                if (dateTimePicker1.Value.Year > int.Parse(yearNow.ToString()) || dateTimePicker1.Value.Year < int.Parse(yearNowOld.ToString()))
                {
                    MessageBox.Show("تاريخ اليومية خارج نطاق العام المالى برجاء التأكد من تاريخ اليومية");
                    dateTimePicker1.Value = new DateTime(yearNow, 1, 1);
                    dateTimePicker1.Focus();
                }
                else
                {
                    exCenter.Focus();
                }


            }
            if (e.KeyCode == Keys.Right)
            {
                Restriction_NO.Focus();
                Restriction_NO.SelectAll();
            }

            if (e.KeyCode == Keys.Left)
            {
                exCenter.Focus();
                exCenter.SelectAll();
            }
        }

        private void exCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DocNO.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                dateTimePicker1.Focus();

            }
            if (e.KeyCode == Keys.Left)
            {
                DocNO.Focus();
                DocNO.SelectAll();
            }
            if (e.KeyCode == Keys.Down && exCenter.Focus() == true)
            {
                try
                {
                    FindEx f = new FindEx();
                    f.ShowDialog();
                    exCenter.Text = FindEx.SelectedRow.Cells[1].Value.ToString();
                    exID.Text = FindEx.SelectedRow.Cells[0].Value.ToString();
                    GetManagamentBYExCenter();
                    if (FindEx.SelectedRow.Cells[1].Value == null)
                    {
                        exCenter.Text = DBNull.Value.ToString();
                        exID.Text = DBNull.Value.ToString();
                    }
                }
                catch { }
            }
            if (e.KeyCode == Keys.Delete && exCenter.Focus() == true)
            {
                try
                {
                    //FindDepart f = new FindDepart();
                    //f.ShowDialog();
                    exCenter.Text = DBNull.Value.ToString();
                    exID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }

        private void DocNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DocNO.Text != string.Empty)
                {
                    DocNO2.Text = string.Empty;
                }
                DocNO2.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                exCenter.Focus();

            }
            if (e.KeyCode == Keys.Left)
            {
                DocNO2.Focus();
                DocNO2.SelectAll();
            }
        }

        private void Manag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                UsFul.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                DocNO2.Focus();
                DocNO2.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                UsFul.Focus();
                UsFul.SelectAll();
            }
            if (e.KeyCode == Keys.Down && Manag.Focus() == true)
            {
                try
                {
                    Manag.Text = null;
                    ManagID.Text = null;
                    FindDepart f = new FindDepart();
                    f.ShowDialog();

                    Manag.Text = FindDepart.SelectedRow.Cells[1].Value.ToString();
                    ManagID.Text = FindDepart.SelectedRow.Cells[0].Value.ToString();
                    //if (FindDepart.SelectedRow.Cells[1].Value == null)
                    //{
                    //    Manag.Text = DBNull.Value.ToString() ;
                    //    ManagID.Text = DBNull.Value.ToString();
                    //}
                }
                catch { }
            }
            if (e.KeyCode == Keys.Delete && Manag.Focus() == true)
            {
                try
                {
                    //FindDepart f = new FindDepart();
                    //f.ShowDialog();
                    Manag.Text = DBNull.Value.ToString();
                    ManagID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }

        private void UsFul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Empc.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                Manag.Focus();
                Manag.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                Empc.Focus();
                Empc.SelectAll();
            }
            if (e.KeyCode == Keys.Down && UsFul.Focus() == true)
            {
                try
                {


                    FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                    //f.label1.Text = "R";
                    if (FindUsefl.SelectedRow != null)
                    {
                        UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                        UsFulID.Text = FindUsefl.SelectedRow.Cells[0].Value.ToString();
                    }

                }
                catch { /*Restriction_NO.Focus(); Restriction_NO.SelectAll();*/ }

            }
            if (e.KeyCode == Keys.Delete && UsFul.Focus() == true)
            {
                try
                {

                    UsFul.Text = DBNull.Value.ToString();
                    UsFulID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }

        private void Descp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Order.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                Empc.Focus();
                Empc.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                Order.Focus();
                Order.SelectAll();
            }
            if (e.KeyCode == Keys.Down && Descp.Focused)
            {
                try
                {
                    FindCatregory f = new FindCatregory();
                    f.ShowDialog();
                    Descp.Text = FindCatregory.SelectedRow.Cells[1].Value?.ToString() ?? DBNull.Value.ToString();
                    CategortID.Text = FindCatregory.SelectedRow.Cells[0].Value?.ToString() ?? DBNull.Value.ToString();
                }
                catch { }
            }
            if (e.KeyCode == Keys.Delete && Descp.Focused)
            {
                try
                {
                    Descp.Text = DBNull.Value.ToString();
                    CategortID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }

        private void Emp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Descp.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                UsFul.Focus();
                UsFul.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                Descp.Focus();
                Descp.SelectAll();
            }
            if (e.KeyCode == Keys.Down && Empc.Focus() == true)
            {
                try
                {
                    FindHandler f = new FindHandler();
                    f.ShowDialog();
                    Empc.Text = FindHandler.SelectedRow.Cells[1].Value.ToString();
                    HandlerID.Text = FindHandler.SelectedRow.Cells[0].Value.ToString();
                    if (FindHandler.SelectedRow.Cells[1].Value == null)
                    {
                        Empc.Text = DBNull.Value.ToString();
                        HandlerID.Text = DBNull.Value.ToString();
                    }
                }
                catch { }
            }
            if (e.KeyCode == Keys.Delete && Empc.Focus() == true)
            {
                try
                {

                    Empc.Text = DBNull.Value.ToString();
                    HandlerID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }
        private void SelcectOrderUser(string Vst_OrderId)
        {


            var List = FsEvDb.SecurityEvents.Where(x => x.TableName == "Tbl_Order" && x.TableRecordId == Vst_OrderId).ToList();
            if (List.Count > 0)
            {
                textBox37.Text = "";
                foreach (var v in List)
                {
                    textBox37.Text = textBox37.Text + " - " + v.EmployeeName.ToString();
                }
            }

        }
        private void Order_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBox2.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                Descp.Focus();
                Descp.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                Respo.Focus();
                Respo.SelectAll();
            }
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    FindOrder f = new FindOrder();
                    f.ShowDialog();
                    Order.Text = FindOrder.SelectedRow.Cells[1].Value.ToString();
                    textBox7.Text = FindOrder.SelectedRow.Cells[0].Value.ToString();
                    if (textBox7.Text != "")
                    {
                        string Vst_OrderId = textBox7.Text;
                        SelcectOrderUser(Vst_OrderId);
                    }
                    comboBox2.Text = FindOrder.SelectedRow.Cells[2].Value.ToString();
                    dateTimePicker2.Text = Convert.ToDateTime(FindOrder.SelectedRow.Cells[3].Value).ToShortDateString();

                }
                catch { }
            }

            if (e.KeyCode == Keys.Delete && Order.Focus() == true)
            {
                try
                {

                    comboBox2.Text = DBNull.Value.ToString();
                    Order.Text = DBNull.Value.ToString();
                    textBox7.Text = DBNull.Value.ToString();
                    dateTimePicker2.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }

        private void Respo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox26.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                Order.Focus();
                Order.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox26.Focus();
                textBox26.SelectAll();
            }
            if (e.KeyCode == Keys.Down && Respo.Focus() == true)
            {
                try
                {
                    FindRespo f = new FindRespo();
                    f.ShowDialog();
                    Respo.Text = FindRespo.SelectedRow.Cells[1].Value.ToString();
                    RespoID.Text = FindRespo.SelectedRow.Cells[0].Value.ToString();
                    if (FindRespo.SelectedRow.Cells[1].Value == null)
                    {
                        Respo.Text = DBNull.Value.ToString();
                        RespoID.Text = DBNull.Value.ToString();
                    }
                }
                catch { }
            }

            if (e.KeyCode == Keys.Delete && Respo.Focus() == true)
            {
                try
                {
                    //FindDepart f = new FindDepart();
                    //f.ShowDialog();
                    Respo.Text = DBNull.Value.ToString();
                    RespoID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }

        private void Lyear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && checkBox9.Checked == true)
            {

                dataGridView1.Focus();


            }
            if (e.KeyCode == Keys.Enter && checkBox9.Checked == false)
            {

                Lyear.Focus();
                Lyear.SelectAll();


            }
            if (e.KeyCode == Keys.Down && Lyear.Focus() == true)
            {
                try
                {
                    FindDoc f = new FindDoc();

                    f.textBox1.Text = x.ToString();
                    f.textBox3.Text = y.ToString();
                    f.label2.Text = comboBox1.Text;
                    f.ShowDialog();
                    textBox19.Text = FindDoc.SelectedRow.Cells[3].Value.ToString();
                }
                catch { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.OrdersKindsFrm f = new BasicCodeForms.OrdersKindsFrm();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {//first
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("select top(1)Restriction_NO, LAG (Restriction_NO) OVER (ORDER BY Restriction_NO asc) from Tbl_AccountingRestriction where   AccountingRestrictionKind_ID =@D2 Or AccountingRestrictionKind_ID =@D3");
                com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {
                    Restriction_NO.Text = red.GetValue(0).ToString();
                }
                if (!red.HasRows)
                {
                    Restriction_NO.Text = "0";
                }
                red.Close();
                con.Close();
                CleareControls();
                GetREstrictionID();
                FindFileNumber1();
                GetDocumentData();
                Getex();
                GetMan();
                GetUsf();
                Getcate();
                GetHand();
                GetRespon();
                GetOrdersIDDocument();
                BrokerAccount();
                //}
            }
            catch { }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {//last
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("select top(1)Restriction_NO, LAG (Restriction_NO) OVER (ORDER BY Restriction_NO desc) from Tbl_AccountingRestriction where   AccountingRestrictionKind_ID =@D2 OR AccountingRestrictionKind_ID =@D3");
                com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                con.Open();
                red = com.ExecuteReader();

                while (red.Read())
                {
                    Restriction_NO.Text = red.GetValue(0).ToString();
                }
                if (!red.HasRows)
                {
                    Restriction_NO.Text = "0";
                }
                red.Close();
                con.Close();
                CleareControls();
                GetREstrictionID();
                FindFileNumber1();
                GetDocumentData();
                Getex();
                GetMan();
                GetUsf();
                Getcate();
                GetHand();
                GetRespon();
                GetOrdersIDDocument();
                BrokerAccount();
                //}
            }
            catch { }
        }
        private void UpdateRes()
        {
            dataGridView1.AllowUserToAddRows = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            con.Open();


            if (dataGridViewX8.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value.ToString()) > 0)
                    {
                        for (int x = 0; x < dataGridViewX8.Rows.Count; x++)
                        {
                            com.CommandText = "Update Tbl_AccountingRestrictionItems set Accounting_Guid_ID=@Accounting_Guid_ID,Debit_Value=@Debit_Value,Credit_Value=@Credit_Value,RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID,AccountingRestrictionKind_ID=@AccountingRestrictionKind_ID where ID=@ID  ";
                            com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

                            com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                            com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                            if (dataGridView1.Rows[i].Cells[10].Value == DBNull.Value || dataGridView1.Rows[i].Cells[10].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[10].Value.ToString()))
                            {
                                com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                            }
                            else
                            {
                                com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                            }



                            com.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);

                            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridViewX8.Rows[x].Cells[13].Value);
                            dataGridView1.AllowUserToAddRows = false;
                            com.ExecuteNonQuery();
                            com.Parameters.Clear();
                        }

                    }
                }
            }
            if (dataGridViewX8.Rows.Count == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value.ToString()) > 0)
                    {
                        //for (int x = 0; x < dataGridViewX8.Rows.Count; x++)
                        //{
                        com.CommandText = "Update Tbl_AccountingRestrictionItems set Accounting_Guid_ID=@Accounting_Guid_ID,Debit_Value=@Debit_Value,Credit_Value=@Credit_Value,RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID,AccountingRestrictionKind_ID=@AccountingRestrictionKind_ID where ID=@ID  ";
                        com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

                        com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                        com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        if (dataGridView1.Rows[i].Cells[10].Value == DBNull.Value || dataGridView1.Rows[i].Cells[10].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[10].Value.ToString()))
                        {
                            com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                        }
                        else
                        {
                            com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                        }



                        com.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);

                        com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value);
                        dataGridView1.AllowUserToAddRows = false;
                        com.ExecuteNonQuery();
                        com.Parameters.Clear();
                        //}

                    }
                }
            }
            //for(int i = 0; i < dataGridView1. Rows. Count; i++)
            //    {
            //    if(dataGridView1. Rows[i]. Cells[13]. Value != null && dataGridView1. Rows[i]. Cells[13]. Value != DBNull. Value && !string. IsNullOrEmpty(dataGridView1. Rows[i]. Cells[13]. Value. ToString()))
            //        {
            //        int cellValue = 0;
            //        if(int. TryParse(dataGridView1. Rows[i]. Cells[13]. Value. ToString(), out cellValue))
            //            {
            //            if(cellValue > 0)
            //                {
            //                for(int x = 0; x < dataGridView1. Rows. Count; x++)
            //                    {
            //                    com. CommandText = "Update Tbl_AccountingRestrictionItems set Accounting_Guid_ID=@Accounting_Guid_ID,Debit_Value=@Debit_Value,Credit_Value=@Credit_Value,RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID,AccountingRestrictionKind_ID=@AccountingRestrictionKind_ID where ID=@ID";
            //                    com. Parameters. Add("@Accounting_Guid_ID", SqlDbType. Int). Value = Convert. ToInt32(dataGridView1. Rows[i]. Cells[6]. Value);
            //                    com. Parameters. Add("@Debit_Value", SqlDbType. Decimal). Value = Convert. ToDecimal(dataGridView1. Rows[i]. Cells[3]. Value);
            //                    com. Parameters. Add("@Credit_Value", SqlDbType. Decimal). Value = Convert. ToDecimal(dataGridView1. Rows[i]. Cells[4]. Value);

            //                    if(dataGridView1. Rows[i]. Cells[10]. Value == DBNull. Value || dataGridView1. Rows[i]. Cells[10]. Value == null || string. IsNullOrEmpty(dataGridView1. Rows[i]. Cells[10]. Value. ToString()))
            //                        {
            //                        com. Parameters. Add("@RestrictionItemsCategory_ID", SqlDbType. Int). Value = DBNull. Value;
            //                        }
            //                    else
            //                        {
            //                        com. Parameters. Add("@RestrictionItemsCategory_ID", SqlDbType. Int). Value = Convert. ToInt32(dataGridView1. Rows[i]. Cells[10]. Value);
            //                        }

            //                    com. Parameters. Add("@AccountingRestrictionKind_ID", SqlDbType. Int). Value = Convert. ToInt32(dataGridView1. Rows[i]. Cells[5]. Value);
            //                    com. Parameters. Add("@ID", SqlDbType. Int). Value = Convert. ToInt32(dataGridViewX8. Rows[x]. Cells[13]. Value);

            //                    com. ExecuteNonQuery();
            //                    com. Parameters. Clear();
            //                    }
            //                }
            //            }
            //        else
            //            {
            //            // يمكنك إضافة رسالة خطأ هنا في حالة فشل تحويل القيمة إلى int
            //            }
            //        }
            //    }
            // Clear parameters after use if needed

            con.Close();

            dataGridViewX8.Rows.Clear();
            UpdateRestrictionDocConnect();
            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            textBox1.Text = dataGridView1.Rows.Count.ToString();
            double xx, yy, zz;
            xx = Convert.ToDouble(tD.Text);
            yy = Convert.ToDouble(tC.Text);
            zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            df.Text = Convert.ToString(zz);
            LoadSerial();

        }

        private void UpdateRes1()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            con.Open();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                com.CommandText = ("Update Tbl_AccountingRestrictionItems set Accounting_Guid_ID=@Accounting_Guid_ID,Debit_Value=@Debit_Value,Credit_Value=@Credit_Value,RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID,Activities_ID=@Activities_ID ,CostCenters_ID=@CostCenters_ID where ID=@ID   ");
                com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

                com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                if (dataGridView1.Rows[i].Cells[10].Value != DBNull.Value)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[10].Value);
                }
                if (dataGridView1.Rows[i].Cells[10].Value == DBNull.Value)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (dataGridView1.Rows[i].Cells[8].Value != DBNull.Value)
                {
                    com.Parameters.Add("@Activities_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                }
                if (dataGridView1.Rows[i].Cells[8].Value == DBNull.Value)
                {
                    com.Parameters.Add("@Activities_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (dataGridView1.Rows[i].Cells[12].Value != DBNull.Value)
                {
                    com.Parameters.Add("@CostCenters_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                }
                if (dataGridView1.Rows[i].Cells[12].Value == DBNull.Value)
                {
                    com.Parameters.Add("@CostCenters_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                com.Parameters.Add("@ID", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells[13].Value;


                com.ExecuteNonQuery();
                com.Parameters.Clear();
            }
            con.Close();
            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            textBox1.Text = dataGridView1.Rows.Count.ToString();
            double xx, yy, zz;
            xx = Convert.ToDouble(tD.Text);
            yy = Convert.ToDouble(tC.Text);
            zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            df.Text = Convert.ToString(zz);
            LoadSerial();

            FindFileNumber1();
            GetDocumentData();

        }
        private void UpdateDocument()
        {
            if (CategortID.Text != string.Empty)
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show(" هل أنت متأكد من تعديل البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

                    SqlCommand com = new SqlCommand();
                    SqlCommand com1 = new SqlCommand();
                    com.CommandType = CommandType.Text;
                    com1.CommandType = CommandType.Text;
                    SqlDataReader red;
                    com.Connection = con;
                    con.Open();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        com.CommandText = ("Update Tbl_AccountingRestrictionItems set Accounting_Guid_ID=@Accounting_Guid_ID,Debit_Value=@Debit_Value,Credit_Value=@Credit_Value,RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID,Activities_ID=@Activities_ID ,CostCenters_ID=@CostCenters_ID where ID=@ID   ");
                        com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);

                        com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                        com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        if (dataGridView1.Rows[i].Cells[10].Value != DBNull.Value)
                        {
                            com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt64(dataGridView1.Rows[i].Cells[10].Value);
                        }
                        if (dataGridView1.Rows[i].Cells[10].Value == DBNull.Value)
                        {
                            com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                        }
                        if (dataGridView1.Rows[i].Cells[8].Value != DBNull.Value)
                        {
                            com.Parameters.Add("@Activities_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                        }
                        if (dataGridView1.Rows[i].Cells[8].Value == DBNull.Value)
                        {
                            com.Parameters.Add("@Activities_ID", SqlDbType.Int).Value = DBNull.Value;
                        }
                        if (dataGridView1.Rows[i].Cells[12].Value != DBNull.Value)
                        {
                            com.Parameters.Add("@CostCenters_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value);
                        }
                        if (dataGridView1.Rows[i].Cells[12].Value == DBNull.Value)
                        {
                            com.Parameters.Add("@CostCenters_ID", SqlDbType.Int).Value = DBNull.Value;
                        }
                        com.Parameters.Add("@ID", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells[13].Value;


                        com.ExecuteNonQuery();
                        com.Parameters.Clear();
                    }
                    con.Close();
                    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[3].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[4].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                    textBox1.Text = dataGridView1.Rows.Count.ToString();
                    double xx, yy, zz;
                    xx = Convert.ToDouble(tD.Text);
                    yy = Convert.ToDouble(tC.Text);
                    zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                    df.Text = Convert.ToString(zz);
                    LoadSerial();
                    MessageBox.Show("تم تعديل  بند القيد بنجاح");
                    FindFileNumber1();
                    GetDocumentData();
                }
            }
            if (CategortID.Text == string.Empty)
            {
                MessageBox.Show("من فضلك أختر البيان أولا");
            }
        }

        private void UpdateHeader()
        {
            //if (!string.IsNullOrEmpty(CategortID.Text))
            //{
            if (CategortID.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        com.CommandType = CommandType.Text;
                        com.Connection = con;
                        con.Open();
                        com.CommandText = "UPDATE TBL_Document SET DocumentCategory_ID = @DocumentCategory_ID, Beneficiary_ID = @Beneficiary_ID, ExchangeCenter_ID = @ExchangeCenter_ID, Order_ID = @Order_ID, Handler_ID = @Handler_ID, Management_ID = @Management_ID, responspilityID = @responspilityID, Document_NO = @Document_NO, Assays_ID = @Assays_ID, Projects_ID = @Projects_ID ,Salary_NO=@Salary_NO WHERE ID = @ID";

                        com.Parameters.Add("@DocumentCategory_ID", SqlDbType.Int).Value = string.IsNullOrEmpty(CategortID.Text) ? DBNull.Value : (object)Convert.ToInt32(CategortID.Text);
                        com.Parameters.Add("@Beneficiary_ID", SqlDbType.Int).Value = string.IsNullOrEmpty(UsFulID.Text) ? DBNull.Value : (object)Convert.ToInt32(UsFulID.Text);
                        com.Parameters.Add("@ExchangeCenter_ID", SqlDbType.Int).Value = string.IsNullOrEmpty(exID.Text) ? DBNull.Value : (object)Convert.ToInt32(exID.Text);
                        com.Parameters.Add("@Order_ID", SqlDbType.Int).Value = string.IsNullOrEmpty(textBox7.Text) ? DBNull.Value : (object)Convert.ToInt32(textBox7.Text);
                        com.Parameters.Add("@Handler_ID", SqlDbType.Int).Value = string.IsNullOrEmpty(HandlerID.Text) ? DBNull.Value : (object)Convert.ToInt32(HandlerID.Text);
                        com.Parameters.Add("@Management_ID", SqlDbType.Int).Value = string.IsNullOrEmpty(ManagID.Text) ? DBNull.Value : (object)Convert.ToInt32(ManagID.Text);
                        com.Parameters.Add("@responspilityID", SqlDbType.Int).Value = string.IsNullOrEmpty(RespoID.Text) ? DBNull.Value : (object)Convert.ToInt32(RespoID.Text);
                        com.Parameters.Add("@Document_NO", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(DocNO.Text) ? DBNull.Value : (object)DocNO.Text;
                        com.Parameters.Add("@Assays_ID", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(assaysID.Text) ? DBNull.Value : (object)assaysID.Text;
                        com.Parameters.Add("@Projects_ID", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(ProjectID.Text) ? DBNull.Value : (object)ProjectID.Text;
                        com.Parameters.Add("@Salary_NO", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(DocNO2.Text) ? DBNull.Value : (object)DocNO2.Text;
                        com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox10.Text);

                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
                UpdateRestriction();
            }
            if (CategortID.Text == string.Empty)
            {
                MessageBox.Show("من فضلك أختر البيان أولا");
            }

        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (dataGridView1.Rows.Count > 0 && checkBox8.Checked == false)
            {
                if (dateTimePicker1.Value >= dateTimePicker3.Value || dateTimePicker1.Value <= dateTimePicker4.Value)
                {

                    //MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");

                    dataGridView1.AllowUserToAddRows = false;


                    UpdateHeader();
                    UpdateRes();
                    FindFileNumber1();
                    GetDocumentData();
                    try
                    {//next
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                        SqlCommand com = new SqlCommand();
                        SqlCommand com1 = new SqlCommand();
                        com.CommandType = CommandType.Text;
                        com1.CommandType = CommandType.Text;
                        SqlDataReader red;
                        com.Connection = con;
                        com.CommandText = ("select top(1) Restriction_NO, LAG(Restriction_NO) OVER ( ORDER BY Restriction_NO) from Tbl_AccountingRestriction where Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D2 OR Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D3     ");
                        com.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Restriction_NO.Text;
                        com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                        com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                        con.Open();
                        red = com.ExecuteReader();

                        while (red.Read())
                        {
                            Restriction_NO.Text = red.GetValue(0).ToString();
                        }
                        if (!red.HasRows)
                        {
                            Restriction_NO.Text = "0";
                        }
                        red.Close();
                        con.Close();
                        CleareControls();
                        GetREstrictionID();
                        FindFileNumber1();
                        GetDocumentData();
                        Getex();
                        GetMan();
                        GetUsf();
                        Getcate();
                        GetHand();
                        GetRespon();
                        GetOrdersIDDocument();
                        BrokerAccount();
                        Restriction_NO.Focus();
                    }
                    catch { }
                    //FindFileNumber1();
                    //GetDocumentData();
                }
            }
            if (checkBox8.Checked == true)
            {
                MessageBox.Show("العام المالى تم إغلاقة ولا يمكنك التعديل علية");
            }
            //if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
            //{

            //    MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
            //}
            //}
            //catch { MessageBox.Show("من فضلك أضغط حفظ للإضافة وليس التعديل"); }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show(" هل أنت متأكد من حذف البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes && checkBox8.Checked == false)
            {
                if (dateTimePicker1.Value >= dateTimePicker3.Value || dateTimePicker1.Value <= dateTimePicker4.Value)
                {

                    //MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                    SqlCommand com = new SqlCommand();
                    SqlCommand com1 = new SqlCommand();
                    com.CommandType = CommandType.Text;
                    com1.CommandType = CommandType.Text;
                    SqlDataReader red;
                    com.Connection = con;

                    com.CommandText = ("delete from Tbl_AccountingRestrictionItems  where ID=@ID   ");

                    com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
                    con.Open();

                    com.ExecuteNonQuery();
                    con.Close();
                    //}
                    //FindFileNumber();
                    //if (dataGridView1.Rows.Count == 0)
                    //{
                    FindFileNumber1();
                    GetDocumentData();
                    //}
                    MessageBox.Show("تم حذف  بند القيد بنجاح");

                    //if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count)
                    //{

                    //    dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Selected = true;

                }





                //}


            }
            if (checkBox8.Checked == true)
            {
                MessageBox.Show("العام المالى تم إغلاقة ولا يمكنك التعديل علية");
            }
            if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
            {

                MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Restriction_NO.Text = "0";
            FindFileNumber1();
            GetDocumentData();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Rows.Clear();
            dataGridViewX2.Rows.Clear();
            // MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
            CaDebit.Text = "0";
            CaCridit.Text = "0";
            CaTolt.Text = "0";
            PrDebit.Text = "0";
            Prcridit.Text = "0";
            Prcridit.Text = "0";
            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            textBox1.Text = dataGridView1.Rows.Count.ToString();
            double xx1, yy1, zz1;
            xx1 = Convert.ToDouble(tD.Text);
            yy1 = Convert.ToDouble(tC.Text);
            zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            df.Text = Convert.ToString(zz1);
            Restriction_NO.Focus();
        }
        public void SaveDocument()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            //try
            //{

            if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0)
            {
                com1.Parameters.Clear();
                com1.CommandText = " Insert Into TBL_Document (DocumentCategory_ID,Beneficiary_ID,ExchangeCenter_ID,Order_ID,Handler_ID,Document_NO,Management_ID,responspilityID,Restriction_NO,AccountingRestrictionKind_ID) Values(@DocumentCategory_ID,@Beneficiary_ID,@ExchangeCenter_ID,@Order_ID,@Handler_ID,@Document_NO,@Management_ID,@responspilityID,@Restriction_NO,@AccountingRestrictionKind_ID) ";


                //if (com1.Parameters.Add("@DocumentCategory_ID", SqlDbType.Int).Value != DBNull.Value)
                //{
                if (CategortID.Text != string.Empty)
                {
                    com1.Parameters.Add("@DocumentCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(CategortID.Text);
                }
                if (CategortID.Text == string.Empty)
                {
                    com1.Parameters.Add("@DocumentCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                //if (com1.Parameters.Add("@DocumentCategory_ID", SqlDbType.Int).Value == DBNull.Value)
                //{
                //    com1.Parameters.Add("@DocumentCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                //}

                if (UsFulID.Text == string.Empty)
                {
                    com1.Parameters.Add("@Beneficiary_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (UsFulID.Text != string.Empty)
                {
                    com1.Parameters.Add("@Beneficiary_ID", SqlDbType.Int).Value = Convert.ToInt32(UsFulID.Text);
                }
                if (exID.Text != string.Empty)
                {
                    com1.Parameters.Add("@ExchangeCenter_ID", SqlDbType.Int).Value = Convert.ToInt32(exID.Text);
                }
                if (exID.Text == string.Empty)
                {
                    com1.Parameters.Add("@ExchangeCenter_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (textBox7.Text == string.Empty)
                {
                    com1.Parameters.Add("@Order_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (textBox7.Text != string.Empty)
                {
                    com1.Parameters.Add("@Order_ID", SqlDbType.Int).Value = Convert.ToInt32(textBox7.Text);
                }
                if (HandlerID.Text != string.Empty)
                {
                    com1.Parameters.Add("@Handler_ID", SqlDbType.Int).Value = Convert.ToInt32(HandlerID.Text);
                }
                if (HandlerID.Text == string.Empty)
                {
                    com1.Parameters.Add("@Handler_ID", SqlDbType.Int).Value = DBNull.Value;
                }

                if (DocNO.Text != string.Empty)
                {
                    com1.Parameters.AddWithValue("@Document_NO", SqlDbType.NVarChar).Value = DocNO.Text;
                }
                if (DocNO.Text == string.Empty)
                {
                    com1.Parameters.AddWithValue("@Document_NO", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (ManagID.Text != string.Empty)
                {
                    com1.Parameters.Add("@Management_ID", SqlDbType.Int).Value = Convert.ToInt32(ManagID.Text);
                }
                if (ManagID.Text == string.Empty)
                {
                    com1.Parameters.Add("@Management_ID", SqlDbType.Int).Value = DBNull.Value;
                }


                if (RespoID.Text == string.Empty)
                {
                    com1.Parameters.Add("@responspilityID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (RespoID.Text != string.Empty)
                {
                    com1.Parameters.Add("@responspilityID", SqlDbType.Int).Value = Convert.ToInt32(RespoID.Text);
                }


                com1.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
                com1.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = x;

                con.Open();
                com1.ExecuteNonQuery();
                con.Close();
                GetDocumentData();
            }
        }
        public void PresessingSaveBtn()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand comDoc = new SqlCommand();
            SqlCommand comRest = new SqlCommand();

            com.Connection = con;
            com.CommandType = CommandType.Text;
            comDoc.Connection = con;
            comDoc.CommandType = CommandType.Text;

            comRest.Connection = con;
            comRest.CommandType = CommandType.Text;

            comDoc.Parameters.Clear();
            con.Open();
            SqlTransaction Tran = con.BeginTransaction();
            try
            {
                if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0)
                {

                    com.Transaction = Tran;
                    comDoc.Transaction = Tran;
                    comRest.Transaction = Tran;
                    //save Document 
                    comDoc.CommandText = " Insert Into TBL_Document (DocumentCategory_ID,Beneficiary_ID,ExchangeCenter_ID,Order_ID,OrderHandler_ID,Document_NO) Values(@DocumentCategory_ID,@Beneficiary_ID,@ExchangeCenter_ID,@Order_ID,@OrderHandler_ID,@Document_NO) ";
                    comDoc.Parameters.Add("@DocumentCategory_ID", SqlDbType.Int).Value = Descp.SelectedValue;
                    comDoc.Parameters.Add("@Beneficiary_ID", SqlDbType.Int).Value = UsFul.SelectedValue;
                    comDoc.Parameters.Add("@ExchangeCenter_ID", SqlDbType.Int).Value = exCenter.SelectedValue;
                    comDoc.Parameters.Add("@Order_ID", SqlDbType.Int).Value = Convert.ToInt32(textBox7.Text);
                    comDoc.Parameters.Add("@OrderHandler_ID", SqlDbType.Int).Value = Empc.SelectedValue;
                    comDoc.Parameters.AddWithValue("@Document_NO", SqlDbType.Int).Value = DocNO.Text;


                    comDoc.ExecuteNonQuery();
                    GetDocID();
                    //Save Restrection
                    comRest.CommandText = "Insert Into Tbl_AccountingRestriction (Restriction_NO,Restriction_Date,Document_ID,AccountingRestrictionKind_ID) Values(@Restriction_NO,@Restriction_Date,@Document_ID,@AccountingRestrictionKind_ID)";
                    comRest.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
                    comRest.Parameters.Add("@Restriction_Date", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                    comRest.Parameters.Add("@Document_ID", SqlDbType.Int).Value = Convert.ToInt32(textBox10.Text);
                    comRest.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = comboBox1.SelectedValue;
                    comRest.ExecuteNonQuery();
                    //Save Restrection Items 
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        dataGridView1.AllowUserToAddRows = false;
                        bool isSelected = Convert.ToBoolean(row.Cells["Column21"].Value);
                        if (isSelected)
                        {
                            com.Parameters.Clear();
                            //***************************
                            if (textEdit2.Text != null)
                            {
                                row.Cells[14].Value = textEdit2.Text;
                            }
                            if (textEdit2.Text == null)
                            {
                                row.Cells[14].Value = textBox5.Text;
                            }
                            row.Cells[14].Value = textBox5.Text;

                            com.CommandText = ("Insert Into Tbl_AccountingRestrictionItems(Row_No,AccountingRestriction_ID,Accounting_Guid_ID,Debit_Value,Credit_Value,RestrictionItemsCategory_ID) values(@Row_No,@AccountingRestriction_ID,@Accounting_Guid_ID,@Debit_Value,@Credit_Value,@RestrictionItemsCategory_ID)");
                            com.Parameters.Add("@Row_No", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[0].Value);
                            com.Parameters.Add("@AccountingRestriction_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[14].Value);
                            com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                            com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[3].Value);
                            com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[4].Value);
                            if (row.Cells[10].Value == null)
                            {
                                com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                            }
                            if (row.Cells[10].Value != null)
                            {
                                com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                            }
                            com.ExecuteNonQuery();
                            con.Close();
                        }

                    }
                    DT.Clear();
                    Tran.Commit();
                    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[3].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[4].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                    textBox1.Text = dataGridView1.Rows.Count.ToString();
                    double xx, yy, zz;
                    xx = Convert.ToDouble(tD.Text);
                    yy = Convert.ToDouble(tC.Text);
                    zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                    df.Text = Convert.ToString(zz);
                    //textEdit1.Text = GenerateID().ToString();
                    //Restriction_NO.Text = "0";
                    Restriction_NO.Focus();
                    Restriction_NO.Select();
                    //UpdateRes1();
                    MessageBox.Show("تم حفظ المستند بنجاح", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleareControls();
                    GetREstrictionID();
                    FindFileNumber1();
                    GetDocumentData();

                }

                //}
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch
            {
                //Tran.Rollback();
                MessageBox.Show("تم إرجاع القيد وعدم حفظة ");
            }
            con.Close();
        }
        //}
        public void GetDocID()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();



            string query = "SELECT ID FROM TBL_Document WHERE Restriction_NO = @P AND AccountingRestrictionKind_ID = @P1";


            string restrictionNo = Restriction_NO.Text;
            int accountingRestrictionKindId = x;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {



                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@P", restrictionNo);
                    command.Parameters.AddWithValue("@P1", accountingRestrictionKindId);


                    connection.Open();
                    SqlDataReader red = command.ExecuteReader();

                    while (red.Read())
                    {
                        textBox10.Text = red.GetValue(0).ToString();
                    }
                    red.Close();
                    connection.Close();
                }
            }
        }

        public void GetDocumentData()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            SqlDataReader red1;
            //try
            //{

            com1.CommandText = "Select TBL_Document.ID,DocumentCategory_ID,Beneficiary_ID,ExchangeCenter_ID,Order_ID,Handler_ID,Document_NO,TBL_Document.Management_ID,responspilityID,Assays_ID,Projects_ID,Salary_NO From TBL_Document left join Tbl_AccountingRestriction on Tbl_AccountingRestriction.Document_ID =TBL_Document.ID  Where Tbl_AccountingRestriction.Restriction_NO=@P and Tbl_AccountingRestriction.AccountingRestrictionKind_ID=@P1 and Tbl_AccountingRestriction.FYear=@FY OR Tbl_AccountingRestriction.Restriction_NO=@P and Tbl_AccountingRestriction.AccountingRestrictionKind_ID=@P2 and Tbl_AccountingRestriction.FYear=@FY   ";

            com1.Parameters.Add("@P", SqlDbType.Int).Value = Restriction_NO.Text;
            com1.Parameters.Add("@P1", SqlDbType.Int).Value = x;
            com1.Parameters.Add("@P2", SqlDbType.Int).Value = y;
            com1.Parameters.Add("@FY", SqlDbType.NVarChar).Value = comboBox3.SelectedValue;
            con.Open();
            red = com1.ExecuteReader();

            while (red.Read())
            {
                textBox10.Text = red.GetValue(0).ToString();
                CategortID.Text = red.GetValue(1).ToString();
                textBox11.Text = red.GetValue(1).ToString();
                UsFulID.Text = red.GetValue(2).ToString();
                exID.Text = red.GetValue(3).ToString();
                textBox7.Text = red.GetValue(4).ToString();
                HandlerID.Text = red.GetValue(5).ToString();
                DocNO.Text = red.GetValue(6).ToString();
                ManagID.Text = red.GetValue(7).ToString();
                RespoID.Text = red.GetValue(8).ToString();
                assaysID.Text = red.GetValue(9).ToString();
                ProjectID.Text = red.GetValue(10).ToString();
                DocNO2.Text = red.GetValue(11).ToString();
            }
            red.Close();
            //com.CommandText = "select name from Tbl_DocumentCategory where id = @id";
            //com.Parameters.Add("@id", SqlDbType.Int).Value = textBox11.Text;
            //red1 = com.ExecuteReader();
            //while (red1.Read())
            //{
            //    Descp.Items.Add(red1.GetValue(0)).ToString();

            //}
            //red1.Close();
            con.Close();

        }
        public void CleareControls()
        {
            // Resetting controls to default or empty values
            UseFULL_Kind.Text = DBNull.Value.ToString(); // Resets the text of UseFULL_Kind to the string representation of DBNull.Value
            textBox19.Text = DBNull.Value.ToString();    // Resets the text of textBox19 to the string representation of DBNull.Value
            textBox10.Text = string.Empty;
            textBox5.Text = string.Empty;// Clears the text of textBox10
            CategortID.Text = "";                        // Clears the text of CategortID
            UsFulID.Text = "";                           // Clears the text of UsFulID
            exID.Text = "";                              // Clears the text of exID
            textBox7.Text = DBNull.Value.ToString();     // Resets the text of textBox7 to the string representation of DBNull.Value
            HandlerID.Text = "";                         // Clears the text of HandlerID
            DocNO.Text = "";
            DocNO2.Text = "";
            // Clears the text of DocNO
            RespoID.Text = "";                           // Clears the text of RespoID
            Respo.Text = "";                             // Clears the text of Respo
            ManagID.Text = "";                           // Clears the text of ManagID
            ProjectID.Text = DBNull.Value.ToString();    // Resets the text of ProjectID to the string representation of DBNull.Value
            assaysID.Text = DBNull.Value.ToString();     // Resets the text of assaysID to the string representation of DBNull.Value
            textBox26.Text = "";                         // Clears the text of textBox26
            textBox28.Text = "";                         // Clears the text of textBox28
            Order.Text = "";                             // Clears the text of Order
            comboBox2.Text = "";                         // Clears the text of comboBox2
            dateTimePicker2.Text = "";
            comboBox2.Text = DBNull.Value.ToString();                         // Clears the text of comboBox2
            dateTimePicker2.Text = DBNull.Value.ToString();
            Lyear.Text = DBNull.Value.ToString();
            textBox19.Text = "";
            // Clears the text of dateTimePicker2
        }
        public void GetOrderID()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            //try
            //{

            com1.CommandText = "Select ID From Tbl_Order Where OrderKind_ID=@P and  Order_NO=@P1 and Order_Date=@P2 ";

            com1.Parameters.Add("@P", SqlDbType.Int).Value = Order.SelectedValue;
            com1.Parameters.Add("@P1", SqlDbType.Int).Value = Convert.ToInt32(textBox6.Text);
            com1.Parameters.Add("@P2", SqlDbType.Date).Value = Convert.ToDateTime(dateTimePicker2.Text).ToShortDateString();

            con.Open();
            red = com1.ExecuteReader();
            while (red.Read())
            {

                textBox7.Text = red.GetValue(0).ToString();

            }
            red.Close();
            con.Close();

        }
        public void UpdateRestrictionDocConnect()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            //try
            //{
            if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDouble(df.Text) == 0)
            {
                com1.CommandText = "Update Tbl_AccountingRestriction set AcountingRestrictionCorrRelation_ID = @P where Restriction_NO=@p1 and AccountingRestrictionKind_ID=@p2 OR Restriction_NO=@p1 and AccountingRestrictionKind_ID=@p3";

                if (Lyear.Text != string.Empty)
                {
                    com1.Parameters.Add("@P", SqlDbType.Int).Value = Convert.ToInt32(Lyear.Text);
                }
                if (Lyear.Text == string.Empty)
                {
                    com1.Parameters.Add("@P", SqlDbType.Int).Value = DBNull.Value;
                }
                com1.Parameters.Add("@p1", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
                com1.Parameters.Add("@p2", SqlDbType.Int).Value = x;
                com1.Parameters.Add("@p3", SqlDbType.Int).Value = y;
                con.Open();

                com1.ExecuteNonQuery();
                con.Close();
            }
            //}
            //catch { }
        }
        public void UpdateRestriction()
        {
            if (string.IsNullOrEmpty(Restriction_NO.Text) || Convert.ToInt32(Restriction_NO.Text) <= 0 || Convert.ToDecimal(df.Text) != 0)
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                using (SqlCommand com1 = new SqlCommand())
                {
                    com1.Connection = con;
                    com1.CommandType = CommandType.Text;

                    if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0)
                    {
                        com1.CommandText = "UPDATE Tbl_AccountingRestriction SET Restriction_Date = @P , Document_ID=@D WHERE Restriction_NO = @p1 AND AccountingRestrictionKind_ID = @p2 AND FYear = @Year";

                        com1.Parameters.Add("@P", SqlDbType.Date).Value = dateTimePicker1.Value;
                        com1.Parameters.Add("@D", SqlDbType.Int).Value = Convert.ToInt32(textBox10.Text);
                        com1.Parameters.Add("@p1", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
                        com1.Parameters.Add("@p2", SqlDbType.Int).Value = x;
                        com1.Parameters.Add("@Year", SqlDbType.Int).Value = comboBox3.SelectedValue;


                        con.Open();
                        com1.ExecuteNonQuery();

                        con.Close();

                    }
                }
            }
        }
        public void SaveRestrictionFirtTime()//لحجز ID لرقم المستند
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            //try
            //{
            //if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0)
            //{
            com1.CommandText = "Insert Into Tbl_AccountingRestriction (Restriction_NO,Restriction_Date,Document_ID,AccountingRestrictionKind_ID,FYear) Values(@Restriction_NO,@Restriction_Date,@Document_ID,@AccountingRestrictionKind_ID,@FYear)";
            com1.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
            com1.Parameters.Add("@Restriction_Date", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
            com1.Parameters.Add("@Document_ID", SqlDbType.Int).Value = Convert.ToInt32(textBox10.Text);
            com1.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = x;
            com1.Parameters.Add("@FYear", SqlDbType.NVarChar).Value = comboBox3.SelectedValue;
            con.Open();

            com1.ExecuteNonQuery();
            con.Close();
        }
        public void SaveRestriction()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //try
                //{
                if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0)
                {
                    com1.CommandText = "Insert Into Tbl_AccountingRestriction (Restriction_NO,Restriction_Date,Document_ID,AccountingRestrictionKind_ID,AcountingRestrictionCorrRelation_ID,FYear) Values(@Restriction_NO,@Restriction_Date,@Document_ID,@AccountingRestrictionKind_ID,@AcountingRestrictionCorrRelation_ID,@FYear)";
                    com1.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
                    com1.Parameters.Add("@Restriction_Date", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                    com1.Parameters.Add("@Document_ID", SqlDbType.Int).Value = Convert.ToInt32(textBox10.Text);
                    com1.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = x;
                    com1.Parameters.Add("@FYear", SqlDbType.NVarChar).Value = comboBox3.SelectedValue;
                    if (Lyear.Text != string.Empty)
                    {
                        com1.Parameters.Add("@AcountingRestrictionCorrRelation_ID", SqlDbType.Int).Value = Convert.ToInt32(Lyear.Text);
                    }
                    if (Lyear.Text == string.Empty)
                    {
                        com1.Parameters.Add("@AcountingRestrictionCorrRelation_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    con.Open();

                    com1.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch { }
        }
        public void saveToDB()
        {
            progressBar1.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dataGridView1.Rows.Count;
            progressBar1.Value = 0; // Start with 0 progress

            int selectedRowCount = 0;
            dataGridView1.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Column21"].Value);
                if (isSelected)
                {
                    selectedRowCount++;

                    com.Parameters.Clear();
                    row.Cells[14].Value = textBox5.Text;
                    com.CommandText = ("Insert Into Tbl_AccountingRestrictionItems(Row_No,AccountingRestriction_ID,Accounting_Guid_ID,Debit_Value,Credit_Value,RestrictionItemsCategory_ID,AccountingRestrictionKind_ID) values(@Row_No,@AccountingRestriction_ID,@Accounting_Guid_ID,@Debit_Value,@Credit_Value,@RestrictionItemsCategory_ID,@AccountingRestrictionKind_ID)");
                    com.Parameters.Add("@Row_No", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[0].Value);
                    com.Parameters.Add("@AccountingRestriction_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[14].Value);
                    com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[3].Value);
                    com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[4].Value);

                    if (row.Cells[10].Value == DBNull.Value || row.Cells[10].Value == null)
                    {
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    else
                    {
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    }
                    com.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                    // Update the progress bar
                    progressBar1.Value++;
                    int progressPercentage = (progressBar1.Value * 100) / progressBar1.Maximum;
                    using (Graphics gr = progressBar1.CreateGraphics())
                    {
                        gr.DrawString(progressPercentage.ToString() + "%", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    }
                }
            }

            progressBar1.Visible = false;

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                dataGridView1.Rows[x].Cells[20].Value = false;
            }

            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();

            textBox1.Text = dataGridView1.Rows.Count.ToString();
            double xx, yy, zz;
            xx = Convert.ToDouble(tD.Text);
            yy = Convert.ToDouble(tC.Text);
            zz = xx - yy;
            df.Text = Convert.ToString(zz);

            SaveEvnt();
            SendNoteFromUserToSysUniteAuditing();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (CategortID.Text != string.Empty)
            {
                if (checkBox8.Checked == false)
                {
                    if (dateTimePicker1.Value >= dateTimePicker3.Value || dateTimePicker1.Value <= dateTimePicker4.Value)
                    {

                        // MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");

                        //dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.AllowUserToAddRows = false;

                        SaveDocument();
                        //PresessingSaveBtn();
                        GetDocID();
                        SaveRestriction();
                        GetREstrictionID();
                        saveToDB();
                        CleareControls();
                        //next
                        try
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                            SqlCommand com = new SqlCommand();
                            SqlCommand com1 = new SqlCommand();
                            com.CommandType = CommandType.Text;
                            com1.CommandType = CommandType.Text;
                            SqlDataReader red;
                            com.Connection = con;
                            com.CommandText = ("select top(1) Restriction_NO, LAG(Restriction_NO) OVER ( ORDER BY Restriction_NO) from Tbl_AccountingRestriction where Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D2 OR Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D3     ");
                            com.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Restriction_NO.Text;
                            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                            con.Open();
                            red = com.ExecuteReader();

                            while (red.Read())
                            {
                                Restriction_NO.Text = red.GetValue(0).ToString();
                            }
                            if (!red.HasRows)
                            {
                                Restriction_NO.Text = "0";
                            }
                            red.Close();
                            con.Close();
                            CleareControls();
                            GetREstrictionID();
                            FindFileNumber1();
                            GetDocumentData();
                            Getex();
                            GetMan();
                            GetUsf();
                            Getcate();
                            GetHand();
                            GetRespon();
                            GetOrdersIDDocument();
                        }
                        catch { }
                        //catch
                        //{
                        //    MessageBox.Show("لا توجد بنود تم اضافتها للحفظ", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                    }


                }
                if (checkBox8.Checked == true)
                {
                    MessageBox.Show("العام المالى تم إغلاقة ولا يمكنك التعديل علية");
                }

                if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
                {

                    MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
                }
            }
            if (CategortID.Text == string.Empty)
            {
                MessageBox.Show("من فضلك أختر البيان أولا");
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            GetOrderID();
        }
        private void ChexkDate()
        {
            if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
            {

                MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
            }
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }
        public DataTable RespoFill()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select top (30) ID,Name from tbl_ResponspilityCenters ");
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

        public DataTable DocumentCategory()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select top (30) ID,Name from Tbl_DocumentCategory ");
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
        public void GetOrders()
        {
            //comboBox2.Items.Clear();
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select Order_NO,Order_Date,ID from Tbl_Order where OrderKind_ID=@P ");
            if (Order.Text != string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.Int).Value = Order.SelectedValue;
            }
            if (Order.Text == string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.Int).Value = DBNull.Value;
            }
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                comboBox2.Items.Add(red.GetValue(0)).ToString();
                //textBox7.Text = red.GetValue(2).ToString();
            }
            //comboBox2.SelectedValue   = 0;
            red.Close();
            con.Close();

        }
        public void GetOrdersForPreview()
        {
            textBox13.Text = null;
            textBox14.Text = null;
            //comboBox2.Items.Clear();
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("SELECT        dbo.Tbl_Order.Order_NO, dbo.Tbl_Order.Order_Date, dbo.Tbl_Order.ID, dbo.Tbl_OrderKind.Name, dbo.TBL_Document.ID AS Expr1 FROM dbo.Tbl_Order INNER JOIN  dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID INNER JOIN  dbo.TBL_Document ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID where TBL_Document.ID=@P ");
            if (textBox10.Text != string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Convert.ToInt32(textBox10.Text);
            }
            if (textBox10.Text == string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox13.Text = red.GetValue(0).ToString();
                textBox14.Text = red.GetValue(1).ToString();
                //textBox7.Text = red.GetValue(2).ToString();
            }
            //comboBox2.SelectedValue   = 0;
            red.Close();
            con.Close();
            try
            {
                GetOrdersForPreview1();
            }
            catch { }
        }
        public void GetOrdersForPreview1()
        {
            //comboBox2.Items.Clear();
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("SELECT        dbo.Tbl_Order.Order_NO, dbo.Tbl_Order.Order_Date, dbo.Tbl_Order.ID, dbo.Tbl_OrderKind.Name, dbo.TBL_Document.ID AS Expr1 FROM dbo.Tbl_Order INNER JOIN  dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID INNER JOIN  dbo.TBL_Document ON dbo.Tbl_Order.ID = dbo.TBL_Document.Order_ID where TBL_Document.ID=@P ");
            if (textBox10.Text != string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Convert.ToInt32(textBox10.Text);
            }
            if (textBox10.Text == string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox13.Text = red.GetValue(0).ToString();
                textBox14.Text = red.GetValue(1).ToString();
                //textBox7.Text = red.GetValue(2).ToString();
            }
            //comboBox2.SelectedValue   = 0;
            red.Close();
            con.Close();

        }
        public void GetOrdersDateForPreview()
        {
            ////dateTimePicker2.Items.Clear();
            ////DataTable dt = new DataTable();
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            //SqlCommand com = new SqlCommand();
            //SqlDataReader red;
            //com.CommandType = CommandType.Text;
            //com.Connection = con;
            //com.CommandText = ("select Order_Date from Tbl_Order where Order_NO=@P ");
            //com.Parameters.Add("@P", SqlDbType.NVarChar).Value = comboBox2.Text;
            //con.Open();
            //red = com.ExecuteReader();
            //while (red.Read())
            //{
            //    textBox14.Text = red.GetValue(0).ToString();

            //}

            //red.Close();
            //con.Close();

        }
        public void GetOrdersDate()
        {
            try
            {
                //dateTimePicker2.Items.Clear();
                //DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlDataReader red;
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = ("select Order_Date from Tbl_Order where Order_NO=@P ");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = comboBox2.Text;
                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {
                    dateTimePicker2.Items.Add(red.GetValue(0)).ToString();

                }
                dateTimePicker2.SelectedIndex = 1;
                red.Close();
                con.Close();
            }
            catch { }
        }
        public void GetOrdersID()
        {
            try
            {
                textBox7.Text = "";
                //DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlDataReader red;
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = ("select ID from Tbl_Order where Order_NO=@P and Order_Date=@P1 ");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = comboBox2.Text;
                com.Parameters.Add("@P1", SqlDbType.DateTime).Value = Convert.ToDateTime(dateTimePicker2.Text).ToShortDateString();
                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {
                    //comboBox2.Items.Add(red.GetValue(0)).ToString();
                    textBox7.Text = red.GetValue(0).ToString();
                }
                red.Close();
                con.Close();
            }
            catch { }

        }
        public void GetOrdersIDDocument()
        {

            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("SELECT        dbo.Tbl_Order.OrderKind_ID, dbo.Tbl_OrderKind.Name FROM dbo.TBL_Document INNER JOIN dbo.Tbl_Order ON dbo.TBL_Document.Order_ID = dbo.Tbl_Order.ID INNER JOIN dbo.Tbl_OrderKind ON dbo.Tbl_Order.OrderKind_ID = dbo.Tbl_OrderKind.ID   where TBL_Document.ID=@P  ");
            if (textBox10.Text != string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Convert.ToInt32(textBox10.Text);
            }
            if (textBox10.Text == string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                //comboBox2.Items.Add(red.GetValue(0)).ToString();
                Order.Text = red.GetValue(1).ToString();
            }
            //textBox13.Text =  
            GetOrdersForPreview();
            comboBox2.Text = textBox13.Text;
            dateTimePicker2.Text = textBox14.Text;
            //GetOrdersDateForPreview();
            //comboBox2.SelectedItem = 0;
            red.Close();
            con.Close();

        }
        public void GetAssayes()
        {
            textBox26.Text = ""; // Clear the text box before populating with new data


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();


            SqlCommand com = new SqlCommand();
            SqlDataReader red;


            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select AssaysNo from Tbl_Assays where ID=@P  ");


            if (assaysID.Text == string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Convert.ToInt32(assaysID.Text);
            }


            con.Open();
            red = com.ExecuteReader();


            while (red.Read())
            {
                textBox26.Text = red.GetValue(0).ToString();
            }


            red.Close();
            con.Close();
        }

        public void GetProjects()
        {
            textBox28.Text = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select Name from Tbl_Projects where ID=@P  ");
            if (ProjectID.Text == string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            if (ProjectID.Text != string.Empty)
            {
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = Convert.ToInt32(ProjectID.Text);
            }
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                textBox28.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();

        }
        public void Getex()
        {
            exCenter.Text = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {

                string query = "SELECT Name FROM Tbl_ExchangeCenter WHERE ID = @P";


                con.Open();


                using (SqlCommand com = new SqlCommand(query, con))
                {

                    if (exID.Text == string.Empty)
                    {
                        com.Parameters.AddWithValue("@P", DBNull.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("@P", Convert.ToInt32(exID.Text));
                    }


                    using (SqlDataReader reader = com.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            string name = reader.GetString(0);


                            exCenter.Text = name;
                        }
                        else
                        {

                            exCenter.Text = "";
                        }
                        reader.Close();
                        con.Close();
                    }
                }
            }


        }
        public void GetMan()
        {
            Manag.Text = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {

                string query = "SELECT Name FROM Tbl_Management WHERE ID = @P";


                con.Open();


                using (SqlCommand com = new SqlCommand(query, con))
                {

                    com.Parameters.AddWithValue("@P", ManagID.Text);


                    using (SqlDataReader reader = com.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            string name = reader.GetString(0);


                            Manag.Text = name;
                        }
                        else
                        {

                            Manag.Text = "";
                        }
                        reader.Close();
                        con.Close();
                    }
                }
            }

        }

        public void Getcate()
        {
            Descp.Text = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {

                string query = "SELECT Name FROM Tbl_DocumentCategory WHERE ID = @P";


                con.Open();


                using (SqlCommand com = new SqlCommand(query, con))
                {

                    com.Parameters.AddWithValue("@P", CategortID.Text);


                    using (SqlDataReader reader = com.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            string name = reader.GetString(0);


                            Descp.Text = name;
                        }
                        else
                        {

                            Descp.Text = "";
                        }
                        reader.Close();
                        con.Close();
                    }
                }
            }

        }
        public void GetHand()
        {
            Empc.Text = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {

                string query = "SELECT Name FROM Tbl_Handler WHERE ID = @P";


                con.Open();


                using (SqlCommand com = new SqlCommand(query, con))
                {

                    com.Parameters.AddWithValue("@P", HandlerID.Text);


                    using (SqlDataReader reader = com.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            string name = reader.GetString(0);


                            Empc.Text = name;
                        }
                        else
                        {

                            Empc.Text = "";
                        }
                        reader.Close();
                        con.Close();
                    }
                }
            }

        }
        public void GetRespon()
        {
            Respo.Text = "";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {

                string query = "SELECT Name FROM Tbl_ResponspilityCenters WHERE ID = @P";


                con.Open();


                using (SqlCommand com = new SqlCommand(query, con))
                {

                    com.Parameters.AddWithValue("@P", RespoID.Text);

                    using (SqlDataReader reader = com.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            string name = reader.GetString(0);


                            Respo.Text = name;
                        }
                        else
                        {

                            Respo.Text = "";
                        }
                        reader.Close();
                        con.Close();
                    }

                }
            }


        }
        public void GetUsf()
        {
            UsFul.Text = "";
            UsFulID.Text = "";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {

                string query = "select Name,ID from Tbl_Beneficiary where ID=@P";


                con.Open();


                using (SqlCommand com = new SqlCommand(query, con))
                {

                    com.Parameters.AddWithValue("@P", UsFulID.Text);

                    using (SqlDataReader reader = com.ExecuteReader())
                    {

                        if (reader.Read())
                        {



                            UsFul.Text = reader.GetValue(0).ToString();
                            UsFulID.Text = reader.GetValue(1).ToString();
                        }
                        else
                        {

                            UsFul.Text = "";
                        }
                        reader.Close();
                        con.Close();
                    }

                }
            }


        }
        public DataTable ManaGament()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select top(30) ID,Name from Tbl_Management ");
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

        public DataTable Emp()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select top (30) ID,Name from Tbl_OrderHandler ");
            //con.Open();
            //com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            //con.Close();
            return dt;
        }

        public DataTable Beneficiary()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select top(30) ID,Name from Tbl_Beneficiary ");
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
        private void Respo_Click(object sender, EventArgs e)
        {
            //if (Respo.DataSource == null)
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    splashScreenManager1.SetWaitFormCaption(" تحميل مراكز المسؤلية ");
            //    Respo.DataSource = RespoFill();
            //    Respo.DisplayMember = ("Name");
            //    Respo.ValueMember = ("ID");
            //    splashScreenManager1.CloseWaitForm();
            //}


            //this.tbl_ResponspilityCentersTableAdapter.Fill(this.financialSysDataSet1.Tbl_ResponspilityCenters);
            //this.tbl_BeneficiaryTableAdapter.Fill(this.financialSysDataSet.Tbl_Beneficiary);
            //this.tbl_OrderHandlerTableAdapter.Fill(this.financialSysDataSet.Tbl_OrderHandler);
            //this.tbl_OrderTableAdapter.Fill(this.financialSysDataSet.Tbl_Order);
            //this.tbl_ExchangeCenterTableAdapter.Fill(this.financialSysDataSet.Tbl_ExchangeCenter);
            //this.tbl_CostCentersTableAdapter.Fill(this.financialSysDataSet.Tbl_CostCenters);

            //this.tbl_ManagementTableAdapter.Fill(this.financialSysDataSet.Tbl_Management);
            //this.tbl_DocumentCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentCategory);

        }
        public DataTable OrderKindFill()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select ID,Name from tbl_OrderKind ");
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
        private void Order_Click(object sender, EventArgs e)
        {
            //if (Order.DataSource == null)
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    splashScreenManager1.SetWaitFormCaption(" تحميل أنواع الأوامر ");
            //    Order.DataSource = OrderKindFill();
            //    Order.DisplayMember = ("Name");
            //    Order.ValueMember = ("ID");
            //    splashScreenManager1.CloseWaitForm();
            //}
        }
        private void fill()
        {
            // this.SuspendLayout();
            Order.SuspendLayout();
            Order.DataSource = OrderKindFill();
            Order.DisplayMember = ("Name");
            Order.ValueMember = ("ID");
            Order.ResumeLayout();
            Respo.SuspendLayout();
            Respo.DataSource = RespoFill();
            Respo.DisplayMember = ("Name");
            Respo.ValueMember = ("ID");
            Respo.ResumeLayout();
            Descp.SuspendLayout();
            Descp.DataSource = DocumentCategory();
            Descp.DisplayMember = ("Name");
            Descp.ValueMember = ("ID");
            Descp.ResumeLayout();

            //exCenter.SuspendLayout();
            //exCenter.DataSource = ExCenter();
            //exCenter.DisplayMember = ("Name");
            //exCenter.ValueMember = ("ID");
            //exCenter.ResumeLayout();
            Manag.SuspendLayout();
            Manag.DataSource = ManaGament();
            Manag.DisplayMember = ("Name");
            Manag.ValueMember = ("ID");
            Manag.ResumeLayout();
            Empc.SuspendLayout();
            Empc.DataSource = Emp();
            Empc.DisplayMember = ("Name");
            Empc.ValueMember = ("ID");
            Empc.ResumeLayout();
            UsFul.SuspendLayout();
            UsFul.DataSource = Beneficiary();
            UsFul.DisplayMember = ("Name");
            UsFul.ValueMember = ("ID");
            UsFul.ResumeLayout();
        }


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            int currentIndex = dataGridView1.CurrentCell.RowIndex;
            // Check if the current row is a new row.
            if (dataGridView1.Rows[currentIndex].IsNewRow)
            {
                // The current row is a new row.
                dataGridView1.CurrentRow.Cells[20].Value = true;
                simpleButton6.Enabled = true;
            }
            else
            {
                //simpleButton6.Enabled = false ;
            }

            //if (dataGridView1.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            //{
            //    SendKeys.Send("{tab}");

            //}
        }

        private void Descp_Click(object sender, EventArgs e)
        {
            //if (Descp.DataSource == null)
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    splashScreenManager1.SetWaitFormCaption(" تحميل البيان ");
            //    Descp.DataSource = DocumentCategory();
            //    Descp.DisplayMember = ("Name");
            //    Descp.ValueMember = ("ID");
            //    splashScreenManager1.CloseWaitForm();
            //}
        }

        private void exCenter_Click(object sender, EventArgs e)
        {
            //if (exCenter.DataSource == null)
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    splashScreenManager1.SetWaitFormCaption(" تحميل مراكز الصرف ");


            //    exCenter.DataSource = ExCenter();
            //    exCenter.DisplayMember = ("Name");
            //    exCenter.ValueMember = ("ID");
            //    splashScreenManager1.CloseWaitForm();
            //}
        }

        private void Manag_Click(object sender, EventArgs e)
        {
            //if (Manag.DataSource == null)
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    splashScreenManager1.SetWaitFormCaption(" تحميل الإدارات ");
            //    Manag.DataSource = ManaGament();
            //    Manag.DisplayMember = ("Name");
            //    Manag.ValueMember = ("ID");
            //    splashScreenManager1.CloseWaitForm();
            //}
        }

        private void Emp_Click(object sender, EventArgs e)
        {
            //if (Empc.DataSource == null)
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    splashScreenManager1.SetWaitFormCaption(" تحميل المناولين ");
            //    Empc.DataSource = Emp();
            //    Empc.DisplayMember = ("Name");
            //    Empc.ValueMember = ("ID");
            //    splashScreenManager1.CloseWaitForm();

            //}
        }

        private void UsFul_Click(object sender, EventArgs e)
        {
            //if (UsFul.DataSource == null)
            //{
            //    splashScreenManager1.ShowWaitForm();
            //    splashScreenManager1.SetWaitFormCaption(" تحميل المستفيدين ");
            //    UsFul.DataSource = Beneficiary();
            //    UsFul.DisplayMember = ("Name");
            //    UsFul.ValueMember = ("ID");
            //    splashScreenManager1.CloseWaitForm();
            //}
        }

        private void UsFul_Leave(object sender, EventArgs e)
        {
            UsFul.BackColor = Color.White;
        }

        private void UsFul_Enter(object sender, EventArgs e)
        {
            UsFul.BackColor = Color.NavajoWhite;

            // UsFul.BackColor = Color.White;
        }

        private void Restriction_NO_Leave(object sender, EventArgs e)
        {
            Restriction_NO.BackColor = Color.White;
        }

        private void Restriction_NO_Enter(object sender, EventArgs e)
        {
            Restriction_NO.BackColor = Color.NavajoWhite;
        }

        private void exCenter_Leave(object sender, EventArgs e)
        {
            exCenter.BackColor = Color.White;
        }

        private void exCenter_Enter(object sender, EventArgs e)
        {
            exCenter.BackColor = Color.NavajoWhite;
        }

        private void DocNO_Leave(object sender, EventArgs e)
        {
            DocNO.BackColor = Color.White;
        }

        private void DocNO_Enter(object sender, EventArgs e)
        {
            DocNO.BackColor = Color.NavajoWhite;
        }

        private void Manag_Leave(object sender, EventArgs e)
        {
            Manag.BackColor = Color.White;
        }

        private void Manag_Enter(object sender, EventArgs e)
        {
            Manag.BackColor = Color.NavajoWhite;
        }

        private void Lyear_Leave(object sender, EventArgs e)
        {
            Lyear.BackColor = Color.White;
        }

        private void Lyear_Enter(object sender, EventArgs e)
        {
            Lyear.BackColor = Color.NavajoWhite;
        }

        private void Descp_Leave(object sender, EventArgs e)
        {
            Descp.BackColor = Color.White;
        }

        private void Descp_Enter(object sender, EventArgs e)
        {
            Descp.BackColor = Color.NavajoWhite;
        }

        private void Respo_Leave(object sender, EventArgs e)
        {
            Respo.BackColor = Color.White;
        }

        private void Respo_Enter(object sender, EventArgs e)
        {
            Respo.BackColor = Color.NavajoWhite;
        }

        private void Empc_Leave(object sender, EventArgs e)
        {
            Empc.BackColor = Color.White;
        }

        private void Empc_Enter(object sender, EventArgs e)
        {
            Empc.BackColor = Color.NavajoWhite;
        }

        private void Order_Leave(object sender, EventArgs e)
        {
            Order.BackColor = Color.White;
        }

        private void Order_Enter(object sender, EventArgs e)
        {
            Order.BackColor = Color.NavajoWhite;
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            comboBox2.BackColor = Color.White;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.BackColor = Color.NavajoWhite;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(comboBox1.SelectedValue) == 12)
                {
                    x = 1;
                    y = 2;
                }

                if (Convert.ToInt32(comboBox1.SelectedValue) == 13)
                {
                    x = 3;
                    y = 3;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 14)
                {
                    x = 4;
                    y = 4;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 15)
                {
                    x = 5;
                    y = 5;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 16)
                {
                    x = 6;
                    y = 6;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 17)
                {
                    x = 7;
                    y = 7;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 18)
                {
                    x = 8;
                    y = 8;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 19)
                {
                    x = 9;
                    y = 9;
                }
                Restriction_NO.Focus();
                Restriction_NO.SelectAll();
            }
            catch { }
        }
        public void GetParentIDKind()
        {
            if (comboBox1.InvokeRequired)
            {
                comboBox1.Invoke(new MethodInvoker(GetParentIDKind));
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;
                SqlCommand com = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    Connection = con,
                    CommandText = "select ParentID from Tbl_AccountingRestrictions_Kind where ParentID=@P"
                };
                com.Parameters.Add("@P", SqlDbType.Int).Value = comboBox1.SelectedValue;

                con.Open();
                SqlDataReader red = com.ExecuteReader();
                while (red.Read())
                {
                    textBox16.Text = red.GetValue(0).ToString();
                }
                red.Close();
                con.Close();
            }
        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            //try
            //{
            FindDoc f = new FindDoc();
            f.textBox1.Text = x.ToString();
            f.textBox3.Text = y.ToString();
            f.label2.Text = comboBox1.Text;
            f.ShowDialog();
            Lyear.Text = f.textBox2.Text;
            //if (int.Parse(Restriction_NO.Text) > 0)
            //{
            //    Restriction_NO.Focus();
            //    CleareControls();
            //    GetREstrictionID();
            //    FindFileNumber1();
            //    GetDocumentData();
            //}
            //}
            //catch
            //{
            //    Restriction_NO.Text = "0";
            //    Restriction_NO.Focus();
            //    Restriction_NO.SelectAll();
            //}
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.CurrentCell.ColumnIndex == 16)
            //{
            //    try
            //    {
            //        //if (dataGridView1.CurrentRow.Cells[16].Value.ToString() == "اسم الشخص")
            //        //{
            //        AddPersonalRestr ad = new AddPersonalRestr();
            //        if (dataGridView1.CurrentRow.Cells[3].Value.ToString() != "0.000" && dataGridView1.CurrentRow.Cells[4].Value.ToString() == "0.000")
            //        {
            //            ad.textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //            ad.textEdit3.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            //            ad.ShowDialog();
            //        }
            //        if (dataGridView1.CurrentRow.Cells[4].Value.ToString() != "0.000" && dataGridView1.CurrentRow.Cells[3].Value.ToString() == "0.000")
            //        {
            //            ad.textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //            ad.textEdit3.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            //            ad.ShowDialog();
            //        }

            //        if (dataGridView1.CurrentRow.Cells[3].Value.ToString() != "0" && dataGridView1.CurrentRow.Cells[4].Value.ToString() == "0")
            //        {
            //            ad.textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //            ad.textEdit3.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            //            ad.ShowDialog();
            //        }
            //        if (dataGridView1.CurrentRow.Cells[4].Value.ToString() != "0" && dataGridView1.CurrentRow.Cells[3].Value.ToString() == "0")
            //        {
            //            ad.textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //            ad.textEdit3.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            //            ad.ShowDialog();
            //        }


            //        //}
            //    }
            //    catch { }

            //}
            //if (dataGridView1.CurrentCell.ColumnIndex == 1)//Account Number 
            //{
            //    try
            //    {
            //        string x = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //        FindAccount f = new FindAccount();

            //        DataGridViewCell currentCell = dataGridView1.CurrentCell;

            //        currentCell.Value = DBNull.Value;


            //        f.ShowDialog();
            //        dataGridView1.CurrentRow.Cells[1].Value = FindAccount.SelectedRow.Cells[0].Value.ToString();
            //        SendKeys.Send("{TAB}");

            //        if (dataGridView1.CurrentRow.Cells[2].Value == null)
            //        {
            //            MessageBox.Show("رقم الحساب خطأ");
            //        }

            //        if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "0")
            //        {
            //            dataGridView1.CurrentRow.Cells[1].Value = x;
            //        }


            //    }
            //    catch { }
            //}

        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Respo.Focus();


            }
            if (e.KeyCode == Keys.Delete)
            {
                textBox7.Text = DBNull.Value.ToString();
                comboBox2.Text = DBNull.Value.ToString();
            }
        }
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        public void ExCenter()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select Name from Tbl_ExchangeCenter ");

            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            if (dt.Rows.Count > 0)

            {

                for (int i = 0; i < dt.Rows.Count; i++)

                {

                    coll.Add(dt.Rows[i]["Name"].ToString());

                }

            }
            else

            {

                MessageBox.Show("Name not found");

            }


            con.Close();



            //  return dt;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            ExCenter();
            textBox12.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            textBox12.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox12.AutoCompleteCustomSource = coll;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            //SqlCommand com = new SqlCommand();
            //com.CommandType = CommandType.Text;
            //com.Connection = con;
            //com.CommandText = ("select Name from Tbl_ExchangeCenter where Name Like '%' + @P + '%' ");
            //com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox12.Text;
            //con.Open();
            //com.ExecuteScalar();
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            //da.SelectCommand = com;
            //com.ExecuteScalar();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)

            //{

            //    for (int i = 0; i < dt.Rows.Count; i++)

            //    {

            //        coll.Add(dt.Rows[i]["Name"].ToString());

            //    }

            //}
            //else

            //{

            //    MessageBox.Show("Name not found");

            //}


            //con.Close();


            //textBox12.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //textBox12.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //textBox12.AutoCompleteCustomSource = coll;

        }

        private void buttonX7_Click(object sender, EventArgs e)
        {

        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.ResponspilityCentersFrm f = new BasicCodeForms.ResponspilityCentersFrm();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
        double wi = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            pnadvisory.Left += 2;
            if (pnadvisory.Left + 350 >= wi)
            {
                // pnadvisory.Left = (int)wi * 2;
                //     pnadvisory.Left = -(int)wi * 2;
                if (wi > this.Width)
                {

                    // pnadvisory.Left = -(int)wi * 2;
                    pnadvisory.Left = -panel5x.Width;

                }
                else
                {
                    pnadvisory.Left = -this.Width;

                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Res_Frm_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            if (e.KeyCode == Keys.PageUp && Restriction_NO.Focus() == true)
            {
                try
                {//next
                    UseFULL_Kind.Text = "";

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                    {
                        using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE Restriction_NO > @Restriction_NO AND (AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3) ORDER BY Restriction_NO ASC", con))
                        {
                            com.Parameters.AddWithValue("@Restriction_NO", int.Parse(Restriction_NO.Text));
                            com.Parameters.AddWithValue("@D2", x);
                            com.Parameters.AddWithValue("@D3", y);

                            con.Open();
                            SqlDataReader red = com.ExecuteReader();

                            if (red.Read())
                            {
                                Restriction_NO.Text = red["Restriction_NO"].ToString();
                            }
                            else
                            {
                                Restriction_NO.Text = "0";
                            }

                            red.Close();
                        }
                        con.Close();
                    }


                    button2_Click_1(sender, e);

                }
                catch { }
                this.KeyPreview = true;
            }
            if (e.KeyCode == Keys.PageDown && Restriction_NO.Focus() == true)
            {
                try
                { //prev
                    UseFULL_Kind.Text = "";

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                    {
                        using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE Restriction_NO < @Restriction_NO AND (AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3) ORDER BY Restriction_NO DESC", con))
                        {
                            com.Parameters.AddWithValue("@Restriction_NO", int.Parse(Restriction_NO.Text));
                            com.Parameters.AddWithValue("@D2", x);
                            com.Parameters.AddWithValue("@D3", y);

                            con.Open();
                            SqlDataReader red = com.ExecuteReader();

                            if (red.Read())
                            {
                                Restriction_NO.Text = red["Restriction_NO"].ToString();
                            }
                            else
                            {
                                Restriction_NO.Text = "0";
                            }

                            red.Close();
                        }
                        con.Close();
                    }



                    button2_Click_1(sender, e);
                }
                catch { }
                this.KeyPreview = true;
            }
            if (e.KeyCode == Keys.Home && Restriction_NO.Focus() == true)
            {
                try
                {//first
                    UseFULL_Kind.Text = "";


                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                    {
                        using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3 ORDER BY Restriction_NO ASC", con))
                        {
                            com.Parameters.AddWithValue("@D2", x);
                            com.Parameters.AddWithValue("@D3", y);

                            con.Open();
                            object result = com.ExecuteScalar();
                            if (result != null)
                            {
                                Restriction_NO.Text = result.ToString();
                            }
                            else
                            {
                                Restriction_NO.Text = "0";
                            }
                        }
                        con.Close();
                    }


                    button2_Click_1(sender, e);

                }
                catch { }
                this.KeyPreview = true;
            }
            if (e.KeyCode == Keys.End && Restriction_NO.Focus() == true)
            {
                try
                {//last
                    UseFULL_Kind.Text = "";
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                    {
                        using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3 ORDER BY Restriction_NO DESC", con))
                        {
                            com.Parameters.AddWithValue("@D2", x);
                            com.Parameters.AddWithValue("@D3", y);

                            con.Open();
                            using (SqlDataReader red = com.ExecuteReader())
                            {
                                if (red.Read())
                                {
                                    Restriction_NO.Text = red.GetValue(0).ToString();
                                }
                                else
                                {
                                    Restriction_NO.Text = "0";
                                }
                            }
                            con.Close();
                        }
                    }
                    button2_Click_1(sender, e);
                }
                catch { }
                this.KeyPreview = true;
            }
            if (e.KeyCode == Keys.F1 && switchButton1.Value == true)
            {
                if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0 && Convert.ToDecimal(PrTot.Text) == 0 && Convert.ToDecimal(CaTolt.Text) == 0)
                {
                    if (CategortID.Text != string.Empty)
                    {
                        dataGridView1.AllowUserToAddRows = false;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 3);
                            if (validationSaveUser != null)
                            {
                                if (textBox10.Text == string.Empty)
                                {
                                    SaveDocument();
                                    GetDocID();
                                }
                                if (textBox5.Text == string.Empty)
                                {
                                    SaveRestrictionFirtTime();
                                    GenerateID();
                                }
                                SaveDocumentBenefcairy();
                                saveToDB();
                                UpdateHeader();
                                UpdateRes();
                                Restriction_NO.Focus();
                                Restriction_NO.Select();
                                //SaveEvnt();
                                labelControl1.Visible = true;
                                MessageBox.Show(" تم حفظ المستند بنجاح ", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                progressBar1.Visible = false;
                                DT.Clear();
                                dataGridView1.Rows.Clear();
                                dataGridViewX2.Rows.Clear();
                                //if(checkBox12. Checked == false)
                                //    {
                                OpenConnection();
                                GoNextAfterSave();
                                CloseConnection();
                                //}
                                CleareControls();
                                button2_Click_1(sender, e);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(" الرجاء قم باختيار البيان ", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Descp.Focus();
                    }
                }
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            //}
            //catch { }
        }
        private void DeleteRecords()
        {
            DialogResult result = MessageBox.Show("هل انت متأكد من حذف المستند؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

                string query = @"DELETE 
                         FROM Tbl_AccountingRestriction
                         
                         WHERE Restriction_NO = @Rest
                         AND AccountingRestrictionKind_ID IN (@i, @i1) 
                         AND FYear = @F;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Rest", Restriction_NO.Text);
                        command.Parameters.AddWithValue("@i", x);
                        command.Parameters.AddWithValue("@i1", y);
                        command.Parameters.AddWithValue("@F", Convert.ToInt32(comboBox3.SelectedValue));

                        // Open connection
                        connection.Open();

                        // Execute the delete operation
                        command.ExecuteNonQuery();

                        // Close connection
                        connection.Close();
                        MessageBox.Show("تم حذف المستند بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void GoNextAfterSave()
        {
            try
            {//next
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    UseFULL_Kind.Text = "";
                    labelControl1.Visible = false;
                    panel2.Visible = false;
                    chckBxBasicData.Checked = false;
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox36.Text = "";
                    textBox19.Text = "";
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    dataGridViewX8.Rows.Clear();
                    chckBxBasicData.Checked = false;
                    //button2_Click_1(sender, e);
                    //dateTimePicker1.Focus();
                    if (comboBox4.Items.Count > 1)
                    {
                        comboBox4.SelectedValue = 1;
                    }
                    if (checkBox15.Checked == true)
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                        {
                            using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE Restriction_NO > @Restriction_NO AND (AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3) ORDER BY Restriction_NO ASC", con))
                            {
                                com.Parameters.AddWithValue("@Restriction_NO", int.Parse(Restriction_NO.Text));
                                com.Parameters.AddWithValue("@D2", x);
                                com.Parameters.AddWithValue("@D3", y);

                                con.Open();
                                SqlDataReader red = com.ExecuteReader();

                                if (red.Read())
                                {
                                    Restriction_NO.Text = red["Restriction_NO"].ToString();
                                }
                                else
                                {
                                    Restriction_NO.Text = "0";
                                }

                                red.Close();
                            }
                            con.Close();
                        }

                        chckBxBasicData.Checked = false;
                        textBox36.BackColor = Color.White;
                        textBox36.ForeColor = Color.Black;
                        label24.Text = string.Empty;
                        Searching();
                        getBanifecary();
                        try
                        {
                            long Vlng_AccRstID = long.Parse(textBox5.Text);
                            AccRstAuditSelect(Vlng_AccRstID);
                            var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TrecordId == Vlng_AccRstID).Distinct().ToList();

                            string Vstr_UserAddR = "";
                            int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                            for (int i = 0; i <= WCount - 1; i++)
                            {
                                Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                            }
                            textBox30.Text = Vstr_UserAddR;
                        }
                        catch { }


                    }
                    if (checkBox15.Checked == false)
                    {
                        int x1 = Convert.ToInt32(Restriction_NO.Text);
                        int y = 1;
                        int t = x1 + y;
                        Restriction_NO.Text = Convert.ToString(t);


                        chckBxBasicData.Checked = false;
                        textBox36.BackColor = Color.White;
                        textBox36.ForeColor = Color.Black;
                        label24.Text = string.Empty;
                        Searching();
                        getBanifecary();
                        try
                        {
                            long Vlng_AccRstID = long.Parse(textBox5.Text);
                            AccRstAuditSelect(Vlng_AccRstID);
                            var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TrecordId == Vlng_AccRstID).Distinct().ToList();

                            string Vstr_UserAddR = "";
                            int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                            for (int i = 0; i <= WCount - 1; i++)
                            {
                                Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                            }
                            textBox30.Text = Vstr_UserAddR;
                        }
                        catch { }
                    }
                }

            }
            catch { }

        }

        private void UpdateAuditRestriction(long Vlng_AccRstID, int Vint_userID)
        {
            Vlng_AccRstID = long.Parse(textBox5.Text);

            var listAccResAudit = FsDb.Tbl_AccountingRestriction_Audit.Where(x => x.AccountingRestrictionID == Vlng_AccRstID && x.UserIDData == Vint_userID).ToList();
            if (listAccResAudit.Count != 0)
            {
                listAccResAudit[0].IsUserUpdate = true;
                listAccResAudit[0].UserUpdateDate = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
                FsDb.SaveChanges();
            }

        }
        private void SaveEvnt()
        {
            long V_TbleRecord = 0;

            long Vlong_RestNo = long.Parse(Restriction_NO.Text);
            DateTime Vdate_RestDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

            // Check if the record exists in the database
            var list = FsDb.Tbl_AccountingRestriction.FirstOrDefault(x => x.Restriction_NO == Vlong_RestNo && x.Restriction_Date == Vdate_RestDate);




            //---------------خفظ ااحداث 
            if (list != null)
            {
                V_TbleRecord = list.ID;
                UpdateAuditRestriction(V_TbleRecord, Program.GlbV_UserId);
                string Vdt_DateRestriction = Convert.ToDateTime(dateTimePicker1.Value).ToString();
                //---------------حفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "إضافة/ تعديل قيود",
                    TableName = "Tbl_AccountingRestriction",
                    TableRecordId = Restriction_NO.Text + " -- " + Vdt_DateRestriction,
                    TrecordId = V_TbleRecord,
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة القيود المحاسبيه"


                };
                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
            }
            else
            {
                //MessageBox.Show("لا يوجد تسجيل مطابق في قاعدة البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveDocumentBenefcairy()
        {

            // Get the beneficiary ID
            int beneficiaryID = string.IsNullOrEmpty(UsFulID.Text) ? 0 : Convert.ToInt32(UsFulID.Text);

            // Check if document ID is valid
            if (string.IsNullOrEmpty(textBox10.Text) || Convert.ToInt32(textBox10.Text) <= 0)
            {
                MessageBox.Show("يرجى تحديد رقم المستند", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Connection string
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Delete existing beneficiary records associated with the document
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM Tbl_DocumentBenefcairy WHERE Document_ID = @Document_ID", con);
                deleteCommand.Parameters.AddWithValue("@Document_ID", Convert.ToInt32(textBox10.Text));
                deleteCommand.ExecuteNonQuery();

                // Insert new beneficiary record if the beneficiary ID is not null
                if (beneficiaryID > 0)
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Tbl_DocumentBenefcairy (Document_ID, Beneficiary_ID) VALUES (@Document_ID, @Beneficiary_ID)", con);
                    insertCommand.Parameters.AddWithValue("@Document_ID", Convert.ToInt32(textBox10.Text));
                    insertCommand.Parameters.AddWithValue("@Beneficiary_ID", beneficiaryID);
                    insertCommand.ExecuteNonQuery();
                }

                con.Close();
            }
            getBanifecary();

        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.ExchangeCemtersFrm f = new BasicCodeForms.ExchangeCemtersFrm();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.DocumentCategoryFrm f = new BasicCodeForms.DocumentCategoryFrm();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.BeneficiaryFrm f = new BasicCodeForms.BeneficiaryFrm();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.ManagementFrm f = new BasicCodeForms.ManagementFrm();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void simpleButton5_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void simpleButton4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void simpleButton1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void simpleButton2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            try
            {
                //comboBox2.Items.Clear();
                GetOrders();
            }
            catch { }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    GetOrdersID();
            //}
            //catch
            //{
            //    MessageBox.Show("من فضلك أختر رقم وتاريخ الأمر");
            //}
        }

        private void dateTimePicker2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{

            //}
            //catch
            //{
            //    MessageBox.Show("من فضلك أختر رقم وتاريخ الأمر");
            //}
        }

        private void Order_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //comboBox2.Items.Clear();
                //GetOrders();
            }
            catch { }
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
            //BrokerAccount();

        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
            e.Row.Cells[1].Value = "000";
            e.Row.Cells[21].Value = 1;
            e.Row.Cells[3].Value = "000";
            e.Row.Cells[4].Value = "000";
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            //HighamountsFrm f = new HighamountsFrm();
            //f.ShowDialog();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(comboBox1.SelectedValue) == 12)
                {
                    x = 1;
                    y = 2;
                }

                if (Convert.ToInt32(comboBox1.SelectedValue) == 13)
                {
                    x = 3;
                    y = 3;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 14)
                {
                    x = 4;
                    y = 4;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 15)
                {
                    x = 5;
                    y = 5;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 16)
                {
                    x = 6;
                    y = 6;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 17)
                {
                    x = 7;
                    y = 7;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 18)
                {
                    x = 8;
                    y = 8;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 19)
                {
                    x = 9;
                    y = 9;
                }
                Restriction_NO.Focus();
                Restriction_NO.SelectAll();
            }
            catch { }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (checkBox15.Checked == false)
                {
                    comboBox1.Text = comboBox5.Text;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 12)
                {
                    x = 1;
                    y = 2;
                }

                if (Convert.ToInt32(comboBox1.SelectedValue) == 13)
                {
                    x = 3;
                    y = 3;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 14)
                {
                    x = 4;
                    y = 4;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 15)
                {
                    x = 5;
                    y = 5;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 16)
                {
                    x = 6;
                    y = 6;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 17)
                {
                    x = 7;
                    y = 7;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 18)
                {
                    x = 8;
                    y = 8;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 19)
                {
                    x = 9;
                    y = 9;
                }
                GetParentIDKind();
                ComboInDataGrid();
                comboBox4.DataSource = fillDGVComboBox();
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
                if (int.Parse(Restriction_NO.Text) > 0)
                {
                    Restriction_NO.Focus();
                    CleareControls();
                    GetREstrictionID();
                    FindFileNumber1();
                    GetDocumentData();
                    Getex();
                    GetMan();
                    GetUsf();
                    Getcate();
                    GetHand();
                    GetRespon();
                    GetHand();
                    GetOrdersIDDocument();
                    BrokerAccount();
                    dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";

                }
                Restriction_NO.Focus();
                Restriction_NO.SelectAll();
            }
            catch { }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Don't throw an exception when we're done.
            //e.ThrowException = false;

            //// Display an error message.
            //string txt = "Error with " +
            //    dataGridView1.Columns[e.ColumnIndex].HeaderText +
            //    "\n\n" +"الرجاء إدخال البيانات";
            //MessageBox.Show(txt, "Error",
            //    MessageBoxButtons.OK, MessageBoxIcon.Error);

            //// If this is true, then the user is trapped in this cell.
            //e.Cancel = false;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    foreach (DataGridViewRow row in this.dataGridView1.Rows)
            //    //for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            //    {
            //        //string Account = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //        if (Convert.ToInt32(row.Cells[22].Value) == 1 && textBox16.Text == "12")
            //        {
            //            if (Convert.ToInt32(row.Index) == Convert.ToInt32(row.Cells[1].Value))
            //            {

            //                dataGridViewX2.Rows.Add(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());
            //            }
            //        }
            //    }
            //    string s = (from DataGridViewRow row in dataGridViewX2.Rows
            //                where row.Cells[2].FormattedValue.ToString() != string.Empty
            //                select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
            //    string f = (from DataGridViewRow row in dataGridViewX2.Rows
            //                where row.Cells[3].FormattedValue.ToString() != string.Empty
            //                select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            //    // textBox1.Text = dataGridView1.Rows.Count.ToString();
            //    double xx, yy, zz;
            //    xx = Convert.ToDouble(s);
            //    yy = Convert.ToDouble(f);
            //    zz = Convert.ToDouble(s) - Convert.ToDouble(f);
            //    TTT.Text = Convert.ToString(zz);
            //    dataGridView1.AllowUserToAddRows = true;
            //}
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if ((dataGridView1[1, e.RowIndex].Value == null) || (dataGridView1[3, e.RowIndex].Value == null) || (dataGridView1[4, e.RowIndex].Value == null))
            //{
            //    // e.Cancel = true;
            //    MessageBox.Show("Fill Empty Row");

            //}
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            //RestRPT BRPT = new RestRPT();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.Accounting_Guid_ID ,Tbl_Activities.Name as[النشاط] ,Tbl_Activities.ID,Tbl_RestrictionItemsCategory.Name as [التصنيف],Tbl_RestrictionItemsCategory.ID, Tbl_CostCenters.Name ,Tbl_AccountingRestrictionItems.CostCenters_ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID, dbo.Tbl_Accounting_Guid.Parent_ID from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID Left Join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID left join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID left join Tbl_CostCenters on Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2  OR Tbl_AccountingRestriction.Restriction_NO = @D and Tbl_AccountingRestrictions_Kind.id = @D3  Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

            //if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
            //{
            //    x = 1;
            //    y = 2;
            //}

            //if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
            //{
            //    x = 1;
            //    y = 2;
            //}
            //if (Convert.ToInt32(comboBox1.SelectedValue) != 2 && Convert.ToInt32(comboBox1.SelectedValue) != 1)
            //{
            //    x = Convert.ToInt32(comboBox1.SelectedValue);
            //    y = Convert.ToInt32(comboBox1.SelectedValue);
            //}
            //if (Convert.ToInt32(comboBox1.SelectedValue) != 1 && Convert.ToInt32(comboBox1.SelectedValue) != 2)
            //{
            //    x = Convert.ToInt32(comboBox1.SelectedValue);
            //    y = Convert.ToInt32(comboBox1.SelectedValue);
            //}


            com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;
            //if (comboBox1.Text != "عمليات" || comboBox1.Text != "مدفوعات"  ) 
            //{
            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
            //}

            //if (comboBox1.Text == "عمليات" || comboBox1.Text == "مدفوعات")
            //{
            //    com.Parameters.Add("@D2", SqlDbType.Int).Value = 1;
            //    com.Parameters.Add("@D3", SqlDbType.Int).Value = 2;
            //}
            con.Open();


            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            DataSet DBDataSet = new DataSet();
            DBDataSet.Tables.Add(dt);
            //DBDataSet.Clear();
            da.Fill(DBDataSet);

            da.Fill(DBDataSet, "View_PrintDoc");
            //BRPT.SetDataSource(DBDataSet);
            //crystalReportViewer1.ReportSource = BRPT;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Visible = true;
            con.Close();
            //ViewRestrictionRPT v = new ViewRestrictionRPT();
            //v.ShowDialog();


            // ReportPrint();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void BrokerAccount()
        {
            //try
            //{
            dataGridView1.AllowUserToAddRows = false;
            dataGridViewX2.Rows.Clear();
            TTT.Text = "0";

            if (Convert.ToInt32(textBox16.Text) == 12)
            {

                for (int currentRow = 0; currentRow < dataGridView1.Rows.Count; currentRow++)
                {
                    string id = dataGridView1.Rows[currentRow].Cells[1].Value.ToString();
                    string name = dataGridView1.Rows[currentRow].Cells[2].Value.ToString();
                    for (int row = 0; row < dataGridView1.Rows.Count; row++)
                    {
                        string idCompare = dataGridView1.Rows[row].Cells[1].Value.ToString();
                        string nameCompare = dataGridView1.Rows[row].Cells[2].Value.ToString();
                        //if (currentRow != row)
                        //{
                        if (id == idCompare && name == nameCompare && Convert.ToInt32(dataGridView1.Rows[currentRow].Cells[22].Value).ToString() == "1")
                        {
                            dataGridViewX2.Rows.Add(dataGridView1.Rows[currentRow].Cells[1].Value.ToString(), dataGridView1.Rows[currentRow].Cells[2].Value.ToString(), dataGridView1.Rows[currentRow].Cells[3].Value.ToString(), dataGridView1.Rows[currentRow].Cells[4].Value.ToString());

                            break;
                        }
                        else
                        {

                        }
                        //}
                    }
                }
            }
            //DataView dataView = new DataView(dataGridViewX2.DataSource as DataTable);
            //dataGridViewX2.DataSource = dataView;
            // Set the Sort property of the DataView to the column you want to group by.
            //dataView.Sort  = "dataGridViewTextBoxColumn2";

            // Set the DataSource of the DataGridView to the DataView.

            //****************

            string s = (from DataGridViewRow row in dataGridViewX2.Rows
                        where row.Cells[2].FormattedValue.ToString() != string.Empty
                        select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
            string f = (from DataGridViewRow row in dataGridViewX2.Rows
                        where row.Cells[3].FormattedValue.ToString() != string.Empty
                        select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

            double xx, yy, zz;
            xx = Convert.ToDouble(s);
            yy = Convert.ToDouble(f);
            zz = Convert.ToDouble(s) - Convert.ToDouble(f);
            TTT.Text = Convert.ToString(zz);
            // dataGridView1.AllowUserToAddRows = true;


            PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                            where row.Cells[21].Value.ToString() == "1"
                            select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
            Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[21].Value.ToString() == "1"
                             select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            double PrD, PRC, PRT;
            PrD = Convert.ToDouble(PrDebit.Text);
            PRC = Convert.ToDouble(Prcridit.Text);
            PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
            PrTot.Text = Convert.ToString(PRT);
            //dataGridView1.AllowUserToAddRows = true;


            CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                            where row.Cells[21].Value.ToString() == "2"
                            select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
            CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                             where row.Cells[21].Value.ToString() == "2"
                             select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            double CaD, CaC, CaT;
            CaD = Convert.ToDouble(CaDebit.Text);
            CaC = Convert.ToDouble(CaCridit.Text);
            CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
            CaTolt.Text = Convert.ToString(CaT);
            //dataGridViewX3.Rows.Clear();


            for (int currentRow = 0; currentRow < dataGridViewX2.Rows.Count; currentRow++)
            {
                int id = Convert.ToInt32(dataGridViewX2.Rows[currentRow].Cells[0].Value);
                string name = dataGridViewX2.Rows[currentRow].Cells[1].Value.ToString();
                for (int row = 0; row < dataGridViewX2.Rows.Count; row++)
                {
                    int idCompare = Convert.ToInt32(dataGridViewX2.Rows[row].Cells[0].Value);
                    string nameCompare = dataGridViewX2.Rows[row].Cells[1].Value.ToString();
                    if (currentRow != row)
                    {
                        if (id == idCompare && name == nameCompare)
                        {
                            dataGridViewX2.Rows[currentRow].Cells[4].Value = (from DataGridViewRow row1 in dataGridViewX2.Rows
                                                                              where row1.Cells[0].Value.ToString() == dataGridViewX2.Rows[currentRow].Cells[0].Value.ToString()
                                                                              select Convert.ToDouble(row1.Cells[2].Value) - Convert.ToDouble(row1.Cells[3].Value)).Sum();

                            break;
                        }
                        else
                        {

                        }
                    }
                }
            }
            dataGridView1.AllowUserToAddRows = true;
            //}
            //    catch { }
        }
        private void dataGridViewX2_Click(object sender, EventArgs e)
        {

            //List<string> values = new List<string>();
            //List<DataGridViewRow> duplicateRows = new List<DataGridViewRow>();

            //// Loop through the rows of the first DataGridView
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    // Get the value in the first column of the current row
            //    string value = row.Cells[1].Value.ToString();
            //    string Debit = row.Cells[3].Value.ToString();
            //    string Cridit = row.Cells[4].Value.ToString();
            //    // Check if the value is already in the list of values
            //    if (!values.Contains(value))
            //    {
            //        // If the value is not in the list, add it
            //        values.Add(value);

            //        //values.Add(value1);
            //    }
            //    if ( !values.Contains(Debit) )
            //    {
            //        // If the value is not in the list, add it
            //       // values.Add(value);
            //        values.Add(Debit);
            //       // values.Add(Cridit);
            //        //values.Add(value1);
            //    }
            //    if (!values.Contains(Cridit))
            //    {
            //        // If the value is not in the list, add it
            //       // values.Add(value);
            //        //values.Add(Debit);
            //        values.Add(Cridit);
            //        //values.Add(value1);
            //    }
            //    if (values.Contains(value) && values.Contains(Debit) == values.Contains(Cridit))
            //    {
            //        // If the value is in the list, add the entire row to the second DataGridView
            //        duplicateRows.Add(row);
            //    }
            //}

            //// Add the duplicate rows to the second DataGridView
            //foreach (DataGridViewRow row in duplicateRows)
            //{
            //    dataGridViewX2.Rows.Add(row.Cells[1].Value, row.Cells[2].Value);
            //}
        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && dataGridView1.Focus() == true)
            {
                dataGridView1.CancelEdit();
            }
        }

        private void dataGridViewX2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Restriction_NO_TextChanged(object sender, EventArgs e)
        {
            msa.Text = Restriction_NO.Text;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //dateTimePicker2.Items.Clear();
                //GetOrdersDate();
                //dateTimePicker2.SelectedIndex = 0;
            }
            catch { }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void TTT_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewX3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[21].Value.ToString() == "1"
                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                    Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[21].Value.ToString() == "1"
                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                    double PrD, PRC, PRT;
                    PrD = Convert.ToDouble(PrDebit.Text);
                    PRC = Convert.ToDouble(Prcridit.Text);
                    PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                    PrTot.Text = Convert.ToString(PRT);
                    //dataGridView1.AllowUserToAddRows = true;


                    CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[21].Value.ToString() == "2"
                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                    CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[21].Value.ToString() == "2"
                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                    double CaD, CaC, CaT;
                    CaD = Convert.ToDouble(CaDebit.Text);
                    CaC = Convert.ToDouble(CaCridit.Text);
                    CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                    CaTolt.Text = Convert.ToString(CaT);
                    LoadSerial();
                    dataGridView1.AllowUserToAddRows = true;
                }
                if (e.ColumnIndex == 4)
                {
                    PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[21].Value.ToString() == "1"
                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                    Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[21].Value.ToString() == "1"
                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                    double PrD, PRC, PRT;
                    PrD = Convert.ToDouble(PrDebit.Text);
                    PRC = Convert.ToDouble(Prcridit.Text);
                    PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                    PrTot.Text = Convert.ToString(PRT);
                    //dataGridView1.AllowUserToAddRows = true;


                    CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[21].Value.ToString() == "2"
                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                    CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[21].Value.ToString() == "2"
                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                    double CaD, CaC, CaT;
                    CaD = Convert.ToDouble(CaDebit.Text);
                    CaC = Convert.ToDouble(CaCridit.Text);
                    CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                    CaTolt.Text = Convert.ToString(CaT);
                    LoadSerial();
                    dataGridView1.AllowUserToAddRows = true;
                }
            }
            catch { }
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {

            //Res_Search  f = new Res_Search();
            //f.ShowDialog();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet1.Tbl_Fiscalyear);
            //    //if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
            //    //{
            //    dataGridView1.Rows.Clear();
            //    dataGridViewX2.Rows.Clear();
            //    //MessageBox.Show("تم تغيير العام المالى");
            //    CaDebit.Text = "0";
            //    CaCridit.Text = "0";
            //    CaTolt.Text = "0";
            //    PrDebit.Text = "0";
            //    Prcridit.Text = "0";
            //    Prcridit.Text = "0";

            //    DateTime Val;
            //    Val = DateTime.Now;
            //    dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //    //Restriction_NO.Text = "1";
            //    Restriction_NO.Focus();
            //    //tD.Text = (from DataGridViewRow row in dataGridView1.Rows
            //    //           where row.Cells[3].FormattedValue.ToString() != string.Empty
            //    //           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            //    //tC.Text = (from DataGridViewRow row in dataGridView1.Rows
            //    //           where row.Cells[4].FormattedValue.ToString() != string.Empty
            //    //           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            //    //textBox1.Text = dataGridView1.Rows.Count.ToString();
            //    //double xx1, yy1, zz1;
            //    //xx1 = Convert.ToDouble(tD.Text);
            //    //yy1 = Convert.ToDouble(tC.Text);
            //    //zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            //    //df.Text = Convert.ToString(zz1);


            //    //string s = (from DataGridViewRow row in dataGridViewX2.Rows
            //    //            where row.Cells[2].FormattedValue.ToString() != string.Empty
            //    //            select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
            //    //string f = (from DataGridViewRow row in dataGridViewX2.Rows
            //    //            where row.Cells[3].FormattedValue.ToString() != string.Empty
            //    //            select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

            //    //double xx, yy, zz;
            //    //xx = Convert.ToDouble(s);
            //    //yy = Convert.ToDouble(f);
            //    //zz = Convert.ToDouble(s) - Convert.ToDouble(f);
            //    //TTT.Text = Convert.ToString(zz);
            //    //// dataGridView1.AllowUserToAddRows = true;


            //    //PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //    //                where row.Cells[21].Value.ToString() == "1"
            //    //                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
            //    //Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //    //                 where row.Cells[21].Value.ToString() == "1"
            //    //                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            //    //double PrD, PRC, PRT;
            //    //PrD = Convert.ToDouble(PrDebit.Text);
            //    //PRC = Convert.ToDouble(Prcridit.Text);
            //    //PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
            //    //PrTot.Text = Convert.ToString(PRT);
            //    //dataGridView1.AllowUserToAddRows = true;


            //    //CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //    //                where row.Cells[21].Value.ToString() == "2"
            //    //                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
            //    //CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //    //                 where row.Cells[21].Value.ToString() == "2"
            //    //                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            //    //double CaD, CaC, CaT;
            //    //CaD = Convert.ToDouble(CaDebit.Text);
            //    //CaC = Convert.ToDouble(CaCridit.Text);
            //    //CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
            //    //CaTolt.Text = Convert.ToString(CaT);


            //    ////}
            //    ////else
            //    ////{
            //    GetParentIDKind();
            //    ComboInDataGrid();
            //    textBox13.Text = "";
            //    textBox14.Text = "";
            //    dateTimePicker1.Focus();
            //    CleareControls();
            //    GetREstrictionID();
            //    FindFileNumber1();
            //    GetDocumentData();

            //    //PresessingSaveBtn();
            //    // GetDocID();
            //    Getex();
            //    GetMan();
            //    GetUsf();
            //    Getcate();
            //    GetHand();
            //    GetRespon();
            //    GetHand();
            //    GetOrdersIDDocument();
            //    BrokerAccount();
            //    dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
            //    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
            //               where row.Cells[3].FormattedValue.ToString() != string.Empty
            //               select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            //    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
            //               where row.Cells[4].FormattedValue.ToString() != string.Empty
            //               select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            //    textBox1.Text = dataGridView1.Rows.Count.ToString();
            //    double xx1, yy1, zz1;
            //    xx1 = Convert.ToDouble(tD.Text);
            //    yy1 = Convert.ToDouble(tC.Text);
            //    zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            //    df.Text = Convert.ToString(zz1);


            //    string s = (from DataGridViewRow row in dataGridViewX2.Rows
            //                where row.Cells[2].FormattedValue.ToString() != string.Empty
            //                select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
            //    string f = (from DataGridViewRow row in dataGridViewX2.Rows
            //                where row.Cells[3].FormattedValue.ToString() != string.Empty
            //                select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

            //    double xx, yy, zz;
            //    xx = Convert.ToDouble(s);
            //    yy = Convert.ToDouble(f);
            //    zz = Convert.ToDouble(s) - Convert.ToDouble(f);
            //    TTT.Text = Convert.ToString(zz);
            //    // dataGridView1.AllowUserToAddRows = true;

            //    PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //                    where row.Cells[21].Value.ToString() == "1"
            //                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
            //    Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //                     where row.Cells[21].Value.ToString() == "1"
            //                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            //    double PrD, PRC, PRT;
            //    PrD = Convert.ToDouble(PrDebit.Text);
            //    PRC = Convert.ToDouble(Prcridit.Text);
            //    PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
            //    PrTot.Text = Convert.ToString(PRT);
            //    //dataGridView1.AllowUserToAddRows = true;


            //    CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //                    where row.Cells[21].Value.ToString() == "2"
            //                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
            //    CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
            //                     where row.Cells[21].Value.ToString() == "2"
            //                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

            //    double CaD, CaC, CaT;
            //    CaD = Convert.ToDouble(CaDebit.Text);
            //    CaC = Convert.ToDouble(CaCridit.Text);
            //    CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
            //    CaTolt.Text = Convert.ToString(CaT);
            //    try
            //    {
            //        this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet1.Tbl_Fiscalyear);
            //    }
            //    catch
            //    { }
            //    //}
            //}
            //catch
            //{ }
            

        }

        private void checkBox8_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                //MessageBox.Show("العام المالى تم إغلاقة ولا يمكنك التعديل علية");
                comboBox3.BackColor = Color.Red;
            }
            if (checkBox8.Checked == false)
            {
                //MessageBox.Show("العام المالى تم إغلاقة ولا يمكنك التعديل علية");
                comboBox3.BackColor = Color.White;
            }
        }

        private void Res_Frm_Activated(object sender, EventArgs e)
        {

        }

        private void ultraPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.SuppliersFrm sfr = new Forms.BasicCodeForms.SuppliersFrm();
            sfr.Show();
        }

        private void exCenter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Empc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Restriction_NO.Text = "0";
            CleareControls();
            FindFileNumber1();
            GetDocumentData();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Rows.Clear();
            dataGridViewX2.Rows.Clear();
            // MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
            CaDebit.Text = "0";
            CaCridit.Text = "0";
            CaTolt.Text = "0";
            PrDebit.Text = "0";
            Prcridit.Text = "0";
            Prcridit.Text = "0";
            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            textBox1.Text = dataGridView1.Rows.Count.ToString();
            double xx1, yy1, zz1;
            xx1 = Convert.ToDouble(tD.Text);
            yy1 = Convert.ToDouble(tC.Text);
            zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
            df.Text = Convert.ToString(zz1);
            Restriction_NO.Focus();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (switchButton2.Value == true)
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 3);
                if (validationSaveUser != null)
                {
                    if (CategortID.Text != string.Empty)
                    {
                        if (dataGridView1.Rows.Count > 0 && checkBox8.Checked == false)
                        {
                            if (dateTimePicker1.Value >= dateTimePicker3.Value || dateTimePicker1.Value <= dateTimePicker4.Value)
                            {
                                //this.KeyPreview = true;
                                //MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");

                                dataGridView1.AllowUserToAddRows = false;


                                UpdateHeader();
                                UpdateRes();
                                FindFileNumber1();
                                GetDocumentData();
                                try
                                {//next
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                                    SqlCommand com = new SqlCommand();
                                    SqlCommand com1 = new SqlCommand();
                                    com.CommandType = CommandType.Text;
                                    com1.CommandType = CommandType.Text;
                                    SqlDataReader red;
                                    com.Connection = con;
                                    com.CommandText = ("select top(1) Restriction_NO, LAG(Restriction_NO) OVER ( ORDER BY Restriction_NO) from Tbl_AccountingRestriction where Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D2 OR Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D3     ");
                                    com.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Restriction_NO.Text;
                                    com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                                    com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
                                    con.Open();
                                    red = com.ExecuteReader();

                                    while (red.Read())
                                    {
                                        Restriction_NO.Text = red.GetValue(0).ToString();
                                    }
                                    if (!red.HasRows)
                                    {
                                        Restriction_NO.Text = "0";
                                    }
                                    red.Close();
                                    con.Close();
                                    CleareControls();
                                    GetParentIDKind();
                                    ComboInDataGrid();
                                    textBox13.Text = "";
                                    textBox14.Text = "";
                                    dateTimePicker1.Focus();


                                    GetREstrictionID();
                                    FindFileNumber1();
                                    GetDocumentData();

                                    //PresessingSaveBtn();
                                    // GetDocID();
                                    Getex();
                                    GetMan();
                                    GetUsf();
                                    Getcate();
                                    GetHand();
                                    GetRespon();
                                    GetHand();
                                    GetOrdersIDDocument();
                                    BrokerAccount();
                                    dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
                                    dataGridViewX4.Visible = false;
                                    UseFULL_Kind.Text = DBNull.Value.ToString();
                                    Lyear.Text = DBNull.Value.ToString();
                                    GetManagamentBYUsefull();
                                }
                                catch { }
                                //FindFileNumber1();
                                //GetDocumentData();
                            }
                        }
                        if (checkBox8.Checked == true)
                        {
                            MessageBox.Show("العام المالى تم إغلاقة ولا يمكنك التعديل علية");
                        }
                        if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
                        {

                            MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
                        }
                    }
                    if (CategortID.Text == string.Empty)
                    {
                        //MessageBox.Show("من فضلك أختر البيان بشكل صحيح");
                        //Descp.Focus();
                    }

                }//****************
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل القيود .. برجاء مراجعة مدير المنظومه");
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 4);
            //if (validationSaveUser != null)
            //{
            //    DialogResult result = new DialogResult();
            //    result = MessageBox.Show(" هل أنت متأكد من حذف البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == System.Windows.Forms.DialogResult.Yes && checkBox8.Checked == false)
            //    {
            //        //if (dateTimePicker1.Value >= dateTimePicker3.Value || dateTimePicker1.Value <= dateTimePicker4.Value)
            //        //{

            //            //MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");

            //            SqlConnection con = new SqlConnection();
            //            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            //            SqlCommand com = new SqlCommand();
            //            SqlCommand com1 = new SqlCommand();
            //            com.CommandType = CommandType.Text;
            //            com1.CommandType = CommandType.Text;
            //            SqlDataReader red;
            //            com.Connection = con;

            //            com.CommandText = ("delete from Tbl_AccountingRestrictionItems  where ID=@ID   ");

            //            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value);
            //            con.Open();

            //            com.ExecuteNonQuery();
            //            con.Close();
            //            //}
            //            //FindFileNumber();
            //            //if (dataGridView1.Rows.Count == 0)
            //            //{
            //            FindFileNumber1();
            //            GetDocumentData();
            //            //}
            //            MessageBox.Show("تم حذف  بند القيد بنجاح");
            //            //---------------خفظ ااحداث 
            //            SecurityEvent sev = new SecurityEvent
            //            {
            //                ActionName = "حذف بند قيد",
            //                TableName = "Tbl_AccountingRestrictionItems",
            //                TableRecordId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value).ToString(),
            //                //TrecordId = int.Parse(textEdit2.Text),
            //                Description = "",
            //                ManagementName = Program.GlbV_Management,
            //                ActionDate = Convert.ToDateTime(DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
            //                EmployeeName = Program.GlbV_EmpName,
            //                User_ID = Program.GlbV_UserId,
            //                UserName = Program.GlbV_UserName,
            //                FormName = "شاشة القيود المحاسبيه"


            //            };
            //            FsEvDb.SecurityEvents.Add(sev);
            //            FsEvDb.SaveChanges();
            //            //************************************
            //            //if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count)
            //            //{

            //            //    dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Selected = true;

            //        //}





            //        //}


            //    }
            //    if (checkBox8.Checked == true)
            //    {
            //        MessageBox.Show("العام المالى تم إغلاقة ولا يمكنك التعديل علية");
            //    }
            //    //if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
            //    //{

            //    //    MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
            //    //}
            //}
            //else
            //{
            //    MessageBox.Show("ليس لديك صلاحية حذف بندقيود .. برجاء مراجعة مدير المنظومه");
            //}
            MessageBox.Show("F3 اضغط من لوحة المفاتيح");
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {//first
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    UseFULL_Kind.Text = "";
                    labelControl1.Visible = false;
                    panel2.Visible = false;
                    chckBxBasicData.Checked = false;
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox36.Text = "";
                    textBox19.Text = "";
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    dataGridViewX8.Rows.Clear();
                    chckBxBasicData.Checked = false;

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                    {
                        using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3 ORDER BY Restriction_NO ASC", con))
                        {
                            com.Parameters.AddWithValue("@D2", x);
                            com.Parameters.AddWithValue("@D3", y);

                            con.Open();
                            object result = com.ExecuteScalar();
                            if (result != null)
                            {
                                Restriction_NO.Text = result.ToString();
                            }
                            else
                            {
                                Restriction_NO.Text = "0";
                            }
                        }
                        con.Close();
                    }


                    button2_Click_1(sender, e);
                }
            }
            catch { }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {//next
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    UseFULL_Kind.Text = "";
                    labelControl1.Visible = false;
                    panel2.Visible = false;
                    chckBxBasicData.Checked = false;
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox36.Text = "";
                    textBox19.Text = "";
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    dataGridViewX8.Rows.Clear();
                    chckBxBasicData.Checked = false;
                    //button2_Click_1(sender, e);
                    //dateTimePicker1.Focus();
                    if (comboBox4.Items.Count > 1)
                    {
                        comboBox4.SelectedValue = 1;
                    }
                    if (checkBox15.Checked == true)
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                        {
                            using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE Restriction_NO > @Restriction_NO AND (AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3) ORDER BY Restriction_NO ASC", con))
                            {
                                com.Parameters.AddWithValue("@Restriction_NO", int.Parse(Restriction_NO.Text));
                                com.Parameters.AddWithValue("@D2", x);
                                com.Parameters.AddWithValue("@D3", y);

                                con.Open();
                                SqlDataReader red = com.ExecuteReader();

                                if (red.Read())
                                {
                                    Restriction_NO.Text = red["Restriction_NO"].ToString();
                                }
                                else
                                {
                                    Restriction_NO.Text = "0";
                                }

                                red.Close();
                            }
                            con.Close();
                        }


                        button2_Click_1(sender, e);
                    }
                    if (checkBox15.Checked == false)
                    {
                        int x = Convert.ToInt32(Restriction_NO.Text);
                        int y = 1;
                        int t = x + y;
                        Restriction_NO.Text = Convert.ToString(t);


                        button2_Click_1(sender, e);
                    }
                }
            }
            catch { }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            { //prev
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    UseFULL_Kind.Text = "";
                    labelControl1.Visible = false;
                    panel2.Visible = false;
                    chckBxBasicData.Checked = false;
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox36.Text = "";
                    textBox19.Text = "";
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    dataGridViewX8.Rows.Clear();
                    chckBxBasicData.Checked = false;
                    if (checkBox15.Checked == true)
                    {
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                        {
                            using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE Restriction_NO < @Restriction_NO AND (AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3) ORDER BY Restriction_NO DESC", con))
                            {
                                com.Parameters.AddWithValue("@Restriction_NO", int.Parse(Restriction_NO.Text));
                                com.Parameters.AddWithValue("@D2", x);
                                com.Parameters.AddWithValue("@D3", y);

                                con.Open();
                                SqlDataReader red = com.ExecuteReader();

                                if (red.Read())
                                {
                                    Restriction_NO.Text = red["Restriction_NO"].ToString();
                                }
                                else
                                {
                                    Restriction_NO.Text = "0";
                                }

                                red.Close();
                            }
                            con.Close();
                        }



                        button2_Click_1(sender, e);
                    }
                    if (checkBox15.Checked == false)
                    {
                        int x = Convert.ToInt32(Restriction_NO.Text);
                        int y = 1;
                        int t = x - y;
                        Restriction_NO.Text = Convert.ToString(t);


                        button2_Click_1(sender, e);
                    }
                }
            }
            catch { }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {//last
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    UseFULL_Kind.Text = "";
                    labelControl1.Visible = false;
                    panel2.Visible = false;
                    chckBxBasicData.Checked = false;
                    textBox29.Text = "";
                    textBox30.Text = "";
                    textBox36.Text = "";
                    textBox19.Text = "";
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    dataGridViewX8.Rows.Clear();
                    chckBxBasicData.Checked = false;
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
                    {
                        using (SqlCommand com = new SqlCommand("SELECT TOP(1) Restriction_NO FROM Tbl_AccountingRestriction WHERE AccountingRestrictionKind_ID = @D2 OR AccountingRestrictionKind_ID = @D3 ORDER BY Restriction_NO DESC", con))
                        {
                            com.Parameters.AddWithValue("@D2", x);
                            com.Parameters.AddWithValue("@D3", y);

                            con.Open();
                            using (SqlDataReader red = com.ExecuteReader())
                            {
                                if (red.Read())
                                {
                                    Restriction_NO.Text = red.GetValue(0).ToString();
                                }
                                else
                                {
                                    Restriction_NO.Text = "0";
                                }
                            }
                            con.Close();
                        }
                    }



                    button2_Click_1(sender, e);
                }
            }
            catch { }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.CategoryFrm ctgfrm = new Forms.BasicCodeForms.CategoryFrm();
            ctgfrm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Fiscalyear f = new Fiscalyear();
            f.ShowDialog();
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            //try
            this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.Fill(this.financialSysDataSet.Tbl_RestrictionItemsCategory_With_AccountNumber);


            foreach (DataGridViewRow row1 in dataGridView2.Rows)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.AllowUserToAddRows = false;

                    if (CategortID.Text == row1.Cells[3].Value.ToString())
                    {
                        if (row.Cells[6].Value.ToString() == row1.Cells[1].Value.ToString())
                        {
                            row.Cells[10].Value = row1.Cells[2].Value;
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                            con.Open();
                            SqlDataAdapter da = new SqlDataAdapter("select Name from Tbl_RestrictionItemsCategory where ID='" + row.Cells[10].Value + "'", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //MessageBox.Show(dt.Rows.Count.ToString());
                            if (dt.Rows.Count > 0)
                            {
                                row.Cells[9].Value = dt.Rows[0][0].ToString();
                            }
                            con.Close();


                        }
                    }
                }
            }
            dataGridView1.AllowUserToAddRows = true;
            //}
            //catch { }
        }

        private void CategortID_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.Fill(this.financialSysDataSet.Tbl_RestrictionItemsCategory_With_AccountNumber);
            foreach (DataGridViewRow row3 in dataGridView1.Rows)
            {
                row3.Cells[9].Value = DBNull.Value;
                row3.Cells[10].Value = DBNull.Value;
            }
            foreach (DataGridViewRow row1 in dataGridView2.Rows)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.AllowUserToAddRows = false;

                    if (CategortID.Text == row1.Cells[3].Value.ToString())
                    {
                        if (row.Cells[6].Value.ToString() == row1.Cells[1].Value.ToString())
                        {
                            row.Cells[10].Value = row1.Cells[2].Value;
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                            con.Open();
                            SqlDataAdapter da = new SqlDataAdapter("select Name from Tbl_RestrictionItemsCategory where ID='" + row.Cells[10].Value + "'", con);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //   MessageBox.Show(dt.Rows.Count.ToString());
                            if (dt.Rows.Count > 0)
                            {
                                row.Cells[9].Value = dt.Rows[0][0].ToString();
                            }
                            con.Close();


                        }
                    }
                }
            }
            dataGridView1.AllowUserToAddRows = true;
            //}
            //catch { }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.DocCategorySetup f = new DocCategorySetup();
            f.ShowDialog();
        }
        private void GetManagamentBYUsefull()
        {
            Nutional_ID.Text = DBNull.Value.ToString();
            //Manag.Text = DBNull.Value.ToString();
            //ManagID.Text = DBNull.Value.ToString();
            GetEMPIDBYUsefull();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = "SELECT        Tbl_Management.Name , Tbl_Management.ID, Tbl_Employee.NationalId FROM  Tbl_Employee INNER JOIN  Tbl_Management ON Tbl_Employee.Management_ID = Tbl_Management.Management_ID where Tbl_Employee.ID=@ID";
            if (Emp_ID.Text != string.Empty)
            {
                com.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(Emp_ID.Text);
            }
            if (Emp_ID.Text == string.Empty)
            {
                com.Parameters.Add("@ID", SqlDbType.Int).Value = DBNull.Value;
            }
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                Manag.Text = red.GetValue(0).ToString();
                ManagID.Text = red.GetValue(1).ToString();
                Nutional_ID.Text = red.GetValue(2).ToString();
            }
            red.Close();
            con.Close();
        }
        private void GetManagamentBYExCenter()
        {
            Nutional_ID.Text = DBNull.Value.ToString();
            //Manag.Text = DBNull.Value.ToString();
            //ManagID.Text = DBNull.Value.ToString();
            //GetEMPIDBYUsefull();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = "SELECT        Tbl_Management.Name , Tbl_Management.ID FROM  Tbl_ExchangeCenter INNER JOIN  Tbl_Management ON Tbl_ExchangeCenter.Mnagement_ID = Tbl_Management.Management_ID where Tbl_ExchangeCenter.ID=@ID";
            if (exID.Text != string.Empty)
            {
                com.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(exID.Text);
            }
            if (exID.Text == string.Empty)
            {
                com.Parameters.Add("@ID", SqlDbType.Int).Value = DBNull.Value;
            }
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                Manag.Text = red.GetValue(0).ToString();
                ManagID.Text = red.GetValue(1).ToString();
                //Nutional_ID.Text = red.GetValue(2).ToString();
            }
            red.Close();
            con.Close();
        }
        private void GetEMPIDBYUsefull()
        {
            Emp_ID.Text = null;
            UsFulID.Text = null;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = "SELECT ID_Emp,ID  FROM  Tbl_Beneficiary  WHERE  ID = @ID";
            com.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(UsFulID.Text);
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                Emp_ID.Text = red.GetValue(0).ToString();
                UsFulID.Text = red.GetValue(1).ToString();
            }
            red.Close();
            con.Close();

        }
        private void GetEMPIDBYUsefull1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlDataReader red;
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = "SELECT Tbl_BeneficiaryKind.Name FROM  Tbl_BeneficiaryKind INNER JOIN Tbl_Beneficiary ON Tbl_BeneficiaryKind.ID = Tbl_Beneficiary.BeneficiaryKind_ID WHERE        (Tbl_Beneficiary.ID = @ID)";
            com.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(UsFulID.Text);
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                UseFULL_Kind.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();
        }
        private void UsFul_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void Emp_ID_Click(object sender, EventArgs e)
        {
            GetManagamentBYUsefull();
        }

        private void Nutional_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Nutional_ID.Text != DBNull.Value.ToString())
                {
                    dataGridViewX4.Visible = true;
                    this.tbl_HummanResourceTableAdapter.FillByNational_ID(this.financialSysDataSet.Tbl_HummanResource, decimal.Parse(Nutional_ID.Text));
                }
                if (Nutional_ID.Text == DBNull.Value.ToString())
                {
                    dataGridViewX4.Visible = false;
                }
            }
            catch { dataGridViewX4.Rows.Clear(); }
        }

        private void dateTimePicker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOrdersID();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 1002);
            if (validationSaveUser != null)
            {
                Forms.ProcessingForms.Fiscalyear f = new Fiscalyear();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية على اعدادات القيود .. برجاء مراجعة مدير المنظومه");
            }

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 1002);
            if (validationSaveUser != null)
            {
                DocCategorySetup f = new DocCategorySetup();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية على اعدادات القيود .. برجاء مراجعة مدير المنظومه");
            }

        }
        public void GetOrderMoared()
        {
            //try
            //{
            //UseFULL_Kind.Text = "";
            dataGridViewX5.Rows.Clear();
            dataGridViewX6.Rows.Clear();
            if (UseFULL_Kind.Text == "مورد")
            {

                //DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlDataReader red;
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = ("SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [أسم الحساب],  dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, dbo.Tbl_BeneficiaryKind.Name AS النوع, dbo.Tbl_Beneficiary.Name AS[اسم المورد],    dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID FROM            dbo.Tbl_AccountingRestrictionItems INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID = dbo.Tbl_Accounting_Guid.ID INNER JOIN  dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID INNER JOIN dbo.Tbl_BeneficiaryKind INNER JOIN dbo.Tbl_Beneficiary ON dbo.Tbl_BeneficiaryKind.ID = dbo.Tbl_Beneficiary.BeneficiaryKind_ID INNER JOIN  dbo.TBL_Document ON dbo.Tbl_Beneficiary.ID = dbo.TBL_Document.Beneficiary_ID ON dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID WHERE(dbo.Tbl_Beneficiary.ID = @P)  ");
                com.Parameters.Clear();
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = UsFulID.Text;
                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {
                    //comboBox2.Items.Add(red.GetValue(0)).ToString();
                    dataGridViewX5.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8));
                }
                red.Close();
                con.Close();
            }
            if (UseFULL_Kind.Text != "موظف" || UseFULL_Kind.Text != "مورد")
            {
                //DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlDataReader red;
                com.CommandType = CommandType.Text;
                com.Connection = con;
                com.CommandText = ("SELECT        dbo.Tbl_AccountingRestriction.Restriction_NO AS [رقم المستند], dbo.Tbl_AccountingRestriction.Restriction_Date AS [تاريخ المستند], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_Accounting_Guid.Name AS [أسم الحساب],  dbo.Tbl_AccountingRestrictionItems.Debit_Value AS مدين, dbo.Tbl_AccountingRestrictionItems.Credit_Value AS دائن, dbo.Tbl_BeneficiaryKind.Name AS النوع, dbo.Tbl_Beneficiary.Name AS[اسم المورد],  dbo.Tbl_AccountingRestriction.AccountingRestrictionKind_ID, dbo.Tbl_SupplierKind.Name FROM   dbo.Tbl_AccountingRestrictionItems INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID = dbo.Tbl_Accounting_Guid.ID INNER JOIN dbo.Tbl_AccountingRestriction ON dbo.Tbl_AccountingRestrictionItems.AccountingRestriction_ID = dbo.Tbl_AccountingRestriction.ID INNER JOIN dbo.Tbl_BeneficiaryKind INNER JOIN dbo.Tbl_Beneficiary ON dbo.Tbl_BeneficiaryKind.ID = dbo.Tbl_Beneficiary.BeneficiaryKind_ID INNER JOIN dbo.TBL_Document ON dbo.Tbl_Beneficiary.ID = dbo.TBL_Document.Beneficiary_ID ON dbo.Tbl_AccountingRestriction.Document_ID = dbo.TBL_Document.ID INNER JOIN dbo.Tbl_Supplier ON dbo.Tbl_Beneficiary.ID_Supp = dbo.Tbl_Supplier.ID INNER JOIN dbo.Tbl_SupplierKind ON dbo.Tbl_Supplier.SuplierKind = dbo.Tbl_SupplierKind.ID WHERE (dbo.Tbl_Beneficiary.Name = @P)");
                com.Parameters.Clear();
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = UsFul.Text;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {
                    //comboBox2.Items.Add(red.GetValue(0)).ToString();
                    dataGridViewX6.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8));
                }
                red.Close();
                con.Close();
            }
            //}
            //catch { }

        }

        private void UseFULL_Kind_TextChanged(object sender, EventArgs e)
        {

        }
        public void FindFileNumber2()
        {
            //if (Convert.ToInt32(textBox16.Text) == 12)
            //{
            //    x = 1;
            //    y = 2;
            //}

            //if (Convert.ToInt32(textBox16.Text) == 13)
            //{
            //    x = 3;
            //    y = 3;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 14)
            //{
            //    x = 4;
            //    y = 4;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 15)
            //{
            //    x = 5;
            //    y = 5;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 16)
            //{
            //    x = 6;
            //    y = 6;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 17)
            //{
            //    x = 7;
            //    y = 7;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 18)
            //{
            //    x = 8;
            //    y = 8;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 19)
            //{
            //    x = 9;
            //    y = 9;
            //}
            dataGridView1.Rows.Clear();
            dataGridViewX5.AllowUserToAddRows = false;
            if (dataGridViewX5.Rows.Count > 0)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.Accounting_Guid_ID ,Tbl_Activities.Name as[النشاط] ,Tbl_Activities.ID,Tbl_RestrictionItemsCategory.Name as [التصنيف],Tbl_RestrictionItemsCategory.ID, Tbl_CostCenters.Name ,Tbl_AccountingRestrictionItems.CostCenters_ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID,Tbl_Accounting_Guid.BrokerAccount,HighamountsAccount,PersonalAccount from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID Left Join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID left join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID left join Tbl_CostCenters on Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2  OR Tbl_AccountingRestriction.Restriction_NO = @D and Tbl_AccountingRestrictions_Kind.id = @D3  Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

                //if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
                //{
                //    x = 1;
                //    y = 2;
                //}

                //if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
                //{
                //    x = 1;
                //    y = 2;
                //}
                //if (Convert.ToInt32(comboBox1.SelectedValue) != 2 && Convert.ToInt32(comboBox1.SelectedValue) != 1)
                //{
                //    x = Convert.ToInt32(comboBox1.SelectedValue);
                //    y = Convert.ToInt32(comboBox1.SelectedValue);
                //}
                //if (Convert.ToInt32(comboBox1.SelectedValue) != 1 && Convert.ToInt32(comboBox1.SelectedValue) != 2)
                //{
                //    x = Convert.ToInt32(comboBox1.SelectedValue);
                //    y = Convert.ToInt32(comboBox1.SelectedValue);
                //}

                Restriction_NO.Text = dataGridViewX5.CurrentRow.Cells[0].Value.ToString();
                com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;
                //if (comboBox1.Text != "عمليات" || comboBox1.Text != "مدفوعات"  ) 
                //{
                com.Parameters.Add("@D2", SqlDbType.Int).Value = Convert.ToInt32(dataGridViewX5.CurrentRow.Cells[8].Value);
                com.Parameters.Add("@D3", SqlDbType.Int).Value = Convert.ToInt32(dataGridViewX5.CurrentRow.Cells[8].Value);
                //}

                //if (comboBox1.Text == "عمليات" || comboBox1.Text == "مدفوعات")
                //{
                //    com.Parameters.Add("@D2", SqlDbType.Int).Value = 1;
                //    com.Parameters.Add("@D3", SqlDbType.Int).Value = 2;
                //}
                con.Open();
                red = com.ExecuteReader();
                if (red.HasRows)
                {
                    while (red.Read())
                    {
                        dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8), red.GetValue(9), red.GetValue(10), red.GetValue(11), red.GetValue(12), red.GetValue(13), red.GetValue(14), 0, 0, 0, 0, 0, 0, red.GetValue(15), red.GetValue(16), red.GetValue(17), red.GetValue(18));
                    }
                    red.Close();


                    //da.SelectCommand = com;

                    //da.SelectCommand = com;
                    //com.ExecuteScalar();

                    //da.Fill(dt);





                    com1.Connection = con;
                    com1.CommandText = ("select Restriction_Date,AcountingRestrictionCorrRelation_ID  from Tbl_AccountingRestriction  where Tbl_AccountingRestriction.Restriction_NO =  @D and AccountingRestrictionKind_ID=@D1 OR Tbl_AccountingRestriction.Restriction_NO =  @D and AccountingRestrictionKind_ID=@D2 ");

                    //com1.CommandText = ("select Restriction_Date ,Document_ID,  Tbl_Descrption.Name from Tbl_AccountingRestriction inner join TBL_Document on  Tbl_AccountingRestriction.Document_ID = TBL_Document.ID inner join Tbl_Descrption on TBL_Document.DescrptionID = Tbl_Descrption.ID  where Tbl_AccountingRestriction.Restriction_NO =  @D ");

                    com1.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;
                    com1.Parameters.Add("@D1", SqlDbType.VarChar).Value = Convert.ToInt32(dataGridViewX5.CurrentRow.Cells[8].Value);
                    com1.Parameters.Add("@D2", SqlDbType.VarChar).Value = Convert.ToInt32(dataGridViewX5.CurrentRow.Cells[8].Value);
                    //con.Open();
                    SqlDataReader red1;
                    red1 = com1.ExecuteReader();
                    while (red1.Read())
                    {

                        dateTimePicker1.Text = red1.GetValue(0).ToString();
                        Lyear.Text = red1.GetValue(1).ToString();
                        //DocNO.Text = red.GetValue(1).ToString();
                        //Descp.Text = red.GetValue(2).ToString();

                    }
                    red1.Close();
                    con.Close();
                    if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
                    {
                        dataGridView1.Rows.Clear();
                        MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
                    }
                    //return dt;
                    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[3].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[4].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                    textBox1.Text = dataGridView1.Rows.Count.ToString();
                    double xx, yy, zz;
                    xx = Convert.ToDouble(tD.Text);
                    yy = Convert.ToDouble(tC.Text);
                    zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                    df.Text = Convert.ToString(zz);
                    //dataGridView1.AllowUserToAddRows = true;
                }
            }
        }
        public void FindFileNumber3()
        {
            //if (Convert.ToInt32(textBox16.Text) == 12)
            //{
            //    x = 1;
            //    y = 2;
            //}

            //if (Convert.ToInt32(textBox16.Text) == 13)
            //{
            //    x = 3;
            //    y = 3;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 14)
            //{
            //    x = 4;
            //    y = 4;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 15)
            //{
            //    x = 5;
            //    y = 5;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 16)
            //{
            //    x = 6;
            //    y = 6;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 17)
            //{
            //    x = 7;
            //    y = 7;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 18)
            //{
            //    x = 8;
            //    y = 8;
            //}
            //if (Convert.ToInt32(textBox16.Text) == 19)
            //{
            //    x = 9;
            //    y = 9;
            //}
            dataGridView1.Rows.Clear();
            if (dataGridViewX6.Rows.Count > 0)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.Accounting_Guid_ID ,Tbl_Activities.Name as[النشاط] ,Tbl_Activities.ID,Tbl_RestrictionItemsCategory.Name as [التصنيف],Tbl_RestrictionItemsCategory.ID, Tbl_CostCenters.Name ,Tbl_AccountingRestrictionItems.CostCenters_ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID,Tbl_Accounting_Guid.BrokerAccount,HighamountsAccount,PersonalAccount from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID Left Join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID left join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID left join Tbl_CostCenters on Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2  OR Tbl_AccountingRestriction.Restriction_NO = @D and Tbl_AccountingRestrictions_Kind.id = @D3  Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

                //if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
                //{
                //    x = 1;
                //    y = 2;
                //}

                //if (Convert.ToInt32(comboBox1.SelectedValue) == 2)
                //{
                //    x = 1;
                //    y = 2;
                //}
                //if (Convert.ToInt32(comboBox1.SelectedValue) != 2 && Convert.ToInt32(comboBox1.SelectedValue) != 1)
                //{
                //    x = Convert.ToInt32(comboBox1.SelectedValue);
                //    y = Convert.ToInt32(comboBox1.SelectedValue);
                //}
                //if (Convert.ToInt32(comboBox1.SelectedValue) != 1 && Convert.ToInt32(comboBox1.SelectedValue) != 2)
                //{
                //    x = Convert.ToInt32(comboBox1.SelectedValue);
                //    y = Convert.ToInt32(comboBox1.SelectedValue);
                //}

                Restriction_NO.Text = dataGridViewX6.CurrentRow.Cells[0].Value.ToString();
                com.Parameters.Add("@D", SqlDbType.VarChar).Value = dataGridViewX6.CurrentRow.Cells[0].Value;
                //if (comboBox1.Text != "عمليات" || comboBox1.Text != "مدفوعات"  ) 
                //{
                com.Parameters.Add("@D2", SqlDbType.Int).Value = dataGridViewX6.CurrentRow.Cells[8].Value;
                com.Parameters.Add("@D3", SqlDbType.Int).Value = dataGridViewX6.CurrentRow.Cells[8].Value;
                //}

                //if (comboBox1.Text == "عمليات" || comboBox1.Text == "مدفوعات")
                //{
                //    com.Parameters.Add("@D2", SqlDbType.Int).Value = 1;
                //    com.Parameters.Add("@D3", SqlDbType.Int).Value = 2;
                //}
                con.Open();
                red = com.ExecuteReader();
                if (red.HasRows)
                {
                    while (red.Read())
                    {
                        dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8), red.GetValue(9), red.GetValue(10), red.GetValue(11), red.GetValue(12), red.GetValue(13), red.GetValue(14), 0, 0, 0, 0, 0, 0, red.GetValue(15), red.GetValue(16), red.GetValue(17), red.GetValue(18));
                    }
                    red.Close();


                    //da.SelectCommand = com;

                    //da.SelectCommand = com;
                    //com.ExecuteScalar();

                    //da.Fill(dt);





                    com1.Connection = con;
                    com1.CommandText = ("select Restriction_Date,AcountingRestrictionCorrRelation_ID  from Tbl_AccountingRestriction  where Tbl_AccountingRestriction.Restriction_NO =  @D and AccountingRestrictionKind_ID=@D1 OR Tbl_AccountingRestriction.Restriction_NO =  @D and AccountingRestrictionKind_ID=@D2 ");

                    //com1.CommandText = ("select Restriction_Date ,Document_ID,  Tbl_Descrption.Name from Tbl_AccountingRestriction inner join TBL_Document on  Tbl_AccountingRestriction.Document_ID = TBL_Document.ID inner join Tbl_Descrption on TBL_Document.DescrptionID = Tbl_Descrption.ID  where Tbl_AccountingRestriction.Restriction_NO =  @D ");

                    com1.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;
                    com1.Parameters.Add("@D1", SqlDbType.VarChar).Value = dataGridViewX6.CurrentRow.Cells[8];
                    com1.Parameters.Add("@D2", SqlDbType.VarChar).Value = dataGridViewX6.CurrentRow.Cells[8];
                    //con.Open();
                    SqlDataReader red1;
                    red1 = com1.ExecuteReader();
                    while (red1.Read())
                    {

                        dateTimePicker1.Text = red1.GetValue(0).ToString();
                        Lyear.Text = red1.GetValue(1).ToString();
                        //DocNO.Text = red.GetValue(1).ToString();
                        //Descp.Text = red.GetValue(2).ToString();

                    }
                    red1.Close();
                    con.Close();
                    if (dateTimePicker1.Value < dateTimePicker3.Value || dateTimePicker1.Value > dateTimePicker4.Value)
                    {
                        dataGridView1.Rows.Clear();
                        MessageBox.Show("تاريخ المستند غير موجود فى الفترة المالية للعام المالى الحالى");
                    }
                    //return dt;
                    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[3].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[4].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                    textBox1.Text = dataGridView1.Rows.Count.ToString();
                    double xx, yy, zz;
                    xx = Convert.ToDouble(tD.Text);
                    yy = Convert.ToDouble(tC.Text);
                    zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                    df.Text = Convert.ToString(zz);
                    //dataGridView1.AllowUserToAddRows = true;
                }
            }
        }
        private void dataGridViewX5_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridViewX6_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridViewX5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

            //}
            //textBox10.Text = "";
            GetParentIDKind();
            ComboInDataGrid();
            textBox13.Text = "";
            textBox14.Text = "";
            //UseFULL_Kind.Text = "";

            dateTimePicker1.Focus();

            //CleareControls();
            GetREstrictionID();
            FindFileNumber2();
            GetDocumentData();

            //PresessingSaveBtn();
            // GetDocID();
            Getex();
            GetMan();
            GetUsf();
            Getcate();
            GetHand();
            GetRespon();
            GetHand();
            GetOrdersIDDocument();
            BrokerAccount();
            dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
            dataGridViewX4.Visible = false;
            UseFULL_Kind.Text = DBNull.Value.ToString();
            Lyear.Text = DBNull.Value.ToString();
            GetManagamentBYUsefull();

            //}
            //catch { }
        }

        private void dataGridViewX6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //}
                //textBox10.Text = "";
                GetParentIDKind();
                ComboInDataGrid();
                textBox13.Text = "";
                textBox14.Text = "";
                UseFULL_Kind.Text = "";

                dateTimePicker1.Focus();

                CleareControls();
                GetREstrictionID();
                FindFileNumber3();
                GetDocumentData();

                //PresessingSaveBtn();
                // GetDocID();
                Getex();
                GetMan();
                GetUsf();
                Getcate();
                GetHand();
                GetRespon();
                GetHand();
                GetOrdersIDDocument();
                BrokerAccount();
                dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
                dataGridViewX4.Visible = false;
                UseFULL_Kind.Text = DBNull.Value.ToString();
                Lyear.Text = DBNull.Value.ToString();
                GetManagamentBYUsefull();

            }
            catch { }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DifferencesFrm d = new DifferencesFrm();
            d.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.Beneficiary_Rpt.BeneficiaryRpt_Frm f = new Beneficiary_Rpt.BeneficiaryRpt_Frm();
            f.ShowDialog();
        }

        private void barSubItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 1002);
            //if (validationSaveUser != null)
            //{
            //}
            //else
            //{
            //    MessageBox.Show("ليس لديك صلاحية على اعدادات القيود .. برجاء مراجعة مدير المنظومه");
            //}
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Res_Search f = new Res_Search();
            //f.ShowDialog();
        }

        private void UsFulID_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //GetEMPIDBYUsefull();
                GetOrderMoared();
                if (UsFulID.Text == "0")
                {
                    UsFulID.Text = DBNull.Value.ToString();
                }
            }
            catch { }
        }

        private void exID_TextChanged(object sender, EventArgs e)
        {
            GetManagamentBYExCenter();
        }

        private void textBox21_Click(object sender, EventArgs e)
        {
            Restriction_NO.KeyDown += new KeyEventHandler(Restriction_NO_KeyDown);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (resetRow)
            //{
            //    resetRow = false;
            //    dataGridView1.CurrentCell = dataGridView1.Rows[currentRow].Cells[0];
            //}
        }
        private void UpdatecategoryInDataGridView() // التصنيف التلقائى
        {
            try
            {
                this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.Fill(this.financialSysDataSet.Tbl_RestrictionItemsCategory_With_AccountNumber);
                foreach (DataGridViewRow row3 in dataGridView1.Rows)
                {
                    row3.Cells[9].Value = DBNull.Value;
                    row3.Cells[10].Value = DBNull.Value;
                }
                foreach (DataGridViewRow row1 in dataGridView2.Rows)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        dataGridView1.AllowUserToAddRows = false;

                        if (CategortID.Text == row1.Cells[3].Value.ToString())
                        {
                            if (row.Cells[6].Value.ToString() == row1.Cells[1].Value.ToString())
                            {
                                row.Cells[10].Value = row1.Cells[2].Value;
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                                con.Open();
                                SqlDataAdapter da = new SqlDataAdapter("select Name from Tbl_RestrictionItemsCategory where ID='" + row.Cells[10].Value + "'", con);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                //   MessageBox.Show(dt.Rows.Count.ToString());
                                if (dt.Rows.Count > 0)
                                {
                                    row.Cells[9].Value = dt.Rows[0][0].ToString();
                                }
                                con.Close();


                            }
                        }
                    }
                }
                dataGridView1.AllowUserToAddRows = true;
            }
            catch { }
        }
        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox22.Text != string.Empty)
            {
                if (dataGridViewX7.Rows.Count == 1)
                {
                    textBox22.Text = dataGridViewX7.CurrentRow.Cells[0].Value.ToString();
                    textBox23.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();
                    timer4.Stop();
                    labelControl2.Visible = false;
                    //labelControl3.Visible = false;
                    textBox24.Focus();
                    textBox24.SelectAll();
                }
                if (dataGridViewX7.Rows.Count > 1)
                {
                    dataGridViewX7.Focus();
                }



            }
            if (e.KeyCode == Keys.Right)
            {
                textBox19.Focus();
                textBox19.SelectAll();
            }

            //  if (e.KeyCode == Keys.Down)
            //  {
            //      FindAccount f = new FindAccount();


            //      f.ShowDialog();


            //      textBox23.Text = FindAccount.SelectedRow.Cells
            //[1].Value.ToString();
            //      textBox22.Text = FindAccount.SelectedRow.Cells
            //  [0].Value.ToString();
            //      //dataGridViewX7.Focus();

            //  }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox22.Focus();
                textBox22.SelectAll();

            }
            if (e.KeyCode == Keys.Right)
            {
                textBox28.Focus();
                textBox28.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox22.Focus();
                textBox22.SelectAll();
            }
            if (e.KeyCode == Keys.Delete)
            {

                Lyear.Text = DBNull.Value.ToString();

            }
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    FindDoc f = new FindDoc();

                    f.textBox1.Text = x.ToString();
                    f.textBox3.Text = y.ToString();
                    f.label2.Text = comboBox1.Text;
                    f.ShowDialog();
                    Lyear.Text = FindDoc.SelectedRow.Cells[3].Value.ToString();
                }
                catch { }
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            GetREstrictionIDForLYear();
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Right)
            {

                textBox25.Focus();
                textBox25.SelectAll();

            }
            if (e.KeyCode == Keys.Enter && textBox24.Text !="0" || e.KeyCode == Keys.Enter && textBox25.Text != "0")
            {
                label24.Text = string.Empty;
                if (comboBox4.Text.Trim() == "عمليات" && textBox22.Text.Contains("128"))
                {
                    MessageBox.Show("لا يمكنك ادخال حساب البنوك داخل قيد العمليات");
                }
                else
                {
                    if (Convert.ToInt32(textBox22.Text) > 0)
                    {
                        if (checkBox10.Checked == true)
                        {

                            dataGridView1.AllowUserToAddRows = true;
                            dataGridView1.Rows.Add(0, textBox22.Text, textBox23.Text, textBox24.Text, textBox25.Text, comboBox4.SelectedValue, null, null, null, null, null, null, null, dataGridView1.CurrentRow.Cells[13].Value.ToString(), textBox5.Text, null, null, null, null, null, true, comboBox4.SelectedValue);
                            //int newRowIndex = dataGridView1.Rows.Add();
                            //dataGridView1.FirstDisplayedScrollingRowIndex = newRowIndex;
                            //dataGridView1.Rows[newRowIndex].Selected = true;
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

                            dataGridView1.AllowUserToAddRows = false;

                            con.Open();
                            for (int x = 0; x < dataGridView1.Rows.Count; x++)
                            {
                                SqlDataAdapter da = new SqlDataAdapter("select Name,ID,BrokerAccount,HighamountsAccount from Tbl_Accounting_Guid where Account_NO='" + dataGridView1.Rows[x].Cells[1].Value.ToString() + "'", con);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.Rows[x].Cells[2].Value = dt.Rows[0][0].ToString();
                                dataGridView1.Rows[x].Cells[6].Value = dt.Rows[0][1].ToString();
                                dataGridView1.Rows[x].Cells[22].Value = dt.Rows[0][2].ToString();
                                dataGridView1.Rows[x].Cells[23].Value = dt.Rows[0][3].ToString();
                                con.Close();

                                //try
                                //{

                                LoadSerial();
                                dataGridView1.ClearSelection();
                                int nRowIndex = dataGridView1.Rows.Count - 1;

                                dataGridView1.Rows[nRowIndex].Selected = true;
                                dataGridView1.Rows[nRowIndex].Cells[1].Selected = true;




                                // For tD.Text
                                double sumTD = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[3].FormattedValue != null && row.Cells[3].FormattedValue.ToString() != string.Empty)
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[3].FormattedValue.ToString(), out value))
                                        {
                                            sumTD += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].FormattedValue
                                        }
                                    }
                                }
                                tD.Text = Math.Round(sumTD, 3).ToString();

                                // For tC.Text
                                double sumTC = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[4].FormattedValue != null && row.Cells[4].FormattedValue.ToString() != string.Empty)
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[4].FormattedValue.ToString(), out value))
                                        {
                                            sumTC += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[4].FormattedValue
                                        }
                                    }
                                }
                                tC.Text = Math.Round(sumTC, 3).ToString();

                                // For textBox1.Text
                                textBox1.Text = dataGridView1.Rows.Count.ToString();

                                // Calculate differences for tD and tC
                                double differenceTDTC = sumTD - sumTC;
                                df.Text = Math.Round(differenceTDTC, 3).ToString();

                                // For PrDebit.Text
                                double sumPrDebit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "1")
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[3].Value.ToString(), out value))
                                        {
                                            sumPrDebit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].Value
                                        }
                                    }
                                }
                                PrDebit.Text = Math.Round(sumPrDebit, 3).ToString();

                                // For Prcridit.Text
                                double sumPrCredit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "1")
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[4].Value.ToString(), out value))
                                        {
                                            sumPrCredit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[4].Value
                                        }
                                    }
                                }
                                Prcridit.Text = Math.Round(sumPrCredit, 3).ToString();

                                // Calculate differences for PrDebit and Prcridit
                                double differencePr = sumPrDebit - sumPrCredit;
                                PrTot.Text = differencePr.ToString();

                                // For CaDebit.Text
                                double sumCaDebit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "2")
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[3].Value.ToString(), out value))
                                        {
                                            sumCaDebit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].Value
                                        }
                                    }
                                }
                                CaDebit.Text = Math.Round(sumCaDebit, 3).ToString();

                                // For CaCridit.Text
                                double sumCaCredit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "2")
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[4].Value.ToString(), out value))
                                        {
                                            sumCaCredit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[4].Value
                                        }
                                    }
                                }
                                CaCridit.Text = Math.Round(sumCaCredit, 3).ToString();

                                // Calculate differences for CaDebit and CaCridit
                                double differenceCa = sumCaDebit - sumCaCredit;
                                CaTolt.Text = Math.Round(differenceCa, 3).ToString();

                                dataGridView1.AllowUserToAddRows = false;
                                textBox22.Text = string.Empty;
                                textBox23.Text = string.Empty;
                                textBox24.Text = "0";
                                textBox25.Text = "0";
                                textBox22.Focus();
                                textBox22.Select();
                            }
                            foreach (DataGridViewRow row1 in dataGridView2.Rows)
                            {
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    dataGridView1.AllowUserToAddRows = false;

                                    if (CategortID.Text == row1.Cells[3].Value.ToString())
                                    {
                                        if (row.Cells[6].Value.ToString() == row1.Cells[1].Value.ToString())
                                        {
                                            row.Cells[10].Value = row1.Cells[2].Value;
                                            //SqlConnection con = new SqlConnection();
                                            //con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                                            con.Open();
                                            SqlDataAdapter da = new SqlDataAdapter("select Name from Tbl_RestrictionItemsCategory where ID='" + row.Cells[10].Value + "'", con);
                                            DataTable dt = new DataTable();
                                            da.Fill(dt);
                                            //   MessageBox.Show(dt.Rows.Count.ToString());
                                            if (dt.Rows.Count > 0)
                                            {
                                                row.Cells[9].Value = dt.Rows[0][0].ToString();
                                            }
                                            con.Close();


                                        }
                                    }
                                }
                            }
                            UpdateRes();
                            //foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            //    dataGridView1.Rows.RemoveAt(r.Index);
                            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                            dataGridView1.Rows.Clear();
                            //CleareControls();
                            // SQL query
                            string query = @"SELECT Row_No as [م], 
                                    Tbl_Accounting_Guid.Account_NO as [رقم الحساب],
                                    Tbl_Accounting_Guid.Name as [اسم الحساب],
                                    Debit_Value AS [مدين],
                                    Credit_Value AS [دائن],
                                    Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID as [اليومية],
                                    Tbl_AccountingRestrictionItems.Accounting_Guid_ID,
                                    Tbl_Activities.Name as [النشاط],
                                    Tbl_Activities.ID,
                                    Tbl_RestrictionItemsCategory.Name as [التصنيف],
                                    Tbl_RestrictionItemsCategory.ID,
                                    Tbl_CostCenters.Name,
                                    Tbl_AccountingRestrictionItems.CostCenters_ID,
                                    Tbl_AccountingRestrictionItems.ID,
                                    Tbl_AccountingRestrictionItems.AccountingRestriction_ID,
                                    Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID,
                                    Tbl_Accounting_Guid.BrokerAccount,
                                    HighamountsAccount,
                                    PersonalAccount
                            FROM Tbl_AccountingRestrictionItems
                            INNER JOIN Tbl_AccountingRestriction ON Tbl_AccountingRestrictionItems.AccountingRestriction_ID = Tbl_AccountingRestriction.ID
                            INNER JOIN Tbl_Accounting_Guid ON Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID
                            INNER JOIN Tbl_AccountingRestrictions_Kind ON Tbl_AccountingRestriction.AccountingRestrictionKind_ID = Tbl_AccountingRestrictions_Kind.ID
                            LEFT JOIN Tbl_Activities ON Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID
                            LEFT JOIN Tbl_RestrictionItemsCategory ON Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID
                            LEFT JOIN Tbl_CostCenters ON Tbl_AccountingRestrictionItems.CostCenters_ID = Tbl_CostCenters.ID
                            WHERE Tbl_AccountingRestriction.Restriction_NO = @D 
                            AND Tbl_AccountingRestrictions_Kind.id IN (@D2, @D3) 
                            AND FYear = @FY
                            ORDER BY Tbl_AccountingRestrictions_Kind.ID ASC";

                            // Parameters
                            string restrictionNo = Restriction_NO.Text;
                            int d2 = x; // Assuming you have an int value for D2
                            int d3 = y; // Assuming you have an int value for D3
                            int fYear = Convert.ToInt32(comboBox3.SelectedValue); // Assuming you have an int value for FY

                            // Establish connection
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                // Create command
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    // Add parameters
                                    command.Parameters.AddWithValue("@D", restrictionNo);
                                    command.Parameters.AddWithValue("@D2", d2);
                                    command.Parameters.AddWithValue("@D3", d3);
                                    command.Parameters.AddWithValue("@FY", fYear);

                                    // Open connection
                                    connection.Open();

                                    // Execute query
                                    using (SqlDataReader red = command.ExecuteReader())
                                    {
                                        // Check if there are any rows returned
                                        if (red.HasRows)
                                        {
                                            // Loop through each row
                                            while (red.Read())
                                            {

                                                dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7), red.GetValue(8), red.GetValue(9), red.GetValue(10), red.GetValue(11), red.GetValue(12), red.GetValue(13), red.GetValue(14), 0, 0, 0, 0, 0, 0, red.GetValue(5), red.GetValue(16), red.GetValue(17), red.GetValue(18));

                                                // Access other columns similarly
                                            }
                                        }

                                        else
                                        {

                                        }
                                        red.Close();
                                    }

                                    connection.Close();
                                    //checkBox10.Checked = false;
                                }
                                dataGridView1.AllowUserToAddRows = false;
                            }
                            if (dataGridView1.Rows.Count > 1)
                            {
                                // For tD.Text
                                double sumTD = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[3].FormattedValue != null && row.Cells[3].FormattedValue.ToString() != string.Empty)
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[3].FormattedValue.ToString(), out value))
                                        {
                                            sumTD += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].FormattedValue
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }
                                tD.Text = Math.Round(sumTD, 3).ToString();

                                // For tC.Text
                                double sumTC = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[4].FormattedValue != null && row.Cells[4].FormattedValue.ToString() != string.Empty)
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[4].FormattedValue.ToString(), out value))
                                        {
                                            sumTC += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[4].FormattedValue
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }
                                tC.Text = Math.Round(sumTC, 3).ToString();

                                // Calculate differences
                                double difference = sumTD - sumTC;
                                df.Text = Math.Round(difference, 3).ToString();

                                // For textBox1.Text
                                textBox1.Text = dataGridView1.Rows.Count.ToString();

                                // For TTT.Text
                                double sumS = 0;
                                foreach (DataGridViewRow row in dataGridViewX2.Rows)
                                {
                                    if (row.Cells[2].FormattedValue != null && row.Cells[2].FormattedValue.ToString() != string.Empty)
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[2].FormattedValue.ToString(), out value))
                                        {
                                            sumS += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[2].FormattedValue
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }
                                double sumF = 0;
                                foreach (DataGridViewRow row in dataGridViewX2.Rows)
                                {
                                    if (row.Cells[3].FormattedValue != null && row.Cells[3].FormattedValue.ToString() != string.Empty)
                                    {
                                        double value;
                                        if (Double.TryParse(row.Cells[3].FormattedValue.ToString(), out value))
                                        {
                                            sumF += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].FormattedValue
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }

                                // Calculate difference
                                double difference2 = sumS - sumF;
                                TTT.Text = Math.Round(difference2, 3).ToString();

                            }
                        }


                        if (checkBox10.Checked == false)
                        {
                            dataGridView1.AllowUserToAddRows = true;
                            dataGridView1.Rows.Add(0, textBox22.Text, textBox23.Text, textBox24.Text, textBox25.Text, comboBox4.SelectedValue, null, null, null, null, null, null, null, 0, textBox5.Text, null, null, null, null, null, true, comboBox4.SelectedValue);
                            //UpdatecategoryInDataGridView();
                            //int newRowIndex = dataGridView1.Rows.Add();
                            //dataGridView1.FirstDisplayedScrollingRowIndex = newRowIndex;
                            //dataGridView1.Rows[newRowIndex].Selected = true;
                            //dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                            dataGridView1.AllowUserToAddRows = false;



                            con.Open();
                            for (int x = 0; x < dataGridView1.Rows.Count; x++)
                            {
                                SqlDataAdapter da = new SqlDataAdapter("select Name,ID,BrokerAccount,HighamountsAccount from Tbl_Accounting_Guid where Account_NO='" + dataGridView1.Rows[x].Cells[1].Value.ToString() + "'", con);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.Rows[x].Cells[2].Value = dt.Rows[0][0].ToString();
                                dataGridView1.Rows[x].Cells[6].Value = dt.Rows[0][1].ToString();
                                dataGridView1.Rows[x].Cells[22].Value = dt.Rows[0][2].ToString();
                                dataGridView1.Rows[x].Cells[23].Value = dt.Rows[0][3].ToString();
                                con.Close();

                                //try
                                //{

                                LoadSerial();
                                dataGridView1.ClearSelection();
                                int nRowIndex = dataGridView1.Rows.Count - 1;

                                dataGridView1.Rows[nRowIndex].Selected = true;
                                dataGridView1.Rows[nRowIndex].Cells[1].Selected = true;

                                dataGridView1.AllowUserToAddRows = false;


                                decimal sumD = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != string.Empty)
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[3].Value.ToString(), out value))
                                        {
                                            sumD += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].Value
                                        }
                                    }
                                }
                                tD.Text = Math.Round(sumD, 3).ToString();

                                // For tC.Text
                                decimal sumC = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != string.Empty)
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[4].Value.ToString(), out value))
                                        {
                                            sumC += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[4].Value
                                        }
                                    }
                                }
                                tC.Text = Math.Round(sumC, 3).ToString();
                                textBox1.Text = dataGridView1.Rows.Count.ToString();
                                double xx1, yy1, zz1;
                                xx1 = Convert.ToDouble(tD.Text);
                                yy1 = Convert.ToDouble(tC.Text);
                                zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                                df.Text = Convert.ToString(zz1);


                                // For string s
                                decimal sumS = 0;
                                foreach (DataGridViewRow row in dataGridViewX2.Rows)
                                {
                                    if (row.Cells[2].FormattedValue != null && row.Cells[2].FormattedValue.ToString() != string.Empty)
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[2].FormattedValue.ToString(), out value))
                                        {
                                            sumS += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[2].FormattedValue
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }
                                string s = Math.Round(sumS, 3).ToString();

                                // For string f
                                decimal sumF = 0;
                                foreach (DataGridViewRow row in dataGridViewX2.Rows)
                                {
                                    if (row.Cells[3].FormattedValue != null && row.Cells[3].FormattedValue.ToString() != string.Empty)
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[3].FormattedValue.ToString(), out value))
                                        {
                                            sumF += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].FormattedValue
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }
                                string f = Math.Round(sumF, 3).ToString();


                                double xx, yy, zz;
                                xx = Convert.ToDouble(s);
                                yy = Convert.ToDouble(f);
                                zz = Convert.ToDouble(s) - Convert.ToDouble(f);
                                TTT.Text = Convert.ToString(zz);
                                // dataGridView1.AllowUserToAddRows = true;
                                // For PrDebit.Text
                                decimal sumDebit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "1")
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[3].Value.ToString(), out value))
                                        {
                                            sumDebit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].Value
                                        }
                                    }
                                }
                                PrDebit.Text = Math.Round(sumDebit, 3).ToString();

                                // For PrCredit.Text
                                decimal sumCredit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "1")
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[4].Value.ToString(), out value))
                                        {
                                            sumCredit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[4].Value
                                        }
                                    }
                                }
                                Prcridit.Text = Math.Round(sumCredit, 3).ToString();



                                double PrD, PRC, PRT;
                                PrD = Convert.ToDouble(PrDebit.Text);
                                PRC = Convert.ToDouble(Prcridit.Text);
                                PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                                PrTot.Text = Convert.ToString(PRT);
                                //dataGridView1.AllowUserToAddRows = true;

                                // For CaDebit.Text
                                decimal sumCaDebit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "2")
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[3].Value?.ToString(), out value))
                                        {
                                            sumCaDebit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[3].Value
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }
                                CaDebit.Text = Math.Round(sumCaDebit, 3).ToString();

                                // For CaCredit.Text
                                decimal sumCaCredit = 0;
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.Cells[21].Value != null && row.Cells[21].Value.ToString() == "2")
                                    {
                                        decimal value;
                                        if (Decimal.TryParse(row.Cells[4].Value?.ToString(), out value))
                                        {
                                            sumCaCredit += value;
                                        }
                                        else
                                        {
                                            // Handle invalid data in row.Cells[4].Value
                                            // For example: Log the error, skip the row, or set a default value
                                        }
                                    }
                                }
                                CaDebit.Text = Math.Round(sumCaCredit, 3).ToString();



                                double CaD, CaC, CaT;
                                CaD = Convert.ToDouble(CaDebit.Text);
                                CaC = Convert.ToDouble(CaCridit.Text);
                                CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                                CaTolt.Text = Convert.ToString(CaT);
                                dataGridView1.AllowUserToAddRows = false;
                                textBox22.Text = string.Empty;
                                textBox23.Text = string.Empty;
                                textBox24.Text = "0";
                                textBox25.Text = "0";
                                textBox22.Focus();
                                textBox22.Select();

                            }
                            foreach (DataGridViewRow row1 in dataGridView2.Rows)
                            {
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    dataGridView1.AllowUserToAddRows = false;

                                    if (CategortID.Text == row1.Cells[3].Value.ToString())
                                    {
                                        if (row.Cells[6].Value.ToString() == row1.Cells[1].Value.ToString())
                                        {
                                            row.Cells[10].Value = row1.Cells[2].Value;
                                            //SqlConnection con = new SqlConnection();
                                            //con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                                            con.Open();
                                            SqlDataAdapter da = new SqlDataAdapter("select Name from Tbl_RestrictionItemsCategory where ID='" + row.Cells[10].Value + "'", con);
                                            DataTable dt = new DataTable();
                                            da.Fill(dt);
                                            //   MessageBox.Show(dt.Rows.Count.ToString());
                                            if (dt.Rows.Count > 0)
                                            {
                                                row.Cells[9].Value = dt.Rows[0][0].ToString();
                                            }
                                            con.Close();


                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("من فضلك ادخل الحساب والمبلغ مدين أو دائن أولا");
                        textBox22.Focus();
                        textBox22.SelectAll();
                    }
                    //*******************
                }
                if (checkBox10.Checked == true)
                {
                    checkBox10.Checked = false;
                }

            }
        }



        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0)
            ////{
            ////    if (CategortID.Text != string.Empty)
            ////    {
            ////        //try
            ////        //{
            ////        dataGridView1.AllowUserToAddRows = false;
            ////        if (dataGridView1.Rows.Count > 0)
            ////        {
            ////            //textBox5.Text = GenerateID().ToString();
            ////            dataGridView1.AllowUserToAddRows = false;
            ////            UpdateHeader();
            ////            //SaveDocument();
            ////            //PresessingSaveBtn();
            ////            //GetDocID();
            ////            //SaveRestriction();
            ////            saveToDB();
            ////            //CleareControls();

            ////            GetParentIDKind();
            ////            ComboInDataGrid();
            ////            textBox13.Text = "";
            ////            textBox14.Text = "";
            ////            UseFULL_Kind.Text = "";

            ////            dateTimePicker1.Focus();

            ////            CleareControls();
            ////            //GetREstrictionID();
            ////            FindFileNumber1();
            ////            GetDocumentData();

            ////            //PresessingSaveBtn();
            ////            GetDocID();
            ////            Getex();
            ////            GetMan();
            ////            GetUsf();
            ////            Getcate();
            ////            GetHand();
            ////            GetRespon();
            ////            GetHand();
            ////            GetOrdersIDDocument();
            ////            BrokerAccount();
            ////            dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
            ////            dataGridViewX4.Visible = false;
            ////            UseFULL_Kind.Text = DBNull.Value.ToString();
            ////            textBox19.Text = DBNull.Value.ToString();
            ////            GetManagamentBYExCenter();
            ////            //var ListBenf =  FsDb.Tbl_DocumentBenefcairy.Where(x => x.Document_ID == ).ToList();
            ////            //UsFul.DataSource = null ;
            ////            //UsFul.DisplayMember = null;
            ////            //UsFul.ValueMember = null;
            ////            UsFul.DataSource = getBanifecary();
            ////            UsFul.DisplayMember = "Name";
            ////            UsFul.ValueMember = "Beneficiary_ID";
            ////            if (UsFul.Items.Count > 0)
            ////            {
            ////                UsFul.SelectedIndex = 0;
            ////            }
            ////            Restriction_NO.Focus();
            ////            Restriction_NO.SelectAll();

            ////            try
            ////            {//next
            ////                SqlConnection con = new SqlConnection();
            ////                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            ////                SqlCommand com = new SqlCommand();
            ////                SqlCommand com1 = new SqlCommand();
            ////                com.CommandType = CommandType.Text;
            ////                com1.CommandType = CommandType.Text;
            ////                SqlDataReader red;
            ////                com.Connection = con;
            ////                com.CommandText = ("select top(1) Restriction_NO, LAG(Restriction_NO) OVER ( ORDER BY Restriction_NO) from Tbl_AccountingRestriction where Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D2 OR Restriction_NO > @Restriction_NO and AccountingRestrictionKind_ID = @D3     ");
            ////                com.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Restriction_NO.Text;
            ////                com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            ////                com.Parameters.Add("@D3", SqlDbType.Int).Value = y;
            ////                con.Open();
            ////                red = com.ExecuteReader();

            ////                while (red.Read())
            ////                {
            ////                    Restriction_NO.Text = red.GetValue(0).ToString();
            ////                }
            ////                if (!red.HasRows)
            ////                {
            ////                    //Restriction_NO.Text = "0";
            ////                }
            ////                red.Close();
            ////                con.Close();
            ////                textBox19.Text = null;
            ////                textBox5.Text = null;
            ////                textBox10.Text = null;
            ////                GetDocID();


            ////                GenerateID();

            ////                GetParentIDKind();
            ////                ComboInDataGrid();
            ////                textBox13.Text = "";
            ////                textBox14.Text = "";
            ////                UseFULL_Kind.Text = "";

            ////                dateTimePicker1.Focus();

            ////                CleareControls();
            ////                FindFileNumber1();
            ////                GetDocumentData();

            ////                Getex();
            ////                GetMan();
            ////                GetUsf();
            ////                Getcate();
            ////                GetHand();
            ////                GetRespon();
            ////                GetHand();
            ////                GetOrdersIDDocument();
            ////                BrokerAccount();
            ////                dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";
            ////                dataGridViewX4.Visible = false;
            ////                UseFULL_Kind.Text = DBNull.Value.ToString();
            ////                textBox19.Text = DBNull.Value.ToString();
            ////                GetManagamentBYExCenter();
            ////                UsFul.DataSource = getBanifecary();
            ////                UsFul.DisplayMember = "Name";
            ////                UsFul.ValueMember = "Beneficiary_ID";
            ////                if (UsFul.Items.Count > 0)
            ////                {
            ////                    UsFul.SelectedIndex = 0;
            ////                }
            ////                //try
            ////                //{
            ////                //UsFulID.Text = string.Empty;
            ////                //GetEMPIDBYUsefull();
            ////                //GetEMPIDBYUsefull1();
            ////                //GetOrderMoared();
            ////                //}
            ////                //catch { }
            ////                if (textBox10.Text == string.Empty)
            ////                {
            ////                    SaveDocument();
            ////                    //PresessingSaveBtn();
            ////                    GetDocID();
            ////                }

            ////                if (textBox5.Text == string.Empty)
            ////                {
            ////                    SaveRestrictionFirtTime();
            ////                    GenerateID();
            ////                }
            ////                GetAssayes();
            ////                GetProjects();
            ////                Open_PersonalityAccountsButton();
            ////            }
            ////            catch { }

            ////            //}

            ////            //catch { }
            ////            //catch
            ////            //{
            ////            //    MessageBox.Show("لا توجد بنود تم اضافتها للحفظ", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////            //}

            ////        }

            ////    }
            ////}
            ////if (Convert.ToDecimal(df.Text) != 0)
            ////{
            ////    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);


            ////}
            MessageBox.Show("F1 اضغط من لوحة المفاتيح");

        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            //if (switchButton1.Value == true)
            //{
            //    textBox22.Enabled = true;
            //    textBox23.Enabled = true;
            //    textBox24.Enabled = true;
            //    textBox25.Enabled = true;
            //    comboBox4.Enabled = true;
            //    simpleButton14.Enabled = true;
            //    simpleButton16.Enabled = true;
            //    switchButton2.Value = false;
            //    dataGridView1.ReadOnly = true;
            //}
            //if (switchButton1.Value == false)
            //{
            //    switchButton1.Value = true;
            //    //textBox22.Enabled = false ;
            //    //textBox23.Enabled = false ;
            //    //textBox24.Enabled = false ;
            //    //textBox25.Enabled = false ;
            //    //comboBox4.Enabled = false ;

            //    //simpleButton14.Enabled = false ;
            //    //simpleButton16.Enabled = false ;
            //    //switchButton2.Value = true;
            //    //dataGridView1.ReadOnly = true;
            //    textBox22.Enabled = true;
            //    textBox23.Enabled = true;
            //    textBox24.Enabled = true;
            //    textBox25.Enabled = true;
            //    comboBox4.Enabled = true;
            //    simpleButton14.Enabled = true;
            //    simpleButton16.Enabled = true;
            //    switchButton2.Value = false;
            //    dataGridView1.ReadOnly = true;
            //}

        }

        private void switchButton2_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton2.Value == true)
            {

                dataGridView1.AllowUserToAddRows = false;
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    if (dataGridView1.Rows[x].Cells[13].Value != null)
                    {
                        textBox22.Enabled = false;
                        textBox23.Enabled = false;
                        textBox24.Enabled = false;
                        textBox25.Enabled = false;
                        comboBox4.Enabled = false;

                        simpleButton14.Enabled = false;
                        simpleButton16.Enabled = false;
                        switchButton1.Value = false;
                        dataGridView1.ReadOnly = false;
                    }
                    if (dataGridView1.Rows[x].Cells[13].Value == null)
                    {
                        MessageBox.Show("لا يمكنك العمل على وضع التعديل قبل إدخال القيود وحفظها");
                        switchButton2.Value = false;
                        textBox22.Enabled = true;
                        textBox23.Enabled = true;
                        textBox24.Enabled = true;
                        textBox25.Enabled = true;
                        comboBox4.Enabled = true;
                        simpleButton14.Enabled = true;
                        simpleButton16.Enabled = true;
                        switchButton1.Value = true;
                        dataGridView1.ReadOnly = false;
                    }
                }
            }
            if (switchButton2.Value == false)
            {
                dataGridView1.ReadOnly = true;
                switchButton1.Value = true;
                textBox22.Enabled = true;
                textBox23.Enabled = true;
                textBox24.Enabled = true;
                textBox25.Enabled = true;
                comboBox4.Enabled = true;
                simpleButton14.Enabled = true;
                simpleButton16.Enabled = true;

            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox22.Focus() == true)
                {
                    timer4.Start();
                    timer4.Tick += timer4_Tick;
                }
                if (CategortID.Text == string.Empty)
                {
                    MessageBox.Show("من فضلك اختر البيان اولا");
                    Descp.Focus();
                }
                if (Restriction_NO.Text.Trim() == "0")
                {
                    MessageBox.Show("من فضلك ادخل رقم المستند اولا");
                    Restriction_NO.Focus();
                }
                else
                {

                    timer4.Start();
                    timer4.Tick += timer4_Tick;
                    this.tbl_Accounting_GuidTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_Accounting_Guid, textBox22.Text.Trim());
                    //textBox22.Text = dataGridViewX7.CurrentRow.Cells[0].Value.ToString();
                    label24.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();
                }
                //int nRowIndex = dataGridViewX7.Rows.Count - 1;

                //dataGridViewX7.Rows[nRowIndex].Selected = true;
                //dataGridViewX7.Rows[nRowIndex].Cells[1].Selected = true;


            }
            catch { }
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (Descp.Text == string.Empty)
                //{
                //    MessageBox.Show("من فضلك اختر البيان اولا");
                //    Descp.Focus();
                //}
                //else
                //{

                //    this.tbl_Accounting_GuidTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_Accounting_Guid, textBox23.Text);
                //}
                //int nRowIndex = dataGridViewX7.Rows.Count - 1;

                //dataGridViewX7.Rows[nRowIndex].Selected = true;
                //dataGridViewX7.Rows[nRowIndex].Cells[1].Selected = true;


            }
            catch { }
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            textBox19.BackColor = Color.NavajoWhite;
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            textBox19.BackColor = Color.White;
        }

        private void textBox22_Enter(object sender, EventArgs e)
        {
            textBox22.BackColor = Color.NavajoWhite;
            timer4.Start();

        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            textBox22.BackColor = Color.White;
            timer4.Stop();
        }

        private void textBox24_Leave(object sender, EventArgs e)
        {
            textBox24.BackColor = Color.White;
            try
            {
                if (Convert.ToDecimal(textBox24.Text) > 0)
                {
                    textBox25.Text = "0";
                }
            }
            catch { }
        }

        private void textBox24_Enter(object sender, EventArgs e)
        {
            textBox24.BackColor = Color.NavajoWhite;
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            textBox25.BackColor = Color.White;
            try
            {
                if (Convert.ToDecimal(textBox25.Text) > 0)
                {
                    textBox24.Text = "0";
                }
            }
            catch { }
        }

        private void textBox25_Enter(object sender, EventArgs e)
        {
            textBox25.BackColor = Color.NavajoWhite;
        }

        private void comboBox4_Enter(object sender, EventArgs e)
        {
            comboBox4.BackColor = Color.NavajoWhite;
        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            comboBox4.BackColor = Color.White;
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox25.Focus();
                textBox25.SelectAll();

            }
            if (e.KeyCode == Keys.Left)
            {

                textBox25.Focus();
                textBox25.SelectAll();

            }
            if (e.KeyCode == Keys.Right)
            {

                textBox22.Focus();
                textBox22.SelectAll();

            }
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                comboBox4.Focus();
                comboBox4.SelectAll();

            }
            if (e.KeyCode == Keys.Right)
            {

                textBox24.Focus();
                textBox24.SelectAll();

            }
            if (e.KeyCode == Keys.Left)
            {

                comboBox4.Focus();
                comboBox4.SelectAll();

            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (textBox22.Text != string.Empty && Convert.ToDouble(textBox24.Text) > 0 || textBox22.Text != string.Empty && Convert.ToDouble(textBox25.Text) > 0)
            {
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.Rows.Add(0, textBox22.Text, textBox23.Text, textBox24.Text, textBox25.Text, comboBox4.SelectedValue, null, null, null, null, null, null, null, 0, textBox5.Text, null, null, null, null, null, true, comboBox4.SelectedValue);
                //UpdatecategoryInDataGridView();

                //dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();



                //dataGridView1.CurrentRow.Cells[21].Value = Convert.ToInt32(comboBox4.SelectedValue);
                //dataGridView1.CurrentRow.Cells[5].Value = Convert.ToInt32(comboBox4.SelectedValue);
                //dataGridView1.CurrentRow.Cells[14].Value = textBox5.Text;
                ////dataGridView1.CurrentRow.Cells[5].Value = dataGridView1.CurrentRow.Cells[21].Value;
                //dataGridView1.CurrentRow.Cells[20].Value = true;

                con.Open();
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select Name,ID,BrokerAccount,HighamountsAccount from Tbl_Accounting_Guid where Account_NO='" + dataGridView1.Rows[x].Cells[1].Value.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Rows[x].Cells[2].Value = dt.Rows[0][0].ToString();
                    dataGridView1.Rows[x].Cells[6].Value = dt.Rows[0][1].ToString();
                    dataGridView1.Rows[x].Cells[22].Value = dt.Rows[0][2].ToString();
                    dataGridView1.Rows[x].Cells[23].Value = dt.Rows[0][3].ToString();
                    con.Close();

                    //try
                    //{

                    LoadSerial();
                    dataGridView1.ClearSelection();
                    int nRowIndex = dataGridView1.Rows.Count - 1;

                    dataGridView1.Rows[nRowIndex].Selected = true;
                    dataGridView1.Rows[nRowIndex].Cells[1].Selected = true;

                    //if (textBox17.Text != string.Empty)
                    //{
                    //dataGridView1.CurrentRow.Cells[21].Value = 1;
                    //}
                    //if (textBox17.Text == string.Empty)
                    //{
                    //    dataGridView1.CurrentRow.Cells[21].Value = 1;
                    //}


                    //if (Convert.ToInt32(textBox16.Text) == 13)
                    //{
                    //    dataGridView1.SelectedRows[0].Cells[21].Value = 3;
                    //    // y = 3;
                    //}
                    //if (Convert.ToInt32(textBox16.Text) == 14)
                    //{
                    //    dataGridView1.SelectedRows[0].Cells[21].Value = 4;
                    //    // y = 4;
                    //}
                    //if (Convert.ToInt32(textBox16.Text) == 15)
                    //{
                    //    dataGridView1.SelectedRows[0].Cells[21].Value = 5;
                    //    //= 5;
                    //}
                    //if (Convert.ToInt32(textBox16.Text) == 16)
                    //{
                    //    dataGridView1.SelectedRows[0].Cells[21].Value = 6;
                    //    //y = 6;
                    //}
                    //if (Convert.ToInt32(textBox16.Text) == 17)
                    //{
                    //    dataGridView1.SelectedRows[0].Cells[21].Value = 7;
                    //    //y = 7;
                    //}
                    //if (Convert.ToInt32(textBox16.Text) == 18)
                    //{
                    //    dataGridView1.SelectedRows[0].Cells[21].Value = 8;
                    //    //y = 8;
                    //}
                    //if (Convert.ToInt32(textBox16.Text) == 19)
                    //{
                    //    dataGridView1.SelectedRows[0].Cells[21].Value = 9;
                    //    // y = 9;
                    //}


                    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[3].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[4].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                    textBox1.Text = dataGridView1.Rows.Count.ToString();
                    double xx1, yy1, zz1;
                    xx1 = Convert.ToDouble(tD.Text);
                    yy1 = Convert.ToDouble(tC.Text);
                    zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                    df.Text = Convert.ToString(zz1);


                    string s = (from DataGridViewRow row in dataGridViewX2.Rows
                                where row.Cells[2].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
                    string f = (from DataGridViewRow row in dataGridViewX2.Rows
                                where row.Cells[3].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

                    double xx, yy, zz;
                    xx = Convert.ToDouble(s);
                    yy = Convert.ToDouble(f);
                    zz = Convert.ToDouble(s) - Convert.ToDouble(f);
                    TTT.Text = Convert.ToString(zz);
                    // dataGridView1.AllowUserToAddRows = true;

                    PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[21].Value.ToString() == "1"
                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                    Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[21].Value.ToString() == "1"
                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                    double PrD, PRC, PRT;
                    PrD = Convert.ToDouble(PrDebit.Text);
                    PRC = Convert.ToDouble(Prcridit.Text);
                    PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                    PrTot.Text = Convert.ToString(PRT);
                    //dataGridView1.AllowUserToAddRows = true;


                    CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                    where row.Cells[21].Value.ToString() == "2"
                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                    CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                     where row.Cells[21].Value.ToString() == "2"
                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                    double CaD, CaC, CaT;
                    CaD = Convert.ToDouble(CaDebit.Text);
                    CaC = Convert.ToDouble(CaCridit.Text);
                    CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                    CaTolt.Text = Convert.ToString(CaT);
                    dataGridView1.AllowUserToAddRows = false;
                    textBox22.Text = string.Empty;
                    textBox23.Text = string.Empty;
                    textBox24.Text = "0";
                    textBox25.Text = "0";
                    textBox22.Focus();
                    textBox22.Select();
                }

            }
        }
        private void simpleButton17_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 1007);
                if (validationSaveUser != null)
                {


                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[24].Value) == 1)
                    {
                        HighamountsFrm f = new HighamountsFrm();
                        f.LB.Text = "2";
                        f.AccN.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        f.ACCName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        f.Debit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                        f.Cridit.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        f.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        f.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        f.Code.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                        f.UsFul.Text = UsFul.Text;
                        f.UsFulID.Text = UsFulID.Text;
                        //f.MAXID.Text = textBox10.Text;
                        f.ShowDialog();

                        dataGridView1.CurrentRow.Cells[16].Value = "0";
                    }
                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[24].Value) != 1)
                    {
                        MessageBox.Show("هذا الحساب غير مصنف بحساب شخصى");
                        dataGridView1.CurrentRow.Cells[16].Value = "0";
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية إضافة المديونيات .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch
            {

                //MessageBox.Show("لإضافة المديونيات الرجاء حفظ المستند أولا لكى يتم الربط بشكل صحيح");
            }

        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 1006);
                if (validationSaveUser != null)
                {

                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[23].Value) == 1)
                    {
                        HighamountsFrm f = new HighamountsFrm();
                        f.LB.Text = "1";
                        f.AccN.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        f.ACCName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        f.Debit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        f.Cridit.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        f.Code.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                        f.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        f.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                        f.UsFul.Text = UsFul.Text;
                        f.UsFulID.Text = UsFulID.Text;
                        f.ShowDialog();
                        dataGridView1.CurrentRow.Cells[18].Value = "0";
                    }
                    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[23].Value) != 1)
                    {
                        MessageBox.Show("هذا الحساب غير مصنف بحساب تعليات");
                        dataGridView1.CurrentRow.Cells[18].Value = "0";
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة التعليات .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message.ToString());
                //MessageBox.Show("لإضافة المديونيات الرجاء حفظ المستند أولا لكى يتم الربط بشكل صحيح");
            }
        }

        private void line3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[3].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[4].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                textBox1.Text = dataGridView1.Rows.Count.ToString();
                double xx1, yy1, zz1;
                xx1 = Convert.ToDouble(tD.Text);
                yy1 = Convert.ToDouble(tC.Text);
                zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                df.Text = Convert.ToString(zz1);


                string s = (from DataGridViewRow row in dataGridViewX2.Rows
                            where row.Cells[2].FormattedValue.ToString() != string.Empty
                            select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
                string f = (from DataGridViewRow row in dataGridViewX2.Rows
                            where row.Cells[3].FormattedValue.ToString() != string.Empty
                            select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();

                double xx, yy, zz;
                xx = Convert.ToDouble(s);
                yy = Convert.ToDouble(f);
                zz = Convert.ToDouble(s) - Convert.ToDouble(f);
                TTT.Text = Convert.ToString(zz);
                // dataGridView1.AllowUserToAddRows = true;

                PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[21].Value.ToString() == "1"
                                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[21].Value.ToString() == "1"
                                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                double PrD, PRC, PRT;
                PrD = Convert.ToDouble(PrDebit.Text);
                PRC = Convert.ToDouble(Prcridit.Text);
                PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                PrTot.Text = Convert.ToString(PRT);
                //dataGridView1.AllowUserToAddRows = true;


                CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[21].Value.ToString() == "2"
                                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[21].Value.ToString() == "2"
                                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                double CaD, CaC, CaT;
                CaD = Convert.ToDouble(CaDebit.Text);
                CaC = Convert.ToDouble(CaCridit.Text);
                CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                CaTolt.Text = Convert.ToString(CaT);
            }
            catch { }
        }

        private void dataGridViewX7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewX7_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridViewX7_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridViewX7.CurrentCell.ColumnIndex, dataGridViewX7.CurrentCell.RowIndex);

                    dataGridViewX7_CellDoubleClick(dataGridViewX7, args);




                }
            }
            catch { MessageBox.Show("الرجاء ادخال رقم الحساب اولا"); textBox22.Focus(); }
        }

        private void dataGridViewX7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox22.Text = dataGridViewX7.CurrentRow.Cells[0].Value.ToString();
                textBox23.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();
                textBox24.Focus();
                textBox24.SelectAll();
            }
            catch { MessageBox.Show("الرجاء ادخال رقم الحساب اولا"); textBox22.Focus(); }
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox28.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                Respo.Focus();
                Respo.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox28.Focus();
                textBox28.SelectAll();
            }
            if (e.KeyCode == Keys.Down && textBox26.Focus() == true)
            {
                try
                {
                    FindAssays f = new FindAssays();
                    f.ShowDialog();
                    textBox26.Text = FindAssays.SelectedRow.Cells[1].Value.ToString();
                    assaysID.Text = FindAssays.SelectedRow.Cells[0].Value.ToString();
                    if (FindAssays.SelectedRow.Cells[1].Value == null)
                    {
                        textBox26.Text = DBNull.Value.ToString();
                        assaysID.Text = DBNull.Value.ToString();
                    }
                }
                catch { }
            }

            if (e.KeyCode == Keys.Delete && textBox26.Focus() == true)
            {
                try
                {
                    //FindDepart f = new FindDepart();
                    //f.ShowDialog();
                    textBox26.Text = DBNull.Value.ToString();
                    assaysID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }



        private void panelEx2_Click(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox19.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                textBox26.Focus();
                textBox26.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                textBox19.Focus();
                textBox19.SelectAll();
            }
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    FindProject f = new FindProject();
                    f.ShowDialog();
                    textBox28.Text = FindProject.SelectedRow.Cells[1].Value.ToString();
                    ProjectID.Text = FindProject.SelectedRow.Cells[0].Value.ToString();
                    if (FindProject.SelectedRow.Cells[1].Value == null)
                    {
                        textBox28.Text = DBNull.Value.ToString();
                        ProjectID.Text = DBNull.Value.ToString();
                    }
                }
                catch { }
            }

            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    //FindDepart f = new FindDepart();
                    //f.ShowDialog();
                    textBox28.Text = DBNull.Value.ToString();
                    ProjectID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }
        private void AccRstAuditSelect(long? Vint_AccRstAudIDC)
        {
            chckBxBasicData.Checked = false;
            textBox36.BackColor = Color.White;
            textBox36.ForeColor = Color.Black;
            var ListAccRstAuditOrd = FsDb.Tbl_AccountingRestriction_Audit.Where(x => x.AccountingRestrictionID == Vint_AccRstAudIDC && (x.Note != null)).Select(p => p.Note).Distinct().ToList();
            var ListAccRstAuditOrdUser = FsDb.Tbl_AccountingRestriction_Audit.FirstOrDefault(x => x.AccountingRestrictionID == Vint_AccRstAudIDC && x.UserID == Program.GlbV_UserId);
            if (ListAccRstAuditOrd.Count != 0)
            {
                chckBxBasicData.Checked = false;
                textBox36.Text = "";
                foreach (var v in ListAccRstAuditOrd)
                {
                    textBox36.Text = textBox36.Text + " - " + v.ToString();
                }
                textBox36.BackColor = Color.PaleVioletRed;
                textBox36.ForeColor = Color.Blue;

            }
            else
            {
                if (ListAccRstAuditOrdUser != null)
                {
                    if (ListAccRstAuditOrdUser.RestrictionDataID == true)
                    {
                        chckBxBasicData.Checked = true;
                        textBox36.BackColor = Color.Green;
                        textBox36.ForeColor = Color.Black;
                    }
                    else
                    {
                        chckBxBasicData.Checked = false;
                        textBox36.BackColor = Color.White;
                        textBox36.ForeColor = Color.Black;
                    }
                }
                else
                {

                    chckBxBasicData.Checked = false;
                    textBox36.BackColor = Color.White;
                    textBox36.ForeColor = Color.Black;

                }
            }

            var ListAccRstAudit = (from AccRstAud in FsDb.Tbl_AccountingRestriction_Audit
                                   join usr in FsDb.Tbl_User on AccRstAud.UserID equals usr.ID
                                   join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                   where (AccRstAud.AccountingRestrictionID == Vint_AccRstAudIDC)
                                   select new
                                   {
                                       EmpName = emp.Name
                                   }).Distinct().ToList();
            if (ListAccRstAudit != null)
            {
                string Vstr_RefrencesOrder = "";
                int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_RefrencesOrder = ListAccRstAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
                }
                textBox29.Text = Vstr_RefrencesOrder;
            }
            else
            {
                textBox29.Text = "";
            }
        }
        private void chckBxBasicData_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                long Vlng_AccRstID = long.Parse(textBox5.Text);
                bool Vbl_RestrictionDataID = false;
                string Vst_note = null;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 77 && w.ProcdureId == 1003);
                if (validationSaveUser != null)
                {

                    if (textBox30.Text != "")
                    {
                        Vbl_RestrictionDataID = true;
                        var ListOrderAuditOrdUser = FsDb.Tbl_AccountingRestriction_Audit.FirstOrDefault(x => x.AccountingRestrictionID == Vlng_AccRstID);
                        if (ListOrderAuditOrdUser == null)

                        {

                            DateTime Vdt_Today = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate());
                            //****************Refrences******User Enter Data *********

                            AccRstAuditSelect(Vlng_AccRstID);
                            var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TrecordId == Vlng_AccRstID).Select(p => p.User_ID).Distinct().ToList();
                            if (textBox36.Text != "")
                            {
                                Vbl_RestrictionDataID = false;
                                int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                                var List_AccregistrId = FsDb.Tbl_AccountingRestriction_Audit.Where(x => x.AccountingRestrictionID == Vlng_AccRstID).ToList();
                                
                                    for (int i = 0; i <= WCount - 1; i++)
                                    {

                                        //***********************************

                                        Tbl_AccountingRestriction_Audit AccRstAud = new Tbl_AccountingRestriction_Audit
                                        {

                                            UserID = Program.GlbV_UserId,
                                            AccountingRestrictionID = Vlng_AccRstID,
                                            RestrictionDataID = Vbl_RestrictionDataID,
                                            ReferenceDate = Vdt_Today,
                                            Note = textBox36.Text,
                                            Note1 = textBox36.Text,
                                            UserIDData = int.Parse(ListAccRstAudit[i].ToString())
                                        };
                                        FsDb.Tbl_AccountingRestriction_Audit.Add(AccRstAud);
                                        FsDb.SaveChanges();
                                        int Vint_LastRow = AccRstAud.ID;
                                        SecurityEvent sev = new SecurityEvent
                                        {
                                            ActionName = "اضافة مراجعة مستند قيد",
                                            TableName = "Tbl_AccountingRestriction_Audit",
                                            TableRecordId = Vint_LastRow.ToString(),
                                            Description = "",
                                            ManagementName = Program.GlbV_Management,
                                            ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                                            //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                            EmployeeName = Program.GlbV_EmpName,
                                            User_ID = Program.GlbV_UserId,
                                            UserName = Program.GlbV_UserName,
                                            FormName = "شاشة مراجعة مستندات القيود اليوميه"


                                        };
                                        FsEvDb.SecurityEvents.Add(sev);
                                        FsEvDb.SaveChanges();

                                    }
                               
                                 
                            }
                            else
                            {
                                Vbl_RestrictionDataID = true;
                                //***********************************

                                Tbl_AccountingRestriction_Audit AccRstAud = new Tbl_AccountingRestriction_Audit
                                {

                                    UserID = Program.GlbV_UserId,
                                    AccountingRestrictionID = Vlng_AccRstID,
                                    RestrictionDataID = Vbl_RestrictionDataID,
                                    ReferenceDate = Vdt_Today

                                };
                                FsDb.Tbl_AccountingRestriction_Audit.Add(AccRstAud);
                                FsDb.SaveChanges();
                                int Vint_LastRow = AccRstAud.ID;
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "اضافة مراجعة مستند قيد",
                                    TableName = "Tbl_AccountingRestriction_Audit",
                                    TableRecordId = Vint_LastRow.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                                    //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة مراجعة مستندات القيود اليوميه"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                            }

                            //***************************
                            MessageBox.Show("تم الحفظ");
                            //****************Refrences***************
                            AccRstAuditSelect(Vlng_AccRstID);
                            //***************************************
                        }
                        else
                        {
                            if (chckBxBasicData.Checked == true)
                            {
                                Vbl_RestrictionDataID = true;
                            }
                            else
                            {
                                Vbl_RestrictionDataID = false;
                            }
                            if (textBox36.Text == "")
                            {
                                Vst_note = null;
                            }
                            else
                            {
                                Vst_note = textBox36.Text;
                            }
                            DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                            var ListOrderAuditOrdUsero = FsDb.Tbl_AccountingRestriction_Audit.Where(x => x.AccountingRestrictionID == Vlng_AccRstID).ToList();
                            foreach (var v in ListOrderAuditOrdUsero)
                            {
                                v.RestrictionDataID = Vbl_RestrictionDataID;

                                v.ReferenceDate = Vdt_Today;
                                v.Note = Vst_note;
                                v.IsUserUpdate = false;
                                v.UserUpdateDate = null;
                                FsDb.SaveChanges();
                            }

                            MessageBox.Show("تم التعديل");
                            //****************Refrences***************
                            AccRstAuditSelect(Vlng_AccRstID);
                            //***************************************

                        }
                    }
                    else
                    {
                        MessageBox.Show("برجاء مراجعة مدخلي بيانات المستندات ");
                    }
                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  مراجعه المستندات .. برجاء مراجعة مدير المنظومه");
                }
            }
            else
            {
                MessageBox.Show("اختر المستند المراد مراجعته");
            }
        }

        private void textBox29_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإثبات مراجعة المستند", TB, 0, 0, VisibleTime);
        }

        private void textBox29_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.AccountRstAuditFrm t = new Forms.DocumentsForms.AccountRstAuditFrm();
                t.txtAccRstId.Text = this.textBox5.Text;
                t.txtAccNo.Text = this.Restriction_NO.Text;

                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                if (textBox2.Text != "")
                {
                    t.ShowDialog();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر المستند المراد مراجعته اولا");
                }
                //if (Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow != null)
                //{
                //    txtSupliers.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[1].Value.ToString();
                //    txtSuplierID.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[0].Value.ToString();

                //}
            }
        }

        private void Res_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Convert.ToDecimal(df.Text) != 0 || Convert.ToDecimal(PrTot.Text) != 0 || Convert.ToDecimal(CaTolt.Text) != 0)
            {
                MessageBox.Show("لا يمكنك اقفال الشاشة والقيد غير متزن");
                e.Cancel = true;
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            panel2.Visible = true;
            dataGridView1.Enabled = false;

        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            //saveToDB();
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 1005);
                if (validationSaveUser != null)
                {



                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                    SqlCommand com = new SqlCommand();
                    com.CommandType = CommandType.Text;
                    com.Connection = con;

                    FindKind f = new FindKind();
                    f.ShowDialog();

                    if (FindKind.SelectedRow != null)
                    {
                        dataGridView1.CurrentRow.Cells[9].Value = FindKind.SelectedRow.Cells[1].Value.ToString();
                    }

                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("select ID from Tbl_RestrictionItemsCategory where Name='" + dataGridView1.CurrentRow.Cells[9].Value.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.CurrentRow.Cells[10].Value = dt.Rows[0][0].ToString();

                        con.Close();


                        if (Convert.ToInt32(textBox31.Text) > 0)
                        {
                            con.Open();
                            com.CommandText = ("Update Tbl_AccountingRestrictionItems set RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID where ID=@ID   ");



                            com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);
                            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox31.Text);
                            com.ExecuteNonQuery();
                            con.Close();

                            //******************حفظ احداث التصنيف
                            long Vlng_AccRst = long.Parse(textBox5.Text);
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة تصنيف",
                                TableName = "Tbl_AccountingRestrictionItems",
                                TableRecordId = textBox31.Text,
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                                //ActionDate = Convert.ToDateTime(DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة تصنيف بنود القيد"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("تم الحفظ");

                            //*********************
                        }

                        textBox31.Text = "0";
                    }
                    //else
                    //{
                    //    MessageBox.Show("الرجاء قم بالضغط مرتين على البند المراد اضافه / تعديل التصنيف الخاص به");
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تصنيف بنود القيد .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox31.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            }
            catch { }
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            chckBxBasicData.Checked = false;
            textBox36.BackColor = Color.White;
            textBox36.ForeColor = Color.Black;
            label24.Text = string.Empty;
            Searching();
            getBanifecary();
            try
            {
                long Vlng_AccRstID = long.Parse(textBox5.Text);
                AccRstAuditSelect(Vlng_AccRstID);
                var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TrecordId == Vlng_AccRstID).Distinct().ToList();

                string Vstr_UserAddR = "";
                int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                }
                textBox30.Text = Vstr_UserAddR;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long Vlng_AccRstID = long.Parse(textBox5.Text);
            AccRstAuditSelect(Vlng_AccRstID);
            var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TrecordId == Vlng_AccRstID).Distinct().ToList();

            string Vstr_UserAddR = "";
            int WCount = int.Parse(ListAccRstAudit.Count.ToString());
            for (int i = 0; i <= WCount - 1; i++)
            {
                Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
            }
            textBox30.Text = Vstr_UserAddR;
        }

        private void DocNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void DocNO2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DocNO2.Text != string.Empty)
                {
                    DocNO.Text = string.Empty;
                }
                Manag.Focus();


            }
            if (e.KeyCode == Keys.Right)
            {
                DocNO.Focus();
                DocNO.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                Manag.Focus();
                Manag.SelectAll();
            }
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            DocumentBenefcairyFrm f = new DocumentBenefcairyFrm();
            f.textBox1.Text = textBox10.Text;
            f.textBox7.Text = comboBox4.SelectedValue.ToString();
            string s = (from DataGridViewRow row in dataGridViewX2.Rows
                        where row.Cells[2].FormattedValue.ToString() != string.Empty
                        select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
            string x = (from DataGridViewRow row in dataGridView1.Rows
                        where row.Cells[1].FormattedValue.ToString().Contains("12821")
                        select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            f.BrokerAccount.Text = s.ToString();
            f.BankAccount.Text = x.ToString();
            f.ShowDialog();
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            PrintRestriction p = new PrintRestriction();
            p.resNum.Text = Restriction_NO.Text;
            p.ResDate.Text = dateTimePicker1.Text;
            p.textBox1.Text = exCenter.Text;
            p.textBox2.Text = Manag.Text;
            p.textBox3.Text = DocNO.Text;
            p.textBox4.Text = DocNO2.Text;
            p.textBox5.Text = UsFul.Text;
            p.textBox6.Text = Empc.Text;
            p.textBox7.Text = Descp.Text;
            p.textBox8.Text = Order.Text;
            p.textBox9.Text = comboBox2.Text;
            p.textBox10.Text = dateTimePicker2.Text;
            p.textBox11.Text = Respo.Text;
            p.textBox12.Text = textBox26.Text;
            p.textBox13.Text = textBox28.Text;
            p.x = x;
            p.y = y;
            p.z = Convert.ToInt32(comboBox3.SelectedValue);
            p.ShowDialog();
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            DeleteRecords();
            button2_Click_1(sender, e);
        }

        private void PrDebit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Descp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DocNO2_Leave(object sender, EventArgs e)
        {
            DocNO2.BackColor = Color.White;
        }

        private void DocNO2_Enter(object sender, EventArgs e)
        {
            DocNO2.BackColor = Color.NavajoWhite;
        }

        private void textBox26_Leave(object sender, EventArgs e)
        {
            textBox26.BackColor = Color.White;
        }

        private void textBox26_Enter(object sender, EventArgs e)
        {
            textBox26.BackColor = Color.NavajoWhite;
        }

        private void textBox28_Leave(object sender, EventArgs e)
        {
            textBox28.BackColor = Color.White;
        }

        private void textBox28_Enter(object sender, EventArgs e)
        {
            textBox28.BackColor = Color.NavajoWhite;
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            dateTimePicker1.BackColor = Color.White;
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            dateTimePicker1.BackColor = Color.NavajoWhite;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {

                //DialogResult result = MessageBox.Show(" هل تريد حذف هذا البند ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == System.Windows.Forms.DialogResult.Yes)
                //{
                checkBox10.Checked = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                SqlDataReader red;
                com.Connection = con;
                com.CommandText = ("delete from Tbl_AccountingRestrictionItems  where ID=@ID   ");
                com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value.ToString());
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                    dataGridView1.Rows.RemoveAt(r.Index);
                checkBox10.Checked = false;


                textBox31.Text = string.Empty;
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[3].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[4].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                textBox1.Text = dataGridView1.Rows.Count.ToString();
                double xx1, yy1, zz1;
                xx1 = Convert.ToDouble(tD.Text);
                yy1 = Convert.ToDouble(tC.Text);
                zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                df.Text = Convert.ToString(zz1);


                int value = 1;

                PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value) && value == 1
                                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value) && value == 1
                                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                double PrD, PRC, PRT;
                PrD = Convert.ToDouble(PrDebit.Text);
                PRC = Convert.ToDouble(Prcridit.Text);
                PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                PrTot.Text = Convert.ToString(PRT);

                int value1 = 2;
                CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value1) && value == 2
                                select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value1) && value == 2
                                 select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                double CaD, CaC, CaT;
                CaD = Convert.ToDouble(CaDebit.Text);
                CaC = Convert.ToDouble(CaCridit.Text);
                CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                CaTolt.Text = Convert.ToString(CaT);
                MessageBox.Show("تم حذف  بند القيد بنجاح");
                panel2.Visible = false;
                dataGridView1.Enabled = true;
                //}
                //else
                //{
                //    panel2.Visible = false;
                //    dataGridView1.Enabled = true;
                //}

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل أو حذف  بنود القيد .. برجاء مراجعة مدير المنظومه");
            }
            //}
            //catch { }
            textBox22.Focus();
            textBox22.SelectAll();
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 3);
                if (validationSaveUser != null)
                {
                    if (dataGridViewX8.Rows.Count > 0)
                    {
                        MessageBox.Show("يوجد بند لم يتم تعديلة ,, الرجاء قم بتعديلة أولا");
                        panel2.Visible = false;
                        dataGridView1.Enabled = true;
                    }
                    else
                    {
                        //DialogResult result = MessageBox.Show(" هل تريد تعديل هذا البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (result == System.Windows.Forms.DialogResult.Yes)
                        //{
                        panel2.Visible = false;
                        dataGridView1.Enabled = true;
                        checkBox10.Checked = true;
                        textBox22.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        textBox23.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        textBox24.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        textBox25.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        comboBox4.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value;
                        try
                        {
                            dataGridViewX8.Rows.Add(0, dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), dataGridView1.CurrentRow.Cells[4].Value.ToString(), dataGridView1.CurrentRow.Cells[5].Value.ToString(), dataGridView1.CurrentRow.Cells[6].Value.ToString(), dataGridView1.CurrentRow.Cells[7].Value.ToString(), dataGridView1.CurrentRow.Cells[8].Value.ToString(), dataGridView1.CurrentRow.Cells[9].Value.ToString(), dataGridView1.CurrentRow.Cells[10].Value.ToString(), dataGridView1.CurrentRow.Cells[11].Value.ToString(), dataGridView1.CurrentRow.Cells[12].Value.ToString(), dataGridView1.CurrentRow.Cells[13].Value.ToString(), dataGridView1.CurrentRow.Cells[14].Value.ToString(), dataGridView1.CurrentRow.Cells[15].Value.ToString(), dataGridView1.CurrentRow.Cells[16].Value.ToString(), dataGridView1.CurrentRow.Cells[17].Value.ToString(), dataGridView1.CurrentRow.Cells[18].Value.ToString(), dataGridView1.CurrentRow.Cells[19].Value.ToString(), true, dataGridView1.CurrentRow.Cells[21].Value.ToString());
                        }
                        catch
                        {
                            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                                dataGridView1.Rows.RemoveAt(r.Index);
                            checkBox10.Checked = false;
                            //MessageBox.Show("الرجاء قم بالضغط مرتين على البند المراد حذفة");
                        }
                        textBox31.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                        if (dataGridView1.CurrentRow.Cells[13].Value.ToString() == DBNull.Value.ToString())
                        {
                            textBox31.Text = "0";
                        }
                        if (Convert.ToInt32(textBox31.Text) > 0)
                        {
                            //SqlConnection con = new SqlConnection();
                            //con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                            //SqlCommand com = new SqlCommand();
                            //SqlCommand com1 = new SqlCommand();
                            //com.CommandType = CommandType.Text;
                            //com1.CommandType = CommandType.Text;
                            //SqlDataReader red;
                            //com.Connection = con;
                            //com.CommandText = ("delete from Tbl_AccountingRestrictionItems  where ID=@ID   ");
                            //com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox31.Text);
                            //con.Open();
                            //com.ExecuteNonQuery();
                            //con.Close();
                            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                            if (selectedRowCount > 0)
                            {
                                for (int i = 0; i < selectedRowCount; i++)
                                {
                                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                                }
                            }
                            textBox31.Text = string.Empty;
                            //FindFileNumber1();
                            tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                                       where row.Cells[3].FormattedValue.ToString() != string.Empty
                                       select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                            tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                                       where row.Cells[4].FormattedValue.ToString() != string.Empty
                                       select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                            textBox1.Text = dataGridView1.Rows.Count.ToString();
                            double xx1, yy1, zz1;
                            xx1 = Convert.ToDouble(tD.Text);
                            yy1 = Convert.ToDouble(tC.Text);
                            zz1 = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                            df.Text = Convert.ToString(zz1);



                            // dataGridView1.AllowUserToAddRows = true;
                            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[21].Value != null)
                            {
                                if (int.Parse(dataGridView1.CurrentRow.Cells[21].Value.ToString()) == 1)
                                {
                                    int value = 1; // Define value outside the LINQ query

                                    PrDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                    where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value) && value == 1
                                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                                    Prcridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                     where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value) && value == 1
                                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                                    double PrD, PRC, PRT;
                                    PrD = Convert.ToDouble(PrDebit.Text);
                                    PRC = Convert.ToDouble(Prcridit.Text);
                                    PRT = Convert.ToDouble(PrDebit.Text) - Convert.ToDouble(Prcridit.Text);
                                    PrTot.Text = Convert.ToString(PRT);
                                    //dataGridView1.AllowUserToAddRows = true;

                                }
                                else if (int.Parse(dataGridView1.CurrentRow.Cells[21].Value.ToString()) == 2)
                                {
                                    int value = 2;
                                    CaDebit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                    where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value) && value == 2
                                                    select Convert.ToDouble(row.Cells[3].Value)).Sum().ToString();
                                    CaCridit.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                     where row.Cells[21].Value != null && int.TryParse(row.Cells[21].Value.ToString(), out value) && value == 2
                                                     select Convert.ToDouble(row.Cells[4].Value)).Sum().ToString();

                                    double CaD, CaC, CaT;
                                    CaD = Convert.ToDouble(CaDebit.Text);
                                    CaC = Convert.ToDouble(CaCridit.Text);
                                    CaT = Convert.ToDouble(CaDebit.Text) - Convert.ToDouble(CaCridit.Text);
                                    CaTolt.Text = Convert.ToString(CaT);
                                    //GetDocumentData();
                                    //MessageBox.Show("تم حذف  بند القيد بنجاح");
                                    //UsFul.Items.Clear();
                                    //getBanifecary();
                                    panel2.Visible = false;
                                    dataGridView1.Enabled = true;
                                }
                            }
                        }
                        //if(textBox31.Text == "0" || textBox31.Text == string.Empty)
                        else
                        {

                            //foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                            //    dataGridView1.Rows.RemoveAt(r.Index);
                            //MessageBox.Show("الرجاء قم بالضغط مرتين على البند المراد حذفة");
                        }
                        //}
                        //else
                        //{
                        //    panel2.Visible = false;
                        //    dataGridView1.Enabled = true;

                        //}
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل أو حذف  بنود القيد .. برجاء مراجعة مدير المنظومه");
                }
                //}
                //catch { }
                textBox22.Focus();
                textBox22.SelectAll();
            }
            catch { }
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    dataGridView1.Rows.Add(0, dataGridViewX8.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString(), dataGridViewX8.CurrentRow.Cells[4].Value.ToString(), dataGridViewX8.CurrentRow.Cells[5].Value.ToString(), dataGridViewX8.CurrentRow.Cells[6].Value.ToString(), dataGridViewX8.CurrentRow.Cells[7].Value.ToString(), dataGridViewX8.CurrentRow.Cells[8].Value.ToString(), dataGridViewX8.CurrentRow.Cells[9].Value.ToString(), dataGridViewX8.CurrentRow.Cells[10].Value.ToString(), dataGridViewX8.CurrentRow.Cells[11].Value.ToString(), dataGridViewX8.CurrentRow.Cells[12].Value.ToString(), dataGridViewX8.CurrentRow.Cells[13].Value.ToString(), dataGridViewX8.CurrentRow.Cells[14].Value.ToString(), dataGridViewX8.CurrentRow.Cells[15].Value.ToString(), dataGridViewX8.CurrentRow.Cells[16].Value.ToString(), dataGridViewX8.CurrentRow.Cells[17].Value.ToString(), dataGridViewX8.CurrentRow.Cells[18].Value.ToString(), dataGridViewX8.CurrentRow.Cells[19].Value.ToString(), true, dataGridViewX8.CurrentRow.Cells[21].Value.ToString());
            //}
            //catch
            //{
            //    foreach (DataGridViewRow r in dataGridViewX8.SelectedRows)
            //        dataGridViewX8.Rows.RemoveAt(r.Index);
            //    checkBox10.Checked = false;
            //    //MessageBox.Show("الرجاء قم بالضغط مرتين على البند المراد حذفة");
            //}
            if (Convert.ToInt32(Restriction_NO.Text) > 0 && Convert.ToDecimal(df.Text) == 0 && Convert.ToDecimal(PrTot.Text) == 0 && Convert.ToDecimal(CaTolt.Text) == 0)
            {
                if (CategortID.Text != string.Empty)
                {
                    dataGridView1.AllowUserToAddRows = false;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 27 && w.ProcdureId == 3);
                        if (validationSaveUser != null)
                        {
                            DialogResult result = MessageBox.Show(" هل تريد تعديل هذا المستند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (textBox10.Text == string.Empty)
                                {
                                    SaveDocument();
                                    GetDocID();
                                }
                                if (textBox5.Text == string.Empty)
                                {
                                    SaveRestrictionFirtTime();
                                    GenerateID();
                                }
                                SaveDocumentBenefcairy();
                                saveToDB();
                                UpdateHeader();
                                UpdateRes();


                                MessageBox.Show(" تم حفظ المستند بنجاح ", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Restriction_NO.Focus();
                                Restriction_NO.Select();
                                progressBar1.Visible = false;
                                DT.Clear();
                                dataGridView1.Rows.Clear();
                                dataGridViewX2.Rows.Clear();
                                //if(checkBox12. Checked == false)
                                //    {
                                //GoNextAfterSave();
                                //}
                                //CleareControls();
                                Restriction_NO.Focus();
                                Restriction_NO.SelectAll();
                                button2_Click_1(sender, e);
                                Restriction_NO.Focus();
                                Restriction_NO.SelectAll();
                                labelControl1.Visible = true;
                            }

                        }
                    }

                }

                else
                {
                    MessageBox.Show(" الرجاء قم باختيار البيان ", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Descp.Focus();

                }
                if (Convert.ToDecimal(df.Text) != 0)
                {
                    MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Thread networkThread = new Thread(MonitorNetworkStatus);
            //networkThread. Start();
        }
        private void MonitorNetworkStatus()
        {
            while (true)
            {
                // Check the database connection status
                bool isConnected = CheckConnection();

                // Update the PictureBox image based on the database connection status
                UpdateNetworkStatusImage(isConnected);

                // Wait for 5 seconds before checking again
                Thread.Sleep(5000);
            }
        }

        private bool CheckConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

        private void UpdateNetworkStatusImage(bool isConnected)
        {

        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // تنفيذ دالة التحقق من الاتصال
            CheckConnection();
        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {
            //if (textBox5.Text != string.Empty)
            //{
            //    Forms.Banks.Restrictions_checksFRM f = new Banks.Restrictions_checksFRM();
            //    f.textBox3.Text = Restriction_NO.Text;
            //    f.textBox4.Text = comboBox1.Text;
            //    f.textBox5.Text = UsFul.Text;
            //    f.textBox14.Text = UsFulID.Text;
            //    f.textBox15.Text = textBox5.Text;
            //    string Val = (from DataGridViewRow row in dataGridView1.Rows
            //                  where row.Cells[1].FormattedValue.ToString().Contains("12821")
            //                  select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
            //    DataTable BankInGrid = new DataTable();
            //    BankInGrid.Columns.Add("ID");
            //    BankInGrid.Columns.Add("البنوك المسجلة على المستند");

            //    //BankInGrid.Add((from DataGridViewRow row in dataGridView1.Rows
            //    //                where row.Cells[1].FormattedValue.ToString().Contains("12821")
            //    //                select row.Cells[13].Value.ToString()).ToString());
            //    dataGridView1.AllowUserToAddRows = false;
            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (dataGridView1.Rows[i].Cells[1].Value.ToString().Contains("12821"))
            //        {

            //            string ReID = dataGridView1.Rows[i].Cells[13].Value.ToString();
            //            string ReBank = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //            BankInGrid.Rows.Add(ReID, ReBank);

            //        }
            //    }
            //    f.dataGridView3.DataSource = BankInGrid;
            //    f.dataGridView3.Columns[0].Visible = false;
            //    f.dataGridView3.Columns[1].Width = 310;
            //    f.textBox1.Text = Val;
            //    f.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("الرجاء قم بإختيار البيان وحفظ المستند أولا");
            //}
        }

        private void Res_Frm_Resize(object sender, EventArgs e)
        {
            //this.SuspendLayout();
            //ResizeControls();
            //this.ResumeLayout();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //labelControl3.Visible = !labelControl3.Visible;
            labelControl2.Visible = !labelControl2.Visible;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == false)
            {
                panel20.Visible = true;

            }
            if (checkBox14.Checked == true)
            {
                panel20.Visible = false;

            }
        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            panel22.Visible = true;
        }

        private void dateTimePicker5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox32.Focus();
                textBox32.SelectAll();
            }
        }

        private void textBox32_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox33.Focus();
                textBox33.SelectAll();
            }

        }

        private void textBox33_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(textBox32.Text) > 0 || Convert.ToInt32(textBox32.Text) > 0)
                {
                    dateTimePicker1.Value = dateTimePicker5.Value;
                    panel22.Visible = false;
                    labelControl8.Text = " العام المالى " + comboBox3.Text;
                    Restriction_NO.Text = textBox32.Text;
                    try
                    {
                        if (checkBox15.Checked == false)
                        {
                            comboBox1.Text = comboBox5.Text;
                        }
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 12)
                        {
                            x = 1;
                            y = 2;
                        }

                        if (Convert.ToInt32(comboBox1.SelectedValue) == 13)
                        {
                            x = 3;
                            y = 3;
                        }
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 14)
                        {
                            x = 4;
                            y = 4;
                        }
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 15)
                        {
                            x = 5;
                            y = 5;
                        }
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 16)
                        {
                            x = 6;
                            y = 6;
                        }
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 17)
                        {
                            x = 7;
                            y = 7;
                        }
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 18)
                        {
                            x = 8;
                            y = 8;
                        }
                        if (Convert.ToInt32(comboBox1.SelectedValue) == 19)
                        {
                            x = 9;
                            y = 9;
                        }
                        GetParentIDKind();
                        ComboInDataGrid();
                        comboBox4.DataSource = fillDGVComboBox();
                        comboBox4.DisplayMember = "Name";
                        comboBox4.ValueMember = "ID";
                        //if (int.Parse(Restriction_NO.Text) > 0)
                        //{
                        //    Restriction_NO.Focus();
                        //    CleareControls();
                        //    GetREstrictionID();
                        //    FindFileNumber1();
                        //    GetDocumentData();
                        //    Getex();
                        //    GetMan();
                        //    GetUsf();
                        //    Getcate();
                        //    GetHand();
                        //    GetRespon();
                        //    GetHand();
                        //    GetOrdersIDDocument();
                        //    BrokerAccount();
                        //    dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";

                        //}

                    }
                    catch { }
                    Restriction_NO.Focus();
                    Restriction_NO.SelectAll();
                }
                else
                {
                    MessageBox.Show("الرجاء حدد تاريخ اليومية وتحديد نطاق المستندات");
                }

            }

        }

        private void checkBox15_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                panel22.Visible = false;
                Restriction_NO.Focus();
                Restriction_NO.SelectAll();
                labelControl8.Text = " العام المالى " + comboBox3.Text;
            }
            else
            {
                dateTimePicker5.Focus();
            }
        }

        private void SendNoteFromUserToSysUniteAuditing()
        {
            long Vlng_AccRstID = long.Parse(textBox5.Text);
            bool Vbl_RestrictionDataID = false;
            string Vst_note = null;
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 77 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                if (textBox34.Text != "" && textBox7.Text != "")
                {
                    Vbl_RestrictionDataID = true;
                    var ListOrderAuditOrdUser = FsDb.Tbl_UserNoteToSystemUnite.FirstOrDefault(x => x.AccountingRestrictionID == Vlng_AccRstID);
                    if (ListOrderAuditOrdUser == null)

                    {
                        SelcectOrderUser(textBox7.Text);
                        string Vst_OrderId = textBox7.Text;
                        var List = FsEvDb.SecurityEvents.Where(x => x.TableName == "Tbl_Order" && x.TableRecordId == Vst_OrderId).Select(p => p.User_ID).Distinct().ToList();
                        foreach (var v in List)
                        {

                        }
                        var selecteditems = checkedComboBoxEdit1.Properties.GetItems().GetCheckedValues();

                        int Vint_SystemUnitID = 0;
                        foreach (var value in selecteditems)
                        {
                            Vint_SystemUnitID = int.Parse(value.ToString());
                            DateTime Vdt_Today = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate());

                            //***********************************
                            long Vint_orderId = long.Parse(textBox7.Text);
                            Tbl_UserNoteToSystemUnite AccRstAud = new Tbl_UserNoteToSystemUnite
                            {

                                UserIDData = Program.GlbV_UserId,
                                AccountingRestrictionID = Vlng_AccRstID,
                                IsRestrictionNot = Vbl_RestrictionDataID,
                                NoteDate = Vdt_Today,
                                Note = textBox34.Text,
                                Note1 = textBox34.Text,
                                SystemUnitesID = Vint_SystemUnitID,
                                OrderID = Vint_orderId
                            };
                            FsDb.Tbl_UserNoteToSystemUnite.Add(AccRstAud);
                            FsDb.SaveChanges();
                            long Vint_LastRow = AccRstAud.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة ملاحظه لوحدة مراجعه",
                                TableName = "Tbl_UserNoteToSystemUnite",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                                //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة القيود اليوميه"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();




                        }
                    }
                    textBox34.Text = "";
                    //checkBox16.Checked = false;
                    //DeselectAllItems();

                }
            }
        }
        void DeselectAllItems()
        {
            for (int i = 0; i < checkedComboBoxEdit1.Properties.Items.Count; i++)
            {
                checkedComboBoxEdit1.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
        }
        private void AccRstNoteToUnitSelect(long? Vint_AccRstAudIDC)
        {

            checkBox16.Checked = false;
            if (textBox34.InvokeRequired)
            {
                textBox34.Invoke(new MethodInvoker(delegate { textBox34.BackColor = Color.White; }));
            }
            else
            {
                textBox34.BackColor = Color.White;
            }
            textBox34.ForeColor = Color.Black;
            var ListAccRstAuditOrd = FsDb.Tbl_UserNoteToSystemUnite.Where(x => x.AccountingRestrictionID == Vint_AccRstAudIDC && (x.Note != null)).Select(p => p.Note).Distinct().ToList();
            var ListAccRstCount = FsDb.Tbl_UserNoteToSystemUnite.Where(x => x.AccountingRestrictionID == Vint_AccRstAudIDC && (x.Note != null)).ToList();
            var ListAccRstAuditOrdUser = FsDb.Tbl_UserNoteToSystemUnite.FirstOrDefault(x => x.AccountingRestrictionID == Vint_AccRstAudIDC && x.UserIDData == Program.GlbV_UserId);
            if (ListAccRstAuditOrd.Count != 0)
            {
                checkBox16.Checked = false;
                textBox34.Text = "";
                foreach (var v in ListAccRstAuditOrd)
                {
                    textBox34.Text = textBox34.Text + " - " + v.ToString();
                }
                foreach (var vC in ListAccRstCount)
                {
                    if (vC.SystemUnitesID != null)
                    {
                        int Vint_SysID = int.Parse(vC.SystemUnitesID.ToString());
                        var Vstr_sysuniteName = FsDb.Tbl_SystemUnites.Where(x => x.ID == Vint_SysID).Select(p => p.Name).Distinct().ToList();
                        textBox35.Text = textBox35.Text + " - " + Vstr_sysuniteName[0].ToString();
                    }
                }
                textBox34.BackColor = Color.PaleVioletRed;
                textBox34.ForeColor = Color.Blue;

            }
            else
            {
                if (ListAccRstAuditOrdUser != null)
                {
                    if (ListAccRstAuditOrdUser.IsRestrictionNot == true)
                    {
                        checkBox16.Checked = true;
                        textBox34.BackColor = Color.Green;
                        textBox34.ForeColor = Color.Black;
                    }
                    else
                    {
                        checkBox16.Checked = false;
                        textBox34.BackColor = Color.White;
                        textBox34.ForeColor = Color.Black;
                    }
                }
                else
                {

                    checkBox16.Checked = false;
                    textBox34.BackColor = Color.White;
                    textBox34.ForeColor = Color.Black;

                }
            }

            //var ListAccRstAudit = (from AccRstAud in FsDb.Tbl_UserNoteToSystemUnite
            //                       join usr in FsDb.Tbl_User on AccRstAud.UserIDData equals usr.ID
            //                       join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
            //                       where (AccRstAud.AccountingRestrictionID == Vint_AccRstAudIDC)
            //                       select new
            //                       {
            //                           EmpName = emp.Name
            //                       }).Distinct().ToList();
            //if (ListAccRstAudit != null)
            //{
            //    string Vstr_RefrencesOrder = "";
            //    int WCount = int.Parse(ListAccRstAudit.Count.ToString());
            //    for (int i = 0; i <= WCount - 1; i++)
            //    {
            //        Vstr_RefrencesOrder = ListAccRstAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
            //    }
            //    textBox29.Text = Vstr_RefrencesOrder;
            //}
            //else
            //{
            //    textBox29.Text = "";
            //}
        }
        private void checkBox16_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (checkBox15.Checked == false)
                {
                    comboBox1.Text = comboBox5.Text;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 12)
                {
                    x = 1;
                    y = 2;
                }

                if (Convert.ToInt32(comboBox1.SelectedValue) == 13)
                {
                    x = 3;
                    y = 3;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 14)
                {
                    x = 4;
                    y = 4;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 15)
                {
                    x = 5;
                    y = 5;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 16)
                {
                    x = 6;
                    y = 6;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 17)
                {
                    x = 7;
                    y = 7;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 18)
                {
                    x = 8;
                    y = 8;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 19)
                {
                    x = 9;
                    y = 9;
                }
                GetParentIDKind();
                ComboInDataGrid();
                comboBox4.DataSource = fillDGVComboBox();
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
                if (int.Parse(Restriction_NO.Text) > 0)
                {
                    Restriction_NO.Focus();
                    CleareControls();
                    GetREstrictionID();
                    FindFileNumber1();
                    GetDocumentData();
                    Getex();
                    GetMan();
                    GetUsf();
                    Getcate();
                    GetHand();
                    GetRespon();
                    GetHand();
                    GetOrdersIDDocument();
                    BrokerAccount();
                    dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";

                }

            }
            catch { }
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == false)
            {
                comboBox1.Text = comboBox5.Text;
                try
                {
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 12)
                    {
                        x = 1;
                        y = 2;
                    }

                    if (Convert.ToInt32(comboBox1.SelectedValue) == 13)
                    {
                        x = 3;
                        y = 3;
                    }
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 14)
                    {
                        x = 4;
                        y = 4;
                    }
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 15)
                    {
                        x = 5;
                        y = 5;
                    }
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 16)
                    {
                        x = 6;
                        y = 6;
                    }
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 17)
                    {
                        x = 7;
                        y = 7;
                    }
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 18)
                    {
                        x = 8;
                        y = 8;
                    }
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 19)
                    {
                        x = 9;
                        y = 9;
                    }
                }
                catch { }
            }
        }
        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox15.Checked == false)
                {
                    comboBox1.Text = comboBox5.Text;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 12)
                {
                    x = 1;
                    y = 2;
                }

                if (Convert.ToInt32(comboBox1.SelectedValue) == 13)
                {
                    x = 3;
                    y = 3;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 14)
                {
                    x = 4;
                    y = 4;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 15)
                {
                    x = 5;
                    y = 5;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 16)
                {
                    x = 6;
                    y = 6;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 17)
                {
                    x = 7;
                    y = 7;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 18)
                {
                    x = 8;
                    y = 8;
                }
                if (Convert.ToInt32(comboBox1.SelectedValue) == 19)
                {
                    x = 9;
                    y = 9;
                }
                GetParentIDKind();
                ComboInDataGrid();
                comboBox4.DataSource = fillDGVComboBox();
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
                if (int.Parse(Restriction_NO.Text) > 0)
                {
                    Restriction_NO.Focus();
                    CleareControls();
                    GetREstrictionID();
                    FindFileNumber1();
                    GetDocumentData();
                    Getex();
                    GetMan();
                    GetUsf();
                    Getcate();
                    GetHand();
                    GetRespon();
                    GetHand();
                    GetOrdersIDDocument();
                    BrokerAccount();
                    dataGridView1.Columns["Column2"].DefaultCellStyle.NullValue = "0";

                }

            }
            catch { }
        }

        private void textBox30_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.AddDataByUsersFrm t = new Forms.DocumentsForms.AddDataByUsersFrm();
                decimal Vlong_RestNo = decimal.Parse(Restriction_NO.Text);
                DateTime Vdate_RestDate = Convert.ToDateTime(dateTimePicker1.Value);

                var list = FsDb.Tbl_AccountingRestriction.FirstOrDefault(x => x.Restriction_NO == Vlong_RestNo && x.Restriction_Date == Vdate_RestDate);


                t.txtRstAccId.Text = list.ID.ToString();
                t.txtAccRestNo.Text = this.Restriction_NO.Text;
                t.dateTimePicker1.Value = Convert.ToDateTime(this.dateTimePicker1.Value.ToString());
                t.txtKindProcess.Text = "1";

                if (textBox2.Text != "")
                {
                    t.ShowDialog();
                }


            }
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& e.KeyChar!='\b' && e.KeyChar != '0' && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show( "المدين ***  الرجاء إدخال ارقام فقط");
                textBox24.Text = "0";
                textBox24.Focus();
                textBox24.SelectAll();
            }
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '0' && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("الدائن ***  الرجاء إدخال ارقام فقط");
                textBox25.Text = "0";
                textBox25.Focus();
                textBox25.SelectAll();
            }
        }

        private void textBox24_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void Descp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void exCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UsFul_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Empc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}


