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
        SqlConnection gcon = new SqlConnection();
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
                using (var con = DBConnect.connect())
                {
                    con.Open();
                    using (var cmd = new SqlCommand("Sp_GetSPCStation", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@User_ID", SqlDbType.Int).Value = Program.userID;
                        cmd.Parameters.Add("@mac_address", SqlDbType.VarChar, 200).Value = Program.mac;

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = DBConnect.connect())
                {
                    con.Open();
                    using (var cmd = new SqlCommand("Sp_UpdateSPCStationMAcAddress", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@User_ID", SqlDbType.Int).Value = Program.userID;
                        cmd.Parameters.Add("@Station_ID", SqlDbType.Int).Value = Convert.ToInt32(cmbSPCStation.SelectedValue);
                        cmd.Parameters.Add("@mac_address", SqlDbType.VarChar, 200).Value = Program.mac;
                        cmd.ExecuteNonQuery();
                    }
                }

                var result = MessageBox.Show("SPC Station Saved Successfully", "SPC Station",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.Close();
                    new frmLogin().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
