using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Drawing;

namespace SPC_KDL
{
    public partial class frmScanPartNo : Form
    {
        public frmScanPartNo()
        {
            InitializeComponent();
        }

        #region VariableDeclaration

        public static DataTable dtTemplates = new DataTable();
        public static DataTable dtEvents = new DataTable();
        public static DataTable dtShifts = new DataTable();
        public static DataTable dtMachines = new DataTable();
        public static DataTable dtPallets = new DataTable();

        //26/05/23
        public static DataTable dtCastingSupplier = new DataTable();
        public static DataTable dtSemiFinishSupplier = new DataTable();
        //26/05/23

        public static DataTable dtConfig = new DataTable();
        public static DataTable dtDotCombo = new DataTable();
        public static DataTable dtDotComboAll = new DataTable();
        int machineWisePalletWise = 0;
        int templateWiseModelWise = 0;

        private bool goForSaveUpdate = false;

        string partNo = "";
        string extractedPartNo = "";
        string extractedModelNo = "";
        #endregion
        private void frmScanPartNo_Load(object sender, EventArgs e)
        {
            //Aamir - 18/01/2023 - Check Config
           dtConfig = CheckConfig();

            machineWisePalletWise = Convert.ToInt32(dtConfig.Rows[0][0].ToString());
            templateWiseModelWise = Convert.ToInt32(dtConfig.Rows[0][1].ToString());


            //CASE - 4 - (Current Working)

            if (machineWisePalletWise == 0 && templateWiseModelWise == 0)
            {
                lblDotSpec.Visible = false;
                cmbDotSpec.Visible = false;

                cmbTemplate.Focus();
                //Binding data to all comboBox
                //1. Template
                TemplateCombo();
                //2. Event
                EventCombo();
                //3. Shift
                ShiftCombo();
                //4.Machine
                MachineCombo();
                //5.PalletNo
                PalletCombo();
            }

            //Case - 3 - (machineWisePalletWise = 1,  templateWiseModelWise = 0)

            if (machineWisePalletWise == 1 && templateWiseModelWise == 0)
            {
                lblDotSpec.Visible = true;
                cmbDotSpec.Visible = true;
                cmbDotSpec.Focus();

                DotCombo();

                cmbMachineNo.Enabled = false;
                cmbPalletNo.Enabled = false;
                txtModelNo.ReadOnly = true;

                TemplateCombo();
                ShiftCombo();
            }

            //Case - 2 - (machineWisePalletWise = 0,  templateWiseModelWise = 1)
            if (machineWisePalletWise == 0 && templateWiseModelWise == 1)
            {
                lblDotSpec.Visible = false;
                cmbDotSpec.Visible = false;
                cmbTemplate.Enabled = false;

                cmbMachineNo.Enabled = true;
                cmbMachineNo.Focus();
                cmbPalletNo.Enabled = true;

                txtModelNo.ReadOnly = true;

                //TemplateCombo();
                MachineCombo();
                PalletCombo();
                ShiftCombo();
            }

            //Case - 1 - (machineWisePalletWise = 1,  templateWiseModelWise = 1)
            if (machineWisePalletWise == 1 && templateWiseModelWise == 1)
            {
                //Aamir - 27/01/2023
                //lblDotSpec.Visible = true;
                //cmbDotSpec.Visible = true;


                cmbDotSpec.Enabled = false;

                //cmbDotSpec.Focus(); 
                //DotCombo();
                //Aamir - 27/01/2023

                cmbTemplate.Enabled = false;
                cmbMachineNo.Enabled = false;
                cmbPalletNo.Enabled = false;

                txtModelNo.ReadOnly = true;

                //TemplateCombo();
              //  MachineCombo();
               // PalletCombo();
                ShiftCombo();

                txtPartNo.Select(); 
                txtPartNo.Focus();
            }

            if (Program.Operator != null)
            {
                if (Program.Operator != "")
                {
                    txtOperatorName.Text = Program.Operator;

                    // Aamir - 15/09/22  
                    //txtPartNo.Select(); //Commented by Aamir - 19/01/2023
                    //txtPartNo.Focus();
                    // Aamir - 15/09/22  
                }
            }
        }
        private void frmScanPartNo_Activated(object sender, EventArgs e)
        {

        }
        private void frmScanPartNo_FormClosed(object sender, FormClosedEventArgs e)
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
            mdiForm.toolStrip.Items[0].BackColor = Color.White;
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

