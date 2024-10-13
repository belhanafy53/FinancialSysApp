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
using System.IO;
using FinancialSysApp.Forms.DocumentsForms;
using DevComponents.DotNetBar.Controls;

namespace FinancialSysApp.Forms.CashDeposit
{
    public partial class CashDepositFrm : Form
    {
        int Vint_BranchID = 0;
        int Vint_BankDepositeId = 0;
        long Vlng_rowIdDepositCash = 0;
        string Image_Path = "";
        DateTime Vdt_DepositDate = Convert.ToDateTime(DateTime.Today.ToString());
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public CashDepositFrm()
        {
            InitializeComponent();
        }
        private void LoadSerial2()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }

        private void GrdDepositCash()
        {

            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["BranchID"].Visible = false;
            dataGridView2.Columns["BankDepositeID"].Visible = false;
            dataGridView2.Columns["RepresentiveID"].Visible = false;
            dataGridView2.Columns["DepositDate"].Visible = false;
            dataGridView2.Columns["BankAccountID"].Visible = false;
            dataGridView2.Columns["AccountBnkID"].Visible = false;


            dataGridView2.Columns["Name"].Width = 250;
            dataGridView2.Columns["Name"].HeaderText = "البنك";

            dataGridView2.Columns["BranchName"].HeaderText = "الفرع / الجهه";
            dataGridView2.Columns["BranchName"].Width = 120;
            dataGridView2.Columns["DepositCashNo"].HeaderText = "رقم الايداع";
            dataGridView2.Columns["DepositCashNo"].Width = 120;

            dataGridView2.Columns["AmountCash"].HeaderText = "المبلغ المودع";
            dataGridView2.Columns["AmountCash"].Width = 120;
            dataGridView2.Columns["BankDueDate"].HeaderText = "تاريخ الحق";


        }

