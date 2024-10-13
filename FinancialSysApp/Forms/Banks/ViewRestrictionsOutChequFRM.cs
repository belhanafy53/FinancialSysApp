using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using FinancialSysApp.Forms.DocumentsForms;
using DevExpress.PivotGrid.PivotTable;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.CodeParser;
using System.Runtime.InteropServices;
using WIA;
using System.IO;
using DevExpress.Office.Drawing;
using System.Data.SqlClient;
using System.Configuration;
namespace FinancialSysApp.Forms.Banks
{
    public partial class ViewRestrictionsOutChequFRM : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankDepositeId = 0;
        int? Vint_AccountBank = 0;
        int? Vint_BankAccId = 0;
        int? Vint_ChequeReceivedKindID = null;
        int? Vint_BranchID = 0;
        int? Vint_RepresentiveID = null;
        int? Vint_BankDrawnOnID = 0;
        int? Vint_CustID = null;
        string Vstr_CollectionNo = null;
        string Vstr_ChequeNO;
        string Vstr_ReceiptNO;
        string Vstr_TradeCollectionNO;
        long? Vlng_LastRowTreasuryCollection = 0;
        DateTime? vdate_CollectionDate = null;
        long VLng_IDMasterRow = 0;
        decimal Vdc_AmountCheque = 0;
        DateTime? Vdate_ChequeDueDate = null;
        int? Vint_CheckRowID = null;
        int? Vint_DgCount = 0;
        Boolean? Vbl_RestrictionDataID = false;
        int? Vint_TrCollectionID = 0;
        long? vlng_bankCheqID = 0;
        string Image_Path = "";
        public ViewRestrictionsOutChequFRM()
        {
            InitializeComponent();
        }

        private void ViewRestrictionsOutChequFRM_Load(object sender, EventArgs e)
        {
            this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.notOutChequeTableAdapter.FillByOut(this.restrictionCheque.NotOutCheque, Convert.ToDateTime(dateTimePicker1.Value).ToString(), Convert.ToDateTime(dateTimePicker2.Value).ToString());
                //this.notOutChequeTableAdapter.Fill(this.restrictionCheque.NotOutCheque, comboBox3.SelectedValue.ToString(), Convert.ToDateTime(dateTimePicker1.Value.ToString()).ToString(), Convert.ToDateTime(dateTimePicker2.Value.ToString()).ToString());

            }
        }
    }
}
