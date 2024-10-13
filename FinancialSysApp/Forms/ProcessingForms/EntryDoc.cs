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
    public partial class EntryDoc : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable DT = new DataTable();
        DataTable DT1 = new DataTable();
        DataTable DT2 = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
       
            DataTable dt = new DataTable();
        SqlCommandBuilder cbulder = new SqlCommandBuilder();
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


            dataGridView1.DataSource = DT;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells  ;
        }
        public DataTable getDay()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand  com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where id in (1,2)");
            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter  da = new SqlDataAdapter(com);
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
        public EntryDoc()
        {
            InitializeComponent();
            

        }

        private void EntryDoc_Load(object sender, EventArgs e)
        {
            //timer1.Start();
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
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //popupContainerControl1.OwnerEdit.ClosePopup();
                //popupContainerControl1.Show();
                //this.tbl_Accounting_GuidTableAdapter.FillByACCNU(this.financialSysDataSet.Tbl_Accounting_Guid, textEdit2.Text);
            }
            catch { }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            textEdit2.Text = gridView1.GetFocusedRowCellValue("Account_NO").ToString();
            textEdit3.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
            popupContainerControl1.Hide();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

           
           
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

        private void textEdit2_Click(object sender, EventArgs e)
        {
            
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down )
            {
                gridControl1.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                textEdit5.Focus();
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                textEdit2.Text = gridView1.GetFocusedRowCellValue("Account_NO").ToString();
                textEdit3.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                popupContainerControl1.Hide();
                textEdit5.Focus();
            }
        }
        private void RowCount()
        {
           
        }
        public DataTable FindFileNumber()
        {
            dt.Clear();
            SqlConnection  con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand  com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.CommandType = CommandType.Text;
           com1.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select Row_No as[م], Tbl_Accounting_Guid.Account_NO as [رقم الحساب],Tbl_Accounting_Guid.Name as [اسم الحساب],Debit_Value AS [مدين],Credit_Value AS [دائن],Tbl_AccountingRestrictions_Kind.Name as[اليومية] from Tbl_AccountingRestrictionItems inner join Tbl_AccountingRestriction on Tbl_AccountingRestrictionItems.AccountingRestriction_ID =Tbl_AccountingRestriction.ID inner join Tbl_Accounting_Guid on Tbl_AccountingRestrictionItems.Accounting_Guid_ID = Tbl_Accounting_Guid.ID inner join Tbl_AccountingRestrictions_Kind on Tbl_AccountingRestriction.AcountingRestrictionCorrRelation_ID = Tbl_AccountingRestrictions_Kind.ID where  Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D2 OR Tbl_AccountingRestriction.Restriction_NO =  @D and Tbl_AccountingRestrictions_Kind.id = @D3 Order by Tbl_AccountingRestrictions_Kind.ID  ASc ");


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
            SqlDataReader  red;
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

        private void Restriction_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                barCodeControl1.Text = Restriction_NO.Text;
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                Descp.Focus();
                dataGridView1.DataSource = FindFileNumber();
                LoadSerial();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void popupContainerEdit2_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                //popupContainerControl1.OwnerEdit.ClosePopup();


                popupContainerControl2.Show();
                //this.tbl_RestrictionItemsCategoryTableAdapter.FillByCateg (this.financialSysDataSet.Tbl_RestrictionItemsCategory, popupContainerEdit2.Text);
            }
            catch { }
        }

        private void popupContainerEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridControl2.Focus();
            }
            if(e.KeyCode == Keys.Enter )
            {
                comboBox1.Focus();
            }
        }

        private void gridControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit2.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
                popupContainerControl2.Hide();
            }
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            popupContainerEdit2.Text = gridView2.GetFocusedRowCellValue("Name").ToString();
            popupContainerControl2.Hide();
        }

        private void DocNO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode  == Keys.Enter )
            {
                dateTimePicker1.Focus();
            }
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
                textEdit2.Focus();
            }
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
            if (e.KeyCode == Keys.Enter)
            {
                popupContainerEdit2.Focus();
            }
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
                    com.Parameters.Add("@Row_No", SqlDbType.Int).Value = Convert.ToInt32( dataGridView1.Rows[i].Cells[0].Value);
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
            int  x =0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "Select Top 1 ID from Tbl_AccountingRestriction ORDER BY ID DESC";
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while(red.Read())
            {
                x =Convert.ToInt32( red.GetValue(0));
            }

            red.Close();
            con.Close();

            x = x+1;
            return x;
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    


                    DataRow r = DT.NewRow();
                   
                        //r[0] = dataGridView1.Rows[0].Cells[0].Value.ToString();
                  
                    r[1] = textEdit1.Text;
                    r[2] = dataGridView4.Rows[0].Cells[0].Value.ToString();
                    if (dataGridView3.Rows.Count > 0  && popupContainerEdit2.Text !=null )
                    {
                        r[3] = dataGridView3.Rows[0].Cells[0].Value.ToString();
                    }
                    if (dataGridView3.Rows.Count == 0 && popupContainerEdit2.Text == null)
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

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            this.tbl_Accounting_GuidTableAdapter.FillByACCNU(this.financialSysDataSet.Tbl_Accounting_Guid, textEdit2.Text);
        }

        private void popupContainerEdit2_EnabledChanged(object sender, EventArgs e)
        {
            //this.tbl_RestrictionItemsCategoryTableAdapter.FillByCateg(this.financialSysDataSet.Tbl_RestrictionItemsCategory, popupContainerEdit2.Text);
        }

        private void textEdit5_Click(object sender, EventArgs e)
        {
            popupContainerControl2.Hide();
            popupContainerControl1.Hide();
        }

        private void textEdit6_Click(object sender, EventArgs e)
        {
            popupContainerControl2.Hide();
            popupContainerControl1.Hide();
        }

        private void textEdit3_Click(object sender, EventArgs e)
        {
            popupContainerControl2.Hide();
            popupContainerControl1.Hide();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            popupContainerControl2.Hide();
            popupContainerControl1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveToDB();
            labelX6.Visible = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string y = textEdit1.Text;
            string x = comboBox1.Text;
            if (dataGridView1.Rows.Count > 0)
            {
               
                
                DialogResult result = new DialogResult();
                result = MessageBox.Show(" لقد قمت بتغيير نوع اليومية هل أنت متأكد من هذا؟", "المنظومة المالية", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();

                        SqlCommand com1 = new SqlCommand();


                        com1.Connection = con;
                        com1.CommandType = CommandType.Text;
                        //try
                        //{

                        com1.CommandText = "Insert Into Tbl_AccountingRestriction (Restriction_NO,Restriction_Date,AcountingRestrictionCorrRelation_ID) Values(@Restriction_NO,@Restriction_Date,@AcountingRestrictionCorrRelation_ID)";
                        com1.Parameters.Add("@Restriction_NO", SqlDbType.Int).Value = Convert.ToInt32(Restriction_NO.Text);
                        com1.Parameters.Add("@Restriction_Date", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                        com1.Parameters.Add("@AcountingRestrictionCorrRelation_ID", SqlDbType.Int).Value = comboBox1.SelectedValue;
                        con.Open();

                        com1.ExecuteNonQuery();
                        con.Close();
                    if (textEdit1.Text == dataGridView1.Rows[1].Cells[1].Value.ToString())
                    {
                        textEdit1.Text = GenerateID().ToString();
                    }
                    if (textEdit1.Text != dataGridView1.Rows[1].Cells[1].Value.ToString())
                    {
                        textEdit1.Text = y.ToString();
                    }
                }

                else
                {
                    MessageBox.Show("تم التراجع عن التعديل ", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.Text = x;

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // rowcolor();
                int x, y, z;
                x = Convert.ToInt32(textBox8.Text);
                y = Convert.ToInt32(textBox1.Text);
                textBox8.Text = dataGridView1.Rows.Count.ToString();
                if (Convert.ToInt32(textBox1.Text) == 0)
                {
                    z = y + 1;
                    textBox8.Text = Convert.ToString(z);
                }
                if (Convert.ToInt32(textBox1.Text) != 0)
                {
                    z = y + 1;
                    textBox8.Text = Convert.ToString(z);
                }
                
                
               
                
            }
            catch { }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int x, y, z;
            x = Convert.ToInt32(textBox8.Text);
            y = Convert.ToInt32(textBox1.Text);
            textBox8.Text = dataGridView1.Rows.Count.ToString();
            if (Convert.ToInt32(textBox1.Text) == 0)
            {
                z = y + 1;
                textBox8.Text = Convert.ToString(z);
            }
            if (Convert.ToInt32(textBox1.Text) != 0)
            {
                z = y + 1;
                textBox8.Text = Convert.ToString(z);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //string strRowNumber = (e.RowIndex + 1).ToString();

           
            ////while (strRowNumber.Length < this.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

          
            ////SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            
            ////if (this.RowHeadersWidth < (int)(size.Width + 20)) this.RowHeadersWidth = (int)(size.Width + 20);

           
            ////Brush b = SystemBrushes.ControlText;

           
            ////e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

           
           

            //this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = strRowNumber;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();


            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //    row.Cells[0].Value = (row.Index + 1).ToString(); 
        }
        //private void textEdit4_KeyDown(object sender, KeyEventArgs e)
        //{

        //}
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            LoadSerial();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
          
            sqlCommandBuilder1.GetUpdateCommand();
          
        }
    }
}
