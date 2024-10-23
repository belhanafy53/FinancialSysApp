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
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System.IO;
using System.Configuration;
using FinancialSysApp.Forms.DocumentsForms;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils.CommonDialogs;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;

using DevExpress.XtraGauges.Core.Model;

using DevExpress.XtraBars;
using System.Data.Entity.Core.Mapping;
using DevExpress.XtraPrinting.Export.Pdf;
using System.Web;

namespace FinancialSysApp.Forms.Banks.TransferDataBanks
{
    public partial class TransferDataBankFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        string Vs_C1 = "";
        string Vs_C2 = "";
        string Vs_C3 = "";
        string Vs_C4 = "";
        string Vs_C5 = "";
        string Vs_C6 = "";
        string Vst_CodeGenerate = "";
        string Vst_Currency = "";
        string Vst_DebitCredit = "";
        int Vint_BankID = 0;
        int Vint_BankAcc = 0;
        int Vint_FiscYear = 0;
        int? Vint_CountMb = 0;
        string VS_DatebankDay = "";
        DateTime Vd_DateMov = Convert.ToDateTime(DateTime.Now.ToString());
        string VS_DatebankDue = "";
        DateTime Vd_DatebankDue = Convert.ToDateTime(DateTime.Now.ToString());
        string Vs_NumberRefrBank = "";
        string Vs_DescriptionNote = "";
        decimal Vdc_TransferAmount = 0;
        decimal Vdc_BalanceAmount = 0;
        long Vlng_LastRowDepositCash = 0;
        DateTime? Vd_Date = null;
        string Vst_FinancialYear = "";
        int? Vint_MoveType = null;
        int? Vint_MoveType1 = null;
        long? Vlng_TradeCode = null;
        public TransferDataBankFrm()
        {
            InitializeComponent();
        }

