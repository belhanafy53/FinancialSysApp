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
    public partial class FindSupliersFrm : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindSupliersFrm()
        {
            InitializeComponent();
        }

        private void FindSupliersFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Supplier' table. You can move, or remove it, as needed.
            this.tbl_SupplierTableAdapter.Fill(this.financialSysDataSet.Tbl_Supplier);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Customer' table. You can move, or remove it, as needed.
            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();


        }

        private void textBox1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_SupplierTableAdapter.FillByName(this.financialSysDataSet.Tbl_Supplier, textBox1.Text);
            }
            catch
            {

            }
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
                if (dataGridView1.RowCount > 0)
                {
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                    dataGridView1_CellDoubleClick(dataGridView1, args);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {
                SelectedRow = dataGridView1.Rows[e.RowIndex];
                this.Close();
            }
        }
    }
}