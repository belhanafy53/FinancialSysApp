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
using DevComponents.DotNetBar.Controls;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class CheqeesAuditFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        long Vlng_CheqID = 0;
        //bool Vbl_BasicData = false;
        //bool Vbl_ItemOrder = false;
        bool Vbl_Terms = false;
        public CheqeesAuditFrm()
        {
            InitializeComponent();
        }
        public void DtaGrdView()
        {
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ReferenceDate"].HeaderText = "تاريخ المراجعه";
            dataGridView1.Columns["ReferenceDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridView1.Columns["ReferenceDate"].Width = 200;
            dataGridView1.Columns["Name"].HeaderText = "المراجع";
            dataGridView1.Columns["IsCheqBank"].HeaderText = "مراجعة الشيك";
            dataGridView1.Columns["IsCheqBank"].Width = 70;
            dataGridView1.Columns["Note"].HeaderText = "الملاحظات";
            dataGridView1.Columns["Note"].Width = 200;
            dataGridView1.Columns["Name"].Width = 220;
            dataGridView1.Columns["user_id"].Visible = false;

            //dataGridView1.Columns["supp_ID"].Visible = false;

        }
        private void CheqeesAuditFrm_Load(object sender, EventArgs e)
        {
            Vlng_CheqID = long.Parse(txtCheqId.Text);
            // TODO: This line of code loads data into the 'bankCheques.DtbTreasuryCollection_Audit' table. You can move, or remove it, as needed.
            this.dtbTreasuryCollection_AuditTableAdapter.FillByUser(this.bankCheques.DtbTreasuryCollection_Audit, Vlng_CheqID);


            //var ListOrderAudit = (from chqAud in FsDb.Tbl_TreasuryCollection_Audit
            //                      join usr in FsDb.Tbl_User on chqAud.UserID equals usr.ID
            //                      join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID

            //                      where (chqAud.BankCheqeID == Vlng_CheqID)
            //                      select new
            //                      {
            //                          ID = chqAud.ID,
            //                          user_id = chqAud.UserID,
            //                          IsCheqBank = chqAud.IsCheqBank,
            //                          Note = chqAud.Note,
            //                          Name = emp.Name,
            //                          ReferenceDate = chqAud.ReferenceDate
            //                      }).OrderBy(x => x.ReferenceDate).ToList();
            //dataGridView1.DataSource = ListOrderAudit;
            //DtaGrdView();
        }
    }
}
