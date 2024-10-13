using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevExpress.XtraEditors;
using DevExpress.CodeParser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DevExpress.XtraEditors.Filtering.Templates;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class OrderFrm : DevExpress.XtraEditors.XtraForm
    {

        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        //int Vint_Parent_ID = 0;
        int Vint_IdItem = 0;
        //string Vstr_Name = "";
        string vstr_orderNo = "";
        int Vint_KindOrder = 0;
        long? Vint_orderID = 0;
        long? Vlong_orderEsdarAdd = 0;
        int? Vint_OrderPurposeID = 0;
        int? Vint_ResponsipilityDecisionNID = 0;
        int? Vint_SuptId = 0;
        int? Vint_CustId = 0;
        int? Vint_PaperNo = 0;

        public OrderFrm()

        {
            InitializeComponent();
        }

        private void OrderFrm_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ResponspilityCenters1' table. You can move, or remove it, as needed.
            txtDirectEsdr.Text = "";
            txtDirEsdarID.Text = "";
            txtDirectEsdr.Text = "شركة جنوب القاهرة لتوزيع الكهرباء";
            txtDirEsdarID.Text = "18";
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_ValueAddedTax' table. You can move, or remove it, as needed.
            this.tbl_ValueAddedTaxTableAdapter.Fill(this.financialSysDataSet.Tbl_ValueAddedTax);
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Orders' table. You can move, or remove it, as needed.
            this.dTB_OrdersTableAdapter.Fill(this.financialSysDataSet.DTB_Orders);
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Tenders' table. You can move, or remove it, as needed.
            this.dTB_TendersTableAdapter.FillAllTenders(this.financialSysDataSet.DTB_Tenders);
            // TODO: This line of code loads data into the 'financialSysDataSet.DTB_Orders' table. You can move, or remove it, as needed.
            this.dTB_OrdersTableAdapter.Fill(this.financialSysDataSet.DTB_Orders);

            //using (SqlConnection connection = new SqlConnection(Program.GlbV_Connection))
            //{
            //    ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(), "ID", "Name", "Parent_ID", "StoreCode");
            //}
            // TODO: This line of code loads data into the 'financialSysDataSet1.Tbl_QuantityPurposes' table. You can move, or remove it, as needed.
            //this.tbl_QuantityPurposesTableAdapter.Fill(this.financialSysDataSet1.Tbl_QuantityPurposes);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_PurchaseMethods' table. You can move, or remove it, as needed.
            this.tbl_PurchaseMethodsTableAdapter.Fill(this.financialSysDataSet.Tbl_PurchaseMethods);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Supplier' table. You can move, or remove it, as needed.
            this.tbl_SupplierTableAdapter.Fill(this.financialSysDataSet.Tbl_Supplier);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items' table. You can move, or remove it, as needed.
            this.tbl_ItemsTableAdapter.Fill(this.financialSysDataSet.Tbl_Items);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Unites' table. You can move, or remove it, as needed.
            this.tbl_UnitesTableAdapter.Fill(this.financialSysDataSet.Tbl_Unites);
            //************** AutoComplete Order No
            //ordersDataSetBindingSource.DataSource = FsDb.Tbl_Order.ToList();
            //AutoCompleteStringCollection ord = new AutoCompleteStringCollection();
            //foreach (Tbl_Order d in ordersDataSetBindingSource.DataSource as List<Tbl_Order>)
            //    ord.Add(d.Order_NO);
            //textBox1.AutoCompleteCustomSource = ord;
            //radTreeView1.ExpandAll();
            //***************

            if (Program.GlbV_SysUnite_ID == 3)
            {
                lblMNG.Text = "الشبكه";
                label16.Enabled = false;
                txtPaperCount.Enabled = false;
                label17.Enabled = false;
                txtManagementOrder.Multiline = false;
                this.dTB_OrdersTableAdapter.FillBySysuntMost(this.financialSysDataSet.DTB_Orders);
            }
            else if (Program.GlbV_SysUnite_ID == 2)
            {
                lblProcissName.Visible = false;
                txtProcissName.Visible = false;
                txtManagementOrder.Multiline = true;
                this.dTB_OrdersTableAdapter.FillBySysUntTawrd(this.financialSysDataSet.DTB_Orders);
            }
            if (Program.GlbV_SysUnite_ID == 7)


            {
                this.dTB_OrdersTableAdapter.Fill(this.financialSysDataSet.DTB_Orders);
                cmbResponspility.DataSource = (from Rs in FsDb.Tbl_ResponspilityCenters
                                               join RsUNt in FsDb.Tbl_ResponspilitySystemUnit on Rs.ID equals RsUNt.ResponspilityCenterID
                                               where (RsUNt.SystemUnitID == 7)
                                               select new
                                               {
                                                   ID = Rs.ID,
                                                   Name = Rs.Name,
                                                   Parent = Rs.Parent_ID
                                               }).ToList();
                cmbResponspility.DisplayMember = "Name";
                cmbResponspility.ValueMember = "ID";
                cmbPurchMethod.DisplayMember = "Name";
                cmbPurchMethod.ValueMember = "ID";
                cmbPurchMethod.Text = "اختر طريقة الشراء";
                cmbResponspilityN.DataSource = (from Rs in FsDb.Tbl_ResponspilityCenters
                                                join RsUNt in FsDb.Tbl_ResponspilitySystemUnit on Rs.ID equals RsUNt.ResponspilityCenterID
                                                where (RsUNt.SystemUnitID == 7)
                                                select new
                                                {
                                                    ID = Rs.ID,
                                                    Name = Rs.Name,
                                                    Parent = Rs.Parent_ID
                                                }).ToList();
                cmbResponspilityN.DisplayMember = "Name";
                cmbResponspilityN.ValueMember = "ID";

                comboBox1.DataSource = FsDb.Tbl_OrderKind.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
                //dataGridView1.DataSource = FsDb.Tbl_Order.ToList();
            }
            else

            {

                cmbResponspility.DataSource = (from Rs in FsDb.Tbl_ResponspilityCenters
                                               join RsUNt in FsDb.Tbl_ResponspilitySystemUnit on Rs.ID equals RsUNt.ResponspilityCenterID
                                               where (RsUNt.SystemUnitID == Program.GlbV_SysUnite_ID)
                                               select new
                                               {
                                                   ID = Rs.ID,
                                                   Name = Rs.Name,
                                                   Parent = Rs.Parent_ID
                                               }).ToList(); ;
                cmbResponspility.DisplayMember = "Name";
                cmbResponspility.ValueMember = "ID";

                cmbResponspilityN.DataSource = (from Rs in FsDb.Tbl_ResponspilityCenters
                                                join RsUNt in FsDb.Tbl_ResponspilitySystemUnit on Rs.ID equals RsUNt.ResponspilityCenterID
                                                where (RsUNt.SystemUnitID == Program.GlbV_SysUnite_ID)
                                                select new
                                                {
                                                    ID = Rs.ID,
                                                    Name = Rs.Name,
                                                    Parent = Rs.Parent_ID
                                                }).ToList(); ;
                cmbResponspilityN.DisplayMember = "Name";
                cmbResponspilityN.ValueMember = "ID";
                if ((Program.GlbV_UserTypeId == 6 || Program.GlbV_UserTypeId == 2) && Program.GlbV_SysUnite_ID == 3)
                {
                    comboBox1.DataSource = FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Program.GlbV_SysUnite_ID).ToList();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                }
                else if ((Program.GlbV_UserTypeId != 6 ) && Program.GlbV_SysUnite_ID == 3)
                {
                    comboBox1.DataSource = FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Program.GlbV_SysUnite_ID && x.ID == 2).ToList();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                }
                else
                {
                    comboBox1.DataSource = FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Program.GlbV_SysUnite_ID).ToList();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "ID";
                }
            }



            if (Program.GlbV_SysUnite_ID == 7)
            {
                comboBox2.DataSource = FsDb.Tbl_OrderKind.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "ID";
            }
            else

            {
                comboBox2.DataSource = FsDb.Tbl_OrderKind.Where(x => x.SystemUniteID == Program.GlbV_SysUnite_ID).ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "ID";
            }
            cmbResponspilityN.SelectedIndex = -1;
            cmbResponspilityN.Text = "";
            cmbResponspilityN.SelectedText = " اختراللجنه";


            cmbPurchMethod.SelectedIndex = -1;
            cmbPurchMethod.Text = "";
            cmbPurchMethod.SelectedText = " اختر طريقة الشراء";

            cmbResponspility.SelectedIndex = -1;
            cmbResponspility.Text = "";
            cmbResponspility.SelectedText = "اختر اللجنه";

            cmbResponspility.SelectedIndex = -1;
            radioGroup1.SelectedIndex = 0;

            rdgSearchOrderNo.SelectedIndex = 0;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "";
                comboBox1.SelectedText = " اختر نوع الامر";

            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "";
                comboBox2.SelectedText = " اختر نوع الامر";

            }

            txtPaperCount.Text = "0";

            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 43 && w.ProcdureId == 1003);
            if (validationSaveUser != null)
            {
                chckBxBasicData.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                chckBxBasicData.Enabled = false;
                textBox3.Enabled = false;
            }
            comboBox1.Focus();
        }



        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtOrderPurpose.Select();
                this.ActiveControl = txtOrderPurpose;
                txtOrderPurpose.Focus();

            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());
                string vstr_orderNo = textBox1.Text;
                if (rdgSearchOrderNo.SelectedIndex == 0)
                {
                    this.dTB_OrdersTableAdapter.FillByKindOrderOrderNo2(this.financialSysDataSet.DTB_Orders, vstr_orderNo, Vint_KindOrder);
                }
                else
                {
                    this.dTB_OrdersTableAdapter.FillByOrderKindOrderNo(this.financialSysDataSet.DTB_Orders, vstr_orderNo, Vint_KindOrder);
                }
                if (dataGridView1.RowCount == 0)
                {
                    //textBox1.Text = "";
                    textBox2.Text = "";
                    cmbPurchMethod.SelectedIndex = -1;
                    cmbPurchMethod.Text = "";
                    cmbPurchMethod.SelectedText = " اختر طريقة الشراء";

                    radioGroup1.SelectedIndex = 0;

                    rdgSearchOrderNo.SelectedIndex = 0;
                    //if (comboBox1.Items.Count > 0)
                    //{
                    //    comboBox1.SelectedIndex = -1;
                    //    comboBox1.Text = "";
                    //    comboBox1.SelectedText = " اختر نوع الامر";

                    //}
                    dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                    txtSuplierID.Text = "";
                    txtSupliers.Text = "";

                    txtTenderID.Text = "";
                    DtpTender.Value = Convert.ToDateTime(DateTime.Now.ToString());
                    txtTenderNo.Text = "";
                    txtTenderPurpose.Text = "";
                    txtPaperCount.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    chckBxBasicData.Checked = false;

                }
            }
            if (textBox1.Text == "")
            {
                simpleButton4.Enabled = false;
                simpleButton3.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                cmbPurchMethod.SelectedIndex = -1;
                //cmbPurchMethod.SelectedText = "";
                //cmbPurchMethod.SelectedText = " اختر طريقة الشراء";
                txtOrderAddEsn.Text = "";
                dTPOrderAddEsn.Value = Convert.ToDateTime(DateTime.Now.ToString());
                radioGroup1.SelectedIndex = 0;
                txtManagementOrder.Text = "";
                rdgSearchOrderNo.SelectedIndex = 0;
                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedIndex = -1;
                    comboBox2.Text = "";
                    comboBox2.SelectedText = " اختر نوع الامر";

                }
                dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                txtSuplierID.Text = "";
                txtSupliers.Text = "";
                cmbResponspility.SelectedIndex = -1;
                txtResponsipilityDecisionNo.Text = "";
                txtForYear.Text = "";
                txtTenderID.Text = "";
                DtpTender.Value = Convert.ToDateTime(DateTime.Now.ToString());
                txtTenderNo.Text = "";
                txtTenderPurpose.Text = "";
                txtPaperCount.Text = "";
                txtResponsipilityDecisionID.Text = "";
                txtResponsipilityDecisionNo.Text = "";
                txtResponsipilityDecisionNo.Text = "";
                dtpResponsipilityDecision.Value = Convert.ToDateTime(DateTime.Now.ToString());
                Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());
                this.dTB_OrdersTableAdapter.FillByOrderKind(this.financialSysDataSet.DTB_Orders, Vint_KindOrder);
                txtForYear.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                chckBxBasicData.Checked = false;
            }

        }
        private void OrderAuditSelect(long? Vint_OrderIDC)
        {
            var ListOrderAuditOrdUser = FsDb.Tbl_OrderAudit.FirstOrDefault(x => x.OrderId == Vint_OrderIDC && x.UserID == Program.GlbV_UserId);
            if (ListOrderAuditOrdUser != null)
            {
                if (ListOrderAuditOrdUser.OrderIBasicDataID == true)
                { chckBxBasicData.Checked = true; }
                else
                {
                    chckBxBasicData.Checked = false;
                }
            }
            var ListOrderAudit = (from ordAud in FsDb.Tbl_OrderAudit
                                  join usr in FsDb.Tbl_User on ordAud.UserID equals usr.ID
                                  join emp in FsDb.Tbl_Employee on usr.Employee_id equals emp.ID
                                  where (ordAud.OrderId == Vint_OrderIDC)
                                  select new
                                  {
                                      EmpName = emp.Name
                                  }).Distinct().ToList();
            if (ListOrderAudit != null)
            {
                string Vstr_RefrencesOrder = "";
                int WCount = int.Parse(ListOrderAudit.Count.ToString());
                for (int i = 0; i <= WCount - 1; i++)
                {
                    Vstr_RefrencesOrder = ListOrderAudit[i].EmpName + " / " + Vstr_RefrencesOrder;
                }
                textBox3.Text = Vstr_RefrencesOrder;
            }
            else
            {
                textBox3.Text = "";
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            chckBxBasicData.Checked = false;
            textBox3.Text = "";
            txtOrderPuprposeId.Text = "";
            txtManagementID.Text = "";
            txtOrderPurpose.Text = "";
            txtCustID.Text = "";
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (textBox2.Text != "" && int.Parse(textBox2.Text) >= 0)
            {
                Vint_orderID = long.Parse(textBox2.Text);
                //****************Refrences***************
                OrderAuditSelect(Vint_orderID);
                //****************Refrences******User Enter Data *********


                var ListAccRstAudit = FsEvDb.SecurityEvents.Where(x => x.TableRecordId == Vint_orderID.ToString() && x.TableName == "Tbl_Order").Distinct().ToList();

                string Vstr_UserAddR = "";
                int WCount1 = int.Parse(ListAccRstAudit.Count.ToString());
                for (int i = 0; i <= WCount1 - 1; i++)
                {
                    Vstr_UserAddR = Vstr_UserAddR + " / " + ListAccRstAudit[i].EmployeeName;
                }
                textBox4.Text = Vstr_UserAddR;
                //*************الملحوظه على القيود

                //***************************************

                var listOrder = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vint_orderID);

                //var ListOrderManagement = FsDb.Tbl_OrderManagementItems.Where(x => x.OrderId == Vint_orderID).ToList();
                var ListOrderManagement = (from ordMng in FsDb.Tbl_OrderManagementItems
                                           join mng in FsDb.Tbl_Management on ordMng.ManagementID equals mng.Management_ID
                                           where (ordMng.OrderId == Vint_orderID)
                                           select new
                                           {
                                               mng.Management_ID,
                                               mng.Name
                                           }
                                       ).Distinct().ToList();
                if (ListOrderManagement != null)
                {
                    string Vstr_ManagementsOrder = "";
                    int WCount = int.Parse(ListOrderManagement.Count.ToString());
                    if (WCount == 1)
                    {
                        txtManagementOrder.Text = ListOrderManagement[0].Name;
                        txtManagementOldID.Text = ListOrderManagement[0].Management_ID.ToString();
                    }
                    else

                    {
                        for (int i = 0; i <= WCount - 1; i++)
                        {
                            Vstr_ManagementsOrder = ListOrderManagement[i].Name + " / " + Vstr_ManagementsOrder;
                        }
                        txtManagementOrder.Text = Vstr_ManagementsOrder;
                    }


                }
                textBox1.Text = listOrder.Order_NO.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(listOrder.Order_Date.ToString());
                if (listOrder.PaperNumber == null)
                {
                    txtPaperCount.Text = "0";
                }
                else
                {
                    txtPaperCount.Text = listOrder.PaperNumber.ToString();
                }
                comboBox1.SelectedText = "";
                if (listOrder.OrderKind_ID != 0)
                {
                    comboBox1.SelectedValue = listOrder.OrderKind_ID;
                }
                cmbPurchMethod.SelectedText = "";
                if (listOrder.PurchaseMethodsID != null)
                {
                    cmbPurchMethod.SelectedValue = listOrder.PurchaseMethodsID;
                }
                txtOrderPuprposeId.Text = listOrder.OrderPurposeID.ToString();
                if (listOrder.OrderPurposeID != null)
                {
                    var listOprp = FsDb.Tbl_OrderPurpose.FirstOrDefault(x => x.ID == listOrder.OrderPurposeID);
                    if (listOprp != null)
                    {
                        txtOrderPurpose.Text = listOprp.Note.ToString();
                    }

                }
                if (listOrder.DecisionsResponspilitiesID != null)
                {
                    txtResponsipilityDecisionID.Text = listOrder.DecisionsResponspilitiesID.ToString();
                    int vint_decisionresponsId = int.Parse(txtResponsipilityDecisionID.Text);
                    var listDecistionResponspility = FsDb.Tbl_DecisionsResponspilities.FirstOrDefault(x => x.ID == vint_decisionresponsId);
                    cmbResponspility.SelectedValue = int.Parse(listDecistionResponspility.ResponspilityCentersID.ToString());
                    txtResponsipilityDecisionNo.Text = listDecistionResponspility.DecisionNO.ToString();
                    dtpResponsipilityDecision.Value = Convert.ToDateTime(listDecistionResponspility.DecisionDate.ToString());
                    txtForYear.Text = listDecistionResponspility.ForYear.ToString();
                }

                if (listOrder.DecisionsResponspilitiesNID != null)
                {
                    txtResponsipilityDecisionNID.Text = listOrder.DecisionsResponspilitiesNID.ToString();
                    int vint_decisionresponsNId = int.Parse(txtResponsipilityDecisionNID.Text);
                    var listDecistionResponspilityN = FsDb.Tbl_DecisionsResponspilities.FirstOrDefault(x => x.ID == vint_decisionresponsNId);
                    cmbResponspilityN.SelectedValue = int.Parse(listDecistionResponspilityN.ResponspilityCentersID.ToString());
                    txtResponsipilityDecisionNNo.Text = listDecistionResponspilityN.DecisionNO.ToString();
                    dtpResponsipilityDecision.Value = Convert.ToDateTime(listDecistionResponspilityN.DecisionDate.ToString());
                    txtForYear.Text = listDecistionResponspilityN.ForYear.ToString();
                }
                int Vint_mngId = 0;
                if (listOrder.OrderDircEsdarID != null)
                {
                    txtDirEsdarID.Text = listOrder.OrderDircEsdarID.ToString();
                    Vint_mngId = int.Parse(txtDirEsdarID.Text);
                    var Vlist_OrderDrctId = FsDb.Tbl_Management.FirstOrDefault(x => x.Management_ID == Vint_mngId);
                    txtDirectEsdr.Text = Vlist_OrderDrctId.Name.ToString();
                }

                if (listOrder.ProcessName != "")
                {
                    txtProcissName.Text = listOrder.ProcessName;
                }
                if (listOrder.Supp_ID != null)
                {
                    int Vint_suppId = int.Parse(listOrder.Supp_ID.ToString());


                    var listSupp = FsDb.Tbl_Supplier.FirstOrDefault(x => x.ID == Vint_suppId);
                    txtSuplierID.Text = listSupp.ID.ToString();
                    txtSupliers.Text = listSupp.Name.ToString();
                }
                //if (listOrder.OrderAddEsnID)
                if (listOrder.Cust_ID != null)
                {
                    Vint_CustId = int.Parse(listOrder.Cust_ID.ToString());


                    var listSupp = FsDb.Tbl_Customer.FirstOrDefault(x => x.ID == Vint_CustId);
                    txtCustID.Text = listSupp.ID.ToString();
                    txtSupliers.Text = listSupp.Name.ToString();
                }
                txtTenderID.Text = listOrder.TendersAuctionsID.ToString();
                if (txtTenderID.Text != "")
                {
                    int Vint_TenderID = int.Parse(txtTenderID.Text);
                    var list = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_TenderID);
                    txtTenderNo.Text = list.TenderNo.ToString();
                    DtpTender.Value = list.TenderDate;
                    txtTenderPurpose.Text = list.Note.ToString();
                }
                if (listOrder.OrderID != null)
                {
                    var list = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == listOrder.OrderID);
                    if (list.Order_NO != null)
                    {
                        txtOrderAddEsn.Text = list.Order_NO.ToString();
                        dTPOrderAddEsn.Value = list.Order_Date;
                        comboBox2.SelectedValue = list.OrderKind_ID;
                        txtOrderAddEsnID.Text = listOrder.OrderID.ToString();

                    }

                }
                else
                {

                    Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());
                    if (Vint_KindOrder == 2)
                    {

                        HidienObjectsTklf();
                        if (comboBox2.Items.Count > 0)
                        {
                            comboBox2.SelectedValue = 1011;
                            //comboBox2.Text = "";
                            //comboBox2.SelectedText = " اختر نوع الامر";

                        }
                    }
                    else
                    {

                        txtOrderAddEsn.Text = "";
                        dTPOrderAddEsn.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        comboBox2.SelectedIndex = -1;
                    }
                }
                var ListOrderItem = FsDb.Tbl_OrderItems.Where(x => x.OrderID == Vint_orderID).ToList();
                if (ListOrderItem.Count != 0)
                {
                    simpleButton4.Enabled = true;
                    simpleButton3.Enabled = true;
                }
                else
                {
                    simpleButton4.Enabled = true;
                    simpleButton3.Enabled = true;
                }

            }
        }
        private void ItemtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //comboBoxUnite.Focus();
            }

        }

        private void comboBoxUnite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }


        }

        private void QntytextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }

        }

        private void PricetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }

        }


        private void txtSupliers_KeyDown(object sender, KeyEventArgs e)
        {
            Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());
            if (e.KeyCode == Keys.Enter)
            {
                if (Vint_KindOrder == 1011 && Program.GlbV_SysUnite_ID == 3)
                {
                    cmbPurchMethod.Focus();
                }
                else
                {
                    txtOrderAddEsn.Focus();
                }

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Vint_KindOrder == 1009 || Vint_KindOrder == 1010)
                {
                    Forms.ProcessingForms.FindCustomersFrm t = new Forms.ProcessingForms.FindCustomersFrm();

                    t.ShowDialog();
                    if (Forms.ProcessingForms.FindCustomersFrm.SelectedRow != null)
                    {
                        txtSupliers.Text = Forms.ProcessingForms.FindCustomersFrm.SelectedRow.Cells[1].Value.ToString();
                        txtCustID.Text = Forms.ProcessingForms.FindCustomersFrm.SelectedRow.Cells[0].Value.ToString();

                    }
                }
                else
                {
                    Forms.ProcessingForms.FindSupliersFrm t = new Forms.ProcessingForms.FindSupliersFrm();

                    t.ShowDialog();
                    if (Forms.ProcessingForms.FindSupliersFrm.SelectedRow != null)
                    {
                        txtSupliers.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[1].Value.ToString();
                        txtSuplierID.Text = Forms.ProcessingForms.FindSupliersFrm.SelectedRow.Cells[0].Value.ToString();

                    }
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtSuplierID.Text = "";

            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtSuplierID.Text = "";

            }
        }

        private void cmbPurchMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenderNo.Focus();
            }
        }

        private void radioGroup1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                cmbPurchMethod.Focus();
            }
        }





        private void txtTenderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Program.GlbV_SysUnite_ID == 3)

                { cmbResponspility.Focus(); }
                else
                { txtPaperCount.Focus(); }
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.ProcessingForms.FindTendersFrm t = new Forms.ProcessingForms.FindTendersFrm();
                if (cmbPurchMethod.SelectedValue != null)
                {

                    t.textEdit1.Text = this.cmbPurchMethod.SelectedValue.ToString();
                    t.comboBox1.SelectedValue = this.cmbPurchMethod.SelectedValue.ToString();
                    t.txtpurchMethodName.Text = this.cmbPurchMethod.Text;
                    t.ShowDialog();

                    if (Forms.ProcessingForms.FindTendersFrm.SelectedRow != null)
                    {
                        txtTenderID.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[0].Value.ToString();
                        txtTenderNo.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[1].Value.ToString();
                        DtpTender.Value = Convert.ToDateTime(Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[2].Value);
                        txtTenderPurpose.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[4].Value.ToString();
                    }
                    txtPaperCount.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر طريقة الشراء اولا");
                    cmbPurchMethod.Focus();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtTenderID.Text = "";

            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtTenderID.Text = "";

            }
        }

        private void DtpTender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenderPurpose.Focus();
            }

        }

        private void txtTenderPurpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //simpleButton1.Focus();
            }
        }

        private void txtSupliers_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل للاختيار ", TB, 0, 0, VisibleTime);
        }

        private void txtTenderNo_TextChanged(object sender, EventArgs e)
        {
            if (txtTenderNo.Text == "")
            {
                txtTenderID.Text = "";
            }
        }

        private void txtTenderNo_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار المناقصه - المزايده --الامر", TB, 0, 0, VisibleTime);
        }





        private void txtPaperCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbResponspility.Focus();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("من فضلك اختر نوع الامر");
                comboBox1.Focus();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم الامر  ");
                textBox1.Focus();
            }
            else if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("من فضلك ادخل تاريخ الامر  ");
                dateTimePicker1.Focus();

            }
            else if (txtSuplierID.Text == "" && (Vint_KindOrder != 1009 && Vint_KindOrder != 1010))
            {
                MessageBox.Show("من فضلك اختر المورد  ");
                txtSupliers.Focus();
            }
            else if (txtCustID.Text == "" && (Vint_KindOrder == 1009 && Vint_KindOrder == 1010))
            {
                MessageBox.Show("من فضلك اختر العميل  ");
                txtSupliers.Focus();
            }
            else if (int.Parse(comboBox1.SelectedValue.ToString()) == 2 && txtOrderAddEsnID.Text == "")
            {
                MessageBox.Show("من فضلك اختر رقم العقد  ");
                txtOrderAddEsn.Focus();
            }
            else if (txtOrderPuprposeId.Text == "" && txtOrderAddEsnID.Text == "")
            {
                MessageBox.Show("من فضلك اختر التصنيف - الغرض من العمليه  ");
                txtOrderPurpose.Focus();
            }
            else
            {
                Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());

                if (textBox2.Text == "")
                {

                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 43 && w.ProcdureId == 1);
                    if (validationSaveUser != null)
                    {
                        if (txtOrderAddEsnID.Text != "")
                        {
                            Vlong_orderEsdarAdd = long.Parse(txtOrderAddEsnID.Text);
                        }
                        else
                        {
                            Vlong_orderEsdarAdd = null;
                        }

                        int? Vint_purchMethod = null;
                        int? Vint_Tender = null;
                        int? Vint_ResponsipilityDecisionID = null;
                        if (cmbPurchMethod.SelectedValue != null)
                        {
                            Vint_purchMethod = int.Parse(cmbPurchMethod.SelectedValue.ToString());
                            Vint_Tender = int.Parse(txtTenderID.Text);
                        }
                        else
                        {
                            Vint_purchMethod = null;
                            Vint_Tender = null;
                        }
                        if (txtResponsipilityDecisionNID.Text == "")
                        {
                            Vint_ResponsipilityDecisionNID = null;
                        }
                        else
                        {
                            Vint_ResponsipilityDecisionNID = int.Parse(txtResponsipilityDecisionNID.Text);
                        }
                        if (txtResponsipilityDecisionID.Text == "")
                        {
                            Vint_ResponsipilityDecisionID = null;
                        }
                        else
                        {
                            Vint_ResponsipilityDecisionID = int.Parse(txtResponsipilityDecisionID.Text);
                        }
                        if (txtOrderPuprposeId.Text == "")
                        {
                            Vint_OrderPurposeID = null;
                        }
                        else
                        {
                            Vint_OrderPurposeID = int.Parse(txtOrderPuprposeId.Text);
                        }
                       
                        if (txtSuplierID.Text == "")
                        {
                            Vint_SuptId = null;
                        }
                        else
                        {
                            Vint_SuptId = int.Parse(txtSuplierID.Text);
                        }

                        if (txtCustID.Text == "")
                        {
                            Vint_CustId = null;
                        }
                        else
                        {
                            Vint_CustId = int.Parse(txtCustID.Text);
                        }
                        if (txtPaperCount.Text  == "")
                        {
                            Vint_PaperNo = 0;
                        }
                        else
                        {
                            Vint_PaperNo = int.Parse(txtPaperCount.Text);
                        }
                        if (txtPaperCount.Text == "" && Program.GlbV_SysUnite_ID == 3)
                        {
                            txtPaperCount.Text = "0";
                        }
                        Tbl_Order Ordf = new Tbl_Order
                        {
                            Order_NO = (textBox1.Text).Trim(),
                            Order_Date = Convert.ToDateTime( dateTimePicker1.Value.ToString("yyyy/MM/dd")),
                            OrderKind_ID = int.Parse(comboBox1.SelectedValue.ToString()),
                            PurchaseMethodsID = Vint_purchMethod,
                            ExtraOrder = short.Parse(radioGroup1.SelectedIndex.ToString()),
                            PaperNumber = Vint_PaperNo,
                            TendersAuctionsID = Vint_Tender,
                            Supp_ID = Vint_SuptId,
                            DecisionsResponspilitiesID = Vint_ResponsipilityDecisionID,
                            DecisionsResponspilitiesNID = Vint_ResponsipilityDecisionNID,
                            OrderID = Vlong_orderEsdarAdd,
                            OrderPurposeID = Vint_OrderPurposeID,
                            ProcessName = txtProcissName.Text,
                            OrderDircEsdarID = int.Parse(txtDirEsdarID.Text),
                            Cust_ID = Vint_CustId
                        };

                        FsDb.Tbl_Order.Add(Ordf);
                        FsDb.SaveChanges();
                        long Vint_LastRow = Ordf.ID;
                        //**************حفظ الاداره
                        if (txtManagementID.Text != "" && Program.GlbV_SysUnite_ID == 3)
                        {
                            Tbl_OrderManagementItems OrdMng = new Tbl_OrderManagementItems
                            {
                                ManagementID = int.Parse(txtManagementID.Text),
                                OrderId = Vint_LastRow
                            };
                            FsDb.Tbl_OrderManagementItems.Add(OrdMng);
                            FsDb.SaveChanges();
                        }
                        //***************حفظ تعديل الملاحظه 

                        //---------------خفظ ااحداث 
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة امر",
                            TableName = "Tbl_Order",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الاوامر"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //************************************
                        MessageBox.Show("تم الحفظ");
                        this.dTB_OrdersTableAdapter.Fill(this.financialSysDataSet.DTB_Orders);
                        var result1 = MessageBox.Show("هل تريد اضافة امر جديد ؟", "؟", MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.No)
                        {
                            textBox2.Text = Vint_LastRow.ToString();
                            simpleButton4.Enabled = true;
                            simpleButton3.Enabled = true;

                            simpleButton4.Select();
                            this.ActiveControl = simpleButton4;
                            simpleButton4.Focus();

                        }
                        else
                        {
                            simpleButton4.Enabled = false;
                            simpleButton3.Enabled = false;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            cmbPurchMethod.SelectedIndex = -1;
                            cmbPurchMethod.Text = "";
                            cmbPurchMethod.SelectedText = " اختر طريقة الشراء";

                            radioGroup1.SelectedIndex = 0;

                            rdgSearchOrderNo.SelectedIndex = 0;
                            if (comboBox1.Items.Count > 0)
                            {
                                comboBox1.SelectedIndex = -1;
                                comboBox1.Text = "";
                                comboBox1.SelectedText = " اختر نوع الامر";

                            }
                            if (comboBox2.Items.Count > 0)
                            {
                                if (Vint_KindOrder == 2)
                                {

                                    HidienObjectsTklf();
                                    if (comboBox2.Items.Count > 0)
                                    {
                                        comboBox2.SelectedValue = 1011;
                                        //comboBox2.Text = "";
                                        //comboBox2.SelectedText = " اختر نوع الامر";

                                    }

                                }
                                else if (Vint_KindOrder == 1011)
                                {
                                    HidienObjectsEsNad();
                                }
                                else
                                {
                                    comboBox2.SelectedIndex = -1;
                                    comboBox2.Text = "";
                                    comboBox2.SelectedText = " اختر نوع الامر";
                                    ShowObjects();
                                }


                            }
                            if (cmbResponspility.Items.Count > 0)
                            {
                                cmbResponspility.SelectedIndex = -1;
                                cmbResponspility.Text = "";
                                cmbResponspility.SelectedText = " اختر اللجنه";

                            }
                            if (cmbResponspilityN.Items.Count > 0)
                            {
                                cmbResponspilityN.SelectedIndex = -1;
                                cmbResponspilityN.Text = "";
                                cmbResponspilityN.SelectedText = " اختر اللجنه";

                            }
                            txtCustID.Text = "";
                            txtManagementID.Text = "";
                            txtOrderAddEsn.Text = "";
                            dTPOrderAddEsn.Value = Convert.ToDateTime(DateTime.Now.ToString());
                            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                            txtSuplierID.Text = "";
                            txtSupliers.Text = "";
                            txtOrderAddEsn.Text = "";
                            dTPOrderAddEsn.Value = Convert.ToDateTime(DateTime.Now.ToString());
                            cmbResponspility.SelectedValue = 12;
                            txtTenderID.Text = "";
                            DtpTender.Value = Convert.ToDateTime(DateTime.Now.ToString());
                            txtTenderNo.Text = "";
                            txtTenderPurpose.Text = "";
                            txtPaperCount.Text = "";
                            txtResponsipilityDecisionID.Text = "";
                            txtDirectEsdr.Text = "";
                            txtDirEsdarID.Text = "";
                            txtDirectEsdr.Text = "شركة جنوب القاهرة لتوزيع الكهرباء";
                            txtDirEsdarID.Text = "18";

                            txtResponsipilityDecisionNo.Text = "";
                            dtpResponsipilityDecision.Value = Convert.ToDateTime(DateTime.Now.ToString());

                            txtResponsipilityDecisionNID.Text = "";

                            txtResponsipilityDecisionNNo.Text = "";
                            dtpResponsipilityDecisionN.Value = Convert.ToDateTime(DateTime.Now.ToString());

                            txtProcissName.Text = "";
                            txtForYear.Text = "";
                            txtPaperCount.Text = "0";
                            textBox3.Text = "";
                            txtOrderPuprposeId.Text = "";
                            txtOrderPurpose.Text = "";
                            comboBox1.Select();
                            this.ActiveControl = comboBox1;
                            comboBox1.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية اضافة  امر .. برجاء مراجعة مدير المنظومه");
                    }
                }
                else
                {
                    var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 43 && w.ProcdureId == 3);
                    if (validationSaveUser != null)
                    {

                        Vint_orderID = int.Parse(textBox2.Text);
                        Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());
                        var result = FsDb.Tbl_Order.SingleOrDefault(x => x.ID == Vint_orderID && x.OrderKind_ID == Vint_KindOrder);

                        result.Order_NO = textBox1.Text.Trim();
                        result.Order_Date = dateTimePicker1.Value;
                        result.OrderKind_ID = int.Parse(comboBox1.SelectedValue.ToString());
                        long? Vlng_OrderAddEsnId = null;
                        if (txtOrderAddEsnID.Text != "")
                        {
                            Vlng_OrderAddEsnId = long.Parse(txtOrderAddEsnID.Text);
                            result.OrderID = Vlng_OrderAddEsnId;
                        }
                        else
                        {
                            result.OrderID = Vlng_OrderAddEsnId;
                        }
                        if (cmbPurchMethod.SelectedValue != null)
                        {

                            if (txtTenderID.Text != "")
                            {
                                result.TendersAuctionsID = int.Parse(txtTenderID.Text);
                                result.PurchaseMethodsID = int.Parse(cmbPurchMethod.SelectedValue.ToString());
                            }
                            else
                            {
                                result.TendersAuctionsID = null;
                                result.PurchaseMethodsID = null;
                            }
                        }
                        result.ExtraOrder = short.Parse(radioGroup1.SelectedIndex.ToString());
                        result.PaperNumber = int.Parse(txtPaperCount.Text);

                        if (txtOrderPurpose.Text != "")
                        {
                            result.OrderPurposeID = int.Parse(txtOrderPuprposeId.Text);
                        }
                        else
                        {
                            result.OrderPurposeID = null;
                        }
                        if (txtResponsipilityDecisionID.Text != "")
                        {
                            result.DecisionsResponspilitiesID = int.Parse(txtResponsipilityDecisionID.Text);
                        }
                        else
                        {
                            result.DecisionsResponspilitiesID = null;
                        }
                        if (txtResponsipilityDecisionNID.Text != "")
                        {
                            result.DecisionsResponspilitiesNID = int.Parse(txtResponsipilityDecisionNID.Text);
                        }
                        else
                        {
                            result.DecisionsResponspilitiesNID = null;
                        }
                        if (txtOrderPuprposeId.Text != "")
                        {
                            result.OrderPurposeID = int.Parse(txtOrderPuprposeId.Text);
                        }
                        else
                        {
                            result.OrderPurposeID = null;
                        }

                        if (txtSuplierID.Text != "")
                        {
                            result.Supp_ID = int.Parse(txtSuplierID.Text);
                        }
                        else
                        {
                            result.Supp_ID = null;
                        }
                        if (txtCustID.Text != "")
                        {
                            result.Cust_ID = int.Parse(txtCustID.Text);
                        }
                        else
                        {
                            result.Cust_ID = null;
                        }
                        if (txtProcissName.Text != "")
                        {
                            result.ProcessName = txtProcissName.Text;
                        }
                        result.OrderDircEsdarID = int.Parse(txtDirEsdarID.Text);
                        if (txtManagementID.Text != "" && Program.GlbV_SysUnite_ID == 3)
                        {
                            int Vint_mngid = int.Parse(txtManagementID.Text);
                            
                            var listd = FsDb.Tbl_OrderManagementItems.Where(x => x.OrderId == Vint_orderID).ToList();
                            if (listd != null)
                            {
                                FsDb.Tbl_OrderManagementItems.RemoveRange(listd);
                                FsDb.SaveChanges();
                                Tbl_OrderManagementItems OrdMng = new Tbl_OrderManagementItems
                                {
                                    ManagementID = int.Parse(txtManagementID.Text),
                                    OrderId = Vint_orderID
                                };
                                FsDb.Tbl_OrderManagementItems.Add(OrdMng);
                                FsDb.SaveChanges();

                            }
                            else
                            {
                                Tbl_OrderManagementItems OrdMng = new Tbl_OrderManagementItems
                                {
                                    ManagementID = int.Parse(txtManagementID.Text),
                                    OrderId = Vint_orderID
                                };
                                FsDb.Tbl_OrderManagementItems.Add(OrdMng);
                                FsDb.SaveChanges();
                            }
                           
                        }
                        FsDb.SaveChanges();
                        //---------------خفظ ااحداث 

                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "تعديل امر ",
                            TableName = "Tbl_Order",
                            TableRecordId = result.ID.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة الاوامر"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم التعديل");
                        this.dTB_OrdersTableAdapter.Fill(this.financialSysDataSet.DTB_Orders);
                        simpleButton4.Enabled = false;
                        simpleButton3.Enabled = false;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        cmbPurchMethod.SelectedIndex = -1;
                        cmbPurchMethod.Text = "";
                        cmbPurchMethod.SelectedText = " اختر طريقة الشراء";
                        textBox3.Text = "";
                        radioGroup1.SelectedIndex = 0;

                        rdgSearchOrderNo.SelectedIndex = 0;
                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = -1;
                            comboBox1.Text = "";
                            comboBox1.SelectedText = " اختر نوع الامر";

                        }

                        if (comboBox2.Items.Count > 0)
                        {
                            if (Vint_KindOrder == 2)
                            {

                                HidienObjectsTklf();
                                if (comboBox2.Items.Count > 0)
                                {
                                    comboBox2.SelectedValue = 1011;
                                    //comboBox2.Text = "";
                                    //comboBox2.SelectedText = " اختر نوع الامر";

                                }

                            }
                            else if (Vint_KindOrder == 1011)
                            {
                                HidienObjectsEsNad();
                            }
                            else
                            {
                                comboBox2.SelectedIndex = -1;
                                comboBox2.Text = "";
                                comboBox2.SelectedText = " اختر نوع الامر";
                                ShowObjects();
                            }

                        }
                        if (cmbResponspility.Items.Count > 0)
                        {
                            cmbResponspility.SelectedIndex = -1;
                            cmbResponspility.Text = "";
                            cmbResponspility.SelectedText = " اختر اللجنه";

                        }
                        if (cmbResponspilityN.Items.Count > 0)
                        {
                            cmbResponspilityN.SelectedIndex = -1;
                            cmbResponspilityN.Text = "";
                            cmbResponspilityN.SelectedText = " اختر اللجنه";

                        }
                        txtResponsipilityDecisionNID.Text = "";
                        txtProcissName.Text = "";
                        txtResponsipilityDecisionNNo.Text = "";
                        dtpResponsipilityDecisionN.Value = Convert.ToDateTime(DateTime.Now.ToString());

                        txtOrderAddEsn.Text = "";
                        dTPOrderAddEsn.Value = Convert.ToDateTime(DateTime.Now.ToString());

                        dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        txtSuplierID.Text = "";
                        txtSupliers.Text = "";
                        txtDirectEsdr.Text = "";
                        txtDirEsdarID.Text = "";
                        txtDirectEsdr.Text = "";
                        txtDirEsdarID.Text = "";
                        txtDirectEsdr.Text = "شركة جنوب القاهرة لتوزيع الكهرباء";
                        txtDirEsdarID.Text = "18";
                        txtTenderID.Text = "";
                        DtpTender.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        txtTenderNo.Text = "";
                        txtTenderPurpose.Text = "";
                        txtPaperCount.Text = "";
                        txtResponsipilityDecisionID.Text = "";
                        txtResponsipilityDecisionNo.Text = "";
                        txtResponsipilityDecisionNo.Text = "";
                        dtpResponsipilityDecision.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        txtForYear.Text = "";
                        txtOrderPuprposeId.Text = "";
                        txtOrderPurpose.Text = "";
                        comboBox1.Select();
                        this.ActiveControl = comboBox1;
                        comboBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ليس لديك صلاحية تعديل  تصنيف .. برجاء مراجعة مدير المنظومه");
                    }
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Forms.DocumentsForms.OrderItemsFrm t = new Forms.DocumentsForms.OrderItemsFrm();
            t.txtOrderId.Text = this.textBox2.Text;
            t.txtOrderNo.Text = this.textBox1.Text;
            t.txtOrderDate.Text = this.dateTimePicker1.Value.ToString();
            t.dateTimePicker1.Value = this.dateTimePicker1.Value;
            t.txtOrderSupName.Text = this.txtSupliers.Text;
            t.grpOrderData.Text = this.comboBox1.Text;
            t.txtPurchaseMethode.Text = this.cmbPurchMethod.Text;

            if ((Application.OpenForms["OrderItemsFrm"] as OrderItemsFrm != null))
            {
                t.BringToFront();
                this.SendToBack();

            }
            else
            {
                t.Show();
                t.BringToFront();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 43 && w.ProcdureId == 4);
            if (validationSaveUser != null)
            {
                Vint_orderID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var resultMessageYesNo = MessageBox.Show("هل تريد حدف هدا الامر  ؟", "حدف  الامر ", MessageBoxButtons.YesNo);

                if (resultMessageYesNo == DialogResult.Yes)
                {
                    var listCheckOrderItem = FsDb.Tbl_OrderItems.FirstOrDefault(x => x.OrderID == Vint_orderID);
                    var listCheckOrderDocument = FsDb.TBL_Document.FirstOrDefault(x => x.Order_ID == Vint_orderID);
                    var listCheckOrderAuditing = FsDb.Tbl_OrderAudit.FirstOrDefault(x => x.OrderId == Vint_orderID);
                    var listCheckOrderMNGitem = FsDb.Tbl_OrderManagementItems.FirstOrDefault(x => x.OrderId == Vint_orderID);
                    if (listCheckOrderItem != null)
                    {
                        MessageBox.Show($"هذا الامر لايمكن حذفه لوجود بنود مسجله عليه");
                    }

                    else if (listCheckOrderDocument != null)
                    {
                        MessageBox.Show($"هذا الامر لايمكن حذفه لوجود مستندات مسجله عليه");
                    }
                    else if (listCheckOrderAuditing != null)
                    {
                        MessageBox.Show($"هذا الامر لايمكن حذفه لوجود مستندات مسجله عليه");
                    }
                     
                    else if (listCheckOrderItem == null && listCheckOrderDocument == null && listCheckOrderAuditing == null)
                    {
                        if (listCheckOrderMNGitem != null)
                        { FsDb.Tbl_OrderManagementItems.Remove(listCheckOrderMNGitem); }
                        var ListOrdereDel = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vint_orderID);
                        FsDb.Tbl_Order.Remove(ListOrdereDel);
                        FsDb.SaveChanges();
                        MessageBox.Show("تم الحذف");
                        this.dTB_OrdersTableAdapter.Fill(this.financialSysDataSet.DTB_Orders);
                        simpleButton4.Enabled = false;
                        simpleButton3.Enabled = false;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        cmbPurchMethod.SelectedIndex = -1;
                        cmbPurchMethod.SelectedText = " اختر طريقة الشراء";

                        radioGroup1.SelectedIndex = 0;
                        rdgSearchOrderNo.SelectedIndex = 0;
                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = -1;
                            comboBox1.SelectedText = " اختر نوع الامر";

                        }
                        if (comboBox2.Items.Count > 0)
                        {
                            comboBox2.SelectedIndex = -1;
                            comboBox2.SelectedText = " اختر نوع الامر";

                        }
                        if (cmbResponspility.Items.Count > 0)
                        {
                            cmbResponspility.SelectedIndex = -1;
                            cmbResponspility.Text = "";
                            cmbResponspility.SelectedText = " اختر اللجنه";

                        }
                        if (cmbResponspilityN.Items.Count > 0)
                        {
                            cmbResponspilityN.SelectedIndex = -1;
                            cmbResponspilityN.Text = "";
                            cmbResponspilityN.SelectedText = " اختر اللجنه";

                        }
                        txtResponsipilityDecisionNID.Text = "";
                        txtManagementID.Text = "";
                        txtResponsipilityDecisionNNo.Text = "";
                        dtpResponsipilityDecisionN.Value = Convert.ToDateTime(DateTime.Now.ToString());

                        txtOrderAddEsn.Text = "";
                        dTPOrderAddEsn.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        txtSuplierID.Text = "";
                        txtSupliers.Text = "";

                        txtTenderID.Text = "";
                        DtpTender.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        txtTenderNo.Text = "";
                        txtTenderPurpose.Text = "";
                        txtPaperCount.Text = "";
                        txtResponsipilityDecisionID.Text = "";
                        txtResponsipilityDecisionNo.Text = "";
                        txtResponsipilityDecisionNo.Text = "";
                        dtpResponsipilityDecision.Value = Convert.ToDateTime(DateTime.Now.ToString());
                        txtForYear.Text = "";
                        txtProcissName.Text = "";
                        comboBox1.Select();
                        this.ActiveControl = comboBox1;
                        comboBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show(" لايمكن حذف هذا الامر لوجود بنود / مستندات مسجله على هدا الامر");
                    }

                }
                else
                {
                    simpleButton4.Enabled = false;
                    simpleButton3.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    cmbPurchMethod.SelectedIndex = -1;
                    cmbPurchMethod.SelectedText = " اختر طريقة الشراء";

                    radioGroup1.SelectedIndex = 0;
                    rdgSearchOrderNo.SelectedIndex = 0;
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = -1;
                        comboBox1.SelectedText = " اختر نوع الامر";

                    }
                    if (cmbResponspility.Items.Count > 0)
                    {
                        cmbResponspility.SelectedIndex = -1;
                        cmbResponspility.Text = "";
                        cmbResponspility.SelectedText = " اختر اللجنه";

                    }
                    if (cmbResponspilityN.Items.Count > 0)
                    {
                        cmbResponspilityN.SelectedIndex = -1;
                        cmbResponspilityN.Text = "";
                        cmbResponspilityN.SelectedText = " اختر اللجنه";

                    }
                    txtResponsipilityDecisionNID.Text = "";

                    txtResponsipilityDecisionNNo.Text = "";
                    dtpResponsipilityDecisionN.Value = Convert.ToDateTime(DateTime.Now.ToString());

                    dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                    txtSuplierID.Text = "";
                    txtSupliers.Text = "";

                    txtTenderID.Text = "";
                    DtpTender.Value = Convert.ToDateTime(DateTime.Now.ToString());
                    txtTenderNo.Text = "";
                    txtTenderPurpose.Text = "";
                    txtPaperCount.Text = "";
                    txtResponsipilityDecisionID.Text = "";
                    txtResponsipilityDecisionNo.Text = "";
                    txtResponsipilityDecisionNo.Text = "";
                    dtpResponsipilityDecision.Value = Convert.ToDateTime(DateTime.Now.ToString());
                    txtForYear.Text = "";
                    txtProcissName.Text = "";
                    comboBox1.Select();
                    this.ActiveControl = comboBox1;
                    comboBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية اضافة  بند .. برجاء مراجعة مدير المنظومه");
            }
        }





        private void txtResponsipilityDecisionNo_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار اللجنه ورقم - تاريخ", TB, 0, 0, VisibleTime);
        }

        private void txtResponsipilityDecisionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbResponspilityN.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.ProcessingForms.FindDecisionsResponspilities t = new Forms.ProcessingForms.FindDecisionsResponspilities();
                if (cmbResponspility.SelectedValue != null)
                {

                    t.textEdit1.Text = this.cmbResponspility.SelectedValue.ToString();
                    t.comboBox1.SelectedValue = this.cmbResponspility.SelectedValue.ToString();
                    t.txtRespName.Text = this.cmbResponspility.Text;
                    t.ShowDialog();

                    if (Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow != null)
                    {
                        txtResponsipilityDecisionID.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[0].Value.ToString();
                        txtResponsipilityDecisionNo.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[1].Value.ToString();
                        dtpResponsipilityDecision.Value = Convert.ToDateTime(Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[2].Value);
                        txtForYear.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[3].Value.ToString();

                    }
                    cmbResponspilityN.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر اللجنه اولا");
                    cmbResponspility.Focus();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtResponsipilityDecisionID.Text = "";
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtResponsipilityDecisionID.Text = "";
            }
        }

        private void cmbResponspility_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtResponsipilityDecisionNo.Focus();
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار الاداره / الادارات", TB, 0, 0, VisibleTime);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Program.GlbV_SysUnite_ID == 2 || Program.GlbV_SysUnite_ID == 7)
                {
                    cmbPurchMethod.Focus();
                }

                else if (int.Parse(comboBox1.SelectedValue.ToString()) == 1011 && Program.GlbV_SysUnite_ID == 3)
                {
                    cmbPurchMethod.Focus();
                }
                else if (int.Parse(comboBox1.SelectedValue.ToString()) == 2 && Program.GlbV_SysUnite_ID == 3)
                {
                    txtProcissName.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Program.GlbV_SysUnite_ID == 2 || Program.GlbV_SysUnite_ID == 7)
                {
                    if (simpleButton4.Enabled == false)
                    { MessageBox.Show("يجب ادحال البنود للأمر اولاً"); }
                    else if (txtSupliers.Text != "")
                    {
                        Forms.DocumentsForms.FindManagementsItemsOrder t = new Forms.DocumentsForms.FindManagementsItemsOrder();


                        t.txtOrderId.Text = this.textBox2.Text;
                        t.txtOrderNo.Text = this.textBox1.Text;

                        t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                        t.txtOrderSupName.Text = this.txtSupliers.Text;
                        t.grpOrderData.Text = this.comboBox1.Text;

                        t.ShowDialog();

                        if (t.txtOrderManagementID != null)
                        {
                            txtManagementOrder.Text = t.txtManagementOrder.Text;

                        }
                        radioGroup1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("من فضلك اختر المورد  ");
                        txtSupliers.Focus();
                    }

                }
                else if (Program.GlbV_SysUnite_ID == 3)
                {
                    Forms.BasicCodeForms.FindManagementFrm t = new Forms.BasicCodeForms.FindManagementFrm();
                    t.ShowDialog();

                    if (t.txtManagementId != null)
                    {

                        txtManagementOrder.Text = t.txtSelected.Text;
                        txtManagementID.Text = t.txtManagementId.Text;

                    }
                    txtProcissName.Focus();
                }
            }
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار الامر - تاريخ", TB, 0, 0, VisibleTime);
        }

        private void textBox3_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtManagementOrder.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.BasicCodeForms.FindOrdersFrm t = new Forms.BasicCodeForms.FindOrdersFrm();
                if (comboBox2.SelectedValue != null)
                {

                    t.textEdit1.Text = this.comboBox2.SelectedValue.ToString();
                    int Vint_OrderKind = int.Parse(t.textEdit1.Text);
                    int vint_SupId = int.Parse(txtSuplierID.Text);

                    
                    //where (ord.OrderKind_ID == Vint_OrderKind)
                    
                    t.dataGridView1.DataSource = (from ord in FsDb.Tbl_Order
                                                  join purchMth in FsDb.Tbl_PurchaseMethods on ord.PurchaseMethodsID equals purchMth.ID
                                                  join Tndr in FsDb.Tbl_TendersAuctions on ord.TendersAuctionsID equals Tndr.ID
                                                  join supp in FsDb.Tbl_Supplier on ord.Supp_ID equals supp.ID
                                                  join ordK in FsDb.Tbl_OrderKind on ord.OrderKind_ID equals ordK.ID
                                                  where (ord.OrderKind_ID == Vint_OrderKind && supp.ID == vint_SupId)
                                                  select new
                                                  {
                                                      ID = ord.ID,
                                                      Order_NO = ord.Order_NO,
                                                      Order_Date = ord.Order_Date,
                                                      PurchaseMethodsID = ord.PurchaseMethodsID,
                                                      purchaseMethodName = purchMth.Name,
                                                      suppName = supp.Name,
                                                      supp_ID = ord.Supp_ID,
                                                      Tender_No = Tndr.TenderNo,
                                                      TNote = Tndr.Note,
                                                      KindOrd = ordK.Name,
                                                      kindordid = ordK.ID,
                                                  }
                                       ).OrderBy(x => x.Order_Date).ToList();
                    t.DtaGrdView();
                    t.comboBox1.SelectedValue = this.comboBox2.SelectedValue.ToString();
                    t.txtOrderKindName.Text = this.comboBox2.Text;
                    t.textEdit2.Text = txtSupliers.Text;
                    t.txtSupId.Text = txtSuplierID.Text;
                    t.ShowDialog();

                    if (Forms.BasicCodeForms.FindOrdersFrm.SelectedRow != null)
                    {
                        txtOrderAddEsnID.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[0].Value.ToString();
                        txtOrderAddEsn.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[1].Value.ToString();
                        dTPOrderAddEsn.Value = Convert.ToDateTime(Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[2].Value);
                        cmbPurchMethod.SelectedValue = int.Parse(Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[3].Value.ToString());
                        long Vint_OrderID = int.Parse(txtOrderAddEsnID.Text);
                        var ListOrderAuc = FsDb.Tbl_Order.FirstOrDefault(x => x.ID == Vint_OrderID);
                        int Vint_TenderID = int.Parse(ListOrderAuc.TendersAuctionsID.ToString());
                        var list = FsDb.Tbl_TendersAuctions.FirstOrDefault(x => x.ID == Vint_TenderID);
                        if (list != null)
                        {
                            txtTenderNo.Text = list.TenderNo;
                            txtTenderID.Text = ListOrderAuc.TendersAuctionsID.ToString();
                            DtpTender.Value = list.TenderDate;
                        }
                        //txtSupliers.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[5].Value.ToString();
                        //txtSuplierID.Text = Forms.BasicCodeForms.FindOrdersFrm.SelectedRow.Cells[6].Value.ToString();
                        //txtTenderPurpose.Text = Forms.ProcessingForms.FindTendersFrm.SelectedRow.Cells[4].Value.ToString();
                    }
                    txtManagementOrder.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر نوع الامر اولا");
                    comboBox2.Focus();
                }



            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOrderAddEsn.Focus();
            }
        }

        private void textBox3_Enter_2(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لإثبات مراجعة الأمر", TB, 0, 0, VisibleTime);
        }

        private void textBox3_KeyDown_2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.OrderAuditAddFrm t = new Forms.DocumentsForms.OrderAuditAddFrm();
                t.txtOrderId.Text = this.textBox2.Text;
                t.txtOrderNo.Text = this.textBox1.Text;

                t.dateTimePicker1.Value = this.dateTimePicker1.Value;
                if (textBox2.Text != "")
                {
                    t.ShowDialog();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر الامر المراد مراجعته اولا");
                }
                //if (Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow != null)
                //{
                //    txtSupliers.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[1].Value.ToString();
                //    txtSuplierID.Text = Forms.DocumentsForms.OrderAuditAddFrm.SelectedRow.Cells[0].Value.ToString();

                //}
            }
        }


        private void chckBxBasicData_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text != "")
            {
                long Vlng_OrderID = long.Parse(textBox2.Text);
                bool Vbl_BasicDataOrder = false;
                var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 66 && w.ProcdureId == 1);
                if (validationSaveUser != null)
                {


                    Vbl_BasicDataOrder = true;
                    var ListOrderAuditOrdUser = FsDb.Tbl_OrderAudit.FirstOrDefault(x => x.OrderId == Vlng_OrderID && x.UserID == Program.GlbV_UserId);
                    if (ListOrderAuditOrdUser == null)

                    {

                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));


                        Tbl_OrderAudit OrdAud = new Tbl_OrderAudit
                        {

                            UserID = Program.GlbV_UserId,
                            OrderId = Vlng_OrderID,
                            OrderIBasicDataID = Vbl_BasicDataOrder,
                            //OrderIItemDataID = Vbl_itemso,
                            //OrderITermsID = Vbl_termso,
                            ReferenceDate = Vdt_Today
                        };
                        FsDb.Tbl_OrderAudit.Add(OrdAud);
                        FsDb.SaveChanges();

                        int Vint_LastRow = OrdAud.ID;
                        SecurityEvent sev = new SecurityEvent
                        {
                            ActionName = "اضافة مراجعة امر",
                            TableName = "Tbl_OrderAudit",
                            TableRecordId = Vint_LastRow.ToString(),
                            Description = "",
                            ManagementName = Program.GlbV_Management,
                            ActionDate = Convert.ToDateTime(Program.GlbV_DateTime),
                            EmployeeName = Program.GlbV_EmpName,
                            User_ID = Program.GlbV_UserId,
                            UserName = Program.GlbV_UserName,
                            FormName = "شاشة مراجعة الاوامر"


                        };
                        FsEvDb.SecurityEvents.Add(sev);
                        FsEvDb.SaveChanges();
                        //***************************
                        MessageBox.Show("تم الحفظ");
                        //****************Refrences***************
                        OrderAuditSelect(Vlng_OrderID);
                        //***************************************


                    }
                    else
                    {
                        if (chckBxBasicData.Checked == true)
                        {
                            Vbl_BasicDataOrder = true;
                        }
                        else
                        {
                            Vbl_BasicDataOrder = false;
                        }
                        DateTime Vdt_Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));

                        var ListOrderAuditOrdUsero = FsDb.Tbl_OrderAudit.FirstOrDefault(x => x.OrderId == Vlng_OrderID && x.UserID == Program.GlbV_UserId);
                        ListOrderAuditOrdUsero.OrderIBasicDataID = Vbl_BasicDataOrder;
                        //ListOrderAuditOrdUsero.OrderIItemDataID = Vbl_itemso;
                        //ListOrderAuditOrdUsero.OrderITermsID = Vbl_termso;
                        ListOrderAuditOrdUsero.ReferenceDate = Vdt_Today;
                        FsDb.SaveChanges();
                        MessageBox.Show("تم التعديل");
                        //****************Refrences***************
                        OrderAuditSelect(Vlng_OrderID);
                        //***************************************

                    }

                }

                else
                {
                    MessageBox.Show("ليس لديك صلاحية اضافة  مراجعه امر .. برجاء مراجعة مدير المنظومه");
                }
            }
            else
            {
                MessageBox.Show("اختر الامر المراد مراجعته");
            }

        }
        private void HidienObjectsEsNad()
        {
            label25.Visible = false;
            comboBox2.Visible = false;
            label22.Visible = false;
            txtOrderAddEsn.Visible = false;
            label23.Visible = false;
            dTPOrderAddEsn.Visible = false;
            label11.Visible = false;
            radioGroup1.Visible = false;
            lblMNG.Visible = false;
            txtManagementOrder.Visible = false;
            label27.Visible = true;

            txtOrderPurpose.Visible = true;
            lblProcissName.Visible = false;
            txtProcissName.Visible = false;

            //*************

            label9.Visible = true;
            cmbPurchMethod.Visible = true;
            label12.Visible = true;
            txtTenderNo.Visible = true;
            label13.Visible = true;
            DtpTender.Visible = true;
            label15.Visible = true;
            txtTenderPurpose.Visible = true;
            label16.Visible = true;
            txtPaperCount.Visible = true;
            label17.Visible = true;
            label10.Visible = true;
            cmbResponspility.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            txtResponsipilityDecisionNo.Visible = true;
            dtpResponsipilityDecision.Visible = true;
            txtForYear.Visible = true;
            label31.Visible = true;
            cmbResponspilityN.Visible = true;

            label28.Visible = true;
            label29.Visible = true;
            label30.Visible = true;

            txtResponsipilityDecisionNNo.Visible = true;
            dtpResponsipilityDecisionN.Visible = true;
            txtForYearN.Visible = true;
        }

        private void HidienObjectsTklf()
        {
            label25.Visible = true;
            comboBox2.Visible = true;
            label22.Visible = true;
            txtOrderAddEsn.Visible = true;
            label23.Visible = true;
            dTPOrderAddEsn.Visible = true;
            label11.Visible = true;
            radioGroup1.Visible = true;
            lblMNG.Visible = true;
            txtManagementOrder.Visible = true;
            label27.Visible = true;
            txtOrderPurpose.Visible = true;
            lblProcissName.Visible = true;
            txtProcissName.Visible = true;
            //*********
            label9.Visible = false;
            cmbPurchMethod.Visible = false;
            label12.Visible = false;
            txtTenderNo.Visible = false;
            label13.Visible = false;
            DtpTender.Visible = false;
            label15.Visible = false;
            txtTenderPurpose.Visible = false;
            label16.Visible = false;
            txtPaperCount.Visible = false;
            label17.Visible = false;
            label10.Visible = false;
            cmbResponspility.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            txtResponsipilityDecisionNo.Visible = false;
            dtpResponsipilityDecision.Visible = false;
            txtForYear.Visible = false;
            label31.Visible = false;
            cmbResponspilityN.Visible = false;
            label11.Visible = false;
            radioGroup1.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;

            txtResponsipilityDecisionNNo.Visible = false;
            dtpResponsipilityDecisionN.Visible = false;
            txtForYearN.Visible = false;

        }
        private void ShowObjects()
        {
            label25.Visible = true;
            comboBox2.Visible = true;
            label22.Visible = true;
            txtOrderAddEsn.Visible = true;
            label23.Visible = true;
            dTPOrderAddEsn.Visible = true;
            label11.Visible = true;
            radioGroup1.Visible = true;
            lblMNG.Visible = true;
            txtManagementOrder.Visible = true;
            label27.Visible = true;
            txtOrderPurpose.Visible = true;
            lblProcissName.Visible = false;
            txtProcissName.Visible = false;
            //*********
            label9.Visible = true;
            cmbPurchMethod.Visible = true;
            label12.Visible = true;
            txtTenderNo.Visible = true;
            label13.Visible = true;
            DtpTender.Visible = true;
            label15.Visible = true;
            txtTenderPurpose.Visible = true;
            label16.Visible = true;
            txtPaperCount.Visible = true;
            label17.Visible = true;
            label10.Visible = true;
            cmbResponspility.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            txtResponsipilityDecisionNo.Visible = true;
            dtpResponsipilityDecision.Visible = true;
            txtForYear.Visible = true;
            label31.Visible = true;
            cmbResponspilityN.Visible = true;

            label28.Visible = true;
            label29.Visible = true;
            label30.Visible = true;

            txtResponsipilityDecisionNNo.Visible = true;
            dtpResponsipilityDecisionN.Visible = true;
            txtForYearN.Visible = true;

        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Vint_KindOrder = int.Parse(comboBox1.SelectedValue.ToString());
            if (Vint_KindOrder == 2)
            {

                HidienObjectsTklf();
                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedValue = 1011;
                    //comboBox2.Text = "";
                    //comboBox2.SelectedText = " اختر نوع الامر";

                }

            }
            else if (Vint_KindOrder == 1011)
            {
                HidienObjectsEsNad();
            }
            else if (Vint_KindOrder == 1009 || Vint_KindOrder == 1010)
            {
                label8.Text = "العميل";
            }
            else
            {
                label8.Text = "المورد / المقاول";
            }
            this.dTB_OrdersTableAdapter.FillByOrderKind(this.financialSysDataSet.DTB_Orders, Vint_KindOrder);

            simpleButton4.Enabled = false;
            simpleButton3.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            cmbPurchMethod.SelectedIndex = -1;
            cmbPurchMethod.Text = "";
            cmbPurchMethod.SelectedText = " اختر طريقة الشراء";

            radioGroup1.SelectedIndex = 0;
            rdgSearchOrderNo.SelectedIndex = 0;


            if (cmbResponspility.Items.Count > 0)
            {
                cmbResponspility.SelectedIndex = -1;
                cmbResponspility.Text = "";
                cmbResponspility.SelectedText = " اختر اللجنه";

            }
            if (cmbResponspilityN.Items.Count > 0)
            {
                cmbResponspilityN.SelectedIndex = -1;
                cmbResponspilityN.Text = "";
                cmbResponspilityN.SelectedText = " اختر اللجنه";

            }
            txtResponsipilityDecisionNID.Text = "";
            txtManagementID.Text = "";
            txtResponsipilityDecisionNNo.Text = "";
            dtpResponsipilityDecisionN.Value = Convert.ToDateTime(DateTime.Now.ToString());

            txtOrderAddEsn.Text = "";
            dTPOrderAddEsn.Value = Convert.ToDateTime(DateTime.Now.ToString());
            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
            txtSuplierID.Text = "";
            txtSupliers.Text = "";

            txtTenderID.Text = "";
            DtpTender.Value = Convert.ToDateTime(DateTime.Now.ToString());
            txtTenderNo.Text = "";
            txtTenderPurpose.Text = "";
            txtPaperCount.Text = "";
            txtResponsipilityDecisionID.Text = "";
            txtResponsipilityDecisionNo.Text = "";
            txtResponsipilityDecisionNo.Text = "";
            dtpResponsipilityDecision.Value = Convert.ToDateTime(DateTime.Now.ToString());
            txtForYear.Text = "";
            txtProcissName.Text = "";
            txtOrderPurpose.Text = "";
            //textBox1.Select();
            //this.ActiveControl = textBox1;
            //textBox1.Focus();
            //var listOrderPurpose = FsDb.Tbl_OrderPurpose.Where(x => x.OrderKindID == Vint_KindOrder).ToList();
            //if (listOrderPurpose.Count() == 1)
            //{
            //    txtOrderPurpose.Text = listOrderPurpose[0].Note;
            //}
            //else
            //{
            //    txtOrderPurpose.Text = "";
            //}
        }

        private void txtOrderAddEsn_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderAddEsn.Text == "")
            {
                txtOrderAddEsnID.Text = "";
            }

        }

        private void cmbOrderPurpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPurchMethod.Focus();
            }
        }

        private void Nametxt_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار الغرض من الامر", TB, 0, 0, VisibleTime);
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupliers.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.FindOrderPurposeFrm t = new Forms.DocumentsForms.FindOrderPurposeFrm();
                if (comboBox1.SelectedValue != null)
                {
                    t.txtOrderKindId.Text = comboBox1.SelectedValue.ToString();
                    t.ShowDialog();
                    if (t.txtSelected.Text != "")
                    {
                        txtOrderPuprposeId.Text = "";
                        txtOrderPurpose.Text = t.txtSelected.Text;
                        txtOrderPuprposeId.Text = t.txtOrderPuprposeId.Text;
                        Vint_OrderPurposeID = int.Parse(txtOrderPuprposeId.Text);
                        DateTime Vstr_datetimePicker = DateTime.Parse( dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                        string Vstr_KindOrder = comboBox1.SelectedText.ToString();
                        DateTime Vdt_OrderDate = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
                        vstr_orderNo = textBox1.Text;
                        var ListOrderNoDate = FsDb.Tbl_Order.Where(x => x.Order_NO == vstr_orderNo && x.Order_Date == Vdt_OrderDate && x.OrderPurposeID == Vint_OrderPurposeID && x.OrderKind_ID == Vint_KindOrder).ToList();
                        if (ListOrderNoDate.Count != 0 && textBox2.Text == "")
                        {

                            MessageBox.Show($"هذا الأمر {Vstr_KindOrder} رقم {vstr_orderNo}  بتاريخ {Vstr_datetimePicker} تم ادخاله من قبل ");
                            textBox1.Text = "";
                            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString());
                            textBox1.Select();
                            this.ActiveControl = textBox1;
                            textBox1.Focus();
                        }
                        else
                        {

                            txtOrderPurpose.Select();
                            this.ActiveControl = txtOrderPurpose;
                            txtOrderPurpose.Focus();


                        }

                    }
                }


            }
            else if (e.KeyCode == Keys.Back)
            {
                txtOrderPuprposeId.Text = "";

            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtOrderPuprposeId.Text = "";

            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Forms.DocumentsForms.ScanDocuments t = new Forms.DocumentsForms.ScanDocuments();
                t.txtID.Text = this.textBox2.Text;
                t.txtLetterKind.Text = this.comboBox1.Text.ToString();
                t.LblBank.Text = "المورد/ المقاول";
                t.txtBank.Text = this.txtSupliers.Text;
                t.LblLetterFullNo.Text = "رقم الامر";
                t.txtLetterFullNo.Text = this.textBox1.Text;
                t.LblLetterDate.Text = "تاريخ الامر";
                t.txtLetterDate.Text = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
                t.Lblvalue.Visible = false;
                t.LetterId.Text = this.textBox2.Text;
                t.txtLetterKindID.Text = this.comboBox1.SelectedValue.ToString();
                t.txtvalue.Visible = false;
                t.txtcurrency.Visible = false;
                //t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;
                List<int> numbers = new List<int>();

                // Add data to the list
                numbers.Add(1);
                numbers.Add(3);
                numbers.Add(1005);
                numbers.Add(1006);
                numbers.Add(1007);
                numbers.Add(1008);
                numbers.Add(1009);
                numbers.Add(1010);
                numbers.Add(1012);
                int itemSelect = int.Parse(this.comboBox1.SelectedValue.ToString());
                if (this.comboBox1.SelectedValue.ToString() == "2")
                { t.txtProcessID.Text = "1"; }
                else if (this.comboBox1.SelectedValue.ToString() == "1011")
                { t.txtProcessID.Text = "4"; }
                else if ( numbers.Contains(itemSelect))
                { t.txtProcessID.Text = "5"; }

                if ((Application.OpenForms["ScanDocuments"] as ScanDocuments != null))
                {
                    t.BringToFront();
                    this.SendToBack();

                }
                else
                {

                    t.Show();

                    t.BringToFront();

                }

            }
            else
            {
                MessageBox.Show("من فضلك اختر الامر المراد مسح اوراقه اولا");
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Forms.DocumentsForms.ShowScanDocuments t = new Forms.DocumentsForms.ShowScanDocuments();
                t.txtID.Text = this.textBox2.Text;
                t.txtLetterKind.Text = this.comboBox1.Text.ToString();
                t.LblBank.Text = "المورد/ المقاول";
                t.txtBank.Text = this.txtSupliers.Text;
                t.LblLetterFullNo.Text = "رقم الامر";
                t.txtLetterFullNo.Text = this.textBox1.Text;
                t.LblLetterDate.Text = "تاريخ الامر";
                t.txtLetterDate.Text = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
                t.Lblvalue.Visible = false;
                t.LetterId.Text = this.textBox2.Text;
                t.txtLetterKindID.Text = this.comboBox1.SelectedValue.ToString();
                t.txtvalue.Visible = false;
                t.txtcurrency.Visible = false;
                //t.radioGroup1.SelectedIndex = this.radioGroup1.SelectedIndex;
                List<int> numbers = new List<int>();

                // Add data to the list
                numbers.Add(1);
                numbers.Add(3);
                numbers.Add(1005);
                numbers.Add(1006);
                numbers.Add(1007);
                numbers.Add(1008);
                numbers.Add(1009);
                numbers.Add(1010);
                numbers.Add(1012);
                int itemSelect = int.Parse(this.comboBox1.SelectedValue.ToString());
                if (this.comboBox1.SelectedValue.ToString() == "2")
                { t.txtProcessID.Text = "1"; }
                else if (this.comboBox1.SelectedValue.ToString() == "1011")
                { t.txtProcessID.Text = "4"; }
                else if (numbers.Contains(itemSelect))
                { t.txtProcessID.Text = "5"; }
                if ((Application.OpenForms["ShowScanDocuments"] as ShowScanDocuments != null))
                {
                    t.BringToFront();
                    this.SendToBack();
                }
                else
                {
                    t.Show();
                    t.BringToFront();
                }

            }
            else
            {
                MessageBox.Show("من فضلك اختر الامر المراد مسح اوراقه اولا");
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار اللجنه ورقم - تاريخ", TB, 0, 0, VisibleTime);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();

            }
            else if (e.KeyCode == Keys.Down)
            {

                Forms.ProcessingForms.FindDecisionsResponspilities t = new Forms.ProcessingForms.FindDecisionsResponspilities();
                if (cmbResponspilityN.SelectedValue != null)
                {

                    t.textEdit1.Text = this.cmbResponspilityN.SelectedValue.ToString();
                    t.comboBox1.SelectedValue = this.cmbResponspilityN.SelectedValue.ToString();
                    t.txtRespName.Text = this.cmbResponspilityN.Text;
                    t.ShowDialog();

                    if (Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow != null)
                    {
                        txtResponsipilityDecisionNID.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[0].Value.ToString();
                        txtResponsipilityDecisionNNo.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[1].Value.ToString();
                        dtpResponsipilityDecisionN.Value = Convert.ToDateTime(Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[2].Value);
                        txtForYearN.Text = Forms.ProcessingForms.FindDecisionsResponspilities.SelectedRow.Cells[3].Value.ToString();

                    }
                    txtOrderPurpose.Focus();
                }
                else
                {
                    MessageBox.Show("من فضلك اختر اللجنه اولا");
                    cmbResponspility.Focus();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                txtResponsipilityDecisionNID.Text = "";
            }
            else if (e.KeyCode == Keys.Back)
            {
                txtResponsipilityDecisionNID.Text = "";
            }
        }

        private void cmbResponspilityN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtResponsipilityDecisionNNo.Focus();
            }
        }

        private void txtProcissName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                Forms.BasicCodeForms.FindManagementFrm t = new Forms.BasicCodeForms.FindManagementFrm();
                t.ShowDialog();

                if (t.txtManagementId != null)
                {
                    txtDirectEsdr.Text = t.txtSelected.Text;
                    txtDirEsdarID.Text = t.txtManagementId.Text;



                }
                txtProcissName.Focus();
            }

        }

        private void txtDirectEsdr_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show("اضغط على زر السهم لاسفل لاختيار الشركه ", TB, 0, 0, VisibleTime);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            this.dTB_OrdersTableAdapter.FillBySupName(this.financialSysDataSet.DTB_Orders, Vint_KindOrder, txtSearch.Text);
        }

        private void textBox4_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Forms.DocumentsForms.AddDataByUsersFrm t = new Forms.DocumentsForms.AddDataByUsersFrm();
                
                t.txtRstAccId.Text = textBox2.Text;
                t.txtAccRestNo.Text = this.textBox1.Text;
                t.dateTimePicker1.Value = Convert.ToDateTime(this.dateTimePicker1.Value.ToString());
                t.txtKindProcess.Text = "2";
                
                if (textBox2.Text != "")
                {
                    t.ShowDialog();
                }


            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 2000;
            ToolTip tt = new ToolTip();
            tt.Show(" اضغط على زر السهم لاسفل لمعرفة تفاصيل الادخال ", TB, 0, 0, VisibleTime);
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Forms.DocumentsForms.OrderPermeationFrm t = new Forms.DocumentsForms.OrderPermeationFrm();
            t.txtOrderId.Text = this.textBox2.Text;
            t.txtOrderNo.Text = this.textBox1.Text;
            t.txtOrderDate.Text = this.dateTimePicker1.Value.ToString();
            t.dateTimePicker1.Value = this.dateTimePicker1.Value;
            t.txtOrderSupName.Text = this.txtSupliers.Text;
            //t.grpOrderData.Text = this.comboBox1.Text;
            t.txtPurchaseMethode.Text = this.cmbPurchMethod.Text;
            if (Vint_KindOrder == 1)
            {
                t.label11.Text = "مدة التوريد";
            }
            else if (Vint_KindOrder == 2)
            {
                t.label11.Text = "مدة التنفيذ";
            }
            t.Show();
            t.textBox9.Focus();
            t.BringToFront();
        }
    }
}
