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
using MahApps.Metro.Controls;

namespace FinancialSysApp.Forms.Banks
{
    public partial class ElectronicPaymentAuditFrm : DevExpress.XtraEditors.XtraForm
    {
        int Vint_BranchID = 0;
        //int Vint_BankDepositeId = 0;

        long Vlng_rowIdBankMove = 0;
        string Image_Path = "";

        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public ElectronicPaymentAuditFrm()
        {
            InitializeComponent();
        }
        private void ClearDataMaster()
        {
            txtRowID.Text = "";
            txtBnkDepositID.Text = "";

            txtAccountBnkID.Text = "";

            //txtAccountBnk.Text = "";

            txtAmountCash.Text = "";
            dTpBankDueDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
            textBox1.Text = "";
            textBox2.Text = "";
            txtBranchID.Text = "";
            txtBranch.Text = "";

            txtBranchAud.Text = "";
            txtBranchAudID.Text = "";
            txtAmountCash.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox1.SelectedText = "اختر البنك المودع ";


            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";


            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";
            cmbNote.SelectedIndex = -1;
            cmbNote.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox2.Text = "اختر الحساب";

            comboBox3.Text = "";


        }
        private void ElectronicPaymentAuditFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_CustmersType' table. You can move, or remove it, as needed.
            this.tbl_CustmersTypeTableAdapter.FillByElectronicPayment(this.bankTransmentDS.Tbl_CustmersType);
            //var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 108 && w.ProcdureId == 2);
            //if (validationSaveUser != null)
            //{
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques1.Dtb_Banks);
            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.Text = "اختر البنك ";

            var listCustType = FsDb.Tbl_CustmersType.Where(x => x.IsElectronicPaymentNo == true).OrderBy(x => x.Parent_ID).ToList();
            comboBox6.DataSource = listCustType;
            comboBox6.DisplayMember = "Name";
            comboBox6.ValueMember = "ID";
            comboBox6.SelectedIndex = 0;
            comboBox6.Text = "اختر تصنيف العملاء";

            checkBox2.Checked = false;
            checkBox3.Checked = false;
            var ListBank = (from bnk in FsDb.Tbl_Banks
                            join BnkAcc in FsDb.Tbl_AccountsBank on bnk.ID equals BnkAcc.BankID
                            where (BnkAcc.KindAccountBankID == 1)
                            select new
                            {
                                ID = bnk.ID,
                                Name = bnk.Name
                            }
            ).OrderBy(x => x.Name).ToList();

            comboBox1.DataSource = ListBank;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.Text = "اختر البنك ";

            int? UniteID = Program.GlbV_SysUnite_ID;
            var list = (from usr in FsDb.Tbl_User
                        join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                        join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID

                        where (us.SysUnites_ID == 11 && us.SysUnite_StatusID == 1)
                        select new
                        {
                            ID = usr.ID,
                            Name = usr.Tbl_Employee.Name,


                        }).OrderBy(x => x.Name).ToList();

