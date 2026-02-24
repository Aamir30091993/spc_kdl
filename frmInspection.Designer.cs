namespace SPC_KDL
{
    partial class frmInspection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInspection));
            this.flowLayoutPanelTemplate = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTemplateHeading = new System.Windows.Forms.Label();
            this.flowLayoutPanelQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNothingPendingQueue = new System.Windows.Forms.Label();
            this.lblQueueHeading = new System.Windows.Forms.Label();
            this.flowLayoutPanelChar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPartNoHeading = new System.Windows.Forms.Label();
            this.lblPartNo = new System.Windows.Forms.Label();
            this.lblCharacteristicHeading = new System.Windows.Forms.Label();
            this.lblCharacteristic = new System.Windows.Forms.Label();
            this.lblGaugeSourceHeading = new System.Windows.Forms.Label();
            this.lblGaugeSource = new System.Windows.Forms.Label();
            this.lblQueueCount = new System.Windows.Forms.Label();
            this.pnlChartDatatable = new System.Windows.Forms.Panel();
            this.lblChartErrMsg = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvDatatable = new System.Windows.Forms.DataGridView();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.pnlDatatable = new System.Windows.Forms.Panel();
            this.pbDatatable = new System.Windows.Forms.PictureBox();
            this.lblCPHdr = new System.Windows.Forms.Label();
            this.lblCPKHdr = new System.Windows.Forms.Label();
            this.lblCPData = new System.Windows.Forms.Label();
            this.lblCPKData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInspectionCharCountHdr = new System.Windows.Forms.Label();
            this.lbllnspectionCharCountData = new System.Windows.Forms.Label();
            this.pbChart = new System.Windows.Forms.PictureBox();
            this.pbPMCChart = new System.Windows.Forms.PictureBox();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.pbCPK = new System.Windows.Forms.PictureBox();
            this.pbPartImage = new System.Windows.Forms.PictureBox();
            this.lblCPKMData = new System.Windows.Forms.Label();
            this.lblCPMData = new System.Windows.Forms.Label();
            this.lblCPKMHdr = new System.Windows.Forms.Label();
            this.lblCPMHdr = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkMasterSize = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblMachineID1 = new System.Windows.Forms.Label();
            this.lblMachineID2 = new System.Windows.Forms.Label();
            this.lblMachineID3 = new System.Windows.Forms.Label();
            this.lblMachineID4 = new System.Windows.Forms.Label();
            this.flowLayoutPanelQueue.SuspendLayout();
            this.pnlChartDatatable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatatable)).BeginInit();
            this.pnlDatatable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDatatable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPMCChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCPK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPartImage)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelTemplate
            // 
            this.flowLayoutPanelTemplate.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelTemplate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTemplate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelTemplate.Location = new System.Drawing.Point(11, 132);
            this.flowLayoutPanelTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelTemplate.Name = "flowLayoutPanelTemplate";
            this.flowLayoutPanelTemplate.Size = new System.Drawing.Size(273, 280);
            this.flowLayoutPanelTemplate.TabIndex = 7;
            this.flowLayoutPanelTemplate.WrapContents = false;
            // 
            // lblTemplateHeading
            // 
            this.lblTemplateHeading.AutoSize = true;
            this.lblTemplateHeading.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateHeading.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTemplateHeading.Location = new System.Drawing.Point(7, 97);
            this.lblTemplateHeading.Name = "lblTemplateHeading";
            this.lblTemplateHeading.Size = new System.Drawing.Size(90, 26);
            this.lblTemplateHeading.TabIndex = 8;
            this.lblTemplateHeading.Text = "Template";
            // 
            // flowLayoutPanelQueue
            // 
            this.flowLayoutPanelQueue.AutoScrollMargin = new System.Drawing.Size(1, 0);
            this.flowLayoutPanelQueue.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelQueue.Controls.Add(this.lblNothingPendingQueue);
            this.flowLayoutPanelQueue.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelQueue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelQueue.Location = new System.Drawing.Point(11, 464);
            this.flowLayoutPanelQueue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelQueue.Name = "flowLayoutPanelQueue";
            this.flowLayoutPanelQueue.Size = new System.Drawing.Size(273, 560);
            this.flowLayoutPanelQueue.TabIndex = 9;
            this.flowLayoutPanelQueue.WrapContents = false;
            // 
            // lblNothingPendingQueue
            // 
            this.lblNothingPendingQueue.AutoSize = true;
            this.lblNothingPendingQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNothingPendingQueue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNothingPendingQueue.ForeColor = System.Drawing.Color.Red;
            this.lblNothingPendingQueue.Location = new System.Drawing.Point(3, 0);
            this.lblNothingPendingQueue.Name = "lblNothingPendingQueue";
            this.lblNothingPendingQueue.Size = new System.Drawing.Size(235, 19);
            this.lblNothingPendingQueue.TabIndex = 8;
            this.lblNothingPendingQueue.Text = "Nothing Pending for Inspection...";
            // 
            // lblQueueHeading
            // 
            this.lblQueueHeading.AutoSize = true;
            this.lblQueueHeading.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueueHeading.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblQueueHeading.Location = new System.Drawing.Point(7, 430);
            this.lblQueueHeading.Name = "lblQueueHeading";
            this.lblQueueHeading.Size = new System.Drawing.Size(68, 26);
            this.lblQueueHeading.TabIndex = 10;
            this.lblQueueHeading.Text = "Queue";
            // 
            // flowLayoutPanelChar
            // 
            this.flowLayoutPanelChar.AutoScroll = true;
            this.flowLayoutPanelChar.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelChar.Location = new System.Drawing.Point(290, 630);
            this.flowLayoutPanelChar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelChar.Name = "flowLayoutPanelChar";
            this.flowLayoutPanelChar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanelChar.Size = new System.Drawing.Size(1607, 395);
            this.flowLayoutPanelChar.TabIndex = 1;
            this.flowLayoutPanelChar.WrapContents = false;
            this.flowLayoutPanelChar.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelChar_Paint);
            // 
            // lblPartNoHeading
            // 
            this.lblPartNoHeading.AutoSize = true;
            this.lblPartNoHeading.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNoHeading.Location = new System.Drawing.Point(308, 77);
            this.lblPartNoHeading.Name = "lblPartNoHeading";
            this.lblPartNoHeading.Size = new System.Drawing.Size(57, 19);
            this.lblPartNoHeading.TabIndex = 12;
            this.lblPartNoHeading.Text = "Part No";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.BackColor = System.Drawing.Color.GreenYellow;
            this.lblPartNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNo.Location = new System.Drawing.Point(323, 100);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(0, 19);
            this.lblPartNo.TabIndex = 13;
            // 
            // lblCharacteristicHeading
            // 
            this.lblCharacteristicHeading.AutoSize = true;
            this.lblCharacteristicHeading.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacteristicHeading.Location = new System.Drawing.Point(677, 77);
            this.lblCharacteristicHeading.Name = "lblCharacteristicHeading";
            this.lblCharacteristicHeading.Size = new System.Drawing.Size(99, 19);
            this.lblCharacteristicHeading.TabIndex = 14;
            this.lblCharacteristicHeading.Text = "Characteristic";
            // 
            // lblCharacteristic
            // 
            this.lblCharacteristic.AutoSize = true;
            this.lblCharacteristic.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacteristic.Location = new System.Drawing.Point(670, 100);
            this.lblCharacteristic.Name = "lblCharacteristic";
            this.lblCharacteristic.Size = new System.Drawing.Size(0, 19);
            this.lblCharacteristic.TabIndex = 15;
            // 
            // lblGaugeSourceHeading
            // 
            this.lblGaugeSourceHeading.AutoSize = true;
            this.lblGaugeSourceHeading.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGaugeSourceHeading.Location = new System.Drawing.Point(966, 78);
            this.lblGaugeSourceHeading.Name = "lblGaugeSourceHeading";
            this.lblGaugeSourceHeading.Size = new System.Drawing.Size(98, 19);
            this.lblGaugeSourceHeading.TabIndex = 16;
            this.lblGaugeSourceHeading.Text = "Gauge Source";
            // 
            // lblGaugeSource
            // 
            this.lblGaugeSource.AutoSize = true;
            this.lblGaugeSource.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGaugeSource.Location = new System.Drawing.Point(966, 101);
            this.lblGaugeSource.Name = "lblGaugeSource";
            this.lblGaugeSource.Size = new System.Drawing.Size(0, 19);
            this.lblGaugeSource.TabIndex = 17;
            // 
            // lblQueueCount
            // 
            this.lblQueueCount.AutoSize = true;
            this.lblQueueCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQueueCount.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblQueueCount.Location = new System.Drawing.Point(254, 435);
            this.lblQueueCount.Name = "lblQueueCount";
            this.lblQueueCount.Size = new System.Drawing.Size(2, 25);
            this.lblQueueCount.TabIndex = 19;
            this.lblQueueCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlChartDatatable
            // 
            this.pnlChartDatatable.BackColor = System.Drawing.Color.White;
            this.pnlChartDatatable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartDatatable.Controls.Add(this.lblChartErrMsg);
            this.pnlChartDatatable.Controls.Add(this.chart1);
            this.pnlChartDatatable.Controls.Add(this.dgvDatatable);
            this.pnlChartDatatable.Location = new System.Drawing.Point(913, 133);
            this.pnlChartDatatable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChartDatatable.Name = "pnlChartDatatable";
            this.pnlChartDatatable.Size = new System.Drawing.Size(984, 487);
            this.pnlChartDatatable.TabIndex = 20;
            // 
            // lblChartErrMsg
            // 
            this.lblChartErrMsg.AutoSize = true;
            this.lblChartErrMsg.ForeColor = System.Drawing.Color.Red;
            this.lblChartErrMsg.Location = new System.Drawing.Point(187, 216);
            this.lblChartErrMsg.Name = "lblChartErrMsg";
            this.lblChartErrMsg.Size = new System.Drawing.Size(0, 23);
            this.lblChartErrMsg.TabIndex = 2;
            this.lblChartErrMsg.Visible = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(18, 3);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(939, 440);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // dgvDatatable
            // 
            this.dgvDatatable.AllowUserToAddRows = false;
            this.dgvDatatable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgvDatatable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatatable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatatable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDatatable.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatatable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatatable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvDatatable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvDatatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatatable.Location = new System.Drawing.Point(5, 4);
            this.dgvDatatable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDatatable.Name = "dgvDatatable";
            this.dgvDatatable.ReadOnly = true;
            this.dgvDatatable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvDatatable.ShowEditingIcon = false;
            this.dgvDatatable.Size = new System.Drawing.Size(967, 467);
            this.dgvDatatable.TabIndex = 0;
            // 
            // pnlChart
            // 
            this.pnlChart.Location = new System.Drawing.Point(1676, 100);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(27, 24);
            this.pnlChart.TabIndex = 21;
            // 
            // pnlDatatable
            // 
            this.pnlDatatable.Controls.Add(this.pbDatatable);
            this.pnlDatatable.Location = new System.Drawing.Point(1618, 100);
            this.pnlDatatable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDatatable.Name = "pnlDatatable";
            this.pnlDatatable.Size = new System.Drawing.Size(28, 24);
            this.pnlDatatable.TabIndex = 22;
            // 
            // pbDatatable
            // 
            this.pbDatatable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDatatable.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbDatatable.Image = ((System.Drawing.Image)(resources.GetObject("pbDatatable.Image")));
            this.pbDatatable.Location = new System.Drawing.Point(0, 0);
            this.pbDatatable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbDatatable.Name = "pbDatatable";
            this.pbDatatable.Size = new System.Drawing.Size(27, 24);
            this.pbDatatable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDatatable.TabIndex = 1;
            this.pbDatatable.TabStop = false;
            this.pbDatatable.Click += new System.EventHandler(this.pbDatatable_Click);
            // 
            // lblCPHdr
            // 
            this.lblCPHdr.AutoSize = true;
            this.lblCPHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPHdr.Location = new System.Drawing.Point(1202, 77);
            this.lblCPHdr.Name = "lblCPHdr";
            this.lblCPHdr.Size = new System.Drawing.Size(26, 19);
            this.lblCPHdr.TabIndex = 23;
            this.lblCPHdr.Text = "CP";
            // 
            // lblCPKHdr
            // 
            this.lblCPKHdr.AutoSize = true;
            this.lblCPKHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPKHdr.Location = new System.Drawing.Point(1278, 77);
            this.lblCPKHdr.Name = "lblCPKHdr";
            this.lblCPKHdr.Size = new System.Drawing.Size(34, 19);
            this.lblCPKHdr.TabIndex = 24;
            this.lblCPKHdr.Text = "CPK";
            // 
            // lblCPData
            // 
            this.lblCPData.AutoSize = true;
            this.lblCPData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPData.Location = new System.Drawing.Point(1202, 100);
            this.lblCPData.Name = "lblCPData";
            this.lblCPData.Size = new System.Drawing.Size(0, 19);
            this.lblCPData.TabIndex = 25;
            // 
            // lblCPKData
            // 
            this.lblCPKData.AutoSize = true;
            this.lblCPKData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPKData.Location = new System.Drawing.Point(1274, 100);
            this.lblCPKData.Name = "lblCPKData";
            this.lblCPKData.Size = new System.Drawing.Size(0, 19);
            this.lblCPKData.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "[F8]";
            this.label1.Visible = false;
            // 
            // lblInspectionCharCountHdr
            // 
            this.lblInspectionCharCountHdr.AutoSize = true;
            this.lblInspectionCharCountHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspectionCharCountHdr.Location = new System.Drawing.Point(1746, 77);
            this.lblInspectionCharCountHdr.Name = "lblInspectionCharCountHdr";
            this.lblInspectionCharCountHdr.Size = new System.Drawing.Size(152, 19);
            this.lblInspectionCharCountHdr.TabIndex = 30;
            this.lblInspectionCharCountHdr.Text = "Inspection Char Count";
            // 
            // lbllnspectionCharCountData
            // 
            this.lbllnspectionCharCountData.AutoSize = true;
            this.lbllnspectionCharCountData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllnspectionCharCountData.Location = new System.Drawing.Point(1828, 100);
            this.lbllnspectionCharCountData.Name = "lbllnspectionCharCountData";
            this.lbllnspectionCharCountData.Size = new System.Drawing.Size(0, 19);
            this.lbllnspectionCharCountData.TabIndex = 31;
            this.lbllnspectionCharCountData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbChart
            // 
            this.pbChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChart.Image = ((System.Drawing.Image)(resources.GetObject("pbChart.Image")));
            this.pbChart.Location = new System.Drawing.Point(1676, 100);
            this.pbChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbChart.Name = "pbChart";
            this.pbChart.Size = new System.Drawing.Size(27, 24);
            this.pbChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbChart.TabIndex = 0;
            this.pbChart.TabStop = false;
            this.pbChart.Click += new System.EventHandler(this.pbChart_Click);
            // 
            // pbPMCChart
            // 
            this.pbPMCChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPMCChart.Image = ((System.Drawing.Image)(resources.GetObject("pbPMCChart.Image")));
            this.pbPMCChart.Location = new System.Drawing.Point(1647, 100);
            this.pbPMCChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbPMCChart.Name = "pbPMCChart";
            this.pbPMCChart.Size = new System.Drawing.Size(27, 24);
            this.pbPMCChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPMCChart.TabIndex = 29;
            this.pbPMCChart.TabStop = false;
            this.pbPMCChart.Click += new System.EventHandler(this.pbPMCChart_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackColor = System.Drawing.SystemColors.Control;
            this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKeyboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeyboard.Image = ((System.Drawing.Image)(resources.GetObject("btnKeyboard.Image")));
            this.btnKeyboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKeyboard.Location = new System.Drawing.Point(233, 91);
            this.btnKeyboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(52, 39);
            this.btnKeyboard.TabIndex = 18;
            this.btnKeyboard.UseVisualStyleBackColor = false;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // pbCPK
            // 
            this.pbCPK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCPK.Image = ((System.Drawing.Image)(resources.GetObject("pbCPK.Image")));
            this.pbCPK.Location = new System.Drawing.Point(952, 135);
            this.pbCPK.Margin = new System.Windows.Forms.Padding(5);
            this.pbCPK.Name = "pbCPK";
            this.pbCPK.Size = new System.Drawing.Size(739, 448);
            this.pbCPK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCPK.TabIndex = 6;
            this.pbCPK.TabStop = false;
            this.pbCPK.Visible = false;
            // 
            // pbPartImage
            // 
            this.pbPartImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPartImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPartImage.Image = global::SPC_KDL.Properties.Resources.noimageavailabe_image;
            this.pbPartImage.Location = new System.Drawing.Point(292, 133);
            this.pbPartImage.Margin = new System.Windows.Forms.Padding(5);
            this.pbPartImage.Name = "pbPartImage";
            this.pbPartImage.Size = new System.Drawing.Size(613, 487);
            this.pbPartImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPartImage.TabIndex = 0;
            this.pbPartImage.TabStop = false;
            // 
            // lblCPKMData
            // 
            this.lblCPKMData.AutoSize = true;
            this.lblCPKMData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPKMData.Location = new System.Drawing.Point(1448, 100);
            this.lblCPKMData.Name = "lblCPKMData";
            this.lblCPKMData.Size = new System.Drawing.Size(0, 19);
            this.lblCPKMData.TabIndex = 35;
            // 
            // lblCPMData
            // 
            this.lblCPMData.AutoSize = true;
            this.lblCPMData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPMData.Location = new System.Drawing.Point(1345, 100);
            this.lblCPMData.Name = "lblCPMData";
            this.lblCPMData.Size = new System.Drawing.Size(0, 19);
            this.lblCPMData.TabIndex = 34;
            // 
            // lblCPKMHdr
            // 
            this.lblCPKMHdr.AutoSize = true;
            this.lblCPKMHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPKMHdr.Location = new System.Drawing.Point(1448, 77);
            this.lblCPKMHdr.Name = "lblCPKMHdr";
            this.lblCPKMHdr.Size = new System.Drawing.Size(97, 19);
            this.lblCPKMHdr.TabIndex = 33;
            this.lblCPKMHdr.Text = "CPK(Monthly)";
            // 
            // lblCPMHdr
            // 
            this.lblCPMHdr.AutoSize = true;
            this.lblCPMHdr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPMHdr.Location = new System.Drawing.Point(1345, 77);
            this.lblCPMHdr.Name = "lblCPMHdr";
            this.lblCPMHdr.Size = new System.Drawing.Size(89, 19);
            this.lblCPMHdr.TabIndex = 32;
            this.lblCPMHdr.Text = "CP(Monthly)";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1329, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 44);
            this.panel1.TabIndex = 36;
            // 
            // chkMasterSize
            // 
            this.chkMasterSize.AutoSize = true;
            this.chkMasterSize.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMasterSize.Location = new System.Drawing.Point(1074, 76);
            this.chkMasterSize.Name = "chkMasterSize";
            this.chkMasterSize.Size = new System.Drawing.Size(103, 23);
            this.chkMasterSize.TabIndex = 38;
            this.chkMasterSize.Text = "Master Size";
            this.chkMasterSize.UseVisualStyleBackColor = true;
            this.chkMasterSize.Visible = false;
            this.chkMasterSize.CheckedChanged += new System.EventHandler(this.chkMasterSize_CheckedChanged);
            this.chkMasterSize.Click += new System.EventHandler(this.chkMasterSize_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 43);
            this.button1.TabIndex = 39;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 43);
            this.button2.TabIndex = 40;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(393, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 43);
            this.button3.TabIndex = 41;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(584, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 43);
            this.button4.TabIndex = 42;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblMachineID1
            // 
            this.lblMachineID1.AutoSize = true;
            this.lblMachineID1.Location = new System.Drawing.Point(125, 19);
            this.lblMachineID1.Name = "lblMachineID1";
            this.lblMachineID1.Size = new System.Drawing.Size(0, 23);
            this.lblMachineID1.TabIndex = 43;
            // 
            // lblMachineID2
            // 
            this.lblMachineID2.AutoSize = true;
            this.lblMachineID2.Location = new System.Drawing.Point(309, 19);
            this.lblMachineID2.Name = "lblMachineID2";
            this.lblMachineID2.Size = new System.Drawing.Size(0, 23);
            this.lblMachineID2.TabIndex = 44;
            // 
            // lblMachineID3
            // 
            this.lblMachineID3.AutoSize = true;
            this.lblMachineID3.Location = new System.Drawing.Point(509, 19);
            this.lblMachineID3.Name = "lblMachineID3";
            this.lblMachineID3.Size = new System.Drawing.Size(0, 23);
            this.lblMachineID3.TabIndex = 45;
            // 
            // lblMachineID4
            // 
            this.lblMachineID4.AutoSize = true;
            this.lblMachineID4.Location = new System.Drawing.Point(702, 19);
            this.lblMachineID4.Name = "lblMachineID4";
            this.lblMachineID4.Size = new System.Drawing.Size(0, 23);
            this.lblMachineID4.TabIndex = 46;
            // 
            // frmInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1923, 1040);
            this.ControlBox = false;
            this.Controls.Add(this.lblMachineID4);
            this.Controls.Add(this.lblMachineID3);
            this.Controls.Add(this.lblMachineID2);
            this.Controls.Add(this.lblMachineID1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkMasterSize);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCPKMData);
            this.Controls.Add(this.lblCPMData);
            this.Controls.Add(this.lblCPKMHdr);
            this.Controls.Add(this.lblCPMHdr);
            this.Controls.Add(this.lbllnspectionCharCountData);
            this.Controls.Add(this.lblInspectionCharCountHdr);
            this.Controls.Add(this.pbChart);
            this.Controls.Add(this.pbPMCChart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCPKData);
            this.Controls.Add(this.lblCPData);
            this.Controls.Add(this.lblCPKHdr);
            this.Controls.Add(this.lblCPHdr);
            this.Controls.Add(this.pnlDatatable);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlChartDatatable);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.lblQueueCount);
            this.Controls.Add(this.lblGaugeSource);
            this.Controls.Add(this.lblGaugeSourceHeading);
            this.Controls.Add(this.lblCharacteristic);
            this.Controls.Add(this.lblCharacteristicHeading);
            this.Controls.Add(this.lblPartNo);
            this.Controls.Add(this.lblPartNoHeading);
            this.Controls.Add(this.flowLayoutPanelChar);
            this.Controls.Add(this.lblQueueHeading);
            this.Controls.Add(this.flowLayoutPanelQueue);
            this.Controls.Add(this.lblTemplateHeading);
            this.Controls.Add(this.flowLayoutPanelTemplate);
            this.Controls.Add(this.pbCPK);
            this.Controls.Add(this.pbPartImage);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Inspection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInspection_FormClosed);
            this.Load += new System.EventHandler(this.frmInspection_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInspection_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmInspection_KeyUp);
            this.flowLayoutPanelQueue.ResumeLayout(false);
            this.flowLayoutPanelQueue.PerformLayout();
            this.pnlChartDatatable.ResumeLayout(false);
            this.pnlChartDatatable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatatable)).EndInit();
            this.pnlDatatable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDatatable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPMCChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCPK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPartImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPartImage;
        private System.Windows.Forms.PictureBox pbCPK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTemplate;
        private System.Windows.Forms.Label lblTemplateHeading;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelQueue;
        private System.Windows.Forms.Label lblQueueHeading;
        private System.Windows.Forms.Label lblPartNoHeading;
        private System.Windows.Forms.Label lblPartNo;
        private System.Windows.Forms.Label lblCharacteristicHeading;
        private System.Windows.Forms.Label lblCharacteristic;
        private System.Windows.Forms.Label lblGaugeSourceHeading;
        private System.Windows.Forms.Label lblGaugeSource;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChar;
        public System.Windows.Forms.Button btnKeyboard;
        public System.Windows.Forms.Label lblQueueCount;
        private System.Windows.Forms.Panel pnlChartDatatable;
        private System.Windows.Forms.DataGridView dgvDatatable;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.PictureBox pbDatatable;
        private System.Windows.Forms.PictureBox pbChart;
        private System.Windows.Forms.Panel pnlDatatable;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblCPHdr;
        private System.Windows.Forms.Label lblCPKHdr;
        private System.Windows.Forms.Label lblCPData;
        private System.Windows.Forms.Label lblCPKData;
        private System.Windows.Forms.Label lblChartErrMsg;
        private System.Windows.Forms.PictureBox pbPMCChart;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblNothingPendingQueue;
        private System.Windows.Forms.Label lblInspectionCharCountHdr;
        private System.Windows.Forms.Label lbllnspectionCharCountData;
        private System.Windows.Forms.Label lblCPKMData;
        private System.Windows.Forms.Label lblCPMData;
        private System.Windows.Forms.Label lblCPKMHdr;
        private System.Windows.Forms.Label lblCPMHdr;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox chkMasterSize;
        private System.Windows.Forms.Label lblMachineID1;
        private System.Windows.Forms.Label lblMachineID2;
        private System.Windows.Forms.Label lblMachineID3;
        private System.Windows.Forms.Label lblMachineID4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}