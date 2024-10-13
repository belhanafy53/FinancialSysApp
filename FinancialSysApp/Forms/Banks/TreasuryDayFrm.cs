using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared.Json;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using FinancialSysApp.Classes;
using FinancialSysApp.Forms.DocumentsForms;
using DevExpress.DataProcessing.InMemoryDataProcessor;

namespace FinancialSysApp.Forms.Banks
{
    public partial class TreasuryDayFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        //DateTime? vdate_CollectionDate = null;
        int? Vint_ChequeReceivedKindID = null;
        long Vlng_LastRowTreasuryCollection = 0;
        int Vint_BranchID = 0;
        long Vlng_TreasuryCollectionID = 0;
        public TreasuryDayFrm()
        {
            InitializeComponent();
        }

        private void TreasuryDayFrm_Load(object sender, EventArgs e)
        {
            AddColumnDtaGrd1();

            AddColumnDtaGrd2();

            GrdBnkCheq();
            GrdTRCollctionCheq();
            AddCheck.Checked = true;
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 86 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
                this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
                // TODO: This line of code loads data into the 'bankCheques.Tbl_Banks' table. You can move, or remove it, as needed.

                // TODO: This line of code loads data into the 'bankCheques.Tbl_Management' table. You can move, or remove it, as needed.
                int? UniteID = Program.GlbV_SysUnite_ID;
                var list = (from usr in FsDb.Tbl_User
                            join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                            join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID

                            where (us.SysUnites_ID == 13 && us.SysUnite_StatusID == 1)
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

                if (cmbBnkDeposit.Items.Count > 0)
                {
                    cmbBnkDeposit.SelectedIndex = -1;
                    cmbBnkDeposit.Text = "اختر البنك";
                }
                
                this.tbl_ManagementTableAdapter.FillBranch(this.bankCheques.Tbl_Management);
                //if (dataGridView2.Rows.Count == 0)
                //{ AddColumnDtaGrd2(); }

            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية استعلام عن يوميات الخزينه .. برجاء مراجعة مدير المنظومه");
                this.Close();
            }
            dateTimePickerF.Select();

            this.ActiveControl = dateTimePickerF;
            dateTimePickerF.Focus();
        }
        private void ClearDataMaster()
        {
            //txtRowID.Text = "";
            //txtBnkDepositID.Text = "";
            //txtBnkDeposit.Text = "";
            //chckBxBasicData.Checked = false;
            //txtAccountBnkID.Text = "";
            //cmbAccountBank.Text = "";
            //txtAccountBnk.Text = "";

            //txtCollectionNo.Text = "";
            //dTPCollection.Value = Convert.ToDateTime(DateTime.Now.ToString());

            //txtBranchID.Text = "";
            //txtBranch.Text = "";

            //txtRepresentiveID.Text = "";
            //txtRepresentive.Text = "";

            //txtTradeCollectionNO.Text = "";
            //txtReceiptNo.Text = "";
            //textBox1.Text = "";
            //textBox2.Text = "";
            //txtNotCheqAudit.Text = "";
            //cmbBnkDeposit.SelectedIndex = -1;
            //cmbBnkDeposit.Text = "";
            //simpleButton4.Text = "اضافة جهه جديده";
            //cmbBnkDeposit.SelectedText = "اختر البنك المودع ";
            //chckBxBasicData.Checked = false;
        }
        private void ClearDataDetails()
        {
            //txtAmount.Text = "";
            //txtRowChequeID.Text = "";

            //txtBankDrawnOn.Text = "";
            //txtBankDrawnOnID.Text = "";

            //txtCust.Text = "";
            //txtCustID.Text = "";

            //txtAllValueBefore.Text = "";
            //txtChequeNo.Text = "";

            //dTPDueDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
            //dataGridView3.DataSource = null;

        }
        private void AddColumnDtaGrd2()
        {
            // Create a new columns datadridview2
            DataGridViewTextBoxColumn newColumnID = new DataGridViewTextBoxColumn();

            // Set the properties of the new column
            newColumnID.HeaderText = "ID"; // Header text of the column
            newColumnID.Name = "ID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnID);

            DataGridViewTextBoxColumn newColumnBranchID = new DataGridViewTextBoxColumn();
            newColumnBranchID.Name = "BranchID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBranchID);

            DataGridViewTextBoxColumn newColumnBranchName = new DataGridViewTextBoxColumn();
            newColumnBranchName.Name = "BranchName"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBranchName);

            DataGridViewTextBoxColumn newColumnTradeCollectionNo = new DataGridViewTextBoxColumn();
            newColumnTradeCollectionNo.Name = "TradeCollectionNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnTradeCollectionNo);

            DataGridViewTextBoxColumn newColumnCollectionNo = new DataGridViewTextBoxColumn();
            newColumnCollectionNo.Name = "CollectionNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnCollectionNo);

