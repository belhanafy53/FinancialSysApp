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

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class LetterWarrentyAuditFrm : DevExpress.XtraEditors.XtraForm
    {
        public LetterWarrentyAuditFrm()
        {
            InitializeComponent();
        }

        private void LetterWarrentyAuditFrm_Load(object sender, EventArgs e)
        {
            int Vint_LetterID = int.Parse(LetterId.Text);
            this.dtbLetterWAuditTableAdapter.Fill(this.letterWarranty.DtbLetterWAudit, Vint_LetterID);
        }
    }
}