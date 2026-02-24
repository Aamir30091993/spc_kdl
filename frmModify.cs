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
    public partial class frmModify : Form
    {
        public frmModify()
        {
            InitializeComponent();
        }

        #region VariableDeclaration
        public static DataTable dtPartNo = new DataTable();
        public static DataTable dtTemplates = new DataTable();
        public static DataTable dtCharacteristics= new DataTable();
        public static DataTable dtMachines = new DataTable();
        public static DataTable dtReading = new DataTable(); 
        private bool goForSaveUpdate = false;
        #endregion
        private void frmModify_Load(object sender, EventArgs e)
        {
            cmbTemplate.Focus();
            TemplateCombo();
            MachineCombo(); 
        }
        private void frmModify_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {             
                this.Dispose();
                this.Close();
            }
        }
        private void frmModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mdiForm = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
            mdiForm.toolStrip.Items[3].BackColor = Color.White;
            mdiForm.toolStrip.Items[1].BackColor = Color.SkyBlue;
            this.Dispose();
            this.Close();        
        }
        private void frmModify_Activated(object sender, EventArgs e)
        {

        }
        private void TemplateCombo()
        {
            dtTemplates = CommonBL.getCombo(Program.userID, 5, Program.stationID.ToString());
            cmbTemplate.DataSource = dtTemplates;
            cmbTemplate.DisplayMember = "TemplateName";
            cmbTemplate.ValueMember = "ID";

            if (Program.CurrentTemplateID == 0)
            {
                cmbTemplate.SelectedIndex = -1;
            }

            else
            {
                cmbTemplate.SelectedValue = Program.CurrentTemplateID;
            }

        }
        private void MachineCombo()
        {
            dtMachines = CommonBL.getCombo(Program.userID, 7, Program.stationID.ToString());
            cmbMachineNo.DataSource = dtMachines;
            cmbMachineNo.DisplayMember = "MachineNo";
            cmbMachineNo.ValueMember = "ID";

            if (Program.CurrentMachineID == 0)
            {
                cmbMachineNo.SelectedIndex = -1;
            }
            else
            {
                cmbMachineNo.SelectedValue = Program.CurrentMachineID;

                dtPartNo = GetModifyData_PartNo();
                cmbPartNo.DataSource = dtPartNo;
                cmbPartNo.DisplayMember = "PartNo";
                cmbPartNo.SelectedIndex = -1;
            }

        }
        //private void PartNoCombo()
        //{
        //    dtPartNo = GetModifyData_PartNo();
        //    cmbPartNo.DataSource = dtPartNo;
        //    cmbPartNo.DisplayMember = "PartNo";
        //    cmbPartNo.ValueMember = "PartNo";
        //}
        //private void CharacteristicsCombo()
        //{
        //    dtCharacteristics = GetModifyData_Characteristics();
        //    cmbCharacteristics.DataSource = dtCharacteristics;
        //    cmbCharacteristics.DisplayMember = "CharacteristicName";
        //    cmbCharacteristics.ValueMember = "ID";
        //}
        private DataTable GetModifyData_PartNo()
        {
            SqlParameter[] parameters =
               {
                  //new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int,  Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName="@MachineID",SqlDbType=SqlDbType.Int, Value = cmbMachineNo.SelectedValue}, 
                  new SqlParameter{ParameterName="@ActionID",SqlDbType =SqlDbType.Int, Value =  1}, 
                  //outParam_1
              };

            DataTable dt = new DataTable();
            dt = CommonBL.GetModifyData("sp_getDataToModify", parameters);
            return dt;
        }
        private DataTable GetModifyData_Characteristics()
        {
            SqlParameter[] parameters =
               {
                //  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int,  Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName="@MachineID",SqlDbType=SqlDbType.Int, Value = cmbMachineNo.SelectedValue},
                  new SqlParameter{ParameterName="@PartNo",SqlDbType=SqlDbType.VarChar,Size = 100, Value = cmbPartNo.Text},
                  new SqlParameter{ParameterName="@ActionID",SqlDbType =SqlDbType.Int, Value =  2}, 
                  //outParam_1
              };

            DataTable dt = new DataTable();
            dt = CommonBL.GetModifyData("sp_getDataToModify", parameters);
            return dt;
        }
        private DataTable GetModifyData_Reading()
        {
            SqlParameter[] parameters =
               {
                //  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int,  Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName="@MachineID",SqlDbType=SqlDbType.Int, Value = cmbMachineNo.SelectedValue},
                  new SqlParameter{ParameterName="@PartNo",SqlDbType=SqlDbType.VarChar,Size = 100, Value = cmbPartNo.Text},
                  new SqlParameter{ParameterName="@CharacterID",SqlDbType=SqlDbType.Int, Value = cmbCharacteristics.SelectedValue},
                  new SqlParameter{ParameterName="@ActionID",SqlDbType =SqlDbType.Int, Value =  3}, 
                  //outParam_1
              };

            DataTable dt = new DataTable();
            dt = CommonBL.GetModifyData("sp_getDataToModify", parameters);
            return dt;
        }
        private void cmbTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTemplate.Text != "")
            {
                MachineCombo();
            }
        }
        private void cmbMachineNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTemplate.Text == "")
            {
                errorProvider1.SetError(cmbTemplate, "Please select Template");
                cmbTemplate.Focus();
                return;
            }
            else
            {
                if (cmbMachineNo.Text == "")
                {
                    errorProvider1.SetError(cmbMachineNo, "Please select Machine");
                    cmbMachineNo.Focus();
                    return;
                }
                else
                {
                    dtPartNo = GetModifyData_PartNo();
                    cmbPartNo.DataSource = dtPartNo;
                    cmbPartNo.DisplayMember = "PartNo";
                    cmbPartNo.SelectedIndex = -1; 
                   // cmbPartNo.ValueMember = "PartNo";
                }

            }
        }
        private void cmbPartNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTemplate.Text != "" && cmbMachineNo.Text != "" && cmbPartNo.Text != "")
            {
                dtCharacteristics = GetModifyData_Characteristics();
                cmbCharacteristics.DataSource = dtCharacteristics;
                cmbCharacteristics.DisplayMember = "CharacteristicName";
                cmbCharacteristics.ValueMember = "ID";
                cmbCharacteristics.SelectedIndex = -1;
            }

            else
            {
                if (cmbTemplate.Text == "")
                {
                    errorProvider1.SetError(cmbTemplate, "Please select template");
                }
                if (cmbMachineNo.Text == "")
                {
                    errorProvider1.SetError(cmbMachineNo, "Please select Machine");
                }
                if (cmbPartNo.Text == "")
                {
                    errorProvider1.SetError(cmbPartNo, "Please select Part No");
                }
            }

        }
        private void cmbCharacteristics_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTemplate.Text != "" && cmbMachineNo.Text != "" && cmbPartNo.Text != "" && cmbCharacteristics.Text !="")
            {
                //dtCharacteristics = GetModifyData_Characteristics(); //TODO
                //cmbCharacteristics.DataSource = dtCharacteristics;
                //cmbCharacteristics.DisplayMember = "CharacteristicName";
                //cmbCharacteristics.ValueMember = "ID";
                //cmbCharacteristics.SelectedIndex = -1;

                dtReading = GetModifyData_Reading();

                txtReading.Text = dtReading.Rows[0][0].ToString();   
            }

            else
            {
                if (cmbTemplate.Text == "")
                {
                    errorProvider1.SetError(cmbTemplate, "Please select template");
                }
                if (cmbMachineNo.Text == "")
                {
                    errorProvider1.SetError(cmbMachineNo, "Please select Machine");
                }
                if (cmbPartNo.Text == "")
                {
                    errorProvider1.SetError(cmbPartNo, "Please select Part No");
                }
                if (cmbCharacteristics.Text == "")
                {
                    errorProvider1.SetError(cmbCharacteristics, "Please select Characteristics");
                }
            }
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
                  new SqlParameter{ParameterName = "@Login_id", SqlDbType = SqlDbType.Int, Value = Program.userID },
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int, Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName = "@MachineID", SqlDbType = SqlDbType.Int,  Value = cmbMachineNo.SelectedValue},
                  new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100, Value = cmbPartNo.Text},
                  new SqlParameter{ParameterName = "@CharacterID", SqlDbType = SqlDbType.Int, Value = cmbCharacteristics.SelectedValue  },
                  new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal, Value = Convert.ToDecimal(txtReading.Text)},
                  outParam_1,

               };

                CommonBL.InsertData("Sp_UpdateModifyData", parameters);

                //Close();

                string errMsg = outParam_1.Value.ToString();

                if (errMsg != "")
                {
                    MessageBox.Show(errMsg, "SPC");

                    txtReading.Text = "";
                    txtReading.Select();
                    txtReading.Focus();

                  

                    return;
                }

                var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                mdiform.toolStripStatusLabel.Text = " Reading  for Part No. - " + cmbPartNo.Text + " and Characteristics -  " + cmbCharacteristics.Text.ToString() + "  modified successfully ";

                this.Close(); //Added by Aamir - 14/09/2022

            }
        }
        private bool fnValidate()
        {
            errorProvider1.Clear();
            bool ret = true;

            if (cmbTemplate.Text == "")
            {
                errorProvider1.SetError(cmbTemplate, "Please select Template");
                ret = false;
            }

            if (cmbMachineNo.Text == "")
            {
                errorProvider1.SetError(cmbMachineNo, "Please select Machine No");
                ret = false;
            }

            if (cmbPartNo.Text == "")
            {
                errorProvider1.SetError(cmbPartNo, "Please select Part No");
                ret = false;
            }

            if (cmbCharacteristics.Text == "")
            {
                errorProvider1.SetError(cmbCharacteristics, "Please select Charcteristics");
                ret = false;
            }

            if (txtReading.Text == "")
            {
                errorProvider1.SetError(txtReading, "Please enter reading");
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

        private void button1_Click(object sender, EventArgs e)
        {
            prClearControls();
        }
        private void prClearControls()
        {
            cmbTemplate.SelectedIndex = -1;
            cmbMachineNo.SelectedIndex = -1;
            cmbPartNo.SelectedIndex = -1;
            cmbCharacteristics.SelectedIndex = -1;

            txtReading.Text = "";
        }
    }
}
