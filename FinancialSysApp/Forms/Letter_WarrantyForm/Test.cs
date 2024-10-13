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

namespace FinancialSysApp.Forms.Letter_WarrantyForm
{
    public partial class Test : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_LetterWarantyID = 0;
        
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //**************** Update ***************
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Vint_LetterWarantyID = int.Parse(row.Cells[0].Value.ToString());
                var ListUpdateLetterWarranty = FsDb.Tbl_LetterWarranty.FirstOrDefault(x => x.ID == Vint_LetterWarantyID);
                var listExpand = FsDb.Tbl_LetterWExpandDates.Where(x => x.LetterWarrantyID == Vint_LetterWarantyID).ToList();

               var   ListExpandDatetterWarranty = FsDb.Tbl_LetterWExpandDates.Where(x => x.LetterWarrantyID == Vint_LetterWarantyID).ToList();  



                if (ListExpandDatetterWarranty.Count > 0)
                {
                    var ListExpandDatetterWarrantyN = FsDb.Tbl_LetterWExpandDates.Where(x => x.LetterWarrantyID == Vint_LetterWarantyID).Select(p => p.LetterWExpandDate).Max();
                    DateTime? Vdate_CalcNewDate = null;
                    int Vint_KindId = 0;
                    Vint_KindId = int.Parse(ListUpdateLetterWarranty.LetterWarrantyKind.ToString());
                    if (ListUpdateLetterWarranty.LetterWarrantyExpireDate != null)
                    {

                        Vdate_CalcNewDate = Convert.ToDateTime(ListExpandDatetterWarrantyN.ToString());
                        if (Vint_KindId == 1)
                        {

                            ListUpdateLetterWarranty.LetterWarrantyExpandDate = Vdate_CalcNewDate.Value.AddMonths(3);
                        }
                        else if (Vint_KindId == 2 || Vint_KindId == 3)
                        {
                            ListUpdateLetterWarranty.LetterWarrantyExpandDate = Vdate_CalcNewDate.Value.AddMonths(6);
                        }
                    }
                }
                else
                {
                    DateTime? Vdate_CalcNewDate = null;
                    int Vint_KindId = 0;
                    Vint_KindId = int.Parse(ListUpdateLetterWarranty.LetterWarrantyKind.ToString());
                    if (ListUpdateLetterWarranty.LetterWarrantyExpireDate != null)
                    {

                         
                        if (Vint_KindId == 1)
                        {

                            ListUpdateLetterWarranty.LetterWarrantyExpandDate = ListUpdateLetterWarranty.LetterWarrantyExpireDate;
                        }
                        else if (Vint_KindId == 2 || Vint_KindId == 3)
                        {
                            ListUpdateLetterWarranty.LetterWarrantyExpandDate = ListUpdateLetterWarranty.LetterWarrantyExpireDate;
                        }
                    }
                }
                FsDb.SaveChanges();
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_LetterWarranty.ToList();
            textBox1.Text = FsDb.Tbl_LetterWarranty.Count().ToString();
        }
    }
}
