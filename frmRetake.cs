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
    public partial class frmRetake : Form
    {
        public string ModelRetake { get; set; }
        public string CharRetake { get; set; }
        public int TempIDRetake { get; set; }
        public int MachIDRetake { get; set; }
        public string PartRetake { get; set; }
        public string CharIDRetake { get; set; }
        public int srNoRetake { get; set; }

        public int onlyCurrentCharRetake { get; set; }

        string ModelNo = "";
        string CharName = "";
        int currCharRetk = 0;

        public frmRetake(string Model, string Char, int TempID, int MachID, string Part, string CharID, int srNo, int onlyCurrentChar)
        {
            
            InitializeComponent();

            ModelNo = Model;
            CharName = Char;

            currCharRetk = onlyCurrentChar; 

            if (onlyCurrentChar == 1)
            {
                lblModel.Text = Model + " - " + Char + " ?";
            }
            else
            {
                lblModel.Text = Model + " ?";
                lblMsg1.Text = "Retake for all Characteristics"; 
            }

            txtTemplateID.Text  = TempID.ToString() ;
            txtMachineID.Text = MachID.ToString();
            txtPartNo.Text = Part;
            txtCharID.Text = CharID;
            txtCurrentCharCount.Text = srNo.ToString();   
           // lblChar.Text = Char;  
        }

        private void frmRetake_Load(object sender, EventArgs e)
        {

        }

        private void frmRetake_Activated(object sender, EventArgs e)
        {

        }

        private void frmRetake_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close(); //Aamir - TODO - 08/08/2022
            //Dispose();                    
        }

        private void frmRetake_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Dispose();
                Close();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ModelRetake = ModelNo;
            CharRetake = CharName;
            TempIDRetake = Convert.ToInt32(txtTemplateID.Text);
            MachIDRetake = Convert.ToInt32(txtMachineID.Text);
            PartRetake = txtPartNo.Text;
            CharIDRetake = txtCharID.Text;
            srNoRetake = Convert.ToInt32(txtCurrentCharCount.Text);
            onlyCurrentCharRetake = currCharRetk;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }
    }
}
