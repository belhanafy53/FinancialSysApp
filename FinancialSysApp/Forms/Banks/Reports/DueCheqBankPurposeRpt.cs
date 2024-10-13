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
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.Reporting.WinForms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks.Reports
{
    public partial class DueCheqBankPurposeRpt : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public DueCheqBankPurposeRpt()
        {
            InitializeComponent();
        }
        private DataTable GetDataBetweenDatesAndGroupFilterReport(List<int> checkedIDs, DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("قيمة الشيك", typeof(decimal));
            dataTable.Columns.Add("رقم الشيك", typeof(string));
            dataTable.Columns.Add("تاريخ الايداع", typeof(DateTime));
            dataTable.Columns.Add("تاريخ الاستحقاق", typeof(DateTime));
            dataTable.Columns.Add("البنك المودع", typeof(string));
            dataTable.Columns.Add("البنك المسحوب عليه", typeof(string));

           
            foreach (TreeListNode node in treeList1.GetNodeList())
            {
                if (node.CheckState == CheckState.Checked)
                {
                    int Vint_MenuPr;
                    if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                    {
                        checkedIDs.Add(Vint_MenuPr);
                    }
                }
            }

            //var selecteditems = checkedComboBoxEdit1.Properties.GetItems().GetCheckedValues();
            foreach (var value in checkedIDs)
            {
                int Vint_PurposeID = int.Parse(value.ToString());
                var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     join BnkD in FsDb.Tbl_Banks on TRC.BankDepositeID equals BnkD.ID
                                     join AccBnk in FsDb.Tbl_AccountsBank on TRC.BankAccounNoID equals AccBnk.ID
                                     where (AccBnk.AccPurposeID == Vint_PurposeID && BnkChq.ChequeDueDate >= startDate && BnkChq.ChequeDueDate <= endDate)
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
                                         ChequeKindID = BnkChq.ChequeKindID,
                                         BankName = BNK.Name,
                                         ChequeStatusID = BnkChq.ChequeStatusID,
                                         DepositDate = TRC.DepositDate,
                                         BankDpst = BnkD.Name

                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                // Populate grouped data into a new DataTable
                DataTable groupedDataTable = new DataTable();
                groupedDataTable.Columns.Add("قيمة الشيك", typeof(decimal));
                groupedDataTable.Columns.Add("رقم الشيك", typeof(string));
                groupedDataTable.Columns.Add("تاريخ الايداع", typeof(DateTime));
                groupedDataTable.Columns.Add("تاريخ الاستحقاق", typeof(DateTime));
                groupedDataTable.Columns.Add("البنك المودع", typeof(string));
                groupedDataTable.Columns.Add("البنك المسحوب عليه", typeof(string));
                for (int i = 0; i < listBnkCheque.Count; i++)

                {
                    groupedDataTable.Rows.Add(listBnkCheque[i].AmountCheque, listBnkCheque[i].ChequeNo,listBnkCheque[i].DepositDate, listBnkCheque[i].ChequeDueDate,listBnkCheque[i].BankDpst, listBnkCheque[i].BankName);
                   
                }
            }
            

       

            return dataTable;
        }
    private void checkedComboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
    {
       
    }

        private void DueCheqBankPurposeRpt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankCheques.Tbl_AccountsBankPurpose' table. You can move, or remove it, as needed.
            this.tbl_AccountsBankPurposeTableAdapter.Fill(this.bankCheques.Tbl_AccountsBankPurpose);

        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime startDate = Convert.ToDateTime(DTPFrom.Value.ToShortDateString());
                DateTime endDate = Convert.ToDateTime(DTPTo.Value.ToShortDateString());

                //var selecteditems = checkedComboBoxEdit1.Properties.GetItems().GetCheckedValues();

                List<int> checkedIDs = new List<int>();
                foreach (TreeListNode node in treeList1.GetNodeList())
                {
                    if (node.CheckState == CheckState.Checked)
                    {
                        int Vint_MenuPr;
                        if (int.TryParse(node.GetValue("ID").ToString(), out Vint_MenuPr))
                        {
                            checkedIDs.Add(Vint_MenuPr);
                        }
                    }
                }
                DataTable groupedDataTableReport = GetDataBetweenDatesAndGroupFilterReport(checkedIDs, startDate, endDate);


                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", groupedDataTableReport)); // Set your data set name


                // Refresh the report viewer
                ReportParameter[] parameters = new ReportParameter[6];
                parameters[0] = new ReportParameter("d", startDate.ToString());
                parameters[1] = new ReportParameter("d1", endDate.ToString());
                parameters[2] = new ReportParameter("ReportParameter1", "");
                parameters[3] = new ReportParameter("ReportParameter2", "");
                parameters[4] = new ReportParameter("Managament", Program.GlbV_Management);
                parameters[5] = new ReportParameter("Usr", Program.GlbV_EmpName);
                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
