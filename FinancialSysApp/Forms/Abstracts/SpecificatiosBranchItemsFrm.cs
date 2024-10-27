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
using DevExpress.XtraEditors.Controls;

namespace FinancialSysApp.Forms.Abstracts
{
    public partial class SpecificatiosBranchItemsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid;
        public SpecificatiosBranchItemsFrm()
        {
            InitializeComponent();
        }

       
        private void SpecificatiosBranchItemsFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'solidKindDS.Tbl_SpecificationBrnchItemsCode' table. You can move, or remove it, as needed.
            this.tbl_SpecificationBrnchItemsCodeTableAdapter.Fill(this.solidKindDS.Tbl_SpecificationBrnchItemsCode);
            // TODO: This line of code loads data into the 'solidKindDS.Tbl_SoilKind' table. You can move, or remove it, as needed.
            this.tbl_SoilKindTableAdapter.Fill(this.solidKindDS.Tbl_SoilKind);
            
            int Vint_idTender = 0;
            dgId(Vint_idTender);
            ClearData();

            ckbSpecificationItem();
            
            txtTenderNo.Select();
            this.ActiveControl = txtTenderNo;
            txtTenderNo.Focus();
        }
        private void ClearData()
        {
            checkedComboBoxEdit2.DeselectAll();
            checkedComboBoxEdit2.Text = "";
            checkedComboBoxEdit2.Text = "اختر البنود الفرعيه";
            
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر المتغير ";
            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر نوع التربه ";
            
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void ClearBranchData()
        {
             
             
            comboBox4.Text = "";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "اختر نوع التربه ";

            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void ckbSolidKind()
        {
            //checkedComboBoxEdit1.DataBindings = FsDb.Tbl_SoilKind.ToList();
            //checkedComboBoxEdit1.DisplayMember = "Name";
            //checkedComboBoxEdit1.ValueMember = "ID";
            //comboBox1.SelectedIndex = -1;
            //comboBox1.Text = "اختر نوع التربه";

        }

        private void ckbSpecificationItem()
        {
            comboBox1.DataSource = FsDb.Tbl_SpecificationItems.ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "اختر البند الرئيسي";

        }
       
        private void cmbRuleTender(int vid)
        {
            if (vid > 0)
            {
                comboBox3.DataSource = FsDb.Tbl_RuleTender.Where(x => x.TendersAuctionsID == vid).ToList();
            }
            else
            {
                comboBox3.DataSource = FsDb.Tbl_RuleTender.ToList();
            }
            comboBox3.DisplayMember = "RuleName";
            comboBox3.ValueMember = "ID";
            comboBox3.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "اختر المتغير ";

        }
        private void dgId(int Vid)
        {
            if (Vid > 0)
            {
                var list = (from Sbrit in FsDb.Tbl_SpecificationBranchItems
                            join tac in FsDb.Tbl_TendersAuctions on Sbrit.TendersAuctionsID equals tac.ID
                            join si in FsDb.Tbl_SpecificationItems on Sbrit.SpecificationItemsID equals si.ID
                            join sk in FsDb.Tbl_SoilKind on Sbrit.SolidKindID equals sk.ID
                            where (Sbrit.TendersAuctionsID == Vid)
                            select new
                            {
                                ID = Sbrit.ID,
                                itemMName = si.Name,
                                itembrName = Sbrit.Name,
                                solidKindName = sk.Name,
                                Price = Sbrit.Price,
                                TendersAuctionsID = tac.ID,
                                TenderNo = tac.TenderNo,
                                TenderDate = tac.TenderDate


                            }).OrderByDescending(x => x.TenderNo).ToList();
                dataGridView1.DataSource = list;
            }
            else
            {
                var list = (from Sbrit in FsDb.Tbl_SpecificationBranchItems
                            join tac in FsDb.Tbl_TendersAuctions on Sbrit.TendersAuctionsID equals tac.ID
                            join si in FsDb.Tbl_SpecificationItems on Sbrit.SpecificationItemsID equals si.ID
                           join sk in FsDb.Tbl_SoilKind on Sbrit.SolidKindID equals sk.ID

                            select new
                            {
                                ID = Sbrit.ID,
                                itemMName = si.Name,
                                itembrName = Sbrit.Name,
                                solidKindName = sk.Name,
                                Price=Sbrit.Price,
                               TendersAuctionsID = tac.ID,
                                TenderNo = tac.TenderNo,
                                TenderDate = tac.TenderDate


                            }).OrderByDescending(x => x.TenderNo).ToList();
                dataGridView1.DataSource = list;

            }
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Columns["itembrName"].HeaderText = "مسمى البند";
                dataGridView1.Columns["itemMName"].HeaderText = "البند الرئيسي";

                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["TendersAuctionsID"].Visible = false;

                dataGridView1.Columns["solidKindName"].HeaderText = "نوع التربه";
                dataGridView1.Columns["Price"].HeaderText = "السعر";

                dataGridView1.Columns["TenderNo"].HeaderText = "رقم الممارسه";
                dataGridView1.Columns["TenderDate"].HeaderText = "تاريخ الممارسه";

                dataGridView1.Columns["itembrName"].Width = 100;
                dataGridView1.Columns["itemMName"].Width = 100;

                dataGridView1.Columns["solidKindName"].Width = 100;
                dataGridView1.Columns["Price"].Width = 100;

                dataGridView1.Columns["TenderNo"].Width = 100;
                dataGridView1.Columns["TenderDate"].Width = 100;
            }
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
                cmbRuleTender(Vint_tenderAuc);
                var result = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_tenderAuc);
                comboBox2.SelectedIndex = -1;
                if (result.ElectricalEffortID != null) { comboBox2.SelectedIndex = int.Parse(result.ElectricalEffortID.ToString()); }

                txtTenderPurpose.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[4].Value.ToString();
            }
            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //******************استدعاء الاصناف الفرعيه 
            var selecteditems = checkedComboBoxEdit2.Properties.GetItems().GetCheckedValues();
           

            if (txtTenderID.Text == "")
            {
                MessageBox.Show("من فضلك اختر الممارسه ");
                comboBox1.Select();
                this.ActiveControl = comboBox1;
                comboBox1.Focus();
            }

            else if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("من فضلك اختر البند الرئيسي ");
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
            else if (selecteditems == null)
            {
                MessageBox.Show("من فضلك ادخل البنود الفرعي ");
                checkedComboBoxEdit2.Select();
                this.ActiveControl = checkedComboBoxEdit2;
                checkedComboBoxEdit2.Focus();
            }
            else if (comboBox4.SelectedValue == null)
            {
                MessageBox.Show("من فضلك ادخل نوع التربه ");
                comboBox4.Select();
                this.ActiveControl = comboBox4;
                comboBox4.Focus();
            }


            else
            {
                int xrows = dataGridView1.RowCount;
                if (txtRuleid.Text == "")


                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 139 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        

                        Tbl_SpecificationBranchItems taxaF = new Tbl_SpecificationBranchItems
                        {
                            Name = textBox2.Text,
                            
                            TendersAuctionsID = int.Parse(txtTenderID.Text),
                            SpecificationItemsID = int.Parse(comboBox1.SelectedValue.ToString()),
                            SolidKindID = int.Parse(comboBox4.SelectedValue.ToString()),
                            CableNumber = int.Parse(textBox1.Text),
                            Width = int.Parse(textBox3.Text),
                            Price = decimal.Parse(textBox4.Text)

                        };
                        FsDb.Tbl_SpecificationBranchItems.Add(taxaF);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = taxaF.ID;
                        
                        foreach (var value in selecteditems)
                        {
                            int Vint_itemBranchID = int.Parse(value.ToString());
                            Tbl_SpecificationBranchItemsSolidKind spBrsk = new Tbl_SpecificationBranchItemsSolidKind
                            {
                                SpecificationBranchItems = Vint_LastRow,
                                SpecificationBrnchitemsCode = Vint_itemBranchID
                            };
                            FsDb.Tbl_SpecificationBranchItemsSolidKind.Add(spBrsk);
                            FsDb.SaveChanges();
                        }
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند فرعي",
                            TableName = "Tbl_SpecificationBranchItems",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنود الفرعي لمواصفات الممارسات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                        dgId(Vint_tenderAuc);
                        ckbSolidKind();
                        ckbSpecificationItem();
                        ClearBranchData();
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بند  لمواصفة ممارسه .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 139 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {
                        xcatid = int.Parse(txtRuleid.Text);
                        var result = FsDb.Tbl_SpecificationBranchItems.SingleOrDefault(x => x.ID == xcatid);
                        result.SpecificationItemsID = int.Parse(comboBox1.SelectedValue.ToString());
                        result.Name = textBox2.Text;
                        result.CableNumber = int.Parse(textBox1.Text);
                        result.TendersAuctionsID = int.Parse(txtTenderID.Text);
                        result.Width = int.Parse(textBox3.Text);
                        result.Price = decimal.Parse(textBox4.Text);
                        //************البنود الفرعيه
                        foreach (var value in selecteditems)
                        {
                            int Vint_itembranchID = int.Parse(value.ToString());

                            var resultsk = FsDb.Tbl_SpecificationBranchItemsSolidKind.Where(x => x.SpecificationBrnchitemsCode == Vint_itembranchID && x.SpecificationBranchItems == xcatid).ToList();
                            if (resultsk.Count == 0)
                            {
                                Tbl_SpecificationBranchItemsSolidKind spBrsk = new Tbl_SpecificationBranchItemsSolidKind
                                {
                                    SpecificationBranchItems = xcatid,
                                    SpecificationBrnchitemsCode = Vint_itembranchID
                                };
                           
                            FsDb.Tbl_SpecificationBranchItemsSolidKind.Add(spBrsk);
                            FsDb.SaveChanges();
                            }
                        }
                        //**************
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل سعر مواصفة ممارسه",
                            TableName = "Tbl_SpecificationBranchItems",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنود الفرعي لمواصفات الممارسات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                        dgId(Vint_tenderAuc);
                        ClearData();
                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل بند فرعي  .. برجاء مراجعة مدير المنظومه");
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
                    var result1 = MessageBox.Show("هل تريد حدف هدا السعر  ؟", "حدف بند   ", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {

                        xcatid = int.Parse(txtRuleid.Text);
                        var resultD = FsDb.Tbl_SpecificationBranchItemsSolidKind.Where(x=>x.SpecificationBranchItems == xcatid).ToList();
                        FsDb.Tbl_SpecificationBranchItemsSolidKind.RemoveRange(resultD);
                        var result = FsDb.Tbl_SpecificationBranchItems.Find(xcatid);
                        FsDb.Tbl_SpecificationBranchItems.Remove(result);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        //int Vint_LastRow = taxaF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف  بند فرعي مواصقه",
                            TableName = "Tbl_SpecificationBranchItems",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة البنود الفرعي لمواصفات الممارسات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("  تم الحدف");
                        textBox1.Text = "";
                        int Vint_tenderAuc = int.Parse(txtTenderID.Text);
                        dgId(Vint_tenderAuc);
                        ClearData();
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
                MessageBox.Show("ليس لديك صلاحية حذف  بند فرعي .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ClearData();
            txtRuleid.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_SpecificationBranchItems.FirstOrDefault(x => x.ID == xcatid);
            textBox2.Text = result.Name.ToString();
            textBox1.Text = result.CableNumber.ToString();
            CalcDist();
            txtTenderID.Text = result.TendersAuctionsID.ToString();
            cmbRuleTender(int.Parse(txtTenderID.Text));
            comboBox1.SelectedValue = int.Parse(result.SpecificationItemsID.ToString());
            comboBox4.SelectedValue = int.Parse(result.SolidKindID.ToString());
            textBox4.Text = result.Price.ToString();
            txtRuleid.Text = xcatid.ToString();
            //**********البنود الفرعية
            var selectedWitems = (from SbritK in FsDb.Tbl_SpecificationBranchItemsSolidKind
                                  join tac in FsDb.Tbl_SpecificationBrnchItemsCode on SbritK.SpecificationBrnchitemsCode equals tac.ID
                                    select new
                                  {
                                      ID = SbritK.ID,
                                      Name = tac.Name,
                                  }).OrderByDescending(x => x.ID).ToList();


            //for (int i =0;i<= )
            checkedComboBoxEdit2.Properties.DataSource = FsDb.Tbl_SpecificationBrnchItemsCode.ToList();
            checkedComboBoxEdit2.Properties.DisplayMember = "Name";
            checkedComboBoxEdit2.Properties.ValueMember = "ID";
            //// Optionally, you can check items programmatically

            //checkedComboBoxEdit1.Properties.Items[0].CheckState = CheckState.Checked; // Check "Item 1"
            //string items = string.Empty;
            int items;
            foreach (CheckedListBoxItem item in checkedComboBoxEdit2.Properties.GetItems())
            {
                if (item.CheckState != CheckState.Checked)
                {
                    items = int.Parse(item.Value.ToString());
                    var resultitCode= FsDb.Tbl_SpecificationBranchItemsSolidKind.Where(x => x.SpecificationBrnchitemsCode == items && x.SpecificationBranchItems == xcatid).ToList();
                    if(resultitCode.Count > 0)
                    {
                        item.CheckState = CheckState.Checked;

                    }

                }

            }

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
            ClearData();
            txtRuleid.Text = "";
            xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = FsDb.Tbl_SpecificationBranchItems.FirstOrDefault(x => x.ID == xcatid);
            textBox2.Text = result.Name.ToString();
            textBox1.Text = result.CableNumber.ToString();
            CalcDist();
            txtTenderID.Text = result.TendersAuctionsID.ToString();
            cmbRuleTender(int.Parse(txtTenderID.Text));
            comboBox1.SelectedValue = int.Parse(result.SpecificationItemsID.ToString());
            comboBox4.SelectedValue = int.Parse(result.SolidKindID.ToString());
            textBox4.Text = result.Price.ToString();
            txtRuleid.Text = xcatid.ToString();
            //**********البنود الفرعية
            var selectedWitems = (from SbritK in FsDb.Tbl_SpecificationBranchItemsSolidKind
                                  join tac in FsDb.Tbl_SpecificationBrnchItemsCode on SbritK.SpecificationBrnchitemsCode equals tac.ID
                                  select new
                                  {
                                      ID = SbritK.ID,
                                      Name = tac.Name,
                                  }).OrderByDescending(x => x.ID).ToList();


            //for (int i =0;i<= )
            checkedComboBoxEdit2.Properties.DataSource = FsDb.Tbl_SpecificationBrnchItemsCode.ToList();
            checkedComboBoxEdit2.Properties.DisplayMember = "Name";
            checkedComboBoxEdit2.Properties.ValueMember = "ID";
            //// Optionally, you can check items programmatically

            //checkedComboBoxEdit1.Properties.Items[0].CheckState = CheckState.Checked; // Check "Item 1"
            //string items = string.Empty;
            int items;
            foreach (CheckedListBoxItem item in checkedComboBoxEdit2.Properties.GetItems())
            {
                if (item.CheckState != CheckState.Checked)
                {
                    items = int.Parse(item.Value.ToString());
                    var resultitCode = FsDb.Tbl_SpecificationBranchItemsSolidKind.Where(x => x.SpecificationBrnchitemsCode == items && x.SpecificationBranchItems == xcatid).ToList();
                    if (resultitCode.Count > 0)
                    {
                        item.CheckState = CheckState.Checked;

                    }

                }

            }

            //*****************


            int Vint_tenderAuc = int.Parse(txtTenderID.Text);
            var resultN = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_tenderAuc);
            txtTenderNo.Text = resultN.TenderNo.ToString();
            DtpTender.Value = Convert.ToDateTime(resultN.TenderDate.ToString());
            comboBox2.SelectedIndex = -1;
            if (resultN.ElectricalEffortID != null) { comboBox2.SelectedIndex = int.Parse(resultN.ElectricalEffortID.ToString()); }
            txtTenderPurpose.Text = resultN.Note.ToString();
        
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkedComboBoxEdit2.Select();
                this.ActiveControl = checkedComboBoxEdit2;
                checkedComboBoxEdit2.Focus();
               
            }

        }
        private void CalcDist()
        {
            decimal Vdec_DistancBetweenCable = 40;
            decimal Vdec_FixedValue1 = 20;
            decimal Vdec_FixedValue2 = 1;
            if (textBox1.Text != "")
            { textBox3.Text = ((Vdec_DistancBetweenCable + Vdec_FixedValue1) * (decimal.Parse(textBox1.Text) - Vdec_FixedValue2)).ToString(); }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            CalcDist();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //decimal   Vdec_DistancBetweenCable = 40;
                //decimal Vdec_FixedValue1 = 20;
                //decimal Vdec_FixedValue2 = 1;

                //if (textBox1.Text != "")
                //{ textBox3.Text = ((Vdec_DistancBetweenCable + Vdec_FixedValue1) * (decimal.Parse(textBox1.Text)) - Vdec_FixedValue2).ToString(); }

                comboBox4.Focus();


            }
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox2.Text += " " + textBox1.Text;
                textBox2.Focus();
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.Text += " " + textBox3.Text;
                textBox2.Focus();
                //checkBox2.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                int vint_rule = int.Parse(comboBox3.SelectedValue.ToString());
                string Vst_rulename = FsDb.Tbl_RuleTender.FirstOrDefault(x => x.ID == vint_rule).RuleValue.ToString();
                textBox2.Text += " " + Vst_rulename;
                //checkBox3.Checked = false;
                textBox2.Focus();
            }
        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                
                textBox2.Text += " " + comboBox3.Text;
                //checkBox3.Checked = false;
                textBox2.Focus();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTenderNo_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار الممارسه المطلوبه", TB, 0, 0, VisibleTime);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
    }
}