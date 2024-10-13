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


namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class StampsFeesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xcatid = 0;
        //DateTime? nullDateTime = null;
        decimal Vdc_Value1 = 0;

        decimal Vdc_ValueRelated1 = 0;

        decimal Vdc_Value2 = 0;

        decimal Vdc_ValueRelated2 = 0;
        bool Value_Percent1 = true;

        bool PaperCount_AuditingNote1 = true;

        bool Value_Percent2 = true;

        bool PaperCount_AuditingNote2 = true;

        public StampsFeesFrm()
        {
            InitializeComponent();
        }
        private void CheckValues ()
        {
            //****************
            //bool Value_Percent1 = false;

            if (cmbValue_Percent1.SelectedIndex == 0)
            {
                Value_Percent1 = true;
            }
            else
            {
                Value_Percent1 = false;
            }
            //**********
            PaperCount_AuditingNote1 = false;

            if (cmbPaperCount_AuditingNote1.SelectedIndex == 0)
            {
                PaperCount_AuditingNote1 = true;
            }
            else
            {
                PaperCount_AuditingNote1 = false;
            }
            //**********
            //bool Value_Percent2 = false;

            if (cmbValue_Percent2.SelectedIndex == 0)
            {
                Value_Percent2 = true;
            }
            else
            {
                Value_Percent2 = false;
            }
            //*********
            PaperCount_AuditingNote2 = false;

            if (cmbPaperCount_AuditingNote2.SelectedIndex == 0)
            {
                PaperCount_AuditingNote2 = true;
            }
            else
            {
                PaperCount_AuditingNote2 = false;
            }
            //*************************

            Vdc_Value1 = decimal.Parse(txtValue1.Text);

            //*******************
            if (txtCheckValue1.Text != "")
            {
                Vdc_ValueRelated1 = decimal.Parse(txtCheckValue1.Text);
            }
            else
            {
                Vdc_ValueRelated1 = 0;
            }
            //*************
            if (txtValue2.Text != "")
            {
                Vdc_Value2 = decimal.Parse(txtValue2.Text);
            }
            else
            {
                Vdc_Value2 = 0;
            }
            //***************
            if (txtCheckValue2.Text != "")
            {
                Vdc_ValueRelated2 = decimal.Parse(txtCheckValue2.Text);
            }
            else
            {
                Vdc_ValueRelated2 = 0;
            }
            //***********************
        }
        private void StampsFeesFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_StampsFees.Where(x => x.Active_NonActive == true).ToList();

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Value1"].HeaderText = " قيمة الدمغه -- الرسم";
            dataGridView1.Columns["Name"].HeaderText = "الدمغه -- الرسم";
            dataGridView1.Columns["Value_Percent1"].HeaderText = " قيمة / الرسم";
            dataGridView1.Columns["ValueRelated1"].HeaderText = " لقيمة -- اوليه";
            dataGridView1.Columns["PaperCount_AuditingNote1"].HeaderText = "طبقا لـــ ";

            dataGridView1.Columns["Value2"].HeaderText = " قيمة الدمغه -- الرسم";
            dataGridView1.Columns["Value_Percent2"].HeaderText = " قيمة / الرسم";
            dataGridView1.Columns["ValueRelated2"].HeaderText = " لقيمة -- اوليه";
            dataGridView1.Columns["PaperCount_AuditingNote2"].HeaderText = "طبقا لـــ ";
            dataGridView1.Columns["FromDate"].HeaderText = "من تاريخ ";
            dataGridView1.Columns["ToDate"].HeaderText = "الى تاريخ ";
            dTPTo.Value = DateTime.Today.AddYears(10);
            dataGridView1.Columns["Name"].Width = 200;
            cmbValue_Percent1.SelectedIndex = 0;
            cmbPaperCount_AuditingNote1.SelectedIndex = 0;
            cmbValue_Percent2.SelectedIndex = 0;
            cmbPaperCount_AuditingNote2.SelectedIndex = 0;
            textBox1.Text = "";

            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBox1.Text = "";
                if (dataGridView1.RowCount >= 1)
                {
                    xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var result = FsDb.Tbl_StampsFees.SingleOrDefault(x => x.ID == xcatid);
                    Nametxt.Text = result.Name;
                    //******************value 1
                    txtValue1.Text = result.Value1.ToString();


                    //******************value 2
                    txtValue2.Text = result.Value2.ToString();

                    //*****************
                    dTPFrom.Value = Convert.ToDateTime(result.FromDate);
                    dTPTo.Value = Convert.ToDateTime(result.ToDate);

                    textBox1.Text = xcatid.ToString();


                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            if (dataGridView1.RowCount >= 1)
            {
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_StampsFees.SingleOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                //******************value 1
                txtValue1.Text = result.Value1.ToString();
                cmbValue_Percent1.SelectedIndex = int.Parse(result.Value_Percent1.ToString());

                txtCheckValue1.Text = result.ValueRelated1.ToString();
                cmbPaperCount_AuditingNote1.SelectedIndex = int.Parse(result.PaperCount_AuditingNote1.ToString());
                //******************value 2
                txtValue2.Text = result.Value2.ToString();
                cmbValue_Percent2.SelectedIndex = int.Parse(result.Value_Percent2.ToString());

                txtCheckValue2.Text = result.ValueRelated2.ToString();
                cmbPaperCount_AuditingNote2.SelectedIndex = int.Parse(result.PaperCount_AuditingNote2.ToString());
                //*****************
                dTPFrom.Value = Convert.ToDateTime(result.FromDate);
                dTPTo.Value = Convert.ToDateTime(result.ToDate);

                textBox1.Text = xcatid.ToString();

            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                txtValue1.Text = "";
                txtCheckValue1.Text = "";
                txtValue2.Text = "";
                txtCheckValue2.Text = "";
                dTPFrom.CustomFormat = " ";
                dTPTo.CustomFormat = " ";
                //dTPTo.Value = Convert.ToDateTime(DBNull.Value.ToString());
                dataGridView1.DataSource = FsDb.Tbl_StampsFees.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
            }
            else
            {
                dataGridView1.DataSource = FsDb.Tbl_StampsFees.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            if (dataGridView1.RowCount >= 1)
            {
                xcatid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_StampsFees.SingleOrDefault(x => x.ID == xcatid);
                Nametxt.Text = result.Name;
                //******************value 1
                txtValue1.Text = result.Value1.ToString();
                if (result.Value_Percent1 == true)
                {
                    cmbValue_Percent1.SelectedIndex = 0;
                }
                else
                {
                    cmbValue_Percent1.SelectedIndex = 1;
                }

                txtCheckValue1.Text = result.ValueRelated1.ToString();
                if (result.PaperCount_AuditingNote1 == true)
                {
                    cmbPaperCount_AuditingNote1.SelectedIndex = 0;
                }
                else
                {
                    cmbPaperCount_AuditingNote1.SelectedIndex = 1;
                }


                //******************value 2
                txtValue2.Text = result.Value2.ToString();

                if (result.Value_Percent2 == true)
                {
                    cmbValue_Percent2.SelectedIndex = 0;
                }
                else
                {
                    cmbValue_Percent2.SelectedIndex = 1;
                }



                txtCheckValue2.Text = result.ValueRelated2.ToString();
                if (result.PaperCount_AuditingNote2 == true)
                {
                    cmbPaperCount_AuditingNote2.SelectedIndex = 0;
                }
                else
                {
                    cmbPaperCount_AuditingNote2.SelectedIndex = 1;
                }

                //*****************
                dTPFrom.Value = Convert.ToDateTime(result.FromDate);
                if (result.ToDate != null)
                {
                    dTPTo.Value = Convert.ToDateTime(result.ToDate);
                }
                else
                {
                    dTPTo.CustomFormat = " ";
                    dTPTo.Value = Convert.ToDateTime(null);
                }

                textBox1.Text = xcatid.ToString();

            }
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValue1.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
            {
                MessageBox.Show("من فضلك ادخل الدمغه -- التسوية ");
            }
            else if (txtValue1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل قيمة / نسبة الدمغه -- التسوية ");
            }
            else if (dTPFrom.Value == null)
            {
                MessageBox.Show("من فضلك ادخل تاريخ بدء التعامل بالدمغه -- بالتسوية ");
            }
            else
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 58 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {
                    CheckValues();
                    if (txtCheckValue2.Text != "")
                    {
                         Vdc_ValueRelated2 = decimal.Parse(txtCheckValue2.Text);
                    }
                    else
                    {
                         Vdc_ValueRelated2 = 0;
                    }



                    var listStampOld = FsDb.Tbl_StampsFees.FirstOrDefault(x => x.Name == Nametxt.Text && x.Active_NonActive == true);
                    if (listStampOld != null)
                    {
                        var result1 = MessageBox.Show("هل تم تغيير اسعار الدمغه - الرسم   ؟", "اضافة دمغه -- رسم  " + " " + Nametxt.Text, MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            listStampOld.ToDate = Convert.ToDateTime(dTPFrom.Value.Date.AddDays(-1));
                            listStampOld.Active_NonActive = false;
                            Tbl_StampsFees CatF = new Tbl_StampsFees
                            {
                                Name = Nametxt.Text,
                                Value1 = Vdc_Value1,
                                Value_Percent1 = Value_Percent1,
                                ValueRelated1 = Vdc_ValueRelated1,
                                PaperCount_AuditingNote1 = PaperCount_AuditingNote1,


                                Value2 = Vdc_Value2,
                                Value_Percent2 = Value_Percent2,
                                ValueRelated2 = Vdc_ValueRelated2,
                                PaperCount_AuditingNote2 = PaperCount_AuditingNote2,

                                FromDate = Convert.ToDateTime(dTPFrom.Value.Date),
                                ToDate = Convert.ToDateTime(dTPTo.Value.Date),
                                Active_NonActive = true


                            };
                            FsDb.Tbl_StampsFees.Add(CatF);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            int Vint_LastRow = CatF.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة دمغه - رسم",
                                TableName = "Tbl_StampsFees",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة الدمغات -الرسوم "


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("تم الحفظ");
                            dataGridView1.DataSource = FsDb.Tbl_StampsFees.Where(x => x.Active_NonActive == true).ToList();
                            dataGridView1.Columns["ID"].Visible = false;
                            dataGridView1.Columns["Value1"].HeaderText = " قيمة الدمغه -- الرسم";
                            dataGridView1.Columns["Name"].HeaderText = "الدمغه -- الرسم";
                            dataGridView1.Columns["Value_Percent1"].HeaderText = " قيمة / الرسم";
                            dataGridView1.Columns["ValueRelated1"].HeaderText = " لقيمة -- اوليه";
                            dataGridView1.Columns["PaperCount_AuditingNote1"].HeaderText = "طبقا لـــ ";

                            dataGridView1.Columns["Value2"].HeaderText = " قيمة الدمغه -- الرسم";
                            dataGridView1.Columns["Value_Percent2"].HeaderText = " قيمة / الرسم";
                            dataGridView1.Columns["ValueRelated2"].HeaderText = " لقيمة -- اوليه";
                            dataGridView1.Columns["PaperCount_AuditingNote2"].HeaderText = "طبقا لـــ ";
                            dataGridView1.Columns["FromDate"].HeaderText = "من تاريخ ";
                            dataGridView1.Columns["ToDate"].HeaderText = "الى تاريخ ";

                            dataGridView1.Columns["Name"].Width = 200;
                            Nametxt.Text = "";

                            Nametxt.Select();
                            this.ActiveControl = Nametxt;
                            Nametxt.Focus();
                        }

                    }

                    else
                    {
                        Tbl_StampsFees CatF = new Tbl_StampsFees
                        {
                            Name = Nametxt.Text,
                            Value1 = Vdc_Value1,
                            Value_Percent1 = Value_Percent1,
                            ValueRelated1 = Vdc_ValueRelated1,
                            PaperCount_AuditingNote1 = PaperCount_AuditingNote1,


                            Value2 = Vdc_Value2,
                            Value_Percent2 = Value_Percent2,
                            ValueRelated2 = Vdc_ValueRelated2,
                            PaperCount_AuditingNote2 = PaperCount_AuditingNote2,

                            FromDate = Convert.ToDateTime(dTPFrom.Value.Date),
                            ToDate = Convert.ToDateTime(dTPTo.Value.Date),
                            Active_NonActive = true


                        };
                        FsDb.Tbl_StampsFees.Add(CatF);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        int Vint_LastRow = CatF.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة دمغه - رسم",
                            TableName = "Tbl_StampsFees",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الدمغات -الرسوم "


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        dataGridView1.DataSource = FsDb.Tbl_StampsFees.Where(x => x.Active_NonActive == true).ToList();
                        dataGridView1.Columns["ID"].Visible = false;
                        dataGridView1.Columns["Value1"].HeaderText = " قيمة الدمغه -- الرسم";
                        dataGridView1.Columns["Name"].HeaderText = "الدمغه -- الرسم";
                        dataGridView1.Columns["Value_Percent1"].HeaderText = " قيمة / الرسم";
                        dataGridView1.Columns["ValueRelated1"].HeaderText = " لقيمة -- اوليه";
                        dataGridView1.Columns["PaperCount_AuditingNote1"].HeaderText = "طبقا لـــ ";

                        dataGridView1.Columns["Value2"].HeaderText = " قيمة الدمغه -- الرسم";
                        dataGridView1.Columns["Value_Percent2"].HeaderText = " قيمة / الرسم";
                        dataGridView1.Columns["ValueRelated2"].HeaderText = " لقيمة -- اوليه";
                        dataGridView1.Columns["PaperCount_AuditingNote2"].HeaderText = "طبقا لـــ ";
                        dataGridView1.Columns["FromDate"].HeaderText = "من تاريخ ";
                        dataGridView1.Columns["ToDate"].HeaderText = "الى تاريخ ";

                        dataGridView1.Columns["Name"].Width = 200;
                        Nametxt.Text = "";

                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();
                    }


                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  طريقة الشراء .. برجاء مراجعة مدير المنظومه");
                }

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //try
            //{
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 58 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                int xrows = dataGridView1.RowCount;
                if (xrows != 0 && textBox1.Text != "")
                {
                    var result1 = MessageBox.Show("هل تريد حدف هده الدمغه - الرسم  ؟", "حدف دمغه - رسم  " + " " + Nametxt.Text, MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        var result = FsDb.Tbl_StampsFees.Find(xcatid);
                        FsDb.Tbl_StampsFees.Remove(result);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 

                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "حذف دمغه -- رسم ",
                            TableName = "Tbl_StampsFees",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الدمغات -- الرسوم"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("  تم الحدف");
                        dataGridView1.DataSource = FsDb.Tbl_StampsFees.Where(x => x.Active_NonActive == true).ToList();
                        dataGridView1.Columns["ID"].Visible = false;
                        //dataGridView1.Columns["Name"].HeaderText = "طريقة الشراء";

                        dataGridView1.Columns["Name"].Width = 200;
                        textBox1.Text = "";

                        Nametxt.Text = "";
                        Nametxt.Select();
                        this.ActiveControl = Nametxt;
                        Nametxt.Focus();

                    }
                }
                else
                {
                    MessageBox.Show("من فضلك حدد طريقة الشراء المراد حدفه");
                    textBox1.Select();
                    this.ActiveControl = textBox1;
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية لحذف  طريقة شراء.. برجاء مراجعة مدير المنظومه");
            }
            //}
            //catch


            //{
            //    MessageBox.Show("هذه الدمغه - الرسم   لايمكن حذفها لاستخدامها ببعض الاوامر ", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void txtValue1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbValue_Percent1.Focus();
            }
        }

        private void cmbValue_Percent1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCheckValue1.Focus();
            }

        }

        private void txtCheckValue1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPaperCount_AuditingNote1.Focus();
            }

        }

        private void cmbPaperCount_AuditingNote1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValue2.Focus();
            }
        }

        private void txtValue2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbValue_Percent2.Focus();
            }

        }

        private void cmbValue_Percent2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCheckValue2.Focus();
            }

        }

        private void txtCheckValue2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPaperCount_AuditingNote2.Focus();
            }
        }

        private void cmbPaperCount_AuditingNote2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dTPFrom.Focus();
            }
        }

        private void dTPFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dTPTo.Focus();
            }
        }

        private void dTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
                //{
                //    dTPTo.CustomFormat =" ";
                //}
                //else if (e.KeyCode == Keys.Enter)
                //{
                simpleButton1.Focus();
            }
        }

        private void dTPTo_ValueChanged(object sender, EventArgs e)
        {
            //dTPTo.CustomFormat = "dd/MM/yyyy";
            //simpleButton3_Click(sender, e);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 58 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                CheckValues();
                xcatid = int.Parse(textBox1.Text);
                var result = FsDb.Tbl_StampsFees.SingleOrDefault(x => x.ID == xcatid);
                result.Name = Nametxt.Text;

                result.Value1 = Vdc_Value1;
                result.Value_Percent1 = Value_Percent1;
                result.ValueRelated1 = Vdc_ValueRelated1;
                result.PaperCount_AuditingNote1 = PaperCount_AuditingNote1;


                result.Value2 = Vdc_Value2;
                result.Value_Percent2 = Value_Percent2;
                result.ValueRelated2 = Vdc_ValueRelated2;
                result.PaperCount_AuditingNote2 = PaperCount_AuditingNote2;

                result.FromDate = Convert.ToDateTime(dTPFrom.Value.Date);
                result.ToDate = Convert.ToDateTime(dTPTo.Value.ToString());
                FsDb.SaveChanges();
                //---------------خفظ ااحداث 

                SecurityEvent sev = new SecurityEvent
                {
                    ActionName = "تعديل دمغه - رسم",
                    TableName = "Tbl_StampsFees",
                    TableRecordId = result.ID.ToString(),
                    Description = "",
                    ManagementName = Program.GlbV_Management,
                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                    EmployeeName = Program.GlbV_EmpName,
                    User_ID = Program.GlbV_UserId,
                    UserName = Program.GlbV_UserName,
                    FormName = "شاشة الدمغات -- الرسوم"


                };
                FsEvDb.SecurityEvents.Add(sev);
                FsEvDb.SaveChanges();
                //***************************
                MessageBox.Show("تم التعديل");
                dataGridView1.DataSource = FsDb.Tbl_StampsFees.Where(x => x.Active_NonActive == true).ToList();
                dataGridView1.Columns["ID"].Visible = false;

                dataGridView1.Columns["Name"].Width = 200;
                textBox1.Text = "";

                Nametxt.Text = "";
                Nametxt.Select();
                this.ActiveControl = Nametxt;
                Nametxt.Focus();
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية تعديل  طريقة شراء.. برجاء مراجعة مدير المنظومه");
            }
        }

        private void dTPTo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }

        }
    }
}