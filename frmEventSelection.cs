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
    public partial class frmEventSelection : Form
    {
        public int EventID { get; set; }
        public frmEventSelection()
        {
            InitializeComponent();
        }

        #region VariableDeclaration
        public static DataTable dtEventsSelection = new DataTable();
        public static DataTable dtEventsMessage = new DataTable();
        #endregion

        #region FormEvents
        private void frmEventSelection_Load(object sender, EventArgs e)
        {
            EventSelectionCombo();
        }
        //private void frmEventSelection_FormClosed(object sender, FormClosedEventArgs e)
        //{

        //}

        #endregion

        #region Click Events
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbEvent.Text != "")
            {
                EventID = Convert.ToInt32(cmbEvent.SelectedValue);
            }
            else
            {
                errorProvider1.SetError(cmbEvent, "Please select the event");
                cmbEvent.Focus();
                //  MessageBox.Show("Please select event", "Event Selection");
                return; 
            }
        }
        private void btnRetake_Click(object sender, EventArgs e)
        {
            Close();
            //var frmInspectionForm = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
            //frmInspectionForm.Retake(1);
        }
        #endregion

        #region Functions
        private void EventSelectionCombo()
        {
            dtEventsSelection = CommonBL.getCombo(Program.userID, 2, Program.stationID.ToString());
            cmbEvent.DataSource = dtEventsSelection;
            cmbEvent.DisplayMember = "Name";
            cmbEvent.ValueMember = "ID";
            cmbEvent.SelectedIndex = -1; //TODO
        }
        #endregion
        private void cmbEvent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEvent.Text != "")
            {
                dtEventsMessage = GetEventMessage();
                lblMessageEvent.Text = dtEventsMessage.Rows[0][0].ToString();
            }
        }
        private DataTable GetEventMessage()
        {
            SqlParameter[] parameters =
               {
                //  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int,  Value = cmbEvent.SelectedValue},
                  //outParam_1
              };

            DataTable dt = new DataTable();
            dt = CommonBL.GetModifyData("sp_GetEventMsg", parameters);
            return dt;
        }

        private void frmEventSelection_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Dispose();
                this.Close();
            }

            else
            {
                string s = this.ActiveControl.Text;
                if ((s == "OK" || s == "") && cmbEvent.SelectedItem == null)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.Dispose();
                    this.Close();
                }
            }

           
        }

        private void frmEventSelection_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void cmbEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbEvent != null)
            {
                if (cmbEvent.SelectedItem != null)
                {
                    if (cmbEvent.SelectedItem.ToString() != "")
                    {
                        //btnOKAttribute.DialogResult = DialogResult.OK;
                        // btnOKAttribute_Click("OK", e);
                        if (e.KeyCode == Keys.Enter)
                        {
                            btnOK.PerformClick();
                        }
                    }
                }
            }
        }
    }
}