            dTPDeposit.Select();
            this.ActiveControl = dTPDeposit;
            dTPDeposit.Focus();
            //}
            //else
            //{
            //    MessageBox.Show("ليس لديك صلاحية استعلام عن حركات دفع اليكتروني .. برجاء مراجعة مدير المنظومه");
            //    this.Close();
            //}
        }

        private void NonDepositBranches(DateTime d1, DateTime d2)
        {
            var ListCountBr = FsDb.Tbl_Management.Where(x => x.KindBranchDirect == 1 && (x.BrancheName != "" && x.BrancheName != null)).ToList();

            string Vstr_NonDepBranch = "";
            foreach (var v in ListCountBr)
            {

                var LBranchNonDeposit = FsDb.Tbl_DepositCash.Where(x => x.BranchID == v.ID && x.DepositDate >= d1 && x.DepositDate <= d2).ToList();
                if (LBranchNonDeposit.Count == 0)
                {
                    Vstr_NonDepBranch = v.BrancheName + " =/= " + Vstr_NonDepBranch;

                }
                //txtNonDepBranches.Text = Vstr_NonDepBranch;
            }





        }
        private void TotalGr()
        {
            txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                           select Convert.ToDouble(row.Cells[10].Value)).Sum(), 3).ToString();
            txtAllCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                select Convert.ToDouble(row.Cells[10].Value)).Count().ToString();
        }

        private void dTPDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBranch.Text = "";

                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك";


                txtAmountCash.Text = "";
                dTPDeposit2.Focus();
            }
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void dTPDeposit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                this.dataTable1TableAdapter.FillByAllDailyMove(this.bankTransmentDS.DataTable1, 5, 15, Vst_DepositDate1, Vst_DepositDate2);
                LoadSerial();
                TotalGr();
                CheckMovAuditOrNo();
                //NonDepositBranches(d1, d2);
                txtBranch.Text = "";
                //txtRepresentive.Text = "";
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك";
                ChaeqDataBankMovAuditFirst();

                txtAmountCash.Text = "";


                txtBranch.Focus();
            }
        }
        private void CheckMovAuditOrNo()
        {
            long? Vint_MoveID = null;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Vint_MoveID = long.Parse(row.Cells[1].Value.ToString());
                var ListMovAudit = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == Vint_MoveID).ToList();
                if (ListMovAudit.Count > 0)
                { row.Cells[5].Value = ListMovAudit[0].IsAuditOk; }
                else
                {
                    row.Cells[5].Value = false;
                }

            }
        }
        private void txtBranchِAud_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ChaeqDataBankMovAuditFirst()
        {

            long Vlng_CheckID = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                Vlng_CheckID = long.Parse(row.Cells[1].Value.ToString());
                var listMovAuditBR = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == Vlng_CheckID).ToList();

                if (listMovAuditBR.Count != 0 && listMovAuditBR.Where(x => x.Note == "" || x.Note == null).Count() == listMovAuditBR.Count)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (listMovAuditBR.Count != 0 && listMovAuditBR.Where(x => x.Note != "" || x.Note != null).Count() > 0)

                {
                    row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }

        }
        private void ChaeqDataBankMOvAudit()
        {
            Vlng_rowIdBankMove = long.Parse(txtRowID.Text);
            var listCheqAudit = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == Vlng_rowIdBankMove).ToList();


            //******************************
            if (listCheqAudit.Count != 0)
            {
                long Vlng_CheckID = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    Vlng_CheckID = long.Parse(row.Cells[1].Value.ToString());
                    var listCheqAuditBR = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == Vlng_CheckID).ToList();

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

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (checkBox2.Checked == true)
                {
                    Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBranchID.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        if (Vint_BranchID == 355)
                        {
                            checkBox1.Enabled = true;

                        }
                        else
                        {
                            checkBox1.Enabled = false;
                        }
                        Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                        Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                        DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                        DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                        this.dataTable1TableAdapter.FillByDailywithBranch(this.bankTransmentDS.DataTable1, 5, 15, Vst_DepositDate1, Vst_DepositDate2, Vint_BranchID);
                        LoadSerial();
                        TotalGr();
                        CheckMovAuditOrNo();
                        cmbBnkDeposit.SelectedIndex = -1;
                        cmbBnkDeposit.Text = "";
                        cmbBnkDeposit.Text = "اختر البنك";
                        ChaeqDataBankMovAuditFirst();

                        txtAmountCash.Text = "";
                    }
                }
                else if (checkBox3.Checked == true)
                {
                    Forms.BasicCodeForms.FindDirectionFrm t = new Forms.BasicCodeForms.FindDirectionFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindDirectionFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[1].Value.ToString();
                        txtBranchID.Text = Forms.BasicCodeForms.FindDirectionFrm.SelectedRow.Cells[0].Value.ToString();
                        Vint_BranchID = int.Parse(txtBranchID.Text);
                        if (Vint_BranchID == 355)
                        {
                            checkBox1.Enabled = true;

                        }
                        else
                        {
                            checkBox1.Enabled = false;
                        }
                        Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                        Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                        DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                        DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                        this.dataTable1TableAdapter.FillByDailywithBranch(this.bankTransmentDS.DataTable1, 5, 15, Vst_DepositDate1, Vst_DepositDate2, Vint_BranchID);
                        LoadSerial();
                        TotalGr();
                        CheckMovAuditOrNo();
                        cmbBnkDeposit.SelectedIndex = -1;
                        cmbBnkDeposit.Text = "";
                        cmbBnkDeposit.Text = "اختر البنك";
                        ChaeqDataBankMovAuditFirst();

                        txtAmountCash.Text = "";
                    }
                }
            }
        }
        private void AccElectronicAuditSelect(long? Vlng_BnkMovTypID)
        {

            var ListDepCshAuditTreaDuryCUser = FsDb.Tbl_MovementTypingAudit.OrderByDescending(e => e.ID).FirstOrDefault(x => x.BankMovementID == Vlng_BnkMovTypID);
            if (ListDepCshAuditTreaDuryCUser != null)
            {
                if (ListDepCshAuditTreaDuryCUser.IsAuditOk == true)
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
            var ListAccTrCAudit = (from TrDpCA in FsDb.Tbl_MovementTypingAudit
                                   join usr in FsDb.Tbl_User on TrDpCA.UserID equals usr.ID
                                   join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                   where (TrDpCA.BankMovementID == Vlng_rowIdBankMove)
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
        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            cmbNote.SelectedIndex = -1;
            txtRowID.Text = "";
            ClearDataMaster();
            DataGridViewRow currentRow = dataGridView2.CurrentRow;
            if (currentRow != null)
            {

                object cellValue = currentRow.Cells[1].Value;

                if (cellValue != null)
                {
                    txtRowID.Text = cellValue.ToString();
                    //****************Refrences******User Enter Data *********
                    Vlng_rowIdBankMove = long.Parse(txtRowID.Text);
                    AccElectronicAuditSelect(Vlng_rowIdBankMove);
                    var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vlng_rowIdBankMove.ToString() && x.TableName == "Tbl_DepositCash").Distinct().ToList();

                    string Vstr_UserAddR = "";
                    int WCount = int.Parse(ListAccRstAudit.Count.ToString());
                    for (int i = 0; i <= WCount - 1; i++)
                    {
                        Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                    }
                    textBox1.Text = Vstr_UserAddR;
                    //*************
                    //***********البنك ورقم الحساب  والغرض 
                    txtBnkDepositID.Text = currentRow.Cells[2].Value.ToString();
                    int Vint_BankID = int.Parse(txtBnkDepositID.Text);
                    int Vint_BankAccID = int.Parse(currentRow.Cells[3].Value.ToString());
                    comboBox1.SelectedValue = Vint_BankID;

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

                    //*************القيمه
                    txtAmountCash.Text = currentRow.Cells[10].Value.ToString();
                    //********* الفرع
                    txtBranchAudID.Text = currentRow.Cells[27].Value.ToString();
                    txtBranchAud.Text = currentRow.Cells[30].Value.ToString();
                    //****************تواريخ الحركه والحق 
                    dateTimePicker1.Value = Convert.ToDateTime(currentRow.Cells[6].Value.ToString());
                    dTpBankDueDate.Value = Convert.ToDateTime(currentRow.Cells[7].Value.ToString());
                    //*******************تصنيف العملاء وتاريخ اليوميه

                    comboBox6.SelectedValue = int.Parse(currentRow.Cells[28].Value.ToString());
                    dateTimePicker2.Value = Convert.ToDateTime(currentRow.Cells[31].Value.ToString());
                    //****************

                    chckBxBasicData.Checked = false;
                    //****************Refrences***************
                    AccElectronicAuditSelect(Vlng_rowIdBankMove);
                    //***************************************

                    cmbBnkDeposit.Text = currentRow.Cells[14].Value.ToString();



                }
            }
        }

        private void chckBxBasicData_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtRowID.Text != "")
            {
                Vlng_rowIdBankMove = long.Parse(txtRowID.Text);

                bool Vbl_DepositCash = false;

                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 127 && w.ProcdureId == 1003);
                if (validationSaveUser != null)
                {
                    string Vstr_Note = "";
                    if (cmbNote.SelectedItem != null)
                    { Vstr_Note = cmbNote.SelectedItem.ToString(); }
                    else
                    { Vstr_Note = ""; }


                    var ListTrcAuditOrdUser = FsDb.Tbl_MovementTypingAudit.FirstOrDefault(x => x.BankMovementID == Vlng_rowIdBankMove && x.UserID == Program.GlbV_UserId);
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
                        if (checkBox1.Checked == true)
                        {
                            long Vlng_MoveID = 0;
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                Vlng_MoveID = long.Parse(row.Cells[1].Value.ToString());
                                Vbl_DepositCash = Convert.ToBoolean(row.Cells[5].Value.ToString());
                                var ListMovAudit = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == Vlng_MoveID).ToList();
                                if (ListMovAudit.Count > 0)
                                {

                                    ListMovAudit[0].IsAuditOk = Vbl_DepositCash;
                                    ListMovAudit[0].ReferenceDate = Vdt_Today;
                                    ListMovAudit[0].Note = Vstr_Note;
                                    ListMovAudit[0].Note1 = Vstr_Note;
                                    FsDb.SaveChanges();
                                }
                                else
                                {

                                    Tbl_MovementTypingAudit DepCshAud = new Tbl_MovementTypingAudit
                                    {
                                        UserID = Program.GlbV_UserId,
                                        BankMovementID = Vlng_MoveID,

                                        IsAuditOk = Vbl_DepositCash,

                                        ReferenceDate = Vdt_Today,
                                        Note = Vstr_Note,
                                        Note1 = Vstr_Note
                                    };
                                    FsDb.Tbl_MovementTypingAudit.Add(DepCshAud);
                                    FsDb.SaveChanges();
                                }

                            }
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة مجموعة حركات لمراجعة الدفع الاليكتروني",
                                TableName = "Tbl_DepositCash_Audit",
                                TableRecordId = "",
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                                //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة مراجعة الدفع الاليكتروني"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("تم الحفظ");
                            ChaeqDataBankMovAuditFirst();
                        }
                        else
                        {
                            Tbl_MovementTypingAudit DepCshAud = new Tbl_MovementTypingAudit
                            {
                                UserID = Program.GlbV_UserId,
                                BankMovementID = Vlng_rowIdBankMove,

                                IsAuditOk = Vbl_DepositCash,

                                ReferenceDate = Vdt_Today,
                                Note = Vstr_Note,
                                Note1 = Vstr_Note
                            };
                            FsDb.Tbl_MovementTypingAudit.Add(DepCshAud);
                            FsDb.SaveChanges();
                            long Vlng_LastRow = DepCshAud.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة مراجعة الدفع الاليكتروني",
                                TableName = "Tbl_DepositCash_Audit",
                                TableRecordId = Vlng_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                                //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة مراجعة الدفع الاليكتروني"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("تم الحفظ");
                            ChaeqDataBankMovAuditFirst();
                            //****************Refrences***************
                            AccElectronicAuditSelect(Vlng_rowIdBankMove);

                            ChaeqDataBankMOvAudit();
                            //***************************************
                        }



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

                        var ListOrderAuditOrdUsero = FsDb.Tbl_MovementTypingAudit.FirstOrDefault(x => x.BankMovementID == Vlng_rowIdBankMove && x.UserID == Program.GlbV_UserId);
                        ListOrderAuditOrdUsero.IsAuditOk = Vbl_DepositCash1;

                        if (Vstr_Note == "")
                        {
                            var ListOrderAuditOrdUseroN = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == Vlng_rowIdBankMove).ToList();
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
                        ListOrderAuditOrdUsero.Note1 = Vstr_Note;
                        ListOrderAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        ChaeqDataBankMovAuditFirst();
                        //****************Refrences***************
                        AccElectronicAuditSelect(Vlng_rowIdBankMove);

                        ChaeqDataBankMOvAudit();
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية  مراجعه دفع اليكتروني .. برجاء مراجعة مدير المنظومه");
                    chckBxBasicData.Checked = false;
                }
            }
            else
            {
                MessageBox.Show(" من فضلك قم بإختيار الحركه المراد مراجعته اولا");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Vst_MovCode = "";
                if (textBox4.Text != "")
                {
                    Vst_MovCode = textBox4.Text;
                }
                else
                {
                    MessageBox.Show("من ادخل الكود المراد");
                }
                if (txtBranchID.Text != "")
                {
                    Vint_BranchID = int.Parse(txtBranchID.Text);
                }
                else
                {
                    MessageBox.Show("من فضلك اختر الفرع");
                }
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                this.dataTable1TableAdapter.FillByDailyWithBranchMovCode(this.bankTransmentDS.DataTable1, 5, 15, Vst_DepositDate1, Vst_DepositDate2, Vint_BranchID, Vst_MovCode);
                LoadSerial();
                TotalGr();
                CheckMovAuditOrNo();
                ChaeqDataBankMovAuditFirst();
            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells[5].Value = true;

                }
            }
            else if (checkBox1.Checked == false)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells[5].Value = false;

                }
            }

        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 127 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                int? vint_branchID = null;
                int vint_RowID = int.Parse(txtRowID.Text);
                int Vint_CustType = int.Parse(comboBox6.SelectedValue.ToString());
                if (txtBranchAudID.Text != "")
                { vint_branchID = int.Parse(txtBranchAudID.Text); }
                DateTime Vd_DayDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));

                var ListBnkMov = FsDb.Tbl_BankMovement.Where(x => x.ID == vint_RowID).ToList();

                if (ListBnkMov.Count > 0)
                {
                    ListBnkMov[0].TradeMoveType = Vint_CustType;
                    ListBnkMov[0].BranchId = vint_branchID;
                    ListBnkMov[0].DailyDate = Vd_DayDate;
                    ListBnkMov[0].TransferValue = decimal.Parse(txtAmountCash.Text);
                    FsDb.SaveChanges();
                }
                var ListElctPayAudit = FsDb.Tbl_MovementTypingAudit.Where(x => x.BankMovementID == vint_RowID).ToList();
                if (ListElctPayAudit.Count > 0)
                {
                    ListElctPayAudit[0].IsUpdate = true;
                    ListElctPayAudit[0].UpdateDate = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                    ListElctPayAudit[0].UserIDData = int.Parse(Program.GlbV_UserId.ToString());
                    FsDb.SaveChanges();
                }

                MessageBox.Show("تم الحفظ");
                //---------------خفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = " تعديل تصنيف دفع اليكتروني بعد المراجعه",
                    TableName = "Tbl_BankMovement",
                    TableRecordId = vint_RowID.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة مراجعة الدفع الاليكتروني"

                };

                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //************************************
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل تصنيف دفع اليكتروني بعد مراجعته .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox3.Checked = false;
            txtBranch.Focus();
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox2.Checked = false;
            txtBranch.Focus();
        }

         
    }
}