        private void TransferDataBankFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            //this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_Banks' table. You can move, or remove it, as needed.
            //this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Tbl_Banks);
            // TODO: This line of code loads data into the 'transferDataBankDS.Tbl_BankMovement' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter1.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
            //// TODO: This line of code loads data into the 'transferDataBankDS.Tbl_BankMovements' table. You can move, or remove it, as needed.
            //this.tbl_BankMovementsTableAdapter.Fill(this.transferDataBankDS.Tbl_BankMovements);
            //// TODO: This line of code loads data into the 'transferDataBankDS.Tbl_BankMovements' table. You can move, or remove it, as needed.
            //this.dtb_BanksTableAdapter.FillByBankWithAcc(this.bankCheques.Dtb_Banks);
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "اختر البنك";
            simpleButton1.Enabled = true;


        }
        private void LoadSerial2()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void FilterDiscriptionBankData()
        {
            int i = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                //string VsLenght  = (row.Cells[8].Value.ToString()).Length.ToString();
                if (row.Cells[3].Value != null)
                {
                    string Vstr_strchr = row.Cells[4].Value.ToString();

                    string[] vv = Vstr_strchr.Split(new char[] { '-' });
                    int bb = vv.Count();

                    foreach (var v in vv)
                    {
                        string vresult = v;
                        if (bb >= 1)
                        {
                            if (vv[0] != "")
                            {
                                string ResultAch = vv[0].Trim();
                                int t = ResultAch.IndexOf("ACH");
                                int C = ResultAch.IndexOf("Fund Transfer from");
                                int s = 0;
                                if (t != -1)
                                {
                                    int Vl = ResultAch.Length;
                                    s = (Vl - t);
                                }
                                else
                                { s = ResultAch.Length; }
                                if (t != -1)
                                {
                                    string XresultAch = ResultAch.Substring(0, t);
                                    row.Cells[9].Value = XresultAch;
                                }
                                else if (C != -1)
                                {
                                    string XresultAch = ResultAch.Substring(0, C);
                                    row.Cells[10].Value = XresultAch;
                                }
                                else
                                {

                                    row.Cells[9].Value = ResultAch;
                                }

                                string ResultGP = vv[0];
                                int x = ResultGP.IndexOf("GP");
                                if (x != -1)
                                {
                                    string Xresult = ResultGP.Substring(x);
                                    row.Cells[10].Value = Xresult;
                                }

                            }
                        }
                        if (bb >= 2)
                        {
                            if (vv[1] != "")
                            {
                                row.Cells[11].Value = vv[1];


                            }
                        }
                        if (bb >= 3)
                        {
                            if (vv[2] != "")
                            {
                                row.Cells[12].Value = vv[2];
                            }
                        }
                        if (bb >= 4)
                        {
                            if (vv[3] != "")
                            {
                                row.Cells[13].Value = vv[3];
                            }
                        }
                        if (bb >= 5)
                        {
                            if (vv[4] != "")
                            {
                                row.Cells[14].Value = v;
                            }
                        }
                    }

                }
            }
        }
        public static System.Data.DataTable read(Range excelRange)
        {

            DataRow row;
            System.Data.DataTable dt = new System.Data.DataTable();
            int rowCount = excelRange.Rows.Count; //get row count of excel data

            int colCount = excelRange.Columns.Count; // get column count of excel data
            if (colCount <= 5)
            {
                throw new Exception("!الملف المراد رفعه غير مضبوط");
            }
            //Get the first Column of excel file which is the Column Name


            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    if (excelRange.Cells[i, j].Value2 != null)
                    { dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString()); }
                }
                break;
            }

            //Get Row Data of Excel

            int rowCounter; //This variable is used for row index number
            for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
            {


                row = dt.NewRow(); //assign new row to DataTable
                rowCounter = 0;
                for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
                {
                    //check if cell is empty
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                    {
                        row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                    }
                    else
                    {
                        row[i] = "";
                    }
                    rowCounter++;
                }
                dt.Rows.Add(row); //add row to DataTable
            }

            return dt;
        }
        private void AddColumnDtaGrd1()
        {
            // Create a new columns datadridview1
            DataGridViewTextBoxColumn newColumnC1 = new DataGridViewTextBoxColumn();

            // Set the properties of the new column
            newColumnC1.HeaderText = "C1"; // Header text of the column
            newColumnC1.Name = "C1"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnC1);
            newColumnC1.Visible = false;

            DataGridViewTextBoxColumn newColumnC2 = new DataGridViewTextBoxColumn();
            newColumnC2.Name = "C2"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnC2);
            newColumnC2.Visible = false;

            DataGridViewTextBoxColumn newColumnC3 = new DataGridViewTextBoxColumn();
            newColumnC3.Name = "C3"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnC3);
            newColumnC3.Visible = false;

            DataGridViewTextBoxColumn newColumnC4 = new DataGridViewTextBoxColumn();
            newColumnC4.Name = "C4"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnC4);
            newColumnC4.Visible = false;

            DataGridViewTextBoxColumn newColumnC5 = new DataGridViewTextBoxColumn();
            newColumnC5.Name = "C5"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnC5);
            newColumnC5.Visible = false;

            DataGridViewTextBoxColumn newColumnC6 = new DataGridViewTextBoxColumn();
            newColumnC6.Name = "C6"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnC6);
            newColumnC6.Visible = false;

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم الانتهاء من رفع ومعالجة بيانات ملف الاكسيل");
                comboBox2.Text = "";
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "اختر البنك ";

                comboBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "اختر رقم الحساب ";

                if (dataGridView2.Rows.Count > 0)
                {

                    dataGridView2.DataSource = null;
                    string Vs_C1 = "C1";

                    if (dataGridView2.Columns.Contains(Vs_C1))
                    {
                        dataGridView2.Columns.Remove(Vs_C1);
                    }
                    string Vs_C2 = "C2";

                    if (dataGridView2.Columns.Contains(Vs_C2))
                    {
                        dataGridView2.Columns.Remove(Vs_C2);
                    }

                    string Vs_C3 = "C3";

                    if (dataGridView2.Columns.Contains(Vs_C3))
                    {
                        dataGridView2.Columns.Remove(Vs_C3);
                    }
                    string Vs_C4 = "C4";

                    if (dataGridView2.Columns.Contains(Vs_C4))
                    {
                        dataGridView2.Columns.Remove(Vs_C4);
                    }

                    string Vs_C5 = "C5";

                    if (dataGridView2.Columns.Contains(Vs_C5))
                    {
                        dataGridView2.Columns.Remove(Vs_C5);
                    }
                    string Vs_C6 = "C6";

                    if (dataGridView2.Columns.Contains(Vs_C6))
                    {
                        dataGridView2.Columns.Remove(Vs_C6);
                    }

                }
                string file = ""; //variable for the Excel File Location
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Check if Result == "OK".
                {
                    file = openFileDialog1.FileName; //get the filename with the location of the file
                                                     //try
                                                     //{
                                                     //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file
                    Microsoft.Office.Interop.Excel.Application excelApp =
                        new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                    //dataGridView2. DataSource = read(excelRange);
                    List<object[]> rowsData = new List<object[]>();
                    foreach (Microsoft.Office.Interop.Excel.Range row in excelRange.Rows)
                    {
                        string excelDate1 = row.Cells[1].Value.ToString();
                        string excelDate2 = row.Cells[2].Value.ToString();

                        DateTime date1, date2;
                        if (DateTime.TryParse(excelDate1, out date1) && DateTime.TryParse(excelDate2, out date2))
                        {

                            object[] rowData = new object[excelRange.Columns.Count];
                            for (int i = 0; i < excelRange.Columns.Count; i++)
                            {
                                if (i == 0)
                                {

                                    rowData[i] = date1.ToString("d");
                                }
                                else if (i == 1)
                                {

                                    rowData[i] = date2.ToString("d");
                                }
                                else
                                {

                                    rowData[i] = row.Cells[i + 1].Value;
                                }
                            }
                            rowsData.Add(rowData);
                        }
                        else
                        {

                            Console.WriteLine("تاريخ غير صالح");
                        }
                    }


                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    for (int i = 1; i <= excelRange.Columns.Count; i++)
                    {
                        dataTable.Columns.Add("Column " + i);
                    }

                    foreach (object[] rowData in rowsData)
                    {
                        dataTable.Rows.Add(rowData);
                    }

                    dataGridView2.DataSource = dataTable;

                    //string[] columnNames = { "م", "تاريخ الحركه ", "تاريخ الحق", "الرقم المرجعي", "وصف الحركه", "العملة", "المبلغ", "مدين/دائن", "الرصيد" };
                    string[] columnNames = { " ", "تاريخ الحركه ", "تاريخ الحق", " ", " ", " ", " ", " ", " " };
                    try
                    {
                        // تغيير أسماء الأعمدة في DataGridView
                        for (int i = 0; i < dataGridView2.Columns.Count && i < columnNames.Length; i++)
                        {
                            dataGridView2.Columns[i].HeaderText = columnNames[i];
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("حدث خطأ: " + ex.Message);
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(excelRange);
                    Marshal.ReleaseComObject(excelWorksheet);
                    //quit apps
                    excelWorkbook.Close();
                    Marshal.ReleaseComObject(excelWorkbook);
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    textBox1.Text = dataGridView2.Rows.Count.ToString();
                    comboBox2.Text = "";
                    comboBox2.SelectedIndex = -1;
                    comboBox2.Text = "اختر البنك ";

                    comboBox1.Text = "";
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = "اختر رقم الحساب ";

                    LoadSerial2();
                    splashScreenManager1.CloseWaitForm();
                    simpleButton1.Enabled = false;
                    comboBox2.Focus();
                }
                else
                    if (result == DialogResult.Cancel) { splashScreenManager1.CloseWaitForm(); }
                //progressBar1.Visible = true;
                //progressBar1.Minimum = 0;
                //progressBar1.Maximum = dataGridView2.Rows.Count;

                //progressBar1.Value = 0; // Start with 0 progress
                //splashScreenManager1.ShowWaitForm();
                //splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم الانتهاء من رفع ومعالجة بيانات ملف الاكسيل");
                //comboBox2.Text = "";
                //comboBox2.SelectedIndex = -1;
                //comboBox2.Text = "اختر البنك ";

                //comboBox1.Text = "";
                //comboBox1.SelectedIndex = -1;
                //comboBox1.Text = "اختر رقم الحساب ";

                //if (dataGridView2.Rows.Count > 0)
                //{

                //    dataGridView2.DataSource = null;
                //    string Vs_C1 = "C1";

                //    if (dataGridView2.Columns.Contains(Vs_C1))
                //    {
                //        dataGridView2.Columns.Remove(Vs_C1);
                //    }
                //    string Vs_C2 = "C2";

                //    if (dataGridView2.Columns.Contains(Vs_C2))
                //    {
                //        dataGridView2.Columns.Remove(Vs_C2);
                //    }

                //    string Vs_C3 = "C3";

                //    if (dataGridView2.Columns.Contains(Vs_C3))
                //    {
                //        dataGridView2.Columns.Remove(Vs_C3);
                //    }
                //    string Vs_C4 = "C4";

                //    if (dataGridView2.Columns.Contains(Vs_C4))
                //    {
                //        dataGridView2.Columns.Remove(Vs_C4);
                //    }

                //    string Vs_C5 = "C5";

                //    if (dataGridView2.Columns.Contains(Vs_C5))
                //    {
                //        dataGridView2.Columns.Remove(Vs_C5);
                //    }
                //    string Vs_C6 = "C6";

                //    if (dataGridView2.Columns.Contains(Vs_C6))
                //    {
                //        dataGridView2.Columns.Remove(Vs_C6);
                //    }

                //}
                //string file = ""; //variable for the Excel File Location
                //DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                //if (result == DialogResult.OK) // Check if Result == "OK".
                //{
                //    file = openFileDialog1.FileName; //get the filename with the location of the file
                //                                     //try
                //                                     //{
                //                                     //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file
                //    Microsoft.Office.Interop.Excel.Application excelApp =
                //        new Microsoft.Office.Interop.Excel.Application();
                //    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                //    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                //    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                //    dataGridView2.DataSource = read(excelRange);
                //    for(int i = 0; i< dataGridView2.Rows.Count;i ++)
                //    {
                //        dataGridView2.Rows[i].Cells[2].Value = Convert.ToDateTime(dataGridView2.Rows[i].Cells[2].Value).ToShortDateString();
                //    }
                //    //close and clean excel process
                //    GC.Collect();
                //    GC.WaitForPendingFinalizers();
                //    Marshal.ReleaseComObject(excelRange);
                //    Marshal.ReleaseComObject(excelWorksheet);
                //    //quit apps
                //    excelWorkbook.Close();
                //    Marshal.ReleaseComObject(excelWorkbook);
                //    excelApp.Quit();
                //    Marshal.ReleaseComObject(excelApp);
                //    textBox1.Text = dataGridView2.Rows.Count.ToString();
                //    comboBox2.Text = "";
                //    comboBox2.SelectedIndex = -1;
                //    comboBox2.Text = "اختر البنك ";

                //    comboBox1.Text = "";
                //    comboBox1.SelectedIndex = -1;
                //    comboBox1.Text = "اختر رقم الحساب ";

                //    LoadSerial2();
                //    splashScreenManager1.CloseWaitForm();
                //    simpleButton1.Enabled = false;
                //    comboBox2.Focus();
                //}
                //else
                //    if (result == DialogResult.Cancel  ) { splashScreenManager1.CloseWaitForm(); }

            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message);
            }

        }
        private string MonthConvert(string Vs_Month)
        {
            string Result = "";
            if (Vs_Month == "ينا" || Vs_Month == "01")
            {
                Result = "01";
            }
            else if (Vs_Month == "فبر" || Vs_Month == "02")
            {
                Result = "02";
            }
            else if (Vs_Month == "مار" || Vs_Month == "03")
            {
                Result = "03";
            }
            else if (Vs_Month == "أبر" || Vs_Month == "04")
            {
                Result = "4";
            }
            else if (Vs_Month == "ماي" || Vs_Month == "5")
            {
                Result = "05";
            }
            else if (Vs_Month == "يون" || Vs_Month == "06")
            {
                Result = "06";
            }
            else if (Vs_Month == "يول" || Vs_Month == "7")
            {
                Result = "07";
            }
            else if (Vs_Month == "أغس" || Vs_Month == "08")
            {
                Result = "08";
            }
            else if (Vs_Month == "سبت" || Vs_Month == "09")
            {
                Result = "09";
            }
            else if (Vs_Month == "أكت" || Vs_Month == "10")
            {
                Result = "10";
            }
            else if (Vs_Month == "نوف" || Vs_Month == "11")
            {
                Result = "11";
            }
            else if (Vs_Month == "ديس" || Vs_Month == "12")
            {
                Result = "12";
            }


            return Result;
        }
        private DateTime CollectDate(string VS_DatebankDay, int Vint_bankid)
        {
            DateTime Vd_Date = DateTime.Now;
            string Vs_Year = "";
            string Vs_Day = "";
            string Vs_Month = "";
            string Result = "";
            if (Vint_bankid == 2004)
            {

                string[] vv = VS_DatebankDay.Split(new char[] { ' ' });
                foreach (var v in vv)
                {

                    if (vv[0] != "")
                    {
                        Vs_Day = vv[0].Trim();

                    }
                    if (vv[1] != "")
                    {
                        Vs_Month = vv[1].Trim();
                        Vs_Month = MonthConvert(Vs_Month);

                    }

                    if (vv[2] != "")
                    {
                        Vs_Year = vv[2].Trim();

                    }
                    Result = Vs_Year + "-" + Vs_Month + "-" + Vs_Day;

                }
            }
            else if (Vint_bankid != 2014)
            {

                string[] vvv = VS_DatebankDay.Split(new char[] { '/' });
                foreach (var v in vvv)
                {

                    if (vvv[0] != "")
                    {
                        Vs_Day = vvv[0].Trim();

                    }
                    if (vvv[1] != "")
                    {
                        Vs_Month = vvv[1].Trim();
                        Vs_Month = MonthConvert(Vs_Month);

                    }

                    if (vvv[2] != "")
                    {
                        Vs_Year = vvv[2].Trim();

                    }
                    Result = Vs_Year + "-" + Vs_Month + "-" + Vs_Day;

                }
            }
            Vd_Date = Convert.ToDateTime(Result.ToString());
            return Vd_Date;
        }
        private void BankAhlyMasrInsert()
        {
            

            if (Vint_BankAcc == 10 && Vst_DebitCredit == "دائن")
            {
                Vint_MoveType = 5;
                Vint_MoveType1 = 15;
            }
            Tbl_BankMovement bnm = new Tbl_BankMovement()
            {
                MoveDat = Vd_DateMov,
                BankDueDate = Vd_DatebankDue,
                NumberRefrBank = Vs_NumberRefrBank,
                DescriptionNote = Vs_DescriptionNote,
                Currency = Vst_Currency,
                TransferValue = Vdc_TransferAmount,
                DebitCredit = Vst_DebitCredit,
                Balance = Vdc_BalanceAmount,
                C1 = Vs_C1,
                C2 = Vs_C2,
                C3 = Vs_C3,
                C4 = Vs_C4,
                C5 = Vs_C5,
                C6 = Vs_C6,
                BankID = Vint_BankID,
                BankAccID = Vint_BankAcc,
                MovementCode = Vst_CodeGenerate,
                FisicalYeariD = Vint_FiscYear,
                IsSelectedType = false,
                BankCheqID = 0,
                DepositCashID = 0,
                MoveType1 = Vint_MoveType,
                MoveType2 = Vint_MoveType1,
                TradeCode = Vlng_TradeCode,
                AccountBankCode = Vint_CountMb + 1
            };
            FsDb.Tbl_BankMovement.Add(bnm);
            FsDb.SaveChanges();
        }

        private void BankAhlyMotahdInsert()
        {
            Tbl_BankMovement bnm = new Tbl_BankMovement()
            {
                MoveDat = Vd_DateMov,
                BankDueDate = Vd_DatebankDue,
                NumberRefrBank = Vs_NumberRefrBank,
                DescriptionNote = Vs_DescriptionNote,
                Currency = Vst_Currency,
                TransferValue = Vdc_TransferAmount,
                DebitCredit = Vst_DebitCredit,
                Balance = Vdc_BalanceAmount,
                C1 = Vs_C1,
                C2 = Vs_C2,
                C3 = Vs_C3,
                C4 = Vs_C4,
                C5 = Vs_C5,
                C6 = Vs_C6,
                BankID = Vint_BankID,
                BankAccID = Vint_BankAcc,
                MovementCode = Vst_CodeGenerate,
                FisicalYeariD = Vint_FiscYear,
                IsSelectedType = false,
                BankCheqID = 0,
                DepositCashID = 0,
                AccountBankCode = Vint_CountMb + 1
            };
            FsDb.Tbl_BankMovement.Add(bnm);
            FsDb.SaveChanges();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool vbl_SelectType = false;
            //AddColumnDtaGrd1();
            //FilterDiscriptionBankData();


            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                vbl_SelectType = false;
                //*****************Progress Bar 
                //i = i + 1;
                //if (i < dataGridView2.Rows.Count)
                //{
                //    progressBar1.Value = i + 1;
                //    progressBar1.Refresh();
                //    var progress = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);
                //    label17.Text = ($"Progress: {progress}%");
                //    using (Graphics gr = progressBar1.CreateGraphics())
                //    {
                //        gr.DrawString(null, SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                //    }
                //    int progressPercentage = ((int)i / dataGridView2.Rows.Count) * 100;
                //    progressBar1.CreateGraphics().DrawString(progressPercentage.ToString() + "%", new Font("Arial", (float)2.1, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));


                //    Application.DoEvents();
                //}
                Vint_BankID = int.Parse(comboBox2.SelectedValue.ToString());
                if (Vint_BankID == 2004)
                {
                    VS_DatebankDay = row.Cells[1].Value.ToString();
                    Vd_DateMov = Convert.ToDateTime(VS_DatebankDay.ToString());
                    VS_DatebankDue = row.Cells[2].Value.ToString();
                    Vd_DatebankDue = Convert.ToDateTime(VS_DatebankDue.ToString());
                    Vs_NumberRefrBank = row.Cells[3].Value.ToString();
                    Vs_DescriptionNote = row.Cells[4].Value.ToString();
                    Vdc_TransferAmount = Convert.ToDecimal(row.Cells[6].Value.ToString());
                    Vst_DebitCredit = row.Cells[7].Value.ToString();
                    Vdc_BalanceAmount = Convert.ToDecimal(row.Cells[8].Value.ToString());
                    if (checkEdit1.Checked == true)
                    {
                        Vlng_TradeCode =long.Parse( row.Cells[9].Value.ToString());
                    }
                    if (Vint_BankAcc == 10 && Vst_DebitCredit == "دائن")
                    {
                        Vint_MoveType = 5;
                        Vint_MoveType1 = 15;
                        vbl_SelectType = true;
                    }
                }
                else if (Vint_BankID == 2014)
                {
                    VS_DatebankDay = row.Cells[1].Value.ToString();
                    Vd_DateMov = Convert.ToDateTime(VS_DatebankDay.ToString());
                    //Vd_DateMov = CollectDate(VS_DatebankDay, Vint_BankID);
                    VS_DatebankDue = row.Cells[2].Value.ToString();
                    Vd_DatebankDue = Convert.ToDateTime(VS_DatebankDue.ToString());
                    //Vd_DatebankDue = CollectDate(VS_DatebankDue, Vint_BankID);
                    //Vs_NumberRefrBank = row.Cells[3].Value.ToString();
                    Vs_DescriptionNote = row.Cells[3].Value.ToString();
                    if (row.Cells[4].Value != null && row.Cells[4].Value != "")
                    {
                        Vdc_TransferAmount = (Convert.ToDecimal(row.Cells[4].Value.ToString())) * -1;
                        Vst_DebitCredit = "مدين";
                    }
                    if (row.Cells[5].Value != null && row.Cells[5].Value != "")
                    {
                        Vdc_TransferAmount = Convert.ToDecimal(row.Cells[5].Value.ToString());
                        Vst_DebitCredit = "دائن";
                    }


                    Vdc_BalanceAmount = Convert.ToDecimal(row.Cells[6].Value.ToString());
                }
                else if (Vint_BankID == 2005)
                {
                    VS_DatebankDay = row.Cells[1].Value.ToString();
                    Vd_DateMov = Convert.ToDateTime(VS_DatebankDay.ToString());
                    //Vd_DateMov = CollectDate(VS_DatebankDay, Vint_BankID);
                    VS_DatebankDue = row.Cells[2].Value.ToString();
                    Vd_DatebankDue = Convert.ToDateTime(VS_DatebankDue.ToString());
                    //Vd_DatebankDue = CollectDate(VS_DatebankDue, Vint_BankID);
                    //Vs_NumberRefrBank = row.Cells[3].Value.ToString();
                    Vs_DescriptionNote = row.Cells[3].Value.ToString();
                    if(string.IsNullOrEmpty (row.Cells[4].Value.ToString()))
                    { }
                    else
                    {
                        Vdc_TransferAmount = (Convert.ToDecimal(row.Cells[4].Value.ToString())) ;
                        Vst_DebitCredit = "مدين";
                    }
                    if (string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                    { }
                    else
                    {
                        Vdc_TransferAmount = Convert.ToDecimal(row.Cells[5].Value.ToString());
                        Vst_DebitCredit = "دائن";
                    }

                    //Vdc_BalanceAmount = Convert.ToDecimal(row.Cells[6].Value.ToString());
                }
                else if (Vint_BankID == 2162)
                {
                    VS_DatebankDay = row.Cells[1].Value.ToString();
                    Vd_DateMov = Convert.ToDateTime(VS_DatebankDay.ToString());
                    VS_DatebankDue = row.Cells[2].Value.ToString();
                    Vd_DatebankDue = Convert.ToDateTime(VS_DatebankDue.ToString());
                    //Vs_NumberRefrBank = row.Cells[3].Value.ToString();
                    Vs_DescriptionNote = row.Cells[6].Value.ToString();

                    if (row.Cells[4].Value != "0")
                    {
                        Vdc_TransferAmount = (Convert.ToDecimal(row.Cells[4].Value.ToString()));
                        if (Vdc_TransferAmount > 0)

                        {
                            Vst_DebitCredit = "مدين";
                            goto start;
                        }
                    }
                    if (row.Cells[3].Value != "0")
                    {

                        Vdc_TransferAmount = Convert.ToDecimal(row.Cells[3].Value.ToString());
                        if (Vdc_TransferAmount > 0)
                        {
                            Vst_DebitCredit = "دائن";
                            goto start;
                        }
                    }

                    start:
                    Vdc_BalanceAmount = Convert.ToDecimal(row.Cells[5].Value.ToString());
                }
                else if (Vint_BankID == 2093)
                {
                    VS_DatebankDay = row.Cells[1].Value.ToString();
                    Vd_DateMov = Convert.ToDateTime(VS_DatebankDay.ToString());
                    VS_DatebankDue = row.Cells[2].Value.ToString();
                    Vd_DatebankDue = Convert.ToDateTime(VS_DatebankDue.ToString());
                    //Vs_NumberRefrBank = row.Cells[3].Value.ToString();
                    Vs_DescriptionNote = row.Cells[3].Value.ToString();

                    if (row.Cells[4].Value != "0")
                    {
                        Vdc_TransferAmount = (Convert.ToDecimal(row.Cells[4].Value.ToString()));
                        if (Vdc_TransferAmount > 0)

                        {
                            Vst_DebitCredit = "مدين";
                            goto start;
                        }
                    }
                    if (row.Cells[5].Value != "0")
                    {

                        Vdc_TransferAmount = Convert.ToDecimal(row.Cells[5].Value.ToString());
                        if (Vdc_TransferAmount > 0)
                        {
                            Vst_DebitCredit = "دائن";
                            goto start;
                        }
                    }

                    start:
                    Vdc_BalanceAmount = 0;
                }
                else if (Vint_BankID == 2)
                {
                    VS_DatebankDay = row.Cells[1].Value.ToString();
                    Vd_DateMov = Convert.ToDateTime(VS_DatebankDay.ToString());
                    VS_DatebankDue = row.Cells[2].Value.ToString();
                    Vd_DatebankDue = Convert.ToDateTime(VS_DatebankDue.ToString());
                    Vs_NumberRefrBank = row.Cells[6].Value.ToString();
                    Vs_DescriptionNote = row.Cells[5].Value.ToString();

                    if (row.Cells[4].Value.ToString().Trim() == "0" || row.Cells[4].Value.ToString().Trim() == string.Empty || row.Cells[4].Value.ToString().TrimStart() == null || row.Cells[4].Value.ToString().TrimEnd() == null)
                    {
                        row.Cells[4].Value = "0";
                        Vdc_TransferAmount = (Convert.ToDecimal(row.Cells[4].Value.ToString()));
                        if (Vdc_TransferAmount > 0)

                        {
                            Vst_DebitCredit = "مدين";
                            goto start;
                        }
                    }
                    else if (Convert.ToDecimal(row.Cells[4].Value.ToString()) > 0)
                    {
                        Vdc_TransferAmount = (Convert.ToDecimal(row.Cells[4].Value.ToString()));
                        Vst_DebitCredit = "مدين";
                        goto start;
                    }
                    if (row.Cells[3].Value.ToString().Trim() == "0" || row.Cells[3].Value.ToString().Trim() == string.Empty || row.Cells[3].Value.ToString().TrimStart() == null || row.Cells[3].Value.ToString().TrimEnd() == null)
                    {
                        row.Cells[3].Value = "0";
                        Vdc_TransferAmount = Convert.ToDecimal(row.Cells[3].Value.ToString());
                        if (Vdc_TransferAmount > 0)
                        {
                            Vst_DebitCredit = "دائن";
                            goto start;
                        }
                    }
                    else if (Convert.ToDecimal(row.Cells[3].Value.ToString()) > 0)
                    {
                        Vdc_TransferAmount = Convert.ToDecimal(row.Cells[3].Value.ToString());
                        Vst_DebitCredit = "دائن";
                        goto start;
                    }

                    start:
                    Vdc_BalanceAmount = 0;
                }

                Vint_FiscYear = int.Parse(comboBox3.SelectedValue.ToString());

                Vint_BankAcc = int.Parse(comboBox1.SelectedValue.ToString());
                Vst_Currency = "EGP";

                var List = FsDb.Tbl_BankMovement.Where(x => x.BankID == Vint_BankID && x.BankAccID == Vint_BankAcc && x.MoveDat == Vd_DateMov).ToList();

                if (comboBox2.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("من فضلك اختر البنك ورقم الحساب الخاص بكشف الحساب المسحوب");
                    comboBox2.Focus();
                }
                else
                {
                    if (List.Count >= int.Parse(textBox1.Text))
                    {
                        var resultMessageYesNo = MessageBox.Show($"يومية كشف الحساب بتاريخ {Vd_DateMov.ToString("yyyy/MM/dd")} للبنك {txtBankFrom.Text}  تم اضافتها من قبل - هل تريد اضافتها مره اخرى  ", "", MessageBoxButtons.YesNo);

                        if (resultMessageYesNo == DialogResult.Yes)
                        {
                            FsDb.Tbl_BankMovement.RemoveRange(List);
                            FsDb.SaveChanges();
                            //************************** كود حركة البنك
                           
                            Vd_Date = Convert.ToDateTime(List[0].MoveDat.Value.ToString());

                            var listOfYear = FsDb.Tbl_Fiscalyear.Where(x => x.DateFrom <= Vd_Date && x.DateTo >= Vd_Date).ToList();

                            if (listOfYear.Count > 0)
                            {
                                string Vst_YearMovDate = listOfYear[0].FinancialYear.ToString();
                                Vint_FiscYear = int.Parse(listOfYear[0].ID.ToString());
                            }
                            Vst_FinancialYear = FsDb.Tbl_Fiscalyear.Where(x => x.ID == Vint_FiscYear).Select(x => x.FinancialYear).FirstOrDefault();

                            //    Vint_BankID     Vint_BankAcc 
                            Vint_CountMb = FsDb.Tbl_BankMovement.Where(x => x.FisicalYeariD == Vint_FiscYear && x.BankAccID == Vint_BankAcc).ToList().Max(x => x.AccountBankCode);
                            if (Vint_CountMb == null) { Vint_CountMb = 0; }
                            string BankAccNo = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAcc).Select(x => x.AccountBankNo).FirstOrDefault();
                            string bnkacc4charch = BankAccNo.Substring(BankAccNo.Length - 2);
                            Vst_CodeGenerate = Vst_FinancialYear + "/" + bnkacc4charch + "/" + (Vint_CountMb + 1).ToString();
                            //**************************

                           //Vint_CountMb = FsDb.Tbl_BankMovement.Where(x => x.FisicalYeariD == Vint_FiscYear).Count();
                            //string Vst_FinancialYear = FsDb.Tbl_Fiscalyear.Where(x => x.ID == Vint_FiscYear).Select(x => x.FinancialYear).FirstOrDefault();
                            //Vst_CodeGenerate = Vst_FinancialYear + "/" + "/" + (Vint_CountMb + 1).ToString();
                            var ListBank_Chield = FsDb.Tbl_Banks.Where(x => x.Parent_ID == Vint_BankID).ToList();
                            if (Vint_BankID == 2004)
                            {
                                BankAhlyMasrInsert();
                            }
                            else if (Vint_BankID == 2014)
                            {
                                BankAhlyMotahdInsert();
                            }
                            else if (Vint_BankID == 2162)
                            {
                                BankAhlyMotahdInsert();
                            }
                            else if (Vint_BankID == 2)
                            {
                                BankAhlyMotahdInsert();
                            }

                        }
                        else
                        {
                            break;
                        }

                    }
                    else if (List.Count >= 0 && List.Count <= int.Parse(textBox1.Text))
                    {
                        //************************** كود حركة البنك
                        Vd_DateMov = Convert.ToDateTime(VS_DatebankDay.ToString());
                        Vd_Date = Convert.ToDateTime(Vd_DateMov);

                        var listOfYear = FsDb.Tbl_Fiscalyear.Where(x => x.DateFrom <= Vd_Date && x.DateTo >= Vd_Date).ToList();
                        if (listOfYear.Count > 0)
                        {
                            string Vst_YearMovDate = listOfYear[0].FinancialYear.ToString();
                            Vint_FiscYear = int.Parse(listOfYear[0].ID.ToString());
                        }
                        Vst_FinancialYear = FsDb.Tbl_Fiscalyear.Where(x => x.ID == Vint_FiscYear).Select(x => x.FinancialYear).FirstOrDefault();

                        //    Vint_BankID     Vint_BankAcc 
                        Vint_CountMb = FsDb.Tbl_BankMovement.Where(x => x.FisicalYeariD == Vint_FiscYear && x.BankAccID == Vint_BankAcc).ToList().Max(x => x.AccountBankCode);
                        if (Vint_CountMb == null) { Vint_CountMb = 0; }
                        string BankAccNo = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAcc).Select(x => x.AccountBankNo).FirstOrDefault();
                        string bnkacc4charch = BankAccNo.Substring(BankAccNo.Length - 2);
                        Vst_CodeGenerate = Vst_FinancialYear + "/" + bnkacc4charch + "/" + (Vint_CountMb + 1).ToString();
                        //**************************
                        //Vint_CountMb = FsDb.Tbl_BankMovement.Where(x => x.BankID == Vint_BankID && x.BankAccID == Vint_BankAcc && x.FisicalYeariD == Vint_FiscYear).Count();
                        //string Vst_FinancialYear = FsDb.Tbl_Fiscalyear.Where(x => x.ID == Vint_FiscYear).Select(x => x.Name).FirstOrDefault();
                        //Vst_CodeGenerate = Vst_FinancialYear + "/" + Vint_BankID.ToString() + "/" + Vint_BankAcc.ToString() + "/" + (Vint_CountMb + 1).ToString();
                        if (Vint_BankID == 2004 && Vint_BankAcc == 10 && Vst_DebitCredit == "دائن")
                        {
                            Vint_MoveType = 5;
                            Vint_MoveType1 = 15;
                            vbl_SelectType = true;
                        }
                        Tbl_BankMovement bnm = new Tbl_BankMovement()
                        {
                            MoveDat = Vd_DateMov,
                            BankDueDate = Vd_DatebankDue,
                            NumberRefrBank = Vs_NumberRefrBank,
                            DescriptionNote = Vs_DescriptionNote,
                            Currency = Vst_Currency,
                            TransferValue = Vdc_TransferAmount,
                            DebitCredit = Vst_DebitCredit,
                            Balance = Vdc_BalanceAmount,
                            C1 = Vs_C1,
                            C2 = Vs_C2,
                            C3 = Vs_C3,
                            C4 = Vs_C4,
                            C5 = Vst_CodeGenerate,
                            C6 = Vs_C6,
                            BankID = Vint_BankID,
                            BankAccID = Vint_BankAcc,
                            MovementCode = Vst_CodeGenerate,
                            FisicalYeariD = Vint_FiscYear,
                            IsSelectedType = false,
                            BankCheqID = 0,
                            DepositCashID = 0,
                            TransferID = 0,
                            IsCollected = vbl_SelectType,
                            MoveType1 = Vint_MoveType,
                            MoveType2 = Vint_MoveType1,
                            TradeCode = Vlng_TradeCode,
                            AccountBankCode = Vint_CountMb + 1
                        };
                        FsDb.Tbl_BankMovement.Add(bnm);
                        FsDb.SaveChanges();
                        Vlng_LastRowDepositCash = bnm.ID;
                    }

                }

            }
            if (Vlng_LastRowDepositCash > 0)
            {
                //---------------خفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "اضافة كشف حساب بنك",
                    TableName = "Tbl_BankMovement",
                    TableRecordId = Vlng_LastRowDepositCash.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة سحب كشف حساب بنك"

                };

                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //************************************
                MessageBox.Show("تم الحفظ");
                textBox1.Text = "";
                txtBankFrom.Text = "";
                txtBankFromID.Text = "";
                comboBox2.Text = "";
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "اختر البنك ";
                Vint_MoveType = null;
                Vint_MoveType1 = null;
                comboBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "اختر رقم الحساب ";
                simpleButton1.Enabled = true;
            }
        }

        private void txtBankFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.Enabled = true;
                simpleButton2.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBankParentWithAccFrm t = new Forms.BasicCodeForms.FindBankParentWithAccFrm();
                t.ShowDialog();

                if (t.txtBankId.Text != "")
                {

                    txtBankFrom.Text = t.txtSelected.Text;
                    txtBankFromID.Text = t.txtBankId.Text;
                    int Vint_BankFromID = int.Parse(txtBankFromID.Text);

                    if (Vint_BankFromID == 1)
                    { Vint_BankFromID = 2004; }
                    else if (Vint_BankFromID == 2013)
                    { Vint_BankFromID = 2014; }

                    this.tbl_AccountsBank1TableAdapter.FillByBankID(this.bankCheques.Tbl_AccountsBank1, Vint_BankFromID);


                }
                simpleButton2.Focus();

            }
        }

        private void txtBankFrom_Leave(object sender, EventArgs e)
        {
            simpleButton2.Enabled = true;

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_BankFromID = int.Parse(comboBox2.SelectedValue.ToString());
            this.tbl_AccountsBank1TableAdapter.FillByBankID(this.bankCheques.Tbl_AccountsBank1, Vint_BankFromID);
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر رقم الحساب";
            simpleButton2.Enabled = true;
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBox1.Focus();

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Enabled = true;
                simpleButton2.Focus();

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 78 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {

                DateTime Vd_DFrom = Convert.ToDateTime(DTPFrom.Value.ToString("yyyy-MM-dd"));
                DateTime Vd_Dto = Convert.ToDateTime(DTPTo.Value.ToString("yyyy-MM-dd"));
                Vint_BankID = int.Parse(comboBox2.SelectedValue.ToString());
                Vint_BankAcc = int.Parse(comboBox1.SelectedValue.ToString());
                string Vst_Bank = comboBox2.Text;
                var listToDeleteBnkMovement = FsDb.Tbl_BankMovement.Where(x => x.MoveDat >= Vd_DFrom && x.MoveDat <= Vd_Dto && x.BankID==Vint_BankID && x.BankAccID == Vint_BankAcc);

                var resultMessageYesNo = MessageBox.Show($"هل تريد حدف  يوميه كشف الحساب الفتره من  {Vd_DFrom.ToString()} الى {Vd_Dto} بنك {Vst_Bank}؟", "حدف  يومية كشف حساب ", MessageBoxButtons.YesNo);
                if (resultMessageYesNo == DialogResult.Yes)
                {
                    FsDb.Tbl_BankMovement.RemoveRange(listToDeleteBnkMovement);
                    FsDb.SaveChanges();
                    MessageBox.Show($"تم حذف يومية كشف الحساب الفتره من {Vd_DFrom.ToString()} الى {Vd_Dto} بنك {Vst_Bank} ");
                    //---------------خفظ ااحداث 
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "حذف كشف حساب بنك",
                        TableName = "Tbl_BankMovement",
                        TableRecordId = "",
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة سحب كشف حساب بنك"

                    };

                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //************************************
                }

            }

        }

        private void DTPFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPTo.Focus();

            }
        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();

            }
        }
    }
}