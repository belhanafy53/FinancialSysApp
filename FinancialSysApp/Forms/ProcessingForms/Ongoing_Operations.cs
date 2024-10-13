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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Ongoing_Operations : DevExpress.XtraEditors.XtraUserControl
    {
        DateTime DateFR = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        DateTime DateTO = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        public Ongoing_Operations()
        {
            InitializeComponent();
        }
        public void GetParam_Date()
        {

            SqlCommand com = new SqlCommand();
            SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString());
            com.CommandType = CommandType.Text;
            com.Connection = sqlconnection;
            com.CommandText = "Select DateT,DateF From Tbl_DateRange ";
            sqlconnection.Open();
            SqlDataReader re = com.ExecuteReader();
            while (re.Read())
            {
                DateTO = Convert.ToDateTime(re.GetValue(0));
                DateFR = Convert.ToDateTime(re.GetValue(1));
            }
            re.Close();

            sqlconnection.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //GetParam_Date();
            Reports.Ongoing_Operations  r = new Reports.Ongoing_Operations();
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


            ParameterFieldDefinitions crParameterFieldDefinitions1;
            ParameterFieldDefinition crParameterFieldDefinition1;
            ParameterValues crParameterValues1 = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
            crParameterDiscreteValue1.Value = DateFR.ToString();
            crParameterFieldDefinitions1 = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition1 = crParameterFieldDefinitions1["d1"];
           
            crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
            crParameterValues1.Clear();
            crParameterValues1.Add(crParameterDiscreteValue1);
            crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();



        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            Reports.Ongoing_Operations2 r = new Reports.Ongoing_Operations2();
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


            ParameterFieldDefinitions crParameterFieldDefinitions1;
            ParameterFieldDefinition crParameterFieldDefinition1;
            ParameterValues crParameterValues1 = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
            crParameterDiscreteValue1.Value = DateFR.ToString();
            crParameterFieldDefinitions1 = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition1 = crParameterFieldDefinitions1["d2"];

            crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
            crParameterValues1.Clear();
            crParameterValues1.Add(crParameterDiscreteValue1);
            crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();

        }

        private void Ongoing_Operations_Load(object sender, EventArgs e)
        {
            GetParam_Date();

            Reports.Ongoing_Operations r = new Reports.Ongoing_Operations();
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


            ParameterFieldDefinitions crParameterFieldDefinitions1;
            ParameterFieldDefinition crParameterFieldDefinition1;
            ParameterValues crParameterValues1 = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
            crParameterDiscreteValue1.Value = DateFR.ToString();
            crParameterFieldDefinitions1 = r.DataDefinition.ParameterFields;
            crParameterFieldDefinition1 = crParameterFieldDefinitions1["d1"];

            crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
            crParameterValues1.Clear();
            crParameterValues1.Add(crParameterDiscreteValue1);
            crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();

        }
    }
}
