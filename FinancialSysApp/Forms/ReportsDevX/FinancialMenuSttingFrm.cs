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
using System.Data.SqlClient;
using System.Configuration;
/*
أعوذ بالله من الشيطان الرجيم 
بسم الله الرحمن الرحيم
الحمد لله رب العالمين * الرحمن الرحيم * مالك يوم الدين*إياك نعبد وأياك نستعين
*اهدنا الصراط المستقيم * صراط اللذين انعمت عليم * غير المغضوب عليهم * ولا الضآلين

    اللهم صل وسلم وبارك على سيدنا محمد وعلى آل سيدنا محمد
*/
namespace FinancialSysApp.Forms.ReportsDevX
{ 
    
public partial class FinancialMenuSttingFrm : DevExpress.XtraEditors.XtraForm
    {
   
    Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_ItemId;
        int Vint_ItemChildId;
        public FinancialMenuSttingFrm()
        {
            InitializeComponent();
        }
        private void getSortItem()
        {
            //string resut;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select MAX(SortingItems) from Tbl_FinancialMenuSetting where Parent_ID =@ID");
            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(IDParenttxtBox.Text);
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox8.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();
            if (textBox8.Text == string.Empty)
            {
                textBox8.Text = "0";
            }

            int x = 1;
            int y = Convert.ToInt32(textBox8.Text);
            int w = y + x;
            textBox8.Text = Convert.ToString(w);


        }
        public DataTable getDay()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand("SELECT * FROM Tbl_AccountingRestrictions_Kind WHERE ParentID IS NOT NULL ORDER BY ID ASC", con))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        da.Fill(dt);
                    }
                    catch 
                    {
                       
                        
                    }
                }
            }

            return dt;
        }
        private void ClearChck()
        {
            checkEdit1.Checked = false;
            checkEdit2.Checked = false;
            checkEdit3.Checked = false;
            checkEdit4.Checked = false;
            checkEdit5.Checked = false;
            checkEdit6.Checked = false;
            checkEdit7.Checked = false;
            checkEdit8.Checked = false;
            checkEdit11.Checked = false;
            checkEdit13.Checked = false;
            checkEdit15.Checked = false;
            checkEdit17.Checked = false;
            checkEdit19.Checked = false;
            checkEdit18.Checked = false;
            checkEdit9.Checked = false;
            checkEdit20.Checked = false;
            checkEdit41.Checked = false;
            checkEdit40.Checked = false;
            checkEdit45.Checked = false;
            checkEdit44.Checked = false;
            checkEdit49.Checked = false;
            checkEdit50.Checked = false;
            checkEdit48.Checked = false;
            checkEdit47.Checked = false;
        }
        public void getMaxSort1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select SortingItems from Tbl_FinancialMenuSetting where ID= @ID ");
            com.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(IDParenttxtBox.Text);
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox8.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();

        }
        public void  getMaxSort()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select Max(sortRestriction) from Tbl_FinancialMenuSetting where Parent_ID= @ID ");
            com.Parameters.Add("@ID",SqlDbType.Int).Value  = int.Parse(IDParenttxtBox.Text);
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while(red.Read())
            {
                textBox9.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();

            int x = 1;
            int y = Convert.ToInt32(textBox9.Text);
            int z = x + y;
            textBox9.Text = Convert.ToString(z);
        }
        public void getMaxMainSort()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select Max(SortingItems) from Tbl_FinancialMenuSetting where FinancialMenuNameID= @ID ");
            com.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(comboBox1.SelectedValue.ToString());
            con.Open();
            SqlDataReader red;
            red = com.ExecuteReader();
            while (red.Read())
            {
                textBox8.Text = red.GetValue(0).ToString();
            }
            red.Close();
            con.Close();
            int x = 1;
            int y = Convert.ToInt32(textBox8.Text);
            int z = x + y;
            textBox8.Text = Convert.ToString(z);
        }
        private void FinancialMenuSttingFrm_Load(object sender, EventArgs e)
        {

            ClearChck();

            for (int i = 2; i <= 21; i++)
            {
                System.Windows.Forms.ComboBox comboBox = Controls.Find("comboBox" + i, true).FirstOrDefault() as System.Windows.Forms.ComboBox;
                if (comboBox != null)
                {
                    comboBox.DataSource = getDay().Copy();
                    comboBox.DisplayMember = "Name";
                    comboBox.ValueMember = "ID";
                    comboBox.SelectedIndex = -1;
                }
            }

            //comboBox2.DataSource = getDay();
            //comboBox2.DisplayMember = "Name";
            //comboBox2.ValueMember = "ID";
            //comboBox2.SelectedIndex = -1;
            //comboBox3.DataSource = getDay();
            //comboBox3.DisplayMember = "Name";
            //comboBox3.ValueMember = "ID";
            //comboBox3.SelectedIndex = -1;
            //comboBox4.DataSource = getDay();
            //comboBox4.DisplayMember = "Name";
            //comboBox4.ValueMember = "ID";
            //comboBox4.SelectedIndex = -1;
            //comboBox5.DataSource = getDay();
            //comboBox5.DisplayMember = "Name";
            //comboBox5.ValueMember = "ID";
            //comboBox5.SelectedIndex = -1;

            //comboBox6.DataSource = getDay();
            //comboBox6.DisplayMember = "Name";
            //comboBox6.ValueMember = "ID";
            //comboBox6.SelectedIndex = -1;

            //comboBox7.DataSource = getDay();
            //comboBox7.DisplayMember = "Name";
            //comboBox7.ValueMember = "ID";
            //comboBox7.SelectedIndex = -1;

            //comboBox8.DataSource = getDay();
            //comboBox8.DisplayMember = "Name";
            //comboBox8.ValueMember = "ID";
            //comboBox8.SelectedIndex = -1;

            //comboBox9.DataSource = getDay();
            //comboBox9.DisplayMember = "Name";
            //comboBox9.ValueMember = "ID";
            //comboBox9.SelectedIndex = -1;

            //comboBox11.DataSource = getDay();
            //comboBox11.DisplayMember = "Name";
            //comboBox11.ValueMember = "ID";
            //comboBox11.SelectedIndex = -1;

            //comboBox10.DataSource = getDay();
            //comboBox10.DisplayMember = "Name";
            //comboBox10.ValueMember = "ID";
            //comboBox10.SelectedIndex = -1;

            //comboBox12.DataSource = getDay();
            //comboBox12.DisplayMember = "Name";
            //comboBox12.ValueMember = "ID";
            //comboBox12.SelectedIndex = -1;

            //comboBox13.DataSource = getDay();
            //comboBox13.DisplayMember = "Name";
            //comboBox13.ValueMember = "ID";
            //comboBox13.SelectedIndex = -1;

            //comboBox14.DataSource = getDay();
            //comboBox14.DisplayMember = "Name";
            //comboBox14.ValueMember = "ID";
            //comboBox14.SelectedIndex = -1;

            //comboBox15.DataSource = getDay();
            //comboBox15.DisplayMember = "Name";
            //comboBox15.ValueMember = "ID";
            //comboBox15.SelectedIndex = -1;

            //comboBox16.DataSource = getDay();
            //comboBox16.DisplayMember = "Name";
            //comboBox16.ValueMember = "ID";
            //comboBox16.SelectedIndex = -1;

            //comboBox17.DataSource = getDay();
            //comboBox17.DisplayMember = "Name";
            //comboBox17.ValueMember = "ID";
            //comboBox17.SelectedIndex = -1;

            //comboBox18.DataSource = getDay();
            //comboBox18.DisplayMember = "Name";
            //comboBox18.ValueMember = "ID";
            //comboBox18.SelectedIndex = -1;

            //comboBox19.DataSource = getDay();
            //comboBox19.DisplayMember = "Name";
            //comboBox19.ValueMember = "ID";
            //comboBox19.SelectedIndex = -1;

            //comboBox20.DataSource = getDay();
            //comboBox20.DisplayMember = "Name";
            //comboBox20.ValueMember = "ID";
            //comboBox20.SelectedIndex = -1;

            //comboBox21.DataSource = getDay();
            //comboBox21.DisplayMember = "Name";
            //comboBox21.ValueMember = "ID";
            //comboBox21.SelectedIndex = -1;
            this.tbl_FinancialMenuNameTableAdapter.Fill(this.financialSysDataSet.Tbl_FinancialMenuName);
            this.tbl_FinancialMenuSettingTableAdapter.Fill(this.financialSysDataSet.Tbl_FinancialMenuSetting);
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedText = "اختر القائمة";
            //************************
            tBLRESULTBindingSource.DataSource = FsDb.TBL_RESULT.ToList();
            AutoCompleteStringCollection Doct = new AutoCompleteStringCollection();
            foreach (TBL_RESULT d in tBLRESULTBindingSource.DataSource as List<TBL_RESULT>)
                Doct.Add(d.ACC_NM_Ar);
            AuditBalancetxtBox.AutoCompleteCustomSource = Doct;

            //*******************

            comboBox1.Select();
            this.ActiveControl = comboBox1;
            comboBox1.Focus();
        }

        private void radTreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radTreeView1.SelectedNodes.Count() > 0)
            {
                Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                var list = FsDb.Tbl_FinancialMenuSetting.FirstOrDefault(x => x.ID == Vint_ItemId);

                ParentIDtxt.Text = list.Parent_ID.ToString();
                if (IDParenttxtBox.Text == "" && list.Parent_ID == null)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = radTreeView1.SelectedNode.Text.ToString();
                    //Vint_ItemId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    IDParenttxtBox.Text = Vint_ItemId.ToString();

                }
                else if (IDParenttxtBox.Text != "" && list.Parent_ID != null)
                {
                    textBox2.Text = "";
                    Vint_ItemChildId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    IDChildtxtBox.Text = Vint_ItemChildId.ToString();
                    textBox2.Text = radTreeView1.SelectedNode.Text.ToString();
                }
                else if (IDParenttxtBox.Text != "" && list.Parent_ID == null)
                {
                    textBox2.Text = "";
                    Vint_ItemChildId = int.Parse(radTreeView1.SelectedNode.Value.ToString());
                    IDChildtxtBox.Text = Vint_ItemChildId.ToString();
                    textBox2.Text = radTreeView1.SelectedNode.Text.ToString();
                }
                else if (IDParenttxtBox.Text == "" && list.Parent_ID != null)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = radTreeView1.SelectedNode.Text.ToString();

                    IDParenttxtBox.Text = Vint_ItemId.ToString();
                }





                textBox2.Select();
                this.ActiveControl = textBox2;
                textBox2.Focus();
            }
            else
            {
                //textBox1.Text = Nametxt.Text;
                radTreeView1.Select();
                this.ActiveControl = radTreeView1;
                radTreeView1.Focus();
            }
            // getSortItem();
            ShowDeuBlusAccountByAccount();
            ShowCashBlusCategory();
            ShowDeuBlus();
            ShowDeuBlus3();
            ShowDeuBlus4();
            ShowDeunegativeAccountByAccount();
            ShowDeuBlusCategory();
            ShowCashNigativCategory();
            ShowDeuNigativCategory();
            ShowDeunegative();
            ShowDeunegative3();
            ShowCashBlus();
            ShowDeunegative4();
            ShowCashgative();
            try
            {
                getMaxSort();

               
                if (textBox9.Text == string.Empty)
                {
                    textBox9.Text = "1";
                }
            }

            catch { textBox9.Text = "1"; }
            getMaxSort1();
            if (textBox8.Text == string.Empty)
            {
                getMaxMainSort();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == string.Empty )
            {
                textBox9.Text = null;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر القائمه المراده ");
                comboBox1.Select();
                this.ActiveControl = comboBox1;
                comboBox1.Focus();
            }
            //else if (textBox8.Text == "")
            //{
            //    MessageBox.Show("من فضلك ادخل ترتيب البند ");
            //    textBox8.Select();
            //    this.ActiveControl = textBox8;
            //    textBox8.Focus();
            //}
            else if (textBox1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البند ");
                textBox1.Select();
                this.ActiveControl = textBox1;
                textBox1.Focus();
            }
            else
            {
                int xrows = radTreeView1.SelectedNodes.Count;
                if (IDParenttxtBox.Text == "" && textBox1.Text != "")

                   
                {
                    getMaxMainSort();
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 38 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        //***********************
                        if (textBox9.Text != string.Empty)
                        {
                            int Vint_itemcategoryid = 0;

                            Tbl_FinancialMenuSetting CatF = new Tbl_FinancialMenuSetting
                            {
                                Name = textBox1.Text,
                                FinancialMenuNameID = int.Parse(comboBox1.SelectedValue.ToString()),

                                Fdate = Convert.ToDateTime(dateTimePicker1.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                                TDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                                FermulaMenuSide1 = FormulaSide1.Text,
                                FermulaMenuSide2 = FormulaSide2.Text,
                                SortingItems = Convert.ToInt32(textBox8.Text),
                                sortRestriction = Convert.ToInt32(textBox9.Text)
                            };
                            FsDb.Tbl_FinancialMenuSetting.Add(CatF);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            int Vint_LastRow = CatF.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة بند قائمة" + " " + comboBox1.SelectedText,
                                TableName = "Tbl_FinancialMenuSetting",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة اعدادات القوائم المالية"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("تم الحفظ");
                            radTreeView1.DataSource = FsDb.Tbl_FinancialMenuSetting.ToList();
                            ///*Nametxt*/.Text = "";
                            IDParenttxtBox.Text = "";
                            textBox1.Text = "";

                            radTreeView1.ExpandAll();
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                            //**************************
                        }
                        if (textBox9.Text == string.Empty)
                        {
                            int Vint_itemcategoryid = 0;

                            Tbl_FinancialMenuSetting CatF = new Tbl_FinancialMenuSetting
                            {
                                Name = textBox1.Text,
                                FinancialMenuNameID = int.Parse(comboBox1.SelectedValue.ToString()),

                                Fdate = Convert.ToDateTime(dateTimePicker1.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                                TDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                                FermulaMenuSide1 = FormulaSide1.Text,
                                FermulaMenuSide2 = FormulaSide2.Text,
                                SortingItems = Convert.ToInt32(textBox8.Text),
                                sortRestriction = null
                            };
                            FsDb.Tbl_FinancialMenuSetting.Add(CatF);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            int Vint_LastRow = CatF.ID;
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة بند قائمة" + " " + comboBox1.SelectedText,
                                TableName = "Tbl_FinancialMenuSetting",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة اعدادات القوائم المالية"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                            //***************************
                            MessageBox.Show("تم الحفظ");
                            radTreeView1.DataSource = FsDb.Tbl_FinancialMenuSetting.ToList();
                            ///*Nametxt*/.Text = "";
                            IDParenttxtBox.Text = "";
                            textBox1.Text = "";

                            radTreeView1.ExpandAll();
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                            //**************************
                        }
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDParenttxtBox.Text == "" && textBox1.Text == "" && textBox2.Text != "")
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 38 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        //int Vint_itemcategoryid = 0;

                        Tbl_FinancialMenuSetting CatF = new Tbl_FinancialMenuSetting
                        {

                            Name = textBox1.Text,
                            FinancialMenuNameID = int.Parse(comboBox1.SelectedValue.ToString()),
                            Fdate = Convert.ToDateTime(dateTimePicker1.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                            TDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                            FermulaMenuSide1 = FormulaSide1.Text,
                            FermulaMenuSide2 = FormulaSide2.Text,
                            Parent_ID = null,
                            SortingItems = Convert.ToInt32(textBox8.Text),
                            sortRestriction = Convert.ToInt32(textBox9.Text)
                        };
                        FsDb.Tbl_FinancialMenuSetting.Add(CatF);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند قائمة",
                            TableName = "Tbl_FinancialMenuSetting",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اعدادات القوائم المالية"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة بيانات تابعه للبيان " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_FinancialMenuSetting.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            //Nametxt.Text = "";
                            IDParenttxtBox.Text = "";
                            //textBox1.Text = "";
                            textBox2.Text = "";

                            radTreeView1.ExpandAll();
                            textBox2.Select();
                            this.ActiveControl = textBox2;
                            textBox2.Focus();
                        }
                        else
                        {
                            //Nametxt.Text = "";
                            IDParenttxtBox.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";

                            radTreeView1.ExpandAll();
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                        }
                    }
                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && IDParenttxtBox.Text == "")
                {
                    var validationSaveUser1 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 38 && w.ProcdureId == 1);
                    if (validationSaveUser1 != null)
                    {
                        int Vint_itemcategoryid = 0;

                        Tbl_FinancialMenuSetting CatF = new Tbl_FinancialMenuSetting
                        {
                            Name = textBox2.Text,
                            Parent_ID = int.Parse(IDParenttxtBox.Text),

                            FinancialMenuNameID = int.Parse(comboBox1.SelectedValue.ToString()),
                            Fdate = Convert.ToDateTime(dateTimePicker1.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                            TDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                            FermulaMenuSide1 = FormulaSide1.Text,
                            FermulaMenuSide2 = FormulaSide2.Text,
                            SortingItems = Convert.ToInt32(textBox8.Text),
                            sortRestriction = Convert.ToInt32(textBox9.Text)

                        };
                        FsDb.Tbl_FinancialMenuSetting.Add(CatF);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند قائمه",
                            TableName = "Tbl_FinancialMenuSetting",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اعدادات القوائم المالية"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة فروع تابعه للبيان " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_FinancialMenuSetting.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            //Nametxt.Text = "";
                            //IDtxtBox.Text = "";
                            //textBox1.Text = "";
                            textBox2.Text = "";

                            radTreeView1.ExpandAll();
                            textBox2.Select();
                            this.ActiveControl = textBox2;
                            textBox2.Focus();
                        }
                        else
                        {
                            //Nametxt.Text = "";
                            IDParenttxtBox.Text = "";
                            IDChildtxtBox.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";

                            radTreeView1.ExpandAll();
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text == "" && IDChildtxtBox.Text == "")
                {
                    var validationSaveUser3 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 38 && w.ProcdureId == 3);
                    if (validationSaveUser3 != null)

                    {
                        int Vint_itemcategoryid = 0;

                        Vint_ItemId = int.Parse(IDParenttxtBox.Text);
                        var result = FsDb.Tbl_FinancialMenuSetting.SingleOrDefault(x => x.ID == Vint_ItemId);

                        result.Name = textBox1.Text;
                        result.FinancialMenuNameID = int.Parse(comboBox1.SelectedValue.ToString());

                        result.Fdate = Convert.ToDateTime(dateTimePicker1.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss"));
                        result.TDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss"));
                        result.FermulaMenuSide1 = FormulaSide1.Text;
                        result.FermulaMenuSide2 = FormulaSide2.Text;
                        result.SortingItems = Convert.ToInt32(textBox8.Text);
                        result.sortRestriction = Convert.ToInt32(textBox9.Text);


                        //result.Parent_ID = int.Parse(IDParenttxtBox.Text);

                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بند قائمه",
                            TableName = "Tbl_FinancialMenuSetting",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اعدادات القوائم المالية"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_FinancialMenuSetting.ToList();
                        //Nametxt.Text = "";
                        IDParenttxtBox.Text = "";
                        IDChildtxtBox.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";


                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  بند .. برجاء مراجعة مدير المنظومه");
                    }

                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && IDChildtxtBox.Text != "")
                {
                    var validationSaveUser2 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 44 && w.ProcdureId == 3);
                    if (validationSaveUser2 != null)

                    {

                        Vint_ItemChildId = int.Parse(IDChildtxtBox.Text);
                        var result = FsDb.Tbl_FinancialMenuSetting.SingleOrDefault(x => x.ID == Vint_ItemChildId);

                        result.FinancialMenuNameID = int.Parse(comboBox1.SelectedValue.ToString());
                        result.Fdate = Convert.ToDateTime(dateTimePicker1.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss"));
                        result.TDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss"));
                        result.FermulaMenuSide1 = FormulaSide1.Text;
                        result.FermulaMenuSide2 = FormulaSide2.Text;
                        result.Name = textBox2.Text;
                        result.Parent_ID = int.Parse(IDParenttxtBox.Text);
                        result.SortingItems = Convert.ToInt32(textBox8.Text);
                        result.sortRestriction = Convert.ToInt32(textBox9.Text);
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل بند في قائمه",
                            TableName = "Tbl_FinancialMenuSetting",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اعدادات القوائم المالية"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم التعديل");
                        radTreeView1.DataSource = FsDb.Tbl_FinancialMenuSetting.ToList();
                        //Nametxt.Text = "";
                        IDParenttxtBox.Text = "";
                        IDChildtxtBox.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";


                        textBox1.Select();
                        this.ActiveControl = textBox1;
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  بند .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else if (IDParenttxtBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && IDChildtxtBox.Text == "")
                {
                    var validationSaveUser1 = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 38 && w.ProcdureId == 1);
                    if (validationSaveUser1 != null)
                    {
                        int Vint_itemcategoryid = 0;

                        Tbl_FinancialMenuSetting CatF = new Tbl_FinancialMenuSetting
                        {
                            Name = textBox2.Text,
                            Parent_ID = int.Parse(IDParenttxtBox.Text),
                            FinancialMenuNameID = int.Parse(comboBox1.SelectedValue.ToString()),
                            Fdate = Convert.ToDateTime(dateTimePicker1.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),
                            TDate = Convert.ToDateTime(dateTimePicker2.Value.ToString("dddd , MMM dd yyyy,hh:mm:ss")),

                            FermulaMenuSide1 = FormulaSide1.Text,
                            FermulaMenuSide2 = FormulaSide2.Text,
                            SortingItems = Convert.ToInt32(textBox8.Text),
                            sortRestriction = Convert.ToInt32(textBox9.Text)

                        };
                        FsDb.Tbl_FinancialMenuSetting.Add(CatF);
                        FsDb.SaveChanges();
                        int Vint_LastRow = CatF.ID;
                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة بند قائمه",
                            TableName = "Tbl_FinancialMenuSetting",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة اعدادات القوائم المالية"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        var resultASk = MessageBox.Show("هل تريد اضافة فروع تابعه للبيان " + " " + textBox1.Text, "تم الحفظ ", MessageBoxButtons.YesNo);
                        radTreeView1.DataSource = FsDb.Tbl_FinancialMenuSetting.ToList();
                        if (resultASk == DialogResult.Yes)
                        {
                            //Nametxt.Text = "";
                            //IDtxtBox.Text = "";
                            //textBox1.Text = "";
                            textBox2.Text = "";

                            radTreeView1.ExpandAll();
                            textBox2.Select();
                            this.ActiveControl = textBox2;
                            textBox2.Focus();
                        }
                        else
                        {
                            //Nametxt.Text = "";
                            IDParenttxtBox.Text = "";
                            IDChildtxtBox.Text = "";
                            textBox1.Text = "";
                            textBox2.Text = "";

                            radTreeView1.ExpandAll();
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
                    }

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text == "")
            //{
            //    IDParenttxtBox.Text = "";
            //    IDParenttxtBox.Text = "";
            //}
            //var list = FsDb.Tbl_FinancialMenuSetting.Where(x => x.Name.Contains(textBox1.Text)).ToList();
            //radTreeView1.DataSource = list;

            if (textBox1.Text == "")
            {
                IDParenttxtBox.Text = "";
                IDParenttxtBox.Text = "";
                int? Vint_FinMenuID = int.Parse(comboBox1.SelectedValue.ToString());
                var list1 = FsDb.Tbl_FinancialMenuSetting.Where(x => x.FinancialMenuNameID == Vint_FinMenuID).ToList();
                radTreeView1.DataSource = list1;

            }
            if (textBox1.Text != "")
            {
                var list = FsDb.Tbl_FinancialMenuSetting.Where(x => x.Name.Contains(textBox1.Text)).ToList();
                radTreeView1.DataSource = list;
            }
            try
            {
                getMaxSort();


                if (textBox9.Text == string.Empty)
                {
                    textBox9.Text = "1";
                }
            }

            catch { textBox9.Text = "1"; }
            //radTreeView1.ExpandAll();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                IDChildtxtBox.Text = "";
            }
        }


        private void AuditBalancetxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ListABalance = FsDb.TBL_RESULT.FirstOrDefault(x => x.ACC_NM_Ar.Contains(AuditBalancetxtBox.Text));
                AuditBalancetxtBox.Text = ListABalance.ACC_NM_Ar.ToString();
                AuditBalanceIDtxtBox.Text = ListABalance.ID.ToString();
                //if (FormulaSide1.Text == "")
                //{
                //    FormulaSide1.Text = AuditBalancetxtBox.Text;
                //}
                checkBoxX8.Checked = false;
                checkBoxX7.Checked = false;
                checkBoxX8.Focus();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int? Vint_FinMenuID = int.Parse(comboBox1.SelectedValue.ToString());
            var list = FsDb.Tbl_FinancialMenuSetting.Where(x => x.FinancialMenuNameID == Vint_FinMenuID).ToList();
            radTreeView1.DataSource = list;

        }

        private void AuditBalancetxtBox_TextChanged(object sender, EventArgs e)
        {
            //if (AuditBalancetxtBox.Text != "")
            //{
            //    var list = (from AccG in FsDb.TBL_RESULT

            //                where (AccG.ACC_NM_Ar.Contains(AuditBalancetxtBox.Text))

            //                select new
            //                {
            //                    ID = AccG.ID,
            //                    Name = AccG.ACC_NM_Ar,
            //                    Account_NO = AccG.ACC_NO



            //                }).OrderBy(x => x.ID).ToList();

            //    string Vstr_bb = list[0].Name;
            //}
        }

        private void checkBoxX8_CheckedChanged(object sender, EventArgs e)
        {
            if (AuditBalancetxtBox.Text != "")
            {
                if (checkBoxX8.Checked == true)
                {
                    if (FormulaSide1.Text == "")
                    {
                        FormulaSide1.Text = AuditBalancetxtBox.Text;
                    }
                    else
                    {
                        FormulaSide1.Text = FormulaSide1.Text + " " + "+" + " " + AuditBalancetxtBox.Text;

                    }
                }

            }
            else
            {
                MessageBox.Show("من فضلك اختر حساب من ميزان المراجعه او تصنيف اولاً");
            }
        }

        private void checkBoxX7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX7.Checked == true)
            {
                if (AuditBalancetxtBox.Text != "")
                {

                    if (FormulaSide1.Text == "")
                    {
                        FormulaSide1.Text = AuditBalancetxtBox.Text;
                    }
                    else
                    {
                        FormulaSide1.Text = FormulaSide1.Text + "" + "-" + AuditBalancetxtBox.Text;

                    }
                }

            }
            else
            {
                MessageBox.Show("من فضلك اختر حساب من ميزان المراجعه او تصنيف اولاً");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit10.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();

                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox4.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    label12.Text = "(" + Forms.ProcessingForms.FindAccount.SelectedRow.Cells[1].Value.ToString() + ")";
                    AddChildAccount();
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit1.Checked == true || checkEdit2.Checked == true)
                {
                    try


                    {
                        if (checkEdit10.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {
                                dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit10.Checked == false)
                        {

                            dataGridView1.Rows.Add(textBox1.Text, textBox4.Text, comboBox2.Text, IDParenttxtBox.Text, AccID.Text, comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit12.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();
                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox5.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    AddChildAccount();
                }
                catch { }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit3.Checked == true || checkEdit4.Checked == true)
                {
                    try
                    {
                        if (checkEdit12.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {


                                dataGridView2.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox3.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox3.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit4.EditValue, checkEdit3.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit12.Checked == false)
                        {
                            dataGridView2.Rows.Add(textBox1.Text, textBox5.Text, comboBox3.Text, IDParenttxtBox.Text, AccID.Text, comboBox3.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit4.EditValue, checkEdit3.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit14.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();
                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox7.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    AddChildAccount();
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit5.Checked == true || checkEdit6.Checked == true)
                {
                    try
                    {
                        if (checkEdit14.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {




                                dataGridView3.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox5.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox5.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit6.EditValue, checkEdit5.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit14.Checked == false)
                        {
                            dataGridView3.Rows.Add(textBox1.Text, textBox7.Text, comboBox5.Text, IDParenttxtBox.Text, AccID.Text, comboBox5.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit6.EditValue, checkEdit5.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit16.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();
                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox6.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    AddChildAccount();
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit8.Checked == true || checkEdit7.Checked == true)
                {
                    try
                    {
                        if (checkEdit16.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {

                                dataGridView4.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox4.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox4.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit8.EditValue, checkEdit7.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit16.Checked == false)
                        {
                            dataGridView4.Rows.Add(textBox1.Text, textBox6.Text, comboBox4.Text, IDParenttxtBox.Text, AccID.Text, comboBox4.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit8.EditValue, checkEdit7.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }
        private void SaveDeuBlus()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveColumn3Blus()
        {
            //try
            //{
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView23.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn16"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView23.Rows.Count; i++)
                {
                    dataGridView23.Rows[i].Cells[13].Value = false;
                }
            //}
            //catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveColumn4Blus()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView27.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn22"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView27.Rows.Count; i++)
                {
                    dataGridView27.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveColumn3Min()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView24.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn18"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView24.Rows.Count; i++)
                {
                    dataGridView24.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveColumn4Min()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView26.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn20"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView26.Rows.Count; i++)
                {
                    dataGridView26.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveDeuBlusLink()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[15].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Update Tbl_FinancialMenuAccountsDuePaymentBlus set (Trsnsfare = true,Transfare_FinancialMenuNameID =@Transfare_FinancialMenuNameID) where id=@ID");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Transfare_FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@ID", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[14].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveDeuAccountByAccountBlus()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView13.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn8"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }
            for (int i = 0; i < dataGridView13.Rows.Count; i++)
            {
                dataGridView13.Rows[i].Cells[13].Value = false;
            }
            //}
            //catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveDeuAccountByAccountBlus1()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView20.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn13"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }
            for (int i = 0; i < dataGridView20.Rows.Count; i++)
            {
                dataGridView20.Rows[i].Cells[13].Value = false;
            }
            //}
            //catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveCachAccountByAccountBlus1()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView22.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn15"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue,CashPaymentCridetValue,FinancialMenuNameID,CashPayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }
            for (int i = 0; i < dataGridView22.Rows.Count; i++)
            {
                dataGridView22.Rows[i].Cells[13].Value = false;
            }
            //}
            //catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveCachAccountByAccountBlus()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView18.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn11"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue,CashPaymentCridetValue,FinancialMenuNameID,CashPayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }
            for (int i = 0; i < dataGridView18.Rows.Count; i++)
            {
                dataGridView18.Rows[i].Cells[13].Value = false;
            }
            //}
            //catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveCachAccountByAccountMin1()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView21.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn14"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue1,CashPaymentCridetValue1,FinancialMenuNameID,CashPayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }
            for (int i = 0; i < dataGridView21.Rows.Count; i++)
            {
                dataGridView21.Rows[i].Cells[13].Value = false;
            }
            //}
            //catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveCachAccountByAccountMin()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView17.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn10"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue1,CashPaymentCridetValue1,FinancialMenuNameID,CashPayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }
            for (int i = 0; i < dataGridView17.Rows.Count; i++)
            {
                dataGridView17.Rows[i].Cells[13].Value = false;
            }
            //}
            //catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveDeuAccountByAccountMin()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView14.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn9"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue1,DuePaymentCridetValue1,FinancialMenuNameID,DuePayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                        com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView14.Rows.Count; i++)
                {
                    dataGridView14.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveDeuAccountByAccountMin1()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView19.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn12"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountByAccountDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue1,DuePaymentCridetValue1,FinancialMenuNameID,DuePayment,RestrictionItems_D) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItems_D)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                        com.Parameters.Add("@RestrictionItems_D", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView19.Rows.Count; i++)
                {
                    dataGridView19.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void ShowDeuBlusAccountByAccount()
        {
            //try
            //{
            dataGridView13.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
            //    if (isSelected)
            //    {
            com.Parameters.Clear();
            //row.Cells[5].Value = MAXID.Text;
            com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة],  dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue,dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePayment = 1) AND (dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
            com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
            SqlDataReader red;

            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridView13.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

            }

            con.Close();
            //}

            //}

            //}
            //catch { }
        }
        private void ShowDeuBlus()
        {
            try
            {
                dataGridView1.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة],  dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowDeuBlus3()
        {
            try
            {
                dataGridView23.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة],  dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 3) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 3) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView23.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowDeuBlus4()
        {
            try
            {
                dataGridView27.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة],  dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 4) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 4) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView27.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowCashBlusCategory()
        {
            try
            {
                dataGridView12.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue AS Expr1, dbo.Tbl_RestrictionItemsCategory.Name FROM            dbo.Tbl_AccountingRestrictions_Kind INNER JOIN dbo.Tbl_FinancialMenuCategoryDuePaymentBlus INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID INNER JOIN  dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN  dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_RestrictionItemsCategory.ID = dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID AND dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID WHERE(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue = 1) OR (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P GROUP BY dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue, dbo.Tbl_RestrictionItemsCategory.Name");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView12.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3), red.GetValue(7));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowCashBlusColumn3()
        {
            try
            {
                dataGridView23.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue AS Expr1, dbo.Tbl_RestrictionItemsCategory.Name FROM            dbo.Tbl_AccountingRestrictions_Kind INNER JOIN dbo.Tbl_FinancialMenuCategoryDuePaymentBlus INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID INNER JOIN  dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN  dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_RestrictionItemsCategory.ID = dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID AND dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID WHERE(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue = 1) OR (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P GROUP BY dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue, dbo.Tbl_RestrictionItemsCategory.Name");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView23.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3), red.GetValue(7));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowCashNigativCategory()
        {
            try
            {
                dataGridView11.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue1,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue1 AS Expr1, dbo.Tbl_RestrictionItemsCategory.Name FROM            dbo.Tbl_AccountingRestrictions_Kind INNER JOIN  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus INNER JOIN dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON  dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID INNER JOIN dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_RestrictionItemsCategory.ID = dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID AND dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN  dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID WHERE (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue1 = 1)And (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue1 = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P GROUP BY dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_RestrictionItemsCategory.Name ");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView11.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3), red.GetValue(7));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowDeuBlusCategory()
        {
            try
            {
                dataGridView9.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue AS Expr1, dbo.Tbl_RestrictionItemsCategory.Name FROM            dbo.Tbl_AccountingRestrictions_Kind INNER JOIN dbo.Tbl_FinancialMenuCategoryDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID INNER JOIN  dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_RestrictionItemsCategory.ID = dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID AND dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.Account_Guid_ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuNameID,   dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue1,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,   dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Tbl_Accounting_Guid.Account_NO,   dbo.Tbl_RestrictionItemsCategory.Name HAVING   (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentDebitValue = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView9.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3), red.GetValue(7));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowDeuNigativCategory()
        {
            //try
            //{
            dataGridView10.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
            //    if (isSelected)
            //    {
            com.Parameters.Clear();
            //row.Cells[5].Value = MAXID.Text;
            com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO, dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue1 AS Expr1, dbo.Tbl_RestrictionItemsCategory.Name FROM            dbo.Tbl_AccountingRestrictions_Kind INNER JOIN dbo.Tbl_FinancialMenuCategoryDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID INNER JOIN  dbo.Tbl_RestrictionItemsCategory ON dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionItemsCategory_ID = dbo.Tbl_RestrictionItemsCategory.ID LEFT OUTER JOIN  dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_RestrictionItemsCategory.ID = dbo.Tbl_AccountingRestrictionItems.RestrictionItemsCategory_ID AND dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND    dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.ID, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.Account_Guid_ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuSetting_ID,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.FinancialMenuNameID, dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePayment,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPayment, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue,  dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,   dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name, dbo.Tbl_Accounting_Guid.Account_NO,   dbo.Tbl_RestrictionItemsCategory.Name HAVING        (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentDebitValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuCategoryDuePaymentBlus.DuePaymentCridetValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
            com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
            SqlDataReader red;

            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridView10.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3), red.GetValue(7));

            }

            con.Close();
            //}

            //}

            //}
            //catch { }
        }
        private void AddChildAccount()
        {
            try
            {
                dataGridView5.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT ID,Account_NO  FROM [FinancialSys].[dbo].[Tbl_Accounting_Guid] where Account_NO like @P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox10.Text + "%";
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView5.Rows.Add(red.GetValue(0), red.GetValue(1));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void SaveDeunegative()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[13].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue1,DuePaymentCridetValue1,FinancialMenuNameID,DuePayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Cells[13].Value = false;
            }
            //}
            //    catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void ShowDeunegative()
        {
            try
            {
                dataGridView2.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1 FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView2.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowDeunegative3()
        {
            try
            {
                dataGridView24.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1 FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 3) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 3) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView24.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowDeunegative4()
        {
            try
            {
                dataGridView26.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1 FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 4) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment = 4) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView26.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void ShowDeunegativeAccountByAccount()
        {
            try
            {
                dataGridView14.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue1,dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue1 FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentDebitValue1 = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePayment = 1) AND(dbo.Tbl_FinancialMenuAccountByAccountDuePaymentBlus.DuePaymentCridetValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView14.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void SaveCashBlus()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[13].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue,CashPaymentCridetValue,FinancialMenuNameID,CashPayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    dataGridView3.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void ShowCashBlus()
        {
            try
            {
                dataGridView3.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue = 1) and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue  = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView3.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void SaveCashgative()
        {
            //try
            //{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[13].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_FinancialMenuAccountsDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue1,CashPaymentCridetValue1,FinancialMenuNameID,CashPayment) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment)");
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                    com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                    com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                    com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                    com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                dataGridView4.Rows[i].Cells[13].Value = false;
            }
            //}
            //    catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void DeleteFromMenue()
        {
            //try
            //{
            DialogResult result = new DialogResult();
            result = MessageBox.Show(" هل أنت متأكد من حذف البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;

                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("Delete from Tbl_FinancialMenuAccountsDuePaymentBlus Where ID=@ID");
                com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox16.Text);



                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            //}
            //    catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }

        private void DeleteFromMenueCategory()
        {
            //try
            //{
            DialogResult result = new DialogResult();
            result = MessageBox.Show(" هل أنت متأكد من حذف البند؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;

                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("Delete from Tbl_FinancialMenuCategoryDuePaymentBlus Where ID=@ID");
                com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox16.Text);



                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            //}
            //    catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void ShowCashgative()
        {
            try
            {

                dataGridView4.Rows.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    bool isSelected = Convert.ToBoolean(row.Cells["Column12"].Value);
                //    if (isSelected)
                //    {
                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = ("SELECT        dbo.Tbl_FinancialMenuSetting.Name AS [بند القائمة], dbo.Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], dbo.Tbl_AccountingRestrictions_Kind.Name AS اليومية,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1,dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1 FROM   dbo.Tbl_AccountingRestrictions_Kind INNER JOIN         dbo.Tbl_FinancialMenuAccountsDuePaymentBlus INNER JOIN  dbo.Tbl_Accounting_Guid ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID = dbo.Tbl_Accounting_Guid.ID ON   dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID LEFT OUTER JOIN                    dbo.Tbl_AccountingRestrictionItems ON dbo.Tbl_AccountingRestrictions_Kind.ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID AND  dbo.Tbl_Accounting_Guid.ID = dbo.Tbl_AccountingRestrictionItems.Accounting_Guid_ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID = dbo.Tbl_AccountingRestrictionItems.AccountingRestrictionKind_ID RIGHT OUTER JOIN  dbo.Tbl_FinancialMenuSetting INNER JOIN dbo.Tbl_FinancialMenuName ON dbo.Tbl_FinancialMenuSetting.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID ON dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID = dbo.Tbl_FinancialMenuName.ID AND  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID = dbo.Tbl_FinancialMenuSetting.ID GROUP BY dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.RestrictionKind_ID, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.Account_Guid_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateFrom, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DateTo, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuSetting_ID,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.FinancialMenuNameID,  dbo.Tbl_FinancialMenuSetting.Name, dbo.Tbl_FinancialMenuName.Name, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePayment, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment,  dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.DuePaymentCridetValue1,   dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue,    dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1, dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1, dbo.Tbl_FinancialMenuSetting.SortingItems,    dbo.Tbl_FinancialMenuSetting.Parent_ID, dbo.Tbl_FinancialMenuSetting.sortRestriction, dbo.Tbl_Accounting_Guid.Name, dbo.Tbl_AccountingRestrictions_Kind.Name,dbo.Tbl_Accounting_Guid.Account_NO HAVING  (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentDebitValue1 = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P OR (dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPayment = 1) AND(dbo.Tbl_FinancialMenuAccountsDuePaymentBlus.CashPaymentCridetValue1  = 1)and dbo.Tbl_FinancialMenuSetting.Name=@P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = textBox1.Text;
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView4.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), "", "", "", "", "", red.GetValue(4), red.GetValue(5), "", "", "", false, red.GetValue(3));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (checkEdit21.Checked == true || checkEdit22.Checked == true)
            {

                
                splashScreenManager1.ShowWaitForm();
               
                splashScreenManager1.SetWaitFormCaption("جارى ضبط المعادلات وتحميل القائمة ");
                splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات  ");
                DeleteReport();
                SaveCachAccountByAccountMin1();
                SaveCachAccountByAccountBlus1();
                SaveDeuAccountByAccountBlus1();
                SaveDeuAccountByAccountMin1();

                SaveCachAccountByAccountMin();
                SaveCachAccountByAccountBlus();
                SaveDeuAccountByAccountBlus();
                SaveDeuAccountByAccountMin();
                SaveDeuBlus();
                SaveDeuBlusCategory();
                SaveDeuNegativCategory();
                SaveCashMinCategory();
                SaveCashBlusCategory();
                SaveDeunegative();
                SaveCashBlus();
                SaveCashgative();
                SaveColumn3Blus();
                SaveColumn3Min();
                SaveColumn4Blus();
                SaveColumn4Min();
                this.linkedMenuAccountCategoryTableAdapter.Fill(this.dataSet1.LinkedMenuAccountCategory);

                this.linkedMenueTableAdapter.FillLink(this.dataSet12.LinkedMenue);

                this.linkedMenueTableAdapter.FillLink(this.dataSet1.LinkedMenue);
                this.menueWithCategoryTableAdapter.Fill(this.dataSet1.MenueWithCategory);
                this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
                dataGridView7.SelectAll();
                dataGridView6.SelectAll();
                dataGridView16.SelectAll();
                dataGridView8.AllowUserToAddRows = true;
                for (int i = 0; i < dataGridView16.SelectedRows.Count; i++)
                {
                    int index = dataGridView8.Rows.Add();
                    dataGridView8.Rows[index].Cells[0].Value = dataGridView16.SelectedRows[i].Cells[0].Value.ToString();
                    dataGridView8.Rows[index].Cells[1].Value = dataGridView16.SelectedRows[i].Cells[1].Value.ToString();
                    dataGridView8.Rows[index].Cells[2].Value = dataGridView16.SelectedRows[i].Cells[2].Value.ToString();
                    dataGridView8.Rows[index].Cells[3].Value = dataGridView16.SelectedRows[i].Cells[3].Value.ToString();
                    dataGridView8.Rows[index].Cells[4].Value = dataGridView16.SelectedRows[i].Cells[4].Value.ToString();
                    dataGridView8.Rows[index].Cells[5].Value = dataGridView16.SelectedRows[i].Cells[5].Value.ToString();
                    dataGridView8.Rows[index].Cells[6].Value = dataGridView16.SelectedRows[i].Cells[6].Value.ToString();
                    dataGridView8.Rows[index].Cells[7].Value = dataGridView16.SelectedRows[i].Cells[7].Value.ToString();
                    dataGridView8.Rows[index].Cells[8].Value = dataGridView16.SelectedRows[i].Cells[8].Value.ToString();
                    dataGridView8.Rows[index].Cells[9].Value = dataGridView16.SelectedRows[i].Cells[9].Value.ToString();
                    dataGridView8.Rows[index].Cells[10].Value = dataGridView16.SelectedRows[i].Cells[10].Value.ToString();
                    dataGridView8.Rows[index].Cells[11].Value = dataGridView16.SelectedRows[i].Cells[11].Value.ToString();
                    dataGridView8.Rows[index].Cells[12].Value = dataGridView16.SelectedRows[i].Cells[12].Value.ToString();
                    dataGridView8.Rows[index].Cells[14].Value = dataGridView16.SelectedRows[i].Cells[13].Value.ToString();

                }

                dataGridView8.AllowUserToAddRows = false;
                dataGridView8.AllowUserToAddRows = true;
                //foreach (DataGridViewRow row in dataGridView6.SelectedRows)
                //{
                //    object[] rowData = new object[row.Cells.Count];
                //    for (int i = 0; i < row.Cells.Count; i++)
                //    {
                //        rowData[i] = row.Cells[i].Value;
                //    }
                //    dataGridView8.Rows.Add(rowData);
                //}

                foreach (DataGridViewRow sourceRow in dataGridView6.SelectedRows)
                {
                    int targetRowIndex = dataGridView8.Rows.Add();

                    foreach (DataGridViewCell cell in sourceRow.Cells)
                    {
                        int columnIndex = cell.ColumnIndex;
                        dataGridView8.Rows[targetRowIndex].Cells[columnIndex].Value = cell.Value?.ToString();
                    }
                }

                //for (int i = 0; i < dataGridView6.SelectedRows.Count; i++)
                //{
                //    int index = dataGridView8.Rows.Add();
                //    dataGridView8.Rows[index].Cells[0].Value = dataGridView6.SelectedRows[i].Cells[0].Value.ToString();
                //    dataGridView8.Rows[index].Cells[1].Value = dataGridView6.SelectedRows[i].Cells[1].Value.ToString();
                //    dataGridView8.Rows[index].Cells[2].Value = dataGridView6.SelectedRows[i].Cells[2].Value.ToString();
                //    dataGridView8.Rows[index].Cells[3].Value = dataGridView6.SelectedRows[i].Cells[3].Value.ToString();
                //    dataGridView8.Rows[index].Cells[4].Value = dataGridView6.SelectedRows[i].Cells[4].Value.ToString();
                //    dataGridView8.Rows[index].Cells[5].Value = dataGridView6.SelectedRows[i].Cells[5].Value.ToString();
                //    dataGridView8.Rows[index].Cells[6].Value = dataGridView6.SelectedRows[i].Cells[6].Value.ToString();
                //    dataGridView8.Rows[index].Cells[7].Value = dataGridView6.SelectedRows[i].Cells[7].Value.ToString();
                //    dataGridView8.Rows[index].Cells[8].Value = dataGridView6.SelectedRows[i].Cells[8].Value.ToString();
                //    dataGridView8.Rows[index].Cells[9].Value = dataGridView6.SelectedRows[i].Cells[9].Value.ToString();
                //    dataGridView8.Rows[index].Cells[10].Value = dataGridView6.SelectedRows[i].Cells[10].Value.ToString();
                //    dataGridView8.Rows[index].Cells[11].Value = dataGridView6.SelectedRows[i].Cells[11].Value.ToString();
                //    dataGridView8.Rows[index].Cells[12].Value = dataGridView6.SelectedRows[i].Cells[12].Value.ToString();
                //    dataGridView8.Rows[index].Cells[13].Value = dataGridView6.SelectedRows[i].Cells[13].Value.ToString();
                //    dataGridView8.Rows[index].Cells[14].Value = dataGridView6.SelectedRows[i].Cells[14].Value.ToString();

                //    dataGridView8.Rows[index].Cells[15].Value = dataGridView6.SelectedRows[i].Cells[15].Value.ToString();
                //    dataGridView8.Rows[index].Cells[16].Value = dataGridView6.SelectedRows[i].Cells[16].Value.ToString();
                //    dataGridView8.Rows[index].Cells[17].Value = dataGridView6.SelectedRows[i].Cells[17].Value.ToString();
                //    dataGridView8.Rows[index].Cells[18].Value = dataGridView6.SelectedRows[i].Cells[18].Value.ToString();

                //}

                dataGridView8.AllowUserToAddRows = false;

                dataGridView8.AllowUserToAddRows = true;
                for (int i = 0; i < dataGridView7.SelectedRows.Count; i++)
                {
                    int index = dataGridView8.Rows.Add();
                    dataGridView8.Rows[index].Cells[0].Value = dataGridView7.SelectedRows[i].Cells[0].Value.ToString();
                    dataGridView8.Rows[index].Cells[1].Value = dataGridView7.SelectedRows[i].Cells[1].Value.ToString();
                    dataGridView8.Rows[index].Cells[2].Value = dataGridView7.SelectedRows[i].Cells[2].Value.ToString();
                    dataGridView8.Rows[index].Cells[3].Value = dataGridView7.SelectedRows[i].Cells[3].Value.ToString();
                    dataGridView8.Rows[index].Cells[4].Value = dataGridView7.SelectedRows[i].Cells[4].Value.ToString();
                    dataGridView8.Rows[index].Cells[5].Value = dataGridView7.SelectedRows[i].Cells[5].Value.ToString();
                    dataGridView8.Rows[index].Cells[6].Value = dataGridView7.SelectedRows[i].Cells[6].Value.ToString();
                    dataGridView8.Rows[index].Cells[7].Value = dataGridView7.SelectedRows[i].Cells[7].Value.ToString();
                    dataGridView8.Rows[index].Cells[8].Value = dataGridView7.SelectedRows[i].Cells[8].Value.ToString();
                    dataGridView8.Rows[index].Cells[9].Value = dataGridView7.SelectedRows[i].Cells[9].Value.ToString();
                    dataGridView8.Rows[index].Cells[10].Value = dataGridView7.SelectedRows[i].Cells[10].Value.ToString();
                    dataGridView8.Rows[index].Cells[11].Value = dataGridView7.SelectedRows[i].Cells[11].Value.ToString();
                    dataGridView8.Rows[index].Cells[12].Value = dataGridView7.SelectedRows[i].Cells[12].Value.ToString();
                    dataGridView8.Rows[index].Cells[13].Value = dataGridView7.SelectedRows[i].Cells[13].Value.ToString();

                }

                dataGridView8.AllowUserToAddRows = false;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView8.Rows)
                {

                    com.Parameters.Clear();
                    com.CommandText = "Insert Into TBL_ShowMenue_Report (RestrictionKind_ID,FinancialMenuSetting_ID,FinancialMenuNameID,MenuName,TotalDue_Blus,TotalDue_Min,TotalCash_Blus,TotalCash_Min,SortingItems,Parent_ID,Name,sortRestriction,RestrictionItemsCategory_ID,UserName,TotalDue_Blus3,TotalDue_Min3,TotalDue_Blus4,TotalDue_Min4)Values(@RestrictionKind_ID,@FinancialMenuSetting_ID,@FinancialMenuNameID,@MenuName,@TotalDue_Blus,@TotalDue_Min,@TotalCash_Blus,@TotalCash_Min,@SortingItems,@Parent_ID,@Name,@sortRestriction,@RestrictionItemsCategory_ID,@UserName,@TotalDue_Blus3,@TotalDue_Min3,@TotalDue_Blus4,@TotalDue_Min4)";

                    if (row.Cells[1].Value != string.Empty)
                    {
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[1].Value);
                    }
                    if (row.Cells[1].Value == string.Empty)
                    {
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (row.Cells[2].Value != string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[2].Value);
                    }
                    if (row.Cells[2].Value == string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (row.Cells[3].Value != string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[3].Value);
                    }
                    if (row.Cells[3].Value == string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    if (row.Cells[4].Value != string.Empty)
                    {
                        com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                    }
                    if (row.Cells[4].Value == string.Empty)
                    {
                        com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    if (row.Cells[5].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[5].Value);
                    }
                    if (row.Cells[5].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[6].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[6].Value);
                    }
                    if (row.Cells[6].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[7].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[7].Value);
                    }
                    if (row.Cells[7].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[8].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[8].Value);
                    }
                    if (row.Cells[8].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[9].Value != string.Empty)
                    {
                        com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = row.Cells[9].Value;
                    }
                    if (row.Cells[9].Value == string.Empty)
                    {
                        com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    if (row.Cells[10].Value != string.Empty)
                    {
                        com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    }
                    if (row.Cells[10].Value == string.Empty)
                    {
                        com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (row.Cells[11].Value != string.Empty)
                    {
                        com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = row.Cells[11].Value;
                    }
                    if (row.Cells[11].Value == string.Empty)
                    {
                        com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    if (row.Cells[12].Value != string.Empty)
                    {
                        com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[12].Value);
                    }
                    if (row.Cells[12].Value == string.Empty)
                    {
                        com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (row.Cells[13].Value != string.Empty)
                    {
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[13].Value);
                    }

                    if (row.Cells[13].Value == string.Empty)
                    {
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    com.Parameters.Add("@UserName", SqlDbType.NVarChar ).Value = Program.GlbV_UserName;
                    if (row.Cells[15].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus3", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[15].Value);
                    }
                    if (row.Cells[15].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus3", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[16].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min3", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[16].Value);
                    }
                    if (row.Cells[16].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min3", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[17].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus4", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[17].Value);
                    }
                    if (row.Cells[17].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus4", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[18].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min4", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[18].Value);
                    }
                    if (row.Cells[18].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min4", SqlDbType.Decimal).Value = "0";
                    }
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                }
                dataGridView8.Rows.Clear();
                simpleButton2_Click(sender, e);
                    dataGridView25.SelectAll();
                    dataGridView8.AllowUserToAddRows = true;
                    for (int i = 0; i < dataGridView25.SelectedRows.Count; i++)
                    {
                        int index = dataGridView8.Rows.Add();
                        //dataGridView8.Rows[index].Cells[0].Value = dataGridView25.SelectedRows[i].Cells[0].Value.ToString();
                        dataGridView8.Rows[index].Cells[1].Value = dataGridView25.SelectedRows[i].Cells[1].Value.ToString();
                        dataGridView8.Rows[index].Cells[2].Value = dataGridView25.SelectedRows[i].Cells[2].Value.ToString();
                        dataGridView8.Rows[index].Cells[3].Value = dataGridView25.SelectedRows[i].Cells[3].Value.ToString();
                        dataGridView8.Rows[index].Cells[4].Value = dataGridView25.SelectedRows[i].Cells[4].Value.ToString();
                        dataGridView8.Rows[index].Cells[5].Value = dataGridView25.SelectedRows[i].Cells[5].Value.ToString();
                        dataGridView8.Rows[index].Cells[6].Value = dataGridView25.SelectedRows[i].Cells[6].Value.ToString();
                        dataGridView8.Rows[index].Cells[7].Value = dataGridView25.SelectedRows[i].Cells[7].Value.ToString();
                        dataGridView8.Rows[index].Cells[8].Value = dataGridView25.SelectedRows[i].Cells[8].Value.ToString();
                        dataGridView8.Rows[index].Cells[9].Value = dataGridView25.SelectedRows[i].Cells[9].Value.ToString();
                        dataGridView8.Rows[index].Cells[10].Value = dataGridView25.SelectedRows[i].Cells[10].Value.ToString();
                        dataGridView8.Rows[index].Cells[11].Value = dataGridView25.SelectedRows[i].Cells[11].Value.ToString();
                        dataGridView8.Rows[index].Cells[12].Value = dataGridView25.SelectedRows[i].Cells[12].Value.ToString();
                        dataGridView8.Rows[index].Cells[14].Value = dataGridView25.SelectedRows[i].Cells[13].Value.ToString();

                    }


                    dataGridView8.AllowUserToAddRows = false;
                foreach (DataGridViewRow row in dataGridView8.Rows)
                {

                    com.Parameters.Clear();
                    com.CommandText = "Insert Into TBL_ShowMenue_Report (RestrictionKind_ID,FinancialMenuSetting_ID,FinancialMenuNameID,MenuName,TotalDue_Blus,TotalDue_Min,TotalCash_Blus,TotalCash_Min,SortingItems,Parent_ID,Name,sortRestriction,RestrictionItemsCategory_ID,UserName)Values(@RestrictionKind_ID,@FinancialMenuSetting_ID,@FinancialMenuNameID,@MenuName,@TotalDue_Blus,@TotalDue_Min,@TotalCash_Blus,@TotalCash_Min,@SortingItems,@Parent_ID,@Name,@sortRestriction,@RestrictionItemsCategory_ID,@UserName)";

                    if (row.Cells[1].Value != string.Empty)
                    {
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[1].Value);
                    }
                    if (row.Cells[1].Value == string.Empty)
                    {
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (row.Cells[2].Value != string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[2].Value);
                    }
                    if (row.Cells[2].Value == string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (row.Cells[3].Value != string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[3].Value);
                    }
                    if (row.Cells[3].Value == string.Empty)
                    {
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                    if (row.Cells[4].Value != string.Empty)
                    {
                        com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                    }
                    if (row.Cells[4].Value == string.Empty)
                    {
                        com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    if (row.Cells[5].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[5].Value);
                    }
                    if (row.Cells[5].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[6].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[6].Value);
                    }
                    if (row.Cells[6].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[7].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[7].Value);
                    }
                    if (row.Cells[7].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[8].Value != string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[8].Value);
                    }
                    if (row.Cells[8].Value == string.Empty)
                    {
                        com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = "0";
                    }
                    if (row.Cells[9].Value != string.Empty)
                    {
                        com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = row.Cells[9].Value;
                    }
                    if (row.Cells[9].Value == string.Empty)
                    {
                        com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    if (row.Cells[10].Value != string.Empty)
                    {
                        com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                    }
                    if (row.Cells[10].Value == string.Empty)
                    {
                        com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (row.Cells[11].Value != string.Empty)
                    {
                        com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = row.Cells[11].Value;
                    }
                    if (row.Cells[11].Value == string.Empty)
                    {
                        com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    if (row.Cells[12].Value != string.Empty)
                    {
                        com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[12].Value);
                    }
                    if (row.Cells[12].Value == string.Empty)
                    {
                        com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = DBNull.Value;
                    }
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                    com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                }
                splashScreenManager1.CloseWaitForm();
                    PrintMenue p = new PrintMenue();
                    p.StartPosition = FormStartPosition.CenterScreen;
                    p.textBox1.Text = comboBox1.Text;
                    p.textBox2.Text = textBox20.Text;
                p.textBox3.Text = textBox30.Text;
                p.textBox4.Text = textBox31.Text;


                p.textBox5.Text = textBox33.Text;
                p.textBox6.Text = textBox32.Text;
                p.TCount.Text  = textBox29.Text;
                p.textBox17.Text = textBox17.Text;
                    p.ShowDialog();
                }
                else
                {
                    MessageBox.Show("من فضلك أختر إجمالى أو الصافى");
                }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                checkEdit2.Checked = false;
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                checkEdit1.Checked = false;
            }
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit4.Checked == true)
            {
                checkEdit3.Checked = false;
            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit3.Checked == true)
            {
                checkEdit4.Checked = false;
            }
        }

        private void checkEdit6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit6.Checked == true)
            {
                checkEdit5.Checked = false;
            }
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit5.Checked == true)
            {
                checkEdit6.Checked = false;
            }
        }

        private void checkEdit8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit8.Checked == true)
            {
                checkEdit7.Checked = false;
            }
        }

        private void checkEdit7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit7.Checked == true)
            {
                checkEdit8.Checked = false;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.AllowUserToAddRows = true;
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int index = dataGridView3.Rows.Add();
                    dataGridView3.Rows[index].Cells[0].Value = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
                    dataGridView3.Rows[index].Cells[1].Value = dataGridView1.SelectedRows[i].Cells[1].Value.ToString();
                    dataGridView3.Rows[index].Cells[2].Value = dataGridView1.SelectedRows[i].Cells[2].Value.ToString();
                    dataGridView3.Rows[index].Cells[3].Value = dataGridView1.SelectedRows[i].Cells[3].Value.ToString();
                    dataGridView3.Rows[index].Cells[4].Value = dataGridView1.SelectedRows[i].Cells[4].Value.ToString();
                    dataGridView3.Rows[index].Cells[5].Value = dataGridView1.SelectedRows[i].Cells[5].Value.ToString();
                    dataGridView3.Rows[index].Cells[6].Value = dataGridView1.SelectedRows[i].Cells[6].Value.ToString();
                    dataGridView3.Rows[index].Cells[7].Value = dataGridView1.SelectedRows[i].Cells[7].Value.ToString();
                    dataGridView3.Rows[index].Cells[8].Value = dataGridView1.SelectedRows[i].Cells[8].Value.ToString();
                    dataGridView3.Rows[index].Cells[9].Value = dataGridView1.SelectedRows[i].Cells[9].Value.ToString();
                    dataGridView3.Rows[index].Cells[10].Value = dataGridView1.SelectedRows[i].Cells[10].Value.ToString();
                    dataGridView3.Rows[index].Cells[11].Value = dataGridView1.SelectedRows[i].Cells[11].Value.ToString();
                    dataGridView3.Rows[index].Cells[12].Value = dataGridView1.SelectedRows[i].Cells[12].Value.ToString();
                    dataGridView3.Rows[index].Cells[13].Value = dataGridView1.SelectedRows[i].Cells[13].Value.ToString();

                }

                dataGridView3.AllowUserToAddRows = false;
                MessageBox.Show("تم التـــرحيل بنجاح");
            }
            catch
            {
                MessageBox.Show("الرجاء اختر القائمة وحدد البند واليومية أولا");
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView4.AllowUserToAddRows = true;
                for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
                {
                    int index = dataGridView4.Rows.Add();
                    dataGridView4.Rows[index].Cells[0].Value = dataGridView2.SelectedRows[i].Cells[0].Value.ToString();
                    dataGridView4.Rows[index].Cells[1].Value = dataGridView2.SelectedRows[i].Cells[1].Value.ToString();
                    dataGridView4.Rows[index].Cells[2].Value = dataGridView2.SelectedRows[i].Cells[2].Value.ToString();
                    dataGridView4.Rows[index].Cells[3].Value = dataGridView2.SelectedRows[i].Cells[3].Value.ToString();
                    dataGridView4.Rows[index].Cells[4].Value = dataGridView2.SelectedRows[i].Cells[4].Value.ToString();
                    dataGridView4.Rows[index].Cells[5].Value = dataGridView2.SelectedRows[i].Cells[5].Value.ToString();
                    dataGridView4.Rows[index].Cells[6].Value = dataGridView2.SelectedRows[i].Cells[6].Value.ToString();
                    dataGridView4.Rows[index].Cells[7].Value = dataGridView2.SelectedRows[i].Cells[7].Value.ToString();
                    dataGridView4.Rows[index].Cells[8].Value = dataGridView2.SelectedRows[i].Cells[8].Value.ToString();
                    dataGridView4.Rows[index].Cells[9].Value = dataGridView2.SelectedRows[i].Cells[9].Value.ToString();
                    dataGridView4.Rows[index].Cells[10].Value = dataGridView2.SelectedRows[i].Cells[10].Value.ToString();
                    dataGridView4.Rows[index].Cells[11].Value = dataGridView2.SelectedRows[i].Cells[11].Value.ToString();
                    dataGridView4.Rows[index].Cells[12].Value = dataGridView2.SelectedRows[i].Cells[12].Value.ToString();
                    dataGridView4.Rows[index].Cells[13].Value = dataGridView2.SelectedRows[i].Cells[13].Value.ToString();

                }

                dataGridView4.AllowUserToAddRows = false;
                MessageBox.Show("تم التـــرحيل بنجاح");
            }
            catch
            {
                MessageBox.Show("الرجاء اختر القائمة وحدد البند واليومية أولا");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChildAccount();
        }
        public void TransfareITEMS()
        {


        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView7.SelectAll();
            dataGridView6.SelectAll();
            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView6.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                dataGridView8.Rows[index].Cells[0].Value = dataGridView6.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView6.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView6.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView6.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView6.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView6.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView6.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView6.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView6.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView6.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView6.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView6.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView6.SelectedRows[i].Cells[12].Value.ToString();
                //dataGridView8.Rows[index].Cells[13].Value = dataGridView1.SelectedRows[i].Cells[13].Value.ToString();

            }

            dataGridView8.AllowUserToAddRows = false;

            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView7.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                dataGridView8.Rows[index].Cells[0].Value = dataGridView7.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView7.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView7.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView7.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView7.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView7.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView7.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView7.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView7.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView7.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView7.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView7.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView7.SelectedRows[i].Cells[12].Value.ToString();
                dataGridView8.Rows[index].Cells[13].Value = dataGridView7.SelectedRows[i].Cells[13].Value.ToString();

            }

            dataGridView8.AllowUserToAddRows = false;
        }
        private void DeleteReport()
        {
            if (dataGridView8.Rows.Count > 0)
            {
                dataGridView8.Rows.Clear();
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = "delete from TBL_ShowMenue_Report where UserName=@UserName ";
            com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            DeleteReport();
            this.menueWithCategoryTableAdapter.Fill(this.dataSet1.MenueWithCategory);
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            dataGridView7.SelectAll();
            dataGridView6.SelectAll();
            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView6.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                dataGridView8.Rows[index].Cells[0].Value = dataGridView6.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView6.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView6.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView6.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView6.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView6.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView6.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView6.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView6.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView6.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView6.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView6.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView6.SelectedRows[i].Cells[12].Value.ToString();
                //dataGridView8.Rows[index].Cells[13].Value = dataGridView1.SelectedRows[i].Cells[13].Value.ToString();

            }

            dataGridView8.AllowUserToAddRows = false;

            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView7.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                dataGridView8.Rows[index].Cells[0].Value = dataGridView7.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView7.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView7.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView7.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView7.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView7.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView7.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView7.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView7.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView7.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView7.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView7.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView7.SelectedRows[i].Cells[12].Value.ToString();
                dataGridView8.Rows[index].Cells[13].Value = dataGridView7.SelectedRows[i].Cells[13].Value.ToString();

            }

            dataGridView8.AllowUserToAddRows = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView8.Rows)
            {

                com.Parameters.Clear();
                //row.Cells[5].Value = MAXID.Text;
                com.CommandText = "Insert Into TBL_ShowMenue_Report (RestrictionKind_ID,FinancialMenuSetting_ID,FinancialMenuNameID,MenuName,TotalDue_Blus,TotalDue_Min,TotalCash_Blus,TotalCash_Min,SortingItems,Parent_ID,Name,sortRestriction,RestrictionItemsCategory_ID)Values(@RestrictionKind_ID,@FinancialMenuSetting_ID,@FinancialMenuNameID,@MenuName,@TotalDue_Blus,@TotalDue_Min,@TotalCash_Blus,@TotalCash_Min,@SortingItems,@Parent_ID,@Name,@sortRestriction,@RestrictionItemsCategory_ID)";

                if (row.Cells[1].Value != string.Empty)
                {
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[1].Value);
                }
                if (row.Cells[1].Value == string.Empty)
                {
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[2].Value != string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[2].Value);
                }
                if (row.Cells[2].Value == string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[3].Value != string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[3].Value);
                }
                if (row.Cells[3].Value == string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = DBNull.Value;
                }
                if (row.Cells[4].Value != string.Empty)
                {
                    com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                }
                if (row.Cells[4].Value == string.Empty)
                {
                    com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[5].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[5].Value);
                }
                if (row.Cells[5].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[6].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[6].Value);
                }
                if (row.Cells[6].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[7].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[7].Value);
                }
                if (row.Cells[7].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[8].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[8].Value);
                }
                if (row.Cells[8].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[9].Value != string.Empty)
                {
                    com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = row.Cells[9].Value;
                }
                if (row.Cells[9].Value == string.Empty)
                {
                    com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[10].Value != string.Empty)
                {
                    com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                }
                if (row.Cells[10].Value == string.Empty)
                {
                    com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[11].Value != string.Empty)
                {
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = row.Cells[11].Value;
                }
                if (row.Cells[11].Value == string.Empty)
                {
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[12].Value != string.Empty)
                {
                    com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[12].Value);
                }
                if (row.Cells[12].Value == string.Empty)
                {
                    com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[13].Value != string.Empty)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[13].Value);
                }

                if (row.Cells[13].Value == string.Empty)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            //}
            //catch { }
        }
        private void SaveDeuBlusCategory()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView9.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn4"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuCategoryDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue,DuePaymentCridetValue,FinancialMenuNameID,DuePayment,RestrictionItemsCategory_ID) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItemsCategory_ID)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView9.Rows.Count; i++)
                {
                    dataGridView9.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveCashBlusCategory()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView12.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn7"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuCategoryDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue,CashPaymentCridetValue,FinancialMenuNameID,CashPayment,RestrictionItemsCategory_ID) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItemsCategory_ID)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView12.Rows.Count; i++)
                {
                    dataGridView12.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveCashMinCategory()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView11.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn6"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuCategoryDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,CashPaymentDebitValue1,CashPaymentCridetValue1,FinancialMenuNameID,CashPayment,RestrictionItemsCategory_ID) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItemsCategory_ID)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView11.Rows.Count; i++)
                {
                    dataGridView11.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void SaveDeuNegativCategory()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
                SqlCommand com = new SqlCommand();
                SqlCommand com1 = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com1.Connection = con;
                com1.CommandType = CommandType.Text;
                foreach (DataGridViewRow row in dataGridView10.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["dataGridViewCheckBoxColumn5"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                        //row.Cells[5].Value = MAXID.Text;
                        com.CommandText = ("Insert Into Tbl_FinancialMenuCategoryDuePaymentBlus(RestrictionKind_ID,Account_Guid_ID,DateFrom,DateTo,FinancialMenuSetting_ID,DuePaymentDebitValue1,DuePaymentCridetValue1,FinancialMenuNameID,DuePayment,RestrictionItemsCategory_ID) values(@RestrictionKind_ID,@Account_Guid_ID,@DateFrom,@DateTo,@FinancialMenuSetting_ID,@DuePaymentDebitValue,@DuePaymentCridetValue,@FinancialMenuNameID,@DuePayment,@RestrictionItemsCategory_ID)");
                        com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);

                        com.Parameters.Add("@Account_Guid_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                        com.Parameters.Add("@DateFrom", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[11].Value);
                        com.Parameters.Add("@DateTo", SqlDbType.Date).Value = Convert.ToDateTime(row.Cells[12].Value);

                        com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                        com.Parameters.Add("@DuePaymentDebitValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[8].Value);
                        com.Parameters.Add("@DuePaymentCridetValue", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[9].Value);
                        com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[7].Value);
                        com.Parameters.Add("@DuePayment", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                        com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[15].Value);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                }
                for (int i = 0; i < dataGridView10.Rows.Count; i++)
                {
                    dataGridView10.Rows[i].Cells[13].Value = false;
                }
            }
            catch { MessageBox.Show("الرجاء قم باختيار القائمة ونوع اليومية وإدخال البيانات بشكل صحيح"); }
        }
        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                FindRestrictionCategorywithAccount f = new FindRestrictionCategorywithAccount();
                f.ShowDialog();
                AccID.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[0].Value.ToString();
                textBox12.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[1].Value.ToString();
                textBox11.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[3].Value.ToString();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit11.Checked == true || checkEdit13.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{

                        dataGridView9.Rows.Add(textBox1.Text, textBox11.Text, comboBox6.Text, IDParenttxtBox.Text, AccID.Text, comboBox6.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit13.EditValue, checkEdit11.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, textBox12.Text);
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }

        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                FindRestrictionCategorywithAccount f = new FindRestrictionCategorywithAccount();
                f.ShowDialog();
                AccID.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[0].Value.ToString();
                textBox12.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[1].Value.ToString();
                textBox13.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[3].Value.ToString();

            }

            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit17.Checked == true || checkEdit15.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{

                        dataGridView10.Rows.Add(textBox1.Text, textBox13.Text, comboBox7.Text, IDParenttxtBox.Text, AccID.Text, comboBox7.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit17.EditValue, checkEdit15.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, textBox12.Text);
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void checkEdit13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit13.Checked == true)
            {
                checkEdit11.Checked = false;
            }
        }

        private void checkEdit11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit11.Checked == true)
            {
                checkEdit13.Checked = false;
            }
        }

        private void checkEdit17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit17.Checked == true)
            {
                checkEdit15.Checked = false;
            }
        }

        private void checkEdit15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit15.Checked == true)
            {
                checkEdit17.Checked = false;
            }
        }

        private void ultraTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                FindRestrictionCategorywithAccount f = new FindRestrictionCategorywithAccount();
                f.ShowDialog();
                AccID.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[0].Value.ToString();
                textBox12.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[1].Value.ToString();
                textBox15.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[3].Value.ToString();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit20.Checked == true || checkEdit19.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{

                        dataGridView12.Rows.Add(textBox1.Text, textBox15.Text, comboBox9.Text, IDParenttxtBox.Text, AccID.Text, comboBox9.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit20.EditValue, checkEdit19.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, textBox12.Text);
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                FindRestrictionCategorywithAccount f = new FindRestrictionCategorywithAccount();
                f.ShowDialog();
                AccID.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[0].Value.ToString();
                textBox12.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[1].Value.ToString();
                textBox14.Text = FindRestrictionCategorywithAccount.SelectedRow.Cells[3].Value.ToString();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit18.Checked == true || checkEdit9.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{

                        dataGridView11.Rows.Add(textBox1.Text, textBox14.Text, comboBox8.Text, IDParenttxtBox.Text, AccID.Text, comboBox8.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit18.EditValue, checkEdit9.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, textBox12.Text);
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView4.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void checkEdit20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit20.Checked == true)
            {
                checkEdit19.Checked = false;
            }
        }

        private void checkEdit19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit19.Checked == true)
            {
                checkEdit20.Checked = false;
            }
        }

        private void checkEdit18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit18.Checked == true)
            {
                checkEdit9.Checked = false;
            }
        }

        private void checkEdit9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit9.Checked == true)
            {
                checkEdit18.Checked = false;
            }
        }

        private void checkEdit21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit21.Checked == true)
            {
                checkEdit22.Checked = false;
                textBox17.Text = "إجمالى";
            }
        }

        private void checkEdit22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit22.Checked == true)
            {
                checkEdit21.Checked = false;
                textBox17.Text = "الصافى";
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox11.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox19.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }

                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit27.Checked == true || checkEdit25.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView13.Rows.Add(textBox1.Text, textBox19.Text, comboBox11.Text, IDParenttxtBox.Text, AccID.Text, comboBox11.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit27.EditValue, checkEdit25.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());

                        }
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox10.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox18.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit28.Checked == true || checkEdit26.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView14.Rows.Add(textBox1.Text, textBox18.Text, comboBox10.Text, IDParenttxtBox.Text, AccID.Text, comboBox10.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit28.EditValue, checkEdit26.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void checkEdit24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit24.Checked == true)
            {
                textBox20.Text = "1";
            }
            if (checkEdit24.Checked == false)
            {
                textBox20.Text = "2";
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox12.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox21.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }

                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit23.Checked == true || checkEdit30.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView18.Rows.Add(textBox1.Text, textBox21.Text, comboBox12.Text, IDParenttxtBox.Text, AccID.Text, comboBox12.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit23.EditValue, checkEdit30.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());

                        }
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox13.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox22.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }

                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit31.Checked == true || checkEdit29.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView17.Rows.Add(textBox1.Text, textBox22.Text, comboBox13.Text, IDParenttxtBox.Text, AccID.Text, comboBox13.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit31.EditValue, checkEdit29.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());

                        }
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox16.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox25.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }

                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit36.Checked == true || checkEdit35.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView22.Rows.Add(textBox1.Text, textBox25.Text, comboBox16.Text, IDParenttxtBox.Text, AccID.Text, comboBox16.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit36.EditValue, checkEdit35.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());

                        }
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox17.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox26.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }

                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit39.Checked == true || checkEdit37.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView21.Rows.Add(textBox1.Text, textBox26.Text, comboBox17.Text, IDParenttxtBox.Text, AccID.Text, comboBox17.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit39.EditValue, checkEdit37.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());

                        }
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox14.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox23.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }

                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit32.Checked == true || checkEdit34.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView20.Rows.Add(textBox1.Text, textBox23.Text, comboBox14.Text, IDParenttxtBox.Text, AccID.Text, comboBox14.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit32.EditValue, checkEdit34.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());

                        }
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    dataGridView15.Rows.Clear();
                    GetAccountByAccountFrm f = new GetAccountByAccountFrm();
                    f.dateTimePicker1.Value = this.dateTimePicker1.Value;
                    f.dateTimePicker2.Value = this.dateTimePicker2.Value;
                    f.dateTimePicker1.Enabled = false;
                    f.dateTimePicker2.Enabled = false;
                    f.comboBox2.DataSource = getDay();
                    f.comboBox2.DisplayMember = "Name";
                    f.comboBox2.ValueMember = "ID";
                    f.comboBox2.SelectedValue = comboBox15.SelectedValue;
                    f.comboBox2.Enabled = false;
                    f.ShowDialog();
                    AccID.Text = GetAccountByAccountFrm.SelectedRow.Cells[6].Value.ToString();
                    //textBox12.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    textBox24.Text = GetAccountByAccountFrm.SelectedRow.Cells[1].Value.ToString();
                    foreach (DataGridViewRow row in f.dataGridView4.Rows)
                    {
                        //if (row.Cells[1].Value.ToString() == textBox5.Text)
                        //{
                        dataGridView15.Rows.Add(row.Cells[5].Value);
                        //}
                    }

                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit35.Checked == true || checkEdit33.Checked == true)
                {
                    try


                    {
                        //if (checkEdit10.Checked == true)
                        //{
                        //    for (int x = 1; x < dataGridView5.Rows.Count; x++)
                        //    {
                        //        dataGridView1.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox2.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox2.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit1.EditValue, checkEdit2.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        //    }
                        //}
                        //if (checkEdit10.Checked == false)
                        //{
                        foreach (DataGridViewRow row in dataGridView15.Rows)
                        {
                            dataGridView19.Rows.Add(textBox1.Text, textBox24.Text, comboBox15.Text, IDParenttxtBox.Text, AccID.Text, comboBox15.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit35.EditValue, checkEdit33.EditValue, 1, dateTimePicker1.Value, dateTimePicker2.Value, true, 0, row.Cells[0].Value.ToString());

                        }
                        //}
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintMenue p = new PrintMenue();
            p.StartPosition = FormStartPosition.CenterScreen;
            p.textBox1.Text = comboBox1.Text;
            p.textBox2.Text = textBox20.Text;
            p.textBox17.Text = textBox17.Text;
            p.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.finalMenueLinkFunctionTableAdapter.Fill(this.dataSet13.FinalMenueLinkFunction);

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[15].Value) == true)
                {
                    //dataGridView1.CurrentRow.Cells[13].Value = true;
                }

            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (e.ColumnIndex == 15)
            //{
            //    if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[15].Value) == true)
            //    {
            //        dataGridView1.CurrentRow.Cells[13].Value = true;
            //    }
            //}
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 15)
            {
                LinkedFinancialMenu f = new LinkedFinancialMenu();
                f.ShowDialog();
                textBox27.Text = f.SelectParent_ID.ToString();
                textBox28.Text = f.SelectMenue_ID.ToString();


            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            //id=cell 14
            //link = cell 15

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[15].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Update Tbl_FinancialMenuAccountsDuePaymentBlus set Transfare_FinancialMenuNameID=@Transfare_FinancialMenuNameID,Transfare_FinancialMenuSetting_ID=@Transfare_FinancialMenuSetting_ID where ID=@ID");
                    com.Parameters.Add("@Transfare_FinancialMenuNameID", SqlDbType.Int).Value = Convert.ToInt32(textBox28.Text);

                    com.Parameters.Add("@Transfare_FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(textBox27.Text);
                    com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[14].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                  
                }
            }
            for(int x=0;x<dataGridView1.Rows.Count;x++)
            {
                dataGridView1.Rows[x].Cells[15].Value = false;
            }
            MessageBox.Show("تم الربط بنجاح");
        }

        private void textBox27_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            LinkedFinancialMenu f = new LinkedFinancialMenu();
            f.ShowDialog();
        }
        //*******************************
        //*******************************
        //*******************************


        private void PopulateDataGridView8(DataGridView sourceGridView)
        {
            dataGridView8.AllowUserToAddRows = true;
            foreach (DataGridViewRow row in sourceGridView.SelectedRows)
            {
                int index = dataGridView8.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dataGridView8.Rows[index].Cells[i].Value = row.Cells[i].Value;
                }
            }
            dataGridView8.AllowUserToAddRows = false ;
        }

        // Insert data from dataGridView8 into the database
        private void InsertDataIntoDatabase()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString))
            {
                con.Open();
                foreach (DataGridViewRow row in dataGridView8.Rows)
                {
                    using (SqlCommand com = new SqlCommand("Insert Into TBL_ShowMenue_Report (RestrictionKind_ID, FinancialMenuSetting_ID, FinancialMenuNameID, MenuName, TotalDue_Blus, TotalDue_Min, TotalCash_Blus, TotalCash_Min, SortingItems, Parent_ID, Name, sortRestriction, RestrictionItemsCategory_ID, UserName) Values (@RestrictionKind_ID, @FinancialMenuSetting_ID, @FinancialMenuNameID, @MenuName, @TotalDue_Blus, @TotalDue_Min, @TotalCash_Blus, @TotalCash_Min, @SortingItems, @Parent_ID, @Name, @sortRestriction, @RestrictionItemsCategory_ID, @UserName)", con))
                    {
                        com.Parameters.AddWithValue("@RestrictionKind_ID", GetIntValue(row.Cells[1].Value));
                        com.Parameters.AddWithValue("@FinancialMenuSetting_ID", GetIntValue(row.Cells[2].Value));
                        com.Parameters.AddWithValue("@FinancialMenuNameID", GetDecimalValue(row.Cells[3].Value));
                        com.Parameters.AddWithValue("@MenuName", row.Cells[4].Value);
                        com.Parameters.AddWithValue("@TotalDue_Blus", GetDecimalValue(row.Cells[5].Value));
                        com.Parameters.AddWithValue("@TotalDue_Min", GetDecimalValue(row.Cells[6].Value));
                        com.Parameters.AddWithValue("@TotalCash_Blus", GetDecimalValue(row.Cells[7].Value));
                        com.Parameters.AddWithValue("@TotalCash_Min", GetDecimalValue(row.Cells[8].Value));
                        com.Parameters.AddWithValue("@SortingItems", row.Cells[9].Value);
                        com.Parameters.AddWithValue("@Parent_ID", GetIntValue(row.Cells[10].Value));
                        com.Parameters.AddWithValue("@Name", row.Cells[11].Value);
                        com.Parameters.AddWithValue("@sortRestriction", GetIntValue(row.Cells[12].Value));
                        com.Parameters.AddWithValue("@RestrictionItemsCategory_ID", GetIntValue(row.Cells[13].Value));
                        com.Parameters.AddWithValue("@UserName", Program.GlbV_UserName);
                        com.ExecuteNonQuery();
                    }
                }
            }
        }

        // Helper method to convert object to integer safely
       

        private int GetIntValue(object value)
        {
            int result;
            return value != null && int.TryParse(value.ToString(), out  result) ? result : 0;
        }

        // Helper method to convert object to decimal safely
        private decimal GetDecimalValue(object value)
        {
            decimal result;
            return value != null && decimal.TryParse(value.ToString(), out  result) ? result : 0;
        }


        private void RunReport()
        {
            this.linkedMenuAccountCategoryTableAdapter.Fill(this.dataSet1.LinkedMenuAccountCategory);
            this.linkedMenueTableAdapter.FillLink(this.dataSet12.LinkedMenue);
            this.linkedMenueTableAdapter.FillLink(this.dataSet1.LinkedMenue);
            this.menueWithCategoryTableAdapter.Fill(this.dataSet1.MenueWithCategory);
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            dataGridView8.AllowUserToAddRows = true;
            dataGridView7.SelectAll();
            dataGridView6.SelectAll();
            dataGridView16.SelectAll();
            PopulateDataGridView8(dataGridView16);
            PopulateDataGridView8(dataGridView6);
            PopulateDataGridView8(dataGridView7);
            PopulateDataGridView8(dataGridView25);
            dataGridView8.AllowUserToAddRows = false;
            InsertDataIntoDatabase();

            PrintMenue p = new PrintMenue();
            p.StartPosition = FormStartPosition.CenterScreen;
            p.textBox1.Text = comboBox1.Text;
            p.textBox2.Text = textBox20.Text;
            p.textBox17.Text = textBox17.Text;
            p.ShowDialog();
        }
        //*******************************
        //*******************************
        //*******************************
        private void button5_Click(object sender, EventArgs e)
        {
            DeleteReport();
            this.linkedMenuAccountCategoryTableAdapter.Fill(this.dataSet1.LinkedMenuAccountCategory);

            this.linkedMenueTableAdapter.FillLink(this.dataSet12.LinkedMenue);

            this.linkedMenueTableAdapter.FillLink(this.dataSet1.LinkedMenue);
            this.menueWithCategoryTableAdapter.Fill(this.dataSet1.MenueWithCategory);
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            dataGridView7.SelectAll();
            dataGridView6.SelectAll();
            dataGridView16.SelectAll();
            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView16.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                dataGridView8.Rows[index].Cells[0].Value = dataGridView16.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView16.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView16.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView16.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView16.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView16.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView16.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView16.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView16.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView16.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView16.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView16.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView16.SelectedRows[i].Cells[12].Value.ToString();
                dataGridView8.Rows[index].Cells[14].Value = dataGridView16.SelectedRows[i].Cells[13].Value.ToString();

            }

            dataGridView8.AllowUserToAddRows = false;
            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView6.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                dataGridView8.Rows[index].Cells[0].Value = dataGridView6.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView6.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView6.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView6.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView6.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView6.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView6.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView6.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView6.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView6.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView6.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView6.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView6.SelectedRows[i].Cells[12].Value.ToString();

            }

            dataGridView8.AllowUserToAddRows = false;

            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView7.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                dataGridView8.Rows[index].Cells[0].Value = dataGridView7.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView7.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView7.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView7.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView7.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView7.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView7.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView7.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView7.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView7.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView7.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView7.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView7.SelectedRows[i].Cells[12].Value.ToString();
                dataGridView8.Rows[index].Cells[13].Value = dataGridView7.SelectedRows[i].Cells[13].Value.ToString();

            }

            dataGridView8.AllowUserToAddRows = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            foreach (DataGridViewRow row in dataGridView8.Rows)
            {

                com.Parameters.Clear();
                com.CommandText = "Insert Into TBL_ShowMenue_Report (RestrictionKind_ID,FinancialMenuSetting_ID,FinancialMenuNameID,MenuName,TotalDue_Blus,TotalDue_Min,TotalCash_Blus,TotalCash_Min,SortingItems,Parent_ID,Name,sortRestriction,RestrictionItemsCategory_ID,UserName)Values(@RestrictionKind_ID,@FinancialMenuSetting_ID,@FinancialMenuNameID,@MenuName,@TotalDue_Blus,@TotalDue_Min,@TotalCash_Blus,@TotalCash_Min,@SortingItems,@Parent_ID,@Name,@sortRestriction,@RestrictionItemsCategory_ID,@UserName)";

                if (row.Cells[1].Value != string.Empty)
                {
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[1].Value);
                }
                if (row.Cells[1].Value == string.Empty)
                {
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[2].Value != string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[2].Value);
                }
                if (row.Cells[2].Value == string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[3].Value != string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[3].Value);
                }
                if (row.Cells[3].Value == string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = DBNull.Value;
                }
                if (row.Cells[4].Value != string.Empty)
                {
                    com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                }
                if (row.Cells[4].Value == string.Empty)
                {
                    com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[5].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[5].Value);
                }
                if (row.Cells[5].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[6].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[6].Value);
                }
                if (row.Cells[6].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[7].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[7].Value);
                }
                if (row.Cells[7].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[8].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[8].Value);
                }
                if (row.Cells[8].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[9].Value != string.Empty)
                {
                    com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = row.Cells[9].Value;
                }
                if (row.Cells[9].Value == string.Empty)
                {
                    com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[10].Value != string.Empty)
                {
                    com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                }
                if (row.Cells[10].Value == string.Empty)
                {
                    com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[11].Value != string.Empty)
                {
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = row.Cells[11].Value;
                }
                if (row.Cells[11].Value == string.Empty)
                {
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[12].Value != string.Empty)
                {
                    com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[12].Value);
                }
                if (row.Cells[12].Value == string.Empty)
                {
                    com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[13].Value != string.Empty)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[13].Value);
                }

                if (row.Cells[13].Value == string.Empty)
                {
                    com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            dataGridView8.Rows.Clear();
            simpleButton2_Click(sender, e);
            dataGridView25.SelectAll();
            dataGridView8.AllowUserToAddRows = true;
            for (int i = 0; i < dataGridView25.SelectedRows.Count; i++)
            {
                int index = dataGridView8.Rows.Add();
                //dataGridView8.Rows[index].Cells[0].Value = dataGridView25.SelectedRows[i].Cells[0].Value.ToString();
                dataGridView8.Rows[index].Cells[1].Value = dataGridView25.SelectedRows[i].Cells[1].Value.ToString();
                dataGridView8.Rows[index].Cells[2].Value = dataGridView25.SelectedRows[i].Cells[2].Value.ToString();
                dataGridView8.Rows[index].Cells[3].Value = dataGridView25.SelectedRows[i].Cells[3].Value.ToString();
                dataGridView8.Rows[index].Cells[4].Value = dataGridView25.SelectedRows[i].Cells[4].Value.ToString();
                dataGridView8.Rows[index].Cells[5].Value = dataGridView25.SelectedRows[i].Cells[5].Value.ToString();
                dataGridView8.Rows[index].Cells[6].Value = dataGridView25.SelectedRows[i].Cells[6].Value.ToString();
                dataGridView8.Rows[index].Cells[7].Value = dataGridView25.SelectedRows[i].Cells[7].Value.ToString();
                dataGridView8.Rows[index].Cells[8].Value = dataGridView25.SelectedRows[i].Cells[8].Value.ToString();
                dataGridView8.Rows[index].Cells[9].Value = dataGridView25.SelectedRows[i].Cells[9].Value.ToString();
                dataGridView8.Rows[index].Cells[10].Value = dataGridView25.SelectedRows[i].Cells[10].Value.ToString();
                dataGridView8.Rows[index].Cells[11].Value = dataGridView25.SelectedRows[i].Cells[11].Value.ToString();
                dataGridView8.Rows[index].Cells[12].Value = dataGridView25.SelectedRows[i].Cells[12].Value.ToString();
                dataGridView8.Rows[index].Cells[14].Value = dataGridView25.SelectedRows[i].Cells[13].Value.ToString();

            }


            dataGridView8.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in dataGridView8.Rows)
            {

                com.Parameters.Clear();
                com.CommandText = "Insert Into TBL_ShowMenue_Report (RestrictionKind_ID,FinancialMenuSetting_ID,FinancialMenuNameID,MenuName,TotalDue_Blus,TotalDue_Min,TotalCash_Blus,TotalCash_Min,SortingItems,Parent_ID,Name,sortRestriction,RestrictionItemsCategory_ID,UserName)Values(@RestrictionKind_ID,@FinancialMenuSetting_ID,@FinancialMenuNameID,@MenuName,@TotalDue_Blus,@TotalDue_Min,@TotalCash_Blus,@TotalCash_Min,@SortingItems,@Parent_ID,@Name,@sortRestriction,@RestrictionItemsCategory_ID,@UserName)";

                if (row.Cells[1].Value != string.Empty)
                {
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[1].Value);
                }
                if (row.Cells[1].Value == string.Empty)
                {
                    com.Parameters.Add("@RestrictionKind_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[2].Value != string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[2].Value);
                }
                if (row.Cells[2].Value == string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuSetting_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[3].Value != string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[3].Value);
                }
                if (row.Cells[3].Value == string.Empty)
                {
                    com.Parameters.Add("@FinancialMenuNameID", SqlDbType.Decimal).Value = DBNull.Value;
                }
                if (row.Cells[4].Value != string.Empty)
                {
                    com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                }
                if (row.Cells[4].Value == string.Empty)
                {
                    com.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[5].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[5].Value);
                }
                if (row.Cells[5].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Blus", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[6].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[6].Value);
                }
                if (row.Cells[6].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalDue_Min", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[7].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[7].Value);
                }
                if (row.Cells[7].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Blus", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[8].Value != string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[8].Value);
                }
                if (row.Cells[8].Value == string.Empty)
                {
                    com.Parameters.Add("@TotalCash_Min", SqlDbType.Decimal).Value = "0";
                }
                if (row.Cells[9].Value != string.Empty)
                {
                    com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = row.Cells[9].Value;
                }
                if (row.Cells[9].Value == string.Empty)
                {
                    com.Parameters.Add("@SortingItems", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[10].Value != string.Empty)
                {
                    com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[10].Value);
                }
                if (row.Cells[10].Value == string.Empty)
                {
                    com.Parameters.Add("@Parent_ID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (row.Cells[11].Value != string.Empty)
                {
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = row.Cells[11].Value;
                }
                if (row.Cells[11].Value == string.Empty)
                {
                    com.Parameters.Add("@Name", SqlDbType.NVarChar).Value = DBNull.Value;
                }
                if (row.Cells[12].Value != string.Empty)
                {
                    com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[12].Value);
                }
                if (row.Cells[12].Value == string.Empty)
                {
                    com.Parameters.Add("@sortRestriction", SqlDbType.Int).Value = DBNull.Value;
                }
                com.Parameters.Add("@RestrictionItemsCategory_ID", SqlDbType.Int).Value = DBNull.Value;
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Program.GlbV_UserName;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            //splashScreenManager1.CloseWaitForm();
            PrintMenue p = new PrintMenue();
            p.StartPosition = FormStartPosition.CenterScreen;
            p.textBox1.Text = comboBox1.Text;
            p.textBox2.Text = textBox20.Text;
            p.textBox17.Text = textBox17.Text;
            p.ShowDialog();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            ultraTabControl2.Tabs[0].Text = textBox30.Text;
            ultraTabControl2.Tabs[1].Text = textBox31.Text;
            ultraTabControl2.Tabs[2].Text = textBox33.Text;
            ultraTabControl2.Tabs[3].Text = textBox32.Text;
            if(ultraTabControl2.Tabs[0].Text==string.Empty )
            {
                ultraTabControl2.Tabs[0].Visible = false;
            }
            if (ultraTabControl2.Tabs[0].Text != string.Empty)
            {
                ultraTabControl2.Tabs[0].Visible = true ;
            }
            if (ultraTabControl2.Tabs[1].Text == string.Empty)
            {
                ultraTabControl2.Tabs[1].Visible = false;
            }
            if (ultraTabControl2.Tabs[1].Text != string.Empty)
            {
                ultraTabControl2.Tabs[1].Visible = true;
            }
            if (ultraTabControl2.Tabs[2].Text == string.Empty)
            {
                ultraTabControl2.Tabs[2].Visible = false;
            }
            if (ultraTabControl2.Tabs[2].Text != string.Empty)
            {
                ultraTabControl2.Tabs[2].Visible = true;
            }
            if (ultraTabControl2.Tabs[3].Text == string.Empty)
            {
                ultraTabControl2.Tabs[3].Visible = false;
            }
            if (ultraTabControl2.Tabs[3].Text != string.Empty)
            {
                ultraTabControl2.Tabs[3].Visible = true;
            }
        }

        private void radTreeView1_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {

        }

        private void textBox34_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit42.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();

                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox34.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    label12.Text = "(" + Forms.ProcessingForms.FindAccount.SelectedRow.Cells[1].Value.ToString() + ")";
                    AddChildAccount();
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit40.Checked == true || checkEdit41.Checked == true)
                {
                    try


                    {
                        if (checkEdit42.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {
                                dataGridView23.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox18.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox18.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit40.EditValue, checkEdit41.EditValue, 3, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit42.Checked == false)
                        {

                            dataGridView23.Rows.Add(textBox1.Text, textBox4.Text, comboBox18.Text, IDParenttxtBox.Text, AccID.Text, comboBox18.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit40.EditValue, checkEdit41.EditValue, 3, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }

        }

        private void textBox35_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit43.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();
                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox35.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    AddChildAccount();
                }
                catch { }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit45.Checked == true || checkEdit44.Checked == true)
                {
                    try
                    {
                        if (checkEdit43.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {


                                dataGridView24.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox19.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox19.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit45.EditValue, checkEdit44.EditValue, 3, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit43.Checked == false)
                        {
                            dataGridView24.Rows.Add(textBox1.Text, textBox5.Text, comboBox19.Text, IDParenttxtBox.Text, AccID.Text, comboBox19.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit45.EditValue, checkEdit44.EditValue, 3, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox37_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit51.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();

                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox37.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    label12.Text = "(" + Forms.ProcessingForms.FindAccount.SelectedRow.Cells[1].Value.ToString() + ")";
                    AddChildAccount();
                }
                catch { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit49.Checked == true || checkEdit50.Checked == true)
                {
                    try


                    {
                        if (checkEdit51.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {
                                dataGridView27.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox21.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox21.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit49.EditValue, checkEdit50.EditValue, 4, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit51.Checked == false)
                        {

                            dataGridView27.Rows.Add(textBox1.Text, textBox4.Text, comboBox21.Text, IDParenttxtBox.Text, AccID.Text, comboBox21.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit49.EditValue, checkEdit50.EditValue, 4, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void textBox36_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    Forms.ProcessingForms.FindAccount f = new Forms.ProcessingForms.FindAccount();
                    if (checkEdit46.Checked == true)
                    {
                        f.checkEdit10.Checked = true;
                    }
                    f.ShowDialog();
                    AccID.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[2].Value.ToString();
                    textBox36.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    textBox10.Text = Forms.ProcessingForms.FindAccount.SelectedRow.Cells[0].Value.ToString();
                    AddChildAccount();
                }
                catch { }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (checkEdit48.Checked == true || checkEdit47.Checked == true)
                {
                    try
                    {
                        if (checkEdit46.Checked == true)
                        {
                            for (int x = 1; x < dataGridView5.Rows.Count; x++)
                            {


                                dataGridView26.Rows.Add(textBox1.Text, dataGridView5.Rows[x].Cells[1].Value.ToString(), comboBox20.Text, IDParenttxtBox.Text, dataGridView5.Rows[x].Cells[0].Value.ToString(), comboBox20.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit48.EditValue, checkEdit47.EditValue, 4, dateTimePicker1.Value, dateTimePicker2.Value, true);
                            }
                        }
                        if (checkEdit46.Checked == false)
                        {
                            dataGridView26.Rows.Add(textBox1.Text, textBox5.Text, comboBox20.Text, IDParenttxtBox.Text, AccID.Text, comboBox20.SelectedValue, IDParenttxtBox.Text, comboBox1.SelectedValue, checkEdit48.EditValue, checkEdit47.EditValue, 4, dateTimePicker1.Value, dateTimePicker2.Value, true);
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("الرجاء اختار مدين أو دائن أولا");
                }
            }
        }

        private void checkEdit41_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit41.Checked == true)
            {
                checkEdit40.Checked = false;
            }
        }

        private void checkEdit40_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit40.Checked == true)
            {
                checkEdit41.Checked = false;
            }
        }

        private void checkEdit44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit44.Checked == true)
            {
                checkEdit45.Checked = false;
            }
        }

        private void checkEdit45_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit45.Checked == true)
            {
                checkEdit44.Checked = false;
            }
        }

        private void checkEdit49_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit49.Checked == true)
            {
                checkEdit50.Checked = false;
            }
        }

        private void checkEdit50_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit50.Checked == true)
            {
                checkEdit49.Checked = false;
            }
        }

        private void checkEdit47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit47.Checked == true)
            {
                checkEdit48.Checked = false;
            }
        }

        private void checkEdit48_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit48.Checked == true)
            {
                checkEdit47.Checked = false;
            }
        }

        private void dataGridView27_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            DeleteFromMenue();
        }

        private void dataGridView23_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView23.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }

        private void dataGridView24_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView24_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView24.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }

        private void dataGridView27_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView27.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }

        private void dataGridView26_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox16.Text = dataGridView26.CurrentRow.Cells[14].Value.ToString();
            }
            catch { }
        }
    }
}