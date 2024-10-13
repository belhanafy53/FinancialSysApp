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
    public partial class BeneficiaryKindFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public BeneficiaryKindFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 39 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_BeneficiaryKind CatF = new Tbl_BeneficiaryKind
                        {
                            Name = Nametxt.Text,

                        };
                        FsDb.Tbl_BeneficiaryKind.Add(CatF);

                        FsDb.SaveChanges();

                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة نوع مستفيد",
                            TableName = "Tbl_BeneficiaryKind",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "BeneficiaryKindFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_BeneficiaryKind.ToList();
                        Nametxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  نوع مستفيد .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 39 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(textBox1.Text);
                        var result = FsDb.Tbl_BeneficiaryKind.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل نوع مستفيد",
                            TableName = "Tbl_BeneficiaryKind",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "BeneficiaryKindFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = FsDb.Tbl_BeneficiaryKind.ToList();
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  نوع مستفيد .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 39 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView1.RowCount;
                    if (xrows != 0 && textBox1.Text != "")
                    {
                        var result = FsDb.Tbl_BeneficiaryKind.Find(xcatid);
                        FsDb.Tbl_BeneficiaryKind.Remove(result);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 

                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف نوع مستفيد",
                            TableName = "Tbl_BeneficiaryKind",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "BeneficiaryKindFrm"


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
                    MessageBox.Show("ليس لديك صلاحية حذف  نوع مستفيد .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا النوع لايمكن حذفه لوجود مستفيدين له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BeneficiaryKindFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_BeneficiaryKind.ToList();
            textBox1.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_BeneficiaryKind.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            textBox1.Text = xcatid.ToString();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_BeneficiaryKind.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            textBox1.Text = xcatid.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_BeneficiaryKind.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }
    }
}
