using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.FluentDesignSystem;
using FinancialSysApp.DataBase.Model;

namespace FinancialSysApp.Forms.ProcessingForms
{
    public partial class CheckDay : DevExpress.XtraEditors.XtraUserControl
    {
        public CheckDay()
        {
            InitializeComponent();
            //Model1 FsDb = new Model1();
           
            //checkedListBox1.Items[0].ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true )
            {
                checkBox2.Checked = false ;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox1.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox1.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FluentDesignFormContainer fluentDesignFormContainer1 = new FluentDesignFormContainer();
            //FluentDesignForm1 fo = new FluentDesignForm1();
            //fo.Controls.Clear();
            Forms.ProcessingForms.RadForm2  f = new RadForm2();

            if (checkBox1.Checked == true)
            {
               
                f.checkBox1.Checked = true;
                f.checkBox2.Checked = false;
                f.checkBox3.Checked = false;
                f.checkBox4.Checked = false;
                f.checkBox5.Checked = false;
                f.checkBox6.Checked = false;
                f.checkBox7.Checked = false;
            }
            if (checkBox2.Checked == true)
            {

                f.checkBox2.Checked = true;
                f.checkBox1.Checked = false;
                f.checkBox3.Checked = false;
                f.checkBox4.Checked = false;
                f.checkBox5.Checked = false;
                f.checkBox6.Checked = false;
                f.checkBox7.Checked = false;
            }
            if (checkBox3.Checked == true)
            {

                f.checkBox3.Checked = true;
                f.checkBox2.Checked = false;
                f.checkBox1.Checked = false;
                f.checkBox4.Checked = false;
                f.checkBox5.Checked = false;
                f.checkBox6.Checked = false;
                f.checkBox7.Checked = false;
            }
            if (checkBox4.Checked == true)
            {

                f.checkBox4.Checked = true;
                f.checkBox2.Checked = false;
                f.checkBox3.Checked = false;
                f.checkBox1.Checked = false;
                f.checkBox5.Checked = false;
                f.checkBox6.Checked = false;
                f.checkBox7.Checked = false;
            }
            if (checkBox5.Checked == true)
            {

                f.checkBox5.Checked = true;
                f.checkBox2.Checked = false;
                f.checkBox3.Checked = false;
                f.checkBox4.Checked = false;
                f.checkBox1.Checked = false;
                f.checkBox6.Checked = false;
                f.checkBox7.Checked = false;
            }
            if (checkBox6.Checked == true)
            {

                f.checkBox6.Checked = true;
                f.checkBox2.Checked = false;
                f.checkBox3.Checked = false;
                f.checkBox4.Checked = false;
                f.checkBox5.Checked = false;
                f.checkBox1.Checked = false;
                f.checkBox7.Checked = false;
            }
            if (checkBox7.Checked == true)
            {

                f.checkBox7.Checked = true;
                f.checkBox2.Checked = false;
                f.checkBox3.Checked = false;
                f.checkBox4.Checked = false;
                f.checkBox5.Checked = false;
                f.checkBox6.Checked = false;
                f.checkBox1.Checked = false;
            }
            f.ShowDialog();
            //this.Controls.Clear();
            //f.Dock = DockStyle.Fill;
            //// Add the user control to the form.
            //this.Controls.Add(f);
            //this.ControlContainer = f;
            //this.fluentDesignFormContainer1.Controls.Add(f);
            //this.Controls.Add(f);
            //fo.Controls.Add(f);
            //fo.Dock = DockStyle.Fill;
        }
    }
}
