using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class DataBase : DevExpress.XtraEditors.XtraForm
    {
        public DataBase()
        {
            InitializeComponent();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;

            

           

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string shrinkCommand = "DBCC SHRINKDATABASE (FinancialSys);";  

                    SqlCommand command = new SqlCommand(shrinkCommand, connection);

                    
                    command.ExecuteNonQuery();

                    
                    connection.Close();

                    MessageBox.Show("تم ضغط قاعدة البيانات بنجاح");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while shrinking the database: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm");

            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

           
            saveFileDialog.Title = "Save Backup File";
            saveFileDialog.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
            saveFileDialog.FileName = $"FinancialSys_{timestamp}.bak"; 
            saveFileDialog.InitialDirectory = "C:\\Backup"; 

            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
               
                string backupFilePath = saveFileDialog.FileName;

                
                string connectionString = ConfigurationManager.ConnectionStrings["FinancialSysApp.Properties.Settings.FinancialSysConnectionString"].ConnectionString;

                
                string backupCommand = $"BACKUP DATABASE [FinancialSys] TO DISK='{backupFilePath}'";

                try
                {
                   
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                       
                        SqlCommand command = new SqlCommand(backupCommand, connection);

                       
                        connection.Open();

                       
                        command.ExecuteNonQuery();

                       
                        connection.Close();
                    }

                   
                    MessageBox.Show("تم اخذ نسخة احتياطية بنجاح");
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("An error occurred while backing up the database: " + ex.Message);
                }
            }
        }
    }
}
