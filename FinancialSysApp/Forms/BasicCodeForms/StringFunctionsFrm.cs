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
    public partial class StringFunctionsFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public StringFunctionsFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "B1-B2 +B3";
            //textBox2.Text = (textBox1.Text).Substring(0, (textBox1.Text).Length - 4);
            textBox3.Text = (textBox1.Text).Length.ToString();
            string Vstr_strchr = (textBox1.Text);

            string[] vv = Vstr_strchr.Split(new char[] { '-' });
            textBox4.Text = vv[0].ToString();
            string gg = vv[1].ToString();
            string[] dd = gg.Split(new char[] { '+' });
            textBox5.Text = dd[0].ToString();
            textBox6.Text = dd[1].ToString();

        }

        private void StringFunctionsFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items' table. You can move, or remove it, as needed.
            this.tbl_ItemsTableAdapter.Fill(this.financialSysDataSet.Tbl_Items);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items1' table. You can move, or remove it, as needed.
            this.tbl_Items1TableAdapter.FillItemParentNull(this.financialSysDataSet.Tbl_Items1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Result = "";
            //int LoopCount = 0;
            int TableCount = dataGridView1.RowCount;
            int ParentItemID = 0;
            int Parent1ItemID = 0;
            string SelectedResult = "";
            string SelectedResult1 = "";

            for (int i = 0; i <= TableCount - 2; i++)
            {
                int itemID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                //int itemID = 150;
                var ListitemName = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == itemID);
                Result = ListitemName.Name;
                var ListParent = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == itemID);
                if (ListParent.Parent_ID != null)
                {
                    ParentItemID = int.Parse(ListParent.Parent_ID.ToString());
                    var ListParentName = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == ParentItemID);
                    SelectedResult = ListParentName.Name;
                    Result = Result + " - " + SelectedResult;
                    if (ListParentName.Parent_ID != null)
                    {
                        int Vint_parent1id = int.Parse(ListParentName.Parent_ID.ToString());
                        var listParent1 = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent1id);
                        if (listParent1.Parent_ID != null)
                        {
                            Parent1ItemID = int.Parse(listParent1.Parent_ID.ToString());
                            var ListParent1Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Parent1ItemID);
                            SelectedResult1 = ListParent1Name.Name;
                            Result = Result + " - " + SelectedResult1;

                            if (ListParent1Name.Parent_ID != null)
                            {

                                int Vint_parent2id = int.Parse(ListParent1Name.Parent_ID.ToString());
                                var listParent2 = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent2id);
                                if (listParent2.Parent_ID != null)
                                {
                                    int Parent2ItemID = int.Parse(listParent2.Parent_ID.ToString());
                                    var ListParent2Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Parent2ItemID);
                                    string SelectedResult2 = ListParent2Name.Name;
                                    Result = Result + " - " + SelectedResult2;
                                        int Vint_parent3id = int.Parse(ListParent2Name.Parent_ID.ToString());
                                        var listParent3 = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent2id);

                                        if (listParent3.Parent_ID != null)
                                        {
                                            int Parent3ItemID = int.Parse(listParent3.Parent_ID.ToString());
                                            var ListParent3Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Parent3ItemID);
                                            string SelectedResult3 = ListParent3Name.Name;
                                            Result = Result + " - " + SelectedResult3;


                                        }
                                        else
                                        {

                                            var ListParent3Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent3id);
                                            string SelectedResult3 = ListParent3Name.Name;
                                            Result = Result + " - " + SelectedResult3;
                                        }
                                }
                                else
                                {

                                    var ListParent2Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent2id);
                                    string SelectedResult2 = ListParent2Name.Name;
                                    Result = Result + " - " + SelectedResult2;
                                }
                            }

                        }
                        else
                        {
                            var ListParent3Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent1id);
                            string SelectedResult2 = ListParent3Name.Name;
                            Result = Result + " - " + SelectedResult2;
                        }
                    }
                }

                dataGridView1.Rows[i].Cells[3].Value = Result;
                var listResultF = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == itemID);
                //var listResultF = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));

                listResultF.Note = Result;
                FsDb.SaveChanges();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
        //    string Result = "";
        //    int LoopCount = 0;
        //    int TableCount = dataGridView1.RowCount;
        //    int ParentItemID = 0;
        //    int Parent1ItemID = 0;
        //    string SelectedResult = "";
        //    string SelectedResult1 = "";

        //    int itemID = int.Parse(textBox8.Text);

        //    var ListitemName = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == itemID);
        //    Result = ListitemName.Name;
        //    var ListParent = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == itemID);
        //    if (ListParent.Parent_ID != null)
        //    {
        //        ParentItemID = int.Parse(ListParent.Parent_ID.ToString());
        //        var ListParentName = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == ParentItemID);
        //        SelectedResult = ListParentName.Name;
        //        Result = Result + " - " + SelectedResult;
        //        if (ListParentName.Parent_ID != null)
        //        {
        //            int Vint_parent1id = int.Parse(ListParentName.Parent_ID.ToString());
        //            var listParent1 = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent1id);
        //            if (listParent1.Parent_ID != null)
        //            {
        //                Parent1ItemID = int.Parse(listParent1.Parent_ID.ToString());
        //                var ListParent1Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Parent1ItemID);
        //                SelectedResult1 = ListParent1Name.Name;
        //                Result = Result + " - " + SelectedResult1;

        //                if (ListParent1Name.Parent_ID != null)
        //                {

        //                    int Vint_parent2id = int.Parse(ListParent1Name.Parent_ID.ToString());
        //                    var listParent2 = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent2id);
        //                    if (listParent2.Parent_ID != null)
        //                    {
        //                        int Parent2ItemID = int.Parse(listParent2.Parent_ID.ToString());
        //                        var ListParent2Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Parent2ItemID);
        //                        string SelectedResult2 = ListParent2Name.Name;
        //                        Result = Result + " - " + SelectedResult2;
        //                        int Vint_parent3id = int.Parse(ListParent2Name.Parent_ID.ToString());
        //                        var listParent3 = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent2id);

        //                                if (listParent3.Parent_ID != null)
        //                                {
        //                                    int Parent3ItemID = int.Parse(listParent3.Parent_ID.ToString());
        //                                    var ListParent3Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Parent3ItemID);
        //                                    string SelectedResult3 = ListParent3Name.Name;
        //                                    Result = Result + " - " + SelectedResult3;


        //                                }
        //                                else
        //                                {

        //                                    var ListParent3Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent3id);
        //                                    string SelectedResult3 = ListParent3Name.Name;
        //                                    Result = Result + " - " + SelectedResult3;
        //                                }
        //                    }
        //                    else
        //                    {

        //                        var ListParent2Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent2id);
        //                        string SelectedResult2 = ListParent2Name.Name;
        //                        Result = Result + " - " + SelectedResult2;
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                var ListParent3Name = FsDb.Tbl_Items.FirstOrDefault(x => x.ID == Vint_parent1id);
        //                string SelectedResult2 = ListParent3Name.Name;
        //                Result = Result + " - " + SelectedResult2;
        //            }
        //        }
        //    }

        //    dataGridView1.Rows[i].Cells[3].Value = Result;
        }
    }
}