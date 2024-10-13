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
using FinancialSysApp.DataBase.Model;
using FinancialSysApp.DataBase.ModelEvents;
using DevComponents.DotNetBar.Controls;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class FindAssayesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public static DataGridViewRow SelectedRow { get; set; }
        public FindAssayesFrm()
        {
            InitializeComponent();
        }
private void DtaGrdView ()
        {
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["AssaysNo"].HeaderText = "رقم المقايسه";
            dataGridView1.Columns["AssaysDate"].HeaderText = "تاريخ المقايسه";
            dataGridView1.Columns["assaysKindName"].HeaderText = "نوع المقايسه";
            dataGridView1.Columns["assyasmanagement"].HeaderText = "الاداره";
            dataGridView1.Columns["assyasmanagement"].Width = 220;
            dataGridView1.Columns["AssaysKindId"].Visible = false;
             
        }
        private void FindAssayesFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from assys in FsDb.Tbl_Assays
                                        join assk in FsDb.Tbl_AssaysKind on assys.AssaysKindId equals assk.ID
                                        join Mng in FsDb.Tbl_Management on assys.ManagementID equals Mng.ID
                                        
                                        select new
                                        {
                                          ID = assys.ID,
                                            AssaysNo = assys.AssaysNo,
                                            AssaysDate = assys.AssaysDate,
                                            AssaysKindId = assys.AssaysKindId ,
                                         assaysKindName = assk.Name,
                                         assyasmanagement=Mng.Name
                                        }
                                        ).OrderBy(x=>x.AssaysDate).ToList();
            DtaGrdView();
            textBox1.Select();
            this.ActiveControl = textBox1;
            textBox1.Focus();

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                dataGridView1_CellDoubleClick(dataGridView1, args);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }

        private void textBox1_EditValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from assys in FsDb.Tbl_Assays
                                        join assk in FsDb.Tbl_AssaysKind on assys.AssaysKindId equals assk.ID
                                        join Mng in FsDb.Tbl_Management on assys.ManagementID equals Mng.ID
                                        where(assys.AssaysNo.Contains(textBox1.Text))
                                        select new
                                        {
                                            ID = assys.ID,
                                            AssaysNo = assys.AssaysNo,
                                            AssaysDate = assys.AssaysDate,
                                            AssaysKindId = assys.AssaysKindId,
                                            assaysKindName = assk.Name,
                                            assyasmanagement = Mng.Name
                                        }
                                       ).OrderBy(x => x.AssaysDate).ToList();
            DtaGrdView();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from assys in FsDb.Tbl_Assays
                                        join assk in FsDb.Tbl_AssaysKind on assys.AssaysKindId equals assk.ID
                                        join Mng in FsDb.Tbl_Management on assys.ManagementID equals Mng.ID
                                        where (assys.AssaysNo.Contains(textBox1.Text) && assys.AssaysDate==dateTimePicker1.Value)
                                        select new
                                        {
                                            ID = assys.ID,
                                            AssaysNo = assys.AssaysNo,
                                            AssaysDate = assys.AssaysDate,
                                            AssaysKindId = assys.AssaysKindId,
                                            assaysKindName = assk.Name,
                                            assyasmanagement = Mng.Name
                                        }
                                      ).OrderBy(x => x.AssaysDate).ToList();
            DtaGrdView();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void FindAssayesFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Escape )
            {
                SelectedRow = null  ;
                this.Close();
            }
        }
    }
}