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
    public partial class BankCollectedOrNotFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_BankID = 0;
        int Vint_AccBankID = 0;
        int Vint_TypeM = 0;
        int Vint_TypeS = 0;
        public BankCollectedOrNotFrm()
        {
            InitializeComponent();
        }

        private void BankCollectedOrNotFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_MovementBankType' table. You can move, or remove it, as needed.
            this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccountsBank' table. You can move, or remove it, as needed.
            this.tbl_AccountsBankTableAdapter.Fill(this.bankCheques.Tbl_AccountsBank);
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

            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي ";

            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي ";

            checkBox1.Checked = true;
            checkBox2.Checked = false;
            DTPFrom.Focus();
        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();

            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            DTPFrom.Focus();
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            DTPFrom.Focus();
        }

        private void DTPFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPTo.Focus();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Vint_BankID = int.Parse(comboBox1.SelectedValue.ToString());
            this.tbl_AccountsBankTableAdapter.FillByByBankID(this.bankCheques.Tbl_AccountsBank, Vint_BankID);
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "اختر رقم الحساب";
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Vd_DFrom = "";
                string Vd_DTo = "";
                Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                Vint_BankID = int.Parse(comboBox1.SelectedValue.ToString());
                Vint_AccBankID = int.Parse(comboBox2.SelectedValue.ToString());
                if (checkBox1.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankCollectedOrNotRpt.rdlc";
                    this.tbl_BankMovementTableAdapter.FillByCollectedNonCollected(this.bankTransmentDS.Tbl_BankMovement, Vd_DFrom, Vd_DTo, Vint_BankID, Vint_AccBankID, true);
                    ReportParameter[] parameters = new ReportParameter[4];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("TitleRpt", "بيان ماتم ربطه خلال الفتره");
                    //parameters[4] = new ReportParameter("PTypeM", "");
                    //parameters[5] = new ReportParameter("PTypeS", "");
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    comboBox3.Focus();
                }
                else if (checkBox2.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankCollectedOrNotRpt.rdlc";
                    this.tbl_BankMovementTableAdapter.FillByCollectedNonCollected(this.bankTransmentDS.Tbl_BankMovement, Vd_DFrom, Vd_DTo, Vint_BankID, Vint_AccBankID, false);
                    ReportParameter[] parameters = new ReportParameter[4];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("TitleRpt", "بيان بما لم يتم ربطه خلال الفتره");
                    //parameters[4] = new ReportParameter("PTypeM", "");
                    //parameters[5] = new ReportParameter("PTypeS", "");
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    comboBox3.Focus();
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();

            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_type1 = int.Parse(comboBox3.SelectedValue.ToString());
            var listType = FsDb.Tbl_MovementBankType.Where(x => x.MoveType == Vint_type1).ToList();
            if (listType.Count > 0)
            {

                comboBox4.DataSource = listType;
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
                comboBox4.Text = "";
                comboBox4.SelectedIndex = -1;
                comboBox4.Text = "اختر التصنيف الفرعي";
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Vd_DFrom = "";
                string Vd_DTo = "";
                string Vst_typeM = "";
                string Vst_typeS = "";
                Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                Vint_BankID = int.Parse(comboBox1.SelectedValue.ToString());
                Vint_AccBankID = int.Parse(comboBox2.SelectedValue.ToString());
                Vint_TypeM = int.Parse(comboBox3.SelectedValue.ToString());
                Vst_typeM = comboBox3.Text;
                Vint_TypeS = int.Parse(comboBox4.SelectedValue.ToString());
                Vst_typeS = comboBox4.Text;
                if (checkBox1.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankCollectedOrNotRpt.rdlc";
                    this.tbl_BankMovementTableAdapter.FillByCollectedNoTypOrNo(this.bankTransmentDS.Tbl_BankMovement, Vd_DFrom, Vd_DTo, Vint_BankID, Vint_AccBankID, true, Vint_TypeM, Vint_TypeS);
                    ReportParameter[] parameters = new ReportParameter[6];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("TitleRpt", "بيان ماتم ربطه خلال الفتره");
                    parameters[4] = new ReportParameter("PTypeM", Vst_typeM);
                    parameters[5] = new ReportParameter("PtypeS", Vst_typeS);

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                }
                else if (checkBox2.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankCollectedOrNotRpt.rdlc";
                    this.tbl_BankMovementTableAdapter.FillByCollectedNoTypOrNo(this.bankTransmentDS.Tbl_BankMovement, Vd_DFrom, Vd_DTo, Vint_BankID, Vint_AccBankID, false, Vint_TypeM, Vint_TypeS);
                    ReportParameter[] parameters = new ReportParameter[6];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("TitleRpt", "بيان بما لم يتم ربطه خلال الفتره");
                    parameters[4] = new ReportParameter("PTypeM", Vst_typeM);
                    parameters[5] = new ReportParameter("PtypeS", Vst_typeS);
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                }
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox4.Focus();
            }

        }
    }
}
