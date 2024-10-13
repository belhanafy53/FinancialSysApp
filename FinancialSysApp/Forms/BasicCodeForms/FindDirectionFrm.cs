﻿using System;
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
//using Microsoft.ReportingServices.Diagnostics.;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class FindDirectionFrm : Form
    {
        Model1 FsDb = new Model1();
        public static DataGridViewRow SelectedRow { get; set; }
        public FindDirectionFrm()
        {
            InitializeComponent();
        }

        private void FindDirectionFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Management1' table. You can move, or remove it, as needed.
            this.tbl_Management1TableAdapter.FillByKindBr(this.financialSysDataSet.Tbl_Management1,2);

        }

        private void txtBranche_TextChanged(object sender, EventArgs e)
        {
            if (txtBranche.Text != "")
            {
                var listBranchesNam = FsDb.Tbl_Management.Where(x => x.BrancheName.Contains(txtBranche.Text) && x.KindBranchDirect == 2 && x.BrancheName != null).ToList();
                dataGridView1.DataSource = listBranchesNam;
            }
            else
            {
                var listBranches = FsDb.Tbl_Management.Where(x => x.BrancheName != null && x.KindBranchDirect == 2).ToList();
                dataGridView1.DataSource = listBranches;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //SelectedRow = dataGridView1.Rows[e.RowIndex];
            //this.Close();
        }

        private void FindDirectionFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SelectedRow == null)
            {
                try
                {
                    var listBranchesNam = FsDb.Tbl_Management.Where(x => x.BrancheName.Contains(txtBranche.Text) && x.KindBranchDirect == 2).ToList();
                    dataGridView1.DataSource = listBranchesNam;
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
                    if (args != null)
                    { dataGridView1_CellDoubleClick(dataGridView1, args); }
                }
                catch { }
            }
        }

        private void txtBranche_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
                if (args != null)
                { dataGridView1_CellClick(dataGridView1, args); }
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }
    }
}
