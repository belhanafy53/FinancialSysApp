using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class DocumentBenefcairyFrm : DevExpress.XtraEditors.XtraForm
    {
        public int SelectUsful_ID { get; set; }
        public string  SelectUsful_Name { get; set; }
        public DocumentBenefcairyFrm()
        {
            InitializeComponent();
        }
        public DataTable Benefcairy()
        {
            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;
            com.CommandText = ("select * from Tbl_Beneficiary where Parent_ID=@ID");
            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(UsFulID.Text);
            con.Open();
            com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Benefcairy1()
        {

            //DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.Connection = con;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                com.CommandText = ("select * from Tbl_Beneficiary where Parent_ID=@ID1 and Parent_ID not in @ID");
                com.Parameters.Add("@ID", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells[3].Value;
                com.Parameters.Add("@ID1", SqlDbType.Int).Value = Convert.ToInt32(UsFulID.Text);
            }
            con.Open();
            com.ExecuteScalar();

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.SelectCommand = com;
            com.ExecuteScalar();

            da.Fill(dt);
            con.Close();

            return dt;

        }
        private void tbl_DocumentBenefcairyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_DocumentBenefcairyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.financialSysDataSet);

        }
        private void GETBeneficiary()
        {
            dataGridViewX1.Rows.Clear();
           SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString.ToString();
            SqlCommand com = new SqlCommand();
            SqlCommand com1 = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com1.Connection = con;
            com1.CommandType = CommandType.Text;
            com.CommandText = "Select Name,ID  FROM Tbl_Beneficiary  WHERE Parent_ID   = @ID ";
            //com.Parameters.Add("@P", SqlDbType.Int).Value = Convert.ToInt32(Code.Text);
            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(UsFulID.Text );
            SqlDataReader red;
            con.Open();
            red = com.ExecuteReader();
            while (red.Read())
            {

                dataGridViewX1.Rows.Add(red.GetValue(0), red.GetValue(1),0, 0, 0, 0, false, 0);
            }
            red.Close();
            con.Close();
        }
        private void GETDATA()
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
                com.CommandText = "Select dbo.Tbl_Beneficiary.Name ,dbo.Tbl_DocumentBenefcairy.ChecqeValue,  dbo.Tbl_DocumentBenefcairy.Document_ID, dbo.Tbl_DocumentBenefcairy.Beneficiary_ID,dbo.Tbl_DocumentBenefcairy.ID FROM dbo.Tbl_DocumentBenefcairy INNER JOIN dbo.Tbl_Beneficiary ON dbo.Tbl_DocumentBenefcairy.Beneficiary_ID = dbo.Tbl_Beneficiary.ID WHERE(dbo.Tbl_DocumentBenefcairy.Document_ID = @ID)  ";
                //com.Parameters.Add("@P", SqlDbType.Int).Value = Convert.ToInt32(Code.Text);
                com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                SqlDataReader red;
                con.Open();
                red = com.ExecuteReader();

                while (red.Read())
                {
                    if (red.HasRows)
                    {
                        dataGridView1.Rows.Add(red.GetValue(0), red.GetValue(1), red.GetValue(2), 0, red.GetValue(3), 0, false, red.GetValue(4));
                    }
                    else
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
                
                
                red.Close();
                con.Close();
            }
            catch { }
        }
        private void DocumentBenefcairyFrm_Load(object sender, EventArgs e)
        {
            
           
                //if (textBox10.Text == string.Empty)
                //{
                //    SaveDocument();
                //    //PresessingSaveBtn();
                //    GetDocID();
                //}
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_DocumentBenefcairy' table. You can move, or remove it, as needed.
                //  this.tbl_DocumentBenefcairyTableAdapter.Fill(this.financialSysDataSet.Tbl_DocumentBenefcairy);
                if (BrokerAccount.Text == "0" && BankAccount.Text != "0")
                {
                    textBox4.Text = BankAccount.Text;
                }
                if (BrokerAccount.Text != "0" && BankAccount.Text == "0")
                {
                    textBox4.Text = BrokerAccount.Text;
                }
                if (BrokerAccount.Text != "0" && BankAccount.Text != "0")
                {
                    textBox4.Text = BrokerAccount.Text;
                }
                textBox3.Text = textBox4.Text;
            //if (Convert.ToDecimal(textBox3.Text) == 0)
            //{
            //    if (Convert.ToDecimal(textBox7.Text) == 1 || Convert.ToDecimal(textBox7.Text) == 2)
            //    {
            //        MessageBox.Show("الرجاء قم بتسجيل حساب البنك أولا");
            //        UsFul.Text = DBNull.Value.ToString();
            //        UsFulID.Text = DBNull.Value.ToString();
            //        this.Close();
            //    }
            //}
            //else
            //{
                GETDATA();
            try
            {
                FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                    f.label1.Text = "R";
            if (FindUsefl.SelectedRow != null)
            {
                UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                UsFulID.Text = FindUsefl.SelectedRow.Cells[0].Value.ToString();
            }
                    //dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("هل تريد تعديل المستفيد","", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
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
                            for (int x = 0; x < dataGridView1.Rows.Count; x++)
                            {
                                com.CommandText = ("Delete From Tbl_DocumentBenefcairy  where ID=@ID");



                                com.Parameters.Add("@ID", SqlDbType.Int).Value = dataGridView1.Rows[x].Cells[7].Value;
                                con.Open();
                                com.ExecuteNonQuery();
                            }
                            con.Close();

                            dataGridView1.Rows.Clear();
                            if (f.dataGridViewX1.Rows.Count == 0)
                            {
                                dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
                                simpleButton1_Click(sender, e);
                                this.Close();
                                GETDATA();
                            }
                            if (f.dataGridViewX1.Rows.Count > 0)
                            {
                                dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
                                //simpleButton1_Click(sender, e);
                                //this.Close();

                            }
                        }
                        else
                        {
                            this.Close();
                        }
                        
                    }
                    else
                    {
                        if (f.dataGridViewX1.Rows.Count == 0)
                        {
                            dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
                            simpleButton1_Click(sender, e);
                            this.Close();

                        }
                    }

            }
            catch { }
            //}

        }

        private void UsFul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    FindUsefl f = new FindUsefl();
                    f.ShowDialog();
                    f.label1.Text = "R";
                    UsFul.Text = FindUsefl.SelectedRow.Cells[1].Value.ToString();
                    UsFulID.Text = FindUsefl.SelectedRow.Cells[0].Value.ToString();
                }
                catch { }

            }
            if (e.KeyCode == Keys.Escape && UsFul.Focus() == true)
            {
                try
                {
                    //FindDepart f = new FindDepart();
                    //f.ShowDialog();
                    UsFul.Text = DBNull.Value.ToString();
                    UsFulID.Text = DBNull.Value.ToString();
                }
                catch { }
            }
        }
        private void addToGrid()
        {

        }
        private void SaveDocumentBenefcairy()
        {
            if (dataGridView1.Rows.Count > 0)
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
                        com.CommandText = ("Insert Into Tbl_DocumentBenefcairy(Document_ID,Beneficiary_ID,ChecqeValue) values(@Document_ID,@Beneficiary_ID,@ChecqeValue)");

                        com.Parameters.Add("@Document_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[2].Value);
                        com.Parameters.Add("@Beneficiary_ID", SqlDbType.Int).Value = Convert.ToInt32(row.Cells[4].Value);


                        com.Parameters.Add("@ChecqeValue", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[1].Value);

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        private void UsFulID_TextChanged(object sender, EventArgs e)
        {
            //comboBox1.DataSource = null;
            //comboBox1.DataSource = Benefcairy();
            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "ID";
            //comboBox1.SelectedIndex = -1;
            SelectUsful_ID = Convert.ToInt32(UsFulID.Text);
            SelectUsful_Name = UsFul.Text;
            textBox6.Text = SelectUsful_ID.ToString();
            GETBeneficiary();
            //dataGridView1.Rows.Add(UsFul.Text, tD.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
        }
        private void AddToGrid()
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        if (UsFulID.Text == row.Cells[4].Value.ToString())
            //        {
            //            MessageBox.Show("هذا الاسم موجود بالفعل");
            //            //UsFul.Focus();
            //        }
            //        if (comboBox1.SelectedValue.ToString() != row.Cells[4].Value.ToString())
            //        {
            //            MessageBox.Show("هذا الاسم موجود بالفعل");                        //UsFul.Focus();
            //        }
            //    }
            //}
            //else
            //{
            if (comboBox1.Text == string.Empty)
            {
                dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
                //dataGridView1.Rows.Add(comboBox1.Text, textBox4.Text, textBox1.Text, comboBox1.SelectedValue, comboBox1.SelectedValue, null, true);

                textBox4.Text = "0";
                comboBox1.Focus();
            }
            if (comboBox1.Text != string.Empty)
            {
                //dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
                dataGridView1.Rows.Add(comboBox1.Text, textBox4.Text, textBox1.Text, comboBox1.SelectedValue, comboBox1.SelectedValue, null, true);

                textBox4.Text = "0";
                comboBox1.Focus();
            }
            //UsFul.Focus();
            //}

        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToGrid();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //comboBox1.DataSource = null;
            //comboBox1.DataSource = Benefcairy1();
            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "ID";
            //comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
            if (e.KeyCode == Keys.Delete)
            {
                comboBox1.SelectedValue = DBNull.Value;
            }
        }

        public  void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //if (comboBox1.Text == string.Empty)
                //{
                tD.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[1].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
                decimal x = Convert.ToDecimal(textBox3.Text);
                decimal y = Convert.ToDecimal(tD.Text);
                decimal t = x - y;
                textBox5.Text = t.ToString();
                if (Convert.ToDecimal(tD.Text) > Convert.ToDecimal(textBox3.Text))
                {
                    MessageBox.Show("قيمة الشيك المسجلة اكبر من قيمة الشيك الفعلية");
                }
                //dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);
                //dataGridView1.Rows.Add(UsFul.Text, tD.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);


                if (Convert.ToDecimal(tD.Text) <= Convert.ToDecimal(textBox3.Text))
                {
                    SaveDocumentBenefcairy();
                    //MessageBox.Show("تم الحفظ");
                    SelectUsful_ID = Convert.ToInt32(UsFulID.Text);
                    SelectUsful_Name = UsFul.Text;
                    textBox6.Text = SelectUsful_ID.ToString();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("اختر المستفيد اولا");
            }

        }
        private void DeleteIndebtednessBenefi()
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

            com.CommandText = ("Delete From Tbl_DocumentBenefcairy  where ID=@ID");



            com.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            DeleteIndebtednessBenefi();
            dataGridView1.Rows.Clear();
            GETDATA();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
           
        }

        private void UsFul_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void UsFul_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewX1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Rows.Add(dataGridViewX1.CurrentRow.Cells[0].Value, textBox4.Text, textBox1.Text, comboBox1.SelectedValue, dataGridViewX1.CurrentRow.Cells[1].Value, null, true);
            //dataGridView1.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(UsFul.Text, textBox4.Text, textBox1.Text, textBox1.Text, UsFulID.Text, null, true);

        }

        private void DocumentBenefcairyFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectUsful_ID =Convert.ToInt32( DBNull.Value );
                SelectUsful_Name = null;
                this.Close();
            }
        }

        private void UsFul_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
