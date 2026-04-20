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
        public static int InsertData(StoredProcedure sp, SqlParameter[] parameters)
        {
            return CommonDL.InsertData(sp, parameters);
        }

        public static DataSet GetTemplateQueueData(StoredProcedure sp, SqlParameter[] parameters)
        {
            return CommonDL.GetTemplateQueueData(sp, parameters);
        }

        public static DataTable GetModifyData(StoredProcedure sp, SqlParameter[] parameters)
        {
            return CommonDL.GetModifyData(sp, parameters);
        }

        public static DataTable GetDataTable(StoredProcedure sp, SqlParameter[] parameters)
        {
            return CommonDL.GetDataTable(sp, parameters);
        }
    }
}
