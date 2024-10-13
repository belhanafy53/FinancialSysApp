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

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindCustomersFrm : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindCustomersFrm()
        {
            InitializeComponent();
        }

        private void FindCustomersFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Customer1' table. You can move, or remove it, as needed.
            this.tbl_Customer1TableAdapter.Fill(this.financialSysDataSet.Tbl_Customer1);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_CostCenters' table. You can move, or remove it, as needed.
            //this.tbl_CostCentersTableAdapter.Fill(this.financialSysDataSet.Tbl_CostCenters);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Customer' table. You can move, or remove it, as needed.
            //this.tbl_CustomerTableAdapter.Fill(this.financialSysDataSet.Tbl_Customer);

            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_Customer1TableAdapter.FillByName(this.financialSysDataSet.Tbl_Customer1, textBox1.Text);
            }
            catch
            {
            }
        }
    }
}