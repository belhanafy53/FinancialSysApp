using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Reporting.WinForms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace FinancialSysApp.Forms.Banks.Reports
{
    public partial class BankTransmentRpt : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankId = 0;
        int Vint_Bankid = 0;
        int Vint_BankAccid = 0;
        string Vd_DFrom = "";
        string Vd_DTo = "";
        string Vs_BankName = "";
        string Vs_BankAccNoName = "";
        string Vs_DbCredit = "";
        public BankTransmentRpt()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedValue != null)
                {
                    Vint_BankId = int.Parse(comboBox1.SelectedValue.ToString());
                    //*************ارقام الحسابات

                    var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankId).ToList();
                    comboBox2.DataSource = listAccBank;
                    comboBox2.DisplayMember = "AccountBankNo";
                    comboBox2.ValueMember = "ID";
                    int Vin_countItem = comboBox1.Items.Count;

                    comboBox2.SelectedIndex = -1;
                    comboBox2.Text = "اختر رقم الحساب";
                    comboBox2.Select();
                    this.ActiveControl = comboBox2;
                    comboBox2.Focus();

                }
            }
        }

        private void BankTransmentRpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankTransmentDS.DataTable2' table. You can move, or remove it, as needed.
            //this.dtb_BanksTableAdapter.fill
            var listBnkTo = (from BNK in FsDb.Tbl_Banks
                             join BNKACC in FsDb.Tbl_AccountsBank on BNK.ID equals BNKACC.BankID
                             where (BNKACC.KindAccountBankID == 1)
                             select new
                             {
                                 BnkID = BNK.ID,
                                 BnkName = BNK.Name,
                                 BnkParent = BNK.Parent_ID

                             }).Distinct().OrderBy(x => x.BnkName).ToList();
            comboBox1.DataSource = listBnkTo;
            comboBox1.DisplayMember = "BnkName";
            comboBox1.ValueMember = "BnkID";

            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.Text = "اختر البنك ";

            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.Text = "اختر رقم الحساب ";

            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "";
            comboBox3.Text = "اختر نوع العمليه ";
            checkBox2.Checked = true;
            comboBox1.Focus();

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
                comboBox1.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //int Vint_Bankid = 0;
                //int Vint_BankAccid = 0;
                //string Vd_DFrom = "";
                //string Vd_DTo = "";
                //string Vs_BankName = "";
                //string Vs_BankAccNoName = "";
                //Vd_DFrom = DTPFrom.Value.ToString();
                //Vd_DTo = DTPTo.Value.ToString();
                //Vint_Bankid = int.Parse(comboBox1.SelectedValue.ToString());
                //Vs_BankName = comboBox1.Text ;

                //Vint_BankAccid = int.Parse(comboBox2.SelectedValue.ToString());
                //Vs_BankAccNoName = comboBox2.Text;

                //this.dataTable2TableAdapter.Fill(this.bankTransmentDS.DataTable2, Vd_DFrom, Vd_DTo, Vint_Bankid, Vint_BankAccid);
                //ReportParameter[] parameters = new ReportParameter[4];
                //parameters[0] = new ReportParameter("BankID", Vs_BankName);
                //parameters[1] = new ReportParameter("FromDate", Vd_DFrom);
                //parameters[2] = new ReportParameter("ToDate", Vd_DTo);
                //parameters[3] = new ReportParameter("BankAcc", Vs_BankAccNoName);



                //this.reportViewer1.LocalReport.SetParameters(parameters);
                //reportViewer1.RefreshReport();
                comboBox3.Focus();

            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox1.Checked == true)
                {
                   
                    Vd_DFrom = DTPFrom.Value.ToString();
                    Vd_DTo = DTPTo.Value.ToString();
                    Vint_Bankid = int.Parse(comboBox1.SelectedValue.ToString());
                    Vs_BankName = comboBox1.Text;

                    Vint_BankAccid = int.Parse(comboBox2.SelectedValue.ToString());
                    Vs_BankAccNoName = comboBox2.Text;
                    Vs_DbCredit = comboBox3.Text;
                    if (Vs_DbCredit == "دائن" || Vs_DbCredit == "مدين")
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankTransmetTotalRpt.rdlc";
                        this.dataTable2TableAdapter.FillByDebitCredit(this.bankTransmentDS.DataTable2, Vd_DFrom, Vd_DTo, Vint_Bankid, Vint_BankAccid, Vs_DbCredit);
                        ReportParameter[] parameters = new ReportParameter[6];
                        parameters[0] = new ReportParameter("BankID", Vs_BankName);
                        parameters[1] = new ReportParameter("FromDate", Vd_DFrom);
                        parameters[2] = new ReportParameter("ToDate", Vd_DTo);
                        parameters[3] = new ReportParameter("BankAcc", Vs_BankAccNoName);
                        parameters[4] = new ReportParameter("DepitCredit", Vs_DbCredit);
                        parameters[5] = new ReportParameter("User", Program.GlbV_EmpName);



                        this.reportViewer1.LocalReport.SetParameters(parameters);
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankTransmetTotalRpt.rdlc";
                        Vd_DFrom = DTPFrom.Value.ToString();
                        Vd_DTo = DTPTo.Value.ToString();
                        Vint_Bankid = int.Parse(comboBox1.SelectedValue.ToString());
                        Vs_BankName = comboBox1.Text;

                        Vint_BankAccid = int.Parse(comboBox2.SelectedValue.ToString());
                        Vs_BankAccNoName = comboBox2.Text;

                        this.dataTable2TableAdapter.Fill(this.bankTransmentDS.DataTable2, Vd_DFrom, Vd_DTo, Vint_Bankid, Vint_BankAccid);
                        ReportParameter[] parameters = new ReportParameter[5];
                        parameters[0] = new ReportParameter("BankID", Vs_BankName);
                        parameters[1] = new ReportParameter("FromDate", Vd_DFrom);
                        parameters[2] = new ReportParameter("ToDate", Vd_DTo);
                        parameters[3] = new ReportParameter("BankAcc", Vs_BankAccNoName);
                        parameters[4] = new ReportParameter("User", Program.GlbV_EmpName);


                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankTransmetTotalRpt.rdlc";
                        this.reportViewer1.LocalReport.SetParameters(parameters);
                        reportViewer1.RefreshReport();
                    }
                }
                if (checkBox2.Checked == true)
                {
                    Vd_DFrom = DTPFrom.Value.ToString();
                    Vd_DTo = DTPTo.Value.ToString();
                    Vint_Bankid = int.Parse(comboBox1.SelectedValue.ToString());
                    Vs_BankName = comboBox1.Text;
                    if (comboBox2.SelectedValue != null)
                    {
                        Vint_BankAccid = int.Parse(comboBox2.SelectedValue.ToString());
                        Vs_BankAccNoName = comboBox2.Text;
                    }
                    Vs_DbCredit = comboBox3.Text;
                    if (Vs_DbCredit == "دائن" || Vs_DbCredit == "مدين")
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankTransmetRpt.rdlc";
                        this.dataTable2TableAdapter.FillByDebitCredit(this.bankTransmentDS.DataTable2, Vd_DFrom, Vd_DTo, Vint_Bankid, Vint_BankAccid, Vs_DbCredit);
                        ReportParameter[] parameters = new ReportParameter[6];
                        parameters[0] = new ReportParameter("BankID", Vs_BankName);
                        parameters[1] = new ReportParameter("FromDate", Vd_DFrom);
                        parameters[2] = new ReportParameter("ToDate", Vd_DTo);
                        parameters[3] = new ReportParameter("BankAcc", Vs_BankAccNoName);
                        parameters[4] = new ReportParameter("DepitCredit", Vs_DbCredit);
                        parameters[5] = new ReportParameter("User", Program.GlbV_EmpName);



                        this.reportViewer1.LocalReport.SetParameters(parameters);
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankTransmetRpt.rdlc";
                        Vd_DFrom = DTPFrom.Value.ToString();
                        Vd_DTo = DTPTo.Value.ToString();
                        Vint_Bankid = int.Parse(comboBox1.SelectedValue.ToString());
                        Vs_BankName = comboBox1.Text;

                        Vint_BankAccid = int.Parse(comboBox2.SelectedValue.ToString());
                        Vs_BankAccNoName = comboBox2.Text;

                        this.dataTable2TableAdapter.Fill(this.bankTransmentDS.DataTable2, Vd_DFrom, Vd_DTo, Vint_Bankid, Vint_BankAccid);
                        ReportParameter[] parameters = new ReportParameter[5];
                        parameters[0] = new ReportParameter("BankID", Vs_BankName);
                        parameters[1] = new ReportParameter("FromDate", Vd_DFrom);
                        parameters[2] = new ReportParameter("ToDate", Vd_DTo);
                        parameters[3] = new ReportParameter("BankAcc", Vs_BankAccNoName);
                        parameters[4] = new ReportParameter("User", Program.GlbV_EmpName);



                        this.reportViewer1.LocalReport.SetParameters(parameters);
                        reportViewer1.RefreshReport();
                    }
                }
               //else if (checkBox3.Checked == true)
               // {

               //     Vd_DFrom = DTPFrom.Value.ToString();
               //     Vd_DTo = DTPTo.Value.ToString();
                     
               //         this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankTransmetElectrnicPayRpt.rdlc";
               //         this.dataTable2TableAdapter.FillByElectronicPay(this.bankTransmentDS.DataTable2, Vd_DFrom, Vd_DTo);
               //         ReportParameter[] parameters = new ReportParameter[4];
                       
               //         parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
               //         parameters[1] = new ReportParameter("ToDate", Vd_DTo);
               //         parameters[2] = new ReportParameter("DepitCredit", "اا");
               //         parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);



               //         this.reportViewer1.LocalReport.SetParameters(parameters);
               //         reportViewer1.RefreshReport();
                   
               // }
            }
     
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                Vint_BankId = int.Parse(comboBox1.SelectedValue.ToString());
                //*************ارقام الحسابات

                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankId).ToList();
                comboBox2.DataSource = listAccBank;
                comboBox2.DisplayMember = "AccountBankNo";
                comboBox2.ValueMember = "ID";
                int Vin_countItem = comboBox1.Items.Count;

                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "اختر رقم الحساب";
                comboBox2.Select();
                this.ActiveControl = comboBox2;
                comboBox2.Focus();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true )
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true )
            {
                checkBox1.Checked = false;
                
                checkBox3.Checked = false;
                checkBox2.Checked = true;
            }
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox2.Checked = true;
            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
            }
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
                Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                DateTime Vdt_Dtfrom = Convert.ToDateTime(Vd_DFrom);
                DateTime Vdt_DtTo = Convert.ToDateTime(Vd_DTo);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankTransmetElectrnicPayRpt.rdlc";
                this.dataTable2TableAdapter.FillByElectronicPay(this.bankTransmentDS.DataTable2, Vd_DFrom, Vd_DTo);
                //****************
              var listDivGrid =   (from BnkMv in FsDb.Tbl_BankMovement
                 
                 where (BnkMv.MoveDat >= Vdt_Dtfrom && BnkMv.MoveDat <= Vdt_DtTo && BnkMv.MoveType1 == 5 && BnkMv.MoveType2 == 15 && BnkMv.DebitCredit=="دائن")
                 select new
                 {
                     ID = BnkMv.ID,
                     MovementCode = BnkMv.MovementCode,
                     TransferValue = BnkMv.TransferValue,
                     MoveDat = BnkMv.MoveDat,
                     DescriptionNote = BnkMv.DescriptionNote,
                     TradeMoveType = BnkMv.TradeMoveType,
                     BranchId = BnkMv.BranchId,
                      DailyDate = BnkMv.DailyDate,
                    
                
                 }).OrderBy(x => x.MoveDat).ToList();
                //*************

                gridControl1.DataSource = listDivGrid;

                ReportParameter[] parameters = new ReportParameter[4];

                parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                parameters[2] = new ReportParameter("DepitCredit", "اا");
                parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);



                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Vsd_Today = DateTime.Today.ToString("yyyy-MM-dd");                                   
                string loc = Vsd_Today + ".xlsx";


                (gridControl1.MainView as GridView).OptionsPrint.PrintHeader = true;
                XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx();
                advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False;
                advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False;
                advOptions.SheetName = "Not Find Accounts";

                gridControl1.ExportToXlsx(loc, advOptions);

                Process.Start(loc);
            }
            catch
            {
                MessageBox.Show("من فضلك اغلق ملف الاكسيل الخاص بهذا التقرير أولا ،،");
            }
        }
    }
}
