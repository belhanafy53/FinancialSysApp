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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Assest : DevExpress.XtraEditors.XtraUserControl
    {
        public Assest()
        {
            InitializeComponent();
        }
        public void Get_Balance()
        {







           
            Reports.RptAssets BRPT = new Reports.RptAssets();
          
            SqlConnection sqlconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ACC.Properties.Settings.DBConnectionString"].ConnectionString.ToString());

            sqlconnection.Open();
            SqlCommand CMD = new SqlCommand();
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Connection = sqlconnection;
            CMD.CommandText = "SP_Assest_Analysis";
            CMD.Parameters.Add("@D1", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
            CMD.Parameters.Add("@D2", SqlDbType.DateTime).Value = dateTimePicker2.Value.ToShortDateString();
            SqlDataAdapter da = new SqlDataAdapter(CMD);
            DataTable dt = new DataTable();
            DataSet DBDataSet = new DataSet();
            DBDataSet.Tables.Add(dt);
            DBDataSet.Clear();
            da.Fill(DBDataSet, "View_ Asset_Analysis");
            //da.Fill(DBDataSet, "SP_Assest_Analysis");
            BRPT.SetDataSource(DBDataSet);

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = dateTimePicker1.Text;
            crParameterFieldDefinitions = BRPT.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["D1"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterFieldDefinitions crParameterFieldDefinitions1;
            ParameterFieldDefinition crParameterFieldDefinition1;
            ParameterValues crParameterValues1 = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue1 = new ParameterDiscreteValue();
            crParameterDiscreteValue1.Value = dateTimePicker2.Text;
            crParameterFieldDefinitions1 = BRPT.DataDefinition.ParameterFields;
            crParameterFieldDefinition1 = crParameterFieldDefinitions1["D2"];
            crParameterValues1 = crParameterFieldDefinition1.CurrentValues;
            crParameterValues1.Clear();
            crParameterValues1.Add(crParameterDiscreteValue1);
            crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1);
            crystalReportViewer1.ReportSource = BRPT;


            //BRPT.SetParameterValue("D1", dateTimePicker1.Text);
            //BRPT.SetParameterValue("D2", dateTimePicker2.Text);
            //Forms.Balance_Rev FRMBalance = new Forms.Balance_Rev();

            crystalReportViewer1.ReportSource = BRPT;
            crystalReportViewer1.Refresh();
            //DAL.closse();
            sqlconnection.Close();
            DBDataSet.Dispose();
            //}
            //catch { }


        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("تجميع بيانات تحليلات الأصول الثابتة ");
            splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات ");
            Get_Balance();
            splashScreenManager1.CloseWaitForm();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
