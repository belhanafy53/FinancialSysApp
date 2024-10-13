 
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

namespace FinancialSysApp.Forms.Banks
{
    public partial class BankStFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_BankId = 0;
        public BankStFrm()
        {
            InitializeComponent();
        }

        private void BankStatmentsSettingFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_BankStringCHeqCash' table. You can move, or remove it, as needed.
            this.tbl_BankStringCHeqCashTableAdapter.Fill(this.bankTransmentDS.Tbl_BankStringCHeqCash);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_BankCheque' table. You can move, or remove it, as needed.
            //this.dtb_BankChequeTableAdapter.Fill(this.bankCheques.Dtb_BankCheque);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            ClearData();
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر البنك";
            comboBox1.Focus();

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Vint_bankid = int.Parse(comboBox1.SelectedValue.ToString());
                this.tbl_BankStringCHeqCashTableAdapter.FillByBank(this.bankTransmentDS.Tbl_BankStringCHeqCash, Vint_bankid);
                txtCheqBankF.Focus();
            }
        }

        private void txtCheqBankF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCheqBankT.Focus();
            }
        }

        private void txtCheqBankT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCashF.Focus();
            }
        }

        private void txtCashF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCashT.Focus();
            }
        }

        private void txtCashT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTransferF.Focus();
            }
            
        }

        private void txtTransferF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTransferT.Focus();
            }

        }

        private void txtTransferT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCheqExpBankF.Focus();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 110 && w.ProcdureId == 1);
            if (validationSaveUser == null)
            {
                MessageBox.Show("ليس لديك صلاحية اضافة اعدادات البنوك للكلمات الافتتاحيه .. برجاء مراجعة مدير المنظومه");
                return;
            }
            else
            {
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("من فضلك اختر البنك المراد اضافة اعدادات الكلمات الافتتاحيه لكشوف الحساب الخاصه به");
                }
                else
                {
                    if (txtRowId.Text == "")
                    {


                        Vint_BankId = int.Parse(comboBox1.SelectedValue.ToString());

                        Tbl_BankStringCHeqCash BnkStrCh = new Tbl_BankStringCHeqCash
                        {
                            BankID = Vint_BankId,
                            CheqString = txtCheqBankF.Text,

                            ////CashString = txtCashF.Text,

                            ////CheqString1 = txtCheqBankT.Text,
                            ////CashString1 = txtCashT.Text,
                            ////TransferString = txtTransferF.Text,
                            ////TransferString1 = txtTransferT.Text,
                            ////CheqExString = txtCheqExpBankF.Text,
                            ////CheqExString1 = txtCheqExpBankT.Text,
                            ////TransferExString = txtTransferExpF.Text,
                            ////TransferExString1 = txtTransferExpT.Text,
                        };
                        FsDb.Tbl_BankStringCHeqCash.Add(BnkStrCh);
                        FsDb.SaveChanges();
                        int Vint_lastRecord = BnkStrCh.ID;
                        int Vint_bankid = int.Parse(comboBox1.SelectedValue.ToString());
                        
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة اعدادات البنوك للكلمات الافتتاحيه",
                            TableName = "Tbl_TreasuryCollection",
                            TableRecordId = Vint_lastRecord.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اعدادات البنوك للكلمات الافتتاحيه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحفظ");
                        this.tbl_BankStringCHeqCashTableAdapter.FillByBank(this.bankTransmentDS.Tbl_BankStringCHeqCash, Vint_bankid);
                        ClearData();
                        txtCheqBankF.Focus();
                       
                    }
                    else
                    {
                        int Vint_RowID = int.Parse(txtRowId.Text);
                        Vint_BankId = int.Parse(comboBox1.SelectedValue.ToString());
                        var List = FsDb.Tbl_BankStringCHeqCash.Where(x=>x.ID == Vint_RowID).ToList();
                        List[0].BankID = Vint_BankId;
                        List[0].CheqString = txtCheqBankF.Text;
                        List[0].CheqString1 = txtCheqBankT.Text;
                        //List[0].CheqExString = txtCheqExpBankF.Text;
                        //List[0].CheqExString1 = txtCheqExpBankT.Text;

                        //List[0].CashString = txtCashF.Text;
                        //List[0].CashString1 = txtCashT.Text;

                        //List[0].TransferString = txtTransferF.Text;
                        //List[0].TransferString1 = txtTransferT.Text;
                        //List[0].TransferExString = txtTransferExpF.Text;
                        //List[0].TransferExString1 = txtTransferExpT.Text;

                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل اعدادات البنوك للكلمات الافتتاحيه",
                            TableName = "Tbl_TreasuryCollection",
                            TableRecordId = Vint_RowID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اعدادات البنوك للكلمات الافتتاحيه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        int Vint_bankid = int.Parse(comboBox1.SelectedValue.ToString());
                        this.tbl_BankStringCHeqCashTableAdapter.FillByBank(this.bankTransmentDS.Tbl_BankStringCHeqCash, Vint_bankid);
                        ClearData();
                        txtCheqBankF.Focus();
                    }
                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearDataDatailsBank();
            this.tbl_BankStringCHeqCashTableAdapter.Fill(this.bankTransmentDS.Tbl_BankStringCHeqCash);
        }
        private void ClearData ()
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر البنك";
            txtRowId.Text = string.Empty;

            txtCheqBankF.Text = string.Empty;
            txtCheqBankT.Text = string.Empty;
            txtCheqExpBankF.Text = string.Empty;
            txtCheqExpBankT.Text = string.Empty;

            txtCashF.Text = string.Empty;
            txtCashT.Text = string.Empty;

            txtTransferF.Text = string.Empty;
            txtTransferT.Text = string.Empty;
            txtTransferExpF.Text = string.Empty;
            txtTransferExpT.Text = string.Empty;
            
           

        }
        private void ClearDataDatailsBank()
        {
             
            txtRowId.Text = string.Empty;

            txtCheqBankF.Text = string.Empty;
            txtCheqBankT.Text = string.Empty;
            txtCheqExpBankF.Text = string.Empty;
            txtCheqExpBankT.Text = string.Empty;

            txtCashF.Text = string.Empty;
            txtCashT.Text = string.Empty;

            txtTransferF.Text = string.Empty;
            txtTransferT.Text = string.Empty;
            txtTransferExpF.Text = string.Empty;
            txtTransferExpT.Text = string.Empty;



        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ClearData();
            int Vint_rowID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var list_BankSetting = FsDb.Tbl_BankStringCHeqCash.Where(x => x.ID == Vint_rowID).ToList();
            txtRowId.Text = Vint_rowID.ToString();
            comboBox1.SelectedValue = int.Parse(list_BankSetting[0].BankID.ToString());
           if (list_BankSetting[0].CheqString != ""&& list_BankSetting[0].CheqString != null) 
            { txtCheqBankF.Text = list_BankSetting[0].CheqString.ToString(); }
            if (list_BankSetting[0].CheqString1 != "" && list_BankSetting[0].CheqString1 != null)
            { txtCheqBankT.Text = list_BankSetting[0].CheqString1.ToString(); }
            //if (list_BankSetting[0].CheqExString != "" && list_BankSetting[0].CheqExString != null)
            //{ txtCheqExpBankF.Text = list_BankSetting[0].CheqExString.ToString(); }
            //if (list_BankSetting[0].CheqExString1 != "" && list_BankSetting[0].CheqExString1 != null)
            //{
            //    txtCheqExpBankT.Text = list_BankSetting[0].CheqExString1.ToString();
            //}
            //if (list_BankSetting[0].CashString != "" && list_BankSetting[0].CashString != null)
            //{
            //    txtCashF.Text = list_BankSetting[0].CashString.ToString();
            //}
            //if (list_BankSetting[0].CashString1 != "" && list_BankSetting[0].CashString1 != null)
            //{
            //    txtCashT.Text = list_BankSetting[0].CashString1.ToString();
            //}
            //if (list_BankSetting[0].TransferString != "" && list_BankSetting[0].TransferString != null)
            //{
            //    txtTransferF.Text = list_BankSetting[0].TransferString.ToString();
            //}
            //if (list_BankSetting[0].TransferString1 != "" && list_BankSetting[0].TransferString1 != null)
            //{
            //    txtTransferT.Text = list_BankSetting[0].TransferString1.ToString();
            //}
            //if (list_BankSetting[0].TransferExString != "" && list_BankSetting[0].TransferExString != null)
            //{
            //    txtTransferExpF.Text = list_BankSetting[0].TransferExString.ToString();
            //}
            //if (list_BankSetting[0].TransferExString1 != "" && list_BankSetting[0].TransferExString1 != null)
            //{
            //    txtTransferExpT.Text = list_BankSetting[0].TransferExString1.ToString();
            //}

        }

        private void txtCheqExpBankF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCheqExpBankT.Focus();
            }
        }

        private void txtCheqExpBankT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTransferExpF.Focus();
            }
           
        }

        private void txtTransferExpF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTransferExpT.Focus();
            }
        }

        private void txtTransferExpT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton7.Focus();
            }
        }
    }
}
