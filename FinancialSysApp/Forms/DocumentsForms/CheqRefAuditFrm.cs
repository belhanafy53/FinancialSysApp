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
    public partial class CheqRefAuditFrm : Form
    {
        public CheqRefAuditFrm()
        {
            InitializeComponent();
        }

        private void CheqRefAuditFrm_Load(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.FillByRefrencUser(this.accRestAuditDS.Dtb_AccRefAudit, Program.GlbV_UserId);
        }
    }
}
