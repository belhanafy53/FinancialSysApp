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
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class DocCategorySetup : DevExpress.XtraEditors.XtraForm
    {
        public DocCategorySetup()
        {
            InitializeComponent();
        }
        private void SaveInData()
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
                bool isSelected = Convert.ToBoolean(row.Cells["Column4"].Value);
                if (isSelected)
                {
                    com.Parameters.Clear();
                    //row.Cells[5].Value = MAXID.Text;
                    com.CommandText = ("Insert Into Tbl_RestrictionItemsCategory_With_AccountNumber(AccountNo_ID,RestrictionItemsCategoryID,Descrption) values(@AccountNo_ID,@RestrictionItemsCategoryID,@Descrption)");
                    com.Parameters.Add("@AccountNo_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);
                    com.Parameters.Add("@RestrictionItemsCategoryID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[5].Value);
                    com.Parameters.Add("@Descrption", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[6].Value);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                }
            }
            MessageBox.Show("تم الحفظ بنجاح");
            dataGridView1.Rows.Clear();
            GETDATA();
        }
        private void GETDATA()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = "SELECT  Tbl_Accounting_Guid.Account_NO AS [رقم الحساب], Tbl_Accounting_Guid.Name AS [اسم الحساب], Tbl_RestrictionItemsCategory.Name AS التصنيف, Tbl_DocumentCategory.Name AS البيان,Tbl_RestrictionItemsCategory_With_AccountNumber.AccountNo_ID,Tbl_RestrictionItemsCategory_With_AccountNumber.RestrictionItemsCategoryID,Tbl_RestrictionItemsCategory_With_AccountNumber.Descrption,Tbl_RestrictionItemsCategory_With_AccountNumber.ID FROM Tbl_RestrictionItemsCategory_With_AccountNumber INNER JOIN Tbl_Accounting_Guid ON Tbl_RestrictionItemsCategory_With_AccountNumber.AccountNo_ID = Tbl_Accounting_Guid.ID INNER JOIN Tbl_DocumentCategory ON Tbl_RestrictionItemsCategory_With_AccountNumber.Descrption = Tbl_DocumentCategory.ID INNER JOIN Tbl_RestrictionItemsCategory ON Tbl_RestrictionItemsCategory_With_AccountNumber.RestrictionItemsCategoryID = Tbl_RestrictionItemsCategory.ID";
            
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), red.GetValue(3), red.GetValue(4), red.GetValue(5), red.GetValue(6), 0,red.GetValue(7));
            }
            red.Close();
            con.Close();
        }
        private void AddChildAccount()
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
                com.CommandText = ("SELECT ID,Account_NO  FROM [FinancialSys].[dbo].[Tbl_Accounting_Guid] where Account_NO like @P");
                com.Parameters.Add("@P", SqlDbType.NVarChar).Value = UsFul.Text + "%";
                SqlDataReader red;

                con.Open();
                red = com.ExecuteReader();
                while (red.Read())
                {

                    dataGridView2.Rows.Add(red.GetValue(0), red.GetValue(1));

                }

                con.Close();
                //}

                //}

            }
            catch { }
        }
        private void DocCategorySetup_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_DocumentCategory' table. You can move, or remove it, as needed.
            this.tbl_DocumentCategoryTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentCategory);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_RestrictionItemsCategory_With_AccountNumber' table. You can move, or remove it, as needed.
            GETDATA();
            //radCollapsiblePanel2.IsExpanded = false;
        }

        private void UsFul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down  && UsFul.Focus() == true)
            {
                try
                {
                    FindAccount  f = new FindAccount();
                    f.ShowDialog();
                    f.label1.Text = "R";
                    acID.Text = FindAccount.SelectedRow.Cells[2].Value.ToString();
                    UsFul.Text = FindAccount.SelectedRow.Cells[0].Value.ToString();
                    accName.Text = FindAccount.SelectedRow.Cells[1].Value.ToString();
                    AddChildAccount();
                }
                catch { }

            }

            if (e.KeyCode == Keys.Enter )
            {
                try
                {
                    
                    
                }
                catch { }

            }
        }

        private void Empc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Empc.Focus() == true)
            {
                try
                {
                    FindKind  f = new FindKind();
                    f.ShowDialog();
                   
                    caID.Text = FindKind.SelectedRow.Cells[0].Value.ToString();
                    Empc.Text = FindKind.SelectedRow.Cells[1].Value.ToString();
                }
                catch { }

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down  && comboBox1.Focus() == true)
            {
                try
                {
                    FindCatregory f = new FindCatregory();
                    f.ShowDialog();

                    deID.Text = FindCatregory.SelectedRow.Cells[0].Value.ToString();
                    comboBox1.Text = FindCatregory.SelectedRow.Cells[1].Value.ToString();
                }
                catch { }

            }
            if (e.KeyCode == Keys.Enter )
            {
                AddToGrid();
            }
            }
        private void AddToGrid()
        {
            dataGridView1.Rows.Add(UsFul.Text, accName.Text, Empc.Text, comboBox1.Text, acID.Text, caID.Text,deID.Text , true);
            UsFul.Text = DBNull.Value.ToString();
            acID.Text = DBNull.Value.ToString();
            Empc.Text = DBNull.Value.ToString();
            comboBox1.Text = DBNull.Value.ToString();
            acID.Text = DBNull.Value.ToString();
            caID.Text = DBNull.Value.ToString();
            deID.Text = DBNull.Value.ToString() ;
            UsFul.Focus();
            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

            dataGridView1_CellEnter(dataGridView1, args);
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentCell.RowIndex;
            // Check if the current row is a new row.
            if (dataGridView1.Rows[currentIndex].IsNewRow)
            {
                // The current row is a new row.
                dataGridView1.CurrentRow.Cells[7].Value = true;
                simpleButton1.Enabled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveInData();
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
                        com.CommandText = ("Delete From Tbl_RestrictionItemsCategory_With_AccountNumber  where ID=@ID");
                        com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                   
                }
                MessageBox.Show("تم الحذف بنجاح");
                dataGridView1.Rows.Clear();
                GETDATA();
            }
        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
           
                UpdateInData();
            textBox2.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                    this.tbl_DocumentCategoryTableAdapter.FillByCategoryName(this.financialSysDataSet.Tbl_DocumentCategory, textBox1.Text);
            }
            catch { };
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            AddChildAccount(); 
            if (dataGridViewX1.Rows.Count > 0 && UsFul.Text !=string.Empty )
            {

                dataGridView2.SelectAll();
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    
                    if (Convert.ToInt32( row.Cells["Column7"].Value) == 1)
                    {
                        //bool isSelected = Convert.ToBoolean(row.Cells["Column7"].Value);
                        //if (isSelected == true)
                        //{
                        for (int x = 1; x < dataGridView2.Rows.Count; x++)
                        {
                            dataGridView1.Rows.Add(dataGridView2.Rows[x].Cells[1].Value.ToString(), accName.Text, Empc.Text, row.Cells[1].Value, dataGridView2.Rows[x].Cells[0].Value.ToString(), caID.Text, row.Cells[0].Value, true);
                        

                            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                            dataGridView1_CellEnter(dataGridView1, args);
                        }
                        //}
                    }
                }
                UsFul.Text = DBNull.Value.ToString();
                acID.Text = DBNull.Value.ToString();
                Empc.Text = DBNull.Value.ToString();
                comboBox1.Text = DBNull.Value.ToString();
                acID.Text = DBNull.Value.ToString();
                caID.Text = DBNull.Value.ToString();
                deID.Text = DBNull.Value.ToString();
                UsFul.Focus();
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    //bool isSelected = Convert.ToBoolean(row.Cells["Column7"].Value);
                    row.Cells["Column7"].Value = "0";
                }
            }
            else
            {
                MessageBox.Show("أختر رقم الحساب والتصنيف");
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Column7"].Value);
                    row.Cells["Column7"].Value = 0;
                }
            }
            catch { }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Column7"].Value);
                    row.Cells["Column7"].Value = 1;
                }
            }
            catch { }
        }
    }
}