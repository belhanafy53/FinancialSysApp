using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FinancialSysApp.Classes;
using DevExpress.Xpo.DB.Helpers;

using WIA;
using System.Runtime.InteropServices;
using System.IO;
using DevExpress.CodeParser;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using DevExpress.Office.Drawing;
using System.Diagnostics;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class ShowScanDocuments : DevExpress.XtraEditors.XtraForm
    {
        //private Point startPoint;
        private int startAngle;

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
        int? Vint_OrderID = 0;
        int Vint_ID;
        int Vint_IDArch = 0;
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
        //private void gridStateZone_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    LoadSerial(gridStateZone);
        //}

        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
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

        public ShowScanDocuments()
        {
            InitializeComponent();
        }
        private void ScanDocuments_Load(object sender, EventArgs e)
        {
            var validationSaveUser = Program.SecurityProceduresList.FirstOrDefault(w => w.FormId == 75 && w.ProcdureId == 2);
            if (validationSaveUser != null)
            {
                if (txtProcessID.Text == "6")
                {
                    treeView1.Visible = false;
                }
                else
                {
                    treeView1.Visible = true;
                }
                // TODO: This line of code loads data into the 'financialSysEventsDataSet3.Tbl_DocumentProcess' table. You can move, or remove it, as needed.
                this.tbl_DocumentProcessTableAdapter.Fill(this.financialSysEventsDataSet3.Tbl_DocumentProcess);
                // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_LetterWarrantyKind1' table. You can move, or remove it, as needed.
                this.tbl_LetterWarrantyKind1TableAdapter.Fill(this.financialSysDataSet.Tbl_LetterWarrantyKind1);
                //DataGridViewImageColumn dgvimgcol = new DataGridViewImageColumn();
                //dgvimgcol.HeaderText = "Uploaded Image";
                //dgvimgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                //dataGridView1.RowTemplate.Height = 250;

                btnScan.Enabled = false;

                using (SqlConnection connection = new SqlConnection(Program.GlbV_EVConnection))
                {
                    Vint_ProcessDucKind = int.Parse(txtProcessID.Text);
                    ViewTree.fillTreeMulti(treeView1, connection, SelectTreeTable(Vint_ProcessDucKind), "ID", "Name", "Parent_ID", "Name");
                }
                //treeView1.ExpandAll();
            }

            else
            {
                MessageBox.Show("ليس لديك صلاحية عرض الاوراق المسحوبه بالماسح الضوئي  .. برجاء مراجعة مدير المنظومه");
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (Vint_IdItem != 0)
            {
                try
                {
                    pictureBox1.ImageLocation = null;
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
                    var device = AvailableScanner.Connect(); //Connect to the available scanner.

                    var ScanerItem = device.Items[1]; // select the scanner.

                    var imgFile = (ImageFile)ScanerItem.Transfer(FormatID.wiaFormatJPEG); //Retrive an image in Jpg format and store it into a variable.

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
                        pictureBox2.ImageLocation = PathFile;
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

                        imgFile.SaveFile(PathFile);

                        pictureBox1.ImageLocation = PathFile;
                        pictureBox2.ImageLocation = PathFile;
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
                }



                catch (COMException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("برجاء اختيار تصنيف المستند");
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Vint_ID = int.Parse(txtID.Text);
            Vint_IdItem = int.Parse(treeView1.SelectedNode.Tag.ToString());
            if (treeView1.SelectedNode.Name != "")
            {
                Vint_Parent_ID = int.Parse(treeView1.SelectedNode.Name.ToString());
            }
            var listItem = FsEvDb.Tbl_DocumentHirarchy.FirstOrDefault(x => x.ID == Vint_IdItem);

            Vstr_Name = treeView1.SelectedNode.Text;

            txtDocumentArchPr.Text = Vint_IdItem.ToString();
            pictureBox1.ImageLocation = null;
            pictureBox2.ImageLocation = null;
            grpBOrderKind.Text = ViewTree.SelectFullHirachyDocumentArch(treeView1, Vint_IdItem, Vint_Parent_ID);
            //this.dtbArchOrderAndLetterWTableAdapter.FillByLetterDoc(this.letterWarranty.DtbArchOrderAndLetterW, Vint_ID, Vint_IdItem);

            if (txtProcessID.Text == "1")
            {
                dataGridView1.DataSource = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_ID && x.DocumentHirarchyID == Vint_IdItem).ToList();
            }
            else if (txtProcessID.Text == "2")
            {
                dataGridView1.DataSource = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.LetterWID == Vint_ID && x.DocumentHirarchyID == Vint_IdItem).ToList();
            }
            else if (txtProcessID.Text == "4")
            {
                dataGridView1.DataSource = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_ID && x.DocumentHirarchyID == Vint_IdItem).ToList();
            }
            else if (txtProcessID.Text == "5")
            {
                dataGridView1.DataSource = FsEvDb.Tbl_ArchOrderAndLetterW.Where(x => x.OrderID == Vint_ID && x.DocumentHirarchyID == Vint_IdItem).ToList();
            }
            else if (txtProcessID.Text == "6")
            {
                dataGridView1.DataSource = FsEvDb.Tbl_ArchTrCollectioCheque.Where(x => x.ChequeBankID == Vint_ID && x.DocumentHirarchyID == 136).ToList();
            }
        }

        // Resize image and if width and height are different ratio, keep it in center.

        public static Bitmap Resize(Image image, int width, int height)
        {

            int drawWidth = width;
            int drawHeight = height;
            if (width != height)
            {
                drawWidth = Math.Min(width, height);
                drawHeight = drawWidth;
            }

            var destRect = new Rectangle((width - drawWidth) / 2, (height - drawHeight) / 2, drawWidth, drawHeight);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtImgID.Text = "";
            pictureBox1.ImageLocation = null;
            pictureBox2.ImageLocation = null;
            Vint_IDArch = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtImgID.Text = Vint_IDArch.ToString();
            if (txtProcessID.Text == "6")
            {

                var list = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ID == Vint_IDArch);
                if (list.PathFile != "")

                {
                    Image originalImage = Image.FromFile(list.PathFile.ToString());
                    Image.FromFile(list.PathFile.ToString());

                    pictureBox1.Image = originalImage;
                    pictureBox2.Image = originalImage;

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.MouseWheel += picturebox1_MouseWheel;

                    pictureBox1.MouseDown += pictureBox1_MouseDown;

                    pictureBox1.MouseMove += pictureBox1_MouseMove;
                    //pictureBox1.ImageLocation = list.PathFile.ToString();
                    textBox4.Text = list.PathFile.ToString();
                    //Resize(this.pictureBox1, 794, 1123);
                }
            }
            else
            {
                var list = FsEvDb.Tbl_ArchOrderAndLetterW.FirstOrDefault(x => x.ID == Vint_IDArch);
                if (list.PathFile != "")

                {
                    Image originalImage = Image.FromFile(list.PathFile.ToString());
                    Image.FromFile(list.PathFile.ToString());

                    pictureBox1.Image = originalImage;
                    pictureBox2.Image = originalImage;

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.MouseWheel += picturebox1_MouseWheel;

                    pictureBox1.MouseDown += pictureBox1_MouseDown;

                    pictureBox1.MouseMove += pictureBox1_MouseMove;
                    //pictureBox1.ImageLocation = list.PathFile.ToString();
                    textBox4.Text = list.PathFile.ToString();
                    //Resize(this.pictureBox1, 794, 1123);
                }
            }


        }
        private void picturebox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                pictureBox1.Width += 10;
                pictureBox1.Height += 10;
            }
            else
            {
                pictureBox1.Width -= 10;
                pictureBox1.Height -= 10;
            }
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(dataGridView1);

        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("من فضلك حدد الصوره المراد حذفها ");
            }
            else
            {

                string PathFile = textBox4.Text;
                Vint_IDArch = int.Parse(txtImgID.Text);
                var ArchList = FsEvDb.Tbl_ArchOrderAndLetterW.FirstOrDefault(x => x.ID == Vint_IDArch);
                //Process pro = Process.Start(ArchList.PathFile.ToString());
                //pro.Kill();

                if (pictureBox1.ImageLocation ==  ArchList.PathFile.ToString())
                {
                    pictureBox1.ImageLocation = null;

                }
                if (File.Exists(ArchList.PathFile.ToString()))
                {
                    FsEvDb.Tbl_ArchOrderAndLetterW.Remove(ArchList);
                    //File.Delete(ArchList.PathFile.ToString());
                    System.IO.File.Delete(@ArchList.PathFile.ToString());
                    FsEvDb.SaveChanges();
                    MessageBox.Show("تم الحذف");
                }

            }
        }
        //private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    Bitmap myBitmap1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
        //    pictureBox2.DrawToBitmap(myBitmap1, new Rectangle(0, 0, 842, 595));
        //    e.Graphics.DrawImage(myBitmap1, 0, 0);
        //    myBitmap1.Dispose();
        //}
        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0, e.MarginBounds.Width, e.MarginBounds.Height);
            myBitmap1.Dispose();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            PrintDialog myPrinDialog1 = new PrintDialog();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
            myPrinDialog1.Document = myPrintDocument1;
            if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //startPoint = e.Location;
            //startAngle = (int)Math.Atan2(startPoint.Y - pictureBox1.Height / 2, startPoint.Y - pictureBox1.Width / 2) * 180 / (int)Math.PI;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    int currentAngle = 0;
            //    int rotateAngle = 0;
            //    currentAngle = (int)Math.Atan2(e.Y - pictureBox1.Height / 2, e.Y - pictureBox1.Width / 2) * 180 / (int)Math.PI;
            //    rotateAngle = currentAngle - startAngle;
            //    pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //    startAngle = currentAngle;
            //    pictureBox1.Refresh();

            //}
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Refresh();
        }
