using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevComponents.DotNetBar.Controls;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindOrder : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }

        public FindOrder()
        {
            InitializeComponent();
        }

        private void FindOrder_Load(object sender, EventArgs e)
        {
            SelectedRow = null;
            // TODO: This line of code loads data into the 'dataSet1.Tbl_OrderKind' table. You can move, or remove it, as needed.
            this.tbl_OrderKindTableAdapter.Fill(this.dataSet1.Tbl_OrderKind);
            Order.Select();
            this.ActiveControl = Order;
            Order.Focus();
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                  int  Vint_OrderKindID =  int.Parse(Order.SelectedValue.ToString());
                    this.dataTable2TableAdapter.FillByOrderNumber(this.dataSet11.DataTable2, Nametxt.Text, Vint_OrderKindID);
                }
                catch { }
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

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Order_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {
                Nametxt.Focus();
                Nametxt.SelectAll();
            }
        }

        private void FindOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow = null;
                this.Close();
            }
        }
    }
}
