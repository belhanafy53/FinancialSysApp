using FinancialSysApp.DataBase.Model;
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
    public partial class SupplierFrm  : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        int xID;
        int SupKind =0;
        public SupplierFrm()
        {
            InitializeComponent();
            Nametxt.Text = "";
            Addresstxt.Text = "";
            Emailtxt.Text = "";
            Phonetxt.Text = "";
            TaxCardtxt.Text = "";
            TaxFiletxt.Text = "";
            CodeOrgzxtBox.Text = "";
            BankTransfertxtbox.Text = "";

            

           

            

            GrdSupplier.DataSource = FsDb.Tbl_Supplier.OrderBy(x=>x.Name).ToList();
           

            GrdSupplier.Columns["Name"].HeaderText = "المورد";
            GrdSupplier.Columns["Address"].HeaderText = "العنوان";

            GrdSupplier.Columns["ID"].Visible = false;
            GrdSupplier.Columns["Email"].Visible = false;
            //GrdSupplier.Columns["Address"].Visible = false;
            GrdSupplier.Columns["Phone"].Visible = false;
            GrdSupplier.Columns["Tax_Card"].Visible = false;
            GrdSupplier.Columns["Tax_FileNo"].Visible = false;
            GrdSupplier.Columns["TaxAuthority_ID"].Visible = false;
            //GrdSupplier.Columns["Tbl_Beneficiary"].Visible = false;
            GrdSupplier.Columns["CodeOrganization"].Visible = false;
            GrdSupplier.Columns["Banktransferno"].Visible = false;
            GrdSupplier.Columns["Tbl_TaxAuthority"].Visible = false;
            GrdSupplier.Columns["suplierKind"].Visible = false;
            GrdSupplier.Columns["Name"].Width = 250;
            GrdSupplier.Columns["Address"].Width = 250;

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


            //comboBox1.Items.Insert(0, "Select");
            comboBox1.DataSource = FsDb.Tbl_TaxAuthority.OrderBy(x=>x.Name).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";

            comboBox2.DataSource = FsDb.Tbl_SupplierKind.OrderBy(x => x.Name).ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.SelectedItem = null;

            comboBox2.Select();
            this.ActiveControl = comboBox2;
            comboBox2.Focus();

        }

      

        private void Addresstxt_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                Nametxt.Text = "";
                Emailtxt.Text = "";
                Addresstxt.Text = "";
                TaxCardtxt.Text = "";
                TaxFiletxt.Text = "";
                Phonetxt.Text = "";
                CodeOrgzxtBox.Text = "";
                BankTransfertxtbox.Text = "";
                

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = -1;
                }
                comboBox1.SelectedValue = -1;
                xID = 0;
                GrdSupplier.Select();
                this.ActiveControl = GrdSupplier;
                GrdSupplier.Focus();
            }
            GrdSupplier.DataSource = FsDb.Tbl_Supplier.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
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
 
        

        private void Addresstxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TaxCardtxt.Focus();
            }
        }

        private void TaxCardtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

      

        private void Emailtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodeOrgzxtBox.Focus();
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
                Phonetxt.Text = "";
                CodeOrgzxtBox.Text = "";
                BankTransfertxtbox.Text = "";
                xID = int.Parse(GrdSupplier.CurrentRow.Cells[0].Value.ToString());
                
                var result = FsDb.Tbl_Supplier.SingleOrDefault(x => x.ID == xID);
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
                TaxCardtxt.Text = result.Tax_Card.ToString();
                TaxFiletxt.Text = result.Tax_FileNo.ToString();
                //CodeOrgzxtBox.Text = result.CodeOrganization.ToString();
                //BankTransfertxtbox.Text = result.BankTransferNo.ToString();
                //if (result.CodeOrganization != null)
                //{
                //    CodeOrgzxtBox.Text = result.CodeOrganization.ToString();
                //}
                if (result.Tbl_TaxAuthority != null)
                {

                    comboBox1.SelectedValue = result.TaxAuthority_ID;
                }
                comboBox2.SelectedValue = int.Parse(GrdSupplier.CurrentRow.Cells[9].Value.ToString());

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
            Phonetxt.Text = "";
            CodeOrgzxtBox.Text = "";
            BankTransfertxtbox.Text = "";
            xID = int.Parse(GrdSupplier.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_Supplier.SingleOrDefault(x => x.ID == xID);
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
            TaxCardtxt.Text = result.Tax_Card.ToString();
            TaxFiletxt.Text = result.Tax_FileNo.ToString();
            //CodeOrgzxtBox.Text = result.CodeOrganization.ToString();
            //BankTransfertxtbox.Text = result.BankTransferNo.ToString();

            //if (result.CodeOrganization != null)
            //{
            //    CodeOrgzxtBox.Text = result.CodeOrganization.ToString();
            //}
            if (result.Tbl_TaxAuthority != null)
            {
                
                comboBox1.SelectedValue = result.TaxAuthority_ID;
            }
            comboBox2.SelectedValue = int.Parse(GrdSupplier.CurrentRow.Cells[9].Value.ToString());
            Phonetxt.Text = result.Phone.ToString();
            Addresstxt.Focus();
        }
        private void SupplierFrm_Load(object sender, EventArgs e)
        {
            
        
            GrdSupplier.DataSource = FsDb.Tbl_Supplier.ToList();
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
            }
            comboBox1.SelectedValue = -1;
            comboBox2.Select();
            this.ActiveControl = comboBox2;
            comboBox2.Focus();

        }

     

        private void TaxAuthtxt_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedValue != null)
                {
                    int y = int.Parse(comboBox1.SelectedValue.ToString());
                    var result = FsDb.Tbl_TaxAuthority.FirstOrDefault(x => x.ID == y);

                    TaxFiletxt.Focus();
                }
               
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المورد ");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else if (TaxCardtxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم الملف الضريبي ");

                TaxCardtxt.Select();
                this.ActiveControl = TaxCardtxt;
                TaxCardtxt.Focus();
            }
            //else if (comboBox1.SelectedValue == null)
            //{
            //    MessageBox.Show("من فضلك ادخل مأمورية الضرائب ");

            //    comboBox1.Select();
            //    this.ActiveControl = comboBox1;
            //    comboBox1.Focus();
            //}
            else
            {
                if ( comboBox2.SelectedItem.ToString() =="1" )
                {
                    //    MessageBox.Show("من فضلك ادخل الكود المؤسسي ");
                }
                else
                {

                    if (xID == 0 && GrdSupplier.RowCount == 0)

                    {

                        if (comboBox1.SelectedIndex >= 0)
                        {

                            SupKind = int.Parse(comboBox1.SelectedValue.ToString());

                             Tbl_Supplier sup = new Tbl_Supplier
                            {
                                Name = Nametxt.Text,
                                Address = Addresstxt.Text,
                                Email = Emailtxt.Text,
                                Tax_Card = TaxCardtxt.Text,
                                Tax_FileNo = TaxFiletxt.Text,
                                TaxAuthority_ID = SupKind,
                                 //CodeOrganization = CodeOrgzxtBox.Text,
                                 SuplierKind = int.Parse(comboBox2.SelectedValue.ToString()),
                                 //BankTransferNo = BankTransfertxtbox.Text,

                                 Phone = Phonetxt.Text,
                            };
                            FsDb.Tbl_Supplier.Add(sup);
                            FsDb.SaveChanges();
                            MessageBox.Show("تم الحفظ");
                            //var result = FsDb.Tbl_Customer.ToList();
                            //MessageBox.Show(result.Count.ToString());
                            Nametxt.Text = "";
                            Addresstxt.Text = "";
                            Emailtxt.Text = "";
                            Phonetxt.Text = "";
                            TaxCardtxt.Text = "";
                            TaxFiletxt.Text = "";

                            CodeOrgzxtBox.Text = "";
                            BankTransfertxtbox.Text = "";
                            
                            SupKind = 0;
                            if (comboBox1.Items.Count > 0)
                            {
                                comboBox1.SelectedIndex = -1;
                            }
                            comboBox2.SelectedValue = -1;

                            if (comboBox2.Items.Count > 0)
                            {
                                comboBox2.SelectedIndex = -1;
                            }
                            comboBox2.SelectedValue = -1;

                            xID = 0;
                            comboBox1.SelectedItem = null;
                            comboBox2.SelectedItem = null;

                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }

                        else
                            { 
                            //MessageBox.Show("من فضلك قم بإختيار مأمورية الضرائب");
                    }

                    }
                    else
                    {
                        if (comboBox2.SelectedItem.ToString() == "1")
                        {
                            //MessageBox.Show("من فضلك ادخل الكود المؤسسي ");
                        }
                        else
                        {
                            SupKind = int.Parse(comboBox2.SelectedValue.ToString());
                            var result = FsDb.Tbl_Supplier.SingleOrDefault(h => h.ID == xID);
                            result.Name = Nametxt.Text;
                            result.Address = Addresstxt.Text;
                            result.Email = Emailtxt.Text;
                            result.Phone = Phonetxt.Text;
                            result.Tax_Card = TaxCardtxt.Text;
                            result.Tax_FileNo = TaxFiletxt.Text;
                            //result.CodeOrganization = CodeOrgzxtBox.Text;
                            //result.BankTransferNo = BankTransfertxtbox.Text;
                            result.TaxAuthority_ID = int.Parse(comboBox1.SelectedValue.ToString());
                            if (result.TaxAuthority_ID != null)
                            {
                                result.TaxAuthority_ID = int.Parse(comboBox1.SelectedValue.ToString());
                            }

                            result.SuplierKind = SupKind;
                            FsDb.SaveChanges();
                            MessageBox.Show("تم التعديل");

                            Nametxt.Text = "";
                            Addresstxt.Text = "";
                            Emailtxt.Text = "";
                            Phonetxt.Text = "";
                            TaxCardtxt.Text = "";
                            TaxFiletxt.Text = "";

                            CodeOrgzxtBox.Text = "";
                            BankTransfertxtbox.Text = "";
                            
                            SupKind = 0;
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
                            xID = 0;
                            comboBox1.SelectedItem = null;
                            comboBox2.SelectedItem = null;
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                }
            }
        }

        private void Phonetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Emailtxt.Focus();
            }
        }

        private void simpleButton2_KeyDown(object sender, KeyEventArgs e)
        {
            var result = FsDb.Tbl_Supplier.Find(xID);
            if (result != null)
            {
                FsDb.Tbl_Supplier.Remove(result);
                FsDb.SaveChanges();
                MessageBox.Show("  تم الحدف");
                Nametxt.Text = "";
                Addresstxt.Text = "";
                Emailtxt.Text = "";
                Phonetxt.Text = "";
                TaxCardtxt.Text = "";
                TaxFiletxt.Text = "";

                CodeOrgzxtBox.Text = "";
                BankTransfertxtbox.Text = "";
                
                SupKind = 0;
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



                GrdSupplier.DataSource = FsDb.Tbl_Supplier.ToList();
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {
                MessageBox.Show("حدد المورد المراد حدفه");
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
        }

        private void CodeOrgzxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void TaxFiletxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Phonetxt.Focus();
            }
        }


        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Nametxt.Focus();
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
                        var result1 = MessageBox.Show("هل تريد حدف هدا المورد  ؟", "حدف مورد ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_Supplier.Find(xID);
                            FsDb.Tbl_Supplier.Remove(result);
                            FsDb.SaveChanges();
                            //-------------حدف الاحداث 
                            string Vstr_tblRecord = result.ID.ToString();
                            //SecurityEvent sev = new SecurityEvent
                            //{
                            //    ActionName = "حدف بيانات مورد",
                            //    TableName = "Tbl_Supplier",
                            //    TableRecordId = Vstr_tblRecord,
                            //    Description = "",
                            //    ManagementName = Program.GlbV_Management,
                            //    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            //    EmployeeName = Program.GlbV_EmpName,
                            //    User_ID = Program.GlbV_UserId,
                            //    UserName = Program.GlbV_UserName,
                            //    FormName = "Tbl_Supplier"


                            //};
                            //FsEvDb.SecurityEvents.Add(sev);
                            //FsEvDb.SaveChanges();
                            ////-------------------------

                            MessageBox.Show("  تم الحدف");
                            Nametxt.Text = "";
                            Emailtxt.Text = "";
                            Addresstxt.Text = "";

                            Phonetxt.Text = "";
                            GrdSupplier.DataSource = FsDb.Tbl_Customer.ToList();
                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("من فضلك حدد المورد المراد حدفه");
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حدف مورد .. برجاء مراجعة مدير المنظومه");
                }

            }
            catch


            {
                MessageBox.Show("هذا المورد لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }







    
    }

