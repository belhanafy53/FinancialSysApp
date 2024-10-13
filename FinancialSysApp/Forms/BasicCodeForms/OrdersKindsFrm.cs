using DevExpress.CodeParser;
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
    public partial class OrdersKindsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid=0;
        int Vint_SysUnt = 0;
        public OrdersKindsFrm()
        {
            InitializeComponent();
        }

        private void OrdersKindsFrm_Load(object sender, EventArgs e)
        {
          var listStysUnit =   FsDb.Tbl_SystemUnites.Where(x => x.ID == 2 || x.ID == 3).ToList();
            comboBox1.DataSource = listStysUnit;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.SelectedText = "اختر الوحده";
            //dataGridView1.DataSource = FsDb.Tbl_OrderKind.ToList();
            //dataGridView1.Columns["Name"].HeaderText = "النوع";

            //dataGridView1.Columns["Name"].Width = 420;
            //dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["Tbl_Document"].Visible = false;
            Nametxt.Text = "";
            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nametxt.Text = "";
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_OrderKind.SingleOrDefault(x => x.ID == xcatid );
                Nametxt.Text = result.Name;
                IDtxt.Text = xcatid.ToString();
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_OrderKind.Where(x => x.Name.Contains(Nametxt.Text) && x.SystemUniteID == Vint_SysUnt).ToList();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Nametxt.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_OrderKind.SingleOrDefault(x => x.ID == xcatid);
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
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 11 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView1.RowCount;
                    if (xrows != 0 && Nametxt.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا النوع  ؟", "حدف نوع ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_OrderKind.Find(xcatid);
                            FsDb.Tbl_OrderKind.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRow = CatF.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف نوع امر",
                                TableName = "Tbl_OrderKind",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "OrderKindFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("  تم الحدف");
                           
                        }
                        dataGridView1.DataSource = FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Vint_SysUnt).ToList();
                        dataGridView1.Columns["Name"].HeaderText = "النوع";

                        dataGridView1.Columns["Name"].Width = 420;
                        dataGridView1.Columns["ID"].Visible = false;
                        dataGridView1.Columns["SystemUniteID"].Visible = false;
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد النوع المراد حدفه");
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  نوع امر .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا النوع لايمكن حذفه لوجود اوامر تابعه  له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر الوحده ");
            }
           else if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل النوع ");
            }
            else
            {
                int xrows = dataGridView1.RowCount;
                if (IDtxt.Text == "" && Nametxt.Text != "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 11 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_OrderKind CatF = new Tbl_OrderKind
                        {
                            Name = Nametxt.Text,
                            SystemUniteID = int.Parse(comboBox1.SelectedValue.ToString())
                        };
                        FsDb.Tbl_OrderKind.Add(CatF);
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة نوع امر",
                            TableName = "Tbl_OrderKind",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "OrderKindFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        FsDb.SaveChanges();
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Vint_SysUnt).ToList();
                        dataGridView1.Columns["Name"].HeaderText = "النوع";

                        dataGridView1.Columns["Name"].Width = 420;
                        dataGridView1.Columns["ID"].Visible = false;
                        dataGridView1.Columns["SystemUniteID"].Visible = false;
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  نوع امر .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 11 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(IDtxt.Text);
                        var result = FsDb.Tbl_OrderKind.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        result.SystemUniteID = int.Parse(comboBox1.SelectedValue.ToString());
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل نوع امر",
                            TableName = "Tbl_OrderKind",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "OrderKindFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Vint_SysUnt).ToList();
                        dataGridView1.Columns["Name"].HeaderText = "النوع";

                        dataGridView1.Columns["Name"].Width = 420;
                        dataGridView1.Columns["ID"].Visible = false;
                        dataGridView1.Columns["SystemUniteID"].Visible = false;
                        Nametxt.Text = "";
                        IDtxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  نوع امر .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }


        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nametxt.Focus();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
             Vint_SysUnt = int.Parse(comboBox1.SelectedValue.ToString());
          var list=  FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Vint_SysUnt).ToList();
            dataGridView1.DataSource = list;
        }
    }
}