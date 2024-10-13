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
    public partial class BankStatSettingFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_BankId = 0;
        public BankStatSettingFrm()
        {
            InitializeComponent();
        }

        private void BankStatmentSetting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_MovementBankType' table. You can move, or remove it, as needed.
            this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_BankStringCHeqCash' table. You can move, or remove it, as needed.
            this.tbl_BankStringCHeqCashTableAdapter.Fill(this.bankTransmentDS.Tbl_BankStringCHeqCash);
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_MovementBankType' table. You can move, or remove it, as needed.
            //this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_BankStringCHeqCash' table. You can move, or remove it, as needed.
            //this.tbl_BankStringCHeqCashTableAdapter.Fill(this.bankTransmentDS.Tbl_BankStringCHeqCash);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            //this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_BankCheque' table. You can move, or remove it, as needed.
            //this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            //this.dtb_BankChequeTableAdapter.Fill(this.bankCheques.Dtb_BankCheque);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            LoadSerial();
            ClearData();
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر البنك";

            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي ";

            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي ";

            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Vint_bankid = int.Parse(comboBox1.SelectedValue.ToString());
                this.tbl_BankStringCHeqCashTableAdapter.FillByBank(this.bankTransmentDS.Tbl_BankStringCHeqCash, Vint_bankid);
                LoadSerial();
                comboBox3.Focus();
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

                            //CashString = txtCashF.Text,

                            CheqString1 = txtCheqBankT.Text,
                           MoveType = int.Parse(comboBox3.SelectedValue.ToString()),
                            MoveType1 = int.Parse(comboBox4.SelectedValue.ToString()),
                            //TransferString1 = txtTransferT.Text,
                            //CheqExString = txtCheqExpBankF.Text,
                            //CheqExString1 = txtCheqExpBankT.Text,
                            //TransferExString = txtTransferExpF.Text,
                            //TransferExString1 = txtTransferExpT.Text,
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
                        LoadSerial();
                        ClearDataDatailsBank();
                        comboBox3.Focus();

                    }
                    else
                    {
                        int Vint_RowID = int.Parse(txtRowId.Text);
                        Vint_BankId = int.Parse(comboBox1.SelectedValue.ToString());
                        var List = FsDb.Tbl_BankStringCHeqCash.Where(x => x.ID == Vint_RowID).ToList();
                        List[0].BankID = Vint_BankId;
                        List[0].CheqString = txtCheqBankF.Text;
                        List[0].CheqString1 = txtCheqBankT.Text;

                        List[0].MoveType = int.Parse(comboBox3.SelectedValue.ToString());
                        List[0].MoveType1 = int.Parse(comboBox4.SelectedValue.ToString());
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
                        LoadSerial();
                        ClearDataDatailsBank();
                        comboBox3.Focus();
                    }
                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearDataDatailsBank();
            this.tbl_BankStringCHeqCashTableAdapter.Fill(this.bankTransmentDS.Tbl_BankStringCHeqCash);
        }
        private void ClearData()
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر البنك";

            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي";

            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي";

            txtRowId.Text = string.Empty;

            txtCheqBankF.Text = string.Empty;
            txtCheqBankT.Text = string.Empty;
            


        }
        private void ClearDataDatailsBank()
        {
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي";

            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي";

            txtRowId.Text = string.Empty;

            txtCheqBankF.Text = string.Empty;
            txtCheqBankT.Text = string.Empty;
            //txtCheqExpBankF.Text = string.Empty;
            //txtCheqExpBankT.Text = string.Empty;

            //txtCashF.Text = string.Empty;
            //txtCashT.Text = string.Empty;

            //txtTransferF.Text = string.Empty;
            //txtTransferT.Text = string.Empty;
            //txtTransferExpF.Text = string.Empty;
            //txtTransferExpT.Text = string.Empty;



        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ClearData();
            int Vint_rowID = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            var list_BankSetting = FsDb.Tbl_BankStringCHeqCash.Where(x => x.ID == Vint_rowID).ToList();

            txtRowId.Text = Vint_rowID.ToString();
            comboBox1.SelectedValue = int.Parse(list_BankSetting[0].BankID.ToString());

        

            if (list_BankSetting[0].MoveType != null )
            {
                int Vint_movtype = int.Parse(list_BankSetting[0].MoveType.ToString());
                comboBox3.SelectedValue = Vint_movtype;
                var ListChType = FsDb.Tbl_MovementBankType.Where(x => x.MoveType == Vint_movtype).ToList();
                comboBox4.DataSource = ListChType;
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
            }
             
            if (list_BankSetting[0].MoveType1 != null)
            {

               
              int Vint_movtype1 =  int.Parse(list_BankSetting[0].MoveType1.ToString());
                comboBox4.SelectedValue = Vint_movtype1;
            }

            if (list_BankSetting[0].CheqString != "" && list_BankSetting[0].CheqString != null)
            {
                            txtCheqBankF.Text = list_BankSetting[0].CheqString.ToString(); }

            if (list_BankSetting[0].CheqString1 != "" && list_BankSetting[0].CheqString1 != null)
            { txtCheqBankT.Text = list_BankSetting[0].CheqString1.ToString(); }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                int Vint_MovBnkTypeM = int.Parse(comboBox3.SelectedValue.ToString());

                comboBox4.Focus();
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_type1 = int.Parse(comboBox3.SelectedValue.ToString());
            var listType = FsDb.Tbl_MovementBankType.Where(x => x.MoveType == Vint_type1).ToList();
            if (listType.Count > 0)
            {

                comboBox4.DataSource = listType;
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";
                comboBox4.Text = "";
                comboBox4.SelectedIndex = -1;
                comboBox4.Text = "اختر التصنيف الفرعي";
               
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                simpleButton7.Focus();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 110 && w.ProcdureId == 4);
            if (validationSaveUser == null)
            {
                MessageBox.Show("ليس لديك صلاحية حذف اعدادات البنوك للكلمات الافتتاحيه .. برجاء مراجعة مدير المنظومه");
                return;
            }
            else
            {
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("من فضلك اختر البنك المراد حذف اعدادات الكلمات الافتتاحيه لكشوف الحساب الخاصه به");
                }
                else
                {
                    if (txtRowId.Text != "")
                    {


                     int    Vint_RowId = int.Parse(txtRowId.Text);
                        var Result = FsDb.Tbl_BankStringCHeqCash.FirstOrDefault(x => x.ID == Vint_RowId);
                        var resultMsg = MessageBox.Show("هل تريد حدف هذه الكلمه الافتتاحيه لهذا البنك" + " ؟ ", "حدف اعدادات بنكيه ", MessageBoxButtons.YesNo);
                        if (resultMsg == DialogResult.Yes)
                        {
                            FsDb.Tbl_BankStringCHeqCash.Remove(Result);
                            FsDb.SaveChanges();
                            //-------------حدف الاحداث 
                            string Vstr_tblRecord = Result.ID.ToString();
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حدف اعدادات بنك",
                                TableName = "Tbl_BankStringCHeqCash",
                                TableRecordId = Vstr_tblRecord,
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة الكلمات الافتتاحيه"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //-------------------------

                            MessageBox.Show("  تم الحدف");
                            this.tbl_BankStringCHeqCashTableAdapter.Fill(this.bankTransmentDS.Tbl_BankStringCHeqCash);
                        }

                    }
                }
            }
        }
    }
}