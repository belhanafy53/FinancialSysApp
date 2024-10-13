using FinancialSysApp.DataBase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class RefundLetterFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_LetterId = 0; 
        public RefundLetterFrm()
        {
            InitializeComponent();
        }

        private void RefundLetterFrm_Load(object sender, EventArgs e)
        {
            if (cmbRecieveMethode.SelectedIndex < 0)
            {
                cmbRecieveMethode.SelectedIndex = -1;
                cmbRecieveMethode.Text = "";
                cmbRecieveMethode.SelectedText = "اختر طريقة التسليم";
            }
            Vint_LetterId = int.Parse(LetterId.Text);
            //                //****************Refrences***************
            LetterWAuditSelect(Vint_LetterId);
            //                //***************************************
            cmbRecieveMethode.Select();
            this.ActiveControl = cmbRecieveMethode;
            cmbRecieveMethode.Focus();



        }

        private void txtEmpRecieve_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإختيار بالتسليم", TB, 0, 0, VisibleTime);
        }

        private void txtEmpRecieve_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindEmployeesFrm t = new Forms.BasicCodeForms.FindEmployeesFrm();

                t.ShowDialog();

                if (Forms.BasicCodeForms.FindEmployeesFrm.SelectedRow != null)
                {
                    txtEmpRecieveID.Text = Forms.BasicCodeForms.FindEmployeesFrm.SelectedRow.Cells[0].Value.ToString();
                    txtEmpRecieve.Text = Forms.BasicCodeForms.FindEmployeesFrm.SelectedRow.Cells[1].Value.ToString();


                }
                dTPDateRefund.Focus();

            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (txtEmpRecieve.Text == "")
                {
                    txtEmpRecieveID.Text = "";
                }
            }
            else if (e.KeyCode == Keys.Enter) { if (e.KeyCode == Keys.Enter) { dTPDateRefund.Focus(); } }
        }

        private void cmbRecieveMethode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { dTPDateRecieve.Focus(); }
        }

        private void dTPDateRecieve_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtEmpRecieve.Focus(); }
        }

        private void dTPDateRefund_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.KeyCode == Keys.Enter) { simpleButton1.Focus(); }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int? Vint_txtEmpRecieveID = null;
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 69 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                int Vint_LetterID = int.Parse(LetterId.Text);
                int Vint_recieveMthd = int.Parse(cmbRecieveMethode.SelectedIndex.ToString());
                DateTime Vdt_RecieveDate = Convert.ToDateTime(dTPDateRecieve.Value.ToString());
               
                if (txtEmpRecieveID.Text != "")
                {
                     Vint_txtEmpRecieveID = int.Parse(txtEmpRecieveID.Text);
                }
                
                DateTime Vdt_txtdTPDateRefund = Convert.ToDateTime(dTPDateRefund.Value.ToString());



                //var list = FsDb.Tbl_NotificationLetter.Where(x=>x.LetterWarrantyID == Vint_LetterID && x.NotificationDate == Vdt_NtfDate &&x.RefundLetterReasonsID == Vint_refundLtrReason);
                var list = FsDb.Tbl_RefundLetter.FirstOrDefault(x => x.LetterWarrantyID == Vint_LetterID);
                if (list == null)
                {
                    if (cmbRecieveMethode.SelectedIndex == -1)
                    {
                        MessageBox.Show("اختر طريقة التسليم");
                        cmbRecieveMethode.Focus();
                    }
                    else if (txtEmpRecieveID.Text == "")
                    {
                        MessageBox.Show("اختر القائم بتسليم الخطاب");
                        txtEmpRecieve.Focus();
                    }
                    else
                    {
                        if (txtEmpRecieveID.Text != "")
                        {
                            Vint_txtEmpRecieveID = int.Parse(txtEmpRecieveID.Text);
                        }

                        Tbl_RefundLetter RFND = new Tbl_RefundLetter()
                        {
                            LetterWarrantyID = Vint_LetterID,
                            EmployeeID = Vint_txtEmpRecieveID,
                            RecievedMethodeLetterID = Vint_recieveMthd,
                            RecievedDate = Vdt_RecieveDate,
                            RefundLetterDate = Vdt_txtdTPDateRefund

                        };
                        FsDb.Tbl_RefundLetter.Add(RFND);
                        FsDb.SaveChanges();

                        int Vint_LastRow = RFND.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة رد خطابات الضمان",
                            TableName = "Tbl_LetterWarrentyAudit",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة رد خطابات الضمان"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        MessageBox.Show("تم الحفظ");

                    }
                }
                else
                {
                    MessageBox.Show("تم اضافة رد هذا الخطاب من قبل لهذا ");
                }
            }

            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة رد خطاب  .. برجاء مراجعة مدير المنظومه");
            }
        }
        private void LetterWAuditSelect(int? Vint_LetterWIDC)
        {
            var ListLetterWAuditOrdUser = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWIDC && x.UserID == Program.GlbV_UserId);
            if (ListLetterWAuditOrdUser != null)
            {
                if (ListLetterWAuditOrdUser.LetterWRefundLetter == true)
                { chckBxBasicData.Checked = true; }
                else
                {
                    chckBxBasicData.Checked = false;
                }
            }
            var ListLetterWAudit = (from LtrWAud in FsDb.Tbl_LetterWarrentyAudit
                                    join usr in FsDb.Tbl_User on LtrWAud.UserID equals usr.ID
                                    join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                    where (LtrWAud.LetterWarrentyID == Vint_LetterWIDC)
                                    select new
                                    {
                                        EmpName = emp.Name
                                    }).Distinct().ToList();
            if (ListLetterWAudit.Count != 0)
            {
                string Vstr_RefrencesOrder = "";
                int WCount = int.Parse(ListLetterWAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_RefrencesOrder = ListLetterWAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
                }
                //chckBxBasicData.Checked = true;
                textBox6.Text = Vstr_RefrencesOrder;
            }
            else
            {
                //chckBxBasicData.Checked = false;
                textBox6.Text = "";
            }
        }
        private void chckBxBasicData_MouseClick(object sender, MouseEventArgs e)
        {

            if (LetterId.Text != "")
            {
                int Vint_LetterWID = int.Parse(LetterId.Text);
                bool Vbl_LetterWRefund = false;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 71 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {


                    Vbl_LetterWRefund = true;
                    var ListOrderAuditLetterUser = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWID && x.UserID == Program.GlbV_UserId);
                    if (ListOrderAuditLetterUser == null)

                    {

                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));


                        Tbl_LetterWarrentyAudit LttrWAdt = new Tbl_LetterWarrentyAudit
                        {

                            UserID = Program.GlbV_UserId,
                            LetterWarrentyID = Vint_LetterWID,
                            //LetterWBasicData = Vbl_BasicDataOrder,
                            //LetterWExpandDate = Vbl_LetterWRefund,
                            LetterWRefundLetter = Vbl_LetterWRefund,
                            ReferenceDate = Vdt_Today
                        };
                        FsDb.Tbl_LetterWarrentyAudit.Add(LttrWAdt);
                        FsDb.SaveChanges();

                        int Vint_LastRow = LttrWAdt.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مراجعة خطابات الضمان",
                            TableName = "Tbl_LetterWarrentyAudit",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراجعة خطابات الضمان"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        //                //****************Refrences***************
                        LetterWAuditSelect(Vint_LetterWID);
                        //                //***************************************


                    }
                    else
                    {
                        if (chckBxBasicData.Checked == true)
                        {
                            Vbl_LetterWRefund = true;
                        }
                        else
                        {
                            Vbl_LetterWRefund = false;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListOrderAuditOrdUsero = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWID && x.UserID == Program.GlbV_UserId);
                        ListOrderAuditOrdUsero.LetterWRefundLetter = Vbl_LetterWRefund;
                        //ListOrderAuditOrdUsero.OrderIItemDataID = Vbl_itemso;
                        //ListOrderAuditOrdUsero.OrderITermsID = Vbl_termso;
                        ListOrderAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //****************Refrences***************
                        LetterWAuditSelect(Vint_LetterWID);
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  مراجعه رد خطاب  .. برجاء مراجعة مدير المنظومه");
                }
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.LetterWarrentyAuditFrm t = new Forms.DocumentsForms.LetterWarrentyAuditFrm();
                t.txtLetterKind.Text = this.txtLetterKind.Text;
                t.txtBank.Text = this.txtBank.Text;

                t.txtLetterFullNo.Text = this.txtLetterFullNo.Text;

                //t.MskStartDate.Value = Convert.ToDateTime(this.dtpLetterDate.Value.ToString("yyyy/MM/dd"));
                //t.MskFirstExpandDate.Value = Convert.ToDateTime(this.dTPExpireLetterDate.Value.ToString("yyyy/MM/dd"));
                t.LetterId.Text = this.LetterId.Text;
                t.txtLetterKindID.Text = this.txtLetterKindID.Text;
                t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;
                if (LetterId.Text != "")
                {
                    t.ShowDialog();
                }
                
                //if (Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow != null)
                //{
                //    txtSupliers.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[1].Value.ToString();
                //    txtSuplierID.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[0].Value.ToString();

                //}
            }
        }

        private void chckBxBasicData_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}