        private void ClearDataMaster()
        {
            txtRowID.Text = "";
            txtBnkDepositID.Text = "";

            txtAccountBnkID.Text = "";

            txtAccountBnk.Text = "";

            txtAmountCash.Text = "";
            dTpBankDueDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
            textBox1.Text = "";
            textBox2.Text = "";
            txtBranchID.Text = "";
            txtBranch.Text = "";

            txtRepresentiveID.Text = "";
            txtRepresentive.Text = "";
            txtDepositCashNo.Text = "";

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";

            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";
            cmbNote.SelectedIndex = -1;
            cmbNote.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.Text = "اختر الحساب";

        }
        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cmbBnkDeposit.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                t.ShowDialog();
                if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                {
                    txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                    txtBranchID.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                    //************************ رقم الايداع
                    if (txtBranchID.Text != "")
                    {
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                        int Vint_FYear = int.Parse(comboBox1.SelectedValue.ToString());
                        var Vs_YearName = FsDb.Tbl_Fiscalyear.FirstOrDefault(x => x.ID == Vint_FYear);
                        int Vint_CountBrunch = FsDb.Tbl_DepositCash.Where(x => x.BranchID == Vint_BranchID && x.FYear == Vint_FYear).Count();
                        if (Vint_CountBrunch == 0)
                        {
                            txtDepositCashNo.Text = Vs_YearName.Name + "/" + txtBranchID.Text + "/" + "1";
                        }
                        else
                        {
                            txtDepositCashNo.Text = Vs_YearName.Name + "/" + txtBranchID.Text + "/" + (Vint_CountBrunch + 1);
                        }
                    }

                    //**************
                    Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
                    Vint_BranchID = int.Parse(txtBranchID.Text);
                    var list = (from Bch in FsDb.Tbl_DepositCash
                                join BNK in FsDb.Tbl_Banks on Bch.DepositBankID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on Bch.BranchID equals MNG.ID
                                //join rep in FsDb.Tbl_Representatives on Bch.RepresentiveID equals rep.ID
                                where (Bch.BranchID == Vint_BranchID && Bch.DepositDate == Vdt_DepositDate)
                                select new
                                {
                                    ID = Bch.ID,
                                    DepositCashNo = Bch.DepositCashNo,
                                    AmountCash = Bch.AmountCash,
                                    BranchName = MNG.BrancheName,
                                    Name = BNK.Name,
                                    BranchID = Bch.BranchID,
                                    DepositDate = Bch.DepositDate,
                                    BankDepositeID = Bch.DepositBankID,
                                    BankAccountID = Bch.AccBankID,
                                    BankDueDate = Bch.BankDueDate,
                                    AccountBnkID = Bch.AccBankID,
                                    RepresentiveID = Bch.RepresentiveID

                                }).OrderBy(x => x.ID).ToList();
                    //*********************
                    dataGridView2.DataSource = list;



                    LoadSerial2();

                }
                if (txtBranchID.Text != "")
                {
                    cmbBnkDeposit.Select();
                    this.ActiveControl = cmbBnkDeposit;
                    cmbBnkDeposit.Focus();
                }
                else
                {
                    txtBranch.Select();
                    this.ActiveControl = txtBranch;
                    txtBranch.Focus();
                }
            }

        }

        private void cmbBnkDeposit_Leave(object sender, EventArgs e)
        {
            if (cmbBnkDeposit.SelectedValue != null)
            {
                Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
                //************************احتساب تاريخ حق البنك 
                DateTime Vd_RightDateBnk = MRightDateBankNew(Convert.ToDateTime(Vdt_DepositDate).AddDays(1));
                int Vin_year = Vd_RightDateBnk.Year;
                DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                DateTime Vd_AcctualDate = dateAddedStatlment.SelectDateRightDateBank(Vd_RightDateBnk, Vin_year);

                dTpBankDueDate.Value = Vd_AcctualDate;
                //*****************
                if (Vint_BankDepositeId == 2007)
                {
                    dTpBankDueDate.Value = Vdt_DepositDate;
                }
                txtBnkDepositID.Text = Vint_BankDepositeId.ToString();
                var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                if (listAccountBank != null)

                {
                    Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    //*************ارقام الحسابات



                    var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                    comboBox2.DataSource = listAccBank;
                    comboBox2.DisplayMember = "AccountBankNo";
                    comboBox2.ValueMember = "ID";
                    int Vin_countItem = comboBox2.Items.Count;
                    if (comboBox2.Items.Count > 1)
                    {
                        comboBox2.SelectedIndex = -1;
                        comboBox2.Text = "اختر رقم الحساب";
                        comboBox2.Select();
                        this.ActiveControl = comboBox2;
                        comboBox2.Focus();
                    }
                    else
                    {
                        txtAmountCash.Select();
                        this.ActiveControl = txtAmountCash;
                        txtAmountCash.Focus();
                    }
                }
            }
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                //*************ارقام الحسابات
                if (Vint_BankDepositeId == 2007)
                {
                    dTpBankDueDate.Value = Vdt_DepositDate;
                }


                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId).ToList();
                comboBox2.DataSource = listAccBank;
                comboBox2.DisplayMember = "AccountBankNo";
                comboBox2.ValueMember = "ID";
                int Vin_countItem = comboBox2.Items.Count;
                if (comboBox2.Items.Count > 1)
                {
                    comboBox2.SelectedIndex = -1;
                    comboBox2.Text = "اختر رقم الحساب";
                    comboBox2.Select();
                    this.ActiveControl = comboBox2;
                    comboBox2.Focus();
                }
                else
                {
                    txtAmountCash.Select();
                    this.ActiveControl = txtAmountCash;
                    txtAmountCash.Focus();
                }

            }
        }

        private void txtAmountCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentive.Focus();
            }
        }

        private void txtRepresentive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindRepresentativesFrm t = new Forms.BasicCodeForms.FindRepresentativesFrm();
                t.txtBrunchID.Text = Vint_BranchID.ToString();
                t.ShowDialog();

                //t.dataGridView1.DataSource = FsDb.Tbl_Representatives.Where(x => x.BranchID == Vint_BranchID);
                if (Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow != null)
                {
                    txtRepresentive.Text = Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow.Cells[1].Value.ToString();
                    txtRepresentiveID.Text = Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow.Cells[0].Value.ToString();
                    txtRepresentive.SelectionLength = 0;

                    simpleButton1.Select();
                    this.ActiveControl = simpleButton1;
                    simpleButton1.Focus();


                }


            }
        }
        private void GrdDepositDate(DateTime Vdt_DepositDate)
        {

            var list = (from Bch in FsDb.Tbl_DepositCash
                        join BNK in FsDb.Tbl_Banks on Bch.DepositBankID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on Bch.BranchID equals MNG.ID
                        //join rep in FsDb.Tbl_Representatives on Bch.RepresentiveID equals rep.ID
                        where (Bch.DepositDate == Vdt_DepositDate)
                        select new
                        {
                            ID = Bch.ID,
                            DepositCashNo = Bch.DepositCashNo,
                            AmountCash = Bch.AmountCash,
                            BranchName = MNG.BrancheName,
                            Name = BNK.Name,
                            BranchID = Bch.BranchID,
                            DepositDate = Bch.DepositDate,
                            BankDepositeID = Bch.DepositBankID,
                            BankAccountID = Bch.AccBankID,
                            BankDueDate = Bch.BankDueDate,
                            AccountBnkID = Bch.AccBankID,
                            RepresentiveID = Bch.RepresentiveID 
                            


                        }).OrderBy(x => x.ID).ToList();
            dataGridView2.DataSource = list;
            groupControl4.Text = $"النقديه المودعه بتاريخ {dTPDeposit.Value.ToString("yyyy-MM-dd")}";

        }
        private void ChaeqDataDepositCashAudit()
        {
            Vlng_rowIdDepositCash = long.Parse(txtRowID.Text);
            var listCheqAudit = FsDb.Tbl_DepositCash_Audit.Where(x => x.DepositCashID == Vlng_rowIdDepositCash).ToList();


            //******************************
            if (listCheqAudit.Count != 0)
            {
                long Vlng_CheckID = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    Vlng_CheckID = long.Parse(row.Cells["ID"].Value.ToString());
                    var listCheqAuditBR = FsDb.Tbl_DepositCash_Audit.Where(x => x.DepositCashID == Vlng_CheckID).ToList();

                    if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note == "" || x.Note == null).Count() == listCheqAuditBR.Count)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note != "" || x.Note != null).Count() > 0)

                    {
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                }
            }
        }
        private void dTPDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
                GrdDepositDate(Vdt_DepositDate);
                GrdDepositCash();
                ColorAudit();
                LoadSerial2();
                txtBranch.Select();
                this.ActiveControl = txtBranch;

                txtBranch.Focus();

            }

        }
        private void ColorAudit ()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                long Vlng_CheckID = long.Parse(row.Cells["ID"].Value.ToString());
                var listCheqAuditBR = FsDb.Tbl_DepositCash_Audit.Where(x => x.DepositCashID == Vlng_CheckID).ToList();

                if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note == "" || x.Note == null).Count() == listCheqAuditBR.Count)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note != "" || x.Note != null).Count() > 0)

                {
                    row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }
        }
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                t.ShowDialog();
                if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                {
                    textBox6.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox7.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();



                    Vint_BranchID = int.Parse(textBox7.Text);
                    var list = (from Bch in FsDb.Tbl_DepositCash
                                join BNK in FsDb.Tbl_Banks on Bch.DepositBankID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on Bch.BranchID equals MNG.ID
                                //join Rpsntv in FsDb.Tbl_Representatives on bsh.RepresentiveID equals Rpsntv.ID
                                //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                where (Bch.BranchID == Vint_BranchID)
                                select new
                                {
                                    ID = Bch.ID,
                                    DepositCashNo = Bch.DepositCashNo,
                                    AmountCash = Bch.AmountCash,
                                    BranchName = MNG.BrancheName,
                                    Name = BNK.Name,
                                    BranchID = Bch.BranchID,
                                    DepositDate = Bch.DepositDate,
                                    BankDepositeID = Bch.DepositBankID,
                                    BankAccountID = Bch.AccBankID,
                                    BankDueDate = Bch.BankDueDate,
                                    AccountBnkID = Bch.AccBankID,
                                    RepresentiveID = Bch.RepresentiveID,
                                }).OrderBy(x => x.ID).ToList();
                    //*********************
                    dataGridView2.DataSource = list;



                    LoadSerial2();

                    //**********

                    dataGridView2.Focus();
                }

            }
        }

        private void dTPDeposit_Leave(object sender, EventArgs e)
        {
            Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
            //************************احتساب تاريخ حق البنك 
            DateTime Vd_RightDateBnk = MRightDateBankNew(Convert.ToDateTime(Vdt_DepositDate).AddDays(1));
            int Vin_year = Vd_RightDateBnk.Year;
            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
            DateTime Vd_AcctualDate = dateAddedStatlment.SelectDateRightDateBank(Vd_RightDateBnk, Vin_year);

            dTpBankDueDate.Value = Vd_AcctualDate;
            //*****************
        }
        private DateTime MRightDateBankNew(DateTime Vd_ResultRightDateBank)
        {
            DateTime result = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_RightDateBank = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_AddDateBank = Convert.ToDateTime(DateTime.Today.ToString());
            int Vint_year = 0;
            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
            Vd_AddDateBank = Vd_ResultRightDateBank;
            Vint_year = Vd_RightDateBank.Year;
            Vd_RightDateBank = dateAddedStatlment.SelectDateRightDateBankN(Vd_AddDateBank, Vint_year);
            result = Vd_RightDateBank;
            return result;
        }

        private void CashDepositFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccountsBank' table. You can move, or remove it, as needed.
            this.tbl_AccountsBankTableAdapter.Fill(this.bankCheques.Tbl_AccountsBank);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBanksWithAccount(this.bankCheques.Dtb_Banks);
            ClearDataMaster();
            dTPDeposit.Select();
            this.ActiveControl = dTPDeposit;
            dTPDeposit.Focus();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FinancialYearDueDate f = new FinancialYearDueDate();
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 95 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (txtRowID.Text == "")
                {
                    if (txtBranchID.Text == "")
                    { MessageBox.Show("من فضلك ادخل الفرع"); txtBranch.Focus(); }
                    else if (cmbBnkDeposit.SelectedIndex == -1)
                    { MessageBox.Show("من فضلك قم باختيار البنك المودع"); cmbBnkDeposit.Focus(); }
                    else if (txtAmountCash.Text == "")
                    { MessageBox.Show("من فضلك ادخل القيمة "); txtAmountCash.Focus(); }
                    else
                    {
                        int Vin_Year = f.SelectFinancialYearDueDate(Convert.ToDateTime(dTPDeposit.Value.ToString()));
                        int Vint_RepresentiveID = 0;
                        if (txtRepresentiveID.Text != "") { Vint_RepresentiveID = int.Parse(txtRepresentiveID.Text); }


                        decimal Vd_AmountCash = Convert.ToDecimal(txtAmountCash.Text);
                        Tbl_DepositCash ChBnk = new Tbl_DepositCash
                        {
                            AmountCash = Vd_AmountCash,
                            BranchID = int.Parse(txtBranchID.Text),
                            DepositDate = Convert.ToDateTime(dTPDeposit.Value),
                            BankDueDate = Convert.ToDateTime(dTpBankDueDate.Value),
                            DepositBankID = int.Parse(txtBnkDepositID.Text),
                            AccBankID = int.Parse(comboBox2.SelectedValue.ToString()),
                            RepresentiveID = Vint_RepresentiveID,
                            FYear = Vin_Year,
                            DepositCashNo = txtDepositCashNo.Text,
                            BankAddDate = null,
                            DepositCashStatusID = 1,
                            DepositCashStatusDate = Convert.ToDateTime(dTPDeposit.Value)
                        };
                        FsDb.Tbl_DepositCash.Add(ChBnk);
                        FsDb.SaveChanges();

                        long Vlng_LastRowDepositCash = ChBnk.ID;
                        Tbl_DepositCashStatusDates dpcs = new Tbl_DepositCashStatusDates
                        {
                            StatusDate = Convert.ToDateTime(dTPDeposit.Value),
                            DepositCashStatusID = 1,
                            DepositCashID = Vlng_LastRowDepositCash
                        };
                        FsDb.Tbl_DepositCashStatusDates.Add(dpcs);
                        FsDb.SaveChanges();
                        //********************اثبات التعديل بعد اكتشاف خطا من المراجعين
                        var ListDChashAudit = FsDb.Tbl_DepositCash_Audit.Where(x => x.Note != "" && x.DepositCashID == Vlng_LastRowDepositCash && x.IsUpdate == null).Distinct().ToList();
                        if (ListDChashAudit.Count != 0)
                        {
                            ListDChashAudit[0].IsUpdate = true;
                            ListDChashAudit[0].UpdateDate = Convert.ToDateTime(DateTime.Today.ToString());
                        }
                        //************************
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة ايداع نقديه",
                            TableName = "Tbl_DepositCash",
                            TableRecordId = Vlng_LastRowDepositCash.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة ايداع نقديه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحفظ ");
                        ClearDataMaster();
                        Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
                        //************************احتساب تاريخ حق البنك 
                        DateTime Vd_RightDateBnk = MRightDateBankNew(Convert.ToDateTime(Vdt_DepositDate).AddDays(1));
                        dTpBankDueDate.Value = Vd_RightDateBnk;
                        //*****************
                        GrdDepositDate(Vdt_DepositDate);
                        GrdDepositCash();
                        LoadSerial2();
                        txtBranch.Select();
                        this.ActiveControl = txtBranch;
                        txtBranch.Focus();
                    }
                }
                else
                {
                    var validationSaveUserU = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 95 && w.ProcdureId == 3);
                    if (validationSaveUserU != null)
                    {
                        int Vint_rowid = int.Parse(txtRowID.Text);
                        var listDepositCash = FsDb.Tbl_DepositCash.Where(x => x.ID == Vint_rowid).ToList();
                        listDepositCash[0].RepresentiveID = int.Parse(txtRepresentiveID.Text);
                        
                        listDepositCash[0].AmountCash = decimal.Parse(txtAmountCash.Text);
                        listDepositCash[0].BranchID = int.Parse(txtBranchID.Text);
                        listDepositCash[0].DepositBankID = int.Parse(txtBnkDepositID.Text);
                        listDepositCash[0].AccBankID = int.Parse(txtAccountBnkID.Text);
                        listDepositCash[0].BankDueDate = Convert.ToDateTime(dTpBankDueDate.Value.ToString());
                        listDepositCash[0].DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                        int Vin_Year = f.SelectFinancialYearDueDate(Convert.ToDateTime(dTPDeposit.Value.ToString()));
                        listDepositCash[0].FYear = Vin_Year;
                        FsDb.SaveChanges();
                        //********************اثبات التعديل بعد اكتشاف خطا من المراجعين
                        var ListCheqAudit = FsDb.Tbl_DepositCash_Audit.Where(x => x.Note != "" && x.DepositCashID == Vint_rowid && x.IsUpdate == null).Distinct().ToList();
                        if (ListCheqAudit.Count != 0)
                        {
                            ListCheqAudit[0].IsUpdate = true;
                            ListCheqAudit[0].UpdateDate = Convert.ToDateTime(DateTime.Today.ToString());
                            ListCheqAudit[0].UserIDData = Program.GlbV_UserId;
                        }
                        //************************
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل ايداع نقديه",
                            TableName = "Tbl_DepositCash",
                            TableRecordId = Vint_rowid.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة ايداع نقديه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل ");
                        ClearDataMaster();
                        Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
                        //************************احتساب تاريخ حق البنك 
                        DateTime Vd_RightDateBnk = MRightDateBankNew(Convert.ToDateTime(Vdt_DepositDate).AddDays(1));
                        dTpBankDueDate.Value = Vd_RightDateBnk;
                        //*****************
                        GrdDepositDate(Vdt_DepositDate);
                        GrdDepositCash();
                        ColorAudit();
                        LoadSerial2();
                        txtBranch.Select();
                        this.ActiveControl = txtBranch;
                        txtBranch.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  ايداع نفدبه .. برجاء مراجعة مدير المنظومه");
                    }
                }


            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  ايداع نفدبه .. برجاء مراجعة مدير المنظومه");
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int Vint_DepositCashID = 0;
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 95 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                if (txtRowID.Text != "")
                {
                    Vint_DepositCashID = int.Parse(txtRowID.Text);
                    var listToDeleteDepCash = FsDb.Tbl_DepositCash.FirstOrDefault(x => x.ID == Vint_DepositCashID);
                    var resultMessageYesNo = MessageBox.Show("هل تريد حذف هده الحافظه  ؟", "حدف  حافظه ", MessageBoxButtons.YesNo);

                    if (resultMessageYesNo == DialogResult.Yes)
                    {
                        FsDb.Tbl_DepositCash.Remove(listToDeleteDepCash);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف ايداع نقديه",
                            TableName = "Tbl_DepositCash",
                            TableRecordId = Vint_DepositCashID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة ايداع نقديه"

                        };

                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحذف ");
                        ClearDataMaster();
                        Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
                        GrdDepositDate(Vdt_DepositDate);
                        GrdDepositCash();
                        LoadSerial2();
                        txtBranch.Select();
                        this.ActiveControl = txtBranch;
                        txtBranch.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  ايداع نفدبه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            cmbNote.SelectedIndex = -1;
            txtRowID.Text = "";

            DataGridViewRow currentRow = dataGridView2.CurrentRow;
            if (currentRow != null)
            {

                object cellValue = currentRow.Cells[1].Value;

                if (cellValue != null)
                {
                    txtRowID.Text = cellValue.ToString();
                    //****************Refrences******User Enter Data *********
                    Vlng_rowIdDepositCash = long.Parse(txtRowID.Text);
                    AccDepAuditSelect(Vlng_rowIdDepositCash);
                    var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vlng_rowIdDepositCash.ToString() && x.TableName == "Tbl_DepositCash").Distinct().ToList();

                    string Vstr_UserAddR = "";
                    int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                    for (int i = 0; i <= WCount - 1; i++)
                    {
                        Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                    }
                    textBox1.Text = Vstr_UserAddR;
                    //*************
                    
                    txtBranchID.Text = currentRow.Cells["BranchID"].Value.ToString();
                    txtBranch.Text = currentRow.Cells["BranchName"].Value.ToString();
                    txtAmountCash.Text = currentRow.Cells["AmountCash"].Value.ToString();
                    txtBnkDepositID.Text = currentRow.Cells["BankDepositeID"].Value.ToString();
                    int Vint_BankAccID = int.Parse(currentRow.Cells["AccountBnkID"].Value.ToString());
                    int Vint_BankID = int.Parse(txtBnkDepositID.Text);
                    

                    var listAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccID).ToList();
                    comboBox2.DataSource = listAcc;
                    comboBox2.DisplayMember = "AccountBankNo";
                    comboBox2.ValueMember = "ID";

                    comboBox2.SelectedValue = Vint_BankAccID;
                    comboBox2.Text = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccID).Select(x => x.AccountBankNo).FirstOrDefault();

                    int Vint_AccBank = int.Parse(comboBox2.SelectedValue.ToString());
                    var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
                    int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
                    var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();
                    comboBox3.DataSource = ListPurpose;
                    comboBox3.DisplayMember = "Name";
                    comboBox3.ValueMember = "ID";


                    dTPDeposit.Value = Convert.ToDateTime(currentRow.Cells["DepositDate"].Value.ToString());
                    dTpBankDueDate.Value = Convert.ToDateTime(currentRow.Cells["BankDueDate"].Value.ToString());
                    txtAccountBnkID.Text = currentRow.Cells["AccountBnkID"].Value.ToString();
                    if (txtAccountBnkID.Text != "")
                    {
                        int Vint_accId = int.Parse(txtAccountBnkID.Text);
                        var list = FsDb.Tbl_AccountsBank.FirstOrDefault(x => x.ID == Vint_accId);
                        txtAccountBnk.Text = list.AccountBankNo;
                    }

                    txtDepositCashNo.Text = currentRow.Cells["DepositCashNo"].Value.ToString();

                    txtRepresentiveID.Text = currentRow.Cells["RepresentiveID"].Value.ToString();
                    if (txtRepresentiveID.Text != "")
                    {
                        int Vint_repId = int.Parse(txtRepresentiveID.Text);
                        var list = FsDb.Tbl_Representatives.FirstOrDefault(x => x.ID == Vint_repId);
                        if (list != null)
                        { txtRepresentive.Text = list.Name; }
                    }
                    chckBxBasicData.Checked = false;
                    //****************Refrences***************
                    AccDepAuditSelect(Vlng_rowIdDepositCash);
                    //***************************************
                   
                    cmbBnkDeposit.Text = currentRow.Cells["Name"].Value.ToString();



                }
            }
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRowID.Text != "")
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "PDF Files|*.pdf";
                    openFileDialog1.Title = "Select a PDF File";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog1.FileName;


                        if (Path.GetExtension(filePath).ToLower() == ".pdf")
                        {

                            pdfViewer1.DocumentFilePath = filePath;
                            long Vlng_IdItem = 0;
                            string Vstr_HirarckyID = "151";
                            string Vstr_ProcessKindID = "";
                            string Vstr_YearDate = "";
                            string Vstr_MonthDate = "";
                            string Vstr_IDCheque = "";

                            Vlng_IdItem = int.Parse(txtRowID.Text);
                            if (Vlng_IdItem != 0)
                            {

                                Vstr_ProcessKindID = "8";

                                DateTime Vdt_DateP = Convert.ToDateTime(dTPDeposit.Value.ToString());



                                Vstr_YearDate = (Vdt_DateP.Year).ToString();

                                Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                                Vstr_IDCheque = txtRowID.Text;

                                string PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;

                                //string PathDirectory = @"I:\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;

                                if (!Directory.Exists(PathDirectory))
                                {
                                    try
                                    {
                                        Directory.CreateDirectory(PathDirectory);
                                    }
                                    catch (Exception ex)  // CS0168
                                    {
                                        MessageBox.Show(ex.Message);

                                    }

                                }
                                //**************Create Files Of Scan *************
                                Vlng_IdItem = long.Parse(txtRowID.Text);

                                var list = FsEvDb.Tbl_ArchBankTransfer.Where(x => x.BankTransferPayID == Vlng_IdItem && x.DocumentHirarchyID == 151).ToList();

                                if (list.Count == 0)
                                {
                                    int Vint_count = 1;
                                    string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");
                                    string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                                    while (File.Exists(PathFile) || File.Exists(PathFile1))
                                    {
                                        Vint_count++;
                                        PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");
                                        PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                                    }

                                    if (File.Exists(PathFile) || File.Exists(PathFile1))
                                    {
                                        pdfViewer1.DocumentFilePath = null;
                                        File.Delete(PathFile);
                                        File.Delete(PathFile1);
                                    }

                                    File.Copy(filePath, PathFile);

                                    Tbl_ArchBankTransfer ArchD = new Tbl_ArchBankTransfer()
                                    {
                                        BankTransferPayID = long.Parse(txtRowID.Text),
                                        DocumentHirarchyID = 136,
                                        PathFile = PathFile
                                    };
                                    FsEvDb.Tbl_ArchBankTransfer.Add(ArchD);
                                    FsEvDb.SaveChanges();
                                    MessageBox.Show($"تم حفظ الملف");
                                    PathFile = "";
                                }
                                else
                                {
                                    int Vint_count = 1;
                                    string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");
                                    string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                                    list[0].PathFile = PathFile;


                                    if (File.Exists(PathFile) || File.Exists(PathFile1))
                                    {
                                        pdfViewer1.DocumentFilePath = null;
                                        File.Delete(PathFile);
                                        File.Delete(PathFile1);
                                    }

                                    File.Copy(filePath, PathFile);

                                    FsEvDb.SaveChanges();
                                    MessageBox.Show($"تم تعديل الملف");
                                    PathFile = "";
                                }


                            }

                        }
                        else
                        {
                            MessageBox.Show("الرجاء اختيار ملف بصيغة PDF.");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("من فضلك اختر التحويل البنكي المراد عرض صورته اولا");
                }

            }
            catch
            {

            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (txtRowID.Text != "")
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPEG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PicturePath.ImageLocation = dialog.FileName;
                    Image_Path = dialog.FileName;
                }
                if (Image_Path != "")
                {
                    long Vlng_IdItem = 0;
                    string Vstr_HirarckyID = "151";
                    string Vstr_ProcessKindID = "";
                    string Vstr_YearDate = "";
                    string Vstr_MonthDate = "";
                    string Vstr_IDCheque = "";

                    Vlng_IdItem = int.Parse(txtRowID.Text);
                    if (Vlng_IdItem != 0)
                    {

                        Vstr_ProcessKindID = "8";

                        DateTime Vdt_DateP = Convert.ToDateTime(dTPDeposit.Value.ToString());



                        Vstr_YearDate = (Vdt_DateP.Year).ToString();

                        Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                        Vstr_IDCheque = txtRowID.Text;

                        string PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;

                        // string PathDirectory = @"I:\" + Vstr_ProcessKindID + textBox8.Text + Vstr_YearDate + textBox8.Text + Vstr_MonthDate + textBox8.Text + Vstr_IDCheque + textBox8.Text + Vstr_HirarckyID;


                        if (!Directory.Exists(PathDirectory))
                        {
                            try
                            {
                                Directory.CreateDirectory(PathDirectory);
                            }
                            catch (Exception ex)  // CS0168
                            {
                                MessageBox.Show(ex.Message);

                            }

                        }
                        //**************Create Files Of Scan *************
                        Vlng_IdItem = long.Parse(txtRowID.Text);

                        var list = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vlng_IdItem && x.DocumentHirarchyID == 151).ToList();

                        if (list.Count == 0)
                        {
                            int Vint_count = 1;
                            string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                            string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");

                            if (File.Exists(PathFile) || File.Exists(PathFile1))
                            {
                                File.Delete(PathFile);
                                File.Delete(PathFile1);
                            }


                            File.Copy(Image_Path, PathFile);


                            Tbl_ArchBankTransfer ArchD = new Tbl_ArchBankTransfer()
                            {
                                BankTransferPayID = long.Parse(txtRowID.Text),
                                DocumentHirarchyID = 151,
                                PathFile = PathFile
                            };
                            FsEvDb.Tbl_ArchBankTransfer.Add(ArchD);
                            FsEvDb.SaveChanges();
                            MessageBox.Show($"تم حفظ الصوره");
                            Image_Path = "";
                        }
                        else
                        {
                            int Vint_count = 1;
                            string PathFile = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".jpg");
                            string PathFile1 = PathDirectory + textBox8.Text + (Vint_count.ToString() + ".Pdf");


                            if (File.Exists(PathFile) || File.Exists(PathFile1))
                            {
                                File.Delete(PathFile);
                                File.Delete(PathFile1);
                            }


                            File.Copy(Image_Path, PathFile);


                            list[0].PathFile = PathFile;
                            FsEvDb.SaveChanges();
                            MessageBox.Show($"تم تعديل الصوره");
                            Image_Path = "";
                        }
                    }
                }


            }
            else
            {
                MessageBox.Show("من فضلك اختر الايداع المراد عرض صورته اولا");
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (txtRowID.Text != "")
            {
                Forms.DocumentsForms.CheqScanFrm t = new Forms.DocumentsForms.CheqScanFrm();
                //**************بيانات الخافظه 
                t.txtbranch.Text = this.txtBranch.Text;
                t.txtCollectionNo.Text = this.txtDepositCashNo.Text;
                t.dTPCollectionDate.Value = Convert.ToDateTime(this.dTPDeposit.Value.ToString("yyyy/MM/dd"));
                t.txtBankD.Text = this.cmbBnkDeposit.SelectedText.ToString();

                //*************بيانات الشيك
                t.txtRowChequeID.Text = this.txtRowID.Text;
                //t.txtChequeNoScan.Text = this.txtChequeNoScan.Text;
                t.txtAmountScan.Text = this.txtAmountCash.Text;
                //t.txtBankDrawnOnScan.Text = this.txtBankTo.Text;
                //t.dTPDueDateScan.Value = Convert.ToDateTime(this.dTPDueDateScan.Value.ToString("yyyy/MM/dd"));


                //***********************
                long Vint_ID = long.Parse(this.txtRowID.Text);
                int Vint_IdItem = 151;

                //int Vint_Parent_ID = 6;

                var listItem = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);

                //string Vstr_Name = "الوارده";

                //*********************عرض صورة الشيك
                t.pictureBox1.ImageLocation = null;
                //try
                //{
                t.pictureBox1.ImageLocation = null;
                try
                {

                    var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vint_ID);
                    if (listArchCheq != null && !string.IsNullOrEmpty(listArchCheq.PathFile))
                    {
                        t.pictureBox1.ImageLocation = listArchCheq.PathFile;
                        t.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        // Handle case where image file path is empty or image does not exist
                        //MessageBox.Show("Image file path is empty or image does not exist.");
                        t.pdfViewer1.DocumentFilePath = listArchCheq.PathFile;
                    }


                    //var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vint_ID);
                    //int Vint_IDArch = int.Parse(listArchCheq.ID.ToString());

                    //var list = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ID == Vint_IDArch);


                    //if (list.PathFile != "")

                    //{
                    //t.pictureBox1.Dispose();
                    //t.pdfViewer1.DocumentFilePath = listArchCheq.PathFile;
                    //try
                    //{
                    //    Image originalImage = Image.FromFile(list.PathFile.ToString());
                    //    Image.FromFile(list.PathFile.ToString());
                    //    t.pictureBox1.Image = originalImage;
                    //    t.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //}
                    //catch { }






                    //}
                }
                catch { }
                //**************************
                if ((Application.OpenForms["ShowScanDocuments"] as ShowScanDocuments != null))
                {
                    t.BringToFront();
                    //*********************
                    this.SendToBack();
                }
                else
                {
                    t.Show();
                    t.BringToFront();
                }

            }
            else
            {
                MessageBox.Show("من فضلك اختر الايداع المراد عرض صورته اولا");
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmountCash.Focus();
            }

        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                int Vint_AccBank = int.Parse(comboBox2.SelectedValue.ToString());
               
                var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
                int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
                var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();
                comboBox3.DataSource = ListPurpose;
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "ID";
                txtAccountBnkID.Text = "";
                txtAccountBnkID.Text = Vint_AccBank.ToString();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.DocumentsForms.CheqeesAuditFrm t = new Forms.DocumentsForms.CheqeesAuditFrm();
                //t.txtCheqId.Text = this.txtRowChequeID.Text;
                //t.txtCheqNo.Text = this.txtChequeNo.Text;

                t.dateTimePicker1.Value = this.dTPDeposit.Value;
                if (txtRowID.Text != "")
                {
                    t.ShowDialog();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر الايداع النقدي المراد مراجعته اولا");
                }

            }
        }
        private void AccDepAuditSelect(long? Vlng_DepositCashID)
        {

            var ListDepCshAuditTreaDuryCUser = FsDb.Tbl_DepositCash_Audit.OrderByDescending(e => e.ID).FirstOrDefault(x => x.DepositCashID == Vlng_DepositCashID);
            if (ListDepCshAuditTreaDuryCUser != null)
            {
                if (ListDepCshAuditTreaDuryCUser.IsDepositOk == true)
                {
                    chckBxBasicData.Checked = true;
                    if (ListDepCshAuditTreaDuryCUser.Note != null)
                    {
                        cmbNote.Text = "";
                        cmbNote.SelectedItem = ListDepCshAuditTreaDuryCUser.Note;
                    }
                }
                else
                {
                    chckBxBasicData.Checked = false;
                    if (ListDepCshAuditTreaDuryCUser.Note != null)
                    {
                        cmbNote.Text = "";
                        cmbNote.SelectedText = ListDepCshAuditTreaDuryCUser.Note;
                    }
                }
            }
            var ListAccTrCAudit = (from TrDpCA in FsDb.Tbl_DepositCash_Audit
                                   join usr in FsDb.Tbl_User on TrDpCA.UserID equals usr.ID
                                   join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                   where (TrDpCA.DepositCashID == Vlng_rowIdDepositCash)
                                   select new
                                   {
                                       EmpName = emp.Name
                                   }).Distinct().ToList();
            if (ListAccTrCAudit != null)
            {
                string Vstr_RefrencesOrder = "";
                int WCount = int.Parse(ListAccTrCAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_RefrencesOrder = ListAccTrCAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
                }
                textBox2.Text = Vstr_RefrencesOrder;
            }
            else
            {
                textBox2.Text = "";
                //txtNotCheqAudit.Text = "";
                cmbNote.SelectedText = "";
            }
        }
        private void ChaeqDataBankChequeAudit()
        {
            Vlng_rowIdDepositCash = long.Parse(txtRowID.Text);
            var listCheqAudit = FsDb.Tbl_DepositCash_Audit.Where(x => x.DepositCashID == Vlng_rowIdDepositCash).ToList();


            //******************************
            if (listCheqAudit.Count != 0)
            {
                long Vlng_CheckID = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    Vlng_CheckID = long.Parse(row.Cells["ID"].Value.ToString());
                    var listCheqAuditBR = FsDb.Tbl_DepositCash_Audit.Where(x => x.DepositCashID == Vlng_rowIdDepositCash).ToList();

                    if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note == "" || x.Note == null).Count() == listCheqAuditBR.Count)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (listCheqAuditBR.Count != 0 && listCheqAuditBR.Where(x => x.Note != "" || x.Note != null).Count() > 0)

                    {
                        row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                }
            }
        }
        private void chckBxBasicData_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtRowID.Text != "")
            {
                Vlng_rowIdDepositCash = long.Parse(txtRowID.Text);
                 
                bool Vbl_DepositCash = false;
                 
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 108 && w.ProcdureId == 1003);
                if (validationSaveUser != null)
                {
                    string Vstr_Note = "";
                    if (cmbNote.SelectedItem != null)
                    { Vstr_Note = cmbNote.SelectedItem.ToString(); }
                    else
                    { Vstr_Note = ""; }

                    
                    var ListTrcAuditOrdUser = FsDb.Tbl_DepositCash_Audit.FirstOrDefault(x => x.DepositCashID == Vlng_rowIdDepositCash && x.UserID == Program.GlbV_UserId);
                    if (ListTrcAuditOrdUser == null)

                    {
                        if (chckBxBasicData.Checked == true && Vstr_Note == "")
                        {
                            Vbl_DepositCash = true;
                            
                        }
                        else
                        {
                            Vbl_DepositCash = false;
                            
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate());
                        Tbl_DepositCash_Audit DepCshAud = new Tbl_DepositCash_Audit
                        {
                            UserID = Program.GlbV_UserId,
                            DepositCashID = Vlng_rowIdDepositCash,
                            
                            IsDepositOk = Vbl_DepositCash,
                            
                            ReferenceDate = Vdt_Today,
                            Note = Vstr_Note,
                            NoteAdd = Vstr_Note
                        };
                        FsDb.Tbl_DepositCash_Audit.Add(DepCshAud);
                        FsDb.SaveChanges();

                        long Vlng_LastRow = DepCshAud.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مراجعة الايداعات النقديه",
                            TableName = "Tbl_DepositCash_Audit",
                            TableRecordId = Vlng_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                            //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراجعة الايداعات النقديه"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        //****************Refrences***************
                        AccDepAuditSelect(Vlng_rowIdDepositCash);

                        ChaeqDataBankChequeAudit();
                        //***************************************
                    }
                    else
                    {
                        bool Vbl_DepositCash1 = false;
                        if (chckBxBasicData.Checked == true && Vstr_Note == "")
                        {
                            Vbl_DepositCash1 = true;
                            
                        }
                        else
                        {
                            Vbl_DepositCash1 = false;
                             
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListOrderAuditOrdUsero = FsDb.Tbl_DepositCash_Audit.FirstOrDefault(x => x.DepositCashID == Vlng_rowIdDepositCash && x.UserID == Program.GlbV_UserId);
                        ListOrderAuditOrdUsero.IsDepositOk = Vbl_DepositCash1;
                        
                        if (Vstr_Note == "")
                        {
                            var ListOrderAuditOrdUseroN = FsDb.Tbl_DepositCash_Audit.Where(x => x.DepositCashID == Vlng_rowIdDepositCash).ToList();
                            foreach (var v in ListOrderAuditOrdUseroN)
                            {
                                v.Note = Vstr_Note;
                                FsDb.SaveChanges();
                            }

                        }
                        else
                        {
                            ListOrderAuditOrdUsero.Note = Vstr_Note;
                        }
                        ListOrderAuditOrdUsero.NoteAdd = Vstr_Note;
                        ListOrderAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //****************Refrences***************
                        AccDepAuditSelect(Vlng_rowIdDepositCash);

                        ChaeqDataBankChequeAudit();
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية  مراجعه الشيكات .. برجاء مراجعة مدير المنظومه");
                    chckBxBasicData.Checked = false;
                }
            }
            else
            {
                MessageBox.Show(" من فضلك قم بإختيار الشيك المراد مراجعته اولا");
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                int Vint_AccBank = int.Parse(comboBox2.SelectedValue.ToString());
                txtAccountBnk.Text = "";
                txtAccountBnk.Text = Vint_AccBank.ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtAmountCash_Leave(object sender, EventArgs e)
        {
            Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
            //************************احتساب تاريخ حق البنك 
            DateTime Vd_RightDateBnk = MRightDateBankNew(Convert.ToDateTime(Vdt_DepositDate).AddDays(1));
            int Vin_year = Vd_RightDateBnk.Year;
            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
            DateTime Vd_AcctualDate = dateAddedStatlment.SelectDateRightDateBank(Vd_RightDateBnk, Vin_year);

            dTpBankDueDate.Value = Vd_AcctualDate;
            //*****************
            if (Vint_BankDepositeId == 2007)
            {
                dTpBankDueDate.Value = Vdt_DepositDate;
            }
        }
    }
}


