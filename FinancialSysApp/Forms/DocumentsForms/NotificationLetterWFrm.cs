using DevExpress.XtraCharts;
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
    public partial class NotificationLetterWFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public NotificationLetterWFrm()
        {
            InitializeComponent();
        }

        private void NotificationLetterWFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_RefundLettersReasons' table. You can move, or remove it, as needed.
            this.tbl_RefundLettersReasonsTableAdapter.Fill(this.financialSysDataSet.Tbl_RefundLettersReasons);
            // TODO: This line of code loads data into the 'financialSysDataSet1.Tbl_RefundLettersReasons' table. You can move, or remove it, as needed.
            
             dTPNotificationDate.Focus();
        }

        private void dTPNotificationDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRecieveMethode.Focus();
            }
        }

        private void cmbRecieveMethode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            int Vint_LetterID = int.Parse((LetterId.Text));
            DateTime Vdt_NtfDate = Convert.ToDateTime(dTPNotificationDate.Value.ToString());
            int Vint_refundLtrReason = int.Parse(cmbRecieveMethode.SelectedValue.ToString());
            //var list = FsDb.Tbl_NotificationLetter.Where(x=>x.LetterWarrantyID == Vint_LetterID && x.NotificationDate == Vdt_NtfDate &&x.RefundLetterReasonsID == Vint_refundLtrReason);
            var list = FsDb.Tbl_NotificationLetter.Where(x => x.LetterWarrantyID == Vint_LetterID ).ToList();
            if (list.Count() == 0)
            {
                if (cmbRecieveMethode.SelectedIndex == -1)
                {
                    MessageBox.Show("اختر طريقة التسليم");
                }
                else
                {
                    Tbl_NotificationLetter NTF = new Tbl_NotificationLetter()
                    {
                        LetterWarrantyID = Vint_LetterID,
                        NotificationDate = Vdt_NtfDate,
                        RefundLetterReasonsID = Vint_refundLtrReason
                    };
                    FsDb.Tbl_NotificationLetter.Add(NTF);
                    FsDb.SaveChanges();
                    MessageBox.Show("تم الحفظ");
                 }
            }
            else
            {
                MessageBox.Show("تم اضافة هذا الاخطار من قبل لهذا الخطاب");
            }
        }
    }
}
