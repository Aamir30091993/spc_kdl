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
    public partial class ListQueue : UserControl
    {
        public ListQueue()
        {
            InitializeComponent();
        }

        private string _PartNo;
        private string _MachineNo;
        private string _Pallet;
        private string _Time;

        public int _currentTempID;
        public int _currentMachineID;

        [Category("Custom props")]
        public string PartNo
        {
            get { return _PartNo; }
            set { _PartNo = value; lblPartNo.Text = value; }
        }
        [Category("Custom props")]
        public string MachineNo
        {
            get { return _MachineNo; }
            set { _MachineNo = value; lblMachineNo.Text = value; }
        }
        [Category("Custom props")]
        public string Pallet
        {
            get { return _Pallet; }
            set { _Pallet = value; lblPallet.Text = value; }
        }
        [Category("Custom props")]
        public string Time
        {
            get { return _Time; }
            set { _Time = value; lblTime.Text = value; }
        }

        [Category("Custom props")]
        public int CurrentTemplateID
        {
            get { return _currentTempID; }
            set { _currentTempID = value;  }
        }

        [Category("Custom props")]
        public int CurrentMachineID
        {
            get { return _currentMachineID; }
            set { _currentMachineID = value; }
        }
    }
}
