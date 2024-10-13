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
    public partial class SecurityActionRestFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 Fsdb = new Model1();
        ModelEvent Fsevdb = new ModelEvent();
        public SecurityActionRestFrm()
        {
            InitializeComponent();
        }

        private void SecurityActionRestFrm_Load(object sender, EventArgs e)
        {
            var list = Fsevdb.SecurityEvents.Where(x => x.TableName == "Tbl_AccountingRestriction" && x.TableRecordId != null && x.TrecordId == null && x.User_ID != 10).ToList();
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Vint_dgrowcount = dataGridView1.RowCount;
            label1.Text = Vint_dgrowcount.ToString();
           
            for (int i=0;i< Vint_dgrowcount;i++)
            {
                int Vint_Restriction_No = 0;
                int Vint_Length = dataGridView1.Rows[i].Cells["TableRecordId"].Value.ToString().Trim().Length;
                long Vlong_Id = long.Parse(dataGridView1.Rows[i].Cells["ID"].Value.ToString());
                var list = Fsevdb.SecurityEvents.FirstOrDefault(x =>x.ID == Vlong_Id);
                if (Vint_Length < 6)
                {
                     Vint_Restriction_No = int.Parse((dataGridView1.Rows[i].Cells["TableRecordId"].Value.ToString().Trim()).Substring(0, Vint_Length));
                }
                else if (Vint_Length >= 6)
                {
                     Vint_Restriction_No = int.Parse((dataGridView1.Rows[i].Cells["TableRecordId"].Value.ToString().Trim()).Substring(0, 5));
                }
                 var Vstr_IDRest = Fsdb.Tbl_AccountingRestriction.FirstOrDefault(x => x.Restriction_NO == Vint_Restriction_No);
                if (Vstr_IDRest != null)
                {
                    long Vlong_restId = Vstr_IDRest.ID;
                    dataGridView1.Rows[i].Cells["TrecordId"].Value = Vlong_restId;
                    list.TrecordId = Vlong_restId;
                    Fsevdb.SaveChanges();

                }
            
            }
        }
    }
}