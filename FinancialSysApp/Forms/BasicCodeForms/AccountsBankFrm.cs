using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.Classes;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class AccountsBankFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_rowid = 0;
        int Vint_bankid = 0;
        public AccountsBankFrm()
        {
            InitializeComponent();
        }

        private void txtBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBanksFrm t = new Forms.BasicCodeForms.FindBanksFrm();
                t.ShowDialog();

                if (t.txtBankId != null)
                {

                    txtBank.Text = t.txtSelected.Text;
                    txtBankID.Text = t.txtBankId.Text;
                    //if (txtBankID.Text == "")
                    //{
                    int Vint_bankid = int.Parse(txtBankID.Text);
                    if (Vint_bankid == 1)
                    { Vint_bankid = 2004; }
                    else if (Vint_bankid == 2013)
                    { Vint_bankid = 2014; }
                    //var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_bankid).ToList();
                    this.dtb_AccBankTableAdapter.Fill(this.bankCheques.Dtb_AccBank, Vint_bankid);
                    //}
                }
                cmbKindAccBank.Focus();
            }
        }

        private void AccountsBankFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Accounting_Guid' table. You can move, or remove it, as needed.
            this.tbl_Accounting_GuidTableAdapter.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccountsBank' table. You can move, or remove it, as needed.
            this.dtb_AccBankTableAdapter.FillByAll(this.bankCheques.Dtb_AccBank);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccountsBankPurpose1' table. You can move, or remove it, as needed.
            this.tbl_AccountsBankPurpose1TableAdapter.Fill(this.bankCheques.Tbl_AccountsBankPurpose1);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccountsBank' table. You can move, or remove it, as needed.
            //this.dtb_AccBankTableAdapter.Fill(this.bankCheques.Tbl_AccountsBank);

            // TODO: This line of code loads data into the 'bankCheques1.Tbl_AccountsBank' table. You can move, or remove it, as needed.
            //this.tbl_AccountsBankTableAdapter.Fill(this.bankCheques1.Tbl_AccountsBank);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccoiuntBankKind' table. You can move, or remove it, as needed.
            this.tbl_AccoiuntBankKindTableAdapter.Fill(this.bankCheques.Tbl_AccoiuntBankKind);
            cmbKindAccBank.Text = "";
            cmbKindAccBank.SelectedIndex = -1;
            cmbKindAccBank.Text = "اختر نوع الحساب";

            cmbAccPurpose.Text = "";
            cmbAccPurpose.SelectedIndex = -1;
            cmbAccPurpose.Text = "اختر الغرض الحساب";
            dateTimePicker2.Value = Convert.ToDateTime(dateTimePicker1.Value.AddYears(5).ToString());
        }

        private void cmbKindAccBank_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbKindAccBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Vint_bankid = int.Parse(txtBankID.Text);
                if (Vint_bankid == 1)
                { Vint_bankid = 2004; }
                else if (Vint_bankid == 2013)
                { Vint_bankid = 2014; }
                int Vin_kindID = int.Parse(cmbKindAccBank.SelectedValue.ToString());
                //var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_bankid).ToList();
                this.dtb_AccBankTableAdapter.FillByBankIDAccKindID(this.bankCheques.Dtb_AccBank, Vin_kindID, Vint_bankid);
                txtAccBank.Focus();


            }
        }

        private void txtAccBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Vint_bankid = int.Parse(txtBankID.Text);
                if (Vint_bankid == 1)
                { Vint_bankid = 2004; }
                else if (Vint_bankid == 2013)
                { Vint_bankid = 2014; }
                int Vin_kindID = int.Parse(cmbKindAccBank.SelectedValue.ToString());
                string Vst_AccNo = txtAccBank.Text;
                this.dtb_AccBankTableAdapter.FillByBankIDAccNo(this.bankCheques.Dtb_AccBank, Vint_bankid, Vin_kindID, Vst_AccNo);
                dateTimePicker1.Focus();
            }
        }
        private void ClearDataMaster(int vint_bnkid)
        {
            cmbKindAccBank.Text = "";
            cmbKindAccBank.SelectedIndex = -1;
            cmbKindAccBank.Text = "اختر نوع الحساب";
            this.dtb_AccBankTableAdapter.Fill(this.bankCheques.Dtb_AccBank, vint_bnkid);
            cmbAccPurpose.Text = "";
            cmbAccPurpose.SelectedIndex = -1;
            cmbAccPurpose.Text = "اختر الغرض من الحساب";

            txtAccBank.Text = "";
            txtAccBankID.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Today.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(DateTime.Today.ToString());
            cmbKindAccBank.Focus();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            FinancialYearDueDate f = new FinancialYearDueDate();
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 96 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                int Vlng_LastRowAccbank = 0;
                int Vlng_GuedAcc = 0;
                if (txtRowID.Text == "")
                {

                    if (txtBank.Text == "")
                    { MessageBox.Show("من فضلك قم باختيار البنك "); txtBank.Focus(); }
                    else if (txtAccBank.Text == "")
                    { MessageBox.Show("من فضلك ادخل رقم الحساب "); txtAccBank.Focus(); }
                    else
                    {
                        //int Vint_BankID = int.Parse(txtBankID.Text);
                        Vint_bankid = int.Parse(txtBankID.Text);
                        if (Vint_bankid == 1)
                        { Vint_bankid = 2004; }
                        else if (Vint_bankid == 2013)
                        { Vint_bankid = 2014; }
                        int Vint_AccKindID = int.Parse(cmbKindAccBank.SelectedValue.ToString());
                        int? Vint_AccBankPurpose = 0;
                        if (cmbAccPurpose.SelectedIndex != -1)
                        { Vint_AccBankPurpose = int.Parse(cmbAccPurpose.SelectedValue.ToString()); }
                        if (txtGuidID.Text != "")
                        {
                            Vlng_GuedAcc = int.Parse(txtGuidID.Text);
                        }
                        Tbl_AccountsBank ChAccBnk = new Tbl_AccountsBank
                        {
                            AccountBankNo = txtAccBank.Text,
                            BankID = Vint_bankid,
                            KindAccountBankID = Vint_AccKindID,
                            FromDate = Convert.ToDateTime(dateTimePicker1.Value),
                            ToDate = Convert.ToDateTime(dateTimePicker2.Value),
                            BankAccStatusID = 1,
                            AccPurposeID = Vint_AccBankPurpose,
                            Accounting_GuidID = Vlng_GuedAcc,

                        };
                        FsDb.Tbl_AccountsBank.Add(ChAccBnk);
                        FsDb.SaveChanges();

                        Vlng_LastRowAccbank = ChAccBnk.ID;

                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة حسابات بنكيه",
                            TableName = "Tbl_AccountsBank",
                            TableRecordId = Vlng_LastRowAccbank.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة حسابات البنوك "

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        ////************************************
                        MessageBox.Show("تم الحفظ ");
                        ClearDataMaster(Vint_bankid);
                        this.dtb_AccBankTableAdapter.Fill(this.bankCheques.Dtb_AccBank, Vint_bankid);
                        cmbKindAccBank.Focus();
                    }
                }
                else
                {
                    var validationSaveUserU = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 96 && w.ProcdureId == 3);
                    if (validationSaveUserU != null)
                    {
                        Vint_rowid = int.Parse(txtRowID.Text);
                        var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_rowid).ToList();
                        Vint_bankid = int.Parse(txtBankID.Text);
                        listAccBank[0].BankID = int.Parse(txtBankID.Text);
                        listAccBank[0].AccountBankNo = txtAccBank.Text;
                        listAccBank[0].KindAccountBankID = int.Parse(cmbKindAccBank.SelectedValue.ToString());
                        listAccBank[0].FromDate = Convert.ToDateTime(dateTimePicker1.Value);

                        listAccBank[0].ToDate = Convert.ToDateTime(dateTimePicker2.Value);
                        listAccBank[0].AccPurposeID = int.Parse(cmbAccPurpose.SelectedValue.ToString());
                        listAccBank[0].Accounting_GuidID = int.Parse(txtGuidID.Text);
                        FsDb.SaveChanges();
                        ////---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل حسابات بنكيه",
                            TableName = "Tbl_AccountsBank",
                            TableRecordId = Vint_rowid.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة حسابات البنوك"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        ////************************************
                        MessageBox.Show("تم التعديل ");
                        ClearDataMaster(Vint_bankid);
                        this.dtb_AccBankTableAdapter.Fill(this.bankCheques.Dtb_AccBank, Vint_bankid);
                        txtBank.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  حسابات بنكيه .. برجاء مراجعة مدير المنظومه");
                    }
                }


            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  حسابات بنكيه .. برجاء مراجعة مدير المنظومه");
            }
        }


        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAccPurpose.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Vint_rowid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtRowID.Text = Vint_rowid.ToString();
            var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_rowid).ToList();
            txtBankID.Text = listAccBank[0].BankID.ToString();
            cmbAccPurpose.SelectedValue = int.Parse(listAccBank[0].AccPurposeID.ToString());
            int Vint_BankID = int.Parse(txtBankID.Text);
            var VList_Bank = FsDb.Tbl_Banks.Where(x => x.ID == Vint_BankID).ToList();
            txtBank.Text = VList_Bank[0].Name;
            txtAccBank.Text = listAccBank[0].AccountBankNo;
            cmbKindAccBank.SelectedValue = int.Parse(listAccBank[0].KindAccountBankID.ToString());
            dateTimePicker1.Value = Convert.ToDateTime(listAccBank[0].FromDate.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(listAccBank[0].ToDate.ToString());

        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            dateTimePicker2.Value = Convert.ToDateTime(dateTimePicker1.Value.AddYears(5).ToString());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FinancialYearDueDate f = new FinancialYearDueDate();
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 96 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                var result1 = MessageBox.Show("هل تريد حدف هدا الحساب البنكي  ؟", "حدف بنك ", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    Vint_rowid = int.Parse(txtRowID.Text);
                    var listAcc = FsDb.Tbl_TreasuryCollection.Where(x => x.BankAccounNoID == Vint_rowid).ToList();
                    if (listAcc.Count == 0)
                    {
                        var listAccBank = FsDb.Tbl_AccountsBank.FirstOrDefault(x => x.ID == Vint_rowid);
                        Vint_bankid = int.Parse(listAccBank.BankID.ToString());
                        FsDb.Tbl_AccountsBank.Remove(listAccBank);
                        FsDb.SaveChanges();
                        MessageBox.Show("تم الحذف");
                        this.dtb_AccBankTableAdapter.Fill(this.bankCheques.Dtb_AccBank, Vint_bankid);
                        ClearDataMaster(Vint_bankid);
                        txtBank.Focus();
                    }
                    else
                    {
                        MessageBox.Show("لايمكن حذف هذا الحساب البنكي لأنه تم استخدامه من قبل");
                    }
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  حسابات بنكيه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //ClearDataMaster();
        }

        private void cmbAccPurpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Coral;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text != string.Empty)
            {
                if (dataGridViewX7.Rows.Count == 1)
                {
                    textBox1.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();


                }
                if (dataGridViewX7.Rows.Count > 1)
                {
                    dataGridViewX7.Focus();
                }


                //simpleButton1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Vst_AccountNoSearch = textBox1.Text.Trim();
            this.tbl_Accounting_GuidTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_Accounting_Guid, Vst_AccountNoSearch);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void dataGridViewX7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridViewX7.CurrentRow.Cells[2].Value.ToString();
            txtGuidID.Text = dataGridViewX7.CurrentRow.Cells[0].Value.ToString();
            


        }

        private void dataGridViewX7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = dataGridViewX7.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridViewX7.CurrentRow.Cells[2].Value.ToString();
                txtGuidID.Text = dataGridViewX7.CurrentRow.Cells[0].Value.ToString();
                simpleButton1.Focus();
                
            }
        }
    }
}