
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

namespace FinancialSysApp.Forms.Banks
{
    public partial class ChequeBankStatusFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();

        int? Vint_ChequeReceivedKindID = null;

        //long? Vlng_LastRowTreasuryCollection = 0;
        DateTime? Vdt_DepositDate = null;

        long Vlng_TreasuryCollectionID = 0;
        public ChequeBankStatusFrm()
        {
            InitializeComponent();
            //dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void ChequeBankStatusFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);
            // TODO: This line of code loads data into the 'bankCheques.Tbl_Banks' table. You can move, or remove it, as needed.
       

            cmbDepositBank.SelectedIndex = -1;
            cmbDepositBank.Text = "";
            cmbDepositBank.SelectedText = "اختر البنك المودع ";

            dTPAddBank.Select();
            this.ActiveControl = dTPAddBank;
            dTPAddBank.Focus();

        }

        private void DgrTrCollectionNotAdd()
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
               

                dataGridView2.AllowUserToAddRows = true;
                dataGridView2.Rows.Add(0, false, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;


                //LoadSerial2();
            }

            //*******************
            if (dataGridView2.RowCount > 0)
            {
                //txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                //                                        select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                //txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
                //                                select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

                ////************
            }
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
                                 where ( BnkChq.ChequeStatusID == 2)
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
                                     ParentID = TRC.Parent_ID ,
                                    
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
            dataGridView1.Columns["ChequeNo"].HeaderText = "رقم الشيك";

            dataGridView1.Columns["ParentID"].Visible = false;
            dataGridView1.Columns["ParentID"].HeaderText = "الحافظه الام";

            dataGridView1.Columns["BankName"].HeaderText = "البنك";



        }

        private void GetDataChequeBank()
        {



            if (Convert.ToBoolean(dataGridView2.CurrentRow.Cells[1].Value) == true)
            {

                Vlng_TreasuryCollectionID = long.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());

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

        private void DgrTrCollectionNotADD()
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
                dataGridView2.Rows.Add(0, false, 0, 0, Vint_ID, Vint_BranchID, Vst_BranchName, Vst_TradeCollectionNo, Vst_CollectionNo
                , Vdt_CollectionDate, Vint_BankDepositeID, Vint_BankAccountID, Vst_BNameAcc, Vst_Name, Vint_RepresentiveID, Vst_ReceiptNo);
                dataGridView2.AllowUserToAddRows = false;


                //LoadSerial2();
            }

            //*******************
            //if (dataGridView2.RowCount > 0)
            //{
            //    txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
            //                                            select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //    txtAllTrCollectionCount.Text = (from DataGridViewRow row in dataGridView2.Rows
            //                                    select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            //    ////************
            //}
        }

        private void Grd3TrCollectionNotADD()
        {
            var list = (from TRC in FsDb.Tbl_TreasuryCollection
                        join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                        join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                        join CheqBank in FsDb.Tbl_BankCheques on TRC.ID equals CheqBank.TreasuryCollectionID
                        where (TRC.ChequeReceivedKindID == 0 && TRC.IsDepositNo == true && CheqBank.ChequeStatusID == 2)
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

                        }).OrderBy(x => x.ID).Take(30).ToList();
            dataGridView3.DataSource = list;


        }

        private void Grd3TrCollectionADDBank(DateTime Vdt_addDateBank , int? Vint_depositBank)
        {
            var listCheqAddBanktodate = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         where (BnkChq.AddDateBank == Vdt_addDateBank  && TRC.BankDepositeID == Vint_depositBank && BnkChq.ChequeStatusID == 3)
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
                                             ReceiptNo = TRC.ReceiptNo,
                                             IsDisposed = BnkChq.IsDepositNo,
                                             ParentID = TRC.Parent_ID
                                         }).ToList();
            
                dataGridView1.DataSource = listCheqAddBanktodate;
            } 
       
        private void cmbDepositBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            { dataGridView1.Rows.Clear(); }
            //if (dataGridView2.Rows.Count != 0)
            //{
            //    dataGridView2.Rows.Clear();
            //}
            //************retrieve data of BankCheqees  add date       الشيكات التي تم اضافتها الى الحساب البنكي في هذا التاريخ
            DateTime Vdt_addDateBank = Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd"));
            int? Vint_depositBank = int.Parse(cmbDepositBank.SelectedValue.ToString());
            Grd3TrCollectionADDBank(Vdt_addDateBank, Vint_depositBank);
            if (dataGridView3.Rows.Count != 0)
            {

                Grd3TrCollectionNotADD();
                GrdBankCheqData();
            }
            else
            {
                Grd3TrCollectionNotADD();
                GrdBankCheqData();
            }
            //groupControl3.Text = $"بيانات الشيكات والتي تم/ لم يتم  اضافتها بتاريخ {dTPAddBank.Value.ToString("yyyy/MM/dd")} بالبنك {listCheqAddBanktodate[0].BankName.ToString()}";


        }

        private void dTPAddBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime Vdt_addDateBank = Convert.ToDateTime(dTPAddBank.Value.ToString("yyyy/MM/dd"));
                Grd3TrCollectionADDBank(Vdt_addDateBank, null);
                if (dataGridView1.Rows.Count != 0)
                { dataGridView1.Rows.Clear(); }
                if (dataGridView2.Rows.Count != 0)
                {
                    dataGridView2.Rows.Clear();
                }
                //***************الشيكات التي تم اضافتها في هذا التاريخ

                //if (dataGridView3.Rows.Count != 0)
                //{
                    
                //    Grd3TrCollectionNotADD();
                //    GrdBankCheqData();
                //}
                //else
                //{
                //    Grd3TrCollectionNotADD();
                //    GrdBankCheqData();
                //}

                groupControl3.Text = $"بيانات الشيكات والتي تم/ لم يتم  اضافتها بتاريخ {dTPAddBank.Value.ToString("yyyy/MM/dd")}";
                cmbDepositBank.Focus();
            }
        }
    }

}
