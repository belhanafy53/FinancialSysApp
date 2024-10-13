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
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPdfViewer.Bars;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks
{
    public partial class CheqAuditUpdateStatus : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        long Vlng_LastRowTreasuryCollection = 0;
        Forms.Banks.AuditingCheqFrm t = new Forms.Banks.AuditingCheqFrm();

        Forms.Banks.ChequeFrm chq = new Forms.Banks.ChequeFrm();

        int Vint_ChequeReceivedKindID = 0;
        public CheqAuditUpdateStatus()
        {
            InitializeComponent();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void CheqAuditUpdateStatus_Load(object sender, EventArgs e)
        {

            if (Program.GlbV_SysUnite_ID == 13)
            {
                // TODO: This line of code loads data into the 'bankCheques.Dtb_CheqWithError' table. You can move, or remove it, as needed.
                this.dtb_CheqWithErrorTableAdapter.FillCheqWithErrors(this.bankCheques.Dtb_CheqWithError);
                LoadSerial();
            }
            else if (Program.GlbV_SysUnite_ID == 12)
            {
                this.dtb_CheqWithErrorTableAdapter.FillByBank(this.bankCheques.Dtb_CheqWithError);
                LoadSerial();
            }

        }

        private void dTPDeposit_ValueChanged(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dataGridView1.DataSource;
            ////bs.Filter = "[رقم الحساب] like '" + textBox7.Text + "%'"+ "البيان like '" + Descp.Text + "%'";
            //bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] Like  '" + Descp.Text + "%' ";
            ////bs.Filter = "[رقم الحساب] like  '" + textBox7.Text + "%'" + " AND [البيان] =  '" + Descp.Text + "' ";
            //dataGridView1.DataSource = bs;
            //if (Program.GlbV_SysUnite_ID == 13)
            //{
            //    // TODO: This line of code loads data into the 'bankCheques.Dtb_CheqWithError' table. You can move, or remove it, as needed.
            //    this.dtb_CheqWithErrorTableAdapter.FillCheqWithErrors(this.bankCheques.Dtb_CheqWithError);
            //}
            //else if (Program.GlbV_SysUnite_ID == 12)
            //{
            //    this.dtb_CheqWithErrorTableAdapter.FillByBank(this.bankCheques.Dtb_CheqWithError);
            //}
        }
        private void TotalChequeCollection()
        {



            foreach (DataGridViewRow row in t.dataGridView2.Rows)
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
            t.txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in t.dataGridView2.Rows
                                                      select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
            t.textBox5.Text = (from DataGridViewRow row in t.dataGridView2.Rows
                               select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();
        }
        private void GrdTRCollctionCheq()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {
                t.dataGridView2.Columns["ID"].Visible = false;
                t.dataGridView2.Columns["BranchID"].Visible = false;
                t.dataGridView2.Columns["BankDepositeID"].Visible = false;
                t.dataGridView2.Columns["RepresentiveID"].Visible = false;
                //t.dataGridView2.Columns["BankAccName"].Visible = false;
                t.dataGridView2.Columns["BankAccountID"].Visible = false;
                t.dataGridView2.Columns["ReceiptNo"].Visible = false;
                //t.dataGridView2.Columns["TradeCollectionNo"].Visible = true;

                t.dataGridView2.Columns["Name"].Width = 250;
                t.dataGridView2.Columns["Name"].HeaderText = "البنك";

                t.dataGridView2.Columns["BranchName"].HeaderText = "الفرع / الجهه";
                t.dataGridView2.Columns["BranchName"].Width = 120;
                t.dataGridView2.Columns["TradeCollectionNo"].HeaderText = "رقم الحافظه بالتجاري";
                t.dataGridView2.Columns["CollectionNo"].HeaderText = "رقم الحافظه";
                t.dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ الحافظه";
                t.dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
                t.dataGridView2.Columns["CollectionNo"].Width = 150;
                t.dataGridView2.Columns["CountChq"].Width = 50;
                t.dataGridView2.Columns["TotalAmountChq"].Width = 150;
                t.dataGridView2.Columns["TradeCollectionNo"].Width = 60;
                //t.dataGridView2.Columns["RepresentiveName"].HeaderText = "مندوب الخزينه";
            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                t.dataGridView2.Columns["ID"].Visible = false;
                t.dataGridView2.Columns["BranchID"].Visible = false;
                t.dataGridView2.Columns["BankDepositeID"].Visible = false;
                t.dataGridView2.Columns["RepresentiveID"].Visible = false;

                t.dataGridView2.Columns["BankAccountID"].Visible = false;
                t.dataGridView2.Columns["ReceiptNo"].Visible = false;
                t.dataGridView2.Columns["TradeCollectionNo"].Visible = false;
                t.dataGridView2.Columns["BranchName"].HeaderText = " الجهه";
                t.dataGridView2.Columns["BranchName"].Width = 120;
                t.dataGridView2.Columns["CollectionNo"].HeaderText = "رقم  المستند";
                t.dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ المستند";
                t.dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            }


        }

        private void GrdTRCollctionCheq13()
        {
            if (Vint_ChequeReceivedKindID == 0)
            {
                chq.dataGridView2.Columns["ID"].Visible = false;
                chq.dataGridView2.Columns["BranchID"].Visible = false;
                chq.dataGridView2.Columns["BankDepositeID"].Visible = false;
                chq.dataGridView2.Columns["RepresentiveID"].Visible = false;
                //chq.dataGridView2.Columns["BankAccName"].Visible = false;
                chq.dataGridView2.Columns["BankAccountID"].Visible = false;
                chq.dataGridView2.Columns["ReceiptNo"].Visible = false;
                //chq.dataGridView2.Columns["TradeCollectionNo"].Visible = true;

                chq.dataGridView2.Columns["Name"].Width = 250;
                chq.dataGridView2.Columns["Name"].HeaderText = "البنك";

                chq.dataGridView2.Columns["BranchName"].HeaderText = "الفرع / الجهه";
                chq.dataGridView2.Columns["BranchName"].Width = 120;
                chq.dataGridView2.Columns["TradeCollectionNo"].HeaderText = "رقم الحافظه بالتجاري";
                chq.dataGridView2.Columns["CollectionNo"].HeaderText = "رقم الحافظه";
                chq.dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ الحافظه";
                chq.dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
                chq.dataGridView2.Columns["CollectionNo"].Width = 150;
                chq.dataGridView2.Columns["CountChq"].Width = 50;
                chq.dataGridView2.Columns["TotalAmountChq"].Width = 150;
                chq.dataGridView2.Columns["TradeCollectionNo"].Width = 60;
                //chq.dataGridView2.Columns["RepresentiveName"].HeaderText = "مندوب الخزينه";
            }
            else if (Vint_ChequeReceivedKindID == 1)
            {
                chq.dataGridView2.Columns["ID"].Visible = false;
                chq.dataGridView2.Columns["BranchID"].Visible = false;
                chq.dataGridView2.Columns["BankDepositeID"].Visible = false;
                chq.dataGridView2.Columns["RepresentiveID"].Visible = false;

                chq.dataGridView2.Columns["BankAccountID"].Visible = false;
                chq.dataGridView2.Columns["ReceiptNo"].Visible = false;
                chq.dataGridView2.Columns["TradeCollectionNo"].Visible = false;
                chq.dataGridView2.Columns["BranchName"].HeaderText = " الجهه";
                chq.dataGridView2.Columns["BranchName"].Width = 120;
                chq.dataGridView2.Columns["CollectionNo"].HeaderText = "رقم  المستند";
                chq.dataGridView2.Columns["CollectionDate"].HeaderText = "تاريخ المستند";
                chq.dataGridView2.Columns["CollectionDate"].DefaultCellStyle.Format = "yyyy/MM/dd";
            }


        }
        private void LoadSerial2()
        {
            int i = 1;
            foreach (DataGridViewRow row in t.dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void LoadSerial13()
        {
            int i = 1;
            foreach (DataGridViewRow row in chq.dataGridView2.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void TotalChequeCollection13()
        {



            foreach (DataGridViewRow row in chq.dataGridView2.Rows)
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
            chq.txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in chq.dataGridView2.Rows
                                                    select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
           chq.textBox5.Text = (from DataGridViewRow row in chq.dataGridView2.Rows
                             select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            long Vlng_TreasurID = long.Parse(dataGridView1.CurrentRow.Cells[14].Value.ToString());

            if (Program.GlbV_SysUnite_ID == 12)
            {
                Vint_ChequeReceivedKindID = 0;

                t.comboBox1.SelectedIndex = -1;

                t.txtRowID.Text = Vlng_TreasurID.ToString();

                var list = (from TRC in FsDb.Tbl_TreasuryCollection
                            join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                            join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID

                            where (TRC.ID == Vlng_TreasurID)
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
                                Name = BNK.Name,
                                RepresentiveID = TRC.RepresentiveID,
                                DepositDate = TRC.DepositDate,
                                ReceiptNo = TRC.ReceiptNo,
                                ChequeReceivedKindID = TRC.ChequeReceivedKindID

                            }).OrderBy(x => x.BranchID).ToList();
                t.dataGridView2.DataSource = list;
                Vint_ChequeReceivedKindID = int.Parse(list[0].ChequeReceivedKindID.Value.ToString());
                 
                t.comboBox1.SelectedIndex = Vint_ChequeReceivedKindID;
                if (list.Count > 0)
                {
                    TotalChequeCollection();
                    LoadSerial2();
                    GrdTRCollctionCheq();

                    t.txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in t.dataGridView2.Rows
                                                              select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                    t.textBox5.Text = (from DataGridViewRow row in t.dataGridView2.Rows
                                       select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();

                    t.ShowDialog();
                }
              
            }
            else if (Program.GlbV_SysUnite_ID == 13)
            {
                Vint_ChequeReceivedKindID = 0;

                chq.radioGroup1.SelectedIndex = -1;

                //chq.txtRowID.Text = Vlng_TreasurID.ToString();
                var list = (from TRC in FsDb.Tbl_TreasuryCollection
                            join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                            join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID

                            where (TRC.ID == Vlng_TreasurID)
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
                                Name = BNK.Name,
                                RepresentiveID = TRC.RepresentiveID,
                                DepositDate = TRC.DepositDate,
                                ReceiptNo = TRC.ReceiptNo,
                                ChequeReceivedKindID = TRC.ChequeReceivedKindID
                            }).OrderBy(x => x.BranchID).ToList();
              
                //chq.dataGridView2.Refresh();
                Vint_ChequeReceivedKindID = int.Parse(list[0].ChequeReceivedKindID.Value.ToString());
                chq.radioGroup1.SelectedIndex = Vint_ChequeReceivedKindID;
                if (list.Count > 0)
                {
                   
                    chq.dataGridView2.DataSource = null;
                   chq.dataGridView2.DataSource = list;
                    LoadSerial13();
                    TotalChequeCollection13();

                    GrdTRCollctionCheq13();

                    chq.txtAllValueBeforeall.Text = Math.Round((from DataGridViewRow row in chq.dataGridView2.Rows
                                                                select Convert.ToDouble(row.Cells[2].Value)).Sum(), 3).ToString();
                    chq.textBox5.Text = (from DataGridViewRow row in chq.dataGridView2.Rows
                                         select Convert.ToDouble(row.Cells[1].Value)).Sum().ToString();

                    chq.ShowDialog();
                }
               

            }


        }
    }
}
   
