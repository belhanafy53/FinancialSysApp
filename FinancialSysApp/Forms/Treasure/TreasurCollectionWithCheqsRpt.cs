using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using Microsoft.Reporting.WinForms;

namespace FinancialSysApp.Forms.Treasure
{
    public partial class TreasurCollectionWithCheqsRpt : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankId = 0;
        int   Vint_BranchID = 0;
        int Vint_BankAccid = 0;
        string Vd_DFrom = "";
        string Vd_DTo = "";
        string Vs_BankName = "";
        string Vs_BankAccNoName = "";
        string Vs_DbCredit = "";
        public TreasurCollectionWithCheqsRpt()
        {
            InitializeComponent();
        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox3.Checked == true)
                {

                    Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");



                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionRpt.rdlc";
                    this.dtb_TreasureCollectionTablAdapter.Fill(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("Branch", "");
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات الوارده للخزينه العامه خلال الفتره");

                    checkBox1.Checked = true;
                    checkBox2.Checked = false;

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    txtBranch.Focus();
                }
                else if (checkBox4.Checked == true)
                {
                    Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");



                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionTotalBranchNRpt.rdlc";
                    this.dtb_TreasureCollectionTablAdapter.FillByGrBranchId(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("Branch", "");
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات الوارده للخزينه العامه خلال الفتره");

                    checkBox1.Checked = true;
                    checkBox2.Checked = false;

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    txtBranch.Focus();
                }
            }
        }

        private void TreasurCollectionWithCheqsRpt_Load(object sender, EventArgs e)
        {
            checkBox3.Checked = true;

            DTPFrom.Select();
            this.ActiveControl = DTPFrom;
            DTPFrom.Focus();
        }

        private void DTPFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                DTPTo.Focus();
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox3.Checked == true)
                {
                    Vd_DFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");



                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionRpt.rdlc";
                    this.dtb_TreasureCollectionTablAdapter.FillByDepositDate(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("Branch", "");
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات المودعه بالبنوك خلال الفتره");

                    this.reportViewer1.LocalReport.SetParameters(parameters);

                    reportViewer1.RefreshReport();
                    checkBox1.Checked = false;
                    checkBox2.Checked = true;

                    txtBranch.Focus();
                }
                else if (checkBox4.Checked == true)
                {
                    Vd_DFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");



                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionTotalBranchNRpt.rdlc";
                    this.dtb_TreasureCollectionTablAdapter.FillByDepositDate(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("Branch", "");
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات المودعه بالبنوك خلال الفتره");

                    checkBox1.Checked = false;
                    checkBox2.Checked = true;

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.RefreshReport();
                    txtBranch.Focus();
                }

            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindBranchFrm t = new Forms.BasicCodeForms.FindBranchFrm();

                t.ShowDialog();
                if (Forms.BasicCodeForms.FindBranchFrm.SelectedRow != null)
                {
                    txtBranchID.Text =  "";
                       txtBranch.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[1].Value.ToString();
                    txtBranchID.Text = Forms.BasicCodeForms.FindBranchFrm.SelectedRow.Cells[0].Value.ToString();


                      Vint_BranchID = int.Parse(txtBranchID.Text);
                    var list = (from TRC in FsDb.Tbl_TreasuryCollection
                                join BNK in FsDb.Tbl_Banks on TRC.BankDepositeID equals BNK.ID
                                join MNG in FsDb.Tbl_Management on TRC.BranchID equals MNG.ID
                                //join Rpsntv in FsDb.Tbl_Representatives on TRC.RepresentiveID equals Rpsntv.ID
                                //join BnkAcct in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals BnkAcct.ID
                                where (TRC.BranchID == Vint_BranchID && TRC.ChequeReceivedKindID == 0)
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

                                    ReceiptNo = TRC.ReceiptNo,
                                    Name = BNK.Name,
                                    RepresentiveID = TRC.RepresentiveID,
                                    //RepresentiveName = Rpsntv.Name
                                }).OrderByDescending(x => x.CollectionDate).ToList();
                    if (checkBox1.Checked == true)
                    {
                        Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                        Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                        Vint_BranchID = int.Parse(txtBranchID.Text);


                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionRpt.rdlc";
                        this.dtb_TreasureCollectionTablAdapter.FillByTrDateBranchID(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo, Vint_BranchID);
                        ReportParameter[] parameters = new ReportParameter[5];

                        parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                        parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                        parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                        parameters[3] = new ReportParameter("Branch", txtBranch.Text);
                        parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات المودعه بالبنوك خلال الفتره");

                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        reportViewer1.RefreshReport();
                        //checkBox1.Checked = false;
                        //checkBox2.Checked = true;
                    }
                    else if (checkBox2.Checked == true)
                    {
                        Vd_DFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        Vd_DTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                        Vint_BranchID = int.Parse(txtBranchID.Text);


                        this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionRpt.rdlc";
                        this.dtb_TreasureCollectionTablAdapter.FillByDepositDateBranch(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo, Vint_BranchID);
                        ReportParameter[] parameters = new ReportParameter[5];

                        parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                        parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                        parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                        parameters[3] = new ReportParameter("Branch", txtBranch.Text);
                        parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات المودعه بالبنوك خلال الفتره");

                        this.reportViewer1.LocalReport.SetParameters(parameters);

                        reportViewer1.RefreshReport();
                        //checkBox1.Checked = false;
                        //checkBox2.Checked = true;


                    }

                }


            }
            else if(e.KeyCode == Keys.Enter)
            {
                if (checkBox1.Checked == true)
                {
                    Vd_DFrom = DTPFrom.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = DTPTo.Value.ToString("yyyy-MM-dd");
                    Vint_BranchID = int.Parse(txtBranchID.Text);


                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionRpt.rdlc";
                    this.dtb_TreasureCollectionTablAdapter.FillByTrDateBranchID(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo, Vint_BranchID);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("Branch", txtBranch.Text);
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات المودعه بالبنوك خلال الفتره");

                    this.reportViewer1.LocalReport.SetParameters(parameters);

                    reportViewer1.RefreshReport();
                    checkBox1.Checked = false;
                    checkBox2.Checked = true;
                }
                else if (checkBox2.Checked == true)
                {
                    Vd_DFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    Vd_DTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    Vint_BranchID = int.Parse(txtBranchID.Text);


                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinancialSysApp.Reports.Bank.TraesureCollectionRpt.rdlc";
                    this.dtb_TreasureCollectionTablAdapter.FillByDepositDateBranch(this.bankDateAddedReport.Dtb_TreasureCollection, Vd_DFrom, Vd_DTo, Vint_BranchID);
                    ReportParameter[] parameters = new ReportParameter[5];

                    parameters[0] = new ReportParameter("FromDate", Vd_DFrom);
                    parameters[1] = new ReportParameter("ToDate", Vd_DTo);
                    parameters[2] = new ReportParameter("User", Program.GlbV_EmpName);
                    parameters[3] = new ReportParameter("Branch", txtBranch.Text);
                    parameters[4] = new ReportParameter("TitleRpt", "بيان بالشيكات المودعه بالبنوك خلال الفتره");

                    this.reportViewer1.LocalReport.SetParameters(parameters);

                    reportViewer1.RefreshReport();
                    checkBox1.Checked = false;
                    checkBox2.Checked = true;

                    
                }
            }

        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox3.Checked = false;
            }
        }
    }
}
