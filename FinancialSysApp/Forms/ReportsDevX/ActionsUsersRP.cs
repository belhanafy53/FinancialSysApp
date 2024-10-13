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

namespace FinancialSysApp.Forms.ReportsDevX
{
    public partial class ActionsUsersRP : Form
    {
        Model1 FsDb = new Model1();
        public ActionsUsersRP()
        {
            InitializeComponent();

            comboBox1.Focus();
        }

        private void ActionsUsersRP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'systemUnitesDataSet.Tbl_SystemUnites' table. You can move, or remove it, as needed.
            this.tbl_SystemUnitesTableAdapter.Fill(this.systemUnitesDataSet.Tbl_SystemUnites);
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
            }
            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();
            
            //this.reportViewer1.RefreshReport();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPFrom.Focus();
            }
        }

        private void DTPFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPTo.Focus();
            }
        }

        private void DTPTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (FinancialSysEventsEntities db = new FinancialSysEventsEntities())
            {

                if (comboBox2.SelectedValue == null)
                {
                    GetActionsaUsers_ResultBindingSource.DataSource = db.GetActionsaUsers(DTPFrom.Value, DTPTo.Value, null).ToList();
                    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
                       {
                               new Microsoft.Reporting.WinForms.ReportParameter ("FromDate",DTPFrom.Value.Date.ToShortDateString())  ,
                               new Microsoft.Reporting.WinForms.ReportParameter ("ToDate",DTPTo.Value.Date.ToShortDateString())  
                              
                       };
                    reportViewer1.LocalReport.SetParameters(rParams);

                    reportViewer1.RefreshReport();
                }
                else
                {
                    GetActionsaUsers_ResultBindingSource.DataSource = db.GetActionsaUsers(DTPFrom.Value, DTPTo.Value, int.Parse(comboBox2.SelectedValue.ToString())).ToList();
                    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
                        {
                               new Microsoft.Reporting.WinForms.ReportParameter ("FromDate",DTPFrom.Value.Date.ToShortDateString())  ,
                               new Microsoft.Reporting.WinForms.ReportParameter ("ToDate",DTPTo.Value.Date.ToShortDateString()) ,
                               new Microsoft.Reporting.WinForms.ReportParameter ("UserID",comboBox2.SelectedValue.ToString())
                        };
                    reportViewer1.LocalReport.SetParameters(rParams);

                    reportViewer1.RefreshReport();
                }


            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int? ComID = int.Parse(comboBox1.SelectedValue.ToString());
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

            comboBox2.DataSource = list;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = -1;
            }
        }
    }
}
