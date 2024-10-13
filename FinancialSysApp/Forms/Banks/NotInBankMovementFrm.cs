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
    public partial class NotInBankMovementFrm : DevExpress.XtraEditors.XtraForm
    {
        public NotInBankMovementFrm()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.SelectAll();
                comboBox1.Focus();
                try
                {
                    this.bankMovementTableAdapter.ClearBeforeFill = true;
                    this.bankMovementTableAdapter.Fill(this.notInDeposeidCach.BankMovement, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
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

        private void NotInBankMovementFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'notInDeposeidCach1.Tbl_Management' table. You can move, or remove it, as needed.
            this.tbl_ManagementTableAdapter.Fill(this.notInDeposeidCach1.Tbl_Management);
            comboBox1.SelectedValue = -1;
            dateTimePicker1.Focus();

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                try
                {
                    if (comboBox1.Text == "")
                    {
                        this.bankMovementTableAdapter.ClearBeforeFill = true;
                        this.bankMovementTableAdapter.Fill(this.notInDeposeidCach.BankMovement, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
                        textBox11.Text = dataGridView1.Rows.Count.ToString();
                    }
                    if (comboBox1.Text != "")
                    {
                        this.bankMovementTableAdapter.ClearBeforeFill = true;
                        this.bankMovementTableAdapter.FillBy(this.notInDeposeidCach.BankMovement, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString(),comboBox1.Text );
                        textBox11.Text = dataGridView1.Rows.Count.ToString();
                    }
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
    }
}