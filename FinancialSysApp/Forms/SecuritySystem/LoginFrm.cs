using FinancialSysApp.DataBase.Model;
using FinancialSysApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserRoles;
using System.Data.Entity;

using FinancialSysApp.DataBase.ModelEvents;
using FinancialSysApp.Classes;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp
{

    public partial class LoginFrm : Form
    {

        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public LoginFrm()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //int Vbl_User =    Program.GetUsersAuth(Nametxt.Text, Passwordtxt.Text);


            string Vstr_PassIncr = Security.Encrypt_MD5(Passwordtxt.Text);
            
                var result = FsDb.Tbl_User.FirstOrDefault(x => x.Name == Nametxt.Text && x.Password == Vstr_PassIncr);


            if (textBox1.Text == textBox2.Text)
            {
                if (result != null)
                {

                    if (result.UserStatus_ID == 1)
                    {
                        UserFormsProcedures(result);
                        //&& x.LoginTime != DateTime.Today
                        var listRemoveRange = FsEvDb.SecurityUserActivities.Where(x => x.User_ID == result.ID && x.LogoutTime == null && x.PeriodTime == null).ToList();
                        if (listRemoveRange.Count != 0)
                        {
                            //listRemoveRange.LogoutTime = Convert.ToDateTime(DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss"));
                            //listRemoveRange.LoginTime = Convert.ToDateTime(listRemoveRange.LoginTime);
                            //TimeSpan sub = Convert.ToDateTime(listRemoveRange.LogoutTime).Subtract(Convert.ToDateTime(listRemoveRange.LoginTime));
                            //listRemoveRange.PeriodTime = sub;
                            FsEvDb.SecurityUserActivities.RemoveRange(listRemoveRange);
                            FsEvDb.SaveChanges();
                        }
                        Program.GlbV_UserName = result.Name;
                        int? EmpV = result.Employee_id;
                        Program.GlbV_EmpName = result.Tbl_Employee.Name;
                        int? VMngID = result.Tbl_Employee.Management_ID;
                        var resumltMang = FsDb.Tbl_Management.FirstOrDefault(c => c.Management_ID == VMngID);
                        Program.GlbV_Management = resumltMang.Name;
                        Program.GlbV_job = result.Tbl_Employee.WorkerJob;
                        Program.GlbV_CPassword = Vstr_PassIncr;
                        var resultR = FsDb.Tbl_User_SysUnites.SingleOrDefault(z => z.Emp_ID == EmpV && z.SysUnite_StatusID == 1);
                        Program.GlbV_SysUnite = resultR.Tbl_SystemUnites.Name;
                        Program.GlbV_UserId = result.ID;
                        Program.GlbV_UserTypeId = result.Tbl_UserType.ID;
                        Program.GlbV_UserType = result.Tbl_UserType.Name;
                        Program.GlbV_SysUnite_ID = resultR.SysUnites_ID;
                        DateTime td = Convert.ToDateTime(Convert.ToDateTime(GetServerDate.Cs_GetServerDate()).ToString("yyyy/MM/dd HH:mm:ss tt"));
                        //DateTime td = Convert.ToDateTime(Convert.ToDateTime(GetServerDate.Cs_GetServerDate()).ToString());
                        Program.GlbV_DateTime = td.ToString();
                        SecurityUserActivity SEvent = new SecurityUserActivity
                        {
                            EmployeeName = result.Tbl_Employee.Name,
                            UserName = result.Name,
                            ManagementName = resumltMang.Name,
                            User_systemUnitesName = resultR.Tbl_SystemUnites.Name,
                            User_ID = result.ID,
                            LoginTime = Convert.ToDateTime(Convert.ToDateTime(td))
                        };
                        FsEvDb.SecurityUserActivities.Add(SEvent);
                        FsEvDb.SaveChanges();
                        long Vl_ID = SEvent.Id;
                        if (result.ID > 0)
                        {

                            //Program.GlbV_UserName = 
                            this.Close();
                            Thread th = new Thread(openform);
                            th.SetApartmentState(ApartmentState.STA);
                            th.Start();
                            //MessageBox.Show(result.Count().ToString());


                        }
                    }
                    else
                    {
                        MessageBox.Show("هدا المستخدم غير مفعل برجاء مراجعة مدير المنظومه");
                    }
                }

                else
                {
                    MessageBox.Show("اسم المستخدم او كلمة المرور خطأ");
                }
            }
            else
            {
                MessageBox.Show("من فضلك اضبط تاريخ جهازك اولا ");
            }
        }

        private void UserFormsProcedures(Tbl_User result)
        {
            //صفحات المستخدم
            Program.SecurityFormsList = FsDb.Tbl_UsersProcedureForm.Include(t => t.Tbl_ProceduresForms).Where(x => x.User_ID == result.ID).Select(x => x.Tbl_ProceduresForms.Form_ID).Distinct().ToList();

            //إجراءات صفحات المستخدم 
            var proceduresForms = FsDb.Tbl_UsersProcedureForm.Include(t => t.Tbl_ProceduresForms).Where(x => x.User_ID == result.ID).Select(x => x.Tbl_ProceduresForms).ToList();
            foreach (var proceduresForm in proceduresForms)
            {
                Program.SecurityProceduresList.Add(new Classes.FormProcedures() { FormId = proceduresForm.Form_ID, ProcdureId = proceduresForm.Procedure_ID });
            }

        }

        void openform()
        {
           
                Application.Run(new MainForm());
           
        }

        
       
        private void LoginFrm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToDateTime(GetServerDate.Cs_GetServerDate()).ToString("yyyy/MM/dd");
            textBox2.Text = Convert.ToDateTime(DateTime.Now).ToString("yyyy/MM/dd");
            //label3.Text = DateTime.UtcNow.ToShortDateString();
            Nametxt.Focus();
            // This code will return time from database server
             

        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Passwordtxt.Focus();
            }
        }

        private void Passwordtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
