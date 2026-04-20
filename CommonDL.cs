using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPC_KDL
{
    class CommonDL
    {
        DBConnect call = new DBConnect();
        static SqlConnection conn = new SqlConnection();

        //added by kanhaiya 07/03/2026
        private static string ResolveSP(StoredProcedure sp)
        {
            switch (sp)
            {
                case StoredProcedure.GetChartData:
                    return "sp_GetChartData";

                case StoredProcedure.GetStationMachineList:
                    return "spGetStation_Machine_List";

                case StoredProcedure.GetTemplateInspectionHdrData:
                    return "spGetTemplate_InspectionHdrData";

                case StoredProcedure.GetChartDataWin:
                    return "sp_GetChartData_Win";

                case StoredProcedure.GetTemplateList:
                    return "spGetTempate_List";

                case StoredProcedure.InsertEventInspectionData:
                    return "spInsert_EventInspectionData";

                case StoredProcedure.InsertInspectionData:
                    return "spInsert_InspectionData";

                case StoredProcedure.RetakeData:
                    return "Sp_RetakeDAta";

                case StoredProcedure.UpdateModifyData:
                    return "Sp_UpdateModifyData";

                case StoredProcedure.RemovePartInQueue:
                    return "Sp_RemovePartInQueue";

                case StoredProcedure.InsertTraceabilityData:
                    return "spInsert_TracebilityData";

                case StoredProcedure.GetDataForEvent:
                    return "sp_getDataForEvent";

                case StoredProcedure.GetEventMsg:
                    return "sp_GetEventMsg";

                case StoredProcedure.GetChartDataDE:
                    return "sp_GetChartData_DE";

                case StoredProcedure.GetDataToModify:
                    return "sp_getDataToModify";

                case StoredProcedure.GetDataToRemovePartInspectionQueue:
                    return "sp_getDataToRemovePartInspectionQueue";

                case StoredProcedure.GetTemplateData:
                    return "pgetTemplate";

                case StoredProcedure.CheckConfig:
                    return "sp_check_config";

                case StoredProcedure.GetChartDataExport:
                    return "sp_GetChartData_Export";

                default:
                    throw new SecurityException("Invalid stored procedure.");
            }
        }

        private static SqlConnection GetOpenConnection()
        {
            var c = DBConnect.connect();
            if (c.State == ConnectionState.Closed) c.Open();
            return c;
        }

        private static void CloseConnection(SqlConnection c)
        {
            if (c != null && c.State == ConnectionState.Open) c.Close();
        }

        public static DataTable getCombo(int UserID, int ActionID, string keyValue, string ModelNo = "")

        {
            conn = DBConnect.connect();
            DataTable dataTable = new DataTable();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetFillCombo", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = UserID;
                    cmd.Parameters.Add("@actionid", SqlDbType.Int).Value = ActionID;
                    cmd.Parameters.Add("@String", SqlDbType.VarChar).Value = keyValue;
                    if (ModelNo != "")
                        {
                        cmd.Parameters.Add("@ModelNo", SqlDbType.VarChar).Value = ModelNo;
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                conn = null;
            }
            return dataTable;
        }
        public static int InsertData(StoredProcedure sp, SqlParameter[] parameters)
        {
            int returnValue = 0;

            using (var conn = DBConnect.connect())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using (var cmd = new SqlCommand(ResolveSP(sp), conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    returnValue = cmd.ExecuteNonQuery();
                }
            }

            return returnValue;
        }
        public static DataSet GetTemplateQueueData(StoredProcedure sp, SqlParameter[] parameters)
        {
            using (var conn = DBConnect.connect())
            using (var cmd = new SqlCommand(ResolveSP(sp), conn))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600000;

                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                var ds = new DataSet();

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(ds);
                }

                return ds;
            }
        }
        public static DataTable GetModifyData(StoredProcedure sp, SqlParameter[] parameters)
        {
            using (var conn = DBConnect.connect())
            using (var cmd = new SqlCommand(ResolveSP(sp), conn))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600000;

                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                var dt = new DataTable();

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
        }
        public static DataTable GetDataTable(StoredProcedure sp, SqlParameter[] parameters)
        {
            using (var conn = DBConnect.connect())
            using (var cmd = new SqlCommand(ResolveSP(sp), conn))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600000;

                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                var dt = new DataTable();

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
        }
    }
}

