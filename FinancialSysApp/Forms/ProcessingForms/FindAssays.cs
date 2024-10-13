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
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevComponents.DotNetBar.Controls;
namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindAssays : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindAssays()
        {
            InitializeComponent();
        }

        private void FindAssays_Load(object sender, EventArgs e)
        {
            SelectedRow = null;
            txtOrderManagement.Select();
            this.ActiveControl = txtOrderManagement;
            txtOrderManagement.Focus();
        }

        private void txtOrderManagement_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtOrderManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.assaysSearchTableAdapter.Fill(this.dataSet1.AssaysSearch, txtOrderManagement.Text);

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

        private void FindAssays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow = null;
                this.Close();
            }
        }
    }
}
