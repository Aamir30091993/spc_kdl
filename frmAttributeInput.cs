using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPC_KDL
{
    public partial class frmAttributeInput : Form
    {
        public string ReturnValDefect { get; set; }
        public frmAttributeInput(string Model, string Part, string Attribute)
        {
            InitializeComponent();

            txtPartAttribute.Text = Model;
            txtObsAttribute.Text = Part;
            txtAttribute.Text = Attribute;

        }
        private void frmAttributeInput_Load(object sender, EventArgs e)
        {
            cmbDefectsAttribute.SelectedIndex = -1; 
        }
        private void btnOKAttribute_Click(object sender, EventArgs e)
        {
            if (cmbDefectsAttribute.SelectedItem != null)
            {
                if (cmbDefectsAttribute.SelectedItem.ToString() == "")
                {
                    errorProvider1.SetError(cmbDefectsAttribute, "Please select Defects -  Pass/Fail");
                    cmbDefectsAttribute.Focus();
                    //   MessageBox.Show("Please select Defects -  Pass/Fail", "");
                    return;                    
                }
                else
                {
                    this.ReturnValDefect = cmbDefectsAttribute.SelectedItem.ToString();
                }
            }
            else
            {
                errorProvider1.SetError(cmbDefectsAttribute, "Please select Defects -  Pass/Fail");
                cmbDefectsAttribute.Focus();
                //  MessageBox.Show("Please select Defects -  Pass/Fail", "");
                return;
            }
        }
        private void btnCloseAttribute_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose(); 
        }
        private void cmbDefectsAttribute_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (cmbDefectsAttribute != null)
            {
                if (cmbDefectsAttribute.SelectedItem != null)
                {
                    if (cmbDefectsAttribute.SelectedItem.ToString() != "")
                    {
                        //btnOKAttribute.DialogResult = DialogResult.OK;
                        // btnOKAttribute_Click("OK", e);
                        if (e.KeyCode == Keys.Enter)
                        {
                            btnOKAttribute.PerformClick();
                        }
                    }
                }
            }
        }
        private void frmAttributeInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }
        private void frmAttributeInput_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Dispose();
                this.Close();
            }

            else
            {
                string s = this.ActiveControl.Text;
                if ((s == "OK" || s == "") && cmbDefectsAttribute.SelectedItem == null)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.Dispose();
                    this.Close();
                }
            }
            //string s = this.ActiveControl.Text;

            //if (s == "OK" && cmbDefectsAttribute.SelectedItem == null)
            //{
            //    e.Cancel = true;
            //}

            //else
            //{
            //    this.Dispose();
            //    this.Close();
            //}

        }
   
        //private void frmAttributeInput_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    string s = this.ActiveControl.Text;

        //    if (s  == "OK" && cmbDefectsAttribute.SelectedItem != null)
        //    {
        //        this.Close();
        //        this.Dispose();
        //    }
        //}
    }
}
