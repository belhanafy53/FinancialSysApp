using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.Orders.Reports
{
    public partial class OrdersDetailsRpt : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankId = 0;
        int Vint_BranchID = 0;
        //int Vint_BankAccid = 0;
        string Vd_DFrom = "";
        string Vd_DTo = "";
        string Vs_BankName = "";
        string Vs_BankAccNoName = "";
        //string Vs_DbCredit = "";
        public OrdersDetailsRpt()
        {
            InitializeComponent();
        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 

                    Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");



                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Orders.OrdersDetailsRpt.rdlc";
                    this.dtb_OrdersDetailsFromDocTableAdapter.FillDataOrdersByDates(this.ordersDataSet.Dtb_OrdersDetailsFromDoc, Vd_DFrom, Vd_DTo);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User","");
                    parameters[3] = new ReportParameter("Supp", "");
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بأوامر المستندات خلال الفتره");

                     

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    txtSupliers.Focus();
                
                 
            }
        }

        private void OrdersDetailsRpt_Load(object sender, EventArgs e)
        {
            DTPFrom.Select();
            this.ActiveControl = DTPFrom;
            DTPFrom.Focus();
        }

        private void DTPFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPTo.Select();
                this.ActiveControl = DTPTo;
                DTPTo.Focus();
            }
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.ProcessingForms.FindSupliersFrm t = new Forms.ProcessingForms.FindSupliersFrm();

                t.ShowDialog();
                if (Forms.ProcessingForms.FindSupliersFrm.SelectedRow != null)
                {
                    txtSupliers.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[1].Value.ToString();
                    txtSuplierID.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[0].Value.ToString();
                    int Vint_SuppId = int.Parse(txtSuplierID.Text);
                    Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");



                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Orders.OrdersDetailsRpt.rdlc";
                    this.dtb_OrdersDetailsFromDocTableAdapter.FillByDatesSupplId(this.ordersDataSet.Dtb_OrdersDetailsFromDoc, Vd_DFrom, Vd_DTo, Vint_SuppId);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("Supp", txtSupliers.Text);
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بأوامر المستندات  مورد / مقاول خلال الفتره");



                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    txtSupliers.Focus();
                }
            }
        }
    }
}
