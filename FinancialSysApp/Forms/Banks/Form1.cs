﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevExpress.XtraSplashScreen;
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using MahApps.Metro.Controls;

namespace FinancialSysApp.Forms.Banks
{
    public partial class Form1 : Form
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime Vd_r = Convert.ToDateTime("2024-07-01");
            var listRef = FsDb.Tbl_BankMovement.Where(x=>x.MoveDat >= Vd_r).OrderBy(x=>x.MoveDat).ToList();
            dataGridView1.DataSource = listRef;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int? Vint_FiscYear = 0;
                int? Vint_CountMb = 0;
                int? Vint_id = 0;
                string Vst_YearMovDate = "";
                DateTime? Vd_Date = null;
                string Vst_FinancialYear = "";
               string Vst_CodeGenerate = "";

                Vint_id = int.Parse(row.Cells[0].Value.ToString());
                var listBnkMv = FsDb.Tbl_BankMovement.Where(x => x.ID == Vint_id).OrderBy(x=>x.MoveDat).ToList();
                Vd_Date = Convert.ToDateTime(row.Cells[1].Value.ToString());

                var list =  FsDb.Tbl_Fiscalyear.Where(x => x.DateFrom <= Vd_Date && x.DateTo >= Vd_Date).ToList();

                if (list.Count > 0)
                {
                    Vst_YearMovDate = list[0].FinancialYear.ToString();
                    Vint_FiscYear = int.Parse(list[0].ID.ToString());
                }
                
                int bnkid = int.Parse(row.Cells[16].Value.ToString());
                int bnkaccid = int.Parse(row.Cells[17].Value.ToString());
                Vst_FinancialYear = FsDb.Tbl_Fiscalyear.Where(x => x.ID == Vint_FiscYear).Select(x => x.FinancialYear).FirstOrDefault();

                Vint_CountMb = FsDb.Tbl_BankMovement.Where(x => x.FisicalYeariD == Vint_FiscYear && x.BankAccID == bnkaccid).ToList().Max(x => x.AccountBankCode);
                if (Vint_CountMb == null) { Vint_CountMb = 0; }
                string BankAccNo = FsDb.Tbl_AccountsBank.Where(x => x.ID == bnkaccid).Select(x => x.AccountBankNo).FirstOrDefault();
                string bnkacc4charch = BankAccNo.Substring(BankAccNo.Length - 2);
                Vst_CodeGenerate = Vst_FinancialYear + "/" + bnkacc4charch  + "/"+ (Vint_CountMb + 1).ToString();
                //**************************

                listBnkMv[0].AccountBankCode = Vint_CountMb + 1 ;
                //listBnkMv[0].C5 = Vst_CodeGenerate;
                
                FsDb.SaveChanges();


            }
        }
    }
}
 