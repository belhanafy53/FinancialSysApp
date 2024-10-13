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
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class PrintLetter : DevExpress.XtraEditors.XtraForm
    {
        public PrintLetter()
        {
            InitializeComponent();
        }

        private void PrintLetter_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Select();
            this.ActiveControl = dateTimePicker1;
            dateTimePicker1.Focus();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {   if (txtProcessid.Text == "0")
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 82 && w.ProcdureId == 2);
                if (validationSaveUser != null)
                {
                    this.printLetterTableAdapter.Fill(this.letters.PrintLetter, Convert.ToInt32(txtProcessid.Text), Convert.ToDateTime(dateTimePicker1.Value).ToString("yyyy/MM/dd"), Convert.ToDateTime(dateTimePicker2.Value).ToString("yyyy/MM/dd"));
                    ReportParameter[] parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("d", dateTimePicker1.Text);

                    parameters[1] = new ReportParameter("d1", dateTimePicker2.Text);
                    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية عرض وطباعة تقرير الحطابات الوارده خلال فترة .. برجاء مراجعة مدير المنظومه");
                }
            }
            else if (txtProcessid.Text == "1")
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 83 && w.ProcdureId == 2);
                if (validationSaveUser != null)
                {
                    this.printLetterTableAdapter.Fill(this.letters.PrintLetter, Convert.ToInt32(txtProcessid.Text), Convert.ToDateTime(dateTimePicker1.Value).ToString("yyyy/MM/dd"), Convert.ToDateTime(dateTimePicker2.Value).ToString("yyyy/MM/dd"));
                    ReportParameter[] parameters = new ReportParameter[5];
                    parameters[0] = new ReportParameter("d", dateTimePicker1.Text);

                    parameters[1] = new ReportParameter("d1", dateTimePicker2.Text);
                    parameters[2] = new ReportParameter("Usr", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("unit", Program.GlbV_SysUnite);
                    parameters[4] = new ReportParameter("man", Program.GlbV_Management);
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية عرض وطباعة تقرير الحطابات الصادره خلال فترة .. برجاء مراجعة مدير المنظومه");
                }
            }
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
                simpleButton1.Focus();
            }
        }
    }
}