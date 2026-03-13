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
    public partial class frmEventChar : Form
    {
        public frmEventChar()
        {
            InitializeComponent();
        }

        #region VariableDeclaration
        private readonly DataTable dtEvents = new DataTable();
        private readonly DataTable dtTemplates = new DataTable();
        private readonly DataTable dtCharacteristics = new DataTable();
        private readonly DataTable dtMachines = new DataTable();
        private readonly DataTable dtPallets = new DataTable();
        private readonly DataTable dtShifts = new DataTable();
        private readonly object _lock = new object();
        private bool goForSaveUpdate = false;
        #endregion
        private void frmEventChar_Load(object sender, EventArgs e)
        {
            ShiftCombo(); 
            cmbTemplate.Focus();
            TemplateCombo();
        }
        private void frmEventChar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }
        private void frmEventChar_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void frmEventChar_FormClosed(object sender, FormClosedEventArgs e)
        {

            var mdiForm = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
            mdiForm.toolStrip.Items[6].BackColor = Color.White;
            mdiForm.toolStrip.Items[1].BackColor = Color.SkyBlue;

            this.Close();
            this.Dispose();           
        }
        private void TemplateCombo()
        {
            lock (_lock)
            {
                dtTemplates.Clear();
                dtTemplates.Merge(CommonBL.getCombo(Program.userID, 5, Program.stationID.ToString()));  // ✅ refills safely
            }
            //dtTemplates = CommonBL.getCombo(Program.userID, 5, Program.stationID.ToString());
            cmbTemplate.DataSource = dtTemplates;
            cmbTemplate.DisplayMember = "TemplateName";
            cmbTemplate.ValueMember = "ID";
            cmbTemplate.SelectedIndex = -1;

            //if (Program.TemplateID != 0)
            //{
            //    cmbTemplate.SelectedValue = Program.TemplateID;
            //}
            //else
            //{
            //    cmbTemplate.SelectedIndex = -1;
            //}
        }
        private void MachineCombo()
        {
            lock (_lock)
            {
                dtMachines.Clear();
                dtMachines.Merge(CommonBL.getCombo(Program.userID, 7, Program.stationID.ToString()));  // ✅ refills safely
            }
            //dtMachines = CommonBL.getCombo(Program.userID, 7, Program.stationID.ToString());
            cmbMachine.DataSource = dtMachines;
            cmbMachine.DisplayMember = "MachineNo";
            cmbMachine.ValueMember = "ID";
            cmbMachine.SelectedIndex = -1;

            if (Program.MachineID != 0)
            {
                cmbMachine.SelectedValue = Program.MachineID;

            }

            else
            {
                cmbMachine.SelectedIndex = -1;
            }
        }
        private DataTable GetModifyData_Characteristics()
        {
            SqlParameter[] parameters =
               {
                //  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int,  Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName="@MachineID",SqlDbType=SqlDbType.Int, Value = cmbMachine.SelectedValue},
                  new SqlParameter{ParameterName="@ActionID",SqlDbType =SqlDbType.Int, Value =  1}, 
                  //outParam_1
              };

            return CommonBL.GetModifyData("sp_getDataForEvent", parameters);
         
        }
        private void PalletCombo()
        {
            lock (_lock)
            {
                dtPallets.Clear();
                dtPallets.Merge(CommonBL.getCombo(Program.userID, 3, Program.stationID.ToString()));  // ✅ refills safely
            }
            //dtPallets = CommonBL.getCombo(Program.userID, 3, Program.stationID.ToString());
            cmbPallet.DataSource = dtPallets;
            cmbPallet.DisplayMember = "PalletNo";
            cmbPallet.ValueMember = "ID";
            if (Program.Pallet == "")
            {
                cmbPallet.SelectedIndex = -1;
            }
            else
            {
                cmbPallet.Text = Program.Pallet;
            }
        }
        private void EventCombo()
        {
            lock (_lock)
            {
                dtEvents.Clear();
                dtEvents.Merge(CommonBL.getCombo(Program.userID, 2, Program.stationID.ToString()));  // ✅ refills safely
            }
            //dtEvents = CommonBL.getCombo(Program.userID, 2, Program.stationID.ToString());
            cmbEvent.DataSource = dtEvents;
            cmbEvent.DisplayMember = "Name";
            cmbEvent.ValueMember = "ID";
            if (Program.EventID != 0)
            {
                cmbEvent.SelectedValue = Program.EventID;

            }
            else
            {
                cmbEvent.SelectedIndex = -1;
            }
        }
        private void cmbTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTemplate.Text != "")
            {
                MachineCombo();
            }
        }
        private void cmbMachine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbMachine.Text != "")
            {
                lock (_lock)
                {
                    dtCharacteristics.Clear();
                    dtCharacteristics.Merge(GetModifyData_Characteristics());
                }
                //dtCharacteristics = GetModifyData_Characteristics();
                cmbCharacteristics.DataSource = dtCharacteristics;
                cmbCharacteristics.DisplayMember = "CharacteristicName";
                cmbCharacteristics.ValueMember = "ID";
                cmbCharacteristics.SelectedIndex = -1; 
            }
        }
        private void cmbCharacteristics_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PalletCombo();
            EventCombo(); 
        }
        private void prClearControls()
        {
            cmbTemplate.SelectedIndex = -1;
            cmbMachine.SelectedIndex = -1;
            cmbCharacteristics.SelectedIndex = -1;
            cmbPallet.SelectedIndex = -1;
            cmbEvent.SelectedIndex = -1;
            txtOperator.Text = "";      
            txtpart.Text = "";
            txtReading.Text = "";  
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            prClearControls(); 
        }
        private bool fnValidate()
        {
            errorProvider1.Clear();
            bool ret = true;

            if (cmbShift.Text == "")
            {
                errorProvider1.SetError(cmbShift, "Please select Shift");
                ret = false;
            }
            if (cmbTemplate.Text == "")
            {
                errorProvider1.SetError(cmbTemplate, "Please select Template");

                ret = false;
            }
            if (cmbMachine.Text == "")
            {
                errorProvider1.SetError(cmbMachine, "Please select Machine");

                ret = false;
            }
            if (cmbCharacteristics.Text == "")
            {
                errorProvider1.SetError(cmbCharacteristics, "Please select Characteristic");
                ret = false;
            }
            if (cmbPallet.Text == "")
            {
                errorProvider1.SetError(cmbPallet, "Please select Pallet");
                ret = false;
            }
            if (cmbEvent.Text == "")
            {
                errorProvider1.SetError(cmbEvent, "Please select Event");
                ret = false;
            }
            if (txtOperator.Text == "")
            {
                errorProvider1.SetError(txtOperator, "Please enter Operator");
                ret = false;
            }
            if (txtpart.Text == "")
            {
                errorProvider1.SetError(txtpart, "Please scan/enter Part");
                ret = false;
            }
            if (txtRemark.Text == "")
            {
                errorProvider1.SetError(txtRemark, "Please enter Remark");
                ret = false;
            }
            if (txtReading.Text == "")
            {
                errorProvider1.SetError(txtReading, "Please enter Reading");
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
        private void ShiftCombo()
        {
            lock (_lock)
            {
                dtShifts.Clear();
                dtShifts.Merge(CommonBL.getCombo(Program.userID, 6, Program.stationID.ToString()));  // ✅ refills safely
            }
            //dtShifts = CommonBL.getCombo(Program.userID, 6, Program.stationID.ToString());
            cmbShift.DataSource = dtShifts;
            cmbShift.DisplayMember = "ShiftName";
            cmbShift.ValueMember = "ID";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            goForSaveUpdate = fnValidate();

            if (goForSaveUpdate)
            {
                SqlParameter outParam_1 = new SqlParameter();
                outParam_1.ParameterName = "@ErrorMsg";
                outParam_1.SqlDbType = SqlDbType.VarChar;
                outParam_1.Size = 100;
                outParam_1.Direction = ParameterDirection.Output;
                SqlParameter[] parameters =
             {
                  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                  new SqlParameter{ParameterName = "@ShiftID", SqlDbType = SqlDbType.BigInt, Value = cmbShift.SelectedValue},
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int, Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName = "@MachineID", SqlDbType = SqlDbType.Int,  Value = cmbMachine.SelectedValue},
                  new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int,  Value = cmbCharacteristics.SelectedValue},
                  new SqlParameter{ParameterName = "@Pallete", SqlDbType = SqlDbType.NChar,Size = 20,  Value = cmbPallet.Text },
                  new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = cmbEvent.SelectedValue},
                  new SqlParameter{ParameterName = "@OperatorName", SqlDbType = SqlDbType.VarChar,Size=100, Value = txtOperator.Text },
                  new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100, Value = txtpart.Text },
                  new SqlParameter{ParameterName = "@Remark", SqlDbType = SqlDbType.VarChar,Size = 100, Value = txtRemark.Text },
                  new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.VarChar,Size = 100, Value = txtReading.Text },
                  new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                  outParam_1,

               };

                CommonBL.InsertData("spInsert_EventInspectionData", parameters); //spInsert_TracebilityData
                                                                                 // Close(); //Aamir - 16/09/2022

                string errMsg = outParam_1.Value.ToString();

                if (errMsg != "")
                {
                    MessageBox.Show(errMsg, "SPC");

                    txtpart.Text = "";
                    txtpart.Select();
                    txtpart.Focus();
                    
                    return;
                }

                var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                mdiform.toolStripStatusLabel.Text = " Event for Part No. - " + txtpart.Text + " and Characteristics -  " + cmbCharacteristics.Text  + "  saved successfully ";

                this.Close();

            }
        }
        private void frmEventChar_Activated(object sender, EventArgs e)
        {

        }
    }
}
