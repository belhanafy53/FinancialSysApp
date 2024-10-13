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
    public partial class BankPurposeDatesRpt : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        string Vd_DFrom ="";
        string Vd_DTo = "";
        public BankPurposeDatesRpt()
        {
            InitializeComponent();
        }

        private void BankPurposeDatesRpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccountsBankPurpose' table. You can move, or remove it, as needed.
            this.tbl_AccountsBankPurposeTableAdapter.Fill(this.bankCheques.Tbl_AccountsBankPurpose);
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
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                int Vint_PurposeId = int.Parse(comboBox2.SelectedValue.ToString());


                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankPurposeDates.rdlc";
                this.tbl_BankMovementTableAdapter.FillByAcountPurposeID(this.bankTransmentDS.Tbl_BankMovement, Vd_DFrom, Vd_DTo, Vint_PurposeId);
                ReportParameter[] parameters = new ReportParameter[2];

                parameters[0] = new ReportParameter("PdF", Vd_DFrom);
                parameters[1] = new ReportParameter("PdT", Vd_DTo);
                //parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);

                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
                comboBox1.Focus();
                comboBox1.Focus();
            }
        }
    }
}
