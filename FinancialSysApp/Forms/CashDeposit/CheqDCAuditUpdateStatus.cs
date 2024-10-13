using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.CashDeposit
{
    public partial class CheqDCAuditUpdateStatus : Form
    {
        public CheqDCAuditUpdateStatus()
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
        private void CheqDCAuditUpdateStatus_Load(object sender, EventArgs e)
        {
          
          
            if (Program.GlbV_SysUnite_ID == 11)
            {
                // TODO: This line of code loads data into the 'bankCheques.Dtb_CheqWithError' table. You can move, or remove it, as needed.
                this.dtb_DepositCashWithErrorTableAdapter.FillErrors(this.depositCashDS.Dtb_DepositCashWithError);
                LoadSerial();
            }
            else if (Program.GlbV_SysUnite_ID == 12)
            {
                this.dtb_DepositCashWithErrorTableAdapter.FillByBank(this.depositCashDS.Dtb_DepositCashWithError);
                LoadSerial();
            }

        }

        private void dTPDeposit_ValueChanged(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dataGridView1.DataSource;
            ////bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
            //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";
            ////bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
            //dataGridView1.DataSource = bs;
            //if (Program.GlbV_SysUnite_ID == 13)
            //{
            //    // TODO: This line of code loads data into the 'bankCheques.Dtb_CheqWithError' table. You can move, or remove it, as needed.
            //    this.dtb_CheqWithErrorTableAdapter.FillCheqWithErrors(this.bankCheques.Dtb_CheqWithError);
            //}
            //else if (Program.GlbV_SysUnite_ID == 12)
            //{
            //    this.dtb_CheqWithErrorTableAdapter.FillByBank(this.bankCheques.Dtb_CheqWithError);
            //}
        }
    }
}
