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

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class CostsCenterFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public CostsCenterFrm()
        {
            InitializeComponent();
        }

        private void CostsCenterFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_CostCenters.ToList();
            dataGridView1.Columns["Name"].HeaderText = "المركز";

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
                var result = FsDb.Tbl_CostCenters.SingleOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                IDtxt.Text = xcatid.ToString();
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_CostCenters.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Nametxt.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_CostCenters.SingleOrDefault(x => x.ID == xcatid);
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
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 8 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView1.RowCount;
                    if (xrows != 0 && Nametxt.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا المركز  ؟", "حدف مركز ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_CostCenters.Find(xcatid);
                            FsDb.Tbl_CostCenters.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 

                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف مركز تكلفة",
                                TableName = "Tbl_CostCenters",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "CostCentersFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
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
                        MessageBox.Show("من فضلك حدد المركز المراد حدفه");
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  مركز تكلفة .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المركز لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل المركز ");
            }
            else
            {
                int xrows = dataGridView1.RowCount;
                if (IDtxt.Text == "" && Nametxt.Text != "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 8 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_CostCenters CatF = new Tbl_CostCenters
                        {
                            Name = Nametxt.Text,

                        };
                        FsDb.Tbl_CostCenters.Add(CatF);
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مركز تكلفة",
                            TableName = "Tbl_CostCenters",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "CostCentersFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        FsDb.SaveChanges();
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_CostCenters.ToList();
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  مركز تكلفة .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 8 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(IDtxt.Text);
                        var result = FsDb.Tbl_CostCenters.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 

                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل مركز تكلفة",
                            TableName = "Tbl_CostCenters",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "CostCentersFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = FsDb.Tbl_CostCenters.ToList();
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  مركز تكلفة .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }


        }
    }

}
