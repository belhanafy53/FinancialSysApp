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
using DevExpress.XtraEditors;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class SpecificationItemsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public SpecificationItemsFrm()
        {
            InitializeComponent();
        }

        private void SpecificationItemsFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from sk in FsDb.Tbl_SpecificationItems


                                        select new
                                        {
                                            ID = sk.ID,
                                            Name = sk.Name,
                                        }).OrderByDescending(x => x.ID).ToList();
            
            dataGridView1.Columns["Name"].HeaderText = "البند";
            //dataGridView1.Columns["TaxAuthority_Code"].HeaderText = "كود الماموريه";
            dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["Tbl_Supplier"].Visible = false;
            dataGridView1.Columns["Name"].Width = 200;
            ////dataGridView1.Columns["TaxAuthority_Code"].Width = 100;
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
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_SpecificationItems.FirstOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                //CodeTxt.Text = result.TaxAuthority_Code;
                textBox1.Text = xcatid.ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_SpecificationItems.FirstOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            //CodeTxt.Text = result.TaxAuthority_Code;
            textBox1.Text = xcatid.ToString();
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from sk in FsDb.Tbl_SpecificationItems

                                        where (sk.Name.Contains(Nametxt.Text))

                                        select new
                                        {
                                            ID = sk.ID,
                                            Name = sk.Name,
                                        }).OrderByDescending(x => x.ID).ToList();

            dataGridView1.Columns["Name"].HeaderText = "البند";
            //dataGridView1.Columns["TaxAuthority_Code"].HeaderText = "كود الماموريه";
            dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["Tbl_Supplier"].Visible = false;
            dataGridView1.Columns["Name"].Width = 200;
            //FsDb.Tbl_SpecificationItems.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show("من فضلك ادخل البند ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }

            else
            {
                int xrows = dataGridView1.RowCount;
                if (xrows == 0 && textBox1.Text == "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 137 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_SpecificationItems taxaF = new Tbl_SpecificationItems
                        {
                            Name = Nametxt.Text,
                            //TaxAuthority_Code = CodeTxt.Text

                        };
                        FsDb.Tbl_SpecificationItems.Add(taxaF);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند رئيسي للمستخلصات",
                            TableName = "Tbl_SpecificationItems",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنود الرئيسيه للمستخلصات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = (from sk in FsDb.Tbl_SpecificationItems

                                                    

                                                    select new
                                                    {
                                                        ID = sk.ID,
                                                        Name = sk.Name,
                                                    }).OrderByDescending(x => x.ID).ToList();

                        dataGridView1.Columns["Name"].HeaderText = "البند";
                        //dataGridView1.Columns["TaxAuthority_Code"].HeaderText = "كود الماموريه";
                        dataGridView1.Columns["ID"].Visible = false;
                        //dataGridView1.Columns["Tbl_Supplier"].Visible = false;
                        dataGridView1.Columns["Name"].Width = 200;
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        //CodeTxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  نوع تربه .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 137 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(textBox1.Text);
                        var result = FsDb.Tbl_SpecificationItems.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        //result.TaxAuthority_Code = CodeTxt.Text;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بند رئيسي للمستخلصات",
                            TableName = "Tbl_SpecificationItems",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنود الرئيسيه للمستخلصات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = (from sk in FsDb.Tbl_SpecificationItems



                                                    select new
                                                    {
                                                        ID = sk.ID,
                                                        Name = sk.Name,
                                                    }).OrderByDescending(x => x.ID).ToList();

                        dataGridView1.Columns["Name"].HeaderText = "البند";
                        //dataGridView1.Columns["TaxAuthority_Code"].HeaderText = "كود الماموريه";
                        dataGridView1.Columns["ID"].Visible = false;
                        //dataGridView1.Columns["Tbl_Supplier"].Visible = false;
                        dataGridView1.Columns["Name"].Width = 200;
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        //CodeTxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل بند .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 137 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                int xrows = dataGridView1.RowCount;

                if (xrows != 0 && textBox1.Text != "")
                {
                    var result1 = MessageBox.Show("هل تريد حدف هدا البند  ؟", "حدف بنده ", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {

                        if (xrows != 0 && textBox1.Text != "")
                        {
                            var result = FsDb.Tbl_SpecificationItems.Find(xcatid);
                            FsDb.Tbl_SpecificationItems.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRow = taxaF.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف البند",
                                TableName = "Tbl_SpecificationItems",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة البنود الرئيسيه للمستخلصات"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("  تم الحدف");
                            dataGridView1.DataSource = (from sk in FsDb.Tbl_SpecificationItems



                                                        select new
                                                        {
                                                            ID = sk.ID,
                                                            Name = sk.Name,
                                                        }).OrderByDescending(x => x.ID).ToList();

                            dataGridView1.Columns["Name"].HeaderText = "البند";
                            //dataGridView1.Columns["TaxAuthority_Code"].HeaderText = "كود الماموريه";
                            dataGridView1.Columns["ID"].Visible = false;
                            //dataGridView1.Columns["Tbl_Supplier"].Visible = false;
                            dataGridView1.Columns["Name"].Width = 200;
                            textBox1.Text = "";
                            Nametxt.Text = "";
                            //CodeTxt.Text = "";
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("من فضلك حدد البند المراد حدفه");
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  نوع تربه .. برجاء مراجعة مدير المنظومه");
            }
        }
    }
}