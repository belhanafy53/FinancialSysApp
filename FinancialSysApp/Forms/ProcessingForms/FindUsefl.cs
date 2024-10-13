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
    public partial class FindUsefl : DevExpress.XtraEditors.XtraForm
    {
        public static DataGridViewRow SelectedRow { get; set; }
        public FindUsefl()
        {
            InitializeComponent();
        }

        private void FindUsefl_Load(object sender, EventArgs e)
        {
            SelectedRow = null;
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Beneficiary' table. You can move, or remove it, as needed.
            this.tbl_BeneficiaryTableAdapter.Fill(this.financialSysDataSet.Tbl_Beneficiary);
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
                this.tbl_BeneficiaryTableAdapter.FillByName(this.financialSysDataSet.Tbl_Beneficiary,textBox1.Text );
            }
            catch { };
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

        private void FindUsefl_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.tbl_BeneficiaryTableAdapter1.FillParenID(this.dataSet1.Tbl_Beneficiary, Convert.ToInt32(SelectedRow.Cells[0].Value.ToString()));
            }
            catch { }
            //if (dataGridViewX1.Rows.Count > 0)
            //{
            //    this.Close();
            //}
            //if (dataGridViewX1.Rows.Count == 0)
            //{
            //    DocumentBenefcairyFrm f = new DocumentBenefcairyFrm();
                
            //    if ((Application.OpenForms["DocumentBenefcairyFrm"] as DocumentBenefcairyFrm != null))
            //    {

            //        f.BringToFront();
            //        f.UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
            //        f.UsFulID.Text = FindUsefl.SelectedRow.Cells[0].Value.ToString();
            //        f.dataGridView1.Rows.Add(f.UsFul.Text, f.textBox4.Text, f.textBox1.Text, f.textBox1.Text, f.UsFulID.Text, null, true);

            //        f.simpleButton1_Click(sender, e);
            //        //f.Close();
            //    }
                
                

               
                //this.Close();
               
            //}
        }

        private void FindUsefl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow = null;
                this.Close();
            }
        }
    }
}