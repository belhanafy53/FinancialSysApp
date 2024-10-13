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
using UserRoles;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class ItemsTreasurCategoryFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid = 0;
        public ItemsTreasurCategoryFrm()
        {
            InitializeComponent();
        }

        private void ItemsTreasurCategoryFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_TreasuryItems.ToList();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "التصنيف";
            dataGridView1.Columns["Tbl_Treasury"].Visible = false;
            dataGridView1.Columns["Tbl_ItemsTreasureManagement"].Visible = false;
            //dataGridView1.Columns[""].Visible = false;
            dataGridView1.Columns["Name"].Width = 200;
            textBox1.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = "";
                if (dataGridView1.RowCount >= 1)
                {
                    xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var result = FsDb.Tbl_TreasuryItems.SingleOrDefault(x => x.ID == xcatid);
                    Nametxt.Text = result.Name;
                    textBox1.Text = xcatid.ToString();
                }
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_TreasuryItems.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            if (dataGridView1.RowCount >= 1)
            {
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_TreasuryItems.SingleOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                textBox1.Text = xcatid.ToString();
            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل التصنيف ");
            }
            else
            {
                int xrows = dataGridView1.RowCount;
                if (xrows == 0 && textBox1.Text == "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 111 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_TreasuryItems CatF = new Tbl_TreasuryItems
                        {
                            Name = Nametxt.Text,

                        };
                        FsDb.Tbl_TreasuryItems.Add(CatF);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة اضافة تصنيف بنود خزينه",
                            TableName = "Tbl_TreasuryItems",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة  تصنيف بنود خزينه"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_TreasuryItems.ToList();
                        Nametxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  النوع .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 111 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {

                        xcatid = int.Parse(textBox1.Text);
                        var result = FsDb.Tbl_TreasuryItems.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 

                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل تصنيف بنود خزينه",
                            TableName = "Tbl_TreasuryItems",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة  تصنيف بنود خزينه"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = FsDb.Tbl_TreasuryItems.ToList();
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  التصنيف .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 111 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView1.RowCount;
                    if (xrows != 0 && textBox1.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا التصنيف  ؟", "حدف تصنيف ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_TreasuryItems.Find(xcatid);
                            FsDb.Tbl_TreasuryItems.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 

                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف اضافة تصنيف بنود خزينه",
                                TableName = "Tbl_TreasuryItems",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة  تصنيف بنود خزينه"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("  تم الحدف");
                            textBox1.Text = "";
                            Nametxt.Text = "";
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();

                        }
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد النوع المراد حدفه");
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  تصنيف .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا التصنيف لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

