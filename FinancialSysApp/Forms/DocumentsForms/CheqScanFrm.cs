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
using System.IO;

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class CheqScanFrm : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public CheqScanFrm()
        {
            InitializeComponent();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Refresh();
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
        private void CheqScanFrm_Load(object sender, EventArgs e)
        {
            try
            {
                long Vlng_ID = long.Parse(txtRowChequeID.Text);
                var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vlng_ID);
                if (listArchCheq.PathFile != "")
                {
                    if (listArchCheq.PathFile.ToLower().EndsWith(".pdf")) // Check if the file is a PDF
                    {
                        pdfViewer1.DocumentFilePath = listArchCheq.PathFile;
                        pdfViewer1.Visible = true;
                        simpleButton1.Visible = true;
                        simpleButton2.Visible = false ;
                        pictureBox1.Visible = false ;
                        pdfCommandBar1.Visible = true;
                    }
                    else // Assume it's an image
                    {
                        pictureBox1.ImageLocation = listArchCheq.PathFile;
                        pictureBox1.Visible = true;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.MouseWheel += picturebox1_MouseWheel;
                        simpleButton2.Visible = true;
                        simpleButton1.Visible = false ;
                        pdfViewer1.Visible = false ;
                        pdfCommandBar1.Visible = false;

                    }
                }
            }
            catch
            {
            }
            finally
            {
                // Hide the PictureBox or PdfViewer if no file was loaded
                if (pictureBox1.ImageLocation == null)
                {
                    pictureBox1.Visible = false;
                    simpleButton1.Visible = true;
                    simpleButton2.Visible = false;
                }
                if (pdfViewer1.DocumentFilePath == null)
                {
                    pdfViewer1.Visible = false;
                    simpleButton2.Visible = true;
                    simpleButton1.Visible = false;
                }
            }

        }
        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //try
            //{
                //if (pictureBox1.ImageLocation != null)
                //{
                   
                    System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
                    PrintDialog myPrinDialog1 = new PrintDialog();
                    myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
                    myPrinDialog1.Document = myPrintDocument1;
                    if (myPrinDialog1.ShowDialog() == DialogResult.OK)
                    {
                        myPrintDocument1.Print();
                    }
                //}
               
            //}
            //catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (pdfViewer1.DocumentFilePath != null)
            {

                pdfViewer1.Print();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                long Vlng_ID = long.Parse(txtRowChequeID.Text);
                var listArchCheq = FsEvDb.Tbl_ArchTrCollectioCheque.FirstOrDefault(x => x.ChequeBankID == Vlng_ID);
                if (listArchCheq != null && !string.IsNullOrEmpty(listArchCheq.PathFile))
                {
                   
                    if (listArchCheq.PathFile.ToLower().EndsWith(".pdf"))
                    {
                       
                        if (File.Exists(listArchCheq.PathFile))
                        {
                            pdfViewer1.DocumentFilePath = null;
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

                    
                    pdfViewer1.DocumentFilePath = "";
                    pdfViewer1.Visible = false;
                    pictureBox1.ImageLocation = "";
                    pictureBox1.Visible = false;
                    pdfCommandBar1.Visible = false;
                }
            }
            catch 
            {
                
            }
        }
    }
}
