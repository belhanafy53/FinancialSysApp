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
    public partial class TaxAuthorityFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public TaxAuthorityFrm()
        {

            InitializeComponent();

        }



        private void TaxAuthorityFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_TaxAuthority.ToList();
            dataGridView1.Columns["Name"].HeaderText = "مأمورية الضرائب";
            //dataGridView1.Columns["TaxAuthority_Code"].HeaderText = "كود الماموريه";
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Tbl_Supplier"].Visible = false;
            dataGridView1.Columns["Name"].Width = 200;
            ////dataGridView1.Columns["TaxAuthority_Code"].Width = 100;
            textBox1.Text = "";
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_TaxAuthority.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            //CodeTxt.Text = result.TaxAuthority_Code;
            textBox1.Text = xcatid.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_TaxAuthority.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_TaxAuthority.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_TaxAuthority.SingleOrDefault(x => x.ID == xcatid);
            Nametxt.Text = result.Name;
            //CodeTxt.Text = result.TaxAuthority_Code;
            textBox1.Text = xcatid.ToString();
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        //private void CodeTxt_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        simpleButton1.Focus();
        //    }
        //}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المأمورية ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }

            else
            {
                int xrows = dataGridView1.RowCount;
                if (xrows == 0 && textBox1.Text == "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 6 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_TaxAuthority taxaF = new Tbl_TaxAuthority
                        {
                            Name = Nametxt.Text,
                            //TaxAuthority_Code = CodeTxt.Text

                        };
                        FsDb.Tbl_TaxAuthority.Add(taxaF);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مامورية ضرائب",
                            TableName = "Tbl_TaxAuthority",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مأموريات الضرائب"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_TaxAuthority.ToList();
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        //CodeTxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  مأمورية الضرائب .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 6 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(textBox1.Text);
                        var result = FsDb.Tbl_TaxAuthority.SingleOrDefault(x => x.ID == xcatid);
                        result.Name = Nametxt.Text;
                        //result.TaxAuthority_Code = CodeTxt.Text;
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مامورية ضرائب",
                            TableName = "Tbl_TaxAuthority",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مأموريات الضرائب"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        dataGridView1.DataSource = FsDb.Tbl_TaxAuthority.ToList();
                        textBox1.Text = "";
                        Nametxt.Text = "";
                        //CodeTxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  مأمورية الضرائب .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            { 
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 6 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                int xrows = dataGridView1.RowCount;

                if (xrows != 0 && textBox1.Text != "")
                {
                    var result1 = MessageBox.Show("هل تريد حدف هده المامورية  ؟", "حدف مامورية ", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {

                        if (xrows != 0 && textBox1.Text != "")
                        {
                            var result = FsDb.Tbl_TaxAuthority.Find(xcatid);
                            FsDb.Tbl_TaxAuthority.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRow = taxaF.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف مامورية ضرائب",
                                TableName = "Tbl_TaxAuthority",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة مأموريات الضرائب"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("  تم الحدف");
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
                    MessageBox.Show("من فضلك حدد مأمورية الضرائب المراد حدفها");
                    Nametxt.Select();
                    this.ActiveControl = Nametxt;
                    Nametxt.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  مأمورية الضرائب .. برجاء مراجعة مدير المنظومه");
            }
            }
            catch


            {
                MessageBox.Show("هذه المأمورية لايمكن حذفها لوجود تابعين لها او مستندات لها", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

