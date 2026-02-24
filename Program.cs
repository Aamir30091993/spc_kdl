using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPC_KDL
{
    static class Program
    {
        public static int userID, roleID, stationID;
        public static string name, username, mac;

        //Scan
        public static int TemplateID, EventID, MachineID;
        public static string Operator, Pallet;

        //Modify
        public static int CurrentTemplateID, CurrentMachineID;

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
