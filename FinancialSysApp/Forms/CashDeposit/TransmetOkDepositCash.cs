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
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.CashDeposit.TransmetOkDepositCash
{
    public partial class TransmetOkDepositCash : Form
    {
        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        int Vint_BankID = 0;
        int Vint_bankAccid = 0;
        //long Vlng_TreasuryCollectionID = 0;
        long Vlng_ChqBnkID = 0;
        int Vint_type1 = 0;
        int Vint_type2 = 0;

        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public TransmetOkDepositCash()
        {
            InitializeComponent();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        
        private void TransmetOkCheqBank_Load(object sender, EventArgs e)
        {
            
            

            Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
            Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
            DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
            DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
            Vint_BankID = int.Parse(txtBnkID.Text);
            Vint_bankAccid = int.Parse(txtBnkAccID.Text);
            Vint_type1 = int.Parse(txtType1ID.Text);
            Vint_type2 = int.Parse(txtType2ID.Text);
            //if (comboBox1.SelectedValue != null)
            //{ Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString()); }
            //this.dataTable13TableAdapter.FillByDatesBankIdBankAccTypes(this.bankTransmentDS.DataTable13, Vst_DepositDate1, Vst_DepositDate2, Vint_BankID, Vint_bankAccid, Vint_type1, Vint_type2);
            //LoadSerial();
        }
    }
}
