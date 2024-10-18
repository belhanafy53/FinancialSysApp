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

namespace FinancialSysApp.Forms.Abstracts
{
    public partial class SpecificationPriceFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public SpecificationPriceFrm()
        {
            InitializeComponent();
        }
        private void cmbSolidKind()
        {
            comboBox1.DataSource = FsDb.Tbl_SoilKind.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedText = "";
             comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر نوع التربه";
        }
        private void SpecificationPriceFrm_Load(object sender, EventArgs e)
        {
            
            dg();
            cmbSolidKind();

            textBox1.Text = "";
            textBox2.Text = "";
            txtTenderNo.Select();
            this.ActiveControl = txtTenderNo;
            txtTenderNo.Focus();
        }
        private void dg()
        {
            var list = (from Rt in FsDb.Tbl_SpecificationPrice
                        join tac in FsDb.Tbl_TendersAuctions on Rt.TendersAuctionsID equals tac.ID
                        join sk in FsDb.Tbl_SoilKind on Rt.SolidKindID equals sk.ID
                        
                        select new
                        {
                            ID = Rt.ID,
                            SolidKindName = sk.Name,
                            CableNumber = Rt.CableNumber,
                            Peice = Rt.Peice,
                            TendersAuctionsID = Rt.TendersAuctionsID,
                            TenderNo = tac.TenderNo,
                            TenderDate = tac.TenderDate
                            

                        }).OrderByDescending(x => x.TenderNo).ToList();
            dataGridView1.DataSource = list;
            
                dataGridView1.Columns["SolidKindName"].HeaderText = "نوع التربه";
            dataGridView1.Columns["CableNumber"].HeaderText = "عدد الكابلات";
            dataGridView1.Columns["Peice"].HeaderText = "السعر";
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["TendersAuctionsID"].Visible = false;
            dataGridView1.Columns["TenderNo"].HeaderText = "رقم الممارسه";
            dataGridView1.Columns["TenderDate"].HeaderText = "تاريخ الممارسه";

            dataGridView1.Columns["CableNumber"].Width = 200;
            dataGridView1.Columns["Peice"].Width = 100;

            dataGridView1.Columns["TenderNo"].Width = 100;
            dataGridView1.Columns["TenderDate"].Width = 100;
           

        }
        private void dgId(int Vid)
        {
            var list = (from Rt in FsDb.Tbl_SpecificationPrice
                        join tac in FsDb.Tbl_TendersAuctions on Rt.TendersAuctionsID equals tac.ID
                        join sk in FsDb.Tbl_SoilKind on Rt.SolidKindID equals sk.ID
                        where (Rt.TendersAuctionsID == Vid)
                        select new
                        {
                            ID = Rt.ID,
                            SolidKindName = sk.Name,
                            CableNumber = Rt.CableNumber,
                            Peice = Rt.Peice,
                            TendersAuctionsID = Rt.TendersAuctionsID,
                            TenderNo = tac.TenderNo,
                            TenderDate = tac.TenderDate


                        }).OrderByDescending(x => x.TenderNo).ToList();
            dataGridView1.DataSource = list;

            dataGridView1.Columns["SolidKindName"].HeaderText = "نوع التربه";
            dataGridView1.Columns["CableNumber"].HeaderText = "عدد الكابلات";
            dataGridView1.Columns["Peice"].HeaderText = "السعر";
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["TendersAuctionsID"].Visible = false;
            dataGridView1.Columns["TenderNo"].HeaderText = "رقم الممارسه";
            dataGridView1.Columns["TenderDate"].HeaderText = "تاريخ الممارسه";

            dataGridView1.Columns["CableNumber"].Width = 200;
            dataGridView1.Columns["Peice"].Width = 100;

            dataGridView1.Columns["TenderNo"].Width = 100;
            dataGridView1.Columns["TenderDate"].Width = 100;
            return;

        }
        private void txtTenderNo_KeyDown(object sender, KeyEventArgs e)
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
                int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                dgId(Vint_tenderAuc);
                var result = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_tenderAuc);
                comboBox2.SelectedIndex = -1;
                if (result.ElectricalEffortID != null) { comboBox2.SelectedIndex = int.Parse(result.ElectricalEffortID.ToString()); }

                txtTenderPurpose.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[4].Value.ToString();
            }
            comboBox1.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTenderID.Text == "")
            {
                MessageBox.Show("من فضلك اختر الممارسه ");
                comboBox1.Select();
                this.ActiveControl = comboBox1;
                comboBox1.Focus();
            }

            else if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("من فضلك اختر نوع التربه ");
                comboBox1.Select();
                this.ActiveControl = comboBox1;
                comboBox1.Focus();
            }
           else if (textBox1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل عدد الكابلات ");
                comboBox1.Select();
                this.ActiveControl = comboBox1;
                comboBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("من فضلك ادخل السعر ");
                comboBox1.Select();
                this.ActiveControl = comboBox1;
                comboBox1.Focus();
            }


            else
            {
                int xrows = dataGridView1.RowCount;
                if (txtRuleid.Text == "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 139 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        decimal Vd_value = decimal.Parse(textBox2.Text);

                        Tbl_SpecificationPrice taxaF = new Tbl_SpecificationPrice
                        {
                            CableNumber = int.Parse( textBox1.Text),
                            Peice = Vd_value,
                            TendersAuctionsID = int.Parse(txtTenderID.Text),
                            SolidKindID = int.Parse(comboBox1.SelectedValue.ToString())

                        };
                        FsDb.Tbl_SpecificationPrice.Add(taxaF);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة سعر مواصفه",
                            TableName = "Tbl_SpecificationPrice",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اسعار المواصفات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                        dgId(Vint_tenderAuc);
                                cmbSolidKind();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        //CodeTxt.Text = "";
                        comboBox1.Select();
                        this.ActiveControl = comboBox1;
                        comboBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  سهر مواصفة ممارسه .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 139 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(txtRuleid.Text);
                        var result = FsDb.Tbl_SpecificationPrice.SingleOrDefault(x => x.ID == xcatid);
                        result.SolidKindID = int.Parse(comboBox1.SelectedValue.ToString());
                        result.CableNumber = int.Parse(textBox1.Text);
                        result.Peice = decimal.Parse(textBox2.Text);
                        result.TendersAuctionsID = int.Parse(txtTenderID.Text);

                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل سعر مواصفة ممارسه",
                            TableName = "Tbl_SpecificationPrice",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اسعار المواصفات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                        dgId(Vint_tenderAuc);
                        cmbSolidKind();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        //CodeTxt.Text = "";
                        comboBox1.Select();
                        this.ActiveControl = comboBox1;
                        comboBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل سعر مواصفه  .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 139 && w.ProcdureId == 3);
            if (validationSaveUser != null)
            {
                int xrows = dataGridView1.RowCount;

                if (xrows != 0 && txtRuleid.Text != "")
                {
                    var result1 = MessageBox.Show("هل تريد حدف هدا السعر  ؟", "حدف سعر مواصفه  ", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {

                        xcatid = int.Parse(txtRuleid.Text);

                        var result = FsDb.Tbl_SpecificationPrice.Find(xcatid);
                        FsDb.Tbl_SpecificationPrice.Remove(result);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف  سعر مولصقه",
                            TableName = "Tbl_SpecificationPrice",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اسعار المواصفات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("  تم الحدف");
                        textBox1.Text = "";
                        int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                        dgId(Vint_tenderAuc);
                        cmbSolidKind();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.Select();
                        this.ActiveControl = comboBox1;
                        comboBox1.Focus();

                    }

                }
                else
                {
                    MessageBox.Show("من فضلك حدد سعر المواصفه المراد حدفه");
                    comboBox1.Select();
                    this.ActiveControl = comboBox1;
                    comboBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية حذف  سعر مواصفه .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtRuleid.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_SpecificationPrice.FirstOrDefault(x => x.ID == xcatid);
            textBox1.Text = result.CableNumber.ToString();
            textBox2.Text = result.Peice.ToString();
            txtTenderID.Text = result.TendersAuctionsID.ToString();
            comboBox1.SelectedValue = int.Parse(result.SolidKindID.ToString());
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
                var result = FsDb.Tbl_SpecificationPrice.FirstOrDefault(x => x.ID == xcatid);
                textBox1.Text = result.CableNumber.ToString();
                textBox2.Text = result.Peice.ToString();
                comboBox1.SelectedValue = int.Parse(result.SolidKindID.ToString());
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

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }
    }
}