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
    public partial class LetterWarrantyTwoRecieveDateRep : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();

        int Vint_LetterProcessID = 0;
        public LetterWarrantyTwoRecieveDateRep()
        {
            InitializeComponent();
        }

        private void LetterWarrantyTwoRecieveDateRep_Load(object sender, EventArgs e)
        {
            
            this.tbl_LetterWarrantyKindTableAdapter.Fill(this.financialSysDataSet.Tbl_LetterWarrantyKind);
            Vint_LetterProcessID = radioGroup1.SelectedIndex;
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
                if (e.KeyCode == Keys.Enter)
                {
                    int Vint_LetterKindId = int.Parse(cmbLetterKind.SelectedValue.ToString());
                    string Vs_DtaeFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string Vs_DtaeTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Letter_WarrentyReport.LetterWarrantyTwoDatesRecievedRpt.rdlc";
                    this.dtb_LttrWrrntyRepTableAdapter.FillByTwoDateRecieved(this.letterWarranty.Dtb_LttrWrrntyRep, Vint_LetterProcessID, Vint_LetterKindId, Vs_DtaeFrom, Vs_DtaeTo);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromFileNo", Vs_DtaeFrom.ToString());
                    parameters[1] = new ReportParameter("ToFileNo", Vs_DtaeTo.ToString());
                    parameters[2] = new ReportParameter("PTitle", "تقرير بخطابات الضمان طبقا لتاريخ الاستلام");
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
    }
}
