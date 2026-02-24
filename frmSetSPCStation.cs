using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPC_KDL
{
    public partial class frmSetSPCStation : Form
    {
      //  DBConnect call = new DBConnect();
        static SqlConnection gcon = new SqlConnection();
        DataTable dt;
        SqlCommand Cmd, Cmd1;
        SqlParameter param, paramErrMsg, param1, paramErrMsg1;
        SqlDataAdapter da, da1;

        public frmSetSPCStation()
        {
            InitializeComponent();
        }
        private void frmSetSPCStation_Load(object sender, EventArgs e)
        {
            getSPCStations(); 
        }
        private void frmSetSPCStation_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Dispose();
            frmLogin.Close();
            this.Dispose();
            this.Close();

            frmLogin frmLogin1 = new frmLogin();
            frmLogin1.Show();
        }
        private void getSPCStations()
        {
            cmbSPCStation.DataSource = fnGetSPCStation();
            cmbSPCStation.DisplayMember = "Name";
            cmbSPCStation.ValueMember = "ID"; 
        }
        public DataTable fnGetSPCStation()
        {
            try
            {
                dt = null;
                gcon = DBConnect.connect();
                if (gcon.State == ConnectionState.Closed)
                    gcon.Open();
                Cmd = new SqlCommand("Sp_GetSPCStation", gcon);
                Cmd.CommandType = CommandType.StoredProcedure;
                param = Cmd.Parameters.Add("@User_ID", SqlDbType.Int);
                param.Value = Program.userID ;
                param = Cmd.Parameters.Add("@mac_address", SqlDbType.VarChar,200 );
                param.Value = Program.mac;
                da = new SqlDataAdapter(Cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.TableName = "Sp_GetSPCStation".Substring(3);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //// Cmd.Dispose();
                // gcon.Close();
                // daModule.Dispose();
            }
            return dt;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gcon = DBConnect.connect();
                if (gcon.State == ConnectionState.Closed)
                    gcon.Open();
                Cmd1 = new SqlCommand("Sp_UpdateSPCStationMAcAddress", gcon);
                Cmd1.CommandType = CommandType.StoredProcedure;
                param1 = Cmd1.Parameters.Add("@User_ID", SqlDbType.Int);
                param1.Value = Program.userID;
                param1 = Cmd1.Parameters.Add("@Station_ID", SqlDbType.Int);
                param1.Value = Convert.ToInt32(cmbSPCStation.SelectedValue );
                param1 = Cmd1.Parameters.Add("@mac_address", SqlDbType.VarChar, 200);
                param1.Value = Program.mac ;
                //paramErrMsg1 = Cmd1.Parameters.Add("@error_msg", SqlDbType.VarChar, 200);
                //paramErrMsg1.Direction = ParameterDirection.Output;

                Cmd1.ExecuteNonQuery();

                //MessageBox.Show("SPC Station Saved Successfully", "SPC Station"); 
                string message = "SPC Station Saved Successfully";
                string title = "SPC Station";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                       this.Close();
                    //this.Hide();

                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();  

                }
                  
        //else {
        //            // Do something  
        //        }

                //string errMsg1 = paramErrMsg1.Value.ToString();
            }

            catch (Exception ex)
            {

            }

            finally
            {

            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Dispose();
            frmLogin.Close();
            this.Dispose();
            this.Close();

            frmLogin frmLogin1 = new frmLogin();
            frmLogin1.Show();  
                
        }

    }
}
