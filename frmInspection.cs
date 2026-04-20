using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace SPC_KDL
{
    public partial class frmInspection : Form
    {
        public frmInspection()
        {
            InitializeComponent();

            //this.Location = new Point(0, 0);

            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        public ListTemplate[] listTemplates; 

        public static DataSet dsFinalTemplateQueueList;
        public static DataTable dtTempList;
        public static DataTable dtQueueList;
        public static DataSet dsStationMachineList; //14/06/23
        public static DataSet dsTemplate_List; //19/06/23
        public static DataSet dsInspectionHdrData;
        public static DataTable dtInspectionHdr1;
        public static DataTable dtInspectionHdr2;
        string partsScanned = "";
        string partsShiftScanned = "";
        string Shift = "";
        string lastSyncedDate = "";
        string StationName = "";
        string MitPartPos = "";
        string MitReadingPos = "";
        string MitPartNeg = "";
        string MitReadingNeg = "";

        //15/06/23
        int MachineId = 0;
        string MachineName = "";
        int IsDefault = 0;
        int SeqNo = 0;
        //15/06/23

        string currentPartNo = "";
        string MitPart = "";
        string MitReading= "";

        int charCount = 0;

        bool lastFlag = false;

        string currentModel = "";
        string currentChar = "";
        string currentLTL = "";
        string currentTarget = "";
        string currentUTL = "";
        int currentSrNo = 0;

        int tempID = 0;
        int machID = 0;
        string currentCharID = "";

        int currentTempID = 0;
        int currentmachineID = 0;

        public int currentEventID = 0;
        

        int sel = 0;

        //Chart
        DataSet dsChartData;
        DataTable dtConfig;
        DataTable dtReadings;
        DataTable dtActualTable;

        double xUL, xLL, xM, xUCL, xLCL;
        double xMinReading, xMaxReading, rMinReading, rMaxReading;
        int x_xAxisMaxLength = 0;

        double rUL, rLL, rM;
       // decimal rUL, rLL, rM;
        int r_xAxisMaxLength = 0;

        int controlChartClicked = 0;
        private void frmInspection_Load(object sender, EventArgs e)
    {
            //OnLoadLogic(); //comment on 28/06/23
            StationMachineList(); //Add on 28/06/23

        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
        mdiform.toolStripStatusLabel.Text = "";

            //chkMasterSize.Checked= true; //29/05/23 //comment on 14/07/23

        }
        public void populateTemplates()
        {
            if (dtTempList != null)
            {
                if (dtTempList.Rows.Count > 0)
                {
                    //populate it here
                    // ListTemplate[] 
                    listTemplates = new ListTemplate[dtTempList.Rows.Count]; // 6 20 (No. of template counts)

                    for (int i = 0; i < listTemplates.Length; i++)    //loop through  each item
                    {
                        listTemplates[i] = new ListTemplate();
                        listTemplates[i].Width = flowLayoutPanelTemplate.Width;
                        listTemplates[i].TemplateID = Convert.ToInt32(dtTempList.Rows[i]["TemplateID"].ToString());
                        listTemplates[i].Template = dtTempList.Rows[i]["TemplateName"].ToString();   //"Template " + i; //Get Template Name
                                                                                                     //add to flowlayout
                        if (flowLayoutPanelTemplate.Controls.Count < 0)
                        {
                            flowLayoutPanelTemplate.Controls.Clear();
                        }
                        else

                            flowLayoutPanelTemplate.Controls.Add(listTemplates[i]);
                        // listTemplates[i].Click += new EventHandler(this.UserControlTemplate_Click); //TODO //Aamir - 13/09/22
                        listTemplates[i].Enter += new EventHandler(this.UserControlTemplate_Enter);
                    }

                    flowLayoutPanelTemplate.HorizontalScroll.Maximum = 0;
                    flowLayoutPanelTemplate.AutoScroll = false;
                    flowLayoutPanelTemplate.VerticalScroll.Visible = false;
                    flowLayoutPanelTemplate.AutoScroll = true;
                }
            }

        }
        void UserControlTemplate_Enter(object sender, EventArgs e) //Aamir - TODO
        {
            //if (flowLayoutPanelChar.Controls.Count == 0) //Commented by Aamir - 23/09/2022 - TODO
            //{

            ListTemplate objTemp = (ListTemplate)sender;

            for (int i = 0; i < listTemplates.Length; i++)    //loop through  each item
            {

                listTemplates[i].BackColor = Color.White;

            }
            objTemp.BackColor = Color.LightSkyBlue;


            pnlChartDatatable.Controls.Remove(chart1);


            lblChartErrMsg.Visible = false;
            lblChartErrMsg.Text = "";

            pbDatatable.BackColor = Color.SkyBlue;
            pbChart.BackColor = SystemColors.Control;
            pbPMCChart.BackColor = SystemColors.Control;
            // pnlDatatable.BackColor = Color.SkyBlue;
            //pnlChart.BackColor = SystemColors.Control;

            dgvDatatable.Visible = true;

            SqlParameter[] parameters =
               {
                //  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@Login_id", SqlDbType = SqlDbType.VarChar, Size = 100,  Value = Program.userID.ToString()},
                  new SqlParameter{ParameterName="@StationId",SqlDbType=SqlDbType.Int, Value = Program.stationID},
                  new SqlParameter{ParameterName="@TemplateId",SqlDbType=SqlDbType.Int, Value = objTemp.TemplateID},
                  new SqlParameter{ParameterName="@MachineId",SqlDbType =SqlDbType.Int, Value = 0 },
                  new SqlParameter{ParameterName="@CharacteristicsId",SqlDbType =SqlDbType.Int,  Value =  0},  //"1"
                  //outParam_1
              };

            DataTable dt = new DataTable();
            //dt = CommonBL.GetModifyData("sp_GetChartData_DE", parameters);
            dt = CommonBL.GetModifyData(StoredProcedure.GetChartDataDE, parameters);



            dgvDatatable.DataSource = dt;

            //Added by Aamir - 24/09/22
            //lblQueueCount.Text = "0"; Commented by Aamir - 24/09/22



            btnKeyboard.Visible = false;
            lblPartNoHeading.Visible = false;
            lblPartNo.Visible = false;
            lblCharacteristicHeading.Visible = false;
            lblCharacteristic.Visible = false;
            lblGaugeSourceHeading.Visible = false;
            lblGaugeSource.Visible = false;
            lblCPHdr.Visible = false;
            lblCPData.Visible = false;
            lblCPKHdr.Visible = false;
            lblCPKData.Visible = false;

            //Aamir - 01/10/2022
            lblCPMHdr.Visible = false;
            lblCPMData.Visible = false;
            lblCPKMHdr.Visible = false;
            lblCPKMData.Visible = false;
            //Aamir - 01/10/2022

            pbDatatable.Visible = false;
            pbPMCChart.Visible = false;
            pbChart.Visible = false;

            lblInspectionCharCountHdr.Visible = false;
            lbllnspectionCharCountData.Visible = false;

            pnlChartDatatable.Width = 1605;
            pnlChartDatatable.Height = 892;

            pnlChartDatatable.Location = new System.Drawing.Point(292, 132);

            dgvDatatable.Width = 1605;
            dgvDatatable.Height = 892;

            //chkMasterSize.Visible = false; //comment on 14/07/23

            //comment on 22/06/23<<
            //pnlChartDatatable.Width = 1613;
            //pnlChartDatatable.Height = 888;

            //pnlChartDatatable.Location = new System.Drawing.Point(292, 53);

            //dgvDatatable.Width = 1613;
            //dgvDatatable.Height = 888;
            //>> comment on 22/06/23

            //Add on 22/06/23<<
            //if (lblQueueCount.Text != "0")
            //{
            //    chkMasterSize.Visible = false;

            //    pnlChartDatatable.Width = 1605;
            //    pnlChartDatatable.Height = 892;

            //    pnlChartDatatable.Location = new System.Drawing.Point(292, 132);

            //    dgvDatatable.Width = 1605;
            //    dgvDatatable.Height = 892;
            //    //>> Add on 22/06/23

            //    //Added by Aamir - 24/09/22

            //    //  } //Commented by Aamir - 23/09/2022 - TODO


            //    //Add on 26/06/23
            //    currentmachineID.ToString();
            //    dsFinalTemplateQueueList = GetTemplate_Queue_List();
            //    if (dsFinalTemplateQueueList.Tables[1].Rows.Count > 0)
            //    {
            //        if (dtQueueList != null)
            //        {
            //            dtQueueList.Rows.Clear();
            //        }

            //        dtQueueList = dsFinalTemplateQueueList.Tables[1];
            //    }
            //    if (dtQueueList != null)
            //    {
            //        dtQueueList.Rows.Clear();


            //        btnKeyboard.Visible = true;
            //        lblPartNoHeading.Visible = true;
            //        lblPartNo.Visible = true;
            //        lblCharacteristicHeading.Visible = true;
            //        lblCharacteristic.Visible = true;
            //        lblGaugeSourceHeading.Visible = true;
            //        lblGaugeSource.Visible = true;
            //        lblCPHdr.Visible = true;
            //        lblCPData.Visible = true;
            //        lblCPKHdr.Visible = true;
            //        lblCPKData.Visible = true;

            //        //Aamir - 03/10/22
            //        lblCPMHdr.Visible = true;
            //        lblCPMData.Visible = true;
            //        lblCPKMHdr.Visible = true;
            //        lblCPKMData.Visible = true;
            //        //Aamir - 03/10/22

            //        pbDatatable.Visible = true;
            //        pbPMCChart.Visible = true;
            //        pbChart.Visible = true;

            //        lblInspectionCharCountHdr.Visible = true;
            //        lbllnspectionCharCountData.Visible = true;

            //        chkMasterSize.Visible = true;

            //        //add on 22/06/23
            //        pbPartImage.Visible = true;
            //        pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
            //        pnlChartDatatable.Width = 984;
            //        pnlChartDatatable.Height = 487;

            //        flowLayoutPanelChar.Visible = true;
            //        //add on 22/06/23


            //    }
            //}
            //Add on 26/06/23
        }
        public void PopulateQueue()
        {
        currentPartNo = "";
        if (dtQueueList != null)
            {
                if (dtQueueList.Rows.Count > 0)
                {
                    lblQueueCount.Text = dtQueueList.Rows.Count.ToString(); //"99";

                    ListQueue[] listQueue = new ListQueue[dtQueueList.Rows.Count];
                    //loop through  each item
                    for (int i = 0; i < listQueue.Length; i++)
                    {
                        listQueue[i] = new ListQueue();
                        listQueue[i].Width = flowLayoutPanelQueue.Width;
                        listQueue[i].PartNo = dtQueueList.Rows[i]["PartNo"].ToString();   //"PartNo " + i;
                        if (i == 0)
                        {
                            listQueue[i].BackColor = Color.LightCyan; 
                            currentPartNo = listQueue[i].PartNo; //obsNo

                            currentTempID = Convert.ToInt32(dtQueueList.Rows[i]["TemplateID"].ToString());
                            currentmachineID = Convert.ToInt32(dtQueueList.Rows[i]["MachineID"].ToString());

                            Program.CurrentTemplateID = currentTempID;
                            Program.CurrentMachineID = currentmachineID; 

                        }
                        listQueue[i].MachineNo = dtQueueList.Rows[i]["MachineNo"].ToString();  //"MachineNo " + i;
                        listQueue[i].Pallet = dtQueueList.Rows[i]["Pallete"].ToString();  //"Pallet " + i;
                        listQueue[i].Time = dtQueueList.Rows[i]["ScanTime"].ToString();  //i + " min ago";
                                                                                            //add to flowlayout
                        if (flowLayoutPanelQueue.Controls.Count < 0)
                        {
                            flowLayoutPanelQueue.Controls.Clear();
                            flowLayoutPanelQueue.Controls.Add(lblNothingPendingQueue); 


                        }
                        else

                            flowLayoutPanelQueue.Controls.Add(listQueue[i]);
                    }
                    flowLayoutPanelQueue.HorizontalScroll.Maximum = 0;
                    flowLayoutPanelQueue.AutoScroll = false;
                    flowLayoutPanelQueue.VerticalScroll.Visible = false;
                    flowLayoutPanelQueue.AutoScroll = true;
                      
                }

                else
                {
                    lblQueueCount.Text = "0";
                    dgvDatatable.Visible = false;

                    //Aamir - 16/09/2022
                    btnKeyboard.Visible = false;
                    lblPartNoHeading.Visible = false;
                    lblPartNo.Visible = false;
                    lblCharacteristicHeading.Visible = false;
                    lblCharacteristic.Visible = false;
                    lblGaugeSourceHeading.Visible = false;
                    lblGaugeSource.Visible = false;
                    lblCPHdr.Visible = false;
                    lblCPData.Visible = false;
                    lblCPKHdr.Visible = false;
                    lblCPKData.Visible = false;

                    //Aamir - 03/10/2022
                    lblCPMHdr.Visible = false;
                    lblCPMData.Visible = false;
                    lblCPKMHdr.Visible = false;
                    lblCPKMData.Visible = false;
                    //Aamir - 03/10/2022

                    pbDatatable.Visible = false;
                    pbPMCChart.Visible = false;
                    pbChart.Visible = false;

                    lblInspectionCharCountHdr.Visible = false;
                    lbllnspectionCharCountData.Visible = false;



                    //Comment on 22/06/23<<
                    //pnlChartDatatable.Width = 1613;
                    //pnlChartDatatable.Height = 888;

                    //pnlChartDatatable.Location = new System.Drawing.Point(292, 53);

                    //dgvDatatable.Width = 1613;
                    //dgvDatatable.Height = 888;
                    //>> Comment on 22/06/23

                    //Add on 22/06/23<<

                    //chkMasterSize.Visible = false; //comment on 14/07/23
                    pnlChartDatatable.Width = 1605;
                    pnlChartDatatable.Height = 892;

                    pnlChartDatatable.Location = new System.Drawing.Point(292, 132);

                    dgvDatatable.Width = 1605;
                    dgvDatatable.Height = 892;
                    //>> Add on 22/06/23

                    //dgvDatatable.Visible = true;

                    flowLayoutPanelQueue.Controls.Clear();
                    flowLayoutPanelQueue.Controls.Add(lblNothingPendingQueue);
                }

        }

        //Aamir - 15/09/22
        else
            {
                flowLayoutPanelQueue.Controls.Clear();
                flowLayoutPanelQueue.Controls.Add(lblNothingPendingQueue);
            }




            //TODO
            //   ListTemplate[] listTemplates1 = new ListTemplate[dtTempList.Rows.Count]; // 6 20 (No. of template counts)
            if (dtTempList != null)
            {
                if (dtTempList.Rows.Count > 0)
                {
                    for (int i = 0; i < listTemplates.Length; i++)    //loop through  each item
                    {
                        if (Convert.ToInt32(dtTempList.Rows[i]["TemplateID"].ToString()) == currentTempID)
                        {
                            listTemplates[i].BackColor = Color.LightCyan;
                        }
                    }
                }
            }

            }
        public void PopulateChar()
        {
            var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
            mdiform.toolStripStatusLabel.Text = "";

            flowLayoutPanelChar.Controls.Clear();

            charCount = 0;
            if (dtInspectionHdr2 != null)
            {
                ListChar[] listChar = new ListChar[dtInspectionHdr2.Rows.Count]; //7
                                                                                    //loop through  each item
                charCount = listChar.Length;

                //Added by Aamir - 17/09/22
                lbllnspectionCharCountData.Text = charCount.ToString();

                for (int i = 0; i < listChar.Length; i++)
                {
                    listChar[i] = new ListChar();
                    listChar[i].CurrentCharCount = i + 1; 

                    listChar[i].Char = "Char :  " + dtInspectionHdr2.Rows[i]["Char"].ToString();
                    listChar[i].LastObs = "Last Obs : " + dtInspectionHdr2.Rows[i]["lastObs"].ToString();
                    listChar[i].Target = "Target :     " + dtInspectionHdr2.Rows[i]["Target"].ToString();
                    listChar[i].UTL = "UTL :         " + dtInspectionHdr2.Rows[i]["UTL"].ToString();
                    listChar[i].LTL = "LTL :          " + dtInspectionHdr2.Rows[i]["LTL"].ToString();

                    listChar[i].UCL = "UCL :         " + dtInspectionHdr2.Rows[i]["UPCL"].ToString();
                    listChar[i].LCL = "LCL :          " + dtInspectionHdr2.Rows[i]["LPCL"].ToString();

                    listChar[i].UPCL = dtInspectionHdr2.Rows[i]["UPCL"].ToString();
                    listChar[i].LPCL = dtInspectionHdr2.Rows[i]["LPCL"].ToString();
                    listChar[i].MasterSize  = dtInspectionHdr2.Rows[i]["MasterSize"].ToString();
                    listChar[i].GaugeSource = dtInspectionHdr2.Rows[i]["GuageSource"].ToString();
                    listChar[i].ImageString  = dtInspectionHdr2.Rows[i]["Cimage"].ToString();
                    listChar[i].PartNo = dtInspectionHdr2.Rows[i]["ObsNo"].ToString(); 
                    listChar[i].ModelNo = dtInspectionHdr2.Rows[i]["PartNo"].ToString();

                    listChar[i].CharID = dtInspectionHdr2.Rows[i]["CharID"].ToString();
                    listChar[i].ChannelNo = dtInspectionHdr2.Rows[i]["ChannelNo"].ToString();
                    listChar[i].CharType = dtInspectionHdr2.Rows[i]["CharType"].ToString();

                    listChar[i].InspectionStatusID = Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString());
                    listChar[i].prevInspectionStatusID = Convert.ToInt32(dtInspectionHdr2.Rows[i]["prevInspectionStatusID"].ToString());
                    listChar[i].TemplateID  = Convert.ToInt32(dtInspectionHdr2.Rows[i]["TemplateID"].ToString());
                    listChar[i].MachineID = Convert.ToInt32(dtInspectionHdr2.Rows[i]["MachineID"].ToString());

                    listChar[i].Formula = Convert.ToInt32(dtInspectionHdr2.Rows[i]["Formula"].ToString());//30/05/23

                    listChar[i].Event = dtInspectionHdr2.Rows[i]["EventAbbr"].ToString();  

                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 0) // No Inspection needed
                    {
                        listChar[i].BackColor = Color.Gray;
                    }
                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 1) //Inspection Needed 
                    {
                        listChar[i].BackColor = Color.Orange; //Yellow
                    }
                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 2) // Inspection Done
                    {
                        listChar[i].BackColor = Color.LimeGreen;

                        //listChar[i].lblLastObs.ForeColor = Color.LimeGreen;  
                    }
                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 3) // Inspection Current 
                    {
                        listChar[i].BackColor = Color.Blue;
                    }

                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 4) // Red
                    {
                        listChar[i].BackColor = Color.Red;

                        //listChar[i].lblLastObs.ForeColor = Color.Red;
                    }
                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 5) // Yellow
                    {
                        listChar[i].BackColor = Color.Yellow;

                       // listChar[i].lblLastObs.ForeColor = Color.Yellow;
                    }

                    if(Convert.ToInt32(dtInspectionHdr2.Rows[i]["prevInspectionStatusID"].ToString()) == 2)
                    {
                        listChar[i].lblLastObs.ForeColor = Color.LimeGreen;
                    }
                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["prevInspectionStatusID"].ToString()) == 4)
                    {
                        listChar[i].lblLastObs.ForeColor = Color.Red;
                    }
                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["prevInspectionStatusID"].ToString()) == 5)
                    {
                        listChar[i].lblLastObs.ForeColor = Color.FromArgb(246, 190, 0); //Color.Yellow
                    }


                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 3) //i == 0
                {
                            listChar[i].BackColor = Color.Blue;


                    string base64String = listChar[i].ImageString; //TODO - Kranti
                    // Convert base 64 string to byte[]
                    if (base64String != "")
                    {
                        byte[] imageBytes = Convert.FromBase64String(base64String);
                        // Convert byte[] to Image
                        using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                        {
                            pbPartImage.Image = Image.FromStream(ms, true);
                        }

                    }
                    else
                    {
                            //  pbPartImage.Image = SPC_KDL.Properties.Resources.no_img_avail;//null; //Aamir - 16/09/2022
                            pbPartImage.Image = SPC_KDL.Properties.Resources.noimageavailabe_image;
                        }

                    lblPartNo.Text = listChar[i].PartNo;
                    lblCharacteristic.Text = listChar[i].Char.Split(':')[1] ;
                    lblGaugeSource.Text = listChar[i].GaugeSource;

                        //31/05/23
                        //if (listChar[i].GaugeSource != null)  //comment on 14/07/23>>
                        //{
                        //    chkMasterSize.Enabled = false;
                        //}
                        //else
                        //{
                        //    chkMasterSize.Enabled = true;
                        //}                                    //<<comment on 14/07/23
                        //

                        //Added by Aamir - 02/03/2023
                        currentCharID = listChar[i].CharID;
                        //Added by Aamir - 02/03/2023

                    }
                    //add to flowlayout
                    if (flowLayoutPanelChar.Controls.Count < 0)
                    {
                        flowLayoutPanelChar.Controls.Clear();
                    }
                    else

                        flowLayoutPanelChar.Controls.Add(listChar[i]);
                        listChar[i].Leave  += new EventHandler(this.UserControlForm_Leave); //TODO
                        listChar[i].Enter += new EventHandler(this.UserControlForm_Enter);


                    if (Convert.ToInt32(dtInspectionHdr2.Rows[i]["InspectionStatusID"].ToString()) == 3) // i == 0
                        {
                            //listChar[i].Select(); // 0
                            //listChar[i].Focus(); // 0               
                              sel = i;
                        }
              } // for loop end
                if (flowLayoutPanelChar.Controls.Count > 0)
                {

                    //Commented by Aamir - 03/03/2023

                    ////Added by Aamir - 03/10/2022
                    //pbDatatable_Click(this.pbDatatable, null);
                    ////Added by Aamir - 03/10/2022

                    //Commented by Aamir - 03/03/2023

                    //Added by Aamir - 03/03/2023
                    pbPMCChart_Click(this.pbPMCChart, null);
                    //Added by Aamir - 03/03/2023




                    //Aamir - 03/11/2022
                    listChar[sel].Select(); // 0
                    listChar[sel].Focus(); // 0

                }


            }
        } //private
        private void UserControlForm_Enter(object sender, EventArgs e)
        {          
            ListChar obj = (ListChar)sender;

            if (obj.BackColor != Color.LimeGreen) //Added by Aamir - 16/09/2022
            {
                if (obj.BackColor != Color.Red)
                {
                    if (obj.BackColor != Color.Yellow)
                    {
                        // obj.txtCurrentReading.ReadOnly = true;
                        obj.txtCurrentReading.KeyPress += new KeyPressEventHandler(this.CurrentReading_KeyPress);

                        //TODO - Aamir - 09/08/2022
                        if (obj.CurrentCharCount != 1)
                        {
                            ListChar objPrevious = (ListChar)flowLayoutPanelChar.Controls.Find("ListChar", true)[obj.CurrentCharCount - 2];

                            if (obj.InspectionStatusID != 3)
                            {
                                if (objPrevious.txtCurrentReading.Text == "") //TODO Aamir - 10/08/2022 
                                {
                                    objPrevious.txtCurrentReading.Select();
                                    objPrevious.Focus();
                                    return;
                                }
                            }
                        }
                        //TODO - Aamir - 09/08/2022


                        currentModel = obj.ModelNo;
                        currentChar = obj.Char;
                        currentLTL = obj.LTL;
                        currentTarget = obj.Target;
                        currentUTL = obj.UTL;
                        currentSrNo = obj.CurrentCharCount;

                        tempID = obj.TemplateID;
                        machID = obj.MachineID;
                        currentCharID = obj.CharID;

                        //if (charCount != obj.CurrentCharCount)
                        // { 
                        //To check here - InspectionStatusID //TODO - Aamir
                        if (obj.InspectionStatusID == 0)
                        {
                            this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                        }
                        else
                        {

                            obj.BackColor = Color.Blue; //TODO

                            string base64String = obj.ImageString;
                            // Convert base 64 string to byte[]
                            if (base64String != "")
                            {
                                byte[] imageBytes = Convert.FromBase64String(base64String);
                                // Convert byte[] to Image
                                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                                {
                                    pbPartImage.Image = Image.FromStream(ms, true);
                                }
                            }
                            else
                            {
                                pbPartImage.Image = SPC_KDL.Properties.Resources.noimageavailabe_image;//null;
                            }

                            lblPartNo.Text = obj.PartNo;
                            lblCharacteristic.Text = obj.Char.Split(':')[1];
                            lblGaugeSource.Text = obj.GaugeSource;

                            //31/05/23
                            //if (obj.GaugeSource != "") //<<Comment on 14/07/23
                            //{
                            //    chkMasterSize.Enabled = false;
                            //}
                            //else
                            //{
                            //    chkMasterSize.Enabled = true;
                            //}                          //>>Comment on 14/07/23
                            //

                            if (obj.CharType == "Attribute")
                            {
                                string Model = obj.ModelNo;
                                string Part = obj.PartNo;
                                string Attribute = obj.Char;

                                frmAttributeInput frmAttributeInput = new frmAttributeInput(Model, Part, Attribute);

                                //    pbDatatable_Click(this.pbDatatable, e); //TODO Commented by Aamir - 03/10/2022
                                //    pbChart_Click(this.pbChart, e); //07/09 //TODO

                                //01/06/23
                                //if (obj.CharType == "Attribute")//<<Comment on 14/07/23
                                //{
                                //    chkMasterSize.Enabled = false;
                                //}                               //>>Comment on 14/07/23
                                //



                                var result = frmAttributeInput.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    string defect = frmAttributeInput.ReturnValDefect;
                                    string readingAttribute = "";
                                    if (defect == "Pass")
                                    {
                                        readingAttribute = "1";
                                        obj.txtCurrentReading.Text = defect;

                                        obj.BackColor = Color.LimeGreen;

                                        //Add on 29/06/23
                                        SqlParameter outparam_1 = new SqlParameter();
                                        outparam_1.ParameterName = "@Msg";
                                        outparam_1.SqlDbType = SqlDbType.VarChar;
                                        outparam_1.Size = 500;
                                        outparam_1.Direction = ParameterDirection.Output;
                                        //Add on 29/06/23

                                        //Update Inspection data here for the current characteristic
                                        SqlParameter[] parameters = //TODO
                                            {
                        new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                        new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                        new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(obj.CharID)},
                        new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = obj.PartNo},
                        new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(readingAttribute)}, //TODO
                        new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                        outparam_1, //add on 29/06/23
                    };

                                        //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                        CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                        string msg = outparam_1.Value.ToString();//03/07/23

                                        if (msg == "")//03/07/23
                                        {
                                            mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                            mdiform.toolStripStatusLabel.Text = "Reading saved for - " + obj.Char;

                                            if (charCount != obj.CurrentCharCount)
                                            {
                                                this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);

                                                //frmAttributeInput frmAttribute = new frmAttributeInput(null, null, null);
                                                //frmAttribute.Close();
                                            }
                                            else
                                            {
                                                frmAttributeInput frmAttribute = new frmAttributeInput(null, null, null);
                                                frmAttribute.Close();

                                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                                DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                                if (result1 == DialogResult.OK)
                                                {
                                                    OnLoadLogic();
                                                    PopulateChar();
                                                }
                                            }

                                        }//03/07/23
                                        else //03/07/23
                                        {
                                            MessageBox.Show("Contineous 7 Reading on One side");
                                            obj.BackColor = Color.Blue;
                                            obj.txtCurrentReading.Focus();
                                            return;//03/07/23
                                        }


                                        //  SendKeys.Send("{TAB}");
                                    }
                                    else if (defect == "Fail")
                                    {
                                        readingAttribute = "0";
                                        obj.txtCurrentReading.Text = defect;

                                        obj.BackColor = Color.Red;

                                        //Add on 29/06/23
                                        SqlParameter outparam_1 = new SqlParameter();
                                        outparam_1.ParameterName = "@Msg";
                                        outparam_1.SqlDbType = SqlDbType.VarChar;
                                        outparam_1.Size = 500;
                                        outparam_1.Direction = ParameterDirection.Output;
                                        //Add on 29/06/23

                                        //Update Inspection data here for the current characteristic
                                        SqlParameter[] parameters = //TODO
                                            {
                                                new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                                new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                                new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(obj.CharID)},
                                                new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = obj.PartNo},
                                                new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(readingAttribute)}, //TODO
                                                new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                                 new SqlParameter { ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = 'R' },
                                                 outparam_1, //Add on 29/06/23

                                            };

                                        //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                        CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                        string msg = outparam_1.Value.ToString();//03/07/23

                                        if (msg == "")//03/07/23
                                        {
                                            mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                            mdiform.toolStripStatusLabel.Text = "Reading saved for - " + obj.Char;

                                            if (charCount != obj.CurrentCharCount)
                                            {
                                                this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);

                                                //frmAttributeInput frmAttribute = new frmAttributeInput(null, null, null);
                                                //frmAttribute.Close();
                                            }
                                            else
                                            {
                                                frmAttributeInput frmAttribute = new frmAttributeInput(null, null, null);
                                                frmAttribute.Close();

                                                // lastFlag = true;
                                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                                DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                                if (result1 == DialogResult.OK)
                                                {
                                                    OnLoadLogic();
                                                    PopulateChar();
                                                }
                                            }

                                        }//03/07/23
                                        else //03/07/23
                                        {
                                            MessageBox.Show("Contineous 7 Reading on One side"); 
                                            obj.BackColor = Color.Blue;
                                            obj.txtCurrentReading.Focus();
                                            return;//30/06/23
                                        }


                                    }
                                    else
                                    {
                                        //Aamir - TODO - 25/08/2022

                                        //frmAttributeInput frmAttribute = new frmAttributeInput(null, null, null);
                                        //frmAttribute.Close();

                                        //MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        //DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                        //if (result1 == DialogResult.OK)
                                        //{
                                        //    OnLoadLogic();
                                        //}
                                    }
                                }

                                else //TODO
                                {


                                    //  frmAttributeInput.Close();

                                }

                            }

                        }

                        //   pbDatatable_Click(this.pbDatatable, e); //Commented by Aamir 03/10/2022
                        //  pbChart_Click(this.pbChart, e); //07/09 //TODO

                        pbPMCChart_Click(this.pbPMCChart, e);
                    }
                }
            }
        }
        void CurrentReading_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.')
            //{
            //    e.Handled = true;
            //}
            ////Edit: Alternative
            //if (!char.IsDigit(e.KeyChar) && e.KeyChar == (char)Keys.Back && e.KeyChar == '.')
            //{
            //    e.Handled = true;
            //}
        }
        private void UserControlForm_Leave(object sender, EventArgs e)
     {
            ListChar obj = (ListChar)sender;

            //if (obj.CurrentCharCount != charCount && obj.txtCurrentReading.Text != "")
            //{
                currentModel = obj.ModelNo;
                currentChar = obj.Char;
                currentLTL = obj.LTL;
                currentTarget = obj.Target;
                currentUTL = obj.UTL;
                currentSrNo = obj.CurrentCharCount;

                tempID = obj.TemplateID;
                machID = obj.MachineID;
                currentCharID = obj.CharID;

                //frmKeyboard frmKeyboard  = new frmKeyboard(Model,Char,LTL,Target,UTL);

                //// if (obj.CurrentCharCount != charCount && charCount == 1) //11/08/2022
                ////{
                if (obj.InspectionStatusID == 0) //Aamir - 11/09/2022 TODO
                {
                    //if (obj.CurrentCharCount != charCount ) //11/08/2022
                    //{
                    this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                }
                else
                {

                    if (obj.txtCurrentReading.Text != "")
                    {
                        // obj.BackColor = Color.LimeGreen; //TODO Aamir - 11/09/2022

                        string Reading = "";
                        if (obj.CharType == "Variable")
                        {
                            //To bind "Reading" into User Control hidden textbox/label here
                            string currentReading = obj.txtCurrentReading.Text;

                            obj.txtCurrentReading.Text = "";  //Aamir 11/09/2022 TODO

                            if (currentReading.Length > 10)
                            {
                                if (currentReading.Contains("+"))
                                {
                                    MitPart = currentReading.Split('+')[0];
                                    MitPart = MitPart.Substring(2, 5);

                                    MitReading = currentReading.Substring(currentReading.LastIndexOf('+'));
                                    MitReading = MitReading.Remove(MitReading.Length - 1);
                                }
                                if (currentReading.Contains("-"))
                                {
                                    MitPart = currentReading.Split('-')[0];
                                    MitPart = MitPart.Substring(2, 5);

                                    MitReading = currentReading.Substring(currentReading.LastIndexOf('-'));
                                    MitReading = MitReading.Remove(MitReading.Length - 1);
                                }

                                if (MitPart != obj.ChannelNo)
                                {
                                    MessageBox.Show("Wrong device found on Channel " + obj.ChannelNo + ". Please enter the reading manually");
                                    obj.txtCurrentReading.Text = "";
                                    obj.txtCurrentReading.Select();
                                    obj.txtCurrentReading.Focus();
                                    return;
                                }
                                else
                                {
                                    //Bind Reading Here
                                    MitReading = MitReading.Substring(1, MitReading.Length - 1);
                                    Reading = MitReading;

                                    Reading = Reading.TrimStart('0'); //Aamir - 11/09/22 TODO

                                    obj.txtCurrentReading.Text = Reading; //Aamir - 11/09/22 TODO

                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect reading found on Channel " + obj.ChannelNo + ". Please select Keyboard and enter the reading manually");
                                // null the textbox here
                                obj.txtCurrentReading.Text = "";
                                obj.txtCurrentReading.Select();
                                obj.txtCurrentReading.Focus();
                                return;
                            }

                            //str.Substring(str.LastIndexOf('-') + 1);

                            //Check for event - 06/08/2022 - start
                            if (Convert.ToDecimal(Reading) < Convert.ToDecimal(obj.LTL.Substring(obj.LTL.LastIndexOf(':') + 1))) //LTL = LSL (Red Zone)
                            {
                                obj.BackColor = Color.Red;

                                frmEventSelection frmEventSelection = new frmEventSelection();
                                var result = frmEventSelection.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    currentEventID = frmEventSelection.EventID;

                                    char pnlBackColor = ' ';

                                    if (obj.BackColor == Color.Red)
                                    {
                                        pnlBackColor = 'R';//TODO
                                    }
                                    if (obj.BackColor == Color.Yellow)
                                    {
                                        pnlBackColor = 'Y';//TODO
                                    }

                                //Add on 29/06/23
                                SqlParameter outparam_1 = new SqlParameter();
                                outparam_1.ParameterName = "@Msg";
                                outparam_1.SqlDbType = SqlDbType.VarChar;
                                outparam_1.Size = 500;
                                outparam_1.Direction = ParameterDirection.Output;
                                //Add on 29/06/23

                                SqlParameter[] parameters = //TODO
                                       {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(obj.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = obj.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(Reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                            new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID }, //TODO
                                            new SqlParameter { ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor }, //TODO
                                            outparam_1, //Add on 29/06/23
                                      };

                                //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                frmEventSelection.Close();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                    string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                if (msg == "")//Add on 30/06/23
                                {

                                    mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Reading saved for - " + obj.Char;

                                    //TODO - Aamir - 07/08/2022
                                    //if (obj.InspectionStatusID == 0) - //Aamir - 11/09/2022 TODO
                                    // {
                                    //     this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                    //     //TODO - Aamir - 07/08/2022
                                    // }

                                    //     if (obj.CurrentCharCount  != charCount) //11/08/2022
                                    // {
                                    //     OnLoadLogic(); 
                                    // }

                                    if (obj.CurrentCharCount != charCount)  //Aamir - 11/09/2022 TODO
                                    {
                                        this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                        //TODO - Aamir - 07/08/2022
                                    }

                                    else //11/08/2022
                                    {
                                        obj.Leave -= new EventHandler(this.UserControlForm_Leave); //TODO Aamir - 12/09/2022
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                        if (result1 == DialogResult.OK)
                                        {
                                            OnLoadLogic();
                                            PopulateChar();
                                        }
                                    }
                                }  //Add on 30/06/23
                                else //03/07/23
                                {
                                    MessageBox.Show("Contineous 7 Reading on One side");
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();
                                    return;//30/06/23
                                }


                            }

                            else
                                {
                                    //TODO - Aamir 
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                    mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Retake the reading for " + obj.Char;
                                }


                            }
                            else if (Convert.ToDecimal(Reading) > Convert.ToDecimal(obj.UTL.Substring(obj.UTL.LastIndexOf(':') + 1)))
                            {
                                obj.BackColor = Color.Red;

                                frmEventSelection frmEventSelection = new frmEventSelection();
                                var result = frmEventSelection.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    char pnlBackColor = ' ';

                                    if (obj.BackColor == Color.Red)
                                    {
                                        pnlBackColor = 'R';//TODO
                                    }
                                    if (obj.BackColor == Color.Yellow)
                                    {
                                        pnlBackColor = 'Y';//TODO
                                    }
                                    currentEventID = frmEventSelection.EventID;

                                //Add on 29/06/23
                                SqlParameter outparam_1 = new SqlParameter();
                                outparam_1.ParameterName = "@Msg";
                                outparam_1.SqlDbType = SqlDbType.VarChar;
                                outparam_1.Size = 500;
                                outparam_1.Direction = ParameterDirection.Output;
                                //Add on 29/06/23

                                SqlParameter[] parameters = //TODO
                                       {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(obj.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = obj.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(Reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                             new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID }, //TODO
                                             new SqlParameter { ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor }, //TODO
                                             outparam_1, //Add on 29/06/23

                                      };

                                //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                frmEventSelection.Close();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                    string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                if (msg == "")//Add on 30/06/23
                                {

                                    mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Reading saved for - " + obj.Char;

                                    ////TODO - Aamir - 07/08/2022
                                    //if (obj.InspectionStatusID == 0)
                                    //{
                                    //    this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                    //    //TODO - Aamir - 07/08/2022
                                    //}

                                    //if (obj.CurrentCharCount != charCount) //11/08/2022
                                    //{
                                    //    OnLoadLogic();
                                    //}

                                    if (obj.CurrentCharCount != charCount)  //Aamir - 11/09/2022 TODO
                                    {
                                        this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                        //TODO - Aamir - 07/08/2022
                                    }

                                    else //11/08/2022
                                    {
                                        obj.Leave -= new EventHandler(this.UserControlForm_Leave); //TODO Aamir - 12/09/2022
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                        if (result1 == DialogResult.OK)
                                        {
                                            OnLoadLogic();
                                            PopulateChar();
                                        }
                                    }
                                }  //Add on 30/06/23
                                else //03/07/23
                                {
                                    MessageBox.Show("Contineous 7 Reading on One side");
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();
                                    return;//30/06/23
                                }


                            }

                            else
                                {
                                    //TODO - Aamir 
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                    mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Retake the reading for " + obj.Char;
                                }

                            }
                            else if (Convert.ToDecimal(Reading) < Convert.ToDecimal(obj.LPCL.Substring(obj.LPCL.LastIndexOf(':') + 1)))
                            {
                                obj.BackColor = Color.Yellow; //Orange

                                frmEventSelection frmEventSelection = new frmEventSelection();
                                var result = frmEventSelection.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    char pnlBackColor = ' ';

                                    if (obj.BackColor == Color.Red)
                                    {
                                        pnlBackColor = 'R';//TODO
                                    }
                                    if (obj.BackColor == Color.Yellow)
                                    {
                                        pnlBackColor = 'Y';//TODO
                                    }
                                    currentEventID = frmEventSelection.EventID;

                                //Add on 29/06/23
                                SqlParameter outparam_1 = new SqlParameter();
                                outparam_1.ParameterName = "@Msg";
                                outparam_1.SqlDbType = SqlDbType.VarChar;
                                outparam_1.Size = 500;
                                outparam_1.Direction = ParameterDirection.Output;
                                //Add on 29/06/23

                                SqlParameter[] parameters = //TODO
                                       {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(obj.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = obj.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(Reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                            new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID } ,//TODO
                                            new SqlParameter { ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor }, //TODO
                                            outparam_1,  //Add on 29/06/23
                                      };

                                //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                frmEventSelection.Close();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                    string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                if (msg == "")//Add on 30/06/23
                                {

                                    mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Reading saved for - " + obj.Char;

                                    ////TODO - Aamir - 07/08/2022
                                    //if (obj.InspectionStatusID == 0)
                                    //{
                                    //    this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                    //    //TODO - Aamir - 07/08/2022
                                    //}

                                    //if (obj.CurrentCharCount != charCount) //11/08/2022
                                    //{
                                    //    OnLoadLogic();
                                    //}

                                    if (obj.CurrentCharCount != charCount)  //Aamir - 11/09/2022 TODO
                                    {
                                        this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                        //TODO - Aamir - 07/08/2022
                                    }

                                    else //11/08/2022
                                    {
                                        obj.Leave -= new EventHandler(this.UserControlForm_Leave); //TODO Aamir - 12/09/2022
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                        if (result1 == DialogResult.OK)
                                        {
                                            OnLoadLogic();
                                            PopulateChar();
                                        }
                                    }
                                }  //Add on 30/06/23
                                else //03/07/23
                                {
                                    MessageBox.Show("Contineous 7 Reading on One side");
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();
                                    return;//30/06/23
                                }


                            }

                            else //Aamir - TODO
                                {
                                    //TODO - Aamir 
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                    mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Retake the reading for " + obj.Char;
                                }
                            }
                            else if (Convert.ToDecimal(Reading) > Convert.ToDecimal(obj.UPCL.Substring(obj.UPCL.LastIndexOf(':') + 1)))
                            {
                                obj.BackColor = Color.Yellow; //Orange

                                frmEventSelection frmEventSelection = new frmEventSelection();
                                var result = frmEventSelection.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    char pnlBackColor = ' ';

                                    if (obj.BackColor == Color.Red)
                                    {
                                        pnlBackColor = 'R';//TODO
                                    }
                                    if (obj.BackColor == Color.Yellow)
                                    {
                                        pnlBackColor = 'Y';//TODO
                                    }
                                    currentEventID = frmEventSelection.EventID;

                                //Add on 29/06/23
                                SqlParameter outparam_1 = new SqlParameter();
                                outparam_1.ParameterName = "@Msg";
                                outparam_1.SqlDbType = SqlDbType.VarChar;
                                outparam_1.Size = 500;
                                outparam_1.Direction = ParameterDirection.Output;
                                //Add on 29/06/23

                                SqlParameter[] parameters = //TODO
                                       {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(obj.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = obj.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(Reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                             new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID }, //TODO
                                             new SqlParameter { ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor }, //TODO
                                            outparam_1, //Add on 29/06/23
                                      };

                                //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                frmEventSelection.Close();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                    string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                if (msg == "")//Add on 30/06/23
                                {

                                    mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Reading saved for - " + obj.Char;

                                    ////TODO - Aamir - 07/08/2022
                                    //if (obj.InspectionStatusID == 0)
                                    //{
                                    //    this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                    //    //TODO - Aamir - 07/08/2022
                                    //}

                                    //if (obj.CurrentCharCount != charCount) //11/08/2022
                                    //{
                                    //    OnLoadLogic();
                                    //}

                                    if (obj.CurrentCharCount != charCount)  //Aamir - 11/09/2022 TODO
                                    {
                                        this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                        //TODO - Aamir - 07/08/2022
                                    }

                                    else //11/08/2022
                                    {
                                 
                                        obj.Leave -= new EventHandler(this.UserControlForm_Leave); //TODO Aamir - 12/09/2022
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                        if (result1 == DialogResult.OK)
                                        {
                                            OnLoadLogic();
                                            PopulateChar();
                                        }
                                    }

                                }  //Add on 30/06/23
                                else //03/07/23
                                {
                                    MessageBox.Show("Contineous 7 Reading on One side");
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();
                                    return;//30/06/23
                                }


                            }
                            else //Aamir - TODO
                                {
                                    //TODO - Aamir 
                                    obj.BackColor = Color.Blue;
                                    obj.txtCurrentReading.Focus();

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                    mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Retake the reading for " + obj.Char;
                                }
                            }
                            else
                            {
                                obj.BackColor = Color.LimeGreen;
                            //Check for event - 06/08/2022 - end 

                            //Add on 29/06/23
                            SqlParameter outparam_1 = new SqlParameter();
                            outparam_1.ParameterName = "@Msg";
                            outparam_1.SqlDbType = SqlDbType.VarChar;
                            outparam_1.Size = 500;
                            outparam_1.Direction = ParameterDirection.Output;
                            //Add on 29/06/23


                            // Update Inspection data here for the current characteristic
                            SqlParameter[] parameters = //TODO
                                    {
                                    new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                    new SqlParameter { ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID },
                                    new SqlParameter { ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(obj.CharID) },
                                    new SqlParameter { ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar, Size = 100, Value = obj.PartNo },
                                    new SqlParameter { ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal, Value = Convert.ToDecimal(Reading) }, //TODO
                                    new SqlParameter { ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar, Size = 20, Value = "1.0.0.0" }, //TODO
                                    outparam_1, //Add on 29/06/23
                                  
                                 };

                            //CommonBL.InsertData("spInsert_InspectionData", parameters);
                            CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);

                            var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                            string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                            if (msg == "") // Add on 29/06/23
                            {
                                mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                mdiform.toolStripStatusLabel.Text = "Reading saved for - " + obj.Char;

                                ////TODO - Aamir - 07/08/2022
                                //if (obj.InspectionStatusID == 0)
                                //{
                                //    this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                //    //TODO - Aamir - 07/08/2022
                                //}

                                //if (obj.CurrentCharCount != charCount) //11/08/2022
                                //{
                                //    OnLoadLogic();
                                //}

                                if (obj.CurrentCharCount != charCount)  //Aamir - 11/09/2022 TODO
                                {
                                    this.SelectNextControl(obj.txtCurrentReading, true, true, true, true);
                                    //TODO - Aamir - 07/08/2022
                                }

                                else //11/08/2022
                                {
                                    obj.Leave -= new EventHandler(this.UserControlForm_Leave); //TODO Aamir - 12/09/2022
                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                                    DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
                                    if (result1 == DialogResult.OK)
                                    {
                                        OnLoadLogic();
                                        PopulateChar();
                                    }
                                }
                            }//29/06/23
                            else //30/06/23
                            {
                                obj.BackColor = Color.Blue;
                                obj.txtCurrentReading.Focus();
                                return;//30/06/23
                            }

                            
                        }
                        }
                    }
                }
          //  }
        //} //11/08/22
        //else
        //{
        //    OnLoadLogic(); 
        //}

    }
        private DataSet GetTemplate_Queue_List()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int,  Value = Program.stationID},
                 new SqlParameter{ParameterName="@MachineID", SqlDbType =SqlDbType.Int, Value=currentmachineID} //add on 19/06/23
                //outParam_1
            };

            DataSet ds = new DataSet();
            //ds = CommonBL.GetTemplateQueueData("spGetTempate_List", parameters);
            ds = CommonBL.GetTemplateQueueData(StoredProcedure.GetTemplateList, parameters);
            return ds;
        }
        
        private DataSet GetStationMachineList()//14/06/23<<
        {
            SqlParameter[] parameters =
            {
                new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                new SqlParameter{ParameterName = "@StationID",SqlDbType = SqlDbType.Int, Value = Program.stationID} 
            };

            DataSet ds = new DataSet();
            //ds = CommonBL.GetTemplateQueueData("spGetStation_Machine_List", parameters);
            ds = CommonBL.GetTemplateQueueData(StoredProcedure.GetStationMachineList, parameters);

            return ds;
        }
        //14/06/23>>

        //private DataSet GetTemplate_List()//19/06/23
        //{
        //    SqlParameter[] parameters =
        //    {
        //        new SqlParameter{ParameterName="@UserID",SqlDbType =SqlDbType.Int,Value=Program.userID},
        //        new SqlParameter{ParameterName="@StationID", SqlDbType =SqlDbType.Int,Value=Program.stationID},
        //        new SqlParameter{ParameterName="@MachineID", SqlDbType =SqlDbType.Int, Value=currentmachineID}
        //    };

        //    DataSet ds = new DataSet();
        //    ds = CommonBL.GetTemplateQueueData("spGetTempate_List", parameters);
        //    return ds;
        //} //19/06/23

        private DataSet GetInspectionHdrData()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                new SqlParameter{ParameterName = "@StationID",SqlDbType = SqlDbType.Int, Value = Program.stationID} ,
                new SqlParameter{ParameterName = "@MachineID",SqlDbType = SqlDbType.Int, Value = currentmachineID} ,//12/06/23
                new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size=200,  Value = currentPartNo} //TODO
                //outParam_1
            };

            DataSet ds = new DataSet();
            //ds = CommonBL.GetTemplateQueueData("spGetTemplate_InspectionHdrData", parameters);
            ds = CommonBL.GetTemplateQueueData(StoredProcedure.GetTemplateInspectionHdrData, parameters);
            return ds;
        }

        private void StationMachineList() //28/06/23
        {
            dsStationMachineList = GetStationMachineList();//14/06/23


            for (int i = 0; i < dsStationMachineList.Tables[0].Rows.Count; i++) //15/06/23
            {
                //if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0) //comment on 19/06/23
                {
                    if (button1.Text == "")//&& Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)//comment on 19/06/23
                    {
                        button1.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
                        button1.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

                        if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
                        {
                            button1.BackColor = Color.LightBlue;

                            currentmachineID = Convert.ToInt32(button1.Tag);
                            OnLoadLogic();
                            //dsFinalTemplateQueueList = GetTemplate_Queue_List();

                            //if (dsFinalTemplateQueueList.Tables[1].Rows.Count > 0)
                            //{
                            //    if (dtQueueList != null)
                            //    {
                            //        dtQueueList.Rows.Clear();
                            //    }

                            //    dtQueueList = dsFinalTemplateQueueList.Tables[1];
                            //}
                            //dsInspectionHdrData = GetInspectionHdrData();
                            if (dtQueueList != null)
                            {
                                dtQueueList.Rows.Clear();


                                btnKeyboard.Visible = true;
                                lblPartNoHeading.Visible = true;
                                lblPartNo.Visible = true;
                                lblCharacteristicHeading.Visible = true;
                                lblCharacteristic.Visible = true;
                                lblGaugeSourceHeading.Visible = true;
                                lblGaugeSource.Visible = true;
                                lblCPHdr.Visible = true;
                                lblCPData.Visible = true;
                                lblCPKHdr.Visible = true;
                                lblCPKData.Visible = true;

                                //Aamir - 03/10/22
                                lblCPMHdr.Visible = true;
                                lblCPMData.Visible = true;
                                lblCPKMHdr.Visible = true;
                                lblCPKMData.Visible = true;
                                //Aamir - 03/10/22

                                pbDatatable.Visible = true;
                                pbPMCChart.Visible = true;
                                pbChart.Visible = true;

                                lblInspectionCharCountHdr.Visible = true;
                                lbllnspectionCharCountData.Visible = true;

                                //chkMasterSize.Visible = true; //Comment on 14/07/23

                                //add on 22/06/23
                                pbPartImage.Visible = true;
                                pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                                pnlChartDatatable.Width = 984;
                                pnlChartDatatable.Height = 487;

                                flowLayoutPanelChar.Visible = true;
                                //add on 22/06/23
                            }
                            //Add on 22/06/23
                            PopulateChar();
                            //26/06/23
                        }
                    }

                    if (i > 0 && button1.Text != "" && button2.Text == "")//&& Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)
                    {
                        button2.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
                        button2.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

                        if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
                        {
                            button2.BackColor = Color.LightBlue;

                            currentmachineID = Convert.ToInt32(button2.Tag);
                            OnLoadLogic();
                            //dsFinalTemplateQueueList = GetTemplate_Queue_List();

                            //if (dsFinalTemplateQueueList.Tables[1].Rows.Count > 0)
                            //{
                            //    if (dtQueueList != null)
                            //    {
                            //        dtQueueList.Rows.Clear();
                            //    }

                            //    dtQueueList = dsFinalTemplateQueueList.Tables[1];
                            //}
                            //dsInspectionHdrData = GetInspectionHdrData();
                            if (dtQueueList != null)
                            {
                                dtQueueList.Rows.Clear();


                                btnKeyboard.Visible = true;
                                lblPartNoHeading.Visible = true;
                                lblPartNo.Visible = true;
                                lblCharacteristicHeading.Visible = true;
                                lblCharacteristic.Visible = true;
                                lblGaugeSourceHeading.Visible = true;
                                lblGaugeSource.Visible = true;
                                lblCPHdr.Visible = true;
                                lblCPData.Visible = true;
                                lblCPKHdr.Visible = true;
                                lblCPKData.Visible = true;

                                //Aamir - 03/10/22
                                lblCPMHdr.Visible = true;
                                lblCPMData.Visible = true;
                                lblCPKMHdr.Visible = true;
                                lblCPKMData.Visible = true;
                                //Aamir - 03/10/22

                                pbDatatable.Visible = true;
                                pbPMCChart.Visible = true;
                                pbChart.Visible = true;

                                lblInspectionCharCountHdr.Visible = true;
                                lbllnspectionCharCountData.Visible = true;

                                //chkMasterSize.Visible = true; //Comment on 14/07/23

                                //add on 22/06/23
                                pbPartImage.Visible = true;
                                pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                                pnlChartDatatable.Width = 984;
                                pnlChartDatatable.Height = 487;

                                flowLayoutPanelChar.Visible = true;
                                //add on 22/06/23
                            }
                            //Add on 22/06/23
                            PopulateChar();
                            //26/06/23
                        }

                    }

                    if (i > 1 && button2.Text != "" && button3.Text == "")//&& Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)
                    {
                        button3.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
                        button3.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

                        if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
                        {
                            button3.BackColor = Color.LightBlue;

                            ////26/06/23
                            currentmachineID = Convert.ToInt32(button3.Tag);
                            OnLoadLogic();
                            //dsFinalTemplateQueueList = GetTemplate_Queue_List();

                            //if (dsFinalTemplateQueueList.Tables[1].Rows.Count > 0)
                            //{
                            //    if (dtQueueList != null)
                            //    {
                            //        dtQueueList.Rows.Clear();
                            //    }

                            //    dtQueueList = dsFinalTemplateQueueList.Tables[1];
                            //}
                            //dsInspectionHdrData = GetInspectionHdrData();


                            if (dtQueueList != null)
                            {
                                dtQueueList.Rows.Clear();


                                btnKeyboard.Visible = true;
                                lblPartNoHeading.Visible = true;
                                lblPartNo.Visible = true;
                                lblCharacteristicHeading.Visible = true;
                                lblCharacteristic.Visible = true;
                                lblGaugeSourceHeading.Visible = true;
                                lblGaugeSource.Visible = true;
                                lblCPHdr.Visible = true;
                                lblCPData.Visible = true;
                                lblCPKHdr.Visible = true;
                                lblCPKData.Visible = true;

                                //Aamir - 03/10/22
                                lblCPMHdr.Visible = true;
                                lblCPMData.Visible = true;
                                lblCPKMHdr.Visible = true;
                                lblCPKMData.Visible = true;
                                //Aamir - 03/10/22

                                pbDatatable.Visible = true;
                                pbPMCChart.Visible = true;
                                pbChart.Visible = true;

                                lblInspectionCharCountHdr.Visible = true;
                                lbllnspectionCharCountData.Visible = true;

                                //chkMasterSize.Visible = true; //Comment on 14/07/23

                                //add on 22/06/23
                                pbPartImage.Visible = true;
                                pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                                pnlChartDatatable.Width = 984;
                                pnlChartDatatable.Height = 487;

                                flowLayoutPanelChar.Visible = true;

                                //add on 22/06/23
                            }
                            //Add on 22/06/23
                            PopulateChar();
                            //26/06/23
                        }
                    }
                    if (i > 2 && button2.Text != "" && button3.Text != "" && button4.Text == "")// && Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)
                    {
                        button4.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
                        button4.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

                        if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
                        {
                            button4.BackColor = Color.LightBlue;

                            currentmachineID = Convert.ToInt32(button4.Tag);
                            OnLoadLogic();
                            //dsFinalTemplateQueueList = GetTemplate_Queue_List();

                            //if (dsFinalTemplateQueueList.Tables[1].Rows.Count > 0)
                            //{
                            //    if (dtQueueList != null)
                            //    {
                            //        dtQueueList.Rows.Clear();
                            //    }

                            //    dtQueueList = dsFinalTemplateQueueList.Tables[1];
                            //}
                            //dsInspectionHdrData = GetInspectionHdrData();
                            if (dtQueueList != null)
                            {
                                dtQueueList.Rows.Clear();


                                btnKeyboard.Visible = true;
                                lblPartNoHeading.Visible = true;
                                lblPartNo.Visible = true;
                                lblCharacteristicHeading.Visible = true;
                                lblCharacteristic.Visible = true;
                                lblGaugeSourceHeading.Visible = true;
                                lblGaugeSource.Visible = true;
                                lblCPHdr.Visible = true;
                                lblCPData.Visible = true;
                                lblCPKHdr.Visible = true;
                                lblCPKData.Visible = true;

                                //Aamir - 03/10/22
                                lblCPMHdr.Visible = true;
                                lblCPMData.Visible = true;
                                lblCPKMHdr.Visible = true;
                                lblCPKMData.Visible = true;
                                //Aamir - 03/10/22

                                pbDatatable.Visible = true;
                                pbPMCChart.Visible = true;
                                pbChart.Visible = true;

                                lblInspectionCharCountHdr.Visible = true;
                                lbllnspectionCharCountData.Visible = true;

                                //chkMasterSize.Visible = true;  //Comment on 14/07/23

                                //add on 22/06/23
                                pbPartImage.Visible = true;
                                pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                                pnlChartDatatable.Width = 984;
                                pnlChartDatatable.Height = 487;

                                flowLayoutPanelChar.Visible = true;
                                //add on 22/06/23
                            }
                            //Add on 22/06/23
                            PopulateChar();
                            //26/06/23
                        }
                    }
                }
            }

            //for (int i = 0; i < dsStationMachineList.Tables[0].Rows.Count; i++)
            //{
            //    if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1)
            //    {
            //        //26/06/23
            //        //currentmachineID = Convert.ToInt32(button3.Tag);
            //        OnLoadLogic();
            //        //dsFinalTemplateQueueList = GetTemplate_Queue_List();

            //        //if (dsFinalTemplateQueueList.Tables[1].Rows.Count > 0)
            //        //{
            //        //    if (dtQueueList != null)
            //        //    {
            //        //        dtQueueList.Rows.Clear();
            //        //    }

            //        //    dtQueueList = dsFinalTemplateQueueList.Tables[1];
            //        //}
            //        //dsInspectionHdrData = GetInspectionHdrData();
            //        if (dtQueueList != null)
            //        {
            //            dtQueueList.Rows.Clear();


            //            btnKeyboard.Visible = true;
            //            lblPartNoHeading.Visible = true;
            //            lblPartNo.Visible = true;
            //            lblCharacteristicHeading.Visible = true;
            //            lblCharacteristic.Visible = true;
            //            lblGaugeSourceHeading.Visible = true;
            //            lblGaugeSource.Visible = true;
            //            lblCPHdr.Visible = true;
            //            lblCPData.Visible = true;
            //            lblCPKHdr.Visible = true;
            //            lblCPKData.Visible = true;

            //            //Aamir - 03/10/22
            //            lblCPMHdr.Visible = true;
            //            lblCPMData.Visible = true;
            //            lblCPKMHdr.Visible = true;
            //            lblCPKMData.Visible = true;
            //            //Aamir - 03/10/22

            //            pbDatatable.Visible = true;
            //            pbPMCChart.Visible = true;
            //            pbChart.Visible = true;

            //            lblInspectionCharCountHdr.Visible = true;
            //            lbllnspectionCharCountData.Visible = true;

            //            chkMasterSize.Visible = true;

            //            //add on 22/06/23
            //            pbPartImage.Visible = true;
            //            pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
            //            pnlChartDatatable.Width = 984;
            //            pnlChartDatatable.Height = 487;

            //            flowLayoutPanelChar.Visible = true;
            //            //add on 22/06/23
            //        }
            //        //Add on 22/06/23
            //        PopulateChar();
            //        //26/06/23
            //    }
            //}
            //15/06/23
            if (button1.Text != "")
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
            if (button2.Text != "")
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }
            if (button3.Text != "")
            {
                button3.Visible = true;
            }
            else
            {
                button3.Visible = false;
            }
            if (button4.Text != "")
            {
                button4.Visible = true;
            }
            else
            {
                button4.Visible = false;
            }
            //15/06/23
        }
        private void OnLoadLogic()
    {
         dgvDatatable.Visible = false; 
         this.ActiveControl = flowLayoutPanelChar; //TODO Aamir - 12/09/22

        flowLayoutPanelChar.Controls.Clear();
        flowLayoutPanelTemplate.Controls.Clear();
        flowLayoutPanelQueue.Controls.Clear();

        lblPartNo.Text = "";
        lblCharacteristic.Text = "";
        lblGaugeSource.Text = "";
        pbPartImage.Image = SPC_KDL.Properties.Resources.noimageavailabe_image; //null

        lblCPData.Text = "";
        lblCPKData.Text = "";

        //Aamir - 03/10/2022
        lblCPMData.Text = "";
        lblCPKMData.Text = "";
        //Aamir - 03/10/2022

            dsFinalTemplateQueueList = GetTemplate_Queue_List();

        if (dsFinalTemplateQueueList.Tables[0].Rows.Count > 0)
        {
            if (dtTempList != null)
            {
                dtTempList.Rows.Clear();
            }

            dtTempList = dsFinalTemplateQueueList.Tables[0];
        }
        if (dsFinalTemplateQueueList.Tables[1].Rows.Count > 0)
        {
            if (dtQueueList != null)
            {
                dtQueueList.Rows.Clear();
            }
               
                dtQueueList = dsFinalTemplateQueueList.Tables[1];
        }

        else
        {
            if (dtQueueList != null)
            {
                dtQueueList.Rows.Clear();


                    btnKeyboard.Visible = true;
                    lblPartNoHeading.Visible = true;
                    lblPartNo.Visible = true;
                    lblCharacteristicHeading.Visible = true;
                    lblCharacteristic.Visible = true;
                    lblGaugeSourceHeading.Visible = true;
                    lblGaugeSource.Visible = true;
                    lblCPHdr.Visible = true;
                    lblCPData.Visible = true;
                    lblCPKHdr.Visible = true;
                    lblCPKData.Visible = true;

                    //Aamir - 03/10/22
                    lblCPMHdr.Visible = true;
                    lblCPMData.Visible = true;
                    lblCPKMHdr.Visible = true;
                    lblCPKMData.Visible = true;
                    //Aamir - 03/10/22

                    pbDatatable.Visible = true;
                    pbPMCChart.Visible = true;
                    pbChart.Visible = true;

                    lblInspectionCharCountHdr.Visible = true;
                    lbllnspectionCharCountData.Visible = true;

                    //pnlChartDatatable.Width = 992;
                    //pnlChartDatatable.Height = 487;

                    //dgvDatatable.Width = 992;
                    //dgvDatatable.Height = 487;
                    //  lblNothingPendingQueue.Visible = false; 
                }
            else
                {
                    lblQueueCount.Text = "0";

                    btnKeyboard.Visible = false;
                    lblPartNoHeading.Visible = false;
                    lblPartNo.Visible = false;
                    lblCharacteristicHeading.Visible = false;
                    lblCharacteristic.Visible = false;
                    lblGaugeSourceHeading.Visible = false;
                    lblGaugeSource.Visible = false;
                    lblCPHdr.Visible = false;
                    lblCPData.Visible = false;
                    lblCPKHdr.Visible = false;
                    lblCPKData.Visible = false;

                    //Aamir - 03/10/2022
                    lblCPMHdr.Visible = false;
                    lblCPMData.Visible = false;
                    lblCPKMHdr.Visible = false;
                    lblCPKMData.Visible = false;
                    //Aamir - 03/10/2022

                    pbDatatable.Visible = false;
                    pbPMCChart.Visible = false;
                    pbChart.Visible = false;

                    lblInspectionCharCountHdr.Visible = false;
                    lbllnspectionCharCountData.Visible = false;

                    //chkMasterSize.Visible = false; //Comment on 14/07/23 //add on 22/06/23

                    //comment on 22/06/23<<
                    //pnlChartDatatable.Width  =  1613;
                    //pnlChartDatatable.Height = 888;

                    //pnlChartDatatable.Location = new System.Drawing.Point(292,53);

                    //dgvDatatable.Width = 1613;
                    //dgvDatatable.Height = 888;
                    //>>comment on 22/06/23

                    //  lblNothingPendingQueue.Visible = true;

                    //Add on 22/06/23<<
                    pnlChartDatatable.Width = 1605;
                    pnlChartDatatable.Height = 892;

                    pnlChartDatatable.Location = new System.Drawing.Point(292, 132);

                    dgvDatatable.Width = 1605;
                    dgvDatatable.Height = 892;
                    //>> Add on 22/06/23

                }
        }

        populateTemplates(); //TODO
        PopulateQueue();

            //comment on 28/06/23 start<<
            //dsStationMachineList = GetStationMachineList();//14/06/23


            //    for (int i = 0; i < dsStationMachineList.Tables[0].Rows.Count; i++) //15/06/23
            //    {
            //        //if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0) //comment on 19/06/23
            //        {
            //            if (button1.Text == "")//&& Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)//comment on 19/06/23
            //            {
            //                button1.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
            //                button1.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

            //                if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
            //                {
            //                    button1.BackColor = Color.LightBlue;

            //                    currentmachineID = Convert.ToInt32(button1.Tag);
            //                    OnLoadLogic();

            //                    if (dtQueueList != null)
            //                    {
            //                        dtQueueList.Rows.Clear();


            //                        btnKeyboard.Visible = true;
            //                        lblPartNoHeading.Visible = true;
            //                        lblPartNo.Visible = true;
            //                        lblCharacteristicHeading.Visible = true;
            //                        lblCharacteristic.Visible = true;
            //                        lblGaugeSourceHeading.Visible = true;
            //                        lblGaugeSource.Visible = true;
            //                        lblCPHdr.Visible = true;
            //                        lblCPData.Visible = true;
            //                        lblCPKHdr.Visible = true;
            //                        lblCPKData.Visible = true;

            //                        //Aamir - 03/10/22
            //                        lblCPMHdr.Visible = true;
            //                        lblCPMData.Visible = true;
            //                        lblCPKMHdr.Visible = true;
            //                        lblCPKMData.Visible = true;
            //                        //Aamir - 03/10/22

            //                        pbDatatable.Visible = true;
            //                        pbPMCChart.Visible = true;
            //                        pbChart.Visible = true;

            //                        lblInspectionCharCountHdr.Visible = true;
            //                        lbllnspectionCharCountData.Visible = true;

            //                        chkMasterSize.Visible = true;

            //                        //add on 22/06/23
            //                        pbPartImage.Visible = true;
            //                        pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
            //                        pnlChartDatatable.Width = 984;
            //                        pnlChartDatatable.Height = 487;

            //                        flowLayoutPanelChar.Visible = true;
            //                        //add on 22/06/23
            //                    }
            //                    //Add on 22/06/23
            //                    PopulateChar();
            //                    //26/06/23
            //                }
            //            }

            //            if (i > 0 && button1.Text != "" && button2.Text == "" )//&& Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)
            //            {
            //                button2.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
            //                button2.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

            //                if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
            //                {
            //                    button2.BackColor = Color.LightBlue;

            //                    currentmachineID = Convert.ToInt32(button2.Tag);
            //                    OnLoadLogic();

            //                    if (dtQueueList != null)
            //                    {
            //                        dtQueueList.Rows.Clear();


            //                        btnKeyboard.Visible = true;
            //                        lblPartNoHeading.Visible = true;
            //                        lblPartNo.Visible = true;
            //                        lblCharacteristicHeading.Visible = true;
            //                        lblCharacteristic.Visible = true;
            //                        lblGaugeSourceHeading.Visible = true;
            //                        lblGaugeSource.Visible = true;
            //                        lblCPHdr.Visible = true;
            //                        lblCPData.Visible = true;
            //                        lblCPKHdr.Visible = true;
            //                        lblCPKData.Visible = true;

            //                        //Aamir - 03/10/22
            //                        lblCPMHdr.Visible = true;
            //                        lblCPMData.Visible = true;
            //                        lblCPKMHdr.Visible = true;
            //                        lblCPKMData.Visible = true;
            //                        //Aamir - 03/10/22

            //                        pbDatatable.Visible = true;
            //                        pbPMCChart.Visible = true;
            //                        pbChart.Visible = true;

            //                        lblInspectionCharCountHdr.Visible = true;
            //                        lbllnspectionCharCountData.Visible = true;

            //                        chkMasterSize.Visible = true;

            //                        //add on 22/06/23
            //                        pbPartImage.Visible = true;
            //                        pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
            //                        pnlChartDatatable.Width = 984;
            //                        pnlChartDatatable.Height = 487;

            //                        flowLayoutPanelChar.Visible = true;
            //                        //add on 22/06/23
            //                    }
            //                    //Add on 22/06/23
            //                    PopulateChar();
            //                    //26/06/23
            //                }

            //            }

            //            if (i > 1 && button2.Text != "" && button3.Text == "" )//&& Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)
            //            {
            //                button3.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
            //                button3.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

            //                if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
            //                {
            //                    button3.BackColor = Color.LightBlue;

            //                    ////26/06/23
            //                    currentmachineID = Convert.ToInt32(button3.Tag);
            //                    OnLoadLogic();

            //                    if (dtQueueList != null)
            //                    {
            //                        dtQueueList.Rows.Clear();


            //                        btnKeyboard.Visible = true;
            //                        lblPartNoHeading.Visible = true;
            //                        lblPartNo.Visible = true;
            //                        lblCharacteristicHeading.Visible = true;
            //                        lblCharacteristic.Visible = true;
            //                        lblGaugeSourceHeading.Visible = true;
            //                        lblGaugeSource.Visible = true;
            //                        lblCPHdr.Visible = true;
            //                        lblCPData.Visible = true;
            //                        lblCPKHdr.Visible = true;
            //                        lblCPKData.Visible = true;

            //                        //Aamir - 03/10/22
            //                        lblCPMHdr.Visible = true;
            //                        lblCPMData.Visible = true;
            //                        lblCPKMHdr.Visible = true;
            //                        lblCPKMData.Visible = true;
            //                        //Aamir - 03/10/22

            //                        pbDatatable.Visible = true;
            //                        pbPMCChart.Visible = true;
            //                        pbChart.Visible = true;

            //                        lblInspectionCharCountHdr.Visible = true;
            //                        lbllnspectionCharCountData.Visible = true;

            //                        chkMasterSize.Visible = true;

            //                        //add on 22/06/23
            //                        pbPartImage.Visible = true;
            //                        pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
            //                        pnlChartDatatable.Width = 984;
            //                        pnlChartDatatable.Height = 487;

            //                        flowLayoutPanelChar.Visible = true;

            //                        //add on 22/06/23
            //                    }
            //                    //Add on 22/06/23
            //                    PopulateChar();
            //                    //26/06/23
            //                }
            //            }
            //            if (i > 2 && button2.Text != "" && button3.Text != "" && button4.Text == "")// && Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 0)
            //            {
            //                button4.Text = dsStationMachineList.Tables[0].Rows[i]["MachineName"].ToString();
            //                button4.Tag = dsStationMachineList.Tables[0].Rows[i]["MachineID"].ToString();

            //                if (Convert.ToInt32(dsStationMachineList.Tables[0].Rows[i]["IsDefault"].ToString()) == 1) //add on 19/06/23
            //                {
            //                    button4.BackColor = Color.LightBlue;

            //                    currentmachineID = Convert.ToInt32(button4.Tag);
            //                    OnLoadLogic();

            //                    if (dtQueueList != null)
            //                    {
            //                        dtQueueList.Rows.Clear();


            //                        btnKeyboard.Visible = true;
            //                        lblPartNoHeading.Visible = true;
            //                        lblPartNo.Visible = true;
            //                        lblCharacteristicHeading.Visible = true;
            //                        lblCharacteristic.Visible = true;
            //                        lblGaugeSourceHeading.Visible = true;
            //                        lblGaugeSource.Visible = true;
            //                        lblCPHdr.Visible = true;
            //                        lblCPData.Visible = true;
            //                        lblCPKHdr.Visible = true;
            //                        lblCPKData.Visible = true;

            //                        //Aamir - 03/10/22
            //                        lblCPMHdr.Visible = true;
            //                        lblCPMData.Visible = true;
            //                        lblCPKMHdr.Visible = true;
            //                        lblCPKMData.Visible = true;
            //                        //Aamir - 03/10/22

            //                        pbDatatable.Visible = true;
            //                        pbPMCChart.Visible = true;
            //                        pbChart.Visible = true;

            //                        lblInspectionCharCountHdr.Visible = true;
            //                        lbllnspectionCharCountData.Visible = true;

            //                        chkMasterSize.Visible = true;

            //                        //add on 22/06/23
            //                        pbPartImage.Visible = true;
            //                        pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
            //                        pnlChartDatatable.Width = 984;
            //                        pnlChartDatatable.Height = 487;

            //                        flowLayoutPanelChar.Visible = true;
            //                        //add on 22/06/23
            //                    }
            //                    //Add on 22/06/23
            //                    PopulateChar();
            //                    //26/06/23
            //                }
            //            }
            //        }
            //    }


            //        //15/06/23
            //        if (button1.Text != "")
            //    {
            //        button1.Visible = true;
            //    }
            //    else
            //    {
            //        button1.Visible = false;
            //    }
            //    if (button2.Text != "")
            //    {
            //        button2.Visible = true;
            //    }
            //    else
            //    {
            //        button2.Visible = false;
            //    }
            //    if (button3.Text != "")
            //    {
            //        button3.Visible = true;
            //    }
            //    else
            //    {
            //        button3.Visible = false;
            //    }
            //    if (button4.Text != "")
            //    {
            //        button4.Visible = true;
            //    }
            //    else
            //    {
            //        button4.Visible = false;
            //    }
            //    //15/06/23
            //comment on 28/06/23 End>>


            dsInspectionHdrData = GetInspectionHdrData();

        if (dsInspectionHdrData.Tables[0].Rows.Count > 0)
        {
            partsScanned = dsInspectionHdrData.Tables[0].Rows[0]["DayPartScanned"].ToString();
            partsShiftScanned = dsInspectionHdrData.Tables[0].Rows[0]["ShiftPartScanned"].ToString();
            Shift = dsInspectionHdrData.Tables[0].Rows[0]["Shift"].ToString();
            lastSyncedDate = dsInspectionHdrData.Tables[0].Rows[0]["LAstSyncDate"].ToString();
            StationName = dsInspectionHdrData.Tables[0].Rows[0]["StationName"].ToString();
        }
            //  MDISPC mdiform = new MDISPC();
            var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

            if (partsScanned != "")
            {
                   mdiform.lblDayPartsScannedData.Text = partsScanned;
                //  ((MDISPC)this.MdiParent).lblPartsScannedData.Text = partsScanned;  
                
            }
            if (partsShiftScanned != "")
            {
                mdiform.lblShiftsPartsScannedData.Text = partsShiftScanned;
                //  ((MDISPC)this.MdiParent).lblPartsScannedData.Text = partsScanned;  

            }
            if (Shift != "")
            {
                  mdiform.lblShiftData.Text = Shift;  
                //((MDISPC)this.MdiParent).lblShiftData.Text = Shift;
            }
            if(lastSyncedDate != "")
            {
                mdiform.lblLastSyncDateData.Text = lastSyncedDate;  
               // ((MDISPC)this.MdiParent).lblLastSyncDateData.Text = lastSyncedDate;
            }
            if (StationName != "")
            {
                //((MDISPC)this.MdiParent).lblStation.Text    = StationName;
                mdiform.lblStation.Text = StationName; 
            }

        if (dsInspectionHdrData.Tables[1].Rows.Count > 0)
        {
            if (dtInspectionHdr2 != null)
            {
                dtInspectionHdr2.Rows.Clear();
            }

            dtInspectionHdr2 = dsInspectionHdrData.Tables[1];

          //  PopulateChar(); //TODO
        }

        else
        {
                if(dtInspectionHdr2 != null)
            {
                dtInspectionHdr2.Rows.Clear();
            }
        }
        
    }
        private void btnKeyboard_Click(object sender, EventArgs e)
    {
        frmKeyboard frmKeyboard = new frmKeyboard(currentModel, currentChar, currentLTL, currentTarget, currentUTL, currentSrNo);
            
        int srNo1 = currentSrNo;

            if (srNo1 == 0)
            {
                MessageBox.Show("No data found for Inspection", "SPC");
            }
            else
            {
                if (flowLayoutPanelChar.Controls.Count > 0)
                {
                    ListChar listChar1 = (ListChar)flowLayoutPanelChar.Controls.Find("ListChar", true)[srNo1 - 1];

                    // Attribute Start         
                    if (listChar1.CharType == "Attribute")
                    {
                        string Model = listChar1.ModelNo;
                        string Part = listChar1.PartNo;
                        string Attribute = listChar1.Char;

                        frmAttributeInput frmAttributeInput = new frmAttributeInput(Model, Part, Attribute);

                        var result = frmAttributeInput.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            string defect = frmAttributeInput.ReturnValDefect;
                            string readingAttribute = "";
                            if (defect == "Pass")
                            {
                                readingAttribute = "1";
                                listChar1.txtCurrentReading.Text = defect;

                                listChar1.BackColor = Color.LimeGreen;

                                //Add on 29/06/23
                                SqlParameter outparam_1 = new SqlParameter();
                                outparam_1.ParameterName = "@Msg";
                                outparam_1.SqlDbType = SqlDbType.VarChar;
                                outparam_1.Size = 500;
                                outparam_1.Direction = ParameterDirection.Output;
                                //Add on 29/06/23


                                //Update Inspection data here for the current characteristic
                                SqlParameter[] parameters = //TODO
                                    {
                        new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                        new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                        new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(listChar1.CharID)},
                        new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = listChar1.PartNo},
                        new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(readingAttribute)}, //TODO
                        new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                        outparam_1, //Add on 29/06/23
                    };

                                //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);

                                var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                if (msg == "")//Add on 30/06/23
                                {

                                    mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Reading saved for - " + listChar1.Char;

                                    if (charCount != listChar1.CurrentCharCount)
                                    {
                                        this.SelectNextControl(listChar1.txtCurrentReading, true, true, true, true);
                                    }
                                    else
                                    {
                                        frmAttributeInput frmAttribute = new frmAttributeInput(null, null, null);
                                        frmAttribute.Close();

                                        frmKeyboard frmKeyboard1 = new frmKeyboard(null, null, null, null, null, 0);
                                        frmKeyboard1.Close();
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + listChar1.PartNo, "Info", buttons);
                                        if (result1 == DialogResult.OK)
                                        {
                                            OnLoadLogic();
                                            PopulateChar();
                                        }
                                    }
                                }//Add on 30/06/23
                                else //30/06/23
                                {
                                    listChar1.BackColor = Color.Blue;
                                    listChar1.txtCurrentReading.Focus();
                                    return;//30/06/23
                                }


                            }
                            else if (defect == "Fail")
                            {
                                readingAttribute = "0";
                                listChar1.txtCurrentReading.Text = defect;

                                listChar1.BackColor = Color.Red;

                                //Add on 29/06/23
                                SqlParameter outparam_1 = new SqlParameter();
                                outparam_1.ParameterName = "@Msg";
                                outparam_1.SqlDbType = SqlDbType.VarChar;
                                outparam_1.Size = 500;
                                outparam_1.Direction = ParameterDirection.Output;
                                //Add on 29/06/23

                                //Update Inspection data here for the current characteristic
                                SqlParameter[] parameters = //TODO
                                    {
                        new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                        new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                        new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(listChar1.CharID)},
                        new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = listChar1.PartNo},
                        new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(readingAttribute)}, //TODO
                        new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                        outparam_1, //Add on 03/07/23
                    };

                                //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);

                                var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                if (msg == "")
                                {

                                    mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                    mdiform.toolStripStatusLabel.Text = "Reading saved for - " + listChar1.Char;

                                    if (charCount != listChar1.CurrentCharCount)
                                    {
                                        this.SelectNextControl(listChar1.txtCurrentReading, true, true, true, true);
                                    }
                                    else
                                    {
                                        frmAttributeInput frmAttribute = new frmAttributeInput(null, null, null); //TODO - Aamir - 09/08/22
                                        frmAttribute.Close();

                                        frmKeyboard.Close();

                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + listChar1.PartNo, "Info", buttons);
                                        if (result1 == DialogResult.OK)
                                        {
                                            OnLoadLogic();
                                            PopulateChar();
                                        }


                                    }
                                }

                            } //03/07/23
                            else //03/07/23
                            {
                                listChar1.BackColor = Color.Blue;
                                listChar1.txtCurrentReading.Focus();
                                return;//03/07/23
                            }


                        }

                        else
                        {
                            frmAttributeInput.Close();  
                        }
                    }
                    // Attribute End
                    else  //Keyboard
                    {
                        var result = frmKeyboard.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            string reading = frmKeyboard.manualReading;

                            if (reading != null)
                            {
                                int srNo = frmKeyboard.currentSrNo;

                                ListChar listChar = (ListChar)flowLayoutPanelChar.Controls.Find("ListChar", true)[srNo - 1];
                                listChar.BackColor = Color.LimeGreen;
                                listChar.Leave -= new EventHandler(this.UserControlForm_Leave); //TODO
                                listChar.txtCurrentReading.Text = reading;  //TODO - Aamir

                                //Add on 30/05/23
                                if (frmKeyboard.chkMasterSize.Checked == true)
                                {
                                    string MS = listChar.MasterSize;
                                    int formula = listChar.Formula; 

                                    decimal read= Convert.ToDecimal(reading.ToString()) / formula;
                                    //reading = reading / formula;
                                    reading = read.ToString();

                                    //reading = MS + read;
                                    decimal read2 = Convert.ToDecimal(MS.ToString()) + read;
                                    reading = read2.ToString();
                                    listChar.txtCurrentReading.Text = reading;

                                }
                                //Add on 30/05/23

                                // listChar.Leave += new EventHandler(this.UserControlForm_Leave); //TODO

                                //Convert.ToDecimal(obj.LTL.Substring(obj.LTL.LastIndexOf (':') + 1)) //TODO - For Reference

                                //Check for event - 06/08/2022 - start
                                if (Convert.ToDecimal(reading) < Convert.ToDecimal(listChar.LTL.Substring(listChar.LTL.LastIndexOf(':') + 1))) //LTL = LSL (Red Zone)
                                {
                                    listChar.BackColor = Color.Red;

                                    frmEventSelection frmEventSelection = new frmEventSelection();
                                    var result1 = frmEventSelection.ShowDialog();

                                    if (result1 == DialogResult.OK)
                                    {
                                        currentEventID = frmEventSelection.EventID;
                                        char pnlBackColor = ' ';

                                        if (listChar.BackColor == Color.Red)
                                        {
                                            pnlBackColor = 'R';//TODO
                                        }
                                        if (listChar.BackColor == Color.Yellow)
                                        {
                                            pnlBackColor = 'Y';//TODO
                                        }

                                        //Add on 29/06/23
                                        SqlParameter outparam_1 = new SqlParameter();
                                        outparam_1.ParameterName = "@Msg";
                                        outparam_1.SqlDbType = SqlDbType.VarChar;
                                        outparam_1.Size = 500;
                                        outparam_1.Direction = ParameterDirection.Output;
                                        //Add on 29/06/23

                                        SqlParameter[] parameters = //TODO
                                           {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(listChar.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = listChar.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                            new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID }, //TODO
                                            new SqlParameter { ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor }, //TODO
                                            outparam_1, //Add on 29/06/23
                                           };

                                        //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                        CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                        frmEventSelection.Close();

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                        string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                        if (msg == "")//Add on 30/06/23
                                        {
                                            mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                            mdiform.toolStripStatusLabel.Text = "Reading saved for - " + listChar.Char;

                                            //TODO - Aamir - 07/08/2022
                                            if (listChar.InspectionStatusID == 0)
                                            {
                                                // 12 / 08 / 22
                                                //  this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true);
                                                if (charCount != listChar.CurrentCharCount)
                                                {
                                                    this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true); //TODO 11/08/2022
                                                   // btnKeyboard.PerformClick(); // Aamir - 15/09/2022
                                                }
                                                else
                                                {
                                                    frmKeyboard frmKeyboard1 = new frmKeyboard(null, null, null, null, null, 0); //TODO - Aamir - 09/08/22
                                                    frmKeyboard1.Close();
                                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                                                    DialogResult result2 = MessageBox.Show("Inspection completed for Part No." + listChar.PartNo, "Info", buttons);
                                                    if (result2 == DialogResult.OK)
                                                    {
                                                        OnLoadLogic();
                                                        PopulateChar();
                                                    }
                                                }
                                                //TODO - Aamir - 07/08/2022
                                            }
                                        }  //Add on 30/06/23
                                        else //03/07/23
                                        {
                                            MessageBox.Show("Contineous 7 Reading on One side");
                                            listChar.BackColor = Color.Blue;
                                            listChar.txtCurrentReading.Focus();
                                            return;//30/06/23
                                        }

                                    }

                                    else
                                    {
                                        listChar.BackColor = Color.Blue;
                                        listChar.txtCurrentReading.Focus();

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                        mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                        mdiform.toolStripStatusLabel.Text = "Retake the reading for " + listChar.Char;

                                    }

                                }
                                else if (Convert.ToDecimal(reading) > Convert.ToDecimal(listChar.UTL.Substring(listChar.UTL.LastIndexOf(':') + 1)))
                                {
                                    listChar.BackColor = Color.Red;

                                    frmEventSelection frmEventSelection = new frmEventSelection();
                                    var result1 = frmEventSelection.ShowDialog();

                                    if (result1 == DialogResult.OK)
                                    {
                                        char pnlBackColor = ' ';

                                        if (listChar.BackColor == Color.Red)
                                        {
                                            pnlBackColor = 'R';//TODO
                                        }
                                        if (listChar.BackColor == Color.Yellow)
                                        {
                                            pnlBackColor = 'Y';//TODO
                                        }
                                        currentEventID = frmEventSelection.EventID;

                                        //Add on 29/06/23
                                        SqlParameter outparam_1 = new SqlParameter();
                                        outparam_1.ParameterName = "@Msg";
                                        outparam_1.SqlDbType = SqlDbType.VarChar;
                                        outparam_1.Size = 500;
                                        outparam_1.Direction = ParameterDirection.Output;
                                        //Add on 29/06/23

                                        SqlParameter[] parameters = //TODO
                                           {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(listChar.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = listChar.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                            new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID }, //TODO
                                            new SqlParameter{ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor},
                                            outparam_1, //Add on 29/06/23
                                            };

                                        //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                        CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                        frmEventSelection.Close();

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                        string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                        if (msg == "")//Add on 30/06/23
                                        {

                                            mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                            mdiform.toolStripStatusLabel.Text = "Reading saved for - " + listChar.Char;

                                            //TODO - Aamir - 07/08/2022

                                            // 12 / 08 / 22
                                            //  this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true);
                                            if (charCount != listChar.CurrentCharCount)
                                            {
                                                this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true); //TODO 11/08/2022
                                                btnKeyboard.PerformClick(); // Aamir - 15/09/2022 // Uncommented by Aamir - 03/04/2024
                                            }
                                            else
                                            {
                                                frmKeyboard frmKeyboard1 = new frmKeyboard(null, null, null, null, null, 0); //TODO - Aamir - 09/08/22
                                                frmKeyboard1.Close();
                                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                                DialogResult result2 = MessageBox.Show("Inspection completed for Part No." + listChar.PartNo, "Info", buttons);
                                                if (result2 == DialogResult.OK)
                                                {
                                                    OnLoadLogic();
                                                    PopulateChar();
                                                }
                                            }
                                        }  //Add on 30/06/23
                                        else //03/07/23
                                        {
                                            MessageBox.Show("Contineous 7 Reading on One side");
                                            listChar.BackColor = Color.Blue;
                                            listChar.txtCurrentReading.Focus();
                                            return;//30/06/23
                                        }

                                        //TODO - Aamir - 07/08/2022
                                    }

                                    else
                                    {
                                        listChar.BackColor = Color.Blue;
                                        // listChar.txtCurrentReading.Text = "";
                                        listChar.txtCurrentReading.Focus();

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                        mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                        mdiform.toolStripStatusLabel.Text = "Retake the reading for " + listChar.Char;

                                    }
                                }
                                else if (Convert.ToDecimal(reading) < Convert.ToDecimal(listChar.LPCL.Substring(listChar.LPCL.LastIndexOf(':') + 1)))
                                {
                                    listChar.BackColor = Color.Yellow; //Orange

                                    frmEventSelection frmEventSelection = new frmEventSelection();
                                    var result1 = frmEventSelection.ShowDialog();

                                    if (result1 == DialogResult.OK)
                                    {
                                        char pnlBackColor = ' ';

                                        if (listChar.BackColor == Color.Red)
                                        {
                                            pnlBackColor = 'R';//TODO
                                        }
                                        if (listChar.BackColor == Color.Yellow)
                                        {
                                            pnlBackColor = 'Y';//TODO
                                        }
                                        currentEventID = frmEventSelection.EventID;

                                        //Add on 29/06/23
                                        SqlParameter outparam_1 = new SqlParameter();
                                        outparam_1.ParameterName = "@Msg";
                                        outparam_1.SqlDbType = SqlDbType.VarChar;
                                        outparam_1.Size = 500;
                                        outparam_1.Direction = ParameterDirection.Output;
                                        //Add on 29/06/23

                                        SqlParameter[] parameters = //TODO
                                           {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(listChar.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = listChar.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                            new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID }, //TODO
                                            new SqlParameter{ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor},
                                            outparam_1, //Add on 29/06/23
                                      };

                                        //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                        CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                        frmEventSelection.Close();

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                        string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                        if (msg == "")//Add on 30/06/23
                                        {

                                            mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                            mdiform.toolStripStatusLabel.Text = "Reading saved for - " + listChar.Char;

                                            //TODO - Aamir - 07/08/2022

                                            // 12 / 08 / 22
                                            //  this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true);
                                            if (charCount != listChar.CurrentCharCount)
                                            {
                                                this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true); //TODO 11/08/2022
                                                btnKeyboard.PerformClick(); // Aamir - 15/09/2022 // Uncommented by Aamir - 03/04/2024
                                            }
                                            else
                                            {
                                                frmKeyboard frmKeyboard1 = new frmKeyboard(null, null, null, null, null, 0); //TODO - Aamir - 09/08/22
                                                frmKeyboard1.Close();
                                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                                DialogResult result2 = MessageBox.Show("Inspection completed for Part No." + listChar.PartNo, "Info", buttons);
                                                if (result2 == DialogResult.OK)
                                                {
                                                    OnLoadLogic();
                                                    PopulateChar();
                                                }
                                            }
                                        }  //Add on 30/06/23
                                        else //03/07/23
                                        {
                                            MessageBox.Show("Contineous 7 Reading on One side");
                                            listChar.BackColor = Color.Blue;
                                            listChar.txtCurrentReading.Focus();
                                            return;//30/06/23
                                        }


                                        //TODO - Aamir - 07/08/2022
                                    }

                                    else
                                    {
                                        listChar.BackColor = Color.Blue;
                                        listChar.txtCurrentReading.Focus();
                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                        mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                        mdiform.toolStripStatusLabel.Text = "Retake the reading for " + listChar.Char;

                                    }
                                }
                                else if (Convert.ToDecimal(reading) > Convert.ToDecimal(listChar.UPCL.Substring(listChar.UPCL.LastIndexOf(':') + 1)))
                                {
                                    listChar.BackColor = Color.Yellow; //Orange

                                    frmEventSelection frmEventSelection = new frmEventSelection();
                                    var result1 = frmEventSelection.ShowDialog();

                                    if (result1 == DialogResult.OK)
                                    {
                                        char pnlBackColor = ' ';

                                        if (listChar.BackColor == Color.Red)
                                        {
                                            pnlBackColor = 'R';//TODO
                                        }
                                        if (listChar.BackColor == Color.Yellow)
                                        {
                                            pnlBackColor = 'Y';//TODO
                                        }
                                        currentEventID = frmEventSelection.EventID;

                                        //Add on 29/06/23
                                        SqlParameter outparam_1 = new SqlParameter();
                                        outparam_1.ParameterName = "@Msg";
                                        outparam_1.SqlDbType = SqlDbType.VarChar;
                                        outparam_1.Size = 500;
                                        outparam_1.Direction = ParameterDirection.Output;
                                        //Add on 29/06/23
                                        SqlParameter[] parameters = //TODO
                                           {
                                            new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                                            new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                                            new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(listChar.CharID)},
                                            new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = listChar.PartNo},
                                            new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(reading)}, //TODO
                                            new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                                            new SqlParameter{ParameterName = "@EventID", SqlDbType = SqlDbType.Int, Value = currentEventID }, //TODO
                                            new SqlParameter{ParameterName = "@isZone", SqlDbType = SqlDbType.Char, Value = pnlBackColor },
                                            outparam_1,  //Add on 29/06/23
                                            };

                                        //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                        CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);
                                        frmEventSelection.Close();

                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                                        string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                        if (msg == "")//Add on 30/06/23
                                        {
                                            mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                            mdiform.toolStripStatusLabel.Text = "Reading saved for - " + listChar.Char;
                                            //TODO - Aamir - 07/08/2022

                                            //12/08/22
                                            //  this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true);
                                            if (charCount != listChar.CurrentCharCount)
                                            {
                                                this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true); //TODO 11/08/2022
                                                btnKeyboard.PerformClick(); // Aamir - 15/09/2022 // Uncommented by Aamir - 03/04/2024
                                            }
                                            else
                                            {
                                                frmKeyboard frmKeyboard1 = new frmKeyboard(null, null, null, null, null, 0); //TODO - Aamir - 09/08/22
                                                frmKeyboard1.Close();
                                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                                DialogResult result2 = MessageBox.Show("Inspection completed for Part No." + listChar.PartNo, "Info", buttons);
                                                if (result2 == DialogResult.OK)
                                                {
                                                    OnLoadLogic();
                                                    PopulateChar();
                                                }
                                            }
                                        }  //Add on 30/06/23
                                        else //03/07/23
                                        {
                                            MessageBox.Show("Contineous 7 Reading on One side");
                                            listChar.BackColor = Color.Blue;
                                            listChar.txtCurrentReading.Focus();
                                            return;//30/06/23
                                        }

                                        //TODO - Aamir - 07/08/2022
                                    }

                                    else
                                    {
                                        listChar.BackColor = Color.Blue;
                                        listChar.txtCurrentReading.Focus();
                                        var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                        mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                                        mdiform.toolStripStatusLabel.Text = "Retake the reading for " + listChar.Char;

                                    }
                                }

                                else
                                {
                                    //Add on 29/06/23
                                    SqlParameter outparam_1 = new SqlParameter();
                                    outparam_1.ParameterName = "@Msg";
                                    outparam_1.SqlDbType = SqlDbType.VarChar;
                                    outparam_1.Size = 500;
                                    outparam_1.Direction = ParameterDirection.Output;
                                    //Add on 29/06/23

                                    //Update Inspection data here for the current characteristic
                                    SqlParameter[] parameters = //TODO
                                    {
                        new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.BigInt, Value = Program.userID },
                        new SqlParameter{ParameterName = "@StationID", SqlDbType = SqlDbType.Int, Value = Program.stationID},
                        new SqlParameter{ParameterName = "@CharacteristicID", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(listChar.CharID)},
                        new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100 , Value = listChar.PartNo},
                        new SqlParameter{ParameterName = "@Reading", SqlDbType = SqlDbType.Decimal , Value =  Convert.ToDecimal(reading)}, //TODO
                        new SqlParameter{ParameterName = "@CreateVersion", SqlDbType = SqlDbType.VarChar,Size = 20, Value = "1.0.0.0" }, //TODO
                        outparam_1, //Add on 29/06/23

                             };

                                    //CommonBL.InsertData("spInsert_InspectionData", parameters);
                                    CommonBL.InsertData(StoredProcedure.InsertInspectionData, parameters);

                                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                                    string msg = outparam_1.Value.ToString(); // Add on 29/06/23

                                    if (msg == "")//Add on 30/06/23
                                    {
                                        mdiform.toolStripStatusLabel.ForeColor = Color.DarkGreen;  //Color.Green
                                        mdiform.toolStripStatusLabel.Text = "Reading saved for - " + listChar.Char;

                                        if (charCount != listChar.CurrentCharCount)
                                        {
                                            this.SelectNextControl(listChar.txtCurrentReading, true, true, true, true); //TODO 11/08/2022
                                             btnKeyboard.PerformClick(); // Aamir - 15/09/2022 // Uncommented by Aamir - 03/04/2024
                                        }
                                        else
                                        {
                                            frmKeyboard frmKeyboard1 = new frmKeyboard(null, null, null, null, null, 0); //TODO - Aamir - 09/08/22
                                            frmKeyboard1.Close();
                                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                                            DialogResult result1 = MessageBox.Show("Inspection completed for Part No." + listChar.PartNo, "Info", buttons);
                                            if (result1 == DialogResult.OK)
                                            {
                                                OnLoadLogic();
                                                PopulateChar();
                                            }
                                        }

                                    }  //Add on 30/06/23
                                    else //03/07/23
                                    {
                                       MessageBox.Show("Contineous 7 Reading on One side");
                                        listChar.BackColor = Color.Blue;
                                        listChar.txtCurrentReading.Focus();
                                        return;//30/06/23
                                    }

                                }
                            }

                        }

                    }
                }
            }

            // } //charCount != objCharCount //11/08/2022
            //else 
            //{
            //    frmKeyboard frmKeyboard1 = new frmKeyboard(null, null, null, null, null, 0); //TODO - Aamir - 09/08/22
            //    frmKeyboard1.Close();
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //        DialogResult result = MessageBox.Show("Inspection completed for Part No." + obj.PartNo, "Info", buttons);
            //    if (result == DialogResult.OK)
            //        {
            //            OnLoadLogic();
            //        }
            //}
        }
        public void Retake (int onlyCurrentChar)
        {

            if (flowLayoutPanelChar.Controls.Count > 0)
            {

                if (currentSrNo == 1)
                {
                    var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                    mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                    mdiform.toolStripStatusLabel.Text = "No previous characteristic to Retake...";

                    return;
                }

                ListChar listChar1 = (ListChar)flowLayoutPanelChar.Controls.Find("ListChar", true)[currentSrNo - 2];

                if (listChar1.txtCurrentReading.Text != "")
                {
                    //   frmRetake frmRetake = new frmRetake(currentModel, currentChar,  tempID, machID, currentPartNo, currentCharID, currentSrNo, onlyCurrentChar );
                    ListChar listChar0 = (ListChar)flowLayoutPanelChar.Controls.Find("ListChar", true)[currentSrNo - 1];

                    //listChar0.BackColor = Color.Orange;
                    //listChar1.BackColor = Color.Blue;
                    listChar1.txtCurrentReading.Focus();  //TODO

                    currentModel = listChar1.ModelNo;
                    currentChar = listChar1.Char;
                    currentLTL = listChar1.LTL;
                    currentTarget = listChar1.Target;
                    currentUTL = listChar1.UTL;
                    currentSrNo = listChar1.CurrentCharCount;

                    tempID = listChar1.TemplateID;
                    machID = listChar1.MachineID;
                    currentCharID = listChar1.CharID;

                    frmRetake frmRetake = new frmRetake(currentModel, currentChar, tempID, machID, currentPartNo, currentCharID, currentSrNo, onlyCurrentChar);

                    var result = frmRetake.ShowDialog();

                    if (result == DialogResult.Yes)
                    {
                        listChar0.BackColor = Color.Orange;
                        listChar1.BackColor = Color.Blue;

                        string Model = frmRetake.ModelRetake;
                        string Char = frmRetake.CharRetake;
                        int tempID = frmRetake.TempIDRetake;
                        int machID = frmRetake.MachIDRetake;
                        string Part = frmRetake.PartRetake;
                        int charID = Convert.ToInt32(frmRetake.CharIDRetake);
                        int srNo = frmRetake.srNoRetake;
                        int ifOnlyCurrentChar = frmRetake.onlyCurrentCharRetake;

                        if (ifOnlyCurrentChar == 1)
                        {
                            SqlParameter[] parameters =
                           {
                      new SqlParameter{ParameterName = "@Login_id", SqlDbType = SqlDbType.Int, Value = Program.userID },
                      new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int, Value = tempID},
                      new SqlParameter{ParameterName = "@MachineID", SqlDbType = SqlDbType.Int,  Value = machID},
                      new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100, Value = Part},
                      new SqlParameter{ParameterName = "@CharacterID", SqlDbType = SqlDbType.Int, Value = charID  },
                      };

                            //CommonBL.InsertData("Sp_RetakeDAta", parameters);
                            CommonBL.InsertData(StoredProcedure.RetakeData, parameters);

                            var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                            mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                            mdiform.toolStripStatusLabel.Text = "Take reading of  " + Char + "(previous)";
                        }

                        else
                        {
                            SqlParameter[] parameters =
                             {
                      new SqlParameter{ParameterName = "@Login_id", SqlDbType = SqlDbType.Int, Value = Program.userID },
                      new SqlParameter{ParameterName = "@TemplateID", SqlDbType = SqlDbType.Int, Value = tempID},
                      new SqlParameter{ParameterName = "@MachineID", SqlDbType = SqlDbType.Int,  Value = machID},
                      new SqlParameter{ParameterName = "@PartNo", SqlDbType = SqlDbType.VarChar,Size = 100, Value = Part},
                      new SqlParameter{ParameterName = "@CharacterID", SqlDbType = SqlDbType.Int, Value = 0  },
                      };

                            //CommonBL.InsertData("Sp_RetakeDAta", parameters);
                            CommonBL.InsertData(StoredProcedure.RetakeData, parameters);

                            var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();

                            mdiform.toolStripStatusLabel.ForeColor = Color.Black;  //Color.Green
                            mdiform.toolStripStatusLabel.Text = " All characteristics reading cleared for Part No. - " + Part;
                        }
                        //frmRetake.Close();

                        //TODO - Aamir - 08/08/2022

                        if (onlyCurrentChar == 1)
                        {
                            //listChar1.txtCurrentReading.Select();
                            //listChar1.txtCurrentReading.Focus(); 

                            //Added by Aamir - 17/09/22
                            string base64String = listChar1.ImageString;
                            // Convert base 64 string to byte[]
                            if (base64String != "")
                            {
                                byte[] imageBytes = Convert.FromBase64String(base64String);
                                // Convert byte[] to Image
                                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                                {
                                    pbPartImage.Image = Image.FromStream(ms, true);
                                }
                            }
                            else
                            {
                                pbPartImage.Image = SPC_KDL.Properties.Resources.noimageavailabe_image;//null;
                            }

                            lblPartNo.Text = listChar1.PartNo;
                            lblCharacteristic.Text = listChar1.Char.Split(':')[1];
                            lblGaugeSource.Text = listChar1.GaugeSource;

                        }
                        else
                        {
                            OnLoadLogic();
                            PopulateChar();
                        }
                        frmRetake.Close();
                    }

                    else
                    {
                        //Aamir - TODO
                        listChar0.txtCurrentReading.Select();
                        listChar0.txtCurrentReading.Focus();
                    }
                }
            }
        }
        private void flowLayoutPanelChar_Paint(object sender, PaintEventArgs e)
        {

        }
        private void frmInspection_KeyUp(object sender, KeyEventArgs e) //Aamir - 24/09/2022
        {
            if (e.KeyCode == Keys.F2)
            {
                btnKeyboard.Visible = true;
                lblPartNoHeading.Visible = true;
                lblPartNo.Visible = true;
                lblCharacteristicHeading.Visible = true;
                lblCharacteristic.Visible = true;
                lblGaugeSourceHeading.Visible = true;
                lblGaugeSource.Visible = true;
                lblCPHdr.Visible = true;
                lblCPData.Visible = true;
                lblCPKHdr.Visible = true;
                lblCPKData.Visible = true;

                //Aamir - 03/10/2022
                lblCPMHdr.Visible = true;
                lblCPMData.Visible = true;
                lblCPKMHdr.Visible = true;
                lblCPKMData.Visible = true;
                //Aamir - 03/10/2022

                pbDatatable.Visible = true;
                pbPMCChart.Visible = true;
                pbChart.Visible = true;

                lblInspectionCharCountHdr.Visible = true;
                lbllnspectionCharCountData.Visible = true;

                pnlChartDatatable.Width = 992;
                pnlChartDatatable.Height = 487;

                pnlChartDatatable.Location = new System.Drawing.Point(913,53);

                dgvDatatable.Width = 992;
                dgvDatatable.Height = 487;

                if (dtTempList != null)
                {
                    if (dtTempList.Rows.Count > 0)
                    {
                        for (int i = 0; i < listTemplates.Length; i++)    //loop through  each item
                        {
                            if (Convert.ToInt32(dtTempList.Rows[i]["TemplateID"].ToString()) == currentTempID)
                            {
                                listTemplates[i].BackColor = Color.LightCyan;
                            }
                            else
                            {
                                listTemplates[i].BackColor = Color.White;
                            }
                        }
                    }
                }

                //    pbDatatable_Click(this.pbDatatable, e);  //Commented by Aamir - 03/03/2023

                 pbPMCChart_Click(this.pbPMCChart, e); //Added by Aamir - 03/03/2023

                if (flowLayoutPanelChar.Controls.Count > 0)
                {
                    ListChar listChar1 = (ListChar)flowLayoutPanelChar.Controls.Find("ListChar", true)[currentSrNo - 1];
                    listChar1.txtCurrentReading.Select();
                    listChar1.txtCurrentReading.Focus();
                }

            }
   
        }

        private void chkMasterSize_Click(object sender, EventArgs e)//29/05/23
        {
            
        }

        private void chkMasterSize_CheckedChanged(object sender, EventArgs e) //29/05/23
        {
            //if (chkMasterSize.Checked == true)
            //{
            //    //frmKeyboard frmKeyboard = new frmKeyboard(currentModel, currentChar, currentLTL, currentTarget, currentUTL, currentSrNo);
            //    frmKeyboard frmKeyboard = new frmKeyboard(null, null, null, null, null, 0);
            //    //frmKeyboard.ShowDialog();
            //    //string reading = frmKeyboard.manualReading;
            //}
            //else
            //{
                
            //}
        }

        private void button1_Click(object sender, EventArgs e)//15/06/23
        {
            if (button1.Text != "")
            {
                currentmachineID= Convert.ToInt32(button1.Tag);
                
                //StationMachineList();
                OnLoadLogic();


                //dsTemplate_List = GetTemplate_List();
                //populateTemplates();
                //PopulateQueue();
                //dsInspectionHdrData = GetInspectionHdrData();

                //Add on 22/06/23
                if (dtQueueList != null)
                {

                    if (lblQueueCount.Text != "0")
                    {
                        dtQueueList.Rows.Clear();


                        btnKeyboard.Visible = true;
                        lblPartNoHeading.Visible = true;
                        lblPartNo.Visible = true;
                        lblCharacteristicHeading.Visible = true;
                        lblCharacteristic.Visible = true;
                        lblGaugeSourceHeading.Visible = true;
                        lblGaugeSource.Visible = true;
                        lblCPHdr.Visible = true;
                        lblCPData.Visible = true;
                        lblCPKHdr.Visible = true;
                        lblCPKData.Visible = true;

                        //Aamir - 03/10/22
                        lblCPMHdr.Visible = true;
                        lblCPMData.Visible = true;
                        lblCPKMHdr.Visible = true;
                        lblCPKMData.Visible = true;
                        //Aamir - 03/10/22

                        pbDatatable.Visible = true;
                        pbPMCChart.Visible = true;
                        pbChart.Visible = true;

                        lblInspectionCharCountHdr.Visible = true;
                        lbllnspectionCharCountData.Visible = true;

                        //chkMasterSize.Visible = true; //comment on 14/07/23

                        //add on 22/06/23
                        pbPartImage.Visible = true;
                        pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                        pnlChartDatatable.Width = 984;
                        pnlChartDatatable.Height = 487;

                        flowLayoutPanelChar.Visible = true;

                        dgvDatatable.Visible = false;
                        //add on 22/06/23

                        //pnlChartDatatable.Width = 992;
                        //pnlChartDatatable.Height = 487;

                        //dgvDatatable.Width = 992;
                        //dgvDatatable.Height = 487;
                        //  lblNothingPendingQueue.Visible = false; 
                    }
                }
                //Add on 22/06/23

                PopulateChar();
                
            }
        }

        private void button2_Click(object sender, EventArgs e) //19/06/23
        {
            currentmachineID = Convert.ToInt32(button2.Tag);
            OnLoadLogic();
            //dsTemplate_List = GetTemplate_List();
            //dsInspectionHdrData = GetInspectionHdrData();

            //Add on 22/06/23
            if (dtQueueList != null)
            {
                if (lblQueueCount.Text != "0")
                {
                    dtQueueList.Rows.Clear();


                    btnKeyboard.Visible = true;
                    lblPartNoHeading.Visible = true;
                    lblPartNo.Visible = true;
                    lblCharacteristicHeading.Visible = true;
                    lblCharacteristic.Visible = true;
                    lblGaugeSourceHeading.Visible = true;
                    lblGaugeSource.Visible = true;
                    lblCPHdr.Visible = true;
                    lblCPData.Visible = true;
                    lblCPKHdr.Visible = true;
                    lblCPKData.Visible = true;

                    //Aamir - 03/10/22
                    lblCPMHdr.Visible = true;
                    lblCPMData.Visible = true;
                    lblCPKMHdr.Visible = true;
                    lblCPKMData.Visible = true;
                    //Aamir - 03/10/22

                    pbDatatable.Visible = true;
                    pbPMCChart.Visible = true;
                    pbChart.Visible = true;

                    lblInspectionCharCountHdr.Visible = true;
                    lbllnspectionCharCountData.Visible = true;

                    //chkMasterSize.Visible = true; //comment on 14/07/23

                    //add on 22/06/23
                    pbPartImage.Visible = true;
                    pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                    pnlChartDatatable.Width = 984;
                    pnlChartDatatable.Height = 487;

                    flowLayoutPanelChar.Visible = true;
                    //add on 22/06/23

                    //pnlChartDatatable.Width = 992;
                    //pnlChartDatatable.Height = 487;

                    //dgvDatatable.Width = 992;
                    //dgvDatatable.Height = 487;
                    //  lblNothingPendingQueue.Visible = false; 
                }
            }
            //Add on 22/06/23

            PopulateChar();
        }

        private void button3_Click(object sender, EventArgs e) //19/06/23
        {
            currentmachineID = Convert.ToInt32(button3.Tag);
            OnLoadLogic();
            //dsFinalTemplateQueueList = GetTemplate_Queue_List();
            //populateTemplates();
            //PopulateQueue();
            //dsInspectionHdrData = GetInspectionHdrData();
            //Add on 22/06/23
            if (dtQueueList != null)
            {
                if (lblQueueCount.Text != "0")
                {
                    dtQueueList.Rows.Clear();


                    btnKeyboard.Visible = true;
                    lblPartNoHeading.Visible = true;
                    lblPartNo.Visible = true;
                    lblCharacteristicHeading.Visible = true;
                    lblCharacteristic.Visible = true;
                    lblGaugeSourceHeading.Visible = true;
                    lblGaugeSource.Visible = true;
                    lblCPHdr.Visible = true;
                    lblCPData.Visible = true;
                    lblCPKHdr.Visible = true;
                    lblCPKData.Visible = true;

                    //Aamir - 03/10/22
                    lblCPMHdr.Visible = true;
                    lblCPMData.Visible = true;
                    lblCPKMHdr.Visible = true;
                    lblCPKMData.Visible = true;
                    //Aamir - 03/10/22

                    pbDatatable.Visible = true;
                    pbPMCChart.Visible = true;
                    pbChart.Visible = true;

                    lblInspectionCharCountHdr.Visible = true;
                    lbllnspectionCharCountData.Visible = true;

                    //chkMasterSize.Visible = true; //comment on 14/07/23

                    //add on 22/06/23
                    pbPartImage.Visible = true;
                    pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                    pnlChartDatatable.Width = 984;
                    pnlChartDatatable.Height = 487;

                    flowLayoutPanelChar.Visible = true;
                    //add on 22/06/23

                    //pnlChartDatatable.Width = 992;
                    //pnlChartDatatable.Height = 487;

                    //dgvDatatable.Width = 992;
                    //dgvDatatable.Height = 487;
                    //  lblNothingPendingQueue.Visible = false; 
                }
            }
            //Add on 22/06/23
            PopulateChar();
        }

        private void button4_Click(object sender, EventArgs e) //19/06/23
        {
            currentmachineID = Convert.ToInt32(button4.Tag);
            OnLoadLogic();
            //dsTemplate_List = GetTemplate_List();
            //dsInspectionHdrData = GetInspectionHdrData();

            //Add on 22/06/23
            if (dtQueueList != null)
            {
                if (lblQueueCount.Text != "0")
                {
                    dtQueueList.Rows.Clear();


                    btnKeyboard.Visible = true;
                    lblPartNoHeading.Visible = true;
                    lblPartNo.Visible = true;
                    lblCharacteristicHeading.Visible = true;
                    lblCharacteristic.Visible = true;
                    lblGaugeSourceHeading.Visible = true;
                    lblGaugeSource.Visible = true;
                    lblCPHdr.Visible = true;
                    lblCPData.Visible = true;
                    lblCPKHdr.Visible = true;
                    lblCPKData.Visible = true;

                    //Aamir - 03/10/22
                    lblCPMHdr.Visible = true;
                    lblCPMData.Visible = true;
                    lblCPKMHdr.Visible = true;
                    lblCPKMData.Visible = true;
                    //Aamir - 03/10/22

                    pbDatatable.Visible = true;
                    pbPMCChart.Visible = true;
                    pbChart.Visible = true;

                    lblInspectionCharCountHdr.Visible = true;
                    lbllnspectionCharCountData.Visible = true;

                    //chkMasterSize.Visible = true; //comment on 14/07/23

                    //add on 22/06/23
                    pbPartImage.Visible = true;
                    pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
                    pnlChartDatatable.Width = 984;
                    pnlChartDatatable.Height = 487;

                    flowLayoutPanelChar.Visible = true;
                    //add on 22/06/23

                    //pnlChartDatatable.Width = 992;
                    //pnlChartDatatable.Height = 487;

                    //dgvDatatable.Width = 992;
                    //dgvDatatable.Height = 487;
                    //  lblNothingPendingQueue.Visible = false; 
                }
            }
            //Add on 22/06/23

            PopulateChar();
        }

        private void pbPMCChart_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelChar.Controls.Count > 0)
            {
                lblChartErrMsg.Visible = false;
                lblChartErrMsg.Text = "";

                //pnldatatable.BackColor = SystemColors.Control; 
                //pnlChart.BackColor = Color.SkyBlue;
                pbDatatable.BackColor = SystemColors.Control;
                pbPMCChart.BackColor = Color.SkyBlue;
                pbChart.BackColor = SystemColors.Control;
                dgvDatatable.Visible = false;
                pnlChartDatatable.Visible = true;

                //  pnlChartPMC.Visible = true;

                //Aamir - 06/09/2022
                pnlChartDatatable.Controls.Remove(chart1);

                if (chart1.ChartAreas.Count > 0)
                {
                    chart1 = null;
                }



                //Run Chart
                chart1 = new Chart();
                //  chart1.Location = new Point(700, 50);
                chart1.Width = 950; // 650
                chart1.Height = 450; // 400
                chart1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
                pnlChartDatatable.Controls.Add(chart1);
               // pnlChartPMC.BringToFront();

                dsChartData = GetChartData();

                if (dsChartData.Tables.Count ==  3) //dsChartData.Tables.Count > 0
                {

                    dtConfig = dsChartData.Tables[0];
                    dtReadings = dsChartData.Tables[1];
                    dtActualTable = dsChartData.Tables[2];

                    if (dtReadings.Rows.Count > 0)
                    {
                        //X-Bar Chart
                        DataRow[] selectedRows = dtConfig.Select("Key = 'UL' and CharacteristicsId = " + currentCharID);
                        xUL = Convert.ToDouble(selectedRows[0]["Value"]);
                        DataRow[] selectedRows1 = dtConfig.Select("Key = 'M' and CharacteristicsId = " + currentCharID);
                        xM = Convert.ToDouble(selectedRows1[0]["Value"]);
                        DataRow[] selectedRows2 = dtConfig.Select("Key = 'LL' and CharacteristicsId = " + currentCharID);
                        xLL = Convert.ToDouble(selectedRows2[0]["Value"]);
                        x_xAxisMaxLength = dtReadings.Rows.Count;

                        DataRow[] selectedRows21 = dtConfig.Select("Key = 'LLTH' and CharacteristicsId = " + currentCharID);
                        xMinReading = Convert.ToDouble(selectedRows21[0]["Value"]);
                        DataRow[] selectedRows22 = dtConfig.Select("Key = 'ULTH' and CharacteristicsId = " + currentCharID);
                        xMaxReading = Convert.ToDouble(selectedRows22[0]["Value"]);

                        DataRow[] selectedRows23 = dtConfig.Select("Key = 'Cp' and CharacteristicsId = " + currentCharID); //TODO - Aamir - 13/09/22
                        lblCPData.Text = selectedRows23[0]["Value"].ToString();
                        DataRow[] selectedRows24 = dtConfig.Select("Key = 'Cpk' and CharacteristicsId = " + currentCharID);
                        lblCPKData.Text = selectedRows24[0]["Value"].ToString();

                        //Aamir - 03/10/2022
                        DataRow[] selectedRows231 = dtConfig.Select("Key = 'CpM' and CharacteristicsId = " + currentCharID); //TODO - Aamir - 13/09/22
                        lblCPMData.Text = selectedRows231[0]["Value"].ToString();
                        DataRow[] selectedRows241 = dtConfig.Select("Key = 'CpkM' and CharacteristicsId = " + currentCharID);
                        lblCPKMData.Text = selectedRows241[0]["Value"].ToString();
                        //Aamir - 03/10/2022

                        DataRow[] selectedRows25 = dtConfig.Select("Key = 'UCL' and CharacteristicsId = " + currentCharID);
                        xUCL = Convert.ToDouble(selectedRows25[0]["Value"]);
                        DataRow[] selectedRows26 = dtConfig.Select("Key = 'LCL' and CharacteristicsId = " + currentCharID);
                        xLCL = Convert.ToDouble(selectedRows26[0]["Value"]);

                        //Aamir - 05/09/2022
                        //if (xMaxReading > xUL)
                        //{
                        //    xUL = xMaxReading;
                        //}
                        //if (xMinReading < xLL)
                        //{
                        //    xLL = xMinReading;
                        //}

                        // xM = (xLL + xUL) / 2;
                        //Aamir - 05/09/2022


                        runChart();


                   
                    }
                    else
                    {
                        lblChartErrMsg.Visible = true;
                        lblChartErrMsg.BringToFront();
                        lblChartErrMsg.Text = "Data not available / Something went wrong";
                       
                    }
                }


                else
                {
                    lblChartErrMsg.Visible = true;
                    lblChartErrMsg.BringToFront();
                    lblChartErrMsg.Text = "Data not available / Something went wrong";
                    
                }
            }
        }
        private void frmInspection_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Close();
            Dispose();
        }
        private void frmInspection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8) // keyboard
            {
                btnKeyboard.PerformClick();
            }
        }
        private void pbChart_Click(object sender, EventArgs e)
        {

            if (flowLayoutPanelChar.Controls.Count > 0)
            {
                controlChartClicked = 1;

                lblChartErrMsg.Visible = false;
                lblChartErrMsg.Text = "";

                //pnldatatable.BackColor = SystemColors.Control; 
                //pnlChart.BackColor = Color.SkyBlue;
                pbDatatable.BackColor = SystemColors.Control;
                pbPMCChart.BackColor = SystemColors.Control;
                pbChart.BackColor = Color.SkyBlue;
                dgvDatatable.Visible = false;
       
                pnlChartDatatable.Visible = true;

                //Aamir - 06/09/2022
                pnlChartDatatable.Controls.Remove(chart1);

                if (chart1.ChartAreas.Count > 0)
                {
                    chart1 = null;
                }



                //X-Bar Chart
                chart1 = new Chart();
                //  chart1.Location = new Point(700, 50);
                chart1.Width = 950; // 650
                chart1.Height = 450; // 400
                chart1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
                pnlChartDatatable.Controls.Add(chart1);


                dsChartData = GetChartData();

                if (dsChartData.Tables.Count == 3) //dsChartData.Tables.Count > 0
                {

                    dtConfig = dsChartData.Tables[0];
                    dtReadings = dsChartData.Tables[1];
                    dtActualTable = dsChartData.Tables[2];

                    if (dtReadings.Rows.Count > 0)
                    {
                        //X-Bar Chart
                        DataRow[] selectedRows = dtConfig.Select("Key = 'XUL' and CharacteristicsId = " + currentCharID);
                        xUL = Convert.ToDouble(selectedRows[0]["Value"]);
                        DataRow[] selectedRows1 = dtConfig.Select("Key = 'XM' and CharacteristicsId = " + currentCharID);
                        xM = Convert.ToDouble(selectedRows1[0]["Value"]);
                        DataRow[] selectedRows2 = dtConfig.Select("Key = 'XLL' and CharacteristicsId = " + currentCharID);
                        xLL = Convert.ToDouble(selectedRows2[0]["Value"]);
                        x_xAxisMaxLength = dtReadings.Rows.Count;

                        DataRow[] selectedRows21 = dtConfig.Select("Key = 'minreadingx' and CharacteristicsId = " + currentCharID);
                        xMinReading = Convert.ToDouble(selectedRows21[0]["Value"]);
                        DataRow[] selectedRows22 = dtConfig.Select("Key = 'maxreadingx' and CharacteristicsId = " + currentCharID);
                        xMaxReading = Convert.ToDouble(selectedRows22[0]["Value"]);

                        DataRow[] selectedRows23 = dtConfig.Select("Key = 'Cp' and CharacteristicsId = " + currentCharID);
                        lblCPData.Text = selectedRows23[0]["Value"].ToString();
                        DataRow[] selectedRows24 = dtConfig.Select("Key = 'Cpk' and CharacteristicsId = " + currentCharID);
                        lblCPKData.Text = selectedRows24[0]["Value"].ToString();

                        //Aamir - 03/10/2022
                        DataRow[] selectedRows231 = dtConfig.Select("Key = 'CpM' and CharacteristicsId = " + currentCharID);
                        lblCPMData.Text = selectedRows231[0]["Value"].ToString();
                        DataRow[] selectedRows241 = dtConfig.Select("Key = 'CpkM' and CharacteristicsId = " + currentCharID);
                        lblCPKMData.Text = selectedRows241[0]["Value"].ToString();
                        //Aamir - 03/10/2022

                        //Aamir - 05/09/2022
                        //if (xMaxReading > xUL)
                        //{
                        //    xUL = xMaxReading;
                        //}
                        //if (xMinReading < xLL)
                        //{
                        //    xLL = xMinReading;
                        //}

                        // xM = (xLL + xUL) / 2;
                        //Aamir - 05/09/2022


                        firstSeries();


                        //R-Bar Chart

                        DataRow[] selectedRows3 = dtConfig.Select("Key = 'RUL' and CharacteristicsId = " + currentCharID);
                        rUL = Convert.ToDouble(selectedRows3[0]["Value"]);
                        //rUL.ToString("0.0000");
                        DataRow[] selectedRows4 = dtConfig.Select("Key = 'RM' and CharacteristicsId =" + currentCharID);
                        rM = Convert.ToDouble(selectedRows4[0]["Value"]);
                        DataRow[] selectedRows5 = dtConfig.Select("Key = 'RLL' and CharacteristicsId =" + currentCharID);
                        rLL = Convert.ToDouble(selectedRows5[0]["Value"]);
                        r_xAxisMaxLength = dtReadings.Rows.Count;



                        DataRow[] selectedRows51 = dtConfig.Select("Key = 'minreadingR' and CharacteristicsId = " + currentCharID);
                        rMinReading = Convert.ToDouble(selectedRows51[0]["Value"]);
                        DataRow[] selectedRows52 = dtConfig.Select("Key = 'maxreadingR' and CharacteristicsId = " + currentCharID);
                        rMaxReading = Convert.ToDouble(selectedRows52[0]["Value"]);

                        secondSeries();
                        //R-Bar Chart

                        if (chart1.ChartAreas.Count > 0)
                        {
                            chart1.ChartAreas[0].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                            chart1.ChartAreas[0].AlignWithChartArea = chart1.ChartAreas[0].Name;

                            chart1.ChartAreas[1].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                            chart1.ChartAreas[1].AlignWithChartArea = chart1.ChartAreas[0].Name;
                        }
                    }
                    else
                    {
                        lblChartErrMsg.Visible = true;
                        lblChartErrMsg.Text = "Data not available / Something went wrong";
                    }
                }


                else
                {
                    lblChartErrMsg.Visible = true;
                    lblChartErrMsg.Text = "Data not available / Something went wrong";
                }
            }

        }
        private void firstSeries()
        {
            // chartArea
            ChartArea chartArea = new ChartArea();
            chartArea.Name = "First Area";
            chart1.ChartAreas.Add(chartArea);

            chartArea.BackColor = Color.White; //Color.Azure;
            chartArea.BackGradientStyle = GradientStyle.HorizontalCenter;
            chartArea.BackHatchStyle = ChartHatchStyle.None;//ChartHatchStyle.LargeGrid;
            chartArea.BorderDashStyle = ChartDashStyle.Solid;
            chartArea.BorderWidth = 0;//1;
            chartArea.ShadowOffset = 0;
            chart1.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
            chart1.ChartAreas[0].Axes[1].MajorGrid.Enabled = true;//y axis //false //TODO
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 1; //1 //Aamir - 06/09/2022
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Red; //Aamir - 06/09/2022
            chart1.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false; //TODO

            chartArea.AxisX.LineColor = Color.DarkGray;   
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 8f, System.Drawing.FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 8f, System.Drawing.FontStyle.Bold);
            chartArea.AxisY.LineColor = Color.DarkGray;

            chartArea.AxisY2.Enabled = AxisEnabled.True;
            chartArea.AxisY2.LineWidth = 0;
            chartArea.AxisY2.MajorGrid.Enabled = false;
            chartArea.AxisY2.MajorTickMark.Enabled = false;
            chartArea.AxisY2.LabelStyle.Enabled = true;
            chartArea.AxisY2.LabelStyle.Font = chartArea.AxisY.LabelStyle.Font;

            //Aamir - Scales
            //Cursor：only apply the top area
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.AxisType = AxisType.Primary;//act on primary x axis
            chartArea.CursorX.Interval = 1;
            chartArea.CursorX.LineWidth = 1;
            chartArea.CursorX.LineDashStyle = ChartDashStyle.Dash;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorX.SelectionColor = Color.Yellow;
            chartArea.CursorX.AutoScroll = true;

            //chartArea.CursorY.IsUserEnabled = true;
            //chartArea.CursorY.AxisType = AxisType.Primary;//act on primary y axis
            //chartArea.CursorY.Interval = 1;
            //chartArea.CursorY.LineWidth = 1;
            //chartArea.CursorY.LineDashStyle = ChartDashStyle.Dash;
            //chartArea.CursorY.IsUserSelectionEnabled = true;
            //chartArea.CursorY.SelectionColor = Color.Yellow;
            //chartArea.CursorY.AutoScroll = true;

            //Axis - Y //TODO

            //chartArea.AxisY.Minimum = double.NaN;
            //chartArea.AxisY.Maximum = double.NaN;

            //Aamir - 06/09/22
            //chartArea.AxisY.Minimum = xLL - 0.0002; //-10d;//Y axis Minimum value
            //chartArea.AxisY.Maximum = xUL + 0.0002; //100d;//Y axis Maximum value      

            //chartArea.AxisY2.Minimum = xLL - 0.0002; //-10d;//Y axis Minimum value
            //chartArea.AxisY2.Maximum = xUL + 0.0002; //100d;//Y axis Maximum value    

            chartArea.AxisY.Minimum = xMinReading; //-10d;//Y axis Minimum value
            chartArea.AxisY.Maximum = xMaxReading; //100d;//Y axis Maximum value      

            chartArea.AxisY2.Minimum = xMinReading; //-10d;//Y axis Minimum value
            chartArea.AxisY2.Maximum = xMaxReading; //100d;//Y axis Maximum value    

            chartArea.AxisY.IsStartedFromZero = false; //Aamir


            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.Minimum = 0d; //X axis Minimum value
            chartArea.AxisX.Maximum = x_xAxisMaxLength; //12d;

         //   chartArea.RecalculateAxesScale(); //TODO

            chartArea.AxisX.IsLabelAutoFit = true;
            //chartArea.AxisX.LabelAutoFitMaxFontSize = 12;
            chartArea.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea.AxisX.LabelStyle.Angle = 0; //-20
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;//show the last label
            chartArea.AxisX.LabelStyle.Enabled = true;

             

            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount; //FixedCount //VariableCount
            chartArea.AxisX.IntervalType = DateTimeIntervalType.NotSet;
            chartArea.AxisX.Title = @"";
            chartArea.AxisX.TextOrientation = TextOrientation.Auto;
            chartArea.AxisX.LineWidth = 1;
          //  chartArea.AxisX.LineColor = Color.Red; //Color.DarkOrchid; //Aamir - 06/09

            chartArea.AxisX2.LineWidth = 0;
            //   chartArea.AxisX2.LineColor = Color.Red; //Aamir - 06/09
            chartArea.AxisX2.Enabled = AxisEnabled.True; //True //Aamir - 06/09
            chartArea.AxisX2.MajorGrid.Enabled = false;
            chartArea.AxisX2.LabelStyle.Enabled = false;

            chartArea.AxisX2.MajorTickMark.Enabled = false;

            chartArea.AxisX2.Title = "X-Bar Chart Plotting's";
            chartArea.AxisX2.TitleFont = new Font("Calibri", 10f, FontStyle.Bold);

            chartArea.AxisX.Enabled = AxisEnabled.True;
            //chartArea.AxisX.ScaleView.MinSizeType =  DateTimeIntervalType.Months;
            chartArea.AxisX.ScrollBar = new AxisScrollBar();
            chartArea.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea.AxisX.ScrollBar.Enabled = true;

            //Series
            Series series1 = new Series();
            series1.ChartArea = "First Area";
            chart1.Series.Add(series1);
            //Series style
            series1.Name = @"series：Test One";
            series1.ChartType = SeriesChartType.Line;  // type
            series1.BorderWidth = 2;
            series1.Color = Color.Navy;//Color.Green;
            series1.XValueType = ChartValueType.Int32;//x axis type
            series1.YValueType = ChartValueType.Double;  //ChartValueType.Int32;//y axis type
            // series.YValuesPerPoint = 6;

            //Marker
            series1.MarkerStyle = MarkerStyle.Circle; //MarkerStyle.Star4;
            series1.MarkerSize = 8;
            series1.MarkerStep = 1;
            series1.MarkerColor = Color.Navy;//Color.Red;
            series1.ToolTip = "#VALY"; //@"ToolTip"; " X = #VALX\nY = #VALY"


            //Empty Point Style 
            //DataPointCustomProperties p = new DataPointCustomProperties();
            //p.Color = Color.Green;
            //series1.EmptyPointStyle = p;

            //Label
            //series1.IsValueShownAsLabel = true;
            //series1.SmartLabelStyle.Enabled = false;
            //series1.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            //series1.LabelForeColor = Color.Gray;
            //series1.LabelToolTip = @"LabelToolTip";


            double[] values = dtReadings.AsEnumerable().Select(row => Convert.ToDouble(row.Field<decimal>("XReading"), System.Globalization.CultureInfo.InvariantCulture)).ToArray();

            //Aamir
            chartArea.AxisY.CustomLabels.Clear(); 

            chartArea.AxisY.CustomLabels.Add(xLL, xUL, "", 0, LabelMarkStyle.None, GridTickTypes.None);

            chartArea.AxisY.CustomLabels.Add(xLL, xLL + 0.0001, xLL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None
            chartArea.AxisY.CustomLabels.Add(xM - 0.0001, xM + 0.0001, xM.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.None);
            chartArea.AxisY.CustomLabels.Add(xUL - 0.0001 , xUL, xUL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None
           
            //StripLine stripLow = new StripLine();
            //stripLow.IntervalOffset = 17.7722;//xLL;//xLL + 0.001;
            //stripLow.StripWidth = 0;
            //stripLow.BorderWidth = 1;
            //stripLow.Interval = 0;
            //stripLow.BorderColor = Color.Red;
            

            StripLine stripMed = new StripLine();
            stripMed.IntervalOffset = xM;//xM + 0.001;
            stripMed.StripWidth = 0;
            stripMed.BorderWidth = 1;
            stripMed.Interval = 0;
            stripMed.BorderColor = Color.Green;//Color.FromArgb(64, Color.Red);

            //StripLine stripHigh = new StripLine();
            //stripHigh.IntervalOffset = 17.7761;//xUL - 0.0002;//xUL;
            //stripHigh.StripWidth = 0;
            //stripHigh.BorderWidth = 1;
            //stripHigh.Interval = 0;
            //stripHigh.BorderColor = Color.Red;//Color.FromArgb(64, Color.Red);

            //chartArea.AxisY.StripLines.Add(stripLow);
            chartArea.AxisY.StripLines.Add(stripMed);
            //chartArea.AxisY.StripLines.Add(stripHigh);
      
            chartArea.AxisY2.CustomLabels.Clear();

            chartArea.AxisY2.CustomLabels.Add(xLL, xUL, "", 0, LabelMarkStyle.None, GridTickTypes.None);

            //Aamir - 06/09/2022
            //chartArea.AxisY2.CustomLabels.Add(0, 1, "LCL", 0, LabelMarkStyle.None, GridTickTypes.None);
            //chartArea.AxisY2.CustomLabels.Add(Math.Round(xUL / 2), Math.Round(xUL / 2) + 2, "Mean", 0, LabelMarkStyle.None, GridTickTypes.None);
            //chartArea.AxisY2.CustomLabels.Add(Math.Round(xUL) - 2, Math.Round(xUL), "UCL", 0, LabelMarkStyle.None, GridTickTypes.None);  

            chartArea.AxisY2.CustomLabels.Add(xLL, xLL + 0.0001, "LCL", 0, LabelMarkStyle.None, GridTickTypes.None); //None
            chartArea.AxisY2.CustomLabels.Add(xM - 0.0001, xM + 0.0001,"Mean", 0, LabelMarkStyle.None, GridTickTypes.None);
            chartArea.AxisY2.CustomLabels.Add(xUL - 0.0001, xUL, "UCL", 0, LabelMarkStyle.None, GridTickTypes.None); //None



            //Aamir

            int x1 = 0; //1

            series1.Points.Clear();   

            foreach (double v in values) //float
            {

                series1.Points.AddXY(x1, v);
                x1++;

            }

            //chart1.Update(); //TODO
            //chart1.Invalidate(); //TODO
           //chart1.Refresh(); 

        }
        private void runChart()
        {
            // chartArea
            ChartArea chartArea = new ChartArea();
            chartArea.Name = "First Area";
            chart1.ChartAreas.Add(chartArea);

            chartArea.BackColor = Color.White; //Color.Azure;
            chartArea.BackGradientStyle = GradientStyle.HorizontalCenter;
            chartArea.BackHatchStyle = ChartHatchStyle.None;//ChartHatchStyle.LargeGrid;
            chartArea.BorderDashStyle = ChartDashStyle.Solid;
            chartArea.BorderWidth = 0;//1;
            chartArea.ShadowOffset = 0;
            chart1.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
            chart1.ChartAreas[0].Axes[1].MajorGrid.Enabled = true;//y axis //false //TODO
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 1; //1 //Aamir - 06/09/2022
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Black; //Aamir - 06/09/2022
            chart1.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false; //TODO

            chartArea.AxisX.LineColor = Color.DarkGray;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 8f, System.Drawing.FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 8f, System.Drawing.FontStyle.Bold);
            chartArea.AxisY.LineColor = Color.DarkGray;


            //Aamir - Scales
            //Cursor：only apply the top area
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.AxisType = AxisType.Primary;//act on primary x axis
            chartArea.CursorX.Interval = 1;
            chartArea.CursorX.LineWidth = 1;
            chartArea.CursorX.LineDashStyle = ChartDashStyle.Dash;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorX.SelectionColor = Color.Yellow;
            chartArea.CursorX.AutoScroll = true;

            chartArea.AxisY.Minimum = xMinReading; //-10d;//Y axis Minimum value
            chartArea.AxisY.Maximum = xMaxReading; //100d;//Y axis Maximum value      

            chartArea.AxisY.IsStartedFromZero = false; //Aamir

            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.Minimum = 0d; //X axis Minimum value
            chartArea.AxisX.Maximum = x_xAxisMaxLength; //12d;

            //   chartArea.RecalculateAxesScale(); //TODO

            chartArea.AxisX.IsLabelAutoFit = true;
            //chartArea.AxisX.LabelAutoFitMaxFontSize = 12;
            chartArea.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea.AxisX.LabelStyle.Angle = 0; //-20
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;//show the last label
            chartArea.AxisX.LabelStyle.Enabled = true;



            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount; //FixedCount //VariableCount
            chartArea.AxisX.IntervalType = DateTimeIntervalType.NotSet;
            chartArea.AxisX.Title = @"";
            chartArea.AxisX.TextOrientation = TextOrientation.Auto;
            chartArea.AxisX.LineWidth = 1;
            //  chartArea.AxisX.LineColor = Color.Red; //Color.DarkOrchid; //Aamir - 06/09

            chartArea.AxisX2.LineWidth = 0;
            //   chartArea.AxisX2.LineColor = Color.Red; //Aamir - 06/09
            chartArea.AxisX2.Enabled = AxisEnabled.True; //True //Aamir - 06/09
            chartArea.AxisX2.MajorGrid.Enabled = false;
            chartArea.AxisX2.LabelStyle.Enabled = false;

            chartArea.AxisX2.MajorTickMark.Enabled = false;

            //chartArea.AxisX2.Title = "X-Bar Chart Plotting's";
            //chartArea.AxisX2.TitleFont = new Font("Calibri", 10f, FontStyle.Bold);

            chartArea.AxisX.Enabled = AxisEnabled.True;
            //chartArea.AxisX.ScaleView.MinSizeType =  DateTimeIntervalType.Months;
            chartArea.AxisX.ScrollBar = new AxisScrollBar();
            chartArea.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea.AxisX.ScrollBar.Enabled = true;

            //Series
            Series series1 = new Series();
            series1.ChartArea = "First Area";
            chart1.Series.Add(series1);
            //Series style
            series1.Name = @"series：Test One";
            series1.ChartType = SeriesChartType.Line;  // type
            series1.BorderWidth = 2;
            series1.Color = Color.Navy;//Color.Green;
            series1.XValueType = ChartValueType.Int32;//x axis type
            series1.YValueType = ChartValueType.Double;  //ChartValueType.Int32;//y axis type
            // series.YValuesPerPoint = 6;

            //Marker
            series1.MarkerStyle = MarkerStyle.Circle; //MarkerStyle.Star4;
            series1.MarkerSize = 8;
            series1.MarkerStep = 1;
            series1.MarkerColor = Color.Navy;//Color.Red;
          //  series1.ToolTip = "#VALY"; //@"ToolTip"; " X = #VALX\nY = #VALY" Commented Aamir - 18/09/2022


            double[] values = dtReadings.AsEnumerable().Select(row => Convert.ToDouble(row.Field<decimal>("Reading"), System.Globalization.CultureInfo.InvariantCulture)).ToArray();

            //Aamir - 18/09/22 
            string[] eventAbbr = dtReadings.AsEnumerable().Select(row => Convert.ToString(row.Field<string>("Event"), System.Globalization.CultureInfo.InvariantCulture)).ToArray();
            string[] eventDesc = dtReadings.AsEnumerable().Select(row => Convert.ToString(row.Field<string>("Description"), System.Globalization.CultureInfo.InvariantCulture)).ToArray();
            //Aamir - 18/09/22 

            //Aamir
            chartArea.AxisY.CustomLabels.Clear();

            //chartArea.AxisY.CustomLabels.Add(xLL, xUL, "", 0, LabelMarkStyle.None, GridTickTypes.None);
            chartArea.AxisY.CustomLabels.Add(xMinReading, xMaxReading, "", 0, LabelMarkStyle.None, GridTickTypes.None);

            chartArea.AxisY.CustomLabels.Add(xMinReading, xMinReading + 0.0001, xMinReading.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.None); //None

            chartArea.AxisY.CustomLabels.Add(xLL - 0.0001, xLL + 0.0001, xLL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None
            chartArea.AxisY.CustomLabels.Add(xLCL - 0.0001, xLCL + 0.0001, xLCL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None

            chartArea.AxisY.CustomLabels.Add(xM - 0.0001, xM + 0.0001, xM.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline);

            chartArea.AxisY.CustomLabels.Add(xUCL - 0.0001, xUCL + 0.0001, xUCL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None
            chartArea.AxisY.CustomLabels.Add(xUL - 0.0001, xUL + 0.0001, xUL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None

            chartArea.AxisY.CustomLabels.Add(xMaxReading - 0.001, xMaxReading, xMaxReading.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None


            var stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine()
            {
                BackColor = Color.FromArgb(250,80,80),
                IntervalOffset = xMinReading, // This is where the stripline starts
                StripWidth = xLL - xMinReading // And this is how long the interval is
            };
            var stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine()
            {
                BackColor = Color.FromArgb(241,235,156),
                IntervalOffset = xLL, // This is where the stripline starts
                StripWidth = xLCL - xLL // And this is how long the interval is
            };
            var stripLine3 = new System.Windows.Forms.DataVisualization.Charting.StripLine()
            {
                BackColor = Color.FromArgb(144, 238, 144),
                IntervalOffset = xLCL, // This is where the stripline starts
                StripWidth = xUCL - xLCL // And this is how long the interval is
            };
            var stripLine4 = new System.Windows.Forms.DataVisualization.Charting.StripLine()
            {
                BackColor = Color.FromArgb(241, 235, 156),
                IntervalOffset = xUCL, // This is where the stripline starts
                StripWidth = xUL - xUCL // And this is how long the interval is
            };
            var stripLine5 = new System.Windows.Forms.DataVisualization.Charting.StripLine()
            {
                BackColor = Color.FromArgb(250, 80, 80),
                IntervalOffset = xUL, // This is where the stripline starts
                StripWidth = xMaxReading - xUL  // And this is h ow long the interval is
            };

            chartArea.AxisY.StripLines.Add(stripLine1);
            chartArea.AxisY.StripLines.Add(stripLine2);
            chartArea.AxisY.StripLines.Add(stripLine3);
            chartArea.AxisY.StripLines.Add(stripLine4);
            chartArea.AxisY.StripLines.Add(stripLine5);


            //Aamir

            int x1 = 0; //1

            series1.Points.Clear();

            foreach (double v in values) //float
            {

                series1.Points.AddXY(x1, v);
                series1.Points[x1].Label = eventAbbr[x1];
                //series1.Points[x1].ToolTip = eventDesc[x1];
                series1.Points[x1].ToolTip  = "#VALY\n" + eventDesc[x1];
                x1++;

            }

           

            //chart1.Update(); //TODO
            //chart1.Invalidate(); //TODO
            //chart1.Refresh(); 

        }
        private void secondSeries()
        {
            // chartArea
            ChartArea chartArea2 = new ChartArea();
            chartArea2.Name = "Second Area";
            chart1.ChartAreas.Add(chartArea2); //chart2

            chartArea2.BackColor = Color.White; //Color.Azure;
            chartArea2.BackGradientStyle = GradientStyle.HorizontalCenter;
            chartArea2.BackHatchStyle = ChartHatchStyle.None;//ChartHatchStyle.LargeGrid;
            chartArea2.BorderDashStyle = ChartDashStyle.Solid;
            chartArea2.BorderWidth = 0;//1;
            chartArea2.ShadowOffset = 0;
            chartArea2.Axes[0].MajorGrid.Enabled = false;//x axis
            chartArea2.Axes[1].MajorGrid.Enabled = true;//y axis //false //TODO
            chartArea2.Axes[1].MajorGrid.LineWidth = 1; //1  Aamir - 06/09/2022
            chartArea2.Axes[1].MajorGrid.LineColor = Color.Red;
            chartArea2.Axes[1].MajorTickMark.Enabled = false; //TODO

            chartArea2.AxisX.LineColor = Color.DarkGray;
            chartArea2.AxisY.LineColor = Color.DarkGray;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 8f, System.Drawing.FontStyle.Regular);
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 8f, System.Drawing.FontStyle.Bold);

            chartArea2.AxisY2.Enabled = AxisEnabled.True; //true //Aamir - 06/09/2022
            chartArea2.AxisY2.LineWidth = 0;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.LabelStyle.Enabled = true;
            chartArea2.AxisY2.LabelStyle.Font = chartArea2.AxisY.LabelStyle.Font;

            //Aamir - Scales
            //Cursor：only apply the top area
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.AxisType = AxisType.Primary;//act on primary x axis
            chartArea2.CursorX.Interval = 1;
            chartArea2.CursorX.LineWidth = 1;
            chartArea2.CursorX.LineDashStyle = ChartDashStyle.Dash;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorX.SelectionColor = Color.Yellow;
            chartArea2.CursorX.AutoScroll = true;

            //chartArea.CursorY.IsUserEnabled = true;
            //chartArea.CursorY.AxisType = AxisType.Primary;//act on primary y axis
            //chartArea.CursorY.Interval = 1;
            //chartArea.CursorY.LineWidth = 1;
            //chartArea.CursorY.LineDashStyle = ChartDashStyle.Dash;
            //chartArea.CursorY.IsUserSelectionEnabled = true;
            //chartArea.CursorY.SelectionColor = Color.Yellow;
            //chartArea.CursorY.AutoScroll = true;

            //Axis - Y //TODO
            //Aamir - 06/09/22

            chartArea2.AxisY.Minimum = rLL;// - 0.0002; //-10d;//Y axis Minimum value
            chartArea2.AxisY.Maximum = rUL; //+ 0.02; //100d;//Y axis Maximum value   

            chartArea2.AxisY2.Minimum = rLL; //- 0.0002; //-10d;//Y axis Minimum value
            chartArea2.AxisY2.Maximum = rUL; //+ 0.02; //100d;//Y axis Maximum value   

            //chartArea2.AxisY.Minimum = rMinReading; //-10d;//Y axis Minimum value
            //chartArea2.AxisY.Maximum = rMaxReading; //100d;//Y axis Maximum value   

            //chartArea2.AxisY2.Minimum = rMinReading; //-10d;//Y axis Minimum value
            //chartArea2.AxisY2.Maximum = rMaxReading; //100d;//Y axis Maximum value   

            chartArea2.AxisY.IsStartedFromZero = false; //Aamir

            chartArea2.AxisX.ScaleView.Zoomable = true;
            chartArea2.AxisX.Minimum = 0d; //X axis Minimum value
            chartArea2.AxisX.Maximum = r_xAxisMaxLength; //12d;

            chartArea2.AxisX.IsLabelAutoFit = true;
            //chartArea.AxisX.LabelAutoFitMaxFontSize = 12;
            chartArea2.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea2.AxisX.LabelStyle.Angle = 0; //-20
            chartArea2.AxisX.LabelStyle.IsEndLabelVisible = true;//show the last label
            chartArea2.AxisX.LabelStyle.Enabled = true;

            chartArea2.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount; //FixedCount //VariableCount
            chartArea2.AxisX.IntervalType = DateTimeIntervalType.NotSet;
            chartArea2.AxisX.Title = @"";
            chartArea2.AxisX.TextOrientation = TextOrientation.Auto;
            chartArea2.AxisX.LineWidth = 1;
             chartArea2.AxisX.LineColor = Color.Red;  //Aamir - 06/09/2022

            chartArea2.AxisX2.LineWidth = 0;
          //  chartArea2.AxisX2.LineColor = Color.Red; //Aamir - 06/09/2022
            chartArea2.AxisX2.Enabled = AxisEnabled.True; //Aamir - 06/09/2022
            chartArea2.AxisX2.MajorGrid.Enabled = false;
            chartArea2.AxisX2.LabelStyle.Enabled = false;

            chartArea2.AxisX2.MajorTickMark.Enabled = false;

            chartArea2.AxisX2.Title = "Range Chart Plotting's";
            chartArea2.AxisX2.TitleFont = new Font("Calibri", 10f, FontStyle.Bold);

            chartArea2.AxisX.Enabled = AxisEnabled.True;
            //chartArea.AxisX.ScaleView.MinSizeType =  DateTimeIntervalType.Months;
            chartArea2.AxisX.ScrollBar = new AxisScrollBar();
            chartArea2.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea2.AxisX.ScrollBar.Enabled = true;

            //Series
            Series series1 = new Series();
            series1.ChartArea = "Second Area";
            chart1.Series.Add(series1);
            //Series style
            series1.Name = @"series：Test Two";
            series1.ChartType = SeriesChartType.Line;  // type
            series1.BorderWidth = 2; //2
            series1.Color = Color.Navy;//Color.Green;
            series1.XValueType = ChartValueType.Int32;//x axis type
            series1.YValueType = ChartValueType.Double;  //ChartValueType.Int32;//y axis type
            // series.YValuesPerPoint = 6;

            //Marker
            series1.MarkerStyle = MarkerStyle.Circle; //MarkerStyle.Star4;
            series1.MarkerSize = 8; //8
            series1.MarkerStep = 1;
            series1.MarkerColor = Color.Navy;//Color.Red;
            series1.ToolTip = "#VALY"; //@"ToolTip"; " X = #VALX\nY = #VALY"


            //Empty Point Style 
            //DataPointCustomProperties p = new DataPointCustomProperties();
            //p.Color = Color.Green;
            //series1.EmptyPointStyle = p;

            //Label
            //series1.IsValueShownAsLabel = true;
            //series1.SmartLabelStyle.Enabled = false;
            //series1.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            //series1.LabelForeColor = Color.Gray;
            //series1.LabelToolTip = @"LabelToolTip";


            double[] values = dtReadings.AsEnumerable().Select(row => Convert.ToDouble(row.Field<decimal>("RReading"), System.Globalization.CultureInfo.InvariantCulture)).ToArray();

            //Aamir

                chartArea2.AxisY.CustomLabels.Add(rLL, rUL, "", 0, LabelMarkStyle.None, GridTickTypes.None);

                chartArea2.AxisY.CustomLabels.Add(rLL, rLL + 0.0001, rLL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.None); //TODO
                chartArea2.AxisY.CustomLabels.Add(rM - 0.0001, rM + 0.0001, rM.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.None);
                chartArea2.AxisY.CustomLabels.Add(rUL - 0.0001, rUL, rUL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline);


                chartArea2.AxisY2.CustomLabels.Add(rLL, rUL, "", 0, LabelMarkStyle.None, GridTickTypes.None);

            //chartArea2.AxisY2.CustomLabels.Add(0, 0.001, "LCL", 0, LabelMarkStyle.None, GridTickTypes.None);
            //chartArea2.AxisY2.CustomLabels.Add(rM - 0.02 , rM, "Mean", 0, LabelMarkStyle.None, GridTickTypes.None);
            //chartArea2.AxisY2.CustomLabels.Add(rUL - 0.03, rUL - 0.01, "UCL", 0, LabelMarkStyle.None, GridTickTypes.None);

            chartArea2.AxisY2.CustomLabels.Add(rLL, rLL + 0.0001, "LCL", 0, LabelMarkStyle.None, GridTickTypes.None);
            chartArea2.AxisY2.CustomLabels.Add(rM - 0.0001, rM + 0.0001, "Mean", 0, LabelMarkStyle.None, GridTickTypes.None);
            chartArea2.AxisY2.CustomLabels.Add(rUL - 0.0001, rUL, "UCL", 0, LabelMarkStyle.None, GridTickTypes.None);

            //StripLine stripLow = new StripLine();
            //stripLow.IntervalOffset = rLL;//xLL;//xLL + 0.001;
            //stripLow.StripWidth = 0;
            //stripLow.BorderWidth = 1;
            //stripLow.Interval = 0;
            //stripLow.BorderColor = Color.Red;


            StripLine stripMed = new StripLine();
            stripMed.IntervalOffset = rM;//xM + 0.001;
            stripMed.StripWidth = 0;
            stripMed.BorderWidth = 1;
            stripMed.Interval = 0;
            stripMed.BorderColor = Color.Green;//Color.FromArgb(64, Color.Red);

            //StripLine stripHigh = new StripLine();
            //stripHigh.IntervalOffset = rUL;//xUL - 0.0002;//xUL;
            //stripHigh.StripWidth = 0;
            //stripHigh.BorderWidth = 1;
            //stripHigh.Interval = 0;
            //stripHigh.BorderColor = Color.Red;//Color.FromArgb(64, Color.Red);

           // chartArea2.AxisY.StripLines.Add(stripLow);
            chartArea2.AxisY.StripLines.Add(stripMed);
         //  chartArea2.AxisY.StripLines.Add(stripHigh);

            //Aamir

            int x1 = 0; //1
            foreach (double v in values) //float
            {
                series1.Points.AddXY(x1, v);
                x1++;
            }

        }
        private DataSet GetChartData()
        {
            int chartTypeiD = 0;

            if (controlChartClicked == 1)
            {
                chartTypeiD = 2;
            }
            else
            {
                chartTypeiD = 1;
            }

          //  if (currentCharID != "") //Added by Aamir - 04/03/2023
           // {

                SqlParameter outParam_1 = new SqlParameter();
                outParam_1.ParameterName = "@Message";
                outParam_1.SqlDbType = SqlDbType.VarChar;
                outParam_1.Size = 100;
                outParam_1.Direction = ParameterDirection.Output;

                SqlParameter[] parameters =
                {
                new SqlParameter { ParameterName = "@Login_id",SqlDbType=SqlDbType.NVarChar,Size = 100, Value = Program.userID.ToString()},
                new SqlParameter{ParameterName = "@StationID",SqlDbType = SqlDbType.Int, Value = Program.stationID } ,
                new SqlParameter{ParameterName = "@TemplateId", SqlDbType =  SqlDbType.Int, Value = currentTempID},
                new SqlParameter{ParameterName = "@MachineId", SqlDbType =  SqlDbType.Int, Value = currentmachineID},
                new SqlParameter{ParameterName = "@CharacteristicsId", SqlDbType =  SqlDbType.Int, Value =Convert.ToInt32(currentCharID)}, //1,2
                //new SqlParameter{ParameterName = "@DateRangeType", SqlDbType =  SqlDbType.VarChar,Size=20, Value = "Custom Period"},
                //new SqlParameter{ParameterName = "@FromDate", SqlDbType =  SqlDbType.VarChar,Size = 10, Value = "2022-04-01"},
                //new SqlParameter{ParameterName = "@ToDate", SqlDbType =  SqlDbType.VarChar, Size=10,Value = "2022-08-01"},
                //new SqlParameter{ParameterName = "@Shift1", SqlDbType =  SqlDbType.Bit, Value = 0},
                //new SqlParameter{ParameterName = "@Shift2", SqlDbType =  SqlDbType.Bit, Value = 0},
                //new SqlParameter{ParameterName = "@Shift3", SqlDbType =  SqlDbType.Bit, Value = 0},
                new SqlParameter{ParameterName = "@ChartTypeID", SqlDbType =  SqlDbType.Int, Value = chartTypeiD},
                //new SqlParameter{ParameterName = "@Subgroup", SqlDbType =  SqlDbType.Int, Value = 4},
                //new SqlParameter{ParameterName = "@EventIds", SqlDbType =  SqlDbType.VarChar,Size=500, Value = ""},
                //new SqlParameter{ParameterName = "@ControlLimitOption", SqlDbType =  SqlDbType.Int, Value = 0},
                //new SqlParameter{ParameterName = "@ExportOptionIds", SqlDbType =  SqlDbType.VarChar, Size=500,Value = "" },
                outParam_1,
            };

                controlChartClicked = 0;

                DataSet ds = new DataSet();
            //ds = CommonBL.GetTemplateQueueData("sp_GetChartData_Win", parameters); //sp_GetChartData
            ds = CommonBL.GetTemplateQueueData(StoredProcedure.GetChartDataWin, parameters);
            return ds;
           // } //Added by Aamir - 04/03/2023
           
        }
        private void pbDatatable_Click(object sender, EventArgs e)
        {
            pnlChartDatatable.Controls.Remove(chart1);

            lblChartErrMsg.Visible = false;
            lblChartErrMsg.Text = "";

            if (flowLayoutPanelChar.Controls.Count > 0)
            {
                pbDatatable.BackColor = Color.SkyBlue;
                pbChart.BackColor = SystemColors.Control;
                pbPMCChart.BackColor = SystemColors.Control;
                // pnlDatatable.BackColor = Color.SkyBlue;
                //pnlChart.BackColor = SystemColors.Control;

                dgvDatatable.Visible = true;
                dgvDatatable.BringToFront(); 

                SqlParameter[] parameters =
                   {
                //  new SqlParameter{ParameterName = "@UserID", SqlDbType = SqlDbType.Int,  Value = Program.userID},
                  new SqlParameter{ParameterName = "@Login_id", SqlDbType = SqlDbType.VarChar, Size = 100,  Value = Program.userID.ToString()},
                  new SqlParameter{ParameterName="@StationId",SqlDbType=SqlDbType.Int, Value = Program.stationID},
                  new SqlParameter{ParameterName="@TemplateId",SqlDbType=SqlDbType.Int, Value = Program.CurrentTemplateID},
                  new SqlParameter{ParameterName="@MachineId",SqlDbType =SqlDbType.Int, Value =  Program.CurrentMachineID},
                  new SqlParameter{ParameterName="@CharacteristicsId",SqlDbType =SqlDbType.Int,  Value =  0 }, //Convert.ToInt32(currentCharID)},  //"1" //Aamir - 03/10/2022
                  //outParam_1
              };

                DataTable dt = new DataTable();
                //dt = CommonBL.GetModifyData("sp_GetChartData_DE", parameters);
                dt = CommonBL.GetModifyData(StoredProcedure.GetChartDataDE, parameters);

                dgvDatatable.DataSource = dt;
            }
    
          
        }
    }
}

