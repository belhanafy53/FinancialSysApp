using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraEditors;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace FinancialSysApp.Forms.Banks.TransferDataBanks
{
    public partial class TransmetBankAddTypeingFrm : DevExpress.XtraEditors.XtraForm
    {
        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        int Vint_BankID = 0;
        int Vint_bankAccid = 0;
        long Vlng_TreasuryCollectionID = 0;
        long Vlng_ChqBnkID = 0;
        int Vint_MovType = 0;
        int Vint_MovType1 = 0;

        string Vst_Cheqstring1 = "";
        string Vst_Cheqstring2 = "";
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public TransmetBankAddTypeingFrm()
        {
            InitializeComponent();
        }

        private void TransmetBankAddTypeingFrm_Load(object sender, EventArgs e)
        {
            //int Vint_BankMType = int.Parse(comboBox3.SelectedValue.ToString());
            this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);

            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "اختر البنك ";

            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر رقم الحساب ";

            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر التصنيف الرئيسي ";

            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر التصنيف الفرعي ";

            //AddColumnDtaGrd1();

            dTPDeposit.Select();
            this.ActiveControl = dTPDeposit;
            dTPDeposit.Focus();
        }
        private void AddColumnDtaGrd5()
        {


            // Create a new columns datadridview1
            DataGridViewTextBoxColumn newColumnID = new DataGridViewTextBoxColumn();

            // Set the properties of the new column
            newColumnID.HeaderText = "ID"; // Header text of the column
            newColumnID.Name = "ID"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnID);

            DataGridViewCheckBoxColumn newColumnIsAddedAccNo = new DataGridViewCheckBoxColumn();
            newColumnIsAddedAccNo.Name = "IsAddedAccNo"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnIsAddedAccNo);

            DataGridViewTextBoxColumn newColumnAmountCash = new DataGridViewTextBoxColumn();
            newColumnAmountCash.Name = "AmountCash"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnAmountCash);

            DataGridViewTextBoxColumn newColumnDepositDate = new DataGridViewTextBoxColumn();
            newColumnDepositDate.Name = "DepositDate"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnDepositDate);

            DataGridViewTextBoxColumn newColumnBankDueDate = new DataGridViewTextBoxColumn();
            newColumnBankDueDate.Name = "BankDueDate"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnBankDueDate);

            DataGridViewTextBoxColumn newColumnDepositBankID = new DataGridViewTextBoxColumn();
            newColumnDepositBankID.Name = "DepositBankID"; // Unique name of the column
            newColumnDepositBankID.Visible = false;
            dataGridView5.Columns.Add(newColumnDepositBankID);



            DataGridViewTextBoxColumn newColumnAccBankID = new DataGridViewTextBoxColumn();
            newColumnAccBankID.Name = "AccBankID"; // Unique name of the column
            newColumnAccBankID.Visible = false;
            dataGridView5.Columns.Add(newColumnAccBankID);

            DataGridViewTextBoxColumn newColumnRepresentiveID = new DataGridViewTextBoxColumn();
            newColumnRepresentiveID.Name = "RepresentiveID"; // Unique name of the column
            newColumnRepresentiveID.Visible = false;
            dataGridView5.Columns.Add(newColumnRepresentiveID);



            DataGridViewTextBoxColumn newColumnFYear = new DataGridViewTextBoxColumn();
            newColumnFYear.Name = "FYear"; // Unique name of the column
            newColumnFYear.Visible = false;
            dataGridView5.Columns.Add(newColumnFYear);


            DataGridViewTextBoxColumn newColumnDepositCashNo = new DataGridViewTextBoxColumn();
            newColumnDepositCashNo.Name = "DepositCashNo"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnDepositCashNo);

            DataGridViewTextBoxColumn newColumnBankAddDate = new DataGridViewTextBoxColumn();
            newColumnBankAddDate.Name = "BankAddDate"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnBankAddDate);
            //*****************
            DataGridViewTextBoxColumn newColumnDepositCashStatusID = new DataGridViewTextBoxColumn();
            newColumnDepositCashStatusID.Name = "DepositCashStatusID"; // Unique name of the column
            newColumnDepositCashStatusID.Visible = false;
            dataGridView5.Columns.Add(newColumnDepositCashStatusID);

            DataGridViewTextBoxColumn newColumnDepositCashStatusDate = new DataGridViewTextBoxColumn();
            newColumnDepositCashStatusDate.Name = "DepositCashStatusDate"; // Unique name of the column
            newColumnDepositCashStatusDate.Visible = false;
            dataGridView5.Columns.Add(newColumnDepositCashStatusDate);

            DataGridViewTextBoxColumn newColumnBankName = new DataGridViewTextBoxColumn();
            newColumnBankName.Name = "BankName"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnBankName);



            DataGridViewTextBoxColumn newColumnmngName = new DataGridViewTextBoxColumn();
            newColumnmngName.Name = "mngName"; // Unique name of the column
            dataGridView5.Columns.Add(newColumnmngName);


            DataGridViewTextBoxColumn newColumnBranchID = new DataGridViewTextBoxColumn();
            newColumnBranchID.Name = "BranchID"; // Unique name of the column
            newColumnBranchID.Visible = false;
            dataGridView5.Columns.Add(newColumnBranchID);

            DataGridViewCheckBoxColumn newColumnCheqTrue = new DataGridViewCheckBoxColumn();
            newColumnCheqTrue.Name = "CheqTrue"; // Unique name of the column
            newColumnCheqTrue.Visible = false;
            dataGridView5.Columns.Add(newColumnCheqTrue);

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

        private void dTPDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dTPDeposit2.Focus();
            }
        }

        private void dTPDeposit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //dataGridView2.DataSource = null;
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                Vint_BankID = int.Parse(comboBox2.SelectedValue.ToString());

                comboBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "اختر رقم الحساب ";

                this.dataTable1TableAdapter.FillByBankNotTyping(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_BankID);
                LoadSerial6();
                GrdTotalValue6();
                radGroupBox2.Text = "بيان بكشف حساب البنك " +" " + comboBox2.Text;
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                txtSpAllValue.Text = "";
                txtSpAllCount.Text = "";
                GrdTotalValue();
                dataGridView2.Visible = false;
                dataGridView6.Visible = true;
                //comboBox3.SelectedIndex = -1;
                //comboBox3.Text = "اختر التصنيف الرئيسي ";

                //comboBox4.Text = "";
                //comboBox4.SelectedIndex = -1;
                //comboBox4.Text = "اختر التصنيف الفرعي ";


                comboBox1.Focus();
            }
        }

        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
                //ColorDgrdRows();
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
        private void LoadSerial5()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void LoadSerial6()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                if (comboBox2.SelectedValue != null)
                { Vint_BankID = int.Parse(comboBox2.SelectedValue.ToString()); }
                if (comboBox1.SelectedValue != null)
                {
                    Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                }
                //var list_KindPr = FsDb.Tbl_BankMovement.Where(x => x.BankID == Vint_BankID && x.BankAccID == Vint_bankAccid && x.MoveDat >= d1 && x.MoveDat <= d2).Select(x=>x.DebitCredit).Distinct().ToList();
                //if (list_KindPr.Count != 0)
                //{
                //    comboBox5.DataSource = list_KindPr;
                comboBox5.SelectedIndex = -1;
                comboBox5.Text = "اختر نوع العملية";
                //    comboBox5.DisplayMember = list_KindPr.ToString();
                //    comboBox5.ValueMember = list_KindPr.ToString();
                //}
                if (comboBox1.SelectedValue != null)
                { Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString()); }

                //int Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString());
                //int Vint_MovType1 = int.Parse(comboBox4.SelectedValue.ToString());
                //var ListBankSetting = FsDb.Tbl_BankStringCHeqCash.Where(x => x.BankID == Vint_BankID && x.MoveType == Vint_MovType && x.MoveType1 == Vint_MovType1).ToList();
                //if (ListBankSetting.Count != 0)
                //{
                //    string Vst_BankSettingSt1 = ListBankSetting[0].CheqString.ToString();
                //    int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                //    //this.dataTable1TableAdapter.FillByBankAccSearchNote(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_BankSettingSt1, Vint_bankAccid);

                this.dataTable1TableAdapter.FillByBankAccTyping(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_BankID, Vint_bankAccid);
                LoadSerial6();
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                txtSpAllValue.Text = "";
                txtSpAllCount.Text = "";
                GrdTotalValue6();
                //    //dataGridView2.Columns["Ser2"].Visible = false;

                //    simpleButton1.Enabled = true;
                //    simpleButton2.Enabled = false;
                //    //simpleButton3.Enabled = true;
                comboBox3.Focus();

                //}
               
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Vint_BankID = int.Parse(comboBox2.SelectedValue.ToString());
            this.tbl_AccountsBank1TableAdapter.FillByBankID(this.bankCheques.Tbl_AccountsBank1, Vint_BankID);
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر رقم الحساب";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private Boolean DgrDepositCashAmountCh(int Vint_Bank, int Vint_bankAccid, Decimal Vd_AmountCh)
        {
            Boolean Vb_Action = false;

            var listDepositCash = (from DpC in FsDb.Tbl_DepositCash
                                   join DpCSt in FsDb.Tbl_DepositCashStatusDates on DpC.ID equals DpCSt.DepositCashID
                                   join BNK in FsDb.Tbl_Banks on DpC.DepositBankID equals BNK.ID
                                   join mng in FsDb.Tbl_Management on DpC.BranchID equals mng.ID

                                   where (DpC.DepositBankID == Vint_BankID && DpC.AccBankID == Vint_bankAccid && DpC.AmountCash == Vd_AmountCh)
                                   select new

                                   {
                                       ID = DpC.ID,
                                       DepositDate = DpC.DepositDate,
                                       BankDueDate = DpC.BankDueDate,
                                       DepositBankID = DpC.DepositBankID,
                                       AccBankID = DpC.AccBankID,
                                       RepresentiveID = DpC.RepresentiveID,
                                       AmountCash = DpC.AmountCash,
                                       FYear = DpC.FYear,
                                       DepositCashNo = DpC.DepositCashNo,
                                       BankAddDate = DpC.BankAddDate,
                                       DepositCashStatusID = DpC.DepositCashStatusID,
                                       DepositCashStatusDate = DpC.DepositCashStatusDate,
                                       BankName = BNK.Name,
                                       IsAddedAccNo = DpC.IsAddedAccNo,
                                       branchId = DpC.BranchID

                                   }).OrderBy(x => x.DepositDate).ToList();
            if (listDepositCash.Count == 1)
            {

                dataGridView3.DataSource = listDepositCash;
                DgrDCashAndAdded();
                GrdDepCash();
                LoadSerial5();
                Vb_Action = true;

            }

            return Vb_Action;
        }
        private void GrdDepCash()
        {


            dataGridView5.Columns["ID"].Visible = false;



            dataGridView5.Columns["DepositDate"].Visible = true;


            dataGridView5.Columns["BankDueDate"].Visible = true;

            dataGridView5.Columns["DepositBankID"].Visible = false;


            dataGridView5.Columns["AccBankID"].Visible = false;

            dataGridView5.Columns["RepresentiveID"].Visible = false;
            dataGridView5.Columns["AmountCash"].Visible = true;


            dataGridView5.Columns["DepositCashNo"].Visible = true;

            dataGridView5.Columns["BankAddDate"].Visible = true;
            dataGridView5.Columns["DepositCashStatusID"].Visible = false;

            dataGridView5.Columns["DepositCashStatusDate"].Visible = false;
            dataGridView5.Columns["IsAddedAccNo"].Visible = false;

            dataGridView5.Columns["BankName"].Visible = false;




            dataGridView5.Columns["AmountCash"].HeaderText = "مبلغ الايداع";
            dataGridView5.Columns["AmountCash"].Width = 120;

            dataGridView5.Columns["BankAddDate"].HeaderText = "تاريخ الاضافه";
            dataGridView5.Columns["BankAddDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView5.Columns["BankDueDate"].HeaderText = "تاريخ الحق";
            dataGridView5.Columns["BankDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView5.Columns["DepositDate"].HeaderText = "تاريخ الايداع";
            dataGridView5.Columns["DepositDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView5.Columns["DepositCashNo"].HeaderText = "رقم الايداع";

            dataGridView5.Columns["BankName"].HeaderText = "البنك";

            dataGridView5.Columns["mngName"].HeaderText = "الفرع";

            dataGridView5.Columns["IsAddedAccNo"].HeaderText = "تمت الاضافه ام لا";

            dataGridView5.Columns["IsSelectedType"].HeaderText = "تمت التصنيف ام لا";
            


        }
      
        private Boolean DgrChequesTrueDepositAmountCh(int Vint_Bank, int Vint_bankAccid, Decimal Vd_AmountCh, string Vst_CheqNo, int Vint_moveType, long Vint_IdBankMovement, DateTime VDt_MovDate)
        {
            long Vlng_TrCollID = 0;
            Boolean Vb_Action = false;
            dataGridView1.DataSource = null;
            //******************************البحث عن الشيك برقم الشيك
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where (TRC.BankAccounNoID == Vint_bankAccid && TRC.BankDepositeID == Vint_Bank && BnkChq.ChequeNo == Vst_CheqNo)
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
                                     ChequeStatusID = BnkChq.ChequeStatusID,
                                     AddDateAccBank = BnkChq.AddDateAccBank

                                 }).OrderBy(x => x.AddDateBank).ToList();

            var list_mov = FsDb.Tbl_BankMovement.Where(x => x.ID == Vint_IdBankMovement).ToList();

            if (listBnkCheque.Count == 1 && (Vint_moveType == 2 || Vint_moveType == 1))
            {
                Vlng_TrCollID = long.Parse(listBnkCheque[0].TreasuryCollectionID.ToString());

                long VLnt_cheqID = int.Parse(listBnkCheque[0].ID.ToString());

                var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == VLnt_cheqID).ToList();
                long Vlng_bnkCheqId = int.Parse(listBnkCheque[0].ID.ToString());
                //******************************مقارنة قيمة الشيك بالقيمه بكشف الحساب ولو الفرق اكبر من 1 لا يتم الربط
                Decimal Vdc_SubAmount = 0;
                if (Vint_Bank == 2004)
                {
                    decimal Vdc_TotalCheqTrColl = Convert.ToDecimal(FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_TrCollID).Select(P => P.AmountCheque).Sum().ToString());
                    Vdc_SubAmount = Vd_AmountCh - Vdc_TotalCheqTrColl;

                }
                else
                {
                    Vdc_SubAmount = Vd_AmountCh - Convert.ToDecimal(listBnkCheque[0].AmountCheque);
                }
                if (Vdc_SubAmount < 0)
                {
                    Vdc_SubAmount = Convert.ToDecimal(listBnkCheque[0].AmountCheque) - Vd_AmountCh;
                }
                if ((Vdc_SubAmount < 1 && Vdc_SubAmount >= 0))

                {
                    dataGridView3.DataSource = listBnkCheque;
                    DgrCheqAndAdded();
                    GrdBnkCheq();
                    //LoadSerial1();
                    Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString());
                    //************************تصنيف الشيك

                    list_mov[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
                    list_mov[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString());
                    list_mov[0].IsSelectedType = true;
                    if (Vint_BankID == 2004)
                    {
                        list_mov[0].C2 = Vlng_TrCollID.ToString();
                    }
                    else
                    {
                        list_mov[0].BankCheqID = Vlng_bnkCheqId;
                    }
                    list_mov[0].IsCollected = true;
                    //************************حفظ حالة الشيك
                    if (Vint_MovType == 2)
                    {
                        if (listBankCheq.Count != 0)
                        {
                            listBankCheq[0].IsAddedAccNo = true;
                            listBankCheq[0].ChequeStatusID = 3;
                            listBankCheq[0].ChequeStatusDate = VDt_MovDate;
                            listBankCheq[0].AddDateAccBank = VDt_MovDate;
                            FsDb.SaveChanges();
                            var listCheqStatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == VLnt_cheqID && x.BankChequeStatusID == 2).ToList();
                            if (listCheqStatus.Count != 0)
                            {
                                Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                                {
                                    BankChequeStatusID = 3,
                                    BankChequeID = Vlng_bnkCheqId,

                                    ChequeBankStatusDate = VDt_MovDate
                                };
                                listCheqStatus[0].BankChequeStatusID = 3;
                                listCheqStatus[0].ChequeBankStatusDate = VDt_MovDate;
                                FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                                FsDb.SaveChanges();
                                Vb_Action = true;
                            }
                        }
                    }
                }
            }
            //**********************البحث عن الشيك بالقيمه 
            else if (listBnkCheque.Count == 0 && Vint_moveType == 2)
            {

                var listBnkChequeAm = (from BnkChq in FsDb.Tbl_BankCheques
                                       join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                       join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                       where (TRC.BankAccounNoID == Vint_bankAccid && TRC.BankDepositeID == Vint_Bank && BnkChq.AmountCheque == Vd_AmountCh)
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
                                           ChequeStatusID = BnkChq.ChequeStatusID,
                                           AddDateAccBank = BnkChq.AddDateAccBank

                                       }).OrderBy(x => x.AddDateBank).ToList();

                //******************************مقارنة قيمة الشيك بالقيمه بكشف الحساب ولو الفرق اكبر من 1 لا يتم الربط
                if (listBnkChequeAm.Count == 1 && Vint_moveType == 2)
                {
                    Vlng_TrCollID = long.Parse(listBnkChequeAm[0].TreasuryCollectionID.ToString());
                    long VLnt_cheqID = int.Parse(listBnkChequeAm[0].ID.ToString());
                    var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == VLnt_cheqID).ToList();
                    long Vlng_bnkCheqId = int.Parse(listBnkChequeAm[0].ID.ToString());
                    Decimal Vdc_SubAmount = Vd_AmountCh - Convert.ToDecimal(listBnkChequeAm[0].AmountCheque);
                    if (Vdc_SubAmount < 0)
                    {
                        Vdc_SubAmount = Convert.ToDecimal(listBnkChequeAm[0].AmountCheque) - Vd_AmountCh;
                    }
                    if ((Vdc_SubAmount < 1 && Vdc_SubAmount >= 0))

                    {
                        dataGridView3.DataSource = listBnkChequeAm;
                        DgrCheqAndAdded();
                        GrdBnkCheq();
                        //LoadSerial1();
                        if (Vint_BankID == 2004)
                        {
                            list_mov[0].C2 = Vlng_TrCollID.ToString();
                        }
                        else
                        { list_mov[0].BankCheqID = Vlng_bnkCheqId; }
                        Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString());
                        //************************تصنيف الشيك

                        list_mov[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
                        list_mov[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString());
                        list_mov[0].IsSelectedType = true;

                        list_mov[0].IsCollected = true;
                        //************************حفظ حالة الشيك
                        if (Vint_MovType == 2)
                        {


                            if (listBankCheq.Count != 0)
                            {
                                listBankCheq[0].IsAddedAccNo = true;
                                listBankCheq[0].ChequeStatusID = 3;
                                listBankCheq[0].ChequeStatusDate = VDt_MovDate;
                                listBankCheq[0].AddDateAccBank = VDt_MovDate;
                                FsDb.SaveChanges();
                                var listCheqStatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == VLnt_cheqID && x.BankChequeStatusID == 2).ToList();
                                if (listCheqStatus.Count != 0)
                                {
                                    Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                                    {
                                        BankChequeStatusID = 3,
                                        BankChequeID = Vlng_bnkCheqId,

                                        ChequeBankStatusDate = VDt_MovDate
                                    };
                                    listCheqStatus[0].BankChequeStatusID = 3;
                                    listCheqStatus[0].ChequeBankStatusDate = VDt_MovDate;
                                    FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                                    FsDb.SaveChanges();
                                    Vb_Action = true;
                                }
                            }
                        }
                    }
                }

            }
            else if (listBnkCheque.Count == 1 && Vint_moveType != 2)
            {
                Vlng_TrCollID = long.Parse(listBnkCheque[0].TreasuryCollectionID.ToString());
                long VLnt_cheqID = int.Parse(listBnkCheque[0].ID.ToString());
                var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == VLnt_cheqID).ToList();
                listBankCheq[0].AddDateAccBank = VDt_MovDate;
                dataGridView3.DataSource = listBnkCheque;
                DgrCheqAndAdded();
                GrdBnkCheq();
                //LoadSerial1();

                long Vlng_bnkCheqId = int.Parse(listBnkCheque[0].ID.ToString());
                if (Vint_BankID == 2004)
                {
                    list_mov[0].C2 = Vlng_TrCollID.ToString();
                }
                else
                { list_mov[0].BankCheqID = Vlng_bnkCheqId; }
                list_mov[0].IsCollected = true;
                list_mov[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
                list_mov[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString());

                list_mov[0].IsSelectedType = true;
                string Vst_ChqBnkNo = listBnkCheque[0].ChequeNo.ToString();
                //***************كشف الحساب
                int vint_MovBankId = 0;
                Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString());
                Vint_MovType1 = int.Parse(comboBox4.SelectedValue.ToString());
                var ListBankSettingN = FsDb.Tbl_BankStringCHeqCash.Where(x => x.BankID == Vint_BankID && x.MoveType == Vint_MovType && x.MoveType1 == Vint_MovType1).ToList();

                Vst_Cheqstring1 = ListBankSettingN[0].CheqString;
                Vst_Cheqstring2 = ListBankSettingN[0].CheqString1;


                var List_bankMove = FsDb.Tbl_BankMovement.Where(x => x.C1 == Vst_ChqBnkNo && x.DescriptionNote.Contains(Vst_Cheqstring1) && x.IsCollected == false).ToList();
                if (List_bankMove.Count != 0)
                {

                    vint_MovBankId = int.Parse(List_bankMove[0].BankID.ToString());
                    bool Vbl_Checked = true;


                    List_bankMove[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
                    if (comboBox4.SelectedValue != null)
                    { List_bankMove[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString()); }
                    List_bankMove[0].IsSelectedType = true;
                    List_bankMove[0].IsCollected = true;
                    if (List_bankMove[0].BankCheqID != 0)
                    { List_bankMove[0].BankCheqID = Vlng_ChqBnkID; }
                    else
                    {
                        var List_bankMoveN = FsDb.Tbl_BankMovement.Where(x => x.C1 == Vst_ChqBnkNo && x.BankCheqID > 0).ToList();
                        if (List_bankMoveN.Count > 0)
                        {
                            if (Vint_BankID == 2004)
                            {
                                List_bankMove[0].C2 = Vlng_TrCollID.ToString();
                            }
                            else
                            { List_bankMove[0].BankCheqID = List_bankMoveN[0].BankCheqID; }
                        }
                    }

                    FsDb.SaveChanges();
                }

                Vb_Action = true;
            }
            else if (Vint_moveType == 10)
            {
                decimal Vdc_Amount = Convert.ToDecimal(list_mov[0].TransferValue.ToString());
                DateTime Vdt_MoveDate = Convert.ToDateTime(list_mov[0].MoveDat.ToString());
                var lIst_DepositCash = FsDb.Tbl_DepositCash.Where(x => x.AmountCash == Vdc_Amount && x.DepositDate == Vdt_MoveDate).ToList();
                if (lIst_DepositCash.Count != 0 && list_mov[0].MoveType1 == 10)
                {
                    dataGridView3.DataSource = lIst_DepositCash;
                    DgrDCashAndAdded();
                    dataGridView5.Visible = true;
                    dataGridView1.Visible = false;
                    dataGridView4.Visible = false;
                    list_mov[0].DepositCashID = lIst_DepositCash[0].ID;
                    list_mov[0].IsCollected = true;
                }
                else if (lIst_DepositCash.Count == 0 && list_mov[0].MoveType1 == 10)
                {
                    list_mov[0].IsCollected = false;
                }
                list_mov[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
                list_mov[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString());

                list_mov[0].IsSelectedType = true;
                FsDb.SaveChanges();
            }

            FsDb.SaveChanges();
            return Vb_Action;
        }

        private Boolean DgrChequesTrueDepositAmountChN(int Vint_Bank, int Vint_bankAccid, Decimal Vd_AmountCh, string Vst_CheqNo)
        {
            Boolean Vb_Action = false;

            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID

                                 where ((BnkChq.ChequeStatusID == 2 || BnkChq.ChequeStatusID == 3) && TRC.BankAccounNoID == Vint_bankAccid && TRC.BankDepositeID == Vint_Bank && BnkChq.AmountCheque == Vd_AmountCh && BnkChq.ChequeNo == Vst_CheqNo)
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
            if (listBnkCheque.Count == 1)

            {
                dataGridView3.DataSource = listBnkCheque;
                DgrCheqAndAdded();
                GrdBnkCheq();
                //LoadSerial1();

                Vb_Action = true;
            }
            return Vb_Action;
        }

        private void DgrCheqAndAdded()
        {

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
                    dataGridView1.Rows.Add(0, true, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                    listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositDate, listBnkCheque[j].AddDateBank, listBnkCheque[j].AddDateAccBank, listBnkCheque[j].BankDueDate, listBnkCheque[j].TradeCollectionNo, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName, listBnkCheque[j].BankDeposit,
                   listBnkCheque[j].ReceiptNo, listBnkCheque[j].IsDisposed, listBnkCheque[j].ParentID, listBnkCheque[j].ChequeStatusID, true
                  );
                    dataGridView1.AllowUserToAddRows = false;
                }
                //LoadSerial();
                //ColorSt();
            }
            dataGridView1.ResumeLayout();

            GrdTotalValue();
            //ColorSt();

        }
        private void DgrDCashAndAdded()
        {

            dataGridView5.SuspendLayout();

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                //Vlng_DepositCashID = long.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                //int Vint_BranchID = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                var listDepCashe = (from DpC in FsDb.Tbl_DepositCash
                                    join DpCSt in FsDb.Tbl_DepositCashStatusDates on DpC.ID equals DpCSt.DepositCashID
                                    join BNK in FsDb.Tbl_Banks on DpC.DepositBankID equals BNK.ID
                                    join mng in FsDb.Tbl_Management on DpC.BranchID equals mng.ID

                                    where (DpC.ID == Vint_ID)
                                    select new

                                    {
                                        ID = DpC.ID,
                                        IsAddedAccNo = DpC.IsAddedAccNo,
                                        DepositDate = DpC.DepositDate,
                                        BankDueDate = DpC.BankDueDate,
                                        DepositBankID = DpC.DepositBankID,
                                        AccBankID = DpC.AccBankID,
                                        RepresentiveID = DpC.RepresentiveID,
                                        AmountCash = DpC.AmountCash,
                                        FYear = DpC.FYear,
                                        DepositCashNo = DpC.DepositCashNo,
                                        BankAddDate = DpC.BankAddDate,
                                        DepositCashStatusID = DpC.DepositCashStatusID,
                                        DepositCashStatusDate = DpC.DepositCashStatusDate,
                                        BankName = BNK.Name,

                                        mngName = mng.BrancheName,
                                        Branchid = DpC.BranchID

                                    }).OrderBy(x => x.DepositDate).ToList();


                for (int j = 0; j < (listDepCashe.Count); j++)
                {

                    dataGridView5.AllowUserToAddRows = true;
                    dataGridView5.Rows.Add(0, true, listDepCashe[j].ID, listDepCashe[j].IsAddedAccNo, listDepCashe[j].AmountCash, listDepCashe[j].DepositDate, listDepCashe[j].BankDueDate, listDepCashe[j].DepositBankID,
                    listDepCashe[j].AccBankID, listDepCashe[j].RepresentiveID, listDepCashe[j].FYear, listDepCashe[j].DepositCashNo,
                    listDepCashe[j].BankAddDate, listDepCashe[j].DepositCashStatusID, listDepCashe[j].DepositCashStatusDate, listDepCashe[j].BankName,
                    listDepCashe[j].mngName, listDepCashe[j].Branchid, true
                  );
                    dataGridView5.AllowUserToAddRows = false;
                }
                //LoadSerial();
                //ColorSt();
            }
            dataGridView5.ResumeLayout();

            Grd5TotalValue();
            //ColorSt();

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
        private void DgrCheqDepositAndAdded()
        {

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

            }
            dataGridView1.ResumeLayout();
            //LoadSerial1();
            ColorSt();

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
        private void retrieveDataTransmet()
        {
            int Vint_bankid = 0;
            int Vint_bankAccid = 0;
            Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
            Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
            DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
            DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
            if (comboBox2.SelectedValue != null)
            { Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString()); }
            if (comboBox1.SelectedValue != null)
            { Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString()); }
            string Vst_SearhNote = txtSearch.Text;

            string Vst_ProcessKind = comboBox5.Text;
            this.dataTable1TableAdapter.FillByBankAccBankSearchNote(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_SearhNote, Vint_bankAccid, Vst_ProcessKind);
            txtAllValue.Text = "";
            txtAllCount.Text = "";
            txtSpAllValue.Text = "";
            txtSpAllCount.Text = "";
            GrdTotalValue();
        }
        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.CurrentRow.Cells[1].Value = true;
                //Grd1TotalValue();

            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                int Vint_MovBnkTypeM = int.Parse(comboBox3.SelectedValue.ToString());
                if (Vint_MovBnkTypeM == 2)
                {
                    dataGridView1.Visible = true;
                }
                else if (Vint_MovBnkTypeM == 10)
                {
                    dataGridView5.Visible = true;
                    dataGridView1.Visible = false;

                }
                comboBox4.Focus();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int Vint_MovBnkType = 0;
                if (comboBox4.SelectedValue != null)
                { Vint_MovBnkType = int.Parse(comboBox4.SelectedValue.ToString()); }

                if (Vint_MovBnkType == 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView5.Visible = false;
                    dataGridView4.Visible = false;
                }
                else if (Vint_MovBnkType == 2)
                {
                    dataGridView1.Visible = true;
                    dataGridView5.Visible = false;
                    dataGridView4.Visible = false;
                }
                else if (Vint_MovBnkType == 4)
                {

                    dataGridView5.Visible = false;
                    dataGridView1.Visible = false;
                    dataGridView4.Visible = true;

                }
                else if (Vint_MovBnkType == 5)
                {
                    dataGridView1.Visible = false;
                    dataGridView5.Visible = false;
                    dataGridView4.Visible = true;
                }
                else if (Vint_MovBnkType == 10)
                {

                    dataGridView5.Visible = true;
                    dataGridView1.Visible = false;
                    dataGridView4.Visible = false;

                }
                int Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString());
                int Vint_MovType1 = int.Parse(comboBox4.SelectedValue.ToString());
                var ListBankSetting = FsDb.Tbl_BankStringCHeqCash.Where(x => x.BankID == Vint_BankID && x.MoveType == Vint_MovType && x.MoveType1 == Vint_MovType1).ToList();

                if (ListBankSetting.Count != 0)
                {
                    Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                    Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                    DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                    DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                    //************************الشيكات طبقا للتصنيف بناء على الكلمات المدخله بشاشة الاعدادات
                    List<string> checkedIDs = new List<string>();// List Of Names 
                    checkedIDs = FsDb.Tbl_BankStringCHeqCash.Where(x => x.BankID == Vint_BankID && x.MoveType == Vint_MovType && x.MoveType1 == Vint_MovType1).Select(x => x.CheqString).ToList();
                    


                    DataTable groupedDataTableReport = GetDataBetweenDatesAndGroupFilterReport(checkedIDs, d1, d2, Vint_BankID);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = groupedDataTableReport;
                    GrdBnkMovType();
                    LoadSerial2();
                    Grd1TotalValue2();
                    //******************
                    string Vst_BankSettingSt1 = ListBankSetting[0].CheqString.ToString();
                    int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                    dataGridView2.Visible = true;
                    dataGridView6.Visible = false;
                    simpleButton1.Focus();
                    simpleButton1.Enabled = true;
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Visible = true;
                    dataGridView6.Visible = false;
                }
            }
        }

        private void GrdBnkMovType()
        {


            dataGridView2.Columns["ID"].Visible = false;



            dataGridView2.Columns["MoveDat"].Visible = true;


            dataGridView2.Columns["BankDueDate"].Visible = true;

            dataGridView2.Columns["BankID"].Visible = false;

            dataGridView2.Columns["TransferValue"].Visible = true;

            dataGridView2.Columns["BankAccID"].Visible = false;

            dataGridView2.Columns["DebitCredit"].Visible = true;


            dataGridView2.Columns["Balance"].Visible = false;


            dataGridView2.Columns["DescriptionNote"].Visible = true;


           

            dataGridView2.Columns["MovementCode"].Visible = true;

            //dataGridView2.Columns["DepositCashStatusID"].Visible = false;

            dataGridView2.Columns["Name"].Visible = false;

            dataGridView2.Columns["FisicalYeariD"].Visible = false;

            dataGridView2.Columns["AccountBankNo"].Visible = false;
            //dataGridView2.Columns["BnkPurpose"].Visible = false;

            //dataGridView2.Columns["BnkType1"].Visible = false;

            //dataGridView2.Columns["BnkType1"].Visible = false;
           
            //dataGridView2.Columns["  [الغرض من الحساب]"].Visible = false;
            dataGridView2.Columns["MoveType1"].Visible = false;
            dataGridView2.Columns["MoveType2"].Visible = false;


            dataGridView2.Columns["IsSelectedType"].HeaderText = "تمت التصنيف ام لا";

            dataGridView2.Columns["MoveDat"].HeaderText = "مبلغ الحركه";
            dataGridView2.Columns["MoveDat"].DefaultCellStyle.Format = "yyyy/MM/dd";

            

            dataGridView2.Columns["BankDueDate"].HeaderText = "تاريخ الحق";
            dataGridView2.Columns["BankDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView2.Columns["DebitCredit"].HeaderText = "نوع العمليه";
           

            dataGridView2.Columns["DescriptionNote"].HeaderText = "وصف الحركه";
            dataGridView2.Columns["DescriptionNote"].Width = 300;

                       dataGridView2.Columns["TransferValue"].HeaderText = "قيمة الحركه";

            dataGridView2.Columns["MovementCode"].HeaderText = "كود الحركه";

            

            



        }
        private DataTable GetDataBetweenDatesAndGroupFilterReport(List<string> checkedIDs, DateTime d1, DateTime d2, int Vint_BankID)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("IsSelectedType", typeof(Boolean));
            dataTable.Columns.Add("MoveDat", typeof(DateTime));
            dataTable.Columns.Add("BankDueDate", typeof(DateTime));
            dataTable.Columns.Add("DescriptionNote", typeof(string));
            dataTable.Columns.Add("TransferValue", typeof(decimal));

            dataTable.Columns.Add("DebitCredit", typeof(string));
            dataTable.Columns.Add("Balance", typeof(decimal));
            dataTable.Columns.Add("BankID", typeof(int));
            dataTable.Columns.Add("BankAccID", typeof(int));
            dataTable.Columns.Add("MovementCode", typeof(string));

            dataTable.Columns.Add("FisicalYeariD", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("AccountBankNo", typeof(string));
            dataTable.Columns.Add("Name AS [نوع الحساب]", typeof(string));
            dataTable.Columns.Add("Name AS [الغرض من الحساب]", typeof(string));

            dataTable.Columns.Add("MoveType1", typeof(int));
            dataTable.Columns.Add("MoveType2", typeof(int));
            
           

            int vv = checkedIDs.Count;
            for (int checkedID = 0; checkedID < vv; checkedID++)
            {
                string pdn = checkedIDs[ checkedID].ToString();
                RetrieveDataBetweenDates(d1, d2, Vint_BankID, pdn, dataTable);
            }
            return dataTable;
        }
        //كود الاستعلام **************************************************
        private void RetrieveDataBetweenDates(DateTime d1, DateTime d2, int Vint_BankID, string pDN, DataTable dataTable)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                string query = @"SELECT Tbl_BankMovement.ID,
                                Tbl_BankMovement.IsSelectedType,
                                Tbl_BankMovement.MoveDat AS [تاريخ الحركه], 
                                Tbl_BankMovement.BankDueDate AS [تاريخ الحق],
                                Tbl_BankMovement.DescriptionNote AS [وصف الحركه], 
                                Tbl_BankMovement.TransferValue AS [قيمة التحويل],
                               
                                Tbl_BankMovement.DebitCredit AS [نوع العمليه], 
                                Tbl_BankMovement.Balance AS الرصيد, 
                                Tbl_BankMovement.BankID, 
                                Tbl_BankMovement.BankAccID, 
                                Tbl_BankMovement.MovementCode,
                                Tbl_BankMovement.FisicalYeariD, 
                                Tbl_Banks.Name AS البنك, 
                                Tbl_AccountsBank.AccountBankNo AS [رقم الحساب],
                                Tbl_AccoiuntBankKind.Name , 
                                Tbl_AccountsBankPurpose.Name AS BnkPurpose,
                                Tbl_MovementBankType_1.Name AS BnkType1,
                                Tbl_MovementBankType.Name AS BnkType, 
                                Tbl_BankMovement.MoveType1,
                                Tbl_BankMovement.MoveType2, 
                                
                                Tbl_BankMovement.BankCheqID, 
                                Tbl_BankMovement.DepositCashID,
                                Tbl_BankMovement.C1, 
                                Tbl_BankMovement.IsCollected,
                                Tbl_BankMovement.NumberRefrBank AS [كود البنك]
                                FROM            Tbl_MovementBankType AS Tbl_MovementBankType_1 RIGHT OUTER JOIN
                                                        Tbl_BankMovement LEFT OUTER JOIN
                                                        Tbl_MovementBankType ON Tbl_BankMovement.MoveType2 = Tbl_MovementBankType.ID ON Tbl_MovementBankType_1.ID = Tbl_BankMovement.MoveType1 LEFT OUTER JOIN
                                                        Tbl_AccountsBankPurpose RIGHT OUTER JOIN
                                                        Tbl_AccountsBank ON Tbl_AccountsBankPurpose.ID = Tbl_AccountsBank.AccPurposeID ON Tbl_BankMovement.BankAccID = Tbl_AccountsBank.ID LEFT OUTER JOIN
                                                        Tbl_AccoiuntBankKind ON Tbl_AccountsBank.KindAccountBankID = Tbl_AccoiuntBankKind.ID LEFT OUTER JOIN
                                                        Tbl_Banks ON Tbl_BankMovement.BankID = Tbl_Banks.ID
                                WHERE        (Tbl_BankMovement.MoveDat >= @d1) AND (Tbl_BankMovement.MoveDat <= @d2) AND (Tbl_BankMovement.BankID = @Vint_BankID) AND (Tbl_BankMovement.IsCollected = 0) AND (Tbl_BankMovement.IsSelectedType = 0) AND (Tbl_BankMovement.DescriptionNote LIKE N'%' + @pDN + N'%') 
                                ORDER BY [تاريخ الحركه]";

                using (SqlCommand com = new SqlCommand(query, con))
                {
                    com.Parameters.Add("@d1", SqlDbType.DateTime).Value = d1;
                    com.Parameters.Add("@d2", SqlDbType.DateTime).Value = d2;
                    com.Parameters.Add("@Vint_BankID", SqlDbType.Int).Value = Vint_BankID;
                    com.Parameters.Add("@pDN", SqlDbType.NVarChar).Value = pDN;

                    con.Open();

                    SqlDataReader reader = com.ExecuteReader();

                    // Add retrieved data to the DataTable
                    while (reader.Read())
                    {
                        dataTable.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7),reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12), reader.GetValue(13), reader.GetValue(14), reader.GetValue(15), reader.GetValue(16), reader.GetValue(17));
                    }

                    reader.Close();
                    con.Close();
                }
            }
        }
        // كود الاضافه الى data table ******************************************
        private void GrdTotalValue()
        {
            //try
            //{

            int Vint_DgCount = dataGridView2.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                txtSpAllValue.Text = "";
                txtSpAllCount.Text = "";
                txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                   //where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                               select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                txtAllCount.Text = ((from DataGridViewRow row in dataGridView2.Rows
                                         //where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                     select Convert.ToDouble(row.Cells[7].Value)).Count().ToString());

                txtSpAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                 where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                 select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                txtSpAllCount.Text = ((from DataGridViewRow row in dataGridView2.Rows
                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                       select Convert.ToDouble(row.Cells[7].Value)).Count().ToString());

            }
        }
        private void GrdTotalValue6()
        {
            //try
            //{

            int Vint_DgCount = dataGridView6.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                txtSpAllValue.Text = "";
                txtSpAllCount.Text = "";
                txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView6.Rows
                                                   
                                               select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                txtAllCount.Text = ((from DataGridViewRow row in dataGridView6.Rows
                                         
                                     select Convert.ToDouble(row.Cells[7].Value)).Count().ToString());

                txtSpAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView6.Rows
                                                 where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                 select Convert.ToDouble(row.Cells[7].Value)).Sum(), 3).ToString();
                txtSpAllCount.Text = ((from DataGridViewRow row in dataGridView6.Rows
                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                       select Convert.ToDouble(row.Cells[7].Value)).Count().ToString());

            }
        }
        private void Grd1TotalValue2()
        {
            //try
            //{

            int Vint_DgCount = dataGridView2.RowCount;
            if (Vint_DgCount != 0)
            {

                txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                  
                                               select Convert.ToDouble(row.Cells[6].Value)).Sum(), 3).ToString();
                txtAllCount.Text = ((from DataGridViewRow row in dataGridView2.Rows
                                        
                                     select Convert.ToDouble(row.Cells[6].Value)).Count().ToString());

                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[6].Value)).Sum(), 3).ToString();

                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView2.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[6].Value)).Count().ToString());

            }
        }
        private void Grd5TotalValue()
        {
            //try
            //{

            int Vint_DgCount = dataGridView1.RowCount;
            if (Vint_DgCount != 0)
            {


                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView5.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView5.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[4].Value)).Count().ToString());

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
                //if (Vint_type1 == 2 || Vint_type1 == 10)
                //{
                //    simpleButton1.Text = "ربط";
                //}
                //else
                //{
                //    simpleButton1.Text = "تصنيف";
                //}
            }
            else
            {
                comboBox4.DataSource = null;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            radGroupBox2.Text = "بيان بكشف حساب  " + " " + comboBox2.Text +" -"+ "رقم حساب"+" "+ comboBox1.Text;
            dataGridView2.Visible = false;
            dataGridView6.Visible = true;
            comboBox3.Focus(); 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
                    
             

            Vint_BankID = int.Parse(comboBox2.SelectedValue.ToString());
            if (comboBox1.SelectedValue != null)
            { Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString()); }
            
            int Vint_MovType = int.Parse(comboBox3.SelectedValue.ToString());
            int Vint_MovType1 = int.Parse(comboBox4.SelectedValue.ToString());
            
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                 

                long Vlng_BankMovement = long.Parse(row.Cells[1].Value.ToString());
                var List_MovBank = FsDb.Tbl_BankMovement.Where(x => x.ID == Vlng_BankMovement).ToList();
                List_MovBank[0].MoveType1 = Vint_MovType;
                List_MovBank[0].MoveType2 = Vint_MovType1;
                List_MovBank[0].IsSelectedType = true;
                 

                FsDb.SaveChanges();

            }
           
            simpleButton1.Enabled = false;
            //---------------خفظ ااحداث 
            SecurityEvent sev = new SecurityEvent
            {
                ActionName = "اضافة تصنيف حركه من  كشف حساب بنك",
                TableName = "Tbl_BankMovement",
                TableRecordId = "",
                Description = "",
                ManagementName = Program.GlbV_Management,
                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                EmployeeName = Program.GlbV_EmpName,
                User_ID = Program.GlbV_UserId,
                UserName = Program.GlbV_UserName,
                FormName = "شاشة تصنيف حركه من كشف حساب بنك"

            };
            //*******************
            FsEvDb.SecurityEvents.Add(sev);
            FsEvDb.SaveChanges();
           
            //*******************
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[2].Value = true;
            }

            //*************
            MessageBox.Show("تم حفظ التصنيف");
            comboBox2.Focus();
        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            if (comboBox4.SelectedValue != null)
            {
                int Vint_MovBnkType = int.Parse(comboBox3.SelectedValue.ToString());
                if (Vint_MovBnkType == 2)
                {
                    dataGridView1.Visible = true;
                    label14.Visible = true;
                    dataGridView5.Visible = false;
                    label20.Visible = false;
                    dataGridView4.Visible = false;
                }

                else if (Vint_MovBnkType == 4)
                {

                    dataGridView1.Visible = true;
                    label14.Visible = true;
                    dataGridView5.Visible = false;
                    label20.Visible = false;
                    dataGridView4.Visible = true;
                }
                else if (Vint_MovBnkType == 5)
                {
                    dataGridView1.Visible = true;
                    label14.Visible = true;
                    dataGridView5.Visible = false;
                    label20.Visible = false;
                    dataGridView4.Visible = true;

                }
                else if (Vint_MovBnkType == 10)
                {
                    dataGridView1.Visible = false;
                    label14.Visible = false;
                    dataGridView5.Visible = true;
                    label20.Visible = true;
                    dataGridView4.Visible = false;
                }
                dataGridView2.Visible = true;
                dataGridView6.Visible = false;
            }
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            //int Vint_MovBnkTypeM = int.Parse(comboBox3.SelectedValue.ToString());
        }
        private void ColorDgrdRows()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                int Vint__BankCheq = int.Parse(row.Cells["BankCheqID"].Value.ToString());
                int Vint__DepositCash = int.Parse(row.Cells["DepositCashID"].Value.ToString());
                int vint_movtype = 0;
                vint_movtype = int.Parse(comboBox3.SelectedValue.ToString());
                if (Vint__BankCheq == 0 && (vint_movtype == 2 || vint_movtype == 1))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (Vint__DepositCash == 0 && vint_movtype == 10)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Forms.Banks.TransferDataBanks.TransmetCommentsFrm t = new Forms.Banks.TransferDataBanks.TransmetCommentsFrm();
            t.txtType1.Text = this.comboBox3.Text.ToString();
            t.txtType1ID.Text = this.comboBox3.SelectedValue.ToString();
            t.txtType2.Text = this.comboBox4.Text.ToString();
            t.txtType2ID.Text = this.comboBox4.SelectedValue.ToString();
            t.dTPDeposit.Value = this.dTPDeposit.Value;
            t.dTPDeposit2.Value = this.dTPDeposit2.Value;
            if (this.comboBox2.SelectedValue != null)
            {
                t.txtBnk.Text = this.comboBox2.Text.ToString();

                t.txtBnkID.Text = this.comboBox2.SelectedValue.ToString();
            }
            if (this.comboBox1.SelectedValue != null)
            {
                t.txtBnkAcc.Text = this.comboBox1.Text.ToString();
                t.txtBnkAccID.Text = this.comboBox1.SelectedValue.ToString();
            }
            t.simpleButton1.Text = this.simpleButton1.Text;
            t.txtRowID.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            t.txtBankChq.Text = dataGridView2.CurrentRow.Cells[23].Value.ToString();
            t.simpleButton1.Enabled = true;



            t.ShowDialog();
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            radGroupBox2.Text = "بيان بكشف حساب  " + " " + comboBox2.Text;
            dataGridView2.Visible = false;
            dataGridView6.Visible = true;
        }
    }
}
