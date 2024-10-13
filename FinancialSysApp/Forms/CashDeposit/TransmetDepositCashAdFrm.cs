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

namespace FinancialSysApp.Forms.CashDeposit
{
    public partial class TransmetDepositCashAdFrm : DevExpress.XtraEditors.XtraForm
    {
        string Vst_DepositDate1 = DateTime.Today.ToString();
        string Vst_DepositDate2 = DateTime.Today.ToString();
        int Vint_BankID = 0;
        int Vint_bankAccid = 0;
        int Vint_DepositCashID = 0;
        long Vlng_ChqBnkID = 0;
        //int Vint_MovementID = 0;

        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public TransmetDepositCashAdFrm()
        {
            InitializeComponent();
        }

        private void TransmetBankAddAccBank_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_MovementBankType' table. You can move, or remove it, as needed.
            this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            // TODO: This line of code loads data into the 'bankTransmentDS.Tbl_MovementBankType' table. You can move, or remove it, as needed.
            //this.tbl_MovementBankTypeTableAdapter.FillParentNull(this.bankTransmentDS.Tbl_MovementBankType);
            int Vint_BankMType = int.Parse(comboBox3.SelectedValue.ToString());
            //this.tbl_MovementBankTypeTableAdapter1.FillByParent(this.bankTransmentDS.Tbl_MovementBankType, Vint_BankMType);
            // TODO: This line of code loads data into the 'bankCheques.Dtb_Banks' table. You can move, or remove it, as needed.
            this.dtb_BanksTableAdapter.FillByBankKind(this.bankCheques.Dtb_Banks);

            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "اختر البنك ";

            comboBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر رقم الحساب ";

            comboBox3.Text = "";
            comboBox3.SelectedValue = 10;
            var listType1 = FsDb.Tbl_MovementBankType.Where(x => x.MoveType == 10).ToList();
            if (listType1.Count > 0)
            {

                comboBox4.DataSource = listType1;
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "ID";

            }

            comboBox4.Text = "";
            comboBox4.SelectedValue = 12;


            //AddColumnDtaGrd1();

            comboBox4.Select();
            this.ActiveControl = comboBox4;
            comboBox4.Focus();
        }
        private void AddColumnDtaGrd1()
        {
            // Create a new columns datadridview1
            DataGridViewTextBoxColumn newColumnID = new DataGridViewTextBoxColumn();

            // Set the properties of the new column
            newColumnID.HeaderText = "ID"; // Header text of the column
            newColumnID.Name = "ID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnID);

            DataGridViewTextBoxColumn newColumnTransferValue = new DataGridViewTextBoxColumn();
            newColumnTransferValue.Name = "TransferValue"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnTransferValue);

