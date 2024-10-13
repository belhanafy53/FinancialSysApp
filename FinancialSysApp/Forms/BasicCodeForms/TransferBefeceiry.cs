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
using UserRoles;

namespace FinancialSysApp.Forms
{
    public partial class TransferBefeceiry : Form
    {
        Model1 FsDb = new Model1();
        public TransferBefeceiry()
        {
            InitializeComponent();
        }

        private void TransferBefeceiry_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FsDb.Tbl_Supplier.OrderBy(x => x.Name).ToList();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {                                                                                   
            int? VintSupId;
            if (dataGridView1.RowCount > 0)
            {
                int WCount = int.Parse(dataGridView1.RowCount.ToString());
               
                for (int i = 0; i <= WCount - 1; i++)
                {
                    VintSupId = string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value.ToString()) ? (int?)null : int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());


                    var listbenf = FsDb.Tbl_Beneficiary.SingleOrDefault(x => x.ID_Supp == VintSupId);
                    if (listbenf == null)
                    {
                        Tbl_Beneficiary bnf = new Tbl_Beneficiary
                        {
                            Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                            ID_Supp = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()),
                            BeneficiaryKind_ID = 2

                        };
                        FsDb.Tbl_Beneficiary.Add(bnf);
                        FsDb.SaveChanges();
                    }
                 
                }
            }
        }
    }
}
