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
    public partial class FindKind : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindKind()
        {
            InitializeComponent();
        }

        private void FindKind_Load(object sender, EventArgs e)
        {
            SelectedRow = null;
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_RestrictionItemsCategory' table. You can move, or remove it, as needed.
            this.tbl_RestrictionItemsCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_RestrictionItemsCategory);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_RestrictionItemsCategoryTableAdapter.FillByName(this.financialSysDataSet.Tbl_RestrictionItemsCategory,textBox1.Text );
            }
            catch { }
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

        private void FindKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow = null;
                this.Close();
            }
        }
    }
}