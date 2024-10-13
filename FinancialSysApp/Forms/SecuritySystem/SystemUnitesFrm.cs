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
    public partial class SystemUnitesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public SystemUnitesFrm()
        {
            InitializeComponent();
        }

        private void SystemUnitesFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_SystemUnites.ToList();
            dataGridView1.Columns["Name"].HeaderText = "الوحده";

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
                var result = FsDb.Tbl_SystemUnites.SingleOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                IDtxt.Text = xcatid.ToString();
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_SystemUnites.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Nametxt.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_SystemUnites.SingleOrDefault(x => x.ID == xcatid);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 20 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                int xrows = dataGridView1.RowCount;
            if (xrows != 0 && Nametxt.Text != "")
            {
                var result1 = MessageBox.Show("هل تريد حدف هده الوحده  ؟", "حدف وحده ", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    var result = FsDb.Tbl_SystemUnites.Find(xcatid);
                    FsDb.Tbl_SystemUnites.Remove(result);
                    FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = int.Parse(CatF.ID.ToString());
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف وحدة منظومة",
                            TableName = "Tbl_SystemUnites",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "SystemUnitesFrm"


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
                MessageBox.Show("من فضلك حدد الوحده المراد حدفه");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  وحدة منظومة  .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اوحده ");
            }
            else
            {
                int xrows = dataGridView1.RowCount;
                if (IDtxt.Text == "" && Nametxt.Text != "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 20 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_SystemUnites CatF = new Tbl_SystemUnites
                    {
                        Name = Nametxt.Text,

                    };
                    FsDb.Tbl_SystemUnites.Add(CatF);
                    FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = int.Parse(CatF.ID.ToString());
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة وحدة منظومة",
                            TableName = "Tbl_SystemUnites",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "SystemUnitesFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحفظ");
                    dataGridView1.DataSource = FsDb.Tbl_SystemUnites.ToList();
                    Nametxt.Text = "";
                    IDtxt.Text = "";
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  وحدة منظومة  .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 20 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(IDtxt.Text);
                    var result = FsDb.Tbl_SystemUnites.SingleOrDefault(x => x.ID == xcatid);
                    result.Name = Nametxt.Text;
                    FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = int.Parse(CatF.ID.ToString());
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل وحدة منظومة",
                            TableName = "Tbl_SystemUnites",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "SystemUnitesFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                    dataGridView1.DataSource = FsDb.Tbl_SystemUnites.ToList();
                    Nametxt.Text = "";
                    IDtxt.Text = "";
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل   وحدة منظومة  .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }
    }
}
