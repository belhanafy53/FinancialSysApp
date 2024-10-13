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


namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class RestrictinItemsForm : DevExpress.XtraEditors.XtraForm
    {
        DataTable DT = new DataTable();
        DataTable DT1 = new DataTable();
        DataTable DT2 = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt = new DataTable();
        //SqlCommandBuilder cbulder = new SqlCommandBuilder();
        void CreateDataTable()
        {
            DT.Columns.Add("م ");
            DT.Columns.Add("AccountingRestriction_ID");
            DT.Columns.Add("Accounting_Guid_ID");
            DT.Columns.Add("RestrictionItemsCategory_ID");
            DT.Columns.Add("رقم الحساب");
            DT.Columns.Add("اسم الحساب");
            DT.Columns.Add("مدين");
            DT.Columns.Add("دائن");
            DT.Columns.Add("Activities_ID");
            //DT.Columns.Add("RestrictionItemsCategory_ID");
            //DT.Columns.Add("RestrictionItemsCategory_ID");


            dataGridView1.DataSource = DT;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.AllCells  ;
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
        public RestrictinItemsForm()
        {
            InitializeComponent();
        }

        private void RestrictinItemsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Management' table. You can move, or remove it, as needed.
            this.tbl_ManagementTableAdapter.Fill(this.financialSysDataSet.Tbl_Management);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_IndebtednessKind' table. You can move, or remove it, as needed.
            this.tbl_IndebtednessKindTableAdapter.Fill(this.financialSysDataSet.Tbl_IndebtednessKind);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Activities' table. You can move, or remove it, as needed.
            this.tbl_ActivitiesTableAdapter.Fill(this.financialSysDataSet.Tbl_Activities);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_CostCenters' table. You can move, or remove it, as needed.
            this.tbl_CostCentersTableAdapter.Fill(this.financialSysDataSet.Tbl_CostCenters);
            //try
            //{
                dataGridView1.DataSource = FindFileNumber();
               
                // TODO: This line of code loads data into the 'financialSysDataSet.TBL_Document' table. You can move, or remove it, as needed.
                this.tBL_DocumentTableAdapter.Fill(this.financialSysDataSet.TBL_Document);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Beneficiary' table. You can move, or remove it, as needed.
                ////this.tbl_BeneficiaryTableAdapter.Fill(this.financialSysDataSet.Tbl_Beneficiary);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_OrderHandler' table. You can move, or remove it, as needed.
                //this.tbl_OrderHandlerTableAdapter.Fill(this.financialSysDataSet.Tbl_OrderHandler);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ExchangeCenter' table. You can move, or remove it, as needed.
                this.tbl_ExchangeCenterTableAdapter.Fill(this.financialSysDataSet.Tbl_ExchangeCenter);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Order' table. You can move, or remove it, as needed.
                this.tbl_OrderTableAdapter.Fill(this.financialSysDataSet.Tbl_Order);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_DocumentCategory' table. You can move, or remove it, as needed.
                this.tbl_DocumentCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentCategory);
                popupContainerEdit2.SelectedIndex = -1;
                Descp.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                popupContainerEdit6.SelectedIndex = -1;
                popupContainerEdit5.SelectedIndex = -1;
                popupContainerEdit4.SelectedIndex = -1;
                popupContainerEdit1.SelectedIndex = -1;
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
                textEdit1.Text = GenerateID().ToString();
                DT.Columns.Add("م ");
                DT.Columns.Add("AccountingRestriction_ID");
                DT.Columns.Add("Accounting_Guid_ID");
                DT.Columns.Add("RestrictionItemsCategory_ID");
                DT.Columns.Add("رقم الحساب");
                DT.Columns.Add("اسم الحساب");
                DT.Columns.Add("مدين");
                DT.Columns.Add("دائن");
                DT.Columns.Add("ID");
                LoadSerial();
            //}
            //catch { }

            }
        
        public DataTable FindFileNumber()
        {
           
                dt.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.CommandType = CommandType.Text;
                com1.CommandType = CommandType.Text;
                com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID  where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");

            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_Activities.Name as [النشاط] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_Activities on Tbl_AccountingRestrictionItems.Activities_ID = Tbl_Activities.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");


            //com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية],Tbl_RestrictionItemsCategory.Name as [التصنيف] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID inner join Tbl_RestrictionItemsCategory on Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID = Tbl_RestrictionItemsCategory.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D Order by Row_No ,Tbl_AccountingRestrictions_Kind.ID  ASc ");

            com.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;

                com.Parameters.Add("@D2", SqlDbType.Int).Value = x;
                com.Parameters.Add("@D3", SqlDbType.Int).Value = y;

                con.Open();
                com.ExecuteScalar();

                da.SelectCommand = com;

                da.SelectCommand = com;
                com.ExecuteScalar();

                da.Fill(dt);





                com1.Connection = con;
                com1.CommandText = ("select Restriction_Date  from Tbl_AccountingRestriction  where Tbl_AccountingRestriction.Restriction_NO =  @D ");

                //com1.CommandText = ("select Restriction_Date ,Document_ID,  Tbl_Descrption.Name from Tbl_AccountingRestriction inner join TBL_Document on  Tbl_AccountingRestriction.Document_ID = TBL_Document.ID inner join Tbl_Descrption on TBL_Document.DescrptionID = Tbl_Descrption.ID  where Tbl_AccountingRestriction.Restriction_NO =  @D ");

                com1.Parameters.Add("@D", SqlDbType.VarChar).Value = Restriction_NO.Text;

                //con.Open();
                SqlDataReader red;
                red = com1.ExecuteReader();
                while (red.Read())
                {

                    dateTimePicker1.Text = red.GetValue(0).ToString();
                    //DocNO.Text = red.GetValue(1).ToString();
                    //Descp.Text = red.GetValue(2).ToString();

                }
                red.Close();
                con.Close();
                return dt;
            
        }
        public void saveToDB()
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
                com1.CommandText = "Insert Into Tbl_AccountingRestriction (Restriction_NO,Restriction_Date,AcountingRestrictionCorrRelation_ID) Values(@Restriction_NO,@Restriction_Date,@AcountingRestrictionCorrRelation_ID)";
                com1.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
                com1.Parameters.Add("@Restriction_Date", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                com1.Parameters.Add("@AcountingRestrictionCorrRelation_ID", SqlDbType.Int).Value = comboBox1.SelectedValue;
                con.Open();

                com1.ExecuteNonQuery();
                con.Close();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {




                    com.Parameters.Clear();
                    com.CommandText = ("Insert Into Tbl_AccountingRestrictionItems(Row_No,AccountingRestriction_ID,Accounting_Guid_ID,Debit_Value,Credit_Value,RestrictionItemsCategory_ID) values(@Row_No,@AccountingRestriction_ID,@Accounting_Guid_ID,@Debit_Value,@Credit_Value,@RestrictionItemsCategory_ID)");
                    com.Parameters.Add("@Row_No", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    com.Parameters.Add("@AccountingRestriction_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                    com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);

                    con.Open();

                    com.ExecuteNonQuery();
                    con.Close();
                }
                DT.Clear();
                //dataGridView2.DataSource = FindFileNumber();
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[6].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
                tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[7].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum().ToString();
                textBox1.Text = dataGridView1.Rows.Count.ToString();
                double xx, yy, zz;
                xx = Convert.ToDouble(tD.Text);
                yy = Convert.ToDouble(tC.Text);
                zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                df.Text = Convert.ToString(zz);
                textEdit1.Text = GenerateID().ToString();
                Restriction_NO.Text = "0";
                Restriction_NO.Focus();
                Restriction_NO.Select();
            }
            if (Convert.ToDecimal(df.Text) != 0)
            {
                MessageBox.Show("(القيد غير متزن)لايمكن حفظ المستند", "المنظموة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private int GenerateID()
        {
            int x = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Select Top 1 ID from Tbl_AccountingRestriction ORDER BY ID DESC";
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while (red.Read())
            {
                x = Convert.ToInt32(red.GetValue(0));
            }

            red.Close();
            con.Close();

            x = x + 1;
            return x;
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void Restriction_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
               
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                Descp.Focus();
                dataGridView1.DataSource = FindFileNumber();
                LoadSerial();
               
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
                if (dataGridView1.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.AllCells)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

            }
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
                    dateTimePicker1.Focus();
                    //popupContainerEdit2.SelectedIndex = -1;
                    //Descp.Text = "";
                    this.tBL_DocumentTableAdapter.FillByDocNO(this.financialSysDataSet.TBL_Document, DocNO.Text);
                    this.tbl_DocumentCategoryTableAdapter.FillByDoc(this.financialSysDataSet.Tbl_DocumentCategory, int.Parse(textBox2.Text));
                    this.tbl_ExchangeCenterTableAdapter.FillByDoc(this.financialSysDataSet.Tbl_ExchangeCenter, int.Parse(textBox3.Text));
                    Restriction_NO.Text = textBox4.Text;
                    if(Restriction_NO.Text != null)
                    {
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        dataGridView1.Refresh();
                        Descp.Focus();
                        dataGridView1.DataSource = FindFileNumber();
                        LoadSerial();
                        
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
                        if (dataGridView1.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.AllCells)
                        {
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                   
                    DOCPANEL.Visible = true;
                    groupPanel2.Enabled = false ;
                    this.tBL_DocumentBindingSource.AddNew();
                    popupContainerEdit2.SelectedIndex = -1;
                    Descp.SelectedIndex = -1;
                    textBoxX1.Focus();
                }
            }
            catch { }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Restriction_NO.Focus();
            }
        }

        private void Descp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit7.Focus();
            }
        }

        private void popupContainerEdit7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit1.Focus();
            }
        }

        private void popupContainerEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit2.Focus();
            }
        }

        private void popupContainerEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textEdit2.Focus();
            }
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridControl1.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                textEdit5.Focus();
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            this.tbl_Accounting_GuidTableAdapter.FillByACCNU(this.financialSysDataSet.Tbl_Accounting_Guid, textEdit2.Text);
        }

        private void textEdit2_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                //popupContainerControl1.OwnerEdit.ClosePopup();

                financialSysDataSet.EnforceConstraints = false;

                popupContainerControl1.Show();
                this.tbl_Accounting_GuidTableAdapter.FillByACCNU(this.financialSysDataSet.Tbl_Accounting_Guid, textEdit2.Text);
            }
            catch { }
        }

        private void textEdit2_Leave(object sender, EventArgs e)
        {
            
           
        }

        private void textEdit5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textEdit6.Focus();
            }
        }

        private void textEdit6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridControl2.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void popupContainerEdit6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {



                    DataRow r = DT.NewRow();

                    //r[0] = dataGridView1.Rows[0].Cells[0].Value.ToString();

                    r[1] = textEdit1.Text;
                    r[2] = dataGridView4.Rows[0].Cells[0].Value.ToString();
                    if (dataGridView3.Rows.Count > 0 && popupContainerEdit3.Text != null)
                    {
                        r[3] = dataGridView3.Rows[0].Cells[0].Value.ToString();
                    }
                    if (dataGridView3.Rows.Count == 0 && popupContainerEdit3.Text == null)
                    {
                        r[3] = "";
                    }
                    r[4] = textEdit2.Text;
                    r[5] = textEdit3.Text;
                    r[6] = textEdit5.Text;
                    r[7] = textEdit6.Text;

                    DT.Rows.Add(r);
                    LoadSerial();
                    dataGridView1.DataSource = DT;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;

                    tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[6].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
                    tC.Text = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[7].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum().ToString();
                    textBox1.Text = dataGridView1.Rows.Count.ToString();
                    double xx, yy, zz;
                    xx = Convert.ToDouble(tD.Text);
                    yy = Convert.ToDouble(tC.Text);
                    zz = Convert.ToDouble(tD.Text) - Convert.ToDouble(tC.Text);
                    df.Text = Convert.ToString(zz);
                    textEdit2.Text = "";
                    textEdit3.Text = "";
                    textEdit5.Text = "0";
                    textEdit6.Text = "0";
                    popupContainerEdit2.Text = "";
                    textEdit2.Focus();
                    popupContainerControl2.Hide();
                    popupContainerControl1.Hide();
                    textEdit2.Focus();
                }
            }
            catch { }
        }

        private void popupContainerEdit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridControl2.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit4.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit3.Focus();
            }
        }

        private void popupContainerEdit3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //popupContainerControl1.OwnerEdit.ClosePopup();


                popupContainerControl2.Show();
                //this.tbl_RestrictionItemsCategoryTableAdapter.FillByCateg(this.financialSysDataSet.Tbl_RestrictionItemsCategory, popupContainerEdit2.Text);
            }
            catch { }
        }

        private void popupContainerEdit3_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //this.tbl_RestrictionItemsCategoryTableAdapter.FillByCateg(this.financialSysDataSet.Tbl_RestrictionItemsCategory, popupContainerEdit2.Text);
        }

        private void popupContainerEdit3_Leave(object sender, EventArgs e)
        {
           
        }

        private void textEdit5_Enter(object sender, EventArgs e)
        {
            popupContainerControl1.Hide();
        }

        private void popupContainerEdit4_Enter(object sender, EventArgs e)
        {
          
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textEdit2.Text = gridView1.GetFocusedRowCellValue("Account_NO").ToString();
                textEdit3.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                popupContainerControl1.Hide();
                textEdit5.Focus();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Account_NO").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
            popupContainerControl1.Hide();
        }

        private void gridControl1_Leave(object sender, EventArgs e)
        {
            popupContainerControl1.Hide();
        }

        private void gridControl2_Leave(object sender, EventArgs e)
        {
            popupContainerControl2.Hide();
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            popupContainerEdit3.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
            popupContainerControl2.Hide();
        }

        private void gridControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit3.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
                popupContainerControl2.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelX28.Left -= 1;
            if (labelX28.Left == (0 - labelX28.Width))
            {
                labelX28.Left = labelX28.Width;
            }

            //labelX5.Left -= 1;
            //if (labelX5.Left == (0 - labelX5.Width))
            //{
            //    labelX5.Left = labelX5.Width;
            //}
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveToDB();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navButton8_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            DocNO.Text = textBoxX1.Text;
            DOCPANEL.Visible = false;
            groupPanel2.Enabled = true;
        }

        private void navButton10_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Validate();
            this.tBL_DocumentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.financialSysDataSet);
            MessageBox.Show("تم حفظ المستند بنجاح");
        }

        private void comboBox7_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            this.tbl_DocumentCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentCategory);
        }

        private void fillByDOEXToolStripButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.tBL_DocumentTableAdapter.FillByDOEX(this.financialSysDataSet.TBL_Document, paToolStripTextBox.Text);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.tBL_DocumentTableAdapter.FillByDocNO(this.financialSysDataSet.TBL_Document, textBoxX1.Text);
                }
            }
            catch { }
        }
    }
}