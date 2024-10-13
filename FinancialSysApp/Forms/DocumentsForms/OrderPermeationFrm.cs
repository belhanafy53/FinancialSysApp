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

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class OrderPermeationFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public OrderPermeationFrm()
        {
            InitializeComponent();
        }

        private void txtsearchitem_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Down)
            {

                Forms.FindStores  t = new Forms.FindStores();

                
                t.txtOrderId.Text = this.txtOrderId.Text;
                t.txtOrderNo.Text = this.txtOrderNo.Text;
                t.txtOrderSupName.Text  = this.txtOrderSupName.Text ;
                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.grpOrderData.Text = this.comboBox1.Text;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.ShowDialog();

                //if (Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow != null)
                //{
                //    txtResponsipilityDecisionID.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[0].Value.ToString();
                //    txtResponsipilityDecisionNo.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[1].Value.ToString();
                //    dtpResponsipilityDecision.Value = Convert.ToDateTime(Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[2].Value);
                //    txtForYear.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[3].Value.ToString();
                //}
                //simpleButton1.Focus();

            }
        }

        private void OrderPermeationFrm_Load(object sender, EventArgs e)
        {
            int Vint_orderid = int.Parse(txtOrderId.Text);
            var result = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vint_orderid);
            if (result.ImplementationPeriod.ToString() !="" ) { textBox9.Text = result.ImplementationPeriod.ToString(); }
            
            if (result.ImplementationPeriodFrom != "" && result.ImplementationPeriodFrom != null) { dtpimpdatefrom.Text = result.ImplementationPeriodFrom.ToString(); }
            if (result.ImplementationPeriodTo != "" && result.ImplementationPeriodTo != null) { dtpimpdateTo.Text = result.ImplementationPeriodTo.ToString(); }
            
            try
            {
                this.orderStoresTableAdapter.FillByOrder(this.dataSet1.OrderStores, int.Parse(txtOrderId.Text));
               

            }
            catch { }
            this.projectStorsTableAdapter.FillByOrder(this.dataSet11.ProjectStors, int.Parse(txtOrderId.Text));
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                textBox3.Text += " / " + dataGridView1.Rows[x].Cells[0].Value.ToString();
            }
            this.orderAssaysTableAdapter.Fill(this.dataSet12.OrderAssays, int.Parse(txtOrderId.Text));
            for (int x = 0; x < dataGridView2.Rows.Count; x++)
            {
                textBox4.Text += " / " + dataGridView2.Rows[x].Cells[1].Value.ToString();
            }
            this.orderStoresTableAdapter.FillByOrder(this.dataSet13.OrderStores, int.Parse(txtOrderId.Text));
            for (int x = 0; x < dataGridView3.Rows.Count; x++)
            {
                txtsearchitem.Text += " / " + dataGridView3.Rows[x].Cells[0].Value.ToString();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.FindProject t = new Forms.FindProject();






                t.txtOrderId.Text = this.txtOrderId.Text;
                t.txtOrderNo.Text = this.txtOrderNo.Text;
                t.txtOrderSupName.Text = this.txtOrderSupName.Text;
                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.grpOrderData.Text = this.comboBox1.Text;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.ShowDialog();

                //if (Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow != null)
                //{
                //    txtResponsipilityDecisionID.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[0].Value.ToString();
                //    txtResponsipilityDecisionNo.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[1].Value.ToString();
                //    dtpResponsipilityDecision.Value = Convert.ToDateTime(Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[2].Value);
                //    txtForYear.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[3].Value.ToString();
                //}
                //simpleButton1.Focus();

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.DocumentsForms.FindAssays  t = new Forms.DocumentsForms.FindAssays();






                t.txtOrderId.Text = this.txtOrderId.Text;
                t.txtOrderNo.Text = this.txtOrderNo.Text;
                t.txtOrderSupName.Text = this.txtOrderSupName.Text;
                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.grpOrderData.Text = this.comboBox1.Text;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.ShowDialog();
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.DocumentsForms.RecievedMethodSettingFrm f = new RecievedMethodSettingFrm();
            f.ShowDialog();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.DocumentsForms.FindRecievedMethod t = new DocumentsForms.FindRecievedMethod();






                t.txtOrderId.Text = this.txtOrderId.Text;
                t.txtOrderNo.Text = this.txtOrderNo.Text;
                t.txtOrderSupName.Text = this.txtOrderSupName.Text;
                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.grpOrderData.Text = this.comboBox1.Text;
                t.txtOrderSupName.Text = this.txtSupliers.Text;
                t.ShowDialog();

                //if (Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow != null)
                //{
                //    txtResponsipilityDecisionID.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[0].Value.ToString();
                //    txtResponsipilityDecisionNo.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[1].Value.ToString();
                //    dtpResponsipilityDecision.Value = Convert.ToDateTime(Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[2].Value);
                //    txtForYear.Text = Forms.DocumentsForms.FindManagementsItemsOrder.SelectedRow.Cells[3].Value.ToString();
                //}
                //simpleButton1.Focus();

            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpimpdatefrom.Focus();
            }
        }

       

      

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int Vint_orderid = int.Parse(txtOrderId.Text);
            var resultupdate = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vint_orderid);
            if (textBox9.Text != "") { resultupdate.ImplementationPeriod = short.Parse(textBox9.Text); }
            
            
            if (dtpimpdatefrom.Text != "")
            {
                resultupdate.ImplementationPeriodFrom = dtpimpdatefrom.Text;
            }
            if (dtpimpdateTo.Text != "")
            {
                resultupdate.ImplementationPeriodTo = dtpimpdateTo.Text;
            }
            
            FsDb.SaveChanges();
            MessageBox.Show("تم الحفظ");
        }

        private void dtpimpdatefrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpimpdateTo.Focus();
            }
        }

        private void dtpimpdateTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsearchitem.Focus();
            }
        }
    }
}