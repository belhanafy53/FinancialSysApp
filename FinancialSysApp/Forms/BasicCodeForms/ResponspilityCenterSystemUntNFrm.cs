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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class ResponspilityCenterSystemUntNFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_SysUnitID = 0;
        int Vint_ResCntR = 0;
        string VStr_ResCntR = "";
        public ResponspilityCenterSystemUntNFrm()
        {
            InitializeComponent();
        }

        private void ResponspilityCenterSystemUntNFrm_Load(object sender, EventArgs e)
        {
            simpleButton1.Enabled = false;
            //var listPrSYS = (from ResCNTR in FsDb.Tbl_ResponspilityCenters
            //                 join ResCUnt in FsDb.Tbl_ResponspilitySystemUnit on ResCNTR.ID equals ResCUnt.ResponspilityCenterID
            //                 where (ResCNTR.Parent_ID == 1)
            //                 orderby (ResCNTR.Parent_ID)
            //                 select new
            //                 {
            //                     ID = ResCNTR.ID,
            //                     Name = ResCNTR.Name,
            //                     Parent_ID = ResCNTR.Parent_ID


            //                 }).OrderBy(t => t.ID).ToList();
            treeList1.DataSource = FsDb.Tbl_ResponspilityCenters.ToList();
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_SystemUnites' table. You can move, or remove it, as needed.
            this.tbl_SystemUnitesTableAdapter.Fill(this.financialSysDataSet.Tbl_SystemUnites);
            if (Program.GlbV_UserTypeId == 1)
            {


                comboBox1.SelectedIndex = -1;
            }
            else if (Program.GlbV_UserTypeId == 2)
            {
                comboBox1.DataSource = FsDb.Tbl_SystemUnites.Where(x => x.ID == Program.GlbV_SysUnite_ID).ToList();
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox1.SelectedIndex = -1;

            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {

                simpleButton1.Enabled = true;
                Vint_SysUnitID = int.Parse(comboBox1.SelectedValue.ToString());
                //******************
                //treeList1.Nodes.Clear();
                var listPrSYS = (from ResCNTR in FsDb.Tbl_ResponspilityCenters
                                 join ResCUnt in FsDb.Tbl_ResponspilitySystemUnit on ResCNTR.ID equals ResCUnt.ResponspilityCenterID
                                 where (ResCUnt.SystemUnitID == Vint_SysUnitID)
                                 orderby (ResCNTR.Parent_ID)
                                 select new
                                 {
                                     ID = ResCNTR.ID,
                                     Name = ResCNTR.Name,
                                     Parent_ID = ResCNTR.Parent_ID


                                 }).OrderBy(t => t.ID).ToList();

                
                int Vint_TreelistCount = treeList1.Nodes.Count();
                List<TreeListNode> nodes = treeList1.GetNodeList();
                foreach (TreeListNode item in nodes)
                {


                    Vint_ResCntR = int.Parse(item.GetValue("ID").ToString());
                    VStr_ResCntR = item.GetValue("Name").ToString();
                    Vint_SysUnitID = int.Parse(comboBox1.SelectedValue.ToString());

                    var listMs = FsDb.Tbl_ResponspilitySystemUnit.FirstOrDefault(x => x.SystemUnitID == Vint_SysUnitID && x.ResponspilityCenterID == Vint_ResCntR);

                    if (listMs != null)
                    {
                        item.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        item.CheckState = CheckState.Unchecked;
                    }

                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 76 && w.ProcdureId == 1);
            if (validationSaveUser != null)
            {
                if (comboBox1.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("من فضلك قم بإختيار وحدة المنظومة ");
                    comboBox1.Focus();
                }
                else
                {
                    var listremove = FsDb.Tbl_MenuProgUnit_SysUnites.Where(x => x.SysUnites_ID == Vint_SysUnitID);

                    FsDb.Tbl_MenuProgUnit_SysUnites.RemoveRange(listremove);

                    FsDb.SaveChanges();

                    foreach (TreeListNode n in treeList1.GetAllCheckedNodes())
                    {
                        Vint_ResCntR = 0;
                        Vint_ResCntR = int.Parse(n.GetValue("ID").ToString());
                        Vint_SysUnitID = int.Parse(comboBox1.SelectedValue.ToString());

                        var listRspSysUnt = FsDb.Tbl_ResponspilitySystemUnit.FirstOrDefault(x => x.SystemUnitID == Vint_SysUnitID && x.ResponspilityCenterID == Vint_ResCntR);
                        if (listRspSysUnt == null)
                        {
                            Tbl_ResponspilitySystemUnit ResSysUnit = new Tbl_ResponspilitySystemUnit
                            {
                                SystemUnitID = int.Parse(comboBox1.SelectedValue.ToString()),
                                ResponspilityCenterID = Vint_ResCntR

                            };
                            FsDb.Tbl_ResponspilitySystemUnit.Add(ResSysUnit);
                            FsDb.SaveChanges();
                            //---------------خفظ ااحداث 
                            int Vint_LastRow = int.Parse(ResSysUnit.ID.ToString());
                            SecurityEvent sev = new SecurityEvent
                            {
                                ActionName = "اضافة لجان الوحدات",
                                TableName = "Tbl_MenuProgUnit_SysUnites",
                                TableRecordId = Vint_LastRow.ToString(),
                                Description = "",
                                ManagementName = Program.GlbV_Management,
                                ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                EmployeeName = Program.GlbV_EmpName,
                                User_ID = Program.GlbV_UserId,
                                UserName = Program.GlbV_UserName,
                                FormName = "شاشة لجان الوحدات"


                            };
                            FsEvDb.SecurityEvents.Add(sev);
                            FsEvDb.SaveChanges();
                        }
                        //************************************
                    }
                    int Vint_TreelistCount = treeList1.Nodes.Count();
                    List<TreeListNode> nodes = treeList1.GetNodeList();
                    //****************لحذف الاحتيارات السابقه التي لم يتم اختيارها ان وجدت
                    foreach (TreeListNode item in nodes)
                    {
                        if (item.CheckState == CheckState.Unchecked)
                        {
                            Vint_ResCntR = 0;
                            Vint_ResCntR = int.Parse(item.GetValue("ID").ToString());
                            var List = FsDb.Tbl_ResponspilitySystemUnit.FirstOrDefault(x => x.ResponspilityCenterID == Vint_ResCntR && x.SystemUnitID == Vint_SysUnitID);
                            if (List != null)
                            {
                                FsDb.Tbl_ResponspilitySystemUnit.Remove(List);
                                FsDb.SaveChanges();
                                //---------------خفظ ااحداث 
                                int Vint_LastRow = int.Parse(List.ID.ToString());
                                SecurityEvent sev = new SecurityEvent
                                {
                                    ActionName = "حذف لجان الوحدات",
                                    TableName = "Tbl_MenuProgUnit_SysUnites",
                                    TableRecordId = Vint_LastRow.ToString(),
                                    Description = "",
                                    ManagementName = Program.GlbV_Management,
                                    ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                                    EmployeeName = Program.GlbV_EmpName,
                                    User_ID = Program.GlbV_UserId,
                                    UserName = Program.GlbV_UserName,
                                    FormName = "شاشة لجان الوحدات"


                                };
                                FsEvDb.SecurityEvents.Add(sev);
                                FsEvDb.SaveChanges();
                                //************************************
                            }


                        }
                    }

                    MessageBox.Show("تم الحفظ");
                }

            }


            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  صفحات وحدات المنظومة .. برجاء مراجعة مدير المنظومه");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
