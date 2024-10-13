using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using FinancialSysApp.Forms.DocumentsForms;
using MahApps.Metro.Controls;

namespace FinancialSysApp.Forms.Banks.TransferDataBanks
{
    public partial class TransmetCommentsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_bankDepositId = 0;
        int Vint_bankDepositAccId = 0;
        DateTime Vd_DateDeposit = Convert.ToDateTime(DateTime.Now.ToString());
        public TransmetCommentsFrm()
        {
            InitializeComponent();
        }
        private void GrdTotalValue2()
        {
            //try
            //{

            int Vint_DgCount = dataGridView2.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValue.Text = "";
                txtAllCount.Text = "";
                
                txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView2.Rows
                                                  
                                               select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtAllCount.Text = ((from DataGridViewRow row in dataGridView2.Rows
                                         
                                     select Convert.ToDouble(row.Cells[7].Value)).Count().ToString());
            }
        }
        private void GrdTotalValue1()
        {
            //try
            //{

            int Vint_DgCount = dataGridView1.RowCount;
            if (Vint_DgCount != 0)
            {
                txtAllValue.Text = "";
                txtAllCount.Text = "";

                txtAllValue.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows

                                               select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                txtAllCount.Text = ((from DataGridViewRow row in dataGridView1.Rows

                                     select Convert.ToDouble(row.Cells[3].Value)).Count().ToString());
            }
        }
        private void TransmetCommentsFrm_Load(object sender, EventArgs e)
        {
            long Vlng_Trid = 0;
            DateTime Vd_DateDeposit = DateTime.Now;
            int Vint_Id = int.Parse(txtRowID.Text);
            int Vint_bankCeqId = int.Parse(txtBankChq.Text);
            decimal Vdc_CheqValue = 0;
            if (txtBnkID.Text != "")
            { Vint_bankDepositId = int.Parse((string)txtBnkID.Text); }
            if (txtBnkAccID.Text != "")
            { Vint_bankDepositAccId = int.Parse((string)txtBnkAccID.Text); }

            var list = FsDb.Tbl_BankMovement.Where(x => x.ID == Vint_Id).ToList();

           
            
            if (list != null)
            {
                this.dataTable1TableAdapter.FillById(this.bankTransmentDS.DataTable1, Vint_Id);
                if (list[0].C2 != "")
                { Vlng_Trid = long.Parse(list[0].C2.ToString()); }
                Vd_DateDeposit = Convert.ToDateTime(list[0].MoveDat.Value.ToString());
                 Vdc_CheqValue = Convert.ToDecimal(list[0].TransferValue.ToString());
            }

            if (Vint_bankDepositId == 2004)
            {
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                     join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                     where (BnkChq.TreasuryCollectionID == Vlng_Trid)
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

                if (listBnkCheque.Count > 0)
                { 
                    this.dataGridView1.DataSource = listBnkCheque; 
                    GrdBnkCheq();
                    GrdTotalValue1();
                }

            }
            else
            {
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                     join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                     where (BnkChq.AmountCheque == Vdc_CheqValue && TRC.BankDepositeID == Vint_bankDepositId && TRC.BankAccounNoID == Vint_bankDepositAccId && TRC.DepositDate <= Vd_DateDeposit)
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

                if (listBnkCheque.Count > 0)
                {
                    this.dataGridView1.DataSource = listBnkCheque;
                    GrdBnkCheq();
                    GrdTotalValue1();
                }
                else if (txtBankChq.Text != "")
                {
                    var listBnkChequek = (from BnkChq in FsDb.Tbl_BankCheques
                                          join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                          join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                          join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                          join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                          where (BnkChq.ID == Vint_bankCeqId)
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
                    dataGridView1.DataSource = listBnkChequek;
                    GrdBnkCheq();
                    GrdTotalValue1();

                }
                
            }
            //else if (txtType1ID.Text == "2")
            //{
            //    var listCDeposit = (from Bch in FsDb.Tbl_DepositCash
            //                        join BNK in FsDb.Tbl_Banks on Bch.DepositBankID equals BNK.ID
            //                        join MNG in FsDb.Tbl_Management on Bch.BranchID equals MNG.ID
            //                        //join rep in FsDb.Tbl_Representatives on Bch.RepresentiveID equals rep.ID
            //                        where (Bch.AmountCash == Vdc_CheqValue && Bch.DepositBankID == Vint_bankDepositId && Bch.AccBankID == Vint_bankDepositAccId)
            //                        select new
            //                        {
            //                            ID = Bch.ID,
            //                            DepositCashNo = Bch.DepositCashNo,
            //                            AmountCash = Bch.AmountCash,
            //                            BranchName = MNG.BrancheName,
            //                            Name = BNK.Name,
            //                            BranchID = Bch.BranchID,
            //                            DepositDate = Bch.DepositDate,
            //                            BankDepositeID = Bch.DepositBankID,
            //                            BankAccountID = Bch.AccBankID,
            //                            BankDueDate = Bch.BankDueDate,
            //                            AccountBnkID = Bch.AccBankID,
            //                            RepresentiveID = Bch.RepresentiveID



            //                        }).OrderBy(x => x.ID).ToList();
            //    dataGridView3.DataSource = listCDeposit;
            //}
        }
        private void GrdBnkCheq()
        {


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

            dataGridView1.Columns["ChequeStatusID"].Visible = false;
            dataGridView1.Columns["BankName"].Visible = true;
            dataGridView1.Columns["BankName"].Width = 200;
            dataGridView1.Columns["IsDisposed"].Visible = false;
            dataGridView1.Columns["ReceiptNo"].Visible = false;

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
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Forms.DocumentsForms.CheqScanFrm t = new Forms.DocumentsForms.CheqScanFrm();


            if (this.dataGridView1.CurrentRow.Cells["ID"].Value != null)
            {
                long Vint_TrCollectionID = 0;
                //**************بيانات الخافظه 
                if (dataGridView1.CurrentRow.Cells["BranchNam"].Value != null)
                { t.txtbranch.Text = this.dataGridView1.CurrentRow.Cells["BranchNam"].Value.ToString(); }
                if (dataGridView1.CurrentRow.Cells["CollectionNo"].Value != null)
                {
                    t.txtCollectionNo.Text = this.dataGridView1.CurrentRow.Cells["CollectionNo"].Value.ToString();
                }

                Vint_TrCollectionID = int.Parse(this.dataGridView1.CurrentRow.Cells["TreasuryCollectionID"].Value.ToString());

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
                t.txtBankD.Text = ListTrColl[0].BankName;
                ////t.txtBankAcc.Text = this.comboBox1.Text.ToString();
                t.txtBankAcc.Text = ListTrColl[0].BankAcc;
                ////t.txtpurpose.Text = this.comboBox2.Text.ToString();
                t.txtpurpose.Text = ListTrColl[0].bnkAccTypeName;
                ////*************بيانات الشيك
                t.txtRowChequeID.Text = this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                t.txtChequeNoScan.Text = this.dataGridView1.CurrentRow.Cells["ChequeNo"].Value.ToString();
                t.txtAmountScan.Text = this.dataGridView1.CurrentRow.Cells["AmountCheque"].Value.ToString();
                t.txtBankDrawnOnScan.Text = this.dataGridView1.CurrentRow.Cells["BankName"].Value.ToString();
                t.dTPDueDateScan.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["ChequeDueDate"].Value.ToString());


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
                MessageBox.Show("من فضلك اختر الحركه المراد عرض صورته اولا");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            txtCheqAllCount.Text = ((from DataGridViewRow row in dataGridView1.Rows
                                     where (Convert.ToBoolean(row.Cells[1].Value) == true)
                                     select Convert.ToDouble(row.Cells[2].Value)).Count().ToString());

            if (txtNoteComment.Text == "")
            {
                MessageBox.Show("من فضلك ادخل الملاحظه الخاصه بعدم اضافة المنظومه للحركه تلقائيا");
            }
            else
            {
                if (txtCheqAllCount.Text == "1")
                {
                    //************اضافة الشيكات
                    int Vint_MovBnkTypeM = int.Parse(txtType1ID.Text);
                    int Vint_MovBnkType = int.Parse(txtType2ID.Text);



                    if (dataGridView1.Rows.Count > 0 && Vint_MovBnkTypeM == 2 && Vint_MovBnkType == 8)
                    {
                        long Vlng_ChqBnkID = 0;
                        //int i = 0;
                        string Vst_ChqBnkNo = "";

                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            //*****************Progress Bar 

                            //**********************************كود الشيك 
                            Vlng_ChqBnkID = long.Parse(dataGridView1.Rows[j].Cells["ID"].Value.ToString());
                            Vst_ChqBnkNo = dataGridView1.Rows[j].Cells["ChequeNo"].Value.ToString();
                            //***********************بيانات الشيك
                            var listBankCheq = FsDb.Tbl_BankCheques.Where(x => x.ID == Vlng_ChqBnkID).ToList();
                            if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == true && Convert.ToBoolean(dataGridView1.Rows[j].Cells["CheqTrue"].Value) == true)
                            {
                                listBankCheq[0].IsAddedAccNo = true;
                                listBankCheq[0].ChequeStatusID = 3;
                                listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                //listBankCheq[0].TradeCollectionNo = txtBankAccPaperNo.Text;
                                listBankCheq[0].AddDateAccBank = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                var listCheqStatus = FsDb.Tbl_ChequeBankStatusDates.Where(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 3).ToList();
                                if (listCheqStatus.Count == 0)
                                {
                                    Tbl_ChequeBankStatusDates ChStDate = new Tbl_ChequeBankStatusDates
                                    {
                                        BankChequeStatusID = 3,
                                        BankChequeID = Vlng_ChqBnkID,

                                        ChequeBankStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString())
                                    };

                                    FsDb.Tbl_ChequeBankStatusDates.Add(ChStDate);
                                    FsDb.SaveChanges();
                                }
                                else
                                {
                                    listCheqStatus[0].ChequeBankStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                    FsDb.SaveChanges();
                                }


                            }
                            else if (Convert.ToBoolean(dataGridView1.Rows[j].Cells[1].Value) == false)
                            {
                                //var V_listTRCollection = FsDb.Tbl_TreasuryCollection.FirstOrDefault(x => x.ID == listBankCheq[0].TreasuryCollectionID);
                                listBankCheq[0].IsAddedAccNo = false;
                                listBankCheq[0].ChequeStatusID = 2;
                                //listBankCheq[0].AddDateBank = null;
                                listBankCheq[0].AddDateAccBank = null;
                                listBankCheq[0].TradeCollectionNo = "";
                                listBankCheq[0].ChequeStatusDate = Convert.ToDateTime(dTPDeposit.Value.ToString());
                                var listStDelete = FsDb.Tbl_ChequeBankStatusDates.FirstOrDefault(x => x.BankChequeID == Vlng_ChqBnkID && x.BankChequeStatusID == 3);
                                if (listStDelete != null) { FsDb.Tbl_ChequeBankStatusDates.Remove(listStDelete); }

                                FsDb.SaveChanges();
                            }




                            //***************كشف الحساب
                            int vint_MovBankId = 0;
                            int vint_MovId = int.Parse(dataGridView2.Rows[0].Cells[1].Value.ToString());
                            var List_bankMove = FsDb.Tbl_BankMovement.Where(x => x.ID == vint_MovId).ToList();
                            vint_MovBankId = int.Parse(List_bankMove[0].BankID.ToString());



                            List_bankMove[0].MoveType1 = int.Parse(txtType1ID.Text);

                            List_bankMove[0].MoveType2 = int.Parse(txtType2ID.Text);
                            List_bankMove[0].IsSelectedType = true;
                            List_bankMove[0].BankCheqID = Vlng_ChqBnkID;
                            List_bankMove[0].C6 = txtNoteComment.Text;
                            List_bankMove[0].IsCollected = true;
                            FsDb.SaveChanges();


                            //---------------خفظ ااحداث 
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة الشيكات من  كشف حساب بنك",
                                TableName = "Tbl_BankMovement",
                                TableRecordId = List_bankMove[0].ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة شيكات من كشف حساب بنك"

                            };

                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                           
                            //************************************
                        }
                        MessageBox.Show("تم الحفظ");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("من فضلك يجب اختيار شيك واحد فقط");
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vint_bankDepositId = int.Parse((string)txtBnkID.Text);
                Vint_bankDepositAccId = int.Parse((string)txtBnkAccID.Text);
                decimal Vdc_CheqValueF = Convert.ToDecimal(textBox1.Text);
                decimal Vdc_CheqValueT = Convert.ToDecimal(textBox2.Text);
                if (txtType1ID.Text == "2")
                {
                    dataGridView3.Visible = false;
                    dataGridView1.Visible = true;
                    var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                         join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                         join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                         join bnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals bnkD.ID
                                         join mng in FsDb.Tbl_Management on TRC.BranchID equals mng.ID
                                         where (BnkChq.AmountCheque >= Vdc_CheqValueF && BnkChq.AmountCheque <= Vdc_CheqValueT && TRC.BankDepositeID == Vint_bankDepositId && TRC.BankAccounNoID == Vint_bankDepositAccId && TRC.DepositDate <= Vd_DateDeposit)

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
                    //if (dataGridView1.Rows.Count > 0)
                    //{
                    //    dataGridView1.Rows.Clear();
                    //}
                    this.dataGridView1.DataSource = listBnkCheque;
                    GrdBnkCheq();
                }
                else if (txtType1ID.Text == "10")
                {
                    dataGridView3.Visible = true;
                    dataGridView1.Visible = false;
                    var listCDeposit = (from Bch in FsDb.Tbl_DepositCash
                                        join BNK in FsDb.Tbl_Banks on Bch.DepositBankID equals BNK.ID
                                        join MNG in FsDb.Tbl_Management on Bch.BranchID equals MNG.ID
                                        //join rep in FsDb.Tbl_Representatives on Bch.RepresentiveID equals rep.ID
                                        where (Bch.AmountCash >= Vdc_CheqValueF && Bch.AmountCash <= Vdc_CheqValueT && Bch.DepositBankID == Vint_bankDepositId && Bch.AccBankID == Vint_bankDepositAccId)
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
                    dataGridView3.DataSource = listCDeposit;

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void txtType1ID_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
