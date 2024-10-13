using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.Banks
{
    public partial class PrinQNB : Form
    {
        public PrinQNB()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            //البنك الاهلى المتحد  - فرع الزمالك
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void PrinQNB_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDateAddedReport.Tbl_TreasuryCollection' table. You can move, or remove it, as needed.
          

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbl_TreasuryCollectionTableAdapter.FillByQNB2(this.bankDateAddedReport.Tbl_TreasuryCollection, "بنك قطر الوطنى الاهلى QNB", Convert.ToDateTime( dateTimePicker2.Value.ToShortDateString()).ToString(), Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()).ToString());
                textBox1.Text = dataGridView1.Rows.Count.ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            this.tbl_TreasuryCollectionTableAdapter.FillByFillQNBRepot(this.bankDateAddedReport.Tbl_TreasuryCollection, "بنك قطر الوطنى الاهلى QNB", dataGridView1.CurrentRow.Cells[2].Value.ToString());
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("D", dateTimePicker2.Value.ToShortDateString());


            this.reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
           
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbl_TreasuryCollectionTableAdapter.FillByQNB(this.bankDateAddedReport.Tbl_TreasuryCollection, Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString()).ToString(), Convert.ToDateTime(dateTimePicker3.Value.ToShortDateString()).ToString(), "بنك قطر الوطنى الاهلى QNB");
                textBox1.Text = dataGridView1.Rows.Count.ToString();
            }
        }

        private void dateTimePicker4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker3.Focus();
            }
        }
    }
}
