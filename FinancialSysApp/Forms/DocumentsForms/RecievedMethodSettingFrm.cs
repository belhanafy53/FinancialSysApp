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

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class RecievedMethodSettingFrm : DevExpress.XtraEditors.XtraForm
    {
        public RecievedMethodSettingFrm()
        {
            InitializeComponent();
        }

        private void tbl_RecievedMethodBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_RecievedMethodBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void RecievedMethodSettingFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Tbl_RecievedMethod' table. You can move, or remove it, as needed.
            this.tbl_RecievedMethodTableAdapter.Fill(this.dataSet1.Tbl_RecievedMethod);
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtsearchitem.Text != string.Empty && textBox1.Text !=string.Empty )
            {
                if (checkEdit1.Checked !=false || checkEdit1.Checked==false )
                {
                    this.Validate();
                    this.tbl_RecievedMethodBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.dataSet1);
                    MessageBox.Show("تم الحفظ بنجاح");
                    txtsearchitem.Enabled = false;
                    textBox1.Enabled = false;
                    checkEdit1.Enabled = false;
                    checkEdit2.Enabled = false;
                    simpleButton1.Enabled = true;
                    simpleButton2.Enabled = false;
                }
                else
                {
                    MessageBox.Show("الرجاء اختر المدة أولا");
                }
            }
            else
            {
                MessageBox.Show("الرجاء ادخل البيانات أولا");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            checkEdit1.Checked = true;
            checkEdit2.Checked = true;
            checkEdit1.Checked = false;
            checkEdit2.Checked = false;
            simpleButton2.Enabled = true;
            simpleButton1.Enabled = false ;
            txtsearchitem.Enabled = true;
           
            checkEdit1.Enabled = true;
            checkEdit2.Enabled = true;
            this.tbl_RecievedMethodBindingSource.AddNew();
            txtsearchitem.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(dataGridView1.Rows.Count >0)
            {
                simpleButton3.Enabled = true;
                txtsearchitem.Enabled = true;
                textBox1.Enabled = true;
                checkEdit1.Enabled = true;
                checkEdit2.Enabled = true;
                simpleButton2.Enabled = false;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_RecievedMethodBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);
            MessageBox.Show("تم التعديل بنجاح");
            txtsearchitem.Enabled = false;
            textBox1.Enabled = false;
            checkEdit1.Enabled = false;
            checkEdit2.Enabled = false;
            simpleButton3.Enabled = false;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEdit1.Checked==true && checkEdit1.Enabled == true)
            {
                checkEdit2.Checked = false;
                textBox1.Enabled = true;
                textBox1.Focus();
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true && checkEdit2.Enabled  == true )
            {
                checkEdit1.Checked = false;
                textBox1.Enabled = true;
                textBox1.Focus();
            }
        }
    }
}