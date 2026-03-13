using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPC_KDL
{
    static class Program
    {
        private static int _userID, _roleID, _stationID;
        public static int userID { get => _userID; set => _userID = value; }
        public static int roleID { get => _roleID; set => _roleID = value; }
        public static int stationID { get => _stationID; set => _stationID = value; }

        private static string _name, _username, _mac;
        public static string name { get => _name; set => _name = value; }
        public static string username { get => _username; set => _username = value; }
        public static string mac { get => _mac; set => _mac = value; }

        //Scan
        private static int _templateID, _eventID, _machineID;
        private static string _operator, _pallet;
        public static int TemplateID { get => _templateID; set => _templateID = value; }
        public static int EventID { get => _eventID; set => _eventID = value; }
        public static int MachineID { get => _machineID; set => _machineID = value; }
        public static string Operator { get => _operator; set => _operator = value; }
        public static string Pallet { get => _pallet; set => _pallet = value; }


        //Modify
        private static int _currentTemplateID, _currentMachineID;
        public static int CurrentTemplateID { get => _currentTemplateID; set => _currentTemplateID = value; }
        public static int CurrentMachineID { get => _currentMachineID; set => _currentMachineID = value; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin()); //MDISPC
        }
    }
}
