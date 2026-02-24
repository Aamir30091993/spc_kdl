using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SPC_KDL
{
    public partial class MDISPC : Form
    {
        //23/05/23
        static SqlConnection gcon = new SqlConnection();
        DataTable dt;
        SqlCommand Cmd;
        SqlParameter param, paramShiftInfoEnable;
        SqlDataAdapter da;
        //23/05/23

        public event EventHandler ButtonFirstFormClicked;
        public MDISPC()
        {
            InitializeComponent();

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void toolStripButtonScan_Click(object sender, EventArgs e)
        {
            toolStrip.Items[0].BackColor = Color.SkyBlue;

            toolStrip.Items[1].BackColor =  Color.White;
            toolStrip.Items[2].BackColor =  Color.White;
            toolStrip.Items[3].BackColor =  Color.White;
            toolStrip.Items[4].BackColor =  Color.White;
            toolStrip.Items[5].BackColor =  Color.White;
            toolStrip.Items[6].BackColor =  Color.White;
            //toolStrip.Items[7].BackColor = Color.White;

            //Added by Aamir - 03/11/2022
            FormCollection fc = Application.OpenForms; //TODO

            Form activeChild = this.ActiveMdiChild;
           if (activeChild.Name == "frmCharts")
            {
                activeChild.Close();

                //frmInspection frmInspection = new frmInspection();
                //frmInspection.MdiParent = this;
                //frmInspection.Show();
                //frmInspection.PopulateChar();
            }
            else
            {

            }

            //23/05/23
            gcon = DBConnect.connect();
            //DataTable dt2 = new DataTable();
            if (gcon.State == ConnectionState.Closed)
                gcon.Open();
            Cmd = new SqlCommand("spGetShiftInfoEnable", gcon);
            Cmd.CommandType = CommandType.StoredProcedure;
            param = Cmd.Parameters.Add("@StationID", SqlDbType.Int);
            param.Value = Program.stationID;
            paramShiftInfoEnable = Cmd.Parameters.Add("@IsShiftInfoEntered", SqlDbType.Bit);
            paramShiftInfoEnable.Direction = ParameterDirection.Output;
            //Cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            bool IsShiftInfoEntered = Convert.ToBoolean(paramShiftInfoEnable.Value);

            if (ds.Tables[0].Rows.Count > 0)//25/05/23
            {
                if (Convert.ToBoolean(IsShiftInfoEntered == false)) // 0
                {
                    frmShiftInfo frmShiftInfo = new frmShiftInfo();
                    
                    if (ds.Tables[0].Rows[2]["ScreenType"].ToString() == "S         ")
                    {
                        frmShiftInfo.cmbShift.Enabled = true;
                        frmShiftInfo.txtOperatorName.Enabled = true;
                        frmShiftInfo.txtTokenNo.Enabled = true;
                        frmShiftInfo.dateTimePicker1.Enabled = true;
                    }

                    //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)//26/05/23
                    //{
                    //    if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblShift")
                    //    {
                    //        frmShiftInfo.cmbShift.Enabled = true;
                    //    }
                    //    if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblOperatorName")
                    //    {
                    //        frmShiftInfo.txtOperatorName.Enabled = true;
                    //    }
                    //    if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblTokenNo")
                    //    {
                    //        frmShiftInfo.txtTokenNo.Enabled = true;
                    //    }
                    //    if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblDate")
                    //    {
                    //        frmShiftInfo.dateTimePicker1.Enabled = true;
                    //    }
                    //}
                        frmShiftInfo.ShowDialog();
                }
                else
                {
                    //23/05/23
                    frmScanPartNo frmScanPartNo = new frmScanPartNo();  //old working
                    frmScanPartNo.ShiftCombo();
                    frmScanPartNo.CastingSupplierCombo();
                    frmScanPartNo.SemiFinishSupplierCombo();
                    frmScanPartNo.cmbCastingSupplierwise.SelectedIndex = -1;
                    frmScanPartNo.cmbSemifinishSupplierwise.SelectedIndex = -1;

                    frmShiftInfo frm = new frmShiftInfo();

                    if (ds.Tables[1].Rows[0]["ScreenType"].ToString() == "T         ")
                    {
                        frmScanPartNo.cmbDotSpec.Enabled = false;
                        frmScanPartNo.cmbTemplate.Enabled = false;
                        frmScanPartNo.cmbShift.Enabled = false;
                    }
                    if (ds.Tables[1].Rows[2]["ScreenType"].ToString() == "T         ")
                    {
                        frmScanPartNo.cmbShift.Enabled = true;
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["ShiftName"].ToString() != "")
                        {
                            frmScanPartNo.cmbShift.SelectedValue = ds.Tables[0].Rows[0]["shiftID"].ToString();
                            frmScanPartNo.cmbShift.Enabled = false;
                        }
                    }
                    if (ds.Tables[1].Rows[3]["ScreenType"].ToString() == "T         ")
                    {
                        frmScanPartNo.txtOperatorName.Enabled = true;
                    }
                    else
                    {
                        if (ds.Tables[0].Rows[0]["Operator"].ToString() != "")
                        {
                            frmScanPartNo.txtOperatorName.Text = ds.Tables[0].Rows[0]["Operator"].ToString();
                            frmScanPartNo.txtOperatorName.Enabled = false;
                        }
                    }
                    if (ds.Tables[1].Rows[0]["ScreenType"].ToString() == "T         ")//Rows[4]
                    {
                        frmScanPartNo.cmbMachineNo.Enabled = false;
                        frmScanPartNo.cmbPalletNo.Enabled = false;
                        frmScanPartNo.txtPartNo.Enabled = false;
                        frmScanPartNo.txtModelNo.Enabled = false;
                        frmScanPartNo.txtModelSAPNo.Enabled = false;
                        frmScanPartNo.cmbCastingSupplierwise.Enabled = false;
                        frmScanPartNo.cmbSemifinishSupplierwise.Enabled = false;
                    }


                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)//26/05/23
                    {
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblDotSpec")
                        {
                            frmScanPartNo.cmbDotSpec.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblTemplate")
                        {
                            frmScanPartNo.cmbTemplate.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblMachineNo")
                        {
                            frmScanPartNo.cmbMachineNo.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblPalletNo")
                        {
                            frmScanPartNo.cmbPalletNo.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == " lblPartNo")
                        {
                            frmScanPartNo.txtPartNo.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == " lblModelNo")
                        {
                            frmScanPartNo.txtModelNo.Enabled = true;
                        }
                        
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblModelSAPNo")
                        {
                            frmScanPartNo.txtModelSAPNo.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblCastingSupplierwise  ")
                        {
                            frmScanPartNo.cmbCastingSupplierwise.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblSemifinishSupplierwise  ")
                        {
                            frmScanPartNo.cmbSemifinishSupplierwise.Enabled = true;
                        }

                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblShift")
                        {
                            frm.cmbShift.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblOperatorName")
                        {
                            frm.txtOperatorName.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblTokenNo")
                        {
                            frm.txtTokenNo.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[i]["Label"].ToString() == "lblDate")
                        {
                            frm.dateTimePicker1.Enabled = true;
                        }
                    }

                    frmScanPartNo.ShowDialog();  //old working
                }//23/05/23
            }
            
           
            //

            //

            //    frmScanPartNo frmScanPartNo = new frmScanPartNo();  //old working
            //    frmScanPartNo.ShowDialog();  //old working

        }

        private void toolStripButtonInspection_Click(object sender, EventArgs e) //TODO - Aamir 11/09/2022
        {
            //this.Hide(); 

            toolStrip.Items[1].BackColor = Color.SkyBlue;

            toolStrip.Items[0].BackColor =  Color.White;
            toolStrip.Items[2].BackColor =  Color.White;
            toolStrip.Items[3].BackColor =  Color.White;
            toolStrip.Items[4].BackColor =  Color.White;
            toolStrip.Items[5].BackColor =  Color.White;
            toolStrip.Items[6].BackColor =  Color.White;
           // toolStrip.Items[7].BackColor = Color.White;

            FormCollection fc = Application.OpenForms; //TODO

            Form activeChild = this.ActiveMdiChild; 

            if (activeChild == null)
            {
                frmInspection frmInspection = new frmInspection();
                frmInspection.MdiParent = this;
                frmInspection.Show();
            }


            else if (activeChild.Name  != "frmInspection")
            {
                activeChild.Close();  

                frmInspection frmInspection = new frmInspection();
                frmInspection.MdiParent = this;
                frmInspection.Show();
                frmInspection.PopulateChar();
            }
            else
            {

            }
        }

        //private void toolStripButtonRetake_Click(object sender, EventArgs e)
        //{
        //    frmRetake frmRetake = new frmRetake();
        //    frmRetake.ShowDialog();  
        //}

        private void toolStripButtonModify_Click(object sender, EventArgs e)
        {
            toolStrip.Items[3].BackColor = Color.SkyBlue;

            toolStrip.Items[1].BackColor =  Color.White;
            toolStrip.Items[2].BackColor =  Color.White;
            toolStrip.Items[0].BackColor =  Color.White;
            toolStrip.Items[4].BackColor =  Color.White;
            toolStrip.Items[5].BackColor =  Color.White;
            toolStrip.Items[6].BackColor =  Color.White;
          //  toolStrip.Items[7].BackColor = Color.White;

            frmModify frmModify = new frmModify();
            frmModify.ShowDialog(); 
        }

        private void toolStripButtonCharts_Click(object sender, EventArgs e)
        {
            toolStrip.Items[6].BackColor = Color.SkyBlue;

            toolStrip.Items[1].BackColor =  Color.White;
            toolStrip.Items[2].BackColor =  Color.White;
            toolStrip.Items[3].BackColor =  Color.White;
            toolStrip.Items[0].BackColor =  Color.White;
            toolStrip.Items[5].BackColor =  Color.White;
        //    toolStrip.Items[6].BackColor =  Color.White;
          //  toolStrip.Items[7].BackColor = Color.White;

            Form activeChild = this.ActiveMdiChild;
            if (activeChild.Name != "frmCharts")
            {
                activeChild.Close();

                frmCharts frmCharts = new frmCharts();
                frmCharts.MdiParent = this;
                frmCharts.Show();
            }
        }

        //private void toolStripButtonKeyboard_Click(object sender, EventArgs e)
        //{
        //    frmKeyboard frmKeyboard = new frmKeyboard();
        //    frmKeyboard.ShowDialog();
        //}

        private void MDISPC_Load(object sender, EventArgs e)
        {
            toolStrip.Items[1].BackColor = Color.SkyBlue;

            frmInspection frmInspection = new frmInspection();
            frmInspection.MdiParent = this;  
            frmInspection.Show();

            //frmInspection.PopulateChar(); //comment on 29/06/23
            
        }

        private void MDISPC_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close(); 
        }

        private void MDISPC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are You sure You Want To LogOut ?", "LogOut SPC ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.Dispose();
                frmLogin.Close();  
                this.Dispose();
                this.Close();

                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void currentCharacteristicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmInspection frmInspection = new frmInspection();
            //frmInspection.Retake();  

           var frmInspectionForm = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
            frmInspectionForm.Retake(1);   

        }

        private void allCharacteristicsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var frmInspectionForm = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
            frmInspectionForm.Retake(0);
        }

        private void toolStripButtonEvent_Click(object sender, EventArgs e)
        {
            toolStrip.Items[4].BackColor = Color.SkyBlue;

            toolStrip.Items[1].BackColor = Color.White;
            toolStrip.Items[2].BackColor =  Color.White;
            toolStrip.Items[3].BackColor =  Color.White;
            toolStrip.Items[5].BackColor =  Color.White;
            toolStrip.Items[6].BackColor =  Color.White;
            toolStrip.Items[0].BackColor =  Color.White;
           // toolStrip.Items[7].BackColor = Color.White;

            frmEventChar frmEventChar = new frmEventChar();
            frmEventChar.ShowDialog();
        }

        private void toolStripButtonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure You Want To Logout ?", "Logout SPC ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.Dispose();
                frmLogin.Close();
                this.Dispose();
                this.Close();

                Application.Exit();
            }
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void toolStripSplitButtonRetake_ButtonClick(object sender, EventArgs e)
        {
            toolStrip.Items[2].BackColor = Color.SkyBlue;

            toolStrip.Items[1].BackColor =  Color.White;
            toolStrip.Items[0].BackColor =  Color.White;
            toolStrip.Items[3].BackColor =  Color.White;
            toolStrip.Items[4].BackColor =  Color.White;
            toolStrip.Items[5].BackColor =  Color.White;
            toolStrip.Items[6].BackColor =  Color.White;
            toolStrip.Items[7].BackColor = Color.White;
        }

        private void lblLastSyncDateHdr_Click(object sender, EventArgs e)
        {

        }

        private void MDISPC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) // Scan
            {
                toolStripButtonScan.PerformClick();  
            }
            if (e.KeyCode == Keys.F2) //Inspection
            {
                toolStripButtonInspection.PerformClick();   
            }
            if (e.KeyCode == Keys.F3) //Retake //TODO
            {
                toolStripSplitButtonRetake.PerformClick();  
            }
            if (e.KeyCode == Keys.F4) //Modify
            {
                toolStripButtonModify.PerformClick(); 
            }
            if (e.KeyCode == Keys.F5) //Event
            {
                toolStripButtonEvent.PerformClick();   
            }
            //if (e.KeyCode == Keys.F6) //Charts
            //{
            //    toolStripButtonCharts.PerformClick(); 
            //}
            if (e.KeyCode == Keys.F7) //Logout
            {
                toolStripButtonLogOut.PerformClick();
            }
            if (e.KeyCode == Keys.F6) //REmove Part No - Aamir - 21/09/22
            {
                toolStripButtonRemovePartNo.PerformClick();
            }

            //Added by Aamir - 09/03/2024
            if (e.KeyCode == Keys.F9) //Charts
            {
                toolStripButtonCharts.PerformClick();
            }
            //Added by Aamir - 09/03/2024

        }

        private void toolStripButtonRemovePartNo_Click(object sender, EventArgs e)
        {
            //   toolStrip.Items[7].BackColor = Color.SkyBlue;
            toolStrip.Items[6].BackColor = Color.SkyBlue;

            toolStrip.Items[1].BackColor = Color.White;
            toolStrip.Items[2].BackColor = Color.White;
            toolStrip.Items[3].BackColor = Color.White;
            toolStrip.Items[4].BackColor = Color.White;
            toolStrip.Items[5].BackColor = Color.White;
            toolStrip.Items[0].BackColor = Color.White;
          

            frmRemovePartNo frmRemovePartNo = new frmRemovePartNo();
            frmRemovePartNo.ShowDialog();
        }
    }
}
