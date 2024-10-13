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
    public partial class AccountingRestrictions_KindFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public AccountingRestrictions_KindFrm()
        {
            InitializeComponent();
        }



        private void AccountingRestrictions_KindFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_AccountingRestrictions_Kind.ToList();
            dataGridView1.Columns["Name"].HeaderText = "النوع";
            dataGridView1.Columns["Name"].Width = 420;
            dataGridView1.Columns["ID"].Visible = false;
            textBox1.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_AccountingRestrictions_Kind.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            textBox1.Text = xcatid.ToString();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_AccountingRestrictions_Kind.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            textBox1.Text = xcatid.ToString();
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_AccountingRestrictions_Kind.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
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
                MessageBox.Show("من فضلك ادخل التصنيف ");
            }
            else
            {

                int xrows = dataGridView1.RowCount;
                if (xrows == 0 && textBox1.Text == "")


                {
                    //********************انشاء جديد  
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 16 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_AccountingRestrictions_Kind ACrkF = new Tbl_AccountingRestrictions_Kind
                        {
                            Name = Nametxt.Text,

                        };
                        FsDb.Tbl_AccountingRestrictions_Kind.Add(ACrkF);
                        FsDb.SaveChanges();
                        int Vint_LastRowId = ACrkF.ID;
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_AccountingRestrictions_Kind.ToList();
                        textBox1.Text = "";
                        Nametxt.Text = "";

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة نوع قيد",
                            TableName = "Tbl_AccountingRestrictions_Kind",
                            TableRecordId = Vint_LastRowId.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "AccountingRestrictions_KindFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);

                        FsEvDb.SaveChanges();
                    }


                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة نوع القيد .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationUpdateUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 16 && w.ProcdureId == 3);
                    if (validationUpdateUser != null)
                    {
                        xcatid = int.Parse(textBox1.Text);
                        var result = FsDb.Tbl_AccountingRestrictions_Kind.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = FsDb.Tbl_AccountingRestrictions_Kind.ToList();
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل نوع القيد",
                            TableName = "Tbl_AccountingRestrictions_Kind",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "AccountingRestrictions_KindFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //-------------------------
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل نوع القيد .. برجاء مراجعة مدير المنظومه");
                    }

                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationUpdateUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 16 && w.ProcdureId == 4);
                if (validationUpdateUser != null)
                {
                    int xrows = dataGridView1.RowCount;
                    if (textBox1.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا النوع  ؟", "حدف نوع ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {


                            var result = FsDb.Tbl_AccountingRestrictions_Kind.Find(xcatid);
                            FsDb.Tbl_AccountingRestrictions_Kind.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حدف نوع القيد",
                                TableName = "Tbl_AccountingRestrictions_Kind",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "AccountingRestrictions_KindFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //-------------------------
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
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حدف نوع القيد .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا النوع لايمكن حذفه لوجود مستندات تابعه له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
