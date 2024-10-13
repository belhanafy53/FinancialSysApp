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
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using Telerik.Windows.Documents.Fixed.Model.Objects;
using DevExpress.XtraCharts.Design;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class LetterWarrantyExpandFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        DateTime? Vdt_LetterExpir = null;
        DateTime? Vdt_LetterLastExpand = null;
        DateTime? Vdate_CalcNewDate = null;
        int Vint_LetterId = 0;
        int Vint_KindId = 0;


        public LetterWarrantyExpandFrm()
        {
            InitializeComponent();
        }
        private void CalcDates(int Vint_Lid, int Vint_kid)
        {
            //******** Retrieve Data
            var list = FsDb.Tbl_LetterWExpandDates.Where(x => x.LetterWarrantyID == Vint_LetterId).OrderBy(x => x.LetterWExpandDate).ToList();
            if (list != null)
            {
                dataGridView1.DataSource = list;

            }
            if (list.Count != 0)
            {
                Vdt_LetterLastExpand = Convert.ToDateTime(list.Max(x => x.LetterWExpandDate).ToString("yyyy/MM/dd"));
                MskExpandLastDate.Text = Convert.ToDateTime(Vdt_LetterLastExpand).ToString("yyyy/MM/dd");

            }

            Vdt_LetterExpir = Convert.ToDateTime(MskFirstExpandDate.Value.ToString("yyyy/MM/dd"));


            if (MskExpandLastDate.Text == "")
            {


                if (Vint_KindId == 1)
                {
                    Vdate_CalcNewDate = Vdt_LetterExpir;
                    dateTimePicker1.Value = (MskFirstExpandDate.Value).AddMonths(3);
                }
                else if (Vint_KindId == 2 || Vint_KindId == 3)
                {
                    Vdate_CalcNewDate = Convert.ToDateTime((MskFirstExpandDate.Value).AddMonths(6).ToString());
                    dateTimePicker1.Value = Vdate_CalcNewDate.Value;
                }
            }
            else if (MskExpandLastDate.Text != "")
            {


                if (Vint_KindId == 1)
                {
                    Vdate_CalcNewDate = Convert.ToDateTime((Vdt_LetterLastExpand.Value).AddMonths(3).ToString());
                    dateTimePicker1.Value = Vdate_CalcNewDate.Value;
                }
                else if (Vint_KindId == 2)
                {
                    Vdate_CalcNewDate = Convert.ToDateTime((Vdt_LetterLastExpand.Value).AddMonths(6).ToString());
                    dateTimePicker1.Value = Vdate_CalcNewDate.Value;
                }
                else if (Vint_KindId == 3)
                {
                    Vdate_CalcNewDate = Convert.ToDateTime((Vdt_LetterLastExpand.Value).AddMonths(6).ToString());
                    dateTimePicker1.Value = Vdate_CalcNewDate.Value;
                }
            }

            //dateEdit1.Text = "";
            dateTimePicker1.Focus();
        }
        private void LetterWarrantyExpandFrm_Load(object sender, EventArgs e)
        {


            Vint_LetterId = int.Parse(LetterId.Text);
            Vint_KindId = int.Parse(txtLetterKindID.Text);
            CalcDates(Vint_LetterId, Vint_KindId);
            //                //****************Refrences***************
            LetterWAuditSelect(Vint_LetterId);
            //                //***************************************
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime Vdate_NewDate = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            var Vdate_Sub = Vdate_NewDate.Subtract(Vdate_CalcNewDate.Value).TotalDays;
            var ListLW = FsDb.Tbl_LetterWarranty.Where(x => x.ID == Vint_LetterId).ToList();
            if (Program.GlbV_UserTypeId == 3 || Program.GlbV_UserTypeId == 6)
            {
                if (Vdate_Sub >= -2 && Vdate_Sub <= 2)
                {
                    Tbl_LetterWExpandDates ltrw = new Tbl_LetterWExpandDates()
                    {
                        LetterWarrantyID = Vint_LetterId,
                        LetterWExpandDate = Vdate_NewDate,
                    };
                    FsDb.Tbl_LetterWExpandDates.Add(ltrw);
                    if (Vint_KindId == 1)
                    {
                        Vdate_CalcNewDate = Vdt_LetterExpir;
                        ListLW[0].LetterWarrantyExpandDate = (MskFirstExpandDate.Value).AddMonths(3);
                    }
                    else if (Vint_KindId == 2 || Vint_KindId == 3)
                    {
                        Vdate_CalcNewDate = Convert.ToDateTime((MskFirstExpandDate.Value).AddMonths(6).ToString());
                        ListLW[0].LetterWarrantyExpandDate = Vdate_CalcNewDate.Value;
                    }
                    
                    FsDb.SaveChanges();
                    MessageBox.Show("تم الحفظ");
                    CalcDates(Vint_LetterId, Vint_KindId);

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحيه لحفظ تاريخ مد الخطاب الا في حدود المده المقرره ");
                }
            }
            else if (Program.GlbV_UserTypeId == 1 || Program.GlbV_UserTypeId == 2 || Program.GlbV_UserTypeId == 7)
            {
                Tbl_LetterWExpandDates ltrw = new Tbl_LetterWExpandDates()
                {
                    LetterWarrantyID = Vint_LetterId,
                    LetterWExpandDate = Vdate_NewDate,
                };
                FsDb.Tbl_LetterWExpandDates.Add(ltrw);
                FsDb.SaveChanges();
                MessageBox.Show("تم الحفظ");

                CalcDates(Vint_LetterId, Vint_KindId);


            }


        }
        private void LetterWAuditSelect(int? Vint_LetterWIDC)
        {
            var ListLetterWAuditOrdUser = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWIDC && x.UserID == Program.GlbV_UserId);
            if (ListLetterWAuditOrdUser != null)
            {
                if (ListLetterWAuditOrdUser.LetterWExpandDate == true)
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
                bool vbl_LetterExpand = false;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 71 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {


                    vbl_LetterExpand = true;
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
                            //LetterWRefundLetter = Vbl_LetterWRefund,
                            LetterWExpandDate = vbl_LetterExpand,
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
                            vbl_LetterExpand = true;
                        }
                        else
                        {
                            vbl_LetterExpand = false;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListOrderAuditOrdUsero = FsDb.Tbl_LetterWarrentyAudit.FirstOrDefault(x => x.LetterWarrentyID == Vint_LetterWID && x.UserID == Program.GlbV_UserId);
                        ListOrderAuditOrdUsero.LetterWExpandDate = vbl_LetterExpand;
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
                    MessageBox.Show("ليس لديك صلاحية اضافة  مراجعه مد خطاب  .. برجاء مراجعة مدير المنظومه");
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string Vst_Date = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            var resultMsg = MessageBox.Show(Vst_Date  + " " + "هل تريد حدف هدا التاريخ   " + " ؟ ", "حدف مد ", MessageBoxButtons.YesNo);
            int Vint_id = 0;
            
            if (resultMsg == DialogResult.Yes)
            {
                Vint_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
              int  Vint_LetterWID = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                var listExpLetter = FsDb.Tbl_LetterWExpandDates.FirstOrDefault(x => x.ID == Vint_id);
                if (listExpLetter != null) 
                { 
                    FsDb.Tbl_LetterWExpandDates.Remove(listExpLetter);
                    FsDb.SaveChanges();
                    MessageBox.Show("تم الحذف");
                    ////****************Refrences***************
                    //LetterWAuditSelect(Vint_LetterWID);
                   dataGridView1.DataSource = listExpLetter;
                    ////***************************************
                }

            }
        }
    }
}