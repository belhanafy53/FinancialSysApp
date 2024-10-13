using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.Banks.Reports
{
    public partial class AllCheqWithErrorRP : Form
    {
        public AllCheqWithErrorRP()
        {
            InitializeComponent();
        }

        private void AllCheqWithErrorRP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Dtb_CheqWithError' table. You can move, or remove it, as needed.
            this.dtb_CheqWithErrorTableAdapter.FillCheqWithErrors(this.bankCheques.Dtb_CheqWithError);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.Banks.Reports.AllCheqAuditingWithErrorsRpt.rdlc";
        }
    }
}
