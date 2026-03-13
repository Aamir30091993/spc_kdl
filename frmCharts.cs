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
using System.Windows.Forms.DataVisualization.Charting;

namespace SPC_KDL
{
    public partial class frmCharts : Form
    {
        DataSet dsChartData;
        DataTable dtConfig;
        DataTable dtReadings;
        DataTable dtReadingsAll;
        DataTable dtActualTable;

        DataTable dtViewDatatable;

        private readonly DataTable dtTemplates = new DataTable();
        private readonly DataTable dtMachines = new DataTable();
        private readonly DataTable dtEvents = new DataTable();
        private readonly DataTable dtCharacteristics = new DataTable();
        private readonly object _lock = new object();


        double xUL, xLL, xM, xUCL, xLCL;
        double xMinReading, xMaxReading, rMinReading, rMaxReading;
        int x_xAxisMaxLength = 0;

        double rUL, rLL, rM;
        // decimal rUL, rLL, rM;
        int r_xAxisMaxLength = 0;

        Chart chart1;
        string eventIDs = "";
        string charIDs = "";
        string palletes = "";
        public frmCharts()
        {
            InitializeComponent();
           
        }
        private void frmCharts_Load(object sender, EventArgs e)
        {
            cmbTemplate.Focus();
            //Binding data to all comboBox
            //1. Template
            TemplateCombo();
            MachineCombo();
            EventCombo();

        }
        private void cmbDateRange_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDateRange.Text ==  "Custom Period" )
            {
                lblFromDate.Visible = true;
                lblToDate.Visible = true; 
                dtpFromDate.Visible = true;
                dtpToDate.Visible = true; 
            }
            else
            {
                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpFromDate.Visible = false;
                dtpToDate.Visible = false;
            }
        }
        private void chkbxRunChart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxRunChart.Checked == true )
            {
                chkbxControlChart.Checked = false;

                btnViewDatatable.Visible = true;

                //lblSubgroupSize.Visible = false;
                //lblSubGroupSizeStar.Visible = false;
                //cmbSubGroupSize.Visible = false;
                //cmbSubGroupSize.SelectedIndex = 3;
                //lblOptions.Visible = false;
                //lblControlLinit.Visible = false;
                //rdbPastPeriod.Visible = false;
                //rdbCurrentData.Visible = false;
            }
    
        }
        private void chkbxControlChart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxControlChart.Checked == true)
            {
                chkbxRunChart.Checked = false;

                btnViewDatatable.Visible = false;

                //lblSubgroupSize.Visible = true;
                //lblSubGroupSizeStar.Visible = true;
                //cmbSubGroupSize.Visible = true;
                //cmbSubGroupSize.SelectedIndex = 3; 
                //lblOptions.Visible = true;
                //lblControlLinit.Visible = true;
                //rdbPastPeriod.Visible = true;
                //rdbCurrentData.Visible = true;
            }

            //else
            //{
            //    chkbxRunChart.Checked = false;

            //    //lblSubgroupSize.Visible = false;
            //    //lblSubGroupSizeStar.Visible = false;
            //    //cmbSubGroupSize.Visible = false;
            //    //cmbSubGroupSize.SelectedIndex = 3;
            //    //lblOptions.Visible = false;
            //    //lblControlLinit.Visible = false;
            //    //rdbPastPeriod.Visible = false;
            //    //rdbCurrentData.Visible = false;
            //}
        }
        private void btnBack1_Click(object sender, EventArgs e)
        {
            pnlChartParamters.Show();
            pnlChartView.Hide();
            pnlDatatable.Hide();
            btnBack1.Visible = false; 
        }
        private void TemplateCombo()
        {
            //dtTemplates = CommonBL.getCombo(Program.userID, 5, Program.stationID.ToString());
            lock (_lock) { dtTemplates.Clear(); dtTemplates.Merge(CommonBL.getCombo(Program.userID, 5, Program.stationID.ToString())); }
            cmbTemplate.DataSource = dtTemplates;
            cmbTemplate.DisplayMember = "TemplateName";
            cmbTemplate.ValueMember = "ID";

            cmbTemplate.SelectedIndex = -1;
           
        }
        private void btnViewDatatable_Click(object sender, EventArgs e)
        {
            if (fnValidate() == true)
            {
                pnlChartParamters.Hide();

                //TODO
                //var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                //mdiform.progressBar1.Visible = true;
                //mdiform.progressBar1.Maximum = 100;
                //mdiform.progressBar1.Step = 1;
                //mdiform.progressBar1.Value = 0;
                //mdiform.progressBar1.BringToFront();

                DataGridView dgvDatatable = new DataGridView();
                dgvDatatable.Name = "Datatable";
                dgvDatatable.BackColor = Color.White;
                dgvDatatable.ForeColor = Color.Black;
                dgvDatatable.Font = new Font("Calibri", 12);
                dgvDatatable.Width = 1800; //1900 1470
                dgvDatatable.Height = 850; //900 772
               
                dgvDatatable.AllowUserToAddRows = false;
                dgvDatatable.AllowUserToDeleteRows = false;
                dgvDatatable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                pnlDatatable.Controls.Add(dgvDatatable);

                //EVENTS - START
                int eventsCount = chklstbxEvents.CheckedItems.Count;
                if (eventsCount == 0)
                {
                    eventIDs = "";
                } //eventsCount == 0
                else
                {
                    eventIDs = "";
                    foreach (object item in chklstbxEvents.CheckedItems) //chklstbxChar.CheckedItems
                    {
                        DataRowView castedItem = item as DataRowView;
                        eventIDs += castedItem[0].ToString() + ",";  //"Tabpage" + i.ToString()
                    }
                    eventIDs = eventIDs.Remove(eventIDs.Length - 1);
                }
                //EVENTS - END

                //CHARACTERISTICS - START
                int charCount = chklstbxChar.CheckedItems.Count;
                if (charCount == 0)
                {
                    charIDs = "";
                }
                else
                {
                    charIDs = "";
                    foreach (object item in chklstbxChar.CheckedItems) //chklstbxChar.CheckedItems
                    {
                        DataRowView castedItem = item as DataRowView;
                        charIDs += castedItem[0].ToString() + ",";  //"Tabpage" + i.ToString()
                    }
                    charIDs = charIDs.Remove(charIDs.Length - 1);
                }
                //CHARACTERISTICS - END

                //PALLETS - START
                if (chkbPalletA.Checked == true)
                {
                    palletes = "A";
                }
                if (chkbPalletB.Checked == true)
                {
                    palletes = "B";
                }
                if (chkbPalletA.Checked == true && chkbPalletB.Checked == true)
                {
                    palletes = "";
                }
                if (chkbPalletA.Checked == false && chkbPalletB.Checked == false)
                {
                    palletes = "";
                }
                //PALLETS - END

                //SP CALL - START
                dtViewDatatable = GetDataTable();
                dgvDatatable.DataSource = dtViewDatatable;

                dgvDatatable.ReadOnly = true;
                //SP CALL - END

                pnlDatatable.Visible = true;
                pnlDatatable.BringToFront();
                pnlDatatable.AutoScroll = true;
                pnlDatatable.Location = new Point(-6, 30); //(-6, -1)
                pnlDatatable.Size = new Size(1850, 900); //1913, 922 1370, 772  1470, 772  1900, 950
                btnBack1.Visible = true;
            }
        }
        private void MachineCombo()
        {
            //dtMachines = CommonBL.getCombo(Program.userID, 23, Program.stationID.ToString());
            lock (_lock) { dtMachines.Clear(); dtMachines.Merge(CommonBL.getCombo(Program.userID, 23, Program.stationID.ToString())); }
            cmbMachineNo.DataSource = dtMachines;
            cmbMachineNo.DisplayMember = "MachineName";
            cmbMachineNo.ValueMember = "ID";

            cmbMachineNo.SelectedIndex = -1;
        }
        private void EventCombo()
        {
            //dtEvents = CommonBL.getCombo(Program.userID, 26, Program.stationID.ToString());
            lock (_lock) { dtEvents.Clear(); dtEvents.Merge(CommonBL.getCombo(Program.userID, 26, Program.stationID.ToString())); }

            chklstbxEvents.DataSource = dtEvents;
            chklstbxEvents.DisplayMember = "Name";
            chklstbxEvents.ValueMember = "ID";
   
            chklstbxEvents.SelectedIndex = -1;
            
        }
        private void cmbTemplate_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (cmbTemplate.Text != "")
            {
                //dtCharacteristics = CommonBL.getCombo(Program.userID, 18, cmbTemplate.SelectedValue.ToString());
                lock (_lock) { dtCharacteristics.Clear(); dtCharacteristics.Merge(CommonBL.getCombo(Program.userID, 18, cmbTemplate.SelectedValue.ToString())); }
                chklstbxChar.DataSource = dtCharacteristics;
                chklstbxChar.DisplayMember = "CharacteristicsName";
                chklstbxChar.ValueMember = "ID";
                chklstbxChar.SelectedIndex = -1;
            }
        }
        private void btnViewChart_Click_1(object sender, EventArgs e)
        {
            if (fnValidate() == true)
            {
                //Check for Mandatory fields

                //Check for Mandatory fields

                pnlChartParamters.Hide();

                //TODO
                var mdiform = Application.OpenForms.OfType<MDISPC>().FirstOrDefault();
                mdiform.progressBar1.Visible = true;
                mdiform.progressBar1.Maximum = 100;
                mdiform.progressBar1.Step = 1;
                mdiform.progressBar1.Value = 0;
                mdiform.progressBar1.BringToFront();

                // Create a TabControl and set its properties              
                TabControl dynamicTabControl = new TabControl();
                dynamicTabControl.Name = "DynamicTabControl";
                dynamicTabControl.BackColor = Color.White;
                dynamicTabControl.ForeColor = Color.Black;
                dynamicTabControl.Font = new Font("Calibri", 12);
                dynamicTabControl.Width = 1850; //1900 1470
                dynamicTabControl.Height = 900; //900 772
                pnlChartView.Controls.Add(dynamicTabControl);
                //pnlChartView.Controls.Add(btnBack1);  

                //EVENTS - START
                int eventsCount = chklstbxEvents.CheckedItems.Count;

                if (eventsCount == 0)
                {
                    eventIDs = "";
                } //eventsCount == 0

                else
                {
                    eventIDs = "";
                    foreach (object item in chklstbxEvents.CheckedItems) //chklstbxChar.CheckedItems
                    {
                        DataRowView castedItem = item as DataRowView;
                        eventIDs += castedItem[0].ToString() + ",";  //"Tabpage" + i.ToString()
                    }
                    eventIDs = eventIDs.Remove(eventIDs.Length - 1);

                }
                //EVENTS - END

                //CHARACTERISTICS - START
                int charCount = chklstbxChar.CheckedItems.Count;
                if (charCount == 0)
                {
                    charIDs = "";
                }
                else
                {
                    charIDs = "";
                    foreach (object item in chklstbxChar.CheckedItems) //chklstbxChar.CheckedItems
                    {
                        DataRowView castedItem = item as DataRowView;
                        charIDs += castedItem[0].ToString() + ",";  //"Tabpage" + i.ToString()
                    }
                    charIDs = charIDs.Remove(charIDs.Length - 1);
                }

                if (chkbPalletA.Checked == true)
                {
                    palletes = "A";
                }
                if (chkbPalletB.Checked == true)
                {
                    palletes = "B";
                }
                if (chkbPalletA.Checked == true && chkbPalletB.Checked == true)
                {
                    palletes = "";
                }
                if (chkbPalletA.Checked == false && chkbPalletB.Checked == false)
                {
                    palletes = "";
                }

                dsChartData = GetChartData();

                if (charCount == 0)
                {
                    int counter = 0;
                    //Prepare Chart

                    foreach (object item in chklstbxChar.Items) //chklstbxChar.CheckedItems
                    {
                        //mdiform.lblTimer.Visible = true;
                        //mdiform.lblTimer.BringToFront();
                        mdiform.progressBar1.Maximum = this.chklstbxChar.Items.Count;
                        mdiform.progressBar1.Value = counter + 1;

                        DataRowView castedItem = item as DataRowView;
                        TabPage tabPage = new TabPage();
                        //  {
                        tabPage.Name = "Tabpage" + counter.ToString();
                        tabPage.Text = castedItem[1].ToString();  //"Tabpage" + i.ToString
                        tabPage.AutoScroll = true;
                        tabPage.Width = 1850;
                        tabPage.Height = 900;
                        // tabPage.BackColor = Color.SkyBlue;

                        // };
                        // Create Button
                        //Button btn = new Button();
                        //btn.Name = "btnButton";
                        //btn.Text = "Dynamic Button";
                        //btn.BackColor = Color.SeaGreen;
                        //btn.Size = new Size(100, 100);
                        //btn.Location = new Point(10, 10);

                        Label lblCPHdr = new Label();
                        lblCPHdr.Name = "lblCPHdr";
                        lblCPHdr.Text = "Cp = ";
                        lblCPHdr.Size = new Size(30, 30);
                        lblCPHdr.BackColor = Color.GreenYellow;
                        lblCPHdr.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPHdr.Location = new Point(850, 1); //10, 15  //10, 10

                        Label lblCPData = new Label();
                        lblCPData.Name = "lblCPData";
                        lblCPData.Text = ""; //1.67
                        lblCPData.Size = new Size(40, 30);
                        lblCPData.BackColor = Color.GreenYellow;
                        lblCPData.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPData.Location = new Point(890, 1); //10, 60 //55, 10

                        Label lblCPKHdr = new Label();
                        lblCPKHdr.Name = "lblCPKHdr";
                        lblCPKHdr.Text = "Cpk = ";
                        lblCPKHdr.Size = new Size(40, 30);
                        lblCPKHdr.BackColor = Color.GreenYellow;
                        lblCPKHdr.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPKHdr.Location = new Point(950, 1); //10, 105 //100, 10

                        Label lblCPKData = new Label();
                        lblCPKData.Name = "lblCPKData";
                        lblCPKData.Text = ""; //1.09
                        lblCPKData.Size = new Size(40, 30);
                        lblCPKData.BackColor = Color.GreenYellow;
                        lblCPKData.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPKData.Location = new Point(1000, 1); //10, 150  //145, 10

                        //tabPage.Controls.Add(lblCPData);
                        //tabPage.Controls.Add(lblCPKData);


                        chart1 = new Chart();
                        chart1.Width = 1850; // 650 1350
                        chart1.Height = 850; // 450 600
                                             // chart1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;

                        ////Prepare Chart
                        //dsChartData = GetChartData();

                        if (chkbxRunChart.Checked == true)
                        {
                            lblCPHdr.Visible = false;
                            lblCPData.Visible = false;
                            lblCPKHdr.Visible = false;
                            lblCPKData.Visible = false;

                            if (dsChartData.Tables.Count == 3) //dsChartData.Tables.Count > 0
                            {

                                dtConfig = dsChartData.Tables[0];
                                dtReadingsAll = dsChartData.Tables[1];
                                dtActualTable = dsChartData.Tables[2];

                                if (dtReadingsAll.Rows.Count > 0)
                                {
                                    //X-Bar Chart
                                    DataRow[] selectedRows = dtConfig.Select("Key = 'UL' and CharacteristicsId = " + castedItem[0]);
                                    xUL = Convert.ToDouble(selectedRows[0]["Value"]);
                                    DataRow[] selectedRows1 = dtConfig.Select("Key = 'M' and CharacteristicsId = " + castedItem[0]);
                                    xM = Convert.ToDouble(selectedRows1[0]["Value"]);
                                    DataRow[] selectedRows2 = dtConfig.Select("Key = 'LL' and CharacteristicsId = " + castedItem[0]);
                                    xLL = Convert.ToDouble(selectedRows2[0]["Value"]);
                                    // x_xAxisMaxLength = dtReadings.Rows.Count; //Commented by Aamir - 03/11/2022
                                    DataRow[] rowCount = dtReadingsAll.Select("CharacterID = " + castedItem[0]);

                                    x_xAxisMaxLength = rowCount.Length;

                                    dtReadings = rowCount.CopyToDataTable();  

                                    DataRow[] selectedRows21 = dtConfig.Select("Key = 'LLTH' and CharacteristicsId = " + castedItem[0]);
                                    xMinReading = Convert.ToDouble(selectedRows21[0]["Value"]);
                                    DataRow[] selectedRows22 = dtConfig.Select("Key = 'ULTH' and CharacteristicsId = " + castedItem[0]);
                                    xMaxReading = Convert.ToDouble(selectedRows22[0]["Value"]);

                                    //DataRow[] selectedRows23 = dtConfig.Select("Key = 'Cp' and CharacteristicsId = " + castedItem[0]); //TODO - Aamir - 13/09/22
                                    //lblCPData.Text = selectedRows23[0]["Value"].ToString();
                                    //DataRow[] selectedRows24 = dtConfig.Select("Key = 'Cpk' and CharacteristicsId = " + castedItem[0]);
                                    // lblCPKData.Text = selectedRows24[0]["Value"].ToString();

                                    //Aamir - 03/10/2022
                                    //DataRow[] selectedRows231 = dtConfig.Select("Key = 'CpM' and CharacteristicsId = " + castedItem[0]); //TODO - Aamir - 13/09/22
                                    //                                                                                                     //     lblCPMData.Text = selectedRows231[0]["Value"].ToString();
                                    //DataRow[] selectedRows241 = dtConfig.Select("Key = 'CpkM' and CharacteristicsId = " + castedItem[0]);
                                    //    lblCPKMData.Text = selectedRows241[0]["Value"].ToString();
                                    //Aamir - 03/10/2022

                                    DataRow[] selectedRows25 = dtConfig.Select("Key = 'UCL' and CharacteristicsId = " + castedItem[0]);
                                    xUCL = Convert.ToDouble(selectedRows25[0]["Value"]);
                                    DataRow[] selectedRows26 = dtConfig.Select("Key = 'LCL' and CharacteristicsId = " + castedItem[0]);
                                    xLCL = Convert.ToDouble(selectedRows26[0]["Value"]);

                                    runChart();

                                }
                                else
                                {
                                    //lblChartErrMsg.Visible = true;
                                    //lblChartErrMsg.BringToFront();
                                    //lblChartErrMsg.Text = "Data not available / Something went wrong";

                                }
                            }


                            else
                            {
                                //lblChartErrMsg.Visible = true;
                                //lblChartErrMsg.BringToFront();
                                //lblChartErrMsg.Text = "Data not available / Something went wrong";

                            }
                        }

                        if (chkbxControlChart.Checked == true)
                        {
                            if (dsChartData.Tables.Count == 3) //dsChartData.Tables.Count > 0
                            {

                                dtConfig = dsChartData.Tables[0];
                                dtReadingsAll = dsChartData.Tables[1];
                                dtActualTable = dsChartData.Tables[2];

                                if (dtReadingsAll.Rows.Count > 0)
                                {
                                    //X-Bar Chart
                                    DataRow[] selectedRows = dtConfig.Select("Key = 'XUL' and CharacteristicsId = " + castedItem[0]);
                                    if(selectedRows.Length == 0 )
                                    {
                                        break;
                                    }
                                    xUL = Convert.ToDouble(selectedRows[0]["Value"]);
                                    DataRow[] selectedRows1 = dtConfig.Select("Key = 'XM' and CharacteristicsId = " + castedItem[0]);
                                    xM = Convert.ToDouble(selectedRows1[0]["Value"]);
                                    DataRow[] selectedRows2 = dtConfig.Select("Key = 'XLL' and CharacteristicsId = " + castedItem[0]);
                                    xLL = Convert.ToDouble(selectedRows2[0]["Value"]);

                                    //x_xAxisMaxLength = dtReadings.Rows.Count; Commented by Aamir - 03/11/2022
                                    DataRow[] rowCount = dtReadingsAll.Select("CharacterID = " + castedItem[0]);

                                    x_xAxisMaxLength = rowCount.Length;

                                    dtReadings = rowCount.CopyToDataTable();

                                    DataRow[] selectedRows21 = dtConfig.Select("Key = 'minreadingx' and CharacteristicsId = " + castedItem[0]);
                                    xMinReading = Convert.ToDouble(selectedRows21[0]["Value"]);
                                    DataRow[] selectedRows22 = dtConfig.Select("Key = 'maxreadingx' and CharacteristicsId = " + castedItem[0]);
                                    xMaxReading = Convert.ToDouble(selectedRows22[0]["Value"]);

                                    DataRow[] selectedRows23 = dtConfig.Select("Key = 'Cp' and CharacteristicsId = " + castedItem[0]); //TODO
                                    lblCPData.Text = selectedRows23[0]["Value"].ToString();
                                    DataRow[] selectedRows24 = dtConfig.Select("Key = 'Cpk' and CharacteristicsId = " + castedItem[0]);
                                    lblCPKData.Text = selectedRows24[0]["Value"].ToString();

                                    //Aamir - 03/10/2022
                                    // DataRow[] selectedRows231 = dtConfig.Select("Key = 'CpM' and CharacteristicsId = " + castedItem[0]);
                                    //// lblCPMData.Text = selectedRows231[0]["Value"].ToString();
                                    // DataRow[] selectedRows241 = dtConfig.Select("Key = 'CpkM' and CharacteristicsId = " + castedItem[0]);
                                    // lblCPKMData.Text = selectedRows241[0]["Value"].ToString();
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

                                    DataRow[] selectedRows3 = dtConfig.Select("Key = 'RUL' and CharacteristicsId = " + castedItem[0]);
                                    rUL = Convert.ToDouble(selectedRows3[0]["Value"]);
                                    //rUL.ToString("0.0000");
                                    DataRow[] selectedRows4 = dtConfig.Select("Key = 'RM' and CharacteristicsId =" + castedItem[0]);
                                    rM = Convert.ToDouble(selectedRows4[0]["Value"]);
                                    DataRow[] selectedRows5 = dtConfig.Select("Key = 'RLL' and CharacteristicsId =" + castedItem[0]);
                                    rLL = Convert.ToDouble(selectedRows5[0]["Value"]);
                                    //  r_xAxisMaxLength = dtReadings.Rows.Count;
                                    DataRow[] rowCountR = dtReadingsAll.Select("CharacterID = " + castedItem[0]);

                                    r_xAxisMaxLength = rowCount.Length;

                                    dtReadings = rowCountR.CopyToDataTable();


                                    DataRow[] selectedRows51 = dtConfig.Select("Key = 'minreadingR' and CharacteristicsId = " + castedItem[0]);
                                    rMinReading = Convert.ToDouble(selectedRows51[0]["Value"]);
                                    DataRow[] selectedRows52 = dtConfig.Select("Key = 'maxreadingR' and CharacteristicsId = " + castedItem[0]);
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
                                    //lblChartErrMsg.Visible = true;
                                    //lblChartErrMsg.Text = "Data not available / Something went wrong";
                                }
                            }


                            else
                            {
                                //lblChartErrMsg.Visible = true;
                                //lblChartErrMsg.Text = "Data not available / Something went wrong";
                            }
                        }

                        // tabPage.Controls.Add(btn);
                        tabPage.Controls.Add(lblCPHdr);
                        tabPage.Controls.Add(lblCPData);
                        tabPage.Controls.Add(lblCPKHdr);
                        tabPage.Controls.Add(lblCPKData);
                        tabPage.Controls.Add(chart1); //chart1 
                        dynamicTabControl.TabPages.Add(tabPage);
                        dynamicTabControl.BringToFront();



                        counter++;
                    }


                } //charCount == 0

                else
                {
                    int counter = 0;
                    foreach (object item in chklstbxChar.CheckedItems) //chklstbxChar.CheckedItems
                    {
                        //mdiform.lblTimer.Visible = true;
                        //mdiform.lblTimer.BringToFront();
                        mdiform.progressBar1.Maximum = this.chklstbxChar.Items.Count;
                        mdiform.progressBar1.Value = counter + 1;

                        DataRowView castedItem = item as DataRowView;
                        TabPage tabPage = new TabPage();
                        //  {
                        tabPage.Name = "Tabpage" + counter.ToString();
                        tabPage.Text = castedItem[1].ToString();  //"Tabpage" + i.ToString
                        tabPage.AutoScroll = true;
                        tabPage.Width = 1850;
                        tabPage.Height = 900;
                        // tabPage.BackColor = Color.SkyBlue;

                        //};// Create Button
                        //Button btn = new Button();
                        //btn.Name = "btnButton";
                        //btn.Text = "Dynamic Button";
                        //btn.BackColor = Color.SeaGreen;
                        //btn.Size = new Size(100, 100);
                        //btn.Location = new Point(10, 10);
                        //tabPage.Controls.Add(btn);


                        Label lblCPHdr = new Label();
                        lblCPHdr.Name = "lblCPHdr";
                        lblCPHdr.Text = "Cp = ";
                        lblCPHdr.Size = new Size(30, 30);
                        lblCPHdr.BackColor = Color.GreenYellow;
                        lblCPHdr.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPHdr.Location = new Point(850, 1); //10, 15  //10, 10

                        Label lblCPData = new Label();
                        lblCPData.Name = "lblCPData";
                        lblCPData.Text = ""; //1.67
                        lblCPData.Size = new Size(40, 30);
                        lblCPData.BackColor = Color.GreenYellow;
                        lblCPData.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPData.Location = new Point(890, 1); //10, 60 //55, 10

                        Label lblCPKHdr = new Label();
                        lblCPKHdr.Name = "lblCPKHdr";
                        lblCPKHdr.Text = "Cpk = ";
                        lblCPKHdr.Size = new Size(40, 30);
                        lblCPKHdr.BackColor = Color.GreenYellow;
                        lblCPKHdr.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPKHdr.Location = new Point(950, 1); //10, 105 //100, 10

                        Label lblCPKData = new Label();
                        lblCPKData.Name = "lblCPKData";
                        lblCPKData.Text = ""; //1.09
                        lblCPKData.Size = new Size(40, 30);
                        lblCPKData.BackColor = Color.GreenYellow;
                        lblCPKData.Font = new System.Drawing.Font("Calibri", 14F, FontStyle.Bold);
                        lblCPKData.Location = new Point(1000, 1); //10, 150  //145, 10

                        chart1 = new Chart();
                        chart1.Width = 1850; // 650 1350
                        chart1.Height = 850; // 450 600
                                             // chart1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;

                        ////Prepare Chart
                        //dsChartData = GetChartData();

                        if (chkbxRunChart.Checked == true)
                        {
                            if (dsChartData.Tables.Count == 3) //dsChartData.Tables.Count > 0
                            {

                                dtConfig = dsChartData.Tables[0];
                                dtReadingsAll= dsChartData.Tables[1];
                                dtActualTable = dsChartData.Tables[2];

                                if (dtReadingsAll.Rows.Count > 0)
                                {
                                    //X-Bar Chart
                                    DataRow[] selectedRows = dtConfig.Select("Key = 'UL' and CharacteristicsId = " + castedItem[0]);
                                    xUL = Convert.ToDouble(selectedRows[0]["Value"]);
                                    DataRow[] selectedRows1 = dtConfig.Select("Key = 'M' and CharacteristicsId = " + castedItem[0]);
                                    xM = Convert.ToDouble(selectedRows1[0]["Value"]);
                                    DataRow[] selectedRows2 = dtConfig.Select("Key = 'LL' and CharacteristicsId = " + castedItem[0]);
                                    xLL = Convert.ToDouble(selectedRows2[0]["Value"]);
                                    //  x_xAxisMaxLength = dtReadings.Rows.Count;
                                    DataRow[] rowCount = dtReadingsAll.Select("CharacterID = " + castedItem[0]);

                                    x_xAxisMaxLength = rowCount.Length;

                                    dtReadings = rowCount.CopyToDataTable();

                                    DataRow[] selectedRows21 = dtConfig.Select("Key = 'LLTH' and CharacteristicsId = " + castedItem[0]);
                                    xMinReading = Convert.ToDouble(selectedRows21[0]["Value"]);
                                    DataRow[] selectedRows22 = dtConfig.Select("Key = 'ULTH' and CharacteristicsId = " + castedItem[0]);
                                    xMaxReading = Convert.ToDouble(selectedRows22[0]["Value"]);

                                    //DataRow[] selectedRows23 = dtConfig.Select("Key = 'Cp' and CharacteristicsId = " + castedItem[0]); //TODO - Aamir - 13/09/22
                                    //                                                                                                   //   lblCPData.Text = selectedRows23[0]["Value"].ToString();
                                    //DataRow[] selectedRows24 = dtConfig.Select("Key = 'Cpk' and CharacteristicsId = " + castedItem[0]);
                                    ////   lblCPKData.Text = selectedRows24[0]["Value"].ToString();

                                    ////Aamir - 03/10/2022
                                    //DataRow[] selectedRows231 = dtConfig.Select("Key = 'CpM' and CharacteristicsId = " + castedItem[0]); //TODO - Aamir - 13/09/22
                                    //                                                                                                     //     lblCPMData.Text = selectedRows231[0]["Value"].ToString();
                                    //DataRow[] selectedRows241 = dtConfig.Select("Key = 'CpkM' and CharacteristicsId = " + castedItem[0]);
                                    ////    lblCPKMData.Text = selectedRows241[0]["Value"].ToString();
                                    //Aamir - 03/10/2022

                                    DataRow[] selectedRows25 = dtConfig.Select("Key = 'UCL' and CharacteristicsId = " + castedItem[0]);
                                    xUCL = Convert.ToDouble(selectedRows25[0]["Value"]);
                                    DataRow[] selectedRows26 = dtConfig.Select("Key = 'LCL' and CharacteristicsId = " + castedItem[0]);
                                    xLCL = Convert.ToDouble(selectedRows26[0]["Value"]);

                                    runChart();

                                }
                                else
                                {
                                    //lblChartErrMsg.Visible = true;
                                    //lblChartErrMsg.BringToFront();
                                    //lblChartErrMsg.Text = "Data not available / Something went wrong";

                                }
                            }


                            else
                            {
                                //lblChartErrMsg.Visible = true;
                                //lblChartErrMsg.BringToFront();
                                //lblChartErrMsg.Text = "Data not available / Something went wrong";

                            }
                        }

                        if (chkbxControlChart.Checked == true)
                        {
                            if (dsChartData.Tables.Count == 3) //dsChartData.Tables.Count > 0
                            {

                                dtConfig = dsChartData.Tables[0];
                                dtReadingsAll = dsChartData.Tables[1];
                                dtActualTable = dsChartData.Tables[2];

                                if (dtReadingsAll.Rows.Count > 0)
                                {
                                    //X-Bar Chart
                                    DataRow[] selectedRows = dtConfig.Select("Key = 'XUL' and CharacteristicsId = " + castedItem[0]);
                                    xUL = Convert.ToDouble(selectedRows[0]["Value"]);
                                    DataRow[] selectedRows1 = dtConfig.Select("Key = 'XM' and CharacteristicsId = " + castedItem[0]);
                                    xM = Convert.ToDouble(selectedRows1[0]["Value"]);
                                    DataRow[] selectedRows2 = dtConfig.Select("Key = 'XLL' and CharacteristicsId = " + castedItem[0]);
                                    xLL = Convert.ToDouble(selectedRows2[0]["Value"]);
                                    // x_xAxisMaxLength = dtReadings.Rows.Count; //Commented by Aamir - 03/11/2022
                                    DataRow[] rowCount = dtReadingsAll.Select("CharacterID = " + castedItem[0]);

                                    x_xAxisMaxLength = rowCount.Length;

                                    dtReadings = rowCount.CopyToDataTable();

                                    DataRow[] selectedRows21 = dtConfig.Select("Key = 'minreadingx' and CharacteristicsId = " + castedItem[0]);
                                    xMinReading = Convert.ToDouble(selectedRows21[0]["Value"]);
                                    DataRow[] selectedRows22 = dtConfig.Select("Key = 'maxreadingx' and CharacteristicsId = " + castedItem[0]);
                                    xMaxReading = Convert.ToDouble(selectedRows22[0]["Value"]);

                                    DataRow[] selectedRows23 = dtConfig.Select("Key = 'Cp' and CharacteristicsId = " + castedItem[0]);
                                    lblCPData.Text = selectedRows23[0]["Value"].ToString();
                                    DataRow[] selectedRows24 = dtConfig.Select("Key = 'Cpk' and CharacteristicsId = " + castedItem[0]);
                                    lblCPKData.Text = selectedRows24[0]["Value"].ToString();

                                    ////Aamir - 03/10/2022
                                    //DataRow[] selectedRows231 = dtConfig.Select("Key = 'CpM' and CharacteristicsId = " + castedItem[0]);
                                    //// lblCPMData.Text = selectedRows231[0]["Value"].ToString();
                                    //DataRow[] selectedRows241 = dtConfig.Select("Key = 'CpkM' and CharacteristicsId = " + castedItem[0]);
                                    //// lblCPKMData.Text = selectedRows241[0]["Value"].ToString();
                                    ////Aamir - 03/10/2022

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

                                    DataRow[] selectedRows3 = dtConfig.Select("Key = 'RUL' and CharacteristicsId = " + castedItem[0]);
                                    rUL = Convert.ToDouble(selectedRows3[0]["Value"]);
                                    //rUL.ToString("0.0000");
                                    DataRow[] selectedRows4 = dtConfig.Select("Key = 'RM' and CharacteristicsId =" + castedItem[0]);
                                    rM = Convert.ToDouble(selectedRows4[0]["Value"]);
                                    DataRow[] selectedRows5 = dtConfig.Select("Key = 'RLL' and CharacteristicsId =" + castedItem[0]);
                                    rLL = Convert.ToDouble(selectedRows5[0]["Value"]);
                                    //  r_xAxisMaxLength = dtReadings.Rows.Count;

                                    DataRow[] rowCountR = dtReadingsAll.Select("CharacterID = " + castedItem[0]);

                                    r_xAxisMaxLength = rowCount.Length;

                                    dtReadings = rowCountR.CopyToDataTable();

                                    DataRow[] selectedRows51 = dtConfig.Select("Key = 'minreadingR' and CharacteristicsId = " + castedItem[0]);
                                    rMinReading = Convert.ToDouble(selectedRows51[0]["Value"]);
                                    DataRow[] selectedRows52 = dtConfig.Select("Key = 'maxreadingR' and CharacteristicsId = " + castedItem[0]);
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
                                    //lblChartErrMsg.Visible = true;
                                    //lblChartErrMsg.Text = "Data not available / Something went wrong";
                                }
                            }


                            else
                            {
                                //lblChartErrMsg.Visible = true;
                                //lblChartErrMsg.Text = "Data not available / Something went wrong";
                            }
                        }
                        tabPage.Controls.Add(lblCPHdr);
                        tabPage.Controls.Add(lblCPData);
                        tabPage.Controls.Add(lblCPKHdr);
                        tabPage.Controls.Add(lblCPKData);
                        tabPage.Controls.Add(chart1); //chart1 
                        dynamicTabControl.TabPages.Add(tabPage);
                        dynamicTabControl.BringToFront();



                        counter++;
                    }

                }
                //CHARACTERISTICS - END

                mdiform.progressBar1.Visible = false;

                pnlChartView.Visible = true;
                pnlChartView.BringToFront();
                pnlChartView.AutoScroll = true;
                pnlChartView.Location = new Point(-6, 30); //(-6, -1)
                pnlChartView.Size = new Size(1900, 950); //1913, 922 1370, 772      1470, 772
                btnBack1.Visible = true;
                //   btnBack1.Location = new Point(-6, -25);
            }

        }           
        private DataSet GetChartData()
        {
            int chartTypeID = 0;
            int controlLimitOption = 0;
            
            if (chkbxControlChart.Checked   == true)
            {
                chartTypeID = 2; // Control Chart
            }
            else
            {
                chartTypeID = 1; //Run Chart
            }
            
            //if (lblControlLinit.Visible == true)
            //{
            //    if (rdbPastPeriod.Checked == true)
            //    {
            //        controlLimitOption = 0;
            //    }
            //    else
            //    {
            //        controlLimitOption = 1;
            //    }
            //}
            //else
            //{
            //    controlLimitOption = 0;
            //}



            SqlParameter outParam_1 = new SqlParameter();
            outParam_1.ParameterName = "@Message";
            outParam_1.SqlDbType = SqlDbType.VarChar;
            outParam_1.Size = 100;
            outParam_1.Direction = ParameterDirection.Output;

            SqlParameter[] parameters =
            {
                new SqlParameter {ParameterName = "@Login_id",SqlDbType=SqlDbType.NVarChar,Size = 100, Value = Program.userID.ToString()},
                new SqlParameter{ParameterName = "@StationID",SqlDbType = SqlDbType.Int, Value = Program.stationID } ,
                new SqlParameter{ParameterName = "@TemplateId", SqlDbType =  SqlDbType.Int, Value =  cmbTemplate.SelectedValue }, //TODO cmbTemplate.SelectedValue
                new SqlParameter{ParameterName = "@MachineId", SqlDbType =  SqlDbType.Int, Value = cmbMachineNo.SelectedValue}, //TODO  cmbMachineNo.SelectedValue //cmbMachineNo.SelectedValue == null ? 0 : cmbMachineNo.SelectedValue
               new SqlParameter{ParameterName = "@Pallete", SqlDbType =  SqlDbType.VarChar,Size = 20, Value = palletes },  //TODO "A,B" palletes
                new SqlParameter{ParameterName = "@CharacteristicsIds", SqlDbType =  SqlDbType.VarChar,Size=500, Value = charIDs}, //1,2 //TODO
                new SqlParameter{ParameterName = "@DateRangeType", SqlDbType =  SqlDbType.VarChar,Size=20, Value = cmbDateRange.SelectedItem },  //TODO  cmbDateRange.SelectedText "Previous Month" 
           
                new SqlParameter { ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = (cmbDateRange.SelectedItem.ToString() == "Custom Period") ? dtpFromDate.Value.ToString("yyyy-MM-dd") :  "" }, //TODO   dtpFromDate.Value
                new SqlParameter { ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = (cmbDateRange.SelectedItem.ToString() == "Custom Period") ?  dtpToDate.Value.ToString("yyyy-MM-dd") : ""} , //TODO    dtpToDate.Value 

                //new SqlParameter { ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = "2022-04-01" }, //TODO   dtpFromDate.Value
                //new SqlParameter { ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = "2022-04-31"} , //TODO    dtpToDate.Value 
                
                new SqlParameter{ParameterName = "@Shift1", SqlDbType =  SqlDbType.Bit, Value =  chkbxFirstShift.Checked ? 1 : 0}, //TODO 1 chkbxFirstShift.Checked chkbxFirstShift.Checked ? 1 : 0
                new SqlParameter{ParameterName = "@Shift2", SqlDbType =  SqlDbType.Bit, Value =  chkbxSecondShift.Checked ? 1 : 0}, //TODO 1  chkbxSecondShift.Checked
                new SqlParameter{ParameterName = "@Shift3", SqlDbType =  SqlDbType.Bit, Value = chkbxThirdShift.Checked ? 1 : 0}, //TODO 1 chkbxThirdShift.Checked
                new SqlParameter{ParameterName = "@ChartTypeID", SqlDbType =  SqlDbType.Int, Value = chartTypeID}, //TODO chartTypeID

                new SqlParameter{ParameterName = "@Subgroup", SqlDbType =  SqlDbType.Int, Value =4}, //TODO cmbSubGroupSize.SelectedValue} cmbSubGroupSize.SelectedValue == null ? 0 :  cmbSubGroupSize.SelectedValue
                new SqlParameter{ParameterName = "@EventIds", SqlDbType =  SqlDbType.VarChar,Size=500, Value = eventIDs}, //TODO

                new SqlParameter{ParameterName = "@ControlLimitOption", SqlDbType =  SqlDbType.Int, Value = 0},  //TODO controlLimitOption
                new SqlParameter{ParameterName = "@ExportOptionIds", SqlDbType =  SqlDbType.VarChar, Size=500,Value = "" },
                outParam_1,
            };

            //controlChartClicked = 0;

            return CommonBL.GetTemplateQueueData("sp_GetChartData", parameters); //sp_GetChartData
          

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
                BackColor = Color.FromArgb(250, 80, 80),
                IntervalOffset = xMinReading, // This is where the stripline starts
                StripWidth = xLL - xMinReading // And this is how long the interval is
            };
            var stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine()
            {
                BackColor = Color.FromArgb(241, 235, 156),
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
                series1.Points[x1].ToolTip = "#VALY\n" + eventDesc[x1];
                x1++;

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
            chartArea.AxisY.CustomLabels.Add(xUL - 0.0001, xUL, xUL.ToString("0.0000"), 0, LabelMarkStyle.None, GridTickTypes.Gridline); //None

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
            chartArea.AxisY2.CustomLabels.Add(xM - 0.0001, xM + 0.0001, "Mean", 0, LabelMarkStyle.None, GridTickTypes.None);
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
                errorProvider1.SetError(cmbMachineNo, "Please select Machine");
                ret = false;
            }

            if (cmbDateRange.Text == "")
            {
                errorProvider1.SetError(cmbDateRange, "Please select Date Range");
                ret = false;
            }

            if (chkbxRunChart.Checked == false && chkbxControlChart.Checked == false )
            {
                errorProvider1.SetError(chkbxRunChart, "Please select Chart Type");
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
        private DataTable GetDataTable()
        {
            int chartTypeID = 0;
            int controlLimitOption = 0;

            if (chkbxControlChart.Checked == true)
            {
                chartTypeID = 2; // Control Chart
            }
            else
            {
                chartTypeID = 1; //Run Chart
            }

            //if (lblControlLinit.Visible == true)
            //{
            //    if (rdbPastPeriod.Checked == true)
            //    {
            //        controlLimitOption = 0;
            //    }
            //    else
            //    {
            //        controlLimitOption = 1;
            //    }
            //}
            //else
            //{
            //    controlLimitOption = 0;
            //}



            //SqlParameter outParam_1 = new SqlParameter();
            //outParam_1.ParameterName = "@Message";
            //outParam_1.SqlDbType = SqlDbType.VarChar;
            //outParam_1.Size = 100;
            //outParam_1.Direction = ParameterDirection.Output;

            SqlParameter[] parameters =
            {
                new SqlParameter {ParameterName = "@Login_id",SqlDbType=SqlDbType.NVarChar,Size = 100, Value = Program.userID.ToString()},
                new SqlParameter{ParameterName = "@StationId",SqlDbType = SqlDbType.Int, Value = Program.stationID } ,
                new SqlParameter{ParameterName = "@TemplateId", SqlDbType =  SqlDbType.Int, Value =  cmbTemplate.SelectedValue }, //TODO cmbTemplate.SelectedValue
                new SqlParameter{ParameterName = "@MachineId", SqlDbType =  SqlDbType.Int, Value = cmbMachineNo.SelectedValue}, //TODO  cmbMachineNo.SelectedValue //cmbMachineNo.SelectedValue == null ? 0 : cmbMachineNo.SelectedValue
               new SqlParameter{ParameterName = "@Pallete", SqlDbType =  SqlDbType.VarChar,Size = 20, Value = palletes },  //TODO "A,B" palletes
                new SqlParameter{ParameterName = "@CharacteristicsIds", SqlDbType =  SqlDbType.VarChar,Size=500, Value = charIDs}, //1,2 //TODO
                new SqlParameter{ParameterName = "@DateRangeType", SqlDbType =  SqlDbType.VarChar,Size=20, Value = cmbDateRange.SelectedItem },  //TODO  cmbDateRange.SelectedText "Previous Month" 
           
                new SqlParameter { ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = (cmbDateRange.SelectedItem.ToString() == "Custom Period") ? dtpFromDate.Value.ToString("yyyy-MM-dd") :  "" }, //TODO   dtpFromDate.Value
                new SqlParameter { ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = (cmbDateRange.SelectedItem.ToString() == "Custom Period") ?  dtpToDate.Value.ToString("yyyy-MM-dd") : ""} , //TODO    dtpToDate.Value 

                //new SqlParameter { ParameterName = "@FromDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = "2022-04-01" }, //TODO   dtpFromDate.Value
                //new SqlParameter { ParameterName = "@ToDate", SqlDbType = SqlDbType.VarChar, Size = 10, Value = "2022-04-31"} , //TODO    dtpToDate.Value 
                
                new SqlParameter{ParameterName = "@Shift1", SqlDbType =  SqlDbType.Bit, Value =  chkbxFirstShift.Checked ? 1 : 0}, //TODO 1 chkbxFirstShift.Checked chkbxFirstShift.Checked ? 1 : 0
                new SqlParameter{ParameterName = "@Shift2", SqlDbType =  SqlDbType.Bit, Value =  chkbxSecondShift.Checked ? 1 : 0}, //TODO 1  chkbxSecondShift.Checked
                new SqlParameter{ParameterName = "@Shift3", SqlDbType =  SqlDbType.Bit, Value = chkbxThirdShift.Checked ? 1 : 0}, //TODO 1 chkbxThirdShift.Checked
                new SqlParameter{ParameterName = "@ChartTypeID", SqlDbType =  SqlDbType.Int, Value = chartTypeID}, //TODO chartTypeID

                new SqlParameter{ParameterName = "@Subgroup", SqlDbType =  SqlDbType.Int, Value =4}, //TODO cmbSubGroupSize.SelectedValue} cmbSubGroupSize.SelectedValue == null ? 0 :  cmbSubGroupSize.SelectedValue
                new SqlParameter{ParameterName = "@EventIds", SqlDbType =  SqlDbType.VarChar,Size=500, Value = eventIDs}, //TODO

                new SqlParameter{ParameterName = "@ControlLimitOption", SqlDbType =  SqlDbType.Int, Value = 0},  //TODO controlLimitOption
                new SqlParameter{ParameterName = "@ExportOptionIds", SqlDbType =  SqlDbType.VarChar, Size=500,Value = "" },
                //outParam_1,
            };

            //controlChartClicked = 0;

            return CommonBL.GetDataTable("sp_GetChartData_Export", parameters); //sp_GetChartData
           
        }
    }
}
