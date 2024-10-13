using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialSysApp.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using FinancialSysApp.Forms.DocumentsForms;
using DevExpress.PivotGrid.PivotTable;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.CodeParser;
using System.Runtime.InteropServices;
using WIA;
using System.IO;
using DevExpress.Office.Drawing;
using System.Data.SqlClient;
using System.Configuration;
namespace FinancialSysApp.Forms.Banks
{
    public partial class ViewRestrictonsCheqFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int? Vint_BankDepositeId = 0;
        int? Vint_AccountBank = 0;
        int? Vint_BankAccId = 0;
        int? Vint_ChequeReceivedKindID = null;
        int? Vint_BranchID = 0;
        int? Vint_RepresentiveID = null;
        int? Vint_BankDrawnOnID = 0;
        int? Vint_CustID = null;
        string Vstr_CollectionNo = null;
        string Vstr_ChequeNO;
        string Vstr_ReceiptNO;
        string Vstr_TradeCollectionNO;
        long? Vlng_LastRowTreasuryCollection = 0;
        DateTime? vdate_CollectionDate = null;
        long VLng_IDMasterRow = 0;
        decimal Vdc_AmountCheque = 0;
        DateTime? Vdate_ChequeDueDate = null;
        int? Vint_CheckRowID = null;
        int? Vint_DgCount = 0;
        Boolean? Vbl_RestrictionDataID = false;
        int? Vint_TrCollectionID = 0;
        long? vlng_bankCheqID = 0;
        string Image_Path = "";
        public ViewRestrictonsCheqFrm()
        {
            InitializeComponent();
        }

        private void ViewRestrictonsCheqFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Fiscalyear' table. You can move, or remove it, as needed.
            
            this.tbl_FiscalyearTableAdapter.FillByYear(this.financialSysDataSet.Tbl_Fiscalyear);
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter )
            {

                this.notOutChequeTableAdapter.Fill(this.restrictionCheque.NotOutCheque,  Convert.ToDateTime(dateTimePicker1.Value).ToString(), Convert.ToDateTime(dateTimePicker2.Value).ToString());
                //this.notOutChequeTableAdapter.Fill(this.restrictionCheque.NotOutCheque, comboBox3.SelectedValue.ToString(), Convert.ToDateTime(dateTimePicker1.Value.ToString()).ToString(), Convert.ToDateTime(dateTimePicker2.Value.ToString()).ToString());

            }
        }

        private void dataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(dataGridViewX1.CurrentRow.Cells[4].Value?.ToString()))
            {
                Forms.Banks.Restrictions_checksFRM f = new Banks.Restrictions_checksFRM();
                f.textBox3.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                f.textBox5.Text = f.textBox19.Text = dataGridViewX1.CurrentRow.Cells[4].Value.ToString();
                f.textBox14.Text = f.textBox18.Text = dataGridViewX1.CurrentRow.Cells[9].Value.ToString();
                f.textBox15.Text = dataGridViewX1.CurrentRow.Cells[12].Value.ToString();
                try
                {
                    string val = Math.Round((from DataGridViewRow row in dataGridViewX1.Rows
                                             where row.Cells[13].Value.ToString() == "True" && row.Cells[0].Value.ToString() ==
                                             dataGridViewX1.CurrentRow.Cells[0].Value.ToString()
                                             select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                }
                catch { }

                //txtSpValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
                //                                    where (Convert.ToBoolean(row.Cells[1].Value) == true)
                //                                    select Convert.ToDouble(row.Cells[4].Value)).Sum(), 3).ToString();
                // Define DataTable and add columns
                DataTable bankInGrid = new DataTable();
                bankInGrid.Columns.Add("حدد البنك المراد تعديلة", typeof(bool));
                bankInGrid.Columns.Add("ID");
                bankInGrid.Columns.Add("البنوك المسجلة على المستند");
                bankInGrid.Columns.Add("القيمة");
                bankInGrid.Columns.Add("Cehque");
                // Populate DataTable with rows from dataGridViewX1
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    if (row.Cells[13].Value != null && row.Cells[13].Value.ToString()=="True" &&
                        row.Cells[0].FormattedValue.ToString() == dataGridViewX1.CurrentRow.Cells[0].FormattedValue.ToString())
                    {
                        bankInGrid.Rows.Add(true ,row.Cells[11].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[13].Value.ToString());
                    }
                }

                // Set DataSource of dataGridView3
                f.dataGridView3.DataSource = bankInGrid;

                // Set column widths and properties
                f.dataGridView3.Columns[1].Width = 100;
                f.dataGridView3.Columns[2].Width = 320;
                f.dataGridView3.Columns[3].Width = 140;
                f.dataGridView3.Columns[1].Visible = false;
                f.dataGridView3.Columns[4].Visible = false;

                f.textBox8.Text = Math.Round((from DataGridViewRow row in dataGridViewX1.Rows
                                               where row.Cells[4].Value.ToString() == "True" && row.Cells[0].Value.ToString() ==
                                               dataGridViewX1.CurrentRow.Cells[0].Value.ToString()
                                               select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
                f.textBox1.Text = Math.Round((from DataGridViewRow row in dataGridViewX1.Rows
                                              where row.Cells[4].Value.ToString() == "True" && row.Cells[0].Value.ToString() ==
                                              dataGridViewX1.CurrentRow.Cells[0].Value.ToString()
                                              select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();

                // Show dialog
                f.ShowDialog();

            }
            else
            {
                MessageBox.Show("الرجاء قم بتسجيل اسم المستفيد  وحفظ المستند أولا");
            }

        }
        void AddCheckBoxColumn(DataGridView dataGridView)
        {
            //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            //checkBoxColumn.HeaderText = "تحديد";
            //checkBoxColumn.Name = "SelectColumn"; // Set a unique name for the column
            //checkBoxColumn.DataPropertyName = "حدد البنك المراد تعديلة";
            //checkBoxColumn.TrueValue = true;
            //checkBoxColumn.FalseValue = false;

            //dataGridView.Columns.Insert(3, checkBoxColumn); // Insert at index 3 (or adjust as needed)
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter )
            {
                dateTimePicker2.Focus();
            }
        }
    }
}
