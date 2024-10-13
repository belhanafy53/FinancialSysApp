using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.DataProcessing;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class FindOrdersFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_SupId = 0;
        public static DataGridViewRow SelectedRow { get; set; }
        int Vint_cmbOrderId = 0;
        public FindOrdersFrm()
        {
            InitializeComponent();
        }

        private void FindOrdersFrm_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_OrderKind' table. You can move, or remove it, as needed.
            this.tbl_OrderKindTableAdapter.Fill(this.financialSysDataSet.Tbl_OrderKind);
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Orders' table. You can move, or remove it, as needed.
            //Vint_SupId = int.Parse(txtSupId.Text);
            if (textEdit1.Text != "")
            { Vint_cmbOrderId = int.Parse(textEdit1.Text); }
            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();

        }
        public void DtaGrdView()
        {
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Order_NO"].HeaderText = "رقم الامر";
            dataGridView1.Columns["Order_Date"].HeaderText = "تاريخ الامر";
            dataGridView1.Columns["Order_Date"].DefaultCellStyle.Format = "yyyy/MM/dd";
            dataGridView1.Columns["purchaseMethodName"].HeaderText = "طريقة الشراء";
            dataGridView1.Columns["Tender_No"].HeaderText = "رقم طريقة الشراء";
            dataGridView1.Columns["TNote"].Width = 150;
            dataGridView1.Columns["TNote"].HeaderText = "الغرض";


            dataGridView1.Columns["TNote"].Width = 500;
            dataGridView1.Columns["Tender_No"].Width = 130;
            dataGridView1.Columns["suppName"].HeaderText = "المورد";
            dataGridView1.Columns["KindOrd"].HeaderText = "نوع الامر";
            dataGridView1.Columns["KindOrd"].Width = 150;
            dataGridView1.Columns["suppName"].Width = 500;
            dataGridView1.Columns["PurchaseMethodsID"].Visible = false;
            dataGridView1.Columns["kindordid"].Visible = false;
            dataGridView1.Columns["suppName"].Visible = false;
            dataGridView1.Columns["supp_ID"].Visible = false;



        }
        private void textBox1_EditValueChanged(object sender, EventArgs e)
        {

            //Vint_cmbOrderId = int.Parse(textEdit1.Text);
            if (txtSupId.Text != "")
            {
                Vint_SupId = int.Parse(txtSupId.Text);
            }
            if (textBox1.Text != "")
            {//**********************
                if (Vint_cmbOrderId == 1011)
                //*****************
                {
                    dataGridView1.DataSource = (from ord in FsDb.Tbl_Order
                                                join purchMth in FsDb.Tbl_PurchaseMethods on ord.PurchaseMethodsID equals purchMth.ID
                                                join supp in FsDb.Tbl_Supplier on ord.Supp_ID equals supp.ID
                                                join Tndr in FsDb.Tbl_TendersAuctions on ord.TendersAuctionsID equals Tndr.ID
                                                join ordK in FsDb.Tbl_OrderKind on ord.OrderKind_ID equals ordK.ID
                                                //where (ord.Order_NO.Contains(textBox1.Text) && ( ord.OrderKind_ID == Vint_cmbOrderId || supp.ID == Vint_SupId))
                                                where (ord.Order_NO == textBox1.Text && (ord.OrderKind_ID == Vint_cmbOrderId || supp.ID == Vint_SupId))
                                                select new
                                                {
                                                    ID = ord.ID,
                                                    Order_NO = ord.Order_NO,
                                                    Order_Date = ord.Order_Date,
                                                    PurchaseMethodsID = ord.PurchaseMethodsID,
                                                    purchaseMethodName = purchMth.Name,
                                                    suppName = supp.Name,
                                                    supp_ID = ord.Supp_ID,
                                                    Tender_No = Tndr.TenderNo,
                                                    TNote = Tndr.Note,
                                                    KindOrd = ordK.Name,
                                                    kindordid = ordK.ID,
                                                }
                                                                                                 ).OrderBy(x => x.Order_Date).ToList();
                    DtaGrdView();
                }
                else
                {
                    dataGridView1.DataSource = (from ord in FsDb.Tbl_Order
                                                join purchMth in FsDb.Tbl_PurchaseMethods on ord.PurchaseMethodsID equals purchMth.ID
                                                join supp in FsDb.Tbl_Supplier on ord.Supp_ID equals supp.ID
                                                join Tndr in FsDb.Tbl_TendersAuctions on ord.TendersAuctionsID equals Tndr.ID
                                                join ordK in FsDb.Tbl_OrderKind on ord.OrderKind_ID equals ordK.ID
                                                //where (ord.Order_NO.Contains(textBox1.Text) && ( ord.OrderKind_ID == Vint_cmbOrderId || supp.ID == Vint_SupId))
                                                where (ord.Order_NO == textBox1.Text)
                                                select new
                                                {
                                                    ID = ord.ID,
                                                    Order_NO = ord.Order_NO,
                                                    Order_Date = ord.Order_Date,
                                                    PurchaseMethodsID = ord.PurchaseMethodsID,
                                                    purchaseMethodName = purchMth.Name,
                                                    suppName = supp.Name,
                                                    supp_ID = ord.Supp_ID,
                                                    Tender_No = Tndr.TenderNo,
                                                    TNote = Tndr.Note,
                                                    KindOrd = ordK.Name,
                                                    kindordid = ordK.ID,
                                                }
                                                                              ).OrderBy(x => x.Order_Date).ToList();
                    DtaGrdView();
                }


            }
            else
            {
                dataGridView1.DataSource = (from ord in FsDb.Tbl_Order
                                            join purchMth in FsDb.Tbl_PurchaseMethods on ord.PurchaseMethodsID equals purchMth.ID
                                            join supp in FsDb.Tbl_Supplier on ord.Supp_ID equals supp.ID
                                            join Tndr in FsDb.Tbl_TendersAuctions on ord.TendersAuctionsID equals Tndr.ID
                                            join ordK in FsDb.Tbl_OrderKind on ord.OrderKind_ID equals ordK.ID

                                            where (ord.OrderKind_ID == Vint_cmbOrderId && supp.ID == Vint_SupId)

                                            select new
                                            {
                                                ID = ord.ID,
                                                Order_NO = ord.Order_NO,
                                                Order_Date = ord.Order_Date,
                                                PurchaseMethodsID = ord.PurchaseMethodsID,
                                                purchaseMethodName = purchMth.Name,
                                                suppName = supp.Name,
                                                supp_ID = ord.Supp_ID,
                                                Tender_No = Tndr.TenderNo,
                                                TNote = Tndr.Note,
                                                KindOrd = ordK.Name,
                                                kindordid = ordK.ID,
                                            }
                                                      ).OrderBy(x => x.Order_Date).ToList();
                DtaGrdView();


            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
                if (args != null)

                { dataGridView1_CellDoubleClick(dataGridView1, args); }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Vint_SupId = int.Parse(txtSupId.Text);
            //Vint_cmbOrderId = int.Parse(textEdit1.Text);

            dataGridView1.DataSource = (from ord in FsDb.Tbl_Order
                                        join purchMth in FsDb.Tbl_PurchaseMethods on ord.PurchaseMethodsID equals purchMth.ID
                                        join supp in FsDb.Tbl_Supplier on ord.Supp_ID equals supp.ID
                                        join Tndr in FsDb.Tbl_TendersAuctions on ord.TendersAuctionsID equals Tndr.ID
                                        join ordK in FsDb.Tbl_OrderKind on ord.OrderKind_ID equals ordK.ID
                                        //where (ord.Order_NO == textBox1.Text && ord.OrderKind_ID == Vint_cmbOrderId && supp.ID == Vint_SupId && ord.Order_Date == dateTimePicker1.Value)
                                        where (ord.Order_NO == textBox1.Text && ord.Order_Date == dateTimePicker1.Value)
                                        select new
                                        {
                                            ID = ord.ID,
                                            Order_NO = ord.Order_NO,
                                            Order_Date = ord.Order_Date,
                                            PurchaseMethodsID = ord.PurchaseMethodsID,
                                            purchaseMethodName = purchMth.Name,
                                            suppName = supp.Name,
                                            supp_ID = ord.Supp_ID,
                                            Tender_No = Tndr.TenderNo,
                                            TNote = Tndr.Note,
                                            KindOrd = ordK.Name,
                                            kindordid = ordK.ID,
                                        }
                                                         ).OrderBy(x => x.Order_Date).ToList();
            DtaGrdView();

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //Vint_SupId = int.Parse(txtSupId.Text);
            //Vint_cmbOrderId = int.Parse(textEdit1.Text);
            //if (textEdit2.Text != "")
            //{
            //    dataGridView1.DataSource = (from ord in FsDb.Tbl_Order
            //                                join purchMth in FsDb.Tbl_PurchaseMethods on ord.PurchaseMethodsID equals purchMth.ID
            //                                join supp in FsDb.Tbl_Supplier on ord.Supp_ID equals supp.ID
            //                                where (supp.Name.Contains(textEdit2.Text) && ord.OrderKind_ID == Vint_cmbOrderId && supp.ID == Vint_SupId)
            //                                select new
            //                                {
            //                                    ID = ord.ID,
            //                                    Order_NO = ord.Order_NO,
            //                                    Order_Date = ord.Order_Date,
            //                                    PurchaseMethodsID = ord.PurchaseMethodsID,
            //                                    purchaseMethodName = purchMth.Name,
            //                                    suppName = supp.Name,
            //                                    supp_ID = ord.Supp_ID
            //                                }
            //                                                            ).OrderBy(x => x.Order_Date).ToList();
            //    DtaGrdView();
            //}
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }
    }
}
