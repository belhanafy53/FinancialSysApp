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

namespace FinancialSysApp.Forms.Banks
{
    public partial class NotInDeposidCachFrm : DevExpress.XtraEditors.XtraForm
    {
        public NotInDeposidCachFrm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.depositCashTableAdapter.ClearBeforeFill = true;
                    this.depositCashTableAdapter.Fill(this.notInDeposeidCach.DepositCash, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
                    textBox11.Text = dataGridView1.Rows.Count.ToString();
                    decimal sum = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].FormattedValue.ToString() != string.Empty)
                        {
                            sum += Convert.ToDecimal(row.Cells[3].FormattedValue);
                        }
                    }
                    textBox1.Text = sum.ToString();
                }
                catch { }

            }
        }

        private void NotInDeposidCachFrm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
        }
    }
}