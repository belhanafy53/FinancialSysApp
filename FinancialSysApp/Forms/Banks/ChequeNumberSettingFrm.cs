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
namespace FinancialSysApp.Forms.Banks
{
    public partial class ChequeNumberSettingFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankDepositeId = 0;
        int? Vint_AccountBank = 0;
        int? Vint_BankAccId = 0;
        //int? Vint_ChequeReceivedKindID = null;
        int? Vint_BranchID = 0;
        int? Vint_RepresentiveID = null;
        int? Vint_BankDrawnOnID = 0;
        int? Vint_CustID = null;
        string Vstr_CollectionNo = null;
        string Vstr_ChequeNO;
        //string Vstr_ReceiptNO;
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
        public ChequeNumberSettingFrm()
        {
            InitializeComponent();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var FirstNum = txtChequeNo.Text;
                var LastNum = textBox2.Text;
                //var FirstNum = "0000500";
                //var LastNum = "0000600";

                int firstNumber = int.Parse(FirstNum)-1;
                int lastNumber = int.Parse(LastNum);

                int difference = lastNumber - firstNumber;

                // إضافة الفرق مع الأصفار الزائدة إلى DataGridView
                for (int i = 0; i < difference; i++)
                {
                    string formattedNumber = (firstNumber + i + 1).ToString(); // يتم إضافة 1 لأن الفرق بين 600 و 500 = 100
                   // string formattedNumber = (firstNumber + i + 1).ToString("D14"); // يتم إضافة 1 لأن الفرق بين 600 و 500 = 100
                    dataGridView1.Rows.Add(textBox1.Text, formattedNumber, cmbBnkDeposit.Text ,true, cmbBnkDeposit.SelectedValue.ToString(),comboBox1.Text , comboBox1.SelectedValue.ToString());
                }

                // عرض الفرق الفعلي في TextBox
                textBox11.Text =Convert.ToInt32( dataGridView1.Rows.Count -1).ToString();
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
                    com.CommandText = ("Insert Into TBL_cheque_book(Bank_ID,cheque_Num,BookNum,BankAccountID) values(@Bank_ID,@cheque_Num,@BookNum,@BankAccountID)");
                    com.Parameters.Add("@Bank_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@cheque_Num", SqlDbType.NVarChar ).Value = row.Cells[1].Value.ToString();
                    com.Parameters.Add("@BookNum", SqlDbType.NVarChar ).Value = row.Cells[0].Value;
                    com.Parameters.Add("@BankAccountID", SqlDbType.NVarChar).Value = row.Cells[6].Value;


                    con.Open();

                    com.ExecuteNonQuery();
                    con.Close();
                }
            }

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                dataGridView1.Rows[x].Cells[3].Value = false;
            }





        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            saveToDB();
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void ChequeNumberSettingFrm_Load(object sender, EventArgs e)
        {
            try
            {
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



            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.Text = "اختر الحساب";
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
    }
}