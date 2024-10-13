using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Rev_EXP : DevExpress.XtraEditors.XtraUserControl
    {
        DateTime  DateTO =Convert.ToDateTime( DateTime.Now.ToShortDateString());
        public Rev_EXP()
        {
            InitializeComponent();
        }
        public void GetParam_Date()
        {

            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "Select DateT From Tbl_DateRange ";
            sqlconnection.Open();
            SqlDataReader re = com.ExecuteReader();
            while (re.Read())
            {
                DateTO = Convert.ToDateTime( re.GetValue(0));
            }
            re.Close();
            
            sqlconnection.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

           // GetParam_Date();
            Reports.Revenue_and_expense r = new Reports.Revenue_and_expense();
            //crystalReportViewer1.ReportSource = r;

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterFieldDefinitions = r.DataDefinition.ParameterFields ;
            crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();





        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //GetParam_Date();
            Reports.Revenue  r = new Reports.Revenue();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           // GetParam_Date();
            Reports.expense_  r = new Reports.expense_();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //GetParam_Date();
            Reports.expense2 r = new Reports.expense2();
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }

        private void Rev_EXP_Load(object sender, EventArgs e)
        {
            GetParam_Date();
            Reports.Revenue_and_expense r = new Reports.Revenue_and_expense();
            //crystalReportViewer1.ReportSource = r;

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = DateTO.ToString();
            crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["d"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   

                }
            }
            catch { }
        }

        private void fillByFirstMonthToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByFirstMonth(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByFirstYearToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByFirstYear(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByThsMonthToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByThsMonth(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByThsYearToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByThsYear(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByFirstMonth(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByFirstYear(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByThsMonth(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByThsYear(this.fSys.TBL_RESULT);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.tBL_RESULTTableAdapter.FillByMonthAndYears(this.fSys.TBL_RESULT, comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text);
                //GetParam_Date();
                //Reports.Revenue_and_expense r = new Reports.Revenue_and_expense();
                //crystalReportViewer1.ReportSource = r;
                //r.SetDataSource(this.tBL_RESULTTableAdapter.FillByMonthAndYears(this.fSys.TBL_RESULT, comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text));
                //ParameterFieldDefinitions crParameterFieldDefinitions;
                //ParameterFieldDefinition crParameterFieldDefinition;
                //ParameterValues crParameterValues = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                //crParameterDiscreteValue.Value = DateTO.ToString();
                //crParameterFieldDefinitions = r.DataDefinition.ParameterFields;
                //crParameterFieldDefinition = crParameterFieldDefinitions["d"];
                //crParameterValues = crParameterFieldDefinition.CurrentValues;
                //crParameterValues.Clear();
                //crParameterValues.Add(crParameterDiscreteValue);
                //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                //crystalReportViewer1.ReportSource = r;
                //crystalReportViewer1.Refresh();
            }
            catch { }
        }
    }
}