static void DeleteFileWithRetry (string filePath, int maxRetryAttempts,int delay)
        {
            int attempts = 0;
            bool fileDeleteed = false;
            while (attempts< maxRetryAttempts && !fileDeleteed)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        MessageBox.Show("تم حذف الصوره");
                        fileDeleteed = true;

                    }
                    else
                    {
                        MessageBox.Show("الصوره تم حذفها من قبل");
                        fileDeleteed = true;
                    }
                }
                catch (IOException ex)
                {
                    attempts++;
                    if (attempts < maxRetryAttempts)
                    {
                        MessageBox.Show($"Attempts {attempts} failed.Retrying in {delay} milliseconds...");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to Delete the file after {attempts} attempts.error: {ex.Message}");
                    }
                }
            }
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                //Vint_IdItem = int.Parse(txtImgID.Text); 
                int Vlng_ID = int.Parse(txtImgID.Text);
                var listArchCheq = FsEvDb.Tbl_ArchOrderAndLetterW.FirstOrDefault(x => x.ID == Vlng_ID );
                //if (listArchCheq != null && !string.IsNullOrEmpty(listArchCheq.PathFile))
               if (listArchCheq != null )
                {
                    var resultMessageYesNo = MessageBox.Show("هل تريد حدف هده الصوره ؟", "حدف صوره من الامر ", MessageBoxButtons.YesNo);

                    if (resultMessageYesNo == DialogResult.Yes)
                    {
                        string Vst_FilePath = listArchCheq.PathFile.ToString();
                        if (listArchCheq.PathFile.ToLower().EndsWith(".pdf"))
                        {

                            if (File.Exists(Vst_FilePath))
                            {
                                //pdfViewer1.DocumentFilePath = null;
                                File.Delete(Vst_FilePath);
                            }
                        }
                        else
                        {

                            if (File.Exists(Vst_FilePath))
                            {
                                pictureBox1.ImageLocation = "";
                                pictureBox1.Visible = false;
                                //int MAXrETRYaTTEMPS = 5;
                                //int delay = 1000;
                                //DeleteFileWithRetry(Vst_FilePath, MAXrETRYaTTEMPS, delay);
                                File.Delete(Vst_FilePath);
                            }
                        }


                        FsEvDb.Tbl_ArchOrderAndLetterW.Remove(listArchCheq);
                        FsEvDb.SaveChanges();


                        //pdfViewer1.DocumentFilePath = "";
                        //pdfViewer1.Visible = false;
                        pictureBox1.ImageLocation = "";
                        pictureBox1.Visible = false;
                        //pdfCommandBar1.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            string PathFile = textBox4.Text;
            Vint_IDArch = int.Parse(txtImgID.Text);
            var ArchList = FsEvDb.Tbl_ArchOrderAndLetterW.FirstOrDefault(x => x.ID == Vint_IDArch);
            if (ArchList != null && !string.IsNullOrEmpty(ArchList.PathFile))
            {
                if (File.Exists(ArchList.PathFile))
                {
                    new System.IO.FileStream(@ArchList.PathFile, FileMode.Open, System.IO.FileAccess.Read);

                    Process.GetProcesses().First(p => string.Compare(p.MainModule.FileName, @ArchList.PathFile, true) == 0).Kill();
                    pictureBox1.ImageLocation = "";
                    //pictureBox1.Visible = false;
                    File.Delete(ArchList.PathFile);
                }
            }
            FsEvDb.Tbl_ArchOrderAndLetterW.Remove(ArchList);
            FsEvDb.SaveChanges();
        }
    }
}
