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
    public partial class FindAccount : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindAccount()
        {
            InitializeComponent();
        }
        Res_Frm r = new Res_Frm();
        private void FindAccount_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Accounting_Guid' table. You can move, or remove it, as needed.
            this.tbl_Accounting_GuidTableAdapter.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);

           
            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {    try
            {
                if (checkEdit10.Checked == true)
                {
                    this.tbl_Accounting_GuidTableAdapter.FillByAll(this.financialSysDataSet.Tbl_Accounting_Guid, textBox1.Text);
                }
                if (checkEdit10.Checked == false )
                {
                    this.tbl_Accounting_GuidTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_Accounting_Guid, textBox1.Text);
                }
            }
            catch { }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                dataGridView1.Focus();
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            //this.Close();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void FindAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void FindAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SelectedRow == null)
            {
                try
                {
                    this.tbl_Accounting_GuidTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_Accounting_Guid, label13.Text);
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                    dataGridView1_CellDoubleClick(dataGridView1, args);
                }
                catch { }
            }
        }

    
    }
}