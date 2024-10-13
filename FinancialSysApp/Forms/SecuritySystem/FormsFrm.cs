using FinancialSysApp.DataBase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.SecuritySystem
{

    public partial class FormsFrm : Form
    {
        Model1 FsDb = new Model1();
        int xcatid;
        public FormsFrm()
        {
            InitializeComponent();
        }

        private void FormsFrm_Load(object sender, EventArgs e)
        {
            var list = FsDb.Tbl_Forms.ToList();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Name"].HeaderText = "النافده";
            dataGridView1.Columns["Name_English"].HeaderText = "Form";
            dataGridView1.Columns["Name"].Width = 150;
            dataGridView1.Columns["Name_English"].Width = 120;
            dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["Tbl_Form_SysUnites"].Visible = false;
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                xcatid = 0;
                Nametxt.Text = "";
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_Forms.SingleOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                textBox1.Text = result.Name_English;
                IDtxt.Text = xcatid.ToString();
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (IDtxt.Text == "")
            {
                dataGridView1.DataSource = FsDb.Tbl_Forms.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
                textBox1.Text = "";
            }
            else if (Nametxt.Text == "")
            {
                IDtxt.Text = "";
                textBox1.Text = "";
                dataGridView1.DataSource = FsDb.Tbl_Forms.ToList();
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل النافده ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {
                int xrows = dataGridView1.RowCount;
                if (IDtxt.Text == "" && Nametxt.Text != "")


                {
                    Tbl_Forms CatF = new Tbl_Forms
                    {
                        Name = Nametxt.Text,
                        Name_English = textBox1.Text

                    };
                    FsDb.Tbl_Forms.Add(CatF);
                    FsDb.SaveChanges();
                    MessageBox.Show("تم الحفظ");
                    dataGridView1.DataSource = FsDb.Tbl_Forms.ToList();
                    textBox1.Text = "";
                    Nametxt.Text = "";
                    IDtxt.Text = "";
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                }
                else
                {
                    xcatid = int.Parse(IDtxt.Text);
                    var result = FsDb.Tbl_Forms.SingleOrDefault(x => x.ID == xcatid);
                    result.Name = Nametxt.Text;
                    result.Name_English = textBox1.Text;
                    FsDb.SaveChanges();
                    MessageBox.Show("تم التعديل");
                    dataGridView1.DataSource = FsDb.Tbl_Forms.ToList();
                    textBox1.Text = "";
                    Nametxt.Text = "";
                    IDtxt.Text = "";
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                }
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int xrows = dataGridView1.RowCount;
                if (xrows != 0 && Nametxt.Text != "")
                {
                    var result1 = MessageBox.Show("هل تريد حدف هدا النافده  ؟", "حدف  نافده ", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        var result = FsDb.Tbl_Forms.Find(xcatid);
                        FsDb.Tbl_Forms.Remove(result);
                        FsDb.SaveChanges();
                        MessageBox.Show("  تم الحدف");
                    }
                    textBox1.Text = "";
                    Nametxt.Text = "";
                    IDtxt.Text = "";
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك حدد النافده المراد حدفه");
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                }
            }
            catch


            {
                MessageBox.Show("هذه الصفحه لايمكن حذفها لوجود اجراءات لها", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            xcatid = 0;
            Nametxt.Text = "";
            //if (dataGridView1.SelectedRows.Count != 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            //    row.Cells["ID"].Value
            //}

            xcatid = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());

            var result = FsDb.Tbl_Forms.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            textBox1.Text = result.Name_English;
            IDtxt.Text = xcatid.ToString();
        }
    }

}
