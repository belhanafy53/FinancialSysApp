using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataProcessing;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar.Controls;
using FinancialSysApp.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using FinancialSysApp.Forms.DocumentsForms;
using System;
using DevExpress.Charts.Native;
using DevExpress.Utils;
using System.Web.Services.Description;
using DevExpress.XtraLayout.Helpers;
using Infragistics.Win.UltraWinGrid;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.Utils.Extensions;
using DevExpress.CodeParser;
using Infragistics.UltraGauge.Resources;
using DevExpress.XtraSplashScreen;
using System.Collections.Generic;

namespace FinancialSysApp.Forms.Banks
{
    public partial class DepositeCollectionFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();



        int? Vint_ChequeReceivedKindID = null;

        long? Vlng_LastRowTreasuryCollection = 0;
        DateTime? Vdt_DepositDate = null;

        long Vlng_TreasuryCollectionID = 0;
        long? Vlng_ParentID = 0;
        private string message;
        int Vint_bankDepositID = 0;
        int Vint_bankdrawnonid = 0;
        string result = "";
        public DepositeCollectionFrm()
        {
            InitializeComponent();
            // Wire up event handler for checkbox state change
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;



        }


        private void dTPCollection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.Rows.Count != 0)
                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                //ClearData();

                //***********استدعاء الحوافظ التي لم يتم ايداعها
                Grd3TrCollectionBrFalseDep();

                //************retrieve data saved Deposit at this Day 

                if (Vint_ChequeReceivedKindID == 0)
                {
                    Grd3TrCollectionBrDep(Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy/MM/dd")), 0);

                    //***********الحوافظ التي تم ايداعها في التاريح 
                    if (dataGridView4.Rows.Count != 0)
                    {
                        DgrTrCollectionDeposit();
                        GrdBnkCheq();
                    }
                    //***********الحوافظ التي لم يتم ايداعها في التاريح 
                    if (dataGridView3.Rows.Count != 0)
                    {
                        DgrTrCollectionFalseDeposit();
                    }
                    //***********
                    if (dataGridView4.Rows.Count != 0 || dataGridView3.Rows.Count != 0)
                    {
                        TotalChequeCollection();
                        //************ضبط طريقة عرض بيانات الحوافظ Datagridview2 

                        GrdTRCollctionCheq();
                        //************ضبط طريقة عرض بيانات الشيكات  Datagridview1

                    }


                }



                dataGridView2.Focus();
            }
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
                if (Vint_ChequeReceivedKindID == 1)
                {
                    txtBranch.Text = Vst_BranchName;
                    txtBranchID.Text = Vint_BranchID.ToString();
                    dTPCollection.Value = Vdt_CollectionDate;
                    txtCollectionNo.Text = Vst_CollectionNo;
                    cmbBnkDeposit.SelectedValue = Vint_BankDepositeID;
                    txtAccountBnk.Text = listAccName[0].AccountBankNo;
                    txtRepresentive.Text = listRepresentiveName[0].Name;
                    Vlng_ParentID = long.Parse(dataGridView4.Rows[i].Cells[12].Value.ToString());
                    Vlng_TreasuryCollectionID = long.Parse(Vlng_ParentID.ToString());
                }

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, true, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vdt_CollectionDate, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;
                TotalChequeCollection();

                if (Vint_BranchID == 180)
                {
                    GetDataChequeBankKhazina();
                }
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
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
                                         ParentID = TRC.Parent_ID

                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                if (dataGridView1.Rows.Count == 0)
                {
                    AddColumnDtaGrd1();
                }
                for (int j = 0; j < (listBnkCheque.Count); j++)
                {

                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.Rows.Add(0, true, listBnkCheque[j].ID, listBnkCheque[j].TreasuryCollectionID, listBnkCheque[j].AmountCheque, listBnkCheque[j].BankDrawnOnID,
                    listBnkCheque[j].ChequeNo, listBnkCheque[j].ChequeDueDate, listBnkCheque[j].DepositedByTrRepresntvID, listBnkCheque[j].CustID, listBnkCheque[j].AddDateBank, listBnkCheque[j].ChequeKind, listBnkCheque[j].BankName, listBnkCheque[j].ParentID, true);
                    dataGridView1.AllowUserToAddRows = false;
                    LoadSerial();

                    if (j == 0)
                    {
                        textBox2.Text = (1).ToString();
                    }
                    { textBox2.Text = (j).ToString(); }


                }
                LoadSerial2();
            }


        }
        private void DgrTrCollectionFalseDeposit()
        {
            int? Vint_RepresentiveID = 0;
            string Vst_ReceiptNo = "";
            //**************** Retrieve Data Not Deposit Untill Now 

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells[1].Value = true;
                Vlng_TreasuryCollectionID = long.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                int Vint_ID = 0;
                int Vint_BranchID = 0;
                string Vst_BranchName = "";
                string Vst_TradeCollectionNo = "";
                string Vst_CollectionNo = "";
                DateTime? Vdt_CollectionDate = null;
                int Vint_BankDepositeID = 0;
                int Vint_BankAccountID = 0;
                string Vst_BNameAcc = "";
                string Vst_Name = "";



                //************** Declare 
                if (Vint_ChequeReceivedKindID == 0)
                {
                    Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                    Vint_BranchID = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());

                    Vst_BranchName = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    if (dataGridView3.Rows[i].Cells[3].Value != null)
                    { Vst_TradeCollectionNo = dataGridView3.Rows[i].Cells[3].Value.ToString(); }

                    Vst_CollectionNo = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    Vdt_CollectionDate = Convert.ToDateTime(dataGridView3.Rows[i].Cells[5].Value.ToString());

                    Vint_BankDepositeID = int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                    Vint_BankAccountID = int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                    Vst_BNameAcc = dataGridView3.Rows[i].Cells[8].Value.ToString();
                    Vst_Name = dataGridView3.Rows[i].Cells[9].Value.ToString();


                    if (dataGridView3.Rows[i].Cells[10].Value != null)
                    { Vint_RepresentiveID = int.Parse(dataGridView3.Rows[i].Cells[10].Value.ToString()); }
                    else { Vint_RepresentiveID = null; }
                    if (dataGridView3.Rows[i].Cells[11].Value != null)
                    { Vst_ReceiptNo = dataGridView3.Rows[i].Cells[11].Value.ToString(); }
                    else { Vst_ReceiptNo = ""; }
                    //if (dataGridView3.Rows[i].Cells[12].Value != null)
                    //{ Vst_ReceiptNo = dataGridView3.Rows[i].Cells[12].Value.ToString(); }
                    //else { Vst_ReceiptNo = ""; }

                    //**********************
                }
                else if (Vint_ChequeReceivedKindID == 1)
                {
                    Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                    Vint_BranchID = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());

                    Vst_BranchName = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    if (dataGridView3.Rows[i].Cells[3].Value != null)
                    { Vst_TradeCollectionNo = dataGridView3.Rows[i].Cells[3].Value.ToString(); }

                    Vst_CollectionNo = dataGridView3.Rows[i].Cells[4].Value.ToString();
                    Vdt_CollectionDate = Convert.ToDateTime(dataGridView3.Rows[i].Cells[5].Value.ToString());

                    Vint_BankDepositeID = int.Parse(dataGridView3.Rows[i].Cells[6].Value.ToString());
                    Vint_BankAccountID = int.Parse(dataGridView3.Rows[i].Cells[7].Value.ToString());
                    //Vst_BNameAcc = dataGridView3.Rows[i].Cells[8].Value.ToString();
                    //Vst_Name = dataGridView3.Rows[i].Cells[9].Value.ToString();


                    if (dataGridView3.Rows[i].Cells[8].Value != null)
                    { Vint_RepresentiveID = int.Parse(dataGridView3.Rows[i].Cells[9].Value.ToString()); }
                    else { Vint_RepresentiveID = null; }
                    if (dataGridView3.Rows[i].Cells[9].Value != null)
                    { Vst_ReceiptNo = dataGridView3.Rows[i].Cells[10].Value.ToString(); }
                    else { Vst_ReceiptNo = ""; }

                    //if (dataGridView3.Rows[i].Cells[12].Value != null)
                    //{ Vst_ReceiptNo = dataGridView3.Rows[i].Cells[12].Value.ToString(); }
                    //else { Vst_ReceiptNo = ""; }
                }

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, false, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vdt_CollectionDate, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;


                LoadSerial2();
            }

            //*******************
            if (dataGridView2.RowCount > 0)
            {
                txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                ////************
            }
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DepositeCollectionFrm_Load(object sender, EventArgs e)
        {
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques1.Dtb_Banks);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            this.tbl_FiscalyearTableAdapter1.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
            //radioGroup1.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            Vint_ChequeReceivedKindID = comboBox1.SelectedIndex;
            //Vint_ChequeReceivedKindID = 0;
            ClearData();
            txtRepresentive.SelectionLength = 0;

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";

            checkData();
            //***********استدعاء الحوافظ التي لم يتم ايداعها
            Grd3TrCollectionBrFalseDep();

            if (dataGridView2.Rows.Count == 0)
            { AddColumnDtaGrd2(); }
            //****************  عرض الحوافظ التي لم يتم ايداعها 

            DgrTrCollectionFalseDeposit();
            TotalChequeCollection();
            //************** مايتم عرضه من بيانات الحوافظ 


            GrdTRCollctionCheq();

            dTPDeposit.Select();
            this.ActiveControl = dTPDeposit;
            dTPDeposit.Focus();
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

            DataGridViewTextBoxColumn newColumnCollectionDate = new DataGridViewTextBoxColumn();
            newColumnCollectionDate.Name = "CollectionDate"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnCollectionDate);

            DataGridViewTextBoxColumn newColumnTradeCollectionNo = new DataGridViewTextBoxColumn();
            newColumnTradeCollectionNo.Name = "TradeCollectionNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnTradeCollectionNo);

            DataGridViewTextBoxColumn newColumnCollectionNo = new DataGridViewTextBoxColumn();
            newColumnCollectionNo.Name = "CollectionNo"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnCollectionNo);



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


        }
        private void GrdBankCheqData()
        {
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                 where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID)
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
                                     BankName = BNK.Name

                                 }).OrderBy(x => x.ChequeDueDate).ToList();

            dataGridView1.DataSource = listBnkCheque;
            LoadSerial();
            GrdBnkCheq();
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
        private void TotalChequeCollection()
        {

            //int i = 1;

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
                    }
                }
                else
                {
                    //var list = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_LastRowTreasuryCollection).ToList();
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
                    }

                }
                //***************
            }
            //*******************
            if (dataGridView2.RowCount > 0)
            {
                txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
            }
            //************
        }
        private void GrdCheqData()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                        join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                        where (TRC.ID == Vlng_LastRowTreasuryCollection)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            //IsDepositNo = TRC.IsDepositNo,
                            BranchName = MNG.BrancheName,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,
                            BankAccName = BnkAcct.AccountBankNo,
                            BanKName = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,

                            ReceiptNo = TRC.ReceiptNo,
                            RepresentiveName = Rpsntv.Name,
                        }).OrderBy(x => x.ID).ToList();
            dataGridView1.DataSource = list;
            LoadSerial();
            GrdBnkCheq();

        }
        private void Grd3TrCollectionBrFalseDep()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == 0 && TRC.IsDepositNo == false)
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
                            Parent_ID = TRC.Parent_ID

                        }).OrderBy(x => x.BranchID).Take(200).ToList();
            dataGridView3.DataSource = list;


        }
        private void Grd3TrCollectionDrFalseDep()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection

                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == 1 && TRC.IsDepositNo == false)
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

                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView3.DataSource = list;


        }
        private void Grd3TrCollectionBrDep(DateTime Vdt_DepositDate, int Vint_ReceivedKindID)
        {

            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.IsDepositNo == true && TRC.DepositDate == Vdt_DepositDate)
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

                        }).OrderBy(x => x.BranchID).Take(200).ToList();
            dataGridView4.DataSource = list;


        }
        private void Grd3TrCollectionDrDep(DateTime Vdt_DepositDate, int Vint_ReceivedKindID)
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.IsDepositNo == true && TRC.DepositDate == Vdt_DepositDate)
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

                        }).OrderBy(x => x.BranchID).Take(30).ToList();
            dataGridView4.DataSource = list;
            if (list != null)
            {

            }


        }
        private void GrdTrCollectionBr()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.IsDepositNo == false)
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
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.BranchID).Take(30).ToList();
            dataGridView2.DataSource = list;
            if (list.Count > 0)
            {
                TotalChequeCollection();
                LoadSerial2();
                GrdTRCollctionCheq();
            }

        }

        private void GrdTrCollectionDateBr(DateTime Vdt_DepositTrcollection)
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.DepositDate == Vdt_DepositTrcollection)
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
                            Name = BNK.Name,
                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo,

                        }).OrderBy(x => x.BranchID).Take(30).ToList();
            //if (dataGridView2.Rows.Count == 0)
            //{ AddColumnDtaGrd2(); }

            DgrTrCollectionFalseDeposit();
            GrdTRCollctionCheq();
            //TotalChequeCollection();
        }
        private void GrdTrCollectionDr()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                            //join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                        where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID)
                        select new
                        {
                            ID = TRC.ID,
                            BranchID = TRC.BranchID,
                            BranchName = MNG.BrancheName,
                            TradeCollectionNo = TRC.TradeCollectionNo,
                            CollectionNo = TRC.CollectionNo,
                            CollectionDate = TRC.CollectionDate,
                            BankDepositeID = TRC.BankDepositeID,
                            BankAccountID = TRC.BankAccounNoID,

                            RepresentiveID = TRC.RepresentiveID,
                            ReceiptNo = TRC.ReceiptNo

                        }).OrderBy(x => x.BranchID).Take(30).ToList();
            dataGridView2.DataSource = list;
            if (list.Count > 0)
            {
                TotalChequeCollection();
                LoadSerial2();
                GrdTRCollctionCheq();
            }
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
                dataGridView2.Columns["Name"].HeaderText = "البنك";

                dataGridView2.Columns["BranchName"].HeaderText = "الفرع / الجهه";
                dataGridView2.Columns["BranchName"].Width = 120;
                dataGridView2.Columns["TradeCollectionNo"].HeaderText = "رقم الحافظه بالتجاري";
                dataGridView2.Columns["CollectionNo"].HeaderText = "رقم الحافظه";
                dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ الحافظه";
                dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
                //dataGridView2.Columns["CollectionDate"].
                dataGridView2.Columns["CollectionNo"].Width = 150;
                dataGridView2.Columns["CountChq"].Width = 50;
                dataGridView2.Columns["TotalAmountChq"].Width = 100;
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

            dataGridView1.Columns["BankName"].HeaderText = "البنك";



        }
        private void checkData()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {

                //groupControl1.Text = "بيانات الحافظه";
                //groupControl3.Text = "بيانات الحوافظ";
                //groupControl4.Text = "بيانات شيكات الحوافظ";
                label11.Text = "الفرع";
                //label2.Text = "رقم الحافظه";
                groupControl1.Visible = false;
                //label1.Visible = false;
                label2.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
                txtCollectionNo.Visible = false;
                //dTPCollection.Visible = true;
                label4.Visible = false;
                //txtBnkDeposit.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                //cmbAccountBank.Visible = false;
                txtAccountBnk.Visible = false;
                label10.Visible = false;
                txtRepresentive.Visible = false;


            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                groupControl1.Text = "بيانات الجهه";
                groupControl3.Text = "بيانات مستندات الجهات";
                groupControl4.Text = "بيانات شيكات الجهات";
                label11.Text = "الخزينه الرئيسيه";
                //label2.Text = "رقم الحافظه";
                label2.Visible = true;
                label3.Visible = true;
                groupControl1.Visible = true;
                txtBranch.Text = "الخزينه الرئيسيه";
                txtBranchID.Text = "180";
                label3.Text = "تاريخ الايداع";
                txtCollectionNo.Visible = true;
                label4.Visible = true;
                txtBranch.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                dTPCollection.Visible = true;
                label10.Visible = true;
                txtRepresentive.Visible = true;
                txtAccountBnk.Visible = false;
                cmbBnkDeposit.Visible = true;
                txtCollectionNo.Visible = true;

                label20.Visible = false;

                txtAccountBnk.Visible = true;
                txtRepresentive.Visible = true;
                //GrdTrCollectionDr();
            }
        }
        private void checkDataNoData()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {
                groupControl1.Text = "بيانات الحافظه";
                groupControl3.Text = "بيانات الحوافظ";
                groupControl4.Text = "بيانات شيكات الحوافظ";
                label11.Text = "الفرع";
                //label2.Text = "رقم الحافظه";
                label3.Text = "تاريخ الحافظه";
                label2.Visible = true;
                label3.Visible = true;
                txtCollectionNo.Visible = true;
                //dTPCollection.Visible = true;
                label4.Visible = true;
                //txtBnkDeposit.Visible = false;
                label5.Visible = true;
                //cmbAccountBank.Visible = false;
                txtAccountBnk.Visible = true;
                label10.Visible = true;
                txtRepresentive.Visible = true;

                //label17.Visible = true;
                //txtTradeCollectionNO.Visible = true;

                //lblReceiptNo.Visible = true;
                //txtReceiptNo.Visible = true;


            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                groupControl1.Text = "بيانات الجهه";
                groupControl3.Text = "بيانات مستندات الجهات";
                groupControl4.Text = "بيانات شيكات الجهات";
                label11.Text = "الجهه";
                label2.Text = "رقم المستند";
                label2.Visible = true;
                label3.Visible = true;
                label3.Text = "تاريخ المستند";
                txtCollectionNo.Visible = true;
                //dTPCollection.Visible = true;
                label4.Visible = false;
                cmbBnkDeposit.Visible = false;
                //txtBnkDeposit.Visible = false;
                label5.Visible = false;
                //cmbAccountBank.Visible = false;
                label10.Visible = false;
                txtRepresentive.Visible = false;
                txtAccountBnk.Visible = false;
                //label17.Visible = false;
                //txtTradeCollectionNO.Visible = false;

                label20.Visible = false;

                //lblReceiptNo.Visible = false;
                //txtReceiptNo.Visible = false;

            }
        }
        private void ClearDataMaster()
        {
            txtRowID.Text = "";
            txtBnkDepositID.Text = "";
            txtBnkDeposit.Text = "";

            txtAccountBnkID.Text = "";
            //cmbAccountBank.Text = "";
            txtAccountBnk.Text = "";

            txtCollectionNo.Text = "";
            dTPCollection.Value = Convert.ToDateTime(DateTime.Now.ToString());

            //txtBranchID.Text = "";
            //txtBranch.Text = "";

            txtRepresentiveID.Text = "";
            txtRepresentive.Text = "";

            //txtTradeCollectionNO.Text = "";
            //txtReceiptNo.Text = "";

            cmbBnkDeposit.SelectedIndex = -1;
            cmbBnkDeposit.Text = "";
            cmbBnkDeposit.SelectedText = "اختر البنك المودع ";
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


        }

        public class DataGridViewCheckboxCellFilter : DataGridViewCheckBoxCell
        {
            public DataGridViewCheckboxCellFilter() : base()
            {
                this.FalseValue = 0;
                this.TrueValue = 1;
                this.Value = TrueValue;
            }
        }

        private void GetDataChequeBank()
        {



            if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == true)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                //***************

                txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
                //********
                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                //************
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     where (TRC.ChequeReceivedKindID == Vint_ChequeReceivedKindID && TRC.ID == Vlng_TreasuryCollectionID)
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
                                         ParentID = TRC.Parent_ID

                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                //*******************

                textBox2.Text = (listBnkCheque.Count).ToString();
                string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                     where (row.Cells[3].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                     select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                if (Vstr_Count != listBnkCheque.Count.ToString())
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        AddColumnDtaGrd1();
                    }
                    for (int i = 0; i < (listBnkCheque.Count); i++)
                    {


                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                        listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName, listBnkCheque[i].ParentID, true);
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
                            long Vlng_Trcoll = long.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                            if (Vlng_Trcoll == Vlng_TreasuryCollectionID)
                            {
                                dataGridView1.Rows[i].Cells[1].Value = true;
                                dataGridView1.Rows[i].Cells[13].Value = true;
                            }
                        }
                    }
                    catch
                    { }
                }


                //*************

                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
                //************
            }
            else if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == false)
            {
                //******************
                txtSpValueBeforeall.Text = "";
                txtSpTrCollection.Text = "";
                //***************
                //********
                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();
                //*************

                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
                //************
                //************
                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                var V_CountChq = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_TreasuryCollectionID).ToList();
                if (V_CountChq.Count() != 0 && dataGridView1.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        long VintTrCollectionCheq = long.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        long Vlng_BnkChqID = long.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        if (VintTrCollectionCheq == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = false;

                        }

                    }

                }

            }
        }
        //**************حوافظ الخزينه العامه

        private void GetDataChequeBankKhazina()
        {



            if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == true)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
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
                                         ParentID = TRC.Parent_ID

                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                //*******************
                textBox2.Text = (listBnkCheque.Count).ToString();

                string Vstr_Count = (from DataGridViewRow row in dataGridView1.Rows
                                     where (row.Cells[12].Value.ToString() == Vlng_TreasuryCollectionID.ToString())
                                     select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                if (Vstr_Count != listBnkCheque.Count.ToString())
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        AddColumnDtaGrd1();
                    }

                    for (int i = 0; i < (listBnkCheque.Count); i++)
                    {

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.Rows.Add(0, true, listBnkCheque[i].ID, listBnkCheque[i].TreasuryCollectionID, listBnkCheque[i].AmountCheque, listBnkCheque[i].BankDrawnOnID,
                        listBnkCheque[i].ChequeNo, listBnkCheque[i].ChequeDueDate, listBnkCheque[i].DepositedByTrRepresntvID, listBnkCheque[i].CustID, listBnkCheque[i].AddDateBank, listBnkCheque[i].ChequeKind, listBnkCheque[i].BankName, listBnkCheque[i].ParentID, true);
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

                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

                //********
                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                //*************
                //************
            }
            else if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == false)
            {
                //******************
                txtSpValueBeforeall.Text = "";
                txtSpTrCollection.Text = "";
                //***************

                //************
                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                var V_CountChq = (from Trc in FsDb.Tbl_TreasuryCollection
                                  join BnkChq in FsDb.Tbl_BankCheques on Trc.ID equals BnkChq.TreasuryCollectionID
                                  where (Trc.ChequeReceivedKindID == 1 && Trc.Parent_ID == Vlng_TreasuryCollectionID)
                                  select new { Trc.ID, BnkChq.TreasuryCollectionID }).ToList();

                //************
                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

                if (V_CountChq.Count() != 0 && dataGridView1.RowCount > 0)
                {
                    long VintTrCollectionCheq = 0;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[13].Value != null)
                        {

                            //MessageBox.Show(dataGridView1.Rows[i].Cells[13].Value.ToString());
                            VintTrCollectionCheq = long.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
                        }
                        long Vlng_BnkChqID = long.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        if (VintTrCollectionCheq == Vlng_TreasuryCollectionID)
                        {
                            dataGridView1.Rows[i].Cells[1].Value = false;

                        }

                    }

                }
                //********
                txtSpValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                       select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtSpTrCollection.Text = (from DataGridViewRow row in dataGridView2.Rows
                                          where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                          select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                //*************

                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
                //************1

            }
        }

        //*************
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (int.Parse(dataGridView2.CurrentRow.Cells["BranchID"].Value.ToString()) != 180)
            {
                GetDataChequeBank();

            }
            else
            {
                GetDataChequeBankKhazina();
            }
            GrdBnkCheq();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        bool isSelected = Convert.ToBoolean(row.Cells["Column1"].Value);
                        row.Cells["Column1"].Value = 1;

                    }
                }
                catch { }
            }
        }
        private DateTime MRightDateBank(DateTime Vd_ResultRightDateBank)
        {
            DateTime result = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_RightDateBank = Convert.ToDateTime(DateTime.Today.ToString());
            DateTime Vd_AddDateBank = Convert.ToDateTime(DateTime.Today.ToString());
            int Vint_year = 0;
            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                Vd_AddDateBank = Vd_ResultRightDateBank;
                Vint_year = Vd_RightDateBank.Year;
                Vd_RightDateBank = dateAddedStatlment.SelectDateRightDateBank(Vd_AddDateBank.AddDays(1), Vint_year);
                result = Vd_RightDateBank;
            }
            return result;
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
                Vd_RightDateBank = dateAddedStatlment.SelectDateRightDateBank(Vd_AddDateBank, Vint_year);
                result = Vd_RightDateBank;
           return result;
        }
        private void ProcessDepositsAndChequesNew()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dataGridView2.Rows.Count;
            progressBar1.Value = 0; // Start with 0 progress

            DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
            ///////****************تاريخ الايداع 
            Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
            //*********************ايداع الحوافظ المحتاره لليوم المحدد
            long Vlng_ChqBnkID = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                //*****************Progress Bar 
                progressBar1.Value = i + 1;
                progressBar1.Refresh();
                var progress = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);
                label17.Text = ($"Progress: {progress}%");
                using (Graphics gr = progressBar1.CreateGraphics())
                {
                    gr.DrawString(null, SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                }
                int progressPercentage = ((int)i / dataGridView2.Rows.Count) * 100;
                progressBar1.CreateGraphics().DrawString(progressPercentage.ToString() + "%", new Font("Arial", (float)2.1, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));


                Application.DoEvents();
                //********************ID الحافظه
                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
                //***************************  استدعاء بيانات الحافظه للصف الحالي
                var listTrCollection = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_TreasuryCollectionID && x.ChequeReceivedKindID == Vint_ChequeReceivedKindID).ToList();

                var listTrCollectionChild = FsDb.Tbl_TreasuryCollection.Where(x => x.Parent_ID == Vlng_TreasuryCollectionID  ).ToList();
               
                //**************************البنك المودع  وتاريح الايداع

                if (listTrCollection != null)
                {
                    Vint_bankDepositID = int.Parse(dataGridView2.Rows[i].Cells[10].Value.ToString());
                    if (Vint_bankDepositID == 1)
                    { Vint_bankDepositID = 2004; }
                    else if (Vint_bankDepositID == 2013)
                    { Vint_bankDepositID = 2014; }
                    //**************الحوافظ التابعه
                    if (listTrCollectionChild.Count != 0)
                    {
                        
                        listTrCollectionChild[0].BankDepositeID = Vint_bankDepositID;
                        listTrCollectionChild[0].BankAccounNoID = listTrCollection[0].BankAccounNoID;
                        listTrCollectionChild[0].DepositDate = Vdt_DepositDate;
                        listTrCollectionChild[0].IsDepositNo = listTrCollection[0].IsDepositNo;

                    }
                }
                //*******************************************
                Vint_bankDepositID = int.Parse(dataGridView2.Rows[i].Cells[10].Value.ToString());
                if (Vint_bankDepositID == 1)
                { Vint_bankDepositID = 2004; }
                else if (Vint_bankDepositID == 2013)
                { Vint_bankDepositID = 2014; }
                //*******************************************
                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[1].Value) == true)
                {
                    listTrCollection[0].IsDepositNo = true;
                    listTrCollection[0].DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                    //*******************           استدعاء بيانات الشيكات التابعه للخافظه

                    if (listTrCollection[0].BranchID != 180)
                    { Vlng_TreasuryCollectionID = long.Parse(listTrCollection[0].ID.ToString());  }
                    else
                    { Vlng_TreasuryCollectionID = long.Parse(listTrCollectionChild[0].ID.ToString()); }
                     var listCheques = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_TreasuryCollectionID).ToList();
                    
                    foreach (var xx in listCheques)
                    {
                       
                        Vlng_ChqBnkID = xx.ID;
                        xx.ChequeStatusID = 2;
                        xx.IsDepositNo = true;
                        xx.ChequeStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                          //*******************تسجيل حالة وتاريخ الحاله
                        var liststatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2).ToList();
                        if (liststatus.Count == 0)
                        {
                            Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                            {
                                BankChequeStatusID = 2,
                                BankChequeID = Vlng_ChqBnkID,
                                ChequeBankStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString())
                            };

                            FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                        }
                        //******************************حساب تاريخ اضافة الشيك للحساب البنكي


                        DateTime Vd_chequDueDate = Convert.ToDateTime(xx.ChequeDueDate.ToString());
                        Vint_bankdrawnonid = int.Parse(xx.BankDrawnOnID.ToString());
                        if (Vint_bankdrawnonid == 1)
                        { Vint_bankdrawnonid = 2004; }
                        else if (Vint_bankdrawnonid == 2013)
                        { Vint_bankdrawnonid = 2014; }

                        int vacationYear = 2024;//سنة الاجازة

                        DateTime Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                        dateAddedStatlment.PublicvacationYear = vacationYear;
                        result = dateAddedStatlment.SelectDateAddedBank(Vd_chequDueDate, Vdt_DepositDate, Vint_bankDepositID, Vint_bankdrawnonid);
                        //************************احتساب تاريخ حق البنك 
                        DateTime Vd_RightDateBnk = MRightDateBankNew(Convert.ToDateTime(result).AddDays(1));
                        //*****************
                        xx.AddDateBank = Convert.ToDateTime(result);
                        xx.BankDueDate = Vd_RightDateBnk;
                        FsDb.SaveChanges();
                    }
                    FsDb.SaveChanges();
                }
                else if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[1].Value) == false)
                {
                    listTrCollection[0].IsDepositNo = false;
                    //*******************           استدعاء بيانات الشيكات التابعه للخافظه
                    var listCheques = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_TreasuryCollectionID).ToList();
                    foreach (var xx in listCheques)
                    {
                        Vlng_ChqBnkID = xx.ID;
                        xx.ChequeStatusID = 1;
                        xx.IsDepositNo = false;
                        var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2);
                        if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }
                        FsDb.SaveChanges();
                    }
                    FsDb.SaveChanges();
                }

            }
        }
        private void ProcessDepositsAndCheques()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dataGridView2.Rows.Count;
            progressBar1.Value = 0; // Start with 0 progress


            Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
            //*************حفظ ايداع الحوافظ 
            if (Vint_ChequeReceivedKindID == 0)
            {
                dataGridView2.AllowUserToAddRows = false;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    progressBar1.Value = i + 1;
                    progressBar1.Refresh();
                    var progress = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);
                    label17.Text = ($"Progress: {progress}%");
                    using (Graphics gr = progressBar1.CreateGraphics())
                    {
                        gr.DrawString(null, SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    }
                    int progressPercentage = ((int)i / dataGridView2.Rows.Count) * 100;
                    progressBar1.CreateGraphics().DrawString(progressPercentage.ToString() + "%", new Font("Arial", (float)2.1, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));


                    Application.DoEvents();
                    Vlng_TreasuryCollectionID = long.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString());
                    var listTrCollection = FsDb.Tbl_TreasuryCollection.Where(x => x.ID == Vlng_TreasuryCollectionID && x.ChequeReceivedKindID == Vint_ChequeReceivedKindID).ToList();
                    var ListChild = FsDb.Tbl_TreasuryCollection.Where(x => x.Parent_ID == Vlng_TreasuryCollectionID).ToList();
                    //**************************البنك المودع  وتاريح الايداع

                    if (listTrCollection != null)
                    {
                        Vint_bankDepositID = int.Parse(dataGridView2.Rows[i].Cells[10].Value.ToString());
                        if (Vint_bankDepositID == 2004)
                        { Vint_bankDepositID = 1; }
                        else if (Vint_bankDepositID == 2014)
                        { Vint_bankDepositID = 2013; }

                    }
                    //*******************************************
                    if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[1].Value) == true)
                    {
                        listTrCollection[0].IsDepositNo = true;
                        listTrCollection[0].DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                        FsDb.SaveChanges();
                        long? Vlng_ChqBnkID = 0;
                        long? Vlng_trCollBnkCheq = 0;

                        if (ListChild.Count > 0)
                        {
                            //foreach (var xx in ListChild)
                            //{
                            //Vlng_trCollBnkCheq = long.Parse(xx.ID.ToString());
                            //****************الشيكات
                            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                            {
                                Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                                Vlng_trCollBnkCheq = long.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());

                                //******************************حساب تاريخ اضافة الشيك للحساب البنكي

                                DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                                DateTime Vd_chequDueDate = Convert.ToDateTime(dataGridView1.Rows[j].Cells[7].Value.ToString());
                                Vint_bankdrawnonid = int.Parse(dataGridView1.Rows[j].Cells[5].Value.ToString());//تاريخ الاستحقاق


                                int vacationYear = 2024;//سنة الاجازة

                                DateTime Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                dateAddedStatlment.PublicvacationYear = vacationYear;
                                result = dateAddedStatlment.SelectDateAddedBank(Vd_chequDueDate, Vdt_DepositDate, Vint_bankDepositID, Vint_bankdrawnonid);
                                //************************احتساب تاريخ حق البنك 
                                DateTime Vd_RightDateBnk = MRightDateBank(Convert.ToDateTime(result));
                                //*****************
                                var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();

                                if (listBankCheq[0].TreasuryCollectionID == Vlng_trCollBnkCheq)
                                {
                                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView1.Rows[j].Cells[14].Value) == true)
                                    {
                                        var List_trChild = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == Vlng_trCollBnkCheq);
                                        List_trChild.DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                        listBankCheq[0].IsDepositNo = true;
                                        listBankCheq[0].ChequeStatusID = 2;
                                        listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                        if (result != "")
                                        {
                                            listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                            listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                        }

                                        var liststatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2).ToList();
                                        if (liststatus.Count == 0)
                                        {
                                            Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                                            {
                                                BankChequeStatusID = 2,
                                                BankChequeID = Vlng_ChqBnkID,
                                                ChequeBankStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString())
                                            };

                                            FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                                        }
                                        else
                                        {
                                            liststatus[0].BankChequeStatusID = 2;
                                            liststatus[0].BankChequeID = Vlng_ChqBnkID;
                                            liststatus[0].ChequeBankStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                            if (result != "")
                                            {
                                                listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                                listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                            }
                                        }


                                        FsDb.SaveChanges();
                                    }
                                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
                                    {
                                        listBankCheq[0].IsDepositNo = false;
                                        listBankCheq[0].ChequeStatusID = 1;
                                        listBankCheq[0].ChequeStatusDate = listTrCollection[0].AddRecievedDate;
                                        if (result != "")
                                        {
                                            listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                            listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                        }
                                        var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2);
                                        if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }

                                        FsDb.SaveChanges();
                                    }
                                }
                            }
                            //}
                        }
                        else
                        {

                            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                            {
                                Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                                Vlng_trCollBnkCheq = long.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());

                                var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();
                                //******************************حساب تاريخ اضافة الشيك للحساب البنكي

                                DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                                DateTime Vd_chequDueDate = Convert.ToDateTime(dataGridView1.Rows[j].Cells[7].Value.ToString());
                                Vint_bankdrawnonid = int.Parse(dataGridView1.Rows[j].Cells[5].Value.ToString());//تاريخ الاستحقاق


                                int vacationYear = 2024;//سنة الاجازة

                                DateTime Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                dateAddedStatlment.PublicvacationYear = vacationYear;
                                result = dateAddedStatlment.SelectDateAddedBank(Vd_chequDueDate, Vdt_DepositDate, Vint_bankDepositID, Vint_bankdrawnonid);
                                //************************
                                //************************احتساب تاريخ حق البنك 
                                DateTime Vd_RightDateBnk = MRightDateBank(Convert.ToDateTime(result));
                                //*****************
                                if (listBankCheq[0].TreasuryCollectionID == Vlng_trCollBnkCheq)
                                {
                                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView1.Rows[j].Cells[14].Value) == true)
                                    {
                                        listBankCheq[0].IsDepositNo = true;
                                        listBankCheq[0].ChequeStatusID = 2;
                                        listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                        if (result != "")
                                        {
                                            listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                            listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                        }
                                        var liststatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2).ToList();
                                        if (liststatus.Count == 0)
                                        {
                                            Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                                            {
                                                BankChequeStatusID = 2,
                                                BankChequeID = Vlng_ChqBnkID,
                                                ChequeBankStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString())
                                            };

                                            FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                                        }
                                        else
                                        {
                                            liststatus[0].BankChequeStatusID = 2;
                                            liststatus[0].BankChequeID = Vlng_ChqBnkID;
                                            liststatus[0].ChequeBankStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                            if (result != "")
                                            {
                                                listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                                listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                            }
                                        }


                                        FsDb.SaveChanges();
                                    }
                                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
                                    {
                                        listBankCheq[0].IsDepositNo = false;
                                        listBankCheq[0].ChequeStatusID = 1;
                                        listBankCheq[0].ChequeStatusDate = listTrCollection[0].AddRecievedDate;
                                        if (result != "")
                                        { listBankCheq[0].AddDateBank = Convert.ToDateTime(result); }
                                        var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2);
                                        if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }

                                        FsDb.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                    else if (Convert.ToBoolean(dataGridView2.Rows[i].Cells[1].Value) == false)
                    {
                        listTrCollection[0].IsDepositNo = false;
                        listTrCollection[0].DepositDate = null;
                        FsDb.SaveChanges();
                        long? Vlng_ChqBnkID = 0;
                        long? Vlng_trCollBnkCheq = 0;
                        if (ListChild.Count > 0)
                        {
                            foreach (var xx in ListChild)
                            {
                                Vlng_trCollBnkCheq = long.Parse(xx.ID.ToString());
                                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                                {
                                    Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                                    //Vlng_trCollBnkCheq = long.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());
                                    //******************************حساب تاريخ اضافة الشيك للحساب البنكي

                                    DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                                    DateTime Vd_chequDueDate = Convert.ToDateTime(dataGridView1.Rows[j].Cells[7].Value.ToString());
                                    Vint_bankdrawnonid = int.Parse(dataGridView1.Rows[j].Cells[5].Value.ToString());//تاريخ الاستحقاق


                                    int vacationYear = 2024;//سنة الاجازة

                                    DateTime Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                    dateAddedStatlment.PublicvacationYear = vacationYear;
                                    result = dateAddedStatlment.SelectDateAddedBank(Vd_chequDueDate, Vdt_DepositDate, Vint_bankDepositID, Vint_bankdrawnonid);
                                    //************************
                                    //************************احتساب تاريخ حق البنك 
                                    DateTime Vd_RightDateBnk = MRightDateBank(Convert.ToDateTime(result));
                                    //*****************
                                    var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();

                                    if (listBankCheq[0].TreasuryCollectionID == Vlng_trCollBnkCheq)
                                    {
                                        if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false && Convert.ToBoolean(dataGridView1.Rows[j].Cells[14].Value) == true)
                                        {
                                            listBankCheq[0].IsDepositNo = false;
                                            listBankCheq[0].ChequeStatusID = 1;
                                            listBankCheq[0].ChequeStatusDate = listTrCollection[0].AddRecievedDate;
                                            if (result != "")
                                            {
                                                listBankCheq[0].AddDateBank = Convert.ToDateTime(result);

                                                listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                            }
                                            var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2);
                                            if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }
                                            FsDb.SaveChanges();
                                        }
                                        if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
                                        {
                                            listBankCheq[0].IsDepositNo = false;
                                            listBankCheq[0].ChequeStatusID = 1;
                                            listBankCheq[0].ChequeStatusDate = listTrCollection[0].AddRecievedDate;
                                            if (result != "")
                                            {
                                                listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                                listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                            }
                                            var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2);
                                            if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }
                                            FsDb.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.TreasuryCollectionID == Vlng_TreasuryCollectionID).ToList();
                            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                            {
                                Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                                Vlng_trCollBnkCheq = long.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());

                                var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();
                                //******************************حساب تاريخ اضافة الشيك للحساب البنكي

                                DateAddedStatlmentCs dateAddedStatlment = new DateAddedStatlmentCs();
                                DateTime Vd_chequDueDate = Convert.ToDateTime(dataGridView1.Rows[j].Cells[7].Value.ToString());
                                Vint_bankdrawnonid = int.Parse(dataGridView1.Rows[j].Cells[5].Value.ToString());//تاريخ الاستحقاق


                                int vacationYear = 2024;//سنة الاجازة

                                DateTime Vdt_DepositDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                dateAddedStatlment.PublicvacationYear = vacationYear;
                                result = dateAddedStatlment.SelectDateAddedBank(Vd_chequDueDate, Vdt_DepositDate, Vint_bankDepositID, Vint_bankdrawnonid);
                                //************************
                                //************************احتساب تاريخ حق البنك 
                                DateTime Vd_RightDateBnk = MRightDateBank(Convert.ToDateTime(result));
                                //*****************
                                if (listBankCheq[0].TreasuryCollectionID == Vlng_trCollBnkCheq)
                                {
                                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false && Convert.ToBoolean(dataGridView1.Rows[j].Cells[14].Value) == true)
                                    {
                                        listBankCheq[0].IsDepositNo = false;
                                        listBankCheq[0].ChequeStatusID = 1;
                                        listBankCheq[0].ChequeStatusDate = listTrCollection[0].AddRecievedDate;
                                        if (result != "")
                                        {
                                            listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                            listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                        }
                                        var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2);
                                        if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }
                                        FsDb.SaveChanges();
                                    }
                                    if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
                                    {
                                        listBankCheq[0].IsDepositNo = false;
                                        listBankCheq[0].ChequeStatusID = 1;
                                        listBankCheq[0].ChequeStatusDate = listTrCollection[0].AddRecievedDate;
                                        if (result != "")
                                        {
                                            listBankCheq[0].AddDateBank = Convert.ToDateTime(result);
                                            listBankCheq[0].BankDueDate = Vd_RightDateBnk;
                                        }
                                        var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 2);
                                        if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }
                                        FsDb.SaveChanges();
                                    }
                                }
                            }
                        }
                    }

                }
                //splashScreenManager1.CloseWaitForm();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {


                    dataGridView1.Rows[i].Cells[13].Value = false;


                    //dataGridView1.Refresh();
                }
            }
        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 81 && w.ProcdureId == 1);
            if (validationSaveUser == null)
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  حافظه وارده الى الخزينه .. برجاء مراجعة مدير المنظومه");
                return;
            }

            progressBar1.Visible = true;
            ProcessDepositsAndChequesNew();
            progressBar1.Visible = false;
            MessageBox.Show($"تم حفظ ايداع الحوافظ والشيكات يوم {dTPDeposit.Value.ToString("yyyy/MM/dd")}");
        }



        private void radioGroup1_MouseClick(object sender, MouseEventArgs e)
        {
            checkData();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
            txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                    select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
        }
        private void ClearData()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            textBox2.Text = "";
        }


        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Vint_ChequeReceivedKindID == 0)
                { dTPDeposit.Focus(); }
                else if (Vint_ChequeReceivedKindID == 1)
                { dTPCollection.Focus(); }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[1].Value) == true)
            {
                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            }
            else if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[1].Value) == false)
            {
                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            }

        }

        private void cmbBnkDeposit_Leave(object sender, EventArgs e)
        {
            int? Vint_BankDepositeId = 0;
            if (cmbBnkDeposit.SelectedValue != null)
            {
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                if (listAccountBank != null)

                {

                    if (listAccountBank.Count != 0)
                    {
                        txtAccountBnk.Text = listAccountBank[0].AccountBankNo;
                        if (listAccountBank.Count == 1)
                        {
                            txtAccountBnkID.Text = listAccountBank[0].ID.ToString();
                        }
                        else
                        {
                            txtAccountBnkID.Text = "";
                        }
                    }
                }
            }
        }

        private void dTPCollection_Leave(object sender, EventArgs e)
        {
            int? Vint_BranchID = 0;
            DateTime? vdate_CollectionDate = null;
            DateTime Vdt_TodaySrv = Convert.ToDateTime(GetServerDate.Cs_GetServerDate());
            var list = FsDb.Tbl_TreasuryCollection.Where(x => x.CollectionDate == Vdt_TodaySrv && x.ChequeReceivedKindID == 1).ToList();
            if (list.Count == 0)
            {
                Vint_BranchID = 180;
                vdate_CollectionDate = Convert.ToDateTime(dTPCollection.Value.ToString());
                int Vint_FYear = int.Parse(comboBox3.SelectedValue.ToString());
                int Vint_CountBrunch = FsDb.Tbl_TreasuryCollection.Distinct().Where(x => x.FYear == Vint_FYear && x.ChequeReceivedKindID == 1).Count();
                txtCollectionNo.Text = comboBox3.SelectedText + "/" + "180" + "/" + (Vint_CountBrunch + 1);
            }
            else
            {
                txtCollectionNo.Text = list[0].CollectionNo.ToString();
            }
        }

        private void dTPCollection_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBnkDeposit.Focus();
            }
        }

        private void cmbBnkDeposit_Leave_1(object sender, EventArgs e)
        {

            if (cmbBnkDeposit.SelectedValue != null)
            {
                int? Vint_BankDepositeId = 0;
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                if (listAccountBank != null)

                {
                    txtAccountBnkID.Text = "";

                    if (listAccountBank.Count != 0)
                    {
                        txtAccountBnk.Text = listAccountBank[0].AccountBankNo;
                        if (listAccountBank.Count == 1)
                        {
                            txtAccountBnkID.Text = listAccountBank[0].ID.ToString();
                        }
                        else
                        {
                            txtAccountBnkID.Text = "";
                        }
                    }
                }
            }
        }

        private void cmbBnkDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRepresentive.Focus();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearData();
            Vint_ChequeReceivedKindID = comboBox1.SelectedIndex;
            checkData();
            if (Vint_ChequeReceivedKindID == 0)
            {
                checkData();

                Grd3TrCollectionBrFalseDep();

                //if (dataGridView2.Rows.Count == 0)
                //{ AddColumnDtaGrd2(); }
                DgrTrCollectionFalseDeposit();
                GrdTRCollctionCheq();
                TotalChequeCollection();
            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                Grd3TrCollectionDrFalseDep();
                DgrTrCollectionFalseDeposit();
                GrdTRCollctionCheq();
                TotalChequeCollection();

                //Grd3TrCollectionDrDep(Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy/MM/dd")));
            }
            //if (dataGridView1.Rows.Count == 0)
            //{ AddColumnDtaGrd1(); }

            //DgrTrCollectionDeposit();
            //GrdTRCollctionCheq();
        }

        private void cmbBnkDeposit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbBnkDeposit.SelectedValue != null)
            {
                int? Vint_BankDepositeId = 0;
                Vint_BankDepositeId = int.Parse(cmbBnkDeposit.SelectedValue.ToString());
                var listAccountBank = FsDb.Tbl_AccountsBank.Where(x => x.BankID == Vint_BankDepositeId && x.KindAccountBankID == 1).ToList();
                if (listAccountBank != null)

                {
                    txtAccountBnkID.Text = "";

                    if (listAccountBank.Count != 0)
                    {
                        txtAccountBnk.Text = listAccountBank[0].AccountBankNo;
                        if (listAccountBank.Count == 1)
                        {
                            txtAccountBnkID.Text = listAccountBank[0].ID.ToString();
                        }
                        else
                        {
                            txtAccountBnkID.Text = "";
                        }
                    }
                }
            }
        }

        private void progressBar1_ParentChanged(object sender, EventArgs e)
        {
            //progressBar1.Parent = ((Control)sender).Parent;
        }
    }
}
