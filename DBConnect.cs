using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC_KDL
{
    class DBConnect
    {
        public   static SqlConnection connect()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["SPC_MHEL"].ToString();

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return conn;

        }
    }
}
