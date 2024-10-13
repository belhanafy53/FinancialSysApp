using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class RepresentiveFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_Hndid = 0;
        int Vint_empId = 0;
        int vint_RepKind = 0;
        int Vint_BranchID = 0;
        public RepresentiveFrm()
        {
            InitializeComponent();
        }
        private void grdEmployee()
        {
            dataGridView1.Columns["Name"].HeaderText = "الموظف";
            //dataGridView1.Columns["Workerjob"].HeaderText = "الوظيفه";
            dataGridView1.Columns["NationalId"].Visible = false;
            //dataGridView1.Columns["Management_ID"].Visible = false;
            //dataGridView1.Columns["GenderID"].Visible = false;
            //dataGridView1.Columns["Tbl_User"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["Tbl_Beneficiary"].Visible = false;
            //dataGridView1.Columns["Tbl_OrderHandler"].Visible = false;
            //dataGridView1.Columns["Tbl_User_SysUnites"].Visible = false;
            dataGridView1.Columns["Name"].Width = 400;
            textBox1.Visible = true;
        }
        //private void grdRepresentive()
        //{
        //    dataGridView2.Columns["Name"].HeaderText = "المندوبين";
        //    dataGridView2.Columns["Emp_ID"].Visible = false;
        //    dataGridView2.Columns["ID"].Visible = false;
        //    dataGridView2.Columns["Tbl_RepresentativeKind"].Visible = false;
        //    //dataGridView2.Columns["Tbl_Employee"].Visible = false;

        //    dataGridView2.Columns["Name"].Width = 220;
        //}
        private void RepresentiveFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Tbl_RepresentativeKind' table. You can move, or remove it, as needed.
            this.tbl_RepresentativeKindTableAdapter.Fill(this.bankCheques.Tbl_RepresentativeKind);
            dataGridView2.Visible = true;
            dataGridView1.DataSource = FsDb.Tbl_Employee.Take(50).OrderBy(x => x.Name).ToList();
            groupBox2.Text = "الموظفين";
            grdEmployee();

            var list = FsDb.Tbl_Representatives.ToList();
            dataGridView2.DataSource = list;
            grdReprsentive();

            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.SelectedText = "اختر نوع المندوب";

            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Today.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(DateTime.Today.AddYears(5).ToString());

            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();
        }
        private void grdReprsentive()
        {
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["Name"].Visible = true;


            dataGridView2.Columns["Emp_ID"].Visible = false;

            dataGridView2.Columns["RepresentativeKInd"].Visible = false;
            dataGridView2.Columns["BranchID"].Visible = false;

            dataGridView2.Columns["fromDate"].Visible = false;

            dataGridView2.Columns["RepStatus"].Visible = false;
            dataGridView2.Columns["ToDate"].Visible = false;
            dataGridView2.Columns["Name"].Width = 250;
            //dataGridView1.Columns["Tbl_ChequeKind"].Visible = true;
            dataGridView2.Columns["Tbl_RepresentativeKind"].Visible = false;

            dataGridView2.Columns["Name"].HeaderText = "اسم المندوب";
             

            
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


            dataGridView2.DataSource = FsDb.Tbl_Representatives.Where(x => x.Name.Contains(textBox1.Text) && x.RepresentativeKInd == vint_RepKind && x.BranchID == Vint_BranchID).ToList();
            dataGridView2.Visible = true;
            grdReprsentive();
            dataGridView1.DataSource = list;
            grdReprsentive();
            grdEmployee();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vint_empId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                txtEmp.Text = Vint_empId.ToString();
                var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(x => x.ID == Vint_empId);
                textBox1.Text = resultEmp.Name;

                var resultBenf = FsDb.Tbl_Representatives.FirstOrDefault(x => x.Emp_ID == Vint_empId);
                if (resultBenf == null)
                {
                    textBox2.Text = "";

                }
                else
                {
                    textBox2.Text = resultBenf.ID.ToString();
                }
                dateTimePicker1.Focus();
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
            var resultEmp = FsDb.Tbl_Employee.FirstOrDefault(x => x.ID == Vint_empId);
            textBox1.Text = resultEmp.Name;

            var resultBenf = FsDb.Tbl_Representatives.FirstOrDefault(x => x.Emp_ID == Vint_empId);
            if (resultBenf == null)
            {
                textBox2.Text = "";

            }
            else
            {
                textBox2.Text = resultBenf.ID.ToString();
            }
            txtBranch.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المندوب او قم بإختياره من القائمه ");
            }
            else
            {
                if (textBox2.Text == "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 80 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        if (Vint_BranchID > 0)
                        {
                            Vint_empId = int.Parse(txtEmp.Text);
                            vint_RepKind = int.Parse(comboBox1.SelectedValue.ToString());

                            Tbl_Representatives Rprs = new Tbl_Representatives
                            {
                                Name = textBox1.Text,
                                Emp_ID = Vint_empId,
                                RepresentativeKInd = vint_RepKind,
                                BranchID = Vint_BranchID,
                                fromDate = Convert.ToDateTime(dateTimePicker1.Value.ToString()),
                                ToDate = Convert.ToDateTime(dateTimePicker2.Value.ToString()),
                                RepStatus = 1
                            };

                            FsDb.Tbl_Representatives.Add(Rprs);
                            FsDb.SaveChanges();
                            int Vint_LastRow = Rprs.ID;
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة مندوب",
                                TableName = "Tbl_Representatives",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة اضافة مندوب"


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
                            dataGridView2.DataSource = FsDb.Tbl_Representatives.ToList();
                            textBox1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("من فضلك اختر الفرع ");
                        }
                    }

                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  مندوب .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (textBox2.Text != "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 80 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        Vint_Hndid = int.Parse(textBox2.Text);
                        Vint_empId = int.Parse(txtEmp.Text);
                        var result = FsDb.Tbl_Representatives.SingleOrDefault(x => x.ID == Vint_Hndid);
                        result.Name = textBox1.Text;
                        result.Emp_ID = Vint_empId;

                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل مندوب",
                            TableName = "Tbl_Handler",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة المندوبين"


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
                        dataGridView2.DataSource = FsDb.Tbl_Representatives.ToList();
                        textBox1.Focus();

                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  مندوب .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 80 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    int xrows = dataGridView1.RowCount;

                    if (xrows != 0 && textBox2.Text != "")
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا مندوب  ؟", "حدف مندوب ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {

                            Vint_Hndid = int.Parse(textBox2.Text);
                            var resultR = FsDb.Tbl_Representatives.Find(Vint_Hndid);
                            FsDb.Tbl_Representatives.Remove(resultR);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف مندوب",
                                TableName = "Tbl_Representatives",
                                TableRecordId = resultR.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة المندوب"


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
                        dataGridView2.DataSource = FsDb.Tbl_Representatives.ToList();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد المندوب المراد حدفه");
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  المندوب .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المندوب لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            Vint_empId = int.Parse(dataGridView2.CurrentRow.Cells["Emp_ID"].Value.ToString());
            txtEmp.Text = Vint_empId.ToString();
            var resultEmp = FsDb.Tbl_Employee.FirstOrDefault(x => x.ID == Vint_empId);
            textBox1.Text = resultEmp.Name;
            
            var resultBenf = FsDb.Tbl_Representatives.FirstOrDefault(x => x.Emp_ID == Vint_empId);
            if (resultBenf != null)
            {
                textBox2.Text = resultBenf.ID.ToString();
               
                txtBranchID.Text = resultBenf.BranchID.ToString();
                int vint_branchid = int.Parse(txtBranchID.Text);
                var vstr_branchname =  FsDb.Tbl_Management.Where(x => x.ID == vint_branchid).Select(t => t.BrancheName).ToList();

                txtBranch.Text = vstr_branchname[0].ToString();
                comboBox1.SelectedValue = int.Parse( resultBenf.RepresentativeKInd.ToString());
                dateTimePicker1.Value = Convert.ToDateTime(resultBenf.fromDate.ToString());
                dateTimePicker2.Value = Convert.ToDateTime(resultBenf.ToDate.ToString());
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBranch.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }

            else if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                t.ShowDialog();
                if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                {
                    txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                    txtBranchID.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();

                    Vint_BranchID = int.Parse(txtBranchID.Text);
                    var resultBenf = FsDb.Tbl_Representatives.Where(x => x.RepresentativeKInd == vint_RepKind && x.BranchID == Vint_BranchID).ToList();
                    if (resultBenf != null)
                    {
                        dataGridView2.DataSource = resultBenf;
                        grdReprsentive();
                    }
                }

            }
        }

        private void txtBranch_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار الفرع  ", TB, 0, 0, VisibleTime);
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            vint_RepKind = int.Parse(comboBox1.SelectedValue.ToString());
            var resultBenf = FsDb.Tbl_Representatives.Where(x => x.RepresentativeKInd == vint_RepKind).ToList();
            if (resultBenf != null)
            {
                dataGridView2.DataSource = resultBenf;
                grdReprsentive();
                dataGridView2.Visible = true;
            }

        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            
            dateTimePicker2.Value = Convert.ToDateTime(dateTimePicker1.Value.AddYears(5).ToString());
        }
    }
}
