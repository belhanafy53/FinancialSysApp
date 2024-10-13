using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils;
using FinancialSysApp.Classes;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using FinancialSysApp.DepositCashDSTableAdapters;

namespace FinancialSysApp.Forms.Banks
{
    public partial class CheqBankStatusADDCancel : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        long? Vlng_TreasuryCollectionID = 0;
        int Vint_BankDrawnOnID = 0;
        string VStr_CheqNo = "";
        int Vint_DepositBank = 0;
        int Vint_ChequeStatusIDNew = 0;
        public CheqBankStatusADDCancel()
        {
            InitializeComponent();
        }
        private void clearDate()
        {
            //txtBankAccPaperNo.Text = "";
            txtBankDrawnOn.Text = "";
            txtAmount.Text = "";
            txtChequeNo.Text = "";
            txtTrCollectionAmount.Text = "";
            //dTPDueDate.Value = Convert.ToDateTime(DateTime.Today.ToString());
            //dTpDayBank.Value = Convert.ToDateTime(DateTime.Today.ToString());

        }
        private void clearDateMaster()
        {

            dTPAddBank.Value = Convert.ToDateTime(DateTime.Today.ToString());
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "اختر البنك المودع ";

        }

        private void CheqBankStatusADDCancel_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_BankCheque' table. You can move, or remove it, as needed.

            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "اختر البنك المودع ";
            AddColumnDtaGrd1();
            GrdBnkCheq();
            cbxCheqs.Checked = true;
            cbxCash.Checked = false;
            cmbBnkDeposit.Select();
            this.ActiveControl = cmbBnkDeposit;
            cmbBnkDeposit.Focus();
        }
        private void GrdBankCheqData(DateTime Vdt_AddDateBank)
        {
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where ((BnkChq.ChequeStatusID == 2 || BnkChq.ChequeStatusID == 3) && BnkChq.AddDateBank == Vdt_AddDateBank)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,

                                     ChequeKind = BnkChq.ChequeKindID,
                                     //CustomerName = Cust.Name,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.ChequeStatusID).ThenBy(x => x.ChequeDueDate).ToList();

            dataGridView1.DataSource = listBnkCheque;
            LoadSerial();
            ColorSt();
            //GrdBnkCheq();
        }
        private void ColorSt()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Vlng_TreasuryCollectionID = int.Parse(row.Cells["TreasuryCollectionID"].Value.ToString());
                //int Vint_ChequeStatusID = int.Parse(row.Cells["ChequeStatusID"].Value.ToString());
                //if (Vint_ChequeStatusID == 4)
                //{
                //    row.DefaultCellStyle.BackColor = Color.Red;
                //    row.DefaultCellStyle.ForeColor = Color.White;
                //}
                var listofBnk = (from TR in FsDb.Tbl_TreasuryCollection
                                 join bnk in FsDb.Tbl_Banks on TR.BankDepositeID equals bnk.ID
                                 where (TR.ID == Vlng_TreasuryCollectionID)
                                 select new
                                 {
                                     BankDepositName = bnk.Name,
                                 }).ToList();
                if (listofBnk.Count != 0)

                {
                    row.Cells["BankDeposit"].Value = listofBnk[0].BankDepositName;
                    row.Cells["CheqTrue"].Value = true;
                }

            }
        }
        private void GrdBankCheqDataSearch(int? Vint_BankDrawnOnID, string VStr_CheqNo, decimal? VDbl_cheqAmount, DateTime? VDt_dueDate)
        {
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals bnkD.ID
                                 where ((BnkChq.ChequeStatusID == 2 || BnkChq.ChequeStatusID == 3) && (BnkChq.BankDrawnOnID == Vint_BankDrawnOnID) && BnkChq.AddDateBank <= dTPAddBank.Value)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     BankDeposit = bnkD.Name,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     //CustomerName = Cust.Name,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
            if (listBnkCheque != null)
            {
                LoadSerial();
                ColorSt();
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    Vlng_TreasuryCollectionID = int.Parse(row.Cells["TreasuryCollectionID"].Value.ToString());
                    int Vint_ChequeStatusID = int.Parse(row.Cells["ChequeStatusID"].Value.ToString());
                    if (Vint_ChequeStatusID == 4)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    var listofBnk = (from TR in FsDb.Tbl_TreasuryCollection
                                     join bnk in FsDb.Tbl_Banks on TR.BankDepositeID equals bnk.ID
                                     where (TR.ID == Vlng_TreasuryCollectionID)
                                     select new
                                     {
                                         BankDepositName = bnk.Name

                                     }).ToList();
                    if (listofBnk.Count != 0)

                    {
                        row.Cells["BankDeposit"].Value = listofBnk[0].BankDepositName;
                        row.Cells[" CheqTrue"].Value = true;
                    }
                }
                //GrdBnkCheq();
            }
        }

        private void LoadSerial()
        {
            int i = 1;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;

            }
        }
        private void LoadSerial5()
        {
            int i = 1;


            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                row.Cells[0].Value = i; i++;

            }
        }

        private void GrdBnkCheq()
        {


            dataGridView1.Columns["TreasuryCollectionID"].Visible = false;
            dataGridView1.Columns["AmountCheque"].Visible = true;
            dataGridView1.Columns["AmountCheque"].ReadOnly = true;
            dataGridView1.Columns["ID"].Visible = false;


            dataGridView1.Columns["BankDrawnOnID"].Visible = false;
            dataGridView1.Columns["ChequeNo"].Visible = true;
            dataGridView1.Columns["ChequeNo"].ReadOnly = true;

            dataGridView1.Columns["ChequeDueDate"].Visible = true;
            dataGridView1.Columns["ChequeDueDate"].ReadOnly = true;
            dataGridView1.Columns["DepositedByTrRepresntvID"].Visible = false;

            dataGridView1.Columns["CustID"].Visible = false;
            dataGridView1.Columns["AddDateBank"].Visible = true;
            dataGridView1.Columns["AddDateBank"].ReadOnly = true;
            dataGridView1.Columns["ChequeKind"].Visible = false;
            dataGridView1.Columns["CheqTrue"].Visible = false;


            dataGridView1.Columns["ReceiptNo"].Visible = false;
            dataGridView1.Columns["BankName"].Visible = true;
            dataGridView1.Columns["BankName"].ReadOnly = true;
            dataGridView1.Columns["BankName"].Width = 200;
            //dataGridView1.Columns["Tbl_ChequeKind"].Visible = true;
            //dataGridView1.Columns["Tbl_TreasuryCollection"].Visible = true;
            dataGridView1.Columns["ChequeNo"].Width = 150;

            dataGridView1.Columns["AmountCheque"].HeaderText = "مبلغ الشيك";
            dataGridView1.Columns["AmountCheque"].Width = 120;

            dataGridView1.Columns["AddDateBank"].HeaderText = "تاريخ الاضافه";
            dataGridView1.Columns["AddDateBank"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["ChequeDueDate"].HeaderText = "تاريخ استخقاق الشيك";
            dataGridView1.Columns["ChequeDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["DepositDate"].HeaderText = "تاريخ الايداع";
            dataGridView1.Columns["DepositDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["ChequeNo"].HeaderText = "رقم الشيك";


            dataGridView1.Columns["ParentID"].Visible = false;
            dataGridView1.Columns["ParentID"].HeaderText = "الحافظه الام";

            dataGridView1.Columns["BankName"].HeaderText = "البنك المسحوب عليه";
            dataGridView1.Columns["BankDeposit"].HeaderText = "البنك المودع";
            dataGridView1.Columns["BankDeposit"].ReadOnly = true;
            dataGridView1.Columns["BankDeposit"].Width = 200;
            dataGridView1.Columns["TradeCollectionNo"].HeaderText = "رقم الصفحه";
            dataGridView1.Columns["TradeCollectionNo"].ReadOnly = true;
            dataGridView1.Columns["TradeCollectionNo"].Visible = true;
            dataGridView1.Columns["AddDateAccBank"].HeaderText = "تاريخ يومية البنك";
            dataGridView1.Columns["AddDateAccBank"].ReadOnly = true;
            dataGridView1.Columns["AddDateAccBank"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["BankDueDate"].HeaderText = "تاريخ حق البنك";
            dataGridView1.Columns["BankDueDate"].ReadOnly = true;
            dataGridView1.Columns["BankDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";





        }
        private void GrdTotalValue()
        {
            //try
            //{

            int Vint_DgCount = dataGridView1.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                     select Convert.ToDouble(row.Cells[5].Value)).Sum(), 3).ToString();
                txtCheqAllCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                        select Convert.ToDouble(row.Cells[5].Value)).Count().ToString();

                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[4].Value)).Count().ToString());

            }
            //}
            //catch
            //{ }
        }
        private void GrdTotalValueCash()
        {
            //try
            //{

            int Vint_DgCount = dataGridView1.RowCount;
            if (Vint_DgCount != 0)
            {


                txtTotalCash.Text = Math.Round((from DataGridViewRow row in dataGridView5.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[11].Value)).Sum(), 3).ToString();
                

            }
            //}
            //catch
            //{ }
        }
        private void txtBankDrawnOn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChequeNo.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    Forms.BasicCodeForms.FindBankParentFrm t = new Forms.BasicCodeForms.FindBankParentFrm();
                    t.ShowDialog();

                    if (t.txtBankId != null && t.txtBankId.Text != "")
                    {
                        txtBankDrawnOn.Text = t.txtSelected.Text;
                        txtBankDrawnOnID.Text = t.txtBankId.Text;
                        Vint_BankDrawnOnID = int.Parse(txtBankDrawnOnID.Text);
                        //GrdBankCheqDataSearch(Vint_BankDrawnOnID, null, null, null);
                        if (dataGridView1.Rows.Count != 0)
                        { dataGridView1.Rows.Clear(); }
                        DgrCheqAddedBankDrawnOn(Vint_BankDrawnOnID);
                        DgrChequesTrueDepositDrawnon(Vint_BankDrawnOnID);


                        if (dataGridView2.Rows.Count != 0 || dataGridView3.Rows.Count != 0)
                        {
                            //if (dataGridView1.Rows.Count == 0)
                            //{
                            //    AddColumnDtaGrd1();
                            //}
                            DgrCheqDepositAndAdded();
                            //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                            GrdBnkCheq();
                            GrdTotalValue();



                        }

                    }
                    txtChequeNo.Focus();
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }

            }
        }

        private void txtChequeNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void dTPDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dTPAddBank_ValueChanged(object sender, EventArgs e)
        {
            //GrdBankCheqData(Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd")));
            //LoadSerial();
            //GrdBnkCheq();
            //GrdTotalValue();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 84 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                long? Vlng_ChqBnkID = 0;
                long? Vlng_CashDepID = 0;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حفظ الشيكات التي تم اضافتها للحساب");
                //************اضافة الشيكات
                if (cbxCheqs.Checked == true)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells["ID"].Value.ToString());

                        //if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == true)
                        //{

                        var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();
                        if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView1.Rows[j].Cells["CheqTrue"].Value) == true)
                        {
                            listBankCheq[0].IsAddedAccNo = true;
                            listBankCheq[0].ChequeStatusID = 3;
                            listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dTPAddBank.Value.ToString());
                            listBankCheq[0].TradeCollectionNo = txtBankAccPaperNo.Text;
                            listBankCheq[0].AddDateAccBank = Convert.ToDateTime(dTpDayBank.Value.ToString());
                            var listCheqStatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 3).ToList();
                            if (listCheqStatus.Count == 0)
                            {
                                Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                                {
                                    BankChequeStatusID = 3,
                                    BankChequeID = Vlng_ChqBnkID,

                                    ChequeBankStatusDate = Convert.ToDateTime(dTPAddBank.Value.ToString())
                                };

                                FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                                FsDb.SaveChanges();
                            }
                            else
                            {
                                listCheqStatus[0].ChequeBankStatusDate = Convert.ToDateTime(dTPAddBank.Value.ToString());
                                FsDb.SaveChanges();
                            }


                        }
                      else  if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
                        {
                            //var V_listTRCollection = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == listBankCheq[0].TreasuryCollectionID);
                            listBankCheq[0].IsAddedAccNo = false;
                            listBankCheq[0].ChequeStatusID = 2;
                            //listBankCheq[0].AddDateBank = null;
                            listBankCheq[0].AddDateAccBank = null;
                            listBankCheq[0].TradeCollectionNo = "";
                            listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dataGridView1.Rows[j].Cells["DepositDate"].Value.ToString());
                            var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 3);
                            if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }

                            FsDb.SaveChanges();
                        }
                        //}

                    }
                }
                //*************اضافة النقديه
                else if (cbxCash.Checked == true)
                {
                    for (int j = 0; j < dataGridView5.Rows.Count; j++)
                    {
                        Vlng_CashDepID = long.Parse(dataGridView5.Rows[j].Cells[3].Value.ToString());

                         

                        var listCashDeposit = FsDb.Tbl_DepositCash.Where(x => x.ID == Vlng_CashDepID).ToList();
                        if (Convert.ToBoolean(dataGridView5.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView5.Rows[j].Cells["CheqTrue"].Value) == true)
                        {
                             
                            listCashDeposit[0].DepositCashStatusID = 2;
                            listCashDeposit[0].DepositCashStatusDate = Convert.ToDateTime(dTPAddBank.Value.ToString());
                            listCashDeposit[0].BankPaperNo = txtBankAccPaperNo.Text;
                            listCashDeposit[0].BankAddDate = Convert.ToDateTime(dTpDayBank.Value.ToString());
                            listCashDeposit[0].IsAddedAccNo = true;

                            var listDepositStatus = FsDb.Tbl_DepositCashStatusDates.Where(x => x.DepositCashID == Vlng_CashDepID && x.DepositCashStatusID == 2).ToList();
                            if (listDepositStatus.Count == 0)
                            {
                                Tbl_DepositCashStatusDates ChStDate = new Tbl_DepositCashStatusDates
                                {
                                    DepositCashStatusID = 2,
                                    DepositCashID = Vlng_CashDepID,
                                    StatusDate = Convert.ToDateTime(dTPAddBank.Value.ToString())
                                };

                                FsDb.Tbl_DepositCashStatusDates.Add(ChStDate);
                                FsDb.SaveChanges();
                            }
                            else
                            {
                                listDepositStatus[0].StatusDate = Convert.ToDateTime(dTPAddBank.Value.ToString());
                                FsDb.SaveChanges();
                            }


                        }
                        else if (Convert.ToBoolean(dataGridView5.Rows[j].Cells[1].Value) == false)
                        {
                            //var V_listTRCollection = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == listBankCheq[0].TreasuryCollectionID);
                            listCashDeposit[0].IsAddedAccNo = false;
                            listCashDeposit[0].DepositCashStatusID = 1;
                            //listBankCheq[0].AddDateBank = null;
                            listCashDeposit[0].BankAddDate = null;
                            listCashDeposit[0].BankPaperNo = "";
                            listCashDeposit[0].DepositCashStatusDate = Convert.ToDateTime(dataGridView5.Rows[j].Cells[6].Value.ToString());
                            var listStDelete = FsDb.Tbl_DepositCashStatusDates.FirstOrDefault(x => x.DepositCashID == Vlng_CashDepID && x.DepositCashStatusID == 2);
                            if (listStDelete != null) { FsDb.Tbl_DepositCashStatusDates.Remove(listStDelete); }

                            FsDb.SaveChanges();
                        }
                        //}

                    }
                }
                else
                {
                    MessageBox.Show("من فضلك حدد ما الذي تريد اضافته شيكات ام نقديه");
                }
                //---------------خفظ ااحداث 
                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "اضافة موقف شيك ",
                    TableName = "Tbl_TreasuryCollection",
                    TableRecordId = Vlng_ChqBnkID.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة اضافة الشيكات للحسابات البنكيه"

                };

                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //************************************

                splashScreenManager1.CloseWaitForm();
                MessageBox.Show("تم الحفظ");
                //clearDateMaster();
                clearDate();
                txtAmount.Focus();

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  موقف شيك تم اضافته للحساب ام لا  .. برجاء مراجعة مدير المنظومه");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            GrdTotalValue();
        }
        private void DgrChequesTrueDeposit(DateTime Vd_AddedDate)
        {
            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.DataSource = null;
            }
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 2 && BnkChq.IsAddedAccNo == null)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
        private void DgrChequesTrueDepositDrawnon(int Vint_BankDrawnOnID)
        {
            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.DataSource = null;
            }
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 2 && BnkChq.BankDrawnOnID == Vint_BankDrawnOnID)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
        private void DgrChequesTrueDepositBank(int Vint_Bank)
        {
            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.DataSource = null;
            }
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 2 && TRC.BankDepositeID == Vint_Bank)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
        private void DgrChequesTrueDepositDayBank(DateTime Vd_AddedDate, int Vint_Bank, DateTime Vd_AddedDayBank)
        {
            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.DataSource = null;
            }
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 2 && BnkChq.AddDateBank <= Vd_AddedDate && TRC.BankDepositeID == Vint_Bank && BnkChq.AddDateAccBank == null)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
    
        private void DgrChequesTrueDepositAmountCh(int Vint_Bank, Decimal Vd_AmountCh)
        {

            if (cBSearchG.Checked == true)
            {
                Vint_ChequeStatusIDNew = 5;
            }
            else if (cBSearchG.Checked == false)
            {
                Vint_ChequeStatusIDNew = 2;
            }
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID <= Vint_ChequeStatusIDNew && BnkChq.ChequeStatusID >= 2 && TRC.BankDepositeID == Vint_Bank && BnkChq.AmountCheque == Vd_AmountCh)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }

        private void DgrChequesTrueDepositAmountTrColl(int Vint_Bank, Decimal Vd_AmountTR)
        {
            //if (dataGridView2.RowCount > 0)
            //{
            //    dataGridView2.Rows.Clear();
            //    dataGridView2.DataSource = null;
            //}
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 2 && TRC.BankDepositeID == Vint_Bank && TRC.TotalAmountCheqs == Vd_AmountTR)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
        private void DgrChequesTrueDepositDueDateCh(int Vint_Bank, DateTime Vd_DueDate)
        {
            dataGridView2.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 2 && TRC.BankDepositeID == Vint_Bank && BnkChq.ChequeDueDate <= Vd_DueDate)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
        private void DgrChequesTrueDepositPaperNo(DateTime Vd_AddedDate, int Vint_BankDeposit, string Vst_PaperNo)
        {
            dataGridView2.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 2 && TRC.BankDepositeID == Vint_BankDeposit && BnkChq.IsAddedAccNo == null)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView2.DataSource = listBnkCheque;
        }
        private void DgrCheqAddedOurAcount(DateTime Vd_AddedDate)
        {
            if (dataGridView3.RowCount > 0)
            {
                dataGridView3.DataSource = null;
            }

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 3 && BnkChq.AddDateBank == Vd_AddedDate)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }
        private void DgrCheqAddedOurAcountBank(int Vint_Bank)
        {
            dataGridView3.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 3 && TRC.BankDepositeID == Vint_Bank)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }
        private void DgrCheqAddedDayBank(int Vint_Bank, DateTime Vd_AddedDayBank)
        {

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 3 && TRC.BankDepositeID == Vint_Bank && BnkChq.AddDateAccBank == Vd_AddedDayBank)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }
        private void DgrCheqAddedAmountCh(DateTime Vd_AddedDate, int Vint_Bank, decimal Vst_amountCh)
        {
            dataGridView3.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where ((BnkChq.ChequeStatusID == 2 || BnkChq.ChequeStatusID == 3) && TRC.BankDepositeID == Vint_Bank && BnkChq.AmountCheque == Vst_amountCh)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }

        private void DgrCheqAddedDueDateCh(int Vint_Bank, DateTime Vd_DueDate)
        {
            dataGridView3.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where ((BnkChq.ChequeStatusID == 2 || BnkChq.ChequeStatusID == 3) && TRC.BankDepositeID == Vint_Bank)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }
        private void DgrCheqAddedDueDateCh(DateTime Vd_AddedDate, int Vint_Bank, DateTime Vd_DueDate)
        {
            dataGridView3.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where ((BnkChq.ChequeStatusID == 2 || BnkChq.ChequeStatusID == 3) && TRC.BankDepositeID == Vint_Bank && BnkChq.AddDateBank == Vd_AddedDate && BnkChq.ChequeDueDate == Vd_DueDate)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }
        private void DgrCheqAddedOurAcountPaperNo(DateTime Vd_AddedDate, int Vint_BankDeposit, string PaperNo)
        {
            dataGridView3.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 3 && TRC.BankDepositeID == Vint_BankDeposit && BnkChq.AddDateAccBank == Vd_AddedDate && BnkChq.TradeCollectionNo == PaperNo)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     ChequeStatusID = BnkChq.ChequeStatusID

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }
        private void DgrCheqAddedBankDrawnOn(int Vint_BankDrawnOn)
        {
            dataGridView3.DataSource = null;
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (BnkChq.ChequeStatusID == 3 && BnkChq.BankDrawnOnID == Vint_BankDrawnOnID)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositDate = TRC.DepositDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,

                                 }).OrderBy(x => x.AddDateBank).ToList();

            dataGridView3.DataSource = listBnkCheque;
        }
        private void AddColumnDtaGrd1()
        {
            // Create a new columns datadridview1
            DataGridViewTextBoxColumn newColumnID = new DataGridViewTextBoxColumn();

            // Set the properties of the new column
            newColumnID.HeaderText = "ID"; // Header text of the column
            newColumnID.Name = "ID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnID);

            DataGridViewTextBoxColumn newColumnName = new DataGridViewTextBoxColumn();
            newColumnName.Name = "TreasuryCollectionID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnName);

            DataGridViewTextBoxColumn newColumnAmountCheque = new DataGridViewTextBoxColumn();
            newColumnAmountCheque.Name = "AmountCheque"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAmountCheque);

            DataGridViewTextBoxColumn newColumnBankDrawnOnID = new DataGridViewTextBoxColumn();
            newColumnBankDrawnOnID.Name = "BankDrawnOnID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankDrawnOnID);

            DataGridViewTextBoxColumn newColumnChequeNo = new DataGridViewTextBoxColumn();
            newColumnChequeNo.Name = "ChequeNo"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeNo);

            DataGridViewTextBoxColumn newColumnChequeDueDate = new DataGridViewTextBoxColumn();
            newColumnChequeDueDate.Name = "ChequeDueDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeDueDate);

            DataGridViewTextBoxColumn newColumnDepositDate = new DataGridViewTextBoxColumn();
            newColumnDepositDate.Name = "DepositDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositDate);

            DataGridViewTextBoxColumn newColumnAddDateBank = new DataGridViewTextBoxColumn();
            newColumnAddDateBank.Name = "AddDateBank"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAddDateBank);

            DataGridViewTextBoxColumn newColumnAddDateAccBank = new DataGridViewTextBoxColumn();
            newColumnAddDateAccBank.Name = "AddDateAccBank"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAddDateAccBank);

            DataGridViewTextBoxColumn newColumnBankDueDate = new DataGridViewTextBoxColumn();
            newColumnBankDueDate.Name = "BankDueDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankDueDate);
            //*****************
            DataGridViewTextBoxColumn newColumnTradeCollectionNo = new DataGridViewTextBoxColumn();
            newColumnTradeCollectionNo.Name = "TradeCollectionNo"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnTradeCollectionNo);

            DataGridViewTextBoxColumn newColumnDepositedByTrRepresntvID = new DataGridViewTextBoxColumn();
            newColumnDepositedByTrRepresntvID.Name = "DepositedByTrRepresntvID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositedByTrRepresntvID);

            DataGridViewTextBoxColumn newColumnCustID = new DataGridViewTextBoxColumn();
            newColumnCustID.Name = "CustID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnCustID);



            DataGridViewTextBoxColumn newColumnChequeKind = new DataGridViewTextBoxColumn();
            newColumnChequeKind.Name = "ChequeKind"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeKind);

            DataGridViewTextBoxColumn newColumnBankName = new DataGridViewTextBoxColumn();
            newColumnBankName.Name = "BankName"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankName);

            DataGridViewTextBoxColumn newColumBankDeposit = new DataGridViewTextBoxColumn();
            newColumBankDeposit.Name = "BankDeposit"; // Unique name of the column
            newColumBankDeposit.Visible = true;
            dataGridView1.Columns.Add(newColumBankDeposit);


            DataGridViewTextBoxColumn newColumnReceiptNo = new DataGridViewTextBoxColumn();
            newColumnReceiptNo.Name = "ReceiptNo"; // Unique name of the column
            newColumnReceiptNo.Visible = false;
            dataGridView1.Columns.Add(newColumnReceiptNo);


            DataGridViewCheckBoxColumn newColumnChqUpdate = new DataGridViewCheckBoxColumn();
            newColumnChqUpdate.Name = "ChqBxUpd"; // Unique name of the column
            newColumnChqUpdate.Visible = false;
            dataGridView1.Columns.Add(newColumnChqUpdate);

            DataGridViewTextBoxColumn newColumnParentId = new DataGridViewTextBoxColumn();
            newColumnParentId.Name = "ParentID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnParentId);

            DataGridViewTextBoxColumn newColumnChequeStatusID = new DataGridViewTextBoxColumn();
            newColumnChequeStatusID.Name = "ChequeStatusID"; // Unique name of the column
            newColumnChequeStatusID.Visible = false;
            dataGridView1.Columns.Add(newColumnChequeStatusID);


            DataGridViewCheckBoxColumn newColumnCheqTrue = new DataGridViewCheckBoxColumn();
            newColumnCheqTrue.Name = "CheqTrue"; // Unique name of the column
            //newColumnCheqTrue.Visible = false;
            dataGridView1.Columns.Add(newColumnCheqTrue);






        }
        private void DgrCheqAndAdded()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الشيكات  طبقا لليوم المختار");
            dataGridView1.SuspendLayout();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                     //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                     where (BnkChq.ID == Vint_ID)
                                     select new

                                     {
                                         IsAddedAccNo = BnkChq.IsAddedAccNo,
                                         ID = BnkChq.ID,
                                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                         AmountCheque = BnkChq.AmountCheque,
                                         BankDrawnOnID = BnkChq.BankDrawnOnID,
                                         ChequeNo = BnkChq.ChequeNo,
                                         ChequeDueDate = BnkChq.ChequeDueDate,
                                         DepositDate = TRC.DepositDate,
                                         AddDateBank = BnkChq.AddDateBank,
                                         AddDateAccBank = BnkChq.AddDateAccBank,
                                         BankDueDate = BnkChq.BankDueDate,

                                         TradeCollectionNo = BnkChq.TradeCollectionNo,
                                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                         CustID = BnkChq.CustID,


                                         ChequeKind = BnkChq.ChequeKindID,
                                         //CustomerName = Cust.Name,
                                         BankName = BNK.Name,
                                         BankDeposit = bnkD.Name,
                                         ReceiptNo = TRC.ReceiptNo,
                                         IsDisposed = BnkChq.IsDepositNo,
                                         ParentID = TRC.Parent_ID,
                                         ChequeStatusID = BnkChq.ChequeStatusID



                                     }).OrderBy(x => x.ChequeDueDate).ToList();


                for (int j = 0; j < (listBnkCheque.Count); j++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, listBnkCheque[j].IsAddedAccNo, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                    listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositDate, listBnkCheque[j].AddDateBank, listBnkCheque[j].AddDateAccBank, listBnkCheque[j].BankDueDate, listBnkCheque[j].TradeCollectionNo, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName, listBnkCheque[j].BankDeposit,
                   listBnkCheque[j].ReceiptNo, listBnkCheque[j].IsDisposed, listBnkCheque[j].ParentID, listBnkCheque[j].ChequeStatusID, true
                  );
                    dataGridView1.AllowUserToAddRows = false;
                }
                //LoadSerial();
                //ColorSt();
            }
            dataGridView1.ResumeLayout();
            LoadSerial();
            ColorSt();
            splashScreenManager1.CloseWaitForm();
        }

        private void DgrCheqDepositAndAdded()
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الشيكات  طبقا لليوم المختار");
            dataGridView1.SuspendLayout();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                     //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                     where (BnkChq.ID == Vint_ID)
                                     select new

                                     {
                                         IsAddedAccNo = BnkChq.IsAddedAccNo,
                                         ID = BnkChq.ID,
                                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                         AmountCheque = BnkChq.AmountCheque,
                                         BankDrawnOnID = BnkChq.BankDrawnOnID,
                                         ChequeNo = BnkChq.ChequeNo,
                                         ChequeDueDate = BnkChq.ChequeDueDate,
                                         DepositDate = TRC.DepositDate,
                                         AddDateBank = BnkChq.AddDateBank,
                                         AddDateAccBank = BnkChq.AddDateAccBank,
                                         BankDueDate = BnkChq.BankDueDate,

                                         TradeCollectionNo = BnkChq.TradeCollectionNo,
                                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                         CustID = BnkChq.CustID,


                                         ChequeKind = BnkChq.ChequeKindID,
                                         //CustomerName = Cust.Name,
                                         BankName = BNK.Name,
                                         BankDeposit = bnkD.Name,
                                         ReceiptNo = TRC.ReceiptNo,
                                         IsDisposed = BnkChq.IsDepositNo,
                                         ParentID = TRC.Parent_ID,
                                         ChequeStatusID = BnkChq.ChequeStatusID


                                     }).OrderBy(x => x.ChequeDueDate).ToList();



                for (int j = 0; j < (listBnkCheque.Count); j++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, listBnkCheque[j].IsAddedAccNo, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                    listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositDate, listBnkCheque[j].AddDateBank, listBnkCheque[j].AddDateAccBank, listBnkCheque[j].BankDueDate,
                   listBnkCheque[j].TradeCollectionNo, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName, listBnkCheque[j].BankDeposit,
                   listBnkCheque[j].ReceiptNo, listBnkCheque[j].IsDisposed, listBnkCheque[j].ParentID, listBnkCheque[j].ChequeStatusID, true);
                    dataGridView1.AllowUserToAddRows = false;
                }
                //LoadSerial();
                //ColorSt();
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    Vlng_TreasuryCollectionID = int.Parse(row.Cells["TreasuryCollectionID"].Value.ToString());
                //    int Vint_ChequeStatusID = int.Parse(row.Cells["ChequeStatusID"].Value.ToString());
                //    if (Vint_ChequeStatusID == 4)
                //    {
                //        row.DefaultCellStyle.BackColor = Color.Red;
                //        row.DefaultCellStyle.ForeColor = Color.White;
                //    }
                //    var listofBnk = (from TR in FsDb.Tbl_TreasuryCollection
                //                     join bnk in FsDb.Tbl_Banks on TR.BankDepositeID equals bnk.ID
                //                     where (TR.ID == Vlng_TreasuryCollectionID)
                //                     select new
                //                     {
                //                         BankDepositName = bnk.Name,
                //                     }).ToList();
                //    if (listofBnk.Count != 0)

                //    {
                //        row.Cells["BankDeposit"].Value = listofBnk[0].BankDepositName;
                //        row.Cells["CheqTrue"].Value = true;
                //    }

                //}
            }
            dataGridView1.ResumeLayout();
            //LoadSerial();
            ColorSt();
            splashScreenManager1.CloseWaitForm();
        }

        private void dTPAddBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clearDate();
                if (dataGridView1.Rows.Count != 0)
                { dataGridView1.Rows.Clear(); }
                DgrCheqAddedOurAcount(Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd")));
                DgrChequesTrueDeposit(Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd")));


                if (dataGridView2.Rows.Count != 0 || dataGridView3.Rows.Count != 0)
                {
                    //if (dataGridView1.Rows.Count == 0)
                    //{
                    //    AddColumnDtaGrd1();
                    //}
                    DgrCheqAndAdded();
                    DgrCheqDepositAndAdded();
                    //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                    GrdBnkCheq();
                    GrdTotalValue();



                }
                cmbBnkDeposit.Focus();
            }

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Forms.Banks.RefundCheqFrm t = new Banks.RefundCheqFrm();
            //t.txtCheqId.Text = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            //t.txtCheqNo.Text = this.dataGridView1.CurrentRow.Cells["ChequeNo"].Value.ToString();
            //t.dateTimePicker1.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["ChequeDueDate"].Value.ToString());
            ////t.dateTimePicker1.Value = this.dateTimePicker1.Value;
            //if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            //{
            //    t.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("من فضلك اختر الشيك المراد رده اولا");
            //}
        }

        private void cmbBnkDeposit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clearDate();
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedIndex != -1)
                {
                    //if (dataGridView1.Rows.Count != 0)
                    //{ dataGridView1.Rows.Clear(); }
                    //DgrCheqAddedOurAcountBank( int.Parse(cmbBnkDeposit.SelectedValue.ToString()));
                    //DgrChequesTrueDepositBank(int.Parse(cmbBnkDeposit.SelectedValue.ToString()));


                    //if (dataGridView2.Rows.Count != 0 || dataGridView3.Rows.Count != 0)
                    //{
                    //    //if (dataGridView1.Rows.Count == 0)
                    //    //{
                    //    //    AddColumnDtaGrd1();
                    //    //}
                    //    DgrCheqAndAdded();
                    //    DgrCheqDepositAndAdded();
                    //    //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                    //    GrdBnkCheq();
                    //    GrdTotalValue();



                    //}
                    dTpDayBank.Focus();


                }
            }

        }

        private void txtBankAccPaperNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (dataGridView1.Rows.Count != 0)
                    { dataGridView1.Rows.Clear(); }
                    if (cmbBnkDeposit.SelectedValue != null)
                    {
                        DgrCheqAddedOurAcountPaperNo(Convert.ToDateTime(dTpDayBank.Value.ToString("yyyy/MM/dd")), int.Parse(cmbBnkDeposit.SelectedValue.ToString()), txtBankAccPaperNo.Text);
                        //DgrChequesTrueDepositPaperNo(Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd")), int.Parse(cmbBnkDeposit.SelectedValue.ToString()), txtBankAccPaperNo.Text);


                        if (dataGridView3.Rows.Count != 0)
                        {
                            //if (dataGridView1.Rows.Count == 0)
                            //{
                            //    AddColumnDtaGrd1();
                            //}
                            //splashScreenManager1.ShowWaitForm();
                            //splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حفظ الشيكات التي تم اضافتها للحساب");
                            DgrCheqAndAdded();
                            DgrCheqDepositAndAdded();
                            //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                            GrdBnkCheq();
                            GrdTotalValue();
                            dataGridView1.Columns["Ser"].Visible = true;
                            LoadSerial();
                            //splashScreenManager1.CloseWaitForm();

                        }
                        txtBankDrawnOn.Focus();
                    }
                    else
                    {
                        MessageBox.Show("اختر البنك المودع ");
                        cmbBnkDeposit.Focus();
                    }
                    this.dtpDepositCashTableAdapter.FillByAddDateBankPaperNo(this.depositCashDS.DtpDepositCash, dTpDayBank.Value.ToString("yyyy/MM/dd"), txtBankAccPaperNo.Text, Vint_DepositBank);
                    LoadSerial5();
                    GrdTotalValueCash();
                    txtAmount.Focus();
                }
            }
        }

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (txtChequeNo.Text != "")
                    {
                        if (cBSearchG.Checked == true)
                        {
                            Vint_ChequeStatusIDNew = 5;
                        }
                        else if (cBSearchG.Checked == false)
                        {
                            Vint_ChequeStatusIDNew = 2;
                        }
                        int Vint_bankDeposit = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                        DateTime Vd_AddedDate = Convert.ToDateTime(dTPAddBank.Value.ToString());
                        VStr_CheqNo = txtChequeNo.Text;
                        var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                             join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                             join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                             where ((BnkChq.ChequeStatusID <= Vint_ChequeStatusIDNew) && TRC.BankDepositeID == Vint_bankDeposit && BnkChq.ChequeNo == VStr_CheqNo)
                                             select new

                                             {

                                                 ID = BnkChq.ID,
                                                 TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                                 AddDateBank = BnkChq.AddDateBank,
                                                 AmountCheque = BnkChq.AmountCheque,
                                                 BankDrawnOnID = BnkChq.BankDrawnOnID,
                                                 ChequeNo = BnkChq.ChequeNo,
                                                 ChequeDueDate = BnkChq.ChequeDueDate,
                                                 DepositDate = TRC.DepositDate,
                                                 DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                                 CustID = BnkChq.CustID,
                                                 ChequeKind = BnkChq.ChequeKindID,
                                                 BankName = BNK.Name,
                                                 ParentID = TRC.Parent_ID,
                                                 ChequeStatusID = BnkChq.ChequeStatusID

                                             }).OrderBy(x => x.AddDateBank).ToList();

                        dataGridView2.DataSource = listBnkCheque;
                        if (dataGridView1.Rows.Count != 0)
                        {
                            dataGridView1.Rows.Clear();
                            if (dataGridView3.Rows.Count != 0)
                            {
                                //dataGridView3.Rows.Clear();
                                dataGridView3.DataSource = null;
                            }
                        }
                        if (dataGridView2.Rows.Count != 0)
                        {
                            //if (dataGridView1.Rows.Count == 0)
                            //{
                            //    AddColumnDtaGrd1();
                            //}
                            DgrCheqDepositAndAdded();
                            //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                            GrdBnkCheq();
                            GrdTotalValue();
                            dataGridView1.Columns["Ser"].Visible = false;


                        }
                    }
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }
                dataGridView1.Focus();
            }
        }

        private void dTpDayBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView2.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                }

                if (cmbBnkDeposit.SelectedValue != null)
                {
                    Vint_DepositBank = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                    DgrCheqAddedDayBank(int.Parse(cmbBnkDeposit.SelectedValue.ToString()), Convert.ToDateTime(dTpDayBank.Value.ToString("yyyy/MM/dd")));

                    if (dataGridView3.Rows.Count != 0)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.DataSource = null;
                        DgrCheqAndAdded();
                        DgrCheqDepositAndAdded();
                        //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                        GrdBnkCheq();
                        GrdTotalValue();
                        dataGridView1.Columns["Ser"].Visible = true;
                        LoadSerial();
                    }
                    txtBankAccPaperNo.Focus();
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }
                this.dtpDepositCashTableAdapter.FillByAddDateBank(this.depositCashDS.DtpDepositCash, dTpDayBank.Value.ToString("yyyy/MM/dd"), Vint_DepositBank );
                LoadSerial5();
                GrdTotalValueCash();
                txtBankAccPaperNo.Focus();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (txtAmount.Text != "" && txtAmount.Text != " ")
                    {
                        if (dataGridView1.Rows.Count != 0)
                        {
                            dataGridView1.Rows.Clear();
                            dataGridView3.DataSource = null;
                        }
                        //DgrCheqAddedAmountCh(Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd")), int.Parse(cmbBnkDeposit.SelectedValue.ToString()),decimal.Parse( txtAmount.Text) );
                        DgrChequesTrueDepositAmountCh(int.Parse(cmbBnkDeposit.SelectedValue.ToString()), decimal.Parse(txtAmount.Text));


                        if (dataGridView2.Rows.Count != 0)
                        {

                            DgrCheqAndAdded();
                            DgrCheqDepositAndAdded();

                            //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                            GrdBnkCheq();
                            GrdTotalValue();
                            dataGridView1.Columns["Ser"].Visible = false;


                        }
                        //txtBankAccPaperNo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }
                cbxCash.Checked = false;
                cbxCheqs.Checked = true;
                dataGridView1.Focus();
            }
        }

        private void dTPDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (dataGridView1.Rows.Count != 0)
                    { dataGridView1.Rows.Clear(); }

                    //DgrCheqAddedDueDateCh(int.Parse(cmbBnkDeposit.SelectedValue.ToString()), Convert.ToDateTime(dTPDueDate.Value.ToString("yyyy/MM/dd")));
                    //DgrChequesTrueDepositDueDateCh(int.Parse(cmbBnkDeposit.SelectedValue.ToString()), Convert.ToDateTime(dTPDueDate.Value.ToString("yyyy/MM/dd")));


                    if (dataGridView2.Rows.Count != 0 || dataGridView3.Rows.Count != 0)
                    {

                        DgrCheqAndAdded();
                        DgrCheqDepositAndAdded();
                        //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                        GrdBnkCheq();
                        GrdTotalValue();



                    }
                    simpleButton7.Focus();
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton7.Focus();
            }

        }

        private void txtTrCollectionAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (txtTrCollectionAmount.Text != "" && txtTrCollectionAmount.Text != " ")
                    {
                        if (dataGridView1.Rows.Count != 0)
                        {
                            dataGridView1.Rows.Clear();
                            dataGridView3.DataSource = null;
                        }

                        DgrChequesTrueDepositAmountTrColl(int.Parse(cmbBnkDeposit.SelectedValue.ToString()), decimal.Parse(txtTrCollectionAmount.Text));


                        if (dataGridView2.Rows.Count != 0)
                        {

                            DgrCheqAndAdded();
                            DgrCheqDepositAndAdded();

                            //************ضبط طريقة عرض بيانات الشيكات  Datagridview1
                            GrdBnkCheq();
                            GrdTotalValue();
                            dataGridView1.Columns["Ser"].Visible = false;


                        }
                        txtBankAccPaperNo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }

                dataGridView1.Focus();
            }
        }
        private void InsertTrueVal()
        {
            int i = 1;


            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                row.Cells["CheqTrue"].Value = true; i++;

            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbBnkDeposit.SelectedValue != null)
                {
                    if (textBox1.Text != "" && textBox1.Text != " ")
                    {
                        Decimal Vd_AmountCashSearch = Convert.ToDecimal(textBox1.Text);
                        Vint_DepositBank = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                        this.dtpDepositCashTableAdapter.FillByAmountBank(this.depositCashDS.DtpDepositCash, Vd_AmountCashSearch, Vint_DepositBank);
                        LoadSerial5();
                        //GrdTotalValueCash();
                        txtTotalCash.Text = "";
                        InsertTrueVal();
                        cbxCash.Checked = true;
                        cbxCheqs.Checked = false;
                        dataGridView5.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("اختر البنك المودع ");
                    cmbBnkDeposit.Focus();
                }

                dataGridView1.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbxCheqs_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCheqs.Checked == true)
            {
                cbxCash.Checked = false;
            }
        }

        private void cbxCash_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCash.Checked == true)
            {
                cbxCheqs.Checked = false;
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
