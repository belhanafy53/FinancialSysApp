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
    public partial class TreasureCollectionCheqAuditFrm : Form
    {
        public TreasureCollectionCheqAuditFrm()
        {
            InitializeComponent();
        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Vd_DFrom = "";
                string Vd_DTo = "";
                Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                if (checkBox1.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TreasurCollBankCheqAudit.rdlc";
                    this.dtb_TresurCollAuditTableAdapter.FillDates(this.bankDateAddedReport.Dtb_TresurCollAudit, Vd_DFrom, Vd_DTo);
                    ReportParameter[] parameters = new ReportParameter[4];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("PTitle","بيان ما تم مراجعته خلال الفتره");
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                }
                else if (checkBox2.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TreasurCollBankCheqAudit.rdlc";
                    this.dtb_TresurCollAuditTableAdapter.FillByDatesNotAuditing(this.bankDateAddedReport.Dtb_TresurCollAudit, Vd_DFrom, Vd_DTo);
                    ReportParameter[] parameters = new ReportParameter[4];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("PTitle", "بيان ما لم يتم مراجعته خلال الفتره");
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                }
                
            }
        }

        private void TreasureCollectionCheqAuditFrm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            DTPFrom.Focus();
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
            if(e.KeyCode==Keys.Enter)
            {
                DTPTo.Focus();
            }
        }
    }
}