            DataGridViewTextBoxColumn newColumnMoveDat = new DataGridViewTextBoxColumn();
            newColumnMoveDat.Name = "MoveDat"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnMoveDat);

            DataGridViewTextBoxColumn newColumnBankDueDate = new DataGridViewTextBoxColumn();
            newColumnBankDueDate.Name = "BankDueDate"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBankDueDate);

            DataGridViewTextBoxColumn newColumnDescriptionNote = new DataGridViewTextBoxColumn();
            newColumnDescriptionNote.Name = "DescriptionNote"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnDescriptionNote);

           

            DataGridViewTextBoxColumn newColumnDebitCredit = new DataGridViewTextBoxColumn();
            newColumnDebitCredit.Name = "DebitCredit"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnDebitCredit);

            DataGridViewTextBoxColumn newColumnBalance = new DataGridViewTextBoxColumn();
            newColumnBalance.Name = "Balance"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBalance);

            DataGridViewTextBoxColumn newColumnBankID = new DataGridViewTextBoxColumn();
            newColumnBankID.Name = "BankID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBankID);

            DataGridViewTextBoxColumn newColumnBankAccID = new DataGridViewTextBoxColumn();
            newColumnBankAccID.Name = "BankAccID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnBankAccID);

            DataGridViewTextBoxColumn newColumnMovementCode = new DataGridViewTextBoxColumn();
            newColumnMovementCode.Name = "MovementCode"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnMovementCode);
            //*****************
            DataGridViewTextBoxColumn newColumnMoveType1 = new DataGridViewTextBoxColumn();
            newColumnMoveType1.Name = "MoveType1"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnMoveType1);

           

            DataGridViewTextBoxColumn newColumBankDeposit = new DataGridViewTextBoxColumn();
            newColumBankDeposit.Name = "BankDeposit"; // Unique name of the column
            newColumBankDeposit.Visible = true;
            dataGridView2.Columns.Add(newColumBankDeposit);

            DataGridViewTextBoxColumn newColumnMoveType2 = new DataGridViewTextBoxColumn();
            newColumnMoveType2.Name = "MoveType2"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnMoveType2);

            DataGridViewTextBoxColumn newColumnIsSelectedType = new DataGridViewTextBoxColumn();
            newColumnIsSelectedType.Name = "IsSelectedType"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnIsSelectedType);



            DataGridViewTextBoxColumn newColumnDepositCashID = new DataGridViewTextBoxColumn();
            newColumnDepositCashID.Name = "DepositCashID"; // Unique name of the column
            dataGridView2.Columns.Add(newColumnDepositCashID);

             


            DataGridViewCheckBoxColumn newColumnCheqTrue = new DataGridViewCheckBoxColumn();
            newColumnCheqTrue.Name = "Cheq2True"; // Unique name of the column
            newColumnCheqTrue.Visible = false;
            dataGridView2.Columns.Add(newColumnCheqTrue);

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


                comboBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "اختر رقم الحساب ";

                //comboBox3.Text = "";
                //comboBox3.SelectedIndex = -1;
                //comboBox3.Text = "اختر التصنيف الرئيسي ";

                //comboBox4.Text = "";
                //comboBox4.SelectedIndex = -1;
                //comboBox4.Text = "اختر التصنيف الفرعي ";

                comboBox1.Focus();

                if (comboBox2.SelectedValue != null)
                {
                    int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                    //int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());


                    this.dtpDepositCashTableAdapter.FillByDatesBank(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid);
                    LoadSerial();
                    txtAllValue.Text = "";
                    txtAllCount.Text = "";
                    txtSpAllValue.Text = "";
                    txtSpAllCount.Text = "";
                    GrdTotalValue();
                    comboBox1.Focus();
                }
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
        private void LoadSerial1()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
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
                //comboBox5.SelectedIndex = -1;
                //comboBox5.Text = "اختر نوع العملية";
                //    comboBox5.DisplayMember = list_KindPr.ToString();
                //    comboBox5.ValueMember = list_KindPr.ToString();
                //}
                if (comboBox1.SelectedValue != null)
                { Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString()); }
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                //int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());


                this.dtpDepositCashTableAdapter.FillByDatesBankAcc(this.depositCashDS.DtpDepositCash, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vint_bankAccid);
                LoadSerial();
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                txtSpAllValue.Text = "";
                txtSpAllCount.Text = "";
                GrdTotalValue();
                //dataGridView2.Columns["Ser2"].Visible = false;
                if (Vint_BankID == 2014)
                {
                    simpleButton1.Enabled = true;
                    simpleButton2.Enabled = true;
                    simpleButton3.Enabled = true;
                }
                simpleButton1.Focus();
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
        private Boolean DgrChequesTrueDepositAmountCh(int Vint_Bank, int Vint_bankAccid, Decimal Vd_AmountDC, DateTime Vd_depositDate1, DateTime Vd_depositDate2,long Vint_DepositCashID)
        {
            Boolean Vb_Action = false;

            var listBnkMovement = (from bnkMov in FsDb.Tbl_BankMovement

                                 join BNK in FsDb.Tbl_Banks on bnkMov.BankID equals BNK.ID
                                 //join movType in FsDb.Tbl_MovementBankType on bnkMov.MoveType1 equals movType.ID
                                 //join movType2 in FsDb.Tbl_MovementBankType on bnkMov.MoveType2 equals movType2.ID
                                 where ((bnkMov.MoveDat >= Vd_depositDate1 && bnkMov.MoveDat <= Vd_depositDate2) && bnkMov.BankID == Vint_Bank && bnkMov.BankAccID == Vint_bankAccid&& bnkMov.TransferValue == Vd_AmountDC)
                                 select new

                                 {
                                     ID = bnkMov.ID,
                                     MoveDat = bnkMov.MoveDat,
                                     BankDueDate = bnkMov.BankDueDate,
                                     DescriptionNote = bnkMov.DescriptionNote,
                                     TransferValue = bnkMov.TransferValue,
                                     DebitCredit = bnkMov.DebitCredit,
                                     Balance = bnkMov.Balance,
                                     BankID = bnkMov.BankID,
                                     BankAccID = bnkMov.BankAccID,
                                     MovementCode = bnkMov.MovementCode,
                                     MoveType1 = bnkMov.MoveType1,
                                     BankName = BNK.Name,
                                     MoveType2 = bnkMov.MoveType2,
                                     IsSelectedType = bnkMov.IsSelectedType,


                                     DepositCashID = bnkMov.DepositCashID,


                                 }).OrderBy(x => x.MoveDat).ToList();
          
            if (listBnkMovement.Count == 1)
            {
                long Vint_MovID = listBnkMovement[0].ID;
                //var ListBnkMov = FsDb.Tbl_BankMovement.Where(x => x.ID == Vint_MovID).ToList();
                //ListBnkMov[0].DepositCashID = Vint_DepositCashID;
                //FsDb.SaveChanges();
                dataGridView3.DataSource = listBnkMovement;
                
                DgrCheqAndAdded();
                //GrdBnkCheq();
                //LoadSerial1();
                Vb_Action = true;


                
            }
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
                //GrdBnkCheq();
                LoadSerial1();
                Vb_Action = true;
            }
            return Vb_Action;
        }

        private void DgrCheqAndAdded()
        {

            dataGridView2.SuspendLayout();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                

                //************** Declare 
                int Vint_ID = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());

           var ListMov =     (from bnkMov in FsDb.Tbl_BankMovement

                 join BNK in FsDb.Tbl_Banks on bnkMov.BankID equals BNK.ID
                 
                 where (bnkMov.ID == Vint_ID)
                 select new

                 {
                     ID = bnkMov.ID,
                     MoveDat = bnkMov.MoveDat,
                     BankDueDate = bnkMov.BankDueDate,
                     DescriptionNote = bnkMov.DescriptionNote,
                     TransferValue = bnkMov.TransferValue,
                     DebitCredit = bnkMov.DebitCredit,
                     Balance = bnkMov.Balance,
                     BankID = bnkMov.BankID,
                     BankAccID = bnkMov.BankAccID,
                     MovementCode = bnkMov.MovementCode,
                     MoveType1 = bnkMov.MoveType1,
                     BankName = BNK.Name,
                     MoveType2 = bnkMov.MoveType2,
                     IsSelectedType = bnkMov.IsSelectedType,


                     DepositCashID = bnkMov.DepositCashID,


                 }).OrderBy(x => x.MoveDat).ToList();

               
                for (int j = 0; j < (ListMov.Count); j++)
                {

                    dataGridView2.AllowUserToAddRows = true;
                    dataGridView2.Rows.Add(0, true, ListMov[j].ID, ListMov[j].TransferValue, ListMov[j].MoveDat, ListMov[j].BankDueDate, ListMov[j].DescriptionNote,
                     ListMov[j].DebitCredit, ListMov[j].Balance, ListMov[j].BankID, ListMov[j].BankAccID, ListMov[j].MovementCode, ListMov[j].MoveType1, ListMov[j].BankName, ListMov[j].MoveType2, ListMov[j].IsSelectedType,
                   ListMov[j].DepositCashID , true
                  );
                    dataGridView2.AllowUserToAddRows = false;
                }
                LoadSerial();
                //ColorSt();
            }
            dataGridView2.ResumeLayout();
            GrdBnkCheq();
            GrdTotalValue();
            //ColorSt();

        }
        private void GrdBnkCheq()
        {


            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["IsSelectedType"].Visible = true;
            
            

            dataGridView2.Columns["TransferValue"].HeaderText = "مبلغ الايداع";
            dataGridView2.Columns["TransferValue"].Width = 120;

            //dataGridView2.Columns["AddDateBank"].HeaderText = "تاريخ الاضافه";
            //dataGridView2.Columns["AddDateBank"].DefaultCellStyle.Format = "yyyy/MM/dd";
            
            

            dataGridView2.Columns["MoveDat"].HeaderText = "تاريخ الايداع";
            dataGridView2.Columns["MoveDat"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView2.Columns["DebitCredit"].HeaderText = "نوع العمليه";


            dataGridView2.Columns["Balance"].Visible = true;
            dataGridView2.Columns["Balance"].HeaderText = "الرصيد ";

            //dataGridView2.Columns["BankName"].HeaderText = "البنك المسحوب عليه";

            dataGridView2.Columns["MovementCode"].HeaderText = "كود الايداع";
            dataGridView2.Columns["MovementCode"].ReadOnly = true;
            

            dataGridView2.Columns["DescriptionNote"].HeaderText = "وصف الحركه";
            dataGridView2.Columns["DescriptionNote"].ReadOnly = true;

            dataGridView2.Columns["BankID"].Visible = false;
            dataGridView2.Columns["BankAccID"].Visible = false;

            dataGridView2.Columns["MoveType1"].Visible = false;
            dataGridView2.Columns["MoveType2"].Visible = false;

            dataGridView2.Columns["BankDeposit"].Visible = true;
            dataGridView2.Columns["BankDeposit"].HeaderText = "البنك";
            //dataGridView2.Columns["BankDeposit"].ReadOnly = true;
            dataGridView2.Columns["BankDeposit"].Width = 200;
            dataGridView2.Columns["DepositCashID"].Visible = false;

            
            //dataGridView2.Columns["AddDateAccBank"].ReadOnly = true;
            //dataGridView2.Columns["AddDateAccBank"].DefaultCellStyle.Format = "yyyy/MM/dd";

            dataGridView2.Columns["BankDueDate"].HeaderText = "تاريخ حق البنك";
            dataGridView2.Columns["BankDueDate"].ReadOnly = true;
            dataGridView2.Columns["BankDueDate"].DefaultCellStyle.Format = "yyyy/MM/dd";





        }
    
  
      
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                retrieveDataTransmet();
                simpleButton1.Enabled = true;
                simpleButton1.Focus();
            }
        }
        private void retrieveDataTransmet()
        {
            Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
            Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
            DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
            DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
            int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
            int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
            //string Vst_SearhNote = txtSearch.Text;

            //string Vst_ProcessKind = comboBox5.Text;
            //this.dataTable1TableAdapter.FillByBankAccBankSearchNote(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_SearhNote, Vint_bankAccid, Vst_ProcessKind);
            txtAllValue.Text = "";
            txtAllCount.Text = "";
            txtSpAllValue.Text = "";
            txtSpAllCount.Text = "";
            GrdTotalValue();
        }
        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 1 && e.RowIndex >= 0)
        //        this.dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //}

        //private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        dataGridView2.CurrentRow.Cells[1].Value = true;
        //        Grd1TotalValue();

        //    }
        //}



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
                    //dataGridView2.Visible = true;
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
                if (Vint_MovBnkType == 12)
                {
                    dataGridView1.Visible = true;
                    //dataGridView2.Visible = false;
                }
                else if (Vint_MovBnkType == 12)
                {

                    //dataGridView2.Visible = true;
                    dataGridView1.Visible = false;

                }
                dTPDeposit.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ////************اضافة الشيكات
            int Vint_MovBnkTypeM = int.Parse(comboBox3.SelectedValue.ToString());
            int Vint_MovBnkType = int.Parse(comboBox4.SelectedValue.ToString());



            //if (dataGridView1.Rows.Count > 0 && Vint_MovBnkTypeM == 2 && Vint_MovBnkType == 8)
            //{
            //    //**************progress bar
            //    progressBar2.Minimum = 0;
            //    progressBar2.Maximum = dataGridView1.Rows.Count;
            //    progressBar2.Value = 0; // Start with 0 progress
            //    int i = 0;
            //    string Vst_ChqBnkNo = "";
            //    for (int j = 0; j < dataGridView1.Rows.Count; j++)
            //    {
            //        //*****************Progress Bar 
            //        i = i + 1;
            //        if (i < dataGridView1.Rows.Count)
            //        {
            //            progressBar2.Value = i + 1;
            //            progressBar2.Refresh();
            //            var progress = (int)((double)progressBar2.Value / progressBar2.Maximum * 100);

            //            using (Graphics gr = progressBar2.CreateGraphics())
            //            {
            //                gr.DrawString(null, SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar2.Width / 2 - 10, progressBar2.Height / 2 - 7));
            //            }
            //            int progressPercentage = ((int)i / dataGridView1.Rows.Count) * 100;
            //            progressBar2.CreateGraphics().DrawString(progressPercentage.ToString() + "%", new Font("Arial", (float)2.1, FontStyle.Regular), Brushes.Black, new PointF(progressBar2.Width / 2 - 10, progressBar1.Height / 2 - 7));

            //            label21.Text = ($"Progress: {progress}%");
            //            Application.DoEvents();
            //        }
            //        //**********************************كود الشيك 
            //        Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells["ID"].Value.ToString());
            //        Vst_ChqBnkNo = dataGridView1.Rows[j].Cells["ChequeNo"].Value.ToString();
            //        //***********************بيانات الشيك
            //        var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();
            //        if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView1.Rows[j].Cells["CheqTrue"].Value) == true)
            //        {
            //            listBankCheq[0].IsAddedAccNo = true;
            //            listBankCheq[0].ChequeStatusID = 3;
            //            listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            //            //listBankCheq[0].TradeCollectionNo = txtBankAccPaperNo.Text;
            //            listBankCheq[0].AddDateAccBank = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            //            var listCheqStatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 3).ToList();
            //            if (listCheqStatus.Count == 0)
            //            {
            //                Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
            //                {
            //                    BankChequeStatusID = 3,
            //                    BankChequeID = Vlng_ChqBnkID,

            //                    ChequeBankStatusDate = Convert.ToDateTime(dateTimePicker1.Value.ToString())
            //                };

            //                FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
            //                FsDb.SaveChanges();
            //            }
            //            else
            //            {
            //                listCheqStatus[0].ChequeBankStatusDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            //                FsDb.SaveChanges();
            //            }


            //        }
            //        else if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
            //        {
            //            //var V_listTRCollection = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == listBankCheq[0].TreasuryCollectionID);
            //            listBankCheq[0].IsAddedAccNo = false;
            //            listBankCheq[0].ChequeStatusID = 2;
            //            //listBankCheq[0].AddDateBank = null;
            //            listBankCheq[0].AddDateAccBank = null;
            //            listBankCheq[0].TradeCollectionNo = "";
            //            listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            //            var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 3);
            //            if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }

            //            FsDb.SaveChanges();
            //        }




            //        //***************كشف الحساب
            //        int vint_MovBankId = 0;
            //        var List_bankMove = FsDb.Tbl_BankMovement.Where(x => x.C1 == Vst_ChqBnkNo).ToList();
            //        vint_MovBankId = int.Parse(List_bankMove[0].BankID.ToString());
            //        bool Vbl_Checked = true;

            //        if (Vbl_Checked == true)
            //        {
            //            List_bankMove[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
            //            if (comboBox4.SelectedValue != null)
            //            { List_bankMove[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString()); }
            //            List_bankMove[0].IsSelectedType = true;
            //            List_bankMove[0].BankCheqID = Vlng_ChqBnkID;

            //            FsDb.SaveChanges();
            //        }
            //        //else if (Vbl_Checked == false)
            //        //{
            //        //List_bankMove[0].MoveType1 = null;
            //        //List_bankMove[0].MoveType2 = null;
            //        //List_bankMove[0].IsSelectedType = false;
            //        //    FsDb.SaveChanges();
            //        //}
            //        //---------------خفظ ااحداث 
            //        SecurityEvent sev = new SecurityEvent
            //        {
            //            ActionName = "اضافة الشيكات من  كشف حساب بنك",
            //            TableName = "Tbl_BankMovement",
            //            TableRecordId = List_bankMove[0].ID.ToString(),
            //            Description = "",
            //            ManagementName = Program.GlbV_Management,
            //            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
            //            EmployeeName = Program.GlbV_EmpName,
            //            User_ID = Program.GlbV_UserId,
            //            UserName = Program.GlbV_UserName,
            //            FormName = "شاشة شيكات من كشف حساب بنك"

            //        };

            //        FsEvDb.SecurityEvents.Add(sev);
            //        FsEvDb.SaveChanges();
            //        //************************************
            //    }
            //}
            //if (dataGridView5.Rows.Count > 0 && Vint_MovBnkTypeM == 10 && Vint_MovBnkType == 12)
            //{
            //    //************اضافة نقديه
            //    long Vlng_CashDepID = 0;
            //    //    //**************progress bar
            //    progressBar2.Minimum = 0;
            //    progressBar2.Maximum = dataGridView2.Rows.Count;
            //    progressBar2.Value = 0; // Start with 0 progress
            //    int i = 0;
            //    for (int j = 0; j < dataGridView5.Rows.Count; j++)
            //    {
            //        //        //*****************Progress Bar 
            //        i = i + 1;
            //        if (i < dataGridView1.Rows.Count)
            //        {
            //            progressBar2.Value = i + 1;
            //            progressBar2.Refresh();
            //            var progress = (int)((double)progressBar2.Value / progressBar2.Maximum * 100);

            //            using (Graphics gr = progressBar2.CreateGraphics())
            //            {
            //                gr.DrawString(null, SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar2.Width / 2 - 10, progressBar2.Height / 2 - 7));
            //            }
            //            int progressPercentage = ((int)i / dataGridView2.Rows.Count) * 100;
            //            progressBar2.CreateGraphics().DrawString(progressPercentage.ToString() + "%", new Font("Arial", (float)2.1, FontStyle.Regular), Brushes.Black, new PointF(progressBar2.Width / 2 - 10, progressBar1.Height / 2 - 7));

            //            label21.Text = ($"Progress: {progress}%");
            //            Application.DoEvents();
            //        }
            //        Vlng_CashDepID = long.Parse(dataGridView5.Rows[j].Cells[2].Value.ToString());



            //        var listCashDeposit = FsDb.Tbl_DepositCash.Where(x => x.ID == Vlng_CashDepID).ToList();
            //        if (Convert.ToBoolean(dataGridView5.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView5.Rows[j].Cells["CheqTrue"].Value) == true)
            //        {

            //            listCashDeposit[0].DepositCashStatusID = 3;
            //            listCashDeposit[0].DepositCashStatusDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            //            //listCashDeposit[0].BankPaperNo = txtBankAccPaperNo.Text;
            //            listCashDeposit[0].BankAddDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            //            listCashDeposit[0].IsAddedAccNo = true;

            //            var listDepositStatus = FsDb.Tbl_DepositCashStatusDates.Where(x => x.DepositCashID == Vlng_CashDepID && x.DepositCashStatusID == 2).ToList();
            //            if (listDepositStatus.Count == 0)
            //            {
            //                Tbl_DepositCashStatusDates ChStDate = new Tbl_DepositCashStatusDates
            //                {
            //                    DepositCashStatusID = 3,
            //                    DepositCashID = Vlng_CashDepID,
            //                    StatusDate = Convert.ToDateTime(dateTimePicker1.Value.ToString())
            //                };

            //                FsDb.Tbl_DepositCashStatusDates.Add(ChStDate);
            //                FsDb.SaveChanges();
            //            }
            //            else
            //            {
            //                listDepositStatus[0].StatusDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            //                FsDb.SaveChanges();
            //            }


            //        }
            //        else if (Convert.ToBoolean(dataGridView5.Rows[j].Cells[1].Value) == false)
            //        {
            //            //var V_listTRCollection = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == listBankCheq[0].TreasuryCollectionID);
            //            listCashDeposit[0].IsAddedAccNo = false;
            //            listCashDeposit[0].DepositCashStatusID = 1;
            //            //listBankCheq[0].AddDateBank = null;
            //            listCashDeposit[0].BankAddDate = null;
            //            listCashDeposit[0].BankPaperNo = "";
            //            listCashDeposit[0].DepositCashStatusDate = Convert.ToDateTime(dataGridView5.Rows[j].Cells[6].Value.ToString());
            //            var listStDelete = FsDb.Tbl_DepositCashStatusDates.FirstOrDefault(x => x.DepositCashID == Vlng_CashDepID && x.DepositCashStatusID == 2);
            //            if (listStDelete != null) { FsDb.Tbl_DepositCashStatusDates.Remove(listStDelete); }

            //            FsDb.SaveChanges();
            //        }
            //        //}

            //    }
            //    //        //***************كشف الحساب
            //    int vint_MovBankId = 0;
            //    var List_bankMove = FsDb.Tbl_BankMovement.Where(x => x.ID == Vlng_CashDepID).ToList();
            //    vint_MovBankId = int.Parse(List_bankMove[0].BankID.ToString());
            //    bool Vbl_Checked = true;

            //    if (Vbl_Checked == true)
            //    {
            //        List_bankMove[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
            //        if (comboBox4.SelectedValue != null)
            //        { List_bankMove[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString()); }
            //        List_bankMove[0].IsSelectedType = true;
            //        List_bankMove[0].BankCheqID = Vlng_ChqBnkID;

            //        FsDb.SaveChanges();
            //    }
            //    //else if (Vbl_Checked == false)
            //    //{
            //    //List_bankMove[0].MoveType1 = null;
            //    //List_bankMove[0].MoveType2 = null;
            //    //List_bankMove[0].IsSelectedType = false;
            //    //    FsDb.SaveChanges();
            //    //}
            //    //---------------خفظ ااحداث 
            //    SecurityEvent sev = new SecurityEvent
            //    {
            //        ActionName = "مطابقة ايداع النقديه مع كشف الحساب",
            //        TableName = "Tbl_BankMovement",
            //        TableRecordId = List_bankMove[0].ID.ToString(),
            //        Description = "",
            //        ManagementName = Program.GlbV_Management,
            //        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
            //        EmployeeName = Program.GlbV_EmpName,
            //        User_ID = Program.GlbV_UserId,
            //        UserName = Program.GlbV_UserName,
            //        FormName = "شاشة مراجعة الايداعات النقديه بكشف الحساب البنكي"

            //    };

            //    FsEvDb.SecurityEvents.Add(sev);
            //    FsEvDb.SaveChanges();
            //    //        //************************************
            //}
            ////*******************
            //MessageBox.Show("تم الحفظ");
            //if (dataGridView1.Rows.Count != 0)
            //{
            //    dataGridView1.Rows.Clear();

            //    dataGridView3.DataSource = null;
            //}
            //txtAllValue.Text = "";
            //txtAllCount.Text = "";
            //txtSpValueBefore.Text = "";
            //txtCheqSpCount.Text = "";
            //retrieveDataTransmet();
            //dataGridView5.Focus();
            //simpleButton2.Enabled = false;
        }


        private void GrdTotalValue()
        {
            //try
            //{

            int Vint_DgCount = dataGridView5.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                txtSpAllValue.Text = "";
                txtSpAllCount.Text = "";
                txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView5.Rows
                                                   //where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                               select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtAllCount.Text = ((from DataGridViewRow row in dataGridView5.Rows
                                         //where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                     select Convert.ToDouble(row.Cells[4].Value)).Count().ToString());

                txtSpAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView5.Rows
                                                 where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                 select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtSpAllCount.Text = ((from DataGridViewRow row in dataGridView5.Rows
                                       where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                       select Convert.ToDouble(row.Cells[4].Value)).Count().ToString());

            }
        }
        private void Grd1TotalValue()
        {
            //try
            //{

            int Vint_DgCount = dataGridView2.RowCount;
            if (Vint_DgCount != 0)
            {


                txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                txtCheqSpCount.Text = ((from DataGridViewRow row in dataGridView2.Rows
                                        where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                        select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());

            }
        }
        private void Grd5TotalValue()
        {
            //try
            //{

            int Vint_DgCount = dataGridView5.RowCount;
            if (Vint_DgCount != 0)
            {


                txtSpAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView5.Rows
                                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtSpAllCount.Text = ((from DataGridViewRow row in dataGridView5.Rows
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
                if (Vint_type1 == 2 || Vint_type1 == 10)
                {
                    simpleButton1.Text = "ربط";
                }
                else
                {
                    simpleButton1.Text = "تصنيف";
                }
            }
            else
            {
                comboBox4.DataSource = null;
            }
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //string Vst_ProcessKind = comboBox5.SelectedText;
                Vst_DepositDate1 = dTPDeposit.Value.ToString("yyyy/MM/dd");
                Vst_DepositDate2 = dTPDeposit2.Value.ToString("yyyy/MM/dd");
                DateTime d1 = Convert.ToDateTime(Vst_DepositDate1);
                DateTime d2 = Convert.ToDateTime(Vst_DepositDate2);
                int Vint_bankid = int.Parse(comboBox2.SelectedValue.ToString());
                int Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());
                //string Vst_SearhNote = txtSearch.Text;
                //this.dataTable1TableAdapter.FillByProcessKind(this.bankTransmentDS.DataTable1, Vst_DepositDate1, Vst_DepositDate2, Vint_bankid, Vst_ProcessKind, Vint_bankAccid);
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                txtSpAllValue.Text = "";
                txtSpAllCount.Text = "";
                GrdTotalValue();
                //txtSearch.Select();
                //this.ActiveControl = txtSearch;
                //txtSearch.Focus();
            }
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (Vint_BankID == 2014)
            {
                simpleButton1.Enabled = true;
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AddColumnDtaGrd1();
            //**************progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dataGridView5.Rows.Count;
            progressBar1.Value = 0; // Start with 0 progress
            int Vint_CheqID = 0;
            string result = "";
            txtAllValue.Text = "";
            txtAllCount.Text = "";
            txtSpValueBefore.Text = "";
            txtCheqSpCount.Text = "";
            int i = 0;
            Vint_BankID = int.Parse(comboBox2.SelectedValue.ToString());
            Vint_bankAccid = int.Parse(comboBox1.SelectedValue.ToString());

            var ListBankSetting = FsDb.Tbl_BankStringCHeqCash.Where(x => x.BankID == Vint_BankID).ToList();
            string Vst_Cheqstring1 = ListBankSetting[0].CheqString;
            string Vst_Cheqstring2 = ListBankSetting[0].CheqString1;
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows.Clear();
            }

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                //*****************Progress Bar 
                i = i + 1;
                if (i < dataGridView5.Rows.Count)
                {
                    progressBar1.Value = i + 1;
                    progressBar1.Refresh();
                    var progress = (int)((double)progressBar1.Value / progressBar1.Maximum * 100);

                    using (Graphics gr = progressBar1.CreateGraphics())
                    {
                        gr.DrawString(null, SystemFonts.DefaultFont, Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    }
                    int progressPercentage = ((int)i / dataGridView5.Rows.Count) * 100;
                    progressBar1.CreateGraphics().DrawString(progressPercentage.ToString() + "%", new Font("Arial", (float)2.1, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

                    label4.Text = ($"Progress: {progress}%");
                    Application.DoEvents();
                }
                //****************محددات البحث 
                decimal Vd_TransferAmount = Convert.ToDecimal(row.Cells[4].Value.ToString());
                DateTime Vd_DateDeposit1 = Convert.ToDateTime(dTPDeposit.Value.ToString("yyyy-MM-dd"));
                DateTime Vd_DateDeposit2 = Convert.ToDateTime(dTPDeposit2.Value.ToString("yyyy-MM-dd"));
                int Vlng_BankDeposit = int.Parse(row.Cells[9].Value.ToString());
                int Vlng_BankAccDeposit = int.Parse(row.Cells[10].Value.ToString());
                long Vint_DepositCashID = int.Parse(row.Cells[2].Value.ToString());

                if (DgrChequesTrueDepositAmountCh(Vlng_BankDeposit, Vlng_BankAccDeposit, Vd_TransferAmount, Vd_DateDeposit1, Vd_DateDeposit2 , Vint_DepositCashID) == true)
                {
                    row.Cells[1].Value = true;
                    GrdTotalValue();
                    Grd1TotalValue();
                    //Grd5TotalValue();
                    LoadSerial();
                }
                //***********************
                //string Vs_MoveDate = row.Cells[9].Value.ToString();
                //dateTimePicker1.Value = Convert.ToDateTime(row.Cells[9].Value.ToString());

                else if (int.Parse(comboBox3.SelectedValue.ToString()) != 2 && int.Parse(comboBox3.SelectedValue.ToString()) != 10)
                {
                    //List_MovBank[0].MoveType1 = int.Parse(comboBox3.SelectedValue.ToString());
                    //List_MovBank[0].MoveType2 = int.Parse(comboBox4.SelectedValue.ToString());
                    //List_MovBank[0].IsSelectedType = true;
                    row.Cells[1].Value = true;
                    GrdTotalValue();
                    FsDb.SaveChanges();
                }

            }
            simpleButton2.Enabled = true;
            simpleButton2.Focus();
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            //txtSearch.Focus();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Forms.Banks.TransferDataBanks.TransmetOkDepositCash t = new Forms.Banks.TransferDataBanks.TransmetOkDepositCash();
            t.txtType1.Text = this.comboBox3.Text.ToString();
            t.txtType1ID.Text = this.comboBox3.SelectedValue.ToString();
            t.txtType2.Text = this.comboBox4.Text.ToString();
            t.txtType2ID.Text = this.comboBox4.SelectedValue.ToString();
            t.dTPDeposit.Value = this.dTPDeposit.Value;
            t.dTPDeposit2.Value = this.dTPDeposit2.Value;
            t.txtBnk.Text = this.comboBox2.Text.ToString();
            t.txtBnkID.Text = this.comboBox2.SelectedValue.ToString();
            t.txtBnkAcc.Text = this.comboBox1.Text.ToString();
            t.txtBnkAccID.Text = this.comboBox1.SelectedValue.ToString();
            t.simpleButton1.Text = "الغاء" + " " + this.simpleButton1.Text;
            t.simpleButton1.Enabled = true;



            t.ShowDialog();

        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            if (comboBox4.SelectedValue != null)
            {
                int Vint_MovBnkType = int.Parse(comboBox4.SelectedValue.ToString());
                if (Vint_MovBnkType == 8)
                {
                    dataGridView1.Visible = true;
                }
                else
                {
                    dataGridView1.Visible = false;
                }
            }
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            int Vint_MovBnkTypeM = int.Parse(comboBox3.SelectedValue.ToString());
            if (Vint_MovBnkTypeM == 2 || Vint_MovBnkTypeM == 10)
            {
                simpleButton1.Text = "ربط";
            }
            else
            {
                simpleButton1.Text = "تصنيف";
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}