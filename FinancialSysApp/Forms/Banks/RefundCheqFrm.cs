using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;

namespace FinancialSysApp.Forms.Banks
{
    public partial class RefundCheqFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        bool Vbl_RefundCequeCheck = false;
        int Vint_BankCheqId = 0;
        public RefundCheqFrm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 89 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                Vint_BankCheqId = int.Parse(txtCheqId.Text);
                var ListRefundCheq = FsDb.Tbl_RefundCheque.FirstOrDefault(x => x.BankChequesID == Vint_BankCheqId);
                var listCheq = FsDb.Tbl_BankCheques.FirstOrDefault(x => x.ID == Vint_BankCheqId);
                var resultMsg = MessageBox.Show( "هل تريد رد هذا الشيك   " + " ؟ ", "رد شيك ", MessageBoxButtons.YesNo);
                if (resultMsg == DialogResult.Yes)
                {
                    if (checkBox1.Checked == true)
                    {
                        Vbl_RefundCequeCheck = true;

                    }
                    else
                    {
                        Vbl_RefundCequeCheck = false;

                    }
                    if (ListRefundCheq == null)

                    {

                        Tbl_RefundCheque Rch = new Tbl_RefundCheque
                        {
                            BankChequesID = Vint_BankCheqId,
                            IsRefundCheque = Vbl_RefundCequeCheck
                        };
                        FsDb.Tbl_RefundCheque.Add(Rch);
                       
                        Tbl_ChequeBankStatusDates cst = new Tbl_ChequeBankStatusDates
                        {
                            ChequeBankStatusDate = Convert.ToDateTime(dateTimePicker2.Value.ToString()),
                            BankChequeID = Vint_BankCheqId,
                            BankChequeStatusID = 4
                        };
                        FsDb.Tbl_ChequeBankStatusDates.Add(cst);
                      
                        //****************تعديل حالة الشيك

                        listCheq.ChequeStatusID = 4;
                        listCheq.ChequeStatusDate = Convert.ToDateTime(dateTimePicker2.Value.ToString());
                        FsDb.SaveChanges();

                        int Vint_LastRow = Rch.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة رد شيك",
                            TableName = "Tbl_RefundCheque",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                            //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة رد الشيكات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        this.dtb_ChqStatusDatesTableAdapter.FillByCheqID(this.bankCheques.Dtb_ChqStatusDates, Vint_BankCheqId);
                        //****************Refrences***************
                    }
                    else
                    {
                        listCheq.ChequeStatusID = 4;
                        listCheq.ChequeStatusDate = Convert.ToDateTime(dateTimePicker2.Value.ToString());
                        ListRefundCheq.IsRefundCheque = Vbl_RefundCequeCheck;
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل رد شيك",
                            TableName = "Tbl_RefundCheque",
                            TableRecordId = Vint_BankCheqId.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Classes.GetServerDate.Cs_GetServerDate()),
                            //ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة رد الشيكات"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        this.dtb_ChqStatusDatesTableAdapter.FillByCheqID(this.bankCheques.Dtb_ChqStatusDates, Vint_BankCheqId);
                    }
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية رد شيك .. برجاء مراجعة مدير المنظومه");
            }

        }

        private void RefundCheqFrm_Load(object sender, EventArgs e)
        {
            Vint_BankCheqId = int.Parse(txtCheqId.Text);
            this.dtb_ChqStatusDatesTableAdapter.FillByCheqID(this.bankCheques.Dtb_ChqStatusDates, Vint_BankCheqId);
        }
    }
}
