using System;
using System.Linq;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Reporting.WinForms;
namespace FinancialSysApp.Forms.Letter_WarrantyForm
{
    public partial class LetterWarrantFileToFileRPTFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_FillNo1 = 0;
        int Vint_FillNo2 = 0;
        int Vint_FillNo3 = 0;
        int Vint_FillNo4 = 0;
        int Vint_LetterProcessID = 0;
        public LetterWarrantFileToFileRPTFrm()
        {
            InitializeComponent();
        }

        private void LetterWarrantFileToFileRPTFrm_Load(object sender, EventArgs e)
        {
            Vint_LetterProcessID = radioGroup1.SelectedIndex;
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                textBox4.Text = textBox2.Text;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox4.Text = textBox2.Text;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vint_FillNo1 = int.Parse(textBox1.Text);
                Vint_FillNo2 = int.Parse(textBox2.Text);
                Vint_FillNo3 = int.Parse(textBox3.Text);
                Vint_FillNo4 = int.Parse(textBox4.Text);

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWarrantyFillNoToFillNoRpt.rdlc";
                this.dtb_LttrWrrntyRepTableAdapter.FillByFileToFile(this.letterWarranty.Dtb_LttrWrrntyRep, Vint_LetterProcessID, Vint_FillNo1,  Vint_FillNo3, Vint_FillNo2);
                ReportParameter[] parameters = new ReportParameter[7];
                
                parameters[0] = new ReportParameter("FromFileNo", Vint_FillNo1.ToString());
                parameters[1] = new ReportParameter("ToFileNo", Vint_FillNo3.ToString());
                parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان ");
                parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);
                parameters[4] = new ReportParameter("FromFileNo1", Vint_FillNo2.ToString());
                parameters[5] = new ReportParameter("ToFileNo1", Vint_FillNo4.ToString());
                parameters[6] = new ReportParameter("PManagement", "الاداره العامه للموازنه والتمويل");
                
                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();

            }
        }
    }
}
