
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

namespace FinancialSysApp. Forms. Banks. Reports
    {
    public partial class PrintCheque : Form
        {
        public PrintCheque()
            {
            InitializeComponent();
            }

        private void PrintCheque_Load(object sender, EventArgs e)
            {
            
            ReportParameter[] parameters = new ReportParameter[5];

            parameters[0] = new ReportParameter("bdate",dTPDueDate.Value.ToShortDateString() );

            parameters[1] = new ReportParameter("bankn", txtChequeNo.Text);
            parameters[2] = new ReportParameter("usful", textBox5.Text);
            parameters[3] = new ReportParameter("values", textBox2.Text);
            parameters[4] = new ReportParameter("valuename", textBox6.Text);
            this.reportViewer1.LocalReport.SetParameters(parameters);

            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
            reportViewer1. RefreshReport();
            }
        }
    }
