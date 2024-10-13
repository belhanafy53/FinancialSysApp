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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Financial_CenterControl : DevExpress.XtraEditors.XtraUserControl
    {
        DateTime DateTO = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        public Financial_CenterControl()
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
                DateTO = Convert.ToDateTime(re.GetValue(0));
            }
            re.Close();

            sqlconnection.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //GetParam_Date();
            //Reports.Financial_Center r = new Reports.Financial_Center();
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //GetParam_Date();
            Reports.Financial_Center2 r = new Reports.Financial_Center2();
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
            //GetParam_Date();
            Reports.Financial_Center3 r = new Reports.Financial_Center3();
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

        private void Financial_CenterControl_Load(object sender, EventArgs e)
        {
            Forms.ProcessingForms.Financial_Center f = new Financial_Center();
            f.ShowDialog();
            //GetParam_Date();
            //Reports.Financial_Center r = new Reports.Financial_Center();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
