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

namespace FinancialSysApp.Forms.Banks.Reports
{
    public partial class DueCheqBankRpt : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        //int? Vint_BankId = 0;
        int Vint_Bankid = 0;
        //int Vint_BankAccid = 0;
        string Vd_DFrom = "";
        string Vd_DTo = "";
        string Vs_BankName = "";
        string Vs_BankAccNoName = "";
        string Vs_DbCredit = "";
        public DueCheqBankRpt()
        {
            InitializeComponent();
        }

        private void DueCheqBankRpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDateAddedReport.Dtb_RefundCheqBank' table. You can move, or remove it, as needed.
            //this.dtb_RefundCheqBankTableAdapter.FillRefund(this.bankDateAddedReport.Dtb_RefundCheqBank);


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
                Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");



                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.DueDateBanKCheqRpt.rdlc";
                this.dtb_DueCheqDateTableAdapter.FillDueDate (this.bankDateAddedReport.Dtb_DueCheqDate, Vd_DFrom, Vd_DTo);
                ReportParameter[] parameters = new ReportParameter[4];

                parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                parameters[3] = new ReportParameter("Bank", "");
                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                 Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                Vint_Bankid = int.Parse(comboBox1.SelectedValue.ToString());
                Vs_BankName = comboBox1.Text;


                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.DueDateBanKCheqRpt.rdlc";
                this.dtb_DueCheqDateTableAdapter.FillByDueDateBankID(this.bankDateAddedReport.Dtb_DueCheqDate, Vint_Bankid, Vd_DFrom, Vd_DTo);


                ReportParameter[] parameters = new ReportParameter[4];
                
                parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                parameters[3] = new ReportParameter("Bank", comboBox1.Text );

                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();

            }
        }
    }
}
