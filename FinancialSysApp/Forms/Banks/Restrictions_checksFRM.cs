using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataProcessing;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar.Controls;
using FinancialSysApp.Classes;
using WIA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using FinancialSysApp.Forms.DocumentsForms;
using DevExpress.PivotGrid.PivotTable;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.CodeParser;
using System.Runtime.InteropServices;
using System.IO;
using DevExpress.Office.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace FinancialSysApp. Forms. Banks
    {
    public partial class Restrictions_checksFRM : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankDepositeId = 0;
        int? Vint_AccountBank = 0;
        int? Vint_BankAccId = 0;
        int? Vint_ChequeReceivedKindID = null;
        int? Vint_BranchID = 0;
        int? Vint_RepresentiveID = null;
        int? Vint_BankDrawnOnID = 0;
        int? Vint_CustID = null;
        string Vstr_CollectionNo = null;
        string Vstr_ChequeNO;
        string Vstr_ReceiptNO;
        string Vstr_TradeCollectionNO;
        long? Vlng_LastRowTreasuryCollection = 0;
        DateTime? vdate_CollectionDate = null;
        long VLng_IDMasterRow = 0;
        decimal Vdc_AmountCheque = 0;
        DateTime? Vdate_ChequeDueDate = null;
        int? Vint_CheckRowID = null;
        int? Vint_DgCount = 0;
        Boolean? Vbl_RestrictionDataID = false;
        int? Vint_TrCollectionID = 0;
        long? vlng_bankCheqID = 0;
        string Image_Path = "";
        public Restrictions_checksFRM()
        {
            InitializeComponent();
            dataGridView3.CellValueChanged += dataGridView3_CellValueChanged;
        }



        private void cmbBnkDeposit_Leave(object sender, EventArgs e)
        {
            if (cmbBnkDeposit.SelectedValue != null)
            {
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                //*************ارقام الحسابات



                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                comboBox1.DataSource = listAccBank;
                comboBox1.DisplayMember = "AccountBankNo";
                comboBox1.ValueMember = "ID";
                int Vin_countItem = comboBox1.Items.Count;
                if (comboBox1.Items.Count > 1)
                {
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "اختر رقم الحساب";
                    comboBox1.Select();
                    this.ActiveControl = comboBox1;
                    comboBox1.Focus();
                }
                else
                {

                }


                //****************
            }
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    //*************ارقام الحسابات



                    var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                    comboBox1.DataSource = listAccBank;
                    comboBox1.DisplayMember = "AccountBankNo";
                    comboBox1.ValueMember = "ID";
                    int Vin_countItem = comboBox1.Items.Count;
                    if (comboBox1.Items.Count > 1)
                    {
                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "اختر رقم الحساب";
                        comboBox1.Select();
                        this.ActiveControl = comboBox1;
                        comboBox1.Focus();
                    }
                    else
                    {

                    }


                    //****************


                    //txtRepresentive.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            textBox6.Text = NumericToLiteral.Convert(Convert.ToDecimal(textBox2.Text), chkFemale.Checked, txtSingle.Text, txtPlural.Text).ToString();
            if (textBox6.Text.Contains("جنيه مصرى"))
            {
                textBox6.Text += "  فقط لاغير";
            }
            if (!textBox6.Text.Contains("جنيه مصرى"))
            {
                textBox6.Text += "  جنيه مصرى  فقط لاغير";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                textBox6.Text = NumericToLiteral.Convert(Convert.ToDecimal(textBox2.Text), chkFemale.Checked, txtSingle.Text, txtPlural.Text).ToString();
                if (textBox6.Text.Contains("جنيه مصرى"))
                {
                    textBox6.Text += "  فقط لاغير";
                }
                if (!textBox6.Text.Contains("جنيه مصرى"))
                {
                    textBox6.Text += "  جنيه مصرى  فقط لاغير";
                }
                decimal sum = 0;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    bool isFirstCellTrue = Convert.ToBoolean(row.Cells[0].Value);

                    if (isFirstCellTrue)
                    {
                        sum += Convert.ToDecimal(row.Cells[3].Value);
                    }
                }

                // تحديث textBox20 بالقيمة المحسوبة
                textBox20.Text = Math.Round(sum, 3).ToString();

                double x, y, z;
                x = Convert.ToDouble(textBox2.Text);
                y = Convert.ToDouble(textBox20.Text);
                z = y - x;
                textBox8.Text = Math.Round(z, 3).ToString();
                textBox20.Refresh();
            }

            catch { }
        }
        private void GETBeneficiary()
        {
            dataGridViewX1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = "Select Name,ID  FROM Tbl_Beneficiary  WHERE Parent_ID   = @ID ";
            //com.Parameters.Add("@P", SqlDbType.Int).Value = Convert.ToInt32(Code.Text);
            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox14.Text);
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridViewX1.Rows.Add(red.GetValue(0), red.GetValue(1), 0, 0, 0, 0, false, 0);
            }
            red.Close();
            con.Close();
        }
        private void Restrictions_checksFRM_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                var deviceManager = new DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }

                }


            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // TODO: This line of code loads data into the 'bankCheques1.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBanksWithAccount(this.bankCheques1.Dtb_Banks);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter1.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
            // TODO: This line of code loads data into the 'dataSet1.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            //this.tbl_FiscalyearTableAdapter.Fill(this.dataSet1.Tbl_Fiscalyear);
            GETBeneficiary();


            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.Text = "اختر الحساب";


            dataGridView3.CellValueChanged += dataGridView3_CellValueChanged;

            decimal sum = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                bool isFirstCellTrue = Convert.ToBoolean(row.Cells[0].Value);

                if (isFirstCellTrue)
                {
                    sum += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            // تحديث textBox20 بالقيمة المحسوبة
            textBox20.Text = Math.Round(sum, 3).ToString();
            textBox1.Text = Math.Round(sum, 3).ToString();
            textBox8.Text = Math.Round(sum, 3).ToString();
            //ShowNotification("اخطاء", "توجد اخطاء بشيكات يوم.");
            //PopupNotifier popup = new PopupNotifier();
            //popup.Image = Properties.Resources.info;
            //popup.TitleText = "انتبه";
            //popup.ContentText = "توجد شيكات تم مراجعتها وتحتاج الى تعديلات !";
            //popup.Popup();//Show


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

                //bool isSelected = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["Column11"].Value);



                //if (isSelected)
                //{
                //    MessageBox.Show("الرجاء قم بحفظ الشيك أولا قبل الطباعة");
                //}
                //else
                //{
                    Forms.Banks.Reports.PrintCheque p = new Reports.PrintCheque();
                    p.dTPDueDate.Value = dTPDueDate.Value;
                    p.textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); ;
                    p.textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    p.textBox6.Text = textBox6.Text;
                    p.textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    p.txtChequeNo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    p.ShowDialog();
                //}
            }
            catch { }
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDecimal(textBox2.Text) >= Convert.ToDecimal(textBox20.Text) || Convert.ToDecimal(textBox8.Text) == 0)
                {
                    MessageBox.Show("قيمة الشيكات غير مطابقة مع  قيمة المستند");
                }
                else
                {
                    if (textBox5.Text == "")
                    {
                        MessageBox.Show("اختر المستفيد");
                    }
                    else
                    {
                        if (cmbBnkDeposit.Text.Contains("اختر"))
                        {
                            MessageBox.Show("اختر البنك");
                        }
                        else if (comboBox1.Text.Contains("اختر"))
                        {
                            MessageBox.Show("اختر رقم الحساب");
                        }

                        else if (textBox5.Text == string.Empty)
                        {
                            MessageBox.Show("لا يوجد مستفيد");
                        }
                        else if (!comboBox1.Text.Contains("اختر") && !cmbBnkDeposit.Text.Contains("اختر") && textBox5.Text != string.Empty)
                        {
                            dataGridView1.AllowUserToAddRows = true;
                            dataGridView1.Rows.Add(
                                cmbBnkDeposit.Text,
                                comboBox1.Text,
                                txtChequeNo.Text,
                                dTPDueDate.Text,
                                Convert.ToDecimal(textBox8.Text),
                                textBox5.Text,
                                Convert.ToInt32(textBox17.Text),
                                Convert.ToInt32(comboBox1.SelectedValue),
                                Convert.ToInt32(cmbBnkDeposit.SelectedValue),
                                Convert.ToInt32(textBox16.Text),
                                Convert.ToInt32(textBox15.Text),
                                Convert.ToInt32(textBox14.Text),
                                true
                            );
                            dataGridView1.AllowUserToAddRows = false;

                            decimal sum = 0;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells[0].FormattedValue.ToString() != string.Empty)
                                {
                                    sum += Convert.ToDecimal(row.Cells[4].FormattedValue);
                                }
                            }
                            textBox2.Text = sum.ToString();
                            textBox11.Text = dataGridView1.Rows.Count.ToString();
                        }


                        double x, y, z;
                        x = Convert.ToDouble(textBox2.Text);
                        y = Convert.ToDouble(textBox20.Text);
                        z = y - x;
                        textBox8.Text = Math.Round(z, 3).ToString();
                        textBox20.Refresh();
                        textBox8.Focus();

                        textBox8.SelectAll();
                        UsedChequ();
                        textBox5.Text = "";
                        txtChequeNo.Text ="0";
                        cmbBnkDeposit.SelectedIndex = -1;
                        cmbBnkDeposit.Text = "";
                        cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

                        comboBox1.SelectedIndex = -1;
                        comboBox1.Text = "";
                        comboBox1.Text = "اختر الحساب";
                    }
                }
            }
        }
        public void UpdateRestictionsToDB()
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

                bool isSelected = Convert.ToBoolean(row.Cells["Column11"].Value);
                if (isSelected)
                {
                    selectedRowCount++;

                    com.Parameters.Clear();
                    //row.Cells[14].Value = textBox5.Text;
                    com.CommandText = ("Insert Into Tbl_AccountingRestrictionItems(AccountingRestriction_ID,Accounting_Guid_ID,Credit_Value,Debit_Value,AccountingRestrictionKind_ID,OutCheque) values(@AccountingRestriction_ID,@Accounting_Guid_ID,@Credit_Value,@Debit_Value,@AccountingRestrictionKind_ID,1)");
                    //com.Parameters.Add("@Row_No", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[0].Value);
                    com.Parameters.Add("@AccountingRestriction_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    com.Parameters.Add("@Accounting_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);

                    com.Parameters.Add("@Credit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[4].Value);
                    com.Parameters.Add("@Debit_Value", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
                    com.Parameters.Add("@AccountingRestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(2);

                    con.Open();

                    com.ExecuteNonQuery();
                    con.Close();

                }
            }
            int progressPercentage = (selectedRowCount * 100) / dataGridView1.Rows.Count;
            using (Graphics gr = progressBar1.CreateGraphics())
            {
                gr.DrawString(progressPercentage.ToString() + "%", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
            }
            progressBar1.Visible = false;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                dataGridView1.Rows[x].Cells[12].Value = false;
            }


        }
        public void saveToDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
               

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandType = CommandType.Text;

                    dataGridView1.AllowUserToAddRows = false;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        bool isSelected = Convert.ToBoolean(row.Cells["Column11"].Value);



                        if (isSelected)
                        {
                            con.Open();
                            com.Parameters.Clear();

                            com.CommandText = "INSERT INTO TBL_Restrictions_checks (AccountBankID, BankID, cheque_bookID, Restriction_ID, Due_date, check_value, beneficiary_ID, Account_Guid_ID) " +
                                              "VALUES (@AccountBankID, @BankID, @cheque_bookID, @Restriction_ID, @Due_date, @check_value, @beneficiary_ID, @Account_Guid_ID)";

                            com.Parameters.Add("@AccountBankID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                            com.Parameters.Add("@BankID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                            com.Parameters.Add("@cheque_bookID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                            com.Parameters.Add("@Restriction_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                            
                               
                                com.Parameters.Add("@Due_date", SqlDbType.NVarChar ).Value = row.Cells[3].Value.ToString();
                               

                                com.Parameters.Add("@check_value", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[4].Value);
                                com.Parameters.Add("@beneficiary_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[11].Value);
                                com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);

                                com.ExecuteNonQuery();
                                con.Close();
                           
                        }
                    }
                }
            }
        }

           
       

        public void RemoveOldRestriction()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;

            int selectedRowCount = 0;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);



                if (isSelected)
                {

                    selectedRowCount++;
                    com.Parameters.Clear();
                    //row.Cells[14].Value = textBox5.Text;
                    com.CommandText = ("Delete From Tbl_AccountingRestrictionItems where id=@id");
                    com.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[1].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }







        }
        public void UsedChequ()
        {
            if (txtChequeNo.Text != "" || txtChequeNo.Text != "0")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;

                int selectedRowCount = 0;
                dataGridView1.AllowUserToAddRows = false;
                //foreach (DataGridViewRow row in dataGridView3.Rows)
                //{


                selectedRowCount++;
                com.Parameters.Clear();
                //row.Cells[14].Value = textBox5.Text;
                com.CommandText = ("Update TBL_cheque_book set cheque_Locked = 1 where cheque_Num=@cheque_Num and Bank_ID=@Bank_ID");
                com.Parameters.Add("@cheque_Num", SqlDbType.Int).Value = Convert.ToInt32(txtChequeNo.Text);
                com.Parameters.Add("@Bank_ID", SqlDbType.Int).Value = Convert.ToInt32(cmbBnkDeposit.SelectedValue.ToString());
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            //}







        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (Convert.ToDecimal(textBox2.Text) != Convert.ToDecimal(textBox20.Text))
                {
                    MessageBox.Show("قيمة الشيكات غير مطابقة مع  قيمة المستند");
                }
                else
                {
                    RemoveOldRestriction();
                    //UsedChequ();
                    saveToDB();
                    UpdateRestictionsToDB();
                    MessageBox.Show("تم حفظ الشيكات بنجاح");
                }
            }
            else
            {
                MessageBox.Show("ادخل الشيكات أولا");
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                decimal sum = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].FormattedValue.ToString() != string.Empty)
                    {
                        sum += Convert.ToDecimal(row.Cells[4].FormattedValue);
                    }
                }
                textBox2.Text = sum.ToString();
                textBox11.Text = dataGridView1.Rows.Count.ToString();
            }
            catch { }
        }
        public void GetCheqNumber()
        {
            try
            {
                txtChequeNo.Text = "";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;





                //com.Parameters.Clear();
                //row.Cells[14].Value = textBox5.Text;
                com.CommandText = (" SELECT MIN(CONVERT(int, cheque_Num))  FROM TBL_cheque_book where cheque_Locked is  null  And Bank_ID=@Bank_ID and BankAccountID=@ID");
                com.Parameters.Add("@Bank_ID", SqlDbType.Int).Value = Convert.ToInt32(cmbBnkDeposit.SelectedValue.ToString());
                com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                con.Open();
                SqlDataReader red;
                red = com.ExecuteReader();
                while (red.Read())
                {
                    txtChequeNo.Text = red.GetValue(0).ToString();
                }
                red.Close();
                con.Close();

            }
            catch
            {
                MessageBox.Show("برجاء اختيار رقم الحساب");
                comboBox1.Focus();
            }
           







        }
       
        public void GetAccountGuid()
        {
            textBox16.Text = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;





            //com.Parameters.Clear();
            //row.Cells[14].Value = textBox5.Text;
            com.CommandText = (" SELECT Accounting_GuidID FROM Tbl_AccountsBank where AccountBankNo=@AccountBankNo");
            com.Parameters.Add("@AccountBankNo", SqlDbType.NVarChar).Value =comboBox1.Text.ToString();
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox16.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();










        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCheqNumber();
                GetAccountGuid();
                dTPDueDate.Focus();
            }
        }

        private void dTPDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                textBox8.Focus();
                textBox8.SelectAll();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radGroupBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        private void textBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        private void textBox19_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox14.Text = textBox18.Text;
            textBox5.Text = textBox19.Text;
        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox14.Text = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                cmbBnkDeposit.Focus();
                cmbBnkDeposit.SelectAll();
            }
            catch { }
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            
           

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            //{
            dataGridView3.EndEdit();
            dataGridView3.RefreshEdit();
            dataGridView3.Refresh();
                decimal sum = 0;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    bool isFirstCellTrue = Convert.ToBoolean(row.Cells[0].Value);

                    if (isFirstCellTrue)
                    {
                        sum += Convert.ToDecimal(row.Cells[3].Value);
                    }
                }
         
            // تحديث textBox20 بالقيمة المحسوبة
            textBox20.Text = Math.Round(sum, 3).ToString();
            double x, y, z;
            x = Convert.ToDouble(textBox2.Text);
            y = Convert.ToDouble(textBox20.Text);
            z = y - x;
            textBox8.Text = Math.Round(z, 3).ToString();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox2.Text) > Convert.ToDouble(textBox20.Text))
            {
                decimal sum = 0;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    bool isFirstCellTrue = Convert.ToBoolean(row.Cells[0].Value);

                    if (isFirstCellTrue)
                    {
                        sum += Convert.ToDecimal(row.Cells[3].Value);
                    }
                }

                // تحديث textBox20 بالقيمة المحسوبة
                textBox20.Text = Math.Round(sum, 3).ToString();

                double x, y, z;
                x = Convert.ToDouble(textBox2.Text);
                y = Convert.ToDouble(textBox20.Text);
                z = y - x;
                textBox8.Text = Math.Round(z, 3).ToString();
                textBox20.Refresh();
            }
                //}
            }
            catch
            {
                textBox2.Text = "0";
            }
        }        

        private void dataGridView3_MouseLeave(object sender, EventArgs e)
        {
            dataGridView3.EndEdit();
            dataGridView3.RefreshEdit();
            dataGridView3.Refresh();
            decimal sum = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                bool isFirstCellTrue = Convert.ToBoolean(row.Cells[0].Value);

                if (isFirstCellTrue)
                {
                    sum += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            // تحديث textBox20 بالقيمة المحسوبة
            textBox20.Text = Math.Round(sum, 3).ToString();

            try
            {
                double x, y, z;
                x = Convert.ToDouble(textBox2.Text);
                y = Convert.ToDouble(textBox20.Text);
                z = y - x;
                textBox8.Text = Math.Round(z, 3).ToString();
                textBox20.Refresh();
            }
            catch
            {
                textBox2.Text = "0";
            }
        }

        private void dataGridView3_MouseUp(object sender, MouseEventArgs e)
        {
            dataGridView3.EndEdit();
            dataGridView3.RefreshEdit();
            dataGridView3.Refresh();
            decimal sum = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                bool isFirstCellTrue = Convert.ToBoolean(row.Cells[0].Value);

                if (isFirstCellTrue)
                {
                    sum += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            // تحديث textBox20 بالقيمة المحسوبة
            textBox20.Text = Math.Round(sum, 3).ToString();
            try
            {
                double x, y, z;
                x = Convert.ToDouble(textBox2.Text);
                y = Convert.ToDouble(textBox20.Text);
                z = y - x;
                textBox8.Text = Math.Round(z, 3).ToString();
                textBox20.Refresh();
            }
            catch
            {
                textBox2.Text = "0";
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

                textBox6.Text = NumericToLiteral.Convert(Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value.ToString()), chkFemale.Checked, txtSingle.Text, txtPlural.Text).ToString();
                if (textBox6.Text.Contains("جنيه مصرى"))
                {
                    textBox6.Text += "  فقط لاغير";
                }
                if (!textBox6.Text.Contains("جنيه مصرى"))
                {
                    textBox6.Text += "  جنيه مصرى  فقط لاغير";
                }
            }

            catch { }
        }

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                textBox8.Focus();
                textBox8.SelectAll();
            }
        }
    }
    }
