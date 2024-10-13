using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class RadForm2 : Telerik.WinControls.UI.RadForm
    {
        DataTable DT = new DataTable();
        DataTable DT1 = new DataTable();
        DataTable DT2 = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt = new DataTable();
        //SqlCommandBuilder cbulder = new SqlCommandBuilder();
        void CreateDataTable()
        {
            //DT.Columns.Add("م ");
            //DT.Columns.Add("AccountingRestriction_ID");
            //DT.Columns.Add("Accounting_Guid_ID");
            //DT.Columns.Add("RestrictionItemsCategory_ID");
            //DT.Columns.Add("رقم الحساب");
            //DT.Columns.Add("اسم الحساب");
            //DT.Columns.Add("مدين");
            //DT.Columns.Add("دائن");
            //DT.Columns.Add("Activities_ID");
            ////DT.Columns.Add("RestrictionItemsCategory_ID");
            ////DT.Columns.Add("RestrictionItemsCategory_ID");


            //dataGridView1.DataSource = DT;
            //dataGridView1.Columns[1].VisibleInColumnChooser = false;
            //dataGridView1.Columns[2].VisibleInColumnChooser = false;
            //dataGridView1.Columns[3].VisibleInColumnChooser = false;
            //dataGridView1.Columns[8].VisibleInColumnChooser = false;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
          //  dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public DataTable getDay()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (1,2)");
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
        int x = 0;
        int y = 0;
        public RadForm2()
        {
            InitializeComponent();
        }
        public void  FindFileNumber()
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
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.Accounting_Guid_ID,Tbl_RestrictionItemsCategory.Name as [التصنيف] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_Activities.Name as [النشاط] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");


            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_RestrictionItemsCategory.Name as [التصنيف] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D Order by Row_No ,Tbl_AccountingRestrictions_Kind.ID  ASc ");

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

            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_AccountingRestrictionItems.ID,Tbl_AccountingRestrictionItems.Accounting_Guid_ID from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID  where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_Activities.Name as [النشاط] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");


            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_RestrictionItemsCategory.Name as [التصنيف] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D Order by Row_No ,Tbl_AccountingRestrictions_Kind.ID  ASc ");

            com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;

            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;

            con.Open();
            red = com.ExecuteReader();
            if (red.HasRows)
            {
                while (red.Read())
                {
                    dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), red.GetValue(7));
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
        }
        private void Restriction_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //dataGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.None;

                //dataGridView1.DataSource = null;
                ////dataGridView1.Rows.Clear();
                //dataGridView1.Refresh();
                DocNO.Focus();
                FindFileNumber();
                if (dataGridView1.Rows.Count == 0)
                {
                    FindFileNumber1();
                }
                //dataGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            }
            }

        private void RadForm2_Load(object sender, EventArgs e)
        {
            //try
            //{
                Restriction_NO.Focus();
                Restriction_NO.SelectAll();
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_OrderHandler' table. You can move, or remove it, as needed.
                //this.tbl_OrderHandlerTableAdapter.Fill(this.financialSysDataSet.Tbl_OrderHandler);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Order' table. You can move, or remove it, as needed.
                this.tbl_OrderTableAdapter.Fill(this.financialSysDataSet.Tbl_Order);
                // TODO: This line of code loads data into the 'financialSysDataSet.TBL_Document' table. You can move, or remove it, as needed.
                this.tBL_DocumentTableAdapter.Fill(this.financialSysDataSet.TBL_Document);
                this.tbl_ExchangeCenterTableAdapter.Fill(this.financialSysDataSet.Tbl_ExchangeCenter);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_CostCenters' table. You can move, or remove it, as needed.
                this.tbl_CostCentersTableAdapter.Fill(this.financialSysDataSet.Tbl_CostCenters);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_IndebtednessKind' table. You can move, or remove it, as needed.
                this.tbl_IndebtednessKindTableAdapter.Fill(this.financialSysDataSet.Tbl_IndebtednessKind);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_RestrictionItemsCategory' table. You can move, or remove it, as needed.
                this.tbl_RestrictionItemsCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_RestrictionItemsCategory);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Beneficiary' table. You can move, or remove it, as needed.
                //this.tbl_BeneficiaryTableAdapter.Fill(this.financialSysDataSet.Tbl_Beneficiary);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Management' table. You can move, or remove it, as needed.
                this.tbl_ManagementTableAdapter.Fill(this.financialSysDataSet.Tbl_Management);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_DocumentCategory' table. You can move, or remove it, as needed.
                this.tbl_DocumentCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentCategory);
                this.tbl_Accounting_GuidTableAdapter.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);
                if (checkBox1.Checked == true)
                {
                    x = 1;
                    y = 2;
                    comboBox1.DataSource = getDay();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = 0;
                }
                if (checkBox2.Checked == true)
                {
                    x = 4;
                    y = 4;
                    comboBox1.DataSource = getPayment();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = 0;
                }
                if (checkBox3.Checked == true)
                {
                    x = 3;
                    y = 3;
                    comboBox1.DataSource = getsettlements();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = 0;
                }
                if (checkBox4.Checked == true)
                {
                    x = 7;
                    y = 7;
                    comboBox1.DataSource = getMOL1();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = 0;
                }
                if (checkBox5.Checked == true)
                {
                    x = 8;
                    y = 8;
                    comboBox1.DataSource = getMOL2();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = 0;
                }
                if (checkBox6.Checked == true)
                {
                    x = 9;
                    y = 9;
                    comboBox1.DataSource = getMOL3();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = 0;
                }
                if (checkBox7.Checked == true)
                {
                    x = 5;
                    y = 5;
                    comboBox1.DataSource = getOpen();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                    comboBox1.SelectedIndex = 0;
                }
                //textEdit1.Text = GenerateID().ToString();
                DT.Columns.Add("م ");
                DT.Columns.Add("AccountingRestriction_ID");
                DT.Columns.Add("Accounting_Guid_ID");
                DT.Columns.Add("RestrictionItemsCategory_ID");
                DT.Columns.Add("رقم الحساب");
                DT.Columns.Add("اسم الحساب");
                DT.Columns.Add("مدين");
                DT.Columns.Add("دائن");
                DT.Columns.Add("ID");
            //LoadSerial();
            radMultiColumnComboBox4.SelectedIndex = -1;
            popupContainerEdit1.SelectedIndex = -1;
            //}
            //catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select top(1) Restriction_NO from Tbl_AccountingRestriction where (Restriction_NO > @Restriction_NO and AcountingRestrictionCorrRelation_ID = @D2 )  OR ( Restriction_NO > @Restriction_NO and AcountingRestrictionCorrRelation_ID = @D3)     ");
            com.Parameters.Add("@Restriction_NO", SqlDbType.Int ).Value =Convert.ToInt32( Restriction_NO.Text);

            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;

            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                Restriction_NO.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();
            FindFileNumber();
            if (dataGridView1.Rows.Count == 0)
            {
                FindFileNumber1();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
            com1.CommandType = CommandType.Text;
            SqlDataReader red;
            com.Connection = con;
            com.CommandText = ("select top(1) Restriction_NO from Tbl_AccountingRestriction where (Restriction_NO < @Restriction_NO and AcountingRestrictionCorrRelation_ID = @D2 )  OR ( Restriction_NO < @Restriction_NO and AcountingRestrictionCorrRelation_ID = @D3)   ");
            com.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);

            com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
            com.Parameters.Add("@D3", SqlDbType.Int).Value = y;

            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                Restriction_NO.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();
            FindFileNumber();
            if (dataGridView1.Rows.Count == 0)
            {
                FindFileNumber1();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
                    //SqlDataReader red;
                    com.Connection = con;
                    //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    //{
                    com.CommandText = ("Update Tbl_AccountingRestrictionItems set Accounting_Guid_ID=@Accounting_Guid_ID,Debit_Value=@Debit_Value,Credit_Value=@Credit_Value,RestrictionItemsCategory_ID=@RestrictionItemsCategory_ID where ID=@ID   ");
                    com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(an.SelectedValue);

                    com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(db.Text);
                    com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(cr.Text);
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(cat.SelectedValue);
                    com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                    con.Open();

                    com.ExecuteNonQuery();
                    con.Close();
                    //}
                    FindFileNumber();
                    if (dataGridView1.Rows.Count == 0)
                    {
                        FindFileNumber1();
                    }
                    MessageBox.Show("تم التعديل على بند القيد بنجاح");
                    //dataGridView1.CurrentRow.Selected = false;
                    if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count)
                    {

                        dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Selected = true;






                        //dataGridView1.Refresh();
                    }
                    //int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                    //////int iRow = dataGridView1.CurrentCell.RowIndex;
                    //if (iColumn == dataGridView1.Columns.Count - 1)
                    //    dataGridView1.CurrentCell = dataGridView1[0, iRow + 1];
                    //else
                    //    dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];
                    //dataGridView1.CurrentCell.Selected = true;
                    //int currentRow = dataGridView1.SelectedRows[0].Index;
                    //if (currentRow < dataGridView1.RowCount +1)
                    //{
                    //    dataGridView1.Rows[++currentRow].Cells[0].Selected = true;

                    MouseEventArgs b = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2,
                                       MousePosition.X, MousePosition.Y, 0);
                    DataGridViewCellMouseEventArgs a = new DataGridViewCellMouseEventArgs(0, 0,
                    MousePosition.X, MousePosition.Y, b);
                    dataGridView1_MouseDoubleClick(sender, a);


                    //}
                }
            }
            catch { }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                an.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                aname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                db.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cr.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                cat.Text  = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch { }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                
                //textBox3.Text = "";
                //an.Text = "";
                //aname.Text = "";
                //db.Text = "0";
                //cr.Text = "0";
                //cat.Text = "";

                //textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                //an.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //aname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //db.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //cr.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //cat.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch { }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //textBox3.Text = "";
                //an.Text = "";
                //aname.Text = "";
                //db.Text = "0";
                //cr.Text = "0";
                //cat.Text = "";

                //textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                //an.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //aname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //db.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //cr.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //cat.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
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
                    //SqlDataReader red;
                    com.Connection = con;
                    //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    //{
                    com.CommandText = ("delete frome Tbl_AccountingRestrictionItems  where ID=@ID   ");
                    
                    com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                    con.Open();

                    com.ExecuteNonQuery();
                    con.Close();
                    //}
                    FindFileNumber();
                    if (dataGridView1.Rows.Count == 0)
                    {
                        FindFileNumber1();
                    }
                    MessageBox.Show("تم حذف  بند القيد بنجاح");
                    //dataGridView1.CurrentRow.Selected = false;
                    if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count)
                    {

                        dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Selected = true;






                        //dataGridView1.Refresh();
                    }
                    //int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                    //////int iRow = dataGridView1.CurrentCell.RowIndex;
                    //if (iColumn == dataGridView1.Columns.Count - 1)
                    //    dataGridView1.CurrentCell = dataGridView1[0, iRow + 1];
                    //else
                    //    dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];
                    //dataGridView1.CurrentCell.Selected = true;
                    //int currentRow = dataGridView1.SelectedRows[0].Index;
                    //if (currentRow < dataGridView1.RowCount +1)
                    //{
                    //    dataGridView1.Rows[++currentRow].Cells[0].Selected = true;

                    MouseEventArgs b = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2,
                                       MousePosition.X, MousePosition.Y, 0);
                    DataGridViewCellMouseEventArgs a = new DataGridViewCellMouseEventArgs(0, 0,
                    MousePosition.X, MousePosition.Y, b);
                    dataGridView1_MouseDoubleClick(sender, a);


                    //}
                }
            }
            catch { }
        }

        private void DocNO_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tD.Text = "0";
                    tC.Text = "0";
                    df.Text = "0";
                    textBox1.Text = "0";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    Lyear.Focus();
                    //popupContainerEdit2.SelectedIndex = -1;
                    //Descp.Text = "";
                    this.tBL_DocumentTableAdapter.FillByDocNO(this.financialSysDataSet.TBL_Document, DocNO.Text);
                    this.tbl_DocumentCategoryTableAdapter.FillByDoc(this.financialSysDataSet.Tbl_DocumentCategory, int.Parse(textBox2.Text));
                    this.tbl_ExchangeCenterTableAdapter.FillByDoc(this.financialSysDataSet.Tbl_ExchangeCenter, int.Parse(textBox3.Text));
                    Restriction_NO.Text = textBox4.Text;
                    if (Restriction_NO.Text != null)
                    {
                        FindFileNumber();
                        if (dataGridView1.Rows.Count == 0)
                        {
                            FindFileNumber1();
                        }
                        Descp.Focus();
                        //dataGridView1.DataSource = FindFileNumber();
                        //LoadSerial();

                        //tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                        //           where row.Cells[3].FormattedValue.ToString() != string.Empty
                        //           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
                        //tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                        //           where row.Cells[4].FormattedValue.ToString() != string.Empty
                        //           select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum().ToString();
                        //textBox1.Text = dataGridView1.Rows.Count.ToString();
                        //double xx, yy, zz;
                        //xx = Convert.ToDouble(tD.Text);
                        //yy = Convert.ToDouble(tC.Text);
                        //zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                        //df.Text = Convert.ToString(zz);
                       
                    }
                }
                if (e.KeyCode == Keys.Down)
                {

                    DOCPANEL.Visible = true;

                    this.tBL_DocumentBindingSource.AddNew();
                    popupContainerEdit2.SelectedIndex = -1;
                    Descp.SelectedIndex = -1;
                    textBoxX1.Focus();
                }
            }
            catch { }
        }

        private void navButton10_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Validate();
            this.tBL_DocumentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.financialSysDataSet);
            MessageBox.Show("تم حفظ المستند بنجاح");
        }

        private void navButton8_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            DocNO.Text = textBoxX1.Text;
            DOCPANEL.Visible = false;
           
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                dateTimePicker2.Focus();
            }

            }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                comboBox7.Focus();
            }
        }

        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                comboBox4.Focus();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                comboBox3.Focus();
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                comboBox5.Focus();
            }
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                comboBox6.Focus();
            }
        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                textBoxX2.Focus();
            }
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.DocumentCategoryFrm f = new BasicCodeForms.DocumentCategoryFrm();
            f.ShowDialog();
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            //comboBox7.Items.Clear();
            tbl_DocumentCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentCategory);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //Forms.BasicCodeForms. f = new BasicCodeForms.DocumentCategoryFrm();
            //f.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.ExchangeCemtersFrm  f = new BasicCodeForms.ExchangeCemtersFrm();
            f.ShowDialog();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            //Forms.BasicCodeForms.of = new BasicCodeForms.ExchangeCemtersFrm();
            //f.ShowDialog();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Forms.BasicCodeForms.BeneficiaryFrm  f = new BasicCodeForms.BeneficiaryFrm();
            f.ShowDialog();
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            tbl_ExchangeCenterTableAdapter.Fill(this.financialSysDataSet.Tbl_ExchangeCenter );
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            //tbl_BeneficiaryTableAdapter.Fill(this.financialSysDataSet.Tbl_Beneficiary);
        }

        private void Lyear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //dataGridView1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.None;

                //dataGridView1.DataSource = null;
                ////dataGridView1.Rows.Clear();
                //dataGridView1.Refresh();
                //DocNO.Focus();
            }
            }
    }
}
