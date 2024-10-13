using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.ReportsDevX
{
    public partial class FindRestrictionCategorywithAccount : Form
    {
        public static DataGridViewRow SelectedRow { get; set; }

        public FindRestrictionCategorywithAccount()
        {
            InitializeComponent();
        }

        private void FindRestrictionCategorywithAccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Tbl_RestrictionItemsCategory_With_AccountNumber' table. You can move, or remove it, as needed.
            this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.FillAccountNumber(this.dataSet1.Tbl_RestrictionItemsCategory_With_AccountNumber,textBox1.Text );
            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.FillAccountNumber(this.dataSet1.Tbl_RestrictionItemsCategory_With_AccountNumber, textBox1.Text);
            }
            catch { }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                dataGridView1_CellDoubleClick(dataGridView1, args);



            }
        }

        private void FindRestrictionCategorywithAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SelectedRow == null)
            {
                try
                {
                    this.tbl_RestrictionItemsCategory_With_AccountNumberTableAdapter.FillAccountNumber(this.dataSet1.Tbl_RestrictionItemsCategory_With_AccountNumber, textBox1.Text);
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                    dataGridView1_CellDoubleClick(dataGridView1, args);
                }
                catch { }
            }
        }
    }
}
