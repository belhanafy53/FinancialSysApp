using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Net;
using DevComponents.DotNetBar.Controls;
using AnalogClock.My.Resources;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Diagnostics;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Res_Search : Telerik.WinControls.UI.RadForm
    {
        Model1 FsDb = new Model1();
        public Res_Search()
        {
            InitializeComponent();
        }
        public DataTable getDay()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_AccountingRestrictions_Kind where ParentID is Not null Order by ID ASC");
            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        private void Res_Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_OrderKind' table. You can move, or remove it, as needed.
            this.tbl_OrderKindTableAdapter.Fill(this.financialSysDataSet.Tbl_OrderKind);
            comboBox1.DataSource = getDay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedValue = -1;
            comboBox4.DataSource = getDay();
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "ID";
            comboBox4.SelectedValue = -1;
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_AccountingRestrictionItems' table. You can move, or remove it, as needed.
            Order.SelectedIndex = -1;
            //string hostName = Dns.GetHostName();
            this.tbl_SystemUnitesTableAdapter.Fill(this.systemUnitesDataSet.Tbl_SystemUnites);
            comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
            }
            radDateTimePicker1.Select();
            this.ActiveControl = radDateTimePicker1;
            radDateTimePicker1.Focus();
            //string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            //IPLbl.Text = IP;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void Descp_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //BindingSource bs = new BindingSource();
            //    //bs.DataSource = dataGridView1.DataSource;
            //    //bs.Filter = dataGridView1.Columns[8].HeaderText.ToString() + " LIKE '%" + Descp.Text + "%'";
            //    //dataGridView1.DataSource = bs;

            //    foreach (System.Windows.Forms.DataGridViewRow r in dataGridView1.Rows)
            //    {
            //        if ((r.Cells[8].Value).ToString().ToUpper().Contains(Descp.Text ))
            //        {
            //            dataGridView1.Rows[r.Index].Visible = true;
            //            //dataGridView1.Rows[r.Index].Selected = true;
            //        }
            //        else
            //        {
            //            dataGridView1.CurrentCell = null;
            //            dataGridView1.Rows[r.Index].Visible = false;
            //        }
            //    }
            //}
            //catch { }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //BindingSource bs = new BindingSource();
            //    //bs.DataSource = dataGridView1.DataSource;
            //    //bs.Filter = dataGridView1.Columns[8].HeaderText.ToString() + " LIKE '%" + Descp.Text + "%'";
            //    //dataGridView1.DataSource = bs;

            //    foreach (System.Windows.Forms.DataGridViewRow r in dataGridView1.Rows)
            //    {
            //        if ((r.Cells[3].Value).ToString().ToUpper().Contains(comboBox3.Text))
            //        {
            //            dataGridView1.Rows[r.Index].Visible = true;
            //            //dataGridView1.Rows[r.Index].Selected = true;
            //        }
            //        else
            //        {
            //            dataGridView1.CurrentCell = null;
            //            dataGridView1.Rows[r.Index].Visible = false;
            //        }
            //    }
            //}
            //catch { }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //BindingSource bs = new BindingSource();
            //    //bs.DataSource = dataGridView1.DataSource;
            //    //bs.Filter = dataGridView1.Columns[8].HeaderText.ToString() + " LIKE '%" + Descp.Text + "%'";
            //    //dataGridView1.DataSource = bs;

            //    foreach (System.Windows.Forms.DataGridViewRow r in dataGridView1.Rows)
            //    {
            //        if ((r.Cells[2].Value).ToString().ToUpper().Equals(comboBox1.Text))
            //        {
            //            dataGridView1.Rows[r.Index].Visible = true;
            //            //dataGridView1.Rows[r.Index].Selected = true;
            //        }
            //        else
            //        {
            //            dataGridView1.CurrentCell = null;
            //            dataGridView1.Rows[r.Index].Visible = false;
            //        }
            //    }
            //}
            //catch { }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {

                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillBysearch(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()));
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillBysearch(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()));

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByDescR(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Descp.Text);
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByDescR(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Descp.Text);

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByBeneficiary(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), UsFul.Text);
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByBeneficiary(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), UsFul.Text);

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByResponspilityCenter(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Respo.Text);
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByResponspilityCenter(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Respo.Text);

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByResCategory(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), comboBox2.Text);
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByResCategory(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), comboBox2.Text);

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByManagament(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Manag.Text);
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByManagament(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Manag.Text);

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByExCenter(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), exCenter.Text);
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByExCenter(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), exCenter.Text);

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
                ultraTabControl2.Tabs[3].Visible = false;
                ultraTabControl2.Tabs[2].Visible = false;
                ultraTabControl2.Tabs[1].Visible = false;
                try
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByOrderKind(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Order.Text);
                }
                catch { }
                finally
                {
                    this.tbl_AccountingRestrictionItemsTableAdapter.FillByOrderKind(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), Order.Text);

                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void UsFul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && UsFul.Focus() == true)
            {
                try
                {
                    FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                    f.label1.Text = "R";
                    UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }

            }
        }

        private void Descp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Descp.Focus() == true)
            {
                try
                {
                    FindCatregory f = new FindCatregory();
                    f.ShowDialog();
                    Descp.Text = FindCatregory.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void Respo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Respo.Focus() == true)
            {
                try
                {
                    FindRespo f = new FindRespo();
                    f.ShowDialog();
                    Respo.Text = FindRespo.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void Manag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Manag.Focus() == true)
            {
                try
                {
                    FindDepart f = new FindDepart();
                    f.ShowDialog();
                    Manag.Text = FindDepart.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void exCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && exCenter.Focus() == true)
            {
                try
                {
                    FindEx f = new FindEx();
                    f.ShowDialog();
                    exCenter.Text = FindEx.SelectedRow.Cells[1].Value.ToString();

                }
                catch { }
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && comboBox3.Focus() == true)
            {
                try
                {
                    FindAccount f = new FindAccount();
                    f.ShowDialog();
                    comboBox3.Text = FindAccount.SelectedRow.Cells[0].Value.ToString();

                }
                catch { }
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && comboBox2.Focus() == true)
            {
                try
                {
                    FindKind f = new FindKind();
                    f.ShowDialog();


                    comboBox2.Text = FindKind.SelectedRow.Cells[1].Value.ToString();
                }
                catch { }

            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 6);
            if (validationSaveUser != null)
            {
                try
                {
                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    //app.Visible = true;
                    //worksheet = workbook.Sheets["Sheet1"];
                    //worksheet = workbook.ActiveSheet;
                    //worksheet.Name = "Exported from gridview";
                    //for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    //{
                    //    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    //}

                    //// It's the part which we are interested in
                    //// we just need to change dataGridView1.Rows to dataGridView1.SelectedRows
                    //for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    //{
                    //    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    //    {
                    //        worksheet.Cells[i + 2, j + 1] = dataGridView1.SelectedRows[i].Cells[j].Value.ToString();
                    //    }
                    //}

                    //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    //app.Quit();
                    List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn col in dataGridView1.Rows)
                    {
                        if (col.Visible)
                            listVisible.Add(col);
                    }
                    for (int i = 0; i < listVisible.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = listVisible[i].HeaderText;
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < listVisible.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[listVisible[j].Name].Value.ToString();
                        }
                    }
                    workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    app.Quit();
                }
                catch { }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اصدار الاستعلام الى الاكسيل .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int? ComID = int.Parse(comboBox5.SelectedValue.ToString());
                var list = (from usr in FsDb.Tbl_User
                            join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                            join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID

                            where (us.SysUnites_ID == ComID && us.SysUnite_StatusID == 1)
                            select new
                            {
                                ID = usr.ID,
                                Name = usr.Tbl_Employee.Name,
                                //UserType_ID = usr.UserType_ID,
                                //EmployeeName = usr.Tbl_Employee.Name,
                                //Employee_id = usr.Tbl_Employee.ID,
                                //UserSysUnit = us.Tbl_SystemUnites.Name,
                                //UserSysunitID = us.Tbl_SystemUnites.ID,
                                //UserType = usr.Tbl_UserType.Name,
                                //UserImage = usr.ImagePath,
                                //UserFDate = us.From_Date,
                                //UserTDate = us.To_Date,
                                //UserStatus_ID = usr.UserStatus_ID

                            }).ToList();

                comboBox6.DataSource = list;
                comboBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                comboBox6.AutoCompleteSource = AutoCompleteSource.ListItems;

                comboBox6.DisplayMember = "Name";
                comboBox6.ValueMember = "ID";
                if (comboBox6.Items.Count > 0)
                {
                    comboBox6.SelectedIndex = -1;
                }
            }
            catch
            {

            }
        }


        private void simpleButton12_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[1].Visible = true;
            ultraTabControl2.Tabs[0].Visible = false;
            ultraTabControl2.Tabs[2].Visible = false;
            ultraTabControl2.Tabs[3].Visible = false;
            try
            {
                this.allDataAccRestrictionsByUserTableAdapter.Fill(this.financialSysDataSet.allDataAccRestrictionsByUser, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox6.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()));
            }
            catch { }
            finally
            {
                this.allDataAccRestrictionsByUserTableAdapter.Fill(this.financialSysDataSet.allDataAccRestrictionsByUser, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox6.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()));

            }
        }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
}

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[2].Visible = true;
            ultraTabControl2.Tabs[0].Visible = false;
            ultraTabControl2.Tabs[1].Visible = false;
            ultraTabControl2.Tabs[3].Visible = false;
            try
            {
                this.totalAccRestrByUserTableAdapter.Fill(this.financialSysDataSet.TotalAccRestrByUser, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox6.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()));
            }
            catch { }
            finally
            {
                this.totalAccRestrByUserTableAdapter.Fill(this.financialSysDataSet.TotalAccRestrByUser, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox6.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()));
                TCount.Text = dataGridView3.Rows.Count.ToString();

            }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[3].Visible = true;
            ultraTabControl2.Tabs[0].Visible = false;
            ultraTabControl2.Tabs[2].Visible = false;
            ultraTabControl2.Tabs[1].Visible = false;
            try
            {
                this.specificRestriction2DateTableAdapter.Fill(this.financialSysDataSet.SpecificRestriction2Date, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), int.Parse(Fr.Text), int.Parse(To.Text));
            }
            catch { }
            finally
            {
                this.specificRestriction2DateTableAdapter.Fill(this.financialSysDataSet.SpecificRestriction2Date, DateTime.Parse(radDateTimePicker1.Value.ToShortDateString()), DateTime.Parse(radDateTimePicker2.Value.ToShortDateString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), int.Parse(Fr.Text), int.Parse(To.Text));
                textEdit1.Text = dataGridView4.Rows.Count.ToString();

            }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 46 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                ultraTabControl2.Tabs[0].Visible = true;
            ultraTabControl2.Tabs[3].Visible = false;
            ultraTabControl2.Tabs[2].Visible = false;
            ultraTabControl2.Tabs[1].Visible = false;
            try
            {
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), comboBox3.Text);
            }
            catch { }
            finally
            {
                this.tbl_AccountingRestrictionItemsTableAdapter.FillByAccountNumber(this.financialSysDataSet.Tbl_AccountingRestrictionItems, radDateTimePicker1.Value.ToShortDateString(), radDateTimePicker2.Value.ToShortDateString(), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()), comboBox3.Text);

            }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية للاستعلام عن المستندات .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void radDateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radDateTimePicker2.Focus();
            }
        }
    }
}
