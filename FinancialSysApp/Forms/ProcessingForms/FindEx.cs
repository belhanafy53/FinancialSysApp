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
using DevComponents.DotNetBar;
namespace FinancialSysApp.Forms.ProcessingForms
{
    
    public partial class FindEx : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindEx()
        {
            InitializeComponent();
        }

        private void FindEx_Load(object sender, EventArgs e)
        {
            SelectedRow = null;
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ExchangeCenter' table. You can move, or remove it, as needed.
            this.tbl_ExchangeCenterTableAdapter.Fill(this.financialSysDataSet.Tbl_ExchangeCenter);
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

        private void dataGridView1_CellDoubleClick(object sender, KeyEventArgs e)
        {
           
        }

        //private void dataGridView1_CellDoubleClick(object sender, KeyEventArgs e)
        //{
        //    throw new NotImplementedException();

        //}

        //private void dataGridView1_CellMouseDoubleClick(object sender, KeyEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dataGridView1_CellDoubleClick(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_ExchangeCenterTableAdapter.FillByEXName(this.financialSysDataSet.Tbl_ExchangeCenter,textBox1.Text );
            }
            catch { }
        }

        private void FindEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow = null;
                this.Close();
            }
        }
    }
}