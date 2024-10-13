using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevExpress.XtraEditors;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class AccountRstAuditFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        long Vlng_OrderID = 0;
        //bool Vbl_BasicData = false;
        bool Vbl_ItemOrder = false;
        //bool Vbl_Terms = false;
        public AccountRstAuditFrm()
        {
            InitializeComponent();
        }
        public void DtaGrdView()
        {
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ReferenceDate"].HeaderText = "تاريخ المراجعه";
            dataGridView1.Columns["EmpName"].HeaderText = "المراجع";
            dataGridView1.Columns["OrderIBasicDataID"].HeaderText = "البيانات الاساسيه";
            dataGridView1.Columns["OrderIItemDataID"].HeaderText = "بنود الامر";
            dataGridView1.Columns["OrderITermsID"].HeaderText = "شروط الامر";
            dataGridView1.Columns["EmpName"].Width = 220;
            dataGridView1.Columns["user_id"].Visible = false;

            //dataGridView1.Columns["supp_ID"].Visible = false;

        }
        private void AccountRstAuditFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_AccountingRestriction_Audit' table. You can move, or remove it, as needed.
            this.dTB_AccountingRestriction_AuditTableAdapter.Fill(this.financialSysDataSet.DTB_AccountingRestriction_Audit);
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_AccountingRestriction_Audit' table. You can move, or remove it, as needed.
            this.dTB_AccountingRestriction_AuditTableAdapter.Fill(this.financialSysDataSet.DTB_AccountingRestriction_Audit);
            Vlng_OrderID = long.Parse(txtAccRstId.Text);
            // TODO: This line of code loads data into the 'financialSysDataSet.Dtb_OrderAudit' table. You can move, or remove it, as needed.
            this.dTB_AccountingRestriction_AuditTableAdapter.FillByAccRst(this.financialSysDataSet.DTB_AccountingRestriction_Audit, Vlng_OrderID);




            var ListOrderAudit = (from AccRsAud in FsDb.Tbl_AccountingRestriction_Audit
                                  join usr in FsDb.Tbl_User on AccRsAud.UserID equals usr.ID
                                  join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID

                                  where (AccRsAud.AccountingRestrictionID == Vlng_OrderID)
                                  select new
                                  {
                                      ID = AccRsAud.ID,
                                      user_id = AccRsAud.UserID,
                                      RestrictionDataID = AccRsAud.RestrictionDataID,
                                      ReferenceDate = AccRsAud.ReferenceDate 
                                  }).OrderBy(x => x.ReferenceDate).ToList();


        }
    }
}