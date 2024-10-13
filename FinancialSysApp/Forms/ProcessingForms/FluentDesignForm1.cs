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
    public partial class FluentDesignForm1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FluentDesignForm1()
        {
            InitializeComponent();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.TRial  f = new TRial();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            barButtonItem1.Caption = "إغلاق ميزان المراجعة";

        }

        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            //this.fluentDesignFormContainer1.Controls.Clear();
            //Forms.ProcessingForms.TRial f = new TRial();
            ////this.ControlContainer = f;
            ////this.fluentDesignFormContainer1.Controls.Add(f);
            ////this.Controls.Add(f);
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            //barButtonItem1.Caption = "إغلاق ميزان المراجعة";
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
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
            barButtonItem1.Caption = "إغلاق قائمة الإيراد والمصروف";
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.Financial_CenterControl  f = new Financial_CenterControl();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            barButtonItem1.Caption = "إغلاق قائمة المركز المالى";
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.Assest  f = new Assest();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            barButtonItem1.Caption = "إغلاق ";
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            this.fluentDesignFormContainer1.Controls.Clear();
            Forms.ProcessingForms.Ongoing_Operations f = new Ongoing_Operations();
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            this.fluentDesignFormContainer1.Controls.Add(f);
            this.fluentDesignFormContainer1.Dock = DockStyle.Fill;
            barButtonItem1.Caption = "إغلاق ";
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            Forms.ProcessingForms.frm_TRIAl_Balance t = new frm_TRIAl_Balance();
            t.ShowDialog();
        }
    }
}
