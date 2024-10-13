using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.Letter_WarrantyForm
{
    public partial class LetterWarrantyTwoLastExpireDateRep : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();

        int Vint_LetterProcessID = 0;
        public LetterWarrantyTwoLastExpireDateRep()
        {
            InitializeComponent();
        }

        private void LetterWarrantyTwoLastExpireDateRep_Load(object sender, EventArgs e)
        {

            this.tbl_LetterWarrantyKindTableAdapter.Fill(this.financialSysDataSet.Tbl_LetterWarrantyKind);
            Vint_LetterProcessID = radioGroup1.SelectedIndex;
            reportViewer1.Visible = true;
            reportViewer2.Visible = false;
            cmbLetterKind.Focus();
            this.ActiveControl = cmbLetterKind;

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
                reportViewer1.Visible = true;
                reportViewer2.Visible = false;

                if (e.KeyCode == Keys.Enter)
                {
                    int Vint_LetterKindId = int.Parse(cmbLetterKind.SelectedValue.ToString());
                    string Vs_DtaeFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string Vs_DtaeTo = dateTimePicker2.Value.ToString("yyyy-MM-dd"); 
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWarrantyTwoDatesExpirRpt.rdlc";
                    this.dtb_LttrWrrntyRepTableAdapter.FillByTwoDatesExpireDates(this.letterWarranty.Dtb_LttrWrrntyRep, Vint_LetterProcessID, Vint_LetterKindId, Vs_DtaeFrom, Vs_DtaeTo);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromFileNo", Vs_DtaeFrom.ToString());
                    parameters[1] = new ReportParameter("ToFileNo", Vs_DtaeTo.ToString());
                    parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان طبقا لاخر تاريخ سريان");
                    parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);

                    parameters[4] = new ReportParameter("PManagement", "الاداره العامه للموازنه والتمويل");

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();

                }
            }
        }

        private void cmbLetterKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;
                int Vint_LetterKindId = int.Parse(cmbLetterKind.SelectedValue.ToString());
                string Vs_DtaeFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string Vs_DtaeTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                this.reportViewer2.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWarrantyTwoDatesExpirLetterBnkRpt.rdlc";
                this.dtb_LttrWrrntyRepTableAdapter.FillByTwoDatesExpireDates(this.letterWarranty.Dtb_LttrWrrntyRep, Vint_LetterProcessID, Vint_LetterKindId, Vs_DtaeFrom, Vs_DtaeTo);
                ReportParameter[] parameters = new ReportParameter[6];

                parameters[0] = new ReportParameter("FromFileNo", Vs_DtaeFrom.ToString());
                parameters[1] = new ReportParameter("ToFileNo", Vs_DtaeTo.ToString());
                parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان طبقا لاخر تاريخ سريان");
                parameters[3] = new ReportParameter("User", Program.GlbV_EmpName);
                parameters[4] = new ReportParameter("AddText", "");
                
                parameters[5] = new ReportParameter("PManagement", "الاداره العامه للموازنه والتمويل");

                this.reportViewer2.LocalReport.SetParameters(parameters);
                reportViewer2.RefreshReport();
            }
        }
    }

}
