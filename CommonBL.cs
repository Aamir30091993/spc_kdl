using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SPC_KDL
{
    class CommonBL
    {
        public static DataTable getCombo(int UserID, int ActionID, string keyValue, string ModelNo = "")
        {
            return CommonDL.getCombo(UserID, ActionID, keyValue, ModelNo);
        }
        public static int InsertData(string spName, SqlParameter[] paramters)
        {
            return CommonDL.InsertData(spName, paramters);
        }

         public static DataSet GetTemplateQueueData(string spName, SqlParameter[] parameters)
        {
            return CommonDL.GetTemplateQueueData(spName, parameters);
        }

        public static DataTable GetModifyData(string spName, SqlParameter[] parameters)
        {
            return CommonDL.GetModifyData(spName, parameters);
        }

        public static DataTable GetDataTable(string spName, SqlParameter[] parameters)
        {
            return CommonDL.GetModifyData(spName, parameters);
        }
    }
}
