﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraEditors;

namespace FinancialSysApp.Forms.Abstracts
{
    public partial class RulesAbstractsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public RulesAbstractsFrm()
        {
            InitializeComponent();
        }

        private void txtTendersNo_KeyDown(object sender, KeyEventArgs e)
        {
            Forms.ProcessingForms.FindTendersFrm t = new Forms.ProcessingForms.FindTendersFrm();
            

                t.textEdit1.Text = "9".ToString();
                t.comboBox1.SelectedValue = 9;
            t.txtpurchMethodName.Text = "ممارسه عامه";
            t.ShowDialog();

                if (Forms.ProcessingForms.FindTendersFrm.SelectedRow != null)
                {
                    txtTenderID.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[0].Value.ToString();
                    txtTenderNo.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[1].Value.ToString();
                    DtpTender.Value = Convert.ToDateTime(Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[2].Value);
                int Vint_tenderAuc =  int.Parse(txtTenderID.Text);
                var result = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_tenderAuc);
                comboBox2.SelectedIndex = -1;
                if (result.ElectricalEffortID != null) { comboBox2.SelectedIndex = int.Parse(result.ElectricalEffortID.ToString()); }
                 
                txtTenderPurpose.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[4].Value.ToString();
                }
            textBox1.Focus();
            
        }
        private void dg()
        {
            var list = (from Rt in FsDb.Tbl_RuleTender
                        join tac in FsDb.Tbl_TendersAuctions on Rt.TendersAuctionsID equals tac.ID
                        select new
                        {
                            ID = Rt.ID,
                            RuleName = Rt.RuleName,
                            RuleValue = Rt.RuleValue,
                            TendersAuctionsID = Rt.TendersAuctionsID,
                            TenderNo = tac.TenderNo,
                            TenderDate = tac.TenderDate,

                        }).OrderByDescending(x => x.TenderNo).ToList();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["RuleName"].HeaderText = "المتغيرات";
            dataGridView1.Columns["RuleValue"].HeaderText = "الكمية";
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["TendersAuctionsID"].Visible = false;
            dataGridView1.Columns["TenderNo"].HeaderText = "رقم الممارسه";
            dataGridView1.Columns["TenderDate"].HeaderText = "تاريخ الممارسه";
            
            dataGridView1.Columns["RuleName"].Width = 200;
            dataGridView1.Columns["RuleValue"].Width = 100;

            dataGridView1.Columns["TenderNo"].Width = 100;
            dataGridView1.Columns["TenderDate"].Width = 100;

        }
        private void RulesAbstractsFrm_Load(object sender, EventArgs e)
        {

            dg();


            textBox1.Text = "";
            txtTenderNo.Select();
            this.ActiveControl = txtTenderNo;
            txtTenderNo.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البيان ");
                textBox1.Select();
                this.ActiveControl = textBox1;
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل الكمية ");
                textBox1.Select();
                this.ActiveControl = textBox1;
                textBox1.Focus();
            }


            else
            {
                int xrows = dataGridView1.RowCount;
                if ( txtRuleid.Text == "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 138 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        decimal Vd_value = decimal.Parse(textBox2.Text);

                        Tbl_RuleTender taxaF = new Tbl_RuleTender
                        {
                            RuleName = textBox1.Text,
                            RuleValue = Vd_value,
                            TendersAuctionsID =int.Parse(txtTenderID.Text)

                        };
                        FsDb.Tbl_RuleTender.Add(taxaF);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة متغير",
                            TableName = "Tbl_RuleTender",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة متغيرات الممارسات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        dg();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        //CodeTxt.Text = "";
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  متغيرات ممارسه .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 138 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(txtRuleid.Text);
                        var result = FsDb.Tbl_RuleTender.SingleOrDefault(x => x.ID == xcatid);
                        result.RuleName = textBox1.Text;
                        result.RuleValue = decimal.Parse( textBox2.Text);
                        result.TendersAuctionsID =int.Parse( txtTenderID.Text);
                        
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل متغير ممارسه",
                            TableName = "Tbl_RuleTender",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة متغيرات الممارسات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        dg();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        //CodeTxt.Text = "";
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل متغير  .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 138 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                int xrows = dataGridView1.RowCount;

                if (xrows != 0 && txtRuleid.Text != "")
                {
                    var result1 = MessageBox.Show("هل تريد حدف هدا النوع  ؟", "حدف متغير ", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {

                        xcatid = int.Parse(txtRuleid.Text);

                            var result = FsDb.Tbl_RuleTender.Find(xcatid);
                            FsDb.Tbl_RuleTender.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRow = taxaF.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف  متغير",
                                TableName = "Tbl_RuleTender",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة متغيرات الممارسات"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("  تم الحدف");
                            textBox1.Text = "";
                        dg();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                        
                    }

                }
                else
                {
                    MessageBox.Show("من فضلك حدد المتغير المراد حدفه");
                    textBox1.Select();
                    this.ActiveControl = textBox1;
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  متغير .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtRuleid.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_RuleTender.FirstOrDefault(x => x.ID == xcatid);
            textBox1.Text = result.RuleName.ToString();
            textBox2.Text = result.RuleValue.ToString();
            txtTenderID.Text = result.TendersAuctionsID.ToString();
            txtRuleid.Text = xcatid.ToString();
            //*****************
            
           
            int Vint_tenderAuc = int.Parse(txtTenderID.Text);
            var resultN = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_tenderAuc);
            txtTenderNo.Text = resultN.TenderNo.ToString();
            DtpTender.Value = Convert.ToDateTime(resultN.TenderDate.ToString());
            comboBox2.SelectedIndex = -1;
            if (resultN.ElectricalEffortID != null) { comboBox2.SelectedIndex = int.Parse(resultN.ElectricalEffortID.ToString()); }
            txtTenderPurpose.Text = resultN.Note.ToString();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRuleid.Text = "";
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_RuleTender.FirstOrDefault(x => x.ID == xcatid);
                textBox1.Text = result.RuleName.ToString();
                textBox2.Text = result.RuleValue.ToString();

                txtRuleid.Text = xcatid.ToString();
                //***************
                int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                var resultN = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_tenderAuc);
                txtTenderNo.Text = resultN.TenderNo.ToString();
                DtpTender.Value = Convert.ToDateTime(resultN.TenderDate.ToString());
                comboBox2.SelectedIndex = -1;
                if (resultN.ElectricalEffortID != null) { comboBox2.SelectedIndex = int.Parse(resultN.ElectricalEffortID.ToString()); }
                txtTenderPurpose.Text = resultN.Note.ToString();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}