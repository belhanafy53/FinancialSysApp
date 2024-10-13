using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPdfViewer.Bars;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks
{
    public partial class ElectronicPayAuditUpdateStatus : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        long Vlng_LastRowTreasuryCollection = 0;
        public ElectronicPayAuditUpdateStatus()
        {
            InitializeComponent();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void ElectronicPayAuditUpdateStatus_Load(object sender, EventArgs e)
        {
            if (Program.GlbV_SysUnite_ID == 11)
            {
                // TODO: This line of code loads data into the 'bankCheques.Dtb_CheqWithError' table. You can move, or remove it, as needed.
                this.dTBElectronicPayAuditTableAdapter.FillElectronicPayWithErrors(this.bankTransmentDS.DTBElectronicPayAudit);
                LoadSerial();
            }
            else if (Program.GlbV_SysUnite_ID == 12)
            {
                this.dTBElectronicPayAuditTableAdapter.FillByBank(this.bankTransmentDS.DTBElectronicPayAudit);
                
                LoadSerial();
            }// TODO: This line of code loads data into the 'bankTransmentDS.DTBElectronicPayAudit' table. You can move, or remove it, as needed.
           

        }
    }
}