            DataGridViewTextBoxColumn newColumnCollectionDate = new DataGridViewTextBoxColumn();
            newColumnCollectionDate.Name = "CollectionDate"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnCollectionDate);

            DataGridViewTextBoxColumn newColumnBankDepositeID = new DataGridViewTextBoxColumn();
            newColumnBankDepositeID.Name = "BankDepositeID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBankDepositeID);

            //*****************

            DataGridViewTextBoxColumn newColumnBankAccountID = new DataGridViewTextBoxColumn();
            newColumnBankAccountID.Name = "BankAccountID"; // Unique name of the column
            newColumnBankAccountID.Visible = false;
            dataGridView2.Columns.Add(newColumnBankAccountID);

            DataGridViewTextBoxColumn newColumnBankAccName = new DataGridViewTextBoxColumn();
            newColumnBankAccName.Name = "BankAccName"; // Unique name of the column
            newColumnBankAccName.Visible = false;
            dataGridView2.Columns.Add(newColumnBankAccName);

            DataGridViewTextBoxColumn newColumnName = new DataGridViewTextBoxColumn();
            newColumnName.Name = "Name"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnName);

            DataGridViewTextBoxColumn newColumnRepresentiveID = new DataGridViewTextBoxColumn();
            newColumnRepresentiveID.Name = "RepresentiveID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnRepresentiveID);

            DataGridViewTextBoxColumn newColumnReceiptNo = new DataGridViewTextBoxColumn();
            newColumnReceiptNo.Name = "ReceiptNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnReceiptNo);







        }
        private void TotalChequeCollection()
        {

            int i = 1;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Vlng_LastRowTreasuryCollection = int.Parse(row.Cells["ID"].Value.ToString());
                int VCheck_Khaz = int.Parse(row.Cells["BranchID"].Value.ToString());
                //******************

                if (VCheck_Khaz != 180)
                {
                    var query = (from ChBnk in FsDb.Tbl_BankCheques
                                 where ChBnk.TreasuryCollectionID == Vlng_LastRowTreasuryCollection
                                 group ChBnk by 1 into grp
                                 select new
                                 {
                                     rowCount = grp.Count(),
                                     rowSum = grp.Sum(x => x.AmountCheque)
                                 }).ToList();
                    if (query.Count != 0)

                    {
                        row.Cells["CountChq"].Value = query[0].rowCount;
                        row.Cells["TotalAmountChq"].Value = query[0].rowSum;
                        var listUpdateTotalAmount = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_LastRowTreasuryCollection).ToList();
                        listUpdateTotalAmount[0].TotalAmountCheqs = query[0].rowSum;
                        FsDb.SaveChanges();
                    }
                }
                else
                {

                    var query = (from ChBnk in FsDb.Tbl_BankCheques
                                 join Trc in FsDb.Tbl_TreasuryCollection on ChBnk.TreasuryCollectionID equals Trc.ID
                                 where Trc.Parent_ID == Vlng_LastRowTreasuryCollection
                                 group ChBnk by 1 into grp
                                 select new
                                 {
                                     rowCount = grp.Count(),
                                     rowSum = grp.Sum(x => x.AmountCheque)
                                 }).ToList();
                    if (query.Count != 0)

                    {
                        row.Cells["CountChq"].Value = query[0].rowCount;
                        row.Cells["TotalAmountChq"].Value = query[0].rowSum;
                        var listUpdateTotalAmount = FsDb.Tbl_TreasuryCollection.Where(x => x.Parent_ID == Vlng_LastRowTreasuryCollection).ToList();
                        listUpdateTotalAmount[0].TotalAmountCheqs = query[0].rowSum;
                        FsDb.SaveChanges();
                    }

                }
                //***************

            }
            txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                    select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                            select Convert.ToDouble(row.Cells[1].Value)).Count().ToString();
        }
        private void LoopPaintRowDueSateNotFYear()
        {
            FinancialYearDueDate FinancialYearDueDate = new FinancialYearDueDate();
            DateTime Vd_DueDateCheq = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime Vd_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            int Vint_ResultFYear = 0;
            int Vint_ResultToday = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                Vd_DueDateCheq = Convert.ToDateTime(row.Cells["ChequeDueDate"].Value.ToString());

                Vint_ResultFYear = FinancialYearDueDate.SelectFinancialYearDueDate(Vd_DueDateCheq);
                Vint_ResultToday = FinancialYearDueDate.SelectFinancialYearDueDate(Vd_Today);
                int Vint_ChequeStatusID = int.Parse(row.Cells["ChequeStatusID"].Value.ToString());
                if (Vint_ChequeStatusID == 4)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                if (Vint_ResultFYear > Vint_ResultToday)
                {
                    row.DefaultCellStyle.BackColor = Color.Black;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void Grd3TrCollectionBrDep(DateTime Vdt_DepositDateF, DateTime Vdt_DepositDate, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }

        private void Grd3TrCollectionBrDepAmountCheqs(decimal? Vdc_TotAmountTrCollection, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.TotalAmountCheqs == Vdc_TotAmountTrCollection)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionBrDepTradeNoCheqs(string VSt_TradeNoTrCollection, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.TradeCollectionNo == VSt_TradeNoTrCollection)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3CheqsNo(string Vst_CheqNO, int Vint_ReceivedKindID)
        {
            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (CheqBank.ChequeNo == Vst_CheqNO)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID
                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.ID == Vlng_TreasuryCollectionParntID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (CheqBank.ChequeNo == Vst_CheqNO)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void Grd3CheqsBankDrawnOn(DateTime Vdt_DepositDateF, DateTime Vdt_DepositDate, string Vst_BankdrawnID, int Vint_ReceivedKindID)
        {
            int Vint_bnkDrID = int.Parse(txtBankDrawnOnID.Text);
            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate && CheqBank.BankDrawnOnID == Vint_bnkDrID)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID
                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate && TRC.ID == Vlng_TreasuryCollectionParntID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate && CheqBank.BankDrawnOnID == Vint_bnkDrID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void Grd3CheqsAmount(string Vst_AmountF, string Vst_AmountT, int Vint_ReceivedKindID)
        {
            decimal Vd_AmountF = Convert.ToDecimal(txtAmountCheqF.Text);
            decimal Vd_AmountT = Convert.ToDecimal(txtAmountCheqT.Text);

            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (CheqBank.AmountCheque >= Vd_AmountF && CheqBank.AmountCheque <= Vd_AmountT)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID
                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.ID == Vlng_TreasuryCollectionParntID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (CheqBank.AmountCheque >= Vd_AmountF && CheqBank.AmountCheque <= Vd_AmountT)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void Grd3CheqsDueDate(DateTime Vdt_DueDateF, DateTime Vdt_DueDate, int Vint_ReceivedKindID,DateTime df , DateTime dt)
        {

            var listBnkCheque = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (CheqBank.ChequeDueDate >= Vdt_DueDateF && CheqBank.ChequeDueDate <= Vdt_DueDate && TRC.DepositDate >= df && TRC.DepositDate <=dt)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID,
                            IDChq = CheqBank.ID,
                            TreasuryCollectionID = CheqBank.TreasuryCollectionID,
                            AmountCheque = CheqBank.AmountCheque,
                            BankDrawnOnID = CheqBank.BankDrawnOnID,
                            ChequeNo = CheqBank.ChequeNo,
                            ChequeDueDate = CheqBank.ChequeDueDate,
                            DepositedByTrRepresntvID = CheqBank.DepositedByTrRepresntvID,
                            CustID = CheqBank.CustID,
                            AddDateBank = CheqBank.AddDateBank,
                            ChequeKind = CheqBank.ChequeKindID,
                            
                            BankName = BNK.Name,
                            
                            IsDisposed = CheqBank.IsDepositNo,
                            ParentID = TRC.Parent_ID,
                            DepositDate = TRC.DepositDate,
                            ChequeStatusID = CheqBank.ChequeStatusID,
                            TradeCollection = TRC.TradeCollectionNo,
                           

                            DepositBank = BNK.Name,
                            BranchNam = MNG.BrancheName

                        }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = listBnkCheque;

            for (int j = 0; j < (listBnkCheque.Count); j++)
            {

                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.Rows.Add(0, listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName,
                listBnkCheque[j].ParentID, true, listBnkCheque[j].DepositDate,
                listBnkCheque[j].ChequeStatusID,
                listBnkCheque[j].TradeCollection, listBnkCheque[j].CollectionNo, listBnkCheque[j].CollectionDate,
                listBnkCheque[j].DepositBank, listBnkCheque[j].BranchNam);
                dataGridView1.AllowUserToAddRows = false;
                LoadSerial();

                if (j == 0)
                {
                    textBox2.Text = (1).ToString();
                }
                { textBox2.Text = (j).ToString(); }


            }

        }
        private void Grd3CheqsDepositDate(DateTime Vdt_DepositDate, int Vint_ReceivedKindID)
        {
            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (TRC.DepositDate == Vdt_DepositDate)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID

                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.ID == Vlng_TreasuryCollectionParntID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (TRC.ChequeReceivedKindID == 0 && TRC.IsDepositNo == true && TRC.DepositDate == Vdt_DepositDate)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).OrderBy(x => x.BranchID).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void Grd3CheqsDepositDateBankDepAcc(DateTime Vdt_DepositDate, int Vint_BankDepID, int Vint_ReceivedKindID , int Vint_BnkAcc)
        {
            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (TRC.DepositDate == Vdt_DepositDate && TRC.BankDepositeID == Vint_BankDepID && TRC.BankAccounNoID == Vint_BnkAcc)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID

                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.ID == Vlng_TreasuryCollectionParntID && TRC.BankDepositeID == Vint_BankDepID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (TRC.ChequeReceivedKindID == 0 && TRC.IsDepositNo == true && TRC.DepositDate == Vdt_DepositDate && TRC.BankDepositeID == Vint_BankDepID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).OrderBy(x => x.BranchID).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void Grd3CheqsDepositDateBankDep(DateTime Vdt_DepositDate, int Vint_BankDepID, int Vint_ReceivedKindID)
        {
            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (TRC.DepositDate == Vdt_DepositDate && TRC.BankDepositeID == Vint_BankDepID)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID

                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.ID == Vlng_TreasuryCollectionParntID && TRC.BankDepositeID == Vint_BankDepID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (TRC.ChequeReceivedKindID == 0 && TRC.IsDepositNo == true && TRC.DepositDate == Vdt_DepositDate && TRC.BankDepositeID == Vint_BankDepID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).OrderBy(x => x.BranchID).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void Grd3TrCollectionBrDepTrCollNoCheqs(string VSt_CollNoTrCollection, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        //where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.CollectionNo == VSt_CollNoTrCollection)
                        where (TRC.CollectionNo == VSt_CollNoTrCollection)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionBrDepBaanks(DateTime Vdt_DepositDateF, DateTime Vdt_DepositDate, int Vint_BankID, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate && TRC.BankDepositeID == Vint_BankID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionBrDepBaanksAcc(DateTime Vdt_DepositDateF, DateTime Vdt_DepositDate, int Vint_BankID, int Vint_ReceivedKindID,int Vint_BankAcc)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate && TRC.BankDepositeID == Vint_BankID && TRC.BankAccounNoID == Vint_BankAcc)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionBrDepBaanksNullDate(int Vint_BankID, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.BankDepositeID == Vint_BankID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionbyCollectionID(long VLng_TreasCollectionID, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.ID == VLng_TreasCollectionID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionBrDepUsers(DateTime Vdt_DepositDateF, DateTime Vdt_DepositDate, int Vint_UserID, int Vint_ReceivedKindID)
        {

            var list = (from vGetDataUsr in FsDb.V_GetAllDataCollectionByUserCollectionDate

                        where (vGetDataUsr.CollectionDate >= Vdt_DepositDateF && vGetDataUsr.CollectionDate <= Vdt_DepositDate && vGetDataUsr.User_ID == Vint_UserID)
                        select new
                        {
                            ID = vGetDataUsr.ID,
                            BranchID = vGetDataUsr.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = vGetDataUsr.BrancheName,
                            TradeCollectionNo = vGetDataUsr.TradeCollectionNo,
                            CollectionNo = vGetDataUsr.CollectionNo,
                            CollectionDate = vGetDataUsr.CollectionDate,
                            BankDepositeID = vGetDataUsr.BankDepositeID,
                            BankAccountID = vGetDataUsr.BankAccounNoID,
                            BankAccountName = vGetDataUsr.Name,
                            Name = vGetDataUsr.Name,
                            RepresentiveID = vGetDataUsr.RepresentiveID,
                            ReceiptNo = vGetDataUsr.ReceiptNo,
                            Parent_ID = vGetDataUsr.Parent_ID,
                            ChequeReceivedKindID = vGetDataUsr.ChequeReceivedKindID


                        }).OrderBy(x => x.CollectionDate).ThenBy(x => x.BranchID).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionBrDepUsersNullDate(int Vint_UserID, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        join SecUser in FsEvDb.SecurityEvents on TRC.ID equals long.Parse(SecUser.TableRecordId)
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && SecUser.User_ID == Vint_UserID && SecUser.TableName == "Tbl_TreasuryCollection")
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }

        private void Grd3TrCollectionBrDepAmountCheqsNullDate(decimal? Vdc_TotAmountTrCollection, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.TotalAmountCheqs == Vdc_TotAmountTrCollection)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionBrDepBranch(DateTime Vdt_DepositDateF, DateTime Vdt_DepositDate, int? Vint_branchID, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate && TRC.BranchID == Vint_branchID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }

        private void Grd3TrCollectionBrDepBranchNullDate(int? Vint_branchID, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.BranchID == Vint_branchID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).OrderBy(x => x.BranchID).ToList();
            dataGridView4.DataSource = list;


        }
        //private void Grd3TrCollectionBrDepBranchExption(DateTime Vdt_DepositDateF,DateTime Vdt_DepositDate, int? Vint_branchID, List<T> T ,int Vint_ReceivedKindID)
        //{

        //    var list = (from TRC in FsDb.Tbl_TreasuryCollection
        //                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
        //                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
        //                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
        //                where (TRC.ChequeReceivedKindID == Vint_ReceivedKindID && TRC.CollectionDate >= Vdt_DepositDateF && TRC.CollectionDate <= Vdt_DepositDate && TRC.BranchID == Vint_branchID)
        //                select new
        //                {
        //                    ID = TRC.ID,
        //                    BranchID = TRC.BranchID,
        //                    //IsDepositNo = TRC.IsDepositNo,
        //                    BranchName = MNG.BrancheName,
        //                    TradeCollectionNo = TRC.TradeCollectionNo,
        //                    CollectionNo = TRC.CollectionNo,
        //                    CollectionDate = TRC.CollectionDate,
        //                    BankDepositeID = TRC.BankDepositeID,
        //                    BankAccountID = TRC.BankAccounNoID,
        //                    BankAccountName = BNK.Name,
        //                    Name = BNK.Name,
        //                    RepresentiveID = TRC.RepresentiveID,
        //                    ReceiptNo = TRC.ReceiptNo,
        //                    Parent_ID = TRC.Parent_ID,
        //                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

        //                }).OrderBy(x => x.BranchID).Take(200).ToList();
        //    dataGridView4.DataSource = list;


        //}
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

            //*****************

            DataGridViewTextBoxColumn newColumnDepositedByTrRepresntvID = new DataGridViewTextBoxColumn();
            newColumnDepositedByTrRepresntvID.Name = "DepositedByTrRepresntvID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositedByTrRepresntvID);

            DataGridViewTextBoxColumn newColumnCustID = new DataGridViewTextBoxColumn();
            newColumnCustID.Name = "CustID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnCustID);

            DataGridViewTextBoxColumn newColumnAddDateBank = new DataGridViewTextBoxColumn();
            newColumnAddDateBank.Name = "AddDateBank"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnAddDateBank);

            DataGridViewTextBoxColumn newColumnChequeKind = new DataGridViewTextBoxColumn();
            newColumnChequeKind.Name = "ChequeKind"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnChequeKind);

            DataGridViewTextBoxColumn newColumnBankName = new DataGridViewTextBoxColumn();
            newColumnBankName.Name = "BankName"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBankName);

            DataGridViewTextBoxColumn newColumnParentId = new DataGridViewTextBoxColumn();
            newColumnParentId.Name = "ParentID"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnParentId);

            DataGridViewCheckBoxColumn newColumnChqUpdate = new DataGridViewCheckBoxColumn();
            newColumnChqUpdate.Name = "ChqBxUpd"; // Unique name of the column
            newColumnChqUpdate.Visible = false;
            dataGridView1.Columns.Add(newColumnChqUpdate);

            DataGridViewTextBoxColumn newColumnDepositDate = new DataGridViewTextBoxColumn();
            newColumnDepositDate.Name = "DepositDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositDate);

            DataGridViewTextBoxColumn newColumnChequeStatusID = new DataGridViewTextBoxColumn();
            newColumnChequeStatusID.Name = "ChequeStatusID"; // Unique name of the column
            newColumnChequeStatusID.Visible = false;
            dataGridView1.Columns.Add(newColumnChequeStatusID);

            DataGridViewTextBoxColumn newColumnTradeCollection = new DataGridViewTextBoxColumn();
            newColumnTradeCollection.Name = "TradeCollection"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnTradeCollection);

            DataGridViewTextBoxColumn newColumnCollectionNo = new DataGridViewTextBoxColumn();
            newColumnCollectionNo.Name = "CollectionNo"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnCollectionNo);

            DataGridViewTextBoxColumn newColumnCollectionDate = new DataGridViewTextBoxColumn();
            newColumnCollectionDate.Name = "CollectionDate"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnCollectionDate);

            DataGridViewTextBoxColumn newColumnDepositBank = new DataGridViewTextBoxColumn();
            newColumnDepositBank.Name = "DepositBank"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnDepositBank);

            DataGridViewTextBoxColumn newColumnBranchNam = new DataGridViewTextBoxColumn();
            newColumnBranchNam.Name = "BranchNam"; // Unique name of the column
            dataGridView1.Columns.Add(newColumnBranchNam);

        }
        private void DgrTrCollectionDeposit()
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
                //**********************


                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;
                TotalChequeCollection();

                if (Vint_BranchID == 180)
                {
                    GetDataChequeBankKhazina();
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && BnkChq.TreasuryCollectionID == Vlng_TreasuryCollectionID)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,
                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate,

                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName


                                         }).OrderBy(x => x.ChequeDueDate).ToList();
                    //if (dataGridView1.Rows.Count == 0)
                    //{
                    //    AddColumnDtaGrd1();
                    //}
                    for (int j = 0; j < (listBnkCheque.Count); j++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                        listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName,
                        listBnkCheque[j].ParentID, true, listBnkCheque[j].DepositDate, listBnkCheque[j].ChequeStatusID, listBnkCheque[j].
                        TradeCollection, listBnkCheque[j].CollectionNo, listBnkCheque[j].CollectionDate, listBnkCheque[j].DepositBank, listBnkCheque[j].BranchNam

                        );
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();

                        if (j == 0)
                        {
                            textBox2.Text = (1).ToString();
                        }
                        { textBox2.Text = (j).ToString(); }


                    }
                }

                LoadSerial2();

            }


        }

        private void DgrCheqNo(string Vst_CheqNo)
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());


                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
                //**********************


                //dataGridView2.AllowUserToAddRows = true;
                //dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                //, Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                //dataGridView2.AllowUserToAddRows = false;
                //TotalChequeCollection();

                if (Vint_BranchID == 180)
                {
                    GetDataCheqNoKhazina(Vst_CheqNo);
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (BnkChq.ChequeNo == Vst_CheqNo)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,

                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate,

                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName

                                         }).Distinct().OrderBy(x => x.ChequeDueDate).ToList();
                    //if (dataGridView1.Rows.Count == 0)
                    //{
                    //    AddColumnDtaGrd1();
                    //}
                    for (int j = 0; j < (listBnkCheque.Count); j++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                        listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID,
                        listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName,
                        listBnkCheque[j].ParentID, true, listBnkCheque[j].DepositDate, listBnkCheque[i].ChequeStatusID,
                        listBnkCheque[j].TradeCollection, listBnkCheque[j].CollectionNo, listBnkCheque[j].CollectionDate,
                        listBnkCheque[j].DepositBank, listBnkCheque[j].BranchNam);
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();

                        if (j == 0)
                        {
                            textBox2.Text = (1).ToString();
                        }
                        { textBox2.Text = (j).ToString(); }


                    }
                }

                LoadSerial2();
            }


        }
        private void DgrCheqBnkDrwnID(string Vst_CheqBnkDrawnID)
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            int Vint_BankDrwnID = int.Parse(Vst_CheqBnkDrawnID);
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());


                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
                //**********************


                //dataGridView2.AllowUserToAddRows = true;
                //dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                //, Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                //dataGridView2.AllowUserToAddRows = false;
                //TotalChequeCollection();

                if (Vint_BranchID == 180)
                {
                    GetDataCheqNoKhazinaBnkDrawnOn(Vint_BankDrwnID, Vlng_TreasuryCollectionID);
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (BnkChq.BankDrawnOnID == Vint_BankDrwnID && TRC.ID == Vlng_TreasuryCollectionID)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,

                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate
                                             ,
                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName

                                         }).OrderBy(x => x.ChequeDueDate).ToList();
                    //if (dataGridView1.Rows.Count == 0)
                    //{
                    //    AddColumnDtaGrd1();
                    //}
                    for (int j = 0; j < (listBnkCheque.Count); j++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                        listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID,
                        listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind,
                        listBnkCheque[j].BankName, listBnkCheque[j].ParentID, true, listBnkCheque[j].DepositDate,
                        listBnkCheque[j].ChequeStatusID, listBnkCheque[j].TradeCollection, listBnkCheque[j].CollectionNo,
                        listBnkCheque[j].CollectionDate, listBnkCheque[j].DepositBank, listBnkCheque[j].BranchNam);
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();

                        if (j == 0)
                        {
                            textBox2.Text = (1).ToString();
                        }
                        { textBox2.Text = (j).ToString(); }


                    }
                }

                LoadSerial2();
            }


        }
        private void DgrCheqAmount(string Vst_CheqAmountF, string Vst_CheqAmountT)
        {

            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            decimal Vd_AmountF = Convert.ToDecimal(txtAmountCheqF.Text);
            decimal Vd_AmountT = Convert.ToDecimal(txtAmountCheqT.Text);
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());


                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
                //**********************


                //dataGridView2.AllowUserToAddRows = true;
                //dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                //, Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                //dataGridView2.AllowUserToAddRows = false;
                //TotalChequeCollection();

                if (Vint_BranchID == 180)
                {
                    GetDataCheqNoKhazinaAmount(txtAmountCheqF.Text, txtAmountCheqT.Text, Vlng_TreasuryCollectionID);
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (BnkChq.AmountCheque >= Vd_AmountF && BnkChq.AmountCheque <= Vd_AmountT && TRC.ID == Vlng_TreasuryCollectionID)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,
                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate,
                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName


                                         }).OrderBy(x => x.ChequeDueDate).ToList();
                    //if (dataGridView1.Rows.Count == 0)
                    //{
                    //    AddColumnDtaGrd1();
                    //}
                    for (int j = 0; j < (listBnkCheque.Count); j++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(
                        0,
                        listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID,
                        listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                        listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID,
                        listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName,
                        listBnkCheque[j].ParentID, true, listBnkCheque[j].DepositDate, listBnkCheque[j].ChequeStatusID,
                        listBnkCheque[j].TradeCollection, listBnkCheque[j].CollectionNo, listBnkCheque[j].CollectionDate,
                        listBnkCheque[j].DepositBank, listBnkCheque[j].TradeCollection, listBnkCheque[j].CollectionNo,
                        listBnkCheque[j].CollectionDate, listBnkCheque[j].DepositBank, listBnkCheque[j].BranchNam);
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();

                        if (j == 0)
                        {
                            textBox2.Text = (1).ToString();
                        }
                        { textBox2.Text = (j).ToString(); }


                    }
                }

                LoadSerial2();
            }


        }
        private void DgrCheqDueDate(DateTime Vdt_DueDateF, DateTime Vdt_DueDate)
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());


                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
                //**********************


                //dataGridView2.AllowUserToAddRows = true;
                //dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                //, Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                //dataGridView2.AllowUserToAddRows = false;
                //TotalChequeCollection();

                if (Vint_BranchID == 180)
                {
                    GetDataChequeBankKhazinaCheqDueDate(Vdt_DueDate, Vdt_DueDate, Vlng_TreasuryCollectionID);
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (BnkChq.ChequeDueDate >= Vdt_DueDateF && BnkChq.ChequeDueDate <= Vdt_DueDate && BnkChq.TreasuryCollectionID == Vlng_TreasuryCollectionID)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,
                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate,

                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName

                                         }).OrderBy(x => x.ChequeDueDate).ToList();
                    //if (dataGridView1.Rows.Count == 0)
                    //{
                    //    AddColumnDtaGrd1();
                    //}
                    for (int j = 0; j < (listBnkCheque.Count); j++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                        listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName,
                        listBnkCheque[j].ParentID, true, listBnkCheque[j].DepositDate,
                        listBnkCheque[j].ChequeStatusID,
                        listBnkCheque[j].TradeCollection, listBnkCheque[j].CollectionNo, listBnkCheque[j].CollectionDate,
                        listBnkCheque[j].DepositBank, listBnkCheque[j].BranchNam);
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();

                        if (j == 0)
                        {
                            textBox2.Text = (1).ToString();
                        }
                        { textBox2.Text = (j).ToString(); }


                    }
                }

                LoadSerial2();
            }


        }
        private void DgrCheqDeposit(DateTime Vdt_DepositDate)
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());


                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
                //**********************


                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;
                TotalChequeCollection();

                if (Vint_BranchID == 180)
                {
                    GetDataChequeBankKhazinaCheqDepositDate(Vdt_DepositDate, Vlng_TreasuryCollectionID);
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (TRC.DepositDate == Vdt_DepositDate && TRC.ID == Vlng_TreasuryCollectionID)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,
                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate,
                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName

                                         }).OrderBy(x => x.ChequeDueDate).ToList();

                    for (int j = 0; j < (listBnkCheque.Count); j++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque[j].IsDisposed, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                        listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName,
                        listBnkCheque[j].ParentID, true, listBnkCheque[j].DepositDate, listBnkCheque[j].ChequeStatusID,
                        listBnkCheque[j].TradeCollection, listBnkCheque[j].CollectionNo,
                        listBnkCheque[j].CollectionDate, listBnkCheque[j].DepositBank, listBnkCheque[j].BranchNam);
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();

                        if (j == 0)
                        {
                            textBox2.Text = (1).ToString();
                        }
                        { textBox2.Text = (j).ToString(); }


                    }
                }

                LoadSerial2();
            }


        }
        private void GetDataChequeBankKhazina()
        {
            Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (TRC.ChequeReceivedKindID == 1 && TRC.Parent_ID == Vlng_TreasuryCollectionID)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID,
                    listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind,
                    listBnkCheque[i].BankName, listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate,
                    listBnkCheque[i].ChequeStatusID,
                    listBnkCheque[i].TradeCollection, listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }


            //*************

            //txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            //txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
            //                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            //********
            //txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
            //                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
            //                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            //*************
            //************
            //}
            //else if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == false)
            //{
            //    //******************
            //    txtSpValueBeforeall.Text = "";
            //    txtSpTrCollection.Text = "";
            //    //***************

            //    //************
            //    Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
            //    var V_CountChq = (from Trc in FsDb.Tbl_TreasuryCollection
            //                      join BnkChq in FsDb.Tbl_BankCheques on Trc.ID equals BnkChq.TreasuryCollectionID
            //                      where (Trc.ChequeReceivedKindID == 1 && Trc.Parent_ID == Vlng_TreasuryCollectionID)
            //                      select new { Trc.ID, BnkChq.TreasuryCollectionID }).ToList();

            //    //************
            //    Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            //    if (V_CountChq.Count() != 0 && dataGridView1.RowCount > 0)
            //    {
            //        long VintTrCollectionCheq = 0;
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            if (dataGridView1.Rows[i].Cells[13].Value != null)
            //            {

            //                //MessageBox.Show(dataGridView1.Rows[i].Cells[13].Value.ToString());
            //                VintTrCollectionCheq = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
            //            }
            //            long Vlng_BnkChqID = long.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            //            if (VintTrCollectionCheq == Vlng_TreasuryCollectionID)
            //            {
            //                dataGridView1.Rows[i].Cells[1].Value = false;

            //            }

            //        }

            //    }
            //    //********
            //    txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
            //                                           where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                           select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //    txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
            //                              where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                              select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            //    //*************

            //    txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                        select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            //    txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
            //                            where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                            select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
            //    //************1

            //}
        }

        private void GetDataCheqNoKhazina(string Vst_CheqNo)
        {
            //Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (BnkChq.ChequeNo == Vst_CheqNo)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate,
                    listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID,
                    listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName,
                    listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID
                    , listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }



        }
        private void GetDataCheqNoKhazinaBnkDrawnOn(int Vint_CheqBnkDrwnOn, long Vlng_TreasuryCollectionID)
        {
            //Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (BnkChq.BankDrawnOnID == Vint_CheqBnkDrwnOn)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID,
                    listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank,
                    listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName, listBnkCheque[i].ParentID, true,
                    listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID, listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }



        }
        private void GetDataCheqNoKhazinaAmount(string Vst_CheqAmountF, string Vst_CheqAmountT, long Vlng_TreasuryCollectionID)
        {
            decimal Vd_AmountF = Convert.ToDecimal(txtAmountCheqF.Text);
            decimal Vd_AmountT = Convert.ToDecimal(txtAmountCheqT.Text);
            //Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (BnkChq.AmountCheque >= Vd_AmountF && BnkChq.AmountCheque <= Vd_AmountT)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName


                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID
                    , listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind,
                    listBnkCheque[i].BankName, listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID
                     , listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }



        }
        private void GetDataChequeBankKhazinaCheqNO(string Vst_CheqNo)
        {



            //if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == true)
            //{

            Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (TRC.ChequeReceivedKindID == 1 && TRC.Parent_ID == Vlng_TreasuryCollectionID && BnkChq.ChequeNo == Vst_CheqNo)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID,
                    listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName,
                    listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID
                     , listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }


            //*************

            //txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            //txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
            //                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            //********
            //txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
            //                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
            //                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            //*************
            //************
            //}
            //else if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == false)
            //{
            //    //******************
            //    txtSpValueBeforeall.Text = "";
            //    txtSpTrCollection.Text = "";
            //    //***************

            //    //************
            //    Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
            //    var V_CountChq = (from Trc in FsDb.Tbl_TreasuryCollection
            //                      join BnkChq in FsDb.Tbl_BankCheques on Trc.ID equals BnkChq.TreasuryCollectionID
            //                      where (Trc.ChequeReceivedKindID == 1 && Trc.Parent_ID == Vlng_TreasuryCollectionID)
            //                      select new { Trc.ID, BnkChq.TreasuryCollectionID }).ToList();

            //    //************
            //    Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            //    if (V_CountChq.Count() != 0 && dataGridView1.RowCount > 0)
            //    {
            //        long VintTrCollectionCheq = 0;
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            if (dataGridView1.Rows[i].Cells[13].Value != null)
            //            {

            //                //MessageBox.Show(dataGridView1.Rows[i].Cells[13].Value.ToString());
            //                VintTrCollectionCheq = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
            //            }
            //            long Vlng_BnkChqID = long.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
            //            if (VintTrCollectionCheq == Vlng_TreasuryCollectionID)
            //            {
            //                dataGridView1.Rows[i].Cells[1].Value = false;

            //            }

            //        }

            //    }
            //    //********
            //    txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
            //                                           where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                           select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //    txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
            //                              where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                              select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            //    //*************

            //    txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                                        select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            //    txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
            //                            where (Convert.ToBoolean(row.Cells[1].Value) == true)
            //                            select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
            //    //************1

            //}
        }
        private void GetDataChequeBankKhazinaCheqDueDate(DateTime Vdt_DueDateF, DateTime Vdt_DueDate, long Vlng_TreasuryCollectionID)
        {



            //if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == true)
            //{

            //Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (TRC.ChequeReceivedKindID == 1 && TRC.Parent_ID == Vlng_TreasuryCollectionID && BnkChq.ChequeDueDate >= Vdt_DueDateF && BnkChq.ChequeDueDate <= Vdt_DueDate)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID,
                    listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind,
                    listBnkCheque[i].BankName, listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID
                     , listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }



        }
        private void GetDataChequeBankKhazinaCheqDepositDate(DateTime Vdt_DepositDate, long Vlng_TreasuryCollectionID)
        {



            //if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == true)
            //{

            //Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (TRC.ChequeReceivedKindID == 1 && TRC.Parent_ID == Vlng_TreasuryCollectionID && TRC.DepositDate == Vdt_DepositDate)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID,
                    listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName,
                    listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID
                     , listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }



        }
        private void GrdBnkCheq()
        {
            try
            {

                int Vint_DgCount = dataGridView1.RowCount;
                if (Vint_DgCount != 0)
                {
                    txtAllValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                         select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                    txtCheqAllCount.Text = (from DataGridViewRow row in dataGridView1.Rows
                                            select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                }
            }
            catch
            { }

            dataGridView1.Columns["TreasuryCollectionID"].Visible = false;
            dataGridView1.Columns["AmountCheque"].Visible = true;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.Columns["BankDrawnOnID"].Visible = false;
            dataGridView1.Columns["ChequeNo"].Visible = true;


            dataGridView1.Columns["ChequeDueDate"].Visible = true;
            dataGridView1.Columns["DepositedByTrRepresntvID"].Visible = false;

            dataGridView1.Columns["CustID"].Visible = false;
            dataGridView1.Columns["AddDateBank"].Visible = false;

            dataGridView1.Columns["ChequeKind"].Visible = false;

            //dataGridView1.Columns["CustomerName"].Visible = false;
            dataGridView1.Columns["BankName"].Visible = true;
            dataGridView1.Columns["BankName"].Width = 200;
            //dataGridView1.Columns["Tbl_ChequeKind"].Visible = true;
            //dataGridView1.Columns["Tbl_TreasuryCollection"].Visible = true;

            dataGridView1.Columns["AmountCheque"].HeaderText = "مبلغ الشيك";
            dataGridView1.Columns["AmountCheque"].Width = 120;

            dataGridView1.Columns["ChequeDueDate"].HeaderText = "تاريخ الشيك";
            dataGridView1.Columns["ChequeDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["ChequeNo"].HeaderText = "رقم الشيك";

            dataGridView1.Columns["ParentID"].Visible = false;
            dataGridView1.Columns["ParentID"].HeaderText = "الحافظه الام";

            dataGridView1.Columns["BankName"].HeaderText = "البنك المسحوب عليه";
            dataGridView1.Columns["DepositDate"].HeaderText = "تاريخ الايداع";
            dataGridView1.Columns["DepositDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["CollectionNo"].HeaderText = "رقم  الحافظه";
            dataGridView1.Columns["CollectionNo"].Width = 200;
            dataGridView1.Columns["TradeCollection"].HeaderText = "رقم الحافظه التجاري";
            dataGridView1.Columns["CollectionDate"].HeaderText = "تاريخ الحافظه";
            dataGridView1.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView1.Columns["DepositBank"].HeaderText = "البنك المودع";
            dataGridView1.Columns["DepositBank"].Width = 200;

            dataGridView1.Columns["Branchnam"].HeaderText = "الفرع";
            dataGridView1.Columns["Branchnam"].Width = 200;


        }

        private void GrdTRCollctionCheq()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["BranchID"].Visible = false;
                dataGridView2.Columns["BankDepositeID"].Visible = false;
                dataGridView2.Columns["RepresentiveID"].Visible = false;
                //dataGridView2.Columns["BankAccName"].Visible = false;
                dataGridView2.Columns["BankAccountID"].Visible = false;
                dataGridView2.Columns["ReceiptNo"].Visible = false;
                //dataGridView2.Columns["ChqBxUpd"].Visible = false;

                dataGridView2.Columns["Name"].Width = 250;
                dataGridView2.Columns["Name"].HeaderText = "البنك المودع";

                dataGridView2.Columns["BranchName"].HeaderText = "الفرع / الجهه";
                dataGridView2.Columns["BranchName"].Width = 120;
                dataGridView2.Columns["TradeCollectionNo"].HeaderText = "رقم الحافظه بالتجاري";
                dataGridView2.Columns["CollectionNo"].HeaderText = "رقم الحافظه";
                dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ الحافظه";
                dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
                //dataGridView2.Columns["CollectionDate"].
                dataGridView2.Columns["CollectionNo"].Width = 150;
                dataGridView2.Columns["CountChq"].Width = 50;
                dataGridView2.Columns["TotalAmountChq"].Width = 150;
                dataGridView2.Columns["TradeCollectionNo"].Width = 60;
                //dataGridView2.Columns["IsDepositNo"].HeaderText = "تم / لم يتم الايداع";
            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["BranchID"].Visible = false;
                dataGridView2.Columns["BankDepositeID"].Visible = false;
                dataGridView2.Columns["RepresentiveID"].Visible = false;

                dataGridView2.Columns["BankAccountID"].Visible = false;
                dataGridView2.Columns["ReceiptNo"].Visible = false;
                dataGridView2.Columns["TradeCollectionNo"].Visible = false;
                dataGridView2.Columns["BranchName"].HeaderText = " الجهه";
                dataGridView2.Columns["BranchName"].Width = 120;
                dataGridView2.Columns["CollectionNo"].HeaderText = "رقم  المستند";
                dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ المستند";
                dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";


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
        private void LoadSerial2()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                //if (txtCheqAllCount.Text != "")
                //{ dataGridView1.Rows.Clear(); }
                //if (dataGridView2.Rows.Count != 0)
                //{
                //    dataGridView2.Rows.Clear();
                //}
                //splashScreenManager1.ShowWaitForm();
                //splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                ////******************استدعاء حوافظ الفروع في التاريح المختار
                //Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);

                ////***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                //if (dataGridView4.Rows.Count != 0)
                //{
                //    DgrTrCollectionDeposit();
                //    GrdBnkCheq();
                //    TotalChequeCollection();
                //    GrdTRCollctionCheq();
                //}

                //splashScreenManager1.CloseWaitForm();

                AddCheck.Checked = true;
            }
        }

        private void txtAmountCheq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCheqAllCount.Text != "")
                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && TAmountCheck.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3TrCollectionBrDepAmountCheqs(Convert.ToDecimal(txtAmountCheq.Text), 0);
                    //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                    }
                }
                else if (AddCheck.Checked == false && TAmountCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }







            }
        }

        private void TAmountCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TAmountCheck.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                cbxRefundCheq.Checked = false;
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //*************
                //TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
                TAmountCheck.Focus();

            }
            else
            {
                Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                txtAmountCheq.Text = "";
            }

        }

        private void BranchCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (BranchCheck.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                cbxRefundCheq.Checked = false;
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                //BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                //BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
                checkedComboBoxEdit1.Focus();
            }
            else
            {
                Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                txtBranch.Text = "";
            }
        }

        private void ExpCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ExpCheck.Checked == true)
            {
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                //ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
            }
            else
            {
                Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                checkedComboBoxEdit1.DeselectAll();
            }
        }

        private void BankCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (BankCheck.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                cbxRefundCheq.Checked = false;
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                //BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                //BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
                if (cmbBnkDeposit.Items.Count > 0)
                {
                    cmbBnkDeposit.SelectedIndex = -1;
                    cmbBnkDeposit.Text = "اختر البنك";
                }
                cmbBnkDeposit.Focus();
            }
            else
            {
                Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                cmbBnkDeposit.SelectedIndex = -1;
                cmbBnkDeposit.Text = "اختر البنك";
            }
        }

        private void UserCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (UserCheck.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                cbxRefundCheq.Checked = false;
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                //UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                //UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
                cmbUser.Focus();
            }
            else
            {
                Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                cmbUser.SelectedIndex = -1;
                cmbUser.Text = "اختر المستخدم";
            }
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                if (Vint_ChequeReceivedKindID == 0)
                {
                    Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();

                        Vint_BranchID = int.Parse(Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString());
                        txtBranchID.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                        if (txtCheqAllCount.Text != "")
                        { dataGridView1.Rows.Clear(); }
                        if (dataGridView2.Rows.Count != 0)
                        {
                            dataGridView2.Rows.Clear();
                        }
                        if (AddCheck.Checked == true && BranchCheck.Checked == true)
                        {
                            //******************استدعاء حوافظ الفروع في التاريح المختار
                            Grd3TrCollectionBrDepBranch(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), Vint_BranchID, 0);
                        }
                        else if (AddCheck.Checked == false && BranchCheck.Checked == true)
                        {

                            Grd3TrCollectionBrDepBranchNullDate(Vint_BranchID, 0);
                        }
                        //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                        if (dataGridView4.Rows.Count != 0)
                        {
                            DgrTrCollectionDeposit();
                            GrdBnkCheq();
                            TotalChequeCollection();
                            GrdTRCollctionCheq();
                        }
                    }
                }
            }
        }

        private void checkedComboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (AddCheck.Checked == true && BranchCheck.Checked == true)
            {
                if (txtCheqAllCount.Text != "")
                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }

                var selecteditems = checkedComboBoxEdit1.Properties.GetItems().GetCheckedValues();
                //******************استدعاء حوافظ الفروع في التاريح المختار

                foreach (var value in selecteditems)
                {
                    Vint_BranchID = int.Parse(value.ToString());
                    Grd3TrCollectionBrDepBranch(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), Vint_BranchID, 0);
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }

            }
            else
            {
                //Grd3TrCollectionBrDepBranch(null, Vint_BranchID, 0);
                checkedComboBoxEdit1.DeselectAll();


            }
            //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار

        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                if (Vint_ChequeReceivedKindID == 0)
                {
                    Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                    t.ShowDialog();
                    if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                    {
                        txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();

                        Vint_BranchID = int.Parse(Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString());
                        txtBranchID.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();
                        if (txtCheqAllCount.Text != "")
                        { dataGridView1.Rows.Clear(); }
                        if (dataGridView2.Rows.Count != 0)
                        {
                            dataGridView2.Rows.Clear();
                        }
                        if (AddCheck.Checked == true && BranchCheck.Checked == true)
                        {
                            //******************استدعاء حوافظ الفروع في التاريح المختار
                            Grd3TrCollectionBrDepBranch(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), Vint_BranchID, 0);
                        }
                        else if (AddCheck.Checked == false && BranchCheck.Checked == true)
                        {

                            //Grd3TrCollectionBrDepBranchNullDate(Vint_BranchID, 0);
                        }
                        //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                        if (dataGridView4.Rows.Count != 0)
                        {
                            DgrTrCollectionDeposit();
                            GrdBnkCheq();
                            TotalChequeCollection();
                            GrdTRCollctionCheq();
                        }
                    }
                }
            }
        }

        private void cmbBnkDeposit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_BankID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());

            if (txtCheqAllCount.Text != "")
            { dataGridView1.Rows.Clear(); }
            if (dataGridView2.Rows.Count != 0)
            {
                dataGridView2.Rows.Clear();
            }
            if (AddCheck.Checked == true && BankCheck.Checked == true)
            {
                //******************استدعاء حوافظ الفروع في التاريح المختار
                Grd3TrCollectionBrDepBaanks(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), Vint_BankID, 0);
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                if (dataGridView4.Rows.Count != 0)
                {
                    DgrTrCollectionDeposit();
                    GrdBnkCheq();
                    TotalChequeCollection();
                    GrdTRCollctionCheq();
                    LoopPaintRowDueSateNotFYear();
                }
                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankID).ToList();
                comboBox4.DataSource = listAccBank;
                comboBox4.DisplayMember = "AccountBankNo";
                comboBox4.ValueMember = "ID";
                int Vin_countItem = comboBox4.Items.Count;
                if (comboBox4.Items.Count > 1)
                {
                    comboBox4.SelectedIndex = -1;
                    comboBox4.Text = "اختر رقم الحساب";
                    comboBox4.Select();
                    this.ActiveControl = comboBox4;
                    comboBox4.Focus();
                }
            }
            else if (AddCheck.Checked == false && BankCheck.Checked == true)
            {
                //Grd3TrCollectionBrDepBaanksNullDate(Vint_BankID, 0);
            }

        }

        private void cmbUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Vint_userID = int.Parse(cmbUser.SelectedValue.ToString());

            if (txtCheqAllCount.Text != "")
            { dataGridView1.Rows.Clear(); }
            if (dataGridView2.Rows.Count != 0)
            {
                dataGridView2.Rows.Clear();
            }
            dataGridView4.DataSource = null;
            if (AddCheck.Checked == true && UserCheck.Checked == true)
            {
                //******************استدعاء حوافظ الفروع في التاريح المختار
                Grd3TrCollectionBrDepUsers(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), Vint_userID, 0);
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                if (dataGridView4.Rows.Count != 0)
                {
                    DgrTrCollectionDeposit();
                    GrdBnkCheq();
                    TotalChequeCollection();
                    GrdTRCollctionCheq();
                    LoopPaintRowDueSateNotFYear();
                }
            }
            else if (AddCheck.Checked == false && UserCheck.Checked == true)
            {
                //Grd3TrCollectionBrDepUsersNullDate(Vint_userID, 0);
            }

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Checked = false;
            BranchCheck.Checked = false;
            UserCheck.Checked = false;
            ExpCheck.Checked = false;
            BankCheck.Checked = false;
            CollNoCheck.Checked = false;
            TradCollNoCheck.Checked = false;
            //*************
            TAmountCheck.Checked = false;
            BranchCheck.Checked = false;
            ExpCheck.Checked = false;
            BankCheck.Checked = false;
            UserCheck.Checked = false;
            TradCollNoCheck.Checked = false;
            DueDateCheck.Checked = false;
            BankdrawnOnCheck.Checked = false;
            CheqNoCheck.Checked = false;
            DataGridViewRow currentRow = dataGridView2.CurrentRow;
            if (currentRow != null)
            {
                // Assuming you want to get the value of the  cell 3 in the current row
                object cellValue = currentRow.Cells[4].Value;

                if (cellValue != null)
                {

                    Vlng_LastRowTreasuryCollection = long.Parse(cellValue.ToString());

                    Grd3TrCollectionbyCollectionID(Vlng_LastRowTreasuryCollection, 0);
                    if (txtCheqAllCount.Text != "")
                    { dataGridView1.Rows.Clear(); }
                    if (dataGridView2.Rows.Count != 0)
                    {
                        dataGridView2.Rows.Clear();
                    }
                    //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                    }
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TradCollNoCheck.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                //TradCollNoCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                //TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
                textBox3.Focus();

            }
            else
            {
                Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                textBox3.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CollNoCheck.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                cbxRefundCheq.Checked = false;
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                //CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
                textBox4.Focus();
            }
            else
            {
                Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                textBox4.Text = "";
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && TradCollNoCheck.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3TrCollectionBrDepTradeNoCheqs(textBox3.Text, 0);
                    //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && TradCollNoCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }

            }
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && CollNoCheck.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3TrCollectionBrDepTrCollNoCheqs(textBox4.Text, 0);
                    //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && CollNoCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }

            }
        }

        private void dateTimePickerF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void CheqAmountCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CheqAmountCheck.Checked == true)
            {
                checkBox1.Checked = false;
                //chckDepositDate.Checked = true;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                //CheqAmountCheck.Checked = false;
                CheqNoCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                txtAmountCheqF.Focus();
            }
            else
            {
                txtAmountCheqF.Text = "";
                txtAmountCheqT.Text = "";
            }
        }

        private void DueDateCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DueDateCheck.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                CheqAmountCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqAmountCheck.Checked = false;
                CheqNoCheck.Checked = false;
                dtpDueDate1.Focus();
            }
            else
            {
                dtpDueDate.Value = Convert.ToDateTime(DateTime.Today.ToString());
            }
        }

        private void CheqNoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CheqNoCheck.Checked == true)
            {
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                CheqAmountCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                BankdrawnOnCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                //CheqNoCheck.Checked = false;
                txtCheqNo.Focus();
            }
            else
            {
                txtCheqNo.Text = "";
            }


        }

        private void BankdrawnOnCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (BankdrawnOnCheck.Checked == true)
            {
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                CheqAmountCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                //BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;
                txtBankDrawnOn.Focus();
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                txtBankDrawnOn.Text = "";
            }
        }

        private void txtCheqNo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && CheqNoCheck.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3CheqsNo(txtCheqNo.Text, 0);
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrCheqNo(txtCheqNo.Text);
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && CheqNoCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار

                splashScreenManager1.CloseWaitForm();
            }
        }

        private void dtpDueDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //dataGridView4.Rows.Clear();
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && DueDateCheck.Checked == true)
                {
                    DateTime Vdt_DepositDateF = Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd"));
                    DateTime Vdt_DepositDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                    DateTime Vdt_DueDateF = Convert.ToDateTime(dtpDueDate1.Value.ToString("yyyy/MM/dd"));
                    DateTime Vdt_DueDate = Convert.ToDateTime(dtpDueDate.Value.ToString("yyyy/MM/dd"));
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3CheqsDueDate(Vdt_DueDateF, Vdt_DueDate, 0, Vdt_DepositDateF, Vdt_DepositDate);
                    if (dataGridView4.Rows.Count != 0)
                    {
                        Vdt_DueDate = Convert.ToDateTime(dtpDueDate.Value.ToString("yyyy/MM/dd"));

                        //DgrCheqDueDate(Vdt_DueDateF, Vdt_DueDate);
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && DueDateCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                ////***********Test CheqNoQnb
                //string Vst_CheckNo = "";
                //string result = string.Empty;
                //for (int i = 0; i < dataGridView1.Rows.Count;i++ )
                //{
                //    Vst_CheckNo = dataGridView1.Rows[i].Cells[6].Value.ToString();

                //    result = CalcCheqNoQNBCs.CheqNoBank(Vst_CheckNo);

                //}
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void txtAmountCheqF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmountCheqT.Focus();
            }

        }

        private void txtAmountCheqT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && CheqAmountCheck.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3CheqsAmount(txtAmountCheqF.Text, txtAmountCheqT.Text, 0);
                    //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrCheqAmount(txtAmountCheqF.Text, txtAmountCheqT.Text);
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && CheqAmountCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }

                splashScreenManager1.CloseWaitForm();
            }
        }

        private void txtBankDrawnOn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && BankdrawnOnCheck.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3CheqsBankDrawnOn(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), txtBankDrawnOnID.Text, 0);
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrCheqBnkDrwnID(txtBankDrawnOnID.Text);
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && BankdrawnOnCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }


                splashScreenManager1.CloseWaitForm();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindBankParentFrm t = new Forms.BasicCodeForms.FindBankParentFrm();
                t.ShowDialog();

                if (t.txtBankId != null)
                {
                    txtBankDrawnOn.Text = t.txtSelected.Text;
                    txtBankDrawnOnID.Text = t.txtBankId.Text;


                }
                //txtChequeNo.Focus();
            }
        }

        private void chckDepositDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chckDepositDate.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                //checkBox1.Checked = false;
                //chckDepositDate.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                //TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;

            }
            else
            {
                //Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                //textBox3.Text = "";
            }
        }

        private void dtpDepositDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //dataGridView4.Rows.Clear();
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && chckDepositDate.Checked == true)
                {
                    DateTime Vdt_DepositDate = Convert.ToDateTime(dtpDepositDate.Value.ToString("yyyy/MM/dd"));
                    //****************** 
                    Grd3CheqsDepositDate(Vdt_DepositDate, 0);
                    if (dataGridView4.Rows.Count != 0)
                    {
                        //Vdt_DepositDate = Convert.ToDateTime(dtpDepositDate.Value.ToString("yyyy/MM/dd"));

                        DgrCheqDeposit(Vdt_DepositDate);
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                    }
                }
                else if (AddCheck.Checked == false && DueDateCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار

                splashScreenManager1.CloseWaitForm();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Forms.DocumentsForms.CheqScanFrm t = new Forms.DocumentsForms.CheqScanFrm();


            if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                long Vint_TrCollectionID = 0;
                //**************بيانات الخافظه 
                if (dataGridView1.CurrentRow.Cells["BranchNam"].Value != null)
                { t.txtbranch.Text = this.dataGridView1.CurrentRow.Cells["BranchNam"].Value.ToString(); }
                if (dataGridView1.CurrentRow.Cells[18].Value != null)
                {
                    t.txtCollectionNo.Text = this.dataGridView1.CurrentRow.Cells[18].Value.ToString();
                }

                Vint_TrCollectionID = int.Parse(this.dataGridView1.CurrentRow.Cells[3].Value.ToString());

                var ListTrColl = (from Tr in FsDb.Tbl_TreasuryCollection
                                  join bnk in FsDb.Tbl_Banks on Tr.BankDepositeID equals bnk.ID
                                  join bnkAcc in FsDb.Tbl_AccountsBank on Tr.BankAccounNoID equals bnkAcc.ID
                                  join bnkAccType in FsDb.Tbl_AccountsBankPurpose on bnkAcc.AccPurposeID equals bnkAccType.ID
                                  where (Tr.ID == Vint_TrCollectionID)
                                  select new
                                  {
                                      Id = Tr.ID,
                                      BankName = bnk.Name,
                                      BankAcc = bnkAcc.AccountBankNo,
                                      bnkAccTypeName = bnkAccType.Name

                                  }).ToList();

                //t.txtBankD.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();
                if (ListTrColl.Count > 0)
                {
                    t.txtBankD.Text = ListTrColl[0].BankName;
                    ////t.txtBankAcc.Text = this.comboBox1.Text.ToString();
                    t.txtBankAcc.Text = ListTrColl[0].BankAcc;
                    ////t.txtpurpose.Text = this.comboBox2.Text.ToString();
                    t.txtpurpose.Text = ListTrColl[0].bnkAccTypeName;
                }
                ////*************بيانات الشيك
                t.txtRowChequeID.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                t.txtChequeNoScan.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                t.txtAmountScan.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                t.txtBankDrawnOnScan.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();
                t.dTPDueDateScan.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[7].Value.ToString());


                ////***********************
                long Vint_ID = long.Parse(this.dataGridView1.CurrentRow.Cells[2].Value.ToString());
                int Vint_IdItem = 136;

                //int Vint_Parent_ID = 6;

                var listItem = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);

                ////string Vstr_Name = "الوارده";

                ////*********************عرض صورة الشيك
                t.pictureBox1.ImageLocation = null;
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

                }
                catch
                {

                }
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
                MessageBox.Show("من فضلك اختر الشيك المراد عرض صورته اولا");
            }
        }



        private void dtpDueDate1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDueDate.Focus();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chckDepositDate.Checked == true)
            {
                cbxRefundCheq.Checked = false;
                checkBox3.Checked = false;
                cbxRefundCheq.Checked = false;
                //chckDepositDate.Checked = false;
                //checkBox1.Checked = false;
                CheqAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                //TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                CheqNoCheck.Checked = false;

            }
            else
            {
                //Grd3TrCollectionBrDep(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), 0);
                //textBox3.Text = "";
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //dataGridView4.Rows.Clear();
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
            if (txtCheqAllCount.Text != "")

            { dataGridView1.Rows.Clear(); }
            if (dataGridView2.Rows.Count != 0)
            {
                dataGridView2.Rows.Clear();
            }
            if (AddCheck.Checked == true && chckDepositDate.Checked == true)
            {
                DateTime Vdt_DepositDate = Convert.ToDateTime(dtpDepositDate.Value.ToString("yyyy/MM/dd"));
                int Vint_BankID = int.Parse(comboBox1.SelectedValue.ToString());
                //****************** 
                Grd3CheqsDepositDateBankDep(Vdt_DepositDate, Vint_BankID, 0);
                if (dataGridView4.Rows.Count != 0)
                {
                    //Vdt_DepositDate = Convert.ToDateTime(dtpDepositDate.Value.ToString("yyyy/MM/dd"));

                    DgrCheqDeposit(Vdt_DepositDate);
                    GrdBnkCheq();
                    TotalChequeCollection();
                    GrdTRCollctionCheq();
                }
                var listAccBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankID).ToList();
                comboBox4.DataSource = listAccBank;
                comboBox4.DisplayMember = "AccountBankNo";
                comboBox4.ValueMember = "ID";
                int Vin_countItem = comboBox4.Items.Count;
                if (comboBox4.Items.Count > 1)
                {
                    comboBox4.SelectedIndex = -1;
                    comboBox4.Text = "اختر رقم الحساب";
                    comboBox4.Select();
                    this.ActiveControl = comboBox4;
                    comboBox4.Focus();
                }
            }
            else if (AddCheck.Checked == false && DueDateCheck.Checked == true)
            {
                //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
            }
            //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار

            splashScreenManager1.CloseWaitForm();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && TradCollNoCheck.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    Grd3TrCollectionBrDepTradeNoCheqs(textBox3.Text, 0);
                    //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && TradCollNoCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }

            }
        }
        private void GrdCheqsRefund(DateTime d1, DateTime d2)
        {
            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (CheqBank.ChequeStatusDate >= d1 && CheqBank.ChequeStatusDate <= d2 && CheqBank.ChequeStatusID == 4)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID
                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.ID == Vlng_TreasuryCollectionParntID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (CheqBank.ChequeStatusDate >= d1 && CheqBank.ChequeStatusDate <= d2 && CheqBank.ChequeStatusID == 4)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void GrdCheqsDrawn(DateTime d1, DateTime d2)
        {
            var listCh = (from TRC in FsDb.Tbl_TreasuryCollection

                          join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                          where (CheqBank.ChequeStatusDate >= d1 && CheqBank.ChequeStatusDate <= d2 && CheqBank.ChequeStatusID == 5)
                          select new
                          {
                              ID = CheqBank,
                              TreasuryCollectionID = TRC.ID,
                              BranchID = TRC.BranchID,
                              ParentID = TRC.Parent_ID
                          }).ToList();
            if (listCh.Count != 0)
            {
                if (listCh[0].ParentID != null)
                {
                    long Vlng_TreasuryCollectionParntID = long.Parse(listCh[0].ParentID.ToString());
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID

                                where (TRC.ID == Vlng_TreasuryCollectionParntID)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;

                }
                else
                {
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                                where (CheqBank.ChequeStatusDate >= d1 && CheqBank.ChequeStatusDate <= d2 && CheqBank.ChequeStatusID == 5)
                                select new
                                {
                                    ID = TRC.ID,
                                    BranchID = TRC.BranchID,
                                    //IsDepositNo = TRC.IsDepositNo,
                                    BranchName = MNG.BrancheName,
                                    TradeCollectionNo = TRC.TradeCollectionNo,
                                    CollectionNo = TRC.CollectionNo,
                                    CollectionDate = TRC.CollectionDate,
                                    BankDepositeID = TRC.BankDepositeID,
                                    BankAccountID = TRC.BankAccounNoID,
                                    BankAccountName = BNK.Name,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    ReceiptNo = TRC.ReceiptNo,
                                    Parent_ID = TRC.Parent_ID,
                                    ChequeReceivedKindID = TRC.ChequeReceivedKindID

                                }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
                    dataGridView4.DataSource = list;
                }
            }
        }
        private void DgrCheqRefund(DateTime d1, DateTime d2)
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());


                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }
               

                if (Vint_BranchID == 180)
                {
                    GetDataCheqNoKhazinaRef(d1, d2);
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (BnkChq.ChequeStatusDate >= d1 && BnkChq.ChequeStatusDate <= d2 && BnkChq.ChequeStatusID == 4)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,

                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate,

                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName

                                         }).Distinct().OrderBy(x => x.ChequeDueDate).ToList();
                   
                    //for (int j = 0; j < (listBnkCheque.Count); j++)
                    //{

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, listBnkCheque[i].IsDisposed, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                        listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID,
                        listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName,
                        listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID,
                        listBnkCheque[i].TradeCollection, listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate,
                        listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                        dataGridView1.AllowUserToAddRows = false;
                        LoadSerial();

                        if (i == 0)
                        {
                            textBox2.Text = (1).ToString();
                        }
                        { textBox2.Text = (i).ToString(); }


                    //}
                }

                LoadSerial2();
            }


        }
        private void GetDataCheqNoKhazinaRef(DateTime d1, DateTime d2)
        {
            //Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (BnkChq.ChequeStatusDate >= d1 && BnkChq.ChequeStatusDate <= d2 && BnkChq.ChequeStatusID == 4)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate,
                    listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID,
                    listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName,
                    listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID
                    , listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }



        }
        private void cbxRefundCheq_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRefundCheq.Checked == true)
            {
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                CheqAmountCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                checkBox3.Checked = false;

                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && cbxRefundCheq.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    GrdCheqsRefund(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy-MM-dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrCheqRefund(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy-MM-dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && CheqNoCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار

                splashScreenManager1.CloseWaitForm();
            }
        }

        private void CbxDeposit2_CheckedChanged(object sender, EventArgs e)
        {
             
       var listBank =      (from Bnk in FsDb.Tbl_Banks
             join BNkAcc in FsDb.Tbl_AccountsBank on Bnk.ID equals BNkAcc.BankID

             where (BNkAcc.KindAccountBankID == 1)
             select new

             {
                 ID = Bnk.ID,
                 Name = Bnk.Name
                
             }).OrderBy(x => x.Name).ToList();
            comboBox2.DataSource = listBank;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember   = "ID";
           comboBox2.SelectedIndex = -1;
            comboBox2.Text = "اختر البنك";
            comboBox2.Focus();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {

           
        }
        private void GrdBankCheqsDueDate(DateTime Vdt_DueDateF, DateTime Vdt_DueDate, int Vint_ReceivedKindID,int BankId)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (CheqBank.ChequeDueDate >= Vdt_DueDateF && CheqBank.ChequeDueDate <= Vdt_DueDate && TRC.BankDepositeID == BankId)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccountName = BNK.Name,
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,
                            Parent_ID = TRC.Parent_ID,
                            ChequeReceivedKindID = TRC.ChequeReceivedKindID

                        }).Distinct().OrderBy(x => x.BranchID).ThenBy(x => x.CollectionDate).ToList();
            dataGridView4.DataSource = list;


        }
   
        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox2.SelectedValue != null)
                {
                    int Vint_BankDeposit = int.Parse(comboBox2.SelectedValue.ToString());

                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                    if (txtCheqAllCount.Text != "")

                    { dataGridView1.Rows.Clear(); }
                    if (dataGridView2.Rows.Count != 0)
                    {
                        dataGridView2.Rows.Clear();
                    }
                    if (AddCheck.Checked == true && DueDateCheck.Checked == true && CbxDeposit2.Checked == true)
                    {
                        DateTime Vdt_DueDateF = Convert.ToDateTime(dtpDueDate1.Value.ToString("yyyy/MM/dd"));
                        DateTime Vdt_DueDate = Convert.ToDateTime(dtpDueDate.Value.ToString("yyyy/MM/dd"));
                        //******************استدعاء حوافظ الفروع في التاريح المختار
                        GrdBankCheqsDueDate(Vdt_DueDateF, Vdt_DueDate, 0, Vint_BankDeposit);
                        if (dataGridView4.Rows.Count != 0)
                        {
                            Vdt_DueDate = Convert.ToDateTime(dtpDueDate.Value.ToString("yyyy/MM/dd"));

                            DgrCheqDueDate(Vdt_DueDateF, Vdt_DueDate);
                            GrdBnkCheq();
                            TotalChequeCollection();
                            GrdTRCollctionCheq();
                            LoopPaintRowDueSateNotFYear();
                        }
                    }
                    else if (AddCheck.Checked == false && DueDateCheck.Checked == true)
                    {
                        //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                    }

                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر البنك ");
                }
            }
        }
        private void DgrCheqDrawn(DateTime d1, DateTime d2)
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            string Vst_TradeCollectionNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());


                //************** Declare 
                int Vint_ID = int.Parse(dataGridView4.Rows[i].Cells[0].Value.ToString());
                int Vint_BranchID = int.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString());
                Vint_ChequeReceivedKindID = int.Parse(dataGridView4.Rows[i].Cells[13].Value.ToString());
                string Vst_BranchName = dataGridView4.Rows[i].Cells[2].Value.ToString();
                if (dataGridView4.Rows[i].Cells[3].Value != null)
                {
                    Vst_TradeCollectionNo = dataGridView4.Rows[i].Cells[3].Value.ToString();
                }

                string Vst_CollectionNo = dataGridView4.Rows[i].Cells[4].Value.ToString();
                DateTime Vdt_CollectionDate = Convert.ToDateTime(dataGridView4.Rows[i].Cells[5].Value.ToString());

                int Vint_BankDepositeID = int.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString());
                int Vint_BankAccountID = int.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString());
                var listAccName = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_BankAccountID).ToList();
                string Vst_BNameAcc = dataGridView4.Rows[i].Cells[8].Value.ToString();
                string Vst_Name = dataGridView4.Rows[i].Cells[9].Value.ToString();

                if (dataGridView4.Rows[i].Cells[10].Value != null)
                { Vint_RepresentiveID = int.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()); }
                else { Vint_RepresentiveID = null; }
                var listRepresentiveName = FsDb.Tbl_Representatives.Where(x => x.ID == Vint_RepresentiveID).ToList();
                if (dataGridView4.Rows[i].Cells[11].Value != null)
                { Vst_ReceiptNo = dataGridView4.Rows[i].Cells[11].Value.ToString(); }
                else { Vst_ReceiptNo = ""; }


                if (Vint_BranchID == 180)
                {
                    GetDataCheqNoKhazinaDr(d1, d2);
                }
                else
                {
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (BnkChq.ChequeStatusDate >= d1 && BnkChq.ChequeStatusDate <= d2 && BnkChq.ChequeStatusID == 5)
                                         select new

                                         {
                                             ID = BnkChq.ID,
                                             TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                             AmountCheque = BnkChq.AmountCheque,
                                             BankDrawnOnID = BnkChq.BankDrawnOnID,
                                             ChequeNo = BnkChq.ChequeNo,
                                             ChequeDueDate = BnkChq.ChequeDueDate,
                                             DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                             CustID = BnkChq.CustID,
                                             AddDateBank = BnkChq.AddDateBank,
                                             ChequeKind = BnkChq.ChequeKindID,
                                             //CustomerName = Cust.Name,
                                             BankName = BNK.Name,
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID,
                                             DepositDate = TRC.DepositDate,
                                             ChequeStatusID = BnkChq.ChequeStatusID,

                                             TradeCollection = TRC.TradeCollectionNo,
                                             CollectionNo = TRC.CollectionNo,
                                             CollectionDate = TRC.CollectionDate,

                                             DepositBank = bnkD.Name,
                                             BranchNam = mng.BrancheName

                                         }).Distinct().OrderBy(x => x.ChequeDueDate).ToList();

                    //for (int j = 0; j < (listBnkCheque.Count); j++)
                    //{

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, listBnkCheque[i].IsDisposed, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID,
                    listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName,
                    listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID,
                    listBnkCheque[i].TradeCollection, listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate,
                    listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();

                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                    //}
                }

                LoadSerial2();
            }


        }
        private void GetDataCheqNoKhazinaDr(DateTime d1, DateTime d2)
        {
            //Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                 join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                 where (BnkChq.ChequeStatusDate >= d1 && BnkChq.ChequeStatusDate <= d2 && BnkChq.ChequeStatusID == 5)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     BankName = BNK.Name,
                                     ParentID = TRC.Parent_ID,
                                     DepositDate = TRC.DepositDate,
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     TradeCollection = TRC.TradeCollectionNo,
                                     CollectionNo = TRC.CollectionNo,
                                     CollectionDate = TRC.CollectionDate,
                                     DepositBank = bnkD.Name,
                                     BranchNam = mng.BrancheName

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            //*******************
            textBox2.Text = (listBnkCheque.Count).ToString();

            string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                 where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                 select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            if (Vstr_Count != listBnkCheque.Count.ToString())
            {
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    AddColumnDtaGrd1();
                //}

                for (int i = 0; i < (listBnkCheque.Count); i++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                    listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate,
                    listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID,
                    listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName,
                    listBnkCheque[i].ParentID, true, listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeStatusID
                    , listBnkCheque[i].TradeCollection,
                    listBnkCheque[i].CollectionNo, listBnkCheque[i].CollectionDate, listBnkCheque[i].DepositBank, listBnkCheque[i].BranchNam);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();
                    GrdBnkCheq();
                    if (i == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (i).ToString(); }


                }
            }
            else if (Vstr_Count == listBnkCheque.Count.ToString())
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = true;
                            dataGridView1.Rows[i].Cells[14].Value = true;
                        }
                    }
                }
                catch
                { }
            }



        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                chckDepositDate.Checked = false;
                BranchCheck.Checked = false;
                UserCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                CollNoCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                CheqAmountCheck.Checked = false;
                //*************
                TAmountCheck.Checked = false;
                BranchCheck.Checked = false;
                ExpCheck.Checked = false;
                BankCheck.Checked = false;
                UserCheck.Checked = false;
                TradCollNoCheck.Checked = false;
                DueDateCheck.Checked = false;
                BankdrawnOnCheck.Checked = false;
                cbxRefundCheq.Checked = false;
                //checkBox3.Checked = false;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("انتظر قليلا ، حيث يتم حصر الحوافظ والشيكات  طبقا للفتره المحدده  ");
                if (txtCheqAllCount.Text != "")

                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                if (AddCheck.Checked == true && checkBox3.Checked == true)
                {
                    //******************استدعاء حوافظ الفروع في التاريح المختار
                    GrdCheqsDrawn(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy-MM-dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrCheqDrawn(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy-MM-dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                        GrdBnkCheq();
                        TotalChequeCollection();
                        GrdTRCollctionCheq();
                        LoopPaintRowDueSateNotFYear();
                    }
                }
                else if (AddCheck.Checked == false && CheqNoCheck.Checked == true)
                {
                    //Grd3TrCollectionBrDepAmountCheqsNullDate(Convert.ToDecimal(txtAmountCheq.Text), 0);
                }
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار

                splashScreenManager1.CloseWaitForm();
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {

            int Vint_BankID = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
            int Vint_AccBank = int.Parse(comboBox4.SelectedValue.ToString());
            if (txtCheqAllCount.Text != "")
            { dataGridView1.Rows.Clear(); }
            if (dataGridView2.Rows.Count != 0)
            {
                dataGridView2.Rows.Clear();
            }
            if (AddCheck.Checked == true && BankCheck.Checked == true)
            {
                //******************استدعاء حوافظ الفروع في التاريح المختار
                Grd3TrCollectionBrDepBaanksAcc(Convert.ToDateTime(dateTimePickerF.Value.ToString("yyyy/MM/dd")), Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd")), Vint_BankID, 0, Vint_AccBank);
                //***********    استدعاء بيانات حوافظ الفروع وشيكاتها في التاريح المختار
                if (dataGridView4.Rows.Count != 0)
                {
                    DgrTrCollectionDeposit();
                    GrdBnkCheq();
                    TotalChequeCollection();
                    GrdTRCollctionCheq();
                    LoopPaintRowDueSateNotFYear();
                }
            }
            else if (AddCheck.Checked == true && chckDepositDate.Checked == true)
            {
                DateTime Vdt_DepositDate = Convert.ToDateTime(dtpDepositDate.Value.ToString("yyyy/MM/dd"));
                 Vint_BankID = int.Parse(comboBox1.SelectedValue.ToString());
                //****************** 
                Grd3CheqsDepositDateBankDepAcc(Vdt_DepositDate, Vint_BankID, 0, Vint_AccBank);
                if (dataGridView4.Rows.Count != 0)
                {
                    //Vdt_DepositDate = Convert.ToDateTime(dtpDepositDate.Value.ToString("yyyy/MM/dd"));

                    DgrCheqDeposit(Vdt_DepositDate);
                    GrdBnkCheq();
                    TotalChequeCollection();
                    GrdTRCollctionCheq();
                }
            }
                //**********************الغرض من الحساب

                var ListAcc = FsDb.Tbl_AccountsBank.Where(x => x.ID == Vint_AccBank).ToList();
            int Vint_PAccBank = int.Parse(ListAcc[0].AccPurposeID.ToString());
            var ListPurpose = FsDb.Tbl_AccountsBankPurpose.Where(x => x.ID == Vint_PAccBank).ToList();
            comboBox5.DataSource = ListPurpose;
            comboBox5.DisplayMember = "Name";
            comboBox5.ValueMember = "ID";
             //******************************
        }

        
    }

}
