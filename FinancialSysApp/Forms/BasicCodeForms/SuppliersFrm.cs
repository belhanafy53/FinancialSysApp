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
    public partial class SuppliersFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_SupID;
        int? Vint_SupKind;
        int? VIntTaxAuthority;
        int? VintSupId = 0;
        public SuppliersFrm()
        {
            InitializeComponent();
            Nametxt.Text = "";
            Addresstxt.Text = "";
            Emailtxt.Text = "";
            Phonetxt.Text = "";
            TaxCardtxt.Text = "";
            TaxFiletxt.Text = "";
            GrdSupplier.DataSource = FsDb.Tbl_Supplier.OrderBy(x => x.Name).ToList();
            GrdSupplier.Columns["Name"].HeaderText = "المورد";
            GrdSupplier.Columns["Address"].HeaderText = "العنوان";
            GrdSupplier.Columns["Tax_Card"].HeaderText = "البطاقه الضريبيه";
            GrdSupplier.Columns["ID"].Visible = false;
            GrdSupplier.Columns["Name"].Visible = true;
            GrdSupplier.Columns["Email"].Visible = false;
            GrdSupplier.Columns["Address"].Visible = true;
            GrdSupplier.Columns["Phone"].Visible = false;
            GrdSupplier.Columns["Tax_Card"].Visible = true;
            GrdSupplier.Columns["Tax_FileNo"].Visible = false;
            GrdSupplier.Columns["TaxAuthority_ID"].Visible = false;
            GrdSupplier.Columns["Tbl_Beneficiary"].Visible = false;
            GrdSupplier.Columns["Tbl_TaxAuthority"].Visible = false;
            GrdSupplier.Columns["Tbl_SupplierKind"].Visible = false;
            GrdSupplier.Columns["AddRecordingSupplier"].Visible = false;
            GrdSupplier.Columns["suplierKind"].Visible = false;
            GrdSupplier.Columns["Tbl_Order"].Visible = false;
            GrdSupplier.Columns["Name"].Width = 300;
            GrdSupplier.Columns["Address"].Width = 270;

            //if (comboBox1.Items.Count > 0)
            //{
            //    comboBox1.SelectedIndex = -1;
            //}
            //comboBox1.SelectedValue = -1;

            //if (comboBox2.Items.Count > 0)
            //{
            //    comboBox2.SelectedIndex = -1;
            //}
            //comboBox2.SelectedValue = -1;


            //comboBox1.Items.Insert(0, "Select");
            comboBox1.DataSource = FsDb.Tbl_TaxAuthority.OrderBy(x => x.Name).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            //comboBox1.Items.Add(new { Name = "اختر مأمورية الضرائب", ID = "NULL" });


            comboBox2.DataSource = FsDb.Tbl_SupplierKind.OrderBy(x => x.Name).ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";

            //comboBox2.SelectedItem = null;

            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.SelectedText = "اختر نوع المورد / المقاول/الجهه";
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedText = "اختر المأمورية";

            comboBox2.Select();
            this.ActiveControl = comboBox2;
            comboBox2.Focus();
        }


        private void SuppliersFrm_Load(object sender, EventArgs e)
        {
            GrdSupplier.DataSource = FsDb.Tbl_Supplier.OrderByDescending(x=>x.ID ).ToList();
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.SelectedText = "اختر نوع المورد / المقاول";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.SelectedText = "اختر المأمورية";
            comboBox2.Select();
            this.ActiveControl = comboBox2;
            comboBox2.Focus();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nametxt.Focus();
            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int GRow = int.Parse(GrdSupplier.RowCount.ToString());

                if (GRow > 0)
                {
                    GrdSupplier.Focus();
                }
                else
                {
                    Addresstxt.Focus();
                }
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {

                Emailtxt.Text = "";
                Addresstxt.Text = "";
                TaxCardtxt.Text = "";
                TaxFiletxt.Text = "";
                Phonetxt.Text = "";
                txtTax1.Text = "";
                txtTax2.Text = "";
                txtTax3.Text = "";


                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = -1;
                }
                comboBox1.SelectedValue = -1;
                Vint_SupID = 0;

            }
            else
            {
                if (comboBox2.SelectedValue != null)
                {
                    Vint_SupKind = int.Parse(comboBox2.SelectedValue.ToString());
               
                GrdSupplier.DataSource = FsDb.Tbl_Supplier.Where(x => x.Name.Contains(Nametxt.Text) && x.SuplierKind == Vint_SupKind).ToList();
                
                dataGridViewEmp.DataSource = (from emp in FsDb.Tbl_Employee
                                              join mng in FsDb.Tbl_Management on emp.Management_ID equals mng.Management_ID
                                              where (emp.Name.Contains(Nametxt.Text) )
                                              select new
                                              {
                                                  ID = emp.ID,
                                                  Name = emp.Name,
                                                  NationalId = emp.NationalId,
                                                  WorkerJob = emp.WorkerJob,
                                                  ManagementName = mng.Name

                                              }).Take(30).OrderBy(t => t.Name).ToList();
                dataGridViewEmp.Columns["Name"].HeaderText = "اسم الموظف";
                dataGridViewEmp.Columns["NationalId"].HeaderText = "الرقم القومي";
                dataGridViewEmp.Columns["WorkerJob"].HeaderText = "الوظيفة";
                dataGridViewEmp.Columns["ManagementName"].HeaderText = "الادارة";

                dataGridViewEmp.Columns["ID"].Visible = false;
                dataGridViewEmp.Columns["ManagementName"].Width = 250;
                dataGridViewEmp.Columns["Name"].Width = 200;
                }
            }
        }

        private void GrdSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nametxt.Text = "";
                Emailtxt.Text = "";
                Addresstxt.Text = "";
                TaxCardtxt.Text = "";
                TaxFiletxt.Text = "";
                txtTax1.Text = "";
                txtTax2.Text = "";
                txtTax3.Text = "";

                Phonetxt.Text = "";
                checkBox2.Checked = false;
                Vint_SupID = int.Parse(GrdSupplier.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_Supplier.SingleOrDefault(x => x.ID == Vint_SupID);
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = -1;
                }
                if (result.TaxAuthority_ID != null)
                {

                    comboBox1.SelectedValue = result.TaxAuthority_ID;
                }

                Nametxt.Text = result.Name.ToString();
                Emailtxt.Text = result.Email.ToString();
                Addresstxt.Text = result.Address.ToString();

                TaxFiletxt.Text = result.Tax_FileNo.ToString();
                if (result.Tax_FileNo1 != null)
                { txtTax1.Text = result.Tax_FileNo1.ToString(); }
                if (result.Tax_FileNo2 != null)
                {
                    txtTax2.Text = result.Tax_FileNo2.ToString();
                }
                if (result.Tax_FileNo3 != null)
                {
                    txtTax3.Text = result.Tax_FileNo3.ToString();
                }
                if (result.AddRecordingSupplier != null && result.AddRecordingSupplier != false)
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }


                if (result.Tbl_TaxAuthority != null)
                {

                    comboBox1.SelectedValue = result.TaxAuthority_ID;
                }
                comboBox2.SelectedValue = int.Parse(GrdSupplier.CurrentRow.Cells[8].Value.ToString());
                Phonetxt.Text = result.Phone.ToString();
                Addresstxt.Focus();
            }
        }

        private void GrdSupplier_MouseClick(object sender, MouseEventArgs e)
        {
            Nametxt.Text = "";
            Emailtxt.Text = "";
            Addresstxt.Text = "";
            TaxCardtxt.Text = "";
            TaxFiletxt.Text = "";
            txtTax1.Text = "";
            txtTax2.Text = "";
            txtTax3.Text = "";
            txtTaxName.Text = "";
            Phonetxt.Text = "";
            checkBox2.Checked = false; 
            Vint_SupID = int.Parse(GrdSupplier.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_Supplier.SingleOrDefault(x => x.ID == Vint_SupID);
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
            }
            if (result.TaxAuthority_ID != null)
            {

                comboBox1.SelectedValue = result.TaxAuthority_ID;
            }

            Nametxt.Text = result.Name.ToString();
            Emailtxt.Text = result.Email.ToString();
            Addresstxt.Text = result.Address.ToString();
           
            TaxFiletxt.Text = result.Tax_FileNo.ToString();
            if (result.Tax_FileNo1 != null)
            { txtTax1.Text = result.Tax_FileNo1.ToString(); }
            if (result.Tax_FileNo2 != null)
            {
                txtTax2.Text = result.Tax_FileNo2.ToString();
            }
            if (result.Tax_FileNo3 != null)
            {
                txtTax3.Text = result.Tax_FileNo3.ToString();
            }
            if (result.AddRecordingSupplier != null && result.AddRecordingSupplier != false )
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }


            if (result.Tbl_TaxAuthority != null)
            {

                comboBox1.SelectedValue = result.TaxAuthority_ID;
            }
            if (result.TaxName != null)
            {
                txtTaxName.Text = result.TaxName.ToString();
            }
            comboBox2.SelectedValue = int.Parse(GrdSupplier.CurrentRow.Cells[8].Value.ToString());
            Phonetxt.Text = result.Phone.ToString();
            Addresstxt.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedValue != null)
                {
                    int y = int.Parse(comboBox1.SelectedValue.ToString());
                    var result = FsDb.Tbl_TaxAuthority.FirstOrDefault(x => x.ID == y);

                    txtTax3.Focus();
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("من فضلك ادخل نوع المورد ");

                comboBox2.Select();
                this.ActiveControl = comboBox2;
                comboBox2.Focus();
            }
            else if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المورد ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }

            else if (txtTax1.Text == "" && txtTax2.Text =="" && txtTax3.Text == "" && ( int.Parse(comboBox2.SelectedValue.ToString()) != 1 && int.Parse(comboBox2.SelectedValue.ToString()) != 4 && int.Parse(comboBox2.SelectedValue.ToString()) != 5))
            {
                MessageBox.Show("من فضلك ادخل رقم البطاقة الضريبيه ");

                TaxCardtxt.Select();
                this.ActiveControl = TaxCardtxt;
                TaxCardtxt.Focus();
            }
            else if (comboBox1.SelectedValue == null && int.Parse(comboBox2.SelectedValue.ToString()) != 1 && (int.Parse(comboBox2.SelectedValue.ToString()) != 1 && int.Parse(comboBox2.SelectedValue.ToString()) != 4 && int.Parse(comboBox2.SelectedValue.ToString()) != 5))
            {
                MessageBox.Show("من فضلك ادخل مأمورية الضرائب ");

                comboBox1.Select();
                this.ActiveControl = comboBox1;
                comboBox1.Focus();
            }

            else
            {
                if (Vint_SupID == 0 && GrdSupplier.RowCount == 0)

                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 2 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        bool Vbl_AddSupRecord = false;
                        Vint_SupKind = string.IsNullOrEmpty(comboBox2.SelectedValue.ToString()) ? (int?)null : int.Parse(comboBox2.SelectedValue.ToString());
                        if (comboBox1.SelectedValue != null)
                        {

                            VIntTaxAuthority = string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()) ? (int?)null : int.Parse(comboBox1.SelectedValue.ToString());
                        }
                        if (checkBox2.Checked == true)
                        {
                            Vbl_AddSupRecord = true;
                        }
                        else
                        {
                            Vbl_AddSupRecord = false;
                        }
                        Tbl_Supplier sup = new Tbl_Supplier
                        {
                            Name = Nametxt.Text,
                            Address = Addresstxt.Text,
                            Email = Emailtxt.Text,
                            Tax_FileNo1 = txtTax1.Text,
                            Tax_FileNo2 = txtTax2.Text,
                            Tax_FileNo3 = txtTax3.Text,
                            Tax_FileNo = TaxFiletxt.Text,
                            TaxAuthority_ID = VIntTaxAuthority,
                            SuplierKind = Vint_SupKind,
                            Phone = Phonetxt.Text,
                            TaxName = txtTaxName.Text,
                            AddRecordingSupplier = Vbl_AddSupRecord
                        };
                        FsDb.Tbl_Supplier.Add(sup);
                        FsDb.SaveChanges();
                      
                        VintSupId = sup.ID;

                       var listbenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Supp == Vint_SupID);
                        if (listbenf == null)
                        {
                            Tbl_Beneficiary bnf = new Tbl_Beneficiary
                            {
                                ID_Supp = VintSupId,
                                Name = Nametxt.Text,
                                BeneficiaryKind_ID = 2

                            };
                            FsDb.Tbl_Beneficiary.Add(bnf);
                            FsDb.SaveChanges();
                        }
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = sup.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مورد",
                            TableName = "Tbl_Supplier",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الموردين"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");

                        Nametxt.Text = "";
                        Addresstxt.Text = "";
                        Emailtxt.Text = "";
                        Phonetxt.Text = "";
                        TaxCardtxt.Text = "";
                        TaxFiletxt.Text = "";
                        txtTaxName.Text = "";


                        Vint_SupKind = 0;
                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = -1;
                        }
                        comboBox1.SelectedValue = -1;

                        if (comboBox2.Items.Count > 0)
                        {
                            comboBox2.SelectedIndex = 1;
                        }
                        comboBox2.SelectedValue = 1;

                        Vint_SupID = 0;
                        comboBox1.SelectedItem = null;
                        comboBox2.SelectedItem = null;

                        comboBox2.Select();
                        this.ActiveControl = comboBox2;
                        comboBox2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  مورد .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 2 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        //bool? vbl_AddSubRecord = false;
                        Vint_SupKind = string.IsNullOrEmpty(comboBox2.SelectedValue.ToString()) ? (int?)null : int.Parse(comboBox2.SelectedValue.ToString());
                        VIntTaxAuthority = string.IsNullOrEmpty(comboBox2.SelectedValue.ToString()) ? (int?)null : int.Parse(comboBox1.SelectedValue.ToString());
                        var result = FsDb.Tbl_Supplier.SingleOrDefault(h => h.ID == Vint_SupID);
                        result.Name = Nametxt.Text;
                        result.Address = Addresstxt.Text;
                        result.Email = Emailtxt.Text;
                        result.Phone = Phonetxt.Text;
                        result.Tax_FileNo1 = txtTax1.Text;
                        result.Tax_FileNo2 = txtTax2.Text;
                        result.Tax_FileNo3 = txtTax3.Text;
                        result.Tax_FileNo = TaxFiletxt.Text;
                        result.TaxAuthority_ID = VIntTaxAuthority;
                        result.SuplierKind = Vint_SupKind;
                        result.TaxName = txtTaxName.Text;
                        if (checkBox2.Checked == true)
                        {
                            result.AddRecordingSupplier = true;
                        }
                        else
                        {
                            result.AddRecordingSupplier = false;
                        }

                        var listbenf = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.ID_Supp == Vint_SupID);
                        if (listbenf != null)
                        {
                            listbenf.Name = Nametxt.Text;
                           
                        }
                        else
                        {
                            Tbl_Beneficiary bnf = new Tbl_Beneficiary
                            {
                                ID_Supp = result.ID,
                                Name = Nametxt.Text,
                                BeneficiaryKind_ID = 2

                            };
                            FsDb.Tbl_Beneficiary.Add(bnf);
                        }
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = sup.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل مورد",
                            TableName = "Tbl_Supplier",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الموردين"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");

                        Nametxt.Text = "";
                        Addresstxt.Text = "";
                        Emailtxt.Text = "";
                        Phonetxt.Text = "";
                        TaxCardtxt.Text = "";
                        txtTaxName.Text = "";
                        TaxFiletxt.Text = "";
                        comboBox2.SelectedIndex = -1;
                        comboBox2.Text = "";
                        comboBox2.SelectedText = "اختر نوع المورد / المقاول";


                        Vint_SupKind = 0;
                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = -1;
                        }
                        comboBox1.SelectedValue = -1;

                        if (comboBox2.Items.Count > 0)
                        {
                            comboBox2.SelectedIndex = -1;
                        }
                        comboBox2.SelectedValue = -1;
                        Vint_SupID = 0;
                        comboBox1.SelectedItem = null;
                        comboBox2.SelectedItem = null;
                        comboBox2.Select();
                        this.ActiveControl = comboBox2;
                        comboBox2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  مورد .. برجاء مراجعة مدير المنظومه");
                    }
                }


            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 2 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    var result = FsDb.Tbl_Supplier.Find(Vint_SupID);
                    if (result != null)
                    {
                        var resultMsg = MessageBox.Show(Nametxt.Text + " " + "هل تريد حدف هدا المورد   " + " ؟ ", "حدف مورد ", MessageBoxButtons.YesNo);
                        if (resultMsg == DialogResult.Yes)
                        {
                            var listSupOrder = FsDb.Tbl_Order.FirstOrDefault(x => x.Supp_ID == Vint_SupID);
                            var listbenf = FsDb.Tbl_Beneficiary.FirstOrDefault(x => x.ID_Supp == Vint_SupID);
                            if (listSupOrder != null)
                            {
                                MessageBox.Show(" لايمكن حدف هدا المورد لانه تم استخدامه في الاوامر ");
                            }
                            

                            else
                            {
                                if (listbenf != null)
                                {
                                    FsDb.Tbl_Beneficiary.Remove(listbenf);
                                }
                                
                                FsDb.Tbl_Supplier.Remove(result);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                //int Vint_LastRow = sup.ID;
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف مورد",
                                    TableName = "Tbl_Supplier",
                                    TableRecordId = result.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة الموردين"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //***************************

                                MessageBox.Show("تم الحدف");
                                Nametxt.Text = "";
                                Addresstxt.Text = "";
                                Emailtxt.Text = "";
                                Phonetxt.Text = "";
                                TaxCardtxt.Text = "";
                                TaxFiletxt.Text = "";



                                Vint_SupKind = 0;
                                if (comboBox1.Items.Count > 0)
                                {
                                    comboBox1.SelectedIndex = -1;
                                }
                                comboBox1.SelectedValue = -1;
                                comboBox1.SelectedItem = null;

                                if (comboBox2.Items.Count > 0)
                                {
                                    comboBox2.SelectedIndex = -1;
                                }
                                comboBox2.SelectedValue = -1;
                                comboBox2.SelectedItem = null;

                            }
                        }
                        GrdSupplier.DataSource = FsDb.Tbl_Supplier.ToList();
                        comboBox2.Select();
                        this.ActiveControl = comboBox2;
                        comboBox2.Focus();

                    }
                    else
                    {
                        MessageBox.Show("حدد المورد المراد حدفه");
                        comboBox2.Select();
                        this.ActiveControl = comboBox2;
                        comboBox2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  مورد .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المورد لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Addresstxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void TaxCardtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.SelectedIndex = -1;
                comboBox1.SelectedText = "اختر المأمورية";
                comboBox1.Focus();
            }
        }

        private void TaxFiletxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTaxName.Focus();
            }
        }

        private void Phonetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Emailtxt.Focus();
            }
        }

        private void Emailtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int? VintSupId;
            if (GrdSupplier.RowCount > 0)
            {
                int WCount = int.Parse(GrdSupplier.RowCount.ToString());

                for (int i = 0; i <= WCount - 1; i++)
                {
                    VintSupId = string.IsNullOrEmpty(GrdSupplier.Rows[i].Cells[0].Value.ToString()) ? (int?)null : int.Parse(GrdSupplier.Rows[i].Cells[0].Value.ToString());


                    var listbenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Supp == VintSupId);
                    if (listbenf == null)
                    {
                        Tbl_Beneficiary bnf = new Tbl_Beneficiary
                        {
                            ID_Supp = int.Parse(GrdSupplier.Rows[i].Cells[0].Value.ToString()),
                            Name = GrdSupplier.Rows[i].Cells[1].Value.ToString(),
                            BeneficiaryKind_ID = 2

                        };
                        FsDb.Tbl_Beneficiary.Add(bnf);
                        FsDb.SaveChanges();
                    }

                }
                MessageBox.Show("تم النقل");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaxAuthorityFrm Tax = new TaxAuthorityFrm();
            Tax.Show();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

            //comboBox1.DataSource = FsDb.Tbl_TaxAuthority.OrderBy(x => x.Name).ToList();
            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "ID";
            //comboBox1.SelectedIndex = -1;
            //comboBox1.Text = "اختر المأمورية";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {

                int y = int.Parse(comboBox1.SelectedValue.ToString());
                var result = FsDb.Tbl_TaxAuthority.FirstOrDefault(x => x.ID == y);

                comboBox1.Focus();
            }
            else if (comboBox1.SelectedIndex < 0)
            {

                comboBox1.SelectedItem = null;
                comboBox1.Focus();
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.DataSource = FsDb.Tbl_TaxAuthority.OrderBy(x => x.Name).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Vint_SupKind = int.Parse(comboBox2.SelectedValue.ToString());
            var list = FsDb.Tbl_Supplier.Where(x => x.SuplierKind == Vint_SupKind).ToList();
            GrdSupplier.DataSource = list;
            Nametxt.Text = "";
            Addresstxt.Text = "";
            Emailtxt.Text = "";
            Phonetxt.Text = "";
            TaxCardtxt.Text = "";
            TaxFiletxt.Text = "";
            txtTaxName.Text = "";
        }

        private void txtTax1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listSuppTax = FsDb.Tbl_Supplier.Where(x => x.Tax_FileNo1 == txtTax1.Text && x.Tax_FileNo2 == txtTax2.Text && x.Tax_FileNo3 == txtTax3.Text).ToList();
                if (listSuppTax.Count != 0)
                {
                    MessageBox.Show($"هذه الرقم الضريبي تم استخدامه من قبل مع المورد / المقاول {listSuppTax[0].Name}");
                    txtTax1.Text = "";
                    txtTax2.Text = "";
                    txtTax3.Text = "";
                    txtTax3.Focus();
                }
                else
                {
                    TaxFiletxt.Focus();
                }
            }
        }

        private void txtTax2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTax1.Focus();
            }
        }

        private void txtTax3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var listSuppTax = FsDb.Tbl_Supplier.Where(x => x.Tax_FileNo1 == txtTax1.Text && x.Tax_FileNo2 == txtTax2.Text && x.Tax_FileNo3 == txtTax3.Text).ToList();
                if (listSuppTax.Count != 0)
                {
                    MessageBox.Show($"هذه الرقم الضريبي تم استخدامه من قبل مع المرد / المقاول {listSuppTax[0].Name}");
                    txtTax1.Text = "";
                    txtTax2.Text = "";
                    txtTax3.Text = "";
                    txtTax3.Focus();
                }
                else
                {
                    txtTax2.Focus();
                }
            }

        }

        private void txtTaxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Phonetxt.Focus();
            }
            
        }
    }

}
