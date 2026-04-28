using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SPC_KDL
{
    public partial class frmRemovePartNo : Form
    {
        public frmRemovePartNo()
        {
            InitializeComponent();
        }

        #region VariableDeclaration
        private readonly DataTable dtPartNo = new DataTable();
        private readonly DataTable dtTemplates = new DataTable();
        private bool goForSaveUpdate = false;
        #endregion
        private void frmRemovePartNo_Load(object sender, EventArgs e)
        {
            cmbTemplate.Focus();
            TemplateCombo();
        }
        private void frmRemovePartNo_Activated(object sender, EventArgs e)
        {

        }
        //private void frmRemovePartNo_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    var mdiForm = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
        //    mdiForm.toolStrip.Items[6].BackColor = Color.White;
        //    mdiForm.toolStrip.Items[1].BackColor = Color.SkyBlue;
        //    this.Dispose();
        //    this.Close();
        //}
        private void TemplateCombo()
        {
            dtTemplates.Clear();
            dtTemplates.Merge(GetTemplate());
            cmbTemplate.DataSource = dtTemplates;
            cmbTemplate.DisplayMember = "Name";
            cmbTemplate.ValueMember = "ID";
            cmbTemplate.SelectedIndex = -1;

        }
        private DataTable GetTemplate()
        {
            SqlParameter[] parameters =
               {
                  new SqlParameter{ParameterName="@ActionID",SqlDbType =SqlDbType.Int, Value =  1},
                  new SqlParameter{ParameterName="@StationID",SqlDbType =SqlDbType.Int, Value =  Program.stationID}, 
                  //outParam_1
              };

            //return CommonBL.GetModifyData("sp_getDataToRemovePartInspectionQueue", parameters);
            return CommonBL.GetModifyData(StoredProcedure.GetDataToRemovePartInspectionQueue, parameters);

        }
        private void cmbTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTemplate.Text != "")
            {
                PartNoCombo();
            }
        }
        private void PartNoCombo()
        {
            dtPartNo.Clear();
            dtPartNo.Merge(GetPartNo());
            cmbPartNo.DataSource = dtPartNo;
            cmbPartNo.DisplayMember = "PartNo";
            cmbPartNo.ValueMember = "PartNo";
            cmbPartNo.SelectedIndex = -1;
        }
        private DataTable GetPartNo()
        {
            SqlParameter[] parameters =
               {
                  new SqlParameter{ParameterName="@ActionID",SqlDbType =SqlDbType.Int, Value =  2},
                  new SqlParameter{ParameterName="@TemplateID",SqlDbType =SqlDbType.Int, Value =  cmbTemplate.SelectedValue}, 
                  //outParam_1
              };

            //return CommonBL.GetModifyData("sp_getDataToRemovePartInspectionQueue", parameters);
            return CommonBL.GetModifyData(StoredProcedure.GetDataToRemovePartInspectionQueue, parameters);

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

            if (cmbPartNo.Text == "")
            {
                errorProvider1.SetError(cmbPartNo, "Please select Part No.");
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
        private void btnRemove_Click(object sender, EventArgs e)
        {
            goForSaveUpdate = fnValidate();

            if (goForSaveUpdate)
            {
                //SqlParameter outParam_1 = new SqlParameter();
                //outParam_1.ParameterName = "@ErrorMsg";
                //outParam_1.SqlDbType = SqlDbType.VarChar;
                //outParam_1.Size = 100;
                //outParam_1.Direction = ParameterDirection.Output;
                SqlParameter[] parameters =
               {
                  new SqlParameter{ParameterName = "@Login_id", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int, Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100, Value = cmbPartNo.Text },

              //    outParam_1,

               };

                //CommonBL.InsertData("Sp_RemovePartInQueue", parameters); //spInsert_TracebilityData
                CommonBL.InsertData(StoredProcedure.RemovePartInQueue, parameters);

                //string errMsg = outParam_1.Value.ToString();

                //if (errMsg != "")
                //{
                //    MessageBox.Show(errMsg, "SPC");

                //    txtPartNo.Text = "";
                //    txtPartNo.Select();
                //    txtPartNo.Focus();

                //    txtModelNo.Text = "";

                //    return;
                //}

                var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                mdiform.toolStripStatusLabel.Text = "Part No. - " + cmbPartNo.Text + "  removed successfully ";

                this.Close();
            }
        }

        private void prClearControls()
        {
            cmbTemplate.SelectedIndex = -1;
            cmbPartNo.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            prClearControls();
        }

        private void frmRemovePartNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void frmRemovePartNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.Dispose();
            //  this.Hide();

            var frmInspectionForm = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
            // frmInspectionForm.Refresh(); 
            if (frmInspectionForm != null)
            {
                frmInspectionForm.Close();
            }

            //Aamir - 25/08/22
            var mdiForm = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
            mdiForm.toolStrip.Items[6].BackColor = Color.White;
            //mdiForm.Show(); 
            //mdiForm.lblTimer.Visible = true;

            //for (int i = 5; i >= 0; i--)
            //{
            //    mdiForm.lblTimer.Text = i.ToString() ;
            //    Thread.Sleep(1000);
            //}

            mdiForm.toolStrip.Items[1].BackColor = Color.SkyBlue;

            mdiForm.toolStripStatusLabel.Text = "";

            frmInspection frmInspection = new frmInspection();
            frmInspection.MdiParent = mdiForm;
            frmInspection.Show();

            frmInspection.PopulateChar();
        }
    }
}
