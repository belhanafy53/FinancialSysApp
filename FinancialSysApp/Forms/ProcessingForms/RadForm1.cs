using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_AccountingRestrictionItems' table. You can move, or remove it, as needed.
            //this.tbl_AccountingRestrictionItemsTableAdapter.Fill(this.financialSysDataSet.Tbl_AccountingRestrictionItems);
            try
            {
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_NormativeCosts' table. You can move, or remove it, as needed.
                //this.tbl_NormativeCostsTableAdapter.Fill(this.financialSysDataSet.Tbl_NormativeCosts);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Activities' table. You can move, or remove it, as needed.
                this.tbl_ActivitiesTableAdapter.Fill(this.financialSysDataSet.Tbl_Activities);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ExchangeCenter' table. You can move, or remove it, as needed.
                this.tbl_ExchangeCenterTableAdapter.Fill(this.financialSysDataSet.Tbl_ExchangeCenter);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Accounting_Guid' table. You can move, or remove it, as needed.
                this.tbl_Accounting_GuidTableAdapter.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);
                this.tblNormativeCostsBindingSource.AddNew();
                radMultiColumnComboBox1.Focus();
                radMultiColumnComboBox3.SelectedIndex = -1;
                radMultiColumnComboBox4.SelectedIndex = -1;
            }
            catch { }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radCheckBox2_CheckStateChanged(object sender, EventArgs e)
        {
            string x = "";
            if (radCheckBox2.Checked == true)
            {
                radCheckBox1.Checked = false;
                radMultiColumnComboBox3.Enabled = true;
                radMultiColumnComboBox4.Enabled = false;
                x = "تكلفة";
                textBox1.Text = x;
            }
        }

        private void radCheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            string x = "";
            if (radCheckBox1.Checked == true)
            {
                radCheckBox2.Checked = false;
                radMultiColumnComboBox4.Enabled = true;
                radMultiColumnComboBox3.Enabled = false;
                x = "نشاط";
                textBox1.Text = x;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            this.Validate();
            this.tblNormativeCostsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.financialSysDataSet);
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void radMultiColumnComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //decimal x ;
                if (radMultiColumnComboBox3.Enabled == true)
                {
                    radMultiColumnComboBox3.Focus();
                }
                if (radMultiColumnComboBox4.Enabled == true)
                {
                    radMultiColumnComboBox4.Focus();
                }

                tt.Text = this.tbl_AccountingRestrictionItemsTableAdapter.ScalarQuery(int.Parse(radMultiColumnComboBox1.SelectedValue.ToString())).ToString();
                //if(Convert.ToDecimal(tt.Text)<0)
                //{
                //   x = Convert.ToDecimal(tt.Text) * -1;
                //    tt.Text = Convert.ToString(x);
                //}
            }
        }

        private void radMultiColumnComboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Text = radMultiColumnComboBox3.SelectedValue.ToString();
                radTextBox1.Focus();
            }

        }

        private void radTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                string x = "";
                this.tblNormativeCostsBindingSource.AddNew();
                if (radCheckBox1.Checked == true)
                {
                    radCheckBox2.Checked = false;
                    radMultiColumnComboBox4.Enabled = true;
                    radMultiColumnComboBox3.Enabled = false;
                    x = "نشاط";
                    textBox1.Text = x;
                }
               
                if (radCheckBox2.Checked == true)
                {
                    radCheckBox1.Checked = false;
                    radMultiColumnComboBox3.Enabled = true;
                    radMultiColumnComboBox4.Enabled = false;
                    x = "تكلفة";
                    textBox1.Text = x;
                }
                radMultiColumnComboBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tblNormativeCostsBindingSource.AddNew();
        }

        private void radMultiColumnComboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Text = radMultiColumnComboBox4.SelectedValue.ToString();
                radTextBox1.Focus();
            }
        }
    }
}
