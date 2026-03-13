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
    public partial class frmShiftInfo : Form
    {
        //  DBConnect call = new DBConnect();
        SqlConnection gcon = new SqlConnection();
        DataTable dt;
        SqlCommand Cmd;
        SqlParameter param;
        SqlDataAdapter da;

        private readonly DataTable dtShifts = new DataTable();
        private readonly DataTable dtMachines = new DataTable();
        public frmShiftInfo()
        {
            InitializeComponent();
        }

        private void prClearControls()
        {
            dateTimePicker1.Value = DateTime.Today;
            cmbShift.SelectedIndex = -1;
            txtOperatorName.Text = "";
            txtTokenNo.Text = "";
            
            //cmbMachineNo.SelectedIndex = -1;
        }
        private void txtOperatorName_TextChanged(object sender, EventArgs e)
        {
            if (txtOperatorName.Text != "")
            {
                Program.Operator = txtOperatorName.Text;
            }
        }

        //private void cmbMachineNo_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    if (cmbMachineNo.Text != "")
        //    {
        //        Program.MachineID = Convert.ToInt32(cmbMachineNo.SelectedValue);
        //    }
        //}

        private void ShiftCombo()
        {
            dtShifts.Clear();
            dtShifts.Merge(CommonBL.getCombo(Program.userID, 6, Program.stationID.ToString())); cmbShift.DataSource = dtShifts;
            cmbShift.DisplayMember = "ShiftName";
            cmbShift.ValueMember = "ID";
        }

        //private void MachineCombo()
        //{
        //    dtMachines = CommonBL.getCombo(Program.userID, 7, Program.stationID.ToString());
        //    cmbMachineNo.DataSource = dtMachines;
        //    cmbMachineNo.DisplayMember = "MachineNo";
        //    cmbMachineNo.ValueMember = "ID";
        //    if (Program.MachineID != 0)
        //    {
        //        cmbMachineNo.SelectedValue = Program.MachineID;

        //    }

        //    else
        //    {
        //        cmbMachineNo.SelectedIndex = -1;
        //    }
        //}

        public bool fnvalidate()
        {
            errorProvider1.Clear();
            bool ret = true;

            if (cmbShift.SelectedValue == null)
            {
                errorProvider1.SetError(cmbShift, "Please select Shift");
                ret = false;
            }
            if (txtOperatorName.Text == "")
            {
                errorProvider1.SetError(txtOperatorName, "Please Enter Operator Name");
                ret = false;
            }
            if (txtTokenNo.Text == "")
            {
                errorProvider1.SetError(txtTokenNo, "Please Enter Token No");
                ret = false;
            }
            if (ret)
            {
                return ret;
            }
            else
            {
                return false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //25/05/23
            
            if (fnvalidate() == true)
            {
                gcon = DBConnect.connect();
                if (gcon.State == ConnectionState.Closed)
                    gcon.Open();
                Cmd = new SqlCommand("spInsertShiftInfo", gcon);
                Cmd.CommandType = CommandType.StoredProcedure;
                param = Cmd.Parameters.Add("@StationID", SqlDbType.Int);
                param.Value = Program.stationID;
                param = Cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
                param.Value = cmbShift.SelectedValue;
                param = Cmd.Parameters.Add("@Operator", SqlDbType.VarChar, 100);
                param.Value = txtOperatorName.Text;
                param = Cmd.Parameters.Add("@TokenNo", SqlDbType.VarChar, 100);
                param.Value = txtTokenNo.Text;
                Cmd.ExecuteNonQuery();
                gcon.Close();
                this.Close();
                MessageBox.Show("Record Saved Successfully");

                //var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                //mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                //mdiform.toolStripStatusLabel.Text = "Record saved successfully ";
            }
            //25/05/23
        }

        private void frmShiftInfo_Load(object sender, EventArgs e)
        {
            ShiftCombo(); 
            
            //MachineCombo();
        }

        private void frmShiftInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            prClearControls();
        }
    }
}
