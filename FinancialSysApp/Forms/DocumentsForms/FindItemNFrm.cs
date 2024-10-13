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

namespace FinancialSysApp.Forms.DocumentsForms
{
    public partial class FindItemNFrm : DevExpress.XtraEditors.XtraForm
    {
        Model1 FsDb = new Model1();
        ModelEvent FsEvDb = new ModelEvent();
        public FindItemNFrm()
        {
            InitializeComponent();
        }

        private void FindItemNFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'financialSysDataSet.Tbl_Items' table. You can move, or remove it, as needed.
            this.tbl_ItemsTableAdapter.Fill(this.financialSysDataSet.Tbl_Items);
            Nametxt.Focus();
        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            var list = FsDb.Tbl_Items.Where(x => x.Name.Contains(Nametxt.Text)).ToList();
            radTreeView1.DataSource = list;
           
            radTreeView1.ExpandAll();
        }

        private void FindItemNFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}