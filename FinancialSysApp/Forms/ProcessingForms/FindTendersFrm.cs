using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.DataProcessing;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindTendersFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public static DataGridViewRow SelectedRow { get; set; }
      
        public FindTendersFrm()
        {
            InitializeComponent();
         
        }

        private void FindTendersFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_PurchaseMethods' table. You can move, or remove it, as needed.
            this.tbl_PurchaseMethodsTableAdapter.Fill(this.financialSysDataSet.Tbl_PurchaseMethods);
            //comboBox1.SelectedValue = int.Parse(textEdit1.Text);
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Tenders' table. You can move, or remove it, as needed.
            this.dTB_TendersTableAdapter.FillByPurshasePay(this.financialSysDataSet.DTB_Tenders, int.Parse(textEdit1.Text));

            this.tbl_PurchaseMethodsTableAdapter.Fill(this.financialSysDataSet.Tbl_PurchaseMethods);
            //comboBox1.SelectedValue = OrderFrm.;
            //textEdit1.Text = Vint_PUrchasePay.ToString();
           

            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();
           

        }

        private void textBox1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var Vint_cmbtenderId = int.Parse(textEdit1.Text);
                if (textBox1.Text != "")
                {
                    
                    var list = FsDb.Tbl_TendersAuctions.Where(x => x.TenderNo == textBox1.Text && x.PurchaseMethodeID == Vint_cmbtenderId).ToList();
                    dataGridView1.DataSource = list;
                }
                else
                {
                    var list = FsDb.Tbl_TendersAuctions.Where(x => x.PurchaseMethodeID == Vint_cmbtenderId).ToList();
                    dataGridView1.DataSource = list;
                    //this.dTB_TendersTableAdapter.FillByPurshasePay(this.financialSysDataSet.DTB_Tenders, int.Parse(textEdit1.Text));
                }
            }
            catch
            {

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }
   

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                dataGridView1_CellDoubleClick(dataGridView1, args);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.dTB_TendersTableAdapter.FillByTenderNoAndDate(this.financialSysDataSet.DTB_Tenders, textBox1.Text, dateTimePicker1.Value.ToString(), int.Parse(comboBox1.SelectedValue.ToString()));
        }
    }
}