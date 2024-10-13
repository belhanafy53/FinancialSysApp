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
using FinancialSysApp.Classes;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.CashDeposit
{
   
    public partial class CheqeedepositQueryFrm : Form
    {
        string Vs_FromDate = DateTime.Now.ToString();
        DateTime Vd_ToDate = Convert.ToDateTime(DateTime.Now.ToString());
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public CheqeedepositQueryFrm()
        {
            InitializeComponent();
        }

        private void CheqeedepositQueryFrm_Load(object sender, EventArgs e)
        {

        }

        private void dTPDeposit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vs_FromDate = dTPDeposit.Value.ToString("yyyy-MM-dd");
                Vd_ToDate = Convert.ToDateTime(dTPDeposit2.Value.ToString("yyyy-MM-dd"));
                this.dtb_totalTrCollectionTableAdapter.FillByDepositDate(this.bankCheques.Dtb_totalTrCollection, Vs_FromDate);
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Vint_ID = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Vint_ID = int.Parse(row.Cells[1].Value.ToString());
                decimal listAmountSum = decimal.Parse(FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vint_ID).Sum(x => x.AmountCheque).ToString());
                row.Cells[2].Value = listAmountSum;
            }
        }
    }
}
