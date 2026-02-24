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
    public partial class ListChar : UserControl
    {
        public ListChar()
        {
            InitializeComponent();
            
        }

        private string _Char;
        private string _LastObs;
        private string _Target;
        private string _LTL; //LSL
        private string _UTL; //USL
        private string _LCL; 
        private string _UCL; 
        private Color _pnlColor;

        private string _UPCL;
        private string _LPCL;
        private string _MasterSize;
        public string _GaugeSource;
        public string _ChannelNo;
        public string _ImageString;
        public string _PartNo; //ObsNo
        public string _ModelNo; //PartNo
        public string _CharID;
        public string _CharType;

        public int _CurrentCharCount;
        public int _InspectionStatusID;
        public int _prevInspectionStatusID;

        public int _TemplateID;
        public int _MachineID;

        public int _Formula; //30/05/23
        public int Formula //30/05/23 
        {
            get { return _Formula; }
            set { _Formula = value; }
        }

        public string _Event;

        [Category("Custom props")]
        public string Char
        {
            get { return _Char; }
            set { _Char = value; lblChar.Text = value; }
        }
        [Category("Custom props")]
        public string LastObs
        {
            get { return _LastObs; }
            set { _LastObs = value; lblLastObs.Text = value; }
        }
        [Category("Custom props")]
        public string Target
        {
            get { return _Target; }
            set { _Target = value; lblTarget.Text = value; }
        }
        [Category("Custom props")]
        public string UTL
        {
            get { return _UTL; }
            set { _UTL = value; lblUTL.Text = value; }
        }
        [Category("Custom props")]
        public string LTL
        {
            get { return _LTL; }
            set { _LTL = value; lblLTL.Text = value; }
        }

        //Added 30072022 - Aamir
        [Category("Custom props")]
        public string UCL
        {
            get { return _UCL; }
            set { _UCL = value; lblUCL.Text = value; }
        }
        [Category("Custom props")]
        public string LCL
        {
            get { return _LCL; }
            set { _LCL = value; lblLCL.Text = value; }
        }
        //Added 30072022 - Aamir


        [Category("Custom props")]
        public string UPCL
        {
            get { return _UPCL; }
            set { _UPCL = value; txtUPCL.Text = value; }
        }

        [Category("Custom props")]
        public string LPCL
        {
            get { return _LPCL; }
            set { _LPCL = value; txtLPCL.Text = value; }
        }

        [Category("Custom props")]
        public string MasterSize
        {
            get { return _MasterSize; }
            set { _MasterSize = value; txtMasterSize . Text = value; }
        }

        [Category("Custom props")]
        public string GaugeSource
        {
            get { return _GaugeSource; }
            set { _GaugeSource = value; txtGaugeSource.Text = value; }
        }

        [Category("Custom props")]
        public string ChannelNo
        {
            get { return _ChannelNo; }
            set { _ChannelNo = value; txtChannelNo.Text = value; }
        }

        [Category("Custom props")]
        public string ImageString
        {
            get { return _ImageString; }
            set { _ImageString = value; txtImageString.Text = value; }
        }

        [Category("Custom props")]
        public string PartNo //ObsNo
        {
            get { return _PartNo; }
            set { _PartNo = value; txtPartNo .Text = value; }
        }

        [Category("Custom props")]
        public string ModelNo //PartNo
        {
            get { return _ModelNo; }
            set { _ModelNo = value; txtModelNo.Text = value; }
        }

        [Category("Custom props")]
        public string CharID 
        {
            get { return _CharID; }
            set { _CharID = value; txtCharID .Text = value; }
        }

        [Category("Custom props")]
        public string CharType
        {
            get { return _CharType; }
            set { _CharType = value; txtCharType.Text = value; }
        }

        [Category("Custom props")]
        public int CurrentCharCount
        {
            get { return _CurrentCharCount; }
            set { _CurrentCharCount = value; }
        }

        [Category("Custom props")]
        public int InspectionStatusID
        {
            get { return _InspectionStatusID; }
            set { _InspectionStatusID = value; }
        }

        public int prevInspectionStatusID
        {
            get { return _prevInspectionStatusID; }
            set { _prevInspectionStatusID = value; }
        }

        [Category("Custom props")]
        public int TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }

        [Category("Custom props")]
        public int MachineID
        {
            get { return _MachineID; }
            set { _MachineID = value; }
        }

        public string Event
        {
            get { return _Event; }
            set { _Event = value; lblEvent.Text = value;  }
        }


        [Category("Custom props")]
        public Color PanelColor
        {
            get { return _pnlColor; }
            set { _pnlColor = value; pnlMain.BackColor   = value; }
        }

        private void ListChar_Click(object sender, EventArgs e)
        {

        }







        //private void ListChar_Load(object sender, EventArgs e)
        //{
        //    txtCurrentReading.Focus();  
        //}

        //public void txtCurrentReading_KeyDown(object sender, KeyEventArgs e)
        //{

        //}



        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
        //                                 Color.Red, ButtonBorderStyle.Solid);

        //}

        //private void ListChar_Load(object sender, EventArgs e)
        //{
        //    Invalidate(); 
        //}
    }
}
