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
using DevExpress.DataProcessing;

namespace FinancialSysApp.Forms.BasicCodeForms
{
    public partial class FindEmployeesFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public static DataGridViewRow SelectedRow { get; set; }
        public FindEmployeesFrm()
        {
            InitializeComponent();
        }

        private void FindEmployeesFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from emp in FsDb.Tbl_Employee
                                        join MNG in FsDb.Tbl_Management on emp.Management_ID equals MNG.Management_ID
                                         select new
                                        {
                                            ID = emp.ID,
                                            Name = emp.Name,
                                            NationalId = emp.NationalId,
                                            Management_ID = emp.Management_ID,
                                            mngName = MNG.Name,
                                            WorkerJob = emp.WorkerJob,
                                            Status = emp.Status ,
                                            StatusDate = emp.StatusDate,
                                            StatusDetails = emp.StatusDetail
                                        }
                                        ).Take(20).OrderBy(x => x.ID).ToList();
            DtaGrdView();
            txtEmployee.Select();
            this.ActiveControl = txtEmployee;
            txtEmployee.Focus();
        }
        private void DtaGrdView()
        {
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "اسم الموظف";
            dataGridView1.Columns["NationalId"].HeaderText = "رقم البطاقه";
            dataGridView1.Columns["mngName"].HeaderText = "الادارة";
            dataGridView1.Columns["WorkerJob"].HeaderText = "الوظيفه";
            dataGridView1.Columns["Status"].HeaderText = "حالة الموظف";
            dataGridView1.Columns["StatusDate"].HeaderText = "تاريخ الحاله";
            dataGridView1.Columns["StatusDetails"].HeaderText = "تفاصيل الحاله";
            dataGridView1.Columns["mngName"].Width = 220;
            dataGridView1.Columns["Management_ID"].Visible = false;

        }

        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployee.Text == "")
            {
                dataGridView1.DataSource = (from emp in FsDb.Tbl_Employee
                                            join MNG in FsDb.Tbl_Management on emp.Management_ID equals MNG.Management_ID
                                            
                                            select new
                                            {
                                                ID = emp.ID,
                                                Name = emp.Name,
                                                NationalId = emp.NationalId,
                                                Management_ID = emp.Management_ID,
                                                mngName = MNG.Name,
                                                WorkerJob = emp.WorkerJob,
                                                Status = emp.Status,
                                                StatusDate = emp.StatusDate,
                                                StatusDetails = emp.StatusDetail
                                            }
                                      ).OrderBy(x => x.ID).ToList();
                DtaGrdView();
                txtEmployee.Select();
                this.ActiveControl = txtEmployee;
                txtEmployee.Focus();
            }
            else
            {
                dataGridView1.DataSource = (from emp in FsDb.Tbl_Employee
                                            join MNG in FsDb.Tbl_Management on emp.Management_ID equals MNG.Management_ID
                                            where (emp.Name.Contains(txtEmployee.Text))
                                            select new
                                            {
                                                ID = emp.ID,
                                                Name = emp.Name,
                                                NationalId = emp.NationalId,
                                                Management_ID = emp.Management_ID,
                                                mngName = MNG.Name,
                                                WorkerJob = emp.WorkerJob,
                                                Status = emp.Status,
                                                StatusDate = emp.StatusDate,
                                                StatusDetails = emp.StatusDetail
                                            }
                                      ).OrderBy(x => x.ID).ToList();
                DtaGrdView();
                txtEmployee.Select();
                this.ActiveControl = txtEmployee;
                txtEmployee.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);

                dataGridView1_CellDoubleClick(dataGridView1, args);
            }
        }

        private void txtEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = dataGridView1.Rows[e.RowIndex];
            this.Close();
        }
    }
}