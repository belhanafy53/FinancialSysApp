using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class FindRepresentativesFrm : Form
    {
        Model1 FsDb = new Model1();
        int Vint_BranchID = 0;
        public static DataGridViewRow SelectedRow { get; set; }
        public FindRepresentativesFrm()
        {
            InitializeComponent();
        }

        private void FindRepresentativesFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Representive' table. You can move, or remove it, as needed.
            //this.dtb_RepresentiveTableAdapter.Fill(this.bankCheques.Dtb_Representive);
            Vint_BranchID = int.Parse(txtBrunchID.Text);
            dataGridView1.DataSource = FsDb.Tbl_Representatives.Where(x => x.BranchID == Vint_BranchID).ToList();
        }

        private void txtBranche_TextChanged(object sender, EventArgs e)
        {
            int Vint_BranchId = int.Parse(txtBrunchID.Text);
            if (txtBranche.Text != "")
            {
                
                var listRepresntvNam = FsDb.Tbl_Representatives.Where(x => x.Name.Contains(txtBranche.Text) && x.BranchID == Vint_BranchId).ToList();
                dataGridView1.DataSource = listRepresntvNam;
            }
            else
            {
                var listlistRepresntv = FsDb.Tbl_Representatives.Where(x => x.Name != null && x.BranchID == Vint_BranchId ).ToList();
                dataGridView1.DataSource = listlistRepresntv;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void FindRepresentativesFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SelectedRow == null)
            {
                try
                {
                    var listRprSntvNam = FsDb.Tbl_Representatives.Where(x => x.Name.Contains(txtBranche.Text)).ToList();
                    dataGridView1.DataSource = listRprSntvNam;
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                    dataGridView1_CellDoubleClick(dataGridView1, args);
                }
                catch { }
            }
        }

        private void txtBranche_KeyDown(object sender, KeyEventArgs e)
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

                if (args != null)

                { dataGridView1_CellClick(dataGridView1, args); }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }
    }
}
