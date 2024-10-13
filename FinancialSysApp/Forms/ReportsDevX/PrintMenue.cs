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

namespace FinancialSysApp.Forms.ReportsDevX
{
    public partial class PrintMenue : DevExpress.XtraEditors.XtraForm
    {
        public PrintMenue()
        {
            InitializeComponent();
        }

        private void PrintMenue_Load(object sender, EventArgs e)
        {
            //if (TCount.Text == "1")
            //{
            //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment1Column.rdlc";

            //    this.tBL_ShowMenue_ReportTableAdapter.Fill(this.dataSet11.TBL_ShowMenue_Report, textBox1.Text, Program.GlbV_UserName);
            //    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //    reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            //    reportViewer1.ZoomPercent = 100;
            //    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            //     {
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text),

            //      };
            //    reportViewer1.LocalReport.SetParameters(rParams);
            //    this.reportViewer1.RefreshReport();
            //}
            //if (TCount.Text =="2")
            //{
            //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment.rdlc";

            //    this.tBL_ShowMenue_ReportTableAdapter.Fill(this.dataSet11.TBL_ShowMenue_Report, textBox1.Text, Program.GlbV_UserName);
            //    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //    reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            //    reportViewer1.ZoomPercent = 100;
            //    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            //     {
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter3", textBox4.Text)
            //      };
            //    reportViewer1.LocalReport.SetParameters(rParams);
            //    this.reportViewer1.RefreshReport();
            //}
            //if (TCount.Text == "3")
            //{
            //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment3Columns.rdlc";

            //    this.tBL_ShowMenue_ReportTableAdapter.Fill(this.dataSet11.TBL_ShowMenue_Report, textBox1.Text, Program.GlbV_UserName);
            //    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //    reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            //    reportViewer1.ZoomPercent = 100;
            //    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            //     {
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter3", textBox4.Text),
            //       new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter4", textBox5.Text)
            //      };
            //    reportViewer1.LocalReport.SetParameters(rParams);
            //    this.reportViewer1.RefreshReport();
            //}
            //if (TCount.Text == "4")
            //{
            //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment4Columns.rdlc";

            //    this.tBL_ShowMenue_ReportTableAdapter.Fill(this.dataSet11.TBL_ShowMenue_Report, textBox1.Text, Program.GlbV_UserName);
            //    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //    reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            //    reportViewer1.ZoomPercent = 100;
            //    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            //     {
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter3", textBox4.Text),
            //       new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter4", textBox5.Text),
            //      new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter5", textBox6.Text)
            //      };
            //    reportViewer1.LocalReport.SetParameters(rParams);
            //    this.reportViewer1.RefreshReport();
            //}
            switch (TCount.Text)
            {
                case "1":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment1Column.rdlc";
                    Microsoft.Reporting.WinForms.ReportParameter[] rParams1 = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text)
                    };
                    reportViewer1.LocalReport.SetParameters(rParams1);
                    break;

                case "2":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment.rdlc";
                    Microsoft.Reporting.WinForms.ReportParameter[] rParams2 = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter3", textBox4.Text)
                    };
                    reportViewer1.LocalReport.SetParameters(rParams2);
                    break;

                case "3":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment3Columns.rdlc";
                    Microsoft.Reporting.WinForms.ReportParameter[] rParams3 = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter3", textBox4.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter4", textBox5.Text)
                    };
                    reportViewer1.LocalReport.SetParameters(rParams3);
                    break;

                case "4":
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Forms.ReportsDevX.DeuPayment4Columns.rdlc";
                    Microsoft.Reporting.WinForms.ReportParameter[] rParams4 = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", textBox17.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter2", textBox3.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter3", textBox4.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter4", textBox5.Text),
            new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter5", textBox6.Text)
                    };
                    reportViewer1.LocalReport.SetParameters(rParams4);
                    break;

                default:
                   
                    break;
            }

           
            this.tBL_ShowMenue_ReportTableAdapter.Fill(this.dataSet11.TBL_ShowMenue_Report, textBox1.Text, Program.GlbV_UserName);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}