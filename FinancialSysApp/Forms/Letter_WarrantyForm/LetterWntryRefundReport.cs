using System;
using System.Linq;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.Letter_WarrantyForm
{
    public partial class LetterWntryRefundReport : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();

        int? Vint_BankID = 0;
        int? Vint_SuppID = 0;
        int Vint_LetterProcessID = 0;
        public LetterWntryRefundReport()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBank.Text != "")
                {

                }

            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBanksFrm M = new Forms.BasicCodeForms.FindBanksFrm();

                M.ShowDialog();
                if (M.txtBankId.Text != "")
                {

                    txtBank.Text = M.txtSelected.Text;
                    txtBankID.Text = M.txtBankId.Text;
                    Vint_BankID = int.Parse(txtBankID.Text);
                    //int Vint_suppId = int.Parse(txtSuplierID.Text);
                    int Vint_LetterKindId = int.Parse(cmbLetterKind.SelectedValue.ToString());
                    string Vs_FrDateTime = DTPFrom.Value.ToString("yyyy-MM-dd");
                    string Vs_ToDateTime = DTPTo.Value.ToString("yyyy-MM-dd");

                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWntryRefundRpt.rdlc";
                    this.dtb_RefundLtrWarrantyRepTableAdapter.FillByRefundByBank(this.letterWarranty.Dtb_RefundLtrWarrantyRep, Vint_LetterProcessID, Vint_LetterKindId, Vs_FrDateTime, Vs_ToDateTime, Vint_BankID);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vs_FrDateTime);
                    parameters[1] = new ReportParameter("ToDate", Vs_ToDateTime);
                    parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان المرتده " + " " + txtBank.Text);
                    parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[4] = new ReportParameter("PManagement", "الاداره العامه للموازنه والتمويل");

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    txtBank.Focus();
                }
                else
                {


                }

            }
        }

        private void txtSupliers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBank.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.ProcessingForms.FindSupliersFrm t = new Forms.ProcessingForms.FindSupliersFrm();

                t.ShowDialog();
                if (Forms.ProcessingForms.FindSupliersFrm.SelectedRow != null)
                {
                    txtSupliers.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[1].Value.ToString();
                    txtSuplierID.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[0].Value.ToString();
                    int Vint_suppId = int.Parse(txtSuplierID.Text);
                    int Vint_LetterKindId = int.Parse(cmbLetterKind.SelectedValue.ToString());
                    string Vs_FrDateTime = DTPFrom.Value.ToString("yyyy-MM-dd");
                    string Vs_ToDateTime = DTPTo.Value.ToString("yyyy-MM-dd");

                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWntryRefundRpt.rdlc";
                    this.dtb_RefundLtrWarrantyRepTableAdapter.FillByRefundLetterDatesAndSuppID(this.letterWarranty.Dtb_RefundLtrWarrantyRep, Vint_LetterProcessID, Vint_LetterKindId, Vs_FrDateTime, Vs_ToDateTime, Vint_suppId);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vs_FrDateTime);
                    parameters[1] = new ReportParameter("ToDate", Vs_ToDateTime);
                    parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان المرتده " + " " + txtSupliers.Text);
                    parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[4] = new ReportParameter("PManagement", "الاداره العامه للموازنه والتمويل");

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    txtBank.Focus();

                }


            }
        }

        private void LetterWntryRefundReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_LetterWarrantyKind' table. You can move, or remove it, as needed.
            this.tbl_LetterWarrantyKindTableAdapter.Fill(this.financialSysDataSet.Tbl_LetterWarrantyKind);
            Vint_LetterProcessID = radioGroup1.SelectedIndex;
            checkBox1.Checked = false;
            txtBank.Text = "";
            txtBankID.Text = "";
            txtSupliers.Text = "";
            txtSuplierID.Text = "";

            cmbLetterKind.Focus();
            this.ActiveControl = cmbLetterKind;
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
                int Vint_LetterKindId = int.Parse(cmbLetterKind.SelectedValue.ToString());
                string Vs_FrDateTime = DTPFrom.Value.ToString("yyyy-MM-dd");
                string Vs_ToDateTime = DTPTo.Value.ToString("yyyy-MM-dd");

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWntryRefundRpt.rdlc";
                this.dtb_RefundLtrWarrantyRepTableAdapter.FillByRefundDatesLetterWrnty(this.letterWarranty.Dtb_RefundLtrWarrantyRep, 0, Vint_LetterKindId, Vs_FrDateTime, Vs_ToDateTime);
                ReportParameter[] parameters = new ReportParameter[5];

                parameters[0] = new ReportParameter("FromDate", Vs_FrDateTime);
                parameters[1] = new ReportParameter("ToDate", Vs_ToDateTime);
                parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان المرتده " );
                parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);
                parameters[4] = new ReportParameter("PManagement", "الاداره العامه للموازنه والتمويل");

                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
                checkBox1.Checked = false;
                txtBank.Text = "";
                txtBankID.Text = "";
                txtSupliers.Text = "";
                txtSuplierID.Text = "";
                txtSupliers.Focus();
            }
        }

        private void cmbLetterKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBox1.Checked = false;
                txtBank.Text = "";
                txtBankID.Text = "";
                txtSupliers.Text = "";
                txtSuplierID.Text = "";
                DTPFrom.Focus();
            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSuplierID.Text == "")
            {
                MessageBox.Show("من فضلك اختر المورد المراد");
                txtSupliers.Focus();
                goto ok;
            }
            if (txtBankID.Text == "")
            {
                MessageBox.Show("من فضلك اختر البنك المراد");
                txtBank.Focus();
                goto ok;
            }

            ok:
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = true;
                if (txtSuplierID.Text != "" && txtBankID.Text != "")
                {

                    Vint_BankID = int.Parse(txtBankID.Text);
                    int Vint_suppId = int.Parse(txtSuplierID.Text);
                    int Vint_LetterKindId = int.Parse(cmbLetterKind.SelectedValue.ToString());
                    string Vs_FrDateTime = DTPFrom.Value.ToString("yyyy-MM-dd");
                    string Vs_ToDateTime = DTPTo.Value.ToString("yyyy-MM-dd");

                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWntryRefundRpt.rdlc";
                    this.dtb_RefundLtrWarrantyRepTableAdapter.FillBySuppIdBankID(this.letterWarranty.Dtb_RefundLtrWarrantyRep, Vint_LetterProcessID, Vint_LetterKindId, Vs_FrDateTime, Vs_ToDateTime, Vint_BankID, Vint_suppId);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vs_FrDateTime);
                    parameters[1] = new ReportParameter("ToDate", Vs_ToDateTime);
                    parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان المرتده " + " " + txtBank.Text + " " + txtSupliers.Text);
                    parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[4] = new ReportParameter("PManagement", "الاداره العامه للموازنه والتمويل");

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                }
            }

        }
    }
}

