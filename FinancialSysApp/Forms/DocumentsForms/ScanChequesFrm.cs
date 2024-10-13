using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataProcessing;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar.Controls;
using FinancialSysApp.Classes;
using System.IO;
using WIA;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class ScanChequesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        long Vlng_LastRowTreasuryCollection = 0;
        int Vint_CheckRowID = 0;
        string Vstr_ProcessKindID = "";
        public ScanChequesFrm()
        {
            InitializeComponent();
        }
        private void LoadSerial()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }
        private void GrdCheqData()
        {
             Vlng_LastRowTreasuryCollection = int.Parse(txtRowID.Text);
            var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                 join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                 join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                 //join Cust in FsDb.Tbl_Customer on BnkChq.CustID equals Cust.ID
                                 where (TRC.ID == Vlng_LastRowTreasuryCollection)
                                 select new

                                 {
                                     ID = BnkChq.ID,
                                     TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                     AmountCheque = BnkChq.AmountCheque,
                                     BankDrawnOnID = BnkChq.BankDrawnOnID,
                                     ChequeNo = BnkChq.ChequeNo,
                                     ChequeDueDate = BnkChq.ChequeDueDate,
                                     DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                     CustID = BnkChq.CustID,
                                     AddDateBank = BnkChq.AddDateBank,
                                     ChequeKind = BnkChq.ChequeKindID,
                                     //CustomerName = Cust.Name,
                                     BankName = BNK.Name

                                 }).OrderBy(x => x.ChequeDueDate).ToList();
            dataGridView1.DataSource = listBnkCheque;
            LoadSerial();
            GrdBnkCheq();

        }
        private void GrdBnkCheq()
        {


            int Vint_DgCount = dataGridView1.RowCount;
            //if (Vint_DgCount != 0)
            //{
            //    txtAllValueBefore.Text = Math.Round((from DataGridViewRow row in dataGridView1.Rows
            //                                         select Convert.ToDouble(row.Cells[3].Value)).Sum(), 3).ToString();
            //    textBox3.Text = (from DataGridViewRow row in dataGridView1.Rows
            //                     select Convert.ToDouble(row.Cells[3].Value)).Count().ToString();

            //}
            dataGridView1.Columns["TreasuryCollectionID"].Visible = false;
            dataGridView1.Columns["AmountCheque"].Visible = true;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.Columns["BankDrawnOnID"].Visible = false;
            dataGridView1.Columns["ChequeNo"].Visible = true;

            dataGridView1.Columns["ChequeDueDate"].Visible = true;
            dataGridView1.Columns["DepositedByTrRepresntvID"].Visible = false;

            dataGridView1.Columns["CustID"].Visible = false;
            dataGridView1.Columns["AddDateBank"].Visible = false;

            dataGridView1.Columns["ChequeKind"].Visible = false;

            //dataGridView1.Columns["CustomerName"].Visible = false;
            dataGridView1.Columns["BankName"].Visible = true;
            dataGridView1.Columns["BankName"].Width = 200;
            //dataGridView1.Columns["Tbl_ChequeKind"].Visible = true;
            //dataGridView1.Columns["Tbl_TreasuryCollection"].Visible = true;

            dataGridView1.Columns["AmountCheque"].HeaderText = "مبلغ الشيك";
            dataGridView1.Columns["AmountCheque"].Width = 120;

            dataGridView1.Columns["ChequeDueDate"].HeaderText = "تاريخ الشيك";
            dataGridView1.Columns["ChequeNo"].HeaderText = "رقم الشيك";

            //dataGridView1.Columns["CustomerName"].HeaderText = "العميل";
            dataGridView1.Columns["BankName"].HeaderText = "البنك";



        }
        private void ScanChequesFrm_Load(object sender, EventArgs e)
        {
           
            grpTrCollectionCheq.Text = $"حافظة فرع {txtBranch.Text} برقم {txtCollectionNo.Text}  بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")}";
            GrdCheqData();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                 Vint_CheckRowID = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                txtCheqID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
               var listBnkCheque = (from BnkChq in FsDb.Tbl_BankCheques
                                     join TRC in FsDb.Tbl_TreasuryCollection on BnkChq.TreasuryCollectionID equals TRC.ID
                                     join BNK in FsDb.Tbl_Banks on BnkChq.BankDrawnOnID equals BNK.ID
                                     
                                     where (BnkChq.ID == Vint_CheckRowID)
                                     select new
                                     {
                                         ID = BnkChq.ID,
                                         TreasuryCollectionID = BnkChq.TreasuryCollectionID,
                                         AmountCheque = BnkChq.AmountCheque,
                                         BankDrawnOnID = BnkChq.BankDrawnOnID,
                                         ChequeNo = BnkChq.ChequeNo,
                                         ChequeDueDate = BnkChq.ChequeDueDate,
                                         DepositedByTrRepresntvID = BnkChq.DepositedByTrRepresntvID,
                                         CustID = BnkChq.CustID,
                                         AddDateBank = BnkChq.AddDateBank,
                                         ChequeKind = BnkChq.ChequeKindID,
                                         //CustomerName = Cust.Name,
                                         BankName = BNK.Name

                                     }).OrderBy(x => x.ChequeDueDate).ToList();
                grpTrCollectionCheq.Text = $"شيك برقم  {listBnkCheque[0].ChequeNo}   بتاريخ {dTPCollection.Value.ToString("yyyy/MM/dd")} على بنك برقم {listBnkCheque[0].BankName}";
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (txtRowID.Text != "" || txtCheqID.Text != "")
            {

                //**********************Old********************************

                var deviceManager = new DeviceManager();

                DeviceInfo AvailableScanner = null;

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }

                    AvailableScanner = deviceManager.DeviceInfos[i];

                    break;
                }
                var device = AvailableScanner.Connect(); //Connect to the available scanner.

                var ScanerItem = device.Items[1]; // select the scanner.

                var imgFile = (ImageFile)ScanerItem.Transfer(FormatID.wiaFormatJPEG); //Retrive an image in Jpg format and store it into a variable.

                //****************************
                //**************Create Stracture Of Scan *************
                string Vstr_TrCollectionID = txtRowID.Text;
                string Vstr_ChequeID = txtCheqID.Text;
                string Vstr_YearDate = Convert.ToDateTime(dTPCollection.Value.ToString()).Year.ToString();
                string Vstr_MonthDate = Convert.ToDateTime(dTPCollection.Value.ToString()).Month.ToString();
                string Vstr_ID = "";
                string PathDirectory = "";
                Vstr_ProcessKindID = txtProcessID.Text;
                if (txtRowID.Text != "" && txtCheqID.Text == "")
                {
                     Vstr_ID = "1";
                    //PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox3.Text + Vstr_YearDate + textBox3.Text + Vstr_MonthDate + textBox3.Text + Vstr_ID + textBox3.Text + Vint_IdItem;
                }
                else if (txtRowID.Text != "" && txtCheqID.Text != "")
                {
                    Vstr_ID = "2";
                    //PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox3.Text + Vstr_YearDate + textBox3.Text + Vstr_MonthDate + textBox3.Text + Vstr_ID + textBox3.Text + Vint_IdItem;
                }
                


                //**************Create Directories Of Scan *************
      

               



                if (!Directory.Exists(PathDirectory))
                {
                    try
                    {
                        Directory.CreateDirectory(PathDirectory);
                    }
                    catch (Exception ex)  // CS0168
                    {
                        MessageBox.Show(ex.Message);

                    }

                }
                //**************Create Files Of Scan *************
                int Vint_RowID = 0;
                var list = (dynamic)null;
                if (txtRowID.Text != "" && txtCheqID.Text == "")   //*********** حوافظ
                {
                     Vint_RowID = int.Parse(txtRowID.Text);
                    list = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.TrCollectionID == Vint_RowID && x.DocumentHirarchyID == 1).ToList();
                }

                else if (txtRowID.Text != "" && txtCheqID.Text != "")   //*************شيكات
                {
                    Vint_RowID = int.Parse(txtCheqID.Text);
                }
                    
                
                  //*************شيكات وحوافظ
                 if (list.Count != 0)
                {
                    int Vint_count = (list.Count) + 1;
                    string PathFile = PathDirectory + textBox3.Text + (Vint_count.ToString() + ".jpg");
                    if (File.Exists(PathFile))
                    {
                        File.Delete(PathFile);
                    }

                    imgFile.SaveFile(PathFile);

                    pictureBox1.ImageLocation = PathFile;
                    Tbl_ArchTrCollectioCheque ArchD = new Tbl_ArchTrCollectioCheque 
                    {
                        TrCollectionID = Vlng_LastRowTreasuryCollection,
                        ChequeBankID =  Vint_CheckRowID,
                        DocumentHirarchyID = 1,
                        PathFile = PathFile
                    };
                    FsEvDb.Tbl_ArchTrCollectioCheque.Add(ArchD);
                    FsEvDb.SaveChanges();
                }
                else
                {
                    string PathFile = PathDirectory + textBox3.Text + "1.jpg";
                    if (File.Exists(PathFile))
                    {
                        File.Delete(PathFile);
                    }

                    imgFile.SaveFile(PathFile);

                    pictureBox1.ImageLocation = PathFile;
                    Tbl_ArchTrCollectioCheque ArchD = new Tbl_ArchTrCollectioCheque
                    {
                        TrCollectionID = Vlng_LastRowTreasuryCollection,
                        ChequeBankID =  Vint_CheckRowID,
                        DocumentHirarchyID = 1,
                        PathFile = PathFile
                    };
                    FsEvDb.Tbl_ArchTrCollectioCheque.Add(ArchD);
                    FsEvDb.SaveChanges();
                }
               
            }
            else
            {
                MessageBox.Show("برجاء اختيار تصنيف المستند");
            }
        }
    }
}
