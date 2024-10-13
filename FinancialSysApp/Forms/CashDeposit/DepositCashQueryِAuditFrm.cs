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

namespace FinancialSysApp.Forms.CashDeposit
{
    public partial class DepositCashQueryِAuditFrm : Form
    {
        int Vint_BranchID = 0;
        int Vint_BankDepositeId = 0;

        long Vlng_rowIdDepositCash = 0;
        string Image_Path = "";

        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public DepositCashQueryِAuditFrm()
        {
            InitializeComponent();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void DepositCashQueryFrm_Load(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 108 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques1.Dtb_Banks);
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك المودع";




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
                comboBox1.Text = "اختر البنك المودع";

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
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية استعلام عن يوميات ايداع النقديه .. برجاء مراجعة مدير المنظومه");
                this.Close();
            }
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

            txtBranchِAud.Text = "";
            textBox3.Text = "";
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
                                           select Convert.ToDouble(row.Cells[9].Value)).Sum(), 3).ToString();
            txtAllCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                select Convert.ToDouble(row.Cells[9].Value)).Count().ToString();
        }
        private void dTPDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                //Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                //DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                //DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                //this.dtpDepositCashTableAdapter.FillByDepositDate(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vst_DepositDate2);
                //LoadSerial();
                //TotalGr();
                //NonDepositBranches(d1, d2);
                txtBranch.Text = "";

                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك";


                txtAmountCash.Text = "";
                dTPDeposit2.Focus();
            }
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
                    Vint_BranchID = int.Parse(txtBranchID.Text);
                    Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                    Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                    this.dtpDepositCashTableAdapter.FillByBranchId(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vint_BranchID, Vst_DepositDate2);
                    LoadSerial();
                    TotalGr();

                    cmbBnkDeposit.SelectedIndex = -1;
                    cmbBnkDeposit.Text = "";
                    cmbBnkDeposit.Text = "اختر البنك";
                    ChaeqDataBankChequeAuditFirst();

                    txtAmountCash.Text = "";
                }
            }
        }



        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                //txtNonDepBranches.Text = "";
                this.dtpDepositCashTableAdapter.FillByDepositBank(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vint_BankDepositeId, Vst_DepositDate2);
                LoadSerial();
                TotalGr();

                txtBranch.Text = "";

                ChaeqDataBankChequeAudit();
                //cmbBnkDeposit.SelectedIndex = -1;
                //cmbBnkDeposit.Text = "";
                //cmbBnkDeposit.Text = "اختر البنك";



                txtAmountCash.Text = "";
                txtAmountCash.Focus();
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
                this.dtpDepositCashTableAdapter.FillByDepositDate(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vst_DepositDate2);
                LoadSerial();
                TotalGr();
                NonDepositBranches(d1, d2);
                txtBranch.Text = "";
                //txtRepresentive.Text = "";
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك";


                txtAmountCash.Text = "";
                

                txtBranch.Focus();
            }
        }

        private void txtAmountCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                if (txtAmountCash.Text != "")
                {
                    decimal Vdc_Amount = Convert.ToDecimal(txtAmountCash.Text);
                    this.dtpDepositCashTableAdapter.FillByAmountCheq(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vdc_Amount, Vst_DepositDate2);
                    LoadSerial();
                    TotalGr();

                    //txtNonDepBranches.Text = "";
                    txtBranch.Text = "";
                    //txtRepresentive.Text = "";
                    cmbBnkDeposit.SelectedIndex = -1;
                    cmbBnkDeposit.Text = "";
                    cmbBnkDeposit.Text = "اختر البنك";


                    //txtAmountCash.Text = "";

                }
                //txtRepresentive.Focus();
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

                    txtBranchID.Text = currentRow.Cells[3].Value.ToString();
                    txtBranchِAud.Text = currentRow.Cells[2].Value.ToString();
                    txtAmountCash.Text = currentRow.Cells[9].Value.ToString();
                    txtBnkDepositID.Text = currentRow.Cells[6].Value.ToString();
                    int Vint_BankAccID = int.Parse(currentRow.Cells[7].Value.ToString());
                    int Vint_BankID = int.Parse(txtBnkDepositID.Text);
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


                    dateTimePicker1.Value = Convert.ToDateTime(currentRow.Cells[4].Value.ToString());
                    dTpBankDueDate.Value = Convert.ToDateTime(currentRow.Cells[5].Value.ToString());
                    txtAccountBnkID.Text = currentRow.Cells[7].Value.ToString();
                    if (txtAccountBnkID.Text != "")
                    {
                        int Vint_accId = int.Parse(txtAccountBnkID.Text);
                        var list = FsDb.Tbl_AccountsBank.FirstOrDefault(x => x.ID == Vint_accId);
                        //txtAccountBnk.Text = list.AccountBankNo;
                    }

                    //txtDepositCashNo.Text = currentRow.Cells["DepositCashNo"].Value.ToString();

                    //txtRepresentiveID.Text = currentRow.Cells["RepresentiveID"].Value.ToString();
                    //if (txtRepresentiveID.Text != "")
                    //{
                    //    int Vint_repId = int.Parse(txtRepresentiveID.Text);
                    //    var list = FsDb.Tbl_Representatives.FirstOrDefault(x => x.ID == Vint_repId);
                    //    if (list != null)
                    //    { txtRepresentive.Text = list.Name; }
                    //}
                    chckBxBasicData.Checked = false;
                    //****************Refrences***************
                    AccDepAuditSelect(Vlng_rowIdDepositCash);
                    //***************************************

                    cmbBnkDeposit.Text = currentRow.Cells[14].Value.ToString();



                }
            }
        }
        private void ChaeqDataBankChequeAuditFirst()
        {
            
                long Vlng_CheckID = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    Vlng_CheckID = long.Parse(row.Cells[1].Value.ToString());
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

                    Vlng_CheckID = long.Parse(row.Cells[1].Value.ToString());
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

        private void dTPDeposit2_Leave(object sender, EventArgs e)
        {
            ChaeqDataBankChequeAuditFirst();
        }

        private void txtBranch_Leave(object sender, EventArgs e)
        {
            //ChaeqDataBankChequeAuditFirst();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (txtRowID.Text != "")
            {
                Forms.DocumentsForms.CheqScanFrm t = new Forms.DocumentsForms.CheqScanFrm();
                //**************بيانات الخافظه 
                t.txtbranch.Text = this.txtBranch.Text;
                //t.txtCollectionNo.Text = this.txtDepositCashNo.Text;
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
                //Forms.DocumentsForms.ShowScanDocuments t = new Forms.DocumentsForms.ShowScanDocuments();
                //if ((Application.OpenForms["ShowScanDocuments"] as ShowScanDocuments != null))
                //{
                //    t.BringToFront();
                //    //*********************
                //    this.SendToBack();
                //}
                //else
                //{
                //    t.Show();
                //    t.BringToFront();
                //}

            }
            else
            {
                MessageBox.Show("من فضلك اختر الايداع المراد عرض صورته اولا");
            }
        }
    }
}
