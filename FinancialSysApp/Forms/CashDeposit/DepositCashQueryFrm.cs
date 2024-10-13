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
    public partial class DepositCashQueryFrm : Form
    {
        int Vint_BranchID = 0;
        int Vint_BankDepositeId = 0;

        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public DepositCashQueryFrm()
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
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 97 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques1.Dtb_Banks);
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك المودع";

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

                cmbUser.DataSource = list;
                cmbUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                cmbUser.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbUser.DisplayMember = "Name";
                cmbUser.ValueMember = "ID";
                if (cmbUser.Items.Count > 0)
                {
                    cmbUser.SelectedIndex = -1;
                    cmbUser.Text = "اختر المستخدم";
                }
                dTPDeposit.Focus();
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية استعلام عن يوميات ايداع النقديه .. برجاء مراجعة مدير المنظومه");
                this.Close();
            }
        }
        private void NonDepositBranches(DateTime d1,DateTime d2)
        {
            var ListCountBr = FsDb.Tbl_Management.Where(x => x.KindBranchDirect == 1 && (x.BrancheName != "" && x.BrancheName != null)).ToList();

            string Vstr_NonDepBranch = "";
            foreach (var v in ListCountBr)
            {
               
              var LBranchNonDeposit = FsDb.Tbl_DepositCash.Where(x => x.BranchID == v.ID && x.DepositDate >= d1 && x.DepositDate <= d2).ToList();
                if (LBranchNonDeposit.Count == 0)
                {
                    Vstr_NonDepBranch = v.BrancheName +  " =/= " + Vstr_NonDepBranch;
                   
                }
                txtNonDepBranches.Text = Vstr_NonDepBranch;
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
                txtRepresentive.Text = "";
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك";

                cmbUser.SelectedIndex = -1;
                cmbUser.Text = "";
                cmbUser.Text = "اختر المستخدم";
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
                    txtRepresentive.Text = "";
                    cmbBnkDeposit.SelectedIndex = -1;
                    cmbBnkDeposit.Text = "";
                    cmbBnkDeposit.Text = "اختر البنك";

                    cmbUser.SelectedIndex = -1;
                    cmbUser.Text = "";
                    cmbUser.Text = "اختر المستخدم";
                    txtAmountCash.Text = "";
                }
            }
        }

        private void txtRepresentive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUser.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (txtBranchID.Text != "")
                {
                    Vint_BranchID = int.Parse(txtBranchID.Text);
                    Forms.BasicCodeForms.FindRepresentativesFrm t = new Forms.BasicCodeForms.FindRepresentativesFrm();
                    t.txtBrunchID.Text = Vint_BranchID.ToString();
                    t.ShowDialog();
                    Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                    Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                    //t.dataGridView1.DataSource = FsDb.Tbl_Representatives.Where(x => x.BranchID == Vint_BranchID);
                    if (Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow != null)
                    {
                        txtRepresentive.Text = Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow.Cells[1].Value.ToString();
                        txtRepresentiveID.Text = Forms.BasicCodeForms.FindRepresentativesFrm.SelectedRow.Cells[0].Value.ToString();
                        int Vint_Repid = int.Parse(txtRepresentiveID.Text);
                        this.dtpDepositCashTableAdapter.FillByRepresintiveID(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vint_Repid, Vst_DepositDate2);
                        LoadSerial();
                        TotalGr();
                        txtBranch.Text = "";
                        //txtRepresentive.Text = "";
                        cmbBnkDeposit.SelectedIndex = -1;
                        cmbBnkDeposit.Text = "";
                        cmbBnkDeposit.Text = "اختر البنك";

                        cmbUser.SelectedIndex = -1;
                        cmbUser.Text = "";
                        cmbUser.Text = "اختر المستخدم";
                        txtAmountCash.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("من فضلك اختر الفرع");
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
                txtNonDepBranches.Text = "";
                this.dtpDepositCashTableAdapter.FillByDepositBank(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vint_BankDepositeId, Vst_DepositDate2);
                LoadSerial();
                TotalGr();
                
                txtBranch.Text = "";
               
                txtRepresentive.Text = "";
                //cmbBnkDeposit.SelectedIndex = -1;
                //cmbBnkDeposit.Text = "";
                //cmbBnkDeposit.Text = "اختر البنك";

                cmbUser.SelectedIndex = -1;
                cmbUser.Text = "";
                cmbUser.Text = "اختر المستخدم";
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
                txtRepresentive.Text = "";
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك";

                cmbUser.SelectedIndex = -1;
                cmbUser.Text = "";
                cmbUser.Text = "اختر المستخدم";
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

                    txtNonDepBranches.Text = "";
                    txtBranch.Text = "";
                    txtRepresentive.Text = "";
                    cmbBnkDeposit.SelectedIndex = -1;
                    cmbBnkDeposit.Text = "";
                    cmbBnkDeposit.Text = "اختر البنك";

                    cmbUser.SelectedIndex = -1;
                    cmbUser.Text = "";
                    cmbUser.Text = "اختر المستخدم";
                    //txtAmountCash.Text = "";

                }
                txtRepresentive.Focus();
            }
        }

        private void cmbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                int Vint_userid = int.Parse(cmbUser.SelectedValue.ToString());
                this.dtpDepositCashTableAdapter.FillByUserID(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vst_DepositDate2, Vint_userid);
                LoadSerial();
                TotalGr();
                txtNonDepBranches.Text = "";
                //NonDepositBranches();
                txtBranch.Text = "";
                txtRepresentive.Text = "";
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "";
                cmbBnkDeposit.Text = "اختر البنك";

                //cmbUser.SelectedIndex = -1;
                //cmbUser.Text = "";
                //cmbUser.Text = "اختر المستخدم";
                txtAmountCash.Text = "";
                dTPDeposit2.Focus();
            }
        }
    }
}
