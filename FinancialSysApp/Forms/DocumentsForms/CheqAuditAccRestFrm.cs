using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class CheqAuditAccRestFrm : Form
    {
        public CheqAuditAccRestFrm()
        {
            InitializeComponent();
        }

        private void CheqAuditAccRestFrm_Load(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.FillByUserDate(this.accRestAuditDS.Dtb_AccRefAudit,Program.GlbV_UserId);
        }
    }
}
