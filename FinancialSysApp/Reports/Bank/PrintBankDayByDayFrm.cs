using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevComponents.DotNetBar.Controls;
using Microsoft.Reporting.WinForms;



namespace FinancialSysApp.Reports.Banks
{
    public partial class PrintBankDayByDayFrm : DevExpress.XtraEditors.XtraForm
    {
        public PrintBankDayByDayFrm()
        {
            InitializeComponent();
        }
        private void MaxDate()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;


            com.Parameters.Clear();
            //row.Cells[5].Value = MAXID.Text;
            com.CommandText = "SELECT MAX(AddDateBank)  FROM dbo.Tbl_BankCheques";

            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                dateTimePicker1.Text = red.GetValue(0).ToString();
            }


            red.Close();
            con.Close();
        }
        private void PrintBankDayByDayFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankDateAddedReport.DankDayByDay' table. You can move, or remove it, as needed.
            //this.dankDayByDayTableAdapter.Fill(this.bankDateAddedReport.DankDayByDay);
            // TODO: This line of code loads data into the 'bankDateAddedReport.DankDayByDay' table. You can move, or remove it, as needed.
            //this.dankDayByDayTableAdapter.Fill(this.bankDateAddedReport.DankDayByDay);
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_Banks' table. You can move, or remove it, as needed.
            MaxDate();
            this.reportViewer1.RefreshReport();
            cmbDepositBank.SelectedIndex = -1;
            cmbDepositBank.Text = "";
            cmbDepositBank.SelectedText = "اختر البنك المودع ";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            dTPAddBank.Select();
            this.ActiveControl = dTPAddBank;
            dTPAddBank.Focus();

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbDepositBank.SelectedText != "اختر البنك المودع ")
                {
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankDayByDay.rdlc";
                    this.dankDayByDayTableAdapter.FillByAddDateAllBanks(this.bankDateAddedReport.DankDayByDay, dTPAddBank.Text, dateTimePicker1.Text);
                    ReportParameter[] parameters = new ReportParameter[1];
                    parameters[0] = new ReportParameter("ReportParameter1", "تقرير بتاريخ الإضافة");


                    // Set report parameters
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    cmbDepositBank.Focus();

                }
            }
            
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankDayByDay.rdlc";
                this.dankDayByDayTableAdapter.FillByAddDeposDateAllBanks(this.bankDateAddedReport.DankDayByDay, dateTimePicker2.Text, dateTimePicker3.Text);
                string x = "   تقرير الإضافة خلال فترة ايداع"+" من "+ dateTimePicker2.Text + "  الى  " + dateTimePicker3.Text;
                ReportParameter[] parameters = new ReportParameter[1];

                // تعيين قيمة للمعلمة
                parameters[0] = new ReportParameter("ReportParameter1", x);

                // تعيين المعلمات لتقرير RDLC
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
                cmbDepositBank.Focus();

            }

        }

        private void dateTimePicker4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dateTimePicker4_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.DueDateBankDayByDay.rdlc";
                this.dankDayByDayTableAdapter.FillByDeueDateAllBank(this.bankDateAddedReport.DankDayByDay, dateTimePicker5.Text, dateTimePicker4.Text);
                string x = "تقرير بتاريخ الاستحقاق";
                ReportParameter[] parameters = new ReportParameter[1];

                // تعيين قيمة للمعلمة
                parameters[0] = new ReportParameter("ReportParameter1", x);

                // تعيين المعلمات لتقرير RDLC
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
                cmbDepositBank.Focus();

            }
        }

        private void dTPAddBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void cmbDepositBank_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker3.Focus();
            }
        }

        private void cmbDepositBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox1.Checked == true)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankDayByDay.rdlc";
                this.dankDayByDayTableAdapter.Fill(this.bankDateAddedReport.DankDayByDay, dTPAddBank.Text, dateTimePicker1.Text, cmbDepositBank.Text);
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("ReportParameter1", "تقرير بتاريخ الإضافة");


                // Set report parameters
                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();
                cmbDepositBank.Focus();
            }
            else if (checkBox2.Checked == true)
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.BankDayByDay.rdlc";
                this.dankDayByDayTableAdapter.FillByDeposidDate(this.bankDateAddedReport.DankDayByDay, cmbDepositBank.Text, dateTimePicker2.Text, dateTimePicker3.Text);
                string x = "تقرير بتاريخ الإيداع";
                ReportParameter[] parameters = new ReportParameter[1];

                // تعيين قيمة للمعلمة
                parameters[0] = new ReportParameter("ReportParameter1", x);

                // تعيين المعلمات لتقرير RDLC
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();




            }
            else if (checkBox3.Checked == true)
            {

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.DueDateBankDayByDay.rdlc";
                this.dankDayByDayTableAdapter.FillByBankDeueDate(this.bankDateAddedReport.DankDayByDay, cmbDepositBank.Text, dateTimePicker5.Text, dateTimePicker4.Text);
                string x = "تقرير بتاريخ الاستحقاق";
                ReportParameter[] parameters = new ReportParameter[1];

                // تعيين قيمة للمعلمة
                parameters[0] = new ReportParameter("ReportParameter1", x);

                // تعيين المعلمات لتقرير RDLC
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.RefreshReport();

            }
        }
        }

        private void dateTimePicker5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker4.Focus();
            }

        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            checkBox3.Checked = false;
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = true;
        }
    }
}
