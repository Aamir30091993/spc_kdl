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
    public partial class frmKeyboard : Form
    {
        public string manualReading{ get; set; }
        public int currentSrNo{ get; set; }
        public frmKeyboard(string Model, string Char, string LTL, string Target, string UTL, int srNo) //string Model, string Char, string LTL, string Target, string UTL
        {
            InitializeComponent();
            chkMasterSize.Checked = true;//14/07/23

            if (Model != null)
            {
                txtPartKeyboard.Text = Model;
                txtCharacteristicKeyboard.Text = Char.Split(':')[1].Trim();
                //txtLTL_Target_UTL_keyboard.Text = LTL + ", " + Target + ", " + UTL;

                txtUTL.Text = UTL.Split(':')[1].Trim();
                txtTarget.Text = Target.Split(':')[1].Trim();
                txtLTL.Text = LTL.Split(':')[1].Trim();
            }

            txtcurrentCharCount.Text = srNo.ToString();    
        }

        private void btnOKKeyboard_Click(object sender, EventArgs e)
        {
            if (txtValueKeyboard.Text  == "")
            {
                // MessageBox.Show("Please enter Value", "");
                errorProvider1.SetError(txtValueKeyboard, "Please enter Value");
                txtValueKeyboard.Focus();  
              //  return;
                
            }
           
            else
            {
                this.manualReading = txtValueKeyboard.Text ;
                this.currentSrNo = Convert.ToInt32(txtcurrentCharCount.Text); 
            }
        }

        private void btnCloseKeyboard_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtValueKeyboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtValueKeyboard != null)
            {
                if (txtValueKeyboard.Text != null)
                {
                    if (txtValueKeyboard.Text != "")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            btnOKKeyboard.PerformClick();
                        }
                    }
                }
            }
        }

        private void txtValueKeyboard_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void frmKeyboard_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        //private void frmKeyboard_FormClosed(object sender, FormClosedEventArgs e)
        //{

        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        this.Close();
        //        this.Dispose();
        //    }

        //    else
        //    {
        //        string s = this.ActiveControl.Text;
        //        if (s == "OK" && txtValueKeyboard.Text == "")
        //        {
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            this.Close();
        //            this.Dispose();
        //        }
        //    }

        
        //}

        private void lblPartKeyboard_Click(object sender, EventArgs e)
        {

        }

        private void frmKeyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Dispose();
                this.Close();
            }

            else
            {
                string s = this.ActiveControl.Text;
                if ((s == "OK" || s == "") && txtValueKeyboard.Text == "")
                {
                    e.Cancel = true;
                }
                else
                {
                    this.Dispose();
                    this.Close();
                }
            }
        }
    }
}
