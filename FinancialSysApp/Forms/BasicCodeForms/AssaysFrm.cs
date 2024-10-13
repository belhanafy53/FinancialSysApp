using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class AssaysFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_AssaysID = 0;
        public AssaysFrm()
        {
            InitializeComponent();

        }

        private void AssaysFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet1.AssaysDataTapleByNo' table. You can move, or remove it, as needed.
            this.assaysDataTapleByNoTableAdapter.FillAssays(this.financialSysDataSet1.AssaysDataTapleByNo);
            //this.assaysDataTapleByNoTableAdapter.FillAssays(this.financialSysDataSet.AssaysDataTapleByNo);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_AssaysKind' table. You can move, or remove it, as needed.
            this.tbl_AssaysKindTableAdapter.Fill(this.financialSysDataSet.Tbl_AssaysKind);

            //tblAssaysBindingSource.DataSource = FsDb.Tbl_Management.ToList();
            //AutoCompleteStringCollection Mng = new AutoCompleteStringCollection();
            //foreach (Tbl_Management M in tblAssaysBindingSource.DataSource as List<Tbl_Management>)
            //    Mng.Add(M.Name);

            //txtManagement.AutoCompleteCustomSource = Mng;

            cmbAssaysKind.SelectedIndex = -1;
            cmbAssaysKind.SelectedText = "اختر نوع المقايسه";
            cmbAssaysKind.Focus();

        }

        private void cmbAssaysKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAssaysNo.Focus();
            }
        }

        private void txtAssaysNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpAssaysDate.Focus();
            }
        }

        private void dtpAssaysDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtManagement.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 59 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                DateTime Vdt_AssaysDate = Convert.ToDateTime(dtpAssaysDate.Value.ToString("dddd , MMM dd yyyy"));
                int Vint_assKind = int.Parse(cmbAssaysKind.SelectedValue.ToString());
                int Vint_MngId = int.Parse(txtManagementId.Text);
                int Vint_Customer = 0;
                var listCHeckAssays = FsDb.Tbl_Assays.FirstOrDefault(x => x.AssaysNo == txtAssaysNo.Text && x.CustomerId == Vint_Customer);
                if (txtAssaysId.Text == "")
                {
                    if (cmbAssaysKind.SelectedIndex == -1)
                    {
                        MessageBox.Show("من فضلك اختر نوع المقايسه");
                        cmbAssaysKind.Focus();
                    }
                    else if (txtAssaysNo.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل رقم المقايسه");
                        txtAssaysNo.Focus();
                    }
                    else if (dtpAssaysDate.Value == null)
                    {
                        MessageBox.Show("من فضلك ادخل تاريخ المقايسه");
                        dtpAssaysDate.Focus();
                    }
                    else if (txtManagement.Text == "" && txtManagementId.Text == "")
                    {
                        MessageBox.Show("من فضلك اختر الاداره");
                        txtManagement.Focus();

                    }
                    else
                    {

                        Tbl_Assays Ass = new Tbl_Assays
                        {
                            AssaysKindId = int.Parse(cmbAssaysKind.SelectedValue.ToString()),
                            AssaysNo = txtAssaysNo.Text,
                            AssaysDate = Convert.ToDateTime(dtpAssaysDate.Value.ToString()),
                            ManagementID = int.Parse(txtManagementId.Text),
                            CustomerId = int.Parse(txtCustomerId.Text)
                        };
                        FsDb.Tbl_Assays.Add(Ass);
                        FsDb.SaveChanges();
                        int Vint_LastRow = Ass.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مقايسه",
                            TableName = "Tbl_Activities",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة المقايسات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //*******************************
                        MessageBox.Show("تم الحفظ");
                       
                        this.assaysDataTapleByNoTableAdapter.FillAssays(this.financialSysDataSet1.AssaysDataTapleByNo);
                        cmbAssaysKind.SelectedIndex = -1;
                        cmbAssaysKind.SelectedText = "اختر نوع المقايسه";
                        txtAssaysNo.Text = "";
                        dtpAssaysDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                        txtManagementId.Text = "";
                        txtManagement.Text = "";
                        txtCustomerId.Text = "";
                        txtCustomers.Text = "";
                        txtAssaysId.Text = "";

                        cmbAssaysKind.Select();
                        this.ActiveControl = cmbAssaysKind;
                        cmbAssaysKind.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("هذه المقايسه تم ادخالها من قبل");
                    var resultMsg = MessageBox.Show(" " + "هل تريد تعديل هده المقايسه   " + " ؟ ", " تعديل ", MessageBoxButtons.YesNo);
                    if (resultMsg == DialogResult.Yes)
                    {
                        Vint_Customer = int.Parse(txtCustomerId.Text);
                        var listUpdAssays = FsDb.Tbl_Assays.FirstOrDefault(x => x.ID == Vint_AssaysID);
                        listUpdAssays.AssaysNo = txtAssaysNo.Text;
                        listUpdAssays.AssaysDate = Convert.ToDateTime(dtpAssaysDate.Value.ToString("dddd , MMM dd yyyy"));
                        listUpdAssays.AssaysKindId = int.Parse(cmbAssaysKind.SelectedValue.ToString());
                        listUpdAssays.ManagementID = int.Parse(txtManagementId.Text);
                        listUpdAssays.CustomerId = int.Parse(txtCustomerId.Text);
                        FsDb.SaveChanges();
                        int Vint_LastRow = listUpdAssays.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل المقايسه",
                            TableName = "Tbl_Activities",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة المقايسات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //*******************************
                        MessageBox.Show("تم التعديل");
                        this.assaysDataTapleByNoTableAdapter.FillAssays(this.financialSysDataSet1.AssaysDataTapleByNo);
                        cmbAssaysKind.SelectedIndex = -1;
                        cmbAssaysKind.SelectedText = "اختر نوع المقايسه";
                        txtAssaysNo.Text = "";
                        dtpAssaysDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                        txtManagementId.Text = "";
                        txtManagement.Text = "";
                        txtCustomerId.Text = "";
                        txtCustomers.Text = "";
                        txtAssaysId.Text = "";

                        cmbAssaysKind.Select();
                        this.ActiveControl = cmbAssaysKind;
                        cmbAssaysKind.Focus();

                    }
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  المقايسه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void txtManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomers.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.ProcessingForms.FindDepart t = new Forms.ProcessingForms.FindDepart();

                t.ShowDialog();
                txtManagement.Text = Forms.ProcessingForms.FindDepart.SelectedRow.Cells[1].Value.ToString();
                txtManagementId.Text = Forms.ProcessingForms.FindDepart.SelectedRow.Cells[0].Value.ToString();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            cmbAssaysKind.SelectedIndex = -1;
            txtAssaysNo.Text = "";
            dtpAssaysDate.Value = Convert.ToDateTime(DateTime.Now.Date);
            txtManagementId.Text = "";
            txtManagement.Text = "";

            Vint_AssaysID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtAssaysId.Text = Vint_AssaysID.ToString();

            var result = FsDb.Tbl_Assays.FirstOrDefault(x => x.ID == Vint_AssaysID);
            cmbAssaysKind.SelectedValue = result.AssaysKindId;
            txtAssaysNo.Text = result.AssaysNo;
            dtpAssaysDate.Value = Convert.ToDateTime(result.AssaysDate);
            txtManagementId.Text = result.ManagementID.ToString();
            txtManagement.Text = result.Tbl_Management.Name;
            txtCustomerId.Text = result.CustomerId.ToString();
            txtCustomers.Text = result.Tbl_Customer.Name;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 59 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result = FsDb.Tbl_Assays.Find(Vint_AssaysID);
                if (result != null)
                {
                    var resultMsg = MessageBox.Show(" " + "هل تريد حدف هده المقايسه   " + " ؟ ", "حدف مقايسه ", MessageBoxButtons.YesNo);
                    if (resultMsg == DialogResult.Yes)
                    {
                        var listdassays = FsDb.Tbl_Order.SingleOrDefault(x => x.ID == Vint_AssaysID);
                        if (listdassays != null)
                        {
                            MessageBox.Show(" لايمكن حدف هده المقايسه لانها مسجله على  اوامر ");
                        }
                        else
                        {
                            FsDb.Tbl_Assays.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRow = sup.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف مقايسه",
                                TableName = "Tbl_Assays",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة المقايسات"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************

                            MessageBox.Show("تم الحدف");

                            cmbAssaysKind.SelectedIndex = -1;
                            cmbAssaysKind.SelectedText = "اختر نوع المقايسه";
                            txtAssaysNo.Text = "";
                            dtpAssaysDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                            txtManagementId.Text = "";
                            txtManagement.Text = "";
                            txtCustomerId.Text = "";
                            txtCustomers.Text = "";
                            txtAssaysId.Text = "";
                            this.assaysDataTapleByNoTableAdapter.FillAssays(this.financialSysDataSet1.AssaysDataTapleByNo);

                            cmbAssaysKind.Select();
                            this.ActiveControl = cmbAssaysKind;
                            cmbAssaysKind.Focus();


                        }
                    }
                    this.assaysDataTapleByNoTableAdapter.FillAssays(this.financialSysDataSet1.AssaysDataTapleByNo);
                    cmbAssaysKind.Select();
                    this.ActiveControl = cmbAssaysKind;
                    cmbAssaysKind.Focus();

                }
                else
                {
                    MessageBox.Show("حدد المقايسه المراد حدفها");
                    txtAssaysNo.Text = "";
                    dtpAssaysDate.Value = Convert.ToDateTime(DateTime.Now.Date);
                    txtManagementId.Text = "";
                    txtManagement.Text = "";
                    txtCustomerId.Text = "";
                    txtCustomers.Text = "";
                    txtAssaysId.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  المقايسه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void txtAssaysNo_TextChanged(object sender, EventArgs e)
        {
            this.assaysDataTapleByNoTableAdapter.FillByAssNo(this.financialSysDataSet1.AssaysDataTapleByNo,txtAssaysNo.Text);
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.ProcessingForms.FindCustomersFrm t = new Forms.ProcessingForms.FindCustomersFrm();

                t.ShowDialog();
                txtCustomers.Text = Forms.ProcessingForms.FindCustomersFrm.SelectedRow.Cells[1].Value.ToString();
                txtCustomerId.Text = Forms.ProcessingForms.FindCustomersFrm.SelectedRow.Cells[0].Value.ToString();

            }
        }

       
    }
}