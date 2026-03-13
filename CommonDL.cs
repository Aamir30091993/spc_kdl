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
        private static readonly HashSet<string> _allowedProcedures = new HashSet<string>(
             StringComparer.OrdinalIgnoreCase)   // case-insensitive match
        {
            // insert / update / delete
            "spInsert_EventInspectionData",
            "spInsert_InspectionData",
            "Sp_RetakeDAta",
            "Sp_UpdateModifyData",
            "Sp_RemovePartInQueue",
            "spInsert_TracebilityData",

            // GetTemplateQueueData calls
            "sp_GetChartData",
            "spGetTempate_List",
            "spGetStation_Machine_List",
            "spGetTemplate_InspectionHdrData",
            "sp_GetChartData_Win",

            // GetModifyData calls
            "sp_getDataForEvent",
            "sp_GetEventMsg",
            "sp_GetChartData_DE",
            "sp_getDataToModify",
            "sp_getDataToRemovePartInspectionQueue",
            "pgetTemplate",
            "sp_check_config",

            // GetDataTable calls
            "sp_GetChartData_Export",

            // add every other SP your app calls here
        };
        private static void ValidateProcedureName(string spName)
        {
            if (string.IsNullOrWhiteSpace(spName) || !_allowedProcedures.Contains(spName))
                throw new SecurityException(
                    $"Stored procedure '{spName}' is not permitted. " +
                    "Add it to the whitelist in CommonDL if it is a valid procedure.");
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
        public static int InsertData(string spName, SqlParameter[] paramters)
        {
            ValidateProcedureName(spName);
            int _returValue = 0;
            conn = DBConnect.connect();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(paramters);
                    _returValue = cmd.ExecuteNonQuery();
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
            return _returValue;
        }
        

        public static DataSet GetTemplateQueueData(string spName, SqlParameter[] parameters)
        {
            ValidateProcedureName(spName);
            conn = DBConnect.connect();
            DataSet dsLocal = new DataSet();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600000;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsLocal);
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
            return dsLocal;
        }
        public static DataTable  GetModifyData(string spName, SqlParameter[] parameters)
        {
            ValidateProcedureName(spName);
            conn = DBConnect.connect();
            // DataSet dsLocal = new DataSet();
            DataTable dtLocal = new DataTable(); 
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600000;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtLocal);
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
            return dtLocal;
        }
        public static DataTable GetDatatable(string spName, SqlParameter[] parameters)
        {
            ValidateProcedureName(spName);
            conn = DBConnect.connect();
            // DataSet dsLocal = new DataSet();
            DataTable dtLocal = new DataTable();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600000;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtLocal);
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
            return dtLocal;
        }
    }
}

