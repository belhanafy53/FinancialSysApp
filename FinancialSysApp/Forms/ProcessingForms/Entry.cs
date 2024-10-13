using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class Entry : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Entry()
        {
            InitializeComponent();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.EntryDoc   f = new EntryDoc();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            barButtonItem1.Caption = "إغلاق";

        }

        private void Entry_Load(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.CheckDay f = new CheckDay();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            //barButtonItem1.Caption = "إغلاق ميزان المراجعة";
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.CheckDay f = new CheckDay();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.Rev_EXP  f = new Rev_EXP();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            barButtonItem1.Caption = "إغلاق ";
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.XtraUserControl1  f = new XtraUserControl1();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            //barButtonItem1.Caption = "إغلاق قائمة المركز المالى";
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }
    }
}
