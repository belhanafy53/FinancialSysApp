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
    public partial class CheckRestrAuditAtDayFrm : Form
    {
        public CheckRestrAuditAtDayFrm()
        {
            InitializeComponent();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["ser"].Value = i; i++;
            }
        }
        private void CheckRestrAuditAtDayFrm_Load(object sender, EventArgs e)
        {
            string Vst_DepositDate1 = dateTimePickerF.Value.ToString();
            string Vst_DepositDate2 =  dateTimePickerT.Value.ToString() ;
            this.dataTable1TableAdapter.FillByUserDates(this.accRestAuditDS.Dtb_AccRefAudit, Vst_DepositDate1,  Program.GlbV_UserId, Vst_DepositDate2);
            LoadSerial();
            dateTimePickerF.Focus();
        }

        private void dateTimePickerF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePickerT.Focus();
            }
        }

        private void dateTimePickerT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               string  Vst_DepositDate1 = dateTimePickerF.Value.ToString();
               string Vst_DepositDate2 =dateTimePickerT.Value.ToString();
                this.dataTable1TableAdapter.FillByUserDates(this.accRestAuditDS.Dtb_AccRefAudit, Vst_DepositDate1, Program.GlbV_UserId, Vst_DepositDate2);
                LoadSerial();
            }
        }
    }
}
