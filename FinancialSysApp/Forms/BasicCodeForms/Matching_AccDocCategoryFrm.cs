using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserRoles;
using DevExpress.XtraEditors;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class Matching_AccDocCategoryFrm : DevExpress.XtraEditors.XtraForm
    {
        int xExCid = 0;
        int Vint_ACCId = 0;
        int Vint_PrKindId = 0;
        int Vint_ItemId = 0;
        int Vint_PayMthId = 0;
        int Vint_MatchingID = 0;
        //int Vint_ACCId = 0;
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public Matching_AccDocCategoryFrm()
        {
            InitializeComponent();

        }

        private void Matching_AccDocCategoryFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items1' table. You can move, or remove it, as needed.
            this.tbl_Items1TableAdapter.FillItemParentNull(this.financialSysDataSet.Tbl_Items1);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items' table. You can move, or remove it, as needed.
            this.tbl_ItemsTableAdapter.Fill(this.financialSysDataSet.Tbl_Items);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_PaymentMethod' table. You can move, or remove it, as needed.
            this.tbl_PaymentMethodTableAdapter.Fill(this.financialSysDataSet.Tbl_PaymentMethod);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items1' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Processing_Kind' table. You can move, or remove it, as needed.
            this.tbl_Processing_KindTableAdapter.Fill(this.financialSysDataSet.Tbl_Processing_Kind);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Accounting_Guid' table. You can move, or remove it, as needed.
            this.tbl_Accounting_GuidTableAdapter.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Accounting_Guid' table. You can move, or remove it, as needed.
            this.tbl_Accounting_GuidTableAdapter.Fill(this.financialSysDataSet.Tbl_Accounting_Guid);

            tblProcessingKindBindingSource.DataSource = FsDb.Tbl_Processing_Kind.ToList();
            AutoCompleteStringCollection PrK = new AutoCompleteStringCollection();
            foreach (Tbl_Processing_Kind d in tblProcessingKindBindingSource.DataSource as List<Tbl_Processing_Kind>)
                PrK.Add(d.Name);
            ProcessingKindTxt.AutoCompleteCustomSource = PrK;

            //****************

            tblItemsBindingSource.DataSource = FsDb.Tbl_Items.Where(x => x.Parent_ID == null).ToList();
            AutoCompleteStringCollection itm = new AutoCompleteStringCollection();
            foreach (Tbl_Items d in tblItemsBindingSource.DataSource as List<Tbl_Items>)
                itm.Add(d.Name);
            ItemTxt.AutoCompleteCustomSource = itm;
            //***************************

            dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                        join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                        join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                        join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                        join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                        //where (AccMD.Accounting_GuidID == Vint_ACCId)

                                        select new
                                        {
                                            ID = AccMD.ID,
                                            Accounting_GuidID = AccMD.Accounting_GuidID,
                                            Accounting_GuidNo = accg.Account_NO,
                                            account_GuidName = accg.Name,
                                            prociessingKindName = pk.Name,
                                            processingKindID = AccMD.ProcessingKindID,
                                            itemName = it.Name,
                                            ItemID = AccMD.ItemsID,

                                            PaymentMName = Pmt.Name,
                                            PaymentId = AccMD.PaymentMethodID,
                                            NoteMatch = AccMD.Note

                                        }).OrderBy(x => x.ID).ToList();

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Accounting_GuidID"].Visible = false;
            dataGridView1.Columns["processingKindID"].Visible = false;
            dataGridView1.Columns["ItemID"].Visible = false;

            dataGridView1.Columns["PaymentId"].Visible = false;
            dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
            dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
              dataGridView1.Columns["account_GuidName"].Width = 200;
            dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
            dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
            dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
            dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
            //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
            dataGridView1.Columns["NoteMatch"].Width = 200;
            PaymentMethodCmb.SelectedIndex = -1;
            PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
            ProcessingKindTxt.Select();
            this.ActiveControl = ProcessingKindTxt;
            ProcessingKindTxt.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //FsDb.Tbl_Accounting_Guid.Where(x => x.Name.Contains(textBox1.Text) && x.Account_NO == (textBox1.Text) + "%").OrderBy(x => x.Parent_ID).ToList();

            var list = (from AccG in FsDb.Tbl_Accounting_Guid

                        where (AccG.Account_NO.Contains(textBox1.Text) || AccG.Name.StartsWith(textBox1.Text))

                        select new
                        {
                            ID = AccG.ID,
                            Name = AccG.Name,
                            Account_NO = AccG.Account_NO,
                            Parent_ID = AccG.Parent_ID


                        }).OrderBy(x => x.ID).ToList();
            treeList1.DataSource = list;

            treeList1.ExpandAll();

            textBox2.Text = "";
            textBox6.Text = "";

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                treeList1.Focus();
            }
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                AccIDTxt.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString();
                textBox2.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString();
                textBox6.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
                textBox7.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString();

                //comboBox1.SelectedValue = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString());
                Vint_ACCId = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString());

                dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                            join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                            join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                            join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                            join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                            where (AccMD.ProcessingKindID == Vint_PrKindId && AccMD.ProcessingKindID == Vint_ItemId && AccMD.PaymentMethodID == Vint_PayMthId && AccMD.Accounting_GuidID == Vint_ACCId)

                                            select new
                                            {
                                                ID = AccMD.ID,
                                                Accounting_GuidID = AccMD.Accounting_GuidID,
                                                Accounting_GuidNo = accg.Account_NO,
                                                account_GuidName = accg.Name,
                                                prociessingKindName = pk.Name,
                                                processingKindID = AccMD.ProcessingKindID,
                                                itemName = it.Name,
                                                ItemID = AccMD.ItemsID,

                                                PaymentMName = Pmt.Name,
                                                PaymentId = AccMD.PaymentMethodID,
                                                NoteMatch = AccMD.Note

                                            }).OrderBy(x => x.ID).ToList();

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                dataGridView1.Columns["processingKindID"].Visible = false;
                dataGridView1.Columns["ItemID"].Visible = false;

                dataGridView1.Columns["PaymentId"].Visible = false;
                dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                  dataGridView1.Columns["account_GuidName"].Width = 200;
                dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                dataGridView1.Columns["NoteMatch"].Width = 200;
                simpleButton1.Select();
                this.ActiveControl = simpleButton1;
                simpleButton1.Focus();

            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory
                                                //join dc in FsDb.Tbl_DocumentCategory on AccMD.DocumentCategoryID equals dc.ID
                                            join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                            //where (dc.Name.Contains(textBox3.Text))

                                            select new
                                            {
                                                ID = AccMD.ID,
                                                //Name = dc.Name,
                                                Accounting_GuidID = AccMD.Accounting_GuidID
                                                //DocumentCategoryID = AccMD.DocumentCategoryID,

                                            }).OrderBy(x => x.ID).ToList();
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                dataGridView1.Columns["DocumentCategoryID"].Visible = false;
                dataGridView1.Columns["Name"].HeaderText = "البيان";
                dataGridView1.Columns["Name"].Width = 300;
                textBox3.Select();
                this.ActiveControl = textBox3;
                textBox3.Focus();

            }
            else
            {
                textBox3.Select();
                this.ActiveControl = textBox3;
                textBox3.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                MatchingIDTxt.Text = "";


                Vint_MatchingID = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                MatchingIDTxt.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                Vint_ACCId = int.Parse(dataGridView1.CurrentRow.Cells["Accounting_GuidID"].Value.ToString());

                Vint_PrKindId = int.Parse(dataGridView1.CurrentRow.Cells["processingKindID"].Value.ToString());
                Vint_ItemId = int.Parse(dataGridView1.CurrentRow.Cells["ItemID"].Value.ToString());
                Vint_PayMthId = int.Parse(dataGridView1.CurrentRow.Cells["PaymentId"].Value.ToString());

                //textBox1.Text = dataGridView1.CurrentRow.Cells["Accounting_GuidNo"].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells["account_GuidName"].Value.ToString();
                ProcessingKindTxt.Text = dataGridView1.CurrentRow.Cells["prociessingKindName"].Value.ToString();
                ItemTxt.Text = dataGridView1.CurrentRow.Cells["itemName"].Value.ToString();
                PaymentMethodCmb.SelectedValue = Vint_PayMthId;
                DocumntCatTxt.Text = dataGridView1.CurrentRow.Cells["NoteMatch"].Value.ToString();


            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                if (textBox3.Text != "")
                {
                    int Vint_DocCgId = int.Parse(CategortID.Text);
                    var list = FsDb.Tbl_Match_AccGuid_DocCategory.Where(r => r.Accounting_GuidID == Vint_ACCId).ToList();
                    if (list.Count() > 0)
                    {
                        MessageBox.Show("هذا البيات" + " '" + textBox3.Text + "' " + "تم اضافته من قبل للحساب رقم  " + "' " + textBox2.Text);
                        textBox3.Text = "";
                        textBox3.Focus();
                    }
                    else
                    {

                        simpleButton1.Focus();
                    }
                }
            }
            if (e.KeyCode == Keys.Down && textBox3.Focus() == true)
            {
                try
                {
                    Forms.ProcessingForms.FindCatregory f = new Forms.ProcessingForms.FindCatregory();
                    f.ShowDialog();
                    textBox3.Text = Forms.ProcessingForms.FindCatregory.SelectedRow.Cells[1].Value.ToString();
                    CategortID.Text = Forms.ProcessingForms.FindCatregory.SelectedRow.Cells[0].Value.ToString();
                    Vint_ACCId = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString());
                    //int list = FsDb.Tbl_Match_AccGuid_DocCategory.Where(r => r.DocumentCategoryID == int.Parse(CategortID.Text) && r.Accounting_GuidID == Vint_ACCId).Count();
                    //*************


                    dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory
                                                    //join dc in FsDb.Tbl_DocumentCategory on AccMD.DocumentCategoryID equals dc.ID
                                                join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                where (AccMD.Accounting_GuidID == Vint_ACCId)

                                                select new
                                                {
                                                    ID = AccMD.ID,
                                                    //Name = dc.Name,
                                                    Accounting_GuidID = AccMD.Accounting_GuidID
                                                    //DocumentCategoryID = AccMD.DocumentCategoryID,

                                                }).OrderBy(x => x.ID).ToList();

                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                    dataGridView1.Columns["DocumentCategoryID"].Visible = false;
                    dataGridView1.Columns["Name"].HeaderText = "البيان";
                    dataGridView1.Columns["Name"].Width = 300;
                    CategortID.Text = Forms.ProcessingForms.FindCatregory.SelectedRow.Cells[0].Value.ToString();
                    Vint_ACCId = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString());

                }

                catch { }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            MatchingIDTxt.Text = "";


            Vint_MatchingID = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            MatchingIDTxt.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            Vint_ACCId = int.Parse(dataGridView1.CurrentRow.Cells["Accounting_GuidID"].Value.ToString());

            Vint_PrKindId = int.Parse(dataGridView1.CurrentRow.Cells["processingKindID"].Value.ToString());
            Vint_ItemId = int.Parse(dataGridView1.CurrentRow.Cells["ItemID"].Value.ToString());
            Vint_PayMthId = int.Parse(dataGridView1.CurrentRow.Cells["PaymentId"].Value.ToString());


            //textBox1.Text = dataGridView1.CurrentRow.Cells["Accounting_GuidNo"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["account_GuidName"].Value.ToString();
            ProcessingKindTxt.Text = dataGridView1.CurrentRow.Cells["prociessingKindName"].Value.ToString();
            ProcessingKindIDTxt.Text = Vint_PrKindId.ToString();
            ItemTxt.Text = dataGridView1.CurrentRow.Cells["itemName"].Value.ToString();
            ItemIDTxt.Text = Vint_ItemId.ToString();
            PaymentMethodCmb.SelectedValue = Vint_PayMthId;
            AccIDTxt.Text = Vint_ACCId.ToString();
            DocumntCatTxt.Text = dataGridView1.CurrentRow.Cells["NoteMatch"].Value.ToString();






        }

        private void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            AccIDTxt.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString();
            textBox2.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[1]).ToString();
            textBox6.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[0]).ToString();
            textBox7.Text = treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString();

            //comboBox1.SelectedValue = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString());
            Vint_ACCId = int.Parse(treeList1.GetFocusedRowCellValue(treeList1.Columns[2]).ToString());
            if (MatchingIDTxt.Text == "")
            {
                dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                            join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                            join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                            join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                            join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                            where (AccMD.ProcessingKindID == Vint_PrKindId && AccMD.ProcessingKindID == Vint_ItemId && AccMD.PaymentMethodID == Vint_PayMthId && AccMD.Accounting_GuidID == Vint_ACCId)

                                            select new
                                            {
                                                ID = AccMD.ID,
                                                Accounting_GuidID = AccMD.Accounting_GuidID,
                                                Accounting_GuidNo = accg.Account_NO,
                                                account_GuidName = accg.Name,
                                                prociessingKindName = pk.Name,

                                                itemName = it.Name,
                                                PaymentMName = Pmt.Name,
                                                NoteMatch = AccMD.Note

                                            }).OrderBy(x => x.ID).ToList();

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                  dataGridView1.Columns["account_GuidName"].Width = 200;
                dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                dataGridView1.Columns["NoteMatch"].Width = 200;
                simpleButton1.Select();
                this.ActiveControl = simpleButton1;
            }
            simpleButton1.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Vint_ACCId = int.Parse(AccIDTxt.Text);
            Vint_PrKindId = int.Parse(ProcessingKindIDTxt.Text);
            Vint_ItemId = int.Parse(ItemIDTxt.Text);
            Vint_PayMthId = int.Parse(PaymentMethodCmb.SelectedValue.ToString());
            if (MatchingIDTxt.Text == "")
            {
                if (ProcessingKindIDTxt.Text == "")
                {
                    MessageBox.Show("من فضلك قم بإختيار نوع العملية  ");
                }
                else if (ItemIDTxt.Text == "")
                {
                    MessageBox.Show("من فضلك قم بإختيار البند  ");
                }
                //else if (PaymentMethodCmb.SelectedValue == null)
                //{
                //    MessageBox.Show("من فضلك قم بإختيار طريقة الدفع  ");
                //}
                else if (AccIDTxt.Text == "")
                {
                    MessageBox.Show("من فضلك قم بإختيار الحساب من الدليل  ");
                }

                else
                {

                    Vint_ACCId = int.Parse(AccIDTxt.Text);

                    var list = FsDb.Tbl_Match_AccGuid_DocCategory.Where(r => r.Accounting_GuidID == Vint_ACCId && r.PaymentMethodID == Vint_PayMthId && r.ItemsID == Vint_ItemId && r.ProcessingKindID == Vint_PrKindId).ToList();
                    if (list.Count() > 0)
                    {
                        MessageBox.Show("هذا الربط تم اضافته من قبل");
                        ProcessingKindTxt.Text = "";
                        AccIDTxt.Text = "";
                        ItemIDTxt.Text = "";
                        PaymentMethodCmb.SelectedIndex = -1;
                        PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - تسويات";
                        ProcessingKindTxt.Focus();
                    }
                    else
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 47 && w.ProcdureId == 1);
                        if (validationSaveUser != null)
                        {

                            Tbl_Match_AccGuid_DocCategory exchc = new Tbl_Match_AccGuid_DocCategory
                            {
                                Accounting_GuidID = int.Parse(AccIDTxt.Text),
                                ItemsID = Vint_ItemId,
                                PaymentMethodID = Vint_PayMthId,
                                ProcessingKindID = int.Parse(ProcessingKindIDTxt.Text),
                                Note = DocumntCatTxt.Text
                            };
                            FsDb.Tbl_Match_AccGuid_DocCategory.Add(exchc);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            int Vint_LastRow = exchc.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة ربط بيانات لرقم حساب",
                                TableName = "Tbl_Match_AccGuid_DocCategory",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة ربط بيانات برقم حساب"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("تم الحفظ");
                            dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                                        join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                        join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                                        join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                                        join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                                        //where (AccMD.Accounting_GuidID == Vint_ACCId)

                                                        select new
                                                        {
                                                            ID = AccMD.ID,
                                                            Accounting_GuidID = AccMD.Accounting_GuidID,
                                                            Accounting_GuidNo = accg.Account_NO,
                                                            account_GuidName = accg.Name,
                                                            prociessingKindName = pk.Name,
                                                            processingKindID = AccMD.ProcessingKindID,
                                                            itemName = it.Name,
                                                            ItemID = AccMD.ItemsID,

                                                            PaymentMName = Pmt.Name,
                                                            PaymentId = AccMD.PaymentMethodID,
                                                            NoteMatch = AccMD.Note

                                                        }).OrderBy(x => x.ID).ToList();

                            dataGridView1.Columns["ID"].Visible = false;
                            dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                            dataGridView1.Columns["processingKindID"].Visible = false;
                            dataGridView1.Columns["ItemID"].Visible = false;

                            dataGridView1.Columns["PaymentId"].Visible = false;
                            dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                            dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                              dataGridView1.Columns["account_GuidName"].Width = 200;
                            dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                            dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                            dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                            dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                            //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                            dataGridView1.Columns["NoteMatch"].Width = 200;
                            xExCid = 0;
                            textBox3.Text = "";
                            textBox6.Text = "";
                            CategortID.Text = "";
                            ProcessingKindTxt.Text = "";
                            ProcessingKindIDTxt.Text = "";
                            ItemTxt.Text = "";
                            ItemIDTxt.Text = "";
                            textBox1.Text = "";
                            AccIDTxt.Text = "";
                            DocumntCatTxt.Text = "";
                            PaymentMethodCmb.SelectedIndex = -1;
                            PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";

                            //textBox7.Text = "";

                            textBox3.Select();
                            this.ActiveControl = textBox3;
                            textBox3.Focus();
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية اضافة  الربط .. برجاء مراجعة مدير المنظومه");
                        }
                    }

                }
            }
            else
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 47 && w.ProcdureId == 3);
                if (validationSaveUser != null)
                {
                    int Vint_MatchId = int.Parse(MatchingIDTxt.Text);
                    var listEdit = FsDb.Tbl_Match_AccGuid_DocCategory.FirstOrDefault(x => x.ID == Vint_MatchId);
                    listEdit.ProcessingKindID = int.Parse(ProcessingKindIDTxt.Text);
                    listEdit.ItemsID = int.Parse(ItemIDTxt.Text);
                    listEdit.PaymentMethodID = int.Parse(PaymentMethodCmb.SelectedValue.ToString());
                    listEdit.Accounting_GuidID = int.Parse(AccIDTxt.Text);
                    listEdit.Note = DocumntCatTxt.Text;
                    FsDb.SaveChanges();
                    //---------------خفظ ااحداث 
                    //int Vint_LastRow = exchc.ID;
                    SecurityEvent sev = new SecurityEvent
                    {
                        ActionName = "تعديل ربط بيانات لرقم حساب",
                        TableName = "Tbl_Match_AccGuid_DocCategory",
                        TableRecordId =  MatchingIDTxt.Text,
                        Description = "",
                        ManagementName = Program.GlbV_Management,
                        ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                        EmployeeName = Program.GlbV_EmpName,
                        User_ID = Program.GlbV_UserId,
                        UserName = Program.GlbV_UserName,
                        FormName = "شاشة ربط بيانات برقم حساب"


                    };
                    FsEvDb.SecurityEvents.Add(sev);
                    FsEvDb.SaveChanges();
                    //***************************
                    MessageBox.Show("تم التعديل");
                    dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                                join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                                join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                                join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                                //where (AccMD.Accounting_GuidID == Vint_ACCId)

                                                select new
                                                {
                                                    ID = AccMD.ID,
                                                    Accounting_GuidID = AccMD.Accounting_GuidID,
                                                    Accounting_GuidNo = accg.Account_NO,
                                                    account_GuidName = accg.Name,
                                                    prociessingKindName = pk.Name,
                                                    processingKindID = AccMD.ProcessingKindID,
                                                    itemName = it.Name,
                                                    ItemID = AccMD.ItemsID,

                                                    PaymentMName = Pmt.Name,
                                                    PaymentId = AccMD.PaymentMethodID,
                                                    NoteMatch = AccMD.Note

                                                }).OrderBy(x => x.ID).ToList();

                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                    dataGridView1.Columns["processingKindID"].Visible = false;
                    dataGridView1.Columns["ItemID"].Visible = false;

                    dataGridView1.Columns["PaymentId"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                    dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                      dataGridView1.Columns["account_GuidName"].Width = 200;
                    dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                    dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                    dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                    dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                    //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                    dataGridView1.Columns["NoteMatch"].Width = 200;
                    xExCid = 0;
                    textBox3.Text = "";
                    textBox6.Text = "";
                    CategortID.Text = "";
                    ProcessingKindTxt.Text = "";
                    ProcessingKindIDTxt.Text = "";
                    ItemTxt.Text = "";
                    ItemIDTxt.Text = "";
                    textBox1.Text = "";
                    AccIDTxt.Text = "";
                    DocumntCatTxt.Text = "";
                    PaymentMethodCmb.SelectedIndex = -1;
                    PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";

                    //textBox7.Text = "";

                    textBox3.Select();
                    this.ActiveControl = textBox3;
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية تعديل الربط .. برجاء مراجعة مدير المنظومه");
                }
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 47 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    if (textBox3.Text != "")
                    {
                        int Vint_DocCID = int.Parse(CategortID.Text);
                        int Vint_accId = int.Parse(textBox7.Text);
                        var AccFind = FsDb.Tbl_Accounting_Guid.FirstOrDefault(x => x.ID == Vint_accId);
                        textBox6.Text = AccFind.Name;
                        var resultd = FsDb.Tbl_Match_AccGuid_DocCategory.Where(x => x.ID == xExCid);
                        if (resultd != null)
                        {
                            var result1 = MessageBox.Show("هل تريد حدف هدا الربط  ؟", "حدف ربط بيان" + " - " + textBox3.Text + " - " + "برقم حساب " + " -" + textBox2.Text + "-" + textBox6.Text, MessageBoxButtons.YesNo);
                            if (result1 == DialogResult.Yes)
                            {
                                var resultr = FsDb.Tbl_Match_AccGuid_DocCategory.FirstOrDefault(x => x.ID == xExCid && x.Accounting_GuidID == Vint_accId);
                                FsDb.Tbl_Match_AccGuid_DocCategory.Remove(resultr);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 

                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف ربط بيان برقم حساب ",
                                    TableName = "Tbl_Match_AccGuid_DocCategory",
                                    TableRecordId = resultr.ID.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة ربط بيانات برقم حساب"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //***************************
                                MessageBox.Show("  تم الحدف");
                                dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                                            join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                            join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                                            join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                                            join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                                            //where (AccMD.Accounting_GuidID == Vint_ACCId)

                                                            select new
                                                            {
                                                                ID = AccMD.ID,
                                                                Accounting_GuidID = AccMD.Accounting_GuidID,
                                                                Accounting_GuidNo = accg.Account_NO,
                                                                account_GuidName = accg.Name,
                                                                prociessingKindName = pk.Name,
                                                                processingKindID = AccMD.ProcessingKindID,
                                                                itemName = it.Name,
                                                                ItemID = AccMD.ItemsID,

                                                                PaymentMName = Pmt.Name,
                                                                PaymentId = AccMD.PaymentMethodID,
                                                                NoteMatch = AccMD.Note

                                                            }).OrderBy(x => x.ID).ToList();

                                dataGridView1.Columns["ID"].Visible = false;
                                dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                                dataGridView1.Columns["processingKindID"].Visible = false;
                                dataGridView1.Columns["ItemID"].Visible = false;

                                dataGridView1.Columns["PaymentId"].Visible = false;
                                dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                                dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                                  dataGridView1.Columns["account_GuidName"].Width = 200;
                                dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                                dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                                dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                                dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                                //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                                dataGridView1.Columns["NoteMatch"].Width = 200;
                                xExCid = 0;
                                textBox3.Text = "";
                                textBox6.Text = "";
                                CategortID.Text = "";
                                ProcessingKindTxt.Text = "";
                                ProcessingKindIDTxt.Text = "";
                                ItemTxt.Text = "";
                                ItemIDTxt.Text = "";
                                textBox1.Text = "";
                                AccIDTxt.Text = "";
                                DocumntCatTxt.Text = "";
                                PaymentMethodCmb.SelectedIndex = -1;
                                PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";

                                ProcessingKindTxt.Select();
                                this.ActiveControl = ProcessingKindTxt;
                                ProcessingKindTxt.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("حدد البيان المراد حدفه");
                        ProcessingKindTxt.Select();
                        this.ActiveControl = ProcessingKindTxt;
                        ProcessingKindTxt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف  مركز صرف .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch { }


            //{
            //    MessageBox.Show("هذا البيان  لايمكن حذفه لوجود مستندات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void ProcessingKindTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DocumntCatTxt.Text = "";
                var ListAPrBalance = FsDb.Tbl_Processing_Kind.FirstOrDefault(x => x.Name.Contains(ProcessingKindTxt.Text));
                ProcessingKindTxt.Text = ListAPrBalance.Name.ToString();
                ProcessingKindIDTxt.Text = ListAPrBalance.ID.ToString();
                DocumntCatTxt.Text = ListAPrBalance.Note.ToString();
                Vint_PrKindId = int.Parse(ProcessingKindIDTxt.Text);
                if (MatchingIDTxt.Text == "")
                {
                   
                    dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                                join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                                join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                                join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                                where (AccMD.ProcessingKindID == Vint_PrKindId)

                                                select new
                                                {
                                                    ID = AccMD.ID,
                                                    Accounting_GuidID = AccMD.Accounting_GuidID,
                                                    Accounting_GuidNo = accg.Account_NO,
                                                    account_GuidName = accg.Name,
                                                    prociessingKindName = pk.Name,
                                                    processingKindID = AccMD.ProcessingKindID,
                                                    itemName = it.Name,
                                                    ItemID = AccMD.ItemsID,

                                                    PaymentMName = Pmt.Name,
                                                    PaymentId = AccMD.PaymentMethodID,
                                                    NoteMatch = AccMD.Note

                                                }).OrderBy(x => x.ID).ToList();

                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                    dataGridView1.Columns["processingKindID"].Visible = false;
                    dataGridView1.Columns["ItemID"].Visible = false;

                    dataGridView1.Columns["PaymentId"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                    dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                      dataGridView1.Columns["account_GuidName"].Width = 200;
                    dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                    dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                    dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                    dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                    //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                    dataGridView1.Columns["NoteMatch"].Width = 200;
                }
                ItemTxt.Focus();

            }
        }

        private void ItemTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ListABalance = FsDb.Tbl_Items.FirstOrDefault(x => x.Name.Contains(ItemTxt.Text));
                ItemTxt.Text = ListABalance.Name.ToString();
                ItemIDTxt.Text = ListABalance.ID.ToString();
                Vint_ItemId = int.Parse(ItemIDTxt.Text);
                DocumntCatTxt.Text = DocumntCatTxt.Text + " " + ItemTxt.Text;
                if (MatchingIDTxt.Text == "")
                {
                   
                    dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                                join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                                join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                                join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                                where (AccMD.ProcessingKindID == Vint_PrKindId && AccMD.ProcessingKindID == Vint_ItemId)

                                                select new
                                                {
                                                    ID = AccMD.ID,
                                                    Accounting_GuidID = AccMD.Accounting_GuidID,
                                                    Accounting_GuidNo = accg.Account_NO,
                                                    account_GuidName = accg.Name,
                                                    prociessingKindName = pk.Name,
                                                    processingKindID = AccMD.ProcessingKindID,
                                                    itemName = it.Name,
                                                    ItemID = AccMD.ItemsID,

                                                    PaymentMName = Pmt.Name,
                                                    PaymentId = AccMD.PaymentMethodID,
                                                    NoteMatch = AccMD.Note

                                                }).OrderBy(x => x.ID).ToList();

                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                    dataGridView1.Columns["processingKindID"].Visible = false;
                    dataGridView1.Columns["ItemID"].Visible = false;

                    dataGridView1.Columns["PaymentId"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                    dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                      dataGridView1.Columns["account_GuidName"].Width = 200;
                    dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                    dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                    dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                    dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                    //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                    dataGridView1.Columns["NoteMatch"].Width = 200;
                }
                PaymentMethodCmb.Focus();

            }
        }

        private void PaymentMethodCmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int? Vint_PMthod = 0;
                if (MatchingIDTxt.Text == "")
                {
                   

                        dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                                    join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                    join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                                    join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                                    join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                                    where (AccMD.ProcessingKindID == Vint_PrKindId && AccMD.ProcessingKindID == Vint_ItemId && AccMD.PaymentMethodID == Vint_PMthod)

                                                    select new
                                                    {
                                                        ID = AccMD.ID,
                                                        Accounting_GuidID = AccMD.Accounting_GuidID,
                                                        Accounting_GuidNo = accg.Account_NO,
                                                        account_GuidName = accg.Name,
                                                        prociessingKindName = pk.Name,
                                                        processingKindID = AccMD.ProcessingKindID,
                                                        itemName = it.Name,
                                                        ItemID = AccMD.ItemsID,

                                                        PaymentMName = Pmt.Name,
                                                        PaymentId = AccMD.PaymentMethodID,
                                                        NoteMatch = AccMD.Note

                                                    }).OrderBy(x => x.ID).ToList();

                        dataGridView1.Columns["ID"].Visible = false;
                        dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                        dataGridView1.Columns["processingKindID"].Visible = false;
                        dataGridView1.Columns["ItemID"].Visible = false;

                        dataGridView1.Columns["PaymentId"].Visible = false;
                        dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                        dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                          dataGridView1.Columns["account_GuidName"].Width = 200;
                        dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                        dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                        dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                        dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                        //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                        dataGridView1.Columns["NoteMatch"].Width = 200;
                        PaymentMethodCmb.Focus();
                     
                }
               
                if (PaymentMethodCmb.SelectedValue != null)
                {
                    Vint_PMthod = int.Parse(PaymentMethodCmb.SelectedValue.ToString());

                    var list = FsDb.Tbl_PaymentMethod.FirstOrDefault(x => x.ID == Vint_PMthod);
                    DocumntCatTxt.Text = "";
                    DocumntCatTxt.Text = list.Note + " " + DocumntCatTxt.Text + " " + ItemTxt.Text;
                }
                    textBox1.Focus();
            }
        }

        private void PaymentMethodCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int? Vint_PMthod = 0;
            if (MatchingIDTxt.Text == "")
            {
                
                   
                    dataGridView1.DataSource = (from AccMD in FsDb.Tbl_Match_AccGuid_DocCategory

                                                join accg in FsDb.Tbl_Accounting_Guid on AccMD.Accounting_GuidID equals accg.ID
                                                join Pmt in FsDb.Tbl_PaymentMethod on AccMD.PaymentMethodID equals Pmt.ID
                                                join pk in FsDb.Tbl_Processing_Kind on AccMD.ProcessingKindID equals pk.ID
                                                join it in FsDb.Tbl_Items on AccMD.ItemsID equals it.ID
                                                where (AccMD.ProcessingKindID == Vint_PrKindId && AccMD.ProcessingKindID == Vint_ItemId && AccMD.PaymentMethodID == Vint_PMthod)

                                                select new
                                                {
                                                    ID = AccMD.ID,
                                                    Accounting_GuidID = AccMD.Accounting_GuidID,
                                                    Accounting_GuidNo = accg.Account_NO,
                                                    account_GuidName = accg.Name,
                                                    prociessingKindName = pk.Name,
                                                    processingKindID = AccMD.ProcessingKindID,
                                                    itemName = it.Name,
                                                    ItemID = AccMD.ItemsID,

                                                    PaymentMName = Pmt.Name,
                                                    PaymentId = AccMD.PaymentMethodID,
                                                    NoteMatch = AccMD.Note

                                                }).OrderBy(x => x.ID).ToList();

                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidID"].Visible = false;
                    dataGridView1.Columns["processingKindID"].Visible = false;
                    dataGridView1.Columns["ItemID"].Visible = false;

                    dataGridView1.Columns["PaymentId"].Visible = false;
                    dataGridView1.Columns["Accounting_GuidNo"].HeaderText = "رقم الحساب";
                    dataGridView1.Columns["account_GuidName"].HeaderText = "اسم الحساب";
                      dataGridView1.Columns["account_GuidName"].Width = 200;
                    dataGridView1.Columns["PaymentMName"].HeaderText = "طريقة الدفع";
                    dataGridView1.Columns["itemName"].HeaderText = "اسم البند";
                    dataGridView1.Columns["prociessingKindName"].HeaderText = "نوع العملية";
                    dataGridView1.Columns["NoteMatch"].HeaderText = "البيان";
                    //PaymentMethodCmb.SelectedText = "اختر طريقة الدفع - التسويات";
                    dataGridView1.Columns["NoteMatch"].Width = 200;
               

            }
            
            if (PaymentMethodCmb.SelectedValue != null)
            {
                Vint_PMthod = int.Parse(PaymentMethodCmb.SelectedValue.ToString());

                var list = FsDb.Tbl_PaymentMethod.FirstOrDefault(x => x.ID == Vint_PMthod);
                DocumntCatTxt.Text = "";
                DocumntCatTxt.Text = list.Note + " " + ProcessingKindTxt.Text + " " + ItemTxt.Text;
            }
            
        }


    }
}





