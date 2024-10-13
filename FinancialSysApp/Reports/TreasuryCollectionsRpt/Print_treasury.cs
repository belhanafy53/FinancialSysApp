using FinancialSysApp. DataBase. Model;
using FinancialSysApp. DataBase. ModelEvents;
using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Drawing;
using System. Linq;
using System. Text;
using System. Threading. Tasks;
using System. Windows. Forms;
using System. Data. SqlClient;
using System. Configuration;
using FinancialSysApp. Classes;
using DevComponents. DotNetBar. Controls;
using System. Globalization;

namespace FinancialSysApp. Reports. TreasuryCollectionsRpt
    {
    public partial class Print_treasury : DevExpress. XtraEditors. XtraForm
        {
        public Print_treasury()
            {
            InitializeComponent();
            }

        private void Print_treasury_Load(object sender, EventArgs e)
            {
            // TODO: This line of code loads data into the 'treasury_ٌReport.Big' table. You can move, or remove it, as needed.
           

            }

        private void dTPAddBank_KeyPress(object sender, KeyPressEventArgs e)
            {
           
            }

        private void dTPAddBank_KeyDown(object sender, KeyEventArgs e)
            {
            if(e. KeyCode == Keys. Enter)
                {
                this. bigTableAdapter. FillBig(this. treasury_ٌReport. Big, Convert. ToDateTime(dTPAddBank. Value). ToString());
                reportViewer2. RefreshReport();

               

                this. dataTable1TableAdapter. FillBrunches(this. treasury_ٌReport. DataTable1, Convert. ToDateTime(dTPAddBank. Value). ToShortDateString());
                reportViewer1. RefreshReport();
                }
            }
        }
    }
