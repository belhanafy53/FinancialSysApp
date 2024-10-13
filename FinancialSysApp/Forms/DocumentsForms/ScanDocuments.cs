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
using DevExpress.Xpo.DB.Helpers;

using WIA;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraPdfViewer.Bars;


namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class ScanDocuments : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        int Vint_IdItem = 0;
        string Vstr_Name = "";
        string Vstr_fullName = "";
        int Vint_Parent_ID = 0;
        int Vint_orderKind = 0;
        int Vint_ProcessDucKind = 0;
        string Vstr_YearDate = "";
        string Vstr_ProcessKindID = "";
        string Vstr_MonthDate = "";
        string Vstr_ID = "";
        int? Vint_LetterWID = 0;
        int? Vint_OrderID= 0;
        int? Vint_cheqID = 0;
        //******* Tree View
        private List<TreeNode> CurrentNodeMatches = new List<TreeNode>();
        private int LastNodeIndex = 0;
        private string LastSearchText;
        //***************
        private void SearchNodes(string SearchText, TreeNode StartNode)
        {
            //TreeNode node = null;
            while (StartNode != null)
            {
                if (StartNode.Text.Trim().Contains(SearchText.Trim()))
                {
                    CurrentNodeMatches.Add(StartNode);
                }
                if (StartNode.Nodes.Count != 0)
                {
                    SearchNodes(SearchText, StartNode.Nodes[0]);
                }
                StartNode = StartNode.NextNode;
            }
        }

        string SelectTreeTable(int OKID)
        {

            int DocumentProcessID = OKID;

            //string Sql = "Select * From  Tbl_DocumentHirarchy Where Name = @tt";
            string Sql = "select * from Tbl_DocumentHirarchy where Tbl_DocumentHirarchy.DocumentProcessID = " + @DocumentProcessID;
            return Sql;
        }
        string SelectTreeTableByName(string TABLE, string Name, string TxtSearch)
        {
            string Sql = ("Select * From (" + TABLE + ")Chaild WHERE Chaild." + Name + " ='" + TxtSearch + "'");

            return Sql;
        }

        public ScanDocuments()
        {
            InitializeComponent();
        }
        private void ScanDocuments_Load(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 74 && w.ProcdureId == 1004);
            if (validationSaveUser != null)
            {
                
                // TODO: This line of code loads data into the 'financialSysEventsDataSet3.Tbl_DocumentProcess' table. You can move, or remove it, as needed.
                this.tbl_DocumentProcessTableAdapter.Fill(this.financialSysEventsDataSet3.Tbl_DocumentProcess);
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_LetterWarrantyKind1' table. You can move, or remove it, as needed.
            this.tbl_LetterWarrantyKind1TableAdapter.Fill(this.financialSysDataSet.Tbl_LetterWarrantyKind1);

            btnScan.Enabled = false;
                btnMultiScan.Enabled = false;
                try
            {
                var deviceManager = new DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }
                    lstListOfScanner.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                }
                if (lstListOfScanner.Items.Count != 0)
                {
                    btnScan.Enabled = true;
                        btnMultiScan.Enabled = true;
                    }
                  
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
            using (SqlConnection connection = new SqlConnection(Program.GlbV_EVConnection))
            {
                Vint_ProcessDucKind = int.Parse(txtProcessID.Text);
                ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(Vint_ProcessDucKind), "ID", "Name", "Parent_ID", "Name");
            }
            //treeView1.ExpandAll();
            }

            else
            {
                MessageBox.Show("ليس لديك صلاحية سحب الاوراق بالماسح الضوئي  .. برجاء مراجعة مدير المنظومه");
            }
            Nametxt.Select();
            this.ActiveControl = Nametxt;
            Nametxt.Focus();

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (Vint_IdItem != 0)
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
                string Vstr_ProcessKindID = txtProcessID.Text;

                    string Vstr_YearDate = Convert.ToDateTime(txtLetterDate.Text).Year.ToString();

                    string Vstr_MonthDate = Convert.ToDateTime(txtLetterDate.Text).Month.ToString();

                    string Vstr_ID = txtID.Text;
                    //string root = Program.GlbV_IpAddressServer + "\\E:\\" + Vstr_ProcessKindID + "\\" + Vstr_YearDate + "\\" + Vstr_MonthDate + "\\" + Vstr_ID;
                    ////string root =Program.GlbV_IpAddressServer +"\\"+ @"E:\\" + Vstr_ProcessKindID + "\\" + Vstr_YearDate + "\\" + Vstr_MonthDate + "\\" +  Vstr_ID ;
                    //if (Directory.Exists(root))
                    //{
                    //    Directory.CreateDirectory(root);
                    //}
                    //*******************
                  
                    //var Path = @"E:\ScanImg.jpg"; // save the image in some path with filename.


                    //**************Create Directories Of Scan *************
                    Vstr_ProcessKindID = txtProcessID.Text;

                    DateTime Vdt_DateP = Convert.ToDateTime(txtLetterDate.Text);



                    Vstr_YearDate = (Vdt_DateP.Year).ToString();

                    Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                    Vstr_ID = txtID.Text;

                    string PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox3.Text + Vstr_YearDate + textBox3.Text + Vstr_MonthDate + textBox3.Text + Vstr_ID + textBox3.Text + Vint_IdItem;



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
                    int Vint_xx = int.Parse(txtID.Text);
                    var list = (dynamic)null;

                    if (txtProcessID.Text == "1")
                    {
                        list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                        Vint_OrderID = int.Parse(txtID.Text);
                        Vint_LetterWID = null;
                    }
                    else if (txtProcessID.Text == "2")
                    {
                        list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.LetterWID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                        Vint_LetterWID = int.Parse(txtID.Text);
                        Vint_OrderID = null;
                    }
                else if (txtProcessID.Text == "4")
                {
                    list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                    Vint_OrderID = null;
                    Vint_OrderID = int.Parse(txtID.Text);
                }
                else if (txtProcessID.Text == "5")
                {
                    list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                    Vint_LetterWID = null;
                    Vint_OrderID = int.Parse(txtID.Text);
                }
                else if (txtProcessID.Text == "6")
                {
                    list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.BankCheqID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                    Vint_cheqID = int.Parse(txtID.Text);
                    Vint_OrderID = null;
                }
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
                        Tbl_ArchOrderAndLetterW ArchD = new Tbl_ArchOrderAndLetterW()
                        {
                            LetterWID = Vint_LetterWID,
                            OrderID = Vint_OrderID,
                            DocumentHirarchyID = Vint_IdItem,
                            BankCheqID = Vint_cheqID,
                            PathFile = PathFile
                        };
                        FsEvDb.Tbl_ArchOrderAndLetterW.Add(ArchD);
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
                        Tbl_ArchOrderAndLetterW ArchD = new Tbl_ArchOrderAndLetterW()
                        {
                            LetterWID = Vint_LetterWID,
                            OrderID = Vint_OrderID,
                            DocumentHirarchyID = Vint_IdItem,
                            BankCheqID = Vint_cheqID,
                            PathFile = PathFile
                        };
                        FsEvDb.Tbl_ArchOrderAndLetterW.Add(ArchD);
                        FsEvDb.SaveChanges();
                    }
                //}



                //catch (COMException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            else
            {
                MessageBox.Show("برجاء اختيار تصنيف المستند");
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);

            Vstr_Name = treeView1.SelectedNode.Text;

            txtDocumentArchPr.Text = Vint_IdItem.ToString();

            grpBOrderKind.Text = ViewTree.SelectFullHirachyDocumentArch(treeView1, Vint_IdItem, Vint_Parent_ID);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string searchText = this.Nametxt.Text;

           
                if (LastSearchText != searchText)
                {
                    // It's a New Search
                    CurrentNodeMatches.Clear();
                    LastSearchText = searchText;
                    LastNodeIndex = 0;
                    SearchNodes(searchText, treeView1.Nodes[0]);
                }
                if (LastNodeIndex >= 0 && CurrentNodeMatches.Count > 0 && LastNodeIndex < CurrentNodeMatches.Count)
                {
                    TreeNode SelectedNode = CurrentNodeMatches[LastNodeIndex];
                    LastNodeIndex++;
                    this.treeView1.SelectedNode = SelectedNode;
                    this.treeView1.SelectedNode.Expand();
                    this.treeView1.Select();

                }
            
        }

        private void Nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (Nametxt.Text != "")

            {
                if (e.KeyCode == Keys.Enter)
                {
                    simpleButton3.Focus();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
            //try
            //{
            WIA.CommonDialog dialog = new WIA.CommonDialog();
            WIA.Device device = dialog.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType);
            WIA.Items items = dialog.ShowSelectItems(device);
            foreach (WIA.Item item in items)
            {
                while (true)
                {
                    try
                    {
                        WIA.ImageFile image = (WIA.ImageFile)dialog.ShowTransfer(item);
                        if (image != null && image.FileData != null)
                        {
                            dynamic binaryData = image.FileData.get_BinaryData();
                            if (binaryData is byte[])
                                using (MemoryStream stream = new MemoryStream(binaryData))
                                using (Bitmap bitmap = (Bitmap)Bitmap.FromStream(stream))
                                {
                                    //**************Create Directories Of Scan *************
                                    Vstr_ProcessKindID = txtProcessID.Text;

                                    DateTime Vdt_DateP = Convert.ToDateTime(txtLetterDate.Text);



                                    Vstr_YearDate = (Vdt_DateP.Year).ToString();

                                    Vstr_MonthDate = (Vdt_DateP.Month).ToString();

                                    Vstr_ID = txtID.Text;

                                    string PathDirectory = @"\\30.30.30.5\FinancialScan\" + Vstr_ProcessKindID + textBox3.Text + Vstr_YearDate + textBox3.Text + Vstr_MonthDate + textBox3.Text + Vstr_ID + textBox3.Text + Vint_IdItem;



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
                                    int Vint_xx = int.Parse(txtID.Text);
                                    var list = (dynamic)null;

                                    if (txtProcessID.Text == "1")
                                    {
                                        list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                                        Vint_OrderID = int.Parse(txtID.Text);
                                        Vint_LetterWID = null;
                                    }
                                    else if (txtProcessID.Text == "2")
                                    {
                                        list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.LetterWID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                                        Vint_LetterWID = int.Parse(txtID.Text);
                                        Vint_OrderID = null;
                                    }
                                    else if (txtProcessID.Text == "4")
                                    {
                                        list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                                        Vint_LetterWID = null;
                                        Vint_OrderID = int.Parse(txtID.Text);
                                    }
                                    else if (txtProcessID.Text == "5")
                                    {
                                        list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                                        Vint_LetterWID =null ;
                                        Vint_OrderID = int.Parse(txtID.Text);
                                    }
                                    else if (txtProcessID.Text == "6")
                                    {
                                        list = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.BankCheqID == Vint_xx && x.DocumentHirarchyID == Vint_IdItem).ToList();
                                        Vint_LetterWID = int.Parse(txtID.Text);
                                        Vint_OrderID = null;
                                    }
                                    if (list.Count != 0)
                                    {
                                        int Vint_count = (list.Count) + 1;
                                        string PathFile = PathDirectory + textBox3.Text + (Vint_count.ToString() + ".jpg");
                                        if (File.Exists(PathFile))
                                        {
                                            File.Delete(PathFile);
                                        }

                                        bitmap.Save(PathFile, ImageFormat.Jpeg);

                                        pictureBox1.ImageLocation = PathFile;
                                        Tbl_ArchOrderAndLetterW ArchD = new Tbl_ArchOrderAndLetterW()
                                        {
                                            LetterWID = Vint_LetterWID,
                                            OrderID = Vint_OrderID,
                                            DocumentHirarchyID = Vint_IdItem,
                                            PathFile = PathFile
                                        };
                                        FsEvDb.Tbl_ArchOrderAndLetterW.Add(ArchD);
                                        FsEvDb.SaveChanges();
                                    }
                                    else
                                    {
                                        string PathFile = PathDirectory + textBox3.Text + "1.jpg";
                                        if (File.Exists(PathFile))
                                        {
                                            File.Delete(PathFile);
                                        }

                                        bitmap.Save(PathFile, ImageFormat.Jpeg);

                                        pictureBox1.ImageLocation = PathFile;
                                        Tbl_ArchOrderAndLetterW ArchD = new Tbl_ArchOrderAndLetterW()
                                        {
                                            LetterWID = Vint_LetterWID,
                                            OrderID = Vint_OrderID,
                                            DocumentHirarchyID = Vint_IdItem,
                                            PathFile = PathFile
                                        };
                                        FsEvDb.Tbl_ArchOrderAndLetterW.Add(ArchD);
                                        FsEvDb.SaveChanges();
                                    }
                                    //bitmap.Save(@"C:\Temp\scan.jpg", ImageFormat.Jpeg);
                                }
                        }
                    }
                    catch (COMException)
                    {
                        break;
                    }
                }
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                long Vlng_ID = long.Parse(txtID.Text);
                var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vlng_ID);
                if (listArchCheq != null && !string.IsNullOrEmpty(listArchCheq.PathFile))
                {

                    if (listArchCheq.PathFile.ToLower().EndsWith(".pdf"))
                    {

                        if (File.Exists(listArchCheq.PathFile))
                        {
                            //pdfViewer1.DocumentFilePath = null;
                            File.Delete(listArchCheq.PathFile);
                        }
                    }
                    else
                    {

                        if (File.Exists(listArchCheq.PathFile))
                        {
                            File.Delete(listArchCheq.PathFile);
                        }
                    }


                    FsEvDb.Tbl_ArchTrCollectioCheque.Remove(listArchCheq);
                    FsEvDb.SaveChanges();


                    //pdfViewer1.DocumentFilePath = "";
                    //pdfViewer1.Visible = false;
                    pictureBox1.ImageLocation = "";
                    pictureBox1.Visible = false;
                    //pdfCommandBar1.Visible = false;
                }
            }
            catch
            {

            }
        }
    }
}
