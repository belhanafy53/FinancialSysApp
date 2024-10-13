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
    public partial class AddDataByUsersFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        long Vlng_id = 0;
        string Vstr_id = "";
        //bool Vbl_BasicData = false;
        //bool Vbl_ItemOrder = false;
        bool Vbl_Terms = false;
        public AddDataByUsersFrm()
        {
            InitializeComponent();
        }
        public void DtaGrdView()
        {
            dataGridView1.Columns["ID"].Visible = false;
            
            dataGridView1.Columns["EmpName"].HeaderText = "اسم مدخل القيد";
            //dataGridView1.Columns["OrderIBasicDataID"].HeaderText = "البيانات الاساسيه";
            //dataGridView1.Columns["OrderIItemDataID"].HeaderText = "بنود الامر";
            //dataGridView1.Columns["OrderITermsID"].HeaderText = "شروط الامر";
            dataGridView1.Columns["EmpName"].Width = 220;
            dataGridView1.Columns["user_id"].Visible = false;

            //dataGridView1.Columns["supp_ID"].Visible = false;

        }
        private void AddDataByUsersFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysEventsDataSet3.Dtb_SecurityEvent' table. You can move, or remove it, as needed.
            Vlng_id = long.Parse(txtRstAccId.Text);
            Vstr_id = txtRstAccId.Text;

            if (txtKindProcess.Text == "1")
            {
                this.dtb_SecurityEventTableAdapter.FillByAccRstID(this.financialSysEventsDataSet3.Dtb_SecurityEvent, Vlng_id);
            }
            else if  (txtKindProcess.Text == "2")
            {
                this.dtb_SecurityEventTableAdapter.FillByOrderID(this.financialSysEventsDataSet3.Dtb_SecurityEvent, Vstr_id);
            }
           
           

            
        }
    }
}
