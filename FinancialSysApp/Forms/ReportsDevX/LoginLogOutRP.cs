using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Microsoft.Reporting.WinForms;
using FinancialSysApp.DataBase.ModelEvents;



namespace FinancialSysApp.Forms.ReportsDevX
{
    public partial class LoginLogOutRP : Form
    {
        ModelEvent FsEvDb = new ModelEvent();

        public LoginLogOutRP()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            DTPFrom.Focus();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            using (FinancialSysEventsEntities db = new FinancialSysEventsEntities())
            {
                GetLogInLogOutDataUsers_ResultBindingSource.DataSource = db.GetLogInLogOutDataUsers(DTPFrom.Value, DTPTo.Value).ToList();
                Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                   new Microsoft.Reporting.WinForms.ReportParameter ("FromDate",DTPFrom.Value.Date.ToShortDateString())  ,
                   new Microsoft.Reporting.WinForms.ReportParameter ("ToDate",DTPTo.Value.Date.ToShortDateString()) ,
                   new Microsoft.Reporting.WinForms.ReportParameter ("UserName",Program.GlbV_EmpName.ToString())
                };
                reportViewer1.LocalReport.SetParameters(rParams);
                
                reportViewer1.RefreshReport();
            }
        }

        private void DTPFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPTo.Focus();
            }
        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (FinancialSysEventsEntities db = new FinancialSysEventsEntities())
                {
                    GetLogInLogOutDataUsers_ResultBindingSource.DataSource = db.GetLogInLogOutDataUsers(DTPFrom.Value, DTPTo.Value).ToList();
                    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
                   new Microsoft.Reporting.WinForms.ReportParameter ("FromDate",DTPFrom.Value.Date.ToShortDateString())  ,
                   new Microsoft.Reporting.WinForms.ReportParameter ("ToDate",DTPTo.Value.Date.ToShortDateString())
                    };
                    reportViewer1.LocalReport.SetParameters(rParams);

                    reportViewer1.RefreshReport();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
