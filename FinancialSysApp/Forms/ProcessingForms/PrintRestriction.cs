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

namespace FinancialSysApp.Forms.ProcessingForms
{
   
   
    public partial class PrintRestriction : Form
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public PrintRestriction()
        {
            InitializeComponent();
        }

        private void PrintRestriction_Load(object sender, EventArgs e)
        {
            
            this.dataTable1TableAdapter.Fill(this.printRestriction1.DataTable1, Convert.ToDecimal(resNum.Text), x, y, z.ToString());
            ReportParameter[] parameters = new ReportParameter[18];
            parameters[0] = new ReportParameter("ReportParameter1", resNum.Text);

            parameters[1] = new ReportParameter("ReportParameter2", ResDate.Text);
            parameters[2] = new ReportParameter("ReportParameter3", textBox1.Text);
            parameters[3] = new ReportParameter("ReportParameter4", textBox2.Text);
            parameters[4] = new ReportParameter("ReportParameter5", textBox3.Text);
            parameters[5] = new ReportParameter("ReportParameter6", textBox4.Text);
            parameters[6] = new ReportParameter("ReportParameter7", textBox5.Text);
            parameters[7] = new ReportParameter("ReportParameter8", textBox6.Text);
            parameters[8] = new ReportParameter("ReportParameter9", textBox7.Text);
            parameters[9] = new ReportParameter("ReportParameter10", textBox8.Text);
            parameters[10] = new ReportParameter("ReportParameter11", textBox9.Text);
            parameters[11] = new ReportParameter("ReportParameter12", textBox10.Text);
            parameters[12] = new ReportParameter("ReportParameter13", textBox11.Text);
            parameters[13] = new ReportParameter("ReportParameter14", textBox12.Text);
            parameters[14] = new ReportParameter("ReportParameter15", textBox13.Text);
            parameters[15] = new ReportParameter("Usr", Program.GlbV_EmpName);
            parameters[16] = new ReportParameter("unit", Program.GlbV_SysUnite);
            parameters[17] = new ReportParameter("man", Program.GlbV_Management);

           
            this.reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
