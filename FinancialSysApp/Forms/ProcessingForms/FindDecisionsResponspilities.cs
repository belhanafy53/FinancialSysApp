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
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindDecisionsResponspilities : DevExpress.XtraEditors.XtraForm
    {
        DateTime Vdate_decisionDate = Convert.ToDateTime(DateTime.Now.ToString());
        public static DataGridViewRow SelectedRow { get; set; }

        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
       
        public FindDecisionsResponspilities()
        {
            InitializeComponent();
        }

        private void FindDecisionsResponspilities_Load(object sender, EventArgs e)
        {
            int Vint_ResDecicionNID = int.Parse(textEdit1.Text);
            comboBox1.SelectedValue = Vint_ResDecicionNID;
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_DecisionsResponspilities' table. You can move, or remove it, as needed.
           
            comboBox1.DataSource = FsDb.Tbl_ResponspilityCenters.OrderBy(x => x.ID).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            dataGridView1.DataSource = FsDb.Tbl_DecisionsResponspilities.Where(x=>x.ResponspilityCentersID == Vint_ResDecicionNID).OrderBy(x => x.DecisionDate).ToList(); 
            
            txtDecisionNo.Select();
            this.ActiveControl = txtDecisionNo;
            txtDecisionNo.Focus();


        }

       

        private void txtDecisionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtptxtDecisionDate.Focus();
            }
        }

        private void dtptxtDecisionDate_KeyDown(object sender, KeyEventArgs e)
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }

        private void dtptxtDecisionDate_ValueChanged(object sender, EventArgs e)
        {
            this.tbl_DecisionsResponspilitiesTableAdapter.FillByDecisionNoDate(this.financialSysDataSet.Tbl_DecisionsResponspilities, txtDecisionNo.Text, dtptxtDecisionDate.Value.ToString(), int.Parse(textEdit1.Text));
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        

        private void txtDecisionNo_TextChanged(object sender, EventArgs e)
        {

          


        }

        private void txtDecisionNo_EditValueChanged(object sender, EventArgs e)
        {
            int vint_cmbDecRepId = int.Parse(textEdit1.Text);
            if (txtDecisionNo.Text != "")
            {
               
                var list = FsDb.Tbl_DecisionsResponspilities.Where(x => x.DecisionNO.Contains(txtDecisionNo.Text) && x.ResponspilityCentersID == vint_cmbDecRepId).ToList();
                dataGridView1.DataSource = list;
            }
            else
            {
                var list = FsDb.Tbl_DecisionsResponspilities.Where(x => x.ResponspilityCentersID == vint_cmbDecRepId).ToList();
                dataGridView1.DataSource = list;
                //this.tbl_DecisionsResponspilitiesTableAdapter.FillByRespID(this.financialSysDataSet.Tbl_DecisionsResponspilities, int.Parse(textEdit1.Text));
            }
        }
    }
}