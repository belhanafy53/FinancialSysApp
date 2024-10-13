using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Win32;
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
using System.Data.Entity;

namespace FinancialSysApp.Forms
{
    public partial class CustomerFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xID;

        public CustomerFrm()
        {
            InitializeComponent();
            Nametxt.Text = "";
            Addresstxt.Text = "";
            Emailtxt.Text = "";
            Phonetxt.Text = "";



            Nametxt.Select();
            this.ActiveControl = Nametxt;

            Nametxt.Focus();

        }



        private void CustomerFrm_Load(object sender, EventArgs e)
        {
            GrdCustomer.DataSource = FsDb.Tbl_Customer.ToList();
            GrdCustomer.Columns["Email"].Visible = false;
            GrdCustomer.Columns["ID"].Visible = false;
            GrdCustomer.Columns["Phone"].Visible = false;
            GrdCustomer.Columns["Tax_Card"].Visible = false;
            GrdCustomer.Columns["Trade_Record"].Visible = false;
            GrdCustomer.Columns["Tbl_Assays"].Visible = false;
            GrdCustomer.Columns["Tbl_Beneficiary"].Visible = false;

            GrdCustomer.Columns["Name"].HeaderText = "العميل";
            GrdCustomer.Columns["Address"].HeaderText = "العنوان";

            //GrdCustomer.Columns["Tbl_BankCheque"].Visible = false;
            GrdCustomer.Columns["Name"].Width = 250;
            GrdCustomer.Columns["Address"].Width = 250;
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
            ControlFormProcedures();

        }

        private void ControlFormProcedures()
        {
            //simpleButton1.Visible = Program.SecurityProceduresList.FirstOrDefault(r => r.FormId == 1 && r.ProcdureId == 1) != null ? true : false;
        }

        private void GrdCustomer_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                Nametxt.Text = "";
                Emailtxt.Text = "";
                Addresstxt.Text = "";

                Phonetxt.Text = "";
            }
            GrdCustomer.DataSource = FsDb.Tbl_Customer.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
        }

        private void GrdCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GrdCustomer_KeyDown(object sender, KeyEventArgs e)
        {

            xID = int.Parse(GrdCustomer.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_Customer.SingleOrDefault(x => x.ID == xID);
            Nametxt.Text = result.Name.ToString();
            Emailtxt.Text = result.Email.ToString();
            Addresstxt.Text = result.Address.ToString();

            Phonetxt.Text = result.Phone.ToString();
            Emailtxt.Focus();
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int GRow = int.Parse(GrdCustomer.RowCount.ToString());
                //MessageBox.Show(GRow.ToString());
                if (GRow > 0)
                {
                    GrdCustomer.Focus();
                }
                else
                {
                    Emailtxt.Focus();
                }
            }
        }



        private void GrdCustomer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void GrdCustomer_MouseClick(object sender, MouseEventArgs e)
        {

            xID = int.Parse(GrdCustomer.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_Customer.SingleOrDefault(x => x.ID == xID);
            Nametxt.Text = result.Name.ToString();
            Emailtxt.Text = result.Email.ToString();
            Addresstxt.Text = result.Address.ToString();

            Phonetxt.Text = result.Phone.ToString();
            Emailtxt.Focus();
        }

        private void Addresstxt_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                Phonetxt.Focus();
            }
        }





        private void Emailtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Addresstxt.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم العميل على الاقل ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {


                if (xID == 0 && GrdCustomer.RowCount == 0)
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 1 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        Tbl_Customer cus = new Tbl_Customer
                        {
                            Name = Nametxt.Text,
                            Address = Addresstxt.Text,
                            Email = Emailtxt.Text,
                            Phone = Phonetxt.Text

                        };

                        FsDb.Tbl_Customer.Add(cus);

                        FsDb.SaveChanges();
                        Tbl_Beneficiary bnf = new Tbl_Beneficiary
                        {
                            Name = Nametxt.Text,
                            ID_Cust = cus.ID,
                            BeneficiaryKind_ID = 3

                        };
                        FsDb.Tbl_Beneficiary.Add(bnf);
                        FsDb.SaveChanges();
                        int Vint_LastRowId = cus.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة عميل",
                            TableName = "Tbl_CostCenters",
                            TableRecordId = Vint_LastRowId.ToString(),
                            Description="",
                            ManagementName=Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName=Program.GlbV_EmpName,
                            User_ID=Program.GlbV_UserId,
                            UserName=Program.GlbV_UserName,
                            FormName="شاشة العملاء" 


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                       

                        //-------------------------
                        MessageBox.Show("تم الحفظ");

                            Nametxt.Text = "";
                            Addresstxt.Text = "";
                            Emailtxt.Text = "";
                            Phonetxt.Text = "";
                      
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة عميل .. برجاء مراجعة مدير المنظومه");
                    }

                }
                else
                {
                    var validationUpdateUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 1 && w.ProcdureId == 3);
                    if (validationUpdateUser != null)
                    {
                        var result = FsDb.Tbl_Customer.FirstOrDefault(h => h.ID == xID);
                        result.Name = Nametxt.Text;
                        result.Address = Addresstxt.Text;
                        result.Email = Emailtxt.Text;
                        result.Phone = Phonetxt.Text;

                        var resultBnf = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.ID_Cust == xID);
                        if (result != null)
                        {
                            resultBnf.Name = Nametxt.Text;
                            resultBnf.BeneficiaryKind_ID = 3;
                            resultBnf.ID_Cust = result.ID;
                            FsDb.SaveChanges();
                        }
                        else
                        {
                            Tbl_Beneficiary bnf = new Tbl_Beneficiary
                            {
                                Name = Nametxt.Text,
                                ID_Cust = result.ID,
                                BeneficiaryKind_ID = 3

                            };
                            FsDb.Tbl_Beneficiary.Add(bnf);
                            FsDb.SaveChanges();
                        }

                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بيانات عميل",
                            TableName = "Tbl_CostCenters",
                            TableRecordId =result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة العملاء"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //-------------------------

                        MessageBox.Show("تم التعديل");
                        //var result = FsDb.Tbl_Customer.ToList();
                        //MessageBox.Show(result.Count.ToString());
                        Nametxt.Text = "";
                        Addresstxt.Text = "";
                        Emailtxt.Text = "";
                        Phonetxt.Text = "";
                        xID = 0;
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل بيانات عميل .. برجاء مراجعة مدير المنظومه");
                    }

                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationDelUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 1 && w.ProcdureId == 4);
                if (validationDelUser != null)
                {
                    if (xID > 0)
                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا العميل  ؟", "حدف عميل ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_Customer.Find(xID);
                            FsDb.Tbl_Customer.Remove(result);
                            FsDb.SaveChanges();
                            //-------------حدف الاحداث 
                            string Vstr_tblRecord = result.ID.ToString();
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حدف بيانات عميل",
                                TableName = "Tbl_CostCenters",
                                TableRecordId = Vstr_tblRecord,
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة العملاء"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //-------------------------

                            MessageBox.Show("  تم الحدف");
                            Nametxt.Text = "";
                            Emailtxt.Text = "";
                            Addresstxt.Text = "";

                            Phonetxt.Text = "";
                            GrdCustomer.DataSource = FsDb.Tbl_Customer.ToList();
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد العميل المراد حدفه");
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حدف عميل .. برجاء مراجعة مدير المنظومه");
                }

            }
            catch


            {
                MessageBox.Show("هذا العميل لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Phonetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }
    }
}
