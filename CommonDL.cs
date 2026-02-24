using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPC_KDL
{
    class CommonDL
    {
        DBConnect call = new DBConnect();
        static SqlConnection conn = new SqlConnection();
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

