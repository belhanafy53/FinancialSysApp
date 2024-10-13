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


namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class BnfDupplicateFrm : Form
    {
        Model1 Fsdb = new Model1();
        int Vint_ID = 0;
        int Vint_Benf = 0;
        string VStr_TaxFullNo = "";
        //string VStr_TaxFullNo1 = "";
        string VStr_TaxFullNo2 = "";
        //string VStr_TaxFullNo3 = "";
        public BnfDupplicateFrm()
        {
            InitializeComponent();
        }

        private void BnfDupplicateFrm_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = Fsdb.Tbl_Employee.Where(x => x.ID >= 16100 && x.ID <= 17000).OrderBy(x => x.ID).ToList();

            dataGridView2.DataSource = Fsdb.Tbl_Supplier.OrderBy(x => x.ID).ToList();
            //dataGridView2.DataSource = Fsdb.Tbl_Supplier.Where(x => x.ID >= 18 && x.ID <= 20).OrderBy(x => x.ID).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {


                Vint_ID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                var listBenf = Fsdb.Tbl_Beneficiary.Where(x => x.ID_Emp == Vint_ID).ToList();
                if (listBenf.Count() > 1)
                {
                    for (int t = 0; t < listBenf.Count(); t++)
                    {
                        Vint_Benf = listBenf[t].ID;
                        var ListBemp = Fsdb.Tbl_Beneficiary.FirstOrDefault(x => x.ID == Vint_Benf && x.Parent_ID == null && x.ID_Emp == Vint_ID);
                        if (ListBemp != null)
                        {
                            int Vint_bnfDublicate = ListBemp.ID;
                            var listD = Fsdb.TBL_Document.Where(x => x.Beneficiary_ID == Vint_bnfDublicate).ToList();

                            var listDbnf = Fsdb.Tbl_DocumentBenefcairy.Where(x => x.Beneficiary_ID == Vint_bnfDublicate).ToList();

                            if (listD.Count() == 0 && listDbnf.Count == 0)
                            {
                                var ListBnfemp = Fsdb.Tbl_Beneficiary.FirstOrDefault(x => x.ID == Vint_bnfDublicate);
                                if (ListBnfemp != null)
                                {
                                    Fsdb.Tbl_Beneficiary.Remove(ListBnfemp);
                                    Fsdb.SaveChanges();
                                }
                            }
                        }

                    }
                }

            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {


                Vint_ID = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                var listBenf = Fsdb.Tbl_Beneficiary.Where(x => x.ID_Supp == Vint_ID).ToList();
                if (listBenf.Count() > 1)
                {
                    for (int t = 0; t < listBenf.Count(); t++)
                    {
                        Vint_Benf = listBenf[t].ID;
                        var ListBSup = Fsdb.Tbl_Beneficiary.FirstOrDefault(x => x.ID == Vint_Benf && x.Parent_ID == null && x.ID_Supp == Vint_ID);
                        if (ListBSup != null)
                        {
                            int Vint_bnfDublicate = ListBSup.ID;
                            var listD = Fsdb.TBL_Document.Where(x => x.Beneficiary_ID == Vint_bnfDublicate).ToList();

                            var listDbnf = Fsdb.Tbl_DocumentBenefcairy.Where(x => x.Beneficiary_ID == Vint_bnfDublicate).ToList();

                            if (listD.Count() == 0 && listDbnf.Count == 0)
                            {
                                var ListBnfemp = Fsdb.Tbl_Beneficiary.FirstOrDefault(x => x.ID == Vint_bnfDublicate);
                                if (ListBnfemp != null)
                                {
                                    Fsdb.Tbl_Beneficiary.Remove(ListBnfemp);
                                    Fsdb.SaveChanges();
                                }
                            }
                        }

                    }
                }

            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                Vint_ID = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                if (dataGridView2.Rows[i].Cells[5].Value != null)
                {
                    VStr_TaxFullNo = (dataGridView2.Rows[i].Cells[5].Value.ToString()).Trim();
                    var Vstr_Parent = (VStr_TaxFullNo).Split(new char[] { '-' });
                    int index_to = (VStr_TaxFullNo).Trim().LastIndexOf('-');
                    int index_of = (VStr_TaxFullNo).Trim().IndexOf('-');
                    if (index_to > 0 && index_of > 0)
                    {
                        //************Value 1 *****************
                        string Vstr_V1 = VStr_TaxFullNo.Trim().Substring(0, index_of);
                        int txTaxFullNotLenghth = VStr_TaxFullNo.Trim().Length;
                        string Vstr_tax2 = VStr_TaxFullNo.Trim().Substring((index_of + 1), txTaxFullNotLenghth - (index_of + 1));
                        int txtLenghth = Vstr_tax2.Trim().Length;
                        //************Value 2 *****************
                        int index_to1 = (Vstr_tax2).Trim().LastIndexOf('-');
                        int index_of1 = (Vstr_tax2).Trim().IndexOf('-');


                        string Vstr_V2 = (Vstr_tax2).Trim().Substring(0, txtLenghth - (index_of1 + 1));
                        //**************Value 3 *********************
                        int index_to2 = (Vstr_tax2).Trim().LastIndexOf('-');
                        int index_of2 = (Vstr_tax2).Trim().IndexOf('-');

                        string Vstr_V3 = "";
                        Vstr_V3 = (Vstr_tax2).Trim().Substring((index_of2 + 1), txtLenghth - (index_of2 + 1));
                        var ListSupp = Fsdb.Tbl_Supplier.FirstOrDefault(x => x.ID == Vint_ID);
                        //****************************
                        ListSupp.Tax_FileNo1 = Vstr_V3;
                        ListSupp.Tax_FileNo2 = Vstr_V2;
                        ListSupp.Tax_FileNo3 = Vstr_V1;
                        Fsdb.SaveChanges();
                       
                    }
                }
            }
            MessageBox.Show("1");
        }
    }
}

