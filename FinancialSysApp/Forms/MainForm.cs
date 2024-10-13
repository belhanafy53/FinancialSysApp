using FinancialSysApp.Forms.BasicCodeForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.Forms.SecuritySystem;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraBars;
using FinancialSysApp.Classes;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;
using UserRoles;
using System.Data.Entity;
using DevExpress.PivotGrid.Criteria;

namespace FinancialSysApp.Forms
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        private Timer timer;
        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
              
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            CustomerFrm f = new CustomerFrm();
            if ((Application.OpenForms["CustomerFrm"] as CustomerFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }

        }


        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SuppliersFrm f = new SuppliersFrm();
            if ((Application.OpenForms["SuppliersFrm"] as SuppliersFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CategoryFrm f = new CategoryFrm();
            if ((Application.OpenForms["CategoryFrm"] as CategoryFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BeneficiaryKindFrm f = new BeneficiaryKindFrm();
            if ((Application.OpenForms["BeneficiaryKindFrm"] as BeneficiaryKindFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BeneficiaryFrm f = new BeneficiaryFrm();
            if ((Application.OpenForms["BeneficiaryFrm"] as BeneficiaryFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AccountingRestrictions_KindFrm f = new AccountingRestrictions_KindFrm();
            if ((Application.OpenForms["AccountingRestrictions_KindFrm"] as AccountingRestrictions_KindFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void dockPanel2_Click(object sender, EventArgs e)
        {
            SuppliersFrm f = new SuppliersFrm();
            if ((Application.OpenForms["SuppliersFrm"] as SuppliersFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AccountsKindFrm f = new AccountsKindFrm();
            if ((Application.OpenForms["AccountsKindFrm"] as AccountsKindFrm != null))
            {

                f.BringToFront();

            }
            else
            {
                f.Show();
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            CustomerFrm f = new CustomerFrm();
            if ((Application.OpenForms["CustomerFrm"] as CustomerFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }

        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SuppliersFrm f = new SuppliersFrm();
            if ((Application.OpenForms["SuppliersFrm"] as SuppliersFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EmployeeFrm f = new EmployeeFrm();
            if ((Application.OpenForms["EmployeeFrm"] as EmployeeFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ManagementFrm f = new ManagementFrm();
            if ((Application.OpenForms["ManagementFrm"] as ManagementFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AccountsGuidFrm f = new AccountsGuidFrm();
            if ((Application.OpenForms["AccountsGuidFrm"] as AccountsGuidFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsersFrm f = new UsersFrm();
            if ((Application.OpenForms["UsersFrm"] as UsersFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaxAuthorityFrm f = new TaxAuthorityFrm();
            if ((Application.OpenForms["TaxAuthorityFrm"] as TaxAuthorityFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DocumentCategoryNFrm f = new DocumentCategoryNFrm();
            if ((Application.OpenForms["DocumentCategoryNFrm"] as DocumentCategoryNFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExchangeCentersNFrm f = new ExchangeCentersNFrm();
            if ((Application.OpenForms["ExchangeCentersNFrm"] as ExchangeCentersNFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OrdersKindsFrm f = new OrdersKindsFrm();
            if ((Application.OpenForms["OrdersKindsFrm"] as OrdersKindsFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IndebtednessKindFrm f = new IndebtednessKindFrm();
            if ((Application.OpenForms["IndebtednessKindFrm"] as IndebtednessKindFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CostsCenterFrm f = new CostsCenterFrm();
            if ((Application.OpenForms["CostsCenterFrm"] as CostsCenterFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey SkinName = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINREGISTRY");
            SkinName.SetValue("SkinName", DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName.ToString());
            SkinName.Close();
            var listLogOut = FsEvDb.SecurityUserActivities.FirstOrDefault(x => x.User_ID == Program.GlbV_UserId && x.PeriodTime == null);
            if (listLogOut != null)
            {
                listLogOut.LogoutTime = Convert.ToDateTime(GetServerDate.Cs_GetServerDate().ToString());
                //listLogOut.LogoutTime = Convert.ToDateTime(DateTime.Now.ToString());
                listLogOut.LoginTime = Convert.ToDateTime(listLogOut.LoginTime.ToString());
                TimeSpan sub = Convert.ToDateTime(listLogOut.LogoutTime).Subtract(Convert.ToDateTime(listLogOut.LoginTime));
                listLogOut.PeriodTime = sub;
                //listLogOut.Period = decimal.Parse( sub.TotalMinutes.ToString());
                FsEvDb.SaveChanges();
            }
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegistryKey SkinName = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINREGISTRY");
            if (SkinName != null)
            {
                this.barStaticItem1.Caption = "اسم المستخدم  : " + " " + Program.GlbV_UserName;
                this.barStaticItem2.Caption = "التاريخ   : " + " " + DateTime.Now.Date.ToShortDateString();
                this.barStaticItem3.Caption = "الوحدة   : " + " " + Program.GlbV_SysUnite;
                this.barStaticItem5.Caption = "الادارة : " + " " + Program.GlbV_Management;
                this.barStaticItem4.Caption = "اسم الموظف   : " + " " + Program.GlbV_EmpName;
                this.barHeaderItem1.Caption = "اسم الموظف  : " + " " + Program.GlbV_EmpName;
                this.barStaticItem6.Caption = "الوظيفه : " + " " + Program.GlbV_job;
                this.barStaticItem8.Caption = Program.GlbV_UserType;
                ContorleMenu();
                //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = SkinName.GetValue("SkinName").ToString();
                CheckDataBank();
                CheckDataAccResAudit();
                //CheckActionUsers(Program.GlbV_UserId);
            }
        }
        private void CheckActionUsers(int Vint_UserID)
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            DateTime Vd_date = Convert.ToDateTime(GetServerDate.Cs_GetServerDate().ToString());
            this.getLogInLogOutDataOneUserTableAdapter.FillByUser(this.getDataUserActionDS.GetLogInLogOutDataOneUser, Vd_date, Program.GlbV_UserId);
            this.getLogInDataForUserTableAdapter.Fill(this.getDataUserActionDS.GetLogInDataForUser, Vd_date, Vd_date, Program.GlbV_UserId);
            
            TimeSpan subLogin = Vd_date.Subtract(Convert.ToDateTime(textBox8.Text));
            if (textBox6.Text != string.Empty)
            {
                TimeSpan sub = Vd_date.Subtract(Convert.ToDateTime(textBox6.Text));
                if ((subLogin >= TimeSpan.FromMinutes(30) && subLogin <= TimeSpan.FromMinutes(45) )&& (sub >= TimeSpan.FromMinutes(30)&& sub <= TimeSpan.FromMinutes(45)))
                {


                    MessageBox.Show($@"انتبه : انت لم تستخدم المنظومه منذ {sub} دقيقه / ساعه واخر حدث هو {textBox7.Text} وذلك في .
                                {textBox6.Text}.
                                وسيتم اغلاق المنظومه تلقائيا بعد مرور 45 دقيقه اذا تم الاستمرار في عدم استخدامك للمنظومه ");

                }
            }
            else if (subLogin < TimeSpan.FromMinutes(45))
            {
                MessageBox.Show($@"انتبه : انت لم تستخدم المنظومه منذ  {textBox8.Text} 
                                وسيتم اغلاق المنظومه تلقائيا بعد مرور 45 دقيقه اذا تم الاستمرار في عدم استخدامك للمنظومه ");
            }
            else if (subLogin >= TimeSpan.FromMinutes(45))
            {
                Application.Exit();
            }
            
        }
        private void ContorleMenu()
        {
            //القائمة الأفقية
            //1 - العملاء

            barButtonItem14.Enabled = Program.SecurityFormsList.Contains(1) ? true : false;
            //2 - الموردين
            barButtonItem15.Enabled = Program.SecurityFormsList.Contains(2) ? true : false;

            //3 - الموظفين

            barButtonItem16.Enabled = Program.SecurityFormsList.Contains(3) ? true : false;
            //4  - المستفيدون
            barButtonItem5.Enabled = Program.SecurityFormsList.Contains(4) ? true : false;

            //39 - انواع المستفيدون

            barButtonItem4.Enabled = Program.SecurityFormsList.Contains(39) ? true : false;
            //5 - الادارات
            barButtonItem6.Enabled = Program.SecurityFormsList.Contains(5) ? true : false;

            //6- ماموريات الضرائب

            barButtonItem18.Enabled = Program.SecurityFormsList.Contains(6) ? true : false;
            //7 - مراكز الصرف
            barButtonItem7.Enabled = Program.SecurityFormsList.Contains(7) ? true : false;
            //8 مراكز التكلفة

            barButtonItem20.Enabled = Program.SecurityFormsList.Contains(8) ? true : false;
            //9 - الانشطة
            barButtonItem22.Enabled = Program.SecurityFormsList.Contains(9) ? true : false;

            //10 - شجرة الحسابات

            barButtonItem8.Enabled = Program.SecurityFormsList.Contains(10) ? true : false;
            //11  - انواع الاوامر
            barButtonItem9.Enabled = Program.SecurityFormsList.Contains(11) ? true : false;
            //12  - انواع المديونيات
            barButtonItem11.Enabled = Program.SecurityFormsList.Contains(12) ? true : false;

            //13 - انواع الحسابات

            barButtonItem10.Enabled = Program.SecurityFormsList.Contains(13) ? true : false;

            //44 - البنود

            barButtonItem52.Enabled = Program.SecurityFormsList.Contains(44) ? true : false;

            //  45 - الوحدات
            barButtonItem53.Enabled = Program.SecurityFormsList.Contains(45) ? true : false;

            //14 - البيان
            barButtonItem19.Enabled = Program.SecurityFormsList.Contains(14) ? true : false;

            //15 ماموريات الضرائب تصنيف البنود

            barButtonItem12.Enabled = Program.SecurityFormsList.Contains(15) ? true : false;
            //16- انواع القيود
            barButtonItem13.Enabled = Program.SecurityFormsList.Contains(16) ? true : false;
            //17 البنوك
            barButtonItem25.Enabled = Program.SecurityFormsList.Contains(17) ? true : false;
            //18 - انواع الشيكات
            barButtonItem26.Enabled = Program.SecurityFormsList.Contains(18) ? true : false;

            //40 - مراكز المسؤلية

            barButtonItem38.Enabled = Program.SecurityFormsList.Contains(40) ? true : false;

            //   - المناولين

            barButtonItem50.Enabled = Program.SecurityFormsList.Contains(42) ? true : false;
            //******** المشروعات

            barButtonItem74.Enabled = Program.SecurityFormsList.Contains(55) ? true : false;

            //**المخازن
            barButtonItem75.Enabled = Program.SecurityFormsList.Contains(56) ? true : false;
            //***************

            barButtonItem119.Enabled = Program.SecurityFormsList.Contains(96) ? true : false;
            //************طرق الشراء 
            barButtonItem76.Enabled = Program.SecurityFormsList.Contains(57) ? true : false;


            //***************لجان الوحدات
            barButtonItem89.Enabled = Program.SecurityFormsList.Contains(76) ? true : false;
            //***** انواع العمليات

            barButtonItem70.Enabled = Program.SecurityFormsList.Contains(51) ? true : false;

            //****************
            barButtonItem105.Enabled = Program.SecurityFormsList.Contains(87) ? true : false;

            //********** طرق الدفع والتسويات
            barButtonItem71.Enabled = Program.SecurityFormsList.Contains(52) ? true : false;

            barButtonItem136.Enabled = Program.SecurityFormsList.Contains(110) ? true : false;
            //*******************تصنيفات المعاملات البنكيه
            barButtonItem134.Enabled = Program.SecurityFormsList.Contains(109) ? true : false;
            //**************الغرض من العمليات
            barButtonItem72.Enabled = Program.SecurityFormsList.Contains(53) ? true : false;

            //*******************تصنيف بنود الخزينه
            barButtonItem137.Enabled = Program.SecurityFormsList.Contains(111) ? true : false;

            barButtonItem138.Enabled = Program.SecurityFormsList.Contains(112) ? true : false;
            //*******************تقرير مراجعة الايداعات النقديه
            barButtonItem92.Enabled = Program.SecurityFormsList.Contains(128) ? true : false;

            barButtonItem154.Enabled = Program.SecurityFormsList.Contains(123) ? true : false;
            //***************************************نظام الحماية
            // 20 - انواع المستخدمين
            barButtonItem23.Enabled = Program.SecurityFormsList.Contains(19) ? true : false;
            //89 -- المندوبين
            barButtonItem98.Enabled = Program.SecurityFormsList.Contains(80) ? true : false;
            //************106
            barButtonItem106.Enabled = Program.SecurityFormsList.Contains(88) ? true : false;
            // 20 - وحدات المنظومة
            barButtonItem24.Enabled = Program.SecurityFormsList.Contains(20) ? true : false;

            //21 - صفحات المنظومة

            barButtonItem32.Enabled = Program.SecurityFormsList.Contains(21) ? true : false;
            //22 - الاجراءات
            barButtonItem33.Enabled = Program.SecurityFormsList.Contains(22) ? true : false;

            //23- وحدات البرنامج

            barButtonItem34.Enabled = Program.SecurityFormsList.Contains(23) ? true : false;
            //24 -المستخدمين
            barButtonItem31.Enabled = Program.SecurityFormsList.Contains(24) ? true : false;

            //34  - اجراءات الصفحات
            barButtonItem35.Enabled = Program.SecurityFormsList.Contains(34) ? true : false;

            //35 - صفحات وحدات المنظومة

            barButtonItem41.Enabled = Program.SecurityFormsList.Contains(35) ? true : false;
            //36 - صفحات انواع المستخدمين
            barButtonItem42.Enabled = Program.SecurityFormsList.Contains(36) ? true : false;

            //37 صلاخيات المستخدمين

            barButtonItem43.Enabled = Program.SecurityFormsList.Contains(37) ? true : false;
            //***************************************************************

            //*********************************العمليات
            //25 نقل البيانات من ادفاك

            barButtonItem27.Enabled = Program.SecurityFormsList.Contains(25) ? true : false;

            // 47 ربط الحسابات بالبيانات 
            barButtonItem55.Enabled = Program.SecurityFormsList.Contains(47) ? true : false;

            //**********85
            barButtonItem85.Enabled = Program.SecurityFormsList.Contains(68) ? true : false;

            // الدمغات الرسوم
            barButtonItem77.Enabled = Program.SecurityFormsList.Contains(58) ? true : false;

            //*****************الاوامر
            barButtonItem51.Enabled = Program.SecurityFormsList.Contains(43) ? true : false;
            //*****************المقايسات
            barButtonItem78.Enabled = Program.SecurityFormsList.Contains(59) ? true : false;
            //************
            //*****************المناقصات / المزايدات
            barButtonItem79.Enabled = Program.SecurityFormsList.Contains(60) ? true : false;
            //************
            //26 - مستند المراجعة
            barButtonItem28.Enabled = Program.SecurityFormsList.Contains(26) ? true : false;

            //80 قرارات اللجان 
            barButtonItem80.Enabled = Program.SecurityFormsList.Contains(61) ? true : false;

            //27 - القيود المحاسبية

            barButtonItem29.Enabled = Program.SecurityFormsList.Contains(27) ? true : false;

            //****************دفع اليكتروني تلقائي
            barButtonItem157.Enabled = Program.SecurityFormsList.Contains(126) ? true : false;

            //***************** خطابات الضمان 


            barButtonItem83.Enabled = Program.SecurityFormsList.Contains(64) ? true : false;

            barButtonItem84.Enabled = Program.SecurityFormsList.Contains(65) ? true : false;
            //****************
            // - 48 - قيود غير متزنه

            barButtonItem56.Enabled = Program.SecurityFormsList.Contains(48) ? true : false;

            //49 الاعوام المالية
            barButtonItem68.Enabled = Program.SecurityFormsList.Contains(49) ? true : false;
            //50 تصنيف بنود القيد
            barButtonItem69.Enabled = Program.SecurityFormsList.Contains(50) ? true : false;

            //41 - توزيع مراكز التكلفة والانشطة

            barButtonItem37.Enabled = Program.SecurityFormsList.Contains(41) ? true : false;

            //86 - العمليات المؤرشفه

            barButtonItem86.Enabled = Program.SecurityFormsList.Contains(72) ? true : false;
            //87 - تصنيف المستندات

            barButtonItem88.Enabled = Program.SecurityFormsList.Contains(73) ? true : false;

            //***************مقارنة الايداع النقدي بكشف الحساب 
            barButtonItem155.Enabled = Program.SecurityFormsList.Contains(124) ? true : false;
            //***************مقارنة كشف الحساب بالايداع النقدي  
            barButtonItem156.Enabled = Program.SecurityFormsList.Contains(125) ? true : false;
            //**** شيكات وارد الخزينه من الفروع

            barButtonItem94.Enabled = Program.SecurityFormsList.Contains(78) ? true : false;

            //**************** رد وسحب الشيكات 
            barButtonItem123.Enabled = Program.SecurityFormsList.Contains(89) ? true : false;

            //**** شيكات وارد الخزينه من الجهات

            barButtonItem101.Enabled = Program.SecurityFormsList.Contains(79) ? true : false;
            //*********ايداع الشيكاتت بالبنوك
            barButtonItem99.Enabled = Program.SecurityFormsList.Contains(81) ? true : false;
            //******************ايداع نقديه
            barButtonItem114.Enabled = Program.SecurityFormsList.Contains(95) ? true : false;
            //******************************
            barButtonItem122.Enabled = Program.SecurityFormsList.Contains(98) ? true : false;
            //*******************
            barButtonItem93.Enabled = Program.SecurityFormsList.Contains(84) ? true : false;

            //********************استيراد كشف حساب البنك
            barButtonItem124.Enabled = Program.SecurityFormsList.Contains(99) ? true : false;
            //********************مراجعة الايداعات النقديه
            barButtonItem135.Enabled = Program.SecurityFormsList.Contains(108) ? true : false;

            //*********************مراجعة الشيكات الوارده
            barButtonItem144.Enabled = Program.SecurityFormsList.Contains(85) ? true : false;

            //****************مراجعة الدفع الاليكتروني
            barButtonItem158.Enabled = Program.SecurityFormsList.Contains(127) ? true : false;
            //*********************************التقارير
            //48- تقرير بحركة المستخدمين 
            barButtonItem48.Enabled = Program.SecurityFormsList.Contains(33) ? true : false;
            //73 -- اضافة القوائم المالية

            barButtonItem73.Enabled = Program.SecurityFormsList.Contains(54) ? true : false;
            //67- اعدادات القوائم المالية
            barButtonItem67.Enabled = Program.SecurityFormsList.Contains(38) ? true : false;

            //**************اضافة الشيكات من كشف الحساب
            barButtonItem126.Enabled = Program.SecurityFormsList.Contains(101) ? true : false;
            //************** الشيكات الصادرة
            barButtonItem149.Enabled = Program.SecurityFormsList.Contains(119) ? true : false;
            //************** الشيكات التى لم يتم  اصدارها
            barButtonItem148.Enabled = Program.SecurityFormsList.Contains(120) ? true : false;
            //**************الصادرة تكويد دفتر الشيكات
            barButtonItem150.Enabled = Program.SecurityFormsList.Contains(121) ? true : false;

            //*****************الدفع الاليكتروني
            barButtonItem151.Enabled = Program.SecurityFormsList.Contains(122) ? true : false;
            //******************استعلامات
            //54 - استعلامات تفاصيل المستندات
            barButtonItem54.Enabled = Program.SecurityFormsList.Contains(46) ? true : false;
            barButtonItem104.Enabled = Program.SecurityFormsList.Contains(86) ? true : false;

            barButtonItem113.Enabled = Program.SecurityFormsList.Contains(93) ? true : false;

            barButtonItem120.Enabled = Program.SecurityFormsList.Contains(97) ? true : false;

            barButtonItem125.Enabled = Program.SecurityFormsList.Contains(100) ? true : false;

            barButtonItem140.Enabled = Program.SecurityFormsList.Contains(114) ? true : false;

            barButtonItem145.Enabled = Program.SecurityFormsList.Contains(117) ? true : false;
            //***************************************** القائمة الرأسية
            // 28- ميزان المراجعة
            navBarItem1.Enabled = Program.SecurityFormsList.Contains(28) ? true : false;
            //29 العمليات الجارية
            navBarItem2.Enabled = Program.SecurityFormsList.Contains(29) ? true : false;
            // 30- المركز المالي
            navBarItem3.Enabled = Program.SecurityFormsList.Contains(30) ? true : false;
            //31 الايرادات والمصروفات
            navBarItem4.Enabled = Program.SecurityFormsList.Contains(31) ? true : false;
            // 32 تحليلات الاصول الثابته
            navBarItem5.Enabled = Program.SecurityFormsList.Contains(32) ? true : false;


            //******************تقارير 

            barButtonItem139.Enabled = Program.SecurityFormsList.Contains(113) ? true : false;

            barButtonItem100.Enabled = Program.SecurityFormsList.Contains(82) ? true : false;

            barButtonItem102.Enabled = Program.SecurityFormsList.Contains(83) ? true : false;
            barButtonItem110.Enabled = Program.SecurityFormsList.Contains(91) ? true : false;
            barButtonItem111.Enabled = Program.SecurityFormsList.Contains(92) ? true : false;
            barButtonItem64.Enabled = Program.SecurityFormsList.Contains(94) ? true : false;

            barButtonItem127.Enabled = Program.SecurityFormsList.Contains(105) ? true : false;

            barButtonItem129.Enabled = Program.SecurityFormsList.Contains(106) ? true : false;

            barButtonItem130.Enabled = Program.SecurityFormsList.Contains(107) ? true : false;

            barButtonItem142.Enabled = Program.SecurityFormsList.Contains(115) ? true : false;

            barButtonItem143.Enabled = Program.SecurityFormsList.Contains(116) ? true : false;

            barButtonItem147.Enabled = Program.SecurityFormsList.Contains(118) ? true : false;

            barButtonItem160.Enabled = Program.SecurityFormsList.Contains(129) ? true : false;

            barButtonItem161.Enabled = Program.SecurityFormsList.Contains(130) ? true : false;

            barButtonItem162.Enabled = Program.SecurityFormsList.Contains(131) ? true : false;

            barButtonItem163.Enabled = Program.SecurityFormsList.Contains(132) ? true : false;

            barButtonItem166.Enabled = Program.SecurityFormsList.Contains(133) ? true : false;
            barButtonItem169.Enabled = Program.SecurityFormsList.Contains(135) ? true : false;
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActivitiesFrm f = new ActivitiesFrm();
            if ((Application.OpenForms["ActivitiesFrm"] as ActivitiesFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            UserTypeFrm f = new UserTypeFrm();
            if ((Application.OpenForms["UserTypeFrm"] as UserTypeFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SystemUnitesFrm f = new SystemUnitesFrm();
            if ((Application.OpenForms["SystemUnitesFrm"] as SystemUnitesFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.TransferDataFRM f = new Forms.ProcessingForms.TransferDataFRM();
            if ((Application.OpenForms["TransferDataFRM"] as Forms.ProcessingForms.TransferDataFRM != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            //splashScreenManager1.SetWaitFormCaption(" المنظومة المالية ** البنود المحاسبية  ");
            //splashScreenManager1.SetWaitFormDescription("الرجاء الإنتظار لحظات  ");

            Forms.ProcessingForms.Res_Frm f = new Forms.ProcessingForms.Res_Frm();
            if ((Application.OpenForms["Res_Frm"] as Forms.ProcessingForms.Res_Frm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
            //splashScreenManager1.CloseWaitForm();
        }

        private void navBarItem1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Forms.ProcessingForms.FinancialbalanceFrm f = new Forms.ProcessingForms.FinancialbalanceFrm();
            if ((Application.OpenForms["FinancialbalanceFrm"] as Forms.ProcessingForms.FinancialbalanceFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void navBarItem2_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Forms.ProcessingForms.Ongoing_Operation f = new Forms.ProcessingForms.Ongoing_Operation();
            if ((Application.OpenForms["Ongoing_Operation"] as Forms.ProcessingForms.Ongoing_Operation != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void navBarItem3_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Forms.ProcessingForms.Financial_Center f = new Forms.ProcessingForms.Financial_Center();
            if ((Application.OpenForms["Financial_Center"] as Forms.ProcessingForms.Financial_Center != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void navBarItem4_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Forms.ProcessingForms.Revenue_expense f = new Forms.ProcessingForms.Revenue_expense();
            if ((Application.OpenForms["Revenue_expense"] as Forms.ProcessingForms.Revenue_expense != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void navBarItem5_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Forms.ProcessingForms.Frm_Asset_Analysis f = new Forms.ProcessingForms.Frm_Asset_Analysis();
            if ((Application.OpenForms["Frm_Asset_Analysis"] as Forms.ProcessingForms.Frm_Asset_Analysis != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.WorkersFrm f = new Forms.WorkersFrm();
            if ((Application.OpenForms["WorkersFrm"] as WorkersFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.TransfWorkerData f = new Forms.BasicCodeForms.TransfWorkerData();
            if ((Application.OpenForms["TransfWorkerData"] as TransfWorkerData != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ChequeKindFrm f = new Forms.BasicCodeForms.ChequeKindFrm();
            if ((Application.OpenForms["ChequeKindFrm"] as ChequeKindFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.BanksFrm f = new Forms.BasicCodeForms.BanksFrm();
            if ((Application.OpenForms["BanksFrm"] as BanksFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem31_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.UsersFrm f = new Forms.BasicCodeForms.UsersFrm();
            if ((Application.OpenForms["UsersFrm"] as UsersFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.SecuritySystem.ProceduresFrm f = new Forms.SecuritySystem.ProceduresFrm();
            if ((Application.OpenForms["ProceduresFrm"] as ProceduresFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.SecuritySystem.MainMenuProgramFrm f = new Forms.SecuritySystem.MainMenuProgramFrm();
            if ((Application.OpenForms["MainMenuProgramFrm"] as MainMenuProgramFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.SecuritySystem.FormsFrm f = new Forms.SecuritySystem.FormsFrm();
            if ((Application.OpenForms["FormsFrm"] as FormsFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.SecuritySystem.ProceduresFormsFrm f = new Forms.SecuritySystem.ProceduresFormsFrm();
            if ((Application.OpenForms["ProceduresFormsFrm"] as ProceduresFormsFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.RadForm1 f = new Forms.ProcessingForms.RadForm1();
            if ((Application.OpenForms["RadForm1"] as Forms.ProcessingForms.RadForm1 != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ResponspilityCentersFrm f = new Forms.BasicCodeForms.ResponspilityCentersFrm();
            if ((Application.OpenForms["ResponspilityCentersFrm"] as ResponspilityCentersFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var listLogOut = FsEvDb.SecurityUserActivities.FirstOrDefault(x => x.User_ID == Program.GlbV_UserId && x.PeriodTime == null);
            if (listLogOut != null)
            {
                listLogOut.LogoutTime = Convert.ToDateTime(Program.GlbV_DateTime.ToString());
                listLogOut.LoginTime = Convert.ToDateTime(listLogOut.LoginTime);
                TimeSpan sub = Convert.ToDateTime(listLogOut.LogoutTime).Subtract(Convert.ToDateTime(listLogOut.LoginTime));
                listLogOut.PeriodTime = sub;
                //listLogOut.Period = decimal.Parse( sub.TotalMinutes.ToString());
                FsEvDb.SaveChanges();
            }
            Application.Exit();
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.SecuritySystem.MenuProgUnit_SysUnites f = new Forms.SecuritySystem.MenuProgUnit_SysUnites();
            if ((Application.OpenForms["MenuProgUnit_SysUnites"] as MenuProgUnit_SysUnites != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.SecuritySystem.FormsUserTypeUserFrm f = new Forms.SecuritySystem.FormsUserTypeUserFrm();
            if ((Application.OpenForms["FormsUserTypeUserFrm"] as FormsUserTypeUserFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.SecuritySystem.UsersProcedureFormFrm f = new Forms.SecuritySystem.UsersProcedureFormFrm();

            if ((Application.OpenForms["UsersProcedureFormFrm"] as UsersProcedureFormFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barHeaderItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Visible = true;
            textBox1.Text = Program.GlbV_EmpName;
            textBox2.Text = Program.GlbV_SysUnite;
            OldPassTextBox.Text = Program.GlbV_CPassword;
            textBox3.Focus();
        }

        private void svgImageBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (Security.Encrypt_MD5(textBox3.Text) != OldPassTextBox.Text)
            {
                MessageBox.Show("كلمة المرور القديمه خطأ");
                textBox3.Text = "";
                textBox3.Focus();

            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("كلمة المرور الجديده غير متطابقه");
                textBox4.Text = "";
                textBox5.Text = "";
                textBox4.Focus();
            }
            else
            {

                var list = FsDb.Tbl_User.Find(Program.GlbV_UserId);
                list.Password = Security.Encrypt_MD5(textBox4.Text);
                FsDb.SaveChanges();
                MessageBox.Show("تم حفظ كلمة المرور الجديده");
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                panel1.Visible = false;

            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var listLogOut = FsEvDb.SecurityUserActivities.FirstOrDefault(x => x.User_ID == Program.GlbV_UserId && x.PeriodTime == null);
            if (listLogOut != null)
            {
                listLogOut.LogoutTime = Convert.ToDateTime(Program.GlbV_DateTime.ToString());
                listLogOut.LoginTime = Convert.ToDateTime(listLogOut.LoginTime);
                TimeSpan sub = Convert.ToDateTime(listLogOut.LogoutTime).Subtract(Convert.ToDateTime(listLogOut.LoginTime));
                listLogOut.PeriodTime = sub;
                //listLogOut.Period = decimal.Parse( sub.TotalMinutes.ToString());
                FsEvDb.SaveChanges();
            }
            Application.Exit();
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var listLogOut = FsEvDb.SecurityUserActivities.FirstOrDefault(x => x.User_ID == Program.GlbV_UserId && x.PeriodTime == null);
            if (listLogOut != null)
            {
                listLogOut.LogoutTime = Convert.ToDateTime(Program.GlbV_DateTime.ToString());
                listLogOut.LoginTime = Convert.ToDateTime(listLogOut.LoginTime);
                TimeSpan sub = Convert.ToDateTime(listLogOut.LogoutTime).Subtract(Convert.ToDateTime(listLogOut.LoginTime));
                listLogOut.PeriodTime = sub;
                //listLogOut.Period = decimal.Parse( sub.TotalMinutes.ToString());
                FsEvDb.SaveChanges();
            }
            Application.Exit();

        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Forms.ReportsDevX.LoginLogOutRP f = new Forms.ReportsDevX.LoginLogOutRP();
            //        if ((Application.OpenForms["LoginLogOutRP"] as Forms.ReportsDevX.LoginLogOutRP != null))
            //        {

            //            f.BringToFront();
            //            this.SendToBack();

            //        }
            //        else
            //        {
            //            f.Show();
            //            f.BringToFront();
            //        }
        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.HandlersFrm f = new Forms.BasicCodeForms.HandlersFrm();
            if ((Application.OpenForms["HandlersFrm"] as HandlersFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem49_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ReportsDevX.FinancialMenuSttingFrm f = new Forms.ReportsDevX.FinancialMenuSttingFrm();
            if ((Application.OpenForms["FinancialMenuSttingFrm"] as Forms.ReportsDevX.FinancialMenuSttingFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.DocumentsForms.OrderFrm f = new Forms.DocumentsForms.OrderFrm();
            if ((Application.OpenForms["OrderFrm"] as Forms.DocumentsForms.OrderFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem52_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ItemsNFrm f = new Forms.BasicCodeForms.ItemsNFrm();
            if ((Application.OpenForms["ItemsNFrm"] as Forms.BasicCodeForms.ItemsNFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem53_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.UnitesFrm f = new Forms.BasicCodeForms.UnitesFrm();
            if ((Application.OpenForms["UnitesFrm"] as Forms.BasicCodeForms.UnitesFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem54_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.SearchRpt.Search f = new ProcessingForms.SearchRpt.Search();
            if ((Application.OpenForms["Search"] as Forms.ProcessingForms.SearchRpt.Search != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryKey SkinName = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINREGISTRY");
            SkinName.SetValue("SkinName", DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName.ToString());
            SkinName.Close();
        }

        private void barButtonItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.Matching_AccDocCategoryFrm f = new Forms.BasicCodeForms.Matching_AccDocCategoryFrm();
            if ((Application.OpenForms["Matching_AccDocCategoryFrm"] as Forms.BasicCodeForms.Matching_AccDocCategoryFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.DifferencesFrm f = new Forms.ProcessingForms.DifferencesFrm();
            if ((Application.OpenForms["DifferencesFrm"] as Forms.ProcessingForms.DifferencesFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }

        }

        private void barButtonItem67_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ReportsDevX.FinancialMenuSttingFrm f = new Forms.ReportsDevX.FinancialMenuSttingFrm();
            if ((Application.OpenForms["FinancialMenuSttingFrm"] as Forms.ReportsDevX.FinancialMenuSttingFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem68_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.Fiscalyear f = new Forms.ProcessingForms.Fiscalyear();
            if ((Application.OpenForms["Fiscalyear"] as Forms.ProcessingForms.Fiscalyear != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }


        }

        private void barButtonItem69_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ProcessingForms.DocCategorySetup f = new Forms.ProcessingForms.DocCategorySetup();
            if ((Application.OpenForms["DocCategorySetup"] as Forms.ProcessingForms.DocCategorySetup != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }

        }

        private void barButtonItem70_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ProcessinKindFrm f = new Forms.BasicCodeForms.ProcessinKindFrm();
            if ((Application.OpenForms["ProcessinKindFrm"] as Forms.BasicCodeForms.ProcessinKindFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem71_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.PaymentsMethodFrm f = new Forms.BasicCodeForms.PaymentsMethodFrm();
            if ((Application.OpenForms["PaymentsMethodFrm"] as Forms.BasicCodeForms.PaymentsMethodFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem72_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ProcessingPurposeFrm f = new Forms.BasicCodeForms.ProcessingPurposeFrm();
            if ((Application.OpenForms["ProcessingPurposeFrm"] as Forms.BasicCodeForms.ProcessingPurposeFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem73_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.ReportsDevX.MenuNameReportsFrm f = new Forms.ReportsDevX.MenuNameReportsFrm();
            if ((Application.OpenForms["MenuNameReportsFrm"] as Forms.ReportsDevX.MenuNameReportsFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem74_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ProjectsFrm f = new Forms.BasicCodeForms.ProjectsFrm();
            if ((Application.OpenForms["ProjectsFrm"] as Forms.BasicCodeForms.ProjectsFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem75_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.StoresFrm f = new Forms.BasicCodeForms.StoresFrm();
            if ((Application.OpenForms["StoresFrm"] as Forms.BasicCodeForms.StoresFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem76_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.PurchaseMethodsFrm f = new Forms.BasicCodeForms.PurchaseMethodsFrm();
            if ((Application.OpenForms["PurchaseMethodsFrm"] as Forms.BasicCodeForms.PurchaseMethodsFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem77_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.StampsFeesFrm f = new Forms.BasicCodeForms.StampsFeesFrm();
            if ((Application.OpenForms["StampsFeesFrm"] as Forms.BasicCodeForms.StampsFeesFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem78_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.AssaysFrm f = new Forms.BasicCodeForms.AssaysFrm();
            if ((Application.OpenForms["AssaysFrm"] as Forms.BasicCodeForms.AssaysFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem79_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.TendersAuctionsFrm f = new Forms.BasicCodeForms.TendersAuctionsFrm();
            if ((Application.OpenForms["TendersAuctionsFrm"] as Forms.BasicCodeForms.TendersAuctionsFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem80_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.DecisionsResponsipilitiesFrm f = new Forms.BasicCodeForms.DecisionsResponsipilitiesFrm();
            if ((Application.OpenForms["DecisionsResponsipilitiesFrm"] as Forms.BasicCodeForms.DecisionsResponsipilitiesFrm != null))
            {

                f.BringToFront();
                this.SendToBack();

            }
            else
            {
                f.Show();
                f.BringToFront();
            }
        }



        private void barButtonItem83_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.LetterWarrantyFrm f = new Forms.BasicCodeForms.LetterWarrantyFrm();
            if ((Application.OpenForms["LetterWarrantyFrm"] as Forms.BasicCodeForms.LetterWarrantyFrm != null))
            {

                f.BringToFront();
                f.radioGroup1.SelectedIndex = 0;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 0;
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem84_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.LetterWarrantyFrm f = new Forms.BasicCodeForms.LetterWarrantyFrm();
            if ((Application.OpenForms["LetterWarrantyFrm"] as Forms.BasicCodeForms.LetterWarrantyFrm != null))
            {

                f.BringToFront();
                f.radioGroup1.SelectedIndex = 1;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 1;
                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem85_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.OrderPurposeFrm f = new Forms.BasicCodeForms.OrderPurposeFrm();
            if ((Application.OpenForms["OrderPurposeFrm"] as Forms.BasicCodeForms.OrderPurposeFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem86_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsArchiving.DocumentHirarchyFrm f = new Forms.DocumentsArchiving.DocumentHirarchyFrm();
            if ((Application.OpenForms["DocumentHirarchyFrm"] as Forms.DocumentsArchiving.DocumentHirarchyFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem88_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsArchiving.DocumentsArchHirarchyFrm f = new Forms.DocumentsArchiving.DocumentsArchHirarchyFrm();
            if ((Application.OpenForms["DocumentsArchHirarchyFrm"] as Forms.DocumentsArchiving.DocumentsArchHirarchyFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem89_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ResponspilityCenterSystemUntNFrm f = new Forms.BasicCodeForms.ResponspilityCenterSystemUntNFrm();
            if ((Application.OpenForms["ResponspilityCenterSystemUntNFrm"] as Forms.BasicCodeForms.ResponspilityCenterSystemUntNFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();
                f.BringToFront();
            }
        }

        private void barButtonItem94_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ChequeFrm f = new Forms.Banks.ChequeFrm();
            if ((Application.OpenForms["ChequeFrm"] as Forms.Banks.ChequeFrm != null))
            {

                f.BringToFront();
                f.radioGroup1.SelectedIndex = 0;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 0;
                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem95_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ChequeFrm f = new Forms.Banks.ChequeFrm();
            if ((Application.OpenForms["ChequeFrm"] as Forms.Banks.ChequeFrm != null))
            {

                f.BringToFront();
                f.radioGroup1.SelectedIndex = 1;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 1;
                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem98_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.RepresentiveFrm f = new Forms.BasicCodeForms.RepresentiveFrm();
            if ((Application.OpenForms["RepresentiveFrm"] as Forms.BasicCodeForms.RepresentiveFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem99_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.DepositeCollectionFrm f = new Forms.Banks.DepositeCollectionFrm();
            if ((Application.OpenForms["DepositeCollectionFrm"] as Forms.Banks.DepositeCollectionFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }



        private void barButtonItem100_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsForms.PrintLetter f = new Forms.DocumentsForms.PrintLetter();
            if ((Application.OpenForms["PrintLetter"] as Forms.DocumentsForms.PrintLetter != null))
            {

                f.BringToFront();
                f.txtProcessid.Text = "0";
                this.SendToBack();

            }
            else
            {

                f.Show();
                f.txtProcessid.Text = "0";
                f.BringToFront();
            }
        }

        private void barButtonItem102_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsForms.PrintLetter f = new Forms.DocumentsForms.PrintLetter();
            if ((Application.OpenForms["PrintLetter"] as Forms.DocumentsForms.PrintLetter != null))
            {

                f.BringToFront();
                f.txtProcessid.Text = "1";
                this.SendToBack();

            }
            else
            {

                f.Show();
                f.txtProcessid.Text = "1";
                f.BringToFront();
            }
        }

        private void barButtonItem93_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.CheqBankStatusADDCancel f = new Forms.Banks.CheqBankStatusADDCancel();
            if ((Application.OpenForms["CheqBankStatusADDCancel"] as Forms.Banks.CheqBankStatusADDCancel != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem104_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.TreasuryDayFrm f = new Forms.Banks.TreasuryDayFrm();
            if ((Application.OpenForms["TreasuryDayFrm"] as Forms.Banks.TreasuryDayFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem105_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsForms.DateaddedFrm f = new Forms.DocumentsForms.DateaddedFrm();
            if ((Application.OpenForms["DateaddedFrm"] as Forms.DocumentsForms.DateaddedFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem106_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.OfficialVacationFRM f = new Forms.BasicCodeForms.OfficialVacationFRM();
            if ((Application.OpenForms["OfficialVacationFRM"] as Forms.BasicCodeForms.OfficialVacationFRM != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }

        }

        private void barButtonItem110_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.PrintAddedCheqDate f = new Forms.Banks.PrintAddedCheqDate();
            if ((Application.OpenForms["PrintAddedCheqDate"] as Forms.Banks.PrintAddedCheqDate != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem111_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.ProcessingForms.SearchRpt.AdvacDerFRMcs f = new Forms.ProcessingForms.SearchRpt.AdvacDerFRMcs();
            if ((Application.OpenForms["AdvacDerFRMcs"] as Forms.ProcessingForms.SearchRpt.AdvacDerFRMcs != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Forms.ProcessingForms.SearchRpt.PrintDesc f = new Forms.ProcessingForms.SearchRpt.PrintDesc();
            if ((Application.OpenForms["PrintDesc"] as Forms.ProcessingForms.SearchRpt.PrintDesc != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Perform data checking here
            CheckDataBank();
            CheckDataAccResAudit();
            //CheckActionUsers(Program.GlbV_UserId);
        }
        private void CheckDataBank()
        {
            if (Program.GlbV_SysUnite_ID == 13)
            {

                var ListCheqAudit = FsDb.Tbl_TreasuryCollection_Audit
                          .Where(x => x.Note != "" && x.IsUpdate == null)
                                           .Select(x => x.ReferenceDate)
                                           .Count();
                int Vstr_UserAddR = 0;

                Vstr_UserAddR = ListCheqAudit;
                if (ListCheqAudit > 0)
                {
                    MessageBox.Show($"يوجد شيكات تمت المراجعه عليها وتم اكتشاف اخطاء بها وعددها {Vstr_UserAddR.ToString()} شيك ");
                    Forms.Banks.CheqAuditUpdateStatus f = new Forms.Banks.CheqAuditUpdateStatus();
                    if ((Application.OpenForms["CheqAuditUpdateStatus"] as Forms.Banks.CheqAuditUpdateStatus != null))
                    {

                        f.BringToFront();

                        this.SendToBack();

                    }
                    else
                    {

                        f.Show();

                        f.BringToFront();
                    }
                }
            }
            else if (Program.GlbV_SysUnite_ID == 12)
            {

                var ListCheqAudit = FsDb.Tbl_TreasuryCollection_Audit.
                           Where(x => x.Note != "" && x.IsUpdate == true && x.NoteAdd != null).Distinct().Count();
                int Vstr_UserAddR = 0;

                Vstr_UserAddR = ListCheqAudit;
                if (ListCheqAudit > 0)
                {
                    MessageBox.Show($"يوجد شيكات تم تعديل بياناتها بعد المراجعه ولم يتم ازالة الخطأ من قبل المراجع وعددها {Vstr_UserAddR.ToString()} شيك ");
                    Forms.Banks.CheqAuditUpdateStatus f = new Forms.Banks.CheqAuditUpdateStatus();
                    if ((Application.OpenForms["CheqAuditUpdateStatus"] as Forms.Banks.CheqAuditUpdateStatus != null))
                    {

                        f.BringToFront();

                        this.SendToBack();

                    }
                    else
                    {

                        f.Show();

                        f.BringToFront();
                    }
                }
                //********************الايرادات 
                var ListCheqAuditER = FsDb.Tbl_DepositCash_Audit.
                                          Where(x => x.Note != "" && x.IsUpdate == true && x.NoteAdd != null).Distinct().Count();
                int Vstr_UserAddRER = 0;

              int  Vstr_UserAddRR = ListCheqAuditER;
                if (ListCheqAuditER > 0)
                {
                    MessageBox.Show($"يوجد ايداعات نقديه تم تعديل بياناتها بعد المراجعه ولم يتم ازالة الخطأ من قبل المراجع وعددها {Vstr_UserAddRR.ToString()} ايداع نقدي ");
                    Forms.CashDeposit.CheqDCAuditUpdateStatus f = new Forms.CashDeposit.CheqDCAuditUpdateStatus();
                    if ((Application.OpenForms["CheqDCAuditUpdateStatus"] as Forms.CashDeposit.CheqDCAuditUpdateStatus != null))
                    {

                        f.BringToFront();

                        this.SendToBack();

                    }
                    else
                    {

                        f.Show();

                        f.BringToFront();
                    }
                }
            }
            else if (Program.GlbV_SysUnite_ID == 11)
                
            {
                var ListCheqAuditER = FsDb.Tbl_DepositCash_Audit
                                         .Where(x => x.Note != "" && x.IsUpdate == null)
                                                          .Select(x => x.ReferenceDate)
                                                          .Count();
                //int Vstr_UserAddR = 0;

             int   Vstr_UserAddRER = ListCheqAuditER;
                if (ListCheqAuditER > 0)
                {
                    MessageBox.Show($"يوجد ايداعات نقديه تمت المراجعه عليها وتم اكتشاف اخطاء بها وعددها {Vstr_UserAddRER.ToString()} ايداع نقدي ");
                    Forms.CashDeposit.CheqDCAuditUpdateStatus f = new Forms.CashDeposit.CheqDCAuditUpdateStatus();
                    if ((Application.OpenForms["CheqDCAuditUpdateStatus"] as Forms.CashDeposit.CheqDCAuditUpdateStatus != null))
                    {

                        f.BringToFront();

                        this.SendToBack();

                    }
                    else
                    {

                        f.Show();

                        f.BringToFront();
                    }
                }

            }
        }

        private void CheckDataAccResAudit()
        {
            var ListAccResAudit = FsDb.Tbl_AccountingRestriction_Audit
                        .Where(x => x.Note != null && x.UserIDData == Program.GlbV_UserId && x.IsUserUpdate == null).Count();
            int Vstr_UserAddR = 0;
            if (ListAccResAudit != 0)
            {
                Vstr_UserAddR = ListAccResAudit;
                MessageBox.Show($"يوجد مستندات تمت المراجعه عليها وتم اكتشاف اخطاء بها وعددها {Vstr_UserAddR.ToString()} مستند ");
                Forms.DocumentsForms.CheqAuditAccRestFrm f = new Forms.DocumentsForms.CheqAuditAccRestFrm();
                if ((Application.OpenForms["CheqAuditAccRestFrm"] as Forms.DocumentsForms.CheqAuditAccRestFrm != null))
                {
                    f.BringToFront();

                    this.SendToBack();

                }
                else
                {

                    f.Show();

                    f.BringToFront();
                }
            }
            var ListRefAccResAudit = FsDb.Tbl_AccountingRestriction_Audit
                        .Where(x => x.Note != null && x.UserID == Program.GlbV_UserId && x.IsUserUpdate == true)
                                         .Select(x => x.ReferenceDate)
                                         .Count();
            int Vstr_UserRefR = 0;

            if (ListRefAccResAudit != 0)
            {
                Vstr_UserRefR = ListRefAccResAudit;
                MessageBox.Show($"يوجد مستندات تم تعديل بياناتها بعد المراجعه ولم يتم ازالة الخطأ من قبل المراجع وعددها {Vstr_UserRefR.ToString()} مستند ");
                Forms.DocumentsForms.CheqRefAuditFrm f = new Forms.DocumentsForms.CheqRefAuditFrm();
                if ((Application.OpenForms["CheqRefAuditFrm"] as Forms.DocumentsForms.CheqRefAuditFrm != null))
                {
                    f.BringToFront();

                    this.SendToBack();

                }
                else
                {

                    f.Show();

                    f.BringToFront();
                }
            }

        }
        private void barButtonItem112_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Forms.Banks.CheqAuditUpdateStatus f = new Forms.Banks.CheqAuditUpdateStatus();
            //if ((Application.OpenForms["CheqAuditUpdateStatus"] as Forms.Banks.CheqAuditUpdateStatus != null))
            //{

            //    f.BringToFront();

            //    this.SendToBack();

            //}
            //else
            //{

            //    f.Show();

            //    f.BringToFront();
            //}
        }

        private void barButtonItem113_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.CheqAuditUpdateStatus f = new Forms.Banks.CheqAuditUpdateStatus();
            if ((Application.OpenForms["CheqAuditUpdateStatus"] as Forms.Banks.CheqAuditUpdateStatus != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem64_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.ProcessingForms.FinanReport.AccountStatement f = new Forms.ProcessingForms.FinanReport.AccountStatement();
            if ((Application.OpenForms["AccountStatement"] as Forms.ProcessingForms.FinanReport.AccountStatement != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem114_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.CashDeposit.CashDepositFrm f = new Forms.CashDeposit.CashDepositFrm();
            if ((Application.OpenForms["CashDepositFrm"] as Forms.CashDeposit.CashDepositFrm != null))
            {

                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem115_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem116_ItemClick(object sender, ItemClickEventArgs e)
        {


        }

        private void barButtonItem117_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsForms.CheqAuditAccRestFrm f = new Forms.DocumentsForms.CheqAuditAccRestFrm();
            if ((Application.OpenForms["CheqAuditAccRestFrm"] as Forms.DocumentsForms.CheqAuditAccRestFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem118_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsForms.CheqRefAuditFrm f = new Forms.DocumentsForms.CheqRefAuditFrm();
            if ((Application.OpenForms["CheqRefAuditFrm"] as Forms.DocumentsForms.CheqRefAuditFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem119_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.AccountsBankFrm f = new Forms.BasicCodeForms.AccountsBankFrm();
            if ((Application.OpenForms["AccountsBankFrm"] as Forms.BasicCodeForms.AccountsBankFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem120_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.CashDeposit.DepositCashQueryFrm f = new Forms.CashDeposit.DepositCashQueryFrm();
            if ((Application.OpenForms["DepositCashQueryFrm"] as Forms.CashDeposit.DepositCashQueryFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }

        }

        private void barButtonItem121_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.DocumentsForms.CheckRestrAuditAtDayFrm f = new Forms.DocumentsForms.CheckRestrAuditAtDayFrm();
            if ((Application.OpenForms["CheckRestrAuditAtDayFrm"] as Forms.DocumentsForms.CheckRestrAuditAtDayFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem122_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.BanksTransferesFrm f = new Forms.Banks.BanksTransferesFrm();
            if ((Application.OpenForms["BanksTransferesFrm"] as Forms.Banks.BanksTransferesFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }

        }

        private void barButtonItem123_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.RefundCheqBankFrm f = new Forms.Banks.RefundCheqBankFrm();
            if ((Application.OpenForms["RefundCheqBankFrm"] as Forms.Banks.RefundCheqBankFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }


        }

        private void barButtonItem124_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.TransferDataBanks.TransferDataBankFrm f = new Forms.Banks.TransferDataBanks.TransferDataBankFrm();
            if ((Application.OpenForms["TransferDataBankFrm"] as Forms.Banks.TransferDataBanks.TransferDataBankFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem125_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.TransferDataBanks.BankTransmentQueryFrm f = new Forms.Banks.TransferDataBanks.BankTransmentQueryFrm();
            if ((Application.OpenForms["BankTransmentQueryFrm"] as Forms.Banks.TransferDataBanks.BankTransmentQueryFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem126_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.TransferDataBanks.TransmetBankCollectedFrm f = new Forms.Banks.TransferDataBanks.TransmetBankCollectedFrm();
            if ((Application.OpenForms["TransmetBankCollectedFrm"] as Forms.Banks.TransferDataBanks.TransmetBankCollectedFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem127_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.PrinQNB  f = new Forms.Banks.PrinQNB();
            if ((Application.OpenForms["PrinQNB"] as Forms.Banks.PrinQNB != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem128_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.TreasuryCollectionsRpt.Print_treasury  f = new Reports.TreasuryCollectionsRpt.Print_treasury();
            if ((Application.OpenForms["Print_treasury"] as Reports.TreasuryCollectionsRpt.Print_treasury != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem129_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Banks.PrintBankDayByDayFrm  f = new Reports.Banks.PrintBankDayByDayFrm();
            if ((Application.OpenForms["PrintBankDayByDayFrm"] as Reports.Banks.PrintBankDayByDayFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Program.GlbV_DateTime = Convert.ToDateTime(Convert.ToDateTime(GetServerDate.Cs_GetServerDate()).ToString("yyyy/MM/dd HH:mm:ss tt")).ToString();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            CheckActionUsers(Program.GlbV_UserId);
        }

        private void barButtonItem130_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.Reports.BankTransmentRpt f = new Forms.Banks.Reports.BankTransmentRpt();
            if ((Application.OpenForms["BankTransmentRpt"] as Reports.Banks.PrintBankDayByDayFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem132_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.CashDeposit.TransmetDepositCashAdFrm f = new Forms.CashDeposit.TransmetDepositCashAdFrm();
            if ((Application.OpenForms["TransmetDepositCashAdFrm"] as Forms.CashDeposit.TransmetDepositCashAdFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem133_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.CashDeposit.TransmetDepositCashAdFrm f = new Forms.CashDeposit.TransmetDepositCashAdFrm();
            if ((Application.OpenForms["TransmetDepositCashAdFrm"] as Forms.CashDeposit.TransmetDepositCashAdFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem134_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.MovmentBankTypeFrm f = new Forms.BasicCodeForms.MovmentBankTypeFrm();
            if ((Application.OpenForms["MovmentBankTypeFrm"] as Forms.BasicCodeForms.MovmentBankTypeFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem135_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.CashDeposit.DepositCashQueryِAuditFrm  f = new Forms.CashDeposit.DepositCashQueryِAuditFrm ();
            if ((Application.OpenForms["DepositCashQueryِAuditFrm "] as Forms.CashDeposit.DepositCashQueryِAuditFrm  != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem136_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.BankStatSettingFrm f = new Forms.Banks.BankStatSettingFrm();
            if ((Application.OpenForms["BankStatSettingFrm "] as Forms.Banks.BankStatSettingFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem137_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.ItemsTreasurCategoryFrm f = new Forms.BasicCodeForms.ItemsTreasurCategoryFrm();
            if ((Application.OpenForms["ItemsTreasurCategoryFrm "] as Forms.BasicCodeForms.ItemsTreasurCategoryFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem138_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.DirectoryItemTrCategoryFem f = new Forms.BasicCodeForms.DirectoryItemTrCategoryFem();
            if ((Application.OpenForms["DirectoryItemTrCategoryFem "] as Forms.BasicCodeForms.DirectoryItemTrCategoryFem != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem139_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.Reports.RefundBankCheqRpt f = new Forms.Banks.Reports.RefundBankCheqRpt();
            if ((Application.OpenForms["RefundBankCheqRpt"] as Banks.Reports.RefundBankCheqRpt != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem140_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.Reports.DueCheqBankRpt f = new Forms.Banks.Reports.DueCheqBankRpt();
            if ((Application.OpenForms["DueCheqBankRpt"] as Banks.Reports.DueCheqBankRpt != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem142_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.Reports.TreasureCollectionCheqAuditFrm f = new Forms.Banks.Reports.TreasureCollectionCheqAuditFrm();
            if ((Application.OpenForms["TreasureCollectionCheqAuditFrm"] as Banks.Reports.TreasureCollectionCheqAuditFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem143_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.Reports.BankCollectedOrNotFrm f = new Forms.Banks.Reports.BankCollectedOrNotFrm();
            if ((Application.OpenForms["BankCollectedOrNotFrm"] as Banks.Reports.BankCollectedOrNotFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem144_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.AuditingCheqFrm f = new Forms.Banks.AuditingCheqFrm();
            if ((Application.OpenForms["AuditingCheqFrm"] as Banks.AuditingCheqFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem145_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.BankTransmetsManualMoveFrm f = new Forms.Banks.BankTransmetsManualMoveFrm();
            if ((Application.OpenForms["BankTransmetsManualMoveFrm"] as Banks.BankTransmetsManualMoveFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem147_ItemClick(object sender, ItemClickEventArgs e)
        {

            Forms.Treasure.TreasurCollectionWithCheqsRpt f = new Forms.Treasure.TreasurCollectionWithCheqsRpt();
            if ((Application.OpenForms["TreasurCollectionWithCheqsRpt"] as Forms.Treasure.TreasurCollectionWithCheqsRpt != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }

        }

        private void barButtonItem149_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ViewRestrictionsOutChequFRM f = new Forms.Banks.ViewRestrictionsOutChequFRM();
            if ((Application.OpenForms["ViewRestrictionsOutChequFRM"] as Forms.Banks.ViewRestrictionsOutChequFRM != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
            
        }

        private void barButtonItem148_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ViewRestrictonsCheqFrm f = new Forms.Banks.ViewRestrictonsCheqFrm();
            if ((Application.OpenForms["ViewRestrictonsCheqFrm"] as Forms.Banks.ViewRestrictonsCheqFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem150_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ChequeNumberSettingFrm f = new Forms.Banks.ChequeNumberSettingFrm();
            if ((Application.OpenForms["ChequeNumberSettingFrm"] as Forms.Banks.ChequeNumberSettingFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem151_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ElectronicPaymentsFrm f = new Forms.Banks.ElectronicPaymentsFrm();
            if ((Application.OpenForms["ElectronicPaymentsFrm"] as Forms.Banks.ElectronicPaymentsFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem153_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Orders.Reports.OrdersDetailsRpt f = new Forms.Orders.Reports.OrdersDetailsRpt();
            if ((Application.OpenForms["OrdersDetailsRpt"] as Forms.Orders.Reports.OrdersDetailsRpt != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem154_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.BasicCodeForms.CustomersTypeFrm f = new Forms.BasicCodeForms.CustomersTypeFrm();
            if ((Application.OpenForms["CustomersTypeFrm"] as Forms.BasicCodeForms.CustomersTypeFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem155_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.NotInDeposidCachFrm  f = new Forms.Banks.NotInDeposidCachFrm();
            if ((Application.OpenForms["NotInDeposidCachFrm"] as Forms.Banks.NotInDeposidCachFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem156_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.NotInBankMovementFrm f = new Forms.Banks.NotInBankMovementFrm();
            if ((Application.OpenForms["NotInBankMovementFrm"] as Forms.Banks.NotInBankMovementFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem157_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ElectronicPaymentAutoFrm f = new Forms.Banks.ElectronicPaymentAutoFrm();
            if ((Application.OpenForms["ElectronicPaymentAutoFrm"] as Forms.Banks.ElectronicPaymentAutoFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem158_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.ElectronicPaymentAuditFrm f = new Forms.Banks.ElectronicPaymentAuditFrm();
            if ((Application.OpenForms["ElectronicPaymentAuditFrm"] as Forms.Banks.ElectronicPaymentAuditFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem91_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.TransferDataBanks.TransmetBankAddTypeingFrm f = new Forms.Banks.TransferDataBanks.TransmetBankAddTypeingFrm();
            if ((Application.OpenForms["TransmetBankAddTypeingFrm"] as Forms.Banks.TransferDataBanks.TransmetBankAddTypeingFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem92_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Banks.Reports.DepositCashAuditFrm f = new Forms.Banks.Reports.DepositCashAuditFrm();
            if ((Application.OpenForms["DepositCashAuditFrm"] as Banks.Reports.DepositCashAuditFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem159_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.ProcessingForms.ExtrasFinancialYearFrm  f = new Forms.ProcessingForms.ExtrasFinancialYearFrm();
            if ((Application.OpenForms["ExtrasFinancialYearFrm"] as Forms.ProcessingForms.ExtrasFinancialYearFrm != null))
            {
                f.BringToFront();

                this.SendToBack();

            }
            else
            {

                f.Show();

                f.BringToFront();
            }
        }

       
        private void barButtonItem160_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Letter_WarrantyForm.LetterWarrantFileToFileRPTFrm f = new Forms.Letter_WarrantyForm.LetterWarrantFileToFileRPTFrm();
            if ((Application.OpenForms["LetterWarrantFileToFileRPTFrm"] as Forms.Letter_WarrantyForm.LetterWarrantFileToFileRPTFrm != null))
            {
                f.BringToFront();
                f.radioGroup1.SelectedIndex = 0;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 0;
                f.Show();

                f.BringToFront();
            }
        }
        private void barButtonItem161_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Letter_WarrantyForm.LetterWarrantFileToFileRPTFrm f = new Forms.Letter_WarrantyForm.LetterWarrantFileToFileRPTFrm();
            if ((Application.OpenForms["LetterWarrantFileToFileRPTFrm"] as Forms.Letter_WarrantyForm.LetterWarrantFileToFileRPTFrm != null))
            {
                f.BringToFront();
                f.radioGroup1.SelectedIndex = 1;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 1;
                f.Show();

                f.BringToFront();
            }
        }
        private void barButtonItem163_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Letter_WarrantyForm.LetterWntryRefundReport f = new Forms.Letter_WarrantyForm.LetterWntryRefundReport();
            if ((Application.OpenForms["LetterWntryRefundReport"] as Forms.Letter_WarrantyForm.LetterWntryRefundReport != null))
            {
                
                f.BringToFront();
                f.radioGroup1.SelectedIndex = 0;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 0;
                f.Show();
                
                f.BringToFront();
            }
        }

        private void barButtonItem164_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Letter_WarrantyForm.LetterWntryRefundReport f = new Forms.Letter_WarrantyForm.LetterWntryRefundReport();
            if ((Application.OpenForms["LetterWntryRefundReport"] as Forms.Letter_WarrantyForm.LetterWntryRefundReport != null))
            {
                f.BringToFront();
                f.radioGroup1.SelectedIndex = 1;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 1;
                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem166_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Letter_WarrantyForm.LetterWarrantyTwoRecieveDateRep f = new Forms.Letter_WarrantyForm.LetterWarrantyTwoRecieveDateRep();
            if ((Application.OpenForms["LetterWarrantyTwoRecieveDateRep"] as Forms.Letter_WarrantyForm.LetterWarrantyTwoRecieveDateRep != null))
            {
                f.BringToFront();
                f.radioGroup1.SelectedIndex = 0;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 0;
                f.Show();

                f.BringToFront();
            }
        }

        private void barButtonItem169_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Letter_WarrantyForm.LetterWarrantyTwoLastExpireDateRep f = new Forms.Letter_WarrantyForm.LetterWarrantyTwoLastExpireDateRep();
            if ((Application.OpenForms["LetterWarrantyTwoLastExpireDateRep"] as Forms.Letter_WarrantyForm.LetterWarrantyTwoLastExpireDateRep != null))
            {
                f.BringToFront();
                f.radioGroup1.SelectedIndex = 0;
                this.SendToBack();

            }
            else
            {
                f.radioGroup1.SelectedIndex = 0;
                f.Show();

                f.BringToFront();
            }
        }
    }
}
