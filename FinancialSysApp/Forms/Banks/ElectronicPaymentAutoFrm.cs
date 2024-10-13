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

namespace FinancialSysApp.Forms.Banks
{
    public partial class ElectronicPaymentAutoFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        string Vst_CodeMovBank = "";
        public ElectronicPaymentAutoFrm()
        {
            InitializeComponent();
        }

        private void ElectronicPaymentAutoFrm_Load(object sender, EventArgs e)
        {
            simpleButton1.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم الانتهاء من رفع ومعالجة بيانات ملف الاكسيل");
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

                    string ExcelCodeMov = row.Cells[1].Value.ToString();
                    string ExcelAmount = row.Cells[2].Value.ToString();
                    string ExcelDescrptionNote = row.Cells[3].Value.ToString();
                    string excelMOvDate = row.Cells[4].Value.ToString();
                    string excelDailyDate = row.Cells[7].Value.ToString();

                    DateTime date1, date2;
                    if (DateTime.TryParse(excelMOvDate, out date1) && DateTime.TryParse(excelDailyDate, out date2))
                    {

                        object[] rowData = new object[excelRange.Columns.Count];
                        for (int i = 0; i < excelRange.Columns.Count; i++)
                        {
                            if (i == 3)
                            {

                                rowData[i] = date1.ToString("yyyy-MM-dd");
                            }
                            else if (i == 6)
                            {

                                rowData[i] = date2.ToString("yyyy-MM-dd");
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
                string[] columnNames = { " ", "كود الحركه ", "قيمة التحويل", "وصف الحركه ", "تاريخ الحركه ", "التصنيف ", " الفرع", " تاريخ يوميه", "كود قديم " };
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
                LoadSerial2();
                splashScreenManager1.CloseWaitForm();
                //simpleButton1.Enabled = false;
                simpleButton2.Enabled = true;

            }
            else if (result == DialogResult.Cancel)
            {
                splashScreenManager1.CloseWaitForm();
            }



        }
        private void LoadSerial2()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                //string Vst_CodeTrade = "";
                //************************** كود حركة البنك
                String Vs_ValueCodeCheck = "";
                if (row.Cells[1].Value.ToString() != "0")
                {
                    Vs_ValueCodeCheck = row.Cells[1].Value.ToString();
                }
                else
                {
                    Vs_ValueCodeCheck = "";
                }
                if (Vs_ValueCodeCheck != "")
                {

                    Vst_CodeMovBank = row.Cells[1].Value.ToString();
                     
                    var listUpdateTyped = FsDb.Tbl_BankMovement.Where(x => x.MovementCode == Vst_CodeMovBank && x.MoveType1 == 5 && x.MoveType2 == 15).ToList();
                    if (row.Cells[5].Value.ToString() != "")
                    {
                        if (listUpdateTyped[0].TradeMoveType.ToString() == "")
                        {
                            listUpdateTyped[0].TradeMoveType = int.Parse(row.Cells[5].Value.ToString());
                        }
                        else
                        {
                            long vlng_BnkMovId = long.Parse(listUpdateTyped[0].ID.ToString());
                            int Vint_TradeMvType = int.Parse(listUpdateTyped[0].TradeMoveType.ToString());
                            Tbl_BnkMovementCustTypeOld BnkMvOld = new Tbl_BnkMovementCustTypeOld()
                            {
                                BankMovID = long.Parse(listUpdateTyped[0].ID.ToString()),
                                TradeMoveType = int.Parse(listUpdateTyped[0].TradeMoveType.ToString()),
                                BranchId = int.Parse(listUpdateTyped[0].BranchId.ToString()),
                                DailyDate = Convert.ToDateTime(listUpdateTyped[0].DailyDate.ToString()),
                            };
                            FsDb.Tbl_BnkMovementCustTypeOld.Add(BnkMvOld);
                            FsDb.SaveChanges();
                        }

                    }
                    if (row.Cells[6].Value.ToString() != "")
                    {
                        listUpdateTyped[0].BranchId = int.Parse(row.Cells[6].Value.ToString());
                    }
                    listUpdateTyped[0].DailyDate = Convert.ToDateTime(row.Cells[7].Value.ToString());
                    //if (row.Cells[8].Value.ToString() != "")
                    //{ listUpdateTyped[0].TradeCode = long.Parse(row.Cells[8].Value.ToString()); }
                    //************************تصنيف - امانات - نقدي - عهد
                    DateTime Vd_MovDate = Convert.ToDateTime(row.Cells[4].Value.ToString());
                    int Vint_MonthMovDate = Vd_MovDate.Month;
                    DateTime Vd_DailyDate = Convert.ToDateTime(row.Cells[7].Value.ToString());
                    int Vint_MonthDailyDate = Vd_DailyDate.Month;
                    if (Vint_MonthMovDate > Vint_MonthDailyDate)
                    {
                        listUpdateTyped[0].MoveType3 = 3;
                    }
                    else if (Vint_MonthMovDate == Vint_MonthDailyDate)
                    {
                        listUpdateTyped[0].MoveType3 = 2;
                    }
                    //***********************
                }
                else if (row.Cells[8].Value.ToString() != "")
                {
                    long VLg_CodeTrade = long.Parse(row.Cells[8].Value.ToString());
                    var listUpdateTyped = FsDb.Tbl_BankMovement.Where(x => x.TradeCode == VLg_CodeTrade).ToList();
                    if (row.Cells[5].Value.ToString() != "")
                    {
                        if (listUpdateTyped[0].TradeMoveType.ToString() == "")
                        {
                            listUpdateTyped[0].TradeMoveType = int.Parse(row.Cells[5].Value.ToString());
                        }
                        else
                        {
                            int Vint_TradeMvType = int.Parse(listUpdateTyped[0].TradeMoveType.ToString());

                            Tbl_BnkMovementCustTypeOld BnkMvOld = new Tbl_BnkMovementCustTypeOld()
                            {
                                BankMovID = long.Parse(listUpdateTyped[0].ID.ToString()),
                                TradeMoveType = int.Parse(listUpdateTyped[0].TradeMoveType.ToString()),
                                BranchId = int.Parse(listUpdateTyped[0].BranchId.ToString()),
                                DailyDate = Convert.ToDateTime(listUpdateTyped[0].DailyDate.ToString()),
                            };
                            FsDb.Tbl_BnkMovementCustTypeOld.Add(BnkMvOld);
                            FsDb.SaveChanges();
                        }
                    }
                    if (row.Cells[6].Value.ToString() != "")
                    {
                        listUpdateTyped[0].BranchId = int.Parse(row.Cells[6].Value.ToString());
                    }
                    listUpdateTyped[0].DailyDate = Convert.ToDateTime(row.Cells[7].Value.ToString());
                    //if (row.Cells[8].Value.ToString() != "")
                    //{ listUpdateTyped[0].TradeCode = long.Parse(row.Cells[8].Value.ToString()); }
                    //************************تصنيف - امانات - نقدي - عهد
                    DateTime Vd_MovDate = Convert.ToDateTime(row.Cells[4].Value.ToString());
                    int Vint_MonthMovDate = Vd_MovDate.Month;
                    DateTime Vd_DailyDate = Convert.ToDateTime(row.Cells[7].Value.ToString());
                    int Vint_MonthDailyDate = Vd_DailyDate.Month;
                    if (Vint_MonthMovDate > Vint_MonthDailyDate)
                    {
                        listUpdateTyped[0].MoveType3 = 3;
                    }
                    else if (Vint_MonthMovDate == Vint_MonthDailyDate)
                    {
                        listUpdateTyped[0].MoveType3 = 2;
                    }
                    //***********************
                }
              
                FsDb.SaveChanges();
            }
            MessageBox.Show("تم الحفظ");
            //---------------خفظ ااحداث 
            SecurityEvent sev = new SecurityEvent
            {
                ActionName = "رفع ملف اكسيل بتصنيف العملاء",
                TableName = "Tbl_BankMovement",
                TableRecordId = "",
                Description = "",
                ManagementName = Program.GlbV_Management,
                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                EmployeeName = Program.GlbV_EmpName,
                User_ID = Program.GlbV_UserId,
                UserName = Program.GlbV_UserName,
                FormName = "شاشة الدفع الاليكتروني - اليكتروني"

            };

            FsEvDb.SecurityEvents.Add(sev);
            FsEvDb.SaveChanges();
            //************************************
        }

    }
}

