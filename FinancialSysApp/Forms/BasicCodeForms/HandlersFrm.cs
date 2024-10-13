using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class HandlersFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_Hndid = 0;
        int Vint_empId = 0;
        public HandlersFrm()
        {
            InitializeComponent();
        }

        private void HandlersFrm_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView1.DataSource = FsDb.Tbl_Employee.Take(50).OrderBy(x => x.Name).ToList();
            groupBox2.Text = "الموظفين";
            dataGridView1.Columns["Name"].HeaderText = "الموظف";
            dataGridView1.Columns["Workerjob"].HeaderText = "الوظيفه";
            dataGridView1.Columns["NationalId"].Visible = false;
            dataGridView1.Columns["Management_ID"].Visible = false;
            dataGridView1.Columns["GenderID"].Visible = false;
            dataGridView1.Columns["Tbl_User"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Tbl_Beneficiary"].Visible = false;
            //dataGridView1.Columns["Tbl_OrderHandler"].Visible = false;
            dataGridView1.Columns["Tbl_User_SysUnites"].Visible = false;
            dataGridView1.Columns["Name"].Width = 400;
            textBox1.Visible = true;

            var list = FsDb.Tbl_Handler.ToList();

            dataGridView2.DataSource = list;
            dataGridView2.Columns["Name"].HeaderText = "المناول";
            dataGridView2.Columns["Employee_ID"].Visible = false;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["Tbl_OrderHandlers"].Visible = false;
            dataGridView2.Columns["Tbl_Employee"].Visible = false;
            dataGridView2.Columns["TBL_Document"].Visible = false;
            dataGridView2.Columns["Name"].Width = 220;

            textBox1.Select();
            this.ActiveControl = textBox1;
            
          
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var list = (from Emp in FsDb.Tbl_Employee
                        where (Emp.Name.Contains(textBox1.Text))
                        select new
                        {
                            ID = Emp.ID,
                            Name = Emp.Name,
                            NationalId = Emp.NationalId,
                        }).Take(30).OrderBy(t => t.Name).ToList();

           
            dataGridView2.DataSource = FsDb.Tbl_Handler.Where(x => x.Name.Contains(textBox1.Text)).ToList();
            dataGridView2.Visible = true;
            dataGridView2.Columns["Name"].HeaderText = "المناول";
            dataGridView2.Columns["Employee_ID"].Visible = false;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["Tbl_OrderHandlers"].Visible = false;
            dataGridView2.Columns["Tbl_Employee"].Visible = false;
            dataGridView2.Columns["TBL_Document"].Visible = false;
            dataGridView2.Columns["Name"].Width = 220;

            
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vint_empId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                txtEmp.Text = Vint_empId.ToString();
                var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(x => x.ID == Vint_empId);
                textBox1.Text = resultEmp.Name;

                var resultBenf = FsDb.Tbl_Handler.SingleOrDefault(x => x.Employee_ID == Vint_empId);
                if (resultBenf == null)
                {
                    textBox2.Text = "";

                }
                else
                {
                    textBox2.Text = resultBenf.ID.ToString();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Vint_empId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtEmp.Text = Vint_empId.ToString();
            var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(x => x.ID == Vint_empId);
            textBox1.Text = resultEmp.Name;

            var resultBenf = FsDb.Tbl_Handler.SingleOrDefault(x => x.Employee_ID == Vint_empId);
            if (resultBenf == null)
            {
                textBox2.Text = "";

            }
            else
            {
                textBox2.Text = resultBenf.ID.ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المناول او قم بإختياره من القائمه ");
            }
            else
            {
                if (textBox2.Text == "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 42 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        //Vint_Hndid = int.Parse(textBox2.Text);
                        Vint_empId = int.Parse(txtEmp.Text);
                        Tbl_Handler Hndl = new Tbl_Handler
                        {
                            Name = textBox1.Text,
                            Employee_ID = Vint_empId
                        };

                        FsDb.Tbl_Handler.Add(Hndl);
                        FsDb.SaveChanges();
                        int Vint_LastRow = Hndl.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مناول",
                            TableName = "Tbl_Handler",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "HandlersFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحفظ");
                        textBox1.Text = "";
                        txtEmp.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        dataGridView2.Visible = true;
                        dataGridView2.DataSource = FsDb.Tbl_Handler.ToList();
                        textBox1.Focus();
                    }

                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  مناول .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (textBox2.Text != "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 42 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        Vint_Hndid = int.Parse(textBox2.Text);
                        Vint_empId = int.Parse(txtEmp.Text);
                        var result = FsDb.Tbl_Handler.SingleOrDefault(x => x.ID == Vint_Hndid);
                        result.Name = textBox1.Text;
                        result.Employee_ID = Vint_empId;
                        
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل مناول",
                            TableName = "Tbl_Handler",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "HanlersFrm"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        textBox1.Text = "";
                        txtEmp.Text = "";
                        textBox2.Text = "";
                        this.ActiveControl = textBox1;
                        dataGridView2.Visible = true;
                        dataGridView2.DataSource = FsDb.Tbl_Handler.ToList();
                        textBox1.Focus();

                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  مناول .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 4 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView1.RowCount;

                    if (xrows != 0 && textBox2.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا المناول  ؟", "حدف مناول ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {

                            Vint_Hndid = int.Parse(textBox2.Text);
                            var resultR = FsDb.Tbl_Handler.Find(Vint_Hndid);
                            FsDb.Tbl_Handler.Remove(resultR);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف مناول",
                                TableName = "Tbl_Handler",
                                TableRecordId = resultR.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "HanlersFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //************************************
                            MessageBox.Show("  تم الحدف");
                        }
                        textBox1.Text = "";
                        txtEmp.Text = "";
                        textBox2.Text = "";


                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        dataGridView2.Visible = true;
                        dataGridView2.DataSource = FsDb.Tbl_Handler.ToList();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد المناول المراد حدفه");
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  مناول .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المناول لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            Vint_empId = int.Parse(dataGridView2.CurrentRow.Cells["Employee_ID"].Value.ToString());
            txtEmp.Text = Vint_empId.ToString();
            var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(x => x.ID == Vint_empId);
            textBox1.Text = resultEmp.Name;

            var resultBenf = FsDb.Tbl_Handler.SingleOrDefault(x => x.Employee_ID == Vint_empId);
            if (resultBenf == null)
            {
                textBox2.Text = "";

            }
            else
            {
                textBox2.Text = resultBenf.ID.ToString();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
