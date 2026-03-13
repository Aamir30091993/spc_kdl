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
using System.Net.NetworkInformation;

namespace SPC_KDL
{
    public partial class frmLogin : Form
    {
      //  DBConnect call = new DBConnect();
        SqlConnection gcon = new SqlConnection();
        DataTable dt;
        SqlCommand  Cmd, Cmd1;
        SqlParameter param, paramErrMsg, param1, paramErrMsg1, paramStationID ;
        SqlDataAdapter da, da1;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPassword != null)
            {
                if (txtPassword.Text != null)
                {
                    if (txtPassword.Text != "")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            btnLogin.PerformClick();
                        }
                    }
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           //FormCollection fc = Application.OpenForms;  

            this.Dispose();
            this.Close();

            Application.Exit();  
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            checklogin(); 
        }
        private void txtUsername_Leave(object sender, EventArgs e)
        {
             if (txtUsername.Text != "" )
            {
                errorProvider1.Clear();  
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                errorProvider1.Clear();
            }
        }
        private void checklogin()
        {

            if (txtUsername.Text == "")
            {
                //MessageBox.Show("Please Enter Username", "SPC");
                errorProvider1.SetError(txtUsername, "Please enter Username");  
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                //MessageBox.Show("Please Enter Password", "SPC");
                errorProvider1.SetError(txtPassword, "Please enter Password");
                txtPassword.Focus();
                return;
            }

            try
            {
                //Validate SPC User

                dt = null;
                gcon = DBConnect.connect();
                if (gcon.State == ConnectionState.Closed)
                    gcon.Open();
                Cmd = new SqlCommand("validate_user", gcon);
                Cmd.CommandType = CommandType.StoredProcedure;
                param = Cmd.Parameters.Add("@username", SqlDbType.VarChar, 100);
                param.Value = txtUsername.Text;
                param = Cmd.Parameters.Add("@password", SqlDbType.VarChar, 100);
                param.Value = txtPassword.Text;
                paramErrMsg = Cmd.Parameters.Add("@error_msg", SqlDbType.VarChar, 200);
                paramErrMsg.Direction = ParameterDirection.Output;
                da = new SqlDataAdapter(Cmd);
                dt = new DataTable();
                da.Fill(dt);

                string errMsg = paramErrMsg.Value.ToString();

                if (dt.Rows.Count > 0)
                {
                    Program.userID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    Program.name = dt.Rows[0]["Name"].ToString();
                    Program.username = dt.Rows[0]["UserName"].ToString();
                    Program.roleID = Convert.ToInt32(dt.Rows[0]["RoleId"].ToString());
                }

                else
                {
                    lblErrMsg.Text = errMsg;
                    return;
                }

                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                string sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (adapter.Name.Contains("Ethernet") && adapter.OperationalStatus.ToString() == "Up") //adapter.Name == "Ethernet"
                    {
                        if (sMacAddress == string.Empty)// only return MAC Address from first card  
                        {
                            IPInterfaceProperties properties = adapter.GetIPProperties();
                            sMacAddress = adapter.GetPhysicalAddress().ToString();
                        }
                    }
                }
                string MAC = sMacAddress;
                Program.mac = MAC;

                string errMsg1 = "";
                if (Program.roleID != 1)//27/05/23
                { 
                    if (Program.roleID == 3 || Program.roleID == 2)  //3=Operator  //2=Supervisior add on 30/05/23
                    {

                        //Validate SPC Station
                        gcon = DBConnect.connect();
                        if (gcon.State == ConnectionState.Closed)
                            gcon.Open();
                        Cmd1 = new SqlCommand("Validate_Station", gcon);
                        Cmd1.CommandType = CommandType.StoredProcedure;
                        param1 = Cmd1.Parameters.Add("@mac_address", SqlDbType.VarChar, 200);
                        param1.Value = MAC;

                        paramErrMsg1 = Cmd1.Parameters.Add("@error_msg", SqlDbType.VarChar, 200);
                        paramErrMsg1.Direction = ParameterDirection.Output;

                        paramStationID = Cmd1.Parameters.Add("@station_id", SqlDbType.Int);
                        paramStationID.Direction = ParameterDirection.Output;

                        Cmd1.ExecuteNonQuery();

                        errMsg1 = paramErrMsg1.Value.ToString();



                        if (errMsg1 != "")
                        {
                            lblErrMsg.Text = errMsg1;
                            return;
                        }
                        else
                        {
                            Program.stationID = Convert.ToInt32(paramStationID.Value.ToString());
                        }

                        //22/05/23
                        DataTable dt1 = new DataTable();
                        gcon = DBConnect.connect();
                        if (gcon.State == ConnectionState.Closed)
                            gcon.Open();
                        Cmd = new SqlCommand("spGetWindowsUserAccess", gcon);
                        Cmd.CommandType = CommandType.StoredProcedure;
                        param = Cmd.Parameters.Add("@UserID", SqlDbType.Int);
                        param.Value = Program.userID;
                        da = new SqlDataAdapter(Cmd);
                        da.Fill(dt1);
                        //22/05/23


                        //23/05/23
                        MDISPC MDISPC1 = new MDISPC();
                        if (dt1.Rows[0]["ModuleName"].ToString() == "ScanPartNo" && Convert.ToBoolean(dt1.Rows[0]["FullControl"].ToString()) == true)
                        {
                            MDISPC1.toolStripButtonScan.Enabled = true;
                        }
                        else
                        {
                            MDISPC1.toolStripButtonScan.Enabled = false;
                        }

                        if (dt1.Rows[1]["ModuleName"].ToString() == "Inspection" && Convert.ToBoolean(dt1.Rows[1]["FullControl"].ToString()) == true)
                        {
                            MDISPC1.toolStripButtonInspection.Enabled = true;
                        }
                        else
                        {
                            MDISPC1.toolStripButtonInspection.Enabled = false;
                        }

                        if (dt1.Rows[2]["ModuleName"].ToString() == "Retake" && Convert.ToBoolean(dt1.Rows[2]["FullControl"].ToString()) == true)
                        {
                            MDISPC1.toolStripSplitButtonRetake.Enabled = true;
                        }
                        else
                        {
                            MDISPC1.toolStripSplitButtonRetake.Enabled = false;
                        }

                        if (dt1.Rows[3]["ModuleName"].ToString() == "Modify" && Convert.ToBoolean(dt1.Rows[3]["FullControl"].ToString()) == true)
                        {
                            if (Program.roleID == 2) //30/05/23
                            {
                                MDISPC1.toolStripButtonModify.Enabled = true;
                            }
                        }
                        else
                        {
                            MDISPC1.toolStripButtonModify.Enabled = false;
                        }

                        if (dt1.Rows[4]["ModuleName"].ToString() == "Charts" && Convert.ToBoolean(dt1.Rows[4]["FullControl"].ToString()) == true)
                        {
                            MDISPC1.toolStripButtonCharts.Enabled = true;
                        }
                        else
                        {
                            MDISPC1.toolStripButtonCharts.Enabled = false;
                        }
                        if (Program.roleID == 2)//30/05/23
                        {
                            MDISPC1.toolStripButtonModify.Enabled = true;
                        }
                        MDISPC1.Show();
                        //23/05/23
                    }
            }//27/05/23

                else //for other roles
                {
                   // string errMsg1 = paramErrMsg1.Value.ToString();



                    if (errMsg1 != "")
                    {
                        lblErrMsg.Text = errMsg1;
                        return;
                    }

                    else
                    {

                        this.Hide(); //TODO
                        frmSetSPCStation frmSetSPCStation = new frmSetSPCStation();
                        frmSetSPCStation.Show();

                        //this.Dispose(); 
                        //  this.Close();  
                        return;
                    }
                }

                

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            //TODO
             this.Hide();
            //MDISPC MDISPC = new MDISPC(); //commented on 23/05/23
            //MDISPC.Show(); //commented on 23/05/23

            //mDIForm.toolStripStatusLoginName.Text = Username;
            // this.Close(); 


            //Added 110519 - User Access Page
            //if (UserTypeID == 3)
            //{
            //    mDIForm.mnMasters.Enabled = false;
            //    mDIForm.mnUser.Enabled = false;


            //    frmTrainingSession frmTrainingSession = new frmTrainingSession();
            //    frmTrainingSession.MdiParent = mDIForm;
            //    frmTrainingSession.Show();

            //}

            //else if (UserTypeID == 1)
            //{
            //    mDIForm.mnTrainingSession.Enabled = false;
            //}

            //else if (UserTypeID == 2)
            //{
            //    mDIForm.mnTrainingSession.Enabled = false;
            //    mDIForm.mnTrainers.Enabled = false;
            //    mDIForm.mnHRDevices.Enabled = false;
            //    mDIForm.mnRPMDevices.Enabled = false;
            //    mDIForm.mnTrainingTimeSlot.Enabled = false;
            //    mDIForm.mnUser.Enabled = false;
            //}

            //else
            //{
            //    mDIForm.mnMasters.Enabled = false;
            //    mDIForm.mnSecurity.Enabled = false;
            //    mDIForm.mnTrainingSession.Enabled = false;
            //}

            //Added 110519 - User Access Page
            //}
            //else
            //{
            //    MessageBox.Show("Not a Valid User", "SPC");
            //    txtusername.Text = "";
            //    txtpassword.Text = "";
            //    txtusername.Focus();
            //}
        }


    }
}
