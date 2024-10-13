using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.Banks
{
    public partial class PrintAddedCheqDate : DevExpress.XtraEditors.XtraForm
    {
        public PrintAddedCheqDate()
        {
            InitializeComponent();
        }

        private void PrintAddedCheqDate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDateAddedReport.CheqDetails' table. You can move, or remove it, as needed.
          
            // TODO: This line of code loads data into the 'bankDateAddedReport.CheqDetails' table. You can move, or remove it, as needed.
            //this.cheqDetailsTableAdapter.Fill(this.bankDateAddedReport.CheqDetails);


            this.reportViewer1.RefreshReport();
            dateTimePicker1.Focus();
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (checkBox2.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.Banks.PrintDateAdded-Copy.rdlc";

                    this.cheqDetailsTableAdapter.Fill(this.bankDateAddedReport.CheqDetails, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
                    ReportParameter[] parameters = new ReportParameter[2];
                    
                    parameters[0] = new ReportParameter("Usr", Program.GlbV_EmpName);
                    
                    parameters[1] = new ReportParameter("Man", Program.GlbV_Management);
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 100;
                    this.reportViewer1.RefreshReport();
                }
                if (checkBox1.Checked == true)
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.Banks.PrintDateAdded.rdlc";
                    this.cheqDetailsTableAdapter.Fill(this.bankDateAddedReport.CheqDetails, dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString());
                    ReportParameter[] parameters = new ReportParameter[2];

                    parameters[0] = new ReportParameter("Usr", Program.GlbV_EmpName);

                    parameters[1] = new ReportParameter("Man", Program.GlbV_Management);
                    this.reportViewer1.LocalReport.SetParameters(parameters);

                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 100;
                    this.reportViewer1.RefreshReport();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true )
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }
    }
}
