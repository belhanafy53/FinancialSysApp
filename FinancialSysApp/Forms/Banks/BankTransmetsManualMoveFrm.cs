using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Export.Pdf;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks
{
    public partial class BankTransmetsManualMoveFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankDepositeId = 0;
        int? Vint_BankAccId = 0;
        DateTime Vd_MovDate = DateTime.Today;
        DateTime Vd_DueDate = DateTime.Today;
        decimal Vd_TransferValue = 0;
        decimal Vd_BalanceValue = 0;
        string Vst_KindPr = "";
        string Vst_DescriptionPr = "";
        //DateTime? Vd_Date = null;
        string Vst_FinancialYear = "";
        string Vst_CodeGenerate = "";
        int? Vint_MoveType = null;
        int? Vint_MoveType1 = null;
        public BankTransmetsManualMoveFrm()
        {
            InitializeComponent();
        }

        private void BankTransmetsManualMoveFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
           
           
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            txtRowId.Text = "";
            cmbBank.Text = "اختر البنك";
            cmbDebitCredit.Text = "اختر نوع الحركه";
            DTPMov.Select();
            this.ActiveControl = DTPMov;
            DTPMov.Focus();
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBank.SelectedValue != null)
                {
                    Vint_BankDepositeId = int.Parse(cmbBank.SelectedValue.ToString());
                    //*************ارقام الحسابات



                    var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                    cmbAccBank.DataSource = listAccBank;
                    cmbAccBank.DisplayMember = "AccountBankNo";
                    cmbAccBank.ValueMember = "ID";
                    int Vin_countItem = cmbAccBank.Items.Count;
                    if (cmbAccBank.Items.Count > 1)
                    {
                        cmbAccBank.SelectedIndex = -1;
                        cmbAccBank.Text = "اختر رقم الحساب";
                        txtRowId.Text = "";
                        cmbAccBank.Select();
                        this.ActiveControl = cmbAccBank;
                        cmbAccBank.Focus();
                    }
                    else
                    {
                        Vd_MovDate = Convert.ToDateTime(DTPMov.Value.ToString("yyyy-MM-dd"));
                        Vint_BankDepositeId = int.Parse(cmbBank.SelectedValue.ToString());
                        if (cmbAccBank.SelectedValue != null)
                        {
                            Vint_BankAccId = int.Parse(cmbAccBank.SelectedValue.ToString());
                            var list_TransmetBankMovDate = FsDb.Tbl_BankMovement.Where(x => x.MoveDat == Vd_MovDate && x.BankID == Vint_BankDepositeId && x.BankAccID == Vint_BankAccId).ToList();
                            dataGridView1.DataSource = list_TransmetBankMovDate;
                            GrdTRCollctionCheq();
                            LoadSerial();
                            txtRowId.Text = "";
                        }
                        DTPDue.Select();
                        this.ActiveControl = DTPDue;
                        DTPDue.Focus();
                    }
                }
            }
        }

        private void cmbBank_Leave(object sender, EventArgs e)
        {
            if (cmbBank.SelectedValue != null)
            {
                //**************
                Vint_BankDepositeId = int.Parse(cmbBank.SelectedValue.ToString());
                //*************ارقام الحسابات



                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                cmbAccBank.DataSource = listAccBank;
                cmbAccBank.DisplayMember = "AccountBankNo";
                cmbAccBank.ValueMember = "ID";
                int Vin_countItem = cmbAccBank.Items.Count;
                if (cmbAccBank.Items.Count > 1)
                {
                    cmbAccBank.SelectedIndex = -1;
                    cmbAccBank.Text = "اختر رقم الحساب";
                    cmbAccBank.Select();
                    this.ActiveControl = cmbAccBank;
                    cmbAccBank.Focus();
                }
                //****************

            }
        }
        private void GrdTRCollctionCheq()
        {

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["MoveDat"].HeaderText = "تاريخ الحركه";
            dataGridView1.Columns["MoveDat"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["BankDueDate"].HeaderText = "تاريخ الحق";
            dataGridView1.Columns["BankDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["NumberRefrBank"].Visible = false;
            dataGridView1.Columns["DescriptionNote"].HeaderText = "وصف الحركه";
            dataGridView1.Columns["DescriptionNote"].Width = 500;
            dataGridView1.Columns["Currency"].Visible = false;
            dataGridView1.Columns["TransferValue"].HeaderText = "مبلغ الحركه";
            dataGridView1.Columns["DebitCredit"].HeaderText = "نوع الحركه"; ;
            dataGridView1.Columns["DebitCredit"].Width = 50;
            dataGridView1.Columns["Balance"].HeaderText = "الرصيد";
            dataGridView1.Columns["C1"].Visible = false;

            dataGridView1.Columns["C2"].Visible = false;
            dataGridView1.Columns["C22"].Visible = false;
            dataGridView1.Columns["C3"].Visible = false;
            dataGridView1.Columns["C4"].Visible = false;
            dataGridView1.Columns["C5"].Visible = false;
            dataGridView1.Columns["C6"].Visible = false;
            //dataGridView1.Columns["C6"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["BankID"].Visible = false;
            dataGridView1.Columns["BankAccID"].Visible = false;
            dataGridView1.Columns["MovementCode"].Visible = false;
            dataGridView1.Columns["FisicalYeariD"].Visible = false;
            dataGridView1.Columns["MoveType1"].Visible = false;

            dataGridView1.Columns["MoveType2"].Visible = false;
            dataGridView1.Columns["IsSelectedType"].Visible = false;
            dataGridView1.Columns["BankCheqID"].Visible = false;
            dataGridView1.Columns["DepositCashID"].Visible = false;
            dataGridView1.Columns["TransferID"].Visible = false;

            dataGridView1.Columns["Tbl_Banks"].Visible = false;
            dataGridView1.Columns["Tbl_MovementBankType"].Visible = false;

            //dataGridView1.Columns["TransferID"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["IsCollected"].Visible = false;



        }

        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void cmbAccBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vd_MovDate = Convert.ToDateTime(DTPMov.Value.ToString("yyyy-MM-dd"));
                Vint_BankDepositeId = int.Parse(cmbBank.SelectedValue.ToString());
                if (cmbAccBank.SelectedValue != null)
                {
                    Vint_BankAccId = int.Parse(cmbAccBank.SelectedValue.ToString());
                    var list_TransmetBankMovDate = FsDb.Tbl_BankMovement.Where(x => x.MoveDat == Vd_MovDate && x.BankID == Vint_BankDepositeId && x.BankAccID == Vint_BankAccId).ToList();
                    dataGridView1.DataSource = list_TransmetBankMovDate;
                    GrdTRCollctionCheq();
                    LoadSerial();
                }
                txtRowId.Text = "";
                DTPDue.Select();
                this.ActiveControl = DTPDue;
                DTPDue.Focus();

            }
        }

        private void DTPDue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTransferValue.Select();
                this.ActiveControl = txtTransferValue;

                txtTransferValue.Focus();
            }
        }

        private void txtTransferValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDebitCredit.Select();
                this.ActiveControl = cmbDebitCredit;

                cmbDebitCredit.Focus();
            }
        }

        private void cmbDebitCredit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbalance.Select();
                this.ActiveControl = txtbalance;

                txtbalance.Focus();
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Select();
                this.ActiveControl = simpleButton1;
                simpleButton1.Focus();
            }
        }

        private void DTPMov_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBank.Select();
                this.ActiveControl = cmbBank;
                cmbBank.Focus();
            }
        }

        private void cmbAccBank_Leave(object sender, EventArgs e)
        {

            int Vint_AccBank = int.Parse(cmbAccBank.SelectedValue.ToString());
            var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
            int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
            var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();


            comboBox2.DataSource = ListPurpose;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
        }

        private void txtbalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Select();
                this.ActiveControl = txtDescription;

                txtDescription.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtRowId.Text == "")
            {
                Vint_BankDepositeId = int.Parse(cmbBank.SelectedValue.ToString());
                Vint_BankAccId = int.Parse(cmbAccBank.SelectedValue.ToString());
                Vd_MovDate = Convert.ToDateTime(DTPMov.Value.ToString("yyyy-MM-dd"));
                Vd_DueDate = Convert.ToDateTime(DTPDue.Value.ToString("yyyy-MM-dd"));
                if (txtTransferValue.Text != "")
                { Vd_TransferValue = decimal.Parse(txtTransferValue.Text); }
                else
                {  Vd_TransferValue = 0; }
                if (txtbalance.Text != "")
                {
                    Vd_BalanceValue = decimal.Parse(txtbalance.Text);
                }
                else
                {
                    Vd_TransferValue = 0;
                }
                Vst_KindPr = cmbDebitCredit.Text;
                Vst_DescriptionPr = txtDescription.Text;
                int Vint_FiscYear = int.Parse(comboBox3.SelectedValue.ToString());
                int Vint_CountMb = FsDb.Tbl_BankMovement.Where(x => x.BankID == Vint_BankDepositeId && x.BankAccID == Vint_BankAccId && x.FisicalYeariD == Vint_FiscYear).Count();
                //string Vst_FinancialYear = FsDb.Tbl_Fiscalyear.Where(x => x.ID == Vint_FiscYear).Select(x => x.Name).FirstOrDefault();
                //string Vst_CodeGenerate = Vst_FinancialYear + "/" + Vint_BankDepositeId.ToString() + "/" + Vint_BankAccId.ToString() + "/" + (Vint_CountMb + 1).ToString();
                //************************** كود حركة البنك

                //Vd_Date = Convert.ToDateTime(Vd_MovDate);

                var listOfYear = FsDb.Tbl_Fiscalyear.Where(x => x.DateFrom <= Vd_MovDate && x.DateTo >= Vd_MovDate).ToList();
                if (listOfYear.Count > 0)
                {
                  string  Vst_YearMovDate = listOfYear[0].FinancialYear.ToString();
                    Vint_FiscYear = int.Parse(listOfYear[0].ID.ToString());
                }
                Vst_FinancialYear = FsDb.Tbl_Fiscalyear.Where(x => x.ID == Vint_FiscYear).Select(x => x.FinancialYear).FirstOrDefault();

                Vint_CountMb = FsDb.Tbl_BankMovement.Where(x => x.FisicalYeariD == Vint_FiscYear).Count();

                Vst_CodeGenerate = Vst_FinancialYear + "/" + (Vint_CountMb + 1).ToString();
                //**************************
                if (Vint_BankAccId == 10 && Vst_KindPr == "دائن")
                {
                    Vint_MoveType = 5;
                    Vint_MoveType1 = 15;
                }
                Tbl_BankMovement bnm = new Tbl_BankMovement()
                {
                    MoveDat = Vd_MovDate,
                    BankDueDate = Vd_DueDate,

                    DescriptionNote = Vst_DescriptionPr,

                    TransferValue = Vd_TransferValue,
                    DebitCredit = Vst_KindPr,
                    Balance = Vd_BalanceValue,
                    Currency = "EGP",
                    BankID = Vint_BankDepositeId,
                    BankAccID = Vint_BankAccId,
                    MovementCode = Vst_CodeGenerate,
                    FisicalYeariD = Vint_FiscYear,
                    IsSelectedType = false,
                    BankCheqID = 0,
                    DepositCashID = 0,
                    TransferID = 0,
                    IsCollected = false,
                    MoveType1 = Vint_MoveType,
                    MoveType2 = Vint_MoveType1
                };
                FsDb.Tbl_BankMovement.Add(bnm);
                FsDb.SaveChanges();
                long Vlng_LastRowDepositCash = bnm.ID;
                MessageBox.Show("تم الحفظ");

                //---------------خفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "تعديل حركة حساب بنك",
                    TableName = "Tbl_BankMovement",
                    TableRecordId = Vlng_LastRowDepositCash.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة حركة حساب بنك يدوي"

                };

                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //************************************
                ClearData();
                var list_TransmetBankMovDate = FsDb.Tbl_BankMovement.Where(x => x.MoveDat == Vd_MovDate && x.BankID == Vint_BankDepositeId && x.BankAccID == Vint_BankAccId).ToList();
                dataGridView1.DataSource = list_TransmetBankMovDate;
                GrdTRCollctionCheq();
                LoadSerial();
            }
            else
            {
                long Vlng_MovbnkId = long.Parse(txtRowId.Text);
                var list_TransmetBankMovDate = FsDb.Tbl_BankMovement.Where(x => x.ID == Vlng_MovbnkId).ToList();

                list_TransmetBankMovDate[0].BankID = int.Parse(cmbBank.SelectedValue.ToString());
                list_TransmetBankMovDate[0].BankAccID = int.Parse(cmbAccBank.SelectedValue.ToString());
                list_TransmetBankMovDate[0].MoveDat = Convert.ToDateTime(DTPMov.Value.ToString("yyyy-MM-dd"));
                list_TransmetBankMovDate[0].BankDueDate = Convert.ToDateTime(DTPDue.Value.ToString("yyyy-MM-dd"));
                list_TransmetBankMovDate[0].TransferValue = decimal.Parse(txtTransferValue.Text);
                list_TransmetBankMovDate[0].Balance = decimal.Parse(txtbalance.Text);
                list_TransmetBankMovDate[0].DebitCredit = cmbDebitCredit.Text;
                list_TransmetBankMovDate[0].DescriptionNote = txtDescription.Text;
                FsDb.SaveChanges();
             
                MessageBox.Show("تم التعديل");
                //---------------خفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "تعديل حركة حساب بنك",
                    TableName = "Tbl_BankMovement",
                    TableRecordId = Vlng_MovbnkId.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة حركة حساب بنك يدوي"

                };

                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //************************************
                ClearData();
                var list_TransmetBankMovDateN = FsDb.Tbl_BankMovement.Where(x => x.MoveDat == Vd_MovDate && x.BankID == Vint_BankDepositeId && x.BankAccID == Vint_BankAccId).ToList();
                dataGridView1.DataSource = list_TransmetBankMovDateN;
                GrdTRCollctionCheq();
                LoadSerial();
            }
            DTPDue.Focus();
        }
        private void ClearData()
        {
            txtTransferValue.Text = string.Empty;
            txtbalance.Text = string.Empty;
            txtDescription.Text = string.Empty;
            DTPDue.Value = DateTime.Today;
            cmbDebitCredit.SelectedIndex = 0;
            cmbDebitCredit.Text = "اختر نوع الحركه";

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtRowId.Text = "";
            txtRowId.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           
            DTPDue.Value =Convert.ToDateTime( dataGridView1.CurrentRow.Cells[3].Value.ToString());

            txtTransferValue.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cmbDebitCredit.SelectedIndex = 0;
            cmbDebitCredit.Text = "";
            cmbDebitCredit.SelectedText  = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtbalance.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtDescription.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            long Vlng_MovbnkId = long.Parse(txtRowId.Text);
            var list_TransmetBankMovDate = FsDb.Tbl_BankMovement.FirstOrDefault(x => x.ID == Vlng_MovbnkId);
            var resultMessageYesNo = MessageBox.Show("هل تريد حدف هده الحركه من كشف الحساب   ؟", "حدف  حركة كشف حساب ", MessageBoxButtons.YesNo);

            if (resultMessageYesNo == DialogResult.Yes)
            {
                FsDb.Tbl_BankMovement.Remove(list_TransmetBankMovDate);
                FsDb.SaveChanges();
                MessageBox.Show("تم الحذف");
                //---------------خفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "حذف حركة حساب بنك",
                    TableName = "Tbl_BankMovement",
                    TableRecordId = Vlng_MovbnkId.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة حركة حساب بنك يدوي"

                };

                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //************************************

                ClearData();
                var list_TransmetBankMovDateN = FsDb.Tbl_BankMovement.Where(x => x.MoveDat == Vd_MovDate && x.BankID == Vint_BankDepositeId && x.BankAccID == Vint_BankAccId).ToList();
                dataGridView1.DataSource = list_TransmetBankMovDateN;
                GrdTRCollctionCheq();
                LoadSerial();
            }
        }
    }
}
