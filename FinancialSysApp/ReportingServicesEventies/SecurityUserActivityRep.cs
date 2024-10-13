using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.ReportingServicesEventies
{
    public partial class SecurityUserActivityRep : Form
    {
        public SecurityUserActivityRep()
        {
            InitializeComponent();
        }

        private void SecurityUserActivityRep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysEventsDataSet1.SecurityUserActivity' table. You can move, or remove it, as needed.
            this.securityUserActivityTableAdapter.Fill(this.financialSysEventsDataSet1.SecurityUserActivity);
            // TODO: This line of code loads data into the 'financialSysEventsDataSet1.SecurityEvent' table. You can move, or remove it, as needed.
            //this.securityEventTableAdapter.FillByUserId(this.financialSysEventsDataSet1.SecurityEvent,);
            // TODO: This line of code loads data into the 'financialSysEventsDataSet1.SecurityUserActivity' table. You can move, or remove it, as needed.
            this.securityUserActivityTableAdapter.Fill(this.financialSysEventsDataSet1.SecurityUserActivity);


            this.reportViewer1.RefreshReport();
        }
    }
}
