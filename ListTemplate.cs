using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPC_KDL
{
    public partial class ListTemplate : UserControl
    {
        public ListTemplate()
        {
            InitializeComponent();
        }

        private string _template;
        private int _templateID;

        [Category("Custom props")]
        public string Template
        {
            get { return _template; }
            set { _template = value; lblTemplate.Text = value;  }
        }

        [Category("Custom props")]
        public int TemplateID
        {
            get { return _templateID; }
            set { _templateID = value; /*Visible = false;*/ }
        }

        private void ListTemplate_MouseEnter(object sender, EventArgs e)
        {
         //   this.BackColor = Color.LightSkyBlue; 
        }

        private void ListTemplate_MouseLeave(object sender, EventArgs e)
        {
        //    this.BackColor = Color.White;
        }


    }
}
