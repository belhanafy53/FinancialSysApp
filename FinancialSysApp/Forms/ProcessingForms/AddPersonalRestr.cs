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

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class AddPersonalRestr : DevExpress.XtraEditors.XtraForm
    {
        public AddPersonalRestr()
        {
            InitializeComponent();
        }

        private void AddPersonalRestr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Beneficiary' table. You can move, or remove it, as needed.
            this.tbl_BeneficiaryTableAdapter.Fill(this.financialSysDataSet.Tbl_Beneficiary);

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}