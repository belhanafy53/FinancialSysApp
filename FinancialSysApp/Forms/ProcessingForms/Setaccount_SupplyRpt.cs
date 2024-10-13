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
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Setaccount_SupplyRpt : DevExpress.XtraEditors.XtraForm
    {
        public Setaccount_SupplyRpt()
        {
            InitializeComponent();
        }
        public static System.Data.DataTable read(Range excelRange)
        {
            DataRow row;
            System.Data.DataTable dt = new System.Data.DataTable();
            int rowCount = excelRange.Rows.Count; //get row count of excel data

            int colCount = excelRange.Columns.Count; // get column count of excel data

            //Get the first Column of excel file which is the Column Name

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                }
                break;
            }

            //Get Row Data of Excel

            int rowCounter; //This variable is used for row index number
            for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
            {
                row = dt.NewRow(); //assign new row to DataTable
                rowCounter = 0;
                for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
                {
                    //check if cell is empty
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                    {
                        row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                    }
                    else
                    {
                        row[i] = "";
                    }
                    rowCounter++;
                }
                dt.Rows.Add(row); //add row to DataTable
            }

            return dt;
        }
        private void UpdateInData()
        {

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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Delete From Tbl_Description_SupplyeAccount_Rpt  where AccNumber=@AccNumber");
                    com.Parameters.Add("@AccNumber", SqlDbType.NVarChar ).Value = textBox2.Text;

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();


                }
                MessageBox.Show("تم الحذف بنجاح");
                dataGridView2.DataSource = null;
                //GETDATA();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
                dataGridView2.Visible = true;
                dataGridView1.Visible = false ;
                dataGridView2.Rows.Clear();
                string file = ""; //variable for the Excel File Location
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Check if Result == "OK".
                {
                    file = openFileDialog1.FileName; //get the filename with the location of the file
                    //try
                    //{
                        //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file
                        Microsoft.Office.Interop.Excel.Application excelApp =
                            new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                        Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                        Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                        dataGridView2.DataSource = read(excelRange);

                        //close and clean excel process
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.ReleaseComObject(excelRange);
                        Marshal.ReleaseComObject(excelWorksheet);
                        //quit apps
                        excelWorkbook.Close();
                        Marshal.ReleaseComObject(excelWorkbook);
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                        textBox1.Text = dataGridView2.Rows.Count.ToString();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                }
            //}
         
            //catch { }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GETDATA()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = "SELECT  AccNumber AS [رقم الحساب] FROM Tbl_Description_SupplyeAccount_Rpt ";

            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridView1.Rows.Add(red.GetValue(0));
            }
            textBox1.Text = dataGridView1.Rows.Count.ToString();
            red.Close();
            con.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
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
                    bool isSelected = Convert.ToBoolean(row.Cells["Column2"].Value);
                    if (isSelected)
                    {
                        com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_Description_SupplyeAccount_Rpt(AccNumber) values(@AccNumber)");
                    com.Parameters.Add("@AccNumber", SqlDbType.NVarChar).Value = row.Cells[0].Value;

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                    }
                }
                for(int x=0;x<dataGridView1.Rows.Count;x++)
                {
                    dataGridView1.Rows[x].Cells[1].Value = false;
                }
                MessageBox.Show("تم الحفظ بنجاح");
                dataGridView2.DataSource = null ;
                GETDATA();
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
            }
            catch { }
        }

        private void Setaccount_SupplyRpt_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            GETDATA();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            UpdateInData();
            GETDATA();
            //dataGridView1.DataSource = null;
           
        }

        private void Descp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down )
            {
                try
                {
                    FindAccount f = new FindAccount();
                    f.ShowDialog();
                    Descp.Text = FindAccount.SelectedRow.Cells[0].Value.ToString();

                }
                catch { }
            }
            if(e.KeyCode== Keys.Enter )
            {
                dataGridView1.Rows.Add(Descp.Text,true );
            }
        }
    }
}