            //frmInspection.PopulateChar(); //comment on 29/06/23

        }
        private void frmScanPartNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
                //  this.Hide();

                //var frmInspectionForm = Application.OpenForms.OfType<frmInspection>().FirstOrDefault();
                //frmInspectionForm.Refresh();
            }
        }
        private void TemplateCombo()
        {
            dtTemplates = CommonBL.getCombo(Program.userID, 5, Program.stationID.ToString());
            cmbTemplate.DataSource = dtTemplates;
            cmbTemplate.DisplayMember = "TemplateName";
            cmbTemplate.ValueMember = "ID";

            if (Program.TemplateID != 0)
            {
                cmbTemplate.SelectedValue = Program.TemplateID;  
            }
            else
            {
                cmbTemplate.SelectedIndex = -1;
            }
        }
        private void EventCombo()
        {
            dtEvents= CommonBL.getCombo(Program.userID, 2, Program.stationID.ToString());
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
        public void ShiftCombo()
        {
            dtShifts = CommonBL.getCombo(Program.userID, 6, Program.stationID.ToString());
            cmbShift.DataSource = dtShifts;
            cmbShift.DisplayMember = "ShiftName";
            cmbShift.ValueMember = "ID";
        }
        
        public void CastingSupplierCombo()//26/05/23
        {
            dtCastingSupplier = CommonBL.getCombo(Program.userID, 30, Program.stationID.ToString());
            cmbCastingSupplierwise.DataSource = dtCastingSupplier;
            cmbCastingSupplierwise.DisplayMember = "Name";
            cmbCastingSupplierwise.ValueMember = "ID";
        }
        public void SemiFinishSupplierCombo()//26/05/23
        {
            dtSemiFinishSupplier = CommonBL.getCombo(Program.userID, 31, Program.stationID.ToString());
            cmbSemifinishSupplierwise.DataSource = dtSemiFinishSupplier;
            cmbSemifinishSupplierwise.DisplayMember = "Name";
            cmbSemifinishSupplierwise.ValueMember = "ID";
        }
        
        private void MachineCombo()
        {
            dtMachines = CommonBL.getCombo(Program.userID, 7, Program.stationID.ToString());
            cmbMachineNo.DataSource = dtMachines;
            cmbMachineNo.DisplayMember = "MachineNo";
            cmbMachineNo.ValueMember = "ID";
            if (Program.MachineID != 0)
            {
                cmbMachineNo.SelectedValue = Program.MachineID;
             
            }

            else
            {
                cmbMachineNo.SelectedIndex = -1;
            }
        }
        private void PalletCombo()
        {
            dtPallets = CommonBL.getCombo(Program.userID, 3, Program.stationID.ToString());
            cmbPalletNo.DataSource = dtPallets;
            cmbPalletNo  .DisplayMember = "PalletNo";
            cmbPalletNo.ValueMember = "ID";
            if (Program.Pallet == null)
            {
                cmbPalletNo.SelectedIndex = -1;
            }
            else
            {
                cmbPalletNo.Text = Program.Pallet; 
            }
        }
        #region Functions
        private bool fnValidate() //Modified by Aamir - 12/06/2024
        {
            errorProvider1.Clear();
            bool ret = true;

            if (cmbTemplate.Enabled == true)
            {
                if (cmbTemplate.Text == "")
                {
                    errorProvider1.SetError(cmbTemplate, "Please select Template");
                    ret = false;
                }
            }

            //if (cmbEvent.Text == "")
            //{
            //    errorProvider1.SetError(cmbEvent, "Please select Event");
            //    ret = false;
            //}

            if (cmbShift.Enabled == true)
            {
                if (cmbShift.Text == "")
                {
                    errorProvider1.SetError(cmbShift, "Please select Shift");
                    ret = false;
                }
            }

            if (txtOperatorName.Enabled == true)
            {
                if (txtOperatorName.Text == "")
                {
                    errorProvider1.SetError(txtOperatorName, "Please enter Operator Name");
                    ret = false;
                }
            }

            if (cmbMachineNo.Enabled == true)
            {
                if (cmbMachineNo.Text == "")
                {
                    errorProvider1.SetError(cmbMachineNo, "Please select Machine No");
                    ret = false;
                }
            }

            if (cmbPalletNo.Enabled == true)
            {

                if (cmbPalletNo.Text == "")
                {
                    errorProvider1.SetError(cmbPalletNo, "Please select Pallet No");
                    ret = false;
                }
            }

            if (txtPartNo.Enabled == true)
            {
                if (txtPartNo.Text == "")
                {
                    errorProvider1.SetError(txtPartNo, "Please scan/enter Part No");
                    ret = false;
                }
            }

            if (txtModelNo.Enabled == true)
            {
                if (txtModelNo.Text == "")
                {
                    errorProvider1.SetError(txtModelNo, "Please scan/enter Model No");
                    ret = false;
                }
            }

            //Aamir - 19/01/2023
            if(cmbDotSpec.Visible == true)
            {
                if (cmbDotSpec.Enabled == true)
                {
                    if (cmbDotSpec.Text == "")
                    {
                        errorProvider1.SetError(cmbDotSpec, "Please select Dot Specification");
                        ret = false;
                    }
                }
            }
            //Aamir - 19/01/2023

            if (txtModelSAPNo.Enabled == true)
            {
                if (txtModelSAPNo.Text == "")//26/05/23
                {
                    errorProvider1.SetError(txtModelSAPNo, "Please enter Model SAP No");
                    ret = false;
                }
            }
            //if (cmbCastingSupplierwise.Text == "")//26/05/23
            //{
            //    errorProvider1.SetError(cmbCastingSupplierwise, "Please select Casting Supplier");
            //    ret = false;
            //}

            if (cmbSemifinishSupplierwise.Enabled == true)
            {
                if (cmbSemifinishSupplierwise.Text == "")//26/05/23
                {
                    errorProvider1.SetError(cmbSemifinishSupplierwise, "Please select Semi finish Supplier");
                    ret = false;
                }
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

        private bool fnreValidate() //Modified by Aamir - 12/06/2024
        {
           // errorProvider1.Clear();
            bool ret = true;

            if (cmbTemplate.Enabled == true)
            {
                if (cmbTemplate.Text != "")
                {
                    errorProvider1.SetError(cmbTemplate, "");
                    // ret = false;
                }
            }

            //if (cmbEvent.Text == "")
            //{
            //    errorProvider1.SetError(cmbEvent, "Please select Event");
            //    ret = false;
            //}

            if (cmbShift.Enabled == true)
            {
                if (cmbShift.Text != "")
                {
                    errorProvider1.SetError(cmbShift, "");
                    //ret = false;
                }
            }

            if (txtOperatorName.Enabled == true)
            {
                if (txtOperatorName.Text != "")
                {
                    errorProvider1.SetError(txtOperatorName, "");
                    // ret = false;
                }
            }

            if (cmbMachineNo.Enabled == true)
            {
                if (cmbMachineNo.Text != "")
                {
                    errorProvider1.SetError(cmbMachineNo, "");
                    // ret = false;
                }
            }

            if (cmbPalletNo.Enabled == true)
            {
                if (cmbPalletNo.Text != "")
                {
                    errorProvider1.SetError(cmbPalletNo, "");
                    //  ret = false;
                }
            }

            if (txtPartNo.Enabled == true)
            {
                if (txtPartNo.Text != "")
                {
                    errorProvider1.SetError(txtPartNo, "");
                    //  ret = false;
                }
            }

            if (txtModelNo.Enabled == true)
            {
                if (txtModelNo.Text != "")
                {
                    errorProvider1.SetError(txtModelNo, "");
                    //   ret = false;
                }
            }
            //Aamir - 19/01/2023
            if (cmbDotSpec.Visible == true)
            {
                if (cmbDotSpec.Enabled == true)
                {
                    if (cmbDotSpec.Text != "")
                    {
                        errorProvider1.SetError(cmbDotSpec, "");
                        //ret = false;
                    }
                }
            }
            //Aamir - 19/01/2023
            if (txtModelSAPNo.Enabled == true)
            {
                if (txtModelSAPNo.Text != "")
                {
                    errorProvider1.SetError(txtModelSAPNo, "");
                    // ret = false;
                }
            }

            if (cmbSemifinishSupplierwise.Enabled == true)
            {
                if (cmbSemifinishSupplierwise.Text != "")
                {
                    errorProvider1.SetError(cmbSemifinishSupplierwise, "");
                    // ret = false;
                }
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
        #endregion
        #region Functional Functions
        private void btnSave_Click(object sender, EventArgs e)
        {
            goForSaveUpdate = fnValidate();
            
            if (goForSaveUpdate )
            {
                SqlParameter outParam_1 = new SqlParameter();
                outParam_1.ParameterName = "@ErrorMsg";
                outParam_1.SqlDbType = SqlDbType.VarChar;
                outParam_1.Size = 100;
                outParam_1.Direction = ParameterDirection.Output;

                //Added by Aamir - 28/02/2023
                SqlParameter outParam_2 = new SqlParameter();
                outParam_2.ParameterName = "@HeadFlag";
                outParam_2.SqlDbType = SqlDbType.Int;
                outParam_2.Direction = ParameterDirection.Output;
                //Added by Aamir - 28/02/2023


                SqlParameter[] parameters =
               {
                  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                  new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int, Value = cmbTemplate.SelectedValue},
                  new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = cmbEvent.SelectedValue},
                  new SqlParameter{ParameterName = "@ShiftID", SqlDbType = SqlDbType.Int, Value = cmbShift.SelectedValue}, //cmbShift.SelectedValue TODO
                  new SqlParameter{ParameterName = "@OperatorName", SqlDbType = SqlDbType.VarChar,Size=100, Value = txtOperatorName.Text },
                  new SqlParameter{ParameterName = "@MachineID", SqlDbType = SqlDbType.Int,  Value = cmbMachineNo.SelectedValue},
                  new SqlParameter{ParameterName = "@Pallete", SqlDbType = SqlDbType.NChar,Size = 20,  Value = cmbPalletNo.Text },
                  new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100, Value = txtPartNo.Text },
                  new SqlParameter{ParameterName = "@ModelNo", SqlDbType = SqlDbType.VarChar,Size = 100, Value = txtModelNo.Text },
                  new SqlParameter{ParameterName = "@CastingSupplierID", SqlDbType = SqlDbType.Int, Value = cmbCastingSupplierwise.SelectedValue }, //26/05/23
                  new SqlParameter{ParameterName = "@SemiFinishSupplierID", SqlDbType = SqlDbType.Int, Value = cmbSemifinishSupplierwise.SelectedValue }, //26/05/23
                  new SqlParameter{ParameterName = "@ModelSapNo", SqlDbType = SqlDbType.VarChar,Size = 50, Value = txtModelSAPNo.Text }, //26/05/23
                  outParam_1,
                  outParam_2,           
               };

                CommonBL.InsertData("spInsert_TracebilityData", parameters); //spInsert_TracebilityData

                string errMsg = outParam_1.Value.ToString();   

                if (errMsg != "")
                {
                    MessageBox.Show(errMsg, "SPC");

                    txtPartNo.Text = "";
                    txtPartNo.Select();
                    txtPartNo.Focus();

                    txtModelNo.Text = "";

                    return;
                }

                var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                mdiform.toolStripStatusLabel.Text = "Part No. - " + txtPartNo.Text + "  saved successfully ";

                txtPartNo.Text = "";
                txtPartNo.Select();
                txtPartNo.Focus();

                txtModelNo.Text = "";

                // this.Close(); //Added by Aamir - 14/09/2022 //Commented by Aamir - 13/02/2023

                int HeadFlagVal = Convert.ToInt32(outParam_2.Value.ToString());

                if (HeadFlagVal == 1)
                {
                    //this.Hide();
                    this.Close();
                }

                else
                {
                    this.Hide();
                    mdiform.toolStripButtonScan.PerformClick();
                }
            }
        }
      #endregion
        private void button1_Click(object sender, EventArgs e) //Clear
        {
            prClearControls();
        }
        private void prClearControls()
        {
            cmbTemplate.SelectedIndex = -1;
            cmbEvent.SelectedIndex = -1;
            txtOperatorName.Text = "";
            cmbMachineNo.SelectedIndex = -1;
            cmbPalletNo.SelectedIndex = -1;
            txtPartNo.Text = "";

            txtModelNo.Text = "";

            cmbDotSpec.SelectedIndex = -1;

            txtModelSAPNo.Text = "";//26/05/23
            cmbCastingSupplierwise.SelectedIndex = -1; //26/05/23
            cmbSemifinishSupplierwise.SelectedIndex = -1; //26/05/23
        }
        private void cmbTemplate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTemplate.Text != "" )
            {
                Program.TemplateID = Convert.ToInt32(cmbTemplate.SelectedValue);   
            }
        }
        private void cmbEvent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEvent.Text != "")
            {
                Program.EventID  = Convert.ToInt32(cmbEvent.SelectedValue);
            }
        }
        private void txtOperatorName_TextChanged(object sender, EventArgs e)
        {
            if(txtOperatorName.Text != "" )
            {
                Program.Operator = txtOperatorName.Text;   
            }
        }
        private void cmbMachineNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbMachineNo.Text != "")
            {
                Program.MachineID= Convert.ToInt32(cmbMachineNo.SelectedValue);
            }
        }
        private void cmbPalletNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPalletNo.Text != "")
            {
                Program.Pallet = cmbPalletNo.Text;
            }
        }
        private void txtPartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPartNo != null)
            {
                if (txtPartNo.Text != null)
                {
                    if (txtPartNo.Text != "")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {

                            //Aamir - TODO
                            // string partNo = "409:0302abh00280n:a004:240322:02:08051";

                             partNo = "";
                             extractedPartNo = "";
                             extractedModelNo = "";

                            partNo  = txtPartNo.Text;

                            if (partNo.Contains(':'))
                            {
                               // extractedPartNo = partNo.Split(':')[5];
                                extractedModelNo = partNo.Split(':')[1];

                                txtPartNo.Text = "";
                                txtPartNo.Text = partNo; //extractedPartNo;
                                txtModelNo.Text = extractedModelNo;

                                //Aamir - 19/01/2023
                                 if ((machineWisePalletWise == 0 && templateWiseModelWise == 1) || (machineWisePalletWise == 1 && templateWiseModelWise == 1) ) //Case 2 and Case 1
                                {
                                      SqlParameter[] parameters =
                                      {
                                          new SqlParameter{ParameterName = "@ModelNo", SqlDbType = SqlDbType.VarChar,Size = 50,  Value = extractedModelNo},
                                          new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int,  Value = Program.stationID},
                                          //outParam_1
                                        };

                                    DataTable dt = new DataTable();
                                    dt = CommonBL.GetModifyData("pgetTemplate", parameters);

                                    if (dt.Rows.Count > 0)
                                    {
                                        cmbTemplate.DataSource = dt;
                                        cmbTemplate.DisplayMember = "Name";
                                        cmbTemplate.ValueMember = "ID";
                                    }


                                }
                                //Aamir - 19/01/2023

                                // Thread.Sleep(3000); //TODO

                                if (machineWisePalletWise == 1 && templateWiseModelWise == 1)
                                {
                                   
                                    cmbDotSpec.Enabled = true;
                                    DotCombo();
                                    cmbDotSpec.Focus();
                                }

                                else
                                {
                                    btnSave.PerformClick();
                                }
                            }

                            fnreValidate();
                           // btnSave.PerformClick();
                        }
                    }
                }
            }
        }

        //Aamir - 18/01/2023
        private DataTable CheckConfig()
        {

            SqlParameter[] parameters =
              {
                //  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int,  Value = Program.stationID},
                  //outParam_1
              };

            DataTable dt = new DataTable();
            dt = CommonBL.GetModifyData("sp_check_config", parameters);
            return dt;

        }

        private void DotCombo()
        {
            dtDotComboAll = CommonBL.getCombo(Program.userID, 29, Program.stationID.ToString(), txtModelNo.Text);

            //  DataRow[] dr = dtDotComboAll.Select("dotID and dotName");

            string[] selectedColumns = new[] { "dotID", "dotName" };

             dtDotCombo = new DataView(dtDotComboAll).ToTable(false, selectedColumns);

            if (dtDotCombo.Rows.Count > 0)
            {
                //dtDotCombo = dr.CopyToDataTable();

                cmbDotSpec.DataSource = dtDotCombo;
                cmbDotSpec.DisplayMember = "dotName";
                cmbDotSpec.ValueMember = "dotID";

                cmbDotSpec.SelectedIndex = -1;
            }


            
        }

        private void cmbDotSpec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int dotID = Convert.ToInt32(cmbDotSpec.SelectedValue.ToString());

            //MachineFromDot
            string[] selectedColumnsMachines = new[] { "dotID","machineID", "MachineName" };
            DataTable dtMachineFromDot = new DataView(dtDotComboAll).ToTable(false, selectedColumnsMachines);

            DataRow[] dr = dtMachineFromDot.Select("dotID =" + dotID);

            if (dr.Length > 0)
            {
                dtMachineFromDot = dr.CopyToDataTable();
            }
            dtMachineFromDot.Columns.RemoveAt(0);

            cmbMachineNo.DataSource = dtMachineFromDot;
            cmbMachineNo.ValueMember = "machineID";
            cmbMachineNo.DisplayMember = "MachineName";

            //PalleteFromDot
            string[] selectedColumnsPalletes = new[] {"dotID", "PalleteID", "PalleteName" };
            DataTable dtPalleteFromDot = new DataView(dtDotComboAll).ToTable(false, selectedColumnsPalletes);

            DataRow[] dr1 = dtPalleteFromDot.Select("dotID =" + dotID);

            if (dr1.Length > 0)
            {
                dtPalleteFromDot = dr1.CopyToDataTable();
            }
            dtPalleteFromDot.Columns.RemoveAt(0);

            cmbPalletNo.DataSource = dtPalleteFromDot;
            cmbPalletNo.ValueMember = "PalleteID";
            cmbPalletNo.DisplayMember = "PalleteName";


        }

        //Added by Aamir - 03/03/2023
        private void frmScanPartNo_KeyDown(object sender, KeyEventArgs e)
        {

            //if ((((TextBox )sender).Name) == "txtPartNo")

            //var name = this.ActiveControl.Name;

            if (e.KeyCode == Keys.Enter)
            {
                fnreValidate();
                if (fnValidate())
                {
                    btnSave.PerformClick();
                }
            }
        }

        private void cmbCastingSupplierwise_SelectionChangeCommitted(object sender, EventArgs e)//26/05/23
        {
            //if (cmbCastingSupplierwise.Text != "")
            //{
            //    Program.CastingSupplierwise = Convert.ToInt32(cmbCastingSupplierwise.SelectedValue);
            //}
        }

        private void txtModelSAPNo_Leave(object sender, EventArgs e)
        {
           if (txtModelSAPNo.Text != "")
           {
               errorProvider1.SetError(txtModelSAPNo, "");
           }
           
        }

        private void cmbCastingSupplierwise_Leave(object sender, EventArgs e)
        {
            if (cmbCastingSupplierwise.Text != "")
            {
                errorProvider1.SetError(cmbCastingSupplierwise, "");
            }
        }

        private void cmbSemifinishSupplierwise_Leave(object sender, EventArgs e)
        {
            if (cmbSemifinishSupplierwise.Text != "")
            {
                errorProvider1.SetError(cmbSemifinishSupplierwise, "");
            }
        }
        //Added by Aamir - 03/03/2023

        //Aamir - 18/01/2023

    }
}
