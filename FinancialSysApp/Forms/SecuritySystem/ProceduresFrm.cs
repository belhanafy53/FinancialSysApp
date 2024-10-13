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

namespace FinancialSysApp.Forms.SecuritySystem
{
    public partial class ProceduresFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public ProceduresFrm()
        {
            InitializeComponent();
        }

        private void ProceduresFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_Procedures.ToList();
            dataGridView1.Columns["Name"].HeaderText = "الاجراء";

            dataGridView1.Columns["Name"].Width = 420;
            dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["Tbl_Document"].Visible = false;
            Nametxt.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nametxt.Text = "";
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_Procedures.SingleOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                IDtxt.Text = xcatid.ToString();
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_Procedures.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Nametxt.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_Procedures.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            IDtxt.Text = xcatid.ToString();
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
                MessageBox.Show("من فضلك ادخل الاجراء ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {

                int xrows = dataGridView1.RowCount;
                if (IDtxt.Text == "" && Nametxt.Text != "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 22 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_Procedures CatF = new Tbl_Procedures
                        {
                            Name = Nametxt.Text,

                        };
                        FsDb.Tbl_Procedures.Add(CatF);
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = int.Parse(CatF.ID.ToString());
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة اجراء",
                            TableName = "Tbl_Procedures",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "ProceduresFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        FsDb.SaveChanges();
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_Procedures.ToList();
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  اجراء  .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 22 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(IDtxt.Text);
                        var result = FsDb.Tbl_Procedures.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = int.Parse(CatF.ID.ToString());
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل اجراء",
                            TableName = "Tbl_Procedures",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "ProceduresFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = FsDb.Tbl_Procedures.ToList();
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  اجراء  .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 20 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView1.RowCount;
                    if (xrows != 0 && Nametxt.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا الاجراء  ؟", "حدف اجراء ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_Procedures.Find(xcatid);
                            FsDb.Tbl_Procedures.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRow = int.Parse(CatF.ID.ToString());
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف اجراء",
                                TableName = "Tbl_Procedures",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "ProceduresFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //************************************
                            MessageBox.Show("  تم الحدف");
                        }
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد الاجراء المراد حدفه");
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل  اجراء  .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا الاجراء لايمكن حذفه لوجود مستخدمين له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
