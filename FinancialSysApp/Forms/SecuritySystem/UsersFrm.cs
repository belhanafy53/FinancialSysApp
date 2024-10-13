using DevExpress.XtraPrinting;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserRoles;
                                                                              
namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class UsersFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int xidu;
        int Vint_TransfeerUser = 0;
        string Image_Path = "";
        string Vstr_PassIncr;
        int Vint_UserStatus = 0;
        int Vint_LastRow = 0;
        public UsersFrm()
        {
            InitializeComponent();
            string Current_Path = Environment.CurrentDirectory;
            NameEmptxt.Focus();
        }

        private void PicturePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PicturePath.ImageLocation = dialog.FileName;
                Image_Path = dialog.FileName;
            }
        }

        private void UsersFrm_Load(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24);
            if (Program.GlbV_UserTypeId == 1)
            {
                var listUnites = FsDb.Tbl_SystemUnites.ToList();
                comboBox1.DataSource = listUnites;
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;


                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = -1;
                }
                comboBox1.SelectedValue = -1;
            }
            else if (validationSaveUser != null && Program.GlbV_UserTypeId == 2)
            {
                var listUnites = FsDb.Tbl_SystemUnites.Where(x => x.ID == Program.GlbV_SysUnite_ID).ToList();
                comboBox1.DataSource = listUnites;
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;


                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
            }

            comboBox2.DataSource = FsDb.Tbl_UserType.OrderBy(x=>x.SortRow).ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = -1;
            }
            comboBox2.SelectedValue = -1;

            comboBox3.DataSource = FsDb.Tbl_UserStatus.ToList();
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = -1;
            }
            comboBox3.SelectedValue = -1;

            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            // dataGridView1.DataSource = FsDb.Tbl_User.ToList();
            dataGridView2.DataSource = FsDb.Tbl_Employee.Take(30).OrderBy(x => x.Name).ToList();
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["Name"].HeaderText = "الاسم";
            dataGridView2.Columns["NationalID"].HeaderText = "الرقم القومي";
            dataGridView2.Columns["Management_ID"].Visible = false;
            dataGridView2.Columns["WorkerJob"].HeaderText = "الوظيفة";

            dataGridView2.Columns["GenderID"].Visible = false;
            dataGridView2.Columns["Tbl_Beneficiary"].Visible = false;
            dataGridView2.Columns["Tbl_User"].Visible = false;
            //dataGridView2.Columns["Tbl_OrderHandler"].Visible = false;
            dataGridView2.Columns["Name"].Width = 250;
            dataGridView2.Columns["NationalID"].Width = 100;
            dataGridView2.Columns["Tbl_User_SysUnites"].Visible = false;

            var validationSaveUserl = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24);
            if (Program.GlbV_UserTypeId == 1)
            {

                var list = (from usr in FsDb.Tbl_User
                            join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                            join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                            where (us.SysUnite_StatusID == 1)

                            select new
                            {
                                ID = usr.ID,
                                Name = usr.Name,
                                UserType_ID = usr.UserType_ID,
                                EmployeeName = usr.Tbl_Employee.Name,
                                Employee_id = usr.Tbl_Employee.ID,
                                UserSysUnit = us.Tbl_SystemUnites.Name,
                                UserSysunitID = us.Tbl_SystemUnites.ID,
                                UserType = usr.Tbl_UserType.Name,
                                UserImage = usr.ImagePath,
                                UserFDate = us.From_Date,
                                UserTDate = us.To_Date,
                                UserStatus_ID = usr.UserStatus_ID


                            }).Take(30).OrderBy(x => x.UserType).ToList();
                dataGridView3.DataSource = list;


                dataGridView3.Columns["ID"].Visible = false;
                dataGridView3.Columns["Name"].Visible = false;
                dataGridView3.Columns["Name"].HeaderText = "الاسم";
                dataGridView3.Columns["EmployeeName"].HeaderText = "اسم الموظف";
                dataGridView3.Columns["EmployeeName"].Width = 200;
                dataGridView3.Columns["UserSysUnit"].HeaderText = "الوحدة";
                dataGridView3.Columns["UserSysUnit"].Width = 150;
                dataGridView3.Columns["UserType"].HeaderText = "نوع المستخدم";
                dataGridView3.Columns["UserType"].Width = 100;

                dataGridView3.Columns["UserSysunitID"].Visible = false;
                dataGridView3.Columns["Employee_id"].Visible = false;
                dataGridView3.Columns["UserType_ID"].Visible = false;
                //dataGridView3.Columns["Tbl_Employee.Name"].Visible = false;
            }

            else if (validationSaveUserl != null && Program.GlbV_UserTypeId == 2)
            {
                var list = (from usr in FsDb.Tbl_User
                            join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                            join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                            where (us.SysUnite_StatusID == 1 && us.SysUnites_ID == Program.GlbV_SysUnite_ID)

                            select new
                            {
                                ID = usr.ID,
                                Name = usr.Name,
                                UserType_ID = usr.UserType_ID,
                                EmployeeName = usr.Tbl_Employee.Name,
                                Employee_id = usr.Tbl_Employee.ID,
                                UserSysUnit = us.Tbl_SystemUnites.Name,
                                UserSysunitID = us.Tbl_SystemUnites.ID,
                                UserType = usr.Tbl_UserType.Name,
                                UserImage = usr.ImagePath,
                                UserFDate = us.From_Date,
                                UserTDate = us.To_Date,
                                UserStatus_ID = usr.UserStatus_ID


                            }).Take(30).OrderBy(x => x.UserType).ToList();
                dataGridView3.DataSource = list;


                dataGridView3.Columns["ID"].Visible = false;
                dataGridView3.Columns["Name"].Visible = false;
                dataGridView3.Columns["Name"].HeaderText = "الاسم";
                dataGridView3.Columns["EmployeeName"].HeaderText = "اسم الموظف";
                dataGridView3.Columns["EmployeeName"].Width = 200;
                dataGridView3.Columns["UserSysUnit"].HeaderText = "الوحدة";
                dataGridView3.Columns["UserSysUnit"].Width = 150;
                dataGridView3.Columns["UserType"].HeaderText = "نوع المستخدم";
                dataGridView3.Columns["UserType"].Width = 100;

                dataGridView3.Columns["UserSysunitID"].Visible = false;
                dataGridView3.Columns["Employee_id"].Visible = false;
                dataGridView3.Columns["UserType_ID"].Visible = false;
            }
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);
            dateTimePicker2.Value = DateTime.Today.AddYears(10);


            NameEmptxt.Select();
            this.ActiveControl = NameEmptxt;
            NameEmptxt.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                dataGridView1.DataSource = FsDb.Tbl_User.Where(y => y.Name.Contains(textBox1.Text)).OrderBy(x => x.Name).ToList();
            }
            else
            {
                dataGridView1.DataSource = FsDb.Tbl_User.ToList();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Focused)
            {
                xidu = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = FsDb.Tbl_User.SingleOrDefault(x => x.ID == xidu);
                int xidun = int.Parse(result.ID.ToString());
                if (xidun > 1)
                {
                    Nametxt.Text = "";
                    NameEmptxt.Text = "";
                    Passwordtxt.Text = "";
                    ConfirmPasswordtxt.Text = "";
                    if (result != null)
                    {
                        Nametxt.Text = result.Name.ToString();
                        PicturePath.ImageLocation = result.ImagePath.ToString();
                        int xEMP = int.Parse(result.Employee_id.ToString());
                        var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(y => y.ID == xEMP);
                        if (resultEmp != null)
                        {
                            NameEmptxt.Text = resultEmp.Name.ToString();
                        }
                    }

                   
                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
                ConfirmPasswordtxt.Focus();
            }
        }

        private void ConfirmPasswordtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
            }
        }

        private void NameEmptxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView2.Focus();
            }
        }

        private void NameEmptxt_TextChanged(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24);
            if (Program.GlbV_UserTypeId == 1)
            {
                if ((NameEmptxt.Text).Length > 2)
                {

                    dataGridView2.DataSource = FsDb.Tbl_Employee.Where(y => y.Name.Contains(NameEmptxt.Text)).ToList();
                    var list = (from usr in FsDb.Tbl_User
                                join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                                join us1 in FsDb.Tbl_User_SysUnites on usr.ID equals us1.User_ID
                                join sysu in FsDb.Tbl_SystemUnites on us.SysUnites_ID equals sysu.ID
                                where (emp.Name.Contains(NameEmptxt.Text) && us.SysUnite_StatusID == 1)

                                select new
                                {
                                    ID = usr.ID,
                                    Name = usr.Name,
                                    UserType_ID = usr.UserType_ID,
                                    EmployeeName = emp.Name,
                                    Employee_id = emp.ID,
                                    UserSysUnit = sysu.Name,
                                    UserSysunitID = sysu.ID,
                                    UserType = usr.Tbl_UserType.Name,
                                    UserImage = usr.ImagePath,
                                    UserFDate = us.From_Date,
                                    UserTDate = us.To_Date,
                                    UserStatus_ID = usr.UserStatus_ID

                                }).OrderBy(x => x.Name).ToList();
                    dataGridView3.DataSource = list;
                }
                else if ((NameEmptxt.Text).Length < 2)
                {
                    dataGridView2.DataSource = FsDb.Tbl_Employee.ToList();
                    var list = (from usr in FsDb.Tbl_User
                                join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                                where (us.SysUnite_StatusID == 1)

                                select new
                                {
                                    ID = usr.ID,
                                    Name = usr.Name,
                                    UserType_ID = usr.UserType_ID,
                                    EmployeeName = usr.Tbl_Employee.Name,
                                    Employee_id = usr.Tbl_Employee.ID,
                                    UserSysUnit = us.Tbl_SystemUnites.Name,
                                    UserSysunitID = us.Tbl_SystemUnites.ID,
                                    UserType = usr.Tbl_UserType.Name,
                                    UserImage = usr.ImagePath,
                                    UserFDate = us.From_Date,
                                    UserTDate = us.To_Date,
                                    UserStatus_ID = usr.UserStatus_ID
                                }).OrderBy(x => x.Name).ToList();
                    dataGridView3.DataSource = list;
                }
            }
            else if (validationSaveUser != null && Program.GlbV_UserTypeId == 2)
            {
                if (NameEmptxt.Text != "")
                {

                    dataGridView2.DataSource = FsDb.Tbl_Employee.Where(y => y.Name.Contains(NameEmptxt.Text)).ToList();
                    var list = (from usr in FsDb.Tbl_User
                                join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                                where (emp.Name.Contains(NameEmptxt.Text) && us.SysUnite_StatusID == 1 && us.SysUnites_ID == Program.GlbV_SysUnite_ID)

                                select new
                                {
                                    ID = usr.ID,
                                    Name = usr.Name,
                                    UserType_ID = usr.UserType_ID,
                                    EmployeeName = usr.Tbl_Employee.Name,
                                    Employee_id = usr.Tbl_Employee.ID,
                                    UserSysUnit = us.Tbl_SystemUnites.Name,
                                    UserSysunitID = us.Tbl_SystemUnites.ID,
                                    UserType = usr.Tbl_UserType.Name,
                                    UserImage = usr.ImagePath,
                                    UserFDate = us.From_Date,
                                    UserTDate = us.To_Date,
                                    UserStatus_ID = usr.UserStatus_ID

                                }).OrderBy(x => x.Name).ToList();
                    dataGridView3.DataSource = list;
                }
                else
                {
                    dataGridView2.DataSource = FsDb.Tbl_Employee.ToList();
                    var list = (from usr in FsDb.Tbl_User
                                join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                                where (us.SysUnite_StatusID == 1 && us.SysUnites_ID == Program.GlbV_SysUnite_ID)

                                select new
                                {
                                    ID = usr.ID,
                                    Name = usr.Name,
                                    UserType_ID = usr.UserType_ID,
                                    EmployeeName = usr.Tbl_Employee.Name,
                                    Employee_id = usr.Tbl_Employee.ID,
                                    UserSysUnit = us.Tbl_SystemUnites.Name,
                                    UserSysunitID = us.Tbl_SystemUnites.ID,
                                    UserType = usr.Tbl_UserType.Name,
                                    UserImage = usr.ImagePath,
                                    UserFDate = us.From_Date,
                                    UserTDate = us.To_Date,
                                    UserStatus_ID = usr.UserStatus_ID
                                }).OrderBy(x => x.Name).ToList();
                    dataGridView3.DataSource = list;
                }
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (Program.GlbV_UserTypeId == 1)
                {
                    int xidemp = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    var resultUserSys = FsDb.Tbl_User_SysUnites.SingleOrDefault(d => d.Tbl_Employee.ID == xidemp && d.SysUnite_StatusID == 1);
                    var resultuser = FsDb.Tbl_User.SingleOrDefault(u => u.Employee_id == xidemp);
                    if (resultuser != null)
                    {
                        xidu = resultuser.ID;
                        DialogResult resultmsg = MessageBox.Show("  هل تم نقل هدا الموظف ؟ ", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultmsg == DialogResult.Yes)
                        {
                            Vint_TransfeerUser = 1;
                            if (resultuser != null)
                            {
                                NameEmptxt.Text = resultuser.Tbl_Employee.Name.ToString();
                                Nametxt.Text = resultuser.Name.ToString();
                                textBox1.Text = resultuser.Employee_id.ToString();
                                PicturePath.ImageLocation = resultuser.ImagePath;
                                comboBox2.SelectedValue = resultuser.Tbl_UserType.ID;
                                dateTimePicker1.MinDate = DateTime.Today;
                                Vint_UserStatus = int.Parse(resultuser.UserStatus_ID.ToString());
                                comboBox3.SelectedValue = Vint_UserStatus;
                            }
                                Passwordtxt.Select();
                            this.ActiveControl = Passwordtxt;
                            Passwordtxt.Focus();
                        }
                        else
                        {
                            Vint_TransfeerUser = 0;
                            if (resultuser != null)
                            {
                                NameEmptxt.Text = resultuser.Tbl_Employee.Name.ToString();
                                Nametxt.Text = resultuser.Name.ToString();
                                textBox2.Text = resultuser.ID.ToString();
                                textBox1.Text = resultuser.Employee_id.ToString();
                                PicturePath.ImageLocation = resultuser.ImagePath;
                                comboBox1.SelectedValue = resultUserSys.SysUnites_ID;
                                comboBox2.SelectedValue = resultuser.Tbl_UserType.ID;
                                dateTimePicker1.MinDate = resultUserSys.From_Date.Value;
                                dateTimePicker2.MinDate = resultUserSys.To_Date.Value;
                                Vint_UserStatus = int.Parse(resultuser.UserStatus_ID.ToString());
                                comboBox3.SelectedValue = Vint_UserStatus;
                            }
                            Passwordtxt.Select();
                            this.ActiveControl = Passwordtxt;
                            Passwordtxt.Focus();
                            UsrTxtBox.Text = "";
                            PicturePath.Image = FinancialSysApp.Properties.Resources.download__2_;
                        }
                    }
                    else
                    {
                        if (xidemp > 1)
                        {
                            var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(d => d.ID == xidemp);
                            if (resultEmp != null)
                            {
                                NameEmptxt.Text = resultEmp.Name.ToString();
                                Nametxt.Text = resultEmp.NationalId.Substring(7).ToString();
                                textBox1.Text = resultEmp.ID.ToString();
                                Passwordtxt.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            if (Nametxt.Text == "" || NameEmptxt.Text == "")
            {
                MessageBox.Show("من فضلك اكمل البيانات المطلوبه");
            }
            else
            {
                if (Passwordtxt.Text != ConfirmPasswordtxt.Text)
                {
                    MessageBox.Show("كلمة المرور غير متطابقه");
                    Passwordtxt.Focus();
                }
                else if (comboBox3.SelectedItem == "")
                {
                    MessageBox.Show("حدد حالة المستخدم فعال / غير فعال");
                    comboBox3.Focus();
                }
                else
                {

                    int xempid = int.Parse(textBox1.Text.ToString());
                    Vint_UserStatus = 0;


                    Vstr_PassIncr = Security.Encrypt_MD5(Passwordtxt.Text);


                    Tbl_User u = new Tbl_User
                    {

                        Name = Nametxt.Text,
                        Password = Vstr_PassIncr,
                        ImagePath = Image_Path,
                        Employee_id = xempid,
                        UserType_ID = int.Parse(comboBox2.SelectedValue.ToString()),
                        UserStatus_ID = int.Parse(comboBox3.SelectedValue.ToString())


                    };

                    Tbl_User_SysUnites UsrSysU = new Tbl_User_SysUnites
                    {
                        SysUnites_ID = int.Parse(comboBox1.SelectedValue.ToString()),
                        Emp_ID = xempid,
                        From_Date = dateTimePicker1.Value.Date,
                        To_Date = dateTimePicker2.Value.Date,
                        // *********************- الوحده الحالية والفعاله للمستخدم
                        SysUnite_StatusID = 1,
                        User_ID = Vint_LastRow  

                };

                    int vint_empId = int.Parse(textBox1.Text);

                    if (textBox2.Text == "" && Vint_TransfeerUser == 1)
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24 && w.ProcdureId == 1);
                        if (validationSaveUser != null)
                        {
                            var resultSysUserOld = FsDb.Tbl_User_SysUnites.SingleOrDefault(h => h.Emp_ID == vint_empId && h.SysUnite_StatusID == 1);
                            if (resultSysUserOld != null)
                            {
                                DateTime dt = DateTime.Now.AddDays(-1);

                                DateTime newdt = new DateTime(dt.Year, dt.Month, dt.Day);
                                resultSysUserOld.To_Date = Convert.ToDateTime(newdt);
                                //**********************************الوحده غير الفعاله للمستخدم
                                resultSysUserOld.SysUnite_StatusID = 0;
                            }
                            FsDb.Tbl_User_SysUnites.Add(UsrSysU);
                            FsDb.SaveChanges();
                            var listuser = FsDb.Tbl_User.SingleOrDefault(x => x.Employee_id == vint_empId);
                            int vint_userid = listuser.ID;
                            var resultSysUsernew = FsDb.Tbl_User_SysUnites.SingleOrDefault(h => h.Emp_ID == vint_empId && h.SysUnite_StatusID == 1);
                            resultSysUsernew.User_ID = vint_userid;

                            //*****************حذف كل الصلاحيات القديمه للمستخدم
                            FsDb.Tbl_UserAuthForms.RemoveRange(FsDb.Tbl_UserAuthForms.Where(h => h.User_ID == vint_userid));
                            FsDb.Tbl_UsersProcedureForm.RemoveRange(FsDb.Tbl_UsersProcedureForm.Where(h => h.User_ID == vint_userid));
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            int Vint_LastRow = int.Parse(UsrSysU.ID.ToString());
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة المستخدم على وحدة منظومة",
                                TableName = "Tbl_User_SysUnites",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "UsersFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //************************************
                            MessageBox.Show("تم الحفظ ");
                            Nametxt.Text = "";
                            Passwordtxt.Text = "";
                            ConfirmPasswordtxt.Text = "";
                            textBox2.Text = "";
                            NameEmptxt.Text = "";
                            UsrTxtBox.Text = "";
                            comboBox1.SelectedValue = -1;
                            comboBox2.SelectedValue = -1;
                            comboBox3.SelectedValue = -1;
                            dateTimePicker1.Value = DateTime.Today;
                            dateTimePicker2.Value = DateTime.Today.AddYears(10);
                            UsrTxtBox.Text = "";
                            NameEmptxt.Select();
                            this.ActiveControl = NameEmptxt;
                            NameEmptxt.Focus();
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية اضافة  مستخدم لوحدة .. برجاء مراجعة مدير المنظومه");
                        }
                    }
                    else if (textBox2.Text == "" && Vint_TransfeerUser == 0)
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24 && w.ProcdureId == 1);
                        if (validationSaveUser != null)
                        {
                            FsDb.Tbl_User.Add(u);
                            FsDb.SaveChanges();
                            Vint_LastRow = int.Parse(u.ID.ToString());
                            Tbl_User_SysUnites UsrSysUi = new Tbl_User_SysUnites
                            {
                                SysUnites_ID = int.Parse(comboBox1.SelectedValue.ToString()),
                                Emp_ID = xempid,
                                From_Date = dateTimePicker1.Value.Date,
                                To_Date = dateTimePicker2.Value.Date,
                                // *********************- الوحده الحالية والفعاله للمستخدم
                                SysUnite_StatusID = 1,
                                User_ID = Vint_LastRow

                            };
                            FsDb.Tbl_User_SysUnites.Add(UsrSysUi);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                           
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة مستخدم ",
                                TableName = "Tbl_User",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "UsersFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();

                            MessageBox.Show("تم الحفظ ");
                            Nametxt.Text = "";
                            Passwordtxt.Text = "";
                            ConfirmPasswordtxt.Text = "";
                            textBox2.Text = "";
                            NameEmptxt.Text = "";
                            UsrTxtBox.Text = "";
                            comboBox1.SelectedValue = -1;
                            comboBox2.SelectedValue = -1;
                            comboBox3.SelectedValue = -1;
                            dateTimePicker1.Value = DateTime.Today;
                            dateTimePicker2.Value = DateTime.Today.AddYears(10);
                            UsrTxtBox.Text = "";
                            NameEmptxt.Select();
                            this.ActiveControl = NameEmptxt;
                            NameEmptxt.Focus();
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية اضافة  مستخدم  .. برجاء مراجعة مدير المنظومه");
                        }
                    }
                    else if (textBox2.Text != "" && Vint_TransfeerUser == 0)
                    {
                        var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24 && w.ProcdureId == 3);
                        if (validationSaveUser != null)
                        {
                            Vint_UserStatus = int.Parse(comboBox3.SelectedValue.ToString());

                            Vstr_PassIncr = Security.Encrypt_MD5(Passwordtxt.Text);
                            int XuserID = int.Parse(textBox2.Text);
                            int XEMPID = int.Parse(textBox1.Text);
                            //*********************Tbl_User
                            var result = FsDb.Tbl_User.SingleOrDefault(h => h.ID == XuserID);
                            u.ID = result.ID;
                            result.Name = Nametxt.Text;
                            //result.Password = Vstr_PassIncr;
                            result.UserType_ID = int.Parse(comboBox2.SelectedValue.ToString());
                            result.ImagePath = Environment.CurrentDirectory + "\\Images\\" + u.ID + ".jpg";
                            result.UserStatus_ID = Vint_UserStatus;

                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRowS = int.Parse(UsrSysU.ID.ToString());
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "تعديل  بيانات  مستخدم",
                                TableName = "Tbl_User",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "UsersFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //************************************

                            //**********************Tbl_User_SysUnites
                            var resultSysUser = FsDb.Tbl_User_SysUnites.SingleOrDefault(h => h.Emp_ID == XEMPID && h.SysUnite_StatusID == 1);
                            resultSysUser.Emp_ID = XEMPID;
                            resultSysUser.User_ID = u.ID;

                            resultSysUser.SysUnites_ID = int.Parse(comboBox1.SelectedValue.ToString());


                            resultSysUser.From_Date = dateTimePicker1.Value.Date;
                            resultSysUser.To_Date = dateTimePicker2.Value.Date;
                            resultSysUser.SysUnite_StatusID = 1;
                            FsDb.SaveChanges();



                            MessageBox.Show("تم التعديل ");
                            Nametxt.Text = "";
                            Passwordtxt.Text = "";
                            ConfirmPasswordtxt.Text = "";
                            textBox2.Text = "";
                            NameEmptxt.Text = "";
                            UsrTxtBox.Text = "";
                            comboBox1.SelectedValue = -1;
                            comboBox2.SelectedValue = -1;
                            comboBox3.SelectedValue = -1;
                            PicturePath.Image = FinancialSysApp.Properties.Resources.download__2_;
                            dateTimePicker1.Value = DateTime.Today;
                            dateTimePicker2.Value = DateTime.Today.AddYears(10);
                            NameEmptxt.Select();
                            this.ActiveControl = NameEmptxt;
                            NameEmptxt.Focus();
                        }
                        else
                        {
                            MessageBox.Show("ليس لديك صلاحية تعديل بيانات مستخدم  .. برجاء مراجعة مدير المنظومه");
                        }
                    }
                    dataGridView1.DataSource = FsDb.Tbl_User.ToList();
                    if (Image_Path != "")
                    {

                        //Image_Path = Environment.CurrentDirectory + "\\Images\\" + u.ID + ".jpg";
                        string NewPath = Environment.CurrentDirectory + "\\Images\\" + u.ID + ".jpg";

                        File.Copy(Image_Path, NewPath, true);
                        NewPath = Image_Path;
                        dataGridView1.DataSource = FsDb.Tbl_User.ToList();
                        Nametxt.Text = "";
                        Passwordtxt.Text = "";
                        NameEmptxt.Text = "";
                        ConfirmPasswordtxt.Text = "";
                        PicturePath.Image = FinancialSysApp.Properties.Resources.download__2_;
                        NameEmptxt.Select();
                        this.ActiveControl = NameEmptxt;
                        NameEmptxt.Focus();


                    }

                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24 && w.ProcdureId == 4);
                if (validationSaveUser != null)
                {
                    if (xidu > 0)

                    {
                        var result1 = MessageBox.Show("هل تريد حدف هدا المستخدم  ؟", "حدف  مستخدم ", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            var result = FsDb.Tbl_User.Find(xidu);
                            int VIntemp = int.Parse(result.Employee_id.ToString());
                            var resultuserSys = FsDb.Tbl_User_SysUnites.FirstOrDefault(x => x.Emp_ID == VIntemp && x.SysUnite_StatusID == 1);

                            FsDb.Tbl_User_SysUnites.Remove(resultuserSys);

                            FsDb.Tbl_User.Remove(result);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            //int Vint_LastRowS = int.Parse(UsrSysU.ID.ToString());
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "حذف  بيانات  مستخدم",
                                TableName = "Tbl_User",
                                TableRecordId = result.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "UsersFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //************************************
                            //************************************
                            //---------------خفظ ااحداث 
                            //int Vint_LastRowS = int.Parse(UsrSysU.ID.ToString());
                            SecurityEvent sevS = new SecurityEvent
                            {
                                ActionName = "حذف  مستخدم من على وحدة منظومة  ",
                                TableName = "Tbl_User_SysUnites",
                                TableRecordId = resultuserSys.ID.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "UsersFrm"


                            };
                            FsEvDb.SecurityEvents.Add(sevS);
                            FsEvDb.SaveChanges();
                            //************************************
                            MessageBox.Show("تم الحذف ");
                            dataGridView1.DataSource = FsDb.Tbl_User.ToList();
                            Nametxt.Text = "";
                            Passwordtxt.Text = "";
                            ConfirmPasswordtxt.Text = "";
                            NameEmptxt.Text = "";
                            textBox2.Text = "";
                            UsrTxtBox.Text = "";
                            comboBox1.SelectedValue = -1;
                            comboBox2.SelectedValue = -1;
                            PicturePath.Image = FinancialSysApp.Properties.Resources.download__2_;
                            NameEmptxt.Select();
                            this.ActiveControl = NameEmptxt;
                            NameEmptxt.Focus();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("ليس لديك صلاحية حذف بيانات مستخدم  .. برجاء مراجعة مدير المنظومه");
                }
            }
            catch


            {
                MessageBox.Show("هذا المستخدم لايمكن حذفه لوجود صلاحيات له", "المنظومة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int? ComID = int.Parse(comboBox1.SelectedValue.ToString());
                var list = (from usr in FsDb.Tbl_User
                            join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                            join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                            where (us.SysUnites_ID == ComID && us.SysUnite_StatusID == 1)

                            select new
                            {
                                ID = usr.ID,
                                Name = usr.Name,
                                UserType_ID = usr.UserType_ID,
                                EmployeeName = usr.Tbl_Employee.Name,
                                Employee_id = usr.Tbl_Employee.ID,
                                UserSysUnit = us.Tbl_SystemUnites.Name,
                                UserSysunitID = us.Tbl_SystemUnites.ID,
                                UserType = usr.Tbl_UserType.Name,
                                UserImage = usr.ImagePath,
                                UserFDate = us.From_Date,
                                UserTDate = us.To_Date,
                                UserStatus_ID = usr.UserStatus_ID
                            }).ToList();
                dataGridView3.DataSource = list;
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void UsrTxtBox_TextChanged(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 24);
            if (Program.GlbV_UserTypeId == 1)
            {
                if (UsrTxtBox.Text != "")
                {

                    var list = (from usr in FsDb.Tbl_User
                                join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                                where (emp.Name.Contains(UsrTxtBox.Text) && us.SysUnite_StatusID == 1)
                                select new
                                {
                                    ID = usr.ID,
                                    Name = usr.Name,
                                    UserType_ID = usr.UserType_ID,
                                    EmployeeName = usr.Tbl_Employee.Name,
                                    Employee_id = usr.Tbl_Employee.ID,
                                    UserSysUnit = us.Tbl_SystemUnites.Name,
                                    UserSysunitID = us.Tbl_SystemUnites.ID,
                                    UserType = usr.Tbl_UserType.Name,
                                    UserImage = usr.ImagePath,
                                    UserFDate = us.From_Date,
                                    UserTDate = us.To_Date,
                                    UserStatus_ID = usr.UserStatus_ID

                                }).ToList();
                    dataGridView3.DataSource = list;
                }
                else
                {
                    var list = (from usr in FsDb.Tbl_User
                                join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                                where (us.SysUnite_StatusID == 1)

                                select new
                                {
                                    ID = usr.ID,
                                    Name = usr.Name,
                                    UserType_ID = usr.UserType_ID,
                                    EmployeeName = usr.Tbl_Employee.Name,
                                    Employee_id = usr.Tbl_Employee.ID,
                                    UserSysUnit = us.Tbl_SystemUnites.Name,
                                    UserSysunitID = us.Tbl_SystemUnites.ID,
                                    UserType = usr.Tbl_UserType.Name,
                                    UserImage = usr.ImagePath,
                                    UserFDate = us.From_Date,
                                    UserTDate = us.To_Date,
                                    UserStatus_ID = usr.UserStatus_ID


                                }).Take(30).OrderBy(t => t.UserSysUnit).ToList();
                    dataGridView3.DataSource = list;
                }
            }
            else if (validationSaveUser != null && Program.GlbV_UserTypeId == 2)
            {
                if (UsrTxtBox.Text != "")
                {

                    var list = (from usr in FsDb.Tbl_User
                                join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID
                                where (emp.Name.Contains(UsrTxtBox.Text) && us.SysUnite_StatusID == 1 && us.SysUnites_ID == Program.GlbV_SysUnite_ID)
                                select new
                                {
                                    ID = usr.ID,
                                    Name = usr.Name,
                                    UserType_ID = usr.UserType_ID,
                                    EmployeeName = usr.Tbl_Employee.Name,
                                    Employee_id = usr.Tbl_Employee.ID,
                                    UserSysUnit = us.Tbl_SystemUnites.Name,
                                    UserSysunitID = us.Tbl_SystemUnites.ID,
                                    UserType = usr.Tbl_UserType.Name,
                                    UserImage = usr.ImagePath,
                                    UserFDate = us.From_Date,
                                    UserTDate = us.To_Date,
                                    UserStatus_ID = usr.UserStatus_ID

                                }).ToList();
                    dataGridView3.DataSource = list;
                }
            }
        }

        private void dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                {
                    if (Program.GlbV_UserTypeId == 1)
                    {
                        DialogResult resultmsg = MessageBox.Show("  هل تم نقل هدا الموظف ؟ ", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultmsg == DialogResult.Yes)
                        {
                            Vint_TransfeerUser = 1;
                            xidu = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());

                            Nametxt.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                            NameEmptxt.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                            textBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                            comboBox1.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString());
                            comboBox2.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                            Vint_UserStatus = int.Parse(dataGridView3.CurrentRow.Cells[11].Value.ToString());
                            comboBox3.SelectedValue = Vint_UserStatus;
                            comboBox3.SelectedItem = "";
                            if (Vint_UserStatus == 1)
                            {
                                comboBox3.SelectedText = "مفعل";
                            }
                            else
                            {
                                comboBox3.SelectedText = " غير مفعل";
                            }
                            PicturePath.ImageLocation = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                            dateTimePicker1.Value = DateTime.Today.AddDays(0);
                            dateTimePicker2.Value = DateTime.Today.AddYears(10);
                            Passwordtxt.Select();
                            this.ActiveControl = Passwordtxt;
                            Passwordtxt.Focus();
                        }
                        else
                        {
                            Vint_TransfeerUser = 0;
                            xidu = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                            textBox2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                            Nametxt.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                            NameEmptxt.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                            textBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                            comboBox1.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString());
                            comboBox2.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                            Vint_UserStatus = int.Parse(dataGridView3.CurrentRow.Cells[11].Value.ToString());
                            comboBox3.SelectedItem = "";
                            if (Vint_UserStatus == 1)
                            {
                                comboBox3.SelectedText = "مفعل";
                            }
                            else
                            {
                                comboBox3.SelectedText = " غير مفعل";
                            }
                            PicturePath.ImageLocation = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                            dateTimePicker1.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[9].Value.ToString());
                            dateTimePicker2.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[10].Value.ToString());
                            Passwordtxt.Select();
                            this.ActiveControl = Passwordtxt;
                            Passwordtxt.Focus();
                        }
                    }
                    else if (Program.GlbV_UserTypeId != 1)
                    {
                        Vint_TransfeerUser = 0;
                        xidu = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                        textBox2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                        Nametxt.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                        NameEmptxt.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                        textBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                        comboBox1.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString());
                        comboBox2.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                        Vint_UserStatus = int.Parse(dataGridView3.CurrentRow.Cells[11].Value.ToString());
                        comboBox3.SelectedItem = "";
                        if (Vint_UserStatus == 1)
                        {
                            comboBox3.SelectedText = "مفعل";
                        }
                        else
                        {
                            comboBox3.SelectedText = " غير مفعل";
                        }
                        PicturePath.ImageLocation = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                        dateTimePicker1.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[9].Value.ToString());
                        dateTimePicker2.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[10].Value.ToString());
                        Passwordtxt.Select();
                        this.ActiveControl = Passwordtxt;
                        Passwordtxt.Focus();
                    }
                }
            }
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (Program.GlbV_UserTypeId == 1)
            {
                Passwordtxt.Enabled = false;
                ConfirmPasswordtxt.Enabled = false;

                DialogResult resultmsg = MessageBox.Show("  هل تم نقل هدا الموظف ؟ ", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultmsg == DialogResult.Yes)
                {
                    Vint_TransfeerUser = 1;
                    xidu = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    Nametxt.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                    NameEmptxt.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                    textBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                    comboBox1.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString());
                    comboBox2.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());

                    Vint_UserStatus = int.Parse(dataGridView3.CurrentRow.Cells[11].Value.ToString());
                    comboBox3.SelectedValue = Vint_UserStatus;


                    PicturePath.ImageLocation = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                    dateTimePicker1.Value = DateTime.Today.AddDays(0);
                    dateTimePicker2.Value = DateTime.Today.AddYears(10);
                    Passwordtxt.Select();
                    this.ActiveControl = Passwordtxt;
                    Passwordtxt.Focus();
                }
                else
                {
                    Passwordtxt.Enabled = false;
                    ConfirmPasswordtxt.Enabled = false;
                    Vint_TransfeerUser = 0;
                    xidu = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    textBox2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                    Nametxt.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                    NameEmptxt.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                    textBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                    comboBox1.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString());
                    comboBox2.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                    Vint_UserStatus = int.Parse(dataGridView3.CurrentRow.Cells[11].Value.ToString());
                    comboBox3.SelectedValue = Vint_UserStatus;
                    PicturePath.ImageLocation = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                    dateTimePicker1.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[9].Value.ToString());
                    dateTimePicker2.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[10].Value.ToString());
                    Passwordtxt.Select();
                    this.ActiveControl = Passwordtxt;
                    Passwordtxt.Focus();
                }
            }
            else if (Program.GlbV_UserTypeId == 2)
            {
                Passwordtxt.Enabled = false;
                ConfirmPasswordtxt.Enabled = false;
                Vint_TransfeerUser = 0;
                xidu = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                textBox2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                Nametxt.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                NameEmptxt.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                textBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                comboBox1.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString());
                comboBox2.SelectedValue = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                Vint_UserStatus = int.Parse(dataGridView3.CurrentRow.Cells[11].Value.ToString());
                comboBox3.SelectedValue = Vint_UserStatus;
                PicturePath.ImageLocation = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[9].Value.ToString());
                dateTimePicker2.Value = DateTime.Parse(dataGridView3.CurrentRow.Cells[10].Value.ToString());
                Passwordtxt.Select();
                this.ActiveControl = Passwordtxt;
                Passwordtxt.Focus();
            }
        }

        private void UsrTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                dataGridView3.Focus();
            }
        }

        private void dateTimePicker1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox3.Select();
                this.ActiveControl = comboBox3;
                comboBox3.Focus();
            }
        }



        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != "")
            {

                int? ComID = int.Parse(comboBox1.SelectedValue.ToString());
                var list = (from usr in FsDb.Tbl_User
                            join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                            join us in FsDb.Tbl_User_SysUnites on usr.Employee_id equals us.Emp_ID

                            where (us.SysUnites_ID == ComID && us.SysUnite_StatusID == 1)
                            select new
                            {
                                ID = usr.ID,
                                Name = usr.Name,
                                UserType_ID = usr.UserType_ID,
                                EmployeeName = usr.Tbl_Employee.Name,
                                Employee_id = usr.Tbl_Employee.ID,
                                UserSysUnit = us.Tbl_SystemUnites.Name,
                                UserSysunitID = us.Tbl_SystemUnites.ID,
                                UserType = usr.Tbl_UserType.Name,
                                UserImage = usr.ImagePath,
                                UserFDate = us.From_Date,
                                UserTDate = us.To_Date,
                                UserStatus_ID = usr.UserStatus_ID

                            }).ToList();
                dataGridView3.DataSource = list;
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboBox1_PreviewKeyDown);
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboBox1_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }



        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            int xidemp = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            var resultUserSys = FsDb.Tbl_User_SysUnites.SingleOrDefault(d => d.Tbl_Employee.ID == xidemp && d.SysUnite_StatusID == 1);

            var resultuser = FsDb.Tbl_User.SingleOrDefault(u => u.Employee_id == xidemp);

            if (Program.GlbV_UserTypeId == 1)
            {
                if (resultuser != null)
                {
                    Passwordtxt.Enabled = false;
                    ConfirmPasswordtxt.Enabled = false;
                    xidu = resultuser.ID;
                    DialogResult resultmsg = MessageBox.Show($"  هل تم نقل هدا الموظف  من الوحده الحاليه  {comboBox1.SelectedText}؟ ", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultmsg == DialogResult.Yes)
                    {
                        Vint_TransfeerUser = 1;
                        NameEmptxt.Text = resultuser.Tbl_Employee.Name.ToString();
                        Nametxt.Text = resultuser.Name.ToString();
                        //textBox2.Text = resultuser.ID.ToString();
                        textBox1.Text = resultuser.Employee_id.ToString();
                        PicturePath.ImageLocation = resultuser.ImagePath;
                        //comboBox1.SelectedValue = resultUserSys.SysUnites_ID;
                        comboBox2.SelectedValue = resultuser.Tbl_UserType.ID;
                        dateTimePicker1.MinDate = DateTime.Today;
                        Vint_UserStatus = int.Parse(resultuser.UserStatus_ID.ToString());

                        comboBox3.SelectedValue = Vint_UserStatus;
                        Passwordtxt.Select();
                        this.ActiveControl = Passwordtxt;

                        Passwordtxt.Focus();
                    }
                    else
                    {
                        Vint_TransfeerUser = 0;
                        if (resultuser != null)
                        {
                            NameEmptxt.Text = resultuser.Tbl_Employee.Name.ToString();
                            Nametxt.Text = resultuser.Name.ToString();
                            textBox2.Text = resultuser.ID.ToString();
                            textBox1.Text = resultuser.Employee_id.ToString();
                            PicturePath.ImageLocation = resultuser.ImagePath;
                            comboBox1.SelectedValue = resultUserSys.SysUnites_ID;
                            comboBox2.SelectedValue = resultuser.Tbl_UserType.ID;
                            dateTimePicker1.MinDate = resultUserSys.From_Date.Value;
                            dateTimePicker2.MinDate = resultUserSys.To_Date.Value;
                            Vint_UserStatus = int.Parse(resultuser.UserStatus_ID.ToString());
                       
                        comboBox3.SelectedValue = Vint_UserStatus;
                        }
                        else
                        {
                            
                            Nametxt.Text = (dataGridView2.CurrentRow.Cells[2].ToString()).Substring(7);
                        }
                        Passwordtxt.Select();
                        this.ActiveControl = Passwordtxt;
                        Passwordtxt.Focus();
                        //NameEmptxt.Text = "";
                        UsrTxtBox.Text = "";
                        PicturePath.Image = FinancialSysApp.Properties.Resources.download__2_;
                    }
                }
                else
                {
                    if (xidemp > 1)
                    {
                        Passwordtxt.Enabled = true;
                        ConfirmPasswordtxt.Enabled = true;
                        var resultEmp = FsDb.Tbl_Employee.SingleOrDefault(d => d.ID == xidemp);
                        if (resultEmp != null)
                        {
                            NameEmptxt.Text = resultEmp.Name.ToString();
                            Nametxt.Text = resultEmp.NationalId.Substring(7).ToString();
                            textBox1.Text = resultEmp.ID.ToString();
                        }
                        Passwordtxt.Focus();

                        // PicturePath.ImageLocation = result.ImagePath.ToString();

                    }
                }
            }
            else if (Program.GlbV_UserTypeId == 2)
            {
                Vint_TransfeerUser = 0;
                if (resultuser != null)
                {
                    NameEmptxt.Text = resultuser.Tbl_Employee.Name.ToString();
                    Nametxt.Text = resultuser.Name.ToString();
                    textBox2.Text = resultuser.ID.ToString();
                    textBox1.Text = resultuser.Employee_id.ToString();
                    PicturePath.ImageLocation = resultuser.ImagePath;
                    comboBox1.SelectedValue = resultUserSys.SysUnites_ID;
                    comboBox2.SelectedValue = resultuser.Tbl_UserType.ID;
                    dateTimePicker1.MinDate = resultUserSys.From_Date.Value;
                    dateTimePicker2.MinDate = resultUserSys.To_Date.Value;
                    Vint_UserStatus = int.Parse(resultuser.UserStatus_ID.ToString());

                    comboBox3.SelectedValue = Vint_UserStatus;
                }
                Passwordtxt.Select();
                this.ActiveControl = Passwordtxt;
                Passwordtxt.Focus();
                //NameEmptxt.Text = "";
                UsrTxtBox.Text = "";
                PicturePath.Image = FinancialSysApp.Properties.Resources.download__2_;
            }
        }


    }

}


