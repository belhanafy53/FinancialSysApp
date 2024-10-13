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
    public partial class FindProject : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindProject()
        {
            InitializeComponent();
        }

        private void FindProject_Load(object sender, EventArgs e)
        {
            SelectedRow = null;
            // TODO: This line of code loads data into the 'dataSet1.Tbl_Projects' table. You can move, or remove it, as needed.
            this.tbl_ProjectsTableAdapter.Fill(this.dataSet1.Tbl_Projects);
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.tbl_ProjectsTableAdapter.FillByName(this.dataSet1.Tbl_Projects, Nametxt.Text);
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

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void FindProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow = null;
                this.Close();
            }
        }
    }
